Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001DA RID: 474
	<DesignerGenerated()>
	Public Partial Class frmProductEntry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06007ECC RID: 32460 RVA: 0x0003E4DA File Offset: 0x0003C6DA
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductEntry_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductEntry_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17002E86 RID: 11910
		' (get) Token: 0x06007ECF RID: 32463 RVA: 0x0003E50C File Offset: 0x0003C70C
		' (set) Token: 0x06007ED0 RID: 32464 RVA: 0x0003E516 File Offset: 0x0003C716
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17002E87 RID: 11911
		' (get) Token: 0x06007ED1 RID: 32465 RVA: 0x0003E51F File Offset: 0x0003C71F
		' (set) Token: 0x06007ED2 RID: 32466 RVA: 0x0003E529 File Offset: 0x0003C729
		Friend Overridable Property Label21 As Label

		' Token: 0x17002E88 RID: 11912
		' (get) Token: 0x06007ED3 RID: 32467 RVA: 0x0003E532 File Offset: 0x0003C732
		' (set) Token: 0x06007ED4 RID: 32468 RVA: 0x0003E53C File Offset: 0x0003C73C
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17002E89 RID: 11913
		' (get) Token: 0x06007ED5 RID: 32469 RVA: 0x0003E545 File Offset: 0x0003C745
		' (set) Token: 0x06007ED6 RID: 32470 RVA: 0x0003E54F File Offset: 0x0003C74F
		Friend Overridable Property txtbarcodeNocopy As TextBox

		' Token: 0x17002E8A RID: 11914
		' (get) Token: 0x06007ED7 RID: 32471 RVA: 0x0003E558 File Offset: 0x0003C758
		' (set) Token: 0x06007ED8 RID: 32472 RVA: 0x0003E562 File Offset: 0x0003C762
		Friend Overridable Property Label20 As Label

		' Token: 0x17002E8B RID: 11915
		' (get) Token: 0x06007ED9 RID: 32473 RVA: 0x0003E56B File Offset: 0x0003C76B
		' (set) Token: 0x06007EDA RID: 32474 RVA: 0x0003E575 File Offset: 0x0003C775
		Friend Overridable Property Label18 As Label

		' Token: 0x17002E8C RID: 11916
		' (get) Token: 0x06007EDB RID: 32475 RVA: 0x0003E57E File Offset: 0x0003C77E
		' (set) Token: 0x06007EDC RID: 32476 RVA: 0x0003E588 File Offset: 0x0003C788
		Friend Overridable Property Label16 As Label

		' Token: 0x17002E8D RID: 11917
		' (get) Token: 0x06007EDD RID: 32477 RVA: 0x0003E591 File Offset: 0x0003C791
		' (set) Token: 0x06007EDE RID: 32478 RVA: 0x005E680C File Offset: 0x005E4A0C
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearchProduct_KeyDown
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E8E RID: 11918
		' (get) Token: 0x06007EDF RID: 32479 RVA: 0x0003E59B File Offset: 0x0003C79B
		' (set) Token: 0x06007EE0 RID: 32480 RVA: 0x005E6850 File Offset: 0x005E4A50
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E8F RID: 11919
		' (get) Token: 0x06007EE1 RID: 32481 RVA: 0x0003E5A5 File Offset: 0x0003C7A5
		' (set) Token: 0x06007EE2 RID: 32482 RVA: 0x0003E5AF File Offset: 0x0003C7AF
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17002E90 RID: 11920
		' (get) Token: 0x06007EE3 RID: 32483 RVA: 0x0003E5B8 File Offset: 0x0003C7B8
		' (set) Token: 0x06007EE4 RID: 32484 RVA: 0x0003E5C2 File Offset: 0x0003C7C2
		Friend Overridable Property Label17 As Label

		' Token: 0x17002E91 RID: 11921
		' (get) Token: 0x06007EE5 RID: 32485 RVA: 0x0003E5CB File Offset: 0x0003C7CB
		' (set) Token: 0x06007EE6 RID: 32486 RVA: 0x0003E5D5 File Offset: 0x0003C7D5
		Friend Overridable Property DataGridViewImageColumn2 As DataGridViewImageColumn

		' Token: 0x17002E92 RID: 11922
		' (get) Token: 0x06007EE7 RID: 32487 RVA: 0x0003E5DE File Offset: 0x0003C7DE
		' (set) Token: 0x06007EE8 RID: 32488 RVA: 0x0003E5E8 File Offset: 0x0003C7E8
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17002E93 RID: 11923
		' (get) Token: 0x06007EE9 RID: 32489 RVA: 0x0003E5F1 File Offset: 0x0003C7F1
		' (set) Token: 0x06007EEA RID: 32490 RVA: 0x0003E5FB File Offset: 0x0003C7FB
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17002E94 RID: 11924
		' (get) Token: 0x06007EEB RID: 32491 RVA: 0x0003E604 File Offset: 0x0003C804
		' (set) Token: 0x06007EEC RID: 32492 RVA: 0x005E6894 File Offset: 0x005E4A94
		Private _GelButtonNewRecord As Button
		Friend Overridable Property GelButtonNewRecord As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E95 RID: 11925
		' (get) Token: 0x06007EED RID: 32493 RVA: 0x0003E60E File Offset: 0x0003C80E
		' (set) Token: 0x06007EEE RID: 32494 RVA: 0x005E68D8 File Offset: 0x005E4AD8
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E96 RID: 11926
		' (get) Token: 0x06007EEF RID: 32495 RVA: 0x0003E618 File Offset: 0x0003C818
		' (set) Token: 0x06007EF0 RID: 32496 RVA: 0x0003E622 File Offset: 0x0003C822
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17002E97 RID: 11927
		' (get) Token: 0x06007EF1 RID: 32497 RVA: 0x0003E62B File Offset: 0x0003C82B
		' (set) Token: 0x06007EF2 RID: 32498 RVA: 0x0003E635 File Offset: 0x0003C835
		Friend Overridable Property Label15 As Label

		' Token: 0x17002E98 RID: 11928
		' (get) Token: 0x06007EF3 RID: 32499 RVA: 0x0003E63E File Offset: 0x0003C83E
		' (set) Token: 0x06007EF4 RID: 32500 RVA: 0x0003E648 File Offset: 0x0003C848
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17002E99 RID: 11929
		' (get) Token: 0x06007EF5 RID: 32501 RVA: 0x0003E651 File Offset: 0x0003C851
		' (set) Token: 0x06007EF6 RID: 32502 RVA: 0x0003E65B File Offset: 0x0003C85B
		Friend Overridable Property cmbSearchCat As ComboBox

		' Token: 0x17002E9A RID: 11930
		' (get) Token: 0x06007EF7 RID: 32503 RVA: 0x0003E664 File Offset: 0x0003C864
		' (set) Token: 0x06007EF8 RID: 32504 RVA: 0x0003E66E File Offset: 0x0003C86E
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x17002E9B RID: 11931
		' (get) Token: 0x06007EF9 RID: 32505 RVA: 0x0003E677 File Offset: 0x0003C877
		' (set) Token: 0x06007EFA RID: 32506 RVA: 0x0003E681 File Offset: 0x0003C881
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17002E9C RID: 11932
		' (get) Token: 0x06007EFB RID: 32507 RVA: 0x0003E68A File Offset: 0x0003C88A
		' (set) Token: 0x06007EFC RID: 32508 RVA: 0x005E691C File Offset: 0x005E4B1C
		Private _DataGridView2 As DataGridView
		Friend Overridable Property DataGridView2 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView2_CellContentClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DataGridView2_KeyDown
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.DataGridView2_EditingControlShowing
				Dim dataGridView As DataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
				Me._DataGridView2 = value
				dataGridView = Me._DataGridView2
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002E9D RID: 11933
		' (get) Token: 0x06007EFD RID: 32509 RVA: 0x0003E694 File Offset: 0x0003C894
		' (set) Token: 0x06007EFE RID: 32510 RVA: 0x0003E69E File Offset: 0x0003C89E
		Friend Overridable Property PID1 As DataGridViewTextBoxColumn

		' Token: 0x17002E9E RID: 11934
		' (get) Token: 0x06007EFF RID: 32511 RVA: 0x0003E6A7 File Offset: 0x0003C8A7
		' (set) Token: 0x06007F00 RID: 32512 RVA: 0x0003E6B1 File Offset: 0x0003C8B1
		Friend Overridable Property ProductCode1 As DataGridViewTextBoxColumn

		' Token: 0x17002E9F RID: 11935
		' (get) Token: 0x06007F01 RID: 32513 RVA: 0x0003E6BA File Offset: 0x0003C8BA
		' (set) Token: 0x06007F02 RID: 32514 RVA: 0x0003E6C4 File Offset: 0x0003C8C4
		Friend Overridable Property ProductName1 As DataGridViewTextBoxColumn

		' Token: 0x17002EA0 RID: 11936
		' (get) Token: 0x06007F03 RID: 32515 RVA: 0x0003E6CD File Offset: 0x0003C8CD
		' (set) Token: 0x06007F04 RID: 32516 RVA: 0x0003E6D7 File Offset: 0x0003C8D7
		Friend Overridable Property cboxUnit1 As DataGridViewComboBoxColumn

		' Token: 0x17002EA1 RID: 11937
		' (get) Token: 0x06007F05 RID: 32517 RVA: 0x0003E6E0 File Offset: 0x0003C8E0
		' (set) Token: 0x06007F06 RID: 32518 RVA: 0x0003E6EA File Offset: 0x0003C8EA
		Friend Overridable Property cboxTax1 As DataGridViewComboBoxColumn

		' Token: 0x17002EA2 RID: 11938
		' (get) Token: 0x06007F07 RID: 32519 RVA: 0x0003E6F3 File Offset: 0x0003C8F3
		' (set) Token: 0x06007F08 RID: 32520 RVA: 0x0003E6FD File Offset: 0x0003C8FD
		Friend Overridable Property InsertButton As DataGridViewButtonColumn

		' Token: 0x17002EA3 RID: 11939
		' (get) Token: 0x06007F09 RID: 32521 RVA: 0x0003E706 File Offset: 0x0003C906
		' (set) Token: 0x06007F0A RID: 32522 RVA: 0x0003E710 File Offset: 0x0003C910
		Friend Overridable Property UpdateButton As DataGridViewButtonColumn

		' Token: 0x17002EA4 RID: 11940
		' (get) Token: 0x06007F0B RID: 32523 RVA: 0x0003E719 File Offset: 0x0003C919
		' (set) Token: 0x06007F0C RID: 32524 RVA: 0x0003E723 File Offset: 0x0003C923
		Friend Overridable Property DeleteButton As DataGridViewButtonColumn

		' Token: 0x17002EA5 RID: 11941
		' (get) Token: 0x06007F0D RID: 32525 RVA: 0x0003E72C File Offset: 0x0003C92C
		' (set) Token: 0x06007F0E RID: 32526 RVA: 0x0003E736 File Offset: 0x0003C936
		Friend Overridable Property txtPPrice1 As DataGridViewTextBoxColumn

		' Token: 0x17002EA6 RID: 11942
		' (get) Token: 0x06007F0F RID: 32527 RVA: 0x0003E73F File Offset: 0x0003C93F
		' (set) Token: 0x06007F10 RID: 32528 RVA: 0x0003E749 File Offset: 0x0003C949
		Friend Overridable Property txtMRP1 As DataGridViewTextBoxColumn

		' Token: 0x17002EA7 RID: 11943
		' (get) Token: 0x06007F11 RID: 32529 RVA: 0x0003E752 File Offset: 0x0003C952
		' (set) Token: 0x06007F12 RID: 32530 RVA: 0x0003E75C File Offset: 0x0003C95C
		Friend Overridable Property txtSPrice1 As DataGridViewTextBoxColumn

		' Token: 0x17002EA8 RID: 11944
		' (get) Token: 0x06007F13 RID: 32531 RVA: 0x0003E765 File Offset: 0x0003C965
		' (set) Token: 0x06007F14 RID: 32532 RVA: 0x0003E76F File Offset: 0x0003C96F
		Friend Overridable Property txtBarcode1 As DataGridViewTextBoxColumn

		' Token: 0x17002EA9 RID: 11945
		' (get) Token: 0x06007F15 RID: 32533 RVA: 0x0003E778 File Offset: 0x0003C978
		' (set) Token: 0x06007F16 RID: 32534 RVA: 0x0003E782 File Offset: 0x0003C982
		Friend Overridable Property BarcodeButton As DataGridViewButtonColumn

		' Token: 0x17002EAA RID: 11946
		' (get) Token: 0x06007F17 RID: 32535 RVA: 0x0003E78B File Offset: 0x0003C98B
		' (set) Token: 0x06007F18 RID: 32536 RVA: 0x005E6998 File Offset: 0x005E4B98
		Private _GelButton3 As Button
		Friend Overridable Property GelButton3 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim button As Button = Me._GelButton3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton3 = value
				button = Me._GelButton3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002EAB RID: 11947
		' (get) Token: 0x06007F19 RID: 32537 RVA: 0x0003E795 File Offset: 0x0003C995
		' (set) Token: 0x06007F1A RID: 32538 RVA: 0x005E69DC File Offset: 0x005E4BDC
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

		' Token: 0x17002EAC RID: 11948
		' (get) Token: 0x06007F1B RID: 32539 RVA: 0x0003E79F File Offset: 0x0003C99F
		' (set) Token: 0x06007F1C RID: 32540 RVA: 0x005E6A20 File Offset: 0x005E4C20
		Private _btnImportExcel As Button
		Friend Overridable Property btnImportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnImportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnImportExcel_Click
				Dim button As Button = Me._btnImportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnImportExcel = value
				button = Me._btnImportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17002EAD RID: 11949
		' (get) Token: 0x06007F1D RID: 32541 RVA: 0x0003E7A9 File Offset: 0x0003C9A9
		' (set) Token: 0x06007F1E RID: 32542 RVA: 0x005E6A64 File Offset: 0x005E4C64
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17002EAE RID: 11950
		' (get) Token: 0x06007F1F RID: 32543 RVA: 0x0003E7B3 File Offset: 0x0003C9B3
		' (set) Token: 0x06007F20 RID: 32544 RVA: 0x0003E7BD File Offset: 0x0003C9BD
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x06007F21 RID: 32545 RVA: 0x005E6AA8 File Offset: 0x005E4CA8
		Private Sub frmProductEntry_Load(sender As Object, e As EventArgs)
			Me.fillUnit()
			Me.fillTaxRate()
			Me.default_fill_tax()
			Me.Getdata()
			Me.DataGridView2.AllowUserToAddRows = False
			Me.DataGridView2.Columns("ProductCode1").[ReadOnly] = True
			MyBase.KeyPreview = True
		End Sub

		' Token: 0x06007F22 RID: 32546 RVA: 0x005E6B04 File Offset: 0x005E4D04
		Public Sub fillUnit()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cboxUnit1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cboxUnit1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007F23 RID: 32547 RVA: 0x005E6C38 File Offset: 0x005E4E38
		Public Sub default_fillUnit_Default()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Unit) as Unit, IsDefault FROM UnitMaster where isDefault=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Dim text As String = ModCommonClasses.rdr.GetValue(0).ToString()
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					Dim index As Integer = Me.DataGridView2.Columns("cboxUnit1").Index
					Me.DataGridView2.Rows(num).Cells(index).Value = text
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F24 RID: 32548 RVA: 0x005E6D9C File Offset: 0x005E4F9C
		Public Sub fillTaxRate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Rate) FROM TaxCat order by Rate ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cboxTax1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cboxTax1.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06007F25 RID: 32549 RVA: 0x005E6ED0 File Offset: 0x005E50D0
		Public Sub default_fill_tax()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Rate),RTRIM(IsDefault) from TaxCat where IsDefault=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Dim text As String = ModCommonClasses.rdr.GetValue(0).ToString()
					Dim text2 As String = ModCommonClasses.rdr.GetValue(1).ToString()
					Dim dataRow As DataRow = ModCommonClasses.dtable.NewRow()
					dataRow("Column1") = text
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					Dim index As Integer = Me.DataGridView2.Columns("cboxTax1").Index
					Me.DataGridView2.Rows(num).Cells(index).Value = text
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F26 RID: 32550 RVA: 0x005E7064 File Offset: 0x005E5264
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Top " + Me.txtTopResult.Text + " product_id," & vbCrLf & "    product_code," & vbCrLf & "    product_name," & vbCrLf & "    unit," & vbCrLf & "    RTRIM(tax) from tbl_product" & vbCrLf & "     order by product_id desc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If(Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(4))), 0, ModCommonClasses.rdr(4)))
					Me.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), objectValue })
					Dim dataGridViewComboBoxColumn As DataGridViewComboBoxColumn = CType(Me.DataGridView2.Columns("cboxTax1"), DataGridViewComboBoxColumn)
					Dim flag As Boolean = Not dataGridViewComboBoxColumn.Items.Contains(RuntimeHelpers.GetObjectValue(objectValue))
					If flag Then
						dataGridViewComboBoxColumn.Items.Add(RuntimeHelpers.GetObjectValue(objectValue))
					End If
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView2.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F27 RID: 32551 RVA: 0x005E7214 File Offset: 0x005E5414
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.DataGridView2.Rows.Add()
			Me.DataGridView2.[ReadOnly] = False
			Dim num As Integer = Me.DataGridView2.Rows.Count - 1
			Me.DataGridView2.Columns("ProductCode1").[ReadOnly] = False
			Dim num2 As Integer = 1
			Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(num).Cells(num2)
			Me.DataGridView2.BeginEdit(True)
			Me.default_fill_tax()
			Me.default_fillUnit_Default()
		End Sub

		' Token: 0x06007F28 RID: 32552 RVA: 0x005E72BC File Offset: 0x005E54BC
		Public Sub ScrollToSelectedCell(rowIndex As Short, colIndex As Short)
			Me.DataGridView2.FirstDisplayedScrollingRowIndex = CInt(rowIndex)
			Me.DataGridView2.FirstDisplayedScrollingColumnIndex = CInt(colIndex)
			Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(CInt(rowIndex)).Cells(CInt(colIndex))
		End Sub

		' Token: 0x06007F29 RID: 32553 RVA: 0x000F58F4 File Offset: 0x000F3AF4
		Private Sub ComboBox_Enter(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			comboBox.DroppedDown = True
		End Sub

		' Token: 0x06007F2A RID: 32554 RVA: 0x005E730C File Offset: 0x005E550C
		Public Sub DBoperation(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Insert", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(rowNo)
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductCode1").Value))) = 0
					If flag2 Then
						MessageBox.Show("Please enter product code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag3 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductName1").Value))) = 0
						If flag3 Then
							MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = "select product_code from tbl_product where product_code=@d1"
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductCode1").Value.ToString())
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Product Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "insert into tbl_product(product_code,product_name,unit,tax,is_deleted) VALUES (@d0,@d1,@d2,@d3,@d4)"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", dataGridViewRow.Cells("ProductCode1").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductName1").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("cboxUnit1").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells("cboxTax1").Value.ToString())
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								ModCommonClasses.con.Close()
								Me.Getdata()
								Me.GelButtonNewRecord.Focus()
							End If
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
		End Sub

		' Token: 0x06007F2B RID: 32555 RVA: 0x005E7644 File Offset: 0x005E5844
		Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("InsertButton").Index AndAlso e.RowIndex >= 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductCode1").Value))) = 0
					If flag2 Then
						MessageBox.Show("Please enter product code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 0S)
						Return
					End If
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductName1").Value))) = 0
					If flag3 Then
						MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 1S)
						Return
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select product_code from tbl_product where product_code=@d1"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductCode1").Value.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
					If flag4 Then
						MessageBox.Show("Product Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Return
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "insert into tbl_product(product_code,product_name,unit,tax,is_deleted) VALUES (@d0,@d1,@d2,@d3,@d4)"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d0", dataGridViewRow.Cells("ProductCode1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells("ProductName1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("cboxUnit1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells("cboxTax1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					AddHandler Me.GelButtonNewRecord.Click, AddressOf Me.GelButtonNewRecord_Click
					Me.DataGridView2.CurrentCell = Me.DataGridView2(2, e.RowIndex)
					Me.DataGridView2.BeginEdit(True)
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
			Dim flag5 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("UpdateButton").Index AndAlso e.RowIndex >= 0
			If flag5 Then
				Try
					Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
					Dim flag6 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("ProductCode1").Value))) = 0
					If flag6 Then
						MessageBox.Show("Please enter product code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 0S)
						Return
					End If
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells("ProductName1").Value))) = 0
					If flag7 Then
						MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.ScrollToSelectedCell(CShort(e.RowIndex), 1S)
						Return
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "update tbl_product set product_code=@d0,product_name=@d1,unit=@d2,tax=@d3 where product_id=@d4"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d0", dataGridViewRow2.Cells("ProductCode1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells("ProductName1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells("cboxUnit1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow2.Cells("cboxTax1").Value.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow2.Cells("PID1").Value.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					AddHandler Me.GelButtonNewRecord.Click, AddressOf Me.GelButtonNewRecord_Click
					Me.DataGridView2.CurrentCell = Me.DataGridView2(2, e.RowIndex)
					Me.DataGridView2.BeginEdit(True)
				Catch ex2 As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex2.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
			Dim flag8 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("DeleteButton").Index AndAlso e.RowIndex >= 0
			If flag8 Then
				Try
					Dim dataGridViewRow3 As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
					Dim flag9 As Boolean = dataGridViewRow3.Cells("PID1").Value Is Nothing OrElse String.IsNullOrWhiteSpace(dataGridViewRow3.Cells("PID1").Value.ToString())
					If flag9 Then
						MessageBox.Show("Please enter a valid Product ID", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
					Dim flag10 As Boolean = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No
					If flag10 Then
						Return
					End If
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text4 As String = "DELETE FROM tbl_product WHERE product_id = @d0"
						Using sqlCommand As SqlCommand = New SqlCommand(text4, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d0", Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells("PID1").Value)))
							sqlCommand.ExecuteNonQuery()
						End Using
					End Using
					MessageBox.Show("Successfully Deleted", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					AddHandler Me.GelButtonNewRecord.Click, AddressOf Me.GelButtonNewRecord_Click
					Me.DataGridView2.CurrentCell = Me.DataGridView2(2, e.RowIndex)
					Me.DataGridView2.BeginEdit(True)
				Catch ex3 As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex3.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
			Dim flag11 As Boolean = e.ColumnIndex = Me.DataGridView2.Columns("BarcodeButton").Index AndAlso e.RowIndex >= 0
			If flag11 Then
				Try
					Dim dataGridViewRow4 As DataGridViewRow = Me.DataGridView2.Rows(e.RowIndex)
					Dim flag12 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow4.Cells("txtBarcode1").Value))) = 0
					If flag12 Then
						MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim reportDocument As ReportDocument = New ReportDocument()
						Dim dataTable As DataTable = New DataTable()
						Dim dataTable2 As DataTable = dataTable
						dataTable2.Columns.Add("ProductCode")
						dataTable2.Columns.Add("ProductName")
						dataTable2.Columns.Add("Unit")
						dataTable2.Columns.Add("Tax")
						dataTable2.Columns.Add("SalePrice")
						dataTable2.Columns.Add("Barcode")
						Dim text5 As String = dataGridViewRow4.Cells("ProductCode1").Value.ToString()
						Dim text6 As String = dataGridViewRow4.Cells("ProductName1").Value.ToString()
						Dim text7 As String = dataGridViewRow4.Cells("cboxUnit1").Value.ToString()
						Dim text8 As String = dataGridViewRow4.Cells("cboxTax1").Value.ToString()
						Dim text9 As String = dataGridViewRow4.Cells("txtSPrice1").Value.ToString()
						Dim text10 As String = dataGridViewRow4.Cells("txtBarcode1").Value.ToString()
						dataTable.Rows.Add(New Object() { text5, text6, text7, text8, text9, text10 })
						Dim activeBarcodeType As frmProductEntry.GorillaBarcodePreview = Me.GetActiveBarcodeType()
						Dim flag13 As Boolean = activeBarcodeType IsNot Nothing
						If flag13 Then
							Dim reportDocument2 As ReportDocument = New ReportDocument()
							reportDocument2.Load(Application.StartupPath + "\CryReport\" + activeBarcodeType.PrintPreviewType + ".rpt")
							reportDocument2.SetDataSource(dataTable)
							reportDocument2.SetParameterValue("P1", "ABC")
							reportDocument2.SetParameterValue("Productcode", text5)
							reportDocument2.SetParameterValue("ProductName", text6)
							reportDocument2.SetParameterValue("Unit", text7)
							reportDocument2.SetParameterValue("Tax", text8)
							reportDocument2.SetParameterValue("SPrice", text9)
							reportDocument2.SetParameterValue("Barcode", text10)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument2
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						End If
					End If
				Catch ex4 As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex4.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
		End Sub

		' Token: 0x06007F2C RID: 32556 RVA: 0x005E828C File Offset: 0x005E648C
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				e.IsInputKey = True
				Dim rowIndex As Integer = editingControlDataGridView.CurrentCell.RowIndex
				Dim num As Integer = editingControlDataGridView.CurrentCell.ColumnIndex + 1
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 2
				If flag2 Then
					editingControlDataGridView.EndEdit()
					num = 5
				End If
				Dim flag3 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 10
				If flag3 Then
					editingControlDataGridView.EndEdit()
					num = 12
				End If
				Dim text As String = If((editingControlDataGridView.Rows(rowIndex).Cells("ProductCode1").Value IsNot Nothing), editingControlDataGridView.Rows(rowIndex).Cells("ProductCode1").Value.ToString(), "")
				Dim text2 As String = If((editingControlDataGridView.Rows(rowIndex).Cells("txtSPrice1").Value IsNot Nothing), editingControlDataGridView.Rows(rowIndex).Cells("txtSPrice1").Value.ToString(), "")
				Dim flag4 As Boolean = editingControlDataGridView.Columns.Contains("txtBarcode1")
				If flag4 Then
					editingControlDataGridView.Rows(rowIndex).Cells("txtBarcode1").Value = text + text2
				Else
					MessageBox.Show("Column 'Barcode Column' not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				Dim flag5 As Boolean = TypeOf editingControlDataGridView.Rows(rowIndex).Cells(num)Is DataGridViewButtonCell
				If flag5 Then
					Dim dataGridViewButtonCell As DataGridViewButtonCell = CType(editingControlDataGridView.Rows(rowIndex).Cells(num), DataGridViewButtonCell)
					Dim flag6 As Boolean = Operators.CompareString(dataGridViewButtonCell.OwningColumn.Name, "InsertButton", False) = 0
					If flag6 Then
						Me.DBoperation(rowIndex, "Insert")
						Me.GelButtonNewRecord_Click(RuntimeHelpers.GetObjectValue(sender), e)
					End If
					Dim flag7 As Boolean = Operators.CompareString(dataGridViewButtonCell.OwningColumn.Name, "BarcodeButton", False) = 0
					If flag7 Then
						Me.DBoperation_print(rowIndex, "Print")
					End If
				Else
					editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(rowIndex).Cells(num)
					Dim flag8 As Boolean = TypeOf editingControlDataGridView.CurrentCell Is DataGridViewTextBoxCell
					If flag8 Then
						editingControlDataGridView.BeginEdit(True)
					End If
				End If
			End If
		End Sub

		' Token: 0x06007F2D RID: 32557 RVA: 0x005E8510 File Offset: 0x005E6710
		Private Sub DataGridView2_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Dim dataGridView As DataGridView = CType(sender, DataGridView)
					e.Handled = True
					Dim flag2 As Boolean = dataGridView.CurrentCell.ColumnIndex < dataGridView.ColumnCount - 1
					If flag2 Then
						Dim flag3 As Boolean = dataGridView.CurrentCell.ColumnIndex = 1
						If flag3 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
						Else
							Dim visible As Boolean = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex).Visible
							If visible Then
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex)
							Else
								dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex)
							End If
						End If
					Else
						Dim flag4 As Boolean = dataGridView.CurrentCell.RowIndex < dataGridView.RowCount - 1
						If flag4 Then
							dataGridView.CurrentCell = dataGridView(dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex + 1)
						End If
					End If
					Dim rowIndex As Integer = Me.DataGridView2.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView2.CurrentCell.ColumnIndex
					Dim flag5 As Boolean = TypeOf dataGridView.CurrentCell Is DataGridViewButtonCell
					If flag5 Then
						Dim name As String = dataGridView.CurrentCell.OwningColumn.Name
						If Operators.CompareString(name, "InsertButton", False) <> 0 Then
							If Operators.CompareString(name, "UpdateButton", False) <> 0 Then
								If Operators.CompareString(name, "DeleteButton", False) <> 0 Then
									If Operators.CompareString(name, "BarcodeButton", False) = 0 Then
										Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
									End If
								Else
									Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
								End If
							Else
								Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
							End If
						Else
							Me.DataGridView2_CellContentClick(Me.DataGridView2, New DataGridViewCellEventArgs(columnIndex, rowIndex))
						End If
					Else
						dataGridView.BeginEdit(True)
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007F2E RID: 32558 RVA: 0x005E877C File Offset: 0x005E697C
		Private Sub DataGridView2_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Try
				Dim flag As Boolean = TypeOf e.Control Is ComboBox
				If flag Then
					Dim comboBox As ComboBox = CType(e.Control, ComboBox)
					comboBox.DropDownStyle = ComboBoxStyle.DropDown
					comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
					comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
				End If
				Dim flag2 As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewComboBoxCell
				If flag2 Then
					Dim dataGridViewComboBoxEditingControl As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
				Else
					Dim flag3 As Boolean = TypeOf Me.DataGridView2.CurrentCell Is DataGridViewTextBoxCell
					If flag3 Then
						Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
						RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
						AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
					End If
				End If
			Catch ex As Exception
			End Try
			Dim flag4 As Boolean = Me.DataGridView2.CurrentCell.ColumnIndex = 46 AndAlso TypeOf e.Control Is TextBox
			If flag4 Then
				Dim textBox As TextBox = CType(e.Control, TextBox)
			End If
		End Sub

		' Token: 0x06007F2F RID: 32559 RVA: 0x005E889C File Offset: 0x005E6A9C
		Public Sub DBoperation_print(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Print", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Try
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(rowNo)
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("txtBarcode1").Value))) = 0
					If flag2 Then
						MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim reportDocument As ReportDocument = New ReportDocument()
						Dim dataTable As DataTable = New DataTable()
						Dim dataTable2 As DataTable = dataTable
						dataTable2.Columns.Add("ProductCode")
						dataTable2.Columns.Add("ProductName")
						dataTable2.Columns.Add("Unit")
						dataTable2.Columns.Add("Tax")
						dataTable2.Columns.Add("SalePrice")
						dataTable2.Columns.Add("Barcode")
						Dim text As String = dataGridViewRow.Cells("ProductCode1").Value.ToString()
						Dim text2 As String = dataGridViewRow.Cells("ProductName1").Value.ToString()
						Dim text3 As String = dataGridViewRow.Cells("cboxUnit1").Value.ToString()
						Dim text4 As String = dataGridViewRow.Cells("cboxTax1").Value.ToString()
						Dim text5 As String = dataGridViewRow.Cells("txtSPrice1").Value.ToString()
						Dim text6 As String = dataGridViewRow.Cells("txtBarcode1").Value.ToString()
						dataTable.Rows.Add(New Object() { text, text2, text3, text4, text5, text6 })
						Dim activeBarcodeType As frmProductEntry.GorillaBarcodePreview = Me.GetActiveBarcodeType()
						Dim flag3 As Boolean = activeBarcodeType IsNot Nothing
						If flag3 Then
							Dim reportDocument2 As ReportDocument = New ReportDocument()
							reportDocument2.Load(Application.StartupPath + "\CryReport\" + activeBarcodeType.PrintPreviewType + ".rpt")
							reportDocument2.SetDataSource(dataTable)
							reportDocument2.SetParameterValue("P1", "ABC")
							reportDocument2.SetParameterValue("Productcode", text)
							reportDocument2.SetParameterValue("ProductName", text2)
							reportDocument2.SetParameterValue("Unit", text3)
							reportDocument2.SetParameterValue("Tax", text4)
							reportDocument2.SetParameterValue("SPrice", text5)
							reportDocument2.SetParameterValue("Barcode", text6)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument2
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					ModCommonClasses.con.Close()
				End Try
			End If
		End Sub

		' Token: 0x06007F30 RID: 32560 RVA: 0x005E8BD8 File Offset: 0x005E6DD8
		Private Sub txtSearchProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.getgriditemdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F31 RID: 32561 RVA: 0x005E8C34 File Offset: 0x005E6E34
		Private Sub getgriditemdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Top ", Me.txtTopResult.Text, " product_id," & vbCrLf & "    product_code," & vbCrLf & "    product_name," & vbCrLf & "    unit," & vbCrLf & "    RTRIM(tax) from tbl_product where product_name like N'", Me.txtSearchProduct.Text, "%' order by product_id desc" }), ModCommonClasses.con)
				Else
					Dim flag2 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "Select Top ", Me.txtTopResult.Text, " product_id," & vbCrLf & "    product_code," & vbCrLf & "    product_name," & vbCrLf & "    unit," & vbCrLf & "    RTRIM(tax) from tbl_product where product_code like N'", Me.txtSearchProduct.Text, "%' order by product_id desc" }), ModCommonClasses.con)
					End If
				End If
				Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView2.Rows.Clear()
				While sqlDataReader.Read()
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(If(Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader(4))), 0, sqlDataReader(4)))
					Me.DataGridView2.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), objectValue })
					Dim dataGridViewComboBoxColumn As DataGridViewComboBoxColumn = CType(Me.DataGridView2.Columns("cboxTax1"), DataGridViewComboBoxColumn)
					Dim flag3 As Boolean = Not dataGridViewComboBoxColumn.Items.Contains(RuntimeHelpers.GetObjectValue(objectValue))
					If flag3 Then
						dataGridViewComboBoxColumn.Items.Add(RuntimeHelpers.GetObjectValue(objectValue))
					End If
				End While
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06007F32 RID: 32562 RVA: 0x0003E7C6 File Offset: 0x0003C9C6
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x06007F33 RID: 32563 RVA: 0x0003E7D0 File Offset: 0x0003C9D0
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.txtSearchProduct.Text = ""
		End Sub

		' Token: 0x06007F34 RID: 32564 RVA: 0x0003E7E4 File Offset: 0x0003C9E4
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "DProduct"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x06007F35 RID: 32565 RVA: 0x005E8E58 File Offset: 0x005E7058
		Private Function GetActiveBarcodeType() As frmProductEntry.GorillaBarcodePreview
			Dim gorillaBarcodePreview As frmProductEntry.GorillaBarcodePreview = Nothing
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select * from GorillaBarcodePreview where is_active = 1", ModCommonClasses.con)
				Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = sqlDataReader.Read()
				If flag Then
					gorillaBarcodePreview = New frmProductEntry.GorillaBarcodePreview()
					Dim gorillaBarcodePreview2 As frmProductEntry.GorillaBarcodePreview = gorillaBarcodePreview
					gorillaBarcodePreview2.BarcodeStyleId = Conversions.ToInteger(sqlDataReader(0))
					gorillaBarcodePreview2.PrintPreviewType = Conversions.ToString(sqlDataReader(1))
					gorillaBarcodePreview2.BarcodeStyleName = Conversions.ToString(sqlDataReader(2))
					gorillaBarcodePreview2.BarcodeStyleImage = Conversions.ToString(sqlDataReader(3))
					gorillaBarcodePreview2.is_active = Conversions.ToShort(sqlDataReader(4))
					gorillaBarcodePreview2.is_remote = Conversions.ToShort(sqlDataReader(5))
				End If
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			Return gorillaBarcodePreview
		End Function

		' Token: 0x06007F36 RID: 32566 RVA: 0x005E8F78 File Offset: 0x005E7178
		Private Sub frmProductEntry_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.F1
				If flag Then
					Me.txtSearchProduct.Text = ""
					Me.Getdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F37 RID: 32567 RVA: 0x005E8FE8 File Offset: 0x005E71E8
		Private Sub btnImportExcel_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog() With { .Filter = "Excel Files|*.xls;*.xlsx", .Title = "Select Excel File" }
				Dim flag As Boolean = openFileDialog.ShowDialog() <> DialogResult.OK
				If Not flag Then
					Dim fileName As String = openFileDialog.FileName
					Dim text As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"
					Dim dataTable As DataTable = New DataTable()
					Using oleDbConnection As OleDbConnection = New OleDbConnection(text)
						oleDbConnection.Open()
						Dim text2 As String = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
						Dim oleDbCommand As OleDbCommand = New OleDbCommand("SELECT * FROM [" + text2 + "]", oleDbConnection)
						Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter(oleDbCommand)
						oleDbDataAdapter.Fill(dataTable)
					End Using
					Dim flag2 As Boolean = dataTable.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("No records found in Excel file.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim text3 As String = ""
						Dim num As Double = 0.0
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Using sqlCommand As SqlCommand = New SqlCommand("SELECT RTRIM(Unit) FROM UnitMaster WHERE IsDefault=@d1", sqlConnection)
								sqlCommand.Parameters.AddWithValue("@d1", "Yes")
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
								Dim flag3 As Boolean = objectValue IsNot Nothing
								If flag3 Then
									text3 = objectValue.ToString()
								End If
							End Using
							Using sqlCommand2 As SqlCommand = New SqlCommand("SELECT RTRIM(Rate) FROM TaxCat WHERE IsDefault=@d1", sqlConnection)
								sqlCommand2.Parameters.AddWithValue("@d1", "Yes")
								Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())
								Dim flag4 As Boolean = objectValue2 IsNot Nothing AndAlso Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(objectValue2))
								If flag4 Then
									num = Convert.ToDouble(RuntimeHelpers.GetObjectValue(objectValue2))
								End If
							End Using
						End Using
						Dim flag5 As Boolean = String.IsNullOrEmpty(text3)
						If flag5 Then
							text3 = "PCS"
						End If
						Dim flag6 As Boolean = num = 0.0
						If flag6 Then
							num = 0.0
						End If
						Dim list As List(Of String) = New List(Of String)()
						Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection2.Open()
							Try
								For Each obj As Object In dataTable.Rows
									Dim dataRow As DataRow = CType(obj, DataRow)
									Dim text4 As String = dataRow("Product_Code").ToString().Trim()
									Dim flag7 As Boolean = String.IsNullOrEmpty(text4)
									If Not flag7 Then
										Using sqlCommand3 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM tbl_product WHERE product_code=@code", sqlConnection2)
											sqlCommand3.Parameters.AddWithValue("@code", text4)
											Dim num2 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand3.ExecuteScalar()))
											Dim flag8 As Boolean = num2 > 0
											If flag8 Then
												list.Add(text4)
											End If
										End Using
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
						End Using
						Dim text5 As String = String.Format("⚙️ Default Unit: {0}{1}", text3, vbCrLf) + String.Format("⚙️ Default Tax: {0}{1}{2}", num, vbCrLf, vbCrLf)
						Dim flag9 As Boolean = list.Count > 0
						If flag9 Then
							text5 = text5 + "⚠️ The following Product Codes already exist and will be skipped:" & vbCrLf + String.Join(", ", list) + vbCrLf & vbCrLf
						End If
						text5 += "Do you want to proceed with import?"
						Dim dialogResult As DialogResult = MessageBox.Show(text5, "Confirm Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
						Dim flag10 As Boolean = dialogResult = DialogResult.No
						If flag10 Then
							MessageBox.Show("Import cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Else
							Dim num3 As Integer = 0
							Dim num4 As Integer = 0
							Using sqlConnection3 As SqlConnection = New SqlConnection(ModCS.cs)
								sqlConnection3.Open()
								Try
									For Each obj2 As Object In dataTable.Rows
										Dim dataRow2 As DataRow = CType(obj2, DataRow)
										Dim text6 As String = dataRow2("Product_Code").ToString().Trim()
										Dim text7 As String = dataRow2("Product_Name").ToString().Trim()
										Dim flag11 As Boolean = String.IsNullOrEmpty(text6) OrElse String.IsNullOrEmpty(text7)
										If Not flag11 Then
											Dim flag12 As Boolean = list.Contains(text6)
											If flag12 Then
												num4 += 1
											Else
												Using sqlCommand4 As SqlCommand = New SqlCommand(vbCrLf & "                    INSERT INTO tbl_product (product_code, product_name, unit, tax, is_deleted)" & vbCrLf & "                    VALUES (@code, @name, @unit, @tax, 0)", sqlConnection3)
													sqlCommand4.Parameters.AddWithValue("@code", text6)
													sqlCommand4.Parameters.AddWithValue("@name", text7)
													sqlCommand4.Parameters.AddWithValue("@unit", text3)
													sqlCommand4.Parameters.AddWithValue("@tax", Convert.ToDecimal(num))
													sqlCommand4.ExecuteNonQuery()
												End Using
												num3 += 1
											End If
										End If
									Next
								Finally
									Dim enumerator2 As IEnumerator
									If TypeOf enumerator2 Is IDisposable Then
										TryCast(enumerator2, IDisposable).Dispose()
									End If
								End Try
							End Using
							MessageBox.Show(String.Concat(New String() { "✅ Import Completed!" & vbCrLf, String.Format("Inserted: {0}", num3), vbCrLf, String.Format("Skipped (duplicates): {0}", num4), vbCrLf, String.Format("Default Unit: {0}", text3), vbCrLf, String.Format("Default Tax: {0}", num) }), "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Getdata()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("❌ Error importing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06007F38 RID: 32568 RVA: 0x0003E818 File Offset: 0x0003CA18
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGoProduct.ShowDialog()
		End Sub

		' Token: 0x06007F39 RID: 32569 RVA: 0x005E96EC File Offset: 0x005E78EC
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim text As String = Path.Combine(Application.StartupPath, "Product_Format_x.xls")
				Dim flag As Boolean = Not File.Exists(text)
				If flag Then
					MessageBox.Show("Source file not found in Debug folder." & vbCrLf + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Using folderBrowserDialog As FolderBrowserDialog = New FolderBrowserDialog()
						Dim flag2 As Boolean = folderBrowserDialog.ShowDialog() = DialogResult.OK
						If flag2 Then
							Dim selectedPath As String = folderBrowserDialog.SelectedPath
							Dim text2 As String = Path.Combine(selectedPath, "Product_Format_x.xls")
							Dim flag3 As Boolean = File.Exists(text2)
							If flag3 Then
								File.Delete(text2)
							End If
							File.Copy(text, text2)
							Dim flag4 As Boolean = File.Exists(text2)
							If flag4 Then
								MessageBox.Show("✅ File successfully saved to:" & vbCrLf + text2, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Else
								MessageBox.Show("❌ File could not be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("Error while copying file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x020001DB RID: 475
		Private Class GorillaBarcodePreview
			' Token: 0x17002EAF RID: 11951
			' (get) Token: 0x06007F3B RID: 32571 RVA: 0x0003E82B File Offset: 0x0003CA2B
			' (set) Token: 0x06007F3C RID: 32572 RVA: 0x0003E835 File Offset: 0x0003CA35
			Public Property BarcodeStyleId As Integer

			' Token: 0x17002EB0 RID: 11952
			' (get) Token: 0x06007F3D RID: 32573 RVA: 0x0003E83E File Offset: 0x0003CA3E
			' (set) Token: 0x06007F3E RID: 32574 RVA: 0x0003E848 File Offset: 0x0003CA48
			Public Property PrintPreviewType As String

			' Token: 0x17002EB1 RID: 11953
			' (get) Token: 0x06007F3F RID: 32575 RVA: 0x0003E851 File Offset: 0x0003CA51
			' (set) Token: 0x06007F40 RID: 32576 RVA: 0x0003E85B File Offset: 0x0003CA5B
			Public Property BarcodeStyleName As String

			' Token: 0x17002EB2 RID: 11954
			' (get) Token: 0x06007F41 RID: 32577 RVA: 0x0003E864 File Offset: 0x0003CA64
			' (set) Token: 0x06007F42 RID: 32578 RVA: 0x0003E86E File Offset: 0x0003CA6E
			Public Property BarcodeStyleImage As String

			' Token: 0x17002EB3 RID: 11955
			' (get) Token: 0x06007F43 RID: 32579 RVA: 0x0003E877 File Offset: 0x0003CA77
			' (set) Token: 0x06007F44 RID: 32580 RVA: 0x0003E881 File Offset: 0x0003CA81
			Public Property is_active As Short

			' Token: 0x17002EB4 RID: 11956
			' (get) Token: 0x06007F45 RID: 32581 RVA: 0x0003E88A File Offset: 0x0003CA8A
			' (set) Token: 0x06007F46 RID: 32582 RVA: 0x0003E894 File Offset: 0x0003CA94
			Public Property is_remote As Short
		End Class
	End Class
End Namespace
