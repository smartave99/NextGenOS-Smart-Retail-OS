Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000371 RID: 881
	<DesignerGenerated()>
	Public Partial Class frmTempleteEdit
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600D022 RID: 53282 RVA: 0x0005C85D File Offset: 0x0005AA5D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTempleteEdit_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTempleteEdit_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700519C RID: 20892
		' (get) Token: 0x0600D025 RID: 53285 RVA: 0x0005C88F File Offset: 0x0005AA8F
		' (set) Token: 0x0600D026 RID: 53286 RVA: 0x0081C788 File Offset: 0x0081A988
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700519D RID: 20893
		' (get) Token: 0x0600D027 RID: 53287 RVA: 0x0005C899 File Offset: 0x0005AA99
		' (set) Token: 0x0600D028 RID: 53288 RVA: 0x0081C7CC File Offset: 0x0081A9CC
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700519E RID: 20894
		' (get) Token: 0x0600D029 RID: 53289 RVA: 0x0005C8A3 File Offset: 0x0005AAA3
		' (set) Token: 0x0600D02A RID: 53290 RVA: 0x0081C810 File Offset: 0x0081AA10
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700519F RID: 20895
		' (get) Token: 0x0600D02B RID: 53291 RVA: 0x0005C8AD File Offset: 0x0005AAAD
		' (set) Token: 0x0600D02C RID: 53292 RVA: 0x0081C854 File Offset: 0x0081AA54
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051A0 RID: 20896
		' (get) Token: 0x0600D02D RID: 53293 RVA: 0x0005C8B7 File Offset: 0x0005AAB7
		' (set) Token: 0x0600D02E RID: 53294 RVA: 0x0005C8C1 File Offset: 0x0005AAC1
		Friend Overridable Property Label1 As Label

		' Token: 0x0600D02F RID: 53295 RVA: 0x0005C8CA File Offset: 0x0005AACA
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\A4POS.rpt")
			MyBase.Close()
		End Sub

		' Token: 0x0600D030 RID: 53296 RVA: 0x0005C8F3 File Offset: 0x0005AAF3
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\A5POS.rpt")
			MyBase.Close()
		End Sub

		' Token: 0x0600D031 RID: 53297 RVA: 0x0005C91C File Offset: 0x0005AB1C
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\T3InchPOS.rpt")
			MyBase.Close()
		End Sub

		' Token: 0x0600D032 RID: 53298 RVA: 0x0005C945 File Offset: 0x0005AB45
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\T4InchPOS.rpt")
			MyBase.Close()
		End Sub

		' Token: 0x0600D033 RID: 53299 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmTempleteEdit_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600D034 RID: 53300 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTempleteEdit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
