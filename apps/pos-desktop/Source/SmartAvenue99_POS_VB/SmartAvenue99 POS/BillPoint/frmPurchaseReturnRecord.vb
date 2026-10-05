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
	' Token: 0x02000595 RID: 1429
	<DesignerGenerated()>
	Public Partial Class frmPurchaseReturnRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060118FA RID: 71930 RVA: 0x00078F58 File Offset: 0x00077158
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseReturnRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006CF2 RID: 27890
		' (get) Token: 0x060118FD RID: 71933 RVA: 0x00078F8A File Offset: 0x0007718A
		' (set) Token: 0x060118FE RID: 71934 RVA: 0x00078F94 File Offset: 0x00077194
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006CF3 RID: 27891
		' (get) Token: 0x060118FF RID: 71935 RVA: 0x00078F9D File Offset: 0x0007719D
		' (set) Token: 0x06011900 RID: 71936 RVA: 0x00A30000 File Offset: 0x00A2E200
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

		' Token: 0x17006CF4 RID: 27892
		' (get) Token: 0x06011901 RID: 71937 RVA: 0x00078FA7 File Offset: 0x000771A7
		' (set) Token: 0x06011902 RID: 71938 RVA: 0x00078FB1 File Offset: 0x000771B1
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006CF5 RID: 27893
		' (get) Token: 0x06011903 RID: 71939 RVA: 0x00078FBA File Offset: 0x000771BA
		' (set) Token: 0x06011904 RID: 71940 RVA: 0x00A3007C File Offset: 0x00A2E27C
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

		' Token: 0x17006CF6 RID: 27894
		' (get) Token: 0x06011905 RID: 71941 RVA: 0x00078FC4 File Offset: 0x000771C4
		' (set) Token: 0x06011906 RID: 71942 RVA: 0x00078FCE File Offset: 0x000771CE
		Friend Overridable Property Label3 As Label

		' Token: 0x17006CF7 RID: 27895
		' (get) Token: 0x06011907 RID: 71943 RVA: 0x00078FD7 File Offset: 0x000771D7
		' (set) Token: 0x06011908 RID: 71944 RVA: 0x00078FE1 File Offset: 0x000771E1
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006CF8 RID: 27896
		' (get) Token: 0x06011909 RID: 71945 RVA: 0x00078FEA File Offset: 0x000771EA
		' (set) Token: 0x0601190A RID: 71946 RVA: 0x00078FF4 File Offset: 0x000771F4
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006CF9 RID: 27897
		' (get) Token: 0x0601190B RID: 71947 RVA: 0x00078FFD File Offset: 0x000771FD
		' (set) Token: 0x0601190C RID: 71948 RVA: 0x00079007 File Offset: 0x00077207
		Friend Overridable Property Label2 As Label

		' Token: 0x17006CFA RID: 27898
		' (get) Token: 0x0601190D RID: 71949 RVA: 0x00079010 File Offset: 0x00077210
		' (set) Token: 0x0601190E RID: 71950 RVA: 0x0007901A File Offset: 0x0007721A
		Friend Overridable Property Label4 As Label

		' Token: 0x17006CFB RID: 27899
		' (get) Token: 0x0601190F RID: 71951 RVA: 0x00079023 File Offset: 0x00077223
		' (set) Token: 0x06011910 RID: 71952 RVA: 0x0007902D File Offset: 0x0007722D
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006CFC RID: 27900
		' (get) Token: 0x06011911 RID: 71953 RVA: 0x00079036 File Offset: 0x00077236
		' (set) Token: 0x06011912 RID: 71954 RVA: 0x00079040 File Offset: 0x00077240
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006CFD RID: 27901
		' (get) Token: 0x06011913 RID: 71955 RVA: 0x00079049 File Offset: 0x00077249
		' (set) Token: 0x06011914 RID: 71956 RVA: 0x00079053 File Offset: 0x00077253
		Friend Overridable Property Label1 As Label

		' Token: 0x17006CFE RID: 27902
		' (get) Token: 0x06011915 RID: 71957 RVA: 0x0007905C File Offset: 0x0007725C
		' (set) Token: 0x06011916 RID: 71958 RVA: 0x00079066 File Offset: 0x00077266
		Friend Overridable Property lblSet As Label

		' Token: 0x17006CFF RID: 27903
		' (get) Token: 0x06011917 RID: 71959 RVA: 0x0007906F File Offset: 0x0007726F
		' (set) Token: 0x06011918 RID: 71960 RVA: 0x00079079 File Offset: 0x00077279
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006D00 RID: 27904
		' (get) Token: 0x06011919 RID: 71961 RVA: 0x00079082 File Offset: 0x00077282
		' (set) Token: 0x0601191A RID: 71962 RVA: 0x0007908C File Offset: 0x0007728C
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17006D01 RID: 27905
		' (get) Token: 0x0601191B RID: 71963 RVA: 0x00079095 File Offset: 0x00077295
		' (set) Token: 0x0601191C RID: 71964 RVA: 0x00A300C0 File Offset: 0x00A2E2C0
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

		' Token: 0x17006D02 RID: 27906
		' (get) Token: 0x0601191D RID: 71965 RVA: 0x0007909F File Offset: 0x0007729F
		' (set) Token: 0x0601191E RID: 71966 RVA: 0x00A30104 File Offset: 0x00A2E304
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

		' Token: 0x17006D03 RID: 27907
		' (get) Token: 0x0601191F RID: 71967 RVA: 0x000790A9 File Offset: 0x000772A9
		' (set) Token: 0x06011920 RID: 71968 RVA: 0x00A30148 File Offset: 0x00A2E348
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

		' Token: 0x17006D04 RID: 27908
		' (get) Token: 0x06011921 RID: 71969 RVA: 0x000790B3 File Offset: 0x000772B3
		' (set) Token: 0x06011922 RID: 71970 RVA: 0x000790BD File Offset: 0x000772BD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006D05 RID: 27909
		' (get) Token: 0x06011923 RID: 71971 RVA: 0x000790C6 File Offset: 0x000772C6
		' (set) Token: 0x06011924 RID: 71972 RVA: 0x000790D0 File Offset: 0x000772D0
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17006D06 RID: 27910
		' (get) Token: 0x06011925 RID: 71973 RVA: 0x000790D9 File Offset: 0x000772D9
		' (set) Token: 0x06011926 RID: 71974 RVA: 0x000790E3 File Offset: 0x000772E3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006D07 RID: 27911
		' (get) Token: 0x06011927 RID: 71975 RVA: 0x000790EC File Offset: 0x000772EC
		' (set) Token: 0x06011928 RID: 71976 RVA: 0x000790F6 File Offset: 0x000772F6
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006D08 RID: 27912
		' (get) Token: 0x06011929 RID: 71977 RVA: 0x000790FF File Offset: 0x000772FF
		' (set) Token: 0x0601192A RID: 71978 RVA: 0x00079109 File Offset: 0x00077309
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006D09 RID: 27913
		' (get) Token: 0x0601192B RID: 71979 RVA: 0x00079112 File Offset: 0x00077312
		' (set) Token: 0x0601192C RID: 71980 RVA: 0x0007911C File Offset: 0x0007731C
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17006D0A RID: 27914
		' (get) Token: 0x0601192D RID: 71981 RVA: 0x00079125 File Offset: 0x00077325
		' (set) Token: 0x0601192E RID: 71982 RVA: 0x0007912F File Offset: 0x0007732F
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17006D0B RID: 27915
		' (get) Token: 0x0601192F RID: 71983 RVA: 0x00079138 File Offset: 0x00077338
		' (set) Token: 0x06011930 RID: 71984 RVA: 0x00079142 File Offset: 0x00077342
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006D0C RID: 27916
		' (get) Token: 0x06011931 RID: 71985 RVA: 0x0007914B File Offset: 0x0007734B
		' (set) Token: 0x06011932 RID: 71986 RVA: 0x00079155 File Offset: 0x00077355
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006D0D RID: 27917
		' (get) Token: 0x06011933 RID: 71987 RVA: 0x0007915E File Offset: 0x0007735E
		' (set) Token: 0x06011934 RID: 71988 RVA: 0x00079168 File Offset: 0x00077368
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006D0E RID: 27918
		' (get) Token: 0x06011935 RID: 71989 RVA: 0x00079171 File Offset: 0x00077371
		' (set) Token: 0x06011936 RID: 71990 RVA: 0x0007917B File Offset: 0x0007737B
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17006D0F RID: 27919
		' (get) Token: 0x06011937 RID: 71991 RVA: 0x00079184 File Offset: 0x00077384
		' (set) Token: 0x06011938 RID: 71992 RVA: 0x0007918E File Offset: 0x0007738E
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17006D10 RID: 27920
		' (get) Token: 0x06011939 RID: 71993 RVA: 0x00079197 File Offset: 0x00077397
		' (set) Token: 0x0601193A RID: 71994 RVA: 0x000791A1 File Offset: 0x000773A1
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17006D11 RID: 27921
		' (get) Token: 0x0601193B RID: 71995 RVA: 0x000791AA File Offset: 0x000773AA
		' (set) Token: 0x0601193C RID: 71996 RVA: 0x000791B4 File Offset: 0x000773B4
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17006D12 RID: 27922
		' (get) Token: 0x0601193D RID: 71997 RVA: 0x000791BD File Offset: 0x000773BD
		' (set) Token: 0x0601193E RID: 71998 RVA: 0x000791C7 File Offset: 0x000773C7
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006D13 RID: 27923
		' (get) Token: 0x0601193F RID: 71999 RVA: 0x000791D0 File Offset: 0x000773D0
		' (set) Token: 0x06011940 RID: 72000 RVA: 0x000791DA File Offset: 0x000773DA
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006D14 RID: 27924
		' (get) Token: 0x06011941 RID: 72001 RVA: 0x000791E3 File Offset: 0x000773E3
		' (set) Token: 0x06011942 RID: 72002 RVA: 0x000791ED File Offset: 0x000773ED
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17006D15 RID: 27925
		' (get) Token: 0x06011943 RID: 72003 RVA: 0x000791F6 File Offset: 0x000773F6
		' (set) Token: 0x06011944 RID: 72004 RVA: 0x00079200 File Offset: 0x00077400
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17006D16 RID: 27926
		' (get) Token: 0x06011945 RID: 72005 RVA: 0x00079209 File Offset: 0x00077409
		' (set) Token: 0x06011946 RID: 72006 RVA: 0x00079213 File Offset: 0x00077413
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006D17 RID: 27927
		' (get) Token: 0x06011947 RID: 72007 RVA: 0x0007921C File Offset: 0x0007741C
		' (set) Token: 0x06011948 RID: 72008 RVA: 0x00079226 File Offset: 0x00077426
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006D18 RID: 27928
		' (get) Token: 0x06011949 RID: 72009 RVA: 0x0007922F File Offset: 0x0007742F
		' (set) Token: 0x0601194A RID: 72010 RVA: 0x00079239 File Offset: 0x00077439
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006D19 RID: 27929
		' (get) Token: 0x0601194B RID: 72011 RVA: 0x00079242 File Offset: 0x00077442
		' (set) Token: 0x0601194C RID: 72012 RVA: 0x0007924C File Offset: 0x0007744C
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17006D1A RID: 27930
		' (get) Token: 0x0601194D RID: 72013 RVA: 0x00079255 File Offset: 0x00077455
		' (set) Token: 0x0601194E RID: 72014 RVA: 0x0007925F File Offset: 0x0007745F
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17006D1B RID: 27931
		' (get) Token: 0x0601194F RID: 72015 RVA: 0x00079268 File Offset: 0x00077468
		' (set) Token: 0x06011950 RID: 72016 RVA: 0x00079272 File Offset: 0x00077472
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17006D1C RID: 27932
		' (get) Token: 0x06011951 RID: 72017 RVA: 0x0007927B File Offset: 0x0007747B
		' (set) Token: 0x06011952 RID: 72018 RVA: 0x00079285 File Offset: 0x00077485
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17006D1D RID: 27933
		' (get) Token: 0x06011953 RID: 72019 RVA: 0x0007928E File Offset: 0x0007748E
		' (set) Token: 0x06011954 RID: 72020 RVA: 0x00079298 File Offset: 0x00077498
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x06011955 RID: 72021 RVA: 0x00A3018C File Offset: 0x00A2E38C
		Public Sub Getdata()
			Try
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(TaxType),RTRIM(PurchaseID),RTRIM(InvoiceNo),Stock.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.SGST),RTRIM(PurchaseReturn.CGST),RTRIM(PurchaseReturn.IGST),RTRIM(PurchaseReturn.CESS),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(PurchaseReturn.RCM),RTRIM(PurchaseReturn.PaymentMode),RTRIM(PurchaseReturn.BillSundry),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo FROM Stock,PurchaseReturn,Supplier where Stock.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Stock.SupplierID and PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011956 RID: 72022 RVA: 0x00A30480 File Offset: 0x00A2E680
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

		' Token: 0x06011957 RID: 72023 RVA: 0x00A30554 File Offset: 0x00A2E754
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

		' Token: 0x06011958 RID: 72024 RVA: 0x00A305EC File Offset: 0x00A2E7EC
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

		' Token: 0x06011959 RID: 72025 RVA: 0x00A30764 File Offset: 0x00A2E964
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

		' Token: 0x0601195A RID: 72026 RVA: 0x00A30830 File Offset: 0x00A2EA30
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

		' Token: 0x0601195B RID: 72027 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601195C RID: 72028 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601195D RID: 72029 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601195E RID: 72030 RVA: 0x00A308FC File Offset: 0x00A2EAFC
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x0601195F RID: 72031 RVA: 0x000792A1 File Offset: 0x000774A1
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011960 RID: 72032 RVA: 0x00A30924 File Offset: 0x00A2EB24
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "PR", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPurchaseReturn.Show()
						MyBase.Hide()
						MyProject.Forms.frmPurchaseReturn.txtPRID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtPRNO.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.dtpPRDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtPurchaseID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtPurchaseInvoiceNo.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.dtpPurchaseDate.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSupplierID.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSupplierName.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSubTotal.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtCGST.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtSGST.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtIGST.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtCESS.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtFreightCharges.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtOtherCharges.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtTotal.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtRoundOff.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.txtGrandTotal.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox2.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.cmbPmtMode.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.cmbBSundry.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox3.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox4.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox5.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.TextBox6.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPurchaseReturn.btnSave.Enabled = False
						MyProject.Forms.frmPurchaseReturn.DataGridView1.Enabled = True
						MyProject.Forms.frmPurchaseReturn.btnAdd.Enabled = False
						MyProject.Forms.frmPurchaseReturn.btnRemove.Enabled = False
						MyProject.Forms.frmPurchaseReturn.lblSet.Text = "Not Allowed"
						MyProject.Forms.frmPurchaseReturn.pnlCalc.Enabled = False
						MyProject.Forms.frmPurchaseReturn.btnDelete.Enabled = True
						MyProject.Forms.frmPurchaseReturn.btnSelection.Enabled = False
						MyProject.Forms.frmPurchaseReturn.btnPrint.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = If(("SELECT PurchaseReturn_Join.ProductID,RTRIM(HSNCode),RTRIM(Productname), RTRIM(PurchaseReturn_Join.Barcode), PurchaseReturn_Join.Qty,PurchaseReturn_Join.MRP, PurchaseReturn_Join.Price, PurchaseReturn_Join.DiscPer, PurchaseReturn_Join.DiscAmt, PurchaseReturn_Join.CGSTPer, PurchaseReturn_Join.CGSTAmt, PurchaseReturn_Join.SGSTPer, PurchaseReturn_Join.SGSTAmt, PurchaseReturn_Join.IGSTPer, PurchaseReturn_Join.IGSTAmt, PurchaseReturn_Join.CESSPer, PurchaseReturn_Join.CESSAmt,PurchaseReturn_Join.ReturnQty, PurchaseReturn_Join.TotalAmount,RTRIM(PurchaseReturn_Join.PTaxType),(PurchaseReturn_Join.TaxableAmt) FROM PurchaseReturn_Join INNER JOIN PurchaseReturn ON PurchaseReturn_Join.PurchaseReturnID = PurchaseReturn.PR_ID INNER JOIN Product ON Product.PID = PurchaseReturn_Join.ProductID and PR_ID=" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))), "")
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPurchaseReturn.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPurchaseReturn.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20) })
						End While
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "SELECT a.productid AS PID, RTRIM(b.ProductCode) AS Productcode, RTRIM(b.ProductName) AS ProductName, a.barcode AS Barcode, a.serialno" & vbCrLf & "                              FROM tbl_product_serial_purchaseReturn a" & vbCrLf & "                              INNER JOIN product b ON a.productid = b.pid where a.invoice_no=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(1).Value))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmPurchaseReturn.DataGridView5F.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmPurchaseReturn.DataGridView5F.Visible = True
							MyProject.Forms.frmPurchaseReturn.DataGridView5F.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPurchaseReturn.DataGridView1.ClearSelection()
						ModCommonClasses.con.Close()
						MyProject.Forms.frmPurchaseReturn.Calc()
						MyProject.Forms.frmPurchaseReturn.Compute()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011961 RID: 72033 RVA: 0x00A31268 File Offset: 0x00A2F468
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

		' Token: 0x06011962 RID: 72034 RVA: 0x000792AB File Offset: 0x000774AB
		Public Sub Reset()
			Me.txtSupplierName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06011963 RID: 72035 RVA: 0x00A31350 File Offset: 0x00A2F550
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(TaxType),RTRIM(PurchaseID),RTRIM(InvoiceNo),Stock.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.SGST),RTRIM(PurchaseReturn.CGST),RTRIM(PurchaseReturn.IGST),RTRIM(PurchaseReturn.CESS),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(PurchaseReturn.RCM),RTRIM(PurchaseReturn.PaymentMode),RTRIM(PurchaseReturn.BillSundry),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo FROM Stock,PurchaseReturn,Supplier where Stock.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Stock.SupplierID  and [Name] like N'" + Me.txtSupplierName.Text + "%' and PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011964 RID: 72036 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPurchaseReturnRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011965 RID: 72037 RVA: 0x00A31644 File Offset: 0x00A2F844
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

		' Token: 0x06011966 RID: 72038 RVA: 0x00A3175C File Offset: 0x00A2F95C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(TaxType),RTRIM(PurchaseID),RTRIM(InvoiceNo),Stock.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.SGST),RTRIM(PurchaseReturn.CGST),RTRIM(PurchaseReturn.IGST),RTRIM(PurchaseReturn.CESS),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(PurchaseReturn.RCM),RTRIM(PurchaseReturn.PaymentMode),RTRIM(PurchaseReturn.BillSundry),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo FROM Stock,PurchaseReturn,Supplier where Stock.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Stock.SupplierID and PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06011967 RID: 72039 RVA: 0x000792DE File Offset: 0x000774DE
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x06011968 RID: 72040 RVA: 0x00A31A58 File Offset: 0x00A2FC58
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
