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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200056B RID: 1387
	<DesignerGenerated()>
	Public Partial Class frmPurchaseReturnRecord_GSTR
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010D64 RID: 68964 RVA: 0x00073D5B File Offset: 0x00071F5B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseReturnRecord_GSTR_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006861 RID: 26721
		' (get) Token: 0x06010D67 RID: 68967 RVA: 0x00073D8D File Offset: 0x00071F8D
		' (set) Token: 0x06010D68 RID: 68968 RVA: 0x00073D97 File Offset: 0x00071F97
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006862 RID: 26722
		' (get) Token: 0x06010D69 RID: 68969 RVA: 0x00073DA0 File Offset: 0x00071FA0
		' (set) Token: 0x06010D6A RID: 68970 RVA: 0x009CE4A4 File Offset: 0x009CC6A4
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006863 RID: 26723
		' (get) Token: 0x06010D6B RID: 68971 RVA: 0x00073DAA File Offset: 0x00071FAA
		' (set) Token: 0x06010D6C RID: 68972 RVA: 0x00073DB4 File Offset: 0x00071FB4
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006864 RID: 26724
		' (get) Token: 0x06010D6D RID: 68973 RVA: 0x00073DBD File Offset: 0x00071FBD
		' (set) Token: 0x06010D6E RID: 68974 RVA: 0x00073DC7 File Offset: 0x00071FC7
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006865 RID: 26725
		' (get) Token: 0x06010D6F RID: 68975 RVA: 0x00073DD0 File Offset: 0x00071FD0
		' (set) Token: 0x06010D70 RID: 68976 RVA: 0x00073DDA File Offset: 0x00071FDA
		Friend Overridable Property Label2 As Label

		' Token: 0x17006866 RID: 26726
		' (get) Token: 0x06010D71 RID: 68977 RVA: 0x00073DE3 File Offset: 0x00071FE3
		' (set) Token: 0x06010D72 RID: 68978 RVA: 0x00073DED File Offset: 0x00071FED
		Friend Overridable Property Label4 As Label

		' Token: 0x17006867 RID: 26727
		' (get) Token: 0x06010D73 RID: 68979 RVA: 0x00073DF6 File Offset: 0x00071FF6
		' (set) Token: 0x06010D74 RID: 68980 RVA: 0x00073E00 File Offset: 0x00072000
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006868 RID: 26728
		' (get) Token: 0x06010D75 RID: 68981 RVA: 0x00073E09 File Offset: 0x00072009
		' (set) Token: 0x06010D76 RID: 68982 RVA: 0x00073E13 File Offset: 0x00072013
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006869 RID: 26729
		' (get) Token: 0x06010D77 RID: 68983 RVA: 0x00073E1C File Offset: 0x0007201C
		' (set) Token: 0x06010D78 RID: 68984 RVA: 0x00073E26 File Offset: 0x00072026
		Friend Overridable Property Label1 As Label

		' Token: 0x1700686A RID: 26730
		' (get) Token: 0x06010D79 RID: 68985 RVA: 0x00073E2F File Offset: 0x0007202F
		' (set) Token: 0x06010D7A RID: 68986 RVA: 0x00073E39 File Offset: 0x00072039
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700686B RID: 26731
		' (get) Token: 0x06010D7B RID: 68987 RVA: 0x00073E42 File Offset: 0x00072042
		' (set) Token: 0x06010D7C RID: 68988 RVA: 0x00073E4C File Offset: 0x0007204C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700686C RID: 26732
		' (get) Token: 0x06010D7D RID: 68989 RVA: 0x00073E55 File Offset: 0x00072055
		' (set) Token: 0x06010D7E RID: 68990 RVA: 0x009CE4E8 File Offset: 0x009CC6E8
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

		' Token: 0x1700686D RID: 26733
		' (get) Token: 0x06010D7F RID: 68991 RVA: 0x00073E5F File Offset: 0x0007205F
		' (set) Token: 0x06010D80 RID: 68992 RVA: 0x00073E69 File Offset: 0x00072069
		Friend Overridable Property Label5 As Label

		' Token: 0x1700686E RID: 26734
		' (get) Token: 0x06010D81 RID: 68993 RVA: 0x00073E72 File Offset: 0x00072072
		' (set) Token: 0x06010D82 RID: 68994 RVA: 0x00073E7C File Offset: 0x0007207C
		Friend Overridable Property Label3 As Label

		' Token: 0x1700686F RID: 26735
		' (get) Token: 0x06010D83 RID: 68995 RVA: 0x00073E85 File Offset: 0x00072085
		' (set) Token: 0x06010D84 RID: 68996 RVA: 0x009CE52C File Offset: 0x009CC72C
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

		' Token: 0x17006870 RID: 26736
		' (get) Token: 0x06010D85 RID: 68997 RVA: 0x00073E8F File Offset: 0x0007208F
		' (set) Token: 0x06010D86 RID: 68998 RVA: 0x009CE570 File Offset: 0x009CC770
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

		' Token: 0x17006871 RID: 26737
		' (get) Token: 0x06010D87 RID: 68999 RVA: 0x00073E99 File Offset: 0x00072099
		' (set) Token: 0x06010D88 RID: 69000 RVA: 0x00073EA3 File Offset: 0x000720A3
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006872 RID: 26738
		' (get) Token: 0x06010D89 RID: 69001 RVA: 0x00073EAC File Offset: 0x000720AC
		' (set) Token: 0x06010D8A RID: 69002 RVA: 0x009CE5B4 File Offset: 0x009CC7B4
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006873 RID: 26739
		' (get) Token: 0x06010D8B RID: 69003 RVA: 0x00073EB6 File Offset: 0x000720B6
		' (set) Token: 0x06010D8C RID: 69004 RVA: 0x00073EC0 File Offset: 0x000720C0
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006874 RID: 26740
		' (get) Token: 0x06010D8D RID: 69005 RVA: 0x00073EC9 File Offset: 0x000720C9
		' (set) Token: 0x06010D8E RID: 69006 RVA: 0x00073ED3 File Offset: 0x000720D3
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006875 RID: 26741
		' (get) Token: 0x06010D8F RID: 69007 RVA: 0x00073EDC File Offset: 0x000720DC
		' (set) Token: 0x06010D90 RID: 69008 RVA: 0x00073EE6 File Offset: 0x000720E6
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17006876 RID: 26742
		' (get) Token: 0x06010D91 RID: 69009 RVA: 0x00073EEF File Offset: 0x000720EF
		' (set) Token: 0x06010D92 RID: 69010 RVA: 0x00073EF9 File Offset: 0x000720F9
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006877 RID: 26743
		' (get) Token: 0x06010D93 RID: 69011 RVA: 0x00073F02 File Offset: 0x00072102
		' (set) Token: 0x06010D94 RID: 69012 RVA: 0x00073F0C File Offset: 0x0007210C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006878 RID: 26744
		' (get) Token: 0x06010D95 RID: 69013 RVA: 0x00073F15 File Offset: 0x00072115
		' (set) Token: 0x06010D96 RID: 69014 RVA: 0x00073F1F File Offset: 0x0007211F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006879 RID: 26745
		' (get) Token: 0x06010D97 RID: 69015 RVA: 0x00073F28 File Offset: 0x00072128
		' (set) Token: 0x06010D98 RID: 69016 RVA: 0x00073F32 File Offset: 0x00072132
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700687A RID: 26746
		' (get) Token: 0x06010D99 RID: 69017 RVA: 0x00073F3B File Offset: 0x0007213B
		' (set) Token: 0x06010D9A RID: 69018 RVA: 0x00073F45 File Offset: 0x00072145
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700687B RID: 26747
		' (get) Token: 0x06010D9B RID: 69019 RVA: 0x00073F4E File Offset: 0x0007214E
		' (set) Token: 0x06010D9C RID: 69020 RVA: 0x00073F58 File Offset: 0x00072158
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700687C RID: 26748
		' (get) Token: 0x06010D9D RID: 69021 RVA: 0x00073F61 File Offset: 0x00072161
		' (set) Token: 0x06010D9E RID: 69022 RVA: 0x00073F6B File Offset: 0x0007216B
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700687D RID: 26749
		' (get) Token: 0x06010D9F RID: 69023 RVA: 0x00073F74 File Offset: 0x00072174
		' (set) Token: 0x06010DA0 RID: 69024 RVA: 0x00073F7E File Offset: 0x0007217E
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x1700687E RID: 26750
		' (get) Token: 0x06010DA1 RID: 69025 RVA: 0x00073F87 File Offset: 0x00072187
		' (set) Token: 0x06010DA2 RID: 69026 RVA: 0x00073F91 File Offset: 0x00072191
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700687F RID: 26751
		' (get) Token: 0x06010DA3 RID: 69027 RVA: 0x00073F9A File Offset: 0x0007219A
		' (set) Token: 0x06010DA4 RID: 69028 RVA: 0x00073FA4 File Offset: 0x000721A4
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17006880 RID: 26752
		' (get) Token: 0x06010DA5 RID: 69029 RVA: 0x00073FAD File Offset: 0x000721AD
		' (set) Token: 0x06010DA6 RID: 69030 RVA: 0x00073FB7 File Offset: 0x000721B7
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006881 RID: 26753
		' (get) Token: 0x06010DA7 RID: 69031 RVA: 0x00073FC0 File Offset: 0x000721C0
		' (set) Token: 0x06010DA8 RID: 69032 RVA: 0x00073FCA File Offset: 0x000721CA
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006882 RID: 26754
		' (get) Token: 0x06010DA9 RID: 69033 RVA: 0x00073FD3 File Offset: 0x000721D3
		' (set) Token: 0x06010DAA RID: 69034 RVA: 0x00073FDD File Offset: 0x000721DD
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006883 RID: 26755
		' (get) Token: 0x06010DAB RID: 69035 RVA: 0x00073FE6 File Offset: 0x000721E6
		' (set) Token: 0x06010DAC RID: 69036 RVA: 0x00073FF0 File Offset: 0x000721F0
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17006884 RID: 26756
		' (get) Token: 0x06010DAD RID: 69037 RVA: 0x00073FF9 File Offset: 0x000721F9
		' (set) Token: 0x06010DAE RID: 69038 RVA: 0x00074003 File Offset: 0x00072203
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006885 RID: 26757
		' (get) Token: 0x06010DAF RID: 69039 RVA: 0x0007400C File Offset: 0x0007220C
		' (set) Token: 0x06010DB0 RID: 69040 RVA: 0x00074016 File Offset: 0x00072216
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006886 RID: 26758
		' (get) Token: 0x06010DB1 RID: 69041 RVA: 0x0007401F File Offset: 0x0007221F
		' (set) Token: 0x06010DB2 RID: 69042 RVA: 0x00074029 File Offset: 0x00072229
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006887 RID: 26759
		' (get) Token: 0x06010DB3 RID: 69043 RVA: 0x00074032 File Offset: 0x00072232
		' (set) Token: 0x06010DB4 RID: 69044 RVA: 0x0007403C File Offset: 0x0007223C
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006888 RID: 26760
		' (get) Token: 0x06010DB5 RID: 69045 RVA: 0x00074045 File Offset: 0x00072245
		' (set) Token: 0x06010DB6 RID: 69046 RVA: 0x0007404F File Offset: 0x0007224F
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17006889 RID: 26761
		' (get) Token: 0x06010DB7 RID: 69047 RVA: 0x00074058 File Offset: 0x00072258
		' (set) Token: 0x06010DB8 RID: 69048 RVA: 0x00074062 File Offset: 0x00072262
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x1700688A RID: 26762
		' (get) Token: 0x06010DB9 RID: 69049 RVA: 0x0007406B File Offset: 0x0007226B
		' (set) Token: 0x06010DBA RID: 69050 RVA: 0x00074075 File Offset: 0x00072275
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700688B RID: 26763
		' (get) Token: 0x06010DBB RID: 69051 RVA: 0x0007407E File Offset: 0x0007227E
		' (set) Token: 0x06010DBC RID: 69052 RVA: 0x00074088 File Offset: 0x00072288
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700688C RID: 26764
		' (get) Token: 0x06010DBD RID: 69053 RVA: 0x00074091 File Offset: 0x00072291
		' (set) Token: 0x06010DBE RID: 69054 RVA: 0x009CE5F8 File Offset: 0x009CC7F8
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

		' Token: 0x1700688D RID: 26765
		' (get) Token: 0x06010DBF RID: 69055 RVA: 0x0007409B File Offset: 0x0007229B
		' (set) Token: 0x06010DC0 RID: 69056 RVA: 0x009CE63C File Offset: 0x009CC83C
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

		' Token: 0x1700688E RID: 26766
		' (get) Token: 0x06010DC1 RID: 69057 RVA: 0x000740A5 File Offset: 0x000722A5
		' (set) Token: 0x06010DC2 RID: 69058 RVA: 0x009CE680 File Offset: 0x009CC880
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

		' Token: 0x06010DC3 RID: 69059 RVA: 0x009CE6C4 File Offset: 0x009CC8C4
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

		' Token: 0x06010DC4 RID: 69060 RVA: 0x009CE798 File Offset: 0x009CC998
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06010DC5 RID: 69061 RVA: 0x009CEA6C File Offset: 0x009CCC6C
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06010DC6 RID: 69062 RVA: 0x009CEB04 File Offset: 0x009CCD04
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

		' Token: 0x06010DC7 RID: 69063 RVA: 0x009CEC7C File Offset: 0x009CCE7C
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

		' Token: 0x06010DC8 RID: 69064 RVA: 0x009CED48 File Offset: 0x009CCF48
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

		' Token: 0x06010DC9 RID: 69065 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06010DCA RID: 69066 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06010DCB RID: 69067 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06010DCC RID: 69068 RVA: 0x009CEE14 File Offset: 0x009CD014
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

		' Token: 0x06010DCD RID: 69069 RVA: 0x000740AF File Offset: 0x000722AF
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06010DCE RID: 69070 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseReturnRecord_GSTR_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06010DCF RID: 69071 RVA: 0x009CEEFC File Offset: 0x009CD0FC
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					Me.ComboBox2.SelectedIndex = -1
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and PurchaseReturn.PRNo=N'" + Me.TextBox1.Text + "' order by PurchaseReturn.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and Stock.InvoiceNo=N'" + Me.TextBox1.Text + "' order by PurchaseReturn.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and Supplier.Name=N'" + Me.TextBox1.Text + "' order by PurchaseReturn.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and Product.ProductName=N'" + Me.TextBox1.Text + "' order by PurchaseReturn.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and PurchaseReturn_Join.Barcode=N'" + Me.TextBox1.Text + "' order by PurchaseReturn.Date", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									End If
								End If
							End If
						End If
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x06010DD0 RID: 69072 RVA: 0x000740D1 File Offset: 0x000722D1
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010DD1 RID: 69073 RVA: 0x00074106 File Offset: 0x00072306
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox2.SelectedIndex = -1
		End Sub

		' Token: 0x06010DD2 RID: 69074 RVA: 0x009CF538 File Offset: 0x009CD738
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

		' Token: 0x06010DD3 RID: 69075 RVA: 0x009CF650 File Offset: 0x009CD850
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and NOT Stock.TaxType='NON GST' order by PurchaseReturn.Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 and Stock.TaxType='NON GST' order by PurchaseReturn.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					End If
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010DD4 RID: 69076 RVA: 0x009CF9F0 File Offset: 0x009CDBF0
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Clear()
				Me.ComboBox1.SelectedIndex = -1
				Me.ComboBox2.SelectedIndex = -1
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(PurchaseReturn.PRNo), PurchaseReturn.Date, RTRIM(Stock.TaxType), RTRIM(Stock.InvoiceNo), Stock.Date,RTRIM(Supplier.Name), RTRIM(Supplier.State), RTRIM(Supplier.GSTIN), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), (((PurchaseReturn_Join.TaxableAmt) + (PurchaseReturn_Join.DiscAmt)) / (PurchaseReturn_Join.ReturnQty)), PurchaseReturn_Join.ReturnQty,RTRIM(PurchaseUnit),PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt, PurchaseReturn_Join.TotalAmount, RTRIM(PurchaseReturn_Join.Barcode) FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Product ON PurchaseReturn_Join.ProductID = Product.PID INNER JOIN Stock ON PurchaseReturn.PurchaseID = Stock.ST_ID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID where PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06010DD5 RID: 69077 RVA: 0x009CFCF8 File Offset: 0x009CDEF8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
			Me.ComboBox2.SelectedIndex = -1
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06010DD6 RID: 69078 RVA: 0x009CFD48 File Offset: 0x009CDF48
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
