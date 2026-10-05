Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004D6 RID: 1238
	<DesignerGenerated()>
	Public Partial Class frmPrevSales
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FC23 RID: 64547 RVA: 0x0006E872 File Offset: 0x0006CA72
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPrevSales_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPrevSales_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006073 RID: 24691
		' (get) Token: 0x0600FC26 RID: 64550 RVA: 0x0006E8A4 File Offset: 0x0006CAA4
		' (set) Token: 0x0600FC27 RID: 64551 RVA: 0x0006E8AE File Offset: 0x0006CAAE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006074 RID: 24692
		' (get) Token: 0x0600FC28 RID: 64552 RVA: 0x0006E8B7 File Offset: 0x0006CAB7
		' (set) Token: 0x0600FC29 RID: 64553 RVA: 0x0006E8C1 File Offset: 0x0006CAC1
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006075 RID: 24693
		' (get) Token: 0x0600FC2A RID: 64554 RVA: 0x0006E8CA File Offset: 0x0006CACA
		' (set) Token: 0x0600FC2B RID: 64555 RVA: 0x0096F254 File Offset: 0x0096D454
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

		' Token: 0x17006076 RID: 24694
		' (get) Token: 0x0600FC2C RID: 64556 RVA: 0x0006E8D4 File Offset: 0x0006CAD4
		' (set) Token: 0x0600FC2D RID: 64557 RVA: 0x0006E8DE File Offset: 0x0006CADE
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006077 RID: 24695
		' (get) Token: 0x0600FC2E RID: 64558 RVA: 0x0006E8E7 File Offset: 0x0006CAE7
		' (set) Token: 0x0600FC2F RID: 64559 RVA: 0x0006E8F1 File Offset: 0x0006CAF1
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006078 RID: 24696
		' (get) Token: 0x0600FC30 RID: 64560 RVA: 0x0006E8FA File Offset: 0x0006CAFA
		' (set) Token: 0x0600FC31 RID: 64561 RVA: 0x0006E904 File Offset: 0x0006CB04
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006079 RID: 24697
		' (get) Token: 0x0600FC32 RID: 64562 RVA: 0x0006E90D File Offset: 0x0006CB0D
		' (set) Token: 0x0600FC33 RID: 64563 RVA: 0x0006E917 File Offset: 0x0006CB17
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700607A RID: 24698
		' (get) Token: 0x0600FC34 RID: 64564 RVA: 0x0006E920 File Offset: 0x0006CB20
		' (set) Token: 0x0600FC35 RID: 64565 RVA: 0x0006E92A File Offset: 0x0006CB2A
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700607B RID: 24699
		' (get) Token: 0x0600FC36 RID: 64566 RVA: 0x0006E933 File Offset: 0x0006CB33
		' (set) Token: 0x0600FC37 RID: 64567 RVA: 0x0006E93D File Offset: 0x0006CB3D
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700607C RID: 24700
		' (get) Token: 0x0600FC38 RID: 64568 RVA: 0x0006E946 File Offset: 0x0006CB46
		' (set) Token: 0x0600FC39 RID: 64569 RVA: 0x0006E950 File Offset: 0x0006CB50
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700607D RID: 24701
		' (get) Token: 0x0600FC3A RID: 64570 RVA: 0x0006E959 File Offset: 0x0006CB59
		' (set) Token: 0x0600FC3B RID: 64571 RVA: 0x0006E963 File Offset: 0x0006CB63
		Friend Overridable Property Label2 As Label

		' Token: 0x1700607E RID: 24702
		' (get) Token: 0x0600FC3C RID: 64572 RVA: 0x0006E96C File Offset: 0x0006CB6C
		' (set) Token: 0x0600FC3D RID: 64573 RVA: 0x0096F298 File Offset: 0x0096D498
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700607F RID: 24703
		' (get) Token: 0x0600FC3E RID: 64574 RVA: 0x0006E976 File Offset: 0x0006CB76
		' (set) Token: 0x0600FC3F RID: 64575 RVA: 0x0006E980 File Offset: 0x0006CB80
		Friend Overridable Property Label4 As Label

		' Token: 0x17006080 RID: 24704
		' (get) Token: 0x0600FC40 RID: 64576 RVA: 0x0006E989 File Offset: 0x0006CB89
		' (set) Token: 0x0600FC41 RID: 64577 RVA: 0x0006E993 File Offset: 0x0006CB93
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006081 RID: 24705
		' (get) Token: 0x0600FC42 RID: 64578 RVA: 0x0006E99C File Offset: 0x0006CB9C
		' (set) Token: 0x0600FC43 RID: 64579 RVA: 0x0096F2DC File Offset: 0x0096D4DC
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

		' Token: 0x0600FC44 RID: 64580 RVA: 0x0096F320 File Offset: 0x0096D520
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.dtpDateFrom.Value = DateAndTime.Today
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
			End Try
		End Sub

		' Token: 0x0600FC45 RID: 64581 RVA: 0x0006E9A6 File Offset: 0x0006CBA6
		Private Sub frmPrevSales_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.Getdata()
		End Sub

		' Token: 0x0600FC46 RID: 64582 RVA: 0x0096F410 File Offset: 0x0096D610
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(InvoiceNo), InvoiceDate, RTRIM(Customer.Name), GrandTotal, TotalPaid, Balance from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID Left Join Salesman ON InvoiceInfo.SalesmanID=Salesman.SM_ID where InvoiceDate between @d1 and @d2 order by INv_ID DESC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
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

		' Token: 0x0600FC47 RID: 64583 RVA: 0x0006E9CD File Offset: 0x0006CBCD
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600FC48 RID: 64584 RVA: 0x0006E9A6 File Offset: 0x0006CBA6
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Text = Conversions.ToString(DateAndTime.Today)
			Me.Getdata()
		End Sub

		' Token: 0x0600FC49 RID: 64585 RVA: 0x0096F5C4 File Offset: 0x0096D7C4
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

		' Token: 0x0600FC4A RID: 64586 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPrevSales_KeyDown(sender As Object, e As KeyEventArgs)
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
