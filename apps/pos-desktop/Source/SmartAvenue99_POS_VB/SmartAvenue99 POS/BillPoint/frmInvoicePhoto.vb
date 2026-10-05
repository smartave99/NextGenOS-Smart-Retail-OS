Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000349 RID: 841
	<DesignerGenerated()>
	Public Partial Class frmInvoicePhoto
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C52E RID: 50478 RVA: 0x00058398 File Offset: 0x00056598
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004E43 RID: 20035
		' (get) Token: 0x0600C531 RID: 50481 RVA: 0x000583A6 File Offset: 0x000565A6
		' (set) Token: 0x0600C532 RID: 50482 RVA: 0x000583B0 File Offset: 0x000565B0
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17004E44 RID: 20036
		' (get) Token: 0x0600C533 RID: 50483 RVA: 0x000583B9 File Offset: 0x000565B9
		' (set) Token: 0x0600C534 RID: 50484 RVA: 0x007D02B4 File Offset: 0x007CE4B4
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

		' Token: 0x17004E45 RID: 20037
		' (get) Token: 0x0600C535 RID: 50485 RVA: 0x000583C3 File Offset: 0x000565C3
		' (set) Token: 0x0600C536 RID: 50486 RVA: 0x007D02F8 File Offset: 0x007CE4F8
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

		' Token: 0x17004E46 RID: 20038
		' (get) Token: 0x0600C537 RID: 50487 RVA: 0x000583CD File Offset: 0x000565CD
		' (set) Token: 0x0600C538 RID: 50488 RVA: 0x000583D7 File Offset: 0x000565D7
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004E47 RID: 20039
		' (get) Token: 0x0600C539 RID: 50489 RVA: 0x000583E0 File Offset: 0x000565E0
		' (set) Token: 0x0600C53A RID: 50490 RVA: 0x000583EA File Offset: 0x000565EA
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004E48 RID: 20040
		' (get) Token: 0x0600C53B RID: 50491 RVA: 0x000583F3 File Offset: 0x000565F3
		' (set) Token: 0x0600C53C RID: 50492 RVA: 0x000583FD File Offset: 0x000565FD
		Friend Overridable Property Label1 As Label

		' Token: 0x0600C53D RID: 50493 RVA: 0x007D033C File Offset: 0x007CE53C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update InvImg set Image=@d1 where ID=@d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.TextBox1.Text))
				Dim memoryStream As MemoryStream = New MemoryStream()
				Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
				bitmap.Save(memoryStream, ImageFormat.Jpeg)
				Dim buffer As Byte() = memoryStream.GetBuffer()
				Dim sqlParameter As SqlParameter = New SqlParameter("@d1", SqlDbType.VarBinary)
				sqlParameter.Value = buffer
				ModCommonClasses.cmd.Parameters.Add(sqlParameter)
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
				MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.PictureBox1.Image = Resources.Noimage
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C53E RID: 50494 RVA: 0x007D0478 File Offset: 0x007CE678
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
