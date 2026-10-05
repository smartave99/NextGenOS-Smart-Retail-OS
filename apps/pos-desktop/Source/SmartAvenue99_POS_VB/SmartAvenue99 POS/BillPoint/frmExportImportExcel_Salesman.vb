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
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000344 RID: 836
	<DesignerGenerated()>
	Public Partial Class frmExportImportExcel_Salesman
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C38F RID: 50063 RVA: 0x00057739 File Offset: 0x00055939
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExportImportExcel_Salesman_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExportImportExcel_Salesman_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004DA7 RID: 19879
		' (get) Token: 0x0600C392 RID: 50066 RVA: 0x0005776B File Offset: 0x0005596B
		' (set) Token: 0x0600C393 RID: 50067 RVA: 0x00057775 File Offset: 0x00055975
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004DA8 RID: 19880
		' (get) Token: 0x0600C394 RID: 50068 RVA: 0x0005777E File Offset: 0x0005597E
		' (set) Token: 0x0600C395 RID: 50069 RVA: 0x007C42EC File Offset: 0x007C24EC
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

		' Token: 0x17004DA9 RID: 19881
		' (get) Token: 0x0600C396 RID: 50070 RVA: 0x00057788 File Offset: 0x00055988
		' (set) Token: 0x0600C397 RID: 50071 RVA: 0x007C4330 File Offset: 0x007C2530
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

		' Token: 0x17004DAA RID: 19882
		' (get) Token: 0x0600C398 RID: 50072 RVA: 0x00057792 File Offset: 0x00055992
		' (set) Token: 0x0600C399 RID: 50073 RVA: 0x0005779C File Offset: 0x0005599C
		Friend Overridable Property Label1 As Label

		' Token: 0x17004DAB RID: 19883
		' (get) Token: 0x0600C39A RID: 50074 RVA: 0x000577A5 File Offset: 0x000559A5
		' (set) Token: 0x0600C39B RID: 50075 RVA: 0x000577AF File Offset: 0x000559AF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004DAC RID: 19884
		' (get) Token: 0x0600C39C RID: 50076 RVA: 0x000577B8 File Offset: 0x000559B8
		' (set) Token: 0x0600C39D RID: 50077 RVA: 0x007C4374 File Offset: 0x007C2574
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

		' Token: 0x17004DAD RID: 19885
		' (get) Token: 0x0600C39E RID: 50078 RVA: 0x000577C2 File Offset: 0x000559C2
		' (set) Token: 0x0600C39F RID: 50079 RVA: 0x000577CC File Offset: 0x000559CC
		Friend Overridable Property Label2 As Label

		' Token: 0x17004DAE RID: 19886
		' (get) Token: 0x0600C3A0 RID: 50080 RVA: 0x000577D5 File Offset: 0x000559D5
		' (set) Token: 0x0600C3A1 RID: 50081 RVA: 0x000577DF File Offset: 0x000559DF
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004DAF RID: 19887
		' (get) Token: 0x0600C3A2 RID: 50082 RVA: 0x000577E8 File Offset: 0x000559E8
		' (set) Token: 0x0600C3A3 RID: 50083 RVA: 0x007C43B8 File Offset: 0x007C25B8
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004DB0 RID: 19888
		' (get) Token: 0x0600C3A4 RID: 50084 RVA: 0x000577F2 File Offset: 0x000559F2
		' (set) Token: 0x0600C3A5 RID: 50085 RVA: 0x000577FC File Offset: 0x000559FC
		Friend Overridable Property Label3 As Label

		' Token: 0x17004DB1 RID: 19889
		' (get) Token: 0x0600C3A6 RID: 50086 RVA: 0x00057805 File Offset: 0x00055A05
		' (set) Token: 0x0600C3A7 RID: 50087 RVA: 0x007C43FC File Offset: 0x007C25FC
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

		' Token: 0x17004DB2 RID: 19890
		' (get) Token: 0x0600C3A8 RID: 50088 RVA: 0x0005780F File Offset: 0x00055A0F
		' (set) Token: 0x0600C3A9 RID: 50089 RVA: 0x007C4440 File Offset: 0x007C2640
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

		' Token: 0x17004DB3 RID: 19891
		' (get) Token: 0x0600C3AA RID: 50090 RVA: 0x00057819 File Offset: 0x00055A19
		' (set) Token: 0x0600C3AB RID: 50091 RVA: 0x00057823 File Offset: 0x00055A23
		Friend Overridable Property FolderBrowserDialog1 As FolderBrowserDialog

		' Token: 0x17004DB4 RID: 19892
		' (get) Token: 0x0600C3AC RID: 50092 RVA: 0x0005782C File Offset: 0x00055A2C
		' (set) Token: 0x0600C3AD RID: 50093 RVA: 0x00057836 File Offset: 0x00055A36
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004DB5 RID: 19893
		' (get) Token: 0x0600C3AE RID: 50094 RVA: 0x0005783F File Offset: 0x00055A3F
		' (set) Token: 0x0600C3AF RID: 50095 RVA: 0x00057849 File Offset: 0x00055A49
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004DB6 RID: 19894
		' (get) Token: 0x0600C3B0 RID: 50096 RVA: 0x00057852 File Offset: 0x00055A52
		' (set) Token: 0x0600C3B1 RID: 50097 RVA: 0x0005785C File Offset: 0x00055A5C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004DB7 RID: 19895
		' (get) Token: 0x0600C3B2 RID: 50098 RVA: 0x00057865 File Offset: 0x00055A65
		' (set) Token: 0x0600C3B3 RID: 50099 RVA: 0x0005786F File Offset: 0x00055A6F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004DB8 RID: 19896
		' (get) Token: 0x0600C3B4 RID: 50100 RVA: 0x00057878 File Offset: 0x00055A78
		' (set) Token: 0x0600C3B5 RID: 50101 RVA: 0x00057882 File Offset: 0x00055A82
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004DB9 RID: 19897
		' (get) Token: 0x0600C3B6 RID: 50102 RVA: 0x0005788B File Offset: 0x00055A8B
		' (set) Token: 0x0600C3B7 RID: 50103 RVA: 0x00057895 File Offset: 0x00055A95
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004DBA RID: 19898
		' (get) Token: 0x0600C3B8 RID: 50104 RVA: 0x0005789E File Offset: 0x00055A9E
		' (set) Token: 0x0600C3B9 RID: 50105 RVA: 0x000578A8 File Offset: 0x00055AA8
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004DBB RID: 19899
		' (get) Token: 0x0600C3BA RID: 50106 RVA: 0x000578B1 File Offset: 0x00055AB1
		' (set) Token: 0x0600C3BB RID: 50107 RVA: 0x000578BB File Offset: 0x00055ABB
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004DBC RID: 19900
		' (get) Token: 0x0600C3BC RID: 50108 RVA: 0x000578C4 File Offset: 0x00055AC4
		' (set) Token: 0x0600C3BD RID: 50109 RVA: 0x000578CE File Offset: 0x00055ACE
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004DBD RID: 19901
		' (get) Token: 0x0600C3BE RID: 50110 RVA: 0x000578D7 File Offset: 0x00055AD7
		' (set) Token: 0x0600C3BF RID: 50111 RVA: 0x000578E1 File Offset: 0x00055AE1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004DBE RID: 19902
		' (get) Token: 0x0600C3C0 RID: 50112 RVA: 0x000578EA File Offset: 0x00055AEA
		' (set) Token: 0x0600C3C1 RID: 50113 RVA: 0x000578F4 File Offset: 0x00055AF4
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004DBF RID: 19903
		' (get) Token: 0x0600C3C2 RID: 50114 RVA: 0x000578FD File Offset: 0x00055AFD
		' (set) Token: 0x0600C3C3 RID: 50115 RVA: 0x00057907 File Offset: 0x00055B07
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004DC0 RID: 19904
		' (get) Token: 0x0600C3C4 RID: 50116 RVA: 0x00057910 File Offset: 0x00055B10
		' (set) Token: 0x0600C3C5 RID: 50117 RVA: 0x007C4484 File Offset: 0x007C2684
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

		' Token: 0x17004DC1 RID: 19905
		' (get) Token: 0x0600C3C6 RID: 50118 RVA: 0x0005791A File Offset: 0x00055B1A
		' (set) Token: 0x0600C3C7 RID: 50119 RVA: 0x007C44C8 File Offset: 0x007C26C8
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

		' Token: 0x17004DC2 RID: 19906
		' (get) Token: 0x0600C3C8 RID: 50120 RVA: 0x00057924 File Offset: 0x00055B24
		' (set) Token: 0x0600C3C9 RID: 50121 RVA: 0x007C450C File Offset: 0x007C270C
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

		' Token: 0x17004DC3 RID: 19907
		' (get) Token: 0x0600C3CA RID: 50122 RVA: 0x0005792E File Offset: 0x00055B2E
		' (set) Token: 0x0600C3CB RID: 50123 RVA: 0x007C4550 File Offset: 0x007C2750
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600C3CC RID: 50124 RVA: 0x007C4594 File Offset: 0x007C2794
		Public Sub Getdata()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SM_ID,RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman Order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C3CD RID: 50125 RVA: 0x007C4744 File Offset: 0x007C2944
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

		' Token: 0x0600C3CE RID: 50126 RVA: 0x007C482C File Offset: 0x007C2A2C
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(SM_ID),RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman where name like N'%" + Me.txtCustomerName.Text + "%' Order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C3CF RID: 50127 RVA: 0x007C49E8 File Offset: 0x007C2BE8
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				SqlConnection.ClearAllPools()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(SM_ID),RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks) from Salesman where City like N'%" + Me.txtCity.Text + "%' Order by SM_ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C3D0 RID: 50128 RVA: 0x007C4BA4 File Offset: 0x007C2DA4
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.Visible = False
			Me.txtCity.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600C3D1 RID: 50129 RVA: 0x00057938 File Offset: 0x00055B38
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C3D2 RID: 50130 RVA: 0x007C4BF8 File Offset: 0x007C2DF8
		Private Sub frmExportImportExcel_Salesman_Load(sender As Object, e As EventArgs)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C3D3 RID: 50131 RVA: 0x007C4CE8 File Offset: 0x007C2EE8
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

		' Token: 0x0600C3D4 RID: 50132 RVA: 0x007C4E60 File Offset: 0x007C3060
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

		' Token: 0x0600C3D5 RID: 50133 RVA: 0x007C4F1C File Offset: 0x007C311C
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

		' Token: 0x0600C3D6 RID: 50134 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C3D7 RID: 50135 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C3D8 RID: 50136 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C3D9 RID: 50137 RVA: 0x007C4FE8 File Offset: 0x007C31E8
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

		' Token: 0x0600C3DA RID: 50138 RVA: 0x007C50D0 File Offset: 0x007C32D0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C3DB RID: 50139 RVA: 0x007C537C File Offset: 0x007C357C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
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

		' Token: 0x0600C3DC RID: 50140 RVA: 0x007C5480 File Offset: 0x007C3680
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
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
				Try
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
								MessageBox.Show("Salesman ID Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num3 As Integer = Me.DataGridView1.RowCount - 1
						For k As Integer = 0 To num3
							Dim flag6 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(k).Cells(2).Value.ToString(), "", False) = 0
							If flag6 Then
								MessageBox.Show("Salesman Name Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num4 As Integer = Me.DataGridView1.RowCount - 1
						For l As Integer = 0 To num4
							Dim flag7 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(l).Cells(3).Value.ToString(), "", False) = 0
							If flag7 Then
								MessageBox.Show("Address Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num5 As Integer = Me.DataGridView1.RowCount - 1
						For m As Integer = 0 To num5
							Dim flag8 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(m).Cells(4).Value.ToString(), "", False) = 0
							If flag8 Then
								MessageBox.Show("City Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num6 As Integer = Me.DataGridView1.RowCount - 1
						For n As Integer = 0 To num6
							Dim flag9 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(n).Cells(5).Value.ToString(), "", False) = 0
							If flag9 Then
								MessageBox.Show("State Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Dim num7 As Integer = Me.DataGridView1.RowCount - 1
						For num8 As Integer = 0 To num7
							Dim flag10 As Boolean = Operators.CompareString(Me.DataGridView1.Rows(num8).Cells(7).Value.ToString(), "", False) = 0
							If flag10 Then
								MessageBox.Show("Contact No. Cell Blank Found", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Return
							End If
						Next
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Dim flag11 As Boolean = Not dataGridViewRow.IsNewRow
								If flag11 Then
									SqlConnection.ClearAllPools()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = "select SM_ID from Salesman Where SM_ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
									If flag12 Then
										MessageBox.Show("Same Salesman ID detected", "Check", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Return
									End If
									Dim flag13 As Boolean = Not ModCommonClasses.rdr.Read()
									If flag13 Then
										Me.Cursor = Cursors.WaitCursor
										Me.Timer1.Enabled = True
										SqlConnection.ClearAllPools()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into Salesman(SM_ID,Salesman_ID,[Name],Address,City,State,ZipCode,ContactNo,EmailID,CommissionPer,Remarks,Photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(1).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow.Cells(2).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells(3).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow.Cells(4).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(5).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow.Cells(6).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow.Cells(7).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow.Cells(8).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow.Cells(9).Value.ToString())
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(10).Value.ToString())
										Dim memoryStream As MemoryStream = New MemoryStream()
										Dim bitmap As Bitmap = New Bitmap(Resources.photo)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim buffer As Byte() = memoryStream.GetBuffer()
										Dim sqlParameter As SqlParameter = New SqlParameter("@d12", SqlDbType.Image)
										sqlParameter.Value = buffer
										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
									End If
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.DataGridView1.DataSource = Nothing
						Me.Reset()
					End If
				Catch ex As SqlException
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600C3DD RID: 50141 RVA: 0x00057954 File Offset: 0x00055B54
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C3DE RID: 50142 RVA: 0x007C5CE8 File Offset: 0x007C3EE8
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim folderBrowserDialog As FolderBrowserDialog = Me.FolderBrowserDialog1
			Dim flag As Boolean = Me.FolderBrowserDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Dim selectedPath As String = folderBrowserDialog.SelectedPath
				File.WriteAllBytes(selectedPath + "\Salesman_Format.xls", Resources.Salesman_Format)
				Dim flag2 As Boolean = MyProject.Computer.FileSystem.FileExists(selectedPath + "\Salesman_Format.xls")
				If flag2 Then
					File.Delete(selectedPath + "\Salesman_Format.xls")
					File.WriteAllBytes(selectedPath + "\Salesman_Format.xls", Resources.Salesman_Format)
					MessageBox.Show("Successfully Saved" & vbLf, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					MessageBox.Show("Not Saved" & vbLf, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x0600C3DF RID: 50143 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExportImportExcel_Salesman_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04004E7F RID: 20095
		Private num1 As Decimal

		' Token: 0x04004E80 RID: 20096
		Private num2 As Decimal

		' Token: 0x04004E81 RID: 20097
		Private num3 As Decimal

		' Token: 0x04004E82 RID: 20098
		Private str As String
	End Class
End Namespace
