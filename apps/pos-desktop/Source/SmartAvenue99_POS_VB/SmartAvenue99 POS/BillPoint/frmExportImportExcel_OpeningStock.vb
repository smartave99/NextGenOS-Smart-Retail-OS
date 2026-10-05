Imports System
Imports System.Collections
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
Imports ClosedXML.Excel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200010E RID: 270
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_OpeningStock
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002C6D RID: 11373 RVA: 0x0001C4F9 File Offset: 0x0001A6F9
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_OpeningStock_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_OpeningStock_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001147 RID: 4423
		' (get) Token: 0x06002C70 RID: 11376 RVA: 0x0001C52B File Offset: 0x0001A72B
		' (set) Token: 0x06002C71 RID: 11377 RVA: 0x0001C535 File Offset: 0x0001A735
		Friend Overridable Property Label1 As Label

		' Token: 0x17001148 RID: 4424
		' (get) Token: 0x06002C72 RID: 11378 RVA: 0x0001C53E File Offset: 0x0001A73E
		' (set) Token: 0x06002C73 RID: 11379 RVA: 0x0001C548 File Offset: 0x0001A748
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17001149 RID: 4425
		' (get) Token: 0x06002C74 RID: 11380 RVA: 0x0001C551 File Offset: 0x0001A751
		' (set) Token: 0x06002C75 RID: 11381 RVA: 0x001B9514 File Offset: 0x001B7714
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700114A RID: 4426
		' (get) Token: 0x06002C76 RID: 11382 RVA: 0x0001C55B File Offset: 0x0001A75B
		' (set) Token: 0x06002C77 RID: 11383 RVA: 0x001B9558 File Offset: 0x001B7758
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

		' Token: 0x1700114B RID: 4427
		' (get) Token: 0x06002C78 RID: 11384 RVA: 0x0001C565 File Offset: 0x0001A765
		' (set) Token: 0x06002C79 RID: 11385 RVA: 0x001B959C File Offset: 0x001B779C
		Private _btnSave As Button
		Friend Overridable Property btnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSave = value
				button = Me._btnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700114C RID: 4428
		' (get) Token: 0x06002C7A RID: 11386 RVA: 0x0001C56F File Offset: 0x0001A76F
		' (set) Token: 0x06002C7B RID: 11387 RVA: 0x001B95E0 File Offset: 0x001B77E0
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

		' Token: 0x1700114D RID: 4429
		' (get) Token: 0x06002C7C RID: 11388 RVA: 0x0001C579 File Offset: 0x0001A779
		' (set) Token: 0x06002C7D RID: 11389 RVA: 0x001B9624 File Offset: 0x001B7824
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

		' Token: 0x1700114E RID: 4430
		' (get) Token: 0x06002C7E RID: 11390 RVA: 0x0001C583 File Offset: 0x0001A783
		' (set) Token: 0x06002C7F RID: 11391 RVA: 0x001B9668 File Offset: 0x001B7868
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

		' Token: 0x1700114F RID: 4431
		' (get) Token: 0x06002C80 RID: 11392 RVA: 0x0001C58D File Offset: 0x0001A78D
		' (set) Token: 0x06002C81 RID: 11393 RVA: 0x001B96AC File Offset: 0x001B78AC
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

		' Token: 0x17001150 RID: 4432
		' (get) Token: 0x06002C82 RID: 11394 RVA: 0x0001C597 File Offset: 0x0001A797
		' (set) Token: 0x06002C83 RID: 11395 RVA: 0x0001C5A1 File Offset: 0x0001A7A1
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17001151 RID: 4433
		' (get) Token: 0x06002C84 RID: 11396 RVA: 0x0001C5AA File Offset: 0x0001A7AA
		' (set) Token: 0x06002C85 RID: 11397 RVA: 0x001B96F0 File Offset: 0x001B78F0
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

		' Token: 0x17001152 RID: 4434
		' (get) Token: 0x06002C86 RID: 11398 RVA: 0x0001C5B4 File Offset: 0x0001A7B4
		' (set) Token: 0x06002C87 RID: 11399 RVA: 0x0001C5BE File Offset: 0x0001A7BE
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x17001153 RID: 4435
		' (get) Token: 0x06002C88 RID: 11400 RVA: 0x0001C5C7 File Offset: 0x0001A7C7
		' (set) Token: 0x06002C89 RID: 11401 RVA: 0x0001C5D1 File Offset: 0x0001A7D1
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17001154 RID: 4436
		' (get) Token: 0x06002C8A RID: 11402 RVA: 0x0001C5DA File Offset: 0x0001A7DA
		' (set) Token: 0x06002C8B RID: 11403 RVA: 0x0001C5E4 File Offset: 0x0001A7E4
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17001155 RID: 4437
		' (get) Token: 0x06002C8C RID: 11404 RVA: 0x0001C5ED File Offset: 0x0001A7ED
		' (set) Token: 0x06002C8D RID: 11405 RVA: 0x0001C5F7 File Offset: 0x0001A7F7
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17001156 RID: 4438
		' (get) Token: 0x06002C8E RID: 11406 RVA: 0x0001C600 File Offset: 0x0001A800
		' (set) Token: 0x06002C8F RID: 11407 RVA: 0x0001C60A File Offset: 0x0001A80A
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17001157 RID: 4439
		' (get) Token: 0x06002C90 RID: 11408 RVA: 0x0001C613 File Offset: 0x0001A813
		' (set) Token: 0x06002C91 RID: 11409 RVA: 0x0001C61D File Offset: 0x0001A81D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17001158 RID: 4440
		' (get) Token: 0x06002C92 RID: 11410 RVA: 0x0001C626 File Offset: 0x0001A826
		' (set) Token: 0x06002C93 RID: 11411 RVA: 0x0001C630 File Offset: 0x0001A830
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17001159 RID: 4441
		' (get) Token: 0x06002C94 RID: 11412 RVA: 0x0001C639 File Offset: 0x0001A839
		' (set) Token: 0x06002C95 RID: 11413 RVA: 0x0001C643 File Offset: 0x0001A843
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700115A RID: 4442
		' (get) Token: 0x06002C96 RID: 11414 RVA: 0x0001C64C File Offset: 0x0001A84C
		' (set) Token: 0x06002C97 RID: 11415 RVA: 0x0001C656 File Offset: 0x0001A856
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x1700115B RID: 4443
		' (get) Token: 0x06002C98 RID: 11416 RVA: 0x0001C65F File Offset: 0x0001A85F
		' (set) Token: 0x06002C99 RID: 11417 RVA: 0x0001C669 File Offset: 0x0001A869
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700115C RID: 4444
		' (get) Token: 0x06002C9A RID: 11418 RVA: 0x0001C672 File Offset: 0x0001A872
		' (set) Token: 0x06002C9B RID: 11419 RVA: 0x0001C67C File Offset: 0x0001A87C
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x1700115D RID: 4445
		' (get) Token: 0x06002C9C RID: 11420 RVA: 0x0001C685 File Offset: 0x0001A885
		' (set) Token: 0x06002C9D RID: 11421 RVA: 0x0001C68F File Offset: 0x0001A88F
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x1700115E RID: 4446
		' (get) Token: 0x06002C9E RID: 11422 RVA: 0x0001C698 File Offset: 0x0001A898
		' (set) Token: 0x06002C9F RID: 11423 RVA: 0x0001C6A2 File Offset: 0x0001A8A2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700115F RID: 4447
		' (get) Token: 0x06002CA0 RID: 11424 RVA: 0x0001C6AB File Offset: 0x0001A8AB
		' (set) Token: 0x06002CA1 RID: 11425 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17001160 RID: 4448
		' (get) Token: 0x06002CA2 RID: 11426 RVA: 0x0001C6BE File Offset: 0x0001A8BE
		' (set) Token: 0x06002CA3 RID: 11427 RVA: 0x0001C6C8 File Offset: 0x0001A8C8
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x06002CA4 RID: 11428 RVA: 0x001B9734 File Offset: 0x001B7934
		Private Sub frmExportImportExcel_OpeningStock_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x06002CA5 RID: 11429 RVA: 0x001B9824 File Offset: 0x001B7A24
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

		' Token: 0x06002CA6 RID: 11430 RVA: 0x001B990C File Offset: 0x001B7B0C
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

		' Token: 0x06002CA7 RID: 11431 RVA: 0x001B99F4 File Offset: 0x001B7BF4
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Product_OpeningStock.ProductID, (Product_OpeningStock.Qty),(Product_OpeningStock.MRP),(Product_OpeningStock.SalePrice),(Product_OpeningStock.WSalePrice),RTRIM(Product_OpeningStock.Batch),RTRIM(Product_OpeningStock.Mfgdate),RTRIM(Product_OpeningStock.Expdate),RTRIM(Product_OpeningStock.Size),RTRIM(Product_OpeningStock.Colour),RTRIM(Product_OpeningStock.Barcode),(Product_OpeningStock.PPRice),RTRIM(Product_OpeningStock.IMEI1),RTRIM(Product_OpeningStock.IMEI2) from Product_OpeningStock order by ProductID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002CA8 RID: 11432 RVA: 0x001B9BD4 File Offset: 0x001B7DD4
		Private Sub btnImportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Sheet1$]", oleDbConnection)
					oleDbConnection.Open()
					Dim dataSet As DataSet = New DataSet()
					oleDbDataAdapter.Fill(dataSet)
					Me.DataGridView1.Visible = True
					Me.DataGridView1.DataSource = dataSet.Tables(0)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002CA9 RID: 11433 RVA: 0x0001C6D1 File Offset: 0x0001A8D1
		Public Sub Reset()
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.Getdata()
		End Sub

		' Token: 0x06002CAA RID: 11434 RVA: 0x0001C6F5 File Offset: 0x0001A8F5
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002CAB RID: 11435 RVA: 0x0001C6FF File Offset: 0x0001A8FF
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06002CAC RID: 11436 RVA: 0x001B9CD8 File Offset: 0x001B7ED8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Me.DataGridView1.RowCount = 0
				If flag3 Then
					MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim num As Integer = Me.DataGridView1.RowCount - 1
					For i As Integer = 0 To num
						Dim flag4 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(i).Cells(0).Value.ToString(), "", False) = 0
						If flag4 Then
							MessageBox.Show("ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num2 As Integer = Me.DataGridView1.RowCount - 1
					For j As Integer = 0 To num2
						Dim flag5 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(j).Cells(1).Value.ToString(), "", False) = 0
						If flag5 Then
							MessageBox.Show("Opening Qty Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num3 As Integer = Me.DataGridView1.RowCount - 1
					For k As Integer = 0 To num3
						Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(k).Cells(2).Value.ToString(), "", False) = 0
						If flag6 Then
							MessageBox.Show("MRP Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num4 As Integer = Me.DataGridView1.RowCount - 1
					For l As Integer = 0 To num4
						Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(l).Cells(3).Value.ToString(), "", False) = 0
						If flag7 Then
							MessageBox.Show("Sale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num5 As Integer = Me.DataGridView1.RowCount - 1
					For m As Integer = 0 To num5
						Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(m).Cells(4).Value.ToString(), "", False) = 0
						If flag8 Then
							MessageBox.Show("Wholesale Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num6 As Integer = Me.DataGridView1.RowCount - 1
					For n As Integer = 0 To num6
						Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(n).Cells(10).Value.ToString(), "", False) = 0
						If flag9 Then
							MessageBox.Show("Barcode Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num7 As Integer = Me.DataGridView1.RowCount - 1
					For num8 As Integer = 0 To num7
						Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num8).Cells(11).Value.ToString(), "", False) = 0
						If flag10 Then
							MessageBox.Show("Purchase Price Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Return
						End If
					Next
					Dim num9 As Integer = Me.DataGridView1.RowCount - 1
					For num10 As Integer = 0 To num9
						Dim num11 As Integer = num10 + 1
						Dim num12 As Integer = Me.DataGridView1.RowCount - 1
						For num13 As Integer = num11 To num12
							Dim flag11 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num10).Cells(10).Value.ToString(), Me.DataGridView1.Rows(num13).Cells(10).Value.ToString(), False) = 0
							If flag11 Then
								MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject("Duplicate Barcode Number found ", Me.DataGridView1.Rows(num10).Cells(10).Value)))
								Return
							End If
						Next
					Next
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag12 As Boolean = Not dataGridViewRow.IsNewRow
							If flag12 Then
								SqlConnection.ClearAllPools()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select Barcode from Product_OpeningStock Where Barcode=@d1"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(10).Value.ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
								If flag13 Then
									MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Barcode '", dataGridViewRow.Cells(10).Value), "' Already Exists")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag14 Then
										ModCommonClasses.rdr.Close()
									End If
									ModCommonClasses.con.Close()
									Return
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag15 As Boolean = Not dataGridViewRow2.IsNewRow
							If flag15 Then
								SqlConnection.ClearAllPools()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells(10).Value.ToString())
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
								If flag16 Then
									MessageBox.Show("Barcode '" + dataGridViewRow2.Cells(10).Value.ToString() + "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag17 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag17 Then
										ModCommonClasses.rdr.Close()
									End If
									ModCommonClasses.con.Close()
									Return
								End If
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
							Dim flag18 As Boolean = Not dataGridViewRow3.IsNewRow
							If flag18 Then
								Dim flag19 As Boolean = (Operators.CompareString(dataGridViewRow3.Cells(10).Value.ToString(), "", False) <> 0) And (Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString()) > 0.0)
								If flag19 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "Select Barcode from Product_OpeningStock where Barcode=@d1"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(10).Value))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.CommandTimeout = 0
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag20 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag20 Then
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text5 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
										ModCommonClasses.cmd = New SqlCommand(text5)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow3.Cells(2).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(3).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(4).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(6).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(7).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(8).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(10).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
										Dim num14 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(11).Value))
										Dim num15 As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(1).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", num14 * num15)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(12).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(13).Value.ToString())
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text6 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,SPrice,WPrice,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)"
										ModCommonClasses.cmd = New SqlCommand(text6)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(dataGridViewRow3.Cells(0).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(10).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(dataGridViewRow3.Cells(3).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow3.Cells(4).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "0")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow3.Cells(2).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(6).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(7).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow3.Cells(8).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow3.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Opening Stock")
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(12).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(13).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow3.Cells(11).Value.ToString()))
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text7 As String = "select ProductID from StockMovement where ProductID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text7)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.CommandTimeout = 0
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag21 As Boolean = Not ModCommonClasses.rdr.Read()
										If flag21 Then
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(1).Value))), 0D, DateAndTime.Today, "OP-" + dataGridViewRow3.Cells(0).Value.ToString())
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text8 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
											ModCommonClasses.cmd = New SqlCommand(text8)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
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
											ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num16), New Decimal(Conversion.Val(dataGridViewRow3.Cells(1).Value.ToString())), 0D, DateAndTime.Today, "OP-" + dataGridViewRow3.Cells(0).Value.ToString())
										End If
									End If
								End If
							End If
						Next
					Finally
						Dim enumerator3 As IEnumerator
						If TypeOf enumerator3 Is IDisposable Then
							TryCast(enumerator3, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.DataGridView1.DataSource = Nothing
					Me.Reset()
				End If
			End If
		End Sub

		' Token: 0x06002CAD RID: 11437 RVA: 0x001BB02C File Offset: 0x001B922C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002CAE RID: 11438 RVA: 0x001BB2D8 File Offset: 0x001B94D8
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				File.WriteAllBytes(selectedPath + "\OPStock_Format.xls", Resources.OPStock_Format)
				Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\OPStock_Format.xls")
				If flag2 Then
					File.Delete(selectedPath + "\OPStock_Format.xls")
					File.WriteAllBytes(selectedPath + "\OPStock_Format.xls", Resources.OPStock_Format)
					MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06002CAF RID: 11439 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExportImportExcel_OpeningStock_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
