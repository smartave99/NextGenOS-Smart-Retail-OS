Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000591 RID: 1425
	<DesignerGenerated()>
	Public Partial Class frmCustomDialog1
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060116BF RID: 71359 RVA: 0x00077E89 File Offset: 0x00076089
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006C0C RID: 27660
		' (get) Token: 0x060116C2 RID: 71362 RVA: 0x00077E97 File Offset: 0x00076097
		' (set) Token: 0x060116C3 RID: 71363 RVA: 0x00077EA1 File Offset: 0x000760A1
		Friend Overridable Property Label2 As Label

		' Token: 0x17006C0D RID: 27661
		' (get) Token: 0x060116C4 RID: 71364 RVA: 0x00077EAA File Offset: 0x000760AA
		' (set) Token: 0x060116C5 RID: 71365 RVA: 0x00A1AF64 File Offset: 0x00A19164
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

		' Token: 0x17006C0E RID: 27662
		' (get) Token: 0x060116C6 RID: 71366 RVA: 0x00077EB4 File Offset: 0x000760B4
		' (set) Token: 0x060116C7 RID: 71367 RVA: 0x00077EBE File Offset: 0x000760BE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x060116C8 RID: 71368 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub
	End Class
End Namespace
