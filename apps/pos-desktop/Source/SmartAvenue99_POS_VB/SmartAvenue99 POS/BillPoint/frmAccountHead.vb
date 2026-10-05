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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A8 RID: 1192
	<DesignerGenerated()>
	Public Partial Class frmAccountHead
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EC76 RID: 60534 RVA: 0x0006795C File Offset: 0x00065B5C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAccountHead_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAccountHead_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AB7 RID: 23223
		' (get) Token: 0x0600EC79 RID: 60537 RVA: 0x0006798E File Offset: 0x00065B8E
		' (set) Token: 0x0600EC7A RID: 60538 RVA: 0x00067998 File Offset: 0x00065B98
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005AB8 RID: 23224
		' (get) Token: 0x0600EC7B RID: 60539 RVA: 0x000679A1 File Offset: 0x00065BA1
		' (set) Token: 0x0600EC7C RID: 60540 RVA: 0x000679AB File Offset: 0x00065BAB
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17005AB9 RID: 23225
		' (get) Token: 0x0600EC7D RID: 60541 RVA: 0x000679B4 File Offset: 0x00065BB4
		' (set) Token: 0x0600EC7E RID: 60542 RVA: 0x008E6DDC File Offset: 0x008E4FDC
		Private _txtSearchBySubCategory As TextBox
		Friend Overridable Property txtSearchBySubCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchBySubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchBySubCategory_TextChanged
				Dim textBox As TextBox = Me._txtSearchBySubCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchBySubCategory = value
				textBox = Me._txtSearchBySubCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005ABA RID: 23226
		' (get) Token: 0x0600EC7F RID: 60543 RVA: 0x000679BE File Offset: 0x00065BBE
		' (set) Token: 0x0600EC80 RID: 60544 RVA: 0x000679C8 File Offset: 0x00065BC8
		Friend Overridable Property Label4 As Label

		' Token: 0x17005ABB RID: 23227
		' (get) Token: 0x0600EC81 RID: 60545 RVA: 0x000679D1 File Offset: 0x00065BD1
		' (set) Token: 0x0600EC82 RID: 60546 RVA: 0x000679DB File Offset: 0x00065BDB
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005ABC RID: 23228
		' (get) Token: 0x0600EC83 RID: 60547 RVA: 0x000679E4 File Offset: 0x00065BE4
		' (set) Token: 0x0600EC84 RID: 60548 RVA: 0x008E6E20 File Offset: 0x008E5020
		Private _txtSearchByCategory As TextBox
		Friend Overridable Property txtSearchByCategory As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchByCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchByCategory_TextChanged
				Dim textBox As TextBox = Me._txtSearchByCategory
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchByCategory = value
				textBox = Me._txtSearchByCategory
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005ABD RID: 23229
		' (get) Token: 0x0600EC85 RID: 60549 RVA: 0x000679EE File Offset: 0x00065BEE
		' (set) Token: 0x0600EC86 RID: 60550 RVA: 0x000679F8 File Offset: 0x00065BF8
		Friend Overridable Property Label5 As Label

		' Token: 0x17005ABE RID: 23230
		' (get) Token: 0x0600EC87 RID: 60551 RVA: 0x00067A01 File Offset: 0x00065C01
		' (set) Token: 0x0600EC88 RID: 60552 RVA: 0x00067A0B File Offset: 0x00065C0B
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005ABF RID: 23231
		' (get) Token: 0x0600EC89 RID: 60553 RVA: 0x00067A14 File Offset: 0x00065C14
		' (set) Token: 0x0600EC8A RID: 60554 RVA: 0x008E6E64 File Offset: 0x008E5064
		Private _cmbSubCategory As ComboBox
		Friend Overridable Property cmbSubCategory As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSubCategory
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSubCategory_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSubCategory = value
				comboBox = Me._cmbSubCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AC0 RID: 23232
		' (get) Token: 0x0600EC8B RID: 60555 RVA: 0x00067A1E File Offset: 0x00065C1E
		' (set) Token: 0x0600EC8C RID: 60556 RVA: 0x008E6EC4 File Offset: 0x008E50C4
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
				Dim eventHandler As EventHandler = AddressOf Me.cmbCategory_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCategory = value
				comboBox = Me._cmbCategory
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AC1 RID: 23233
		' (get) Token: 0x0600EC8D RID: 60557 RVA: 0x00067A28 File Offset: 0x00065C28
		' (set) Token: 0x0600EC8E RID: 60558 RVA: 0x00067A32 File Offset: 0x00065C32
		Friend Overridable Property Label2 As Label

		' Token: 0x17005AC2 RID: 23234
		' (get) Token: 0x0600EC8F RID: 60559 RVA: 0x00067A3B File Offset: 0x00065C3B
		' (set) Token: 0x0600EC90 RID: 60560 RVA: 0x00067A45 File Offset: 0x00065C45
		Friend Overridable Property Label3 As Label

		' Token: 0x17005AC3 RID: 23235
		' (get) Token: 0x0600EC91 RID: 60561 RVA: 0x00067A4E File Offset: 0x00065C4E
		' (set) Token: 0x0600EC92 RID: 60562 RVA: 0x00067A58 File Offset: 0x00065C58
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005AC4 RID: 23236
		' (get) Token: 0x0600EC93 RID: 60563 RVA: 0x00067A61 File Offset: 0x00065C61
		' (set) Token: 0x0600EC94 RID: 60564 RVA: 0x008E6F40 File Offset: 0x008E5140
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AC5 RID: 23237
		' (get) Token: 0x0600EC95 RID: 60565 RVA: 0x00067A6B File Offset: 0x00065C6B
		' (set) Token: 0x0600EC96 RID: 60566 RVA: 0x00067A75 File Offset: 0x00065C75
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005AC6 RID: 23238
		' (get) Token: 0x0600EC97 RID: 60567 RVA: 0x00067A7E File Offset: 0x00065C7E
		' (set) Token: 0x0600EC98 RID: 60568 RVA: 0x00067A88 File Offset: 0x00065C88
		Friend Overridable Property Label1 As Label

		' Token: 0x17005AC7 RID: 23239
		' (get) Token: 0x0600EC99 RID: 60569 RVA: 0x00067A91 File Offset: 0x00065C91
		' (set) Token: 0x0600EC9A RID: 60570 RVA: 0x00067A9B File Offset: 0x00065C9B
		Friend Overridable Property lblUser As Label

		' Token: 0x17005AC8 RID: 23240
		' (get) Token: 0x0600EC9B RID: 60571 RVA: 0x00067AA4 File Offset: 0x00065CA4
		' (set) Token: 0x0600EC9C RID: 60572 RVA: 0x00067AAE File Offset: 0x00065CAE
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005AC9 RID: 23241
		' (get) Token: 0x0600EC9D RID: 60573 RVA: 0x00067AB7 File Offset: 0x00065CB7
		' (set) Token: 0x0600EC9E RID: 60574 RVA: 0x00067AC1 File Offset: 0x00065CC1
		Friend Overridable Property Label7 As Label

		' Token: 0x17005ACA RID: 23242
		' (get) Token: 0x0600EC9F RID: 60575 RVA: 0x00067ACA File Offset: 0x00065CCA
		' (set) Token: 0x0600ECA0 RID: 60576 RVA: 0x00067AD4 File Offset: 0x00065CD4
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005ACB RID: 23243
		' (get) Token: 0x0600ECA1 RID: 60577 RVA: 0x00067ADD File Offset: 0x00065CDD
		' (set) Token: 0x0600ECA2 RID: 60578 RVA: 0x00067AE7 File Offset: 0x00065CE7
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005ACC RID: 23244
		' (get) Token: 0x0600ECA3 RID: 60579 RVA: 0x00067AF0 File Offset: 0x00065CF0
		' (set) Token: 0x0600ECA4 RID: 60580 RVA: 0x00067AFA File Offset: 0x00065CFA
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005ACD RID: 23245
		' (get) Token: 0x0600ECA5 RID: 60581 RVA: 0x00067B03 File Offset: 0x00065D03
		' (set) Token: 0x0600ECA6 RID: 60582 RVA: 0x008E6FA0 File Offset: 0x008E51A0
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005ACE RID: 23246
		' (get) Token: 0x0600ECA7 RID: 60583 RVA: 0x00067B0D File Offset: 0x00065D0D
		' (set) Token: 0x0600ECA8 RID: 60584 RVA: 0x00067B17 File Offset: 0x00065D17
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17005ACF RID: 23247
		' (get) Token: 0x0600ECA9 RID: 60585 RVA: 0x00067B20 File Offset: 0x00065D20
		' (set) Token: 0x0600ECAA RID: 60586 RVA: 0x008E6FE4 File Offset: 0x008E51E4
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
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

		' Token: 0x17005AD0 RID: 23248
		' (get) Token: 0x0600ECAB RID: 60587 RVA: 0x00067B2A File Offset: 0x00065D2A
		' (set) Token: 0x0600ECAC RID: 60588 RVA: 0x008E7028 File Offset: 0x008E5228
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click_1
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

		' Token: 0x17005AD1 RID: 23249
		' (get) Token: 0x0600ECAD RID: 60589 RVA: 0x00067B34 File Offset: 0x00065D34
		' (set) Token: 0x0600ECAE RID: 60590 RVA: 0x008E706C File Offset: 0x008E526C
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

		' Token: 0x17005AD2 RID: 23250
		' (get) Token: 0x0600ECAF RID: 60591 RVA: 0x00067B3E File Offset: 0x00065D3E
		' (set) Token: 0x0600ECB0 RID: 60592 RVA: 0x008E70B0 File Offset: 0x008E52B0
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

		' Token: 0x0600ECB1 RID: 60593 RVA: 0x008E70F4 File Offset: 0x008E52F4
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(a1), RTRIM(a2) from AccountHead order by a1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ECB2 RID: 60594 RVA: 0x008E71F4 File Offset: 0x008E53F4
		Private Sub Acvalidation()
			Dim flag As Boolean = Me.cmbCategory.SelectedIndex = 0
			If flag Then
				Me.TextBox1.Text = "Tax"
			End If
			Dim flag2 As Boolean = Me.cmbCategory.SelectedIndex = 1
			If flag2 Then
				Me.TextBox1.Text = "Tax"
			End If
			Dim flag3 As Boolean = Me.cmbCategory.SelectedIndex = 2
			If flag3 Then
				Me.TextBox1.Text = "Exp"
			End If
			Dim flag4 As Boolean = Me.cmbCategory.SelectedIndex = 3
			If flag4 Then
				Me.TextBox1.Text = "Exp"
			End If
			Dim flag5 As Boolean = Me.cmbCategory.SelectedIndex = 4
			If flag5 Then
				Me.TextBox1.Text = "Exp"
			End If
			Dim flag6 As Boolean = Me.cmbCategory.SelectedIndex = 5
			If flag6 Then
				Me.TextBox1.Text = "Exp"
			End If
			Dim flag7 As Boolean = Me.cmbCategory.SelectedIndex = 6
			If flag7 Then
				Me.TextBox1.Text = "Inc"
			End If
			Dim flag8 As Boolean = Me.cmbCategory.SelectedIndex = 7
			If flag8 Then
				Me.TextBox1.Text = "Inc"
			End If
			Dim flag9 As Boolean = Me.cmbCategory.SelectedIndex = 8
			If flag9 Then
				Me.TextBox1.Text = "Inc"
			End If
		End Sub

		' Token: 0x0600ECB3 RID: 60595 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600ECB4 RID: 60596 RVA: 0x008E735C File Offset: 0x008E555C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from AccountHead where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "deleted the a/c head '", Me.cmbSubCategory.Text, "' having group '", Me.cmbCategory.Text, "'" }))
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ECB5 RID: 60597 RVA: 0x008E74D8 File Offset: 0x008E56D8
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

		' Token: 0x0600ECB6 RID: 60598 RVA: 0x008E75C0 File Offset: 0x008E57C0
		Public Sub Reset()
			Me.txtID.Text = ""
			Me.cmbCategory.SelectedIndex = -1
			Me.txtSearchByCategory.Text = ""
			Me.txtSearchBySubCategory.Text = ""
			Me.cmbSubCategory.Text = ""
			Me.cmbSubCategory.SelectedIndex = -1
			Me.cmbSubCategory.Focus()
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.Getdata()
			Me.fillachead()
		End Sub

		' Token: 0x0600ECB7 RID: 60599 RVA: 0x008E7670 File Offset: 0x008E5870
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.cmbSubCategory.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbCategory.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600ECB8 RID: 60600 RVA: 0x008E775C File Offset: 0x008E595C
		Private Sub txtSearchByCategory_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a1), RTRIM(a2) from AccountHead where a2 like N'%" + Me.txtSearchByCategory.Text + "%' order by a2", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ECB9 RID: 60601 RVA: 0x008E7870 File Offset: 0x008E5A70
		Private Sub txtSearchBySubCategory_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(a1), RTRIM(a2) from AccountHead where a1 like N'%" + Me.txtSearchBySubCategory.Text + "%' order by a1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ECBA RID: 60602 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSubCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ECBB RID: 60603 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCategory_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600ECBC RID: 60604 RVA: 0x008E7984 File Offset: 0x008E5B84
		Public Sub fillachead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(a1) FROM AccountHead", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSubCategory.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSubCategory.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600ECBD RID: 60605 RVA: 0x008E7AB8 File Offset: 0x008E5CB8
		Private Sub frmAccountHead_Load(sender As Object, e As EventArgs)
			Me.fillachead()
			Me.Reset()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600ECBE RID: 60606 RVA: 0x008E7B48 File Offset: 0x008E5D48
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) AS default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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

		' Token: 0x0600ECBF RID: 60607 RVA: 0x008E7DE8 File Offset: 0x008E5FE8
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

		' Token: 0x0600ECC0 RID: 60608 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600ECC1 RID: 60609 RVA: 0x00067B48 File Offset: 0x00065D48
		Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Acvalidation()
		End Sub

		' Token: 0x0600ECC2 RID: 60610 RVA: 0x00067B48 File Offset: 0x00065D48
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.Acvalidation()
		End Sub

		' Token: 0x0600ECC3 RID: 60611 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAccountHead_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600ECC4 RID: 60612 RVA: 0x008E7E9C File Offset: 0x008E609C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbSubCategory.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSubCategory, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.cmbCategory.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.cmbCategory, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCategory, String.Empty)
			End If
		End Sub

		' Token: 0x0600ECC5 RID: 60613 RVA: 0x00067B52 File Offset: 0x00065D52
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600ECC6 RID: 60614 RVA: 0x008E7F44 File Offset: 0x008E6144
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter A/c Head", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSubCategory.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please select A/c Group", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCategory.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select a1,a2 from AccountHead where a1=@d1 and a2=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.cmbSubCategory.Text = ""
								Me.cmbSubCategory.Focus()
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select a1 from AccountHead where a1=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
								If flag7 Then
									MessageBox.Show("A/c Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.cmbSubCategory.Text = ""
									Me.cmbSubCategory.Focus()
									Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag8 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into AccountHead(a1,a2,a3) VALUES (@d1,@d2,@d3)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new a/c head '", Me.cmbSubCategory.Text, "' having group '", Me.cmbCategory.Text, "'" }))
									MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
									Me.Getdata()
									Me.fillachead()
								End If
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600ECC7 RID: 60615 RVA: 0x008E83B4 File Offset: 0x008E65B4
		Private Sub btnUpdate_Click_1(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSubCategory.Text)) = 0
				If flag Then
					MessageBox.Show("Please enter A/c Head", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSubCategory.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.cmbCategory.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please select A/c Group", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCategory.Focus()
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select a1,a2 from AccountHead where a1=@d1 and a2=@d2"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbSubCategory.Text = ""
							Me.cmbSubCategory.Focus()
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select a1 from AccountHead where a1=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("A/c Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.cmbSubCategory.Text = ""
								Me.cmbSubCategory.Focus()
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = If(("update AccountHead set a1=@d1,a2=@d2,a3=@d3 where ID=" + Me.txtID.Text), "")
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSubCategory.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbCategory.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the a/c head '", Me.cmbSubCategory.Text, "' having group '", Me.cmbCategory.Text, "'" }))
								MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnUpdate.Enabled = False
								Me.Getdata()
								Me.fillachead()
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600ECC8 RID: 60616 RVA: 0x008E87A0 File Offset: 0x008E69A0
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
