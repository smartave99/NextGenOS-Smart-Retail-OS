Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000B2 RID: 178
	<DesignerGenerated()>
	Public Partial Class frmCustomersNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060019DD RID: 6621 RVA: 0x00013805 File Offset: 0x00011A05
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBulkPriceChange_Load
			Me.prevCell = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A1B RID: 2587
		' (get) Token: 0x060019E0 RID: 6624 RVA: 0x0001382F File Offset: 0x00011A2F
		' (set) Token: 0x060019E1 RID: 6625 RVA: 0x0011E210 File Offset: 0x0011C410
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim eventHandler As EventHandler = AddressOf Me.dgw_CurrentCellChanged
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A1C RID: 2588
		' (get) Token: 0x060019E2 RID: 6626 RVA: 0x00013839 File Offset: 0x00011A39
		' (set) Token: 0x060019E3 RID: 6627 RVA: 0x00013843 File Offset: 0x00011A43
		Public Overridable Property Photo As PictureBox

		' Token: 0x17000A1D RID: 2589
		' (get) Token: 0x060019E4 RID: 6628 RVA: 0x0001384C File Offset: 0x00011A4C
		' (set) Token: 0x060019E5 RID: 6629 RVA: 0x00013856 File Offset: 0x00011A56
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000A1E RID: 2590
		' (get) Token: 0x060019E6 RID: 6630 RVA: 0x0001385F File Offset: 0x00011A5F
		' (set) Token: 0x060019E7 RID: 6631 RVA: 0x00013869 File Offset: 0x00011A69
		Friend Overridable Property lblUser As Label

		' Token: 0x17000A1F RID: 2591
		' (get) Token: 0x060019E8 RID: 6632 RVA: 0x00013872 File Offset: 0x00011A72
		' (set) Token: 0x060019E9 RID: 6633 RVA: 0x0001387C File Offset: 0x00011A7C
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000A20 RID: 2592
		' (get) Token: 0x060019EA RID: 6634 RVA: 0x00013885 File Offset: 0x00011A85
		' (set) Token: 0x060019EB RID: 6635 RVA: 0x0011E28C File Offset: 0x0011C48C
		Private _btnNewSupplier As Button
		Friend Overridable Property btnNewSupplier As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNewSupplier
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._btnNewSupplier
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNewSupplier = value
				button = Me._btnNewSupplier
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A21 RID: 2593
		' (get) Token: 0x060019EC RID: 6636 RVA: 0x0001388F File Offset: 0x00011A8F
		' (set) Token: 0x060019ED RID: 6637 RVA: 0x00013899 File Offset: 0x00011A99
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17000A22 RID: 2594
		' (get) Token: 0x060019EE RID: 6638 RVA: 0x000138A2 File Offset: 0x00011AA2
		' (set) Token: 0x060019EF RID: 6639 RVA: 0x000138AC File Offset: 0x00011AAC
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000A23 RID: 2595
		' (get) Token: 0x060019F0 RID: 6640 RVA: 0x000138B5 File Offset: 0x00011AB5
		' (set) Token: 0x060019F1 RID: 6641 RVA: 0x000138BF File Offset: 0x00011ABF
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000A24 RID: 2596
		' (get) Token: 0x060019F2 RID: 6642 RVA: 0x000138C8 File Offset: 0x00011AC8
		' (set) Token: 0x060019F3 RID: 6643 RVA: 0x000138D2 File Offset: 0x00011AD2
		Friend Overridable Property Label17 As Label

		' Token: 0x17000A25 RID: 2597
		' (get) Token: 0x060019F4 RID: 6644 RVA: 0x000138DB File Offset: 0x00011ADB
		' (set) Token: 0x060019F5 RID: 6645 RVA: 0x000138E5 File Offset: 0x00011AE5
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17000A26 RID: 2598
		' (get) Token: 0x060019F6 RID: 6646 RVA: 0x000138EE File Offset: 0x00011AEE
		' (set) Token: 0x060019F7 RID: 6647 RVA: 0x000138F8 File Offset: 0x00011AF8
		Friend Overridable Property Label19 As Label

		' Token: 0x17000A27 RID: 2599
		' (get) Token: 0x060019F8 RID: 6648 RVA: 0x00013901 File Offset: 0x00011B01
		' (set) Token: 0x060019F9 RID: 6649 RVA: 0x0011E2D0 File Offset: 0x0011C4D0
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A28 RID: 2600
		' (get) Token: 0x060019FA RID: 6650 RVA: 0x0001390B File Offset: 0x00011B0B
		' (set) Token: 0x060019FB RID: 6651 RVA: 0x00013915 File Offset: 0x00011B15
		Friend Overridable Property Label18 As Label

		' Token: 0x17000A29 RID: 2601
		' (get) Token: 0x060019FC RID: 6652 RVA: 0x0001391E File Offset: 0x00011B1E
		' (set) Token: 0x060019FD RID: 6653 RVA: 0x00013928 File Offset: 0x00011B28
		Friend Overridable Property Label21 As Label

		' Token: 0x17000A2A RID: 2602
		' (get) Token: 0x060019FE RID: 6654 RVA: 0x00013931 File Offset: 0x00011B31
		' (set) Token: 0x060019FF RID: 6655 RVA: 0x0011E314 File Offset: 0x0011C514
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTopResult_TextChanged
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A2B RID: 2603
		' (get) Token: 0x06001A00 RID: 6656 RVA: 0x0001393B File Offset: 0x00011B3B
		' (set) Token: 0x06001A01 RID: 6657 RVA: 0x0011E358 File Offset: 0x0011C558
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

		' Token: 0x17000A2C RID: 2604
		' (get) Token: 0x06001A02 RID: 6658 RVA: 0x00013945 File Offset: 0x00011B45
		' (set) Token: 0x06001A03 RID: 6659 RVA: 0x0011E39C File Offset: 0x0011C59C
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchProduct_TextChanged
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A2D RID: 2605
		' (get) Token: 0x06001A04 RID: 6660 RVA: 0x0001394F File Offset: 0x00011B4F
		' (set) Token: 0x06001A05 RID: 6661 RVA: 0x0011E3E0 File Offset: 0x0011C5E0
		Private _cmbSearchCat As ComboBox
		Friend Overridable Property cmbSearchCat As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSearchCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSearchCat_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSearchCat = value
				comboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A2E RID: 2606
		' (get) Token: 0x06001A06 RID: 6662 RVA: 0x00013959 File Offset: 0x00011B59
		' (set) Token: 0x06001A07 RID: 6663 RVA: 0x00013963 File Offset: 0x00011B63
		Friend Overridable Property Label1 As Label

		' Token: 0x17000A2F RID: 2607
		' (get) Token: 0x06001A08 RID: 6664 RVA: 0x0001396C File Offset: 0x00011B6C
		' (set) Token: 0x06001A09 RID: 6665 RVA: 0x00013976 File Offset: 0x00011B76
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000A30 RID: 2608
		' (get) Token: 0x06001A0A RID: 6666 RVA: 0x0001397F File Offset: 0x00011B7F
		' (set) Token: 0x06001A0B RID: 6667 RVA: 0x00013989 File Offset: 0x00011B89
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000A31 RID: 2609
		' (get) Token: 0x06001A0C RID: 6668 RVA: 0x00013992 File Offset: 0x00011B92
		' (set) Token: 0x06001A0D RID: 6669 RVA: 0x0001399C File Offset: 0x00011B9C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000A32 RID: 2610
		' (get) Token: 0x06001A0E RID: 6670 RVA: 0x000139A5 File Offset: 0x00011BA5
		' (set) Token: 0x06001A0F RID: 6671 RVA: 0x000139AF File Offset: 0x00011BAF
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000A33 RID: 2611
		' (get) Token: 0x06001A10 RID: 6672 RVA: 0x000139B8 File Offset: 0x00011BB8
		' (set) Token: 0x06001A11 RID: 6673 RVA: 0x000139C2 File Offset: 0x00011BC2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000A34 RID: 2612
		' (get) Token: 0x06001A12 RID: 6674 RVA: 0x000139CB File Offset: 0x00011BCB
		' (set) Token: 0x06001A13 RID: 6675 RVA: 0x000139D5 File Offset: 0x00011BD5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000A35 RID: 2613
		' (get) Token: 0x06001A14 RID: 6676 RVA: 0x000139DE File Offset: 0x00011BDE
		' (set) Token: 0x06001A15 RID: 6677 RVA: 0x000139E8 File Offset: 0x00011BE8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000A36 RID: 2614
		' (get) Token: 0x06001A16 RID: 6678 RVA: 0x000139F1 File Offset: 0x00011BF1
		' (set) Token: 0x06001A17 RID: 6679 RVA: 0x000139FB File Offset: 0x00011BFB
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000A37 RID: 2615
		' (get) Token: 0x06001A18 RID: 6680 RVA: 0x00013A04 File Offset: 0x00011C04
		' (set) Token: 0x06001A19 RID: 6681 RVA: 0x00013A0E File Offset: 0x00011C0E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000A38 RID: 2616
		' (get) Token: 0x06001A1A RID: 6682 RVA: 0x00013A17 File Offset: 0x00011C17
		' (set) Token: 0x06001A1B RID: 6683 RVA: 0x00013A21 File Offset: 0x00011C21
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000A39 RID: 2617
		' (get) Token: 0x06001A1C RID: 6684 RVA: 0x00013A2A File Offset: 0x00011C2A
		' (set) Token: 0x06001A1D RID: 6685 RVA: 0x00013A34 File Offset: 0x00011C34
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000A3A RID: 2618
		' (get) Token: 0x06001A1E RID: 6686 RVA: 0x00013A3D File Offset: 0x00011C3D
		' (set) Token: 0x06001A1F RID: 6687 RVA: 0x00013A47 File Offset: 0x00011C47
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17000A3B RID: 2619
		' (get) Token: 0x06001A20 RID: 6688 RVA: 0x00013A50 File Offset: 0x00011C50
		' (set) Token: 0x06001A21 RID: 6689 RVA: 0x00013A5A File Offset: 0x00011C5A
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000A3C RID: 2620
		' (get) Token: 0x06001A22 RID: 6690 RVA: 0x00013A63 File Offset: 0x00011C63
		' (set) Token: 0x06001A23 RID: 6691 RVA: 0x00013A6D File Offset: 0x00011C6D
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000A3D RID: 2621
		' (get) Token: 0x06001A24 RID: 6692 RVA: 0x00013A76 File Offset: 0x00011C76
		' (set) Token: 0x06001A25 RID: 6693 RVA: 0x00013A80 File Offset: 0x00011C80
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000A3E RID: 2622
		' (get) Token: 0x06001A26 RID: 6694 RVA: 0x00013A89 File Offset: 0x00011C89
		' (set) Token: 0x06001A27 RID: 6695 RVA: 0x00013A93 File Offset: 0x00011C93
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000A3F RID: 2623
		' (get) Token: 0x06001A28 RID: 6696 RVA: 0x00013A9C File Offset: 0x00011C9C
		' (set) Token: 0x06001A29 RID: 6697 RVA: 0x00013AA6 File Offset: 0x00011CA6
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000A40 RID: 2624
		' (get) Token: 0x06001A2A RID: 6698 RVA: 0x00013AAF File Offset: 0x00011CAF
		' (set) Token: 0x06001A2B RID: 6699 RVA: 0x00013AB9 File Offset: 0x00011CB9
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000A41 RID: 2625
		' (get) Token: 0x06001A2C RID: 6700 RVA: 0x00013AC2 File Offset: 0x00011CC2
		' (set) Token: 0x06001A2D RID: 6701 RVA: 0x00013ACC File Offset: 0x00011CCC
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000A42 RID: 2626
		' (get) Token: 0x06001A2E RID: 6702 RVA: 0x00013AD5 File Offset: 0x00011CD5
		' (set) Token: 0x06001A2F RID: 6703 RVA: 0x00013ADF File Offset: 0x00011CDF
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000A43 RID: 2627
		' (get) Token: 0x06001A30 RID: 6704 RVA: 0x00013AE8 File Offset: 0x00011CE8
		' (set) Token: 0x06001A31 RID: 6705 RVA: 0x00013AF2 File Offset: 0x00011CF2
		Friend Overridable Property Column22 As DataGridViewButtonColumn

		' Token: 0x17000A44 RID: 2628
		' (get) Token: 0x06001A32 RID: 6706 RVA: 0x00013AFB File Offset: 0x00011CFB
		' (set) Token: 0x06001A33 RID: 6707 RVA: 0x00013B05 File Offset: 0x00011D05
		Friend Overridable Property Column2 As DataGridViewButtonColumn

		' Token: 0x17000A45 RID: 2629
		' (get) Token: 0x06001A34 RID: 6708 RVA: 0x00013B0E File Offset: 0x00011D0E
		' (set) Token: 0x06001A35 RID: 6709 RVA: 0x00013B18 File Offset: 0x00011D18
		Public Overridable Property Picture As PictureBox

		' Token: 0x17000A46 RID: 2630
		' (get) Token: 0x06001A36 RID: 6710 RVA: 0x00013B21 File Offset: 0x00011D21
		' (set) Token: 0x06001A37 RID: 6711 RVA: 0x00013B2B File Offset: 0x00011D2B
		Friend Overridable Property lblCName As Label

		' Token: 0x06001A38 RID: 6712 RVA: 0x00013B34 File Offset: 0x00011D34
		Private Sub frmBulkPriceChange_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06001A39 RID: 6713 RVA: 0x0011E424 File Offset: 0x0011C624
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode)," & vbCrLf & "                                    RTRIM(ContactNo),RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(Opbal),RTRIM(Remarks),RTRIM(Limit)," & vbCrLf & "                                    RTRIM(OpbalLoyality),is_loyalityDisable, RTRIM(Tcs), RTRIM(Route),RTRIM(Taround),RTRIM(Optype) from Customer  where LStatus = 'Yes' order by id desc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text As String = "No"
					Dim flag As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(16), 1, False)
					If flag Then
						text = "Yes"
					End If
					Dim obj As Object = Operators.ConcatenateObject(Operators.ConcatenateObject(ModCommonClasses.rdr(12), " "), ModCommonClasses.rdr(20))
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), obj, ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), text, ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
					Me.dgw.Rows(num).Cells(20).Value = "Update"
					Me.dgw.Rows(num).Cells(21).Value = "Delete"
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Dim flag2 As Boolean = Me.dgw.RowCount > 0
				If flag2 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001A3A RID: 6714 RVA: 0x0011E744 File Offset: 0x0011C944
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim list As List(Of Short) = New List(Of Short)(New Short() { 6S, 7S, 12S, 14S, 15S, 18S })
			Dim textBox As TextBox = TryCast(e.Control, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				RemoveHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				Dim flag2 As Boolean = list.Contains(CShort(Me.dgw.CurrentCell.ColumnIndex))
				If flag2 Then
					AddHandler textBox.KeyPress, AddressOf Me.NumericDecimal_KeyPress
				End If
			End If
		End Sub

		' Token: 0x06001A3B RID: 6715 RVA: 0x0011AF1C File Offset: 0x0011911C
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim textBox As TextBox = CType(sender, TextBox)
			Dim flag As Boolean = Char.IsControl(e.KeyChar)
			If Not flag Then
				Dim flag2 As Boolean = e.KeyChar = "."c
				If flag2 Then
					Dim flag3 As Boolean = textBox.Text.Contains(".")
					If flag3 Then
						e.Handled = True
					End If
				Else
					Dim flag4 As Boolean = Not Char.IsDigit(e.KeyChar)
					If flag4 Then
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x06001A3C RID: 6716 RVA: 0x0011E7C4 File Offset: 0x0011C9C4
		Private Sub dgw_CurrentCellChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.prevCell IsNot Nothing
			If flag Then
				Me.prevCell.Style.BackColor = Color.White
			End If
			Dim flag2 As Boolean = Me.dgw.CurrentCell IsNot Nothing
			If flag2 Then
				Me.dgw.CurrentCell.Style.BackColor = Color.Yellow
				Me.prevCell = Me.dgw.CurrentCell
			End If
		End Sub

		' Token: 0x06001A3D RID: 6717 RVA: 0x0011E838 File Offset: 0x0011CA38
		Public Function MoveToNextAndClear() As Boolean
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim textBox As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			Dim flag As Boolean = textBox IsNot Nothing
			If flag Then
				textBox.SelectionStart = 0
				textBox.SelectionLength = textBox.Text.Length
				Application.DoEvents()
			End If
			Return True
		End Function

		' Token: 0x06001A3E RID: 6718 RVA: 0x0011E8A0 File Offset: 0x0011CAA0
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			Dim flag As Boolean = Not Me.txtSearchProduct.Focused And Not Me.txtTopResult.Focused
			If flag Then
				Dim flag2 As Boolean = keyData = Keys.[Return]
				If flag2 Then
					Me.dgw.ClearSelection()
					Dim num As Integer = 1
					Dim num2 As Integer = 1
					Dim flag3 As Boolean = Me.dgw.CurrentCell IsNot Nothing
					If flag3 Then
						Dim rowIndex As Integer = Me.dgw.CurrentCell.RowIndex
						Dim columnIndex As Integer = Me.dgw.CurrentCell.ColumnIndex
						Dim flag4 As Boolean = keyData = Keys.[Return] AndAlso columnIndex = 21
						If flag4 Then
							Me.DeleteCustomer(rowIndex, columnIndex)
							Return True
						End If
						Dim flag5 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex > 1 AndAlso Me.dgw.CurrentCell.ColumnIndex < 20
						If flag5 Then
							Dim flag6 As Boolean = Not Me.txtSearchProduct.Focused
							If flag6 Then
								Dim flag7 As Boolean = columnIndex = 5
								If flag7 Then
									Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(rowIndex)
									Dim text As String = ""
									Dim flag8 As Boolean = dataGridViewRow.Cells(5).Value IsNot Nothing
									If flag8 Then
										Dim value As Object = dataGridViewRow.Cells(5).Value
										text = If((value IsNot Nothing), value.ToString(), Nothing)
									End If
									MyProject.Forms.frmState.txtStateName.Text = text
									MyProject.Forms.frmState.currentRow = rowIndex
									MyProject.Forms.frmState.currentColumn = columnIndex
									MyProject.Forms.frmState.Owner = Me
									MyProject.Forms.frmState.ShowDialog()
									Return True
								End If
							End If
							Dim flag9 As Boolean = columnIndex = 12 AndAlso msg.Msg > 0
							If flag9 Then
								Me.dgw.EndEdit()
								Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
								Me.dgw.Refresh()
								Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.Rows(rowIndex)
								MyProject.Forms.frmCreditDebit.currentRow = rowIndex
								MyProject.Forms.frmCreditDebit.currentColumn = columnIndex
								MyProject.Forms.frmCreditDebit.Owner = Me
								MyProject.Forms.frmCreditDebit.ShowDialog()
								Return True
							End If
							Dim flag10 As Boolean = ((columnIndex = 16) Or (columnIndex = 17)) AndAlso msg.Msg > 0
							If flag10 Then
								Me.dgw.EndEdit()
								Me.dgw.CommitEdit(DataGridViewDataErrorContexts.Commit)
								Me.dgw.Refresh()
								Dim dataGridViewRow3 As DataGridViewRow = Me.dgw.Rows(rowIndex)
								MyProject.Forms.frmYesNo.currentRow = rowIndex
								MyProject.Forms.frmYesNo.currentColumn = columnIndex
								MyProject.Forms.frmYesNo.Owner = Me
								MyProject.Forms.frmYesNo.ShowDialog()
								Return True
							End If
							Dim flag11 As Boolean = columnIndex < Me.dgw.Columns.Count
							If flag11 Then
								Me.dgw.Focus()
								Me.dgw.[Select]()
								Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
							End If
							Return Me.MoveToNextAndClear()
						Else
							Dim flag12 As Boolean = keyData = Keys.[Return] AndAlso Me.dgw.CurrentCell.ColumnIndex = 20
							If flag12 Then
								Dim flag13 As Boolean = Operators.ConditionalCompareObjectGreaterEqual(Me.dgw.Rows(rowIndex).Cells(0).Value, 0, False)
								If Not flag13 Then
									Return True
								End If
								Dim flag14 As Boolean = False
								Me.InsertNewSupplier(rowIndex, columnIndex, flag14)
								Dim flag15 As Boolean = flag14
								If flag15 Then
									Dim flag16 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
									If flag16 Then
										Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(2)
									Else
										Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
									End If
									Return Me.MoveToNextAndClear()
								End If
								Return True
							Else
								Select Case keyData
									Case Keys.Left
										Dim flag17 As Boolean = columnIndex > 3
										If flag17 Then
											Dim flag18 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex - num2).Visible
											If flag18 Then
												num2 += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex - num2)
										Else
											Dim flag19 As Boolean = columnIndex = 3
											If flag19 Then
												Dim flag20 As Boolean = rowIndex > 0
												If flag20 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(15)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(2)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Up
										Dim flag21 As Boolean = rowIndex > 0
										If flag21 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex - 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
									Case Keys.Right
										Dim flag22 As Boolean = columnIndex < 16
										If flag22 Then
											Dim flag23 As Boolean = Not Me.dgw.Rows(rowIndex).Cells(columnIndex + num).Visible
											If flag23 Then
												num += 1
											End If
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex).Cells(columnIndex + num)
										Else
											Dim flag24 As Boolean = columnIndex = 20
											If flag24 Then
												Dim flag25 As Boolean = rowIndex >= Me.dgw.Rows.Count - 1
												If flag25 Then
													Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
												Else
													Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(2)
												End If
											End If
										End If
										Return Me.MoveToNextAndClear()
									Case Keys.Down
										Dim flag26 As Boolean = rowIndex < Me.dgw.Rows.Count - 1
										If flag26 Then
											Me.dgw.CurrentCell = Me.dgw.Rows(rowIndex + 1).Cells(columnIndex)
											Return Me.MoveToNextAndClear()
										End If
								End Select
								If keyData <> Keys.[Return] AndAlso keyData - Keys.Left > 3 Then
									Dim flag27 As Boolean = Not Me.txtSearchProduct.Focused
									If flag27 Then
										Dim flag28 As Boolean = columnIndex = 6
										If flag28 Then
											Dim dataGridViewRow4 As DataGridViewRow = Me.dgw.Rows(rowIndex)
											Dim text2 As String = ""
											Dim flag29 As Boolean = dataGridViewRow4.Cells(2).Value IsNot Nothing
											If flag29 Then
												Dim value2 As Object = dataGridViewRow4.Cells(2).Value
												text2 = If((value2 IsNot Nothing), value2.ToString(), Nothing)
											End If
											MyProject.Forms.frmState.txtStateName.Text = text2
											MyProject.Forms.frmState.currentRow = rowIndex
											MyProject.Forms.frmState.currentColumn = columnIndex
											MyProject.Forms.frmState.Owner = Me
											MyProject.Forms.frmState.ShowDialog()
										End If
									End If
								End If
								Dim flag30 As Boolean = Not Me.txtSearchProduct.Focused
								If flag30 Then
									Me.dgw.BeginEdit(True)
									Me.dgw.ClearSelection()
								End If
							End If
						End If
					End If
				End If
			Else
				Dim flag31 As Boolean = keyData = Keys.[Return]
				If flag31 Then
					Dim flag32 As Boolean = Me.dgw.RowCount > 0
					If flag32 Then
						Dim focused As Boolean = Me.txtSearchProduct.Focused
						If focused Then
							Dim flag33 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
							If flag33 Then
								Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(7)
							Else
								Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
							End If
						Else
							Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
						End If
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End If
				End If
			End If
			Return MyBase.ProcessCmdKey(msg, keyData)
		End Function

		' Token: 0x06001A3F RID: 6719 RVA: 0x0011F20C File Offset: 0x0011D40C
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.dgw.Rows
				If row.Cells(0).Value IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Value)) = 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.dgw.ClearSelection()
					Dim r As DataGridViewRow = row
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.Focus()
						Me.dgw.CurrentCell = r.Cells(2)
						Me.dgw.BeginEdit(True)
						Me.dgw.ClearSelection()
					End Sub))
					Return
				End If
			Next
			Me.dgw.ClearSelection()
			Dim num As Integer = Me.dgw.Rows.Add()
			Dim newRow As DataGridViewRow = Me.dgw.Rows(num)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = ""
			newRow.Cells(2).Value = ""
			newRow.Cells(3).Value = ""
			newRow.Cells(4).Value = ""
			newRow.Cells(5).Value = ""
			newRow.Cells(6).Value = ""
			newRow.Cells(7).Value = ""
			newRow.Cells(8).Value = ""
			newRow.Cells(9).Value = ""
			newRow.Cells(10).Value = ""
			newRow.Cells(11).Value = ""
			newRow.Cells(12).Value = "0.00"
			newRow.Cells(13).Value = ""
			newRow.Cells(14).Value = "0.00"
			newRow.Cells(15).Value = "0.00"
			newRow.Cells(16).Value = ""
			newRow.Cells(17).Value = ""
			newRow.Cells(18).Value = ""
			newRow.Cells(19).Value = ""
			newRow.Cells(20).Value = "Save"
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = newRow.Cells(2)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
				End Sub))
		End Sub

		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim rowIndex As Integer = e.RowIndex
			Dim columnIndex As Integer = e.ColumnIndex
			Dim flag As Boolean = False
			Me.InsertNewSupplier(rowIndex, columnIndex, flag)
			Me.DeleteCustomer(e.RowIndex, e.ColumnIndex)
		End Sub

		' Token: 0x06001A41 RID: 6721 RVA: 0x0011F5FC File Offset: 0x0011D7FC
		Public Sub SetFocustoCurrentCell(rowindex As Integer, colindex As Integer)
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.Focus()
				Me.dgw.CurrentCell = Me.dgw.Rows(rowindex).Cells(colindex)
				Me.dgw.BeginEdit(True)
				Me.dgw.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x06001A42 RID: 6722 RVA: 0x0011F638 File Offset: 0x0011D838
		Public Sub InsertNewSupplier(RowIndex As Integer, ColumnIndex As Integer, ByRef isUpdate As Boolean)
			Dim flag As Boolean = ColumnIndex = Me.dgw.Columns(20).Index AndAlso RowIndex >= 0
			If flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
					Dim num As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
					Dim text2 As String = (If(dataGridViewRow.Cells(1).Value, "")).ToString().Trim()
					Dim text3 As String = (If(dataGridViewRow.Cells(2).Value, "")).ToString().Trim()
					Dim text4 As String = (If(dataGridViewRow.Cells(3).Value, "")).ToString().Trim()
					Dim text5 As String = (If(dataGridViewRow.Cells(4).Value, "")).ToString().Trim()
					Dim text6 As String = (If(dataGridViewRow.Cells(5).Value, "")).ToString().Trim()
					Dim text7 As String = (If(dataGridViewRow.Cells(6).Value, "")).ToString().Trim()
					Dim text8 As String = (If(dataGridViewRow.Cells(7).Value, "")).ToString().Trim()
					Dim text9 As String = (If(dataGridViewRow.Cells(8).Value, "")).ToString().Trim()
					Dim text10 As String = (If(dataGridViewRow.Cells(9).Value, "")).ToString().Trim()
					Dim text11 As String = (If(dataGridViewRow.Cells(10).Value, "")).ToString().Trim()
					Dim text12 As String = (If(dataGridViewRow.Cells(11).Value, "")).ToString().Trim()
					Dim text13 As String = (If(dataGridViewRow.Cells(12).Value, "")).ToString().Trim()
					Dim text14 As String = (If(dataGridViewRow.Cells(13).Value, "")).ToString().Trim()
					Dim text15 As String = (If(dataGridViewRow.Cells(14).Value, "0")).ToString().Trim()
					Dim text16 As String = (If(dataGridViewRow.Cells(15).Value, "0")).ToString().Trim()
					Dim text17 As String = Conversions.ToString(0)
					Dim flag4 As Boolean = Operators.CompareString((If(dataGridViewRow.Cells(16).Value, "")).ToString().Trim(), "Yes", False) = 0
					If flag4 Then
						text17 = Conversions.ToString(1)
					End If
					Dim text18 As String = (If(dataGridViewRow.Cells(17).Value, "")).ToString().Trim()
					Dim text19 As String = (If(dataGridViewRow.Cells(18).Value, "")).ToString().Trim()
					Dim text20 As String = (If(dataGridViewRow.Cells(19).Value, "")).ToString().Trim()
					Dim value As Object = dataGridViewRow.Cells(20).Value
					Dim text21 As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
					Dim flag5 As Boolean = Operators.CompareString(text3, "", False) = 0
					If flag5 Then
						MessageBox.Show("Customer Name is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.SetFocustoCurrentCell(RowIndex, 2)
					Else
						Dim flag6 As Boolean = Operators.CompareString(text6, "", False) = 0
						If flag6 Then
							MessageBox.Show("State is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetFocustoCurrentCell(RowIndex, 5)
						Else
							Dim flag7 As Boolean = Operators.CompareString(text8, "", False) = 0
							If flag7 Then
								MessageBox.Show("Contact Number is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.SetFocustoCurrentCell(RowIndex, 7)
							Else
								Dim flag8 As Boolean = Not Regex.IsMatch(text8, "^\d{10}$")
								If flag8 Then
									MessageBox.Show("Invalid Contact Number (must be 10 digits).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.SetFocustoCurrentCell(RowIndex, 7)
								Else
									Dim text22 As String = "Cr"
									Dim num2 As Decimal = 0D
									Dim flag9 As Boolean = text13.Contains("Cr") Or text13.Contains("Dr")
									If flag9 Then
										text22 = text13.Substring(text13.Length - 2)
										text13 = text13.Substring(0, text13.Length - 3)
									End If
									Dim text23 As String = "CR"
									Decimal.TryParse(text13, num2)
									Dim text24 As String = "INSERT INTO Customer (ID,CustomerID,[Name],Address,City,State,ZipCode,ContactNo,EmailID," & vbCrLf & "                               GSTIN,CIN,PAN,Optype,Opbal,Remarks,Limit," & vbCrLf & "                               OpbalLoyality,is_loyalityDisable,Tcs,Route,Taround,LStatus,Photo,QrCustomer,DiscPer,DiscStatus,AccountName,AccountNumber,Bank,Branch,IFSCCode, OpLoyalitytype,shippingAddress)" & vbCrLf & "         VALUES (@ID,@CustomerID,@Name,@Address,@City,@State,@ZipCode,@ContactNo,@EmailID," & vbCrLf & "                 @GSTIN,@CIN,@PAN,@Optype,@Opbal,@Remarks,@Limit," & vbCrLf & "                 @OpbalLoyality,@LoyalDisable,@Tcs,@Route,@Taround,'Yes',@Photo,@QrCustomer,@DiscPer,@DiscStatus,@AccountName,@AccountNumber,@Bank,@Branch,@IFSCCode,@OpLoyalitytype,@shippingAddress)"
									Dim text25 As String = "UPDATE Customer SET" & vbCrLf & "             [Name]=@Name," & vbCrLf & "             Address=@Address," & vbCrLf & "             City=@City," & vbCrLf & "             State=@State," & vbCrLf & "             ZipCode=@ZipCode," & vbCrLf & "             ContactNo=@ContactNo," & vbCrLf & "             EmailID=@EmailID," & vbCrLf & "             GSTIN=@GSTIN," & vbCrLf & "             CIN=@CIN," & vbCrLf & "             PAN=@PAN," & vbCrLf & "             Optype=@Optype," & vbCrLf & "             Opbal=@Opbal," & vbCrLf & "             Remarks=@Remarks," & vbCrLf & "             [Limit]=@Limit," & vbCrLf & "             OpbalLoyality=@OpbalLoyality," & vbCrLf & "             is_loyalityDisable=@LoyalDisable," & vbCrLf & "             Tcs=@Tcs," & vbCrLf & "             Route=@Route," & vbCrLf & "             Taround=@Taround," & vbCrLf & "             Photo=@Photo," & vbCrLf & "             QrCustomer=@QrCustomer," & vbCrLf & "             DiscPer=@DiscPer," & vbCrLf & "             DiscStatus=@DiscStatus," & vbCrLf & "             AccountName=@AccountName," & vbCrLf & "             AccountNumber=@AccountNumber," & vbCrLf & "             Bank=@Bank," & vbCrLf & "             Branch=@Branch," & vbCrLf & "             IFSCCode=@IFSCCode," & vbCrLf & "             OpLoyalitytype=@OpLoyalitytype," & vbCrLf & "             shippingAddress=@shippingAddress" & vbCrLf & "         WHERE ID=@ID"
									Dim text26 As String = If((Operators.CompareString(text21, "Save", False) = 0), text24, text25)
									Dim flag10 As Boolean = Operators.CompareString(text21, "Save", False) = 0
									If flag10 Then
										num = Conversions.ToDouble(Me.GenerateID())
										text2 = "C-" + Me.GenerateID()
										dataGridViewRow.Cells(0).Value = num
										dataGridViewRow.Cells(1).Value = text2
										dataGridViewRow.Cells(20).Value = "Update"
										dataGridViewRow.Cells(21).Value = "Delete"
									End If
									Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
										Using sqlCommand As SqlCommand = New SqlCommand(text26, sqlConnection)
											sqlCommand.Parameters.AddWithValue("@ID", num)
											sqlCommand.Parameters.AddWithValue("@CustomerID", text2)
											sqlCommand.Parameters.AddWithValue("@Name", text3)
											sqlCommand.Parameters.AddWithValue("@Address", text4)
											sqlCommand.Parameters.AddWithValue("@City", text5)
											sqlCommand.Parameters.AddWithValue("@State", text6)
											sqlCommand.Parameters.AddWithValue("@ZipCode", text7)
											sqlCommand.Parameters.AddWithValue("@ContactNo", text8)
											sqlCommand.Parameters.AddWithValue("@EmailID", text9)
											sqlCommand.Parameters.AddWithValue("@GSTIN", text10)
											sqlCommand.Parameters.AddWithValue("@CIN", text11)
											sqlCommand.Parameters.AddWithValue("@PAN", text12)
											sqlCommand.Parameters.AddWithValue("@Optype", text22)
											sqlCommand.Parameters.AddWithValue("@Opbal", num2)
											sqlCommand.Parameters.AddWithValue("@Remarks", text14)
											sqlCommand.Parameters.AddWithValue("@Limit", Conversion.Val(text15))
											sqlCommand.Parameters.AddWithValue("@OpbalLoyality", Conversion.Val(text16))
											sqlCommand.Parameters.AddWithValue("@LoyalDisable", text17)
											sqlCommand.Parameters.AddWithValue("@Tcs", text18)
											sqlCommand.Parameters.AddWithValue("@Route", text19)
											sqlCommand.Parameters.AddWithValue("@Taround", text20)
											sqlCommand.Parameters.AddWithValue("@DiscPer", 0)
											sqlCommand.Parameters.AddWithValue("@DiscStatus", "No")
											sqlCommand.Parameters.AddWithValue("@AccountName", "")
											sqlCommand.Parameters.AddWithValue("@AccountNumber", "")
											sqlCommand.Parameters.AddWithValue("@Bank", "")
											sqlCommand.Parameters.AddWithValue("@Branch", "")
											sqlCommand.Parameters.AddWithValue("@IFSCCode", "")
											sqlCommand.Parameters.AddWithValue("@OpLoyalitytype", text23)
											sqlCommand.Parameters.AddWithValue("@shippingAddress", "")
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim buffer As Byte() = memoryStream.GetBuffer()
											Dim sqlParameter As SqlParameter = New SqlParameter("@Photo", SqlDbType.Image)
											sqlParameter.Value = buffer
											sqlCommand.Parameters.Add(sqlParameter)
											Dim memoryStream2 As MemoryStream = New MemoryStream()
											Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
											bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
											Dim buffer2 As Byte() = memoryStream2.GetBuffer()
											Dim sqlParameter2 As SqlParameter = New SqlParameter("@QrCustomer", SqlDbType.Image)
											sqlParameter2.Value = buffer2
											sqlCommand.Parameters.Add(sqlParameter2)
											sqlConnection.Open()
											sqlCommand.ExecuteNonQuery()
											Dim flag11 As Boolean = Operators.CompareString(text22.ToUpper(), "CR".ToUpper(), False) = 0
											If flag11 Then
												ModFunc.LedgerSave(DateAndTime.Today, text3, text2, "Opening Balance", New Decimal(Conversion.Val(text13)), 0D, text2, text3)
												ModFunc.CustomerLedgerSave(DateAndTime.Today, text3, text2, "Opening Balance", New Decimal(Conversion.Val(text13)), 0D, text2, String.Format("{0}-{1}", text3, text2), text14)
											End If
											Dim flag12 As Boolean = Operators.CompareString(text22.ToUpper(), "DR".ToUpper(), False) = 0
											If flag12 Then
												ModFunc.LedgerSave(DateAndTime.Today, text3, text2, "Opening Balance", 0D, New Decimal(Conversion.Val(text13)), text2, text3)
												ModFunc.CustomerLedgerSave(DateAndTime.Today, text3, text2, "Opening Balance", 0D, New Decimal(Conversion.Val(text13)), text2, String.Format("{0}-{1}", text3, text2), text14)
											End If
											Dim flag13 As Boolean = Operators.CompareString(text23.ToUpper(), "CR".ToUpper(), False) = 0
											If flag13 Then
												ModFunc.LedgerSave_Loyality(DateAndTime.Today, text3, text2, "Opening Balance", New Decimal(Conversion.Val(text16)), 0D, text2, text3)
												ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, text3, text2, "Opening Balance", New Decimal(Conversion.Val(text16)), 0D, text2, String.Format("{0}-{1}", text3, text2), text14)
											End If
											Dim flag14 As Boolean = Operators.CompareString(text23.ToUpper(), "DR".ToUpper(), False) = 0
											If flag14 Then
												ModFunc.LedgerSave_Loyality(DateAndTime.Today, text3, text2, "Opening Balance", 0D, New Decimal(Conversion.Val(text16)), text2, text3)
												ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, text3, text2, "Opening Balance", 0D, New Decimal(Conversion.Val(text16)), text2, String.Format("{0}-{1}", text3, text2), text14)
											End If
											ModFunc.LogFunc(Me.lblUser.Text, "added the new Customer having Customer id '" + text2 + "'")
										End Using
									End Using
									MessageBox.Show("Record " + If((Operators.CompareString(text21, "Save", False) = 0), "inserted", "updated") + " successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Dim flag15 As Boolean = Operators.CompareString(text21, "Save", False) = 0
									If flag15 Then
										Me.AddNewRow()
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06001A43 RID: 6723 RVA: 0x001202A0 File Offset: 0x0011E4A0
		Public Sub DeleteCustomer(RowIndex As Integer, ColumnIndex As Integer)
			Dim flag As Boolean = ColumnIndex <> Me.dgw.Columns(21).Index OrElse RowIndex < 0
			If Not flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.Rows(RowIndex)
				Dim num As Integer = CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))))
				Dim value As Object = dataGridViewRow.Cells(21).Value
				Dim text As String = If(If((value IsNot Nothing), value.ToString().Trim(), Nothing), "")
				Dim flag2 As Boolean = Operators.CompareString(text, "Delete", False) <> 0
				If Not flag2 Then
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete this customer record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
					Dim flag3 As Boolean = dialogResult = DialogResult.No
					If Not flag3 Then
						dataGridViewRow.Cells(20).Value = "Save"
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM Customer WHERE ID=@ID", sqlConnection)
								sqlCommand.Parameters.AddWithValue("@ID", num)
								sqlConnection.Open()
								sqlCommand.ExecuteNonQuery()
							End Using
						End Using
						MessageBox.Show("Record Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End If
				End If
			End If
		End Sub

		' Token: 0x06001A44 RID: 6724 RVA: 0x00013B46 File Offset: 0x00011D46
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x06001A45 RID: 6725 RVA: 0x00120428 File Offset: 0x0011E628
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x06001A46 RID: 6726 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub Reset()
		End Sub

		' Token: 0x06001A47 RID: 6727 RVA: 0x0012045C File Offset: 0x0011E65C
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkSelectAll.Checked
			If checked Then
				Me.dgw.SelectAll()
			Else
				Me.dgw.ClearSelection()
			End If
		End Sub

		' Token: 0x06001A48 RID: 6728 RVA: 0x00120498 File Offset: 0x0011E698
		Public Sub UpdateState(currentRow As Integer, currentColumn As Integer, selectedState As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = ""
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedState
			Me.dgw.EndEdit()
			Me.dgw.RefreshEdit()
			Me.dgw.Invalidate()
			Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(currentColumn + 1)
			Me.dgw.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.dgw.BeginEdit(True)
			End Sub))
		End Sub

		' Token: 0x06001A49 RID: 6729 RVA: 0x00120560 File Offset: 0x0011E760
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM customer ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06001A4A RID: 6730 RVA: 0x001206CC File Offset: 0x0011E8CC
		Public Function GenerateScode(supplierName As String) As String
			Dim text As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			Dim text2 As String = DateAndTime.Now.ToString("ss")
			Dim text3 As String = text2
			text3 = text3 + Convert.ToString(text + supplierName) + text2
			Dim num As Integer = Integer.Parse(Conversions.ToString(4))
			Dim text4 As String = String.Empty
			Dim num2 As Integer = num - 1
			For i As Integer = 0 To num2
				Dim text5 As String = String.Empty
				Do
					Dim num3 As Integer = New Random().[Next](0, text3.Length)
					text5 = text3.ToCharArray()(num3).ToString()
				Loop While text4.IndexOf(text5) <> -1
				text4 += text5
			Next
			Return text4
		End Function

		' Token: 0x06001A4B RID: 6731 RVA: 0x00013B50 File Offset: 0x00011D50
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06001A4C RID: 6732 RVA: 0x00120794 File Offset: 0x0011E994
		Friend Async Sub UpdateAccountType(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Dim opbal As String = Me.dgw.Rows(currentRow).Cells(currentColumn).Value.ToString().Trim()
			Dim flag As Boolean = opbal.Contains("Cr") Or opbal.Contains("Dr")
			If flag Then
				opbal = opbal.Substring(0, opbal.Length - 3)
			End If
			Dim openingBalance As Double = Conversion.Val(opbal.Trim())
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = openingBalance.ToString("0.00") + " " + selectedType
			Dim nextCol As Integer = currentColumn + 1
			Dim flag2 As Boolean = nextCol < Me.dgw.Columns.Count
			If flag2 Then
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(nextCol)
			End If
			Me.dgw.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim editingControl As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			If editingControl IsNot Nothing Then
				editingControl.SelectionStart = 0
				editingControl.SelectionLength = editingControl.Text.Length
			End If
		End Sub

		' Token: 0x06001A4D RID: 6733 RVA: 0x001207E4 File Offset: 0x0011E9E4
		Public Sub Getdata_bySearch()
			Try
				Dim text As String = Me.txtSearchProduct.Text.Trim()
				Dim selectedIndex As Integer = Me.cmbSearchCat.SelectedIndex
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "SELECT TOP " + Me.txtTopResult.Text + " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]),RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode)," & vbCrLf & "                                    RTRIM(ContactNo),RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(Opbal),RTRIM(Remarks),RTRIM(Limit)," & vbCrLf & "                                    RTRIM(OpbalLoyality),is_loyalityDisable, RTRIM(Tcs), RTRIM(Route),RTRIM(Taround),RTRIM(Optype) from Customer  where LStatus = 'Yes'"
				Dim flag As Boolean = selectedIndex = 0
				If flag Then
					text2 += " and RTrim(Name) like @search order by id desc"
				Else
					text2 += " and RTrim(ContactNo) like @search order by id desc"
				End If
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.AddWithValue("@search", "%" + text + "%")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim text3 As String = "No"
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(16), 1, False)
					If flag2 Then
						text3 = "Yes"
					End If
					Dim obj As Object = Operators.ConcatenateObject(Operators.ConcatenateObject(ModCommonClasses.rdr(12), " "), ModCommonClasses.rdr(20))
					Dim num As Integer = Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), obj, ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), text3, ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19) })
					Me.dgw.Rows(num).Cells(20).Value = "Update"
					Me.dgw.Rows(num).Cells(21).Value = "Delete"
				End While
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
				Dim flag3 As Boolean = Me.dgw.RowCount > 0
				If flag3 Then
					Me.dgw.CurrentCell = Me.dgw.Rows(0).Cells(2)
				End If
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001A4E RID: 6734 RVA: 0x00120B80 File Offset: 0x0011ED80
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex <> -1
			If flag Then
				Me.Getdata_bySearch()
			End If
		End Sub

		' Token: 0x06001A4F RID: 6735 RVA: 0x00013B5A File Offset: 0x00011D5A
		Private Sub cmbSearchCat_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.txtSearchProduct.Text = ""
		End Sub

		' Token: 0x06001A50 RID: 6736 RVA: 0x00120BAC File Offset: 0x0011EDAC
		Friend Async Sub UpdateYesNo(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.dgw.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			Dim flag As Boolean = nextCol < Me.dgw.Columns.Count
			If flag Then
				Me.dgw.CurrentCell = Me.dgw.Rows(currentRow).Cells(nextCol)
			End If
			Me.dgw.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.dgw.BeginEdit(True)
			Me.dgw.ClearSelection()
			Dim editingControl As TextBox = TryCast(Me.dgw.EditingControl, TextBox)
			If editingControl IsNot Nothing Then
				editingControl.SelectionStart = 0
				editingControl.SelectionLength = editingControl.Text.Length
			End If
		End Sub

		' Token: 0x04000A38 RID: 2616
		Public eventSender As Object

		' Token: 0x04000A39 RID: 2617
		Private prevCell As DataGridViewCell
	End Class
End Namespace
