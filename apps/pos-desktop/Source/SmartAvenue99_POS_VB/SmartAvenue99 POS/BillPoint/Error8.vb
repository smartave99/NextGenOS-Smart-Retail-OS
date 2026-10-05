Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A6 RID: 1190
	<DesignerGenerated()>
	Public Partial Class Error8
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EC4E RID: 60494 RVA: 0x0006780E File Offset: 0x00065A0E
		Public Sub New()
			AddHandler MyBase.KeyDown, AddressOf Me.Error8_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AAA RID: 23210
		' (get) Token: 0x0600EC51 RID: 60497 RVA: 0x0006782E File Offset: 0x00065A2E
		' (set) Token: 0x0600EC52 RID: 60498 RVA: 0x00067838 File Offset: 0x00065A38
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17005AAB RID: 23211
		' (get) Token: 0x0600EC53 RID: 60499 RVA: 0x00067841 File Offset: 0x00065A41
		' (set) Token: 0x0600EC54 RID: 60500 RVA: 0x0006784B File Offset: 0x00065A4B
		Friend Overridable Property Label1 As Label

		' Token: 0x0600EC55 RID: 60501 RVA: 0x008E447C File Offset: 0x008E267C
		Private Sub Error8_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
