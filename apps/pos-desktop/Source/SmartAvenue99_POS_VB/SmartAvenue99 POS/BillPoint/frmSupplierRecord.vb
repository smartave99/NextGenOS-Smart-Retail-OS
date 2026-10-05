Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005D5 RID: 1493
	<DesignerGenerated()>
	Public Partial Class frmSupplierRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601242A RID: 74794 RVA: 0x0007D377 File Offset: 0x0007B577
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplierRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700715A RID: 29018
		' (get) Token: 0x0601242D RID: 74797 RVA: 0x0007D3A9 File Offset: 0x0007B5A9
		' (set) Token: 0x0601242E RID: 74798 RVA: 0x0007D3B3 File Offset: 0x0007B5B3
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700715B RID: 29019
		' (get) Token: 0x0601242F RID: 74799 RVA: 0x0007D3BC File Offset: 0x0007B5BC
		' (set) Token: 0x06012430 RID: 74800 RVA: 0x00A819B0 File Offset: 0x00A7FBB0
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

		' Token: 0x1700715C RID: 29020
		' (get) Token: 0x06012431 RID: 74801 RVA: 0x0007D3C6 File Offset: 0x0007B5C6
		' (set) Token: 0x06012432 RID: 74802 RVA: 0x0007D3D0 File Offset: 0x0007B5D0
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700715D RID: 29021
		' (get) Token: 0x06012433 RID: 74803 RVA: 0x0007D3D9 File Offset: 0x0007B5D9
		' (set) Token: 0x06012434 RID: 74804 RVA: 0x00A81A2C File Offset: 0x00A7FC2C
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700715E RID: 29022
		' (get) Token: 0x06012435 RID: 74805 RVA: 0x0007D3E3 File Offset: 0x0007B5E3
		' (set) Token: 0x06012436 RID: 74806 RVA: 0x0007D3ED File Offset: 0x0007B5ED
		Friend Overridable Property Label2 As Label

		' Token: 0x1700715F RID: 29023
		' (get) Token: 0x06012437 RID: 74807 RVA: 0x0007D3F6 File Offset: 0x0007B5F6
		' (set) Token: 0x06012438 RID: 74808 RVA: 0x0007D400 File Offset: 0x0007B600
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17007160 RID: 29024
		' (get) Token: 0x06012439 RID: 74809 RVA: 0x0007D409 File Offset: 0x0007B609
		' (set) Token: 0x0601243A RID: 74810 RVA: 0x00A81A70 File Offset: 0x00A7FC70
		Private _txtSupplierName As TextBox
		Friend Overridable Property txtSupplierName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
				Dim textBox As TextBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierName = value
				textBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007161 RID: 29025
		' (get) Token: 0x0601243B RID: 74811 RVA: 0x0007D413 File Offset: 0x0007B613
		' (set) Token: 0x0601243C RID: 74812 RVA: 0x0007D41D File Offset: 0x0007B61D
		Friend Overridable Property Label3 As Label

		' Token: 0x17007162 RID: 29026
		' (get) Token: 0x0601243D RID: 74813 RVA: 0x0007D426 File Offset: 0x0007B626
		' (set) Token: 0x0601243E RID: 74814 RVA: 0x0007D430 File Offset: 0x0007B630
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17007163 RID: 29027
		' (get) Token: 0x0601243F RID: 74815 RVA: 0x0007D439 File Offset: 0x0007B639
		' (set) Token: 0x06012440 RID: 74816 RVA: 0x00A81AB4 File Offset: 0x00A7FCB4
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtContactNo_TextChanged
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007164 RID: 29028
		' (get) Token: 0x06012441 RID: 74817 RVA: 0x0007D443 File Offset: 0x0007B643
		' (set) Token: 0x06012442 RID: 74818 RVA: 0x0007D44D File Offset: 0x0007B64D
		Friend Overridable Property Label4 As Label

		' Token: 0x17007165 RID: 29029
		' (get) Token: 0x06012443 RID: 74819 RVA: 0x0007D456 File Offset: 0x0007B656
		' (set) Token: 0x06012444 RID: 74820 RVA: 0x0007D460 File Offset: 0x0007B660
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17007166 RID: 29030
		' (get) Token: 0x06012445 RID: 74821 RVA: 0x0007D469 File Offset: 0x0007B669
		' (set) Token: 0x06012446 RID: 74822 RVA: 0x0007D473 File Offset: 0x0007B673
		Friend Overridable Property Label1 As Label

		' Token: 0x17007167 RID: 29031
		' (get) Token: 0x06012447 RID: 74823 RVA: 0x0007D47C File Offset: 0x0007B67C
		' (set) Token: 0x06012448 RID: 74824 RVA: 0x0007D486 File Offset: 0x0007B686
		Friend Overridable Property lblSet As Label

		' Token: 0x17007168 RID: 29032
		' (get) Token: 0x06012449 RID: 74825 RVA: 0x0007D48F File Offset: 0x0007B68F
		' (set) Token: 0x0601244A RID: 74826 RVA: 0x0007D499 File Offset: 0x0007B699
		Friend Overridable Property Label5 As Label

		' Token: 0x17007169 RID: 29033
		' (get) Token: 0x0601244B RID: 74827 RVA: 0x0007D4A2 File Offset: 0x0007B6A2
		' (set) Token: 0x0601244C RID: 74828 RVA: 0x0007D4AC File Offset: 0x0007B6AC
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700716A RID: 29034
		' (get) Token: 0x0601244D RID: 74829 RVA: 0x0007D4B5 File Offset: 0x0007B6B5
		' (set) Token: 0x0601244E RID: 74830 RVA: 0x0007D4BF File Offset: 0x0007B6BF
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700716B RID: 29035
		' (get) Token: 0x0601244F RID: 74831 RVA: 0x0007D4C8 File Offset: 0x0007B6C8
		' (set) Token: 0x06012450 RID: 74832 RVA: 0x0007D4D2 File Offset: 0x0007B6D2
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700716C RID: 29036
		' (get) Token: 0x06012451 RID: 74833 RVA: 0x0007D4DB File Offset: 0x0007B6DB
		' (set) Token: 0x06012452 RID: 74834 RVA: 0x0007D4E5 File Offset: 0x0007B6E5
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700716D RID: 29037
		' (get) Token: 0x06012453 RID: 74835 RVA: 0x0007D4EE File Offset: 0x0007B6EE
		' (set) Token: 0x06012454 RID: 74836 RVA: 0x0007D4F8 File Offset: 0x0007B6F8
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700716E RID: 29038
		' (get) Token: 0x06012455 RID: 74837 RVA: 0x0007D501 File Offset: 0x0007B701
		' (set) Token: 0x06012456 RID: 74838 RVA: 0x0007D50B File Offset: 0x0007B70B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700716F RID: 29039
		' (get) Token: 0x06012457 RID: 74839 RVA: 0x0007D514 File Offset: 0x0007B714
		' (set) Token: 0x06012458 RID: 74840 RVA: 0x0007D51E File Offset: 0x0007B71E
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17007170 RID: 29040
		' (get) Token: 0x06012459 RID: 74841 RVA: 0x0007D527 File Offset: 0x0007B727
		' (set) Token: 0x0601245A RID: 74842 RVA: 0x0007D531 File Offset: 0x0007B731
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17007171 RID: 29041
		' (get) Token: 0x0601245B RID: 74843 RVA: 0x0007D53A File Offset: 0x0007B73A
		' (set) Token: 0x0601245C RID: 74844 RVA: 0x0007D544 File Offset: 0x0007B744
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007172 RID: 29042
		' (get) Token: 0x0601245D RID: 74845 RVA: 0x0007D54D File Offset: 0x0007B74D
		' (set) Token: 0x0601245E RID: 74846 RVA: 0x0007D557 File Offset: 0x0007B757
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17007173 RID: 29043
		' (get) Token: 0x0601245F RID: 74847 RVA: 0x0007D560 File Offset: 0x0007B760
		' (set) Token: 0x06012460 RID: 74848 RVA: 0x0007D56A File Offset: 0x0007B76A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17007174 RID: 29044
		' (get) Token: 0x06012461 RID: 74849 RVA: 0x0007D573 File Offset: 0x0007B773
		' (set) Token: 0x06012462 RID: 74850 RVA: 0x0007D57D File Offset: 0x0007B77D
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17007175 RID: 29045
		' (get) Token: 0x06012463 RID: 74851 RVA: 0x0007D586 File Offset: 0x0007B786
		' (set) Token: 0x06012464 RID: 74852 RVA: 0x0007D590 File Offset: 0x0007B790
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17007176 RID: 29046
		' (get) Token: 0x06012465 RID: 74853 RVA: 0x0007D599 File Offset: 0x0007B799
		' (set) Token: 0x06012466 RID: 74854 RVA: 0x0007D5A3 File Offset: 0x0007B7A3
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17007177 RID: 29047
		' (get) Token: 0x06012467 RID: 74855 RVA: 0x0007D5AC File Offset: 0x0007B7AC
		' (set) Token: 0x06012468 RID: 74856 RVA: 0x0007D5B6 File Offset: 0x0007B7B6
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17007178 RID: 29048
		' (get) Token: 0x06012469 RID: 74857 RVA: 0x0007D5BF File Offset: 0x0007B7BF
		' (set) Token: 0x0601246A RID: 74858 RVA: 0x0007D5C9 File Offset: 0x0007B7C9
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17007179 RID: 29049
		' (get) Token: 0x0601246B RID: 74859 RVA: 0x0007D5D2 File Offset: 0x0007B7D2
		' (set) Token: 0x0601246C RID: 74860 RVA: 0x0007D5DC File Offset: 0x0007B7DC
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700717A RID: 29050
		' (get) Token: 0x0601246D RID: 74861 RVA: 0x0007D5E5 File Offset: 0x0007B7E5
		' (set) Token: 0x0601246E RID: 74862 RVA: 0x0007D5EF File Offset: 0x0007B7EF
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x1700717B RID: 29051
		' (get) Token: 0x0601246F RID: 74863 RVA: 0x0007D5F8 File Offset: 0x0007B7F8
		' (set) Token: 0x06012470 RID: 74864 RVA: 0x0007D602 File Offset: 0x0007B802
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700717C RID: 29052
		' (get) Token: 0x06012471 RID: 74865 RVA: 0x0007D60B File Offset: 0x0007B80B
		' (set) Token: 0x06012472 RID: 74866 RVA: 0x0007D615 File Offset: 0x0007B815
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700717D RID: 29053
		' (get) Token: 0x06012473 RID: 74867 RVA: 0x0007D61E File Offset: 0x0007B81E
		' (set) Token: 0x06012474 RID: 74868 RVA: 0x0007D628 File Offset: 0x0007B828
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700717E RID: 29054
		' (get) Token: 0x06012475 RID: 74869 RVA: 0x0007D631 File Offset: 0x0007B831
		' (set) Token: 0x06012476 RID: 74870 RVA: 0x0007D63B File Offset: 0x0007B83B
		Friend Overridable Property Column12 As DataGridViewImageColumn

		' Token: 0x1700717F RID: 29055
		' (get) Token: 0x06012477 RID: 74871 RVA: 0x0007D644 File Offset: 0x0007B844
		' (set) Token: 0x06012478 RID: 74872 RVA: 0x0007D64E File Offset: 0x0007B84E
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17007180 RID: 29056
		' (get) Token: 0x06012479 RID: 74873 RVA: 0x0007D657 File Offset: 0x0007B857
		' (set) Token: 0x0601247A RID: 74874 RVA: 0x0007D661 File Offset: 0x0007B861
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17007181 RID: 29057
		' (get) Token: 0x0601247B RID: 74875 RVA: 0x0007D66A File Offset: 0x0007B86A
		' (set) Token: 0x0601247C RID: 74876 RVA: 0x0007D674 File Offset: 0x0007B874
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17007182 RID: 29058
		' (get) Token: 0x0601247D RID: 74877 RVA: 0x0007D67D File Offset: 0x0007B87D
		' (set) Token: 0x0601247E RID: 74878 RVA: 0x00A81AF8 File Offset: 0x00A7FCF8
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click_1
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007183 RID: 29059
		' (get) Token: 0x0601247F RID: 74879 RVA: 0x0007D687 File Offset: 0x0007B887
		' (set) Token: 0x06012480 RID: 74880 RVA: 0x00A81B3C File Offset: 0x00A7FD3C
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click_1
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007184 RID: 29060
		' (get) Token: 0x06012481 RID: 74881 RVA: 0x0007D691 File Offset: 0x0007B891
		' (set) Token: 0x06012482 RID: 74882 RVA: 0x00A81B80 File Offset: 0x00A7FD80
		Private _btnaddCustomer As GelButton
		Friend Overridable Property btnaddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnaddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnaddCustomer_Click_1
				Dim gelButton As GelButton = Me._btnaddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnaddCustomer = value
				gelButton = Me._btnaddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007185 RID: 29061
		' (get) Token: 0x06012483 RID: 74883 RVA: 0x0007D69B File Offset: 0x0007B89B
		' (set) Token: 0x06012484 RID: 74884 RVA: 0x0007D6A5 File Offset: 0x0007B8A5
		Friend Overridable Property Label10 As Label

		' Token: 0x17007186 RID: 29062
		' (get) Token: 0x06012485 RID: 74885 RVA: 0x0007D6AE File Offset: 0x0007B8AE
		' (set) Token: 0x06012486 RID: 74886 RVA: 0x0007D6B8 File Offset: 0x0007B8B8
		Friend Overridable Property Label11 As Label

		' Token: 0x17007187 RID: 29063
		' (get) Token: 0x06012487 RID: 74887 RVA: 0x0007D6C1 File Offset: 0x0007B8C1
		' (set) Token: 0x06012488 RID: 74888 RVA: 0x0007D6CB File Offset: 0x0007B8CB
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x06012489 RID: 74889 RVA: 0x00A81BC4 File Offset: 0x00A7FDC4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks),Photo,RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier order by name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601248A RID: 74890 RVA: 0x00A81E30 File Offset: 0x00A80030
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601248B RID: 74891 RVA: 0x00A81EB8 File Offset: 0x00A800B8
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

		' Token: 0x0601248C RID: 74892 RVA: 0x00A82030 File Offset: 0x00A80230
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

		' Token: 0x0601248D RID: 74893 RVA: 0x00A820FC File Offset: 0x00A802FC
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

		' Token: 0x0601248E RID: 74894 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601248F RID: 74895 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012490 RID: 74896 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012491 RID: 74897 RVA: 0x00A821C8 File Offset: 0x00A803C8
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06012492 RID: 74898 RVA: 0x00A821F0 File Offset: 0x00A803F0
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Supplier Entry", False) = 0
					If flag2 Then
						MyProject.Forms.frmSupplier.Show()
						MyBase.Hide()
						MyProject.Forms.frmSupplier.btnUpdate.Enabled = True
						MyProject.Forms.frmSupplier.btnDelete.Enabled = True
						MyProject.Forms.frmSupplier.btnSave.Enabled = False
						MyProject.Forms.frmSupplier.chkvalid()
						Me.lblSet.Text = ""
						MyProject.Forms.frmSupplier.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSupplier.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSupplier.cmbSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSupplier.txtSupName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSupplier.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmSupplier.txtCity.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmSupplier.cmbState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmSupplier.txtZipCode.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmSupplier.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSupplier.txtPhNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSupplier.txtEmailID.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmSupplier.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmSupplier.txtCIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmSupplier.txtPAN.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmSupplier.txtAccountName.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmSupplier.txtAccountNo.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmSupplier.txtBank.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmSupplier.txtBranch.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmSupplier.txtIFSCcode.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmSupplier.txtOpeningBalance.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmSupplier.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
						MyProject.Forms.frmSupplier.cmbOpeningBalanceType.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmSupplier.txtRemarks.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmSupplier.txtcrlimit.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmSupplier.cmbcrlimit.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmSupplier.txtSCode.Text = dataGridViewRow.Cells(23).Value.ToString()
						Dim array As Byte() = CType(dataGridViewRow.Cells(20).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						MyProject.Forms.frmSupplier.Picture.Image = Image.FromStream(memoryStream)
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag3 Then
						MyProject.Forms.frmPayment.Show()
						MyBase.Hide()
						MyProject.Forms.frmPayment.txtSup_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPayment.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPayment.cmbSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPayment.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPayment.txtCity.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPayment.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPayment.GetSupplierBalance()
						Me.lblSet.Text = ""
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.lblSet.Text, "Purchase", False) = 0
					If flag4 Then
						MyProject.Forms.frmPurchaseEntry.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseEntry.txtSup_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSuplLimit.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtSuplLimitstatus.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.txtScode.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPurchaseEntry.GetSupplierBalance()
						MyProject.Forms.frmPurchaseEntry.btnSelection.Enabled = False
						Me.lblSet.Text = ""
					End If
					Dim flag5 As Boolean = Operators.CompareString(Me.lblSet.Text, "PO", False) = 0
					If flag5 Then
						MyProject.Forms.frmPurchaseOrder.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseOrder.txtSup_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.cmbSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPurchaseOrder.GetSupplierBalance()
						Me.lblSet.Text = ""
					End If
					Dim flag6 As Boolean = Operators.CompareString(Me.lblSet.Text, "Supplier Ledger", False) = 0
					If flag6 Then
						MyProject.Forms.frmSupplierLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmSupplierLedger.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSupplierLedger.txtSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag7 As Boolean = Operators.CompareString(Me.lblSet.Text, "Purchase Stock", False) = 0
					If flag7 Then
						MyProject.Forms.frmPurchaseStock.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseStock.txtSupplierID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseStock.txtSupplierName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012493 RID: 74899 RVA: 0x0007D6D4 File Offset: 0x0007B8D4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06012494 RID: 74900 RVA: 0x00A82DAC File Offset: 0x00A80FAC
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

		' Token: 0x06012495 RID: 74901 RVA: 0x00A82E94 File Offset: 0x00A81094
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks),Photo,RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where name like N'", Me.txtSupplierName.Text, "%' order by name" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012496 RID: 74902 RVA: 0x00A83118 File Offset: 0x00A81318
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks),Photo,RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where City like N'", Me.txtCity.Text, "%' order by city" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012497 RID: 74903 RVA: 0x00A8339C File Offset: 0x00A8159C
		Public Sub Reset()
			Me.txtSupplierName.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtCity.Text = ""
			Me.txtTopResult.Text = "10"
			Me.Getdata()
		End Sub

		' Token: 0x06012498 RID: 74904 RVA: 0x00A833F8 File Offset: 0x00A815F8
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks),Photo,RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where ContactNo like N'", Me.txtContactNo.Text, "%' order by city" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012499 RID: 74905 RVA: 0x00A8367C File Offset: 0x00A8187C
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.Label5.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x0601249A RID: 74906 RVA: 0x0007D6DE File Offset: 0x0007B8DE
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601249B RID: 74907 RVA: 0x00A836DC File Offset: 0x00A818DC
		Private Sub btnExportExcel_Click_1(sender As Object, e As EventArgs)
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

		' Token: 0x0601249C RID: 74908 RVA: 0x00A8367C File Offset: 0x00A8187C
		Private Sub btnaddCustomer_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.Label5.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x0601249D RID: 74909 RVA: 0x0007D6DE File Offset: 0x0007B8DE
		Private Sub btnReset_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601249E RID: 74910 RVA: 0x00A836DC File Offset: 0x00A818DC
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

		' Token: 0x0601249F RID: 74911 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplierRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006DE5 RID: 28133
		Private num1 As Decimal

		' Token: 0x04006DE6 RID: 28134
		Private num2 As Decimal

		' Token: 0x04006DE7 RID: 28135
		Private num3 As Decimal

		' Token: 0x04006DE8 RID: 28136
		Private str As String
	End Class
End Namespace
