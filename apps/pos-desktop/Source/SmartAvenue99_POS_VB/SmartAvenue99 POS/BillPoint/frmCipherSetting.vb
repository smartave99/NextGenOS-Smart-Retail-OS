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
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004AF RID: 1199
	<DesignerGenerated()>
	Public Partial Class frmCipherSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F053 RID: 61523 RVA: 0x0006931B File Offset: 0x0006751B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCipherSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCipherSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005C1F RID: 23583
		' (get) Token: 0x0600F056 RID: 61526 RVA: 0x0006934D File Offset: 0x0006754D
		' (set) Token: 0x0600F057 RID: 61527 RVA: 0x00069357 File Offset: 0x00067557
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005C20 RID: 23584
		' (get) Token: 0x0600F058 RID: 61528 RVA: 0x00069360 File Offset: 0x00067560
		' (set) Token: 0x0600F059 RID: 61529 RVA: 0x0006936A File Offset: 0x0006756A
		Friend Overridable Property TableLayoutPanel1 As TableLayoutPanel

		' Token: 0x17005C21 RID: 23585
		' (get) Token: 0x0600F05A RID: 61530 RVA: 0x00069373 File Offset: 0x00067573
		' (set) Token: 0x0600F05B RID: 61531 RVA: 0x00909108 File Offset: 0x00907308
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
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
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

		' Token: 0x17005C22 RID: 23586
		' (get) Token: 0x0600F05C RID: 61532 RVA: 0x0006937D File Offset: 0x0006757D
		' (set) Token: 0x0600F05D RID: 61533 RVA: 0x00069387 File Offset: 0x00067587
		Friend Overridable Property Label3 As Label

		' Token: 0x17005C23 RID: 23587
		' (get) Token: 0x0600F05E RID: 61534 RVA: 0x00069390 File Offset: 0x00067590
		' (set) Token: 0x0600F05F RID: 61535 RVA: 0x0006939A File Offset: 0x0006759A
		Friend Overridable Property Label2 As Label

		' Token: 0x17005C24 RID: 23588
		' (get) Token: 0x0600F060 RID: 61536 RVA: 0x000693A3 File Offset: 0x000675A3
		' (set) Token: 0x0600F061 RID: 61537 RVA: 0x00909168 File Offset: 0x00907368
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
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
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

		' Token: 0x17005C25 RID: 23589
		' (get) Token: 0x0600F062 RID: 61538 RVA: 0x000693AD File Offset: 0x000675AD
		' (set) Token: 0x0600F063 RID: 61539 RVA: 0x009091C8 File Offset: 0x009073C8
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox3_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C26 RID: 23590
		' (get) Token: 0x0600F064 RID: 61540 RVA: 0x000693B7 File Offset: 0x000675B7
		' (set) Token: 0x0600F065 RID: 61541 RVA: 0x00909228 File Offset: 0x00907428
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox4_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C27 RID: 23591
		' (get) Token: 0x0600F066 RID: 61542 RVA: 0x000693C1 File Offset: 0x000675C1
		' (set) Token: 0x0600F067 RID: 61543 RVA: 0x00909288 File Offset: 0x00907488
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C28 RID: 23592
		' (get) Token: 0x0600F068 RID: 61544 RVA: 0x000693CB File Offset: 0x000675CB
		' (set) Token: 0x0600F069 RID: 61545 RVA: 0x009092E8 File Offset: 0x009074E8
		Private _TextBox6 As TextBox
		Friend Overridable Property TextBox6 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox6_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C29 RID: 23593
		' (get) Token: 0x0600F06A RID: 61546 RVA: 0x000693D5 File Offset: 0x000675D5
		' (set) Token: 0x0600F06B RID: 61547 RVA: 0x00909348 File Offset: 0x00907548
		Private _TextBox7 As TextBox
		Friend Overridable Property TextBox7 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox7_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C2A RID: 23594
		' (get) Token: 0x0600F06C RID: 61548 RVA: 0x000693DF File Offset: 0x000675DF
		' (set) Token: 0x0600F06D RID: 61549 RVA: 0x009093A8 File Offset: 0x009075A8
		Private _TextBox8 As TextBox
		Friend Overridable Property TextBox8 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox8_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox8
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox8 = value
				textBox = Me._TextBox8
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C2B RID: 23595
		' (get) Token: 0x0600F06E RID: 61550 RVA: 0x000693E9 File Offset: 0x000675E9
		' (set) Token: 0x0600F06F RID: 61551 RVA: 0x00909408 File Offset: 0x00907608
		Private _TextBox9 As TextBox
		Friend Overridable Property TextBox9 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox9_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C2C RID: 23596
		' (get) Token: 0x0600F070 RID: 61552 RVA: 0x000693F3 File Offset: 0x000675F3
		' (set) Token: 0x0600F071 RID: 61553 RVA: 0x00909468 File Offset: 0x00907668
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox10_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.All_Codes
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C2D RID: 23597
		' (get) Token: 0x0600F072 RID: 61554 RVA: 0x000693FD File Offset: 0x000675FD
		' (set) Token: 0x0600F073 RID: 61555 RVA: 0x00069407 File Offset: 0x00067607
		Friend Overridable Property Label1 As Label

		' Token: 0x17005C2E RID: 23598
		' (get) Token: 0x0600F074 RID: 61556 RVA: 0x00069410 File Offset: 0x00067610
		' (set) Token: 0x0600F075 RID: 61557 RVA: 0x0006941A File Offset: 0x0006761A
		Friend Overridable Property Label13 As Label

		' Token: 0x17005C2F RID: 23599
		' (get) Token: 0x0600F076 RID: 61558 RVA: 0x00069423 File Offset: 0x00067623
		' (set) Token: 0x0600F077 RID: 61559 RVA: 0x0006942D File Offset: 0x0006762D
		Friend Overridable Property Label12 As Label

		' Token: 0x17005C30 RID: 23600
		' (get) Token: 0x0600F078 RID: 61560 RVA: 0x00069436 File Offset: 0x00067636
		' (set) Token: 0x0600F079 RID: 61561 RVA: 0x00069440 File Offset: 0x00067640
		Friend Overridable Property Label11 As Label

		' Token: 0x17005C31 RID: 23601
		' (get) Token: 0x0600F07A RID: 61562 RVA: 0x00069449 File Offset: 0x00067649
		' (set) Token: 0x0600F07B RID: 61563 RVA: 0x00069453 File Offset: 0x00067653
		Friend Overridable Property Label10 As Label

		' Token: 0x17005C32 RID: 23602
		' (get) Token: 0x0600F07C RID: 61564 RVA: 0x0006945C File Offset: 0x0006765C
		' (set) Token: 0x0600F07D RID: 61565 RVA: 0x00069466 File Offset: 0x00067666
		Friend Overridable Property Label9 As Label

		' Token: 0x17005C33 RID: 23603
		' (get) Token: 0x0600F07E RID: 61566 RVA: 0x0006946F File Offset: 0x0006766F
		' (set) Token: 0x0600F07F RID: 61567 RVA: 0x00069479 File Offset: 0x00067679
		Friend Overridable Property Label8 As Label

		' Token: 0x17005C34 RID: 23604
		' (get) Token: 0x0600F080 RID: 61568 RVA: 0x00069482 File Offset: 0x00067682
		' (set) Token: 0x0600F081 RID: 61569 RVA: 0x0006948C File Offset: 0x0006768C
		Friend Overridable Property Label7 As Label

		' Token: 0x17005C35 RID: 23605
		' (get) Token: 0x0600F082 RID: 61570 RVA: 0x00069495 File Offset: 0x00067695
		' (set) Token: 0x0600F083 RID: 61571 RVA: 0x0006949F File Offset: 0x0006769F
		Friend Overridable Property Label6 As Label

		' Token: 0x17005C36 RID: 23606
		' (get) Token: 0x0600F084 RID: 61572 RVA: 0x000694A8 File Offset: 0x000676A8
		' (set) Token: 0x0600F085 RID: 61573 RVA: 0x000694B2 File Offset: 0x000676B2
		Friend Overridable Property Label5 As Label

		' Token: 0x17005C37 RID: 23607
		' (get) Token: 0x0600F086 RID: 61574 RVA: 0x000694BB File Offset: 0x000676BB
		' (set) Token: 0x0600F087 RID: 61575 RVA: 0x000694C5 File Offset: 0x000676C5
		Friend Overridable Property Label4 As Label

		' Token: 0x17005C38 RID: 23608
		' (get) Token: 0x0600F088 RID: 61576 RVA: 0x000694CE File Offset: 0x000676CE
		' (set) Token: 0x0600F089 RID: 61577 RVA: 0x009094C8 File Offset: 0x009076C8
		Private _TextBox12 As TextBox
		Friend Overridable Property TextBox12 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox12_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox12_KeyPress
				Dim textBox As TextBox = Me._TextBox12
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox12 = value
				textBox = Me._TextBox12
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C39 RID: 23609
		' (get) Token: 0x0600F08A RID: 61578 RVA: 0x000694D8 File Offset: 0x000676D8
		' (set) Token: 0x0600F08B RID: 61579 RVA: 0x00909528 File Offset: 0x00907728
		Private _TextBox11 As TextBox
		Friend Overridable Property TextBox11 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox11_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox11_KeyPress
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C3A RID: 23610
		' (get) Token: 0x0600F08C RID: 61580 RVA: 0x000694E2 File Offset: 0x000676E2
		' (set) Token: 0x0600F08D RID: 61581 RVA: 0x000694EC File Offset: 0x000676EC
		Friend Overridable Property Label15 As Label

		' Token: 0x17005C3B RID: 23611
		' (get) Token: 0x0600F08E RID: 61582 RVA: 0x000694F5 File Offset: 0x000676F5
		' (set) Token: 0x0600F08F RID: 61583 RVA: 0x000694FF File Offset: 0x000676FF
		Friend Overridable Property Label14 As Label

		' Token: 0x17005C3C RID: 23612
		' (get) Token: 0x0600F090 RID: 61584 RVA: 0x00069508 File Offset: 0x00067708
		' (set) Token: 0x0600F091 RID: 61585 RVA: 0x00069512 File Offset: 0x00067712
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005C3D RID: 23613
		' (get) Token: 0x0600F092 RID: 61586 RVA: 0x0006951B File Offset: 0x0006771B
		' (set) Token: 0x0600F093 RID: 61587 RVA: 0x00069525 File Offset: 0x00067725
		Friend Overridable Property txtID As TextBox

		' Token: 0x17005C3E RID: 23614
		' (get) Token: 0x0600F094 RID: 61588 RVA: 0x0006952E File Offset: 0x0006772E
		' (set) Token: 0x0600F095 RID: 61589 RVA: 0x00069538 File Offset: 0x00067738
		Friend Overridable Property TableLayoutPanel2 As TableLayoutPanel

		' Token: 0x17005C3F RID: 23615
		' (get) Token: 0x0600F096 RID: 61590 RVA: 0x00069541 File Offset: 0x00067741
		' (set) Token: 0x0600F097 RID: 61591 RVA: 0x0006954B File Offset: 0x0006774B
		Friend Overridable Property Label16 As Label

		' Token: 0x17005C40 RID: 23616
		' (get) Token: 0x0600F098 RID: 61592 RVA: 0x00069554 File Offset: 0x00067754
		' (set) Token: 0x0600F099 RID: 61593 RVA: 0x00909588 File Offset: 0x00907788
		Private _TextBox13 As TextBox
		Friend Overridable Property TextBox13 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox13_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox13_KeyPress
				Dim textBox As TextBox = Me._TextBox13
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox13 = value
				textBox = Me._TextBox13
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C41 RID: 23617
		' (get) Token: 0x0600F09A RID: 61594 RVA: 0x0006955E File Offset: 0x0006775E
		' (set) Token: 0x0600F09B RID: 61595 RVA: 0x009095E8 File Offset: 0x009077E8
		Private _TextBox14 As TextBox
		Friend Overridable Property TextBox14 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox14_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox14_KeyPress
				Dim textBox As TextBox = Me._TextBox14
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._TextBox14 = value
				textBox = Me._TextBox14
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C42 RID: 23618
		' (get) Token: 0x0600F09C RID: 61596 RVA: 0x00069568 File Offset: 0x00067768
		' (set) Token: 0x0600F09D RID: 61597 RVA: 0x00069572 File Offset: 0x00067772
		Friend Overridable Property TableLayoutPanel3 As TableLayoutPanel

		' Token: 0x17005C43 RID: 23619
		' (get) Token: 0x0600F09E RID: 61598 RVA: 0x0006957B File Offset: 0x0006777B
		' (set) Token: 0x0600F09F RID: 61599 RVA: 0x00069585 File Offset: 0x00067785
		Friend Overridable Property Label19 As Label

		' Token: 0x17005C44 RID: 23620
		' (get) Token: 0x0600F0A0 RID: 61600 RVA: 0x0006958E File Offset: 0x0006778E
		' (set) Token: 0x0600F0A1 RID: 61601 RVA: 0x00069598 File Offset: 0x00067798
		Friend Overridable Property Label18 As Label

		' Token: 0x17005C45 RID: 23621
		' (get) Token: 0x0600F0A2 RID: 61602 RVA: 0x000695A1 File Offset: 0x000677A1
		' (set) Token: 0x0600F0A3 RID: 61603 RVA: 0x000695AB File Offset: 0x000677AB
		Friend Overridable Property Label17 As Label

		' Token: 0x17005C46 RID: 23622
		' (get) Token: 0x0600F0A4 RID: 61604 RVA: 0x000695B4 File Offset: 0x000677B4
		' (set) Token: 0x0600F0A5 RID: 61605 RVA: 0x00909648 File Offset: 0x00907848
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.ComboBox1_KeyDown
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C47 RID: 23623
		' (get) Token: 0x0600F0A6 RID: 61606 RVA: 0x000695BE File Offset: 0x000677BE
		' (set) Token: 0x0600F0A7 RID: 61607 RVA: 0x0090968C File Offset: 0x0090788C
		Private _CheckBox1 As CheckBox
		Friend Overridable Property CheckBox1 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox1_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox1 = value
				checkBox = Me._CheckBox1
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005C48 RID: 23624
		' (get) Token: 0x0600F0A8 RID: 61608 RVA: 0x000695C8 File Offset: 0x000677C8
		' (set) Token: 0x0600F0A9 RID: 61609 RVA: 0x009096D0 File Offset: 0x009078D0
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

		' Token: 0x17005C49 RID: 23625
		' (get) Token: 0x0600F0AA RID: 61610 RVA: 0x000695D2 File Offset: 0x000677D2
		' (set) Token: 0x0600F0AB RID: 61611 RVA: 0x00909714 File Offset: 0x00907914
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

		' Token: 0x0600F0AC RID: 61612 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0AD RID: 61613 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0AE RID: 61614 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0AF RID: 61615 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B0 RID: 61616 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B1 RID: 61617 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox6_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B2 RID: 61618 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B3 RID: 61619 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B4 RID: 61620 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B5 RID: 61621 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B6 RID: 61622 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B7 RID: 61623 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B8 RID: 61624 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox13_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0B9 RID: 61625 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0BA RID: 61626 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F0BB RID: 61627 RVA: 0x00909758 File Offset: 0x00907958
		Private Sub clear()
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
			Me.TextBox11.Text = ""
			Me.TextBox12.Text = ""
			Me.TextBox13.Text = ""
			Me.TextBox14.Text = ""
			Me.ComboBox1.SelectedIndex = 0
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600F0BC RID: 61628 RVA: 0x00909870 File Offset: 0x00907A70
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(c0), RTRIM(c1), RTRIM(c2),RTRIM(c3), RTRIM(c4), RTRIM(c5), RTRIM(c6), RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c10),RTRIM(c11),RTRIM(c12),RTRIM(c13),RTRIM(c14) from CipherCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtID.Text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.TextBox4.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.TextBox5.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.TextBox6.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.TextBox7.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.TextBox8.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.TextBox9.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.TextBox10.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.TextBox11.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.TextBox12.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox13.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.TextBox14.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.ComboBox1.Text = ModCommonClasses.rdr.GetValue(15).ToString()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F0BD RID: 61629 RVA: 0x00909AEC File Offset: 0x00907CEC
		Private Sub frmCipherSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.CheckBox1.Text = "Char Code Activate"
				Me.CheckBox1.ForeColor = Color.Red
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Me.CheckBox1.Text = "Num Code Activate"
					Me.CheckBox1.ForeColor = Color.Blue
				End If
			End If
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F0BE RID: 61630 RVA: 0x00909B74 File Offset: 0x00907D74
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

		' Token: 0x0600F0BF RID: 61631 RVA: 0x00909CEC File Offset: 0x00907EEC
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

		' Token: 0x0600F0C0 RID: 61632 RVA: 0x00909DA8 File Offset: 0x00907FA8
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

		' Token: 0x0600F0C1 RID: 61633 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F0C2 RID: 61634 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F0C3 RID: 61635 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F0C4 RID: 61636 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F0C5 RID: 61637 RVA: 0x000D5998 File Offset: 0x000D3B98
		Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F0C6 RID: 61638 RVA: 0x00909E74 File Offset: 0x00908074
		Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F0C7 RID: 61639 RVA: 0x00909E74 File Offset: 0x00908074
		Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0600F0C8 RID: 61640 RVA: 0x00909ECC File Offset: 0x009080CC
		Private Sub All_Codes(sender As Object, e As KeyPressEventArgs)
			Me.TextBox1.MaxLength = 1
			Me.TextBox2.MaxLength = 1
			Me.TextBox3.MaxLength = 1
			Me.TextBox4.MaxLength = 1
			Me.TextBox5.MaxLength = 1
			Me.TextBox6.MaxLength = 1
			Me.TextBox7.MaxLength = 1
			Me.TextBox8.MaxLength = 1
			Me.TextBox9.MaxLength = 1
			Me.TextBox10.MaxLength = 1
			Dim flag As Boolean = Not Me.CheckBox1.Checked
			If flag Then
				Dim flag2 As Boolean = Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
				If flag2 Then
					e.Handled = True
				End If
			Else
				Dim checked As Boolean = Me.CheckBox1.Checked
				If checked Then
					Dim flag3 As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso e.KeyChar <> vbBack
					If flag3 Then
						e.Handled = True
					End If
				End If
			End If
		End Sub

		' Token: 0x0600F0C9 RID: 61641 RVA: 0x00909FE0 File Offset: 0x009081E0
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
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
			Me.TextBox1.Focus()
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.CheckBox1.Text = "Char Code Activate"
				Me.CheckBox1.ForeColor = Color.Red
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Me.CheckBox1.Text = "Num Code Activate"
					Me.CheckBox1.ForeColor = Color.Blue
				End If
			End If
		End Sub

		' Token: 0x0600F0CA RID: 61642 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCipherSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F0CB RID: 61643 RVA: 0x000695DC File Offset: 0x000677DC
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.clear()
		End Sub

		' Token: 0x0600F0CC RID: 61644 RVA: 0x0090A110 File Offset: 0x00908310
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update CipherCode set C0=@d0,c1=@d1,c2=@d2,c3=@d3,c4=@d4,c5=@d5,c6=@d6,c7=@d7,c8=@d8,c9=@d9,c10=@d10,c11=@d11,c12=@d12,c13=@d13,c14=@d14 where ID=@d123"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.TextBox1.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox2.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox3.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox4.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.TextBox5.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.TextBox6.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.TextBox7.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.TextBox8.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.TextBox9.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.TextBox10.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.TextBox11.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.TextBox12.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.TextBox13.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.TextBox14.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.ComboBox1.Text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d123", Me.txtID.Text.Trim())
				ModCommonClasses.cmd.ExecuteReader()
				MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.Getdata()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
