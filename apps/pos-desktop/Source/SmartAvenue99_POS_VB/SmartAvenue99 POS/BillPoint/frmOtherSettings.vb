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
	' Token: 0x020004D5 RID: 1237
	<DesignerGenerated()>
	Public Partial Class frmOtherSettings
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FBE1 RID: 64481 RVA: 0x0006E6C1 File Offset: 0x0006C8C1
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmOtherSettings_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmOtherSettings_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700605D RID: 24669
		' (get) Token: 0x0600FBE4 RID: 64484 RVA: 0x0006E6F3 File Offset: 0x0006C8F3
		' (set) Token: 0x0600FBE5 RID: 64485 RVA: 0x0006E6FD File Offset: 0x0006C8FD
		Friend Overridable Property Label1 As Label

		' Token: 0x1700605E RID: 24670
		' (get) Token: 0x0600FBE6 RID: 64486 RVA: 0x0006E706 File Offset: 0x0006C906
		' (set) Token: 0x0600FBE7 RID: 64487 RVA: 0x0006E710 File Offset: 0x0006C910
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700605F RID: 24671
		' (get) Token: 0x0600FBE8 RID: 64488 RVA: 0x0006E719 File Offset: 0x0006C919
		' (set) Token: 0x0600FBE9 RID: 64489 RVA: 0x0006E723 File Offset: 0x0006C923
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006060 RID: 24672
		' (get) Token: 0x0600FBEA RID: 64490 RVA: 0x0006E72C File Offset: 0x0006C92C
		' (set) Token: 0x0600FBEB RID: 64491 RVA: 0x0006E736 File Offset: 0x0006C936
		Friend Overridable Property Label3 As Label

		' Token: 0x17006061 RID: 24673
		' (get) Token: 0x0600FBEC RID: 64492 RVA: 0x0006E73F File Offset: 0x0006C93F
		' (set) Token: 0x0600FBED RID: 64493 RVA: 0x0096D368 File Offset: 0x0096B568
		Private _cmbUserID As ComboBox
		Friend Overridable Property cmbUserID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUserID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbUserID = value
				comboBox = Me._cmbUserID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006062 RID: 24674
		' (get) Token: 0x0600FBEE RID: 64494 RVA: 0x0006E749 File Offset: 0x0006C949
		' (set) Token: 0x0600FBEF RID: 64495 RVA: 0x0006E753 File Offset: 0x0006C953
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006063 RID: 24675
		' (get) Token: 0x0600FBF0 RID: 64496 RVA: 0x0006E75C File Offset: 0x0006C95C
		' (set) Token: 0x0600FBF1 RID: 64497 RVA: 0x0006E766 File Offset: 0x0006C966
		Friend Overridable Property chkCR As CheckBox

		' Token: 0x17006064 RID: 24676
		' (get) Token: 0x0600FBF2 RID: 64498 RVA: 0x0006E76F File Offset: 0x0006C96F
		' (set) Token: 0x0600FBF3 RID: 64499 RVA: 0x0006E779 File Offset: 0x0006C979
		Friend Overridable Property chkBD As CheckBox

		' Token: 0x17006065 RID: 24677
		' (get) Token: 0x0600FBF4 RID: 64500 RVA: 0x0006E782 File Offset: 0x0006C982
		' (set) Token: 0x0600FBF5 RID: 64501 RVA: 0x0006E78C File Offset: 0x0006C98C
		Friend Overridable Property chkID As CheckBox

		' Token: 0x17006066 RID: 24678
		' (get) Token: 0x0600FBF6 RID: 64502 RVA: 0x0006E795 File Offset: 0x0006C995
		' (set) Token: 0x0600FBF7 RID: 64503 RVA: 0x0096D3AC File Offset: 0x0096B5AC
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
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint1
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

		' Token: 0x17006067 RID: 24679
		' (get) Token: 0x0600FBF8 RID: 64504 RVA: 0x0006E79F File Offset: 0x0006C99F
		' (set) Token: 0x0600FBF9 RID: 64505 RVA: 0x0006E7A9 File Offset: 0x0006C9A9
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006068 RID: 24680
		' (get) Token: 0x0600FBFA RID: 64506 RVA: 0x0006E7B2 File Offset: 0x0006C9B2
		' (set) Token: 0x0600FBFB RID: 64507 RVA: 0x0006E7BC File Offset: 0x0006C9BC
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x17006069 RID: 24681
		' (get) Token: 0x0600FBFC RID: 64508 RVA: 0x0006E7C5 File Offset: 0x0006C9C5
		' (set) Token: 0x0600FBFD RID: 64509 RVA: 0x0006E7CF File Offset: 0x0006C9CF
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700606A RID: 24682
		' (get) Token: 0x0600FBFE RID: 64510 RVA: 0x0006E7D8 File Offset: 0x0006C9D8
		' (set) Token: 0x0600FBFF RID: 64511 RVA: 0x0006E7E2 File Offset: 0x0006C9E2
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700606B RID: 24683
		' (get) Token: 0x0600FC00 RID: 64512 RVA: 0x0006E7EB File Offset: 0x0006C9EB
		' (set) Token: 0x0600FC01 RID: 64513 RVA: 0x0006E7F5 File Offset: 0x0006C9F5
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700606C RID: 24684
		' (get) Token: 0x0600FC02 RID: 64514 RVA: 0x0006E7FE File Offset: 0x0006C9FE
		' (set) Token: 0x0600FC03 RID: 64515 RVA: 0x0006E808 File Offset: 0x0006CA08
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700606D RID: 24685
		' (get) Token: 0x0600FC04 RID: 64516 RVA: 0x0006E811 File Offset: 0x0006CA11
		' (set) Token: 0x0600FC05 RID: 64517 RVA: 0x0006E81B File Offset: 0x0006CA1B
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700606E RID: 24686
		' (get) Token: 0x0600FC06 RID: 64518 RVA: 0x0006E824 File Offset: 0x0006CA24
		' (set) Token: 0x0600FC07 RID: 64519 RVA: 0x0006E82E File Offset: 0x0006CA2E
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700606F RID: 24687
		' (get) Token: 0x0600FC08 RID: 64520 RVA: 0x0006E837 File Offset: 0x0006CA37
		' (set) Token: 0x0600FC09 RID: 64521 RVA: 0x0096D40C File Offset: 0x0096B60C
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

		' Token: 0x17006070 RID: 24688
		' (get) Token: 0x0600FC0A RID: 64522 RVA: 0x0006E841 File Offset: 0x0006CA41
		' (set) Token: 0x0600FC0B RID: 64523 RVA: 0x0006E84B File Offset: 0x0006CA4B
		Friend Overridable Property btnDelete As GelButton

		' Token: 0x17006071 RID: 24689
		' (get) Token: 0x0600FC0C RID: 64524 RVA: 0x0006E854 File Offset: 0x0006CA54
		' (set) Token: 0x0600FC0D RID: 64525 RVA: 0x0096D450 File Offset: 0x0096B650
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
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

		' Token: 0x17006072 RID: 24690
		' (get) Token: 0x0600FC0E RID: 64526 RVA: 0x0006E85E File Offset: 0x0006CA5E
		' (set) Token: 0x0600FC0F RID: 64527 RVA: 0x0096D494 File Offset: 0x0096B694
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

		' Token: 0x0600FC10 RID: 64528 RVA: 0x0096D4D8 File Offset: 0x0096B6D8
		Public Sub Reset()
			Me.cmbUserID.SelectedIndex = -1
			Me.chkBD.Checked = False
			Me.chkCR.Checked = False
			Me.chkID.Checked = False
			Me.CheckBox1.Checked = False
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Getdata()
		End Sub

		' Token: 0x0600FC11 RID: 64529 RVA: 0x0006E868 File Offset: 0x0006CA68
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FC12 RID: 64530 RVA: 0x0096D558 File Offset: 0x0096B758
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select distinct RTRIM(UserID) from Registration where UserType='Sales Person' Order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.cmbUserID.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.cmbUserID.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FC13 RID: 64531 RVA: 0x0096D62C File Offset: 0x0096B82C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(UserID), RTRIM(ATEID),RTRIM(ATGBD),RTRIM(ATCR),RTRIM(INVD) from CashierSetting order by 2", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FC14 RID: 64532 RVA: 0x0096D754 File Offset: 0x0096B954
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from CashierSetting where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x0600FC15 RID: 64533 RVA: 0x0096D86C File Offset: 0x0096BA6C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbUserID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkID.Checked = True
					Else
						Me.chkID.Checked = False
					End If
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(3).Value.ToString(), "Yes", False) = 0
					If flag3 Then
						Me.chkBD.Checked = True
					Else
						Me.chkBD.Checked = False
					End If
					Dim flag4 As Boolean = Operators.CompareString(dataGridViewRow.Cells(4).Value.ToString(), "Yes", False) = 0
					If flag4 Then
						Me.chkCR.Checked = True
					Else
						Me.chkCR.Checked = False
					End If
					Dim flag5 As Boolean = Operators.CompareString(dataGridViewRow.Cells(5).Value.ToString(), "Yes", False) = 0
					If flag5 Then
						Me.CheckBox1.Checked = True
					Else
						Me.CheckBox1.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FC16 RID: 64534 RVA: 0x0096DA64 File Offset: 0x0096BC64
		Private Sub dgw_RowPostPaint1(sender As Object, e As DataGridViewRowPostPaintEventArgs)
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

		' Token: 0x0600FC17 RID: 64535 RVA: 0x0006E868 File Offset: 0x0006CA68
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FC18 RID: 64536 RVA: 0x0096DB4C File Offset: 0x0096BD4C
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbUserID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please select user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbUserID.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select UserID from CashierSetting where UserID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							MessageBox.Show("Record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag5 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							Dim checked As Boolean = Me.chkID.Checked
							If checked Then
								Me.st1 = "Yes"
							Else
								Me.st1 = "No"
							End If
							Dim checked2 As Boolean = Me.chkBD.Checked
							If checked2 Then
								Me.st2 = "Yes"
							Else
								Me.st2 = "No"
							End If
							Dim checked3 As Boolean = Me.chkCR.Checked
							If checked3 Then
								Me.st3 = "Yes"
							Else
								Me.st3 = "No"
							End If
							Dim checked4 As Boolean = Me.CheckBox1.Checked
							If checked4 Then
								Me.st4 = "Yes"
							Else
								Me.st4 = "No"
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into CashierSetting(UserID,ATEID,ATGBD,ATCR,INVD) VALUES (@d1,@d2,@d3,@d4,@d5)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.st4)
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							MessageBox.Show("Successfully Saved", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Reset()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600FC19 RID: 64537 RVA: 0x0096DED4 File Offset: 0x0096C0D4
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbUserID.Text)) = 0
			If flag Then
				MessageBox.Show("Please select user id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbUserID.Focus()
			Else
				Try
					Dim checked As Boolean = Me.chkID.Checked
					If checked Then
						Me.st1 = "Yes"
					Else
						Me.st1 = "No"
					End If
					Dim checked2 As Boolean = Me.chkBD.Checked
					If checked2 Then
						Me.st2 = "Yes"
					Else
						Me.st2 = "No"
					End If
					Dim checked3 As Boolean = Me.chkCR.Checked
					If checked3 Then
						Me.st3 = "Yes"
					Else
						Me.st3 = "No"
					End If
					Dim checked4 As Boolean = Me.CheckBox1.Checked
					If checked4 Then
						Me.st4 = "Yes"
					Else
						Me.st4 = "No"
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = If(("Update CashierSetting set UserID=@d1,ATEID=@d2,ATGBD=@d3,ATCR=@d4,INVD=@d5 where ID=" + Conversions.ToString(Conversion.Val(Me.txtID.Text))), "")
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbUserID.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.st1)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.st2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.st3)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.st4)
					ModCommonClasses.cmd.ExecuteReader()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600FC1A RID: 64538 RVA: 0x0096E130 File Offset: 0x0096C330
		Private Sub frmOtherSettings_Load(sender As Object, e As EventArgs)
			Me.FillUserID()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FC1B RID: 64539 RVA: 0x0096E1B8 File Offset: 0x0096C3B8
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

		' Token: 0x0600FC1C RID: 64540 RVA: 0x0096E330 File Offset: 0x0096C530
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

		' Token: 0x0600FC1D RID: 64541 RVA: 0x0096E3EC File Offset: 0x0096C5EC
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

		' Token: 0x0600FC1E RID: 64542 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FC1F RID: 64543 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FC20 RID: 64544 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FC21 RID: 64545 RVA: 0x0096E4B8 File Offset: 0x0096C6B8
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.cmbUserID.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.cmbUserID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbUserID, String.Empty)
			End If
		End Sub

		' Token: 0x0600FC22 RID: 64546 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmOtherSettings_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0400608B RID: 24715
		Private st2 As String

		' Token: 0x0400608C RID: 24716
		Private st1 As String

		' Token: 0x0400608D RID: 24717
		Private st3 As String

		' Token: 0x0400608E RID: 24718
		Private st4 As String
	End Class
End Namespace
