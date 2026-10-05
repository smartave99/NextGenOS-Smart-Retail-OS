Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000316 RID: 790
	<DesignerGenerated()>
	Public Partial Class Cashrefund
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BCA0 RID: 48288 RVA: 0x00054826 File Offset: 0x00052A26
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Cashrefund_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004B1F RID: 19231
		' (get) Token: 0x0600BCA3 RID: 48291 RVA: 0x00054846 File Offset: 0x00052A46
		' (set) Token: 0x0600BCA4 RID: 48292 RVA: 0x00054850 File Offset: 0x00052A50
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004B20 RID: 19232
		' (get) Token: 0x0600BCA5 RID: 48293 RVA: 0x00054859 File Offset: 0x00052A59
		' (set) Token: 0x0600BCA6 RID: 48294 RVA: 0x0078FD68 File Offset: 0x0078DF68
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B21 RID: 19233
		' (get) Token: 0x0600BCA7 RID: 48295 RVA: 0x00054863 File Offset: 0x00052A63
		' (set) Token: 0x0600BCA8 RID: 48296 RVA: 0x0078FDAC File Offset: 0x0078DFAC
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox2_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox2_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B22 RID: 19234
		' (get) Token: 0x0600BCA9 RID: 48297 RVA: 0x0005486D File Offset: 0x00052A6D
		' (set) Token: 0x0600BCAA RID: 48298 RVA: 0x0078FE28 File Offset: 0x0078E028
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B23 RID: 19235
		' (get) Token: 0x0600BCAB RID: 48299 RVA: 0x00054877 File Offset: 0x00052A77
		' (set) Token: 0x0600BCAC RID: 48300 RVA: 0x00054881 File Offset: 0x00052A81
		Friend Overridable Property Label3 As Label

		' Token: 0x17004B24 RID: 19236
		' (get) Token: 0x0600BCAD RID: 48301 RVA: 0x0005488A File Offset: 0x00052A8A
		' (set) Token: 0x0600BCAE RID: 48302 RVA: 0x00054894 File Offset: 0x00052A94
		Friend Overridable Property Label2 As Label

		' Token: 0x17004B25 RID: 19237
		' (get) Token: 0x0600BCAF RID: 48303 RVA: 0x0005489D File Offset: 0x00052A9D
		' (set) Token: 0x0600BCB0 RID: 48304 RVA: 0x000548A7 File Offset: 0x00052AA7
		Friend Overridable Property Label1 As Label

		' Token: 0x17004B26 RID: 19238
		' (get) Token: 0x0600BCB1 RID: 48305 RVA: 0x000548B0 File Offset: 0x00052AB0
		' (set) Token: 0x0600BCB2 RID: 48306 RVA: 0x0078FEA4 File Offset: 0x0078E0A4
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
				Dim eventHandler2 As EventHandler = AddressOf Me.Button1_MouseHover
				Dim eventHandler3 As EventHandler = AddressOf Me.Button1_MouseLeave
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
					RemoveHandler button.MouseLeave, eventHandler3
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
					AddHandler button.MouseLeave, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x17004B27 RID: 19239
		' (get) Token: 0x0600BCB3 RID: 48307 RVA: 0x000548BA File Offset: 0x00052ABA
		' (set) Token: 0x0600BCB4 RID: 48308 RVA: 0x000548C4 File Offset: 0x00052AC4
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004B28 RID: 19240
		' (get) Token: 0x0600BCB5 RID: 48309 RVA: 0x000548CD File Offset: 0x00052ACD
		' (set) Token: 0x0600BCB6 RID: 48310 RVA: 0x000548D7 File Offset: 0x00052AD7
		Friend Overridable Property Label39 As Label

		' Token: 0x0600BCB7 RID: 48311 RVA: 0x000548E0 File Offset: 0x00052AE0
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) - Conversion.Val(Me.TextBox2.Text))
		End Sub

		' Token: 0x0600BCB8 RID: 48312 RVA: 0x000548E0 File Offset: 0x00052AE0
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) - Conversion.Val(Me.TextBox2.Text))
		End Sub

		' Token: 0x0600BCB9 RID: 48313 RVA: 0x000548E0 File Offset: 0x00052AE0
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) - Conversion.Val(Me.TextBox2.Text))
		End Sub

		' Token: 0x0600BCBA RID: 48314 RVA: 0x0078FF20 File Offset: 0x0078E120
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Versioned.IsNumeric(e.KeyChar) Or (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0)
			If flag Then
				Dim flag2 As Boolean = Strings.InStr(Me.TextBox1.Text, ".", CompareMethod.Binary) > 0
				If flag2 Then
					' The following expression was wrapped in a checked-expression
					Dim text As String = Strings.Right(Me.TextBox1.Text, Strings.Len(Me.TextBox1.Text) - Strings.InStr(Me.TextBox1.Text, ".", CompareMethod.Binary))
					Dim flag3 As Boolean = Strings.Len(text) = 2
					If flag3 Then
						e.Handled = True
					End If
				End If
			Else
				Dim flag4 As Boolean = (e.KeyChar <> vbBack) And (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0)
				If flag4 Then
					e.Handled = True
				End If
			End If
			Dim flag5 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag5 Then
				Dim flag6 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag6 Then
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600BCBB RID: 48315 RVA: 0x0079006C File Offset: 0x0078E26C
		Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Versioned.IsNumeric(e.KeyChar) Or (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0)
			If flag Then
				Dim flag2 As Boolean = Strings.InStr(Me.TextBox2.Text, ".", CompareMethod.Binary) > 0
				If flag2 Then
					' The following expression was wrapped in a checked-expression
					Dim text As String = Strings.Right(Me.TextBox2.Text, Strings.Len(Me.TextBox2.Text) - Strings.InStr(Me.TextBox2.Text, ".", CompareMethod.Binary))
					Dim flag3 As Boolean = Strings.Len(text) = 2
					If flag3 Then
						e.Handled = True
					End If
				End If
			Else
				Dim flag4 As Boolean = (e.KeyChar <> vbBack) And (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0)
				If flag4 Then
					e.Handled = True
				End If
			End If
			Dim flag5 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag5 Then
				Dim flag6 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag6 Then
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600BCBC RID: 48316 RVA: 0x00054915 File Offset: 0x00052B15
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600BCBD RID: 48317 RVA: 0x00054946 File Offset: 0x00052B46
		Private Sub Button1_MouseHover(sender As Object, e As EventArgs)
			Me.Button1.BackColor = Color.Red
			Me.Button1.ForeColor = Color.White
		End Sub

		' Token: 0x0600BCBE RID: 48318 RVA: 0x0005496B File Offset: 0x00052B6B
		Private Sub Button1_MouseLeave(sender As Object, e As EventArgs)
			Me.Button1.BackColor = Color.White
			Me.Button1.ForeColor = Color.Blue
		End Sub

		' Token: 0x0600BCBF RID: 48319 RVA: 0x00054990 File Offset: 0x00052B90
		Private Sub Cashrefund_Load(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600BCC0 RID: 48320 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600BCC1 RID: 48321 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub
	End Class
End Namespace
