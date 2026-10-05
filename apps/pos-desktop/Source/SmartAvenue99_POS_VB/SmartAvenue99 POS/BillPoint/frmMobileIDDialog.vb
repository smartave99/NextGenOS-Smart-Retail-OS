Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000133 RID: 307
	<DesignerGenerated()>
	Public Partial Class frmMobileIDDialog
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600348D RID: 13453 RVA: 0x00020512 File Offset: 0x0001E712
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMobileIDDialog_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmMobileIDDialog_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001455 RID: 5205
		' (get) Token: 0x06003490 RID: 13456 RVA: 0x00020544 File Offset: 0x0001E744
		' (set) Token: 0x06003491 RID: 13457 RVA: 0x0002054E File Offset: 0x0001E74E
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17001456 RID: 5206
		' (get) Token: 0x06003492 RID: 13458 RVA: 0x00020557 File Offset: 0x0001E757
		' (set) Token: 0x06003493 RID: 13459 RVA: 0x00207238 File Offset: 0x00205438
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001457 RID: 5207
		' (get) Token: 0x06003494 RID: 13460 RVA: 0x00020561 File Offset: 0x0001E761
		' (set) Token: 0x06003495 RID: 13461 RVA: 0x0020727C File Offset: 0x0020547C
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001458 RID: 5208
		' (get) Token: 0x06003496 RID: 13462 RVA: 0x0002056B File Offset: 0x0001E76B
		' (set) Token: 0x06003497 RID: 13463 RVA: 0x002072C0 File Offset: 0x002054C0
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

		' Token: 0x17001459 RID: 5209
		' (get) Token: 0x06003498 RID: 13464 RVA: 0x00020575 File Offset: 0x0001E775
		' (set) Token: 0x06003499 RID: 13465 RVA: 0x0002057F File Offset: 0x0001E77F
		Friend Overridable Property Label19 As Label

		' Token: 0x1700145A RID: 5210
		' (get) Token: 0x0600349A RID: 13466 RVA: 0x00020588 File Offset: 0x0001E788
		' (set) Token: 0x0600349B RID: 13467 RVA: 0x00207304 File Offset: 0x00205504
		Private _txtAndroidID As TextBox
		Friend Overridable Property txtAndroidID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAndroidID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtAndroidID_TextChanged
				Dim textBox As TextBox = Me._txtAndroidID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtAndroidID = value
				textBox = Me._txtAndroidID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700145B RID: 5211
		' (get) Token: 0x0600349C RID: 13468 RVA: 0x00020592 File Offset: 0x0001E792
		' (set) Token: 0x0600349D RID: 13469 RVA: 0x0002059C File Offset: 0x0001E79C
		Friend Overridable Property PictureBox3 As PictureBox

		' Token: 0x1700145C RID: 5212
		' (get) Token: 0x0600349E RID: 13470 RVA: 0x000205A5 File Offset: 0x0001E7A5
		' (set) Token: 0x0600349F RID: 13471 RVA: 0x00207348 File Offset: 0x00205548
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

		' Token: 0x060034A0 RID: 13472 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x060034A1 RID: 13473 RVA: 0x0001A354 File Offset: 0x00018554
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.Close()
		End Sub

		' Token: 0x060034A2 RID: 13474 RVA: 0x0020738C File Offset: 0x0020558C
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.Form2.PictureBox1.Image = Me.PictureBox3.Image
			Try
				Dim screen As Screen = Screen.AllScreens(1)
				MyProject.Forms.Form2.StartPosition = FormStartPosition.Manual
				MyProject.Forms.Form2.Location = screen.Bounds.Location + CType(New Point(100, 100), Size)
				MyProject.Forms.Form2.Show()
			Catch ex As Exception
				MessageBox.Show("Extend display monitor not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060034A3 RID: 13475 RVA: 0x0020744C File Offset: 0x0020564C
		Private Sub AndroidIDGenerate()
			Try
				Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
				qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
				qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
				Me.PictureBox3.Image = qrcodeEncoder.Encode(Me.txtAndroidID.Text, Encoding.UTF8)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060034A4 RID: 13476 RVA: 0x000205AF File Offset: 0x0001E7AF
		Private Sub txtAndroidID_TextChanged(sender As Object, e As EventArgs)
			Me.AndroidIDGenerate()
		End Sub

		' Token: 0x060034A5 RID: 13477 RVA: 0x000205B9 File Offset: 0x0001E7B9
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Clipboard.SetDataObject(Me.txtAndroidID.Text)
			MessageBox.Show("Mobile ID Copied Successfully" & vbCrLf, "Customer Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x060034A6 RID: 13478 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmMobileIDDialog_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060034A7 RID: 13479 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmMobileIDDialog_KeyDown(sender As Object, e As KeyEventArgs)
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
