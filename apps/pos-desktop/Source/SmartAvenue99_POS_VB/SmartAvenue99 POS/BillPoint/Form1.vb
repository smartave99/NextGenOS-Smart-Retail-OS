Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000328 RID: 808
	<DesignerGenerated()>
	Public Partial Class Form1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BDB5 RID: 48565 RVA: 0x0079183C File Offset: 0x0078FA3C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.Form1_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.Form1_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004B96 RID: 19350
		' (get) Token: 0x0600BDB8 RID: 48568 RVA: 0x00054C1B File Offset: 0x00052E1B
		' (set) Token: 0x0600BDB9 RID: 48569 RVA: 0x00054C25 File Offset: 0x00052E25
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004B97 RID: 19351
		' (get) Token: 0x0600BDBA RID: 48570 RVA: 0x00054C2E File Offset: 0x00052E2E
		' (set) Token: 0x0600BDBB RID: 48571 RVA: 0x007923C0 File Offset: 0x007905C0
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
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

		' Token: 0x17004B98 RID: 19352
		' (get) Token: 0x0600BDBC RID: 48572 RVA: 0x00054C38 File Offset: 0x00052E38
		' (set) Token: 0x0600BDBD RID: 48573 RVA: 0x00054C42 File Offset: 0x00052E42
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17004B99 RID: 19353
		' (get) Token: 0x0600BDBE RID: 48574 RVA: 0x00054C4B File Offset: 0x00052E4B
		' (set) Token: 0x0600BDBF RID: 48575 RVA: 0x00792404 File Offset: 0x00790604
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

		' Token: 0x17004B9A RID: 19354
		' (get) Token: 0x0600BDC0 RID: 48576 RVA: 0x00054C55 File Offset: 0x00052E55
		' (set) Token: 0x0600BDC1 RID: 48577 RVA: 0x00054C5F File Offset: 0x00052E5F
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004B9B RID: 19355
		' (get) Token: 0x0600BDC2 RID: 48578 RVA: 0x00054C68 File Offset: 0x00052E68
		' (set) Token: 0x0600BDC3 RID: 48579 RVA: 0x00054C72 File Offset: 0x00052E72
		Friend Overridable Property Label13 As Label

		' Token: 0x17004B9C RID: 19356
		' (get) Token: 0x0600BDC4 RID: 48580 RVA: 0x00054C7B File Offset: 0x00052E7B
		' (set) Token: 0x0600BDC5 RID: 48581 RVA: 0x00792464 File Offset: 0x00790664
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

		' Token: 0x17004B9D RID: 19357
		' (get) Token: 0x0600BDC6 RID: 48582 RVA: 0x00054C85 File Offset: 0x00052E85
		' (set) Token: 0x0600BDC7 RID: 48583 RVA: 0x007924A8 File Offset: 0x007906A8
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

		' Token: 0x17004B9E RID: 19358
		' (get) Token: 0x0600BDC8 RID: 48584 RVA: 0x00054C8F File Offset: 0x00052E8F
		' (set) Token: 0x0600BDC9 RID: 48585 RVA: 0x007924EC File Offset: 0x007906EC
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

		' Token: 0x17004B9F RID: 19359
		' (get) Token: 0x0600BDCA RID: 48586 RVA: 0x00054C99 File Offset: 0x00052E99
		' (set) Token: 0x0600BDCB RID: 48587 RVA: 0x00054CA3 File Offset: 0x00052EA3
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004BA0 RID: 19360
		' (get) Token: 0x0600BDCC RID: 48588 RVA: 0x00054CAC File Offset: 0x00052EAC
		' (set) Token: 0x0600BDCD RID: 48589 RVA: 0x00054CB6 File Offset: 0x00052EB6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004BA1 RID: 19361
		' (get) Token: 0x0600BDCE RID: 48590 RVA: 0x00054CBF File Offset: 0x00052EBF
		' (set) Token: 0x0600BDCF RID: 48591 RVA: 0x00054CC9 File Offset: 0x00052EC9
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x0600BDD0 RID: 48592 RVA: 0x00792530 File Offset: 0x00790730
		Public Sub Load_frmapartinfo_IntoPanel()
			Me.Panel1.Controls.Clear()
			Dim frmF2 As New Form2() With { .Size = Me.Panel1.Size, .TopLevel = False, .Parent = Me.Panel1 } : frmF2.Show()
		End Sub

		' Token: 0x0600BDD1 RID: 48593 RVA: 0x00792584 File Offset: 0x00790784
		Public Sub Load_frmapartinfo_IntoPanel_Close()
			Me.Panel1.Controls.Clear()
			Dim frmF2Close As New Form2() With { .Size = Me.Panel1.Size, .TopLevel = False, .Parent = Me.Panel1 } : frmF2Close.Close()
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x0600BDD2 RID: 48594 RVA: 0x00054CD2 File Offset: 0x00052ED2
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.Load_frmapartinfo_IntoPanel_Close()
		End Sub

		' Token: 0x0600BDD3 RID: 48595 RVA: 0x007925E8 File Offset: 0x007907E8
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(c1),c2 from UPIImg ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0600BDD4 RID: 48596 RVA: 0x00054CDC File Offset: 0x00052EDC
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.imageisplay()
		End Sub

		' Token: 0x0600BDD5 RID: 48597 RVA: 0x007926E8 File Offset: 0x007908E8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Dim array As Byte() = CType(dataGridViewRow.Cells(2).Value, Byte())
				Dim memoryStream As MemoryStream = New MemoryStream(array)
				Me.PictureBox1.Image = Image.FromStream(memoryStream)
				MyProject.Forms.Form2.PictureBox1.Image = Me.PictureBox1.Image
				Me.Load_frmapartinfo_IntoPanel()
				Try
					Dim screen As Screen = Screen.AllScreens(1)
					MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
					MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
					MyProject.Forms.Form2.Show()
				Catch ex As Exception
					MessageBox.Show("Extend display monitor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
			End Try
		End Sub

		' Token: 0x0600BDD6 RID: 48598 RVA: 0x00792844 File Offset: 0x00790A44
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

		' Token: 0x0600BDD7 RID: 48599 RVA: 0x0079292C File Offset: 0x00790B2C
		Private Sub imageisplay()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT c1 FROM UPIImg ORDER BY c1 ASC"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.ComboBox1.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox1.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BDD8 RID: 48600 RVA: 0x00792A3C File Offset: 0x00790C3C
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(c1), c2 from UPIImg where c1= '" + Me.ComboBox1.Text + "' order by c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BDD9 RID: 48601 RVA: 0x00054CED File Offset: 0x00052EED
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600BDDA RID: 48602 RVA: 0x00054D09 File Offset: 0x00052F09
		Private Sub Clear()
			Me.PictureBox1.Image = Resources.Noimage
			Me.dgw.ClearSelection()
			Me.ComboBox1.SelectedIndex = -1
		End Sub

		' Token: 0x0600BDDB RID: 48603 RVA: 0x00054D36 File Offset: 0x00052F36
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.GetData()
		End Sub

		' Token: 0x0600BDDC RID: 48604 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BDDD RID: 48605 RVA: 0x00054CD2 File Offset: 0x00052ED2
		Private Sub Form1_Closing(sender As Object, e As CancelEventArgs)
			Me.Load_frmapartinfo_IntoPanel_Close()
		End Sub
	End Class
End Namespace
