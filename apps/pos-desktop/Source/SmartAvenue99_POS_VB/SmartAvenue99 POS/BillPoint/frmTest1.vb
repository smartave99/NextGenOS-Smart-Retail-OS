Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200020D RID: 525
	<DesignerGenerated()>
	Public Partial Class frmTest1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060098B1 RID: 39089 RVA: 0x006D9C48 File Offset: 0x006D7E48
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTest1_Load
			Me.UserButtons = New List(Of GelButton)()
			Me.mydict = New Dictionary(Of String, String)()
			Me.UserButtons1 = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170038BC RID: 14524
		' (get) Token: 0x060098B4 RID: 39092 RVA: 0x0004A9D3 File Offset: 0x00048BD3
		' (set) Token: 0x060098B5 RID: 39093 RVA: 0x0004A9DD File Offset: 0x00048BDD
		Friend Overridable Property Panel16 As Panel

		' Token: 0x170038BD RID: 14525
		' (get) Token: 0x060098B6 RID: 39094 RVA: 0x0004A9E6 File Offset: 0x00048BE6
		' (set) Token: 0x060098B7 RID: 39095 RVA: 0x0004A9F0 File Offset: 0x00048BF0
		Friend Overridable Property flpItems_BV As FlowLayoutPanel

		' Token: 0x170038BE RID: 14526
		' (get) Token: 0x060098B8 RID: 39096 RVA: 0x0004A9F9 File Offset: 0x00048BF9
		' (set) Token: 0x060098B9 RID: 39097 RVA: 0x0004AA03 File Offset: 0x00048C03
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x170038BF RID: 14527
		' (get) Token: 0x060098BA RID: 39098 RVA: 0x0004AA0C File Offset: 0x00048C0C
		' (set) Token: 0x060098BB RID: 39099 RVA: 0x0004AA16 File Offset: 0x00048C16
		Friend Overridable Property flpItemsCategory As FlowLayoutPanel

		' Token: 0x170038C0 RID: 14528
		' (get) Token: 0x060098BC RID: 39100 RVA: 0x0004AA1F File Offset: 0x00048C1F
		' (set) Token: 0x060098BD RID: 39101 RVA: 0x0004AA29 File Offset: 0x00048C29
		Friend Overridable Property Label130 As Label

		' Token: 0x170038C1 RID: 14529
		' (get) Token: 0x060098BE RID: 39102 RVA: 0x0004AA32 File Offset: 0x00048C32
		' (set) Token: 0x060098BF RID: 39103 RVA: 0x0004AA3C File Offset: 0x00048C3C
		Friend Overridable Property btnCategory As Button

		' Token: 0x170038C2 RID: 14530
		' (get) Token: 0x060098C0 RID: 39104 RVA: 0x0004AA45 File Offset: 0x00048C45
		' (set) Token: 0x060098C1 RID: 39105 RVA: 0x0004AA4F File Offset: 0x00048C4F
		Friend Overridable Property btnSubCategory As Button

		' Token: 0x060098C2 RID: 39106 RVA: 0x006DA074 File Offset: 0x006D8274
		Public Sub FillCategory()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(category_name),id from tbl_master_menu_header order by orderby"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.flpItemsCategory.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim gelButton As GelButton = New GelButton()
					Me.Label130.Text = ""
					gelButton.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					gelButton.Tag = RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(1))
					Me.Label130.Text = gelButton.Text
					Me.mydict(gelButton.Text) = Conversions.ToString(gelButton.Tag)
					gelButton.TextAlign = ContentAlignment.MiddleCenter
					gelButton.FlatAppearance.BorderSize = 0
					gelButton.GradientBottom = Color.SteelBlue
					gelButton.GradientTop = Color.RoyalBlue
					gelButton.ForeColor = Color.White
					gelButton.FlatStyle = FlatStyle.Flat
					gelButton.Width = 90
					gelButton.Height = 40
					gelButton.Font = New Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(gelButton)
					Me.flpItemsCategory.Controls.Add(gelButton)
					AddHandler gelButton.Click, AddressOf Me.btnCategory_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060098C3 RID: 39107 RVA: 0x006DA264 File Offset: 0x006D8464
		Public Sub FillSubCategory(strCategory As String)
			Dim num As Integer = 120
			Dim num2 As Integer = 120
			Dim num3 As Integer = 20
			Dim num4 As Integer = 30
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img FROM tbl_master_menu WHERE category_name = @Category"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Category", strCategory)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim num5 As Short = Conversions.ToShort(sqlDataReader.GetValue(1))
							Dim array As Byte() = If((Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))), CType(sqlDataReader("icon_img"), Byte()), Nothing)
							Dim button As Button = New Button()
							button.Tag = num5
							button.Size = New Size(num, num2)
							button.BackColor = Color.White
							button.FlatStyle = FlatStyle.Flat
							button.FlatAppearance.BorderSize = 0
							button.Margin = New Padding(num3)
							Dim flag As Boolean = array IsNot Nothing
							If flag Then
								Using memoryStream As MemoryStream = New MemoryStream(array)
									Dim image As Image = Image.FromStream(memoryStream)
									button.BackgroundImage = New Bitmap(image, New Size(num, num2))
									button.BackgroundImageLayout = ImageLayout.Stretch
								End Using
							End If
							Dim graphicsPath As GraphicsPath = New GraphicsPath()
							graphicsPath.AddArc(0, 0, num4, num4, 180F, 90F)
							graphicsPath.AddArc(button.Width - num4, 0, num4, num4, 270F, 90F)
							graphicsPath.AddArc(button.Width - num4, button.Height - num4, num4, num4, 0F, 90F)
							graphicsPath.AddArc(0, button.Height - num4, num4, num4, 90F, 90F)
							graphicsPath.CloseFigure()
							button.Region = New Region(graphicsPath)
							AddHandler button.Click, AddressOf Me.btnSubCategory_Click
							Me.flpItems_BV.Controls.Add(button)
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x060098C4 RID: 39108 RVA: 0x0004AA58 File Offset: 0x00048C58
		Private Sub frmTest1_Load(sender As Object, e As EventArgs)
			Me.FillCategory()
		End Sub

		' Token: 0x060098C5 RID: 39109 RVA: 0x006DA530 File Offset: 0x006D8730
		Private Async Sub btnCategory_Click(sender As Object, e As EventArgs)
			Dim btnClicked As GelButton = CType(sender, GelButton)
			Dim categoryID As String = Me.mydict(btnClicked.Text)
			Me.FillSubCategory(btnClicked.Text)
			Application.DoEvents()
		End Sub

		' Token: 0x060098C6 RID: 39110 RVA: 0x006DA578 File Offset: 0x006D8778
		Private Function GetFormType(index As Integer) As Type
			Dim type As Type
			Select Case index
				Case 1
					type = GetType(Form1)
				Case 2
					type = GetType(Form2)
				Case 3
					type = GetType(Form3)
				Case Else
					type = Nothing
			End Select
			Return type
		End Function

		' Token: 0x060098C7 RID: 39111 RVA: 0x0004AA62 File Offset: 0x00048C62
		Public Sub frmPOSTouch1()
			MyProject.Forms.frmPOSTouch.Reset()
			MyProject.Forms.frmPOSTouch.ShowDialog()
			MyProject.Forms.frmPOSTouch.Dispose()
		End Sub

		' Token: 0x060098C8 RID: 39112 RVA: 0x006DA5D0 File Offset: 0x006D87D0
		Private Sub btnSubCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = button.Tag IsNot Nothing
				If flag Then
					Dim num As Integer = Conversions.ToInteger(button.Tag)
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, form_name FROM tbl_master_menu WHERE id = @id"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@id", num)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Dim text2 As String = sqlDataReader("form_name").ToString().Trim()
									Dim text3 As String = "BillPoint." + text2
									Dim assembly As Assembly = Assembly.GetExecutingAssembly()
									Dim type As Type = assembly.[GetType](text3)
									Dim flag3 As Boolean = type IsNot Nothing AndAlso GetType(Form).IsAssignableFrom(type)
									If flag3 Then
										Dim form As Form = CType(Activator.CreateInstance(type), Form)
										form.ShowDialog()
									Else
										MessageBox.Show("Form '" + text2 + "' not found or not a valid Form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End If
								End If
							End Using
						End Using
					End Using
				Else
					MessageBox.Show("Button tag is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0400438F RID: 17295
		Private UserButtons As List(Of GelButton)

		' Token: 0x04004390 RID: 17296
		Private mydict As Dictionary(Of String, String)

		' Token: 0x04004393 RID: 17299
		Private UserButtons1 As List(Of Button)
	End Class
End Namespace
