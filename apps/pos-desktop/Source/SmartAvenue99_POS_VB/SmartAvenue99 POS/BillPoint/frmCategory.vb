Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports OpenQA.Selenium

Namespace BillPoint
	' Token: 0x020005E1 RID: 1505
	<DesignerGenerated()>
	Public Partial Class frmCategory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060127CB RID: 75723 RVA: 0x00AA3E9C File Offset: 0x00AA209C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmcategory_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCategory_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCategory_Closing
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.password = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x170072BB RID: 29371
		' (get) Token: 0x060127CE RID: 75726 RVA: 0x0007ED43 File Offset: 0x0007CF43
		' (set) Token: 0x060127CF RID: 75727 RVA: 0x0007ED4D File Offset: 0x0007CF4D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170072BC RID: 29372
		' (get) Token: 0x060127D0 RID: 75728 RVA: 0x0007ED56 File Offset: 0x0007CF56
		' (set) Token: 0x060127D1 RID: 75729 RVA: 0x00AA58C4 File Offset: 0x00AA3AC4
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072BD RID: 29373
		' (get) Token: 0x060127D2 RID: 75730 RVA: 0x0007ED60 File Offset: 0x0007CF60
		' (set) Token: 0x060127D3 RID: 75731 RVA: 0x0007ED6A File Offset: 0x0007CF6A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170072BE RID: 29374
		' (get) Token: 0x060127D4 RID: 75732 RVA: 0x0007ED73 File Offset: 0x0007CF73
		' (set) Token: 0x060127D5 RID: 75733 RVA: 0x0007ED7D File Offset: 0x0007CF7D
		Friend Overridable Property Label1 As Label

		' Token: 0x170072BF RID: 29375
		' (get) Token: 0x060127D6 RID: 75734 RVA: 0x0007ED86 File Offset: 0x0007CF86
		' (set) Token: 0x060127D7 RID: 75735 RVA: 0x0007ED90 File Offset: 0x0007CF90
		Friend Overridable Property txtCategoryName As TextBox

		' Token: 0x170072C0 RID: 29376
		' (get) Token: 0x060127D8 RID: 75736 RVA: 0x0007ED99 File Offset: 0x0007CF99
		' (set) Token: 0x060127D9 RID: 75737 RVA: 0x0007EDA3 File Offset: 0x0007CFA3
		Friend Overridable Property lblUser As Label

		' Token: 0x170072C1 RID: 29377
		' (get) Token: 0x060127DA RID: 75738 RVA: 0x0007EDAC File Offset: 0x0007CFAC
		' (set) Token: 0x060127DB RID: 75739 RVA: 0x00AA5924 File Offset: 0x00AA3B24
		Private _cmbCategory As ComboBox
		Friend Overridable Property cmbCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170072C2 RID: 29378
		' (get) Token: 0x060127DC RID: 75740 RVA: 0x0007EDB6 File Offset: 0x0007CFB6
		' (set) Token: 0x060127DD RID: 75741 RVA: 0x00AA5984 File Offset: 0x00AA3B84
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

		' Token: 0x170072C3 RID: 29379
		' (get) Token: 0x060127DE RID: 75742 RVA: 0x0007EDC0 File Offset: 0x0007CFC0
		' (set) Token: 0x060127DF RID: 75743 RVA: 0x0007EDCA File Offset: 0x0007CFCA
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170072C4 RID: 29380
		' (get) Token: 0x060127E0 RID: 75744 RVA: 0x0007EDD3 File Offset: 0x0007CFD3
		' (set) Token: 0x060127E1 RID: 75745 RVA: 0x0007EDDD File Offset: 0x0007CFDD
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170072C5 RID: 29381
		' (get) Token: 0x060127E2 RID: 75746 RVA: 0x0007EDE6 File Offset: 0x0007CFE6
		' (set) Token: 0x060127E3 RID: 75747 RVA: 0x0007EDF0 File Offset: 0x0007CFF0
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170072C6 RID: 29382
		' (get) Token: 0x060127E4 RID: 75748 RVA: 0x0007EDF9 File Offset: 0x0007CFF9
		' (set) Token: 0x060127E5 RID: 75749 RVA: 0x0007EE03 File Offset: 0x0007D003
		Friend Overridable Property BackgroundWorker1 As BackgroundWorker

		' Token: 0x170072C7 RID: 29383
		' (get) Token: 0x060127E6 RID: 75750 RVA: 0x0007EE0C File Offset: 0x0007D00C
		' (set) Token: 0x060127E7 RID: 75751 RVA: 0x0007EE16 File Offset: 0x0007D016
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170072C8 RID: 29384
		' (get) Token: 0x060127E8 RID: 75752 RVA: 0x0007EE1F File Offset: 0x0007D01F
		' (set) Token: 0x060127E9 RID: 75753 RVA: 0x00AA59C8 File Offset: 0x00AA3BC8
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

		' Token: 0x170072C9 RID: 29385
		' (get) Token: 0x060127EA RID: 75754 RVA: 0x0007EE29 File Offset: 0x0007D029
		' (set) Token: 0x060127EB RID: 75755 RVA: 0x00AA5A0C File Offset: 0x00AA3C0C
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072CA RID: 29386
		' (get) Token: 0x060127EC RID: 75756 RVA: 0x0007EE33 File Offset: 0x0007D033
		' (set) Token: 0x060127ED RID: 75757 RVA: 0x00AA5A50 File Offset: 0x00AA3C50
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072CB RID: 29387
		' (get) Token: 0x060127EE RID: 75758 RVA: 0x0007EE3D File Offset: 0x0007D03D
		' (set) Token: 0x060127EF RID: 75759 RVA: 0x00AA5A94 File Offset: 0x00AA3C94
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072CC RID: 29388
		' (get) Token: 0x060127F0 RID: 75760 RVA: 0x0007EE47 File Offset: 0x0007D047
		' (set) Token: 0x060127F1 RID: 75761 RVA: 0x0007EE51 File Offset: 0x0007D051
		Public Overridable Property Picture As PictureBox

		' Token: 0x170072CD RID: 29389
		' (get) Token: 0x060127F2 RID: 75762 RVA: 0x0007EE5A File Offset: 0x0007D05A
		' (set) Token: 0x060127F3 RID: 75763 RVA: 0x00AA5AD8 File Offset: 0x00AA3CD8
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072CE RID: 29390
		' (get) Token: 0x060127F4 RID: 75764 RVA: 0x0007EE64 File Offset: 0x0007D064
		' (set) Token: 0x060127F5 RID: 75765 RVA: 0x00AA5B1C File Offset: 0x00AA3D1C
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072CF RID: 29391
		' (get) Token: 0x060127F6 RID: 75766 RVA: 0x0007EE6E File Offset: 0x0007D06E
		' (set) Token: 0x060127F7 RID: 75767 RVA: 0x00AA5B60 File Offset: 0x00AA3D60
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170072D0 RID: 29392
		' (get) Token: 0x060127F8 RID: 75768 RVA: 0x0007EE78 File Offset: 0x0007D078
		' (set) Token: 0x060127F9 RID: 75769 RVA: 0x0007EE82 File Offset: 0x0007D082
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x170072D1 RID: 29393
		' (get) Token: 0x060127FA RID: 75770 RVA: 0x0007EE8B File Offset: 0x0007D08B
		' (set) Token: 0x060127FB RID: 75771 RVA: 0x0007EE95 File Offset: 0x0007D095
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170072D2 RID: 29394
		' (get) Token: 0x060127FC RID: 75772 RVA: 0x0007EE9E File Offset: 0x0007D09E
		' (set) Token: 0x060127FD RID: 75773 RVA: 0x0007EEA8 File Offset: 0x0007D0A8
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x170072D3 RID: 29395
		' (get) Token: 0x060127FE RID: 75774 RVA: 0x0007EEB1 File Offset: 0x0007D0B1
		' (set) Token: 0x060127FF RID: 75775 RVA: 0x0007EEBB File Offset: 0x0007D0BB
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170072D4 RID: 29396
		' (get) Token: 0x06012800 RID: 75776 RVA: 0x0007EEC4 File Offset: 0x0007D0C4
		' (set) Token: 0x06012801 RID: 75777 RVA: 0x00AA5BA4 File Offset: 0x00AA3DA4
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

		' Token: 0x170072D5 RID: 29397
		' (get) Token: 0x06012802 RID: 75778 RVA: 0x0007EECE File Offset: 0x0007D0CE
		' (set) Token: 0x06012803 RID: 75779 RVA: 0x0007EED8 File Offset: 0x0007D0D8
		Friend Overridable Property lblSource As Label

		' Token: 0x170072D6 RID: 29398
		' (get) Token: 0x06012804 RID: 75780 RVA: 0x0007EEE1 File Offset: 0x0007D0E1
		' (set) Token: 0x06012805 RID: 75781 RVA: 0x0007EEEB File Offset: 0x0007D0EB
		Friend Overridable Property Label2 As Label

		' Token: 0x170072D7 RID: 29399
		' (get) Token: 0x06012806 RID: 75782 RVA: 0x0007EEF4 File Offset: 0x0007D0F4
		' (set) Token: 0x06012807 RID: 75783 RVA: 0x00AA5BE8 File Offset: 0x00AA3DE8
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

		' Token: 0x06012808 RID: 75784 RVA: 0x00AA5C2C File Offset: 0x00AA3E2C
		Public Sub Reset()
			Me.Label2.Text = ""
			Me.cmbCategory.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
			Me.fillGategoryName()
			Me.cmbCategory.Focus()
		End Sub

		' Token: 0x06012809 RID: 75785 RVA: 0x00AA5CAC File Offset: 0x00AA3EAC
		Public Sub fillGategoryName()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(categoryname) FROM category", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbCategory.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
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

		' Token: 0x0601280A RID: 75786 RVA: 0x00AA5DE8 File Offset: 0x00AA3FE8
		Private Sub DeleteRecord()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text As String = "select CategoryName from Category,SubCategory where Category.CategoryName=SubCategory.Category and CategoryName=@d1"
				Me.cmd = New SqlCommand(text)
				Me.cmd.Connection = Me.con
				Me.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text.TrimEnd(New Char(-1) {}))
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Sub Category Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = Me.rdr IsNot Nothing
					If flag2 Then
						Me.rdr.Close()
					End If
				Else
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text2 As String = "delete from category where categoryname=@d1"
					Me.cmd = New SqlCommand(text2)
					Me.cmd.Parameters.AddWithValue("@d1", Me.txtCategoryName.Text)
					Me.cmd.Connection = Me.con
					Dim num As Integer = Me.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						Me.LogFunc(Me.lblUser.Text, "deleted the category '" + Me.cmbCategory.Text.TrimEnd(New Char(-1) {}) + "'")
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
						Me.Reset()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
					If flag4 Then
						Me.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601280B RID: 75787 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LogFunc(text As String, v As String)
		End Sub

		' Token: 0x0601280C RID: 75788 RVA: 0x00AA6010 File Offset: 0x00AA4210
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtCategoryName.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(0).Value.ToString()
					Dim array As Byte() = CType(dataGridViewRow.Cells(1).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601280D RID: 75789 RVA: 0x00AA610C File Offset: 0x00AA430C
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

		' Token: 0x0601280E RID: 75790 RVA: 0x00AA61F4 File Offset: 0x00AA43F4
		Public Sub Getdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT RTRIM(categoryname),CPhoto,ID from category order by categoryname", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While Me.rdr.Read()
					Me.dgw.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2) })
				End While
				Me.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601280F RID: 75791 RVA: 0x00AA6300 File Offset: 0x00AA4500
		Private Sub frmcategory_Load(sender As Object, e As EventArgs)
			Me.LinkLabel1.TabStop = False
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06012810 RID: 75792 RVA: 0x00AA6398 File Offset: 0x00AA4598
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06012811 RID: 75793 RVA: 0x00AA6638 File Offset: 0x00AA4838
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x06012812 RID: 75794 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012813 RID: 75795 RVA: 0x00166364 File Offset: 0x00164564
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Enter)
				If flag Then
					SendKeys.Send("{TAB}")
					e.SuppressKeyPress = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012814 RID: 75796 RVA: 0x00AA66EC File Offset: 0x00AA48EC
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
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
									Dim flag2 As Boolean = dataGridViewCell.ColumnIndex = 1
									If Not flag2 Then
										' The following expression was wrapped in a checked-expression
										dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim flag3 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag3 Then
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

		' Token: 0x06012815 RID: 75797 RVA: 0x00166684 File Offset: 0x00164884
		Public Function DeriveKeyFromPassword(password As String, salt As Byte(), keySizeInBytes As Integer, iterations As Integer) As Byte()
			Dim bytes As Byte()
			Using rfc2898DeriveBytes As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, salt, iterations)
				bytes = rfc2898DeriveBytes.GetBytes(keySizeInBytes)
			End Using
			Return bytes
		End Function

		' Token: 0x06012816 RID: 75798 RVA: 0x001666C4 File Offset: 0x001648C4
		Public Function GenerateRandomSalt() As Byte()
			Dim num As Integer = 16
			Dim array As Byte() = New Byte(num - 1 + 1 - 1) {}
			Using rngcryptoServiceProvider As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
				rngcryptoServiceProvider.GetBytes(array)
			End Using
			Return array
		End Function

		' Token: 0x06012817 RID: 75799 RVA: 0x00166714 File Offset: 0x00164914
		Public Function Compress(data As Byte()) As Byte()
			Dim array As Byte()
			Using memoryStream As MemoryStream = New MemoryStream()
				Using gzipStream As GZipStream = New GZipStream(memoryStream, CompressionMode.Compress)
					gzipStream.Write(data, 0, data.Length)
				End Using
				array = memoryStream.ToArray()
			End Using
			Return array
		End Function

		' Token: 0x06012818 RID: 75800 RVA: 0x00AA69AC File Offset: 0x00AA4BAC
		Public Function EncryptByteArrayUsingPassword(password As String, data As Byte()) As String
			Dim array As Byte() = Me.GenerateRandomSalt()
			Dim num As Integer = 10000
			Dim num2 As Integer = 32
			Dim array2 As Byte() = Me.DeriveKeyFromPassword(password, array, num2, num)
			Dim text As String
			Using aesCryptoServiceProvider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
				aesCryptoServiceProvider.Key = array2
				aesCryptoServiceProvider.GenerateIV()
				Using cryptoTransform As ICryptoTransform = aesCryptoServiceProvider.CreateEncryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV)
					Using memoryStream As MemoryStream = New MemoryStream()
						Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write)
							cryptoStream.Write(data, 0, data.Length)
							cryptoStream.FlushFinalBlock()
						End Using
						Dim array3 As Byte() = array.Concat(aesCryptoServiceProvider.IV).Concat(memoryStream.ToArray()).ToArray()
						Dim array4 As Byte() = Me.Compress(array3)
						text = Convert.ToBase64String(array4)
					End Using
				End Using
			End Using
			Return text
		End Function

		' Token: 0x06012819 RID: 75801 RVA: 0x00AA6AD8 File Offset: 0x00AA4CD8
		Public Function DecryptStringToByteArrayUsingPassword(password As String, encryptedText As String) As Byte()
			Dim array As Byte() = Convert.FromBase64String(encryptedText)
			Dim num As Integer = 16
			Dim num2 As Integer = 16
			Dim num3 As Integer = 32
			Dim array2 As Byte() = array.Take(num).ToArray()
			Dim array3 As Byte() = array.Skip(num).Take(num2).ToArray()
			Dim array4 As Byte() = array.Skip(num + num2).ToArray()
			Dim array5 As Byte() = Me.DeriveKeyFromPassword(password, array2, num3, 10000)
			Dim array6 As Byte()
			Using aesCryptoServiceProvider As AesCryptoServiceProvider = New AesCryptoServiceProvider()
				aesCryptoServiceProvider.Key = array5
				aesCryptoServiceProvider.IV = array3
				Using cryptoTransform As ICryptoTransform = aesCryptoServiceProvider.CreateDecryptor(aesCryptoServiceProvider.Key, aesCryptoServiceProvider.IV)
					Using memoryStream As MemoryStream = New MemoryStream(array4)
						Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read)
							Using memoryStream2 As MemoryStream = New MemoryStream()
								cryptoStream.CopyTo(memoryStream2)
								array6 = memoryStream2.ToArray()
							End Using
						End Using
					End Using
				End Using
			End Using
			Return array6
		End Function

		' Token: 0x0601281A RID: 75802 RVA: 0x00166A00 File Offset: 0x00164C00
		Private Sub frmCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = CDbl(e.KeyCode) = Conversions.ToDouble(OpenQA.Selenium.Keys.Escape)
				If flag Then
					e.Handled = True
					Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
					If flag2 Then
						MyBase.Close()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601281B RID: 75803 RVA: 0x00AA6C2C File Offset: 0x00AA4E2C
		Private Sub frmCategory_Closing(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec", False) = 0
			If flag Then
				MyProject.Forms.frmProductRec.fillCategory()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.lblSource.Text, "ProductRec1", False) = 0
				If flag2 Then
					MyProject.Forms.frmProductRec1.fillCategory()
				Else
					MyProject.Forms.frmProduct.fillCategory()
				End If
			End If
		End Sub

		' Token: 0x0601281C RID: 75804 RVA: 0x00AA6CAC File Offset: 0x00AA4EAC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x0601281D RID: 75805 RVA: 0x0007EEFE File Offset: 0x0007D0FE
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601281E RID: 75806 RVA: 0x00AA6D08 File Offset: 0x00AA4F08
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "select * from Company"
			Me.cmd = New SqlCommand(text)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag As Boolean = Not Me.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Me.con.Close()
			Else
				Dim flag3 As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCategory.Focus()
				Else
					Try
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text2 As String = "select categoryname from category where categoryname=@d1"
						Me.cmd = New SqlCommand(text2)
						Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						Me.cmd.Connection = Me.con
						Me.rdr = Me.cmd.ExecuteReader()
						Dim flag4 As Boolean = Me.rdr.Read()
						If flag4 Then
							MessageBox.Show("Category Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbCategory.Text = ""
							Me.cmbCategory.Focus()
							Dim flag5 As Boolean = Me.rdr IsNot Nothing
							If flag5 Then
								Me.rdr.Close()
							End If
							Return
						End If
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text3 As String = "insert into category(categoryName,CPhoto) VALUES (@d1,@d2)"
						Me.cmd = New SqlCommand(text3)
						Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
						Me.cmd.Connection = Me.con
						Dim memoryStream As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
						bitmap.Save(memoryStream, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream.GetBuffer()
						Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
						sqlParameter.Value = buffer
						Me.cmd.Parameters.Add(sqlParameter)
						Me.cmd.ExecuteNonQuery()
						Me.con.Close()
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnSave.Enabled = False
						Me.Getdata()
						Me.fillGategoryName()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
					MyProject.Forms.frmProductRec.Label15.Text = Me.cmbCategory.Text
					Dim flag6 As Boolean = Operators.CompareString(Me.Label2.Text, "setting", False) = 0
					If flag6 Then
						MyBase.Dispose()
						MyProject.Forms.frmProductRec.ShowDialog()
					End If
				End If
			End If
		End Sub

		' Token: 0x0601281F RID: 75807 RVA: 0x00AA708C File Offset: 0x00AA528C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCategory.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbCategory.Focus()
			Else
				Try
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text As String = "Update category set categoryname=@d1,category.CPhoto=@d3 where categoryname=@d2"
					Me.cmd = New SqlCommand(text)
					Me.cmd.Connection = Me.con
					Me.cmd.Parameters.AddWithValue("@d1", Me.cmbCategory.Text.TrimEnd(New Char(-1) {}))
					Me.cmd.Parameters.AddWithValue("@d2", Me.txtCategoryName.Text)
					Me.cmd.Connection = Me.con
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
					sqlParameter.Value = buffer
					Me.cmd.Parameters.Add(sqlParameter)
					Me.cmd.ExecuteReader()
					Me.LogFunc(Me.lblUser.Text, "updated the category '" + Me.cmbCategory.Text + "'")
					MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					Me.Getdata()
					Me.fillGategoryName()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06012820 RID: 75808 RVA: 0x00AA727C File Offset: 0x00AA547C
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012821 RID: 75809 RVA: 0x00AA72E4 File Offset: 0x00AA54E4
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06012822 RID: 75810 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06012823 RID: 75811 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06012824 RID: 75812 RVA: 0x00AA7384 File Offset: 0x00AA5584
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
					oleDbConnection.Open()
					Me.dtable = New DataTable()
					oleDbDataAdapter.Fill(Me.dtable)
					Try
						For Each obj As Object In Me.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							SqlConnection.ClearAllPools()
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text As String = "SET IDENTITY_INSERT category ON; INSERT INTO category(ID, categoryName, CPhoto) VALUES (@d1, @d2, @d3); SET IDENTITY_INSERT category OFF;"
							Me.cmd = New SqlCommand(text)
							Me.cmd.Parameters.AddWithValue("@d1", dataRow("CID").ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Parameters.AddWithValue("@d2", dataRow("Category").ToString().TrimEnd(New Char(-1) {}))
							Me.cmd.Connection = Me.con
							Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
							Dim memoryStream As MemoryStream = New MemoryStream()
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim array As Byte() = memoryStream.ToArray()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d3", SqlDbType.Image)
							sqlParameter.Value = array
							Me.cmd.Parameters.Add(sqlParameter)
							Me.cmd.ExecuteReader()
							Me.con.Close()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully imported")
					Me.Getdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012825 RID: 75813 RVA: 0x00167420 File Offset: 0x00165620
		Private Function BitmapToByteArray(bitmap As Bitmap) As Byte()
			Dim rectangle As Rectangle = New Rectangle(0, 0, bitmap.Width, bitmap.Height)
			Dim bitmapData As BitmapData = bitmap.LockBits(rectangle, ImageLockMode.[ReadOnly], bitmap.PixelFormat)
			Dim num As Integer = bitmapData.Stride * bitmap.Height
			Dim array As Byte() = New Byte(num - 1 + 1 - 1) {}
			Marshal.Copy(bitmapData.Scan0, array, 0, num)
			bitmap.UnlockBits(bitmapData)
			Return array
		End Function

		' Token: 0x06012826 RID: 75814 RVA: 0x0007EF08 File Offset: 0x0007D108
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategoryNew.ShowDialog()
		End Sub

		' Token: 0x04006F5E RID: 28510
		Private s As String

		' Token: 0x04006F5F RID: 28511
		Private Photoname As String

		' Token: 0x04006F60 RID: 28512
		Private IsImageChanged As Boolean

		' Token: 0x04006F61 RID: 28513
		Private con As SqlConnection

		' Token: 0x04006F62 RID: 28514
		Private cmd As SqlCommand

		' Token: 0x04006F63 RID: 28515
		Private rdr As SqlDataReader

		' Token: 0x04006F64 RID: 28516
		Private adp As SqlDataAdapter

		' Token: 0x04006F65 RID: 28517
		Private ds As DataSet

		' Token: 0x04006F66 RID: 28518
		Private dtable As DataTable

		' Token: 0x04006F67 RID: 28519
		Private password As String
	End Class
End Namespace
