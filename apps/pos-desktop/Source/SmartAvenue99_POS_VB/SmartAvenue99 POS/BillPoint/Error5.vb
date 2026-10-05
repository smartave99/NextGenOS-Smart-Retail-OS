Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A4 RID: 1188
	<DesignerGenerated()>
	Public Partial Class Error5
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EC3E RID: 60478 RVA: 0x00067782 File Offset: 0x00065982
		Public Sub New()
			AddHandler MyBase.KeyDown, AddressOf Me.Error5_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AA6 RID: 23206
		' (get) Token: 0x0600EC41 RID: 60481 RVA: 0x000677A2 File Offset: 0x000659A2
		' (set) Token: 0x0600EC42 RID: 60482 RVA: 0x000677AC File Offset: 0x000659AC
		Friend Overridable Property Label1 As Label

		' Token: 0x17005AA7 RID: 23207
		' (get) Token: 0x0600EC43 RID: 60483 RVA: 0x000677B5 File Offset: 0x000659B5
		' (set) Token: 0x0600EC44 RID: 60484 RVA: 0x000677BF File Offset: 0x000659BF
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x0600EC45 RID: 60485 RVA: 0x008E447C File Offset: 0x008E267C
		Private Sub Error5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
