Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000329 RID: 809
	<DesignerGenerated()>
	Public Partial Class Form2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BDDE RID: 48606 RVA: 0x00054D47 File Offset: 0x00052F47
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form2_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004BA2 RID: 19362
		' (get) Token: 0x0600BDE1 RID: 48609 RVA: 0x00054D67 File Offset: 0x00052F67
		' (set) Token: 0x0600BDE2 RID: 48610 RVA: 0x00054D71 File Offset: 0x00052F71
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17004BA3 RID: 19363
		' (get) Token: 0x0600BDE3 RID: 48611 RVA: 0x00054D7A File Offset: 0x00052F7A
		' (set) Token: 0x0600BDE4 RID: 48612 RVA: 0x00054D84 File Offset: 0x00052F84
		Friend Overridable Property Panel1 As Panel

		' Token: 0x0600BDE5 RID: 48613 RVA: 0x00792D84 File Offset: 0x00790F84
		Private Sub Form2_Load(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Me.Panel1.Location = New Point(CInt(Math.Round(CDbl(MyBase.ClientSize.Width) / 2.0 - CDbl(Me.Panel1.Size.Width) / 2.0)), CInt(Math.Round(CDbl(MyBase.ClientSize.Height) / 2.0 - CDbl(Me.Panel1.Size.Height) / 2.0)))
			Me.Panel1.Anchor = AnchorStyles.None
		End Sub
	End Class
End Namespace
