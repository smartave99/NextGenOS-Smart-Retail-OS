Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000126 RID: 294
	<DesignerGenerated()>
	Public Partial Class frmKeyBordProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x170013A8 RID: 5032
		' (get) Token: 0x0600327F RID: 12927 RVA: 0x0001F7B6 File Offset: 0x0001D9B6
		' (set) Token: 0x06003280 RID: 12928 RVA: 0x0001F7C0 File Offset: 0x0001D9C0
		Friend Overridable Property TableLayoutPanel6 As TableLayoutPanel

		' Token: 0x170013A9 RID: 5033
		' (get) Token: 0x06003281 RID: 12929 RVA: 0x0001F7C9 File Offset: 0x0001D9C9
		' (set) Token: 0x06003282 RID: 12930 RVA: 0x001F5518 File Offset: 0x001F3718
		Private _btnWallet As GelButton
		Friend Overridable Property btnWallet As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnWallet
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnWallet_Click
				Dim gelButton As GelButton = Me._btnWallet
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnWallet = value
				gelButton = Me._btnWallet
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013AA RID: 5034
		' (get) Token: 0x06003283 RID: 12931 RVA: 0x0001F7D3 File Offset: 0x0001D9D3
		' (set) Token: 0x06003284 RID: 12932 RVA: 0x001F555C File Offset: 0x001F375C
		Private _btnDebitCard As GelButton
		Friend Overridable Property btnDebitCard As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDebitCard
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDebitCard_Click
				Dim gelButton As GelButton = Me._btnDebitCard
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDebitCard = value
				gelButton = Me._btnDebitCard
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013AB RID: 5035
		' (get) Token: 0x06003285 RID: 12933 RVA: 0x0001F7DD File Offset: 0x0001D9DD
		' (set) Token: 0x06003286 RID: 12934 RVA: 0x001F55A0 File Offset: 0x001F37A0
		Private _btnCreditCard As GelButton
		Friend Overridable Property btnCreditCard As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCreditCard
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCreditCard_Click
				Dim gelButton As GelButton = Me._btnCreditCard
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCreditCard = value
				gelButton = Me._btnCreditCard
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013AC RID: 5036
		' (get) Token: 0x06003287 RID: 12935 RVA: 0x0001F7E7 File Offset: 0x0001D9E7
		' (set) Token: 0x06003288 RID: 12936 RVA: 0x001F55E4 File Offset: 0x001F37E4
		Private _btnCash As GelButton
		Friend Overridable Property btnCash As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnCash
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCash_Click
				Dim gelButton As GelButton = Me._btnCash
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnCash = value
				gelButton = Me._btnCash
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013AD RID: 5037
		' (get) Token: 0x06003289 RID: 12937 RVA: 0x0001F7F1 File Offset: 0x0001D9F1
		' (set) Token: 0x0600328A RID: 12938 RVA: 0x001F5628 File Offset: 0x001F3828
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

		' Token: 0x170013AE RID: 5038
		' (get) Token: 0x0600328B RID: 12939 RVA: 0x0001F7FB File Offset: 0x0001D9FB
		' (set) Token: 0x0600328C RID: 12940 RVA: 0x001F566C File Offset: 0x001F386C
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

		' Token: 0x170013AF RID: 5039
		' (get) Token: 0x0600328D RID: 12941 RVA: 0x0001F805 File Offset: 0x0001DA05
		' (set) Token: 0x0600328E RID: 12942 RVA: 0x001F56B0 File Offset: 0x001F38B0
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

		' Token: 0x170013B0 RID: 5040
		' (get) Token: 0x0600328F RID: 12943 RVA: 0x0001F80F File Offset: 0x0001DA0F
		' (set) Token: 0x06003290 RID: 12944 RVA: 0x001F56F4 File Offset: 0x001F38F4
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

		' Token: 0x170013B1 RID: 5041
		' (get) Token: 0x06003291 RID: 12945 RVA: 0x0001F819 File Offset: 0x0001DA19
		' (set) Token: 0x06003292 RID: 12946 RVA: 0x001F5738 File Offset: 0x001F3938
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

		' Token: 0x170013B2 RID: 5042
		' (get) Token: 0x06003293 RID: 12947 RVA: 0x0001F823 File Offset: 0x0001DA23
		' (set) Token: 0x06003294 RID: 12948 RVA: 0x001F577C File Offset: 0x001F397C
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

		' Token: 0x170013B3 RID: 5043
		' (get) Token: 0x06003295 RID: 12949 RVA: 0x0001F82D File Offset: 0x0001DA2D
		' (set) Token: 0x06003296 RID: 12950 RVA: 0x001F57C0 File Offset: 0x001F39C0
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

		' Token: 0x170013B4 RID: 5044
		' (get) Token: 0x06003297 RID: 12951 RVA: 0x0001F837 File Offset: 0x0001DA37
		' (set) Token: 0x06003298 RID: 12952 RVA: 0x001F5804 File Offset: 0x001F3A04
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

		' Token: 0x170013B5 RID: 5045
		' (get) Token: 0x06003299 RID: 12953 RVA: 0x0001F841 File Offset: 0x0001DA41
		' (set) Token: 0x0600329A RID: 12954 RVA: 0x001F5848 File Offset: 0x001F3A48
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

		' Token: 0x170013B6 RID: 5046
		' (get) Token: 0x0600329B RID: 12955 RVA: 0x0001F84B File Offset: 0x0001DA4B
		' (set) Token: 0x0600329C RID: 12956 RVA: 0x001F588C File Offset: 0x001F3A8C
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

		' Token: 0x170013B7 RID: 5047
		' (get) Token: 0x0600329D RID: 12957 RVA: 0x0001F855 File Offset: 0x0001DA55
		' (set) Token: 0x0600329E RID: 12958 RVA: 0x001F58D0 File Offset: 0x001F3AD0
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

		' Token: 0x170013B8 RID: 5048
		' (get) Token: 0x0600329F RID: 12959 RVA: 0x0001F85F File Offset: 0x0001DA5F
		' (set) Token: 0x060032A0 RID: 12960 RVA: 0x001F5914 File Offset: 0x001F3B14
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

		' Token: 0x170013B9 RID: 5049
		' (get) Token: 0x060032A1 RID: 12961 RVA: 0x0001F869 File Offset: 0x0001DA69
		' (set) Token: 0x060032A2 RID: 12962 RVA: 0x001F5958 File Offset: 0x001F3B58
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

		' Token: 0x170013BA RID: 5050
		' (get) Token: 0x060032A3 RID: 12963 RVA: 0x0001F873 File Offset: 0x0001DA73
		' (set) Token: 0x060032A4 RID: 12964 RVA: 0x001F599C File Offset: 0x001F3B9C
		Private _GelButton17 As GelButton
		Friend Overridable Property GelButton17 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton17_Click
				Dim gelButton As GelButton = Me._GelButton17
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton17 = value
				gelButton = Me._GelButton17
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013BB RID: 5051
		' (get) Token: 0x060032A5 RID: 12965 RVA: 0x0001F87D File Offset: 0x0001DA7D
		' (set) Token: 0x060032A6 RID: 12966 RVA: 0x001F59E0 File Offset: 0x001F3BE0
		Private _GelButton18 As GelButton
		Friend Overridable Property GelButton18 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton18_Click
				Dim gelButton As GelButton = Me._GelButton18
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton18 = value
				gelButton = Me._GelButton18
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013BC RID: 5052
		' (get) Token: 0x060032A7 RID: 12967 RVA: 0x0001F887 File Offset: 0x0001DA87
		' (set) Token: 0x060032A8 RID: 12968 RVA: 0x001F5A24 File Offset: 0x001F3C24
		Private _GelButton19 As GelButton
		Friend Overridable Property GelButton19 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton19_Click
				Dim gelButton As GelButton = Me._GelButton19
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton19 = value
				gelButton = Me._GelButton19
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013BD RID: 5053
		' (get) Token: 0x060032A9 RID: 12969 RVA: 0x0001F891 File Offset: 0x0001DA91
		' (set) Token: 0x060032AA RID: 12970 RVA: 0x001F5A68 File Offset: 0x001F3C68
		Private _GelButton20 As GelButton
		Friend Overridable Property GelButton20 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton20_Click
				Dim gelButton As GelButton = Me._GelButton20
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton20 = value
				gelButton = Me._GelButton20
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013BE RID: 5054
		' (get) Token: 0x060032AB RID: 12971 RVA: 0x0001F89B File Offset: 0x0001DA9B
		' (set) Token: 0x060032AC RID: 12972 RVA: 0x001F5AAC File Offset: 0x001F3CAC
		Private _GelButton21 As GelButton
		Friend Overridable Property GelButton21 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton21
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton21_Click
				Dim gelButton As GelButton = Me._GelButton21
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton21 = value
				gelButton = Me._GelButton21
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013BF RID: 5055
		' (get) Token: 0x060032AD RID: 12973 RVA: 0x0001F8A5 File Offset: 0x0001DAA5
		' (set) Token: 0x060032AE RID: 12974 RVA: 0x001F5AF0 File Offset: 0x001F3CF0
		Private _GelButton22 As GelButton
		Friend Overridable Property GelButton22 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton22_Click
				Dim gelButton As GelButton = Me._GelButton22
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton22 = value
				gelButton = Me._GelButton22
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C0 RID: 5056
		' (get) Token: 0x060032AF RID: 12975 RVA: 0x0001F8AF File Offset: 0x0001DAAF
		' (set) Token: 0x060032B0 RID: 12976 RVA: 0x001F5B34 File Offset: 0x001F3D34
		Private _GelButton23 As GelButton
		Friend Overridable Property GelButton23 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton23
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton23_Click
				Dim gelButton As GelButton = Me._GelButton23
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton23 = value
				gelButton = Me._GelButton23
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C1 RID: 5057
		' (get) Token: 0x060032B1 RID: 12977 RVA: 0x0001F8B9 File Offset: 0x0001DAB9
		' (set) Token: 0x060032B2 RID: 12978 RVA: 0x001F5B78 File Offset: 0x001F3D78
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

		' Token: 0x170013C2 RID: 5058
		' (get) Token: 0x060032B3 RID: 12979 RVA: 0x0001F8C3 File Offset: 0x0001DAC3
		' (set) Token: 0x060032B4 RID: 12980 RVA: 0x001F5BBC File Offset: 0x001F3DBC
		Private _GelButton26 As GelButton
		Friend Overridable Property GelButton26 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton26
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton26_Click
				Dim gelButton As GelButton = Me._GelButton26
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton26 = value
				gelButton = Me._GelButton26
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170013C3 RID: 5059
		' (get) Token: 0x060032B5 RID: 12981 RVA: 0x0001F8CD File Offset: 0x0001DACD
		' (set) Token: 0x060032B6 RID: 12982 RVA: 0x001F5C00 File Offset: 0x001F3E00
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

		' Token: 0x170013C4 RID: 5060
		' (get) Token: 0x060032B7 RID: 12983 RVA: 0x0001F8D7 File Offset: 0x0001DAD7
		' (set) Token: 0x060032B8 RID: 12984 RVA: 0x0001F8E1 File Offset: 0x0001DAE1
		Friend Overridable Property Label1 As Label

		' Token: 0x060032B9 RID: 12985 RVA: 0x0001F8EA File Offset: 0x0001DAEA
		Public Sub New(value As String)
			AddHandler MyBase.Load, AddressOf Me.frmKeyBordProduct_Load
			Me.InitializeComponent()
			Me.myValue = value
			Me.Label1.Text = value
		End Sub

		' Token: 0x060032BA RID: 12986 RVA: 0x001F5C44 File Offset: 0x001F3E44
		Private Sub btnCash_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "A"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032BB RID: 12987 RVA: 0x001F5CB8 File Offset: 0x001F3EB8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "B"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032BC RID: 12988 RVA: 0x001F5D2C File Offset: 0x001F3F2C
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "C"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032BD RID: 12989 RVA: 0x001F5DA0 File Offset: 0x001F3FA0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "D"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032BE RID: 12990 RVA: 0x001F5E14 File Offset: 0x001F4014
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "E"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032BF RID: 12991 RVA: 0x001F5E88 File Offset: 0x001F4088
		Private Sub GelButton8_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "F"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C0 RID: 12992 RVA: 0x001F5EFC File Offset: 0x001F40FC
		Private Sub btnCreditCard_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "G"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C1 RID: 12993 RVA: 0x001F5F70 File Offset: 0x001F4170
		Private Sub GelButton9_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "H"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C2 RID: 12994 RVA: 0x001F5FE4 File Offset: 0x001F41E4
		Private Sub GelButton10_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "I"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C3 RID: 12995 RVA: 0x001F6058 File Offset: 0x001F4258
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "J"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C4 RID: 12996 RVA: 0x001F60CC File Offset: 0x001F42CC
		Private Sub GelButton12_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "K"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C5 RID: 12997 RVA: 0x001F6140 File Offset: 0x001F4340
		Private Sub GelButton13_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "L"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C6 RID: 12998 RVA: 0x001F61B4 File Offset: 0x001F43B4
		Private Sub btnDebitCard_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "M"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C7 RID: 12999 RVA: 0x001F6228 File Offset: 0x001F4428
		Private Sub GelButton14_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "N"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C8 RID: 13000 RVA: 0x001F629C File Offset: 0x001F449C
		Private Sub GelButton15_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "O"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032C9 RID: 13001 RVA: 0x001F6310 File Offset: 0x001F4510
		Private Sub GelButton16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "P"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CA RID: 13002 RVA: 0x001F6384 File Offset: 0x001F4584
		Private Sub GelButton17_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "Q"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CB RID: 13003 RVA: 0x001F63F8 File Offset: 0x001F45F8
		Private Sub GelButton18_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "R"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CC RID: 13004 RVA: 0x001F646C File Offset: 0x001F466C
		Private Sub btnWallet_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "S"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CD RID: 13005 RVA: 0x001F64E0 File Offset: 0x001F46E0
		Private Sub GelButton19_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "T"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CE RID: 13006 RVA: 0x001F6554 File Offset: 0x001F4754
		Private Sub GelButton20_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "U"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032CF RID: 13007 RVA: 0x001F65C8 File Offset: 0x001F47C8
		Private Sub GelButton21_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "V"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D0 RID: 13008 RVA: 0x001F663C File Offset: 0x001F483C
		Private Sub GelButton22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "W"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D1 RID: 13009 RVA: 0x001F66B0 File Offset: 0x001F48B0
		Private Sub GelButton23_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "X"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D2 RID: 13010 RVA: 0x001F6724 File Offset: 0x001F4924
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "Y"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D3 RID: 13011 RVA: 0x001F6798 File Offset: 0x001F4998
		Private Sub GelButton26_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = "Z"
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D4 RID: 13012 RVA: 0x001F680C File Offset: 0x001F4A0C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblProductShort.Text = ""
			MyProject.Forms.frmPOSNewTuch.Mode = "K"
			MyProject.Forms.frmPOSNewTuch.KVALUE = Me.Label1.Text
			MyProject.Forms.frmPOSNewTuch.Category(RuntimeHelpers.GetObjectValue(sender), e)
			MyBase.Close()
		End Sub

		' Token: 0x060032D5 RID: 13013 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmKeyBordProduct_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x040015F8 RID: 5624
		Private myValue As String
	End Class
End Namespace
