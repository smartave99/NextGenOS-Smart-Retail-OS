Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005A8 RID: 1448
	<DesignerGenerated()>
	Public Partial Class frmSalesmanRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011AD4 RID: 72404 RVA: 0x0007984B File Offset: 0x00077A4B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesmanRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesmanRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006DD3 RID: 28115
		' (get) Token: 0x06011AD7 RID: 72407 RVA: 0x0007987D File Offset: 0x00077A7D
		' (set) Token: 0x06011AD8 RID: 72408 RVA: 0x00079887 File Offset: 0x00077A87
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006DD4 RID: 28116
		' (get) Token: 0x06011AD9 RID: 72409 RVA: 0x00079890 File Offset: 0x00077A90
		' (set) Token: 0x06011ADA RID: 72410 RVA: 0x0007989A File Offset: 0x00077A9A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006DD5 RID: 28117
		' (get) Token: 0x06011ADB RID: 72411 RVA: 0x000798A3 File Offset: 0x00077AA3
		' (set) Token: 0x06011ADC RID: 72412 RVA: 0x000798AD File Offset: 0x00077AAD
		Friend Overridable Property Label1 As Label

		' Token: 0x17006DD6 RID: 28118
		' (get) Token: 0x06011ADD RID: 72413 RVA: 0x000798B6 File Offset: 0x00077AB6
		' (set) Token: 0x06011ADE RID: 72414 RVA: 0x000798C0 File Offset: 0x00077AC0
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006DD7 RID: 28119
		' (get) Token: 0x06011ADF RID: 72415 RVA: 0x000798C9 File Offset: 0x00077AC9
		' (set) Token: 0x06011AE0 RID: 72416 RVA: 0x00A37D58 File Offset: 0x00A35F58
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DD8 RID: 28120
		' (get) Token: 0x06011AE1 RID: 72417 RVA: 0x000798D3 File Offset: 0x00077AD3
		' (set) Token: 0x06011AE2 RID: 72418 RVA: 0x000798DD File Offset: 0x00077ADD
		Friend Overridable Property lblSet As Label

		' Token: 0x17006DD9 RID: 28121
		' (get) Token: 0x06011AE3 RID: 72419 RVA: 0x000798E6 File Offset: 0x00077AE6
		' (set) Token: 0x06011AE4 RID: 72420 RVA: 0x000798F0 File Offset: 0x00077AF0
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006DDA RID: 28122
		' (get) Token: 0x06011AE5 RID: 72421 RVA: 0x000798F9 File Offset: 0x00077AF9
		' (set) Token: 0x06011AE6 RID: 72422 RVA: 0x00A37DD4 File Offset: 0x00A35FD4
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DDB RID: 28123
		' (get) Token: 0x06011AE7 RID: 72423 RVA: 0x00079903 File Offset: 0x00077B03
		' (set) Token: 0x06011AE8 RID: 72424 RVA: 0x0007990D File Offset: 0x00077B0D
		Friend Overridable Property Label2 As Label

		' Token: 0x17006DDC RID: 28124
		' (get) Token: 0x06011AE9 RID: 72425 RVA: 0x00079916 File Offset: 0x00077B16
		' (set) Token: 0x06011AEA RID: 72426 RVA: 0x00079920 File Offset: 0x00077B20
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006DDD RID: 28125
		' (get) Token: 0x06011AEB RID: 72427 RVA: 0x00079929 File Offset: 0x00077B29
		' (set) Token: 0x06011AEC RID: 72428 RVA: 0x00A37E18 File Offset: 0x00A36018
		Private _txtSalesmanName As TextBox
		Friend Overridable Property txtSalesmanName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalesmanName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSalesmanName_TextChanged
				Dim textBox As TextBox = Me._txtSalesmanName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSalesmanName = value
				textBox = Me._txtSalesmanName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DDE RID: 28126
		' (get) Token: 0x06011AED RID: 72429 RVA: 0x00079933 File Offset: 0x00077B33
		' (set) Token: 0x06011AEE RID: 72430 RVA: 0x0007993D File Offset: 0x00077B3D
		Friend Overridable Property Label3 As Label

		' Token: 0x17006DDF RID: 28127
		' (get) Token: 0x06011AEF RID: 72431 RVA: 0x00079946 File Offset: 0x00077B46
		' (set) Token: 0x06011AF0 RID: 72432 RVA: 0x00079950 File Offset: 0x00077B50
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17006DE0 RID: 28128
		' (get) Token: 0x06011AF1 RID: 72433 RVA: 0x00079959 File Offset: 0x00077B59
		' (set) Token: 0x06011AF2 RID: 72434 RVA: 0x00A37E5C File Offset: 0x00A3605C
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtContactNo_TextChanged
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DE1 RID: 28129
		' (get) Token: 0x06011AF3 RID: 72435 RVA: 0x00079963 File Offset: 0x00077B63
		' (set) Token: 0x06011AF4 RID: 72436 RVA: 0x0007996D File Offset: 0x00077B6D
		Friend Overridable Property Label4 As Label

		' Token: 0x17006DE2 RID: 28130
		' (get) Token: 0x06011AF5 RID: 72437 RVA: 0x00079976 File Offset: 0x00077B76
		' (set) Token: 0x06011AF6 RID: 72438 RVA: 0x00079980 File Offset: 0x00077B80
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006DE3 RID: 28131
		' (get) Token: 0x06011AF7 RID: 72439 RVA: 0x00079989 File Offset: 0x00077B89
		' (set) Token: 0x06011AF8 RID: 72440 RVA: 0x00079993 File Offset: 0x00077B93
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006DE4 RID: 28132
		' (get) Token: 0x06011AF9 RID: 72441 RVA: 0x0007999C File Offset: 0x00077B9C
		' (set) Token: 0x06011AFA RID: 72442 RVA: 0x000799A6 File Offset: 0x00077BA6
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006DE5 RID: 28133
		' (get) Token: 0x06011AFB RID: 72443 RVA: 0x000799AF File Offset: 0x00077BAF
		' (set) Token: 0x06011AFC RID: 72444 RVA: 0x000799B9 File Offset: 0x00077BB9
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006DE6 RID: 28134
		' (get) Token: 0x06011AFD RID: 72445 RVA: 0x000799C2 File Offset: 0x00077BC2
		' (set) Token: 0x06011AFE RID: 72446 RVA: 0x000799CC File Offset: 0x00077BCC
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006DE7 RID: 28135
		' (get) Token: 0x06011AFF RID: 72447 RVA: 0x000799D5 File Offset: 0x00077BD5
		' (set) Token: 0x06011B00 RID: 72448 RVA: 0x000799DF File Offset: 0x00077BDF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006DE8 RID: 28136
		' (get) Token: 0x06011B01 RID: 72449 RVA: 0x000799E8 File Offset: 0x00077BE8
		' (set) Token: 0x06011B02 RID: 72450 RVA: 0x000799F2 File Offset: 0x00077BF2
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006DE9 RID: 28137
		' (get) Token: 0x06011B03 RID: 72451 RVA: 0x000799FB File Offset: 0x00077BFB
		' (set) Token: 0x06011B04 RID: 72452 RVA: 0x00079A05 File Offset: 0x00077C05
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006DEA RID: 28138
		' (get) Token: 0x06011B05 RID: 72453 RVA: 0x00079A0E File Offset: 0x00077C0E
		' (set) Token: 0x06011B06 RID: 72454 RVA: 0x00079A18 File Offset: 0x00077C18
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006DEB RID: 28139
		' (get) Token: 0x06011B07 RID: 72455 RVA: 0x00079A21 File Offset: 0x00077C21
		' (set) Token: 0x06011B08 RID: 72456 RVA: 0x00079A2B File Offset: 0x00077C2B
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17006DEC RID: 28140
		' (get) Token: 0x06011B09 RID: 72457 RVA: 0x00079A34 File Offset: 0x00077C34
		' (set) Token: 0x06011B0A RID: 72458 RVA: 0x00079A3E File Offset: 0x00077C3E
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006DED RID: 28141
		' (get) Token: 0x06011B0B RID: 72459 RVA: 0x00079A47 File Offset: 0x00077C47
		' (set) Token: 0x06011B0C RID: 72460 RVA: 0x00079A51 File Offset: 0x00077C51
		Friend Overridable Property Column5 As DataGridViewImageColumn

		' Token: 0x17006DEE RID: 28142
		' (get) Token: 0x06011B0D RID: 72461 RVA: 0x00079A5A File Offset: 0x00077C5A
		' (set) Token: 0x06011B0E RID: 72462 RVA: 0x00A37EA0 File Offset: 0x00A360A0
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

		' Token: 0x06011B0F RID: 72463 RVA: 0x00A37EE4 File Offset: 0x00A360E4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman order by name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011B10 RID: 72464 RVA: 0x00A3807C File Offset: 0x00A3627C
		Private Sub txtSalesmanName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where name like N'" + Me.txtSalesmanName.Text + "%' order by name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011B11 RID: 72465 RVA: 0x00A3821C File Offset: 0x00A3641C
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where City like N'" + Me.txtCity.Text + "%' order by Name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011B12 RID: 72466 RVA: 0x00079A64 File Offset: 0x00077C64
		Public Sub Reset()
			Me.txtSalesmanName.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtCity.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x06011B13 RID: 72467 RVA: 0x00A383BC File Offset: 0x00A365BC
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where ContactNo like N'" + Me.txtContactNo.Text + "%' order by Name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011B14 RID: 72468 RVA: 0x00A3855C File Offset: 0x00A3675C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011B15 RID: 72469 RVA: 0x00A38584 File Offset: 0x00A36784
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Salesman Entry", False) = 0
					If flag2 Then
						MyProject.Forms.frmSalesman.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesman.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesman.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesman.cmbSalesmanName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSalesman.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmSalesman.txtCity.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmSalesman.cmbState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmSalesman.txtZipCode.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmSalesman.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSalesman.txtEmailID.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmSalesman.txtCommissionPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmSalesman.txtRemarks.Text = dataGridViewRow.Cells(10).Value.ToString()
						Dim array As Byte() = CType(dataGridViewRow.Cells(11).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						MyProject.Forms.frmSalesman.Picture.Image = Image.FromStream(memoryStream)
						MyProject.Forms.frmSalesman.cmbSalesmanName.Enabled = False
						MyProject.Forms.frmSalesman.btnUpdate.Enabled = True
						MyProject.Forms.frmSalesman.btnSave.Enabled = False
						Me.lblSet.Text = ""
					End If
					Dim flag3 As Boolean = Operators.CompareString(Me.lblSet.Text, "Billing", False) = 0
					If flag3 Then
						MyProject.Forms.frmPOS.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOS.txtSM_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOS.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOS.txtSalesman.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOS.txtCommissionPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.lblSet.Text, "BillingTouch", False) = 0
					If flag4 Then
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSTouch.txtSM_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtSalesman.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCommissionPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag5 As Boolean = Operators.CompareString(Me.lblSet.Text, "BillingTouchNew", False) = 0
					If flag5 Then
						MyProject.Forms.frmPOSNewTuch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch.txtSM_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtSalesman.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCommissionPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag6 As Boolean = Operators.CompareString(Me.lblSet.Text, "BillingTouchNew_Quotation", False) = 0
					If flag6 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtSM_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtSalesman.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCommissionPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag7 As Boolean = Operators.CompareString(Me.lblSet.Text, "Salesman Ledger", False) = 0
					If flag7 Then
						MyProject.Forms.frmSalesmanLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesmanLedger.txtSalesmanID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesmanLedger.txtSalesmanName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag8 As Boolean = Operators.CompareString(Me.lblSet.Text, "Salesman LedgerNew", False) = 0
					If flag8 Then
						MyProject.Forms.frmSalesmanLedgerNew.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesmanLedgerNew.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesmanLedgerNew.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesmanLedgerNew.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag9 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag9 Then
						MyProject.Forms.frmSalesManPayment.Show()
						MyBase.Hide()
						MyProject.Forms.frmSalesManPayment.txtCustID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmSalesManPayment.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmSalesManPayment.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmSalesManPayment.GetCustomerBalance()
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011B16 RID: 72470 RVA: 0x00079AA1 File Offset: 0x00077CA1
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011B17 RID: 72471 RVA: 0x00A38F18 File Offset: 0x00A37118
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

		' Token: 0x06011B18 RID: 72472 RVA: 0x00A39000 File Offset: 0x00A37200
		Private Sub frmSalesmanRecord_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011B19 RID: 72473 RVA: 0x00A39088 File Offset: 0x00A37288
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

		' Token: 0x06011B1A RID: 72474 RVA: 0x00A39200 File Offset: 0x00A37400
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x06011B1B RID: 72475 RVA: 0x00A392CC File Offset: 0x00A374CC
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

		' Token: 0x06011B1C RID: 72476 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011B1D RID: 72477 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011B1E RID: 72478 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011B1F RID: 72479 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesmanRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011B20 RID: 72480 RVA: 0x00A39398 File Offset: 0x00A37598
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "BillingTouch", False) = 0
			If flag Then
				MyProject.Forms.frmPOSTouch.Show()
				MyBase.Hide()
				MyProject.Forms.frmPOSTouch.txtSM_ID.Text = ""
				MyProject.Forms.frmPOSTouch.txtSalesmanID.Text = ""
				MyProject.Forms.frmPOSTouch.txtSalesman.Text = ""
				MyProject.Forms.frmPOSTouch.txtCommissionPer.Text = ""
				Me.lblSet.Text = ""
			End If
		End Sub
	End Class
End Namespace
