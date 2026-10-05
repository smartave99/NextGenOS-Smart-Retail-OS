Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200033C RID: 828
	<DesignerGenerated()>
	Public Partial Class frmCustomDialog3
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C131 RID: 49457 RVA: 0x00056559 File Offset: 0x00054759
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CCC RID: 19660
		' (get) Token: 0x0600C134 RID: 49460 RVA: 0x00056567 File Offset: 0x00054767
		' (set) Token: 0x0600C135 RID: 49461 RVA: 0x00056571 File Offset: 0x00054771
		Friend Overridable Property Label2 As Label

		' Token: 0x17004CCD RID: 19661
		' (get) Token: 0x0600C136 RID: 49462 RVA: 0x0005657A File Offset: 0x0005477A
		' (set) Token: 0x0600C137 RID: 49463 RVA: 0x007ADFF8 File Offset: 0x007AC1F8
		Private _btnOK As Button
		Friend Overridable Property btnOK As Button
			<CompilerGenerated()>
			Get
				Return Me._btnOK
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnOK_Click
				Dim button As Button = Me._btnOK
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnOK = value
				button = Me._btnOK
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600C138 RID: 49464 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub
	End Class
End Namespace
