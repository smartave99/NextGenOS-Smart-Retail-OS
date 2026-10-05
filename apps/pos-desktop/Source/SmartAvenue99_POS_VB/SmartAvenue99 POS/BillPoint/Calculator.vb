Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000313 RID: 787
	Public Partial Class Calculator
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x17004AFA RID: 19194
		' (get) Token: 0x0600BC28 RID: 48168 RVA: 0x0005430D File Offset: 0x0005250D
		' (set) Token: 0x0600BC29 RID: 48169 RVA: 0x00054317 File Offset: 0x00052517
		Friend Overridable Property Label1 As Label

		' Token: 0x0600BC2A RID: 48170 RVA: 0x00054320 File Offset: 0x00052520
		Public Sub New()
			AddHandler MyBase.KeyPress, AddressOf Me.Form1_KeyPress
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004AFB RID: 19195
		' (get) Token: 0x0600BC2C RID: 48172 RVA: 0x00054357 File Offset: 0x00052557
		' (set) Token: 0x0600BC2D RID: 48173 RVA: 0x0078BFDC File Offset: 0x0078A1DC
		Private _btn3 As Button
		Friend Overridable Property btn3 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn3 = value
				button = Me._btn3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AFC RID: 19196
		' (get) Token: 0x0600BC2E RID: 48174 RVA: 0x00054361 File Offset: 0x00052561
		' (set) Token: 0x0600BC2F RID: 48175 RVA: 0x0078C020 File Offset: 0x0078A220
		Private _btn7 As Button
		Friend Overridable Property btn7 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn7 = value
				button = Me._btn7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AFD RID: 19197
		' (get) Token: 0x0600BC30 RID: 48176 RVA: 0x0005436B File Offset: 0x0005256B
		' (set) Token: 0x0600BC31 RID: 48177 RVA: 0x0078C064 File Offset: 0x0078A264
		Private _btn4 As Button
		Friend Overridable Property btn4 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn4 = value
				button = Me._btn4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AFE RID: 19198
		' (get) Token: 0x0600BC32 RID: 48178 RVA: 0x00054375 File Offset: 0x00052575
		' (set) Token: 0x0600BC33 RID: 48179 RVA: 0x0078C0A8 File Offset: 0x0078A2A8
		Private _btn2 As Button
		Friend Overridable Property btn2 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn2 = value
				button = Me._btn2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004AFF RID: 19199
		' (get) Token: 0x0600BC34 RID: 48180 RVA: 0x0005437F File Offset: 0x0005257F
		' (set) Token: 0x0600BC35 RID: 48181 RVA: 0x0078C0EC File Offset: 0x0078A2EC
		Private _btn5 As Button
		Friend Overridable Property btn5 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn5 = value
				button = Me._btn5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B00 RID: 19200
		' (get) Token: 0x0600BC36 RID: 48182 RVA: 0x00054389 File Offset: 0x00052589
		' (set) Token: 0x0600BC37 RID: 48183 RVA: 0x0078C130 File Offset: 0x0078A330
		Private _btn8 As Button
		Friend Overridable Property btn8 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn8 = value
				button = Me._btn8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B01 RID: 19201
		' (get) Token: 0x0600BC38 RID: 48184 RVA: 0x00054393 File Offset: 0x00052593
		' (set) Token: 0x0600BC39 RID: 48185 RVA: 0x0078C174 File Offset: 0x0078A374
		Private _btn6 As Button
		Friend Overridable Property btn6 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn6 = value
				button = Me._btn6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B02 RID: 19202
		' (get) Token: 0x0600BC3A RID: 48186 RVA: 0x0005439D File Offset: 0x0005259D
		' (set) Token: 0x0600BC3B RID: 48187 RVA: 0x0078C1B8 File Offset: 0x0078A3B8
		Private _btn0 As Button
		Friend Overridable Property btn0 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn0
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn0 = value
				button = Me._btn0
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B03 RID: 19203
		' (get) Token: 0x0600BC3C RID: 48188 RVA: 0x000543A7 File Offset: 0x000525A7
		' (set) Token: 0x0600BC3D RID: 48189 RVA: 0x0078C1FC File Offset: 0x0078A3FC
		Private _btn1 As Button
		Friend Overridable Property btn1 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn1 = value
				button = Me._btn1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B04 RID: 19204
		' (get) Token: 0x0600BC3E RID: 48190 RVA: 0x000543B1 File Offset: 0x000525B1
		' (set) Token: 0x0600BC3F RID: 48191 RVA: 0x0078C240 File Offset: 0x0078A440
		Private _btnClear As Button
		Friend Overridable Property btnClear As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClear_Click
				Dim button As Button = Me._btnClear
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClear = value
				button = Me._btnClear
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B05 RID: 19205
		' (get) Token: 0x0600BC40 RID: 48192 RVA: 0x000543BB File Offset: 0x000525BB
		' (set) Token: 0x0600BC41 RID: 48193 RVA: 0x0078C284 File Offset: 0x0078A484
		Private _btn9 As Button
		Friend Overridable Property btn9 As Button
			<CompilerGenerated()>
			Get
				Return Me._btn9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Digit_Click
				Dim button As Button = Me._btn9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btn9 = value
				button = Me._btn9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B06 RID: 19206
		' (get) Token: 0x0600BC42 RID: 48194 RVA: 0x000543C5 File Offset: 0x000525C5
		' (set) Token: 0x0600BC43 RID: 48195 RVA: 0x0078C2C8 File Offset: 0x0078A4C8
		Private _btnSqrt As Button
		Friend Overridable Property btnSqrt As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSqrt
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSqrt_Click
				Dim button As Button = Me._btnSqrt
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSqrt = value
				button = Me._btnSqrt
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B07 RID: 19207
		' (get) Token: 0x0600BC44 RID: 48196 RVA: 0x000543CF File Offset: 0x000525CF
		' (set) Token: 0x0600BC45 RID: 48197 RVA: 0x0078C30C File Offset: 0x0078A50C
		Private _btnPercentage As Button
		Friend Overridable Property btnPercentage As Button
			<CompilerGenerated()>
			Get
				Return Me._btnPercentage
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPercentage_Click
				Dim button As Button = Me._btnPercentage
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnPercentage = value
				button = Me._btnPercentage
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B08 RID: 19208
		' (get) Token: 0x0600BC46 RID: 48198 RVA: 0x000543D9 File Offset: 0x000525D9
		' (set) Token: 0x0600BC47 RID: 48199 RVA: 0x0078C350 File Offset: 0x0078A550
		Private _btnMC As Button
		Friend Overridable Property btnMC As Button
			<CompilerGenerated()>
			Get
				Return Me._btnMC
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnMC_Click
				Dim button As Button = Me._btnMC
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnMC = value
				button = Me._btnMC
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B09 RID: 19209
		' (get) Token: 0x0600BC48 RID: 48200 RVA: 0x000543E3 File Offset: 0x000525E3
		' (set) Token: 0x0600BC49 RID: 48201 RVA: 0x0078C394 File Offset: 0x0078A594
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0A RID: 19210
		' (get) Token: 0x0600BC4A RID: 48202 RVA: 0x000543ED File Offset: 0x000525ED
		' (set) Token: 0x0600BC4B RID: 48203 RVA: 0x0078C3D8 File Offset: 0x0078A5D8
		Private _btnMNeg As Button
		Friend Overridable Property btnMNeg As Button
			<CompilerGenerated()>
			Get
				Return Me._btnMNeg
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnMNeg_Click
				Dim button As Button = Me._btnMNeg
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnMNeg = value
				button = Me._btnMNeg
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0B RID: 19211
		' (get) Token: 0x0600BC4C RID: 48204 RVA: 0x000543F7 File Offset: 0x000525F7
		' (set) Token: 0x0600BC4D RID: 48205 RVA: 0x0078C41C File Offset: 0x0078A61C
		Private _btnBack As Button
		Friend Overridable Property btnBack As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBack
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBack_Click
				Dim button As Button = Me._btnBack
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBack = value
				button = Me._btnBack
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0C RID: 19212
		' (get) Token: 0x0600BC4E RID: 48206 RVA: 0x00054401 File Offset: 0x00052601
		' (set) Token: 0x0600BC4F RID: 48207 RVA: 0x0078C460 File Offset: 0x0078A660
		Private _btnMinus As Button
		Friend Overridable Property btnMinus As Button
			<CompilerGenerated()>
			Get
				Return Me._btnMinus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnMinus_Click
				Dim button As Button = Me._btnMinus
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnMinus = value
				button = Me._btnMinus
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0D RID: 19213
		' (get) Token: 0x0600BC50 RID: 48208 RVA: 0x0005440B File Offset: 0x0005260B
		' (set) Token: 0x0600BC51 RID: 48209 RVA: 0x0078C4A4 File Offset: 0x0078A6A4
		Private _btnMR As Button
		Friend Overridable Property btnMR As Button
			<CompilerGenerated()>
			Get
				Return Me._btnMR
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnMR_Click
				Dim button As Button = Me._btnMR
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnMR = value
				button = Me._btnMR
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0E RID: 19214
		' (get) Token: 0x0600BC52 RID: 48210 RVA: 0x00054415 File Offset: 0x00052615
		' (set) Token: 0x0600BC53 RID: 48211 RVA: 0x0078C4E8 File Offset: 0x0078A6E8
		Private _btnMPos As Button
		Friend Overridable Property btnMPos As Button
			<CompilerGenerated()>
			Get
				Return Me._btnMPos
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnMPos_Click
				Dim button As Button = Me._btnMPos
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnMPos = value
				button = Me._btnMPos
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B0F RID: 19215
		' (get) Token: 0x0600BC54 RID: 48212 RVA: 0x0005441F File Offset: 0x0005261F
		' (set) Token: 0x0600BC55 RID: 48213 RVA: 0x0078C52C File Offset: 0x0078A72C
		Private _btnDivide As Button
		Friend Overridable Property btnDivide As Button
			<CompilerGenerated()>
			Get
				Return Me._btnDivide
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnDivide_Click
				Dim button As Button = Me._btnDivide
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnDivide = value
				button = Me._btnDivide
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B10 RID: 19216
		' (get) Token: 0x0600BC56 RID: 48214 RVA: 0x00054429 File Offset: 0x00052629
		' (set) Token: 0x0600BC57 RID: 48215 RVA: 0x0078C570 File Offset: 0x0078A770
		Private _btnEqual As Button
		Friend Overridable Property btnEqual As Button
			<CompilerGenerated()>
			Get
				Return Me._btnEqual
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnEqual_Click
				Dim button As Button = Me._btnEqual
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnEqual = value
				button = Me._btnEqual
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B11 RID: 19217
		' (get) Token: 0x0600BC58 RID: 48216 RVA: 0x00054433 File Offset: 0x00052633
		' (set) Token: 0x0600BC59 RID: 48217 RVA: 0x0078C5B4 File Offset: 0x0078A7B4
		Private _btnTimes As Button
		Friend Overridable Property btnTimes As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTimes
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTimes_Click
				Dim button As Button = Me._btnTimes
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTimes = value
				button = Me._btnTimes
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B12 RID: 19218
		' (get) Token: 0x0600BC5A RID: 48218 RVA: 0x0005443D File Offset: 0x0005263D
		' (set) Token: 0x0600BC5B RID: 48219 RVA: 0x0078C5F8 File Offset: 0x0078A7F8
		Private _btnPoint As Button
		Friend Overridable Property btnPoint As Button
			<CompilerGenerated()>
			Get
				Return Me._btnPoint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPoint_Click
				Dim button As Button = Me._btnPoint
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnPoint = value
				button = Me._btnPoint
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B13 RID: 19219
		' (get) Token: 0x0600BC5C RID: 48220 RVA: 0x00054447 File Offset: 0x00052647
		' (set) Token: 0x0600BC5D RID: 48221 RVA: 0x0078C63C File Offset: 0x0078A83C
		Private _btnNegSign As Button
		Friend Overridable Property btnNegSign As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNegSign
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNegSign_Click
				Dim button As Button = Me._btnNegSign
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNegSign = value
				button = Me._btnNegSign
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004B14 RID: 19220
		' (get) Token: 0x0600BC5E RID: 48222 RVA: 0x00054451 File Offset: 0x00052651
		' (set) Token: 0x0600BC5F RID: 48223 RVA: 0x0005445B File Offset: 0x0005265B
		Friend Overridable Property MainMenu1 As MainMenu

		' Token: 0x17004B15 RID: 19221
		' (get) Token: 0x0600BC60 RID: 48224 RVA: 0x00054464 File Offset: 0x00052664
		' (set) Token: 0x0600BC61 RID: 48225 RVA: 0x0005446E File Offset: 0x0005266E
		Friend Overridable Property lblMemory As Label

		' Token: 0x17004B16 RID: 19222
		' (get) Token: 0x0600BC62 RID: 48226 RVA: 0x00054477 File Offset: 0x00052677
		' (set) Token: 0x0600BC63 RID: 48227 RVA: 0x00054481 File Offset: 0x00052681
		Friend Overridable Property lblDisplay As Label

		' Token: 0x17004B17 RID: 19223
		' (get) Token: 0x0600BC64 RID: 48228 RVA: 0x0005448A File Offset: 0x0005268A
		' (set) Token: 0x0600BC65 RID: 48229 RVA: 0x0078C680 File Offset: 0x0078A880
		Private _txtHiden As TextBox
		Friend Overridable Property txtHiden As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtHiden
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtHiden_KeyPress
				Dim textBox As TextBox = Me._txtHiden
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtHiden = value
				textBox = Me._txtHiden
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x0600BC67 RID: 48231 RVA: 0x0078E010 File Offset: 0x0078C210
		Private Sub Digit_Click(sender As Object, e As EventArgs)
			Dim button As Button = CType(sender, Button)
			Dim c As Char = Conversions.ToChar(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing))
			Me.FormatField(c)
			Me.LastInput = Calculator.Operation.Operand
			Me.Label1.Text = Me.lblDisplay.Text + " "
		End Sub

		' Token: 0x0600BC68 RID: 48232 RVA: 0x0078E074 File Offset: 0x0078C274
		Private Sub Backspace()
			Dim text As String = Me.lblDisplay.Text
			Dim flag As Boolean = Me.LastInput = Calculator.Operation.Operand
			If flag Then
				Dim flag2 As Boolean = (text.CompareTo("0") <> 0) And (text.Length <> 0)
				If flag2 Then
					' The following expression was wrapped in a checked-expression
					text = text.Remove(text.Length - 1, 1)
				End If
				Me.lblDisplay.Text = text
			Else
				Dim flag3 As Boolean = Me.LastInput = Calculator.Operation.None
				If flag3 Then
					Me.ResetCalc()
				End If
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC69 RID: 48233 RVA: 0x0078E0FC File Offset: 0x0078C2FC
		Private Sub ResetCalc()
			Me.dFirst = 0.0
			Me.dSecond = 0.0
			Me.iNumOps = 0
			Me.LastInput = Calculator.Operation.Cancel
			Me.cOperator = " "c
			Me.cOpPrev = " "c
			Me.Label1.Text = ""
			Me.lblDisplay.Text = Conversions.ToString(0)
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC6A RID: 48234 RVA: 0x0078E178 File Offset: 0x0078C378
		Private Sub CancelOrClear()
			Dim flag As Boolean = (Me.LastInput = Calculator.Operation.CE) Or (Me.LastInput = Calculator.Operation.None)
			If flag Then
				Me.ResetCalc()
			Else
				Dim flag2 As Boolean = Me.LastInput = Calculator.Operation.Operand
				If flag2 Then
					Me.lblDisplay.Text = Conversions.ToString(0)
					Me.Label1.Text = ""
					Me.LastInput = Calculator.Operation.CE
				Else
					Dim flag3 As Boolean = Me.LastInput = Calculator.Operation.[Operator]
					If flag3 Then
						Me.cOperator = Me.cOpPrev
						Me.LastInput = Calculator.Operation.CE
					Else
						Me.LastInput = Calculator.Operation.CE
					End If
				End If
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC6B RID: 48235 RVA: 0x00054494 File Offset: 0x00052694
		Private Sub Addition()
			Me.DisplayResult()
			Me.cOperator = "+"c
			Me.LastInput = Calculator.Operation.[Operator]
		End Sub

		' Token: 0x0600BC6C RID: 48236 RVA: 0x000544AD File Offset: 0x000526AD
		Private Sub Subtraction()
			Me.DisplayResult()
			Me.cOperator = "-"c
			Me.LastInput = Calculator.Operation.[Operator]
		End Sub

		' Token: 0x0600BC6D RID: 48237 RVA: 0x000544C6 File Offset: 0x000526C6
		Private Sub Multiplication()
			Me.DisplayResult()
			Me.cOperator = "*"c
			Me.LastInput = Calculator.Operation.[Operator]
		End Sub

		' Token: 0x0600BC6E RID: 48238 RVA: 0x000544DF File Offset: 0x000526DF
		Private Sub Division()
			Me.DisplayResult()
			Me.cOperator = "/"c
			Me.LastInput = Calculator.Operation.[Operator]
		End Sub

		' Token: 0x0600BC6F RID: 48239 RVA: 0x0078E21C File Offset: 0x0078C41C
		Private Sub NegSign()
			Dim flag As Boolean = Operators.CompareString(Conversions.ToString(Me.lblDisplay.Text(0)), "-", False) = 0
			If flag Then
				Me.lblDisplay.Text = Me.lblDisplay.Text.TrimStart(Me.sMinus.ToCharArray())
			Else
				Me.lblDisplay.Text = Me.sMinus + Me.lblDisplay.Text
				Me.LastInput = Calculator.Operation.Operand
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC70 RID: 48240 RVA: 0x0078E2B4 File Offset: 0x0078C4B4
		Private Sub FormatField(ByRef newChar As Char)
			Dim flag As Boolean = (Me.LastInput = Calculator.Operation.CE) Or (Me.LastInput = Calculator.Operation.Cancel) Or (Me.LastInput = Calculator.Operation.[Operator]) Or (Me.LastInput = Calculator.Operation.None)
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Conversions.ToString(newChar), ".", False) = 0
				If flag2 Then
					Me.lblDisplay.Text = "0" + newChar.ToString()
					Me.LastInput = Calculator.Operation.Operand
				Else
					Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(newChar), "0", False) = 0
					If flag3 Then
						Dim flag4 As Boolean = Operators.CompareString(Me.lblDisplay.Text.ToString(), "0", False) <> 0
						If flag4 Then
							Me.lblDisplay.Text = Conversions.ToString(0)
							Me.LastInput = Calculator.Operation.None
						End If
					Else
						Me.lblDisplay.Text = newChar.ToString()
						Me.LastInput = Calculator.Operation.Operand
					End If
				End If
			Else
				Dim flag5 As Boolean = Me.LastInput = Calculator.Operation.Operand
				If flag5 Then
					Dim text As String = Me.lblDisplay.Text
					Dim flag6 As Boolean = Operators.CompareString(Conversions.ToString(newChar), ".", False) = 0
					If flag6 Then
						Dim flag7 As Boolean = text.IndexOf(newChar) > 0
						If flag7 Then
							Return
						End If
					End If
					text += newChar.ToString()
					Me.lblDisplay.Text = text
				End If
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC71 RID: 48241 RVA: 0x0078E41C File Offset: 0x0078C61C
		Private Sub DisplayResult()
			Dim flag As Boolean = Me.lblDisplay.Text.Length = 0
			If flag Then
				Me.txtHiden.Focus()
			Else
				Dim flag2 As Boolean = Me.LastInput = Calculator.Operation.Percent
				If flag2 Then
					Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(Me.cOperator), "+", False) = 0
					If flag3 Then
						Me.dFirst += Me.dSecond
						Me.LastInput = Calculator.Operation.CE
					Else
						Dim flag4 As Boolean = Operators.CompareString(Conversions.ToString(Me.cOperator), "-", False) = 0
						If flag4 Then
							Me.dFirst -= Me.dSecond
							Me.LastInput = Calculator.Operation.CE
						End If
					End If
					Me.lblDisplay.Text = Me.dFirst.ToString()
				End If
				Dim flag5 As Boolean = (Me.LastInput = Calculator.Operation.Operand) Or (Me.LastInput = Calculator.Operation.None)
				If flag5 Then
					Dim num As Integer
					Me.iNumOps += 1
					num = Me.iNumOps
					If num <> 1 Then
						If num = 2 Then
							Me.dSecond = Conversions.ToDouble(Me.lblDisplay.Text)
							Dim c As Char = Me.cOperator
							Select Case c
								Case "*"c
									Me.dFirst *= Me.dSecond
								Case "+"c
									Me.dFirst += Me.dSecond
								Case ","c, "."c
								Case "-"c
									Me.dFirst -= Me.dSecond
								Case "/"c
									Dim flag6 As Boolean = Me.dSecond = 0.0
									If flag6 Then
										Me.lblDisplay.Text = "MA Error"
										Me.LastInput = Calculator.Operation.Cancel
										Return
									End If
									Me.dFirst /= Me.dSecond
								Case Else
									If c = "="c Then
										Me.dFirst = Me.dSecond
									End If
							End Select
							Me.lblDisplay.Text = Me.dFirst.ToString()
							Me.iNumOps = 1
						End If
					Else
						Me.dFirst = Conversions.ToDouble(Me.lblDisplay.Text)
					End If
					Me.LastInput = Calculator.Operation.[Operator]
					Me.cOpPrev = Me.cOperator
				End If
				Me.txtHiden.Focus()
			End If
		End Sub

		' Token: 0x0600BC72 RID: 48242 RVA: 0x0078E680 File Offset: 0x0078C880
		Private Sub SquareRoot(sRoot As String)
			Dim flag As Boolean = (Me.LastInput = Calculator.Operation.Operand) Or (Me.LastInput = Calculator.Operation.None)
			If flag Then
				Dim flag2 As Boolean = Conversion.Val(sRoot) < 0.0
				If flag2 Then
					Me.lblDisplay.Text = "MA Error"
					Me.LastInput = Calculator.Operation.CE
				Else
					sRoot = Conversions.ToString(Conversion.Val(sRoot))
					Me.lblDisplay.Text = Math.Sqrt(Conversions.ToDouble(sRoot)).ToString()
					Me.LastInput = Calculator.Operation.None
				End If
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC73 RID: 48243 RVA: 0x0078E718 File Offset: 0x0078C918
		Private Sub AddMemory(sMemory As String)
			Dim flag As Boolean = (Me.LastInput = Calculator.Operation.Operand) Or (Me.LastInput = Calculator.Operation.None)
			If flag Then
				sMemory = Conversions.ToString(Conversion.Val(sMemory))
				Me.dMemory += Conversions.ToDouble(sMemory)
				Dim flag2 As Boolean = Me.dMemory <> 0.0
				If flag2 Then
					Me.lblMemory.Visible = True
				Else
					Me.lblMemory.Visible = False
				End If
				Me.LastInput = Calculator.Operation.None
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC74 RID: 48244 RVA: 0x0078E7AC File Offset: 0x0078C9AC
		Private Sub SubtMemory(sMemory As String)
			Dim flag As Boolean = (Me.LastInput = Calculator.Operation.Operand) Or (Me.LastInput = Calculator.Operation.None)
			If flag Then
				sMemory = Conversions.ToString(Conversion.Val(sMemory))
				Me.dMemory -= Conversions.ToDouble(sMemory)
				Dim flag2 As Boolean = Me.dMemory <> 0.0
				If flag2 Then
					Me.lblMemory.Visible = True
				Else
					Me.lblMemory.Visible = False
				End If
				Me.LastInput = Calculator.Operation.None
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC75 RID: 48245 RVA: 0x0078E840 File Offset: 0x0078CA40
		Private Sub ShowMemory()
			Dim visible As Boolean = Me.lblMemory.Visible
			If visible Then
				Me.lblDisplay.Text = Me.dMemory.ToString()
				Me.LastInput = Calculator.Operation.None
			End If
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC76 RID: 48246 RVA: 0x0078E88C File Offset: 0x0078CA8C
		Private Sub CancelMemory()
			Dim visible As Boolean = Me.lblMemory.Visible
			If visible Then
				Me.dMemory = 0.0
				Me.lblMemory.Visible = False
			End If
			Me.LastInput = Calculator.Operation.None
			Me.txtHiden.Focus()
		End Sub

		' Token: 0x0600BC77 RID: 48247 RVA: 0x0078E8DC File Offset: 0x0078CADC
		Private Function Percentage(d1 As Double, d2 As Double, cOp As Char) As Double
			Dim flag As Boolean = Me.LastInput = Calculator.Operation.Operand
			Dim num As Double
			If flag Then
				Select Case cOp
					Case "*"c
						num = d1 * d2 / 100.0
						Me.LastInput = Calculator.Operation.Percent
						GoTo IL_0088
					Case "+"c
						num = (d1 + d2) / d2 * 100.0
						GoTo IL_0088
					Case "-"c
						num = (d1 - d2) / d2 * 100.0
						GoTo IL_0088
					Case "/"c
						num = d1 / d2 * 100.0
						GoTo IL_0088
				End Select
				num = d1
				IL_0088:
			End If
			Me.LastInput = Calculator.Operation.None
			Me.txtHiden.Focus()
			Return num
		End Function

		' Token: 0x0600BC78 RID: 48248 RVA: 0x000544F8 File Offset: 0x000526F8
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Me.Addition()
			Me.Label1.Text = Me.lblDisplay.Text + "  + "
		End Sub

		' Token: 0x0600BC79 RID: 48249 RVA: 0x00054523 File Offset: 0x00052723
		Private Sub btnMinus_Click(sender As Object, e As EventArgs)
			Me.Subtraction()
			Me.Label1.Text = Me.lblDisplay.Text + "  - "
		End Sub

		' Token: 0x0600BC7A RID: 48250 RVA: 0x0005454E File Offset: 0x0005274E
		Private Sub btnDivide_Click(sender As Object, e As EventArgs)
			Me.Division()
			Me.Label1.Text = Me.lblDisplay.Text + "  / "
		End Sub

		' Token: 0x0600BC7B RID: 48251 RVA: 0x00054579 File Offset: 0x00052779
		Private Sub btnTimes_Click(sender As Object, e As EventArgs)
			Me.Multiplication()
			Me.Label1.Text = Me.lblDisplay.Text + "  * "
		End Sub

		' Token: 0x0600BC7C RID: 48252 RVA: 0x000545A4 File Offset: 0x000527A4
		Private Sub btnEqual_Click(sender As Object, e As EventArgs)
			Me.DisplayResult()
			Me.cOperator = "="c
			Me.Label1.Text = "=" + Me.lblDisplay.Text
		End Sub

		' Token: 0x0600BC7D RID: 48253 RVA: 0x0078E988 File Offset: 0x0078CB88
		Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = keyChar >= Convert.ToChar(48) AndAlso keyChar <= Convert.ToChar(57)
			If flag Then
				Dim keyChar2 As Char = e.KeyChar
				Me.FormatField(keyChar2)
				Me.LastInput = Calculator.Operation.Operand
			Else
				flag = keyChar = Convert.ToChar(8)
				If flag Then
					Me.Backspace()
				Else
					flag = keyChar = Convert.ToChar(43)
					If flag Then
						Me.Addition()
					Else
						flag = keyChar = Convert.ToChar(45)
						If flag Then
							Me.Subtraction()
						Else
							flag = keyChar = Convert.ToChar(42)
							If flag Then
								Me.Multiplication()
							Else
								flag = keyChar = Convert.ToChar(47)
								If flag Then
									Me.Division()
								Else
									flag = keyChar = Convert.ToChar(46)
									If flag Then
										Dim keyChar3 As Char = e.KeyChar
										Me.FormatField(keyChar3)
										e.KeyChar = keyChar3
									Else
										flag = keyChar = vbCr
										If flag Then
											Me.DisplayResult()
											Me.cOperator = "="c
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BC7E RID: 48254 RVA: 0x000545D7 File Offset: 0x000527D7
		Private Sub btnClear_Click(sender As Object, e As EventArgs)
			Me.CancelOrClear()
		End Sub

		' Token: 0x0600BC7F RID: 48255 RVA: 0x000545E1 File Offset: 0x000527E1
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.ResetCalc()
			Me.sMinus = "-"
			Me.iNumOps = 0
			Me.dMemory = 0.0
		End Sub

		' Token: 0x0600BC80 RID: 48256 RVA: 0x0078EA98 File Offset: 0x0078CC98
		Private Sub btnPoint_Click(sender As Object, e As EventArgs)
			Dim c As Char = Conversions.ToChar(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing))
			Me.FormatField(c)
			NewLateBinding.LateSetComplex(sender, Nothing, "text", New Object() { c }, Nothing, Nothing, True, False)
		End Sub

		' Token: 0x0600BC81 RID: 48257 RVA: 0x0005460C File Offset: 0x0005280C
		Private Sub btnBack_Click(sender As Object, e As EventArgs)
			Me.Backspace()
			Me.Label1.Text = Me.lblDisplay.Text + "  < "
		End Sub

		' Token: 0x0600BC82 RID: 48258 RVA: 0x00054637 File Offset: 0x00052837
		Private Sub btnNegSign_Click(sender As Object, e As EventArgs)
			Me.NegSign()
			Me.Label1.Text = Me.lblDisplay.Text + "  +/- "
		End Sub

		' Token: 0x0600BC83 RID: 48259 RVA: 0x00054662 File Offset: 0x00052862
		Private Sub btnSqrt_Click(sender As Object, e As EventArgs)
			Me.SquareRoot(Me.lblDisplay.Text)
			Me.Label1.Text = Me.Label1.Text + "  sqrt "
		End Sub

		' Token: 0x0600BC84 RID: 48260 RVA: 0x00054698 File Offset: 0x00052898
		Private Sub btnMC_Click(sender As Object, e As EventArgs)
			Me.CancelMemory()
			Me.Label1.Text = Me.lblDisplay.Text + "  MC "
		End Sub

		' Token: 0x0600BC85 RID: 48261 RVA: 0x000546C3 File Offset: 0x000528C3
		Private Sub btnMR_Click(sender As Object, e As EventArgs)
			Me.ShowMemory()
			Me.Label1.Text = Me.lblDisplay.Text + "  MR "
		End Sub

		' Token: 0x0600BC86 RID: 48262 RVA: 0x000546EE File Offset: 0x000528EE
		Private Sub btnMNeg_Click(sender As Object, e As EventArgs)
			Me.SubtMemory(Me.lblDisplay.Text)
			Me.Label1.Text = Me.lblDisplay.Text + "  M- "
		End Sub

		' Token: 0x0600BC87 RID: 48263 RVA: 0x00054724 File Offset: 0x00052924
		Private Sub btnMPos_Click(sender As Object, e As EventArgs)
			Me.AddMemory(Me.lblDisplay.Text)
			Me.Label1.Text = Me.lblDisplay.Text + "  M+ "
		End Sub

		' Token: 0x0600BC88 RID: 48264 RVA: 0x0078EAEC File Offset: 0x0078CCEC
		Private Sub btnPercentage_Click(sender As Object, e As EventArgs)
			Dim num As Double = Conversion.Val(Me.lblDisplay.Text)
			Me.dSecond = num
			Me.lblDisplay.Text = Me.Percentage(Me.dFirst, num, Me.cOperator).ToString()
			Me.Label1.Text = Me.Label1.Text + "  % "
		End Sub

		' Token: 0x0600BC89 RID: 48265 RVA: 0x0005475A File Offset: 0x0005295A
		Private Sub txtHiden_KeyPress(sender As Object, e As KeyPressEventArgs)
			Me.Form1_KeyPress(RuntimeHelpers.GetObjectValue(sender), e)
		End Sub

		' Token: 0x04004BBF RID: 19391
		Private dFirst As Double

		' Token: 0x04004BC0 RID: 19392
		Private dSecond As Double

		' Token: 0x04004BC1 RID: 19393
		Private dMemory As Double

		' Token: 0x04004BC2 RID: 19394
		Private cOperator As Char

		' Token: 0x04004BC3 RID: 19395
		Private iNumOps As Integer

		' Token: 0x04004BC4 RID: 19396
		Private cOpPrev As Char

		' Token: 0x04004BC5 RID: 19397
		Private sMinus As String

		' Token: 0x04004BC7 RID: 19399
		Private LastInput As Calculator.Operation

		' Token: 0x02000314 RID: 788
		Public Enum Operation
			' Token: 0x04004BE7 RID: 19431
			None
			' Token: 0x04004BE8 RID: 19432
			Operand
			' Token: 0x04004BE9 RID: 19433
			[Operator]
			' Token: 0x04004BEA RID: 19434
			CE
			' Token: 0x04004BEB RID: 19435
			Cancel
			' Token: 0x04004BEC RID: 19436
			Percent
		End Enum
	End Class
End Namespace
