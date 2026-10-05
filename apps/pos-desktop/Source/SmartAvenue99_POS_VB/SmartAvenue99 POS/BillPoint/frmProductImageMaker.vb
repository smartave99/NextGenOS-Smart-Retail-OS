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
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports DevNet
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200035C RID: 860
	<DesignerGenerated()>
	Public Partial Class frmProductImageMaker
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CBBC RID: 52156 RVA: 0x007F6F2C File Offset: 0x007F512C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductImageMaker_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductImageMaker_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmProductImageMaker_Closing
			Me.cmpname = ""
			Me.cmpaddress = ""
			Me.cmpstate = ""
			Me.cmpcontact = ""
			Me.cmpemail = ""
			Me.cmpgstin = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005012 RID: 20498
		' (get) Token: 0x0600CBBF RID: 52159 RVA: 0x0005A998 File Offset: 0x00058B98
		' (set) Token: 0x0600CBC0 RID: 52160 RVA: 0x0005A9A2 File Offset: 0x00058BA2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005013 RID: 20499
		' (get) Token: 0x0600CBC1 RID: 52161 RVA: 0x0005A9AB File Offset: 0x00058BAB
		' (set) Token: 0x0600CBC2 RID: 52162 RVA: 0x0005A9B5 File Offset: 0x00058BB5
		Friend Overridable Property Label1 As Label

		' Token: 0x17005014 RID: 20500
		' (get) Token: 0x0600CBC3 RID: 52163 RVA: 0x0005A9BE File Offset: 0x00058BBE
		' (set) Token: 0x0600CBC4 RID: 52164 RVA: 0x007F8C10 File Offset: 0x007F6E10
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005015 RID: 20501
		' (get) Token: 0x0600CBC5 RID: 52165 RVA: 0x0005A9C8 File Offset: 0x00058BC8
		' (set) Token: 0x0600CBC6 RID: 52166 RVA: 0x0005A9D2 File Offset: 0x00058BD2
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17005016 RID: 20502
		' (get) Token: 0x0600CBC7 RID: 52167 RVA: 0x0005A9DB File Offset: 0x00058BDB
		' (set) Token: 0x0600CBC8 RID: 52168 RVA: 0x0005A9E5 File Offset: 0x00058BE5
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005017 RID: 20503
		' (get) Token: 0x0600CBC9 RID: 52169 RVA: 0x0005A9EE File Offset: 0x00058BEE
		' (set) Token: 0x0600CBCA RID: 52170 RVA: 0x007F8C54 File Offset: 0x007F6E54
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

		' Token: 0x17005018 RID: 20504
		' (get) Token: 0x0600CBCB RID: 52171 RVA: 0x0005A9F8 File Offset: 0x00058BF8
		' (set) Token: 0x0600CBCC RID: 52172 RVA: 0x007F8C98 File Offset: 0x007F6E98
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

		' Token: 0x17005019 RID: 20505
		' (get) Token: 0x0600CBCD RID: 52173 RVA: 0x0005AA02 File Offset: 0x00058C02
		' (set) Token: 0x0600CBCE RID: 52174 RVA: 0x0005AA0C File Offset: 0x00058C0C
		Friend Overridable Property Label2 As Label

		' Token: 0x1700501A RID: 20506
		' (get) Token: 0x0600CBCF RID: 52175 RVA: 0x0005AA15 File Offset: 0x00058C15
		' (set) Token: 0x0600CBD0 RID: 52176 RVA: 0x0005AA1F File Offset: 0x00058C1F
		Friend Overridable Property Label3 As Label

		' Token: 0x1700501B RID: 20507
		' (get) Token: 0x0600CBD1 RID: 52177 RVA: 0x0005AA28 File Offset: 0x00058C28
		' (set) Token: 0x0600CBD2 RID: 52178 RVA: 0x007F8CDC File Offset: 0x007F6EDC
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

		' Token: 0x1700501C RID: 20508
		' (get) Token: 0x0600CBD3 RID: 52179 RVA: 0x0005AA32 File Offset: 0x00058C32
		' (set) Token: 0x0600CBD4 RID: 52180 RVA: 0x007F8D20 File Offset: 0x007F6F20
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700501D RID: 20509
		' (get) Token: 0x0600CBD5 RID: 52181 RVA: 0x0005AA3C File Offset: 0x00058C3C
		' (set) Token: 0x0600CBD6 RID: 52182 RVA: 0x0005AA46 File Offset: 0x00058C46
		Friend Overridable Property Label4 As Label

		' Token: 0x1700501E RID: 20510
		' (get) Token: 0x0600CBD7 RID: 52183 RVA: 0x0005AA4F File Offset: 0x00058C4F
		' (set) Token: 0x0600CBD8 RID: 52184 RVA: 0x007F8D64 File Offset: 0x007F6F64
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.Datagridview1_CellContentDoubleClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentDoubleClick, dataGridViewCellEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700501F RID: 20511
		' (get) Token: 0x0600CBD9 RID: 52185 RVA: 0x0005AA59 File Offset: 0x00058C59
		' (set) Token: 0x0600CBDA RID: 52186 RVA: 0x007F8DC4 File Offset: 0x007F6FC4
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005020 RID: 20512
		' (get) Token: 0x0600CBDB RID: 52187 RVA: 0x0005AA63 File Offset: 0x00058C63
		' (set) Token: 0x0600CBDC RID: 52188 RVA: 0x0005AA6D File Offset: 0x00058C6D
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17005021 RID: 20513
		' (get) Token: 0x0600CBDD RID: 52189 RVA: 0x0005AA76 File Offset: 0x00058C76
		' (set) Token: 0x0600CBDE RID: 52190 RVA: 0x0005AA80 File Offset: 0x00058C80
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17005022 RID: 20514
		' (get) Token: 0x0600CBDF RID: 52191 RVA: 0x0005AA89 File Offset: 0x00058C89
		' (set) Token: 0x0600CBE0 RID: 52192 RVA: 0x0005AA93 File Offset: 0x00058C93
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17005023 RID: 20515
		' (get) Token: 0x0600CBE1 RID: 52193 RVA: 0x0005AA9C File Offset: 0x00058C9C
		' (set) Token: 0x0600CBE2 RID: 52194 RVA: 0x0005AAA6 File Offset: 0x00058CA6
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17005024 RID: 20516
		' (get) Token: 0x0600CBE3 RID: 52195 RVA: 0x0005AAAF File Offset: 0x00058CAF
		' (set) Token: 0x0600CBE4 RID: 52196 RVA: 0x0005AAB9 File Offset: 0x00058CB9
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005025 RID: 20517
		' (get) Token: 0x0600CBE5 RID: 52197 RVA: 0x0005AAC2 File Offset: 0x00058CC2
		' (set) Token: 0x0600CBE6 RID: 52198 RVA: 0x0005AACC File Offset: 0x00058CCC
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005026 RID: 20518
		' (get) Token: 0x0600CBE7 RID: 52199 RVA: 0x0005AAD5 File Offset: 0x00058CD5
		' (set) Token: 0x0600CBE8 RID: 52200 RVA: 0x0005AADF File Offset: 0x00058CDF
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17005027 RID: 20519
		' (get) Token: 0x0600CBE9 RID: 52201 RVA: 0x0005AAE8 File Offset: 0x00058CE8
		' (set) Token: 0x0600CBEA RID: 52202 RVA: 0x0005AAF2 File Offset: 0x00058CF2
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17005028 RID: 20520
		' (get) Token: 0x0600CBEB RID: 52203 RVA: 0x0005AAFB File Offset: 0x00058CFB
		' (set) Token: 0x0600CBEC RID: 52204 RVA: 0x0005AB05 File Offset: 0x00058D05
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17005029 RID: 20521
		' (get) Token: 0x0600CBED RID: 52205 RVA: 0x0005AB0E File Offset: 0x00058D0E
		' (set) Token: 0x0600CBEE RID: 52206 RVA: 0x0005AB18 File Offset: 0x00058D18
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x1700502A RID: 20522
		' (get) Token: 0x0600CBEF RID: 52207 RVA: 0x0005AB21 File Offset: 0x00058D21
		' (set) Token: 0x0600CBF0 RID: 52208 RVA: 0x0005AB2B File Offset: 0x00058D2B
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x1700502B RID: 20523
		' (get) Token: 0x0600CBF1 RID: 52209 RVA: 0x0005AB34 File Offset: 0x00058D34
		' (set) Token: 0x0600CBF2 RID: 52210 RVA: 0x0005AB3E File Offset: 0x00058D3E
		Friend Overridable Property Column7 As DataGridViewCheckBoxColumn

		' Token: 0x1700502C RID: 20524
		' (get) Token: 0x0600CBF3 RID: 52211 RVA: 0x0005AB47 File Offset: 0x00058D47
		' (set) Token: 0x0600CBF4 RID: 52212 RVA: 0x007F8E08 File Offset: 0x007F7008
		Private _Button10 As GelButton
		Friend Overridable Property Button10 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._Button10
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button10 = value
				gelButton = Me._Button10
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700502D RID: 20525
		' (get) Token: 0x0600CBF5 RID: 52213 RVA: 0x0005AB51 File Offset: 0x00058D51
		' (set) Token: 0x0600CBF6 RID: 52214 RVA: 0x007F8E4C File Offset: 0x007F704C
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700502E RID: 20526
		' (get) Token: 0x0600CBF7 RID: 52215 RVA: 0x0005AB5B File Offset: 0x00058D5B
		' (set) Token: 0x0600CBF8 RID: 52216 RVA: 0x007F8E90 File Offset: 0x007F7090
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700502F RID: 20527
		' (get) Token: 0x0600CBF9 RID: 52217 RVA: 0x0005AB65 File Offset: 0x00058D65
		' (set) Token: 0x0600CBFA RID: 52218 RVA: 0x007F8ED4 File Offset: 0x007F70D4
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005030 RID: 20528
		' (get) Token: 0x0600CBFB RID: 52219 RVA: 0x0005AB6F File Offset: 0x00058D6F
		' (set) Token: 0x0600CBFC RID: 52220 RVA: 0x007F8F18 File Offset: 0x007F7118
		Private _btnBulkImageUpdate As GelButton
		Friend Overridable Property btnBulkImageUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnBulkImageUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnBulkImageUpdate_Click
				Dim gelButton As GelButton = Me._btnBulkImageUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnBulkImageUpdate = value
				gelButton = Me._btnBulkImageUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005031 RID: 20529
		' (get) Token: 0x0600CBFD RID: 52221 RVA: 0x0005AB79 File Offset: 0x00058D79
		' (set) Token: 0x0600CBFE RID: 52222 RVA: 0x0005AB83 File Offset: 0x00058D83
		Public Overridable Property Picture As PictureBox

		' Token: 0x17005032 RID: 20530
		' (get) Token: 0x0600CBFF RID: 52223 RVA: 0x0005AB8C File Offset: 0x00058D8C
		' (set) Token: 0x0600CC00 RID: 52224 RVA: 0x0005AB96 File Offset: 0x00058D96
		Friend Overridable Property ComboBox3 As ComboBox

		' Token: 0x17005033 RID: 20531
		' (get) Token: 0x0600CC01 RID: 52225 RVA: 0x0005AB9F File Offset: 0x00058D9F
		' (set) Token: 0x0600CC02 RID: 52226 RVA: 0x0005ABA9 File Offset: 0x00058DA9
		Friend Overridable Property Label5 As Label

		' Token: 0x17005034 RID: 20532
		' (get) Token: 0x0600CC03 RID: 52227 RVA: 0x0005ABB2 File Offset: 0x00058DB2
		' (set) Token: 0x0600CC04 RID: 52228 RVA: 0x007F8F5C File Offset: 0x007F715C
		Private _GelButton11 As GelButton
		Friend Overridable Property GelButton11 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton11_Click
				Dim gelButton As GelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton11 = value
				gelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600CC05 RID: 52229 RVA: 0x007F8FA0 File Offset: 0x007F71A0
		Public Sub Getdata1()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID order by PID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CC06 RID: 52230 RVA: 0x007F913C File Offset: 0x007F733C
		Private Sub Datagridview1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 10
			Dim flag2 As Boolean = flag
			If flag2 Then
				MyProject.Forms.frmProductImageUpdator.txtID.Text = Conversions.ToString(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
				MyProject.Forms.frmProductImageUpdator.TextBox1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
				MyProject.Forms.frmProductImageUpdator.ShowDialog()
			End If
		End Sub

		' Token: 0x0600CC07 RID: 52231 RVA: 0x007F91F0 File Offset: 0x007F73F0
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

		' Token: 0x0600CC08 RID: 52232 RVA: 0x007F92D8 File Offset: 0x007F74D8
		Private Sub frmProductImageMaker_Load(sender As Object, e As EventArgs)
			Me.GetCompanyDetails()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.ComboBox3.SelectedIndex = 0
			Me.Convert_Language()
			Me.GetStyleDetails()
		End Sub

		' Token: 0x0600CC09 RID: 52233 RVA: 0x007F9374 File Offset: 0x007F7574
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

		' Token: 0x0600CC0A RID: 52234 RVA: 0x007F94EC File Offset: 0x007F76EC
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

		' Token: 0x0600CC0B RID: 52235 RVA: 0x007F95A8 File Offset: 0x007F77A8
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

		' Token: 0x0600CC0C RID: 52236 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CC0D RID: 52237 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CC0E RID: 52238 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CC0F RID: 52239 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmProductImageMaker_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CC10 RID: 52240 RVA: 0x0005ABBC File Offset: 0x00058DBC
		Private Sub frmProductImageMaker_Closing(sender As Object, e As CancelEventArgs)
			Me.DataGridView1.DataSource = Nothing
		End Sub

		' Token: 0x0600CC11 RID: 52241 RVA: 0x0005ABCC File Offset: 0x00058DCC
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CC12 RID: 52242 RVA: 0x007F9674 File Offset: 0x007F7874
		Public Sub GetCompanyDetails()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(EmailID),RTRIM(GSTIN),Logo from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmpname = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.cmpaddress = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.cmpstate = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.cmpcontact = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.cmpemail = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmpgstin = ModCommonClasses.rdr.GetValue(5).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr(6), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Dim image As Image = Image.FromStream(memoryStream)
					Me.PictureBox1.Image = image
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

		' Token: 0x0600CC13 RID: 52243 RVA: 0x007F9810 File Offset: 0x007F7A10
		Public Sub GetStyleDetails()
			Try
				Dim text As String = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select BillStyleName from CatalogStyle where isdisplay=1"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					text = ModCommonClasses.rdr.GetValue(0).ToString()
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag4 Then
					Me.ComboBox3.SelectedItem = text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CC14 RID: 52244 RVA: 0x007F9924 File Offset: 0x007F7B24
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
			If flag Then
				Me.TextBox1.Focus()
			Else
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag2 Then
					Me.TextBox1.Focus()
				Else
					Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
					If flag3 Then
						Me.TextBox1.Focus()
					Else
						Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
						If flag4 Then
							Me.TextBox1.Focus()
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600CC15 RID: 52245 RVA: 0x007F99B4 File Offset: 0x007F7BB4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag2 Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Productname like N'" + Me.TextBox1.Text + "%' order by PID", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView1.ClearSelection()
				End If
				Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag3 Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.Barcode like N'" + Me.TextBox1.Text + "%' order by PID", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView1.ClearSelection()
				End If
				Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
				If flag4 Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and CategoryName like N'" + Me.TextBox1.Text + "%' order by PID", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView1.ClearSelection()
				End If
				Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
				If flag5 Then
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and SubCategoryName like N'" + Me.TextBox1.Text + "%' order by PID", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
					End While
					ModCommonClasses.con.Close()
					Me.DataGridView1.ClearSelection()
				End If
			End If
		End Sub

		' Token: 0x0600CC16 RID: 52246 RVA: 0x007F9FBC File Offset: 0x007F81BC
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox2.SelectedIndex = 0
			If flag Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Status='Yes' order by PID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			End If
			Dim flag2 As Boolean = Me.ComboBox2.SelectedIndex = 1
			If flag2 Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock.Barcode),RTRIM(CategoryName),RTRIM(SubCategoryName),(Product.MRP),(SellingPrice),(Discount),RTRIM(Status),Photo from Temp_Stock,Product,Product_Join,Category,SubCategory where Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Status='No' order by PID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
			End If
		End Sub

		' Token: 0x0600CC17 RID: 52247 RVA: 0x007FA290 File Offset: 0x007F8490
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.Getdata1()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600CC18 RID: 52248 RVA: 0x007FA33C File Offset: 0x007F853C
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(11).Value = True
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(11).Value = False
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600CC19 RID: 52249 RVA: 0x00010F3E File Offset: 0x0000F13E
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x0600CC1A RID: 52250 RVA: 0x00010F51 File Offset: 0x0000F151
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\CryCatalogue.rpt")
		End Sub

		' Token: 0x0600CC1B RID: 52251 RVA: 0x007FA44C File Offset: 0x007F864C
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim num As Integer = 0
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(11).Value IsNot Nothing, Operators.CompareObjectEqual(dataGridViewRow.Cells(11).Value, True, False)))
						If flag2 Then
							num += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = num <= 0
				If flag3 Then
					MessageBox.Show("Please select item list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Try
						Dim dataTable As DataTable = New DataTable()
						Dim dataTable2 As DataTable = dataTable
						dataTable2.Columns.Add("PID")
						dataTable2.Columns.Add("ProductCode")
						dataTable2.Columns.Add("ProductName")
						dataTable2.Columns.Add("Barcode")
						dataTable2.Columns.Add("MRP")
						dataTable2.Columns.Add("RSalePrice")
						dataTable2.Columns.Add("Discount")
						dataTable2.Columns.Add("Status")
						dataTable2.Columns.Add("Photo", Type.[GetType]("System.Byte[]"))
						Try
							For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim flag4 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value))
								Dim flag5 As Boolean = flag4
								If flag5 Then
									dataTable.Rows.Add(New Object() { dataGridViewRow2.Cells(0).Value, dataGridViewRow2.Cells(1).Value, dataGridViewRow2.Cells(2).Value, dataGridViewRow2.Cells(3).Value, dataGridViewRow2.Cells(6).Value, dataGridViewRow2.Cells(7).Value, dataGridViewRow2.Cells(8).Value, dataGridViewRow2.Cells(9).Value, dataGridViewRow2.Cells(10).Value })
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
						Dim reportDocument As ReportDocument = New ReportDocument()
						Dim flag6 As Boolean = Me.ComboBox3.SelectedIndex = 0
						If flag6 Then
							reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue1.rpt")
						Else
							Dim flag7 As Boolean = Me.ComboBox3.SelectedIndex = 1
							If flag7 Then
								reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue2.rpt")
							Else
								Dim flag8 As Boolean = Me.ComboBox3.SelectedIndex = 2
								If flag8 Then
									reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue3.rpt")
								Else
									Dim flag9 As Boolean = Me.ComboBox3.SelectedIndex = 3
									If flag9 Then
										reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue4.rpt")
									Else
										Dim flag10 As Boolean = Me.ComboBox3.SelectedIndex = 4
										If flag10 Then
											reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue5.rpt")
										Else
											Dim flag11 As Boolean = Me.ComboBox3.SelectedIndex = 5
											If flag11 Then
												reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue6.rpt")
											Else
												Dim flag12 As Boolean = Me.ComboBox3.SelectedIndex = 6
												If flag12 Then
													reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue7.rpt")
												Else
													Dim flag13 As Boolean = Me.ComboBox3.SelectedIndex = 7
													If flag13 Then
														reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue8.rpt")
													Else
														Dim flag14 As Boolean = Me.ComboBox3.SelectedIndex = 8
														If flag14 Then
															reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue9.rpt")
														Else
															Dim flag15 As Boolean = Me.ComboBox3.SelectedIndex = 9
															If flag15 Then
																reportDocument.Load(Application.StartupPath + "\CryReport\CryCatalogue10.rpt")
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
						reportDocument.SetDataSource(dataTable)
						reportDocument.SetParameterValue("P1", Me.cmpname)
						reportDocument.SetParameterValue("P2", Me.cmpaddress)
						reportDocument.SetParameterValue("P3", Me.cmpstate)
						reportDocument.SetParameterValue("P4", Me.cmpcontact)
						reportDocument.SetParameterValue("P5", Me.cmpemail)
						reportDocument.SetParameterValue("P6", Me.cmpgstin)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600CC1C RID: 52252 RVA: 0x007FAA70 File Offset: 0x007F8C70
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.CheckBox1.Checked = False
			Me.Getdata1()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600CC1D RID: 52253 RVA: 0x007FAB00 File Offset: 0x007F8D00
		Private Sub btnBulkImageUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim num As Integer = 0
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(11).Value IsNot Nothing, Operators.CompareObjectEqual(dataGridViewRow.Cells(11).Value, True, False)))
						If flag2 Then
							num += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = num <= 0
				If flag3 Then
					MessageBox.Show("Please select item list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getImage()
				End If
			End If
		End Sub

		' Token: 0x0600CC1E RID: 52254 RVA: 0x007FAC20 File Offset: 0x007F8E20
		Public Async Sub getImage()
			Try
				Dim flag As Boolean = ModFunc.CheckForInternetConnection()
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim isSelected As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(row.Cells(11).Value))
							Dim flag2 As Boolean = isSelected
							If flag2 Then
								Dim result As List(Of WebImage) = Await QImage.Query(row.Cells(2).Value.ToString(), 1)
								Me.Picture.Image = result(0).Image
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim cb As String = "delete from Product_Join where ProductID=@d1"
								ModCommonClasses.cmd = New SqlCommand(cb)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(row.Cells(0).Value.ToString()))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim ck As String = "insert into Product_Join(ProductID,Photo) VALUES (" + row.Cells(0).Value.ToString() + ",@d2)"
								ModCommonClasses.cmd = New SqlCommand(ck)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Prepare()
								Dim ms As MemoryStream = New MemoryStream()
								Dim img As Image = Me.Picture.Image
								Dim bmpImage As Bitmap = New Bitmap(img)
								bmpImage.Save(ms, ImageFormat.Jpeg)
								Dim data As Byte() = ms.GetBuffer()
								Dim p As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
								p.Value = data
								ModCommonClasses.cmd.Parameters.Add(p)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.cmd.Parameters.Clear()
								row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#C9E639")
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.Rows.Clear()
					Me.Getdata1()
					Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Else
					MessageBox.Show("Internet Connction not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x0600CC1F RID: 52255 RVA: 0x0005ABE8 File Offset: 0x00058DE8
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCatlogStyle.Show()
		End Sub

		' Token: 0x040051CB RID: 20939
		Private cmpname As String

		' Token: 0x040051CC RID: 20940
		Private cmpaddress As String

		' Token: 0x040051CD RID: 20941
		Private cmpstate As String

		' Token: 0x040051CE RID: 20942
		Private cmpcontact As String

		' Token: 0x040051CF RID: 20943
		Private cmpemail As String

		' Token: 0x040051D0 RID: 20944
		Private cmpgstin As String
	End Class
End Namespace
