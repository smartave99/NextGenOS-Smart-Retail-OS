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
Imports System.Management
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports CButtonLib
Imports ClosedXML.Excel
Imports FireSharp
Imports FireSharp.Config
Imports FireSharp.Interfaces
Imports FireSharp.Response
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Nancy.Json
Imports Newtonsoft.Json
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000119 RID: 281
	<DesignerGenerated()>
	Public Partial Class frmGodownInward
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003008 RID: 12296 RVA: 0x001D8BF8 File Offset: 0x001D6DF8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGodownInward_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGodownInward_KeyDown
			Me.DateTimeFormat = "yyyy/MM/dd HH:mm:ss"
			Me.clearDGVCol = True
			Me.InitializeComponent()
		End Sub

		' Token: 0x170012B4 RID: 4788
		' (get) Token: 0x0600300B RID: 12299 RVA: 0x0001E149 File Offset: 0x0001C349
		' (set) Token: 0x0600300C RID: 12300 RVA: 0x0001E153 File Offset: 0x0001C353
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170012B5 RID: 4789
		' (get) Token: 0x0600300D RID: 12301 RVA: 0x0001E15C File Offset: 0x0001C35C
		' (set) Token: 0x0600300E RID: 12302 RVA: 0x0001E166 File Offset: 0x0001C366
		Friend Overridable Property Label1 As Label

		' Token: 0x170012B6 RID: 4790
		' (get) Token: 0x0600300F RID: 12303 RVA: 0x0001E16F File Offset: 0x0001C36F
		' (set) Token: 0x06003010 RID: 12304 RVA: 0x0001E179 File Offset: 0x0001C379
		Friend Overridable Property lblUser As Label

		' Token: 0x170012B7 RID: 4791
		' (get) Token: 0x06003011 RID: 12305 RVA: 0x0001E182 File Offset: 0x0001C382
		' (set) Token: 0x06003012 RID: 12306 RVA: 0x0001E18C File Offset: 0x0001C38C
		Friend Overridable Property lblCompID As Label

		' Token: 0x170012B8 RID: 4792
		' (get) Token: 0x06003013 RID: 12307 RVA: 0x0001E195 File Offset: 0x0001C395
		' (set) Token: 0x06003014 RID: 12308 RVA: 0x0001E19F File Offset: 0x0001C39F
		Friend Overridable Property lblDB As Label

		' Token: 0x170012B9 RID: 4793
		' (get) Token: 0x06003015 RID: 12309 RVA: 0x0001E1A8 File Offset: 0x0001C3A8
		' (set) Token: 0x06003016 RID: 12310 RVA: 0x001DA454 File Offset: 0x001D8654
		Private _DGVUserData As DataGridView
		Friend Overridable Property DGVUserData As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DGVUserData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DGVUserData_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DGVUserData_MouseUp
				Dim dataGridView As DataGridView = Me._DGVUserData
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseUp, mouseEventHandler
				End If
				Me._DGVUserData = value
				dataGridView = Me._DGVUserData
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseUp, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012BA RID: 4794
		' (get) Token: 0x06003017 RID: 12311 RVA: 0x0001E1B2 File Offset: 0x0001C3B2
		' (set) Token: 0x06003018 RID: 12312 RVA: 0x0001E1BC File Offset: 0x0001C3BC
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x170012BB RID: 4795
		' (get) Token: 0x06003019 RID: 12313 RVA: 0x0001E1C5 File Offset: 0x0001C3C5
		' (set) Token: 0x0600301A RID: 12314 RVA: 0x0001E1CF File Offset: 0x0001C3CF
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170012BC RID: 4796
		' (get) Token: 0x0600301B RID: 12315 RVA: 0x0001E1D8 File Offset: 0x0001C3D8
		' (set) Token: 0x0600301C RID: 12316 RVA: 0x0001E1E2 File Offset: 0x0001C3E2
		Friend Overridable Property Label9 As Label

		' Token: 0x170012BD RID: 4797
		' (get) Token: 0x0600301D RID: 12317 RVA: 0x0001E1EB File Offset: 0x0001C3EB
		' (set) Token: 0x0600301E RID: 12318 RVA: 0x0001E1F5 File Offset: 0x0001C3F5
		Friend Overridable Property Label7 As Label

		' Token: 0x170012BE RID: 4798
		' (get) Token: 0x0600301F RID: 12319 RVA: 0x0001E1FE File Offset: 0x0001C3FE
		' (set) Token: 0x06003020 RID: 12320 RVA: 0x0001E208 File Offset: 0x0001C408
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170012BF RID: 4799
		' (get) Token: 0x06003021 RID: 12321 RVA: 0x0001E211 File Offset: 0x0001C411
		' (set) Token: 0x06003022 RID: 12322 RVA: 0x001DA4B4 File Offset: 0x001D86B4
		Private _btnSearch As Button
		Friend Overridable Property btnSearch As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSearch_Click
				Dim button As Button = Me._btnSearch
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSearch = value
				button = Me._btnSearch
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170012C0 RID: 4800
		' (get) Token: 0x06003023 RID: 12323 RVA: 0x0001E21B File Offset: 0x0001C41B
		' (set) Token: 0x06003024 RID: 12324 RVA: 0x001DA4F8 File Offset: 0x001D86F8
		Private _btnGetData As CButton
		Friend Overridable Property btnGetData As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnGetData_ClickButtonArea
				Dim cbutton As CButton = Me._btnGetData
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnGetData = value
				cbutton = Me._btnGetData
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012C1 RID: 4801
		' (get) Token: 0x06003025 RID: 12325 RVA: 0x0001E225 File Offset: 0x0001C425
		' (set) Token: 0x06003026 RID: 12326 RVA: 0x001DA53C File Offset: 0x001D873C
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

		' Token: 0x170012C2 RID: 4802
		' (get) Token: 0x06003027 RID: 12327 RVA: 0x0001E22F File Offset: 0x0001C42F
		' (set) Token: 0x06003028 RID: 12328 RVA: 0x001DA580 File Offset: 0x001D8780
		Private _btnReset As CButton
		Friend Overridable Property btnReset As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnReset_ClickButtonArea
				Dim cbutton As CButton = Me._btnReset
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnReset = value
				cbutton = Me._btnReset
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012C3 RID: 4803
		' (get) Token: 0x06003029 RID: 12329 RVA: 0x0001E239 File Offset: 0x0001C439
		' (set) Token: 0x0600302A RID: 12330 RVA: 0x001DA5C4 File Offset: 0x001D87C4
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

		' Token: 0x170012C4 RID: 4804
		' (get) Token: 0x0600302B RID: 12331 RVA: 0x0001E243 File Offset: 0x0001C443
		' (set) Token: 0x0600302C RID: 12332 RVA: 0x0001E24D File Offset: 0x0001C44D
		Friend Overridable Property Label2 As Label

		' Token: 0x170012C5 RID: 4805
		' (get) Token: 0x0600302D RID: 12333 RVA: 0x0001E256 File Offset: 0x0001C456
		' (set) Token: 0x0600302E RID: 12334 RVA: 0x0001E260 File Offset: 0x0001C460
		Friend Overridable Property ContextMenuStrip1 As ContextMenuStrip

		' Token: 0x170012C6 RID: 4806
		' (get) Token: 0x0600302F RID: 12335 RVA: 0x0001E269 File Offset: 0x0001C469
		' (set) Token: 0x06003030 RID: 12336 RVA: 0x001DA608 File Offset: 0x001D8808
		Private _AcceptToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property AcceptToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AcceptToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AcceptToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AcceptToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AcceptToolStripMenuItem = value
				toolStripMenuItem = Me._AcceptToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170012C7 RID: 4807
		' (get) Token: 0x06003031 RID: 12337 RVA: 0x0001E273 File Offset: 0x0001C473
		' (set) Token: 0x06003032 RID: 12338 RVA: 0x001DA64C File Offset: 0x001D884C
		Private _RejectToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property RejectToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._RejectToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.RejectToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._RejectToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._RejectToolStripMenuItem = value
				toolStripMenuItem = Me._RejectToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170012C8 RID: 4808
		' (get) Token: 0x06003033 RID: 12339 RVA: 0x0001E27D File Offset: 0x0001C47D
		' (set) Token: 0x06003034 RID: 12340 RVA: 0x0001E287 File Offset: 0x0001C487
		Friend Overridable Property lblProductCode As Label

		' Token: 0x170012C9 RID: 4809
		' (get) Token: 0x06003035 RID: 12341 RVA: 0x0001E290 File Offset: 0x0001C490
		' (set) Token: 0x06003036 RID: 12342 RVA: 0x0001E29A File Offset: 0x0001C49A
		Friend Overridable Property lblID As Label

		' Token: 0x170012CA RID: 4810
		' (get) Token: 0x06003037 RID: 12343 RVA: 0x0001E2A3 File Offset: 0x0001C4A3
		' (set) Token: 0x06003038 RID: 12344 RVA: 0x001DA690 File Offset: 0x001D8890
		Private _btnExportExcel As CButton
		Friend Overridable Property btnExportExcel As CButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CButton)
				Dim clickButtonAreaEventHandler As CButton.ClickButtonAreaEventHandler = AddressOf Me.btnExportExcel_ClickButtonArea
				Dim cbutton As CButton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					RemoveHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
				Me._btnExportExcel = value
				cbutton = Me._btnExportExcel
				If cbutton IsNot Nothing Then
					AddHandler cbutton.ClickButtonArea, clickButtonAreaEventHandler
				End If
			End Set
		End Property

		' Token: 0x170012CB RID: 4811
		' (get) Token: 0x06003039 RID: 12345 RVA: 0x0001E2AD File Offset: 0x0001C4AD
		' (set) Token: 0x0600303A RID: 12346 RVA: 0x0001E2B7 File Offset: 0x0001C4B7
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170012CC RID: 4812
		' (get) Token: 0x0600303B RID: 12347 RVA: 0x0001E2C0 File Offset: 0x0001C4C0
		' (set) Token: 0x0600303C RID: 12348 RVA: 0x001DA6D4 File Offset: 0x001D88D4
		Private _CopyBranchIDToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property CopyBranchIDToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._CopyBranchIDToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.CopyBranchIDToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._CopyBranchIDToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._CopyBranchIDToolStripMenuItem = value
				toolStripMenuItem = Me._CopyBranchIDToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170012CD RID: 4813
		' (get) Token: 0x0600303D RID: 12349 RVA: 0x0001E2CA File Offset: 0x0001C4CA
		' (set) Token: 0x0600303E RID: 12350 RVA: 0x0001E2D4 File Offset: 0x0001C4D4
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x0600303F RID: 12351 RVA: 0x001DA718 File Offset: 0x001D8918
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(If(("SELECT RTRIM(ID), RTRIM(HardwareID), RTRIM(ActivationID) from Activation where ID=" + Conversions.ToString(1)), ""), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.RealtimeDatabasePath = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.EmailSecretKey = ModCommonClasses.rdr.GetValue(2).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003040 RID: 12352 RVA: 0x001DA7FC File Offset: 0x001D89FC
		Private Sub frmGodownInward_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Dim firebaseConfig As FirebaseConfig = New FirebaseConfig() With { .AuthSecret = Me.EmailSecretKey, .BasePath = Me.RealtimeDatabasePath }
			Try
				Me.client = New FirebaseClient(firebaseConfig)
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.lblCompID.Text = ModFunc.MD5Encrypt(Me.lblDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex2 As Exception
				Me.lblCompID.Text = ""
			End Try
		End Sub

		' Token: 0x06003041 RID: 12353 RVA: 0x001DA934 File Offset: 0x001D8B34
		Private Sub btnGetData_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.ShowRecord()
			End If
		End Sub

		' Token: 0x06003042 RID: 12354 RVA: 0x001DA96C File Offset: 0x001D8B6C
		Public Sub ShowRecord()
			' The following expression was wrapped in a checked-statement
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				dataTable.Columns.Add("PID")
				dataTable.Columns.Add("PCode")
				dataTable.Columns.Add("Product Name")
				dataTable.Columns.Add("HSNC")
				dataTable.Columns.Add("Part No")
				dataTable.Columns.Add("Barcode")
				dataTable.Columns.Add("New Barcode")
				dataTable.Columns.Add("Purc Price")
				dataTable.Columns.Add("MRP")
				dataTable.Columns.Add("W Price")
				dataTable.Columns.Add("R Price")
				dataTable.Columns.Add("Disc%")
				dataTable.Columns.Add("CGST%")
				dataTable.Columns.Add("SGST%")
				dataTable.Columns.Add("CESS%")
				dataTable.Columns.Add("P Unit")
				dataTable.Columns.Add("S Unit")
				dataTable.Columns.Add("Conv")
				dataTable.Columns.Add("Alt Unit")
				dataTable.Columns.Add("Sale Tax Type")
				dataTable.Columns.Add("Purc Tax Type")
				dataTable.Columns.Add("Min Stock")
				dataTable.Columns.Add("Category")
				dataTable.Columns.Add("Colour")
				dataTable.Columns.Add("Size")
				dataTable.Columns.Add("Batch")
				dataTable.Columns.Add("Mfg")
				dataTable.Columns.Add("Exp")
				dataTable.Columns.Add("IMEI1")
				dataTable.Columns.Add("IMEI2")
				dataTable.Columns.Add("Trfr Qty")
				dataTable.Columns.Add("Status")
				dataTable.Columns.Add("Entry Date")
				dataTable.Columns.Add("CompId")
				dataTable.Columns.Add("Branch ID")
				Dim flag As Boolean = Me.clearDGVCol
				If flag Then
					Me.DGVUserData.Columns.Clear()
					Me.clearDGVCol = False
				End If
				Dim firebaseResponse As FirebaseResponse = Me.client.[Get](If(Me.lblCompID.Text.ToString(), ""))
				Dim javaScriptSerializer As JavaScriptSerializer = New JavaScriptSerializer()
				Dim dictionary As Dictionary(Of String, FirebaseCRUDData) = JsonConvert.DeserializeObject(Of Dictionary(Of String, FirebaseCRUDData))(firebaseResponse.Body.ToString())
				Try
					Try
						For Each keyValuePair As KeyValuePair(Of String, FirebaseCRUDData) In dictionary
							Dim text As String = Conversions.ToDate(keyValuePair.Value.Entrydate).ToString("yyyy-MM-dd HH:mm:ss")
							Dim text2 As String = keyValuePair.Value.CompId.ToString()
							Dim array As String() = text2.Split(New Char() { "_"c })
							Dim text3 As String = array(0)
							dataTable.Rows.Add(New Object() { keyValuePair.Value.PID, keyValuePair.Value.PCode, keyValuePair.Value.PName, keyValuePair.Value.HSN, keyValuePair.Value.Part, keyValuePair.Value.Barcode, keyValuePair.Value.NewBarcode, keyValuePair.Value.PPrice, keyValuePair.Value.MRP, keyValuePair.Value.WPrice, keyValuePair.Value.RPrice, keyValuePair.Value.Disc, keyValuePair.Value.CGST, keyValuePair.Value.SGST, keyValuePair.Value.CESS, keyValuePair.Value.PUnit, keyValuePair.Value.SUnit, keyValuePair.Value.Conv, keyValuePair.Value.SAltUnit, keyValuePair.Value.STax, keyValuePair.Value.PTax, keyValuePair.Value.MinStk, keyValuePair.Value.Category, keyValuePair.Value.Colour, keyValuePair.Value.Size, keyValuePair.Value.Batch, keyValuePair.Value.Mfg, keyValuePair.Value.Exp, keyValuePair.Value.IMEI1, keyValuePair.Value.IMEI2, keyValuePair.Value.Qty, keyValuePair.Value.Sts, text, keyValuePair.Value.CompId, text3 })
						Next
					Finally
						Dim enumerator As Dictionary(Of String, FirebaseCRUDData).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				Catch ex As Exception
					MessageBox.Show("Database not found or Database is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End Try
				Me.DGVUserData.DataSource = dataTable
				Me.dtTableGrd = dataTable
				Try
					Me.DGVUserData.Columns(33).Visible = False
					Me.DGVUserData.Columns(7).Visible = False
				Catch ex2 As Exception
				End Try
				Dim num As Integer = Me.DGVUserData.RowCount - 1
				For i As Integer = 0 To num
					Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
					Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
					If flag2 Then
						Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
					If flag3 Then
						Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
					End If
				Next
				Me.DGVUserData.ClearSelection()
			Catch ex3 As Exception
				Dim flag4 As Boolean = Operators.CompareString(ex3.Message, "One or more errors occurred", False) = 0
				If flag4 Then
					MessageBox.Show("Cannot connect to firebase, check your network !", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag5 As Boolean = Operators.CompareString(ex3.Message, "Object reference not set to an instance of an object", False) = 0
					If flag5 Then
						Dim dataTable2 As DataTable = New DataTable()
						dataTable2.Columns.Add("PID")
						dataTable2.Columns.Add("PCode")
						dataTable2.Columns.Add("Product Name")
						dataTable2.Columns.Add("HSNC")
						dataTable2.Columns.Add("Part No")
						dataTable2.Columns.Add("Barcode")
						dataTable2.Columns.Add("New Barcode")
						dataTable2.Columns.Add("Purc Price")
						dataTable2.Columns.Add("MRP")
						dataTable2.Columns.Add("W Price")
						dataTable2.Columns.Add("R Price")
						dataTable2.Columns.Add("Disc%")
						dataTable2.Columns.Add("CGST%")
						dataTable2.Columns.Add("SGST%")
						dataTable2.Columns.Add("CESS%")
						dataTable2.Columns.Add("P Unit")
						dataTable2.Columns.Add("S Unit")
						dataTable2.Columns.Add("Conv")
						dataTable2.Columns.Add("Alt Unit")
						dataTable2.Columns.Add("Sale Tax Type")
						dataTable2.Columns.Add("Purc Tax Type")
						dataTable2.Columns.Add("Min Stock")
						dataTable2.Columns.Add("Category")
						dataTable2.Columns.Add("Colour")
						dataTable2.Columns.Add("Size")
						dataTable2.Columns.Add("Batch")
						dataTable2.Columns.Add("Mfg")
						dataTable2.Columns.Add("Exp")
						dataTable2.Columns.Add("IMEI1")
						dataTable2.Columns.Add("IMEI2")
						dataTable2.Columns.Add("Trfr Qty")
						dataTable2.Columns.Add("Status")
						dataTable2.Columns.Add("Entry Date")
						dataTable2.Columns.Add("CompId")
						dataTable2.Columns.Add("Branch ID")
						Me.DGVUserData.DataSource = dataTable2
						Try
							Me.DGVUserData.Columns(33).Visible = False
							Me.DGVUserData.Columns(7).Visible = False
						Catch ex4 As Exception
						End Try
						MessageBox.Show("Database not found or Database is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						MessageBox.Show(ex3.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
				End If
			End Try
		End Sub

		' Token: 0x06003043 RID: 12355 RVA: 0x0001E2DD File Offset: 0x0001C4DD
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06003044 RID: 12356 RVA: 0x001DB470 File Offset: 0x001D9670
		Private Sub btnSearch_Click(sender As Object, e As EventArgs)
			Try
				Me.dtTableGrd.DefaultView.RowFilter = ""
				TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Me.DateTimePicker1.Value.AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Me.DateTimePicker2.Value.AddDays(1.0), "yyyy/MM/dd"), "'" })
			Catch ex As Exception
			End Try
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex2 As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x06003045 RID: 12357 RVA: 0x001DB698 File Offset: 0x001D9898
		Private Sub btnReset_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.ComboBox1.SelectedIndex = -1
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Try
					Me.dtTableGrd.DefaultView.RowFilter = ""
					TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(1.0), "yyyy/MM/dd"), "'" })
				Catch ex2 As Exception
				End Try
			Next
			Dim num2 As Integer = Me.DGVUserData.RowCount - 1
			For j As Integer = 0 To num2
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x06003046 RID: 12358 RVA: 0x001DB914 File Offset: 0x001D9B14
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = "Status Like '" + Me.ComboBox1.Text + "%'"
				Me.DGVUserData.ClearSelection()
			Catch ex As Exception
			End Try
			Try
				Me.DGVUserData.Columns(33).Visible = False
			Catch ex2 As Exception
			End Try
			Dim num As Integer = Me.DGVUserData.RowCount - 1
			For i As Integer = 0 To num
				Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
				Dim flag As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Accepted", False) = 0
				If flag Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.Lime
				End If
				Dim flag2 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(i).Cells(31).Value.ToString(), "Rejected", False) = 0
				If flag2 Then
					Me.DGVUserData.Rows(i).DefaultCellStyle.BackColor = Color.OrangeRed
				End If
			Next
			Me.DGVUserData.ClearSelection()
		End Sub

		' Token: 0x06003047 RID: 12359 RVA: 0x001DBAC8 File Offset: 0x001D9CC8
		Private Sub DGVUserData_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DGVUserData.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DGVUserData.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim controlDarkDark As Brush = SystemBrushes.ControlDarkDark
			e.Graphics.DrawString(text, Me.Font, controlDarkDark, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06003048 RID: 12360 RVA: 0x001DBBB0 File Offset: 0x001D9DB0
		Private Sub DGVUserData_MouseUp(sender As Object, e As MouseEventArgs)
			Dim flag As Boolean = e.Button = MouseButtons.Right
			If flag Then
				Try
					Dim hitTestInfo As DataGridView.HitTestInfo = Me.DGVUserData.HitTest(e.X, e.Y)
					Me.DGVUserData.ClearSelection()
					frmGodownInward.selectedIndex = hitTestInfo.RowIndex
					Me.DGVUserData.Rows(hitTestInfo.RowIndex).Selected = True
					Me.ContextMenuStrip1.Show(Me.DGVUserData, New Point(e.X, e.Y))
				Catch ex As Exception
				End Try
			End If
		End Sub

		' Token: 0x06003049 RID: 12361 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGodownInward_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600304A RID: 12362 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600304B RID: 12363 RVA: 0x001DBC68 File Offset: 0x001D9E68
		Public Sub auto()
			Try
				Me.lblID.Text = Me.GenerateID()
				Me.lblProductCode.Text = "P-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600304C RID: 12364 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub NewBarcode_productEntry()
		End Sub

		' Token: 0x0600304D RID: 12365 RVA: 0x001DBCDC File Offset: 0x001D9EDC
		Private Sub AcceptToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to accept this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			If flag Then
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Me.DGVUserData.Rows.Count > 0
					If flag3 Then
						Try
							For Each obj As Object In Me.DGVUserData.SelectedRows
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim firebaseResponse As FirebaseResponse = Me.client.[Get](Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow.Cells(33).Value)))
								Dim firebaseCRUDData As FirebaseCRUDData = New FirebaseCRUDData()
								firebaseCRUDData = firebaseResponse.ResultAs(Of FirebaseCRUDData)()
								Dim flag4 As Boolean = Operators.CompareString(firebaseCRUDData.Sts, "Accepted", False) = 0
								If flag4 Then
									MessageBox.Show("This record is already been 'Accepted'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Return
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End If
					Dim flag5 As Boolean = Me.DGVUserData.Rows.Count > 0
					If flag5 Then
						Try
							For Each obj2 As Object In Me.DGVUserData.SelectedRows
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim firebaseResponse2 As FirebaseResponse = Me.client.[Get](Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow2.Cells(33).Value)))
								Dim firebaseCRUDData2 As FirebaseCRUDData = New FirebaseCRUDData()
								firebaseCRUDData2 = firebaseResponse2.ResultAs(Of FirebaseCRUDData)()
								Dim flag6 As Boolean = Operators.CompareString(firebaseCRUDData2.Sts, "Rejected", False) = 0
								If flag6 Then
									MessageBox.Show("This record is already been 'Rejected'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Return
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End If
					Try
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim flag7 As Boolean = Me.DGVUserData.Rows.Count > 0
						If flag7 Then
							Try
								For Each obj3 As Object In Me.DGVUserData.SelectedRows
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
									Dim firebaseCRUDData3 As FirebaseCRUDData = New FirebaseCRUDData() With { .PID = Conversions.ToString(dataGridViewRow3.Cells(0).Value), .PCode = Conversions.ToString(dataGridViewRow3.Cells(1).Value), .PName = Conversions.ToString(dataGridViewRow3.Cells(2).Value), .HSN = Conversions.ToString(dataGridViewRow3.Cells(3).Value), .Part = Conversions.ToString(dataGridViewRow3.Cells(4).Value), .Barcode = Conversions.ToString(dataGridViewRow3.Cells(5).Value), .NewBarcode = Conversions.ToString(dataGridViewRow3.Cells(6).Value), .PPrice = Conversions.ToString(dataGridViewRow3.Cells(7).Value), .MRP = Conversions.ToString(dataGridViewRow3.Cells(8).Value), .WPrice = Conversions.ToString(dataGridViewRow3.Cells(9).Value), .RPrice = Conversions.ToString(dataGridViewRow3.Cells(10).Value), .Disc = Conversions.ToString(dataGridViewRow3.Cells(11).Value), .CGST = Conversions.ToString(dataGridViewRow3.Cells(12).Value), .SGST = Conversions.ToString(dataGridViewRow3.Cells(13).Value), .CESS = Conversions.ToString(dataGridViewRow3.Cells(14).Value), .PUnit = Conversions.ToString(dataGridViewRow3.Cells(15).Value), .SUnit = Conversions.ToString(dataGridViewRow3.Cells(16).Value), .Conv = Conversions.ToString(dataGridViewRow3.Cells(17).Value), .SAltUnit = Conversions.ToString(dataGridViewRow3.Cells(18).Value), .STax = Conversions.ToString(dataGridViewRow3.Cells(19).Value), .PTax = Conversions.ToString(dataGridViewRow3.Cells(20).Value), .MinStk = Conversions.ToString(dataGridViewRow3.Cells(21).Value), .Category = Conversions.ToString(dataGridViewRow3.Cells(22).Value), .Colour = Conversions.ToString(dataGridViewRow3.Cells(23).Value), .Size = Conversions.ToString(dataGridViewRow3.Cells(24).Value), .Batch = Conversions.ToString(dataGridViewRow3.Cells(25).Value), .Mfg = Conversions.ToString(dataGridViewRow3.Cells(26).Value), .Exp = Conversions.ToString(dataGridViewRow3.Cells(27).Value), .IMEI1 = Conversions.ToString(dataGridViewRow3.Cells(28).Value), .IMEI2 = Conversions.ToString(dataGridViewRow3.Cells(29).Value), .Qty = Conversions.ToString(dataGridViewRow3.Cells(30).Value), .Sts = "Accepted", .Entrydate = Conversions.ToString(dataGridViewRow3.Cells(32).Value), .CompId = Conversions.ToString(dataGridViewRow3.Cells(33).Value) }
									Try
										For Each obj4 As Object In Me.DGVUserData.SelectedRows
											Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
											SqlConnection.ClearAllPools()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "select (Temp_Stock.Barcode), Temp_Stock.Qty, Temp_Stock.ProductID from Temp_Stock Where Temp_Stock.Barcode=@d1 "
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow4.Cells(5).Value.ToString())
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												Dim num As Integer = Conversions.ToInteger(ModCommonClasses.rdr.GetValue(2))
												Console.WriteLine(num)
												Dim flag9 As Boolean = MessageBox.Show("Same Item found in your record having Barcode : '" + dataGridViewRow4.Cells(5).Value.ToString() + "'" & vbCrLf & "Do you want to add this item's stock ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
												If flag9 Then
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text2 As String = "Update Temp_Stock set Qty=Qty + " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(30).Value))) + " where Barcode=@d2"
													ModCommonClasses.cmd = New SqlCommand(text2)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow4.Cells(5).Value.ToString())
													ModCommonClasses.cmd.ExecuteReader()
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "select ProductID from StockMovement where ProductID=@d1"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.CommandTimeout = 0
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(num))
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag10 As Boolean = Not ModCommonClasses.rdr.Read()
													If flag10 Then
														ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(num))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
													Else
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text4 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
														ModCommonClasses.cmd = New SqlCommand(text4)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(num))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
														Dim num2 As Double
														If flag11 Then
															num2 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
														Else
															num2 = 0.0
														End If
														ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(num))), New Decimal(num2), New Decimal(Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
													End If
													ModFunc.AuditTrial_Master(dataGridViewRow3.Cells(2).Value.ToString(), "Product Entry (Import by Cloud)", Dns.GetHostName(), Me.lblUser.Text, "Add")
													ModFunc.AuditTrial_Inventory(Dns.GetHostName(), Me.lblUser.Text, "Add", "Product Entry (Import by Cloud)", dataGridViewRow3.Cells(1).Value.ToString(), DateAndTime.Today, "Product Entry", dataGridViewRow3.Cells(2).Value.ToString(), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))))
													ModFunc.LogFunc(Me.lblUser.Text, "added the new cloud stock in record having barcode no. '" + dataGridViewRow3.Cells(5).Value.ToString() + "'")
													Dim firebaseResponse3 As FirebaseResponse = Me.client.Update(Of FirebaseCRUDData)(Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow3.Cells(33).Value)), firebaseCRUDData3)
													MessageBox.Show("Stock Accepted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.ShowRecord()
												Else
													Dim flag12 As Boolean = MessageBox.Show("Same Item found in your record having Barcode : '" + dataGridViewRow4.Cells(5).Value.ToString() + "'" & vbCrLf & "Do you really want to add this item with new barcode ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
													If flag12 Then
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text5 As String = "SELECT COUNT(*) FROM SubCategory"
														Dim sqlCommand As SqlCommand = New SqlCommand(text5, ModCommonClasses.con)
														Dim num3 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
														Dim flag13 As Boolean = num3 <= 0
														If flag13 Then
															MessageBox.Show("You have not created Sub Category name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
															ModCommonClasses.con.Close()
															Return
														End If
														Dim flag14 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
														If flag14 Then
															ModCommonClasses.con.Close()
														End If
														SqlConnection.ClearAllPools()
														Me.auto()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text6 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, HSNCode,PartNo, Description, CostPrice, SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status,STax,PTax,GDown,Rack,DefQty,AddDate,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29)"
														ModCommonClasses.cmd = New SqlCommand(text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblProductCode.Text.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(2).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 1)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow3.Cells(3).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(4).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(dataGridViewRow3.Cells(12).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(dataGridViewRow3.Cells(14).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "0")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(15).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(16).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(18).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(21).Value)))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(8).Value)))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d23", "Inclusive")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "Exclusive")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d25", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d29", "")
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text7 As String = "insert into ExtDB1(a1, a2, a3, a4) Values (@d1,@d2,@d3,@d4)"
														ModCommonClasses.cmd = New SqlCommand(text7)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(16).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "1")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "By Product Entry")
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteReader()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text8 As String = "insert into ExtDB1(a1, a2, a3, a4) Values (@d1,@d2,@d3,@d4)"
														ModCommonClasses.cmd = New SqlCommand(text8)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(18).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(17).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "By Product Entry")
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteReader()
														ModCommonClasses.con.Close()
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text9 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
														ModCommonClasses.cmd = New SqlCommand(text9)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(19).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(25).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(26).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(27).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(24).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(23).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(6).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														Dim num4 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))
														Dim num5 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))
														Dim num6 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
														Dim num7 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(13).Value))
														Dim num8 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(14).Value))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num4 * num5 + num4 * num5 * ((num6 + num7 + num8) / 100.0))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(28).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(29).Value.ToString())
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text10 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
														ModCommonClasses.cmd = New SqlCommand(text10)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(6).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(dataGridViewRow3.Cells(21).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(25).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(26).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(27).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(24).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow3.Cells(23).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(28).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(29).Value.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
														Me.Generate_GiftQR(dataGridViewRow3.Cells(6).Value.ToString())
														Dim memoryStream As MemoryStream = New MemoryStream()
														Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
														bitmap.Save(memoryStream, ImageFormat.Jpeg)
														Dim buffer As Byte() = memoryStream.GetBuffer()
														Dim sqlParameter As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
														sqlParameter.Value = buffer
														ModCommonClasses.cmd.Parameters.Add(sqlParameter)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														SqlConnection.ClearAllPools()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text11 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(Me.lblID.Text)) + ",@img)"
														ModCommonClasses.cmd = New SqlCommand(text11)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														Dim memoryStream2 As MemoryStream = New MemoryStream()
														Dim bitmap2 As Bitmap = New Bitmap(Resources._12)
														bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
														Dim buffer2 As Byte() = memoryStream2.GetBuffer()
														Dim sqlParameter2 As SqlParameter = New SqlParameter("@img", SqlDbType.Image)
														sqlParameter2.Value = buffer2
														ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text12 As String = "select ProductID from StockMovement where ProductID=@d1"
														ModCommonClasses.cmd = New SqlCommand(text12)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.CommandTimeout = 0
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag15 As Boolean = Not ModCommonClasses.rdr.Read()
														If flag15 Then
															ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblID.Text))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
														Else
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text13 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
															ModCommonClasses.cmd = New SqlCommand(text13)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
															ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
															ModCommonClasses.cmd.CommandTimeout = 0
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
															Dim num9 As Double
															If flag16 Then
																num9 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
															Else
																num9 = 0.0
															End If
															ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblID.Text))), New Decimal(num9), New Decimal(Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
														End If
														ModFunc.AuditTrial_Master(dataGridViewRow3.Cells(2).Value.ToString(), "Product Entry (Import by Cloud)", Dns.GetHostName(), Me.lblUser.Text, "Add")
														ModFunc.AuditTrial_Inventory(Dns.GetHostName(), Me.lblUser.Text, "Add", "Product Entry (Import by Cloud)", dataGridViewRow3.Cells(1).Value.ToString(), DateAndTime.Today, "Product Entry", dataGridViewRow3.Cells(2).Value.ToString(), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))))
														ModFunc.LogFunc(Me.lblUser.Text, "added the new cloud stock in record having barcode no. '" + dataGridViewRow3.Cells(6).Value.ToString() + "'")
														Dim firebaseResponse4 As FirebaseResponse = Me.client.Update(Of FirebaseCRUDData)(Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow3.Cells(33).Value)), firebaseCRUDData3)
														MessageBox.Show("Stock Accepted Successfully (With New Barcode)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.ShowRecord()
													End If
												End If
												Dim flag17 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag17 Then
													ModCommonClasses.rdr.Close()
												End If
												ModCommonClasses.con.Close()
												Return
											End If
										Next
									Finally
										Dim enumerator4 As IEnumerator
										If TypeOf enumerator4 Is IDisposable Then
											TryCast(enumerator4, IDisposable).Dispose()
										End If
									End Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text14 As String = "SELECT COUNT(*) FROM SubCategory"
									Dim sqlCommand2 As SqlCommand = New SqlCommand(text14, ModCommonClasses.con)
									Dim num10 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar()))
									Dim flag18 As Boolean = num10 <= 0
									If flag18 Then
										MessageBox.Show("You have not created Sub Category name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										ModCommonClasses.con.Close()
										Return
									End If
									Dim flag19 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
									If flag19 Then
										ModCommonClasses.con.Close()
									End If
									SqlConnection.ClearAllPools()
									Me.auto()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text15 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, HSNCode,PartNo, Description, CostPrice, SellingPrice, Discount,CGST,SGST,CESS, ReorderPoint,OpeningStock,Barcode,PurchaseUnit,SalesUnit,SalesAltUnit,Conv,MinStock,MRP,Status,STax,PTax,GDown,Rack,DefQty,AddDate,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29)"
									ModCommonClasses.cmd = New SqlCommand(text15)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.lblID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblProductCode.Text.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(2).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 1)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow3.Cells(3).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(4).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(dataGridViewRow3.Cells(12).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(dataGridViewRow3.Cells(13).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(dataGridViewRow3.Cells(14).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "0")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(15).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(16).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(18).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(21).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(8).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d23", "Inclusive")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "Exclusive")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d25", "")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d27", "1")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d28", DateTime.Today)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d29", "")
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text16 As String = "insert into ExtDB1(a1, a2, a3, a4) Values (@d1,@d2,@d3,@d4)"
									ModCommonClasses.cmd = New SqlCommand(text16)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(16).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", "1")
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "By Product Entry")
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text17 As String = "insert into ExtDB1(a1, a2, a3, a4) Values (@d1,@d2,@d3,@d4)"
									ModCommonClasses.cmd = New SqlCommand(text17)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(18).Value.ToString())
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(17).Value.ToString()))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "By Product Entry")
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text18 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text18)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow3.Cells(5).Value.ToString())
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag20 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag20 Then
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text19 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
										ModCommonClasses.cmd = New SqlCommand(text19)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(19).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(25).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(26).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(27).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(24).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(23).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
										Dim num11 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))
										Dim num12 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))
										Dim num13 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(12).Value))
										Dim num14 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(13).Value))
										Dim num15 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(14).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num11 * num12 + num11 * num12 * ((num13 + num14 + num15) / 100.0))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(28).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(29).Value.ToString())
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text20 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice,QrBarcode,SalesManPur) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
										ModCommonClasses.cmd = New SqlCommand(text20)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(10).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(9).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(dataGridViewRow3.Cells(21).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(8).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(25).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(26).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(27).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(24).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow3.Cells(23).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(28).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(29).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow3.Cells(7).Value.ToString()))
										Me.Generate_GiftQR(dataGridViewRow3.Cells(5).Value.ToString())
										Dim memoryStream3 As MemoryStream = New MemoryStream()
										Dim bitmap3 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
										bitmap3.Save(memoryStream3, ImageFormat.Jpeg)
										Dim buffer3 As Byte() = memoryStream3.GetBuffer()
										Dim sqlParameter3 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
										sqlParameter3.Value = buffer3
										ModCommonClasses.cmd.Parameters.Add(sqlParameter3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d21", 0.0)
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text21 As String = "insert into Product_Join(ProductID,Photo) VALUES (" + Conversions.ToString(Conversion.Val(Me.lblID.Text)) + ",@img)"
										ModCommonClasses.cmd = New SqlCommand(text21)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										Dim memoryStream4 As MemoryStream = New MemoryStream()
										Dim bitmap4 As Bitmap = New Bitmap(Resources._12)
										bitmap4.Save(memoryStream4, ImageFormat.Jpeg)
										Dim buffer4 As Byte() = memoryStream4.GetBuffer()
										Dim sqlParameter4 As SqlParameter = New SqlParameter("@img", SqlDbType.Image)
										sqlParameter4.Value = buffer4
										ModCommonClasses.cmd.Parameters.Add(sqlParameter4)
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text22 As String = "select ProductID from StockMovement where ProductID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text22)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag21 As Boolean = Not ModCommonClasses.rdr.Read()
										If flag21 Then
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblID.Text))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text23 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
											ModCommonClasses.cmd = New SqlCommand(text23)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.lblID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", DateAndTime.Today)
											ModCommonClasses.cmd.CommandTimeout = 0
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag22 As Boolean = ModCommonClasses.rdr.Read()
											Dim num16 As Double
											If flag22 Then
												num16 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
											Else
												num16 = 0.0
											End If
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.lblID.Text))), New Decimal(num16), New Decimal(Conversion.Val(dataGridViewRow3.Cells(30).Value.ToString())), 0D, DateAndTime.Today, dataGridViewRow3.Cells(1).Value.ToString())
										End If
										ModFunc.AuditTrial_Master(dataGridViewRow3.Cells(2).Value.ToString(), "Product Entry (Import by Cloud)", Dns.GetHostName(), Me.lblUser.Text, "Add")
										ModFunc.AuditTrial_Inventory(Dns.GetHostName(), Me.lblUser.Text, "Add", "Product Entry (Import by Cloud)", dataGridViewRow3.Cells(1).Value.ToString(), DateAndTime.Today, "Product Entry", dataGridViewRow3.Cells(2).Value.ToString(), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(30).Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(7).Value))))
										ModFunc.LogFunc(Me.lblUser.Text, "added the new cloud stock in record having barcode no. '" + dataGridViewRow3.Cells(5).Value.ToString() + "'")
										Dim firebaseResponse5 As FirebaseResponse = Me.client.Update(Of FirebaseCRUDData)(Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow3.Cells(33).Value)), firebaseCRUDData3)
										MessageBox.Show("Stock Accepted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.ShowRecord()
									End If
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						End If
						Me.btnGetData.PerformClick()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
					Try
						Me.DGVUserData.Columns(33).Visible = False
					Catch ex2 As Exception
					End Try
					Dim num17 As Integer = Me.DGVUserData.RowCount - 1
					For i As Integer = 0 To num17
						Try
							Me.dtTableGrd.DefaultView.RowFilter = ""
							TryCast(Me.DGVUserData.DataSource, DataTable).DefaultView.RowFilter = String.Concat(New String() { "[Entry Date] >= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(0.0), "yyyy/MM/dd"), "' AND [Entry Date] <= '", Strings.Format(Conversions.ToDate("1900/01/01").AddDays(1.0), "yyyy/MM/dd"), "'" })
						Catch ex3 As Exception
						End Try
					Next
					Dim num18 As Integer = Me.DGVUserData.RowCount - 1
					For j As Integer = 0 To num18
						Me.DGVUserData.Sort(Me.DGVUserData.Columns(32), ListSortDirection.Descending)
						Dim flag23 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Accepted", False) = 0
						If flag23 Then
							Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.Lime
						End If
						Dim flag24 As Boolean = Operators.CompareString(Me.DGVUserData.Rows(j).Cells(31).Value.ToString(), "Rejected", False) = 0
						If flag24 Then
							Me.DGVUserData.Rows(j).DefaultCellStyle.BackColor = Color.OrangeRed
						End If
					Next
					Me.DGVUserData.ClearSelection()
				End If
			End If
		End Sub

		' Token: 0x0600304E RID: 12366 RVA: 0x001DF6EC File Offset: 0x001DD8EC
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600304F RID: 12367 RVA: 0x001DF770 File Offset: 0x001DD970
		Private Sub RejectToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to reject this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			If flag Then
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Me.DGVUserData.Rows.Count > 0
					If flag3 Then
						Try
							For Each obj As Object In Me.DGVUserData.SelectedRows
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim firebaseResponse As FirebaseResponse = Me.client.[Get](Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow.Cells(33).Value)))
								Dim firebaseCRUDData As FirebaseCRUDData = New FirebaseCRUDData()
								firebaseCRUDData = firebaseResponse.ResultAs(Of FirebaseCRUDData)()
								Dim flag4 As Boolean = Operators.CompareString(firebaseCRUDData.Sts, "Accepted", False) = 0
								If flag4 Then
									MessageBox.Show("This record is already been 'Accepted'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Return
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End If
					Dim flag5 As Boolean = Me.DGVUserData.Rows.Count > 0
					If flag5 Then
						Try
							For Each obj2 As Object In Me.DGVUserData.SelectedRows
								Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
								Dim firebaseResponse2 As FirebaseResponse = Me.client.[Get](Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow2.Cells(33).Value)))
								Dim firebaseCRUDData2 As FirebaseCRUDData = New FirebaseCRUDData()
								firebaseCRUDData2 = firebaseResponse2.ResultAs(Of FirebaseCRUDData)()
								Dim flag6 As Boolean = Operators.CompareString(firebaseCRUDData2.Sts, "Rejected", False) = 0
								If flag6 Then
									MessageBox.Show("This record is already been 'Rejected'", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Return
								End If
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End If
					Try
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						Dim flag7 As Boolean = Me.DGVUserData.Rows.Count > 0
						If flag7 Then
							Try
								For Each obj3 As Object In Me.DGVUserData.SelectedRows
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
									Dim firebaseCRUDData3 As FirebaseCRUDData = New FirebaseCRUDData() With { .PID = Conversions.ToString(dataGridViewRow3.Cells(0).Value), .PCode = Conversions.ToString(dataGridViewRow3.Cells(1).Value), .PName = Conversions.ToString(dataGridViewRow3.Cells(2).Value), .HSN = Conversions.ToString(dataGridViewRow3.Cells(3).Value), .Part = Conversions.ToString(dataGridViewRow3.Cells(4).Value), .Barcode = Conversions.ToString(dataGridViewRow3.Cells(5).Value), .NewBarcode = Conversions.ToString(dataGridViewRow3.Cells(6).Value), .PPrice = Conversions.ToString(dataGridViewRow3.Cells(7).Value), .MRP = Conversions.ToString(dataGridViewRow3.Cells(8).Value), .WPrice = Conversions.ToString(dataGridViewRow3.Cells(9).Value), .RPrice = Conversions.ToString(dataGridViewRow3.Cells(10).Value), .Disc = Conversions.ToString(dataGridViewRow3.Cells(11).Value), .CGST = Conversions.ToString(dataGridViewRow3.Cells(12).Value), .SGST = Conversions.ToString(dataGridViewRow3.Cells(13).Value), .CESS = Conversions.ToString(dataGridViewRow3.Cells(14).Value), .PUnit = Conversions.ToString(dataGridViewRow3.Cells(15).Value), .SUnit = Conversions.ToString(dataGridViewRow3.Cells(16).Value), .Conv = Conversions.ToString(dataGridViewRow3.Cells(17).Value), .SAltUnit = Conversions.ToString(dataGridViewRow3.Cells(18).Value), .STax = Conversions.ToString(dataGridViewRow3.Cells(19).Value), .PTax = Conversions.ToString(dataGridViewRow3.Cells(20).Value), .MinStk = Conversions.ToString(dataGridViewRow3.Cells(21).Value), .Category = Conversions.ToString(dataGridViewRow3.Cells(22).Value), .Colour = Conversions.ToString(dataGridViewRow3.Cells(23).Value), .Size = Conversions.ToString(dataGridViewRow3.Cells(24).Value), .Batch = Conversions.ToString(dataGridViewRow3.Cells(25).Value), .Mfg = Conversions.ToString(dataGridViewRow3.Cells(26).Value), .Exp = Conversions.ToString(dataGridViewRow3.Cells(27).Value), .IMEI1 = Conversions.ToString(dataGridViewRow3.Cells(28).Value), .IMEI2 = Conversions.ToString(dataGridViewRow3.Cells(29).Value), .Qty = Conversions.ToString(dataGridViewRow3.Cells(30).Value), .Sts = "Rejected", .Entrydate = Conversions.ToString(dataGridViewRow3.Cells(32).Value), .CompId = Conversions.ToString(dataGridViewRow3.Cells(33).Value) }
									Dim firebaseResponse3 As FirebaseResponse = Me.client.Update(Of FirebaseCRUDData)(Conversions.ToString(Operators.AddObject(Me.lblCompID.Text + "/", dataGridViewRow3.Cells(33).Value)), firebaseCRUDData3)
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
							MessageBox.Show("Stock Rejected Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.ShowRecord()
							Me.DGVUserData.ClearSelection()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06003050 RID: 12368 RVA: 0x001DFF20 File Offset: 0x001DE120
		Private Sub btnExportExcel_ClickButtonArea(Sender As Object, e As MouseEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.DGVUserData.Columns.Count = 0) Or (Me.DGVUserData.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DGVUserData.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							Dim visible As Boolean = dataGridViewColumn.Visible
							If visible Then
								dataTable.Columns.Add(dataGridViewColumn.HeaderText)
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.DGVUserData.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim dataRow As DataRow = dataTable.Rows.Add(New Object(-1) {})
							Dim num As Integer = 0
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									Dim visible2 As Boolean = Me.DGVUserData.Columns(dataGridViewCell.ColumnIndex).Visible
									If visible2 Then
										Dim dataRow2 As DataRow = dataRow
										Dim num2 As Integer = num
										Dim value As Object = dataGridViewCell.Value
										dataRow2(num2) = If((value IsNot Nothing), value.ToString(), Nothing)
										num += 1
									End If
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
						Dim ixlworksheet As IXLWorksheet = xlworkbook.Worksheets.Add(dataTable, "Export File")
						Try
							For Each ixlcolumn As IXLColumn In ixlworksheet.Columns()
								ixlcolumn.AdjustToContents()
							Next
						Finally
							Dim enumerator4 As IEnumerator(Of IXLColumn)
							If enumerator4 IsNot Nothing Then
								enumerator4.Dispose()
							End If
						End Try
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003051 RID: 12369 RVA: 0x001E024C File Offset: 0x001DE44C
		Private Sub CopyBranchIDToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DGVUserData.Rows.Count > 0
			If flag Then
				Try
					For Each obj As Object In Me.DGVUserData.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Clipboard.SetDataObject(dataGridViewRow.Cells(34).Value.ToString())
						MessageBox.Show("Branch ID Copied Successfully" & vbCrLf, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
		End Sub

		' Token: 0x040014A5 RID: 5285
		Private client As IFirebaseClient

		' Token: 0x040014A6 RID: 5286
		Private RealtimeDatabasePath As String

		' Token: 0x040014A7 RID: 5287
		Private EmailSecretKey As String

		' Token: 0x040014A8 RID: 5288
		Private DateTimeFormat As String

		' Token: 0x040014A9 RID: 5289
		Private clearDGVCol As Boolean

		' Token: 0x040014AA RID: 5290
		Private dtTableGrd As DataTable

		' Token: 0x040014AB RID: 5291
		Public Shared selectedIndex As Integer = 0
	End Class
End Namespace
