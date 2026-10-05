Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020002AD RID: 685
	<DesignerGenerated()>
	Public Partial Class frmSalesReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B192 RID: 45458 RVA: 0x000527DF File Offset: 0x000509DF
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700449C RID: 17564
		' (get) Token: 0x0600B195 RID: 45461 RVA: 0x00052811 File Offset: 0x00050A11
		' (set) Token: 0x0600B196 RID: 45462 RVA: 0x0005281B File Offset: 0x00050A1B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700449D RID: 17565
		' (get) Token: 0x0600B197 RID: 45463 RVA: 0x00052824 File Offset: 0x00050A24
		' (set) Token: 0x0600B198 RID: 45464 RVA: 0x0005282E File Offset: 0x00050A2E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700449E RID: 17566
		' (get) Token: 0x0600B199 RID: 45465 RVA: 0x00052837 File Offset: 0x00050A37
		' (set) Token: 0x0600B19A RID: 45466 RVA: 0x00052841 File Offset: 0x00050A41
		Friend Overridable Property Label1 As Label

		' Token: 0x1700449F RID: 17567
		' (get) Token: 0x0600B19B RID: 45467 RVA: 0x0005284A File Offset: 0x00050A4A
		' (set) Token: 0x0600B19C RID: 45468 RVA: 0x00767B64 File Offset: 0x00765D64
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044A0 RID: 17568
		' (get) Token: 0x0600B19D RID: 45469 RVA: 0x00052854 File Offset: 0x00050A54
		' (set) Token: 0x0600B19E RID: 45470 RVA: 0x0005285E File Offset: 0x00050A5E
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170044A1 RID: 17569
		' (get) Token: 0x0600B19F RID: 45471 RVA: 0x00052867 File Offset: 0x00050A67
		' (set) Token: 0x0600B1A0 RID: 45472 RVA: 0x00052871 File Offset: 0x00050A71
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170044A2 RID: 17570
		' (get) Token: 0x0600B1A1 RID: 45473 RVA: 0x0005287A File Offset: 0x00050A7A
		' (set) Token: 0x0600B1A2 RID: 45474 RVA: 0x00052884 File Offset: 0x00050A84
		Friend Overridable Property Label2 As Label

		' Token: 0x170044A3 RID: 17571
		' (get) Token: 0x0600B1A3 RID: 45475 RVA: 0x0005288D File Offset: 0x00050A8D
		' (set) Token: 0x0600B1A4 RID: 45476 RVA: 0x00052897 File Offset: 0x00050A97
		Friend Overridable Property Label4 As Label

		' Token: 0x170044A4 RID: 17572
		' (get) Token: 0x0600B1A5 RID: 45477 RVA: 0x000528A0 File Offset: 0x00050AA0
		' (set) Token: 0x0600B1A6 RID: 45478 RVA: 0x000528AA File Offset: 0x00050AAA
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170044A5 RID: 17573
		' (get) Token: 0x0600B1A7 RID: 45479 RVA: 0x000528B3 File Offset: 0x00050AB3
		' (set) Token: 0x0600B1A8 RID: 45480 RVA: 0x000528BD File Offset: 0x00050ABD
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x170044A6 RID: 17574
		' (get) Token: 0x0600B1A9 RID: 45481 RVA: 0x000528C6 File Offset: 0x00050AC6
		' (set) Token: 0x0600B1AA RID: 45482 RVA: 0x000528D0 File Offset: 0x00050AD0
		Friend Overridable Property Label3 As Label

		' Token: 0x170044A7 RID: 17575
		' (get) Token: 0x0600B1AB RID: 45483 RVA: 0x000528D9 File Offset: 0x00050AD9
		' (set) Token: 0x0600B1AC RID: 45484 RVA: 0x000528E3 File Offset: 0x00050AE3
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x170044A8 RID: 17576
		' (get) Token: 0x0600B1AD RID: 45485 RVA: 0x000528EC File Offset: 0x00050AEC
		' (set) Token: 0x0600B1AE RID: 45486 RVA: 0x000528F6 File Offset: 0x00050AF6
		Friend Overridable Property Label6 As Label

		' Token: 0x170044A9 RID: 17577
		' (get) Token: 0x0600B1AF RID: 45487 RVA: 0x000528FF File Offset: 0x00050AFF
		' (set) Token: 0x0600B1B0 RID: 45488 RVA: 0x00052909 File Offset: 0x00050B09
		Friend Overridable Property ComboBox3 As ComboBox

		' Token: 0x170044AA RID: 17578
		' (get) Token: 0x0600B1B1 RID: 45489 RVA: 0x00052912 File Offset: 0x00050B12
		' (set) Token: 0x0600B1B2 RID: 45490 RVA: 0x0005291C File Offset: 0x00050B1C
		Friend Overridable Property Label5 As Label

		' Token: 0x170044AB RID: 17579
		' (get) Token: 0x0600B1B3 RID: 45491 RVA: 0x00052925 File Offset: 0x00050B25
		' (set) Token: 0x0600B1B4 RID: 45492 RVA: 0x0005292F File Offset: 0x00050B2F
		Friend Overridable Property Label7 As Label

		' Token: 0x170044AC RID: 17580
		' (get) Token: 0x0600B1B5 RID: 45493 RVA: 0x00052938 File Offset: 0x00050B38
		' (set) Token: 0x0600B1B6 RID: 45494 RVA: 0x00052942 File Offset: 0x00050B42
		Friend Overridable Property ComboBox4 As ComboBox

		' Token: 0x170044AD RID: 17581
		' (get) Token: 0x0600B1B7 RID: 45495 RVA: 0x0005294B File Offset: 0x00050B4B
		' (set) Token: 0x0600B1B8 RID: 45496 RVA: 0x00052955 File Offset: 0x00050B55
		Friend Overridable Property Label8 As Label

		' Token: 0x170044AE RID: 17582
		' (get) Token: 0x0600B1B9 RID: 45497 RVA: 0x0005295E File Offset: 0x00050B5E
		' (set) Token: 0x0600B1BA RID: 45498 RVA: 0x00767BA8 File Offset: 0x00765DA8
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044AF RID: 17583
		' (get) Token: 0x0600B1BB RID: 45499 RVA: 0x00052968 File Offset: 0x00050B68
		' (set) Token: 0x0600B1BC RID: 45500 RVA: 0x00767BEC File Offset: 0x00765DEC
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B0 RID: 17584
		' (get) Token: 0x0600B1BD RID: 45501 RVA: 0x00052972 File Offset: 0x00050B72
		' (set) Token: 0x0600B1BE RID: 45502 RVA: 0x00767C30 File Offset: 0x00765E30
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B1 RID: 17585
		' (get) Token: 0x0600B1BF RID: 45503 RVA: 0x0005297C File Offset: 0x00050B7C
		' (set) Token: 0x0600B1C0 RID: 45504 RVA: 0x00767C74 File Offset: 0x00765E74
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B2 RID: 17586
		' (get) Token: 0x0600B1C1 RID: 45505 RVA: 0x00052986 File Offset: 0x00050B86
		' (set) Token: 0x0600B1C2 RID: 45506 RVA: 0x00767CB8 File Offset: 0x00765EB8
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B3 RID: 17587
		' (get) Token: 0x0600B1C3 RID: 45507 RVA: 0x00052990 File Offset: 0x00050B90
		' (set) Token: 0x0600B1C4 RID: 45508 RVA: 0x00767CFC File Offset: 0x00765EFC
		Private _GelButton7 As GelButton
		Friend Overridable Property GelButton7 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton7_Click
				Dim gelButton As GelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton7 = value
				gelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B4 RID: 17588
		' (get) Token: 0x0600B1C5 RID: 45509 RVA: 0x0005299A File Offset: 0x00050B9A
		' (set) Token: 0x0600B1C6 RID: 45510 RVA: 0x00767D40 File Offset: 0x00765F40
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B5 RID: 17589
		' (get) Token: 0x0600B1C7 RID: 45511 RVA: 0x000529A4 File Offset: 0x00050BA4
		' (set) Token: 0x0600B1C8 RID: 45512 RVA: 0x00767D84 File Offset: 0x00765F84
		Private _GelButton12 As GelButton
		Friend Overridable Property GelButton12 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton12_Click
				Dim gelButton As GelButton = Me._GelButton12
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton12 = value
				gelButton = Me._GelButton12
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B6 RID: 17590
		' (get) Token: 0x0600B1C9 RID: 45513 RVA: 0x000529AE File Offset: 0x00050BAE
		' (set) Token: 0x0600B1CA RID: 45514 RVA: 0x00767DC8 File Offset: 0x00765FC8
		Private _GelButton13 As GelButton
		Friend Overridable Property GelButton13 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton13_Click
				Dim gelButton As GelButton = Me._GelButton13
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton13 = value
				gelButton = Me._GelButton13
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B7 RID: 17591
		' (get) Token: 0x0600B1CB RID: 45515 RVA: 0x000529B8 File Offset: 0x00050BB8
		' (set) Token: 0x0600B1CC RID: 45516 RVA: 0x00767E0C File Offset: 0x0076600C
		Private _GelButton10 As GelButton
		Friend Overridable Property GelButton10 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton10_Click
				Dim gelButton As GelButton = Me._GelButton10
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton10 = value
				gelButton = Me._GelButton10
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B8 RID: 17592
		' (get) Token: 0x0600B1CD RID: 45517 RVA: 0x000529C2 File Offset: 0x00050BC2
		' (set) Token: 0x0600B1CE RID: 45518 RVA: 0x00767E50 File Offset: 0x00766050
		Private _GelButton11 As GelButton
		Friend Overridable Property GelButton11 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton11_Click
				Dim gelButton As GelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton11 = value
				gelButton = Me._GelButton11
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044B9 RID: 17593
		' (get) Token: 0x0600B1CF RID: 45519 RVA: 0x000529CC File Offset: 0x00050BCC
		' (set) Token: 0x0600B1D0 RID: 45520 RVA: 0x00767E94 File Offset: 0x00766094
		Private _GelButton8 As GelButton
		Friend Overridable Property GelButton8 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton8_Click
				Dim gelButton As GelButton = Me._GelButton8
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton8 = value
				gelButton = Me._GelButton8
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044BA RID: 17594
		' (get) Token: 0x0600B1D1 RID: 45521 RVA: 0x000529D6 File Offset: 0x00050BD6
		' (set) Token: 0x0600B1D2 RID: 45522 RVA: 0x00767ED8 File Offset: 0x007660D8
		Private _GelButton9 As GelButton
		Friend Overridable Property GelButton9 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton9_Click
				Dim gelButton As GelButton = Me._GelButton9
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton9 = value
				gelButton = Me._GelButton9
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044BB RID: 17595
		' (get) Token: 0x0600B1D3 RID: 45523 RVA: 0x000529E0 File Offset: 0x00050BE0
		' (set) Token: 0x0600B1D4 RID: 45524 RVA: 0x00767F1C File Offset: 0x0076611C
		Private _GelButton14 As GelButton
		Friend Overridable Property GelButton14 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton14_Click
				Dim gelButton As GelButton = Me._GelButton14
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton14 = value
				gelButton = Me._GelButton14
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044BC RID: 17596
		' (get) Token: 0x0600B1D5 RID: 45525 RVA: 0x000529EA File Offset: 0x00050BEA
		' (set) Token: 0x0600B1D6 RID: 45526 RVA: 0x00767F60 File Offset: 0x00766160
		Private _GelButton15 As GelButton
		Friend Overridable Property GelButton15 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton15_Click
				Dim gelButton As GelButton = Me._GelButton15
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton15 = value
				gelButton = Me._GelButton15
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044BD RID: 17597
		' (get) Token: 0x0600B1D7 RID: 45527 RVA: 0x000529F4 File Offset: 0x00050BF4
		' (set) Token: 0x0600B1D8 RID: 45528 RVA: 0x000529FE File Offset: 0x00050BFE
		Friend Overridable Property Label9 As Label

		' Token: 0x170044BE RID: 17598
		' (get) Token: 0x0600B1D9 RID: 45529 RVA: 0x00052A07 File Offset: 0x00050C07
		' (set) Token: 0x0600B1DA RID: 45530 RVA: 0x00052A11 File Offset: 0x00050C11
		Friend Overridable Property cbox_saletype As ComboBox

		' Token: 0x170044BF RID: 17599
		' (get) Token: 0x0600B1DB RID: 45531 RVA: 0x00052A1A File Offset: 0x00050C1A
		' (set) Token: 0x0600B1DC RID: 45532 RVA: 0x00767FA4 File Offset: 0x007661A4
		Private _GelButton16 As GelButton
		Friend Overridable Property GelButton16 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton16_Click
				Dim gelButton As GelButton = Me._GelButton16
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton16 = value
				gelButton = Me._GelButton16
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600B1DD RID: 45533 RVA: 0x00767FE8 File Offset: 0x007661E8
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B1DE RID: 45534 RVA: 0x007680C4 File Offset: 0x007662C4
		Public Sub fillCustomerName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Customer", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox1.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox1.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1DF RID: 45535 RVA: 0x007681F8 File Offset: 0x007663F8
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.ComboBox3.SelectedIndex = -1
			Me.ComboBox4.SelectedIndex = -1
		End Sub

		' Token: 0x0600B1E0 RID: 45536 RVA: 0x00052A24 File Offset: 0x00050C24
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600B1E1 RID: 45537 RVA: 0x00768254 File Offset: 0x00766454
		Public Sub fillTillID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TillID) FROM Invoiceinfo", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.ComboBox2.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.ComboBox2.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1E2 RID: 45538 RVA: 0x00768388 File Offset: 0x00766588
		Public Sub FillUserID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(UserID) from Registration Order by UserID"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.ComboBox3.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox3.Items.Add(ModCommonClasses.rdr.GetValue(0).ToString())
				End While
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1E3 RID: 45539 RVA: 0x00052A40 File Offset: 0x00050C40
		Private Sub frmSalesReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.fillCustomerName()
			Me.fillTillID()
			Me.FillUserID()
			Me.Convert_Language()
			Me.cbox_saletype.SelectedIndex = 0
		End Sub

		' Token: 0x0600B1E4 RID: 45540 RVA: 0x0076845C File Offset: 0x0076665C
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600B1E5 RID: 45541 RVA: 0x007685D4 File Offset: 0x007667D4
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600B1E6 RID: 45542 RVA: 0x00768690 File Offset: 0x00766890
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600B1E7 RID: 45543 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600B1E8 RID: 45544 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600B1E9 RID: 45545 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600B1EA RID: 45546 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button10_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600B1EB RID: 45547 RVA: 0x00052A73 File Offset: 0x00050C73
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600B1EC RID: 45548 RVA: 0x0076875C File Offset: 0x0076695C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "Select * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID where InvoiceDate between @d2 and @d3 order by Name"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim text2 As String = "Select * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID where CType=@dx and InvoiceDate between @d2 and @d3 order by Name"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.Name, Sum(Invoice_Product.Margin), InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d2 and @d3 group by InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.Name, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.Name, Sum(Invoice_Product.Margin), InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate between @d2 and @d3 group by InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, Customer.Name, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("ProfitAndLossReport.xml")
					Dim rptProfitAndLoss As rptProfitAndLoss = New rptProfitAndLoss()
					rptProfitAndLoss.SetDataSource(ModCommonClasses.ds)
					rptProfitAndLoss.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptProfitAndLoss.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptProfitAndLoss.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptProfitAndLoss
					MyProject.Forms.frmReport.ShowDialog()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1ED RID: 45549 RVA: 0x00768C18 File Offset: 0x00766E18
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate >=@d1 and InvoiceDate < @d2 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate >=@d1 and InvoiceDate < @d2 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd1 = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					ModCommonClasses.adp1 = New SqlDataAdapter(ModCommonClasses.cmd1)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable1 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp1.Fill(ModCommonClasses.dtable1)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable1)
					ModCommonClasses.ds.WriteXmlSchema("Sales_XML.xml")
					Dim rptSales As rptSales1 = New rptSales1()
					rptSales.SetDataSource(ModCommonClasses.ds)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag5 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag5 Then
						Dim text3 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text4 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(1))
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(2))
					Else
						Me.a = 0D
						Me.b = 0D
						Me.c = 0D
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag7 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag7 Then
						Dim text5 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text5)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text6 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text6)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
					If flag8 Then
						Me.d = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					Else
						Me.d = 0D
					End If
					ModCommonClasses.con.Close()
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p3", Me.a)
					rptSales.SetParameterValue("p4", Me.b)
					rptSales.SetParameterValue("p5", Me.c)
					rptSales.SetParameterValue("p6", Me.d)
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1EE RID: 45550 RVA: 0x007695C0 File Offset: 0x007677C0
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and Customer.Name=@d33 order by InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox1.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1.xml")
					Dim rptSales As rptSales = New rptSales()
					rptSales.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSales.SetDataSource(ModCommonClasses.ds)
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1EF RID: 45551 RVA: 0x007699BC File Offset: 0x00767BBC
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 and Customer.Name=@d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate >=@d1 and Customer.Name=@d3 order by InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox1.Text)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd1 = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					ModCommonClasses.adp1 = New SqlDataAdapter(ModCommonClasses.cmd1)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable1 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp1.Fill(ModCommonClasses.dtable1)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable1)
					ModCommonClasses.ds.WriteXmlSchema("Sales_XML.xml")
					Dim rptSales As rptSales1 = New rptSales1()
					rptSales.SetDataSource(ModCommonClasses.ds)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(1))
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(2))
					Else
						Me.a = 0D
						Me.b = 0D
						Me.c = 0D
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text3 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
					If flag4 Then
						Me.d = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					Else
						Me.d = 0D
					End If
					ModCommonClasses.con.Close()
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p3", Me.a)
					rptSales.SetParameterValue("p4", Me.b)
					rptSales.SetParameterValue("p5", Me.c)
					rptSales.SetParameterValue("p6", Me.d)
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F0 RID: 45552 RVA: 0x0076A024 File Offset: 0x00768224
		Private Sub GelButton9_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag3 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and InvoiceInfo.TillID=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox2.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate between @d1 and @d2 and InvoiceInfo.TillID=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox2.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where CType=@dx and InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					End If
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1.xml")
					Dim rptSales As rptSales = New rptSales()
					rptSales.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSales.SetDataSource(ModCommonClasses.ds)
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("p8", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F1 RID: 45553 RVA: 0x0076A6D4 File Offset: 0x007688D4
		Private Sub GelButton8_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.TillID=@d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.TillID=@d3"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.TillID=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.TillID=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox2.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd1 = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					ModCommonClasses.adp1 = New SqlDataAdapter(ModCommonClasses.cmd1)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable1 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp1.Fill(ModCommonClasses.dtable1)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable1)
					ModCommonClasses.ds.WriteXmlSchema("Sales_XML.xml")
					Dim rptSales As rptSales1 = New rptSales1()
					rptSales.SetDataSource(ModCommonClasses.ds)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag5 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag5 Then
						Dim text3 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text4 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(1))
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(2))
					Else
						Me.a = 0D
						Me.b = 0D
						Me.c = 0D
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag7 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag7 Then
						Dim text5 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text5)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text6 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text6)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
					If flag8 Then
						Me.d = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					Else
						Me.d = 0D
					End If
					ModCommonClasses.con.Close()
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p3", Me.a)
					rptSales.SetParameterValue("p4", Me.b)
					rptSales.SetParameterValue("p5", Me.c)
					rptSales.SetParameterValue("p6", Me.d)
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F2 RID: 45554 RVA: 0x0076B0FC File Offset: 0x007692FC
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag3 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and InvoiceInfo.Operator=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox3.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate between @d1 and @d2 and InvoiceInfo.Operator=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox3.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where CType=@dx and InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					End If
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1.xml")
					Dim rptSales As rptSales = New rptSales()
					rptSales.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSales.SetDataSource(ModCommonClasses.ds)
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("p8", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F3 RID: 45555 RVA: 0x0076B7AC File Offset: 0x007699AC
		Private Sub GelButton10_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.Operator=@d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text)
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.CType=@dx and InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.Operator=@d3"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text)
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.Operator=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.Operator=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox3.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd1 = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					ModCommonClasses.adp1 = New SqlDataAdapter(ModCommonClasses.cmd1)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable1 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp1.Fill(ModCommonClasses.dtable1)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable1)
					ModCommonClasses.ds.WriteXmlSchema("Sales_XML.xml")
					Dim rptSales As rptSales1 = New rptSales1()
					rptSales.SetDataSource(ModCommonClasses.ds)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag5 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag5 Then
						Dim text3 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text4 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(1))
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(2))
					Else
						Me.a = 0D
						Me.b = 0D
						Me.c = 0D
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag7 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag7 Then
						Dim text5 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text5)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text6 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text6)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
					If flag8 Then
						Me.d = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					Else
						Me.d = 0D
					End If
					ModCommonClasses.con.Close()
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p3", Me.a)
					rptSales.SetParameterValue("p4", Me.b)
					rptSales.SetParameterValue("p5", Me.c)
					rptSales.SetParameterValue("p6", Me.d)
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F4 RID: 45556 RVA: 0x0076C1D4 File Offset: 0x0076A3D4
		Private Sub GelButton13_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag3 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 and InvoiceInfo.TaxType=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox4.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate between @d1 and @d2 and InvoiceInfo.TaxType=@d33 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.AddWithValue("@d33", Me.ComboBox4.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where CType=@dx and InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					End If
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1.xml")
					Dim rptSales As rptSales = New rptSales()
					rptSales.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSales.SetDataSource(ModCommonClasses.ds)
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("p8", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F5 RID: 45557 RVA: 0x0076C884 File Offset: 0x0076AA84
		Private Sub GelButton12_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				If flag Then
					Dim text As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.TaxType=@d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox4.Text)
				Else
					Dim text2 As String = "select InvoiceNo from InvoiceInfo LEFT Join Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.CType=@dx and InvoiceInfo.InvoiceDate between @d1 and @d2 and InvoiceInfo.TaxType=@d3"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox4.Text)
					ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.TaxType=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox4.Text)
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.TaxType, InvoiceInfo.Customer_ID, InvoiceInfo.SalesmanID, InvoiceInfo.SubTotal, InvoiceInfo.CGST, InvoiceInfo.SGST,InvoiceInfo.IGST, InvoiceInfo.CESS, InvoiceInfo.GrandTotal, InvoiceInfo.TotalPaid, InvoiceInfo.Balance, InvoiceInfo.Remarks, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID,Invoice_Product.Barcode, (((Invoice_Product.TaxableAmt)+(Invoice_Product.Discount)) / (Invoice_Product.Qty)) as SalesRate, Invoice_Product.Qty, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.CGSTPer, Invoice_Product.CGSTAmt,Invoice_Product.SGSTPer, Invoice_Product.SGSTAmt, Invoice_Product.IGSTPer, Invoice_Product.IGSTAmt, Invoice_Product.CESSPer, Invoice_Product.CESSAmt, Invoice_Product.TotalAmount,Invoice_Product.PurchaseRate, Invoice_Product.Margin, Product.PID, Product.ProductCode, Product.ProductName, Product.SubCategoryID, Product.HSNCode, InvoiceInfo.OtherCharges as Description,InvoiceInfo.FreightCharges as Expr5,Product.CostPrice, Product.SellingPrice, Product.Discount AS Expr1, Product.CGST AS Expr2, Product.SGST AS Expr3, Product.CESS AS Expr4, Product.ReorderPoint,Product.OpeningStock, Product.PurchaseUnit, Product.SalesUnit, Customer.ID, Customer.CustomerID, Customer.Name, Customer.Address, Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo,Customer.EmailID, InvoiceInfo.RoundOff AS Expr6, Customer.AccountNumber, Customer.AccountName, Customer.Bank, Customer.Branch, Customer.IFSCCode, Customer.GSTIN, Customer.PAN, Customer.CIN FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate >=@d1 and InvoiceDate < @d2 and InvoiceInfo.TaxType=@d3 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.ComboBox4.Text)
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd1 = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					ModCommonClasses.adp1 = New SqlDataAdapter(ModCommonClasses.cmd1)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable1 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp1.Fill(ModCommonClasses.dtable1)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable1)
					ModCommonClasses.ds.WriteXmlSchema("Sales_XML.xml")
					Dim rptSales As rptSales1 = New rptSales1()
					rptSales.SetDataSource(ModCommonClasses.ds)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag5 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag5 Then
						Dim text3 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text4 As String = "select ISNULL(sum(GrandTotal),0),ISNULL(sum(TotalPaid),0),ISNULL(sum(Balance),0) from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
					If flag6 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(1))
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(2))
					Else
						Me.a = 0D
						Me.b = 0D
						Me.c = 0D
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag7 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag7 Then
						Dim text5 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text5)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim text6 As String = "select ISNULL(sum(Margin),0) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and CType=@dx and InvoiceDate between @d1 and @d2"
						ModCommonClasses.cmd = New SqlCommand(text6)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
					If flag8 Then
						Me.d = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					Else
						Me.d = 0D
					End If
					ModCommonClasses.con.Close()
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p3", Me.a)
					rptSales.SetParameterValue("p4", Me.b)
					rptSales.SetParameterValue("p5", Me.c)
					rptSales.SetParameterValue("p6", Me.d)
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F6 RID: 45558 RVA: 0x0076D2AC File Offset: 0x0076B4AC
		Private Sub GelButton14_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select InvoiceNo from InvoiceInfoD where InvoiceDate between @d1 and @d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfoD INNER JOIN Customer ON InvoiceInfoD.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfoD where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
					ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1D.xml")
					Dim rptSalesD As rptSalesD = New rptSalesD()
					rptSalesD.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSalesD.SetDataSource(ModCommonClasses.ds)
					rptSalesD.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSalesD.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSalesD.SetParameterValue("p7", DateAndTime.Today)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalesD
					MyProject.Forms.frmReport.ShowDialog()
					rptSalesD.Close()
					rptSalesD.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F7 RID: 45559 RVA: 0x0076D688 File Offset: 0x0076B888
		Private Sub GelButton15_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				Dim sqlCommand As SqlCommand
				If flag Then
					Dim text As String = "select * from InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2"
					sqlCommand = New SqlCommand(text)
					sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
					sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				Else
					Dim text2 As String = "select * from InvoiceInfo where CType=@dx and InvoiceDate >=@d1 and InvoiceDate < @d2"
					sqlCommand = New SqlCommand(text2)
					sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
					sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					sqlCommand.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				End If
				sqlCommand.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					Dim sqlCommand3 As SqlCommand
					If flag4 Then
						sqlCommand3 = New SqlCommand("SELECT Invoice_Payment.PaymentMode, SUM(Invoice_Payment.TotalPaid) AS Expr1 FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID where InvoiceDate >=@d11 and InvoiceDate < @d12  GROUP BY Invoice_Payment.PaymentMode ORDER BY Invoice_Payment.PaymentMode", ModCommonClasses.con)
						sqlCommand3.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand3.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						sqlCommand3 = New SqlCommand("SELECT Invoice_Payment.PaymentMode, SUM(Invoice_Payment.TotalPaid) AS Expr1 FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID where CType=@dx and InvoiceDate >=@d11 and InvoiceDate < @d12  GROUP BY Invoice_Payment.PaymentMode ORDER BY Invoice_Payment.PaymentMode", ModCommonClasses.con)
						sqlCommand3.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand3.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand3.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand3)
					ModCommonClasses.con.Close()
					Dim dataTable As DataTable = New DataTable()
					Dim dataTable2 As DataTable = New DataTable()
					sqlDataAdapter.Fill(dataTable)
					sqlDataAdapter2.Fill(dataTable2)
					Dim dataSet As DataSet = New DataSet()
					dataSet.Tables.Add(dataTable)
					dataSet.Tables.Add(dataTable2)
					dataSet.WriteXmlSchema("SalesReportAdavncednew.xml")
					Dim rptSaleDayBook As rptSaleDayBook = New rptSaleDayBook()
					rptSaleDayBook.SetDataSource(dataSet)
					rptSaleDayBook.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSaleDayBook.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSaleDayBook.SetParameterValue("pa", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSaleDayBook
					MyProject.Forms.frmReport.ShowDialog()
					rptSaleDayBook.Close()
					rptSaleDayBook.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1F8 RID: 45560 RVA: 0x00052A7D File Offset: 0x00050C7D
		Private Sub GelButton16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSaleReport_Multi_Payment.ShowDialog()
			MyProject.Forms.frmSaleReport_Multi_Payment.Dispose()
		End Sub

		' Token: 0x0600B1F9 RID: 45561 RVA: 0x0076DB9C File Offset: 0x0076BD9C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				Dim text As String
				If flag Then
					text = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
				Else
					text = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
				End If
				Dim sqlCommand As SqlCommand = New SqlCommand(text)
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
				sqlCommand.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				sqlCommand.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT * from Company", ModCommonClasses.con)
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand2)
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					Dim sqlCommand3 As SqlCommand
					If flag4 Then
						sqlCommand3 = New SqlCommand("SELECT Category.CategoryName, SubCategory.SubCategoryName, SUM(Invoice_Product.TotalAmount) AS TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where InvoiceDate >=@d3 and InvoiceDate < @d4 GROUP BY Category.CategoryName, SubCategory.SubCategoryName ORDER BY Category.CategoryName", ModCommonClasses.con)
						sqlCommand3.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand3.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						sqlCommand3 = New SqlCommand("SELECT Category.CategoryName, SubCategory.SubCategoryName, SUM(Invoice_Product.TotalAmount) AS TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where CType=@dx and InvoiceDate >=@d3 and InvoiceDate < @d4 GROUP BY Category.CategoryName, SubCategory.SubCategoryName ORDER BY Category.CategoryName", ModCommonClasses.con)
						sqlCommand3.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand3.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand3.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand3)
					Dim flag5 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					Dim sqlDataAdapter3 As SqlDataAdapter
					Dim sqlDataAdapter4 As SqlDataAdapter
					Dim sqlDataAdapter5 As SqlDataAdapter
					If flag5 Then
						Dim sqlCommand4 As SqlCommand = New SqlCommand("SELECT Category.CategoryName, SubCategory.SubCategoryName, SUM(Invoice_Product.Qty) AS TotalQty FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where InvoiceDate >=@d5 and InvoiceDate < @d6 GROUP BY Category.CategoryName, SubCategory.SubCategoryName ORDER BY Category.CategoryName", ModCommonClasses.con)
						sqlCommand4.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand4.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlDataAdapter3 = New SqlDataAdapter(sqlCommand4)
						Dim sqlCommand5 As SqlCommand = New SqlCommand("SELECT Product.HSNCode, Product.ProductName, SUM(Invoice_Product.Qty) AS Expr1, SUM(Invoice_Product.TotalAmount) AS Expr2 FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceDate >=@d7 and InvoiceDate < @d8 GROUP BY Product.HSNCode, Product.ProductName ORDER BY Product.HSNCode", ModCommonClasses.con)
						sqlCommand5.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand5.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlDataAdapter4 = New SqlDataAdapter(sqlCommand5)
						Dim sqlCommand6 As SqlCommand = New SqlCommand("SELECT Invoice_Payment.PaymentMode, SUM(Invoice_Payment.TotalPaid) AS Expr1 FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID where InvoiceDate >=@d11 and InvoiceDate < @d12  GROUP BY Invoice_Payment.PaymentMode ORDER BY Invoice_Payment.PaymentMode", ModCommonClasses.con)
						sqlCommand6.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand6.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlDataAdapter5 = New SqlDataAdapter(sqlCommand6)
					Else
						Dim sqlCommand4 As SqlCommand = New SqlCommand("SELECT Category.CategoryName, SubCategory.SubCategoryName, SUM(Invoice_Product.Qty) AS TotalQty FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN SubCategory ON Product.SubCategoryID = SubCategory.ID INNER JOIN Category ON SubCategory.Category = Category.CategoryName where CType=@dx and InvoiceDate >=@d5 and InvoiceDate < @d6 GROUP BY Category.CategoryName, SubCategory.SubCategoryName ORDER BY Category.CategoryName", ModCommonClasses.con)
						sqlCommand4.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand4.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand4.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						sqlDataAdapter3 = New SqlDataAdapter(sqlCommand4)
						Dim sqlCommand5 As SqlCommand = New SqlCommand("SELECT Product.HSNCode, Product.ProductName, SUM(Invoice_Product.Qty) AS Expr1, SUM(Invoice_Product.TotalAmount) AS Expr2 FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where CType=@dx and InvoiceDate >=@d7 and InvoiceDate < @d8 GROUP BY Product.HSNCode, Product.ProductName ORDER BY Product.HSNCode", ModCommonClasses.con)
						sqlCommand5.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand5.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand5.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						sqlDataAdapter4 = New SqlDataAdapter(sqlCommand5)
						Dim sqlCommand6 As SqlCommand = New SqlCommand("SELECT Invoice_Payment.PaymentMode, SUM(Invoice_Payment.TotalPaid) AS Expr1 FROM InvoiceInfo INNER JOIN Invoice_Payment ON InvoiceInfo.Inv_ID = Invoice_Payment.InvoiceID where CType=@dx and InvoiceDate >=@d11 and InvoiceDate < @d12  GROUP BY Invoice_Payment.PaymentMode ORDER BY Invoice_Payment.PaymentMode", ModCommonClasses.con)
						sqlCommand6.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand6.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand6.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
						sqlDataAdapter5 = New SqlDataAdapter(sqlCommand6)
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag6 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag6 Then
						Dim text2 As String = "select IsNull(Sum(FreightCharges),0) from InvoiceInfo where InvoiceDate >=@d9 and InvoiceDate < @d10"
						sqlCommand2 = New SqlCommand(text2)
						sqlCommand2.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						Dim text2 As String = "select IsNull(Sum(FreightCharges),0) from InvoiceInfo where CType=@dy and InvoiceDate >=@d9 and InvoiceDate < @d10"
						sqlCommand2 = New SqlCommand(text2)
						sqlCommand2.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand2.Parameters.Add("@dy", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					sqlCommand2.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = sqlCommand2.ExecuteReader()
					Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
					If flag7 Then
						Me.a = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag8 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag8 Then
						Dim text3 As String = "select IsNull(Sum(OtherCharges),0) from InvoiceInfo where InvoiceDate >=@d11 and InvoiceDate < @d12"
						sqlCommand2 = New SqlCommand(text3)
						sqlCommand2.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						Dim text4 As String = "select IsNull(Sum(OtherCharges),0) from InvoiceInfo where CType=@dy and InvoiceDate >=@d11 and InvoiceDate < @d12"
						sqlCommand2 = New SqlCommand(text4)
						sqlCommand2.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand2.Parameters.Add("@dy", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					sqlCommand2.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = sqlCommand2.ExecuteReader()
					Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
					If flag9 Then
						Me.b = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag10 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag10 Then
						Dim text5 As String = "SELECT IsNull(Sum(RoundOff),0) from InvoiceInfo where InvoiceDate >=@d13 and InvoiceDate < @d14"
						sqlCommand2 = New SqlCommand(text5)
						sqlCommand2.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					Else
						Dim text6 As String = "SELECT IsNull(Sum(RoundOff),0) from InvoiceInfo where CType=@dy and InvoiceDate >=@d13 and InvoiceDate < @d14"
						sqlCommand2 = New SqlCommand(text6)
						sqlCommand2.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
						sqlCommand2.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						sqlCommand2.Parameters.Add("@dy", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					sqlCommand2.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = sqlCommand2.ExecuteReader()
					Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
					If flag11 Then
						Me.c = Conversions.ToDecimal(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con.Close()
					Dim dataTable As DataTable = New DataTable()
					Dim dataTable2 As DataTable = New DataTable()
					Dim dataTable3 As DataTable = New DataTable()
					Dim dataTable4 As DataTable = New DataTable()
					Dim dataTable5 As DataTable = New DataTable()
					sqlDataAdapter.Fill(dataTable)
					sqlDataAdapter2.Fill(dataTable2)
					sqlDataAdapter3.Fill(dataTable3)
					sqlDataAdapter4.Fill(dataTable4)
					sqlDataAdapter5.Fill(dataTable5)
					Dim dataSet As DataSet = New DataSet()
					dataSet.Tables.Add(dataTable)
					dataSet.Tables.Add(dataTable2)
					dataSet.Tables.Add(dataTable3)
					dataSet.Tables.Add(dataTable4)
					dataSet.Tables.Add(dataTable5)
					dataSet.WriteXmlSchema("SalesReportAdavnced.xml")
					Dim rptOverallSales As rptOverallSales = New rptOverallSales()
					rptOverallSales.Subreports(0).SetDataSource(dataSet)
					rptOverallSales.Subreports(1).SetDataSource(dataSet)
					rptOverallSales.Subreports(2).SetDataSource(dataSet)
					rptOverallSales.Subreports(3).SetDataSource(dataSet)
					rptOverallSales.SetDataSource(dataSet)
					rptOverallSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptOverallSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptOverallSales.SetParameterValue("pa", Me.cbox_saletype.Text)
					rptOverallSales.SetParameterValue("p3", Me.a)
					rptOverallSales.SetParameterValue("p4", Me.b)
					rptOverallSales.SetParameterValue("p5", Me.a)
					rptOverallSales.SetParameterValue("p6", Me.b)
					rptOverallSales.SetParameterValue("pf1", Me.c)
					rptOverallSales.SetParameterValue("pf2", Me.c)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptOverallSales
					MyProject.Forms.frmReport.ShowDialog()
					rptOverallSales.Close()
					rptOverallSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1FA RID: 45562 RVA: 0x0076EAF4 File Offset: 0x0076CCF4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
				Dim text As String
				If flag Then
					text = "select InvoiceNo from InvoiceInfo where InvoiceDate between @d1 and @d2"
				Else
					text = "select InvoiceNo from InvoiceInfo where CType=@dx and InvoiceDate between @d1 and @d2"
				End If
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag3 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						ModCommonClasses.cmd = New SqlCommand("SELECT * FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where CType=@dx and InvoiceDate between @d1 and @d2 order by InvoiceDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@dx", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					Dim flag4 As Boolean = Operators.CompareString(Me.cbox_saletype.Text, "All", False) = 0
					If flag4 Then
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						ModCommonClasses.cmd2 = New SqlCommand("SELECT CONVERT(varchar(10),YEAR(InvoiceDate)) AS Year, SUM(GrandTotal) AS GrandTotal FROM InvoiceInfo where CType=@dy and InvoiceDate between @d3 and @d4 GROUP BY YEAR(InvoiceDate) ORDER BY Year", ModCommonClasses.con)
						ModCommonClasses.cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						ModCommonClasses.cmd2.Parameters.Add("@dy", SqlDbType.VarChar).Value = Me.cbox_saletype.Text
					End If
					ModCommonClasses.adp2 = New SqlDataAdapter(ModCommonClasses.cmd2)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.dtable2 = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.adp2.Fill(ModCommonClasses.dtable2)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable2)
					ModCommonClasses.ds.WriteXmlSchema("SalesX1.xml")
					Dim rptSales As rptSales = New rptSales()
					rptSales.Subreports(0).SetDataSource(ModCommonClasses.ds)
					rptSales.SetDataSource(ModCommonClasses.ds)
					rptSales.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSales.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					rptSales.SetParameterValue("p7", DateAndTime.Today)
					rptSales.SetParameterValue("p8", Me.cbox_saletype.Text)
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSales
					MyProject.Forms.frmReport.ShowDialog()
					rptSales.Close()
					rptSales.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B1FB RID: 45563 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04004A6C RID: 19052
		Private a As Decimal

		' Token: 0x04004A6D RID: 19053
		Private b As Decimal

		' Token: 0x04004A6E RID: 19054
		Private c As Decimal

		' Token: 0x04004A6F RID: 19055
		Private d As Decimal
	End Class
End Namespace
