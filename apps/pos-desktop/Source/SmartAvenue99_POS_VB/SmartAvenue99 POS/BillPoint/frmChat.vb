Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000336 RID: 822
	<DesignerGenerated()>
	Public Partial Class frmChat
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C0E8 RID: 49384 RVA: 0x000562F3 File Offset: 0x000544F3
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmChat_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmChat_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CB9 RID: 19641
		' (get) Token: 0x0600C0EB RID: 49387 RVA: 0x00056325 File Offset: 0x00054525
		' (set) Token: 0x0600C0EC RID: 49388 RVA: 0x0005632F File Offset: 0x0005452F
		Friend Overridable Property Chart2 As Chart

		' Token: 0x0600C0ED RID: 49389 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChat_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C0EE RID: 49390 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmChat_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
