Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000339 RID: 825
	<DesignerGenerated()>
	Public Partial Class frmChat3
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C0FD RID: 49405 RVA: 0x000563C2 File Offset: 0x000545C2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmChat3_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmChat3_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CBC RID: 19644
		' (get) Token: 0x0600C100 RID: 49408 RVA: 0x000563F4 File Offset: 0x000545F4
		' (set) Token: 0x0600C101 RID: 49409 RVA: 0x000563FE File Offset: 0x000545FE
		Friend Overridable Property Chart2 As Chart

		' Token: 0x0600C102 RID: 49410 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmChat3_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600C103 RID: 49411 RVA: 0x00180440 File Offset: 0x0017E640
		Private Sub frmChat3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
