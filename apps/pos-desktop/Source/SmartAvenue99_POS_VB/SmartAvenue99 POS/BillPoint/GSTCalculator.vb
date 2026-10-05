Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004EE RID: 1262
	<DesignerGenerated()>
	Public Partial Class GSTCalculator
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010346 RID: 66374 RVA: 0x00071CE9 File Offset: 0x0006FEE9
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006321 RID: 25377
		' (get) Token: 0x06010349 RID: 66377 RVA: 0x00071CF7 File Offset: 0x0006FEF7
		' (set) Token: 0x0601034A RID: 66378 RVA: 0x00071D01 File Offset: 0x0006FF01
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006322 RID: 25378
		' (get) Token: 0x0601034B RID: 66379 RVA: 0x00071D0A File Offset: 0x0006FF0A
		' (set) Token: 0x0601034C RID: 66380 RVA: 0x00071D14 File Offset: 0x0006FF14
		Friend Overridable Property Label2 As Label

		' Token: 0x17006323 RID: 25379
		' (get) Token: 0x0601034D RID: 66381 RVA: 0x00071D1D File Offset: 0x0006FF1D
		' (set) Token: 0x0601034E RID: 66382 RVA: 0x00071D27 File Offset: 0x0006FF27
		Friend Overridable Property Label85 As Label

		' Token: 0x17006324 RID: 25380
		' (get) Token: 0x0601034F RID: 66383 RVA: 0x00071D30 File Offset: 0x0006FF30
		' (set) Token: 0x06010350 RID: 66384 RVA: 0x00071D3A File Offset: 0x0006FF3A
		Friend Overridable Property Label1 As Label

		' Token: 0x17006325 RID: 25381
		' (get) Token: 0x06010351 RID: 66385 RVA: 0x00071D43 File Offset: 0x0006FF43
		' (set) Token: 0x06010352 RID: 66386 RVA: 0x009A7D88 File Offset: 0x009A5F88
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

		' Token: 0x17006326 RID: 25382
		' (get) Token: 0x06010353 RID: 66387 RVA: 0x00071D4D File Offset: 0x0006FF4D
		' (set) Token: 0x06010354 RID: 66388 RVA: 0x00071D57 File Offset: 0x0006FF57
		Friend Overridable Property Label84 As Label

		' Token: 0x17006327 RID: 25383
		' (get) Token: 0x06010355 RID: 66389 RVA: 0x00071D60 File Offset: 0x0006FF60
		' (set) Token: 0x06010356 RID: 66390 RVA: 0x00071D6A File Offset: 0x0006FF6A
		Friend Overridable Property Label12 As Label

		' Token: 0x17006328 RID: 25384
		' (get) Token: 0x06010357 RID: 66391 RVA: 0x00071D73 File Offset: 0x0006FF73
		' (set) Token: 0x06010358 RID: 66392 RVA: 0x00071D7D File Offset: 0x0006FF7D
		Friend Overridable Property Label11 As Label

		' Token: 0x17006329 RID: 25385
		' (get) Token: 0x06010359 RID: 66393 RVA: 0x00071D86 File Offset: 0x0006FF86
		' (set) Token: 0x0601035A RID: 66394 RVA: 0x00071D90 File Offset: 0x0006FF90
		Friend Overridable Property Label10 As Label

		' Token: 0x1700632A RID: 25386
		' (get) Token: 0x0601035B RID: 66395 RVA: 0x00071D99 File Offset: 0x0006FF99
		' (set) Token: 0x0601035C RID: 66396 RVA: 0x00071DA3 File Offset: 0x0006FFA3
		Friend Overridable Property Label9 As Label

		' Token: 0x1700632B RID: 25387
		' (get) Token: 0x0601035D RID: 66397 RVA: 0x00071DAC File Offset: 0x0006FFAC
		' (set) Token: 0x0601035E RID: 66398 RVA: 0x00071DB6 File Offset: 0x0006FFB6
		Friend Overridable Property TextBox10 As TextBox

		' Token: 0x1700632C RID: 25388
		' (get) Token: 0x0601035F RID: 66399 RVA: 0x00071DBF File Offset: 0x0006FFBF
		' (set) Token: 0x06010360 RID: 66400 RVA: 0x00071DC9 File Offset: 0x0006FFC9
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x1700632D RID: 25389
		' (get) Token: 0x06010361 RID: 66401 RVA: 0x00071DD2 File Offset: 0x0006FFD2
		' (set) Token: 0x06010362 RID: 66402 RVA: 0x00071DDC File Offset: 0x0006FFDC
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x1700632E RID: 25390
		' (get) Token: 0x06010363 RID: 66403 RVA: 0x00071DE5 File Offset: 0x0006FFE5
		' (set) Token: 0x06010364 RID: 66404 RVA: 0x00071DEF File Offset: 0x0006FFEF
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x1700632F RID: 25391
		' (get) Token: 0x06010365 RID: 66405 RVA: 0x00071DF8 File Offset: 0x0006FFF8
		' (set) Token: 0x06010366 RID: 66406 RVA: 0x00071E02 File Offset: 0x00070002
		Friend Overridable Property Label8 As Label

		' Token: 0x17006330 RID: 25392
		' (get) Token: 0x06010367 RID: 66407 RVA: 0x00071E0B File Offset: 0x0007000B
		' (set) Token: 0x06010368 RID: 66408 RVA: 0x00071E15 File Offset: 0x00070015
		Friend Overridable Property Label7 As Label

		' Token: 0x17006331 RID: 25393
		' (get) Token: 0x06010369 RID: 66409 RVA: 0x00071E1E File Offset: 0x0007001E
		' (set) Token: 0x0601036A RID: 66410 RVA: 0x00071E28 File Offset: 0x00070028
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17006332 RID: 25394
		' (get) Token: 0x0601036B RID: 66411 RVA: 0x00071E31 File Offset: 0x00070031
		' (set) Token: 0x0601036C RID: 66412 RVA: 0x00071E3B File Offset: 0x0007003B
		Friend Overridable Property Label6 As Label

		' Token: 0x17006333 RID: 25395
		' (get) Token: 0x0601036D RID: 66413 RVA: 0x00071E44 File Offset: 0x00070044
		' (set) Token: 0x0601036E RID: 66414 RVA: 0x00071E4E File Offset: 0x0007004E
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17006334 RID: 25396
		' (get) Token: 0x0601036F RID: 66415 RVA: 0x00071E57 File Offset: 0x00070057
		' (set) Token: 0x06010370 RID: 66416 RVA: 0x00071E61 File Offset: 0x00070061
		Friend Overridable Property Label5 As Label

		' Token: 0x17006335 RID: 25397
		' (get) Token: 0x06010371 RID: 66417 RVA: 0x00071E6A File Offset: 0x0007006A
		' (set) Token: 0x06010372 RID: 66418 RVA: 0x00071E74 File Offset: 0x00070074
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17006336 RID: 25398
		' (get) Token: 0x06010373 RID: 66419 RVA: 0x00071E7D File Offset: 0x0007007D
		' (set) Token: 0x06010374 RID: 66420 RVA: 0x00071E87 File Offset: 0x00070087
		Friend Overridable Property Label4 As Label

		' Token: 0x17006337 RID: 25399
		' (get) Token: 0x06010375 RID: 66421 RVA: 0x00071E90 File Offset: 0x00070090
		' (set) Token: 0x06010376 RID: 66422 RVA: 0x009A7DCC File Offset: 0x009A5FCC
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

		' Token: 0x17006338 RID: 25400
		' (get) Token: 0x06010377 RID: 66423 RVA: 0x00071E9A File Offset: 0x0007009A
		' (set) Token: 0x06010378 RID: 66424 RVA: 0x00071EA4 File Offset: 0x000700A4
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17006339 RID: 25401
		' (get) Token: 0x06010379 RID: 66425 RVA: 0x00071EAD File Offset: 0x000700AD
		' (set) Token: 0x0601037A RID: 66426 RVA: 0x009A7E10 File Offset: 0x009A6010
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox2_KeyPress
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700633A RID: 25402
		' (get) Token: 0x0601037B RID: 66427 RVA: 0x00071EB7 File Offset: 0x000700B7
		' (set) Token: 0x0601037C RID: 66428 RVA: 0x009A7E70 File Offset: 0x009A6070
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700633B RID: 25403
		' (get) Token: 0x0601037D RID: 66429 RVA: 0x00071EC1 File Offset: 0x000700C1
		' (set) Token: 0x0601037E RID: 66430 RVA: 0x00071ECB File Offset: 0x000700CB
		Friend Overridable Property Label3 As Label

		' Token: 0x1700633C RID: 25404
		' (get) Token: 0x0601037F RID: 66431 RVA: 0x00071ED4 File Offset: 0x000700D4
		' (set) Token: 0x06010380 RID: 66432 RVA: 0x00071EDE File Offset: 0x000700DE
		Friend Overridable Property Label14 As Label

		' Token: 0x1700633D RID: 25405
		' (get) Token: 0x06010381 RID: 66433 RVA: 0x00071EE7 File Offset: 0x000700E7
		' (set) Token: 0x06010382 RID: 66434 RVA: 0x00071EF1 File Offset: 0x000700F1
		Friend Overridable Property Label13 As Label

		' Token: 0x06010383 RID: 66435 RVA: 0x009A7ED0 File Offset: 0x009A60D0
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim num As Double = Conversion.Val(Me.TextBox1.Text)
			Dim num2 As Double = Conversion.Val(Me.TextBox2.Text)
			Dim num3 As Double = num * 100.0 / (100.0 + num2)
			Me.TextBox3.Text = Conversions.ToString(num3)
			Me.TextBox3.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox3.Text), 2))
			Me.TextBox3.Text = Strings.Format(Math.Round(num3, 2), "0.00")
			Dim num4 As Double = num - num3
			Me.TextBox4.Text = Conversions.ToString(num4)
			Me.TextBox4.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox4.Text), 2))
			Me.TextBox4.Text = Strings.Format(Math.Round(num4, 2), "0.00")
			Dim num5 As Double = num4 / 2.0
			Me.TextBox5.Text = Conversions.ToString(num5)
			Me.TextBox5.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox5.Text), 2))
			Me.TextBox5.Text = Strings.Format(Math.Round(num5, 2), "0.00")
			Dim num6 As Double = num4 / 2.0
			Me.TextBox6.Text = Conversions.ToString(num6)
			Me.TextBox6.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox6.Text), 2))
			Me.TextBox6.Text = Strings.Format(Math.Round(num6, 2), "0.00")
			Dim num7 As Double = num + num * num2 / 100.0
			Me.TextBox7.Text = Conversions.ToString(num7)
			Me.TextBox7.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox7.Text), 2))
			Me.TextBox7.Text = Strings.Format(Math.Round(num7, 2), "0.00")
			Dim num8 As Double = num7 - num
			Me.TextBox8.Text = Conversions.ToString(num8)
			Me.TextBox8.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox8.Text), 2))
			Me.TextBox8.Text = Strings.Format(Math.Round(num8, 2), "0.00")
			Dim num9 As Double = num8 / 2.0
			Me.TextBox9.Text = Conversions.ToString(num9)
			Me.TextBox9.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox9.Text), 2))
			Me.TextBox9.Text = Strings.Format(Math.Round(num9, 2), "0.00")
			Dim num10 As Double = num8 / 2.0
			Me.TextBox10.Text = Conversions.ToString(num10)
			Me.TextBox10.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.TextBox10.Text), 2))
			Me.TextBox10.Text = Strings.Format(Math.Round(num10, 2), "0.00")
		End Sub

		' Token: 0x06010384 RID: 66436 RVA: 0x009A8250 File Offset: 0x009A6450
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox9.Text = ""
			Me.TextBox10.Text = ""
		End Sub

		' Token: 0x06010385 RID: 66437 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010386 RID: 66438 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06010387 RID: 66439 RVA: 0x009A8308 File Offset: 0x009A6508
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag3 Then
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06010388 RID: 66440 RVA: 0x009A8308 File Offset: 0x009A6508
		Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag3 Then
					e.Handled = True
				End If
			End If
		End Sub
	End Class
End Namespace
