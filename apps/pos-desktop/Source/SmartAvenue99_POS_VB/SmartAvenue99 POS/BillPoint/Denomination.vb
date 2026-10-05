Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004A3 RID: 1187
	<DesignerGenerated()>
	Public Partial Class Denomination
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EB8F RID: 60303 RVA: 0x00067304 File Offset: 0x00065504
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Denomination_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005A64 RID: 23140
		' (get) Token: 0x0600EB92 RID: 60306 RVA: 0x00067324 File Offset: 0x00065524
		' (set) Token: 0x0600EB93 RID: 60307 RVA: 0x0006732E File Offset: 0x0006552E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005A65 RID: 23141
		' (get) Token: 0x0600EB94 RID: 60308 RVA: 0x00067337 File Offset: 0x00065537
		' (set) Token: 0x0600EB95 RID: 60309 RVA: 0x00067341 File Offset: 0x00065541
		Friend Overridable Property Label11 As Label

		' Token: 0x17005A66 RID: 23142
		' (get) Token: 0x0600EB96 RID: 60310 RVA: 0x0006734A File Offset: 0x0006554A
		' (set) Token: 0x0600EB97 RID: 60311 RVA: 0x00067354 File Offset: 0x00065554
		Friend Overridable Property Label10 As Label

		' Token: 0x17005A67 RID: 23143
		' (get) Token: 0x0600EB98 RID: 60312 RVA: 0x0006735D File Offset: 0x0006555D
		' (set) Token: 0x0600EB99 RID: 60313 RVA: 0x00067367 File Offset: 0x00065567
		Friend Overridable Property Label9 As Label

		' Token: 0x17005A68 RID: 23144
		' (get) Token: 0x0600EB9A RID: 60314 RVA: 0x00067370 File Offset: 0x00065570
		' (set) Token: 0x0600EB9B RID: 60315 RVA: 0x0006737A File Offset: 0x0006557A
		Friend Overridable Property Label8 As Label

		' Token: 0x17005A69 RID: 23145
		' (get) Token: 0x0600EB9C RID: 60316 RVA: 0x00067383 File Offset: 0x00065583
		' (set) Token: 0x0600EB9D RID: 60317 RVA: 0x0006738D File Offset: 0x0006558D
		Friend Overridable Property Label7 As Label

		' Token: 0x17005A6A RID: 23146
		' (get) Token: 0x0600EB9E RID: 60318 RVA: 0x00067396 File Offset: 0x00065596
		' (set) Token: 0x0600EB9F RID: 60319 RVA: 0x000673A0 File Offset: 0x000655A0
		Friend Overridable Property Label6 As Label

		' Token: 0x17005A6B RID: 23147
		' (get) Token: 0x0600EBA0 RID: 60320 RVA: 0x000673A9 File Offset: 0x000655A9
		' (set) Token: 0x0600EBA1 RID: 60321 RVA: 0x000673B3 File Offset: 0x000655B3
		Friend Overridable Property Label5 As Label

		' Token: 0x17005A6C RID: 23148
		' (get) Token: 0x0600EBA2 RID: 60322 RVA: 0x000673BC File Offset: 0x000655BC
		' (set) Token: 0x0600EBA3 RID: 60323 RVA: 0x000673C6 File Offset: 0x000655C6
		Friend Overridable Property Label4 As Label

		' Token: 0x17005A6D RID: 23149
		' (get) Token: 0x0600EBA4 RID: 60324 RVA: 0x000673CF File Offset: 0x000655CF
		' (set) Token: 0x0600EBA5 RID: 60325 RVA: 0x000673D9 File Offset: 0x000655D9
		Friend Overridable Property Label3 As Label

		' Token: 0x17005A6E RID: 23150
		' (get) Token: 0x0600EBA6 RID: 60326 RVA: 0x000673E2 File Offset: 0x000655E2
		' (set) Token: 0x0600EBA7 RID: 60327 RVA: 0x000673EC File Offset: 0x000655EC
		Friend Overridable Property Label2 As Label

		' Token: 0x17005A6F RID: 23151
		' (get) Token: 0x0600EBA8 RID: 60328 RVA: 0x000673F5 File Offset: 0x000655F5
		' (set) Token: 0x0600EBA9 RID: 60329 RVA: 0x000673FF File Offset: 0x000655FF
		Friend Overridable Property Label1 As Label

		' Token: 0x17005A70 RID: 23152
		' (get) Token: 0x0600EBAA RID: 60330 RVA: 0x00067408 File Offset: 0x00065608
		' (set) Token: 0x0600EBAB RID: 60331 RVA: 0x008E1F40 File Offset: 0x008E0140
		Private _TextBox13 As TextBox
		Friend Overridable Property TextBox13 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox13_TextChanged
				Dim textBox As TextBox = Me._TextBox13
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox13 = value
				textBox = Me._TextBox13
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A71 RID: 23153
		' (get) Token: 0x0600EBAC RID: 60332 RVA: 0x00067412 File Offset: 0x00065612
		' (set) Token: 0x0600EBAD RID: 60333 RVA: 0x0006741C File Offset: 0x0006561C
		Friend Overridable Property Label29 As Label

		' Token: 0x17005A72 RID: 23154
		' (get) Token: 0x0600EBAE RID: 60334 RVA: 0x00067425 File Offset: 0x00065625
		' (set) Token: 0x0600EBAF RID: 60335 RVA: 0x008E1F84 File Offset: 0x008E0184
		Private _TextBox14 As TextBox
		Friend Overridable Property TextBox14 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox14_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox14_KeyDown
				Dim textBox As TextBox = Me._TextBox14
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox14 = value
				textBox = Me._TextBox14
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A73 RID: 23155
		' (get) Token: 0x0600EBB0 RID: 60336 RVA: 0x0006742F File Offset: 0x0006562F
		' (set) Token: 0x0600EBB1 RID: 60337 RVA: 0x008E2000 File Offset: 0x008E0200
		Private _TextBox15 As TextBox
		Friend Overridable Property TextBox15 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox15_TextChanged
				Dim textBox As TextBox = Me._TextBox15
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox15 = value
				textBox = Me._TextBox15
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A74 RID: 23156
		' (get) Token: 0x0600EBB2 RID: 60338 RVA: 0x00067439 File Offset: 0x00065639
		' (set) Token: 0x0600EBB3 RID: 60339 RVA: 0x00067443 File Offset: 0x00065643
		Friend Overridable Property Label30 As Label

		' Token: 0x17005A75 RID: 23157
		' (get) Token: 0x0600EBB4 RID: 60340 RVA: 0x0006744C File Offset: 0x0006564C
		' (set) Token: 0x0600EBB5 RID: 60341 RVA: 0x008E2044 File Offset: 0x008E0244
		Private _TextBox16 As TextBox
		Friend Overridable Property TextBox16 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox16_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox16_KeyDown
				Dim textBox As TextBox = Me._TextBox16
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox16 = value
				textBox = Me._TextBox16
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A76 RID: 23158
		' (get) Token: 0x0600EBB6 RID: 60342 RVA: 0x00067456 File Offset: 0x00065656
		' (set) Token: 0x0600EBB7 RID: 60343 RVA: 0x008E20C0 File Offset: 0x008E02C0
		Private _TextBox17 As TextBox
		Friend Overridable Property TextBox17 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox17_TextChanged
				Dim textBox As TextBox = Me._TextBox17
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox17 = value
				textBox = Me._TextBox17
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A77 RID: 23159
		' (get) Token: 0x0600EBB8 RID: 60344 RVA: 0x00067460 File Offset: 0x00065660
		' (set) Token: 0x0600EBB9 RID: 60345 RVA: 0x0006746A File Offset: 0x0006566A
		Friend Overridable Property Label31 As Label

		' Token: 0x17005A78 RID: 23160
		' (get) Token: 0x0600EBBA RID: 60346 RVA: 0x00067473 File Offset: 0x00065673
		' (set) Token: 0x0600EBBB RID: 60347 RVA: 0x008E2104 File Offset: 0x008E0304
		Private _TextBox18 As TextBox
		Friend Overridable Property TextBox18 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox18_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox18_KeyDown
				Dim textBox As TextBox = Me._TextBox18
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox18 = value
				textBox = Me._TextBox18
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A79 RID: 23161
		' (get) Token: 0x0600EBBC RID: 60348 RVA: 0x0006747D File Offset: 0x0006567D
		' (set) Token: 0x0600EBBD RID: 60349 RVA: 0x008E2180 File Offset: 0x008E0380
		Private _TextBox19 As TextBox
		Friend Overridable Property TextBox19 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox19_TextChanged
				Dim textBox As TextBox = Me._TextBox19
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox19 = value
				textBox = Me._TextBox19
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A7A RID: 23162
		' (get) Token: 0x0600EBBE RID: 60350 RVA: 0x00067487 File Offset: 0x00065687
		' (set) Token: 0x0600EBBF RID: 60351 RVA: 0x00067491 File Offset: 0x00065691
		Friend Overridable Property Label32 As Label

		' Token: 0x17005A7B RID: 23163
		' (get) Token: 0x0600EBC0 RID: 60352 RVA: 0x0006749A File Offset: 0x0006569A
		' (set) Token: 0x0600EBC1 RID: 60353 RVA: 0x008E21C4 File Offset: 0x008E03C4
		Private _TextBox20 As TextBox
		Friend Overridable Property TextBox20 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox20_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox20_KeyDown
				Dim textBox As TextBox = Me._TextBox20
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox20 = value
				textBox = Me._TextBox20
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A7C RID: 23164
		' (get) Token: 0x0600EBC2 RID: 60354 RVA: 0x000674A4 File Offset: 0x000656A4
		' (set) Token: 0x0600EBC3 RID: 60355 RVA: 0x008E2240 File Offset: 0x008E0440
		Private _TextBox21 As TextBox
		Friend Overridable Property TextBox21 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox21
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox21_TextChanged
				Dim textBox As TextBox = Me._TextBox21
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox21 = value
				textBox = Me._TextBox21
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A7D RID: 23165
		' (get) Token: 0x0600EBC4 RID: 60356 RVA: 0x000674AE File Offset: 0x000656AE
		' (set) Token: 0x0600EBC5 RID: 60357 RVA: 0x000674B8 File Offset: 0x000656B8
		Friend Overridable Property Label33 As Label

		' Token: 0x17005A7E RID: 23166
		' (get) Token: 0x0600EBC6 RID: 60358 RVA: 0x000674C1 File Offset: 0x000656C1
		' (set) Token: 0x0600EBC7 RID: 60359 RVA: 0x008E2284 File Offset: 0x008E0484
		Private _TextBox22 As TextBox
		Friend Overridable Property TextBox22 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox22_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox22_KeyDown
				Dim textBox As TextBox = Me._TextBox22
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox22 = value
				textBox = Me._TextBox22
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A7F RID: 23167
		' (get) Token: 0x0600EBC8 RID: 60360 RVA: 0x000674CB File Offset: 0x000656CB
		' (set) Token: 0x0600EBC9 RID: 60361 RVA: 0x008E2300 File Offset: 0x008E0500
		Private _TextBox9 As TextBox
		Friend Overridable Property TextBox9 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox9_TextChanged
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A80 RID: 23168
		' (get) Token: 0x0600EBCA RID: 60362 RVA: 0x000674D5 File Offset: 0x000656D5
		' (set) Token: 0x0600EBCB RID: 60363 RVA: 0x000674DF File Offset: 0x000656DF
		Friend Overridable Property Label27 As Label

		' Token: 0x17005A81 RID: 23169
		' (get) Token: 0x0600EBCC RID: 60364 RVA: 0x000674E8 File Offset: 0x000656E8
		' (set) Token: 0x0600EBCD RID: 60365 RVA: 0x008E2344 File Offset: 0x008E0544
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox10_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox10_KeyDown
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A82 RID: 23170
		' (get) Token: 0x0600EBCE RID: 60366 RVA: 0x000674F2 File Offset: 0x000656F2
		' (set) Token: 0x0600EBCF RID: 60367 RVA: 0x008E23C0 File Offset: 0x008E05C0
		Private _TextBox11 As TextBox
		Friend Overridable Property TextBox11 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox11_TextChanged
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A83 RID: 23171
		' (get) Token: 0x0600EBD0 RID: 60368 RVA: 0x000674FC File Offset: 0x000656FC
		' (set) Token: 0x0600EBD1 RID: 60369 RVA: 0x00067506 File Offset: 0x00065706
		Friend Overridable Property Label28 As Label

		' Token: 0x17005A84 RID: 23172
		' (get) Token: 0x0600EBD2 RID: 60370 RVA: 0x0006750F File Offset: 0x0006570F
		' (set) Token: 0x0600EBD3 RID: 60371 RVA: 0x008E2404 File Offset: 0x008E0604
		Private _TextBox12 As TextBox
		Friend Overridable Property TextBox12 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox12_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox12_KeyDown
				Dim textBox As TextBox = Me._TextBox12
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox12 = value
				textBox = Me._TextBox12
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A85 RID: 23173
		' (get) Token: 0x0600EBD4 RID: 60372 RVA: 0x00067519 File Offset: 0x00065719
		' (set) Token: 0x0600EBD5 RID: 60373 RVA: 0x008E2480 File Offset: 0x008E0680
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox5_TextChanged
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A86 RID: 23174
		' (get) Token: 0x0600EBD6 RID: 60374 RVA: 0x00067523 File Offset: 0x00065723
		' (set) Token: 0x0600EBD7 RID: 60375 RVA: 0x0006752D File Offset: 0x0006572D
		Friend Overridable Property Label25 As Label

		' Token: 0x17005A87 RID: 23175
		' (get) Token: 0x0600EBD8 RID: 60376 RVA: 0x00067536 File Offset: 0x00065736
		' (set) Token: 0x0600EBD9 RID: 60377 RVA: 0x008E24C4 File Offset: 0x008E06C4
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox6_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox6_KeyDown
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A88 RID: 23176
		' (get) Token: 0x0600EBDA RID: 60378 RVA: 0x00067540 File Offset: 0x00065740
		' (set) Token: 0x0600EBDB RID: 60379 RVA: 0x008E2540 File Offset: 0x008E0740
		Private _TextBox7 As TextBox
		Friend Overridable Property TextBox7 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox7_TextChanged
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A89 RID: 23177
		' (get) Token: 0x0600EBDC RID: 60380 RVA: 0x0006754A File Offset: 0x0006574A
		' (set) Token: 0x0600EBDD RID: 60381 RVA: 0x00067554 File Offset: 0x00065754
		Friend Overridable Property Label26 As Label

		' Token: 0x17005A8A RID: 23178
		' (get) Token: 0x0600EBDE RID: 60382 RVA: 0x0006755D File Offset: 0x0006575D
		' (set) Token: 0x0600EBDF RID: 60383 RVA: 0x008E2584 File Offset: 0x008E0784
		Private _TextBox8 As TextBox
		Friend Overridable Property TextBox8 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox8_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox8_KeyDown
				Dim textBox As TextBox = Me._TextBox8
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox8 = value
				textBox = Me._TextBox8
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A8B RID: 23179
		' (get) Token: 0x0600EBE0 RID: 60384 RVA: 0x00067567 File Offset: 0x00065767
		' (set) Token: 0x0600EBE1 RID: 60385 RVA: 0x008E2600 File Offset: 0x008E0800
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

		' Token: 0x17005A8C RID: 23180
		' (get) Token: 0x0600EBE2 RID: 60386 RVA: 0x00067571 File Offset: 0x00065771
		' (set) Token: 0x0600EBE3 RID: 60387 RVA: 0x0006757B File Offset: 0x0006577B
		Friend Overridable Property Label24 As Label

		' Token: 0x17005A8D RID: 23181
		' (get) Token: 0x0600EBE4 RID: 60388 RVA: 0x00067584 File Offset: 0x00065784
		' (set) Token: 0x0600EBE5 RID: 60389 RVA: 0x008E2644 File Offset: 0x008E0844
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox4_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox4_KeyDown
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A8E RID: 23182
		' (get) Token: 0x0600EBE6 RID: 60390 RVA: 0x0006758E File Offset: 0x0006578E
		' (set) Token: 0x0600EBE7 RID: 60391 RVA: 0x008E26C0 File Offset: 0x008E08C0
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
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A8F RID: 23183
		' (get) Token: 0x0600EBE8 RID: 60392 RVA: 0x00067598 File Offset: 0x00065798
		' (set) Token: 0x0600EBE9 RID: 60393 RVA: 0x000675A2 File Offset: 0x000657A2
		Friend Overridable Property Label23 As Label

		' Token: 0x17005A90 RID: 23184
		' (get) Token: 0x0600EBEA RID: 60394 RVA: 0x000675AB File Offset: 0x000657AB
		' (set) Token: 0x0600EBEB RID: 60395 RVA: 0x008E2704 File Offset: 0x008E0904
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
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Onlynumberallow
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

		' Token: 0x17005A91 RID: 23185
		' (get) Token: 0x0600EBEC RID: 60396 RVA: 0x000675B5 File Offset: 0x000657B5
		' (set) Token: 0x0600EBED RID: 60397 RVA: 0x000675BF File Offset: 0x000657BF
		Friend Overridable Property Label12 As Label

		' Token: 0x17005A92 RID: 23186
		' (get) Token: 0x0600EBEE RID: 60398 RVA: 0x000675C8 File Offset: 0x000657C8
		' (set) Token: 0x0600EBEF RID: 60399 RVA: 0x000675D2 File Offset: 0x000657D2
		Friend Overridable Property Label13 As Label

		' Token: 0x17005A93 RID: 23187
		' (get) Token: 0x0600EBF0 RID: 60400 RVA: 0x000675DB File Offset: 0x000657DB
		' (set) Token: 0x0600EBF1 RID: 60401 RVA: 0x000675E5 File Offset: 0x000657E5
		Friend Overridable Property Label14 As Label

		' Token: 0x17005A94 RID: 23188
		' (get) Token: 0x0600EBF2 RID: 60402 RVA: 0x000675EE File Offset: 0x000657EE
		' (set) Token: 0x0600EBF3 RID: 60403 RVA: 0x000675F8 File Offset: 0x000657F8
		Friend Overridable Property Label15 As Label

		' Token: 0x17005A95 RID: 23189
		' (get) Token: 0x0600EBF4 RID: 60404 RVA: 0x00067601 File Offset: 0x00065801
		' (set) Token: 0x0600EBF5 RID: 60405 RVA: 0x0006760B File Offset: 0x0006580B
		Friend Overridable Property Label16 As Label

		' Token: 0x17005A96 RID: 23190
		' (get) Token: 0x0600EBF6 RID: 60406 RVA: 0x00067614 File Offset: 0x00065814
		' (set) Token: 0x0600EBF7 RID: 60407 RVA: 0x0006761E File Offset: 0x0006581E
		Friend Overridable Property Label17 As Label

		' Token: 0x17005A97 RID: 23191
		' (get) Token: 0x0600EBF8 RID: 60408 RVA: 0x00067627 File Offset: 0x00065827
		' (set) Token: 0x0600EBF9 RID: 60409 RVA: 0x00067631 File Offset: 0x00065831
		Friend Overridable Property Label18 As Label

		' Token: 0x17005A98 RID: 23192
		' (get) Token: 0x0600EBFA RID: 60410 RVA: 0x0006763A File Offset: 0x0006583A
		' (set) Token: 0x0600EBFB RID: 60411 RVA: 0x00067644 File Offset: 0x00065844
		Friend Overridable Property Label19 As Label

		' Token: 0x17005A99 RID: 23193
		' (get) Token: 0x0600EBFC RID: 60412 RVA: 0x0006764D File Offset: 0x0006584D
		' (set) Token: 0x0600EBFD RID: 60413 RVA: 0x00067657 File Offset: 0x00065857
		Friend Overridable Property Label20 As Label

		' Token: 0x17005A9A RID: 23194
		' (get) Token: 0x0600EBFE RID: 60414 RVA: 0x00067660 File Offset: 0x00065860
		' (set) Token: 0x0600EBFF RID: 60415 RVA: 0x0006766A File Offset: 0x0006586A
		Friend Overridable Property Label21 As Label

		' Token: 0x17005A9B RID: 23195
		' (get) Token: 0x0600EC00 RID: 60416 RVA: 0x00067673 File Offset: 0x00065873
		' (set) Token: 0x0600EC01 RID: 60417 RVA: 0x0006767D File Offset: 0x0006587D
		Friend Overridable Property Label22 As Label

		' Token: 0x17005A9C RID: 23196
		' (get) Token: 0x0600EC02 RID: 60418 RVA: 0x00067686 File Offset: 0x00065886
		' (set) Token: 0x0600EC03 RID: 60419 RVA: 0x008E2780 File Offset: 0x008E0980
		Private _TextBox23 As TextBox
		Friend Overridable Property TextBox23 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox23
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox23_TextChanged
				Dim textBox As TextBox = Me._TextBox23
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox23 = value
				textBox = Me._TextBox23
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A9D RID: 23197
		' (get) Token: 0x0600EC04 RID: 60420 RVA: 0x00067690 File Offset: 0x00065890
		' (set) Token: 0x0600EC05 RID: 60421 RVA: 0x008E27C4 File Offset: 0x008E09C4
		Private _TextBox24 As TextBox
		Friend Overridable Property TextBox24 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox24
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox24_TextChanged
				Dim textBox As TextBox = Me._TextBox24
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox24 = value
				textBox = Me._TextBox24
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005A9E RID: 23198
		' (get) Token: 0x0600EC06 RID: 60422 RVA: 0x0006769A File Offset: 0x0006589A
		' (set) Token: 0x0600EC07 RID: 60423 RVA: 0x000676A4 File Offset: 0x000658A4
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005A9F RID: 23199
		' (get) Token: 0x0600EC08 RID: 60424 RVA: 0x000676AD File Offset: 0x000658AD
		' (set) Token: 0x0600EC09 RID: 60425 RVA: 0x000676B7 File Offset: 0x000658B7
		Friend Overridable Property Label39 As Label

		' Token: 0x17005AA0 RID: 23200
		' (get) Token: 0x0600EC0A RID: 60426 RVA: 0x000676C0 File Offset: 0x000658C0
		' (set) Token: 0x0600EC0B RID: 60427 RVA: 0x000676CA File Offset: 0x000658CA
		Friend Overridable Property Label38 As Label

		' Token: 0x17005AA1 RID: 23201
		' (get) Token: 0x0600EC0C RID: 60428 RVA: 0x000676D3 File Offset: 0x000658D3
		' (set) Token: 0x0600EC0D RID: 60429 RVA: 0x000676DD File Offset: 0x000658DD
		Friend Overridable Property Label37 As Label

		' Token: 0x17005AA2 RID: 23202
		' (get) Token: 0x0600EC0E RID: 60430 RVA: 0x000676E6 File Offset: 0x000658E6
		' (set) Token: 0x0600EC0F RID: 60431 RVA: 0x000676F0 File Offset: 0x000658F0
		Friend Overridable Property Label36 As Label

		' Token: 0x17005AA3 RID: 23203
		' (get) Token: 0x0600EC10 RID: 60432 RVA: 0x000676F9 File Offset: 0x000658F9
		' (set) Token: 0x0600EC11 RID: 60433 RVA: 0x00067703 File Offset: 0x00065903
		Friend Overridable Property Label35 As Label

		' Token: 0x17005AA4 RID: 23204
		' (get) Token: 0x0600EC12 RID: 60434 RVA: 0x0006770C File Offset: 0x0006590C
		' (set) Token: 0x0600EC13 RID: 60435 RVA: 0x00067716 File Offset: 0x00065916
		Friend Overridable Property Label34 As Label

		' Token: 0x17005AA5 RID: 23205
		' (get) Token: 0x0600EC14 RID: 60436 RVA: 0x0006771F File Offset: 0x0006591F
		' (set) Token: 0x0600EC15 RID: 60437 RVA: 0x008E2808 File Offset: 0x008E0A08
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

		' Token: 0x0600EC16 RID: 60438 RVA: 0x008E2884 File Offset: 0x008E0A84
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(2000.0 * Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC17 RID: 60439 RVA: 0x008E2998 File Offset: 0x008E0B98
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Conversions.ToString(2000.0 * Conversion.Val(Me.TextBox1.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC18 RID: 60440 RVA: 0x008E2A9C File Offset: 0x008E0C9C
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = Strings.Format(Math.Round(1000.0 * Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC19 RID: 60441 RVA: 0x008E2BB0 File Offset: 0x008E0DB0
		Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox3.Text = Conversions.ToString(1000.0 * Conversion.Val(Me.TextBox4.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC1A RID: 60442 RVA: 0x008E2CB4 File Offset: 0x008E0EB4
		Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox7.Text = Strings.Format(Math.Round(500.0 * Conversion.Val(Me.TextBox8.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC1B RID: 60443 RVA: 0x008E2DC8 File Offset: 0x008E0FC8
		Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox7.Text = Conversions.ToString(500.0 * Conversion.Val(Me.TextBox8.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC1C RID: 60444 RVA: 0x008E2ECC File Offset: 0x008E10CC
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox5.Text = Strings.Format(Math.Round(200.0 * Conversion.Val(Me.TextBox6.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC1D RID: 60445 RVA: 0x008E2FE0 File Offset: 0x008E11E0
		Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox5.Text = Conversions.ToString(200.0 * Conversion.Val(Me.TextBox6.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC1E RID: 60446 RVA: 0x008E30E4 File Offset: 0x008E12E4
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox11.Text = Strings.Format(Math.Round(100.0 * Conversion.Val(Me.TextBox12.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC1F RID: 60447 RVA: 0x008E31F8 File Offset: 0x008E13F8
		Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox11.Text = Conversions.ToString(100.0 * Conversion.Val(Me.TextBox12.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC20 RID: 60448 RVA: 0x008E32FC File Offset: 0x008E14FC
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox9.Text = Strings.Format(Math.Round(50.0 * Conversion.Val(Me.TextBox10.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC21 RID: 60449 RVA: 0x008E3410 File Offset: 0x008E1610
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox9.Text = Conversions.ToString(50.0 * Conversion.Val(Me.TextBox10.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC22 RID: 60450 RVA: 0x008E3514 File Offset: 0x008E1714
		Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox21.Text = Strings.Format(Math.Round(20.0 * Conversion.Val(Me.TextBox22.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC23 RID: 60451 RVA: 0x008E3628 File Offset: 0x008E1828
		Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox21.Text = Conversions.ToString(20.0 * Conversion.Val(Me.TextBox22.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC24 RID: 60452 RVA: 0x008E372C File Offset: 0x008E192C
		Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox19.Text = Strings.Format(Math.Round(10.0 * Conversion.Val(Me.TextBox20.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC25 RID: 60453 RVA: 0x008E3840 File Offset: 0x008E1A40
		Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox19.Text = Conversions.ToString(10.0 * Conversion.Val(Me.TextBox20.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC26 RID: 60454 RVA: 0x008E3944 File Offset: 0x008E1B44
		Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox17.Text = Strings.Format(Math.Round(5.0 * Conversion.Val(Me.TextBox18.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC27 RID: 60455 RVA: 0x008E3A58 File Offset: 0x008E1C58
		Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox17.Text = Conversions.ToString(5.0 * Conversion.Val(Me.TextBox18.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC28 RID: 60456 RVA: 0x008E3B5C File Offset: 0x008E1D5C
		Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox15.Text = Strings.Format(Math.Round(2.0 * Conversion.Val(Me.TextBox16.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC29 RID: 60457 RVA: 0x008E3C70 File Offset: 0x008E1E70
		Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox15.Text = Conversions.ToString(2.0 * Conversion.Val(Me.TextBox16.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC2A RID: 60458 RVA: 0x008E3D74 File Offset: 0x008E1F74
		Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox13.Text = Strings.Format(Math.Round(1.0 * Conversion.Val(Me.TextBox14.Text), 2), "0.00")
			Me.TextBox23.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text))
		End Sub

		' Token: 0x0600EC2B RID: 60459 RVA: 0x008E3E88 File Offset: 0x008E2088
		Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox13.Text = Conversions.ToString(1.0 * Conversion.Val(Me.TextBox14.Text))
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC2C RID: 60460 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub Onlynumberallow(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600EC2D RID: 60461 RVA: 0x008E3F8C File Offset: 0x008E218C
		Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox23.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox21.Text) + Conversion.Val(Me.TextBox19.Text) + Conversion.Val(Me.TextBox17.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox13.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EC2E RID: 60462 RVA: 0x008E4078 File Offset: 0x008E2278
		Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox24.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox20.Text) + Conversion.Val(Me.TextBox18.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox14.Text))
		End Sub

		' Token: 0x0600EC2F RID: 60463 RVA: 0x008E4154 File Offset: 0x008E2354
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox12.Text = ""
			Me.TextBox10.Text = ""
			Me.TextBox22.Text = ""
			Me.TextBox20.Text = ""
			Me.TextBox18.Text = ""
			Me.TextBox16.Text = ""
			Me.TextBox14.Text = ""
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600EC30 RID: 60464 RVA: 0x00067729 File Offset: 0x00065929
		Private Sub Button1_MouseHover(sender As Object, e As EventArgs)
			Me.Button1.BackColor = Color.Red
			Me.Button1.ForeColor = Color.White
		End Sub

		' Token: 0x0600EC31 RID: 60465 RVA: 0x0006774E File Offset: 0x0006594E
		Private Sub Button1_MouseLeave(sender As Object, e As EventArgs)
			Me.Button1.BackColor = Color.White
			Me.Button1.ForeColor = Color.Blue
		End Sub

		' Token: 0x0600EC32 RID: 60466 RVA: 0x00067773 File Offset: 0x00065973
		Private Sub Denomination_Load(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600EC33 RID: 60467 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC34 RID: 60468 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC35 RID: 60469 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC36 RID: 60470 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC37 RID: 60471 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC38 RID: 60472 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC39 RID: 60473 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox22_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC3A RID: 60474 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox20_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC3B RID: 60475 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox18_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC3C RID: 60476 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600EC3D RID: 60477 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub
	End Class
End Namespace
