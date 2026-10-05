Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000592 RID: 1426
	<DesignerGenerated()>
	Public Partial Class frmCustomDialog2
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060116C9 RID: 71369 RVA: 0x00077EC7 File Offset: 0x000760C7
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006C0F RID: 27663
		' (get) Token: 0x060116CC RID: 71372 RVA: 0x00077ED5 File Offset: 0x000760D5
		' (set) Token: 0x060116CD RID: 71373 RVA: 0x00077EDF File Offset: 0x000760DF
		Friend Overridable Property Label2 As Label

		' Token: 0x17006C10 RID: 27664
		' (get) Token: 0x060116CE RID: 71374 RVA: 0x00077EE8 File Offset: 0x000760E8
		' (set) Token: 0x060116CF RID: 71375 RVA: 0x00A1B2A0 File Offset: 0x00A194A0
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

		' Token: 0x17006C11 RID: 27665
		' (get) Token: 0x060116D0 RID: 71376 RVA: 0x00077EF2 File Offset: 0x000760F2
		' (set) Token: 0x060116D1 RID: 71377 RVA: 0x00077EFC File Offset: 0x000760FC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x060116D2 RID: 71378 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub
	End Class
End Namespace
