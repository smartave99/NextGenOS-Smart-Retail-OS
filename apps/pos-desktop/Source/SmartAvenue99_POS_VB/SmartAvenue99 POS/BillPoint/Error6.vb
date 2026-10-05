Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A5 RID: 1189
	<DesignerGenerated()>
	Public Partial Class Error6
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EC46 RID: 60486 RVA: 0x000677C8 File Offset: 0x000659C8
		Public Sub New()
			AddHandler MyBase.KeyDown, AddressOf Me.Error6_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AA8 RID: 23208
		' (get) Token: 0x0600EC49 RID: 60489 RVA: 0x000677E8 File Offset: 0x000659E8
		' (set) Token: 0x0600EC4A RID: 60490 RVA: 0x000677F2 File Offset: 0x000659F2
		Friend Overridable Property Label1 As Label

		' Token: 0x17005AA9 RID: 23209
		' (get) Token: 0x0600EC4B RID: 60491 RVA: 0x000677FB File Offset: 0x000659FB
		' (set) Token: 0x0600EC4C RID: 60492 RVA: 0x00067805 File Offset: 0x00065A05
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x0600EC4D RID: 60493 RVA: 0x008E447C File Offset: 0x008E267C
		Private Sub Error6_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
