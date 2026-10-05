Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000361 RID: 865
	<DesignerGenerated()>
	Public Partial Class frmProductListWeigh
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CCC6 RID: 52422 RVA: 0x007FFA98 File Offset: 0x007FDC98
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCurrentStock_Load
			AddHandler MyBase.KeyDown, AddressOf Me.fromProductListWeigh_KeyDown
			Me.unit = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005076 RID: 20598
		' (get) Token: 0x0600CCC9 RID: 52425 RVA: 0x0005B0FF File Offset: 0x000592FF
		' (set) Token: 0x0600CCCA RID: 52426 RVA: 0x0005B109 File Offset: 0x00059309
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005077 RID: 20599
		' (get) Token: 0x0600CCCB RID: 52427 RVA: 0x0005B112 File Offset: 0x00059312
		' (set) Token: 0x0600CCCC RID: 52428 RVA: 0x0005B11C File Offset: 0x0005931C
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17005078 RID: 20600
		' (get) Token: 0x0600CCCD RID: 52429 RVA: 0x0005B125 File Offset: 0x00059325
		' (set) Token: 0x0600CCCE RID: 52430 RVA: 0x00801904 File Offset: 0x007FFB04
		Private _txtPartno As TextBox
		Friend Overridable Property txtPartno As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPartno
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPartno_KeyDown
				Dim textBox As TextBox = Me._txtPartno
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtPartno = value
				textBox = Me._txtPartno
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005079 RID: 20601
		' (get) Token: 0x0600CCCF RID: 52431 RVA: 0x0005B12F File Offset: 0x0005932F
		' (set) Token: 0x0600CCD0 RID: 52432 RVA: 0x0005B139 File Offset: 0x00059339
		Friend Overridable Property Label8 As Label

		' Token: 0x1700507A RID: 20602
		' (get) Token: 0x0600CCD1 RID: 52433 RVA: 0x0005B142 File Offset: 0x00059342
		' (set) Token: 0x0600CCD2 RID: 52434 RVA: 0x0005B14C File Offset: 0x0005934C
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700507B RID: 20603
		' (get) Token: 0x0600CCD3 RID: 52435 RVA: 0x0005B155 File Offset: 0x00059355
		' (set) Token: 0x0600CCD4 RID: 52436 RVA: 0x00801948 File Offset: 0x007FFB48
		Private _txtSubcategory As TextBox
		Friend Overridable Property txtSubcategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSubcategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSubcategory_KeyDown
				Dim textBox As TextBox = Me._txtSubcategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSubcategory = value
				textBox = Me._txtSubcategory
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700507C RID: 20604
		' (get) Token: 0x0600CCD5 RID: 52437 RVA: 0x0005B15F File Offset: 0x0005935F
		' (set) Token: 0x0600CCD6 RID: 52438 RVA: 0x0005B169 File Offset: 0x00059369
		Friend Overridable Property Label7 As Label

		' Token: 0x1700507D RID: 20605
		' (get) Token: 0x0600CCD7 RID: 52439 RVA: 0x0005B172 File Offset: 0x00059372
		' (set) Token: 0x0600CCD8 RID: 52440 RVA: 0x0005B17C File Offset: 0x0005937C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700507E RID: 20606
		' (get) Token: 0x0600CCD9 RID: 52441 RVA: 0x0005B185 File Offset: 0x00059385
		' (set) Token: 0x0600CCDA RID: 52442 RVA: 0x0080198C File Offset: 0x007FFB8C
		Private _txtCategory As TextBox
		Friend Overridable Property txtCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCategory_KeyDown
				Dim textBox As TextBox = Me._txtCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCategory = value
				textBox = Me._txtCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700507F RID: 20607
		' (get) Token: 0x0600CCDB RID: 52443 RVA: 0x0005B18F File Offset: 0x0005938F
		' (set) Token: 0x0600CCDC RID: 52444 RVA: 0x0005B199 File Offset: 0x00059399
		Friend Overridable Property Label6 As Label

		' Token: 0x17005080 RID: 20608
		' (get) Token: 0x0600CCDD RID: 52445 RVA: 0x0005B1A2 File Offset: 0x000593A2
		' (set) Token: 0x0600CCDE RID: 52446 RVA: 0x0005B1AC File Offset: 0x000593AC
		Friend Overridable Property lblSet As Label

		' Token: 0x17005081 RID: 20609
		' (get) Token: 0x0600CCDF RID: 52447 RVA: 0x0005B1B5 File Offset: 0x000593B5
		' (set) Token: 0x0600CCE0 RID: 52448 RVA: 0x0005B1BF File Offset: 0x000593BF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005082 RID: 20610
		' (get) Token: 0x0600CCE1 RID: 52449 RVA: 0x0005B1C8 File Offset: 0x000593C8
		' (set) Token: 0x0600CCE2 RID: 52450 RVA: 0x008019D0 File Offset: 0x007FFBD0
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005083 RID: 20611
		' (get) Token: 0x0600CCE3 RID: 52451 RVA: 0x0005B1D2 File Offset: 0x000593D2
		' (set) Token: 0x0600CCE4 RID: 52452 RVA: 0x0005B1DC File Offset: 0x000593DC
		Friend Overridable Property Label2 As Label

		' Token: 0x17005084 RID: 20612
		' (get) Token: 0x0600CCE5 RID: 52453 RVA: 0x0005B1E5 File Offset: 0x000593E5
		' (set) Token: 0x0600CCE6 RID: 52454 RVA: 0x0005B1EF File Offset: 0x000593EF
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005085 RID: 20613
		' (get) Token: 0x0600CCE7 RID: 52455 RVA: 0x0005B1F8 File Offset: 0x000593F8
		' (set) Token: 0x0600CCE8 RID: 52456 RVA: 0x0005B202 File Offset: 0x00059402
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005086 RID: 20614
		' (get) Token: 0x0600CCE9 RID: 52457 RVA: 0x0005B20B File Offset: 0x0005940B
		' (set) Token: 0x0600CCEA RID: 52458 RVA: 0x00801A14 File Offset: 0x007FFC14
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005087 RID: 20615
		' (get) Token: 0x0600CCEB RID: 52459 RVA: 0x0005B215 File Offset: 0x00059415
		' (set) Token: 0x0600CCEC RID: 52460 RVA: 0x0005B21F File Offset: 0x0005941F
		Friend Overridable Property Label3 As Label

		' Token: 0x17005088 RID: 20616
		' (get) Token: 0x0600CCED RID: 52461 RVA: 0x0005B228 File Offset: 0x00059428
		' (set) Token: 0x0600CCEE RID: 52462 RVA: 0x0005B232 File Offset: 0x00059432
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17005089 RID: 20617
		' (get) Token: 0x0600CCEF RID: 52463 RVA: 0x0005B23B File Offset: 0x0005943B
		' (set) Token: 0x0600CCF0 RID: 52464 RVA: 0x0005B245 File Offset: 0x00059445
		Friend Overridable Property Label1 As Label

		' Token: 0x1700508A RID: 20618
		' (get) Token: 0x0600CCF1 RID: 52465 RVA: 0x0005B24E File Offset: 0x0005944E
		' (set) Token: 0x0600CCF2 RID: 52466 RVA: 0x0005B258 File Offset: 0x00059458
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x1700508B RID: 20619
		' (get) Token: 0x0600CCF3 RID: 52467 RVA: 0x0005B261 File Offset: 0x00059461
		' (set) Token: 0x0600CCF4 RID: 52468 RVA: 0x0005B26B File Offset: 0x0005946B
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700508C RID: 20620
		' (get) Token: 0x0600CCF5 RID: 52469 RVA: 0x0005B274 File Offset: 0x00059474
		' (set) Token: 0x0600CCF6 RID: 52470 RVA: 0x0005B27E File Offset: 0x0005947E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700508D RID: 20621
		' (get) Token: 0x0600CCF7 RID: 52471 RVA: 0x0005B287 File Offset: 0x00059487
		' (set) Token: 0x0600CCF8 RID: 52472 RVA: 0x0005B291 File Offset: 0x00059491
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700508E RID: 20622
		' (get) Token: 0x0600CCF9 RID: 52473 RVA: 0x0005B29A File Offset: 0x0005949A
		' (set) Token: 0x0600CCFA RID: 52474 RVA: 0x0005B2A4 File Offset: 0x000594A4
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700508F RID: 20623
		' (get) Token: 0x0600CCFB RID: 52475 RVA: 0x0005B2AD File Offset: 0x000594AD
		' (set) Token: 0x0600CCFC RID: 52476 RVA: 0x0005B2B7 File Offset: 0x000594B7
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17005090 RID: 20624
		' (get) Token: 0x0600CCFD RID: 52477 RVA: 0x0005B2C0 File Offset: 0x000594C0
		' (set) Token: 0x0600CCFE RID: 52478 RVA: 0x0005B2CA File Offset: 0x000594CA
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17005091 RID: 20625
		' (get) Token: 0x0600CCFF RID: 52479 RVA: 0x0005B2D3 File Offset: 0x000594D3
		' (set) Token: 0x0600CD00 RID: 52480 RVA: 0x0005B2DD File Offset: 0x000594DD
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17005092 RID: 20626
		' (get) Token: 0x0600CD01 RID: 52481 RVA: 0x0005B2E6 File Offset: 0x000594E6
		' (set) Token: 0x0600CD02 RID: 52482 RVA: 0x0005B2F0 File Offset: 0x000594F0
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005093 RID: 20627
		' (get) Token: 0x0600CD03 RID: 52483 RVA: 0x0005B2F9 File Offset: 0x000594F9
		' (set) Token: 0x0600CD04 RID: 52484 RVA: 0x0005B303 File Offset: 0x00059503
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005094 RID: 20628
		' (get) Token: 0x0600CD05 RID: 52485 RVA: 0x0005B30C File Offset: 0x0005950C
		' (set) Token: 0x0600CD06 RID: 52486 RVA: 0x0005B316 File Offset: 0x00059516
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005095 RID: 20629
		' (get) Token: 0x0600CD07 RID: 52487 RVA: 0x0005B31F File Offset: 0x0005951F
		' (set) Token: 0x0600CD08 RID: 52488 RVA: 0x0005B329 File Offset: 0x00059529
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005096 RID: 20630
		' (get) Token: 0x0600CD09 RID: 52489 RVA: 0x0005B332 File Offset: 0x00059532
		' (set) Token: 0x0600CD0A RID: 52490 RVA: 0x0005B33C File Offset: 0x0005953C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005097 RID: 20631
		' (get) Token: 0x0600CD0B RID: 52491 RVA: 0x0005B345 File Offset: 0x00059545
		' (set) Token: 0x0600CD0C RID: 52492 RVA: 0x0005B34F File Offset: 0x0005954F
		Friend Overridable Property Label4 As Label

		' Token: 0x17005098 RID: 20632
		' (get) Token: 0x0600CD0D RID: 52493 RVA: 0x0005B358 File Offset: 0x00059558
		' (set) Token: 0x0600CD0E RID: 52494 RVA: 0x0005B362 File Offset: 0x00059562
		Friend Overridable Property Label10 As Label

		' Token: 0x17005099 RID: 20633
		' (get) Token: 0x0600CD0F RID: 52495 RVA: 0x0005B36B File Offset: 0x0005956B
		' (set) Token: 0x0600CD10 RID: 52496 RVA: 0x0005B375 File Offset: 0x00059575
		Friend Overridable Property Label11 As Label

		' Token: 0x1700509A RID: 20634
		' (get) Token: 0x0600CD11 RID: 52497 RVA: 0x0005B37E File Offset: 0x0005957E
		' (set) Token: 0x0600CD12 RID: 52498 RVA: 0x0005B388 File Offset: 0x00059588
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x1700509B RID: 20635
		' (get) Token: 0x0600CD13 RID: 52499 RVA: 0x0005B391 File Offset: 0x00059591
		' (set) Token: 0x0600CD14 RID: 52500 RVA: 0x0005B39B File Offset: 0x0005959B
		Friend Overridable Property Label9 As Label

		' Token: 0x1700509C RID: 20636
		' (get) Token: 0x0600CD15 RID: 52501 RVA: 0x0005B3A4 File Offset: 0x000595A4
		' (set) Token: 0x0600CD16 RID: 52502 RVA: 0x0005B3AE File Offset: 0x000595AE
		Friend Overridable Property Label5 As Label

		' Token: 0x1700509D RID: 20637
		' (get) Token: 0x0600CD17 RID: 52503 RVA: 0x0005B3B7 File Offset: 0x000595B7
		' (set) Token: 0x0600CD18 RID: 52504 RVA: 0x0005B3C1 File Offset: 0x000595C1
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x1700509E RID: 20638
		' (get) Token: 0x0600CD19 RID: 52505 RVA: 0x0005B3CA File Offset: 0x000595CA
		' (set) Token: 0x0600CD1A RID: 52506 RVA: 0x00801A58 File Offset: 0x007FFC58
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700509F RID: 20639
		' (get) Token: 0x0600CD1B RID: 52507 RVA: 0x0005B3D4 File Offset: 0x000595D4
		' (set) Token: 0x0600CD1C RID: 52508 RVA: 0x00801A9C File Offset: 0x007FFC9C
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
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

		' Token: 0x170050A0 RID: 20640
		' (get) Token: 0x0600CD1D RID: 52509 RVA: 0x0005B3DE File Offset: 0x000595DE
		' (set) Token: 0x0600CD1E RID: 52510 RVA: 0x0005B3E8 File Offset: 0x000595E8
		Friend Overridable Property btnReset As GelButton

		' Token: 0x0600CD1F RID: 52511 RVA: 0x00801AE0 File Offset: 0x007FFCE0
		Public Sub Getdata()
			Try
				Me.dgw.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(Temp_Stock.MRP),(Temp_Stock.MRP),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
				Else
					Dim checked As Boolean = Me.CheckBox1.Checked
					If checked Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(Temp_Stock.MRP),(Temp_Stock.MRP),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					End If
				End If
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
					If flag2 Then
						Me.unit = "0"
					Else
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
						If flag3 Then
							Me.unit = "1"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
							If flag4 Then
								Me.unit = "2"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
								If flag5 Then
									Me.unit = "3"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
									If flag6 Then
										Me.unit = "4"
									End If
								End If
							End If
						End If
					End If
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD20 RID: 52512 RVA: 0x00801D8C File Offset: 0x007FFF8C
		Public Sub Reset()
			Me.CheckBox1.Checked = False
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtCategory.Text = ""
			Me.txtSubcategory.Text = ""
			Me.txtPartno.Text = ""
			Me.dgw.Rows.Clear()
			Me.ComboBox1.SelectedIndex = 0
			Me.ComboBox2.SelectedIndex = 0
		End Sub

		' Token: 0x0600CD21 RID: 52513 RVA: 0x00801E28 File Offset: 0x00800028
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Not Me.CheckBox1.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and ProductName like N'" + Me.txtProductName.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and ProductName like N'" + Me.txtProductName.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
						If flag3 Then
							Me.unit = "0"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
							If flag4 Then
								Me.unit = "1"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
								If flag5 Then
									Me.unit = "2"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
									If flag6 Then
										Me.unit = "3"
									Else
										Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
										If flag7 Then
											Me.unit = "4"
										End If
									End If
								End If
							End If
						End If
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD22 RID: 52514 RVA: 0x008020FC File Offset: 0x008002FC
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Not Me.CheckBox1.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and '0000000000'+Temp_Stock.Barcode like N'" + Me.txtBarcode.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and '0000000000'+Temp_Stock.Barcode like N'" + Me.txtBarcode.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
						If flag3 Then
							Me.unit = "0"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
							If flag4 Then
								Me.unit = "1"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
								If flag5 Then
									Me.unit = "2"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
									If flag6 Then
										Me.unit = "3"
									Else
										Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
										If flag7 Then
											Me.unit = "4"
										End If
									End If
								End If
							End If
						End If
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD23 RID: 52515 RVA: 0x008023D0 File Offset: 0x008005D0
		Private Sub txtCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Not Me.CheckBox1.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and Category like N'" + Me.txtCategory.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Category like N'" + Me.txtCategory.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
						If flag3 Then
							Me.unit = "0"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
							If flag4 Then
								Me.unit = "1"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
								If flag5 Then
									Me.unit = "2"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
									If flag6 Then
										Me.unit = "3"
									Else
										Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
										If flag7 Then
											Me.unit = "4"
										End If
									End If
								End If
							End If
						End If
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD24 RID: 52516 RVA: 0x008026A4 File Offset: 0x008008A4
		Private Sub txtSubcategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Not Me.CheckBox1.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and SubCategoryName like N'" + Me.txtSubcategory.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and SubCategoryName like N'" + Me.txtSubcategory.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
						If flag3 Then
							Me.unit = "0"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
							If flag4 Then
								Me.unit = "1"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
								If flag5 Then
									Me.unit = "2"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
									If flag6 Then
										Me.unit = "3"
									Else
										Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
										If flag7 Then
											Me.unit = "4"
										End If
									End If
								End If
							End If
						End If
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD25 RID: 52517 RVA: 0x00802978 File Offset: 0x00800B78
		Private Sub txtPartno_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Not Me.CheckBox1.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Qty > 0 and PartNo like N'" + Me.txtPartno.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
					Else
						Dim checked As Boolean = Me.CheckBox1.Checked
						If checked Then
							ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(ProductName),RTRIM(SalesUnit),(SellingPrice),Qty,Qty ,(CGST + SGST),Qty,Discount, RTRIM(Temp_Stock.Barcode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and PartNo like N'" + Me.txtPartno.Text + "%' and Product.Status='Yes' order by ProductName", ModCommonClasses.con)
						End If
					End If
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Kg", False)
						If flag3 Then
							Me.unit = "0"
						Else
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Pcs", False)
							If flag4 Then
								Me.unit = "1"
							Else
								Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Liter", False)
								If flag5 Then
									Me.unit = "2"
								Else
									Dim flag6 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "Dozen", False)
									If flag6 Then
										Me.unit = "3"
									Else
										Dim flag7 As Boolean = Operators.ConditionalCompareObjectEqual(ModCommonClasses.rdr(2), "gm", False)
										If flag7 Then
											Me.unit = "4"
										End If
									End If
								End If
							End If
						End If
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), Me.unit, ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), Me.ComboBox1.Text, ModCommonClasses.rdr(6), Me.ComboBox2.Text, ModCommonClasses.rdr(8), Operators.AddObject("0000000000", ModCommonClasses.rdr(9)) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD26 RID: 52518 RVA: 0x00802C4C File Offset: 0x00800E4C
		Private Sub frmCurrentStock_Load(sender As Object, e As EventArgs)
			frmProductListWeigh.DoubleBuffered(Me.dgw, True)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Label4.Text = "UNIT :" & vbCrLf & vbCrLf & "Kg = 0" & vbCrLf & "Pcs = 1" & vbCrLf & "Liter = 2" & vbCrLf & "Dozen = 3" & vbCrLf & "gm = 4"
			Me.ComboBox1.SelectedIndex = 0
			Me.ComboBox2.SelectedIndex = 0
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CD27 RID: 52519 RVA: 0x00802D08 File Offset: 0x00800F08
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

		' Token: 0x0600CD28 RID: 52520 RVA: 0x00802E80 File Offset: 0x00801080
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
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

		' Token: 0x0600CD29 RID: 52521 RVA: 0x00802F3C File Offset: 0x0080113C
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

		' Token: 0x0600CD2A RID: 52522 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CD2B RID: 52523 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CD2C RID: 52524 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CD2D RID: 52525 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw As DataGridView, setting As Boolean)
			Dim type As Type = dgw.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw, setting, Nothing)
		End Sub

		' Token: 0x0600CD2E RID: 52526 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub fromProductListWeigh_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CD2F RID: 52527 RVA: 0x00803008 File Offset: 0x00801208
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Try
				Try
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(obj)
							Dim dataGridViewColumn As DataGridViewColumn = CType(objectValue, DataGridViewColumn)
							text = text + """" + dataGridViewColumn.HeaderText + ""","
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator2 As IEnumerator
					Dim flag As Boolean = TypeOf enumerator2 Is IDisposable
					Dim flag2 As Boolean = flag
					If flag2 Then
						TryCast(enumerator2, IDisposable).Dispose()
					End If
				End Try
				text = text.Substring(0, text.Length - 1)
				text += Environment.NewLine
				Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(obj2)
							Dim dataGridViewRow As DataGridViewRow = CType(objectValue2, DataGridViewRow)
							Try
								Try
									For Each obj3 As Object In dataGridViewRow.Cells
										Dim objectValue3 As Object = RuntimeHelpers.GetObjectValue(obj3)
										Dim dataGridViewCell As DataGridViewCell = CType(objectValue3, DataGridViewCell)
										Dim flag3 As Boolean = dataGridViewCell.Value IsNot Nothing
										Dim flag4 As Boolean = flag3
										If flag4 Then
											text = text + """" + dataGridViewCell.Value.ToString() + ""","
										Else
											text += """"","
										End If
									Next
								Finally
									Dim enumerator4 As IEnumerator
									If TypeOf enumerator4 Is IDisposable Then
										TryCast(enumerator4, IDisposable).Dispose()
									End If
								End Try
							Finally
								Dim enumerator5 As IEnumerator
								Dim flag5 As Boolean = TypeOf enumerator5 Is IDisposable
								Dim flag6 As Boolean = flag5
								If flag6 Then
									TryCast(enumerator5, IDisposable).Dispose()
								End If
							End Try
							text = text.Substring(0, text.Length - 1)
							text += Environment.NewLine
						Next
					Finally
						Dim enumerator3 As IEnumerator
						If TypeOf enumerator3 Is IDisposable Then
							TryCast(enumerator3, IDisposable).Dispose()
						End If
					End Try
				Finally
					Dim enumerator6 As IEnumerator
					Dim flag7 As Boolean = TypeOf enumerator6 Is IDisposable
					Dim flag8 As Boolean = flag7
					If flag8 Then
						TryCast(enumerator6, IDisposable).Dispose()
					End If
				End Try
				Dim textWriter As TextWriter = New StreamWriter(Application.StartupPath + "\PLUDATA.CSV")
				textWriter.Write(text)
				textWriter.Close()
				MessageBox.Show("Successfully Exported", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CD30 RID: 52528 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600CD31 RID: 52529 RVA: 0x00803324 File Offset: 0x00801524
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.Getdata()
			End If
		End Sub

		' Token: 0x04005257 RID: 21079
		Private unit As String
	End Class
End Namespace
