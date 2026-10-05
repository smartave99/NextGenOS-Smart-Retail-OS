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
	' Token: 0x02000125 RID: 293
	<DesignerGenerated()>
	Public Partial Class frmKeyBord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003227 RID: 12839 RVA: 0x0001F10B File Offset: 0x0001D30B
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700138C RID: 5004
		' (get) Token: 0x0600322A RID: 12842 RVA: 0x0001F119 File Offset: 0x0001D319
		' (set) Token: 0x0600322B RID: 12843 RVA: 0x0001F123 File Offset: 0x0001D323
		Friend Overridable Property TableLayoutPanel6 As TableLayoutPanel

		' Token: 0x1700138D RID: 5005
		' (get) Token: 0x0600322C RID: 12844 RVA: 0x0001F12C File Offset: 0x0001D32C
		' (set) Token: 0x0600322D RID: 12845 RVA: 0x001F25DC File Offset: 0x001F07DC
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

		' Token: 0x1700138E RID: 5006
		' (get) Token: 0x0600322E RID: 12846 RVA: 0x0001F136 File Offset: 0x0001D336
		' (set) Token: 0x0600322F RID: 12847 RVA: 0x001F2620 File Offset: 0x001F0820
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

		' Token: 0x1700138F RID: 5007
		' (get) Token: 0x06003230 RID: 12848 RVA: 0x0001F140 File Offset: 0x0001D340
		' (set) Token: 0x06003231 RID: 12849 RVA: 0x001F2664 File Offset: 0x001F0864
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

		' Token: 0x17001390 RID: 5008
		' (get) Token: 0x06003232 RID: 12850 RVA: 0x0001F14A File Offset: 0x0001D34A
		' (set) Token: 0x06003233 RID: 12851 RVA: 0x001F26A8 File Offset: 0x001F08A8
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

		' Token: 0x17001391 RID: 5009
		' (get) Token: 0x06003234 RID: 12852 RVA: 0x0001F154 File Offset: 0x0001D354
		' (set) Token: 0x06003235 RID: 12853 RVA: 0x001F26EC File Offset: 0x001F08EC
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

		' Token: 0x17001392 RID: 5010
		' (get) Token: 0x06003236 RID: 12854 RVA: 0x0001F15E File Offset: 0x0001D35E
		' (set) Token: 0x06003237 RID: 12855 RVA: 0x001F2730 File Offset: 0x001F0930
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

		' Token: 0x17001393 RID: 5011
		' (get) Token: 0x06003238 RID: 12856 RVA: 0x0001F168 File Offset: 0x0001D368
		' (set) Token: 0x06003239 RID: 12857 RVA: 0x001F2774 File Offset: 0x001F0974
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

		' Token: 0x17001394 RID: 5012
		' (get) Token: 0x0600323A RID: 12858 RVA: 0x0001F172 File Offset: 0x0001D372
		' (set) Token: 0x0600323B RID: 12859 RVA: 0x001F27B8 File Offset: 0x001F09B8
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

		' Token: 0x17001395 RID: 5013
		' (get) Token: 0x0600323C RID: 12860 RVA: 0x0001F17C File Offset: 0x0001D37C
		' (set) Token: 0x0600323D RID: 12861 RVA: 0x001F27FC File Offset: 0x001F09FC
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

		' Token: 0x17001396 RID: 5014
		' (get) Token: 0x0600323E RID: 12862 RVA: 0x0001F186 File Offset: 0x0001D386
		' (set) Token: 0x0600323F RID: 12863 RVA: 0x001F2840 File Offset: 0x001F0A40
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

		' Token: 0x17001397 RID: 5015
		' (get) Token: 0x06003240 RID: 12864 RVA: 0x0001F190 File Offset: 0x0001D390
		' (set) Token: 0x06003241 RID: 12865 RVA: 0x001F2884 File Offset: 0x001F0A84
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

		' Token: 0x17001398 RID: 5016
		' (get) Token: 0x06003242 RID: 12866 RVA: 0x0001F19A File Offset: 0x0001D39A
		' (set) Token: 0x06003243 RID: 12867 RVA: 0x001F28C8 File Offset: 0x001F0AC8
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

		' Token: 0x17001399 RID: 5017
		' (get) Token: 0x06003244 RID: 12868 RVA: 0x0001F1A4 File Offset: 0x0001D3A4
		' (set) Token: 0x06003245 RID: 12869 RVA: 0x001F290C File Offset: 0x001F0B0C
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

		' Token: 0x1700139A RID: 5018
		' (get) Token: 0x06003246 RID: 12870 RVA: 0x0001F1AE File Offset: 0x0001D3AE
		' (set) Token: 0x06003247 RID: 12871 RVA: 0x001F2950 File Offset: 0x001F0B50
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

		' Token: 0x1700139B RID: 5019
		' (get) Token: 0x06003248 RID: 12872 RVA: 0x0001F1B8 File Offset: 0x0001D3B8
		' (set) Token: 0x06003249 RID: 12873 RVA: 0x001F2994 File Offset: 0x001F0B94
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

		' Token: 0x1700139C RID: 5020
		' (get) Token: 0x0600324A RID: 12874 RVA: 0x0001F1C2 File Offset: 0x0001D3C2
		' (set) Token: 0x0600324B RID: 12875 RVA: 0x001F29D8 File Offset: 0x001F0BD8
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

		' Token: 0x1700139D RID: 5021
		' (get) Token: 0x0600324C RID: 12876 RVA: 0x0001F1CC File Offset: 0x0001D3CC
		' (set) Token: 0x0600324D RID: 12877 RVA: 0x001F2A1C File Offset: 0x001F0C1C
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

		' Token: 0x1700139E RID: 5022
		' (get) Token: 0x0600324E RID: 12878 RVA: 0x0001F1D6 File Offset: 0x0001D3D6
		' (set) Token: 0x0600324F RID: 12879 RVA: 0x001F2A60 File Offset: 0x001F0C60
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

		' Token: 0x1700139F RID: 5023
		' (get) Token: 0x06003250 RID: 12880 RVA: 0x0001F1E0 File Offset: 0x0001D3E0
		' (set) Token: 0x06003251 RID: 12881 RVA: 0x001F2AA4 File Offset: 0x001F0CA4
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

		' Token: 0x170013A0 RID: 5024
		' (get) Token: 0x06003252 RID: 12882 RVA: 0x0001F1EA File Offset: 0x0001D3EA
		' (set) Token: 0x06003253 RID: 12883 RVA: 0x001F2AE8 File Offset: 0x001F0CE8
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

		' Token: 0x170013A1 RID: 5025
		' (get) Token: 0x06003254 RID: 12884 RVA: 0x0001F1F4 File Offset: 0x0001D3F4
		' (set) Token: 0x06003255 RID: 12885 RVA: 0x001F2B2C File Offset: 0x001F0D2C
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

		' Token: 0x170013A2 RID: 5026
		' (get) Token: 0x06003256 RID: 12886 RVA: 0x0001F1FE File Offset: 0x0001D3FE
		' (set) Token: 0x06003257 RID: 12887 RVA: 0x001F2B70 File Offset: 0x001F0D70
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

		' Token: 0x170013A3 RID: 5027
		' (get) Token: 0x06003258 RID: 12888 RVA: 0x0001F208 File Offset: 0x0001D408
		' (set) Token: 0x06003259 RID: 12889 RVA: 0x001F2BB4 File Offset: 0x001F0DB4
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

		' Token: 0x170013A4 RID: 5028
		' (get) Token: 0x0600325A RID: 12890 RVA: 0x0001F212 File Offset: 0x0001D412
		' (set) Token: 0x0600325B RID: 12891 RVA: 0x001F2BF8 File Offset: 0x001F0DF8
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

		' Token: 0x170013A5 RID: 5029
		' (get) Token: 0x0600325C RID: 12892 RVA: 0x0001F21C File Offset: 0x0001D41C
		' (set) Token: 0x0600325D RID: 12893 RVA: 0x001F2C3C File Offset: 0x001F0E3C
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

		' Token: 0x170013A6 RID: 5030
		' (get) Token: 0x0600325E RID: 12894 RVA: 0x0001F226 File Offset: 0x0001D426
		' (set) Token: 0x0600325F RID: 12895 RVA: 0x001F2C80 File Offset: 0x001F0E80
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

		' Token: 0x170013A7 RID: 5031
		' (get) Token: 0x06003260 RID: 12896 RVA: 0x0001F230 File Offset: 0x0001D430
		' (set) Token: 0x06003261 RID: 12897 RVA: 0x001F2CC4 File Offset: 0x001F0EC4
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

		' Token: 0x06003262 RID: 12898 RVA: 0x0001F23A File Offset: 0x0001D43A
		Private Sub btnCash_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "A"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003263 RID: 12899 RVA: 0x0001F26E File Offset: 0x0001D46E
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "B"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003264 RID: 12900 RVA: 0x0001F2A2 File Offset: 0x0001D4A2
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "C"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003265 RID: 12901 RVA: 0x0001F2D6 File Offset: 0x0001D4D6
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "D"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003266 RID: 12902 RVA: 0x0001F30A File Offset: 0x0001D50A
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "E"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003267 RID: 12903 RVA: 0x0001F33E File Offset: 0x0001D53E
		Private Sub GelButton8_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "F"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003268 RID: 12904 RVA: 0x0001F372 File Offset: 0x0001D572
		Private Sub btnCreditCard_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "G"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003269 RID: 12905 RVA: 0x0001F3A6 File Offset: 0x0001D5A6
		Private Sub GelButton9_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "H"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326A RID: 12906 RVA: 0x0001F3DA File Offset: 0x0001D5DA
		Private Sub GelButton10_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "I"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326B RID: 12907 RVA: 0x0001F40E File Offset: 0x0001D60E
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "J"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326C RID: 12908 RVA: 0x0001F442 File Offset: 0x0001D642
		Private Sub GelButton12_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "K"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326D RID: 12909 RVA: 0x0001F476 File Offset: 0x0001D676
		Private Sub GelButton13_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "L"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326E RID: 12910 RVA: 0x0001F4AA File Offset: 0x0001D6AA
		Private Sub btnDebitCard_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "M"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600326F RID: 12911 RVA: 0x0001F4DE File Offset: 0x0001D6DE
		Private Sub GelButton14_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "N"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003270 RID: 12912 RVA: 0x0001F512 File Offset: 0x0001D712
		Private Sub GelButton15_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "O"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003271 RID: 12913 RVA: 0x0001F546 File Offset: 0x0001D746
		Private Sub GelButton16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "P"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003272 RID: 12914 RVA: 0x0001F57A File Offset: 0x0001D77A
		Private Sub GelButton17_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "Q"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003273 RID: 12915 RVA: 0x0001F5AE File Offset: 0x0001D7AE
		Private Sub GelButton18_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "R"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003274 RID: 12916 RVA: 0x0001F5E2 File Offset: 0x0001D7E2
		Private Sub btnWallet_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "S"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003275 RID: 12917 RVA: 0x0001F616 File Offset: 0x0001D816
		Private Sub GelButton19_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "T"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003276 RID: 12918 RVA: 0x0001F64A File Offset: 0x0001D84A
		Private Sub GelButton20_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "U"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003277 RID: 12919 RVA: 0x0001F67E File Offset: 0x0001D87E
		Private Sub GelButton21_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "V"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003278 RID: 12920 RVA: 0x0001F6B2 File Offset: 0x0001D8B2
		Private Sub GelButton22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "W"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x06003279 RID: 12921 RVA: 0x0001F6E6 File Offset: 0x0001D8E6
		Private Sub GelButton23_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "X"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600327A RID: 12922 RVA: 0x0001F71A File Offset: 0x0001D91A
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "Y"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600327B RID: 12923 RVA: 0x0001F74E File Offset: 0x0001D94E
		Private Sub GelButton26_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = "Z"
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub

		' Token: 0x0600327C RID: 12924 RVA: 0x0001F782 File Offset: 0x0001D982
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPOSNewTuch.lblCatSort.Text = ""
			MyProject.Forms.frmPOSNewTuch.FillCategory()
			MyBase.Close()
		End Sub
	End Class
End Namespace
