Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000A6 RID: 166
	<DesignerGenerated()>
	Public Partial Class frmHoldrecord_Purchase
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600188A RID: 6282 RVA: 0x00012DC8 File Offset: 0x00010FC8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmHoldrecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmHoldrecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170009AE RID: 2478
		' (get) Token: 0x0600188D RID: 6285 RVA: 0x00012DFA File Offset: 0x00010FFA
		' (set) Token: 0x0600188E RID: 6286 RVA: 0x00012E04 File Offset: 0x00011004
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170009AF RID: 2479
		' (get) Token: 0x0600188F RID: 6287 RVA: 0x00012E0D File Offset: 0x0001100D
		' (set) Token: 0x06001890 RID: 6288 RVA: 0x00012E17 File Offset: 0x00011017
		Friend Overridable Property Label1 As Label

		' Token: 0x170009B0 RID: 2480
		' (get) Token: 0x06001891 RID: 6289 RVA: 0x00012E20 File Offset: 0x00011020
		' (set) Token: 0x06001892 RID: 6290 RVA: 0x00012E2A File Offset: 0x0001102A
		Friend Overridable Property Label2 As Label

		' Token: 0x170009B1 RID: 2481
		' (get) Token: 0x06001893 RID: 6291 RVA: 0x00012E33 File Offset: 0x00011033
		' (set) Token: 0x06001894 RID: 6292 RVA: 0x00012E3D File Offset: 0x0001103D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170009B2 RID: 2482
		' (get) Token: 0x06001895 RID: 6293 RVA: 0x00012E46 File Offset: 0x00011046
		' (set) Token: 0x06001896 RID: 6294 RVA: 0x00012E50 File Offset: 0x00011050
		Friend Overridable Property Label3 As Label

		' Token: 0x170009B3 RID: 2483
		' (get) Token: 0x06001897 RID: 6295 RVA: 0x00012E59 File Offset: 0x00011059
		' (set) Token: 0x06001898 RID: 6296 RVA: 0x00012E63 File Offset: 0x00011063
		Friend Overridable Property txtHold As TextBox

		' Token: 0x170009B4 RID: 2484
		' (get) Token: 0x06001899 RID: 6297 RVA: 0x00012E6C File Offset: 0x0001106C
		' (set) Token: 0x0600189A RID: 6298 RVA: 0x0010C43C File Offset: 0x0010A63C
		Private _btnunhold As Button
		Friend Overridable Property btnunhold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnunhold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnunhold_Click
				Dim button As Button = Me._btnunhold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnunhold = value
				button = Me._btnunhold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170009B5 RID: 2485
		' (get) Token: 0x0600189B RID: 6299 RVA: 0x00012E76 File Offset: 0x00011076
		' (set) Token: 0x0600189C RID: 6300 RVA: 0x0010C480 File Offset: 0x0010A680
		Private _btnhold As Button
		Friend Overridable Property btnhold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnhold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnhold_Click
				Dim button As Button = Me._btnhold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnhold = value
				button = Me._btnhold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170009B6 RID: 2486
		' (get) Token: 0x0600189D RID: 6301 RVA: 0x00012E80 File Offset: 0x00011080
		' (set) Token: 0x0600189E RID: 6302 RVA: 0x00012E8A File Offset: 0x0001108A
		Friend Overridable Property lblUser As Label

		' Token: 0x170009B7 RID: 2487
		' (get) Token: 0x0600189F RID: 6303 RVA: 0x00012E93 File Offset: 0x00011093
		' (set) Token: 0x060018A0 RID: 6304 RVA: 0x0010C4C4 File Offset: 0x0010A6C4
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

		' Token: 0x170009B8 RID: 2488
		' (get) Token: 0x060018A1 RID: 6305 RVA: 0x00012E9D File Offset: 0x0001109D
		' (set) Token: 0x060018A2 RID: 6306 RVA: 0x0010C508 File Offset: 0x0010A708
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

		' Token: 0x170009B9 RID: 2489
		' (get) Token: 0x060018A3 RID: 6307 RVA: 0x00012EA7 File Offset: 0x000110A7
		' (set) Token: 0x060018A4 RID: 6308 RVA: 0x0010C54C File Offset: 0x0010A74C
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170009BA RID: 2490
		' (get) Token: 0x060018A5 RID: 6309 RVA: 0x00012EB1 File Offset: 0x000110B1
		' (set) Token: 0x060018A6 RID: 6310 RVA: 0x00012EBB File Offset: 0x000110BB
		Friend Overridable Property Label4 As Label

		' Token: 0x170009BB RID: 2491
		' (get) Token: 0x060018A7 RID: 6311 RVA: 0x00012EC4 File Offset: 0x000110C4
		' (set) Token: 0x060018A8 RID: 6312 RVA: 0x0010C590 File Offset: 0x0010A790
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170009BC RID: 2492
		' (get) Token: 0x060018A9 RID: 6313 RVA: 0x00012ECE File Offset: 0x000110CE
		' (set) Token: 0x060018AA RID: 6314 RVA: 0x00012ED8 File Offset: 0x000110D8
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x170009BD RID: 2493
		' (get) Token: 0x060018AB RID: 6315 RVA: 0x00012EE1 File Offset: 0x000110E1
		' (set) Token: 0x060018AC RID: 6316 RVA: 0x00012EEB File Offset: 0x000110EB
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x170009BE RID: 2494
		' (get) Token: 0x060018AD RID: 6317 RVA: 0x00012EF4 File Offset: 0x000110F4
		' (set) Token: 0x060018AE RID: 6318 RVA: 0x00012EFE File Offset: 0x000110FE
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x170009BF RID: 2495
		' (get) Token: 0x060018AF RID: 6319 RVA: 0x00012F07 File Offset: 0x00011107
		' (set) Token: 0x060018B0 RID: 6320 RVA: 0x00012F11 File Offset: 0x00011111
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x170009C0 RID: 2496
		' (get) Token: 0x060018B1 RID: 6321 RVA: 0x00012F1A File Offset: 0x0001111A
		' (set) Token: 0x060018B2 RID: 6322 RVA: 0x00012F24 File Offset: 0x00011124
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x170009C1 RID: 2497
		' (get) Token: 0x060018B3 RID: 6323 RVA: 0x00012F2D File Offset: 0x0001112D
		' (set) Token: 0x060018B4 RID: 6324 RVA: 0x00012F37 File Offset: 0x00011137
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x170009C2 RID: 2498
		' (get) Token: 0x060018B5 RID: 6325 RVA: 0x00012F40 File Offset: 0x00011140
		' (set) Token: 0x060018B6 RID: 6326 RVA: 0x00012F4A File Offset: 0x0001114A
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x170009C3 RID: 2499
		' (get) Token: 0x060018B7 RID: 6327 RVA: 0x00012F53 File Offset: 0x00011153
		' (set) Token: 0x060018B8 RID: 6328 RVA: 0x00012F5D File Offset: 0x0001115D
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x170009C4 RID: 2500
		' (get) Token: 0x060018B9 RID: 6329 RVA: 0x00012F66 File Offset: 0x00011166
		' (set) Token: 0x060018BA RID: 6330 RVA: 0x00012F70 File Offset: 0x00011170
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x170009C5 RID: 2501
		' (get) Token: 0x060018BB RID: 6331 RVA: 0x00012F79 File Offset: 0x00011179
		' (set) Token: 0x060018BC RID: 6332 RVA: 0x00012F83 File Offset: 0x00011183
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x170009C6 RID: 2502
		' (get) Token: 0x060018BD RID: 6333 RVA: 0x00012F8C File Offset: 0x0001118C
		' (set) Token: 0x060018BE RID: 6334 RVA: 0x00012F96 File Offset: 0x00011196
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x170009C7 RID: 2503
		' (get) Token: 0x060018BF RID: 6335 RVA: 0x00012F9F File Offset: 0x0001119F
		' (set) Token: 0x060018C0 RID: 6336 RVA: 0x00012FA9 File Offset: 0x000111A9
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x170009C8 RID: 2504
		' (get) Token: 0x060018C1 RID: 6337 RVA: 0x00012FB2 File Offset: 0x000111B2
		' (set) Token: 0x060018C2 RID: 6338 RVA: 0x00012FBC File Offset: 0x000111BC
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x170009C9 RID: 2505
		' (get) Token: 0x060018C3 RID: 6339 RVA: 0x00012FC5 File Offset: 0x000111C5
		' (set) Token: 0x060018C4 RID: 6340 RVA: 0x00012FCF File Offset: 0x000111CF
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x170009CA RID: 2506
		' (get) Token: 0x060018C5 RID: 6341 RVA: 0x00012FD8 File Offset: 0x000111D8
		' (set) Token: 0x060018C6 RID: 6342 RVA: 0x00012FE2 File Offset: 0x000111E2
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x170009CB RID: 2507
		' (get) Token: 0x060018C7 RID: 6343 RVA: 0x00012FEB File Offset: 0x000111EB
		' (set) Token: 0x060018C8 RID: 6344 RVA: 0x00012FF5 File Offset: 0x000111F5
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x170009CC RID: 2508
		' (get) Token: 0x060018C9 RID: 6345 RVA: 0x00012FFE File Offset: 0x000111FE
		' (set) Token: 0x060018CA RID: 6346 RVA: 0x00013008 File Offset: 0x00011208
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x170009CD RID: 2509
		' (get) Token: 0x060018CB RID: 6347 RVA: 0x00013011 File Offset: 0x00011211
		' (set) Token: 0x060018CC RID: 6348 RVA: 0x0001301B File Offset: 0x0001121B
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x170009CE RID: 2510
		' (get) Token: 0x060018CD RID: 6349 RVA: 0x00013024 File Offset: 0x00011224
		' (set) Token: 0x060018CE RID: 6350 RVA: 0x0001302E File Offset: 0x0001122E
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x170009CF RID: 2511
		' (get) Token: 0x060018CF RID: 6351 RVA: 0x00013037 File Offset: 0x00011237
		' (set) Token: 0x060018D0 RID: 6352 RVA: 0x00013041 File Offset: 0x00011241
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x170009D0 RID: 2512
		' (get) Token: 0x060018D1 RID: 6353 RVA: 0x0001304A File Offset: 0x0001124A
		' (set) Token: 0x060018D2 RID: 6354 RVA: 0x00013054 File Offset: 0x00011254
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x170009D1 RID: 2513
		' (get) Token: 0x060018D3 RID: 6355 RVA: 0x0001305D File Offset: 0x0001125D
		' (set) Token: 0x060018D4 RID: 6356 RVA: 0x00013067 File Offset: 0x00011267
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x170009D2 RID: 2514
		' (get) Token: 0x060018D5 RID: 6357 RVA: 0x00013070 File Offset: 0x00011270
		' (set) Token: 0x060018D6 RID: 6358 RVA: 0x0001307A File Offset: 0x0001127A
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x170009D3 RID: 2515
		' (get) Token: 0x060018D7 RID: 6359 RVA: 0x00013083 File Offset: 0x00011283
		' (set) Token: 0x060018D8 RID: 6360 RVA: 0x0001308D File Offset: 0x0001128D
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170009D4 RID: 2516
		' (get) Token: 0x060018D9 RID: 6361 RVA: 0x00013096 File Offset: 0x00011296
		' (set) Token: 0x060018DA RID: 6362 RVA: 0x000130A0 File Offset: 0x000112A0
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x170009D5 RID: 2517
		' (get) Token: 0x060018DB RID: 6363 RVA: 0x000130A9 File Offset: 0x000112A9
		' (set) Token: 0x060018DC RID: 6364 RVA: 0x000130B3 File Offset: 0x000112B3
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x170009D6 RID: 2518
		' (get) Token: 0x060018DD RID: 6365 RVA: 0x000130BC File Offset: 0x000112BC
		' (set) Token: 0x060018DE RID: 6366 RVA: 0x000130C6 File Offset: 0x000112C6
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170009D7 RID: 2519
		' (get) Token: 0x060018DF RID: 6367 RVA: 0x000130CF File Offset: 0x000112CF
		' (set) Token: 0x060018E0 RID: 6368 RVA: 0x000130D9 File Offset: 0x000112D9
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x170009D8 RID: 2520
		' (get) Token: 0x060018E1 RID: 6369 RVA: 0x000130E2 File Offset: 0x000112E2
		' (set) Token: 0x060018E2 RID: 6370 RVA: 0x000130EC File Offset: 0x000112EC
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170009D9 RID: 2521
		' (get) Token: 0x060018E3 RID: 6371 RVA: 0x000130F5 File Offset: 0x000112F5
		' (set) Token: 0x060018E4 RID: 6372 RVA: 0x000130FF File Offset: 0x000112FF
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170009DA RID: 2522
		' (get) Token: 0x060018E5 RID: 6373 RVA: 0x00013108 File Offset: 0x00011308
		' (set) Token: 0x060018E6 RID: 6374 RVA: 0x00013112 File Offset: 0x00011312
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170009DB RID: 2523
		' (get) Token: 0x060018E7 RID: 6375 RVA: 0x0001311B File Offset: 0x0001131B
		' (set) Token: 0x060018E8 RID: 6376 RVA: 0x00013125 File Offset: 0x00011325
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170009DC RID: 2524
		' (get) Token: 0x060018E9 RID: 6377 RVA: 0x0001312E File Offset: 0x0001132E
		' (set) Token: 0x060018EA RID: 6378 RVA: 0x00013138 File Offset: 0x00011338
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x060018EB RID: 6379 RVA: 0x0010C5F0 File Offset: 0x0010A7F0
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ST_ID, RTRIM(Hold_Id), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock_Hold.Remarks), RTRIM(Stock_Hold.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock_Hold where Supplier.ID=Stock_Hold.SupplierID and Stock_Hold.TillID=@T1 order by [Date]"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@T1", Dns.GetHostName().TrimEnd(New Char(-1) {}).ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060018EC RID: 6380 RVA: 0x0010C900 File Offset: 0x0010AB00
		Private Sub FrmHoldrecord_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.fillHoldNo()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x060018ED RID: 6381 RVA: 0x0010C988 File Offset: 0x0010AB88
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.Label4.Text, "frmPurchaseEntry", False) = 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyProject.Forms.frmPurchaseEntry.Show()
					MyBase.Hide()
					MyProject.Forms.frmPurchaseEntry.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.dtpDate.Value = Conversions.ToDate(dataGridViewRow.Cells(2).Value.ToString())
					MyProject.Forms.frmPurchaseEntry.txtReferenceNo1.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbReverse.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbPurchaseType.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtGSTNonGST.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.lbltaxtype.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtSupplierInvoiceNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.dtpSupplierInvoiceDate.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtSup_ID.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtSupplierID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbSupplierName.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtSubTotal.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtDiscPer.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtSGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtIGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtCESS.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtFreightCharges.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtOtherCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtPreviousDue.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtTotalPaid.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtBalance.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.txtRemarks.Text = dataGridViewRow.Cells(25).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbBSundry.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.cmbAccountNo.Text = dataGridViewRow.Cells(28).Value.ToString()
					MyProject.Forms.frmPurchaseEntry.limitsearch()
					MyProject.Forms.frmPurchaseEntry.GetSupplierBalance1()
					MyProject.Forms.frmPurchaseEntry.GetSupplierInfo()
					MyProject.Forms.frmPurchaseEntry.btnSelection.Enabled = False
					MyProject.Forms.frmPurchaseEntry.lblSet.Text = "Not Allowed"
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product_Hold.Barcode),Qty,Stock_Product_Hold.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,Qty,Stock_Product_Hold.TaxableAmt,Stock_Product_Hold.AltQty,Stock_Product_Hold.AltUnit,Stock_Product_Hold.PTaxType,Stock_Product_Hold.RPrice,Stock_Product_Hold.WPrice,RTRIM(Stock_Product_Hold.Color),RTRIM(Stock_Product_Hold.Size),RTRIM(Stock_Product_Hold.Info),RTRIM(Stock_Product_Hold.Batch),RTRIM(Stock_Product_Hold.Mfgdate),RTRIM(Stock_Product_Hold.Expdate),RTRIM(Stock_Product_Hold.RCipher),RTRIM(Stock_Product_Hold.WCipher),RTRIM(Stock_Product_Hold.Category),RTRIM(Stock_Product_Hold.MainUnit),RTRIM(Stock_Product_Hold.IMEI1),RTRIM(Stock_Product_Hold.IMEI2) from Product,Stock_Hold,Stock_Product_Hold where product.PID=Stock_Product_Hold.ProductID " & vbCrLf & "and Stock_Hold.Hold_ID=Stock_Product_Hold.Hold_ID and Stock_Hold.Hold_ID='" + dataGridViewRow.Cells(1).Value.ToString() + " '"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Clear()
					MyProject.Forms.frmPurchaseEntry.DataGridView2.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPurchaseEntry.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36) })
						MyProject.Forms.frmPurchaseEntry.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPurchaseEntry.DataGridView1.ClearSelection()
					MyProject.Forms.frmPurchaseEntry.DataGridView2.ClearSelection()
					MyProject.Forms.frmPurchaseEntry.Calc()
					MyProject.Forms.frmPurchaseEntry.Compute()
					MyProject.Forms.frmPurchaseEntry.GetQty_S1()
					MyProject.Forms.frmPurchaseEntry.btnPrint.Enabled = True
					MyProject.Forms.frmPurchaseEntry.Label51.Text = "edit"
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060018EE RID: 6382 RVA: 0x0010D51C File Offset: 0x0010B71C
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyBase.Close()
					MyProject.Forms.frmPOSTouch.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSTouch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSTouch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSTouch.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSTouch.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag2 Then
						MyProject.Forms.frmPOSTouch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSTouch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSTouch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSTouch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSTouch.Button5.Enabled = True
					MyProject.Forms.frmPOSTouch.Button6.Enabled = True
					MyProject.Forms.frmPOSTouch.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSTouch.auto()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product_Hold.Barcode),Qty,Stock_Product_Hold.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,Qty,Stock_Product_Hold.TaxableAmt,Stock_Product_Hold.AltQty,Stock_Product_Hold.AltUnit,Stock_Product_Hold.PTaxType,Stock_Product_Hold.RPrice,Stock_Product_Hold.WPrice,RTRIM(Stock_Product_Hold.Color),RTRIM(Stock_Product_Hold.Size),RTRIM(Stock_Product_Hold.Info),RTRIM(Stock_Product_Hold.Batch),RTRIM(Stock_Product_Hold.Mfgdate),RTRIM(Stock_Product_Hold.Expdate),RTRIM(Stock_Product_Hold.RCipher),RTRIM(Stock_Product_Hold.WCipher),RTRIM(Stock_Product_Hold.Category),RTRIM(Stock_Product_Hold.MainUnit),RTRIM(Stock_Product_Hold.IMEI1),RTRIM(Stock_Product_Hold.IMEI2) from Product,Stock_Hold,Stock_Product_Hold where product.PID=Stock_Product_Hold.ProductID " & vbCrLf & "and Stock_Hold.Hold_ID=Stock_Product_Hold.Hold_ID and Stock_Hold.Hold_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", MyProject.Forms.frmPOSTouch.txtHold.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(38).ToString(), "", False) <> 0
						Dim num As Decimal
						If flag3 Then
							num = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(38).ToString())
						Else
							num = Conversions.ToDecimal("0.00")
						End If
						Dim flag4 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(39).ToString(), "", False) <> 0
						Dim num2 As Decimal
						If flag4 Then
							num2 = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(39).ToString())
						Else
							num2 = 0D
						End If
						MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), num, num2, MyProject.Forms.frmPOSTouch.GetProductImage(CInt(Convert.ToInt16(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(0))))), ModCommonClasses.rdr(40) })
					End While
					MyProject.Forms.frmPOSTouch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSTouch.Calc()
					MyProject.Forms.frmPOSTouch.Compute()
					MyProject.Forms.frmPOSTouch.alldiscountcalc()
					MyProject.Forms.frmPOSTouch.Bankcondn()
					MyProject.Forms.frmPOSTouch.totitemnqty()
					MyProject.Forms.frmPOSTouch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSTouch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSTouch.SalesmanCommn()
					MyProject.Forms.frmPOSTouch.Calculate143()
					MyProject.Forms.frmPOSTouch.tcsconn()
					MyProject.Forms.frmPOSTouch.tcsconn1()
					MyProject.Forms.frmPOSTouch.CTypeStatusforHold()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060018EF RID: 6383 RVA: 0x0010E168 File Offset: 0x0010C368
		Public Sub RetrieveData1New()
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					MyBase.Close()
					MyProject.Forms.frmPOSNewTuch.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.dtpInvoiceDate.Text = dataGridViewRow.Cells(2).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTaxType.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.TextBox7.Text = dataGridViewRow.Cells(3).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow.Cells(10).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow.Cells(11).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow.Cells(12).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSubTotal.Text = dataGridViewRow.Cells(13).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCGST.Text = dataGridViewRow.Cells(14).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtSGST.Text = dataGridViewRow.Cells(15).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtIGST.Text = dataGridViewRow.Cells(16).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtCESS.Text = dataGridViewRow.Cells(17).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtFreightCharges.Text = dataGridViewRow.Cells(18).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillDiscount.Text = dataGridViewRow.Cells(19).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotal.Text = dataGridViewRow.Cells(20).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRoundOff.Text = dataGridViewRow.Cells(21).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtGrandTotal.Text = dataGridViewRow.Cells(22).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTotalPayment.Text = dataGridViewRow.Cells(23).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtPaymentDue.Text = dataGridViewRow.Cells(24).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtNar.Text = dataGridViewRow.Cells(26).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txteway.Text = dataGridViewRow.Cells(27).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.cmbBSundry.Text = dataGridViewRow.Cells(30).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = dataGridViewRow.Cells(31).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtApplyPoint.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtLAmt.Text = dataGridViewRow.Cells(32).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtbilldisc.Text = dataGridViewRow.Cells(33).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtTendAmt.Text = dataGridViewRow.Cells(35).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtRefAmt.Text = dataGridViewRow.Cells(36).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtBillAmt.Text = dataGridViewRow.Cells(37).Value.ToString()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(32).Value, 0, False)
					If flag2 Then
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = True
					Else
						MyProject.Forms.frmPOSNewTuch.cb1.Checked = False
					End If
					MyProject.Forms.frmPOSNewTuch.txtCoupAmt.Text = dataGridViewRow.Cells(38).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.txtgiftamt.Text = dataGridViewRow.Cells(39).Value.ToString()
					MyProject.Forms.frmPOSNewTuch.Button5.Enabled = True
					MyProject.Forms.frmPOSNewTuch.Button6.Enabled = True
					MyProject.Forms.frmPOSNewTuch.txtOffer.Text = "0.00"
					MyProject.Forms.frmPOSNewTuch.auto()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT ProductID,RTRIM(HSNCode),RTRIM(ProductName), RTRIM(Invoiceholdproduct.Barcode),Invoiceholdproduct.Qty, Invoiceholdproduct.SalesRate,Invoiceholdproduct.DiscountPer, Invoiceholdproduct.Discount, Invoiceholdproduct.CGSTPer, Invoiceholdproduct.CGSTAmt, Invoiceholdproduct.SGSTPer, Invoiceholdproduct.SGSTAmt, Invoiceholdproduct.IGSTPer,Invoiceholdproduct.IGSTAmt, Invoiceholdproduct.CESSPer,Invoiceholdproduct.CESSAmt,Invoiceholdproduct.TotalAmount,Invoiceholdproduct.PurchaseRate,Invoiceholdproduct.Margin,Invoiceholdproduct.Descr,Invoiceholdproduct.Qty,RTRIM(Invoiceholdproduct.IM1),RTRIM(Invoiceholdproduct.IM2),(Invoiceholdproduct.MRP),(Invoiceholdproduct.TaxableAmt),(Invoiceholdproduct.AltQty),(Invoiceholdproduct.AltUnit),(Invoiceholdproduct.STaxType),(Invoiceholdproduct.TotalMRP),(Invoiceholdproduct.PromoQty),RTRIM(Invoiceholdproduct.MainUnit),RTRIM(Invoiceholdproduct.Batch),RTRIM(Invoiceholdproduct.Mfg),RTRIM(Invoiceholdproduct.Exp),RTRIM(Invoiceholdproduct.Size),RTRIM(Invoiceholdproduct.Colour),Invoiceholdproduct.SalesManID,Invoiceholdproduct.SalesMan,Invoiceholdproduct.SalesManPur,Invoiceholdproduct.SalesManComm ,Invoiceholdproduct.StockID  from Invoicehold,Invoiceholdproduct,Product where Invoicehold.Hold_ID=Invoiceholdproduct.Hold_ID and Product.PID=Invoiceholdproduct.ProductID and Invoicehold.Hold_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", MyProject.Forms.frmPOSNewTuch.txtHold.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36), ModCommonClasses.rdr(37), ModCommonClasses.rdr(38), ModCommonClasses.rdr(39), ModCommonClasses.rdr(40) })
					End While
					MyProject.Forms.frmPOSNewTuch.DataGridView1.ClearSelection()
					ModCommonClasses.con.Close()
					MyProject.Forms.frmPOSNewTuch.Calc()
					MyProject.Forms.frmPOSNewTuch.Compute()
					MyProject.Forms.frmPOSNewTuch.alldiscountcalc()
					MyProject.Forms.frmPOSNewTuch.Bankcondn()
					MyProject.Forms.frmPOSNewTuch.totitemnqty()
					MyProject.Forms.frmPOSNewTuch.btnSelectSalesman.Enabled = False
					MyProject.Forms.frmPOSNewTuch.btnListReset1.PerformClick()
					MyProject.Forms.frmPOSNewTuch.SalesmanCommn()
					MyProject.Forms.frmPOSNewTuch.Calculate143()
					MyProject.Forms.frmPOSNewTuch.tcsconn()
					MyProject.Forms.frmPOSNewTuch.tcsconn1()
					MyProject.Forms.frmPOSNewTuch.CTypeStatusforHold()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060018F0 RID: 6384 RVA: 0x0010ED00 File Offset: 0x0010CF00
		Private Sub btnunhold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Try
					Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete all hold records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "delete from Stock_Hold where Hold_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag3 As Boolean = num > 0
						If flag3 Then
						End If
						Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag4 Then
							ModCommonClasses.con.Close()
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "delete from Stock_Product_Hold where Hold_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						num = ModCommonClasses.cmd.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
						End If
						Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag6 Then
							ModCommonClasses.con.Close()
						End If
						Dim text3 As String = "deleted hold bill (Products) having Hold No. '" + Me.txtHold.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("No Records Found", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060018F1 RID: 6385 RVA: 0x0010EF14 File Offset: 0x0010D114
		Public Sub fillHoldNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Hold_ID) FROM Stock_Hold WHERE Stock_Hold.TillID='" + Dns.GetHostName() + "'", ModCommonClasses.con)
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

		' Token: 0x060018F2 RID: 6386 RVA: 0x0010F054 File Offset: 0x0010D254
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ST_ID, RTRIM(Hold_Id), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock_Hold.Remarks), RTRIM(Stock_Hold.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock_Hold where Supplier.ID=Stock_Hold.SupplierID and Hold_ID='" + Me.ComboBox1.Text + "'  order by [Date]"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060018F3 RID: 6387 RVA: 0x00013141 File Offset: 0x00011341
		Private Sub Reset()
			Me.txtHold.Text = ""
			Me.ComboBox1.SelectedIndex = -1
			Me.GetData()
			Me.fillHoldNo()
		End Sub

		' Token: 0x060018F4 RID: 6388 RVA: 0x00013170 File Offset: 0x00011370
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060018F5 RID: 6389 RVA: 0x0010F350 File Offset: 0x0010D550
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtHold.Text = dataGridViewRow.Cells(1).Value.ToString()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060018F6 RID: 6390 RVA: 0x0010F3D0 File Offset: 0x0010D5D0
		Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label4.Text, "frmPurchaseEntry", False) = 0
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x060018F7 RID: 6391 RVA: 0x0010F404 File Offset: 0x0010D604
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x060018F8 RID: 6392 RVA: 0x0010F4EC File Offset: 0x0010D6EC
		Private Sub btnhold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag Then
				Try
					Dim flag2 As Boolean = MessageBox.Show("Do you really want to delete all hold records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "DELETE FROM Stock_Hold"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.ExecuteNonQuery()
						text = "DELETE FROM Stock_Product_Hold"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.ExecuteNonQuery()
						MyBase.Close()
						Dim text2 As String = "deleted all hold records"
						ModFunc.LogFunc(Me.lblUser.Text, text2)
						MessageBox.Show("Successfully all Hold Records Deleted", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("No Records Found", "Hold", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060018F9 RID: 6393 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmHoldrecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060018FA RID: 6394 RVA: 0x0010F618 File Offset: 0x0010D818
		Public Sub GetData1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ST_ID, RTRIM(Hold_Id), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock_Hold.Remarks), RTRIM(Stock_Hold.BillSundry),Doc,RTRIM(BankAccount),Supplier.Address,Supplier.GSTIN,Supplier.State,Supplier.ContactNo from Supplier,Stock_Hold where Supplier.ID=Stock_Hold.SupplierID order by [Date]"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@T1", Dns.GetHostName().TrimEnd(New Char(-1) {}).ToString())
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060018FB RID: 6395 RVA: 0x0010F928 File Offset: 0x0010DB28
		Public Sub fillHoldNo1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Hold_ID) FROM Stock_Hold", ModCommonClasses.con)
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

		' Token: 0x060018FC RID: 6396 RVA: 0x0001317A File Offset: 0x0001137A
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.GetData1()
			Me.fillHoldNo1()
		End Sub
	End Class
End Namespace
