Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200020F RID: 527
	<DesignerGenerated()>
	Public Partial Class frmTouchProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060098CC RID: 39116 RVA: 0x006DA87C File Offset: 0x006D8A7C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTouchProduct_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTouchProduct_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmTouchProduct_Closed
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038C3 RID: 14531
		' (get) Token: 0x060098CF RID: 39119 RVA: 0x0004AA95 File Offset: 0x00048C95
		' (set) Token: 0x060098D0 RID: 39120 RVA: 0x0004AA9F File Offset: 0x00048C9F
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x170038C4 RID: 14532
		' (get) Token: 0x060098D1 RID: 39121 RVA: 0x0004AAA8 File Offset: 0x00048CA8
		' (set) Token: 0x060098D2 RID: 39122 RVA: 0x0004AAB2 File Offset: 0x00048CB2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170038C5 RID: 14533
		' (get) Token: 0x060098D3 RID: 39123 RVA: 0x0004AABB File Offset: 0x00048CBB
		' (set) Token: 0x060098D4 RID: 39124 RVA: 0x006DB82C File Offset: 0x006D9A2C
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

		' Token: 0x170038C6 RID: 14534
		' (get) Token: 0x060098D5 RID: 39125 RVA: 0x0004AAC5 File Offset: 0x00048CC5
		' (set) Token: 0x060098D6 RID: 39126 RVA: 0x006DB870 File Offset: 0x006D9A70
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170038C7 RID: 14535
		' (get) Token: 0x060098D7 RID: 39127 RVA: 0x0004AACF File Offset: 0x00048CCF
		' (set) Token: 0x060098D8 RID: 39128 RVA: 0x0004AAD9 File Offset: 0x00048CD9
		Friend Overridable Property Label2 As Label

		' Token: 0x170038C8 RID: 14536
		' (get) Token: 0x060098D9 RID: 39129 RVA: 0x0004AAE2 File Offset: 0x00048CE2
		' (set) Token: 0x060098DA RID: 39130 RVA: 0x0004AAEC File Offset: 0x00048CEC
		Friend Overridable Property Label1 As Label

		' Token: 0x170038C9 RID: 14537
		' (get) Token: 0x060098DB RID: 39131 RVA: 0x0004AAF5 File Offset: 0x00048CF5
		' (set) Token: 0x060098DC RID: 39132 RVA: 0x006DB8B4 File Offset: 0x006D9AB4
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

		' Token: 0x170038CA RID: 14538
		' (get) Token: 0x060098DD RID: 39133 RVA: 0x0004AAFF File Offset: 0x00048CFF
		' (set) Token: 0x060098DE RID: 39134 RVA: 0x006DB8F8 File Offset: 0x006D9AF8
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click_1
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

		' Token: 0x170038CB RID: 14539
		' (get) Token: 0x060098DF RID: 39135 RVA: 0x0004AB09 File Offset: 0x00048D09
		' (set) Token: 0x060098E0 RID: 39136 RVA: 0x0004AB13 File Offset: 0x00048D13
		Friend Overridable Property Label3 As Label

		' Token: 0x170038CC RID: 14540
		' (get) Token: 0x060098E1 RID: 39137 RVA: 0x0004AB1C File Offset: 0x00048D1C
		' (set) Token: 0x060098E2 RID: 39138 RVA: 0x0004AB26 File Offset: 0x00048D26
		Friend Overridable Property Label4 As Label

		' Token: 0x170038CD RID: 14541
		' (get) Token: 0x060098E3 RID: 39139 RVA: 0x0004AB2F File Offset: 0x00048D2F
		' (set) Token: 0x060098E4 RID: 39140 RVA: 0x006DB93C File Offset: 0x006D9B3C
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170038CE RID: 14542
		' (get) Token: 0x060098E5 RID: 39141 RVA: 0x0004AB39 File Offset: 0x00048D39
		' (set) Token: 0x060098E6 RID: 39142 RVA: 0x0004AB43 File Offset: 0x00048D43
		Friend Overridable Property Label5 As Label

		' Token: 0x170038CF RID: 14543
		' (get) Token: 0x060098E7 RID: 39143 RVA: 0x0004AB4C File Offset: 0x00048D4C
		' (set) Token: 0x060098E8 RID: 39144 RVA: 0x006DB980 File Offset: 0x006D9B80
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

		' Token: 0x170038D0 RID: 14544
		' (get) Token: 0x060098E9 RID: 39145 RVA: 0x0004AB56 File Offset: 0x00048D56
		' (set) Token: 0x060098EA RID: 39146 RVA: 0x0004AB60 File Offset: 0x00048D60
		Friend Overridable Property NumericUpDown1 As NumericUpDown

		' Token: 0x170038D1 RID: 14545
		' (get) Token: 0x060098EB RID: 39147 RVA: 0x0004AB69 File Offset: 0x00048D69
		' (set) Token: 0x060098EC RID: 39148 RVA: 0x0004AB73 File Offset: 0x00048D73
		Friend Overridable Property Label6 As Label

		' Token: 0x170038D2 RID: 14546
		' (get) Token: 0x060098ED RID: 39149 RVA: 0x0004AB7C File Offset: 0x00048D7C
		' (set) Token: 0x060098EE RID: 39150 RVA: 0x0004AB86 File Offset: 0x00048D86
		Friend Overridable Property Label7 As Label

		' Token: 0x170038D3 RID: 14547
		' (get) Token: 0x060098EF RID: 39151 RVA: 0x0004AB8F File Offset: 0x00048D8F
		' (set) Token: 0x060098F0 RID: 39152 RVA: 0x0004AB99 File Offset: 0x00048D99
		Friend Overridable Property Label8 As Label

		' Token: 0x170038D4 RID: 14548
		' (get) Token: 0x060098F1 RID: 39153 RVA: 0x0004ABA2 File Offset: 0x00048DA2
		' (set) Token: 0x060098F2 RID: 39154 RVA: 0x0004ABAC File Offset: 0x00048DAC
		Friend Overridable Property Label9 As Label

		' Token: 0x170038D5 RID: 14549
		' (get) Token: 0x060098F3 RID: 39155 RVA: 0x0004ABB5 File Offset: 0x00048DB5
		' (set) Token: 0x060098F4 RID: 39156 RVA: 0x006DB9C4 File Offset: 0x006D9BC4
		Private _cmbComboPack As ComboBox
		Friend Overridable Property cmbComboPack As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbComboPack
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbComboPack_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbComboPack
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbComboPack = value
				comboBox = Me._cmbComboPack
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060098F5 RID: 39157
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060098F6 RID: 39158
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x060098F7 RID: 39159 RVA: 0x006DBA08 File Offset: 0x006D9C08
		Private Sub frmTouchProduct_Load(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.Label3.Text = ""
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = True
			Me.FillCustomerCardStatus2()
			Me.fillCategory()
			Me.fillGategoryName()
		End Sub

		' Token: 0x060098F8 RID: 39160 RVA: 0x006DBA78 File Offset: 0x006D9C78
		Public Sub fillCategory()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060098F9 RID: 39161 RVA: 0x0033E988 File Offset: 0x0033CB88
		Public Shared Function Resize(img As Image, width As Integer, height As Integer) As Object
			Dim bitmap As Bitmap = New Bitmap(width, height)
			Using graphics As Graphics = Graphics.FromImage(bitmap)
				graphics.SmoothingMode = SmoothingMode.HighQuality
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality
				graphics.DrawImage(img, New Rectangle(0, 0, width, height))
			End Using
			Return bitmap
		End Function

		' Token: 0x060098FA RID: 39162 RVA: 0x006DBBAC File Offset: 0x006D9DAC
		Public Sub FillCustomerCardStatus2()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.Label8.Text, "Retailer", False) = 0
				If flag Then
					Dim text As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.SPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.Label8.Text, "Wholesaler", False) = 0
				If flag2 Then
					Dim text2 As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.WPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(5), Byte())
					Dim image As Image
					Using memoryStream As MemoryStream = New MemoryStream(array)
						Try
							image = Image.FromStream(memoryStream)
						Catch ex As Exception
							image = Nothing
						End Try
					End Using
					Dim button As Button = New Button()
					button.Image = CType(frmTouchProduct.Resize(image, 130, 90), Image)
					button.ImageAlign = ContentAlignment.TopCenter
					button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Part No : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Price : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Qty : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.TextAlign = ContentAlignment.BottomLeft
					Dim forestGreen As Color = Color.ForestGreen
					Dim orangeRed As Color = Color.OrangeRed
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					Dim flag3 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) > 0.0
					If flag3 Then
						button.BackgroundImage = Resources.GreenL
						button.BackgroundImageLayout = ImageLayout.Stretch
					Else
						Dim flag4 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) <= 0.0
						If flag4 Then
							button.BackgroundImage = Resources.RedL
							button.BackgroundImageLayout = ImageLayout.Stretch
						Else
							button.BackgroundImage = Resources.BlueL
							button.BackgroundImageLayout = ImageLayout.Stretch
						End If
					End If
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 150
					button.Height = 190
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060098FB RID: 39163 RVA: 0x006DC0A8 File Offset: 0x006DA2A8
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.Label3.Text = ""
			Dim flag As Boolean = Operators.CompareString(Me.Label4.Text, "POINT OF SALE", False) = 0
			If flag Then
				Try
					Dim button As Button = CType(sender, Button)
					Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(button.Tag))
					MyProject.Forms.frmPOS.txtBarcode.Text = text.Split(New Char() { ","c })(1).ToString()
					MyProject.Forms.frmUnitButton.lblBarcode.Text = text.Split(New Char() { ","c })(1).ToString()
					MyProject.Forms.frmUnitButton.Label6.Text = "POINT OF SALE"
					MyProject.Forms.frmUnitButton.txtDefQty.Focus()
					MyProject.Forms.frmUnitButton.txtDefQty.ScrollToCaret()
					MyProject.Forms.frmUnitButton.ShowDialog()
					MyProject.Forms.frmUnitButton.Dispose()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label4.Text, "POINT OF SALE TOUCH", False) = 0
			If flag2 Then
				Try
					Dim button2 As Button = CType(sender, Button)
					Dim text2 As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(button2.Tag))
					MyProject.Forms.frmPOSTouch.txtBarcode.Text = text2.Split(New Char() { ","c })(1).ToString()
					MyProject.Forms.frmUnitButton.lblBarcode.Text = text2.Split(New Char() { ","c })(1).ToString()
					MyProject.Forms.frmUnitButton.Label6.Text = "POINT OF SALE TOUCH"
					MyProject.Forms.frmUnitButton.txtDefQty.Focus()
					MyProject.Forms.frmUnitButton.txtDefQty.ScrollToCaret()
					MyProject.Forms.frmUnitButton.ShowDialog()
					MyProject.Forms.frmUnitButton.Dispose()
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060098FC RID: 39164 RVA: 0x006DC32C File Offset: 0x006DA52C
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.cmbCategory.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.Label3.Text = ""
		End Sub

		' Token: 0x060098FD RID: 39165 RVA: 0x006DC37C File Offset: 0x006DA57C
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmTouchProduct.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmTouchProduct.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x060098FE RID: 39166 RVA: 0x006DC3C4 File Offset: 0x006DA5C4
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbComboPack.Text = ""
				Me.TextBox1.Text = ""
				Me.TextBox2.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.Label8.Text, "Retailer", False) = 0
				If flag Then
					Dim text As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.SPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and Category=@d1 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.Label8.Text, "Wholesaler", False) = 0
				If flag2 Then
					Dim text2 As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.WPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and Category=@d1 order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(5), Byte())
					Dim image As Image
					Using memoryStream As MemoryStream = New MemoryStream(array)
						Try
							image = Image.FromStream(memoryStream)
						Catch ex As Exception
							image = Nothing
						End Try
					End Using
					Dim button As Button = New Button()
					button.Image = CType(frmTouchProduct.Resize(image, 130, 90), Image)
					button.ImageAlign = ContentAlignment.TopCenter
					button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Part No : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Price : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Qty : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.TextAlign = ContentAlignment.BottomLeft
					Dim forestGreen As Color = Color.ForestGreen
					Dim orangeRed As Color = Color.OrangeRed
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					Dim flag3 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) > 0.0
					If flag3 Then
						button.BackgroundImage = Resources.GreenL
						button.BackgroundImageLayout = ImageLayout.Stretch
					Else
						Dim flag4 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) <= 0.0
						If flag4 Then
							button.BackgroundImage = Resources.RedL
							button.BackgroundImageLayout = ImageLayout.Stretch
						Else
							button.BackgroundImage = Resources.BlueL
							button.BackgroundImageLayout = ImageLayout.Stretch
						End If
					End If
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 150
					button.Height = 190
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060098FF RID: 39167 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTouchProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009900 RID: 39168 RVA: 0x006DC93C File Offset: 0x006DAB3C
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.FillCustomerCardStatus2()
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Me.FlowLayoutPanel1.Controls.Clear()
				End If
			End If
		End Sub

		' Token: 0x06009901 RID: 39169 RVA: 0x006DC988 File Offset: 0x006DAB88
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Operators.CompareString(Me.Label8.Text, "Retailer", False) = 0
					If flag2 Then
						Dim text As String = String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.SPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and ProductName like N'", Me.TextBox1.Text, "%' order by ProductName" })
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.Label8.Text, "Wholesaler", False) = 0
					If flag3 Then
						Dim text2 As String = String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.WPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and ProductName like N'", Me.TextBox1.Text, "%' order by ProductName" })
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Me.FlowLayoutPanel1.Controls.Clear()
					While ModCommonClasses.rdr.Read()
						Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(5), Byte())
						Dim image As Image
						Using memoryStream As MemoryStream = New MemoryStream(array)
							Try
								image = Image.FromStream(memoryStream)
							Catch ex As Exception
								image = Nothing
							End Try
						End Using
						Dim button As Button = New Button()
						button.Image = CType(frmTouchProduct.Resize(image, 130, 90), Image)
						button.ImageAlign = ContentAlignment.TopCenter
						button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Part No : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Price : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Qty : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
						button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
						button.TextAlign = ContentAlignment.BottomLeft
						Dim forestGreen As Color = Color.ForestGreen
						Dim orangeRed As Color = Color.OrangeRed
						Dim deepSkyBlue As Color = Color.DeepSkyBlue
						Dim flag4 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) > 0.0
						If flag4 Then
							button.BackgroundImage = Resources.GreenL
							button.BackgroundImageLayout = ImageLayout.Stretch
						Else
							Dim flag5 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) <= 0.0
							If flag5 Then
								button.BackgroundImage = Resources.RedL
								button.BackgroundImageLayout = ImageLayout.Stretch
							Else
								button.BackgroundImage = Resources.BlueL
								button.BackgroundImageLayout = ImageLayout.Stretch
							End If
						End If
						button.ForeColor = Color.White
						button.FlatStyle = FlatStyle.Popup
						button.Cursor = Cursors.Hand
						button.Width = 150
						button.Height = 190
						button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
						Me.UserButtons.Add(button)
						Me.FlowLayoutPanel1.Controls.Add(button)
						AddHandler button.Click, AddressOf Me.Button2_Click
					End While
					ModCommonClasses.con.Close()
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06009902 RID: 39170 RVA: 0x006DCEE4 File Offset: 0x006DB0E4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Operators.CompareString(Me.Label8.Text, "Retailer", False) = 0
					If flag2 Then
						Dim text As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.SPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and Temp_Stock.Barcode=@d1 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text.ToString())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.Label8.Text, "Wholesaler", False) = 0
					If flag3 Then
						Dim text2 As String = "SELECT TOP " + Conversions.ToString(Me.NumericUpDown1.Value) + " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.WPrice),(Qty),Product_Join.Photo from Temp_Stock,Product,SubCategory,Product_Join where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.PID=Product_Join.ProductID and Product.Status='Yes' and Temp_Stock.Barcode=@d1 order by ProductName"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text.ToString())
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Me.FlowLayoutPanel1.Controls.Clear()
					While ModCommonClasses.rdr.Read()
						Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(5), Byte())
						Dim image As Image
						Using memoryStream As MemoryStream = New MemoryStream(array)
							Try
								image = Image.FromStream(memoryStream)
							Catch ex As Exception
								image = Nothing
							End Try
						End Using
						Dim button As Button = New Button()
						button.Image = CType(frmTouchProduct.Resize(image, 130, 90), Image)
						button.ImageAlign = ContentAlignment.TopCenter
						button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Part No : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Price : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Qty : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
						button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
						button.TextAlign = ContentAlignment.BottomLeft
						Dim forestGreen As Color = Color.ForestGreen
						Dim orangeRed As Color = Color.OrangeRed
						Dim deepSkyBlue As Color = Color.DeepSkyBlue
						Dim flag4 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) > 0.0
						If flag4 Then
							button.BackgroundImage = Resources.GreenL
							button.BackgroundImageLayout = ImageLayout.Stretch
						Else
							Dim flag5 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) <= 0.0
							If flag5 Then
								button.BackgroundImage = Resources.RedL
								button.BackgroundImageLayout = ImageLayout.Stretch
							Else
								button.BackgroundImage = Resources.BlueL
								button.BackgroundImageLayout = ImageLayout.Stretch
							End If
						End If
						button.ForeColor = Color.White
						button.FlatStyle = FlatStyle.Popup
						button.Cursor = Cursors.Hand
						button.Width = 150
						button.Height = 190
						button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
						Me.UserButtons.Add(button)
						Me.FlowLayoutPanel1.Controls.Add(button)
						AddHandler button.Click, AddressOf Me.Button2_Click
					End While
					ModCommonClasses.con.Close()
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06009903 RID: 39171 RVA: 0x0004ABBF File Offset: 0x00048DBF
		Private Sub frmTouchProduct_Closed(sender As Object, e As EventArgs)
			Me.Label8.Text = ""
			Me.Label4.Text = ""
		End Sub

		' Token: 0x06009904 RID: 39172 RVA: 0x006DD440 File Offset: 0x006DB640
		Public Sub fillGategoryName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ComboCategoryName) FROM Combopack order by 1 desc", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbComboPack.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbComboPack.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06009905 RID: 39173 RVA: 0x006DD574 File Offset: 0x006DB774
		Private Sub cmbComboPack_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.cmbCategory.Text = ""
			Dim text As String = Conversions.ToString(Me.cmbComboPack.SelectedItem)
			Try
				Me.TextBox1.Text = ""
				Me.TextBox2.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.Label8.Text, "Retailer", False) = 0
				If flag Then
					Dim text2 As String = String.Concat(New String() { "Select Top ", Conversions.ToString(Me.NumericUpDown1.Value), " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.SPrice),(Qty),Product_Join.Photo From Temp_Stock, Product, SubCategory, Product_Join, ComboPack_Product Where Product.SubCategoryID = SubCategory.ID And Product.PID = Temp_Stock.ProductID And Product.PID = ComboPack_Product.ProductID And Product.PID=Product_Join.ProductID And Product.Status='Yes' and ComboPack_Product.ComboCategoryName = '", text, "' order by ProductName" })
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.Label8.Text, "Wholesaler", False) = 0
				If flag2 Then
					Dim text3 As String = String.Concat(New String() { "Select Top ", Conversions.ToString(Me.NumericUpDown1.Value), " RTRIM(ProductName),RTRIM(Temp_Stock.Barcode), (Product.PartNo), (Temp_Stock.WPrice),(Qty),Product_Join.Photo From Temp_Stock, Product, SubCategory, Product_Join, ComboPack_Product Where Product.SubCategoryID = SubCategory.ID And Product.PID = Temp_Stock.ProductID And Product.PID = ComboPack_Product.ProductID And Product.PID=Product_Join.ProductID And Product.Status='Yes' and ComboPack_Product.ComboCategoryName = '", text, "' order by ProductName" })
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(5), Byte())
					Dim image As Image
					Using memoryStream As MemoryStream = New MemoryStream(array)
						Try
							image = Image.FromStream(memoryStream)
						Catch ex As Exception
							image = Nothing
						End Try
					End Using
					Dim button As Button = New Button()
					button.Image = CType(frmTouchProduct.Resize(image, 130, 90), Image)
					button.ImageAlign = ContentAlignment.TopCenter
					button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(0).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Part No : ".ToString(), ModCommonClasses.rdr.GetValue(2).ToString().Trim(), vbCrLf, "Price : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Qty : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(0).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(2).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim() })
					button.TextAlign = ContentAlignment.BottomLeft
					Dim forestGreen As Color = Color.ForestGreen
					Dim orangeRed As Color = Color.OrangeRed
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					Dim flag3 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) > 0.0
					If flag3 Then
						button.BackgroundImage = Resources.GreenL
						button.BackgroundImageLayout = ImageLayout.Stretch
					Else
						Dim flag4 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(4).ToString().Trim()) <= 0.0
						If flag4 Then
							button.BackgroundImage = Resources.RedL
							button.BackgroundImageLayout = ImageLayout.Stretch
						Else
							button.BackgroundImage = Resources.BlueL
							button.BackgroundImageLayout = ImageLayout.Stretch
						End If
					End If
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 150
					button.Height = 190
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040043AF RID: 17327
		Private UserButtons As List(Of Button)
	End Class
End Namespace
