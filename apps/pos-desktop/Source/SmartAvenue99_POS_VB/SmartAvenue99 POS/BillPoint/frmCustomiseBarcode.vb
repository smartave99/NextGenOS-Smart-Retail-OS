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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200029D RID: 669
	<DesignerGenerated()>
	Public Partial Class frmCustomiseBarcode
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A957 RID: 43351 RVA: 0x0004EEC2 File Offset: 0x0004D0C2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomiseBarcode_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomiseBarcode_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004192 RID: 16786
		' (get) Token: 0x0600A95A RID: 43354 RVA: 0x0004EEF4 File Offset: 0x0004D0F4
		' (set) Token: 0x0600A95B RID: 43355 RVA: 0x0004EEFE File Offset: 0x0004D0FE
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004193 RID: 16787
		' (get) Token: 0x0600A95C RID: 43356 RVA: 0x0004EF07 File Offset: 0x0004D107
		' (set) Token: 0x0600A95D RID: 43357 RVA: 0x0004EF11 File Offset: 0x0004D111
		Friend Overridable Property Label44 As Label

		' Token: 0x17004194 RID: 16788
		' (get) Token: 0x0600A95E RID: 43358 RVA: 0x0004EF1A File Offset: 0x0004D11A
		' (set) Token: 0x0600A95F RID: 43359 RVA: 0x0004EF24 File Offset: 0x0004D124
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x17004195 RID: 16789
		' (get) Token: 0x0600A960 RID: 43360 RVA: 0x0004EF2D File Offset: 0x0004D12D
		' (set) Token: 0x0600A961 RID: 43361 RVA: 0x0004EF37 File Offset: 0x0004D137
		Friend Overridable Property Label1 As Label

		' Token: 0x17004196 RID: 16790
		' (get) Token: 0x0600A962 RID: 43362 RVA: 0x0004EF40 File Offset: 0x0004D140
		' (set) Token: 0x0600A963 RID: 43363 RVA: 0x0071509C File Offset: 0x0071329C
		Private _txtNoOfCopies As TextBox
		Friend Overridable Property txtNoOfCopies As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNoOfCopies
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtNoOfCopies_KeyPress
				Dim textBox As TextBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtNoOfCopies = value
				textBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004197 RID: 16791
		' (get) Token: 0x0600A964 RID: 43364 RVA: 0x0004EF4A File Offset: 0x0004D14A
		' (set) Token: 0x0600A965 RID: 43365 RVA: 0x007150E0 File Offset: 0x007132E0
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

		' Token: 0x17004198 RID: 16792
		' (get) Token: 0x0600A966 RID: 43366 RVA: 0x0004EF54 File Offset: 0x0004D154
		' (set) Token: 0x0600A967 RID: 43367 RVA: 0x0004EF5E File Offset: 0x0004D15E
		Friend Overridable Property listView1 As ListView

		' Token: 0x17004199 RID: 16793
		' (get) Token: 0x0600A968 RID: 43368 RVA: 0x0004EF67 File Offset: 0x0004D167
		' (set) Token: 0x0600A969 RID: 43369 RVA: 0x0004EF71 File Offset: 0x0004D171
		Friend Overridable Property columnHeader1 As ColumnHeader

		' Token: 0x1700419A RID: 16794
		' (get) Token: 0x0600A96A RID: 43370 RVA: 0x0004EF7A File Offset: 0x0004D17A
		' (set) Token: 0x0600A96B RID: 43371 RVA: 0x0004EF84 File Offset: 0x0004D184
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x1700419B RID: 16795
		' (get) Token: 0x0600A96C RID: 43372 RVA: 0x0004EF8D File Offset: 0x0004D18D
		' (set) Token: 0x0600A96D RID: 43373 RVA: 0x0004EF97 File Offset: 0x0004D197
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x1700419C RID: 16796
		' (get) Token: 0x0600A96E RID: 43374 RVA: 0x0004EFA0 File Offset: 0x0004D1A0
		' (set) Token: 0x0600A96F RID: 43375 RVA: 0x0004EFAA File Offset: 0x0004D1AA
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x1700419D RID: 16797
		' (get) Token: 0x0600A970 RID: 43376 RVA: 0x0004EFB3 File Offset: 0x0004D1B3
		' (set) Token: 0x0600A971 RID: 43377 RVA: 0x00715124 File Offset: 0x00713324
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

		' Token: 0x1700419E RID: 16798
		' (get) Token: 0x0600A972 RID: 43378 RVA: 0x0004EFBD File Offset: 0x0004D1BD
		' (set) Token: 0x0600A973 RID: 43379 RVA: 0x0004EFC7 File Offset: 0x0004D1C7
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700419F RID: 16799
		' (get) Token: 0x0600A974 RID: 43380 RVA: 0x0004EFD0 File Offset: 0x0004D1D0
		' (set) Token: 0x0600A975 RID: 43381 RVA: 0x00715168 File Offset: 0x00713368
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

		' Token: 0x170041A0 RID: 16800
		' (get) Token: 0x0600A976 RID: 43382 RVA: 0x0004EFDA File Offset: 0x0004D1DA
		' (set) Token: 0x0600A977 RID: 43383 RVA: 0x0004EFE4 File Offset: 0x0004D1E4
		Friend Overridable Property Label3 As Label

		' Token: 0x170041A1 RID: 16801
		' (get) Token: 0x0600A978 RID: 43384 RVA: 0x0004EFED File Offset: 0x0004D1ED
		' (set) Token: 0x0600A979 RID: 43385 RVA: 0x0004EFF7 File Offset: 0x0004D1F7
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x170041A2 RID: 16802
		' (get) Token: 0x0600A97A RID: 43386 RVA: 0x0004F000 File Offset: 0x0004D200
		' (set) Token: 0x0600A97B RID: 43387 RVA: 0x0004F00A File Offset: 0x0004D20A
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x170041A3 RID: 16803
		' (get) Token: 0x0600A97C RID: 43388 RVA: 0x0004F013 File Offset: 0x0004D213
		' (set) Token: 0x0600A97D RID: 43389 RVA: 0x007151AC File Offset: 0x007133AC
		Private _RadioButton1 As RadioButton
		Friend Overridable Property RadioButton1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton1_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton1 = value
				radioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041A4 RID: 16804
		' (get) Token: 0x0600A97E RID: 43390 RVA: 0x0004F01D File Offset: 0x0004D21D
		' (set) Token: 0x0600A97F RID: 43391 RVA: 0x007151F0 File Offset: 0x007133F0
		Private _RadioButton2 As RadioButton
		Friend Overridable Property RadioButton2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton2_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton2 = value
				radioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170041A5 RID: 16805
		' (get) Token: 0x0600A980 RID: 43392 RVA: 0x0004F027 File Offset: 0x0004D227
		' (set) Token: 0x0600A981 RID: 43393 RVA: 0x00715234 File Offset: 0x00713434
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

		' Token: 0x170041A6 RID: 16806
		' (get) Token: 0x0600A982 RID: 43394 RVA: 0x0004F031 File Offset: 0x0004D231
		' (set) Token: 0x0600A983 RID: 43395 RVA: 0x0004F03B File Offset: 0x0004D23B
		Friend Overridable Property Label2 As Label

		' Token: 0x170041A7 RID: 16807
		' (get) Token: 0x0600A984 RID: 43396 RVA: 0x0004F044 File Offset: 0x0004D244
		' (set) Token: 0x0600A985 RID: 43397 RVA: 0x00715278 File Offset: 0x00713478
		Private _txtScode As TextBox
		Friend Overridable Property txtScode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtScode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtScode_KeyDown
				Dim textBox As TextBox = Me._txtScode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtScode = value
				textBox = Me._txtScode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170041A8 RID: 16808
		' (get) Token: 0x0600A986 RID: 43398 RVA: 0x0004F04E File Offset: 0x0004D24E
		' (set) Token: 0x0600A987 RID: 43399 RVA: 0x0004F058 File Offset: 0x0004D258
		Friend Overridable Property Label4 As Label

		' Token: 0x170041A9 RID: 16809
		' (get) Token: 0x0600A988 RID: 43400 RVA: 0x0004F061 File Offset: 0x0004D261
		' (set) Token: 0x0600A989 RID: 43401 RVA: 0x007152BC File Offset: 0x007134BC
		Private _txtPcode As TextBox
		Friend Overridable Property txtPcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPcode_KeyDown
				Dim textBox As TextBox = Me._txtPcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtPcode = value
				textBox = Me._txtPcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170041AA RID: 16810
		' (get) Token: 0x0600A98A RID: 43402 RVA: 0x0004F06B File Offset: 0x0004D26B
		' (set) Token: 0x0600A98B RID: 43403 RVA: 0x0004F075 File Offset: 0x0004D275
		Friend Overridable Property Label5 As Label

		' Token: 0x170041AB RID: 16811
		' (get) Token: 0x0600A98C RID: 43404 RVA: 0x0004F07E File Offset: 0x0004D27E
		' (set) Token: 0x0600A98D RID: 43405 RVA: 0x0004F088 File Offset: 0x0004D288
		Friend Overridable Property Label6 As Label

		' Token: 0x170041AC RID: 16812
		' (get) Token: 0x0600A98E RID: 43406 RVA: 0x0004F091 File Offset: 0x0004D291
		' (set) Token: 0x0600A98F RID: 43407 RVA: 0x0004F09B File Offset: 0x0004D29B
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x170041AD RID: 16813
		' (get) Token: 0x0600A990 RID: 43408 RVA: 0x0004F0A4 File Offset: 0x0004D2A4
		' (set) Token: 0x0600A991 RID: 43409 RVA: 0x00715300 File Offset: 0x00713500
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

		' Token: 0x170041AE RID: 16814
		' (get) Token: 0x0600A992 RID: 43410 RVA: 0x0004F0AE File Offset: 0x0004D2AE
		' (set) Token: 0x0600A993 RID: 43411 RVA: 0x00715344 File Offset: 0x00713544
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

		' Token: 0x0600A994 RID: 43412 RVA: 0x00715388 File Offset: 0x00713588
		Public Sub dommyno()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c10),RTRIM(c11) from CipherCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.dmy1 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.dmy2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.dmy1 = Conversions.ToString(0)
					Me.dmy2 = Conversions.ToString(0)
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				Me.dmy1 = Conversions.ToString(0)
				Me.dmy2 = Conversions.ToString(0)
			End Try
		End Sub

		' Token: 0x0600A995 RID: 43413 RVA: 0x0071547C File Offset: 0x0071367C
		Public Sub Reset()
			Me.txtProductName.Text = ""
			Me.txtNoOfCopies.Text = Conversions.ToString(1)
			Me.chkSelectAll.Checked = True
			Me.RadioButton1.Checked = True
			Me.RadioButton2.Checked = False
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtPcode.Text = ""
			Me.txtScode.Text = ""
			Me.ComboBox2.SelectedIndex = -1
			Me.GetData()
		End Sub

		' Token: 0x0600A996 RID: 43414 RVA: 0x0071552C File Offset: 0x0071372C
		Public Sub FillCompany()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select RTRIM(CompanyName) from Company"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.txtCompany.Text = ModCommonClasses.rdr.GetString(0)
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600A997 RID: 43415 RVA: 0x007155B0 File Offset: 0x007137B0
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.SalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.SPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes'" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A998 RID: 43416 RVA: 0x007157B4 File Offset: 0x007139B4
		Public Sub GetData1()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.WSalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.WPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes'" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A999 RID: 43417 RVA: 0x007159B8 File Offset: 0x00713BB8
		Private Sub frmCustomiseBarcode_Load(sender As Object, e As EventArgs)
			Me.RadioButton1.Checked = True
			Me.dommyno()
			Me.FillCompany()
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.GetData()
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Me.GetData1()
				End If
			End If
			Me.Convert_Language()
		End Sub

		' Token: 0x0600A99A RID: 43418 RVA: 0x00715A18 File Offset: 0x00713C18
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

		' Token: 0x0600A99B RID: 43419 RVA: 0x00715B90 File Offset: 0x00713D90
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

		' Token: 0x0600A99C RID: 43420 RVA: 0x00715C4C File Offset: 0x00713E4C
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

		' Token: 0x0600A99D RID: 43421 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600A99E RID: 43422 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600A99F RID: 43423 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600A9A0 RID: 43424 RVA: 0x00715D18 File Offset: 0x00713F18
		Public Sub Print()
			Dim flag As Boolean = Me.ComboBox2.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.ComboBox2.Focus()
			Else
				Dim flag2 As Boolean = Me.listView1.Items.Count = 0
				If flag2 Then
					MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.listView1.CheckedItems.Count = 0
					If flag3 Then
						MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim dataTable As DataTable = New DataTable()
							Dim dataTable2 As DataTable = dataTable
							dataTable2.Columns.Add("Barcode")
							dataTable2.Columns.Add("Productname")
							dataTable2.Columns.Add("SellingPrice")
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Dim num As Integer = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text))) - 1
									Dim num2 As Integer = num
									For i As Integer = 0 To num2
										dataTable.Rows.Add(New Object() { listViewItem.SubItems(3).Text, listViewItem.SubItems(1).Text, listViewItem.SubItems(4).Text })
									Next
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim reportDocument As ReportDocument = New ReportDocument()
							Dim flag4 As Boolean = Me.ComboBox2.SelectedIndex = 0
							If flag4 Then
								reportDocument = New rptBarcodeCipher()
							End If
							Dim flag5 As Boolean = Me.ComboBox2.SelectedIndex = 1
							If flag5 Then
								reportDocument = New rptCipherA4_4()
							End If
							Dim flag6 As Boolean = Me.ComboBox2.SelectedIndex = 2
							If flag6 Then
								reportDocument = New rptBarcodeCipher2_1()
							End If
							Dim flag7 As Boolean = Me.ComboBox2.SelectedIndex = 3
							If flag7 Then
								reportDocument = New rptBarcodeCipher2_2()
							End If
							reportDocument.SetDataSource(dataTable)
							reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600A9A1 RID: 43425 RVA: 0x0004F0B8 File Offset: 0x0004D2B8
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600A9A2 RID: 43426 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtNoOfCopies_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600A9A3 RID: 43427 RVA: 0x0004F0C2 File Offset: 0x0004D2C2
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600A9A4 RID: 43428 RVA: 0x00716004 File Offset: 0x00714204
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Me.txtBarcode.Text = ""
			Me.txtPcode.Text = ""
			Me.txtScode.Text = ""
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Try
					Dim flag As Boolean = e.KeyCode = Keys.[Return]
					If flag Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.SalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.SPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Product.ProductName) like N'", Me.txtProductName.Text, "%'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem As ListViewItem = New ListViewItem()
							listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem)
						End While
						Dim num As Integer = Me.listView1.Items.Count - 1
						For i As Integer = 0 To num
							Me.listView1.Items(i).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Try
					Dim flag2 As Boolean = e.KeyCode = Keys.[Return]
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.WSalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.WPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Product.ProductName) like N'", Me.txtProductName.Text, "%'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem2 As ListViewItem = New ListViewItem()
							listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem2)
						End While
						Dim num2 As Integer = Me.listView1.Items.Count - 1
						For j As Integer = 0 To num2
							Me.listView1.Items(j).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A9A5 RID: 43429 RVA: 0x007164B4 File Offset: 0x007146B4
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600A9A6 RID: 43430 RVA: 0x0004F0DE File Offset: 0x0004D2DE
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Me.chkSelectAll.Checked = True
			Me.GetData()
		End Sub

		' Token: 0x0600A9A7 RID: 43431 RVA: 0x0004F0F5 File Offset: 0x0004D2F5
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Me.chkSelectAll.Checked = True
			Me.GetData1()
		End Sub

		' Token: 0x0600A9A8 RID: 43432 RVA: 0x007165A0 File Offset: 0x007147A0
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Me.txtProductName.Text = ""
			Me.txtPcode.Text = ""
			Me.txtScode.Text = ""
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Try
					Dim flag As Boolean = e.KeyCode = Keys.[Return]
					If flag Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.SalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.SPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and  RTRIM(Temp_Stock.Barcode) like N'", Me.txtBarcode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem As ListViewItem = New ListViewItem()
							listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem)
						End While
						Dim num As Integer = Me.listView1.Items.Count - 1
						For i As Integer = 0 To num
							Me.listView1.Items(i).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Try
					Dim flag2 As Boolean = e.KeyCode = Keys.[Return]
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.WSalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.WPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Temp_Stock.Barcode) like N'", Me.txtBarcode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem2 As ListViewItem = New ListViewItem()
							listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem2)
						End While
						Dim num2 As Integer = Me.listView1.Items.Count - 1
						For j As Integer = 0 To num2
							Me.listView1.Items(j).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A9A9 RID: 43433 RVA: 0x00716A50 File Offset: 0x00714C50
		Private Sub txtScode_KeyDown(sender As Object, e As KeyEventArgs)
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtPcode.Text = ""
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Try
					Dim flag As Boolean = e.KeyCode = Keys.[Return]
					If flag Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.SalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.SPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Supplier.SCode) like N'", Me.txtScode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem As ListViewItem = New ListViewItem()
							listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem)
						End While
						Dim num As Integer = Me.listView1.Items.Count - 1
						For i As Integer = 0 To num
							Me.listView1.Items(i).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Try
					Dim flag2 As Boolean = e.KeyCode = Keys.[Return]
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.WSalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.WPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Supplier.SCode) like N'", Me.txtScode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem2 As ListViewItem = New ListViewItem()
							listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem2)
						End While
						Dim num2 As Integer = Me.listView1.Items.Count - 1
						For j As Integer = 0 To num2
							Me.listView1.Items(j).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A9AA RID: 43434 RVA: 0x00716F00 File Offset: 0x00715100
		Private Sub txtPcode_KeyDown(sender As Object, e As KeyEventArgs)
			Me.txtProductName.Text = ""
			Me.txtBarcode.Text = ""
			Me.txtScode.Text = ""
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Try
					Dim flag As Boolean = e.KeyCode = Keys.[Return]
					If flag Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.SalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.SPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Product.ProductCode) like N'", Me.txtPcode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem As ListViewItem = New ListViewItem()
							listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem)
						End While
						Dim num As Integer = Me.listView1.Items.Count - 1
						For i As Integer = 0 To num
							Me.listView1.Items(i).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Try
					Dim flag2 As Boolean = e.KeyCode = Keys.[Return]
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT DISTINCT RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Supplier.SCode), RTRIM(Temp_Stock.Barcode), (RTRIM(Product.ProductCode)+ '-' + RTRIM(Supplier.SCode) + '-' + '", Me.dmy1, "' + '-' + RTRIM(Temp_Stock.WSalePrice) + '-' + '", Me.dmy2, "'), RTRIM(Temp_Stock.WPrice) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Temp_Stock ON Stock_Product.ProductID = Temp_Stock.ProductID and Product.Status='Yes' and RTRIM(Product.ProductCode) like N'", Me.txtPcode.Text, "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Me.listView1.Items.Clear()
						While ModCommonClasses.rdr.Read()
							Dim listViewItem2 As ListViewItem = New ListViewItem()
							listViewItem2.Text = ModCommonClasses.rdr(0).ToString().Trim()
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
							listViewItem2.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
							Me.listView1.Items.Add(listViewItem2)
						End While
						Dim num2 As Integer = Me.listView1.Items.Count - 1
						For j As Integer = 0 To num2
							Me.listView1.Items(j).Checked = True
						Next
						ModCommonClasses.con.Close()
					End If
				Catch ex2 As Exception
					MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600A9AB RID: 43435 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomiseBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600A9AC RID: 43436 RVA: 0x0004F10C File Offset: 0x0004D30C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600A9AD RID: 43437 RVA: 0x0004F0B8 File Offset: 0x0004D2B8
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x040046FA RID: 18170
		Private st As String

		' Token: 0x040046FB RID: 18171
		Private dmy1 As String

		' Token: 0x040046FC RID: 18172
		Private dmy2 As String
	End Class
End Namespace
