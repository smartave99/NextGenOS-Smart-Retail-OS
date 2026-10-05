Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports TouchlessLib

Namespace BillPoint
	' Token: 0x020000C0 RID: 192
	<DesignerGenerated()>
	Public Partial Class frmCamera
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001B40 RID: 6976 RVA: 0x0012AF88 File Offset: 0x00129188
		Public Sub New()
			AddHandler MyBase.FormClosing, AddressOf Me.WebcamImage_FormClosing
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCamera_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmCamera_Closed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000A90 RID: 2704
		' (get) Token: 0x06001B43 RID: 6979 RVA: 0x000141D2 File Offset: 0x000123D2
		' (set) Token: 0x06001B44 RID: 6980 RVA: 0x0012B760 File Offset: 0x00129960
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

		' Token: 0x17000A91 RID: 2705
		' (get) Token: 0x06001B45 RID: 6981 RVA: 0x000141DC File Offset: 0x000123DC
		' (set) Token: 0x06001B46 RID: 6982 RVA: 0x000141E6 File Offset: 0x000123E6
		Friend Overridable Property picPreview As PictureBox

		' Token: 0x17000A92 RID: 2706
		' (get) Token: 0x06001B47 RID: 6983 RVA: 0x000141EF File Offset: 0x000123EF
		' (set) Token: 0x06001B48 RID: 6984 RVA: 0x000141F9 File Offset: 0x000123F9
		Friend Overridable Property saveFileDialog1 As SaveFileDialog

		' Token: 0x17000A93 RID: 2707
		' (get) Token: 0x06001B49 RID: 6985 RVA: 0x00014202 File Offset: 0x00012402
		' (set) Token: 0x06001B4A RID: 6986 RVA: 0x0012B7A4 File Offset: 0x001299A4
		Private _btnCapture As Button
		Friend Overridable Property btnCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCapture_Click
				Dim button As Button = Me._btnCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCapture = value
				button = Me._btnCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A94 RID: 2708
		' (get) Token: 0x06001B4B RID: 6987 RVA: 0x0001420C File Offset: 0x0001240C
		' (set) Token: 0x06001B4C RID: 6988 RVA: 0x0012B7E8 File Offset: 0x001299E8
		Private _cmbCamera As ComboBox
		Friend Overridable Property cmbCamera As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCamera
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCamera_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbCamera
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbCamera = value
				comboBox = Me._cmbCamera
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000A95 RID: 2709
		' (get) Token: 0x06001B4D RID: 6989 RVA: 0x00014216 File Offset: 0x00012416
		' (set) Token: 0x06001B4E RID: 6990 RVA: 0x00014220 File Offset: 0x00012420
		Friend Overridable Property lblCamera As Label

		' Token: 0x17000A96 RID: 2710
		' (get) Token: 0x06001B4F RID: 6991 RVA: 0x00014229 File Offset: 0x00012429
		' (set) Token: 0x06001B50 RID: 6992 RVA: 0x00014233 File Offset: 0x00012433
		Friend Overridable Property picFeed As PictureBox

		' Token: 0x17000A97 RID: 2711
		' (get) Token: 0x06001B51 RID: 6993 RVA: 0x0001423C File Offset: 0x0001243C
		' (set) Token: 0x06001B52 RID: 6994 RVA: 0x0012B82C File Offset: 0x00129A2C
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

		' Token: 0x17000A98 RID: 2712
		' (get) Token: 0x06001B53 RID: 6995 RVA: 0x00014246 File Offset: 0x00012446
		' (set) Token: 0x06001B54 RID: 6996 RVA: 0x00014250 File Offset: 0x00012450
		Friend Overridable Property Label1 As Label

		' Token: 0x17000A99 RID: 2713
		' (get) Token: 0x06001B55 RID: 6997 RVA: 0x00014259 File Offset: 0x00012459
		' (set) Token: 0x06001B56 RID: 6998 RVA: 0x00014263 File Offset: 0x00012463
		Friend Overridable Property SaveFileDialog2 As SaveFileDialog

		' Token: 0x17000A9A RID: 2714
		' (get) Token: 0x06001B57 RID: 6999 RVA: 0x0001426C File Offset: 0x0001246C
		' (set) Token: 0x06001B58 RID: 7000 RVA: 0x00014276 File Offset: 0x00012476
		Friend Overridable Property Label2 As Label

		' Token: 0x06001B59 RID: 7001 RVA: 0x0012B870 File Offset: 0x00129A70
		Private Sub WebcamImage_FormClosing(sender As Object, e As FormClosingEventArgs)
			Try
				Me.Timer1.Enabled = False
				Me.CamMgr.CurrentCamera.Dispose()
				Me.CamMgr.Cameras(Me.cmbCamera.SelectedIndex).Dispose()
				Me.CamMgr.Dispose()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001B5A RID: 7002 RVA: 0x0012B8EC File Offset: 0x00129AEC
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.CamMgr = New TouchlessMgr()
			ModCommonClasses.TempFileNames2 = ""
			Dim num As Integer = Me.CamMgr.Cameras.Count - 1
			For i As Integer = 0 To num
				Me.cmbCamera.Items.Add(Me.CamMgr.Cameras(i).ToString())
			Next
			Dim flag As Boolean = Me.cmbCamera.Items.Count > 0
			If flag Then
				Me.cmbCamera.SelectedIndex = 0
				Me.Timer1.Enabled = True
			Else
				Interaction.MsgBox("There are no Camera ...", MsgBoxStyle.OkOnly, Nothing)
				MyBase.Close()
			End If
			Me.btnCapture.[Select]()
		End Sub

		' Token: 0x06001B5B RID: 7003 RVA: 0x0001427F File Offset: 0x0001247F
		Private Sub cmbCamera_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.CamMgr.CurrentCamera = Me.CamMgr.Cameras.ElementAt(Me.cmbCamera.SelectedIndex)
		End Sub

		' Token: 0x06001B5C RID: 7004 RVA: 0x000142A9 File Offset: 0x000124A9
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.picFeed.Image = Me.CamMgr.CurrentCamera.GetCurrentImage()
		End Sub

		' Token: 0x06001B5D RID: 7005 RVA: 0x0012B9AC File Offset: 0x00129BAC
		Private Sub btnCapture_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.Label2.Text, "........", False) = 0
				If flag2 Then
					Me.picPreview.Image = Me.CamMgr.CurrentCamera.GetCurrentImage()
					Dim tempFileName As String = Path.GetTempFileName()
					ModCommonClasses.TempFileNames2 = tempFileName
					Dim bitmap As Bitmap = CType(Me.picPreview.Image, Bitmap)
					bitmap.Save(tempFileName, ImageFormat.Jpeg)
					Me.Timer1.Enabled = False
					Me.CamMgr.CurrentCamera.Dispose()
					Me.CamMgr.Cameras(Me.cmbCamera.SelectedIndex).Dispose()
					Me.CamMgr.Dispose()
					MyProject.Forms.frmPOSNewTuch.lblWebcampstatus.Text = "active"
					MyBase.Close()
				Else
					Me.picPreview.Image = Me.CamMgr.CurrentCamera.GetCurrentImage()
					Me.btnSave.Enabled = True
				End If
			Else
				MessageBox.Show("Internet connection not found", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06001B5E RID: 7006 RVA: 0x0012BAE0 File Offset: 0x00129CE0
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Label2.Text, "PurchaseEntry", False) = 0
			If flag Then
				MyProject.Forms.frmPurchaseEntry.PictureBox1.Image = Me.picPreview.Image
				Me.Timer1.Enabled = False
				Me.CamMgr.CurrentCamera.Dispose()
				Me.CamMgr.Cameras(Me.cmbCamera.SelectedIndex).Dispose()
				Me.CamMgr.Dispose()
				MyBase.Close()
			Else
				Dim tempFileName As String = Path.GetTempFileName()
				ModCommonClasses.TempFileNames2 = tempFileName
				Dim bitmap As Bitmap = CType(Me.picPreview.Image, Bitmap)
				bitmap.Save(tempFileName, ImageFormat.Jpeg)
				Me.Timer1.Enabled = False
				Me.CamMgr.CurrentCamera.Dispose()
				Me.CamMgr.Cameras(Me.cmbCamera.SelectedIndex).Dispose()
				Me.CamMgr.Dispose()
				MyBase.Close()
			End If
		End Sub

		' Token: 0x06001B5F RID: 7007 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCamera_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06001B60 RID: 7008 RVA: 0x000142C8 File Offset: 0x000124C8
		Private Sub frmCamera_Closed(sender As Object, e As EventArgs)
			Me.Label2.Text = ""
		End Sub

		' Token: 0x04000AC9 RID: 2761
		Public CamMgr As TouchlessMgr
	End Class
End Namespace
