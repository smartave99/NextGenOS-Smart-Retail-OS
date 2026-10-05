Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000590 RID: 1424
	<DesignerGenerated()>
	Public Partial Class frmCustomDialog
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060116B5 RID: 71349 RVA: 0x00077E4B File Offset: 0x0007604B
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006C09 RID: 27657
		' (get) Token: 0x060116B8 RID: 71352 RVA: 0x00077E59 File Offset: 0x00076059
		' (set) Token: 0x060116B9 RID: 71353 RVA: 0x00077E63 File Offset: 0x00076063
		Friend Overridable Property Label2 As Label

		' Token: 0x17006C0A RID: 27658
		' (get) Token: 0x060116BA RID: 71354 RVA: 0x00077E6C File Offset: 0x0007606C
		' (set) Token: 0x060116BB RID: 71355 RVA: 0x00A1AC28 File Offset: 0x00A18E28
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

		' Token: 0x17006C0B RID: 27659
		' (get) Token: 0x060116BC RID: 71356 RVA: 0x00077E76 File Offset: 0x00076076
		' (set) Token: 0x060116BD RID: 71357 RVA: 0x00077E80 File Offset: 0x00076080
		Friend Overridable Property Panel1 As Panel

		' Token: 0x060116BE RID: 71358 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub
	End Class
End Namespace
