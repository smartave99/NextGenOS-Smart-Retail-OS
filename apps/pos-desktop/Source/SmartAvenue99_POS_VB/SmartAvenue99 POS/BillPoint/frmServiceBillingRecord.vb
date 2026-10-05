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
	' Token: 0x020005C9 RID: 1481
	<DesignerGenerated()>
	Public Partial Class frmServiceBillingRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012049 RID: 73801 RVA: 0x0007B84A File Offset: 0x00079A4A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServiceBillingRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006FE3 RID: 28643
		' (get) Token: 0x0601204C RID: 73804 RVA: 0x0007B87C File Offset: 0x00079A7C
		' (set) Token: 0x0601204D RID: 73805 RVA: 0x0007B886 File Offset: 0x00079A86
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006FE4 RID: 28644
		' (get) Token: 0x0601204E RID: 73806 RVA: 0x0007B88F File Offset: 0x00079A8F
		' (set) Token: 0x0601204F RID: 73807 RVA: 0x0007B899 File Offset: 0x00079A99
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006FE5 RID: 28645
		' (get) Token: 0x06012050 RID: 73808 RVA: 0x0007B8A2 File Offset: 0x00079AA2
		' (set) Token: 0x06012051 RID: 73809 RVA: 0x0007B8AC File Offset: 0x00079AAC
		Friend Overridable Property Label1 As Label

		' Token: 0x17006FE6 RID: 28646
		' (get) Token: 0x06012052 RID: 73810 RVA: 0x0007B8B5 File Offset: 0x00079AB5
		' (set) Token: 0x06012053 RID: 73811 RVA: 0x00A61FF4 File Offset: 0x00A601F4
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

		' Token: 0x17006FE7 RID: 28647
		' (get) Token: 0x06012054 RID: 73812 RVA: 0x0007B8BF File Offset: 0x00079ABF
		' (set) Token: 0x06012055 RID: 73813 RVA: 0x0007B8C9 File Offset: 0x00079AC9
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006FE8 RID: 28648
		' (get) Token: 0x06012056 RID: 73814 RVA: 0x0007B8D2 File Offset: 0x00079AD2
		' (set) Token: 0x06012057 RID: 73815 RVA: 0x0007B8DC File Offset: 0x00079ADC
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006FE9 RID: 28649
		' (get) Token: 0x06012058 RID: 73816 RVA: 0x0007B8E5 File Offset: 0x00079AE5
		' (set) Token: 0x06012059 RID: 73817 RVA: 0x0007B8EF File Offset: 0x00079AEF
		Friend Overridable Property Label2 As Label

		' Token: 0x17006FEA RID: 28650
		' (get) Token: 0x0601205A RID: 73818 RVA: 0x0007B8F8 File Offset: 0x00079AF8
		' (set) Token: 0x0601205B RID: 73819 RVA: 0x0007B902 File Offset: 0x00079B02
		Friend Overridable Property Label4 As Label

		' Token: 0x17006FEB RID: 28651
		' (get) Token: 0x0601205C RID: 73820 RVA: 0x0007B90B File Offset: 0x00079B0B
		' (set) Token: 0x0601205D RID: 73821 RVA: 0x0007B915 File Offset: 0x00079B15
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006FEC RID: 28652
		' (get) Token: 0x0601205E RID: 73822 RVA: 0x0007B91E File Offset: 0x00079B1E
		' (set) Token: 0x0601205F RID: 73823 RVA: 0x00A62070 File Offset: 0x00A60270
		Private _cmbInvoiceNo As ComboBox
		Friend Overridable Property cmbInvoiceNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbOrderNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbInvoiceNo_Format
				Dim comboBox As ComboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbInvoiceNo = value
				comboBox = Me._cmbInvoiceNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006FED RID: 28653
		' (get) Token: 0x06012060 RID: 73824 RVA: 0x0007B928 File Offset: 0x00079B28
		' (set) Token: 0x06012061 RID: 73825 RVA: 0x0007B932 File Offset: 0x00079B32
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006FEE RID: 28654
		' (get) Token: 0x06012062 RID: 73826 RVA: 0x0007B93B File Offset: 0x00079B3B
		' (set) Token: 0x06012063 RID: 73827 RVA: 0x0007B945 File Offset: 0x00079B45
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006FEF RID: 28655
		' (get) Token: 0x06012064 RID: 73828 RVA: 0x0007B94E File Offset: 0x00079B4E
		' (set) Token: 0x06012065 RID: 73829 RVA: 0x0007B958 File Offset: 0x00079B58
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006FF0 RID: 28656
		' (get) Token: 0x06012066 RID: 73830 RVA: 0x0007B961 File Offset: 0x00079B61
		' (set) Token: 0x06012067 RID: 73831 RVA: 0x0007B96B File Offset: 0x00079B6B
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17006FF1 RID: 28657
		' (get) Token: 0x06012068 RID: 73832 RVA: 0x0007B974 File Offset: 0x00079B74
		' (set) Token: 0x06012069 RID: 73833 RVA: 0x0007B97E File Offset: 0x00079B7E
		Friend Overridable Property Label3 As Label

		' Token: 0x17006FF2 RID: 28658
		' (get) Token: 0x0601206A RID: 73834 RVA: 0x0007B987 File Offset: 0x00079B87
		' (set) Token: 0x0601206B RID: 73835 RVA: 0x0007B991 File Offset: 0x00079B91
		Friend Overridable Property Label5 As Label

		' Token: 0x17006FF3 RID: 28659
		' (get) Token: 0x0601206C RID: 73836 RVA: 0x0007B99A File Offset: 0x00079B9A
		' (set) Token: 0x0601206D RID: 73837 RVA: 0x0007B9A4 File Offset: 0x00079BA4
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17006FF4 RID: 28660
		' (get) Token: 0x0601206E RID: 73838 RVA: 0x0007B9AD File Offset: 0x00079BAD
		' (set) Token: 0x0601206F RID: 73839 RVA: 0x0007B9B7 File Offset: 0x00079BB7
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17006FF5 RID: 28661
		' (get) Token: 0x06012070 RID: 73840 RVA: 0x0007B9C0 File Offset: 0x00079BC0
		' (set) Token: 0x06012071 RID: 73841 RVA: 0x00A620D0 File Offset: 0x00A602D0
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

		' Token: 0x17006FF6 RID: 28662
		' (get) Token: 0x06012072 RID: 73842 RVA: 0x0007B9CA File Offset: 0x00079BCA
		' (set) Token: 0x06012073 RID: 73843 RVA: 0x0007B9D4 File Offset: 0x00079BD4
		Friend Overridable Property lblSet As Label

		' Token: 0x17006FF7 RID: 28663
		' (get) Token: 0x06012074 RID: 73844 RVA: 0x0007B9DD File Offset: 0x00079BDD
		' (set) Token: 0x06012075 RID: 73845 RVA: 0x0007B9E7 File Offset: 0x00079BE7
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006FF8 RID: 28664
		' (get) Token: 0x06012076 RID: 73846 RVA: 0x0007B9F0 File Offset: 0x00079BF0
		' (set) Token: 0x06012077 RID: 73847 RVA: 0x0007B9FA File Offset: 0x00079BFA
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006FF9 RID: 28665
		' (get) Token: 0x06012078 RID: 73848 RVA: 0x0007BA03 File Offset: 0x00079C03
		' (set) Token: 0x06012079 RID: 73849 RVA: 0x0007BA0D File Offset: 0x00079C0D
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006FFA RID: 28666
		' (get) Token: 0x0601207A RID: 73850 RVA: 0x0007BA16 File Offset: 0x00079C16
		' (set) Token: 0x0601207B RID: 73851 RVA: 0x0007BA20 File Offset: 0x00079C20
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006FFB RID: 28667
		' (get) Token: 0x0601207C RID: 73852 RVA: 0x0007BA29 File Offset: 0x00079C29
		' (set) Token: 0x0601207D RID: 73853 RVA: 0x0007BA33 File Offset: 0x00079C33
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006FFC RID: 28668
		' (get) Token: 0x0601207E RID: 73854 RVA: 0x0007BA3C File Offset: 0x00079C3C
		' (set) Token: 0x0601207F RID: 73855 RVA: 0x0007BA46 File Offset: 0x00079C46
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006FFD RID: 28669
		' (get) Token: 0x06012080 RID: 73856 RVA: 0x0007BA4F File Offset: 0x00079C4F
		' (set) Token: 0x06012081 RID: 73857 RVA: 0x0007BA59 File Offset: 0x00079C59
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006FFE RID: 28670
		' (get) Token: 0x06012082 RID: 73858 RVA: 0x0007BA62 File Offset: 0x00079C62
		' (set) Token: 0x06012083 RID: 73859 RVA: 0x0007BA6C File Offset: 0x00079C6C
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006FFF RID: 28671
		' (get) Token: 0x06012084 RID: 73860 RVA: 0x0007BA75 File Offset: 0x00079C75
		' (set) Token: 0x06012085 RID: 73861 RVA: 0x0007BA7F File Offset: 0x00079C7F
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17007000 RID: 28672
		' (get) Token: 0x06012086 RID: 73862 RVA: 0x0007BA88 File Offset: 0x00079C88
		' (set) Token: 0x06012087 RID: 73863 RVA: 0x0007BA92 File Offset: 0x00079C92
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17007001 RID: 28673
		' (get) Token: 0x06012088 RID: 73864 RVA: 0x0007BA9B File Offset: 0x00079C9B
		' (set) Token: 0x06012089 RID: 73865 RVA: 0x0007BAA5 File Offset: 0x00079CA5
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17007002 RID: 28674
		' (get) Token: 0x0601208A RID: 73866 RVA: 0x0007BAAE File Offset: 0x00079CAE
		' (set) Token: 0x0601208B RID: 73867 RVA: 0x0007BAB8 File Offset: 0x00079CB8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17007003 RID: 28675
		' (get) Token: 0x0601208C RID: 73868 RVA: 0x0007BAC1 File Offset: 0x00079CC1
		' (set) Token: 0x0601208D RID: 73869 RVA: 0x0007BACB File Offset: 0x00079CCB
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17007004 RID: 28676
		' (get) Token: 0x0601208E RID: 73870 RVA: 0x0007BAD4 File Offset: 0x00079CD4
		' (set) Token: 0x0601208F RID: 73871 RVA: 0x0007BADE File Offset: 0x00079CDE
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007005 RID: 28677
		' (get) Token: 0x06012090 RID: 73872 RVA: 0x0007BAE7 File Offset: 0x00079CE7
		' (set) Token: 0x06012091 RID: 73873 RVA: 0x0007BAF1 File Offset: 0x00079CF1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17007006 RID: 28678
		' (get) Token: 0x06012092 RID: 73874 RVA: 0x0007BAFA File Offset: 0x00079CFA
		' (set) Token: 0x06012093 RID: 73875 RVA: 0x0007BB04 File Offset: 0x00079D04
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007007 RID: 28679
		' (get) Token: 0x06012094 RID: 73876 RVA: 0x0007BB0D File Offset: 0x00079D0D
		' (set) Token: 0x06012095 RID: 73877 RVA: 0x0007BB17 File Offset: 0x00079D17
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17007008 RID: 28680
		' (get) Token: 0x06012096 RID: 73878 RVA: 0x0007BB20 File Offset: 0x00079D20
		' (set) Token: 0x06012097 RID: 73879 RVA: 0x00A62114 File Offset: 0x00A60314
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

		' Token: 0x17007009 RID: 28681
		' (get) Token: 0x06012098 RID: 73880 RVA: 0x0007BB2A File Offset: 0x00079D2A
		' (set) Token: 0x06012099 RID: 73881 RVA: 0x00A62158 File Offset: 0x00A60358
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

		' Token: 0x1700700A RID: 28682
		' (get) Token: 0x0601209A RID: 73882 RVA: 0x0007BB34 File Offset: 0x00079D34
		' (set) Token: 0x0601209B RID: 73883 RVA: 0x00A6219C File Offset: 0x00A6039C
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700700B RID: 28683
		' (get) Token: 0x0601209C RID: 73884 RVA: 0x0007BB3E File Offset: 0x00079D3E
		' (set) Token: 0x0601209D RID: 73885 RVA: 0x00A621E0 File Offset: 0x00A603E0
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

		' Token: 0x1700700C RID: 28684
		' (get) Token: 0x0601209E RID: 73886 RVA: 0x0007BB48 File Offset: 0x00079D48
		' (set) Token: 0x0601209F RID: 73887 RVA: 0x0007BB52 File Offset: 0x00079D52
		Friend Overridable Property Label6 As Label

		' Token: 0x060120A0 RID: 73888 RVA: 0x00A62224 File Offset: 0x00A60424
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
					Me.DateTimePicker2.Value = DateAndTime.Today
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

		' Token: 0x060120A1 RID: 73889 RVA: 0x00A62308 File Offset: 0x00A60508
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060120A2 RID: 73890 RVA: 0x00A62544 File Offset: 0x00A60744
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.fillInvoiceNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060120A3 RID: 73891 RVA: 0x00A625E4 File Offset: 0x00A607E4
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

		' Token: 0x060120A4 RID: 73892 RVA: 0x00A62884 File Offset: 0x00A60A84
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

		' Token: 0x060120A5 RID: 73893 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060120A6 RID: 73894 RVA: 0x00A62950 File Offset: 0x00A60B50
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060120A7 RID: 73895 RVA: 0x0007BB5B File Offset: 0x00079D5B
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x060120A8 RID: 73896 RVA: 0x00A62978 File Offset: 0x00A60B78
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Billing", False) = 0
					If flag2 Then
						MyProject.Forms.frmServiceBilling.Show()
						MyBase.Hide()
						MyProject.Forms.frmServiceBilling.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtInvoiceNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmServiceBilling.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtS_ID.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtServiceCode.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtRepairCharges.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtUpfront.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtServiceTaxPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtServiceTaxAmount.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtGrandTotal.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtTotalPayment.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtPaymentDue.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmServiceBilling.txtRemarks.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmServiceBilling.btnSave.Enabled = False
						MyProject.Forms.frmServiceBilling.btnUpdate.Enabled = True
						MyProject.Forms.frmServiceBilling.btnPrint.Enabled = True
						MyProject.Forms.frmServiceBilling.btnDelete.Enabled = True
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060120A9 RID: 73897 RVA: 0x00A62D10 File Offset: 0x00A60F10
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

		' Token: 0x060120AA RID: 73898 RVA: 0x00A62DF8 File Offset: 0x00A60FF8
		Public Sub fillInvoiceNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvoiceNo) FROM InvoiceInfo1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbInvoiceNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbInvoiceNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060120AB RID: 73899 RVA: 0x00A62F2C File Offset: 0x00A6112C
		Public Sub Reset()
			Me.cmbInvoiceNo.Text = ""
			Me.cmbInvoiceNo.SelectedIndex = -1
			Me.txtCustomerName.Text = ""
			Me.fillInvoiceNo()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x060120AC RID: 73900 RVA: 0x00A62FA0 File Offset: 0x00A611A0
		Private Sub cmbOrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceNo='" + Me.cmbInvoiceNo.Text + "' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060120AD RID: 73901 RVA: 0x00A63208 File Offset: 0x00A61408
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and Name like N'" + Me.txtCustomerName.Text + "%' and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060120AE RID: 73902 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x060120AF RID: 73903 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServiceBillingRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060120B0 RID: 73904 RVA: 0x00A6347C File Offset: 0x00A6167C
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
			Me.lblTotalAmount.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x060120B1 RID: 73905 RVA: 0x00A6358C File Offset: 0x00A6178C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbInvoiceNo.SelectedIndex = -1
				Me.cmbInvoiceNo.Text = ""
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060120B2 RID: 73906 RVA: 0x00A637FC File Offset: 0x00A619FC
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Inv_ID, RTRIM(InvoiceNo), InvoiceDate, ServiceID,RTRIM(ServiceCode),RTRIM(Customer.CustomerID),RTRIM(Name), RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, RTRIM(InvoiceInfo1.Remarks) from Customer,Service,InvoiceInfo1 where Customer.ID=Service.CustomerID and Service.S_ID=InvoiceInfo1.ServiceID and InvoiceDate between @d1 and @d2 and Balance > 0 order by InvoiceDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060120B3 RID: 73907 RVA: 0x00A63A3C File Offset: 0x00A61C3C
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

		' Token: 0x060120B4 RID: 73908 RVA: 0x0007BB65 File Offset: 0x00079D65
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub
	End Class
End Namespace
