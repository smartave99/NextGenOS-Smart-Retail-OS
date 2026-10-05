Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000337 RID: 823
	<DesignerGenerated()>
	Public Partial Class frmChat1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C0EF RID: 49391 RVA: 0x00056338 File Offset: 0x00054538
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmChat1_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmChat1_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CBA RID: 19642
		' (get) Token: 0x0600C0F2 RID: 49394 RVA: 0x0005636A File Offset: 0x0005456A
		' (set) Token: 0x0600C0F3 RID: 49395 RVA: 0x00056374 File Offset: 0x00054574
		Friend Overridable Property Chart3 As Chart

		' Token: 0x0600C0F4 RID: 49396 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChat1_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C0F5 RID: 49397 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmChat1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
