Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004B6 RID: 1206
	<DesignerGenerated()>
	Public Partial Class frmContactPhoto
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F1CA RID: 61898 RVA: 0x00069D05 File Offset: 0x00067F05
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmContactPhoto_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmContactPhoto_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005CA4 RID: 23716
		' (get) Token: 0x0600F1CD RID: 61901 RVA: 0x00069D37 File Offset: 0x00067F37
		' (set) Token: 0x0600F1CE RID: 61902 RVA: 0x00069D41 File Offset: 0x00067F41
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x0600F1CF RID: 61903 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmContactPhoto_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600F1D0 RID: 61904 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmContactPhoto_KeyDown(sender As Object, e As KeyEventArgs)
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
