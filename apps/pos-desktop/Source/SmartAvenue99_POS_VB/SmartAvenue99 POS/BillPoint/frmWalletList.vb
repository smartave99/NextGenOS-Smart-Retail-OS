Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports BillPoint.My
Imports MessagingToolkit.QRCode.Codec
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000215 RID: 533
	<DesignerGenerated()>
	Public Partial Class frmWalletList
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060099CD RID: 39373 RVA: 0x0004B1F1 File Offset: 0x000493F1
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTables_Load
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003922 RID: 14626
		' (get) Token: 0x060099D0 RID: 39376 RVA: 0x0004B21F File Offset: 0x0004941F
		' (set) Token: 0x060099D1 RID: 39377 RVA: 0x0004B229 File Offset: 0x00049429
		Friend Overridable Property lblSet As Label

		' Token: 0x17003923 RID: 14627
		' (get) Token: 0x060099D2 RID: 39378 RVA: 0x0004B232 File Offset: 0x00049432
		' (set) Token: 0x060099D3 RID: 39379 RVA: 0x006E4980 File Offset: 0x006E2B80
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLogout_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003924 RID: 14628
		' (get) Token: 0x060099D4 RID: 39380 RVA: 0x0004B23C File Offset: 0x0004943C
		' (set) Token: 0x060099D5 RID: 39381 RVA: 0x0004B246 File Offset: 0x00049446
		Friend Overridable Property Label5 As Label

		' Token: 0x17003925 RID: 14629
		' (get) Token: 0x060099D6 RID: 39382 RVA: 0x0004B24F File Offset: 0x0004944F
		' (set) Token: 0x060099D7 RID: 39383 RVA: 0x0004B259 File Offset: 0x00049459
		Friend Overridable Property flpTables As FlowLayoutPanel

		' Token: 0x17003926 RID: 14630
		' (get) Token: 0x060099D8 RID: 39384 RVA: 0x0004B262 File Offset: 0x00049462
		' (set) Token: 0x060099D9 RID: 39385 RVA: 0x006E49C4 File Offset: 0x006E2BC4
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

		' Token: 0x17003927 RID: 14631
		' (get) Token: 0x060099DA RID: 39386 RVA: 0x0004B26C File Offset: 0x0004946C
		' (set) Token: 0x060099DB RID: 39387 RVA: 0x0004B276 File Offset: 0x00049476
		Friend Overridable Property lblControl As Label

		' Token: 0x17003928 RID: 14632
		' (get) Token: 0x060099DC RID: 39388 RVA: 0x0004B27F File Offset: 0x0004947F
		' (set) Token: 0x060099DD RID: 39389 RVA: 0x0004B289 File Offset: 0x00049489
		Friend Overridable Property PictureBox6 As PictureBox

		' Token: 0x17003929 RID: 14633
		' (get) Token: 0x060099DE RID: 39390 RVA: 0x0004B292 File Offset: 0x00049492
		' (set) Token: 0x060099DF RID: 39391 RVA: 0x0004B29C File Offset: 0x0004949C
		Friend Overridable Property lblGTotal As Label

		' Token: 0x060099E0 RID: 39392 RVA: 0x006E4A08 File Offset: 0x006E2C08
		Public Sub FillWallet()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Me.flpTables.Controls.Clear()
				Dim flag As Boolean = Operators.CompareString(Me.lblControl.Text, "frmPOSTouch", False) = 0
				If flag Then
					Dim flag2 As Boolean = MyProject.Forms.frmPOSTouch.DataGridView1.Rows.Count = 0
					If flag2 Then
						MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
				End If
				Dim flag3 As Boolean = Operators.CompareString(Me.lblControl.Text, "frmPOSNewTuch", False) = 0
				If flag3 Then
					Dim flag4 As Boolean = MyProject.Forms.frmPOSNewTuch.DataGridView1.Rows.Count = 0
					If flag4 Then
						MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Return
					End If
				End If
				Dim button As Button = New Button()
				button.Text = "Phone Pay"
				button.TextAlign = ContentAlignment.MiddleCenter
				Dim steelBlue As Color = Color.SteelBlue
				button.BackColor = steelBlue
				button.ForeColor = Color.White
				button.FlatStyle = FlatStyle.Popup
				button.Width = 180
				button.Height = 80
				button.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
				Me.UserButtons.Add(button)
				Me.flpTables.Controls.Add(button)
				AddHandler button.Click, AddressOf Me.Button2_Click
				Dim button2 As Button = New Button()
				button2.Text = "Google Pay"
				button2.TextAlign = ContentAlignment.MiddleCenter
				Dim steelBlue2 As Color = Color.SteelBlue
				button2.BackColor = steelBlue
				button2.ForeColor = Color.White
				button2.FlatStyle = FlatStyle.Popup
				button2.Width = 180
				button2.Height = 80
				button2.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
				Me.UserButtons.Add(button2)
				Me.flpTables.Controls.Add(button2)
				button2.Focus()
				button2.[Select]()
				AddHandler button2.Click, AddressOf Me.Button2_Click
				Dim button3 As Button = New Button()
				button3.Text = "Paytm"
				button3.TextAlign = ContentAlignment.MiddleCenter
				Dim steelBlue3 As Color = Color.SteelBlue
				button3.BackColor = steelBlue
				button3.ForeColor = Color.White
				button3.FlatStyle = FlatStyle.Popup
				button3.Width = 180
				button3.Height = 80
				button3.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
				Me.UserButtons.Add(button3)
				Me.flpTables.Controls.Add(button3)
				AddHandler button3.Click, AddressOf Me.Button2_Click
				Dim button4 As Button = New Button()
				button4.Text = "E-Wallet"
				button3.TextAlign = ContentAlignment.MiddleCenter
				Dim steelBlue4 As Color = Color.SteelBlue
				button4.BackColor = steelBlue
				button4.ForeColor = Color.White
				button4.FlatStyle = FlatStyle.Popup
				button4.Width = 180
				button4.Height = 80
				button4.Font = New Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0)
				Me.UserButtons.Add(button4)
				Me.flpTables.Controls.Add(button4)
				AddHandler button4.Click, AddressOf Me.Button2_Click
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060099E1 RID: 39393 RVA: 0x006E4DDC File Offset: 0x006E2FDC
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim text As String = button.Text.Trim()
				Dim flag As Boolean = Operators.CompareString(button.Text.Trim(), "Phone Pay", False) = 0
				If flag Then
					Me.lblSet.Text = Conversions.ToString(4)
				End If
				Dim flag2 As Boolean = Operators.CompareString(button.Text.Trim(), "Google Pay", False) = 0
				If flag2 Then
					Me.lblSet.Text = Conversions.ToString(5)
				End If
				Dim flag3 As Boolean = Operators.CompareString(button.Text.Trim(), "Paytm", False) = 0
				If flag3 Then
					Me.lblSet.Text = Conversions.ToString(6)
				End If
				Dim flag4 As Boolean = Operators.CompareString(button.Text.Trim(), "E-Wallet", False) = 0
				If flag4 Then
					Me.lblSet.Text = Conversions.ToString(7)
				End If
				MyBase.Hide()
				MyProject.Forms.frmBankList.lblSet.Text = Me.lblSet.Text.Trim()
				MyProject.Forms.frmBankList.lblControl.Text = Me.lblControl.Text.Trim()
				MyProject.Forms.frmBankList.ShowDialog()
				MyProject.Forms.frmBankList.BringToFront()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060099E2 RID: 39394 RVA: 0x0004B2A5 File Offset: 0x000494A5
		Private Sub frmTables_Load(sender As Object, e As EventArgs)
			Me.FillWallet()
			Me.DisplayQrCode()
		End Sub

		' Token: 0x060099E3 RID: 39395 RVA: 0x006E4F7C File Offset: 0x006E317C
		Public Sub DisplayQrCode()
			Dim text As String = ""
			Dim dataTable As DataTable = clsfun.ExecDataTable("Select UPIID,BrandName from POSPrinterSetting")
			text = If((text + "upi://pay?pa={UPIID}&pn={Brand}&am={GrandTotal}"), "")
			text = text.Replace("{UPIID}", dataTable.Rows(0)("UPIID").ToString().Trim()).Replace("{Brand}", dataTable.Rows(0)("BrandName").ToString().Trim()).Replace("{GrandTotal}", Conversions.ToString(Math.Round(Conversion.Val(Me.lblGTotal.Text), 0)))
			Dim qrcodeEncoder As QRCodeEncoder = New QRCodeEncoder()
			qrcodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.[BYTE]
			qrcodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
			Me.PictureBox6.Image = qrcodeEncoder.Encode(text, Encoding.UTF8)
		End Sub

		' Token: 0x060099E4 RID: 39396 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnLogout_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x060099E5 RID: 39397 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x04004423 RID: 17443
		Private UserButtons As List(Of Button)
	End Class
End Namespace
