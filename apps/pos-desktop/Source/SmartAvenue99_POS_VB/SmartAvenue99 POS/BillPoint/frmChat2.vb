Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000338 RID: 824
	<DesignerGenerated()>
	Public Partial Class frmChat2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C0F6 RID: 49398 RVA: 0x0005637D File Offset: 0x0005457D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmChat2_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmChat2_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CBB RID: 19643
		' (get) Token: 0x0600C0F9 RID: 49401 RVA: 0x000563AF File Offset: 0x000545AF
		' (set) Token: 0x0600C0FA RID: 49402 RVA: 0x000563B9 File Offset: 0x000545B9
		Friend Overridable Property Chart3 As Chart

		' Token: 0x0600C0FB RID: 49403 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChat2_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C0FC RID: 49404 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmChat2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
