Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A7 RID: 1191
	<DesignerGenerated()>
	Public Partial Class FormCamera
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EC56 RID: 60502 RVA: 0x00067854 File Offset: 0x00065A54
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AAC RID: 23212
		' (get) Token: 0x0600EC59 RID: 60505 RVA: 0x00067862 File Offset: 0x00065A62
		' (set) Token: 0x0600EC5A RID: 60506 RVA: 0x0006786C File Offset: 0x00065A6C
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17005AAD RID: 23213
		' (get) Token: 0x0600EC5B RID: 60507 RVA: 0x00067875 File Offset: 0x00065A75
		' (set) Token: 0x0600EC5C RID: 60508 RVA: 0x0006787F File Offset: 0x00065A7F
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17005AAE RID: 23214
		' (get) Token: 0x0600EC5D RID: 60509 RVA: 0x00067888 File Offset: 0x00065A88
		' (set) Token: 0x0600EC5E RID: 60510 RVA: 0x00067892 File Offset: 0x00065A92
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17005AAF RID: 23215
		' (get) Token: 0x0600EC5F RID: 60511 RVA: 0x0006789B File Offset: 0x00065A9B
		' (set) Token: 0x0600EC60 RID: 60512 RVA: 0x008E5314 File Offset: 0x008E3514
		Private _BtnStart As Button
		Friend Overridable Property BtnStart As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnStart
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnStart_Click
				Dim button As Button = Me._BtnStart
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnStart = value
				button = Me._BtnStart
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB0 RID: 23216
		' (get) Token: 0x0600EC61 RID: 60513 RVA: 0x000678A5 File Offset: 0x00065AA5
		' (set) Token: 0x0600EC62 RID: 60514 RVA: 0x008E5358 File Offset: 0x008E3558
		Private _BtnCapt As Button
		Friend Overridable Property BtnCapt As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnCapt
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnCapt_Click
				Dim button As Button = Me._BtnCapt
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnCapt = value
				button = Me._BtnCapt
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB1 RID: 23217
		' (get) Token: 0x0600EC63 RID: 60515 RVA: 0x000678AF File Offset: 0x00065AAF
		' (set) Token: 0x0600EC64 RID: 60516 RVA: 0x008E539C File Offset: 0x008E359C
		Private _BtnSave As Button
		Friend Overridable Property BtnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnSave_Click
				Dim button As Button = Me._BtnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnSave = value
				button = Me._BtnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB2 RID: 23218
		' (get) Token: 0x0600EC65 RID: 60517 RVA: 0x000678B9 File Offset: 0x00065AB9
		' (set) Token: 0x0600EC66 RID: 60518 RVA: 0x008E53E0 File Offset: 0x008E35E0
		Private _BtnStop As Button
		Friend Overridable Property BtnStop As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnStop
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnStop_Click
				Dim button As Button = Me._BtnStop
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnStop = value
				button = Me._BtnStop
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB3 RID: 23219
		' (get) Token: 0x0600EC67 RID: 60519 RVA: 0x000678C3 File Offset: 0x00065AC3
		' (set) Token: 0x0600EC68 RID: 60520 RVA: 0x000678CD File Offset: 0x00065ACD
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005AB4 RID: 23220
		' (get) Token: 0x0600EC69 RID: 60521 RVA: 0x000678D6 File Offset: 0x00065AD6
		' (set) Token: 0x0600EC6A RID: 60522 RVA: 0x008E5424 File Offset: 0x008E3624
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB5 RID: 23221
		' (get) Token: 0x0600EC6B RID: 60523 RVA: 0x000678E0 File Offset: 0x00065AE0
		' (set) Token: 0x0600EC6C RID: 60524 RVA: 0x008E5468 File Offset: 0x008E3668
		Private _BtnRmv As Button
		Friend Overridable Property BtnRmv As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnRmv
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BtnRmv_Click
				Dim button As Button = Me._BtnRmv
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BtnRmv = value
				button = Me._BtnRmv
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005AB6 RID: 23222
		' (get) Token: 0x0600EC6D RID: 60525 RVA: 0x000678EA File Offset: 0x00065AEA
		' (set) Token: 0x0600EC6E RID: 60526 RVA: 0x000678F4 File Offset: 0x00065AF4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x0600EC6F RID: 60527 RVA: 0x008E54AC File Offset: 0x008E36AC
		Private Sub BtnStart_Click(sender As Object, e As EventArgs)
			Dim videoCaptureDeviceForm As VideoCaptureDeviceForm = New VideoCaptureDeviceForm()
			Dim flag As Boolean = videoCaptureDeviceForm.ShowDialog() = DialogResult.OK
			If flag Then
				Me.CAMARA = videoCaptureDeviceForm.VideoDevice
				AddHandler Me.CAMARA.NewFrame, AddressOf Me.Captured
				Me.CAMARA.Start()
				Me.BtnStart.Visible = False
				Me.BtnStop.Visible = True
				Me.BtnCapt.Visible = True
				Me.BtnSave.Visible = True
				Me.Button1.Visible = False
				Me.BtnRmv.Visible = True
			End If
		End Sub

		' Token: 0x0600EC70 RID: 60528 RVA: 0x000678FD File Offset: 0x00065AFD
		Private Sub Captured(sender As Object, eventArgs As NewFrameEventArgs)
			Me.BMP = CType(eventArgs.Frame.Clone(), Bitmap)
			Me.PictureBox1.Image = CType(eventArgs.Frame.Clone(), Bitmap)
		End Sub

		' Token: 0x0600EC71 RID: 60529 RVA: 0x00067932 File Offset: 0x00065B32
		Private Sub BtnCapt_Click(sender As Object, e As EventArgs)
			Me.PictureBox2.Image = Me.PictureBox1.Image
		End Sub

		' Token: 0x0600EC72 RID: 60530 RVA: 0x008E5550 File Offset: 0x008E3750
		Private Sub BtnSave_Click(sender As Object, e As EventArgs)
			Me.SaveFileDialog1.DefaultExt = ".jpg"
			Dim flag As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
			If flag Then
				Me.PictureBox2.Image.Save(Me.SaveFileDialog1.FileName, ImageFormat.Jpeg)
			End If
		End Sub

		' Token: 0x0600EC73 RID: 60531 RVA: 0x008E55A4 File Offset: 0x008E37A4
		Private Sub BtnStop_Click(sender As Object, e As EventArgs)
			Me.CAMARA.[Stop]()
			Me.PictureBox1.Image = Nothing
			Me.PictureBox1.BackColor = Color.Black
			Me.PictureBox1.Invalidate()
			Me.PictureBox2.Image = Nothing
			Me.PictureBox2.BackColor = Color.Black
			Me.PictureBox2.Invalidate()
			Me.BtnStart.Visible = True
			Me.BtnCapt.Visible = False
			Me.BtnSave.Visible = False
			Me.BtnStop.Visible = False
			MyBase.Close()
		End Sub

		' Token: 0x0600EC74 RID: 60532 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600EC75 RID: 60533 RVA: 0x0006794C File Offset: 0x00065B4C
		Private Sub BtnRmv_Click(sender As Object, e As EventArgs)
			Me.PictureBox2.Image = Nothing
		End Sub

		' Token: 0x04005A49 RID: 23113
		Private CAMARA As VideoCaptureDevice

		' Token: 0x04005A4A RID: 23114
		Private BMP As Bitmap
	End Class
End Namespace
