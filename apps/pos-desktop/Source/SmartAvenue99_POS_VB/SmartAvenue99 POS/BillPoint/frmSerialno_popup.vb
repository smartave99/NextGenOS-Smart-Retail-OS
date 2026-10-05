Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020001FF RID: 511
	<DesignerGenerated()>
	Public Partial Class frmSerialno_popup
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009359 RID: 37721 RVA: 0x0004822E File Offset: 0x0004642E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSerialno_popup_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170036AB RID: 13995
		' (get) Token: 0x0600935C RID: 37724 RVA: 0x0004824E File Offset: 0x0004644E
		' (set) Token: 0x0600935D RID: 37725 RVA: 0x00048258 File Offset: 0x00046458
		Friend Overridable Property txtSerialno As TextBox

		' Token: 0x170036AC RID: 13996
		' (get) Token: 0x0600935E RID: 37726 RVA: 0x00048261 File Offset: 0x00046461
		' (set) Token: 0x0600935F RID: 37727 RVA: 0x006AA298 File Offset: 0x006A8498
		Private _btnUpdate As Button
		Friend Overridable Property btnUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim button As Button = Me._btnUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate = value
				button = Me._btnUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170036AD RID: 13997
		' (get) Token: 0x06009360 RID: 37728 RVA: 0x0004826B File Offset: 0x0004646B
		' (set) Token: 0x06009361 RID: 37729 RVA: 0x00048275 File Offset: 0x00046475
		Friend Overridable Property txtSerialno2 As TextBox

		' Token: 0x170036AE RID: 13998
		' (get) Token: 0x06009362 RID: 37730 RVA: 0x0004827E File Offset: 0x0004647E
		' (set) Token: 0x06009363 RID: 37731 RVA: 0x00048288 File Offset: 0x00046488
		Friend Overridable Property Label1 As Label

		' Token: 0x170036AF RID: 13999
		' (get) Token: 0x06009364 RID: 37732 RVA: 0x00048291 File Offset: 0x00046491
		' (set) Token: 0x06009365 RID: 37733 RVA: 0x0004829B File Offset: 0x0004649B
		Friend Overridable Property Label2 As Label

		' Token: 0x06009366 RID: 37734 RVA: 0x006AA2DC File Offset: 0x006A84DC
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSerialno.Text)
			If flag Then
				MessageBox.Show("Please enter a serial number before closing.")
			Else
				frmProductRec_serial.strSerialno = Me.txtSerialno.Text
				frmProductRec_serial.strSerialno2 = Me.txtSerialno2.Text
				MyBase.Close()
			End If
		End Sub

		' Token: 0x06009367 RID: 37735 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmSerialno_popup_Load(sender As Object, e As EventArgs)
		End Sub
	End Class
End Namespace
