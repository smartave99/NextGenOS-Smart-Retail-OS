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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C4 RID: 1220
	<DesignerGenerated()>
	Public Partial Class frmEstimateRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F520 RID: 62752 RVA: 0x0006B545 File Offset: 0x00069745
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEstimateRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEstimateRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005DCC RID: 24012
		' (get) Token: 0x0600F523 RID: 62755 RVA: 0x0006B577 File Offset: 0x00069777
		' (set) Token: 0x0600F524 RID: 62756 RVA: 0x0006B581 File Offset: 0x00069781
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005DCD RID: 24013
		' (get) Token: 0x0600F525 RID: 62757 RVA: 0x0006B58A File Offset: 0x0006978A
		' (set) Token: 0x0600F526 RID: 62758 RVA: 0x0006B594 File Offset: 0x00069794
		Friend Overridable Property Label3 As Label

		' Token: 0x17005DCE RID: 24014
		' (get) Token: 0x0600F527 RID: 62759 RVA: 0x0006B59D File Offset: 0x0006979D
		' (set) Token: 0x0600F528 RID: 62760 RVA: 0x0006B5A7 File Offset: 0x000697A7
		Friend Overridable Property Label1 As Label

		' Token: 0x17005DCF RID: 24015
		' (get) Token: 0x0600F529 RID: 62761 RVA: 0x0006B5B0 File Offset: 0x000697B0
		' (set) Token: 0x0600F52A RID: 62762 RVA: 0x0006B5BA File Offset: 0x000697BA
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17005DD0 RID: 24016
		' (get) Token: 0x0600F52B RID: 62763 RVA: 0x0006B5C3 File Offset: 0x000697C3
		' (set) Token: 0x0600F52C RID: 62764 RVA: 0x00930AD8 File Offset: 0x0092ECD8
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DD1 RID: 24017
		' (get) Token: 0x0600F52D RID: 62765 RVA: 0x0006B5CD File Offset: 0x000697CD
		' (set) Token: 0x0600F52E RID: 62766 RVA: 0x0006B5D7 File Offset: 0x000697D7
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005DD2 RID: 24018
		' (get) Token: 0x0600F52F RID: 62767 RVA: 0x0006B5E0 File Offset: 0x000697E0
		' (set) Token: 0x0600F530 RID: 62768 RVA: 0x0006B5EA File Offset: 0x000697EA
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005DD3 RID: 24019
		' (get) Token: 0x0600F531 RID: 62769 RVA: 0x0006B5F3 File Offset: 0x000697F3
		' (set) Token: 0x0600F532 RID: 62770 RVA: 0x0006B5FD File Offset: 0x000697FD
		Friend Overridable Property Label2 As Label

		' Token: 0x17005DD4 RID: 24020
		' (get) Token: 0x0600F533 RID: 62771 RVA: 0x0006B606 File Offset: 0x00069806
		' (set) Token: 0x0600F534 RID: 62772 RVA: 0x0006B610 File Offset: 0x00069810
		Friend Overridable Property Label4 As Label

		' Token: 0x17005DD5 RID: 24021
		' (get) Token: 0x0600F535 RID: 62773 RVA: 0x0006B619 File Offset: 0x00069819
		' (set) Token: 0x0600F536 RID: 62774 RVA: 0x0006B623 File Offset: 0x00069823
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005DD6 RID: 24022
		' (get) Token: 0x0600F537 RID: 62775 RVA: 0x0006B62C File Offset: 0x0006982C
		' (set) Token: 0x0600F538 RID: 62776 RVA: 0x0006B636 File Offset: 0x00069836
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005DD7 RID: 24023
		' (get) Token: 0x0600F539 RID: 62777 RVA: 0x0006B63F File Offset: 0x0006983F
		' (set) Token: 0x0600F53A RID: 62778 RVA: 0x00930B1C File Offset: 0x0092ED1C
		Private _cmbQuotationNo As ComboBox
		Friend Overridable Property cmbQuotationNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbQuotationNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbOrderNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbQuotationNo_Format
				Dim comboBox As ComboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbQuotationNo = value
				comboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DD8 RID: 24024
		' (get) Token: 0x0600F53B RID: 62779 RVA: 0x0006B649 File Offset: 0x00069849
		' (set) Token: 0x0600F53C RID: 62780 RVA: 0x0006B653 File Offset: 0x00069853
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005DD9 RID: 24025
		' (get) Token: 0x0600F53D RID: 62781 RVA: 0x0006B65C File Offset: 0x0006985C
		' (set) Token: 0x0600F53E RID: 62782 RVA: 0x00930B7C File Offset: 0x0092ED7C
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DDA RID: 24026
		' (get) Token: 0x0600F53F RID: 62783 RVA: 0x0006B666 File Offset: 0x00069866
		' (set) Token: 0x0600F540 RID: 62784 RVA: 0x0006B670 File Offset: 0x00069870
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005DDB RID: 24027
		' (get) Token: 0x0600F541 RID: 62785 RVA: 0x0006B679 File Offset: 0x00069879
		' (set) Token: 0x0600F542 RID: 62786 RVA: 0x0006B683 File Offset: 0x00069883
		Friend Overridable Property Label5 As Label

		' Token: 0x17005DDC RID: 24028
		' (get) Token: 0x0600F543 RID: 62787 RVA: 0x0006B68C File Offset: 0x0006988C
		' (set) Token: 0x0600F544 RID: 62788 RVA: 0x0006B696 File Offset: 0x00069896
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005DDD RID: 24029
		' (get) Token: 0x0600F545 RID: 62789 RVA: 0x0006B69F File Offset: 0x0006989F
		' (set) Token: 0x0600F546 RID: 62790 RVA: 0x0006B6A9 File Offset: 0x000698A9
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005DDE RID: 24030
		' (get) Token: 0x0600F547 RID: 62791 RVA: 0x0006B6B2 File Offset: 0x000698B2
		' (set) Token: 0x0600F548 RID: 62792 RVA: 0x0006B6BC File Offset: 0x000698BC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005DDF RID: 24031
		' (get) Token: 0x0600F549 RID: 62793 RVA: 0x0006B6C5 File Offset: 0x000698C5
		' (set) Token: 0x0600F54A RID: 62794 RVA: 0x0006B6CF File Offset: 0x000698CF
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005DE0 RID: 24032
		' (get) Token: 0x0600F54B RID: 62795 RVA: 0x0006B6D8 File Offset: 0x000698D8
		' (set) Token: 0x0600F54C RID: 62796 RVA: 0x0006B6E2 File Offset: 0x000698E2
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17005DE1 RID: 24033
		' (get) Token: 0x0600F54D RID: 62797 RVA: 0x0006B6EB File Offset: 0x000698EB
		' (set) Token: 0x0600F54E RID: 62798 RVA: 0x0006B6F5 File Offset: 0x000698F5
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005DE2 RID: 24034
		' (get) Token: 0x0600F54F RID: 62799 RVA: 0x0006B6FE File Offset: 0x000698FE
		' (set) Token: 0x0600F550 RID: 62800 RVA: 0x0006B708 File Offset: 0x00069908
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005DE3 RID: 24035
		' (get) Token: 0x0600F551 RID: 62801 RVA: 0x0006B711 File Offset: 0x00069911
		' (set) Token: 0x0600F552 RID: 62802 RVA: 0x0006B71B File Offset: 0x0006991B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005DE4 RID: 24036
		' (get) Token: 0x0600F553 RID: 62803 RVA: 0x0006B724 File Offset: 0x00069924
		' (set) Token: 0x0600F554 RID: 62804 RVA: 0x0006B72E File Offset: 0x0006992E
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17005DE5 RID: 24037
		' (get) Token: 0x0600F555 RID: 62805 RVA: 0x0006B737 File Offset: 0x00069937
		' (set) Token: 0x0600F556 RID: 62806 RVA: 0x0006B741 File Offset: 0x00069941
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17005DE6 RID: 24038
		' (get) Token: 0x0600F557 RID: 62807 RVA: 0x0006B74A File Offset: 0x0006994A
		' (set) Token: 0x0600F558 RID: 62808 RVA: 0x0006B754 File Offset: 0x00069954
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17005DE7 RID: 24039
		' (get) Token: 0x0600F559 RID: 62809 RVA: 0x0006B75D File Offset: 0x0006995D
		' (set) Token: 0x0600F55A RID: 62810 RVA: 0x0006B767 File Offset: 0x00069967
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17005DE8 RID: 24040
		' (get) Token: 0x0600F55B RID: 62811 RVA: 0x0006B770 File Offset: 0x00069970
		' (set) Token: 0x0600F55C RID: 62812 RVA: 0x0006B77A File Offset: 0x0006997A
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17005DE9 RID: 24041
		' (get) Token: 0x0600F55D RID: 62813 RVA: 0x0006B783 File Offset: 0x00069983
		' (set) Token: 0x0600F55E RID: 62814 RVA: 0x0006B78D File Offset: 0x0006998D
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17005DEA RID: 24042
		' (get) Token: 0x0600F55F RID: 62815 RVA: 0x0006B796 File Offset: 0x00069996
		' (set) Token: 0x0600F560 RID: 62816 RVA: 0x0006B7A0 File Offset: 0x000699A0
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17005DEB RID: 24043
		' (get) Token: 0x0600F561 RID: 62817 RVA: 0x0006B7A9 File Offset: 0x000699A9
		' (set) Token: 0x0600F562 RID: 62818 RVA: 0x0006B7B3 File Offset: 0x000699B3
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17005DEC RID: 24044
		' (get) Token: 0x0600F563 RID: 62819 RVA: 0x0006B7BC File Offset: 0x000699BC
		' (set) Token: 0x0600F564 RID: 62820 RVA: 0x0006B7C6 File Offset: 0x000699C6
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17005DED RID: 24045
		' (get) Token: 0x0600F565 RID: 62821 RVA: 0x0006B7CF File Offset: 0x000699CF
		' (set) Token: 0x0600F566 RID: 62822 RVA: 0x0006B7D9 File Offset: 0x000699D9
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17005DEE RID: 24046
		' (get) Token: 0x0600F567 RID: 62823 RVA: 0x0006B7E2 File Offset: 0x000699E2
		' (set) Token: 0x0600F568 RID: 62824 RVA: 0x0006B7EC File Offset: 0x000699EC
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005DEF RID: 24047
		' (get) Token: 0x0600F569 RID: 62825 RVA: 0x0006B7F5 File Offset: 0x000699F5
		' (set) Token: 0x0600F56A RID: 62826 RVA: 0x0006B7FF File Offset: 0x000699FF
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17005DF0 RID: 24048
		' (get) Token: 0x0600F56B RID: 62827 RVA: 0x0006B808 File Offset: 0x00069A08
		' (set) Token: 0x0600F56C RID: 62828 RVA: 0x00930BF8 File Offset: 0x0092EDF8
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

		' Token: 0x17005DF1 RID: 24049
		' (get) Token: 0x0600F56D RID: 62829 RVA: 0x0006B812 File Offset: 0x00069A12
		' (set) Token: 0x0600F56E RID: 62830 RVA: 0x00930C3C File Offset: 0x0092EE3C
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005DF2 RID: 24050
		' (get) Token: 0x0600F56F RID: 62831 RVA: 0x0006B81C File Offset: 0x00069A1C
		' (set) Token: 0x0600F570 RID: 62832 RVA: 0x00930C80 File Offset: 0x0092EE80
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

		' Token: 0x0600F571 RID: 62833 RVA: 0x00930CC4 File Offset: 0x0092EEC4
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F572 RID: 62834 RVA: 0x00930D98 File Offset: 0x0092EF98
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(Estimate.Remarks) from Customer,Estimate where Customer.ID=Estimate.CustomerID and Estimate.KP='P' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F573 RID: 62835 RVA: 0x00931018 File Offset: 0x0092F218
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0600F574 RID: 62836 RVA: 0x0006B826 File Offset: 0x00069A26
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0600F575 RID: 62837 RVA: 0x00931040 File Offset: 0x0092F240
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.Label3.Text, "Est", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmEstimate.Show()
						MyBase.Hide()
						MyProject.Forms.frmEstimate.txtQ_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmEstimate.txtQuotationNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmEstimate.dtpQuotationDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmEstimate.cmbTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmEstimate.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmEstimate.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmEstimate.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmEstimate.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmEstimate.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag3 Then
							MyProject.Forms.frmEstimate.txtCustomerState.Text = MyProject.Forms.frmEstimate.txtCompanyState.Text
						Else
							MyProject.Forms.frmEstimate.txtCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmEstimate.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmEstimate.txtSubTotal.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmEstimate.txtCGST.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmEstimate.txtSGST.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmEstimate.txtIGST.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmEstimate.txtCESS.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmEstimate.txtTotal.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmEstimate.txtRoundOff.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmEstimate.txtGrandTotal.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmEstimate.txtRemarks.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmEstimate.btnSave.Enabled = False
						MyProject.Forms.frmEstimate.btnUpdate.Enabled = True
						MyProject.Forms.frmEstimate.btnPrint.Enabled = True
						MyProject.Forms.frmEstimate.Button15.Enabled = True
						MyProject.Forms.frmEstimate.btnDelete.Enabled = True
						MyProject.Forms.frmEstimate.btnCustomerSelection.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Estimate_Join.Barcode),Estimate_Join.Qty, Estimate_Join.Price,Estimate_Join.DiscountPer,Estimate_Join.DiscountAmt,Estimate_Join. CGSTPer, Estimate_Join.CGSTAmt,Estimate_Join. SGSTPer,Estimate_Join. SGSTAmt,Estimate_Join. IGSTPer,Estimate_Join. IGSTAmt,Estimate_Join. CESSPer,Estimate_Join.CESSAmt,Estimate_Join.TotalAmount,Estimate_Join.AltQty,RTRIM(Estimate_Join.AltUnit),RTRIM(Estimate_Join.STaxType) from Estimate,Estimate_Join,Product where Estimate.Q_ID=Estimate_Join.QuotationID and Product.PID=Estimate_Join.ProductID and Estimate.Q_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmEstimate.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmEstimate.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmEstimate.DataGridView1.ClearSelection()
						MyProject.Forms.frmEstimate.Calc()
						MyProject.Forms.frmEstimate.Compute()
						MyProject.Forms.frmEstimate.CTypeStatus()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F576 RID: 62838 RVA: 0x00931748 File Offset: 0x0092F948
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

		' Token: 0x0600F577 RID: 62839 RVA: 0x00931830 File Offset: 0x0092FA30
		Public Sub fillQuotationNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(QuotationNo) FROM Estimate where Estimate.KP='P'", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbQuotationNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbQuotationNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F578 RID: 62840 RVA: 0x00931964 File Offset: 0x0092FB64
		Public Sub Reset()
			Me.cmbQuotationNo.SelectedIndex = -1
			Me.cmbQuotationNo.Text = ""
			Me.txtCustomerName.Text = ""
			Me.fillQuotationNo()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x0600F579 RID: 62841 RVA: 0x009319C8 File Offset: 0x0092FBC8
		Private Sub cmbOrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(Estimate.Remarks) from Customer,Estimate where Customer.ID=Estimate.CustomerID and Estimate.KP='P' and QuotationNo='" + Me.cmbQuotationNo.Text + "' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F57A RID: 62842 RVA: 0x00931C70 File Offset: 0x0092FE70
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbQuotationNo.SelectedIndex = -1
				Me.cmbQuotationNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(Estimate.Remarks) from Customer,Estimate where Customer.ID=Estimate.CustomerID and Estimate.KP='P' and Name like N'" + Me.txtCustomerName.Text + "%' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F57B RID: 62843 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbQuotationNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600F57C RID: 62844 RVA: 0x00931F24 File Offset: 0x00930124
		Private Sub frmEstimateRecord_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.fillQuotationNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F57D RID: 62845 RVA: 0x00931FBC File Offset: 0x009301BC
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

		' Token: 0x0600F57E RID: 62846 RVA: 0x00932134 File Offset: 0x00930334
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

		' Token: 0x0600F57F RID: 62847 RVA: 0x00932200 File Offset: 0x00930400
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

		' Token: 0x0600F580 RID: 62848 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F581 RID: 62849 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F582 RID: 62850 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F583 RID: 62851 RVA: 0x009322CC File Offset: 0x009304CC
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Me.TextBox1.Text = "0.00"
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600F584 RID: 62852 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEstimateRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F585 RID: 62853 RVA: 0x009323EC File Offset: 0x009305EC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbQuotationNo.SelectedIndex = -1
				Me.cmbQuotationNo.Text = ""
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(Estimate.Remarks) from Customer,Estimate where Customer.ID=Estimate.CustomerID and Estimate.KP='P' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F586 RID: 62854 RVA: 0x0006B830 File Offset: 0x00069A30
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600F587 RID: 62855 RVA: 0x0093269C File Offset: 0x0093089C
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
	End Class
End Namespace
