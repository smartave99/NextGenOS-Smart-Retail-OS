Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200033A RID: 826
	<DesignerGenerated()>
	Public Partial Class frmChat4
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C104 RID: 49412 RVA: 0x00056407 File Offset: 0x00054607
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmChat4_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmChat4_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CBD RID: 19645
		' (get) Token: 0x0600C107 RID: 49415 RVA: 0x00056439 File Offset: 0x00054639
		' (set) Token: 0x0600C108 RID: 49416 RVA: 0x00056443 File Offset: 0x00054643
		Friend Overridable Property Chart2 As Chart

		' Token: 0x0600C109 RID: 49417 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChat4_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C10A RID: 49418 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmChat4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
