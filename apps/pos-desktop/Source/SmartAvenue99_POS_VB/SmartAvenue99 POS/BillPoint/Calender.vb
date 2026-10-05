Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000315 RID: 789
	<DesignerGenerated()>
	Public Partial Class Calender
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BC8A RID: 48266 RVA: 0x0005476B File Offset: 0x0005296B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Calender_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004B18 RID: 19224
		' (get) Token: 0x0600BC8D RID: 48269 RVA: 0x0005478B File Offset: 0x0005298B
		' (set) Token: 0x0600BC8E RID: 48270 RVA: 0x00054795 File Offset: 0x00052995
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004B19 RID: 19225
		' (get) Token: 0x0600BC8F RID: 48271 RVA: 0x0005479E File Offset: 0x0005299E
		' (set) Token: 0x0600BC90 RID: 48272 RVA: 0x000547A8 File Offset: 0x000529A8
		Friend Overridable Property Label39 As Label

		' Token: 0x17004B1A RID: 19226
		' (get) Token: 0x0600BC91 RID: 48273 RVA: 0x000547B1 File Offset: 0x000529B1
		' (set) Token: 0x0600BC92 RID: 48274 RVA: 0x000547BB File Offset: 0x000529BB
		Friend Overridable Property Label40 As Label

		' Token: 0x17004B1B RID: 19227
		' (get) Token: 0x0600BC93 RID: 48275 RVA: 0x000547C4 File Offset: 0x000529C4
		' (set) Token: 0x0600BC94 RID: 48276 RVA: 0x000547CE File Offset: 0x000529CE
		Friend Overridable Property MonthCalendar1 As MonthCalendar

		' Token: 0x17004B1C RID: 19228
		' (get) Token: 0x0600BC95 RID: 48277 RVA: 0x000547D7 File Offset: 0x000529D7
		' (set) Token: 0x0600BC96 RID: 48278 RVA: 0x0078F250 File Offset: 0x0078D450
		Private _MaskedTextBox1 As MaskedTextBox
		Friend Overridable Property MaskedTextBox1 As MaskedTextBox
			<CompilerGenerated()>
			Get
				Return Me._MaskedTextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As MaskedTextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.MaskedTextBox1_KeyUp
				Dim maskedTextBox As MaskedTextBox = Me._MaskedTextBox1
				If maskedTextBox IsNot Nothing Then
					RemoveHandler maskedTextBox.KeyUp, keyEventHandler
				End If
				Me._MaskedTextBox1 = value
				maskedTextBox = Me._MaskedTextBox1
				If maskedTextBox IsNot Nothing Then
					AddHandler maskedTextBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B1D RID: 19229
		' (get) Token: 0x0600BC97 RID: 48279 RVA: 0x000547E1 File Offset: 0x000529E1
		' (set) Token: 0x0600BC98 RID: 48280 RVA: 0x0078F294 File Offset: 0x0078D494
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

		' Token: 0x17004B1E RID: 19230
		' (get) Token: 0x0600BC99 RID: 48281 RVA: 0x000547EB File Offset: 0x000529EB
		' (set) Token: 0x0600BC9A RID: 48282 RVA: 0x0078F2D8 File Offset: 0x0078D4D8
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600BC9B RID: 48283
		Private Declare Function SetWindowTheme Lib "uxtheme.dll" (hwnd As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> pszSubAppName As String, <MarshalAs(UnmanagedType.LPWStr)> pszSubIdList As String) As Integer

		' Token: 0x0600BC9C RID: 48284 RVA: 0x0078F31C File Offset: 0x0078D51C
		Private Sub MaskedTextBox1_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				SendKeys.Send("{ENTER}")
			End If
		End Sub

		' Token: 0x0600BC9D RID: 48285 RVA: 0x0078F350 File Offset: 0x0078D550
		Private Sub Calender_Load(sender As Object, e As EventArgs)
			Calender.SetWindowTheme(Me.MonthCalendar1.Handle, "", "")
			Me.MonthCalendar1.BackColor = Color.Indigo
			Me.MonthCalendar1.ForeColor = Color.White
			Me.MonthCalendar1.TitleBackColor = Color.WhiteSmoke
			Me.MonthCalendar1.TitleForeColor = Color.Black
			Me.MonthCalendar1.TrailingForeColor = Color.Red
			Me.MonthCalendar1.Font = New Font(Me.MonthCalendar1.Font.FontFamily, 24F, FontStyle.Bold)
		End Sub

		' Token: 0x0600BC9E RID: 48286 RVA: 0x0078F3F8 File Offset: 0x0078D5F8
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Me.MonthCalendar1.SetDate(Conversions.ToDate(Me.MaskedTextBox1.Text))
			Catch ex As Exception
				Me.MaskedTextBox1.Text = ""
				MessageBox.Show("Please fillup the searchable date in appropriate box as above mentioned format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub

		' Token: 0x0600BC9F RID: 48287 RVA: 0x000547F5 File Offset: 0x000529F5
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.MaskedTextBox1.Text = ""
			Me.MonthCalendar1.SetDate(DateTime.Now)
			Me.MonthCalendar1.Refresh()
		End Sub
	End Class
End Namespace
