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
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports DevNet
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SautinSoft

Namespace BillPoint
	' Token: 0x02000077 RID: 119
	<DesignerGenerated()>
	Public Partial Class frmBanarCreate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001412 RID: 5138 RVA: 0x000D8C44 File Offset: 0x000D6E44
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

		' Token: 0x17000823 RID: 2083
		' (get) Token: 0x06001415 RID: 5141 RVA: 0x00010CF8 File Offset: 0x0000EEF8
		' (set) Token: 0x06001416 RID: 5142 RVA: 0x000DA798 File Offset: 0x000D8998
		Private _Timer1 As Global.System.Windows.Forms.Timer
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Global.System.Windows.Forms.Timer = Me._Timer1
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

		' Token: 0x17000824 RID: 2084
		' (get) Token: 0x06001417 RID: 5143 RVA: 0x00010D02 File Offset: 0x0000EF02
		' (set) Token: 0x06001418 RID: 5144 RVA: 0x00010D0C File Offset: 0x0000EF0C
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000825 RID: 2085
		' (get) Token: 0x06001419 RID: 5145 RVA: 0x00010D15 File Offset: 0x0000EF15
		' (set) Token: 0x0600141A RID: 5146 RVA: 0x000DA7DC File Offset: 0x000D89DC
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

		' Token: 0x17000826 RID: 2086
		' (get) Token: 0x0600141B RID: 5147 RVA: 0x00010D1F File Offset: 0x0000EF1F
		' (set) Token: 0x0600141C RID: 5148 RVA: 0x000DA820 File Offset: 0x000D8A20
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

		' Token: 0x17000827 RID: 2087
		' (get) Token: 0x0600141D RID: 5149 RVA: 0x00010D29 File Offset: 0x0000EF29
		' (set) Token: 0x0600141E RID: 5150 RVA: 0x000DA864 File Offset: 0x000D8A64
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

		' Token: 0x17000828 RID: 2088
		' (get) Token: 0x0600141F RID: 5151 RVA: 0x00010D33 File Offset: 0x0000EF33
		' (set) Token: 0x06001420 RID: 5152 RVA: 0x00010D3D File Offset: 0x0000EF3D
		Friend Overridable Property Label3 As Label

		' Token: 0x17000829 RID: 2089
		' (get) Token: 0x06001421 RID: 5153 RVA: 0x00010D46 File Offset: 0x0000EF46
		' (set) Token: 0x06001422 RID: 5154 RVA: 0x000DA8A8 File Offset: 0x000D8AA8
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

		' Token: 0x1700082A RID: 2090
		' (get) Token: 0x06001423 RID: 5155 RVA: 0x00010D50 File Offset: 0x0000EF50
		' (set) Token: 0x06001424 RID: 5156 RVA: 0x00010D5A File Offset: 0x0000EF5A
		Friend Overridable Property Label2 As Label

		' Token: 0x1700082B RID: 2091
		' (get) Token: 0x06001425 RID: 5157 RVA: 0x00010D63 File Offset: 0x0000EF63
		' (set) Token: 0x06001426 RID: 5158 RVA: 0x000DA8EC File Offset: 0x000D8AEC
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

		' Token: 0x1700082C RID: 2092
		' (get) Token: 0x06001427 RID: 5159 RVA: 0x00010D6D File Offset: 0x0000EF6D
		' (set) Token: 0x06001428 RID: 5160 RVA: 0x000DA930 File Offset: 0x000D8B30
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

		' Token: 0x1700082D RID: 2093
		' (get) Token: 0x06001429 RID: 5161 RVA: 0x00010D77 File Offset: 0x0000EF77
		' (set) Token: 0x0600142A RID: 5162 RVA: 0x00010D81 File Offset: 0x0000EF81
		Friend Overridable Property Label4 As Label

		' Token: 0x1700082E RID: 2094
		' (get) Token: 0x0600142B RID: 5163 RVA: 0x00010D8A File Offset: 0x0000EF8A
		' (set) Token: 0x0600142C RID: 5164 RVA: 0x00010D94 File Offset: 0x0000EF94
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700082F RID: 2095
		' (get) Token: 0x0600142D RID: 5165 RVA: 0x00010D9D File Offset: 0x0000EF9D
		' (set) Token: 0x0600142E RID: 5166 RVA: 0x00010DA7 File Offset: 0x0000EFA7
		Friend Overridable Property Column7 As DataGridViewCheckBoxColumn

		' Token: 0x17000830 RID: 2096
		' (get) Token: 0x0600142F RID: 5167 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		' (set) Token: 0x06001430 RID: 5168 RVA: 0x00010DBA File Offset: 0x0000EFBA
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17000831 RID: 2097
		' (get) Token: 0x06001431 RID: 5169 RVA: 0x00010DC3 File Offset: 0x0000EFC3
		' (set) Token: 0x06001432 RID: 5170 RVA: 0x00010DCD File Offset: 0x0000EFCD
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17000832 RID: 2098
		' (get) Token: 0x06001433 RID: 5171 RVA: 0x00010DD6 File Offset: 0x0000EFD6
		' (set) Token: 0x06001434 RID: 5172 RVA: 0x00010DE0 File Offset: 0x0000EFE0
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x17000833 RID: 2099
		' (get) Token: 0x06001435 RID: 5173 RVA: 0x00010DE9 File Offset: 0x0000EFE9
		' (set) Token: 0x06001436 RID: 5174 RVA: 0x00010DF3 File Offset: 0x0000EFF3
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x17000834 RID: 2100
		' (get) Token: 0x06001437 RID: 5175 RVA: 0x00010DFC File Offset: 0x0000EFFC
		' (set) Token: 0x06001438 RID: 5176 RVA: 0x000DA974 File Offset: 0x000D8B74
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

		' Token: 0x17000835 RID: 2101
		' (get) Token: 0x06001439 RID: 5177 RVA: 0x00010E06 File Offset: 0x0000F006
		' (set) Token: 0x0600143A RID: 5178 RVA: 0x00010E10 File Offset: 0x0000F010
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000836 RID: 2102
		' (get) Token: 0x0600143B RID: 5179 RVA: 0x00010E19 File Offset: 0x0000F019
		' (set) Token: 0x0600143C RID: 5180 RVA: 0x00010E23 File Offset: 0x0000F023
		Friend Overridable Property Label5 As Label

		' Token: 0x17000837 RID: 2103
		' (get) Token: 0x0600143D RID: 5181 RVA: 0x00010E2C File Offset: 0x0000F02C
		' (set) Token: 0x0600143E RID: 5182 RVA: 0x00010E36 File Offset: 0x0000F036
		Friend Overridable Property ComboBox3 As ComboBox

		' Token: 0x17000838 RID: 2104
		' (get) Token: 0x0600143F RID: 5183 RVA: 0x00010E3F File Offset: 0x0000F03F
		' (set) Token: 0x06001440 RID: 5184 RVA: 0x00010E49 File Offset: 0x0000F049
		Public Overridable Property Picture As PictureBox

		' Token: 0x17000839 RID: 2105
		' (get) Token: 0x06001441 RID: 5185 RVA: 0x00010E52 File Offset: 0x0000F052
		' (set) Token: 0x06001442 RID: 5186 RVA: 0x000DA9B8 File Offset: 0x000D8BB8
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

		' Token: 0x1700083A RID: 2106
		' (get) Token: 0x06001443 RID: 5187 RVA: 0x00010E5C File Offset: 0x0000F05C
		' (set) Token: 0x06001444 RID: 5188 RVA: 0x000DA9FC File Offset: 0x000D8BFC
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

		' Token: 0x1700083B RID: 2107
		' (get) Token: 0x06001445 RID: 5189 RVA: 0x00010E66 File Offset: 0x0000F066
		' (set) Token: 0x06001446 RID: 5190 RVA: 0x000DAA40 File Offset: 0x000D8C40
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

		' Token: 0x1700083C RID: 2108
		' (get) Token: 0x06001447 RID: 5191 RVA: 0x00010E70 File Offset: 0x0000F070
		' (set) Token: 0x06001448 RID: 5192 RVA: 0x000DAA84 File Offset: 0x000D8C84
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

		' Token: 0x1700083D RID: 2109
		' (get) Token: 0x06001449 RID: 5193 RVA: 0x00010E7A File Offset: 0x0000F07A
		' (set) Token: 0x0600144A RID: 5194 RVA: 0x00010E84 File Offset: 0x0000F084
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x1700083E RID: 2110
		' (get) Token: 0x0600144B RID: 5195 RVA: 0x00010E8D File Offset: 0x0000F08D
		' (set) Token: 0x0600144C RID: 5196 RVA: 0x00010E97 File Offset: 0x0000F097
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x1700083F RID: 2111
		' (get) Token: 0x0600144D RID: 5197 RVA: 0x00010EA0 File Offset: 0x0000F0A0
		' (set) Token: 0x0600144E RID: 5198 RVA: 0x00010EAA File Offset: 0x0000F0AA
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17000840 RID: 2112
		' (get) Token: 0x0600144F RID: 5199 RVA: 0x00010EB3 File Offset: 0x0000F0B3
		' (set) Token: 0x06001450 RID: 5200 RVA: 0x00010EBD File Offset: 0x0000F0BD
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17000841 RID: 2113
		' (get) Token: 0x06001451 RID: 5201 RVA: 0x00010EC6 File Offset: 0x0000F0C6
		' (set) Token: 0x06001452 RID: 5202 RVA: 0x00010ED0 File Offset: 0x0000F0D0
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000842 RID: 2114
		' (get) Token: 0x06001453 RID: 5203 RVA: 0x00010ED9 File Offset: 0x0000F0D9
		' (set) Token: 0x06001454 RID: 5204 RVA: 0x00010EE3 File Offset: 0x0000F0E3
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000843 RID: 2115
		' (get) Token: 0x06001455 RID: 5205 RVA: 0x00010EEC File Offset: 0x0000F0EC
		' (set) Token: 0x06001456 RID: 5206 RVA: 0x00010EF6 File Offset: 0x0000F0F6
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17000844 RID: 2116
		' (get) Token: 0x06001457 RID: 5207 RVA: 0x00010EFF File Offset: 0x0000F0FF
		' (set) Token: 0x06001458 RID: 5208 RVA: 0x00010F09 File Offset: 0x0000F109
		Friend Overridable Property Label1 As Label

		' Token: 0x06001459 RID: 5209 RVA: 0x000DAAE4 File Offset: 0x000D8CE4
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

		' Token: 0x0600145A RID: 5210 RVA: 0x000DAC80 File Offset: 0x000D8E80
		Private Sub Datagridview1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 10
			Dim flag2 As Boolean = flag
			If flag2 Then
				MyProject.Forms.frmProductImageUpdator.txtID.Text = Conversions.ToString(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
				MyProject.Forms.frmProductImageUpdator.TextBox1.Text = Me.DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
				MyProject.Forms.frmProductImageUpdator.ShowDialog()
			End If
		End Sub

		' Token: 0x0600145B RID: 5211 RVA: 0x000DAD34 File Offset: 0x000D8F34
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

		' Token: 0x0600145C RID: 5212 RVA: 0x000DAE1C File Offset: 0x000D901C
		Private Sub frmProductImageMaker_Load(sender As Object, e As EventArgs)
			Me.GetCompanyDetails()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.ComboBox3.SelectedIndex = 0
			Me.Convert_Language()
		End Sub

		' Token: 0x0600145D RID: 5213 RVA: 0x000DAEB4 File Offset: 0x000D90B4
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

		' Token: 0x0600145E RID: 5214 RVA: 0x000DB02C File Offset: 0x000D922C
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

		' Token: 0x0600145F RID: 5215 RVA: 0x000DB0E8 File Offset: 0x000D92E8
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

		' Token: 0x06001460 RID: 5216 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06001461 RID: 5217 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06001462 RID: 5218 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06001463 RID: 5219 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x06001464 RID: 5220 RVA: 0x00010F12 File Offset: 0x0000F112
		Private Sub frmProductImageMaker_Closing(sender As Object, e As CancelEventArgs)
			Me.DataGridView1.DataSource = Nothing
		End Sub

		' Token: 0x06001465 RID: 5221 RVA: 0x00010F22 File Offset: 0x0000F122
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06001466 RID: 5222 RVA: 0x000DB1B4 File Offset: 0x000D93B4
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

		' Token: 0x06001467 RID: 5223 RVA: 0x000DB350 File Offset: 0x000D9550
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

		' Token: 0x06001468 RID: 5224 RVA: 0x000DB3E0 File Offset: 0x000D95E0
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

		' Token: 0x06001469 RID: 5225 RVA: 0x000DB9E8 File Offset: 0x000D9BE8
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

		' Token: 0x0600146A RID: 5226 RVA: 0x000DBCBC File Offset: 0x000D9EBC
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

		' Token: 0x0600146B RID: 5227 RVA: 0x000DBD68 File Offset: 0x000D9F68
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

		' Token: 0x0600146C RID: 5228 RVA: 0x00010F3E File Offset: 0x0000F13E
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBulkWhatsappDoc.ShowDialog()
		End Sub

		' Token: 0x0600146D RID: 5229 RVA: 0x00010F51 File Offset: 0x0000F151
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\CryCatalogue.rpt")
		End Sub

		' Token: 0x0600146E RID: 5230 RVA: 0x000DBE78 File Offset: 0x000DA078
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
						Dim text As String = MyProject.Application.Info.DirectoryPath + "\expReports\" + Me.cmpname + "_Catalogue.pdf"
						reportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, text)
						Thread.Sleep(1000)
						Dim pdfFocus As PdfFocus = New PdfFocus()
						pdfFocus.OpenPdf(text)
						Dim flag16 As Boolean = pdfFocus.PageCount > 0
						If flag16 Then
							pdfFocus.ImageOptions.Dpi = 300
							Dim text2 As String = text.Replace(".pdf", ".tiff")
							pdfFocus.ToMultipageTiff(text2)
						End If
						MyProject.Forms.frmReport.ShowDialog()
						MyProject.Forms.frmReport.Dispose()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600146F RID: 5231 RVA: 0x000DC52C File Offset: 0x000DA72C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.CheckBox1.Checked = False
			Me.Getdata1()
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06001470 RID: 5232 RVA: 0x000DC5BC File Offset: 0x000DA7BC
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

		' Token: 0x06001471 RID: 5233 RVA: 0x000DC6DC File Offset: 0x000DA8DC
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
								bmpImage.Save(ms, Global.System.Drawing.Imaging.ImageFormat.Jpeg)
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

		' Token: 0x040006DE RID: 1758
		Private cmpname As String

		' Token: 0x040006DF RID: 1759
		Private cmpaddress As String

		' Token: 0x040006E0 RID: 1760
		Private cmpstate As String

		' Token: 0x040006E1 RID: 1761
		Private cmpcontact As String

		' Token: 0x040006E2 RID: 1762
		Private cmpemail As String

		' Token: 0x040006E3 RID: 1763
		Private cmpgstin As String
	End Class
End Namespace
