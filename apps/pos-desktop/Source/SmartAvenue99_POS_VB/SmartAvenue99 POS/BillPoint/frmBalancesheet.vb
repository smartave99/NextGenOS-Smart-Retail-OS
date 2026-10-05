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
	' Token: 0x020004AB RID: 1195
	<DesignerGenerated()>
	Public Partial Class frmBalancesheet
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600ED47 RID: 60743 RVA: 0x00067F1B File Offset: 0x0006611B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBalancesheet_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBalancesheet_KeyDown
			Me.rdr1 = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005AFC RID: 23292
		' (get) Token: 0x0600ED4A RID: 60746 RVA: 0x00067F58 File Offset: 0x00066158
		' (set) Token: 0x0600ED4B RID: 60747 RVA: 0x00067F62 File Offset: 0x00066162
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005AFD RID: 23293
		' (get) Token: 0x0600ED4C RID: 60748 RVA: 0x00067F6B File Offset: 0x0006616B
		' (set) Token: 0x0600ED4D RID: 60749 RVA: 0x008F768C File Offset: 0x008F588C
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

		' Token: 0x17005AFE RID: 23294
		' (get) Token: 0x0600ED4E RID: 60750 RVA: 0x00067F75 File Offset: 0x00066175
		' (set) Token: 0x0600ED4F RID: 60751 RVA: 0x00067F7F File Offset: 0x0006617F
		Friend Overridable Property Label1 As Label

		' Token: 0x17005AFF RID: 23295
		' (get) Token: 0x0600ED50 RID: 60752 RVA: 0x00067F88 File Offset: 0x00066188
		' (set) Token: 0x0600ED51 RID: 60753 RVA: 0x00067F92 File Offset: 0x00066192
		Friend Overridable Property Label2 As Label

		' Token: 0x17005B00 RID: 23296
		' (get) Token: 0x0600ED52 RID: 60754 RVA: 0x00067F9B File Offset: 0x0006619B
		' (set) Token: 0x0600ED53 RID: 60755 RVA: 0x00067FA5 File Offset: 0x000661A5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005B01 RID: 23297
		' (get) Token: 0x0600ED54 RID: 60756 RVA: 0x00067FAE File Offset: 0x000661AE
		' (set) Token: 0x0600ED55 RID: 60757 RVA: 0x00067FB8 File Offset: 0x000661B8
		Friend Overridable Property Label3 As Label

		' Token: 0x17005B02 RID: 23298
		' (get) Token: 0x0600ED56 RID: 60758 RVA: 0x00067FC1 File Offset: 0x000661C1
		' (set) Token: 0x0600ED57 RID: 60759 RVA: 0x00067FCB File Offset: 0x000661CB
		Friend Overridable Property Label4 As Label

		' Token: 0x17005B03 RID: 23299
		' (get) Token: 0x0600ED58 RID: 60760 RVA: 0x00067FD4 File Offset: 0x000661D4
		' (set) Token: 0x0600ED59 RID: 60761 RVA: 0x00067FDE File Offset: 0x000661DE
		Friend Overridable Property Label5 As Label

		' Token: 0x17005B04 RID: 23300
		' (get) Token: 0x0600ED5A RID: 60762 RVA: 0x00067FE7 File Offset: 0x000661E7
		' (set) Token: 0x0600ED5B RID: 60763 RVA: 0x00067FF1 File Offset: 0x000661F1
		Friend Overridable Property Label6 As Label

		' Token: 0x17005B05 RID: 23301
		' (get) Token: 0x0600ED5C RID: 60764 RVA: 0x00067FFA File Offset: 0x000661FA
		' (set) Token: 0x0600ED5D RID: 60765 RVA: 0x008F76D0 File Offset: 0x008F58D0
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

		' Token: 0x17005B06 RID: 23302
		' (get) Token: 0x0600ED5E RID: 60766 RVA: 0x00068004 File Offset: 0x00066204
		' (set) Token: 0x0600ED5F RID: 60767 RVA: 0x008F7714 File Offset: 0x008F5914
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
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B07 RID: 23303
		' (get) Token: 0x0600ED60 RID: 60768 RVA: 0x0006800E File Offset: 0x0006620E
		' (set) Token: 0x0600ED61 RID: 60769 RVA: 0x00068018 File Offset: 0x00066218
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17005B08 RID: 23304
		' (get) Token: 0x0600ED62 RID: 60770 RVA: 0x00068021 File Offset: 0x00066221
		' (set) Token: 0x0600ED63 RID: 60771 RVA: 0x0006802B File Offset: 0x0006622B
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17005B09 RID: 23305
		' (get) Token: 0x0600ED64 RID: 60772 RVA: 0x00068034 File Offset: 0x00066234
		' (set) Token: 0x0600ED65 RID: 60773 RVA: 0x0006803E File Offset: 0x0006623E
		Friend Overridable Property Label7 As Label

		' Token: 0x17005B0A RID: 23306
		' (get) Token: 0x0600ED66 RID: 60774 RVA: 0x00068047 File Offset: 0x00066247
		' (set) Token: 0x0600ED67 RID: 60775 RVA: 0x00068051 File Offset: 0x00066251
		Friend Overridable Property TextBox5 As TextBox

		' Token: 0x17005B0B RID: 23307
		' (get) Token: 0x0600ED68 RID: 60776 RVA: 0x0006805A File Offset: 0x0006625A
		' (set) Token: 0x0600ED69 RID: 60777 RVA: 0x00068064 File Offset: 0x00066264
		Friend Overridable Property Label8 As Label

		' Token: 0x17005B0C RID: 23308
		' (get) Token: 0x0600ED6A RID: 60778 RVA: 0x0006806D File Offset: 0x0006626D
		' (set) Token: 0x0600ED6B RID: 60779 RVA: 0x00068077 File Offset: 0x00066277
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17005B0D RID: 23309
		' (get) Token: 0x0600ED6C RID: 60780 RVA: 0x00068080 File Offset: 0x00066280
		' (set) Token: 0x0600ED6D RID: 60781 RVA: 0x0006808A File Offset: 0x0006628A
		Friend Overridable Property Label9 As Label

		' Token: 0x17005B0E RID: 23310
		' (get) Token: 0x0600ED6E RID: 60782 RVA: 0x00068093 File Offset: 0x00066293
		' (set) Token: 0x0600ED6F RID: 60783 RVA: 0x0006809D File Offset: 0x0006629D
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x17005B0F RID: 23311
		' (get) Token: 0x0600ED70 RID: 60784 RVA: 0x000680A6 File Offset: 0x000662A6
		' (set) Token: 0x0600ED71 RID: 60785 RVA: 0x000680B0 File Offset: 0x000662B0
		Friend Overridable Property Label10 As Label

		' Token: 0x17005B10 RID: 23312
		' (get) Token: 0x0600ED72 RID: 60786 RVA: 0x000680B9 File Offset: 0x000662B9
		' (set) Token: 0x0600ED73 RID: 60787 RVA: 0x000680C3 File Offset: 0x000662C3
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x17005B11 RID: 23313
		' (get) Token: 0x0600ED74 RID: 60788 RVA: 0x000680CC File Offset: 0x000662CC
		' (set) Token: 0x0600ED75 RID: 60789 RVA: 0x000680D6 File Offset: 0x000662D6
		Friend Overridable Property Label11 As Label

		' Token: 0x17005B12 RID: 23314
		' (get) Token: 0x0600ED76 RID: 60790 RVA: 0x000680DF File Offset: 0x000662DF
		' (set) Token: 0x0600ED77 RID: 60791 RVA: 0x000680E9 File Offset: 0x000662E9
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17005B13 RID: 23315
		' (get) Token: 0x0600ED78 RID: 60792 RVA: 0x000680F2 File Offset: 0x000662F2
		' (set) Token: 0x0600ED79 RID: 60793 RVA: 0x000680FC File Offset: 0x000662FC
		Friend Overridable Property Label12 As Label

		' Token: 0x17005B14 RID: 23316
		' (get) Token: 0x0600ED7A RID: 60794 RVA: 0x00068105 File Offset: 0x00066305
		' (set) Token: 0x0600ED7B RID: 60795 RVA: 0x008F7758 File Offset: 0x008F5958
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
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B15 RID: 23317
		' (get) Token: 0x0600ED7C RID: 60796 RVA: 0x0006810F File Offset: 0x0006630F
		' (set) Token: 0x0600ED7D RID: 60797 RVA: 0x00068119 File Offset: 0x00066319
		Friend Overridable Property Label13 As Label

		' Token: 0x17005B16 RID: 23318
		' (get) Token: 0x0600ED7E RID: 60798 RVA: 0x00068122 File Offset: 0x00066322
		' (set) Token: 0x0600ED7F RID: 60799 RVA: 0x008F779C File Offset: 0x008F599C
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

		' Token: 0x17005B17 RID: 23319
		' (get) Token: 0x0600ED80 RID: 60800 RVA: 0x0006812C File Offset: 0x0006632C
		' (set) Token: 0x0600ED81 RID: 60801 RVA: 0x00068136 File Offset: 0x00066336
		Friend Overridable Property Label14 As Label

		' Token: 0x17005B18 RID: 23320
		' (get) Token: 0x0600ED82 RID: 60802 RVA: 0x0006813F File Offset: 0x0006633F
		' (set) Token: 0x0600ED83 RID: 60803 RVA: 0x008F77E0 File Offset: 0x008F59E0
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
				Dim textBox As TextBox = Me._TextBox12
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox12 = value
				textBox = Me._TextBox12
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B19 RID: 23321
		' (get) Token: 0x0600ED84 RID: 60804 RVA: 0x00068149 File Offset: 0x00066349
		' (set) Token: 0x0600ED85 RID: 60805 RVA: 0x00068153 File Offset: 0x00066353
		Friend Overridable Property Label15 As Label

		' Token: 0x17005B1A RID: 23322
		' (get) Token: 0x0600ED86 RID: 60806 RVA: 0x0006815C File Offset: 0x0006635C
		' (set) Token: 0x0600ED87 RID: 60807 RVA: 0x008F7824 File Offset: 0x008F5A24
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

		' Token: 0x17005B1B RID: 23323
		' (get) Token: 0x0600ED88 RID: 60808 RVA: 0x00068166 File Offset: 0x00066366
		' (set) Token: 0x0600ED89 RID: 60809 RVA: 0x00068170 File Offset: 0x00066370
		Friend Overridable Property Label16 As Label

		' Token: 0x17005B1C RID: 23324
		' (get) Token: 0x0600ED8A RID: 60810 RVA: 0x00068179 File Offset: 0x00066379
		' (set) Token: 0x0600ED8B RID: 60811 RVA: 0x008F7868 File Offset: 0x008F5A68
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
				Dim textBox As TextBox = Me._TextBox14
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox14 = value
				textBox = Me._TextBox14
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B1D RID: 23325
		' (get) Token: 0x0600ED8C RID: 60812 RVA: 0x00068183 File Offset: 0x00066383
		' (set) Token: 0x0600ED8D RID: 60813 RVA: 0x0006818D File Offset: 0x0006638D
		Friend Overridable Property Label17 As Label

		' Token: 0x17005B1E RID: 23326
		' (get) Token: 0x0600ED8E RID: 60814 RVA: 0x00068196 File Offset: 0x00066396
		' (set) Token: 0x0600ED8F RID: 60815 RVA: 0x000681A0 File Offset: 0x000663A0
		Friend Overridable Property Label18 As Label

		' Token: 0x17005B1F RID: 23327
		' (get) Token: 0x0600ED90 RID: 60816 RVA: 0x000681A9 File Offset: 0x000663A9
		' (set) Token: 0x0600ED91 RID: 60817 RVA: 0x008F78AC File Offset: 0x008F5AAC
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

		' Token: 0x17005B20 RID: 23328
		' (get) Token: 0x0600ED92 RID: 60818 RVA: 0x000681B3 File Offset: 0x000663B3
		' (set) Token: 0x0600ED93 RID: 60819 RVA: 0x008F78F0 File Offset: 0x008F5AF0
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
				Dim textBox As TextBox = Me._TextBox16
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox16 = value
				textBox = Me._TextBox16
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B21 RID: 23329
		' (get) Token: 0x0600ED94 RID: 60820 RVA: 0x000681BD File Offset: 0x000663BD
		' (set) Token: 0x0600ED95 RID: 60821 RVA: 0x000681C7 File Offset: 0x000663C7
		Friend Overridable Property Label19 As Label

		' Token: 0x17005B22 RID: 23330
		' (get) Token: 0x0600ED96 RID: 60822 RVA: 0x000681D0 File Offset: 0x000663D0
		' (set) Token: 0x0600ED97 RID: 60823 RVA: 0x000681DA File Offset: 0x000663DA
		Friend Overridable Property Label20 As Label

		' Token: 0x17005B23 RID: 23331
		' (get) Token: 0x0600ED98 RID: 60824 RVA: 0x000681E3 File Offset: 0x000663E3
		' (set) Token: 0x0600ED99 RID: 60825 RVA: 0x008F7934 File Offset: 0x008F5B34
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

		' Token: 0x17005B24 RID: 23332
		' (get) Token: 0x0600ED9A RID: 60826 RVA: 0x000681ED File Offset: 0x000663ED
		' (set) Token: 0x0600ED9B RID: 60827 RVA: 0x008F7978 File Offset: 0x008F5B78
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
				Dim textBox As TextBox = Me._TextBox18
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox18 = value
				textBox = Me._TextBox18
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B25 RID: 23333
		' (get) Token: 0x0600ED9C RID: 60828 RVA: 0x000681F7 File Offset: 0x000663F7
		' (set) Token: 0x0600ED9D RID: 60829 RVA: 0x00068201 File Offset: 0x00066401
		Friend Overridable Property Label21 As Label

		' Token: 0x17005B26 RID: 23334
		' (get) Token: 0x0600ED9E RID: 60830 RVA: 0x0006820A File Offset: 0x0006640A
		' (set) Token: 0x0600ED9F RID: 60831 RVA: 0x00068214 File Offset: 0x00066414
		Friend Overridable Property TextBox19 As TextBox

		' Token: 0x17005B27 RID: 23335
		' (get) Token: 0x0600EDA0 RID: 60832 RVA: 0x0006821D File Offset: 0x0006641D
		' (set) Token: 0x0600EDA1 RID: 60833 RVA: 0x00068227 File Offset: 0x00066427
		Friend Overridable Property Label22 As Label

		' Token: 0x17005B28 RID: 23336
		' (get) Token: 0x0600EDA2 RID: 60834 RVA: 0x00068230 File Offset: 0x00066430
		' (set) Token: 0x0600EDA3 RID: 60835 RVA: 0x0006823A File Offset: 0x0006643A
		Friend Overridable Property TextBox20 As TextBox

		' Token: 0x17005B29 RID: 23337
		' (get) Token: 0x0600EDA4 RID: 60836 RVA: 0x00068243 File Offset: 0x00066443
		' (set) Token: 0x0600EDA5 RID: 60837 RVA: 0x0006824D File Offset: 0x0006644D
		Friend Overridable Property Label23 As Label

		' Token: 0x17005B2A RID: 23338
		' (get) Token: 0x0600EDA6 RID: 60838 RVA: 0x00068256 File Offset: 0x00066456
		' (set) Token: 0x0600EDA7 RID: 60839 RVA: 0x00068260 File Offset: 0x00066460
		Friend Overridable Property TextBox21 As TextBox

		' Token: 0x17005B2B RID: 23339
		' (get) Token: 0x0600EDA8 RID: 60840 RVA: 0x00068269 File Offset: 0x00066469
		' (set) Token: 0x0600EDA9 RID: 60841 RVA: 0x00068273 File Offset: 0x00066473
		Friend Overridable Property Label24 As Label

		' Token: 0x17005B2C RID: 23340
		' (get) Token: 0x0600EDAA RID: 60842 RVA: 0x0006827C File Offset: 0x0006647C
		' (set) Token: 0x0600EDAB RID: 60843 RVA: 0x00068286 File Offset: 0x00066486
		Friend Overridable Property TextBox22 As TextBox

		' Token: 0x17005B2D RID: 23341
		' (get) Token: 0x0600EDAC RID: 60844 RVA: 0x0006828F File Offset: 0x0006648F
		' (set) Token: 0x0600EDAD RID: 60845 RVA: 0x00068299 File Offset: 0x00066499
		Friend Overridable Property Label25 As Label

		' Token: 0x17005B2E RID: 23342
		' (get) Token: 0x0600EDAE RID: 60846 RVA: 0x000682A2 File Offset: 0x000664A2
		' (set) Token: 0x0600EDAF RID: 60847 RVA: 0x008F79BC File Offset: 0x008F5BBC
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

		' Token: 0x17005B2F RID: 23343
		' (get) Token: 0x0600EDB0 RID: 60848 RVA: 0x000682AC File Offset: 0x000664AC
		' (set) Token: 0x0600EDB1 RID: 60849 RVA: 0x000682B6 File Offset: 0x000664B6
		Friend Overridable Property Label26 As Label

		' Token: 0x17005B30 RID: 23344
		' (get) Token: 0x0600EDB2 RID: 60850 RVA: 0x000682BF File Offset: 0x000664BF
		' (set) Token: 0x0600EDB3 RID: 60851 RVA: 0x000682C9 File Offset: 0x000664C9
		Friend Overridable Property Label27 As Label

		' Token: 0x17005B31 RID: 23345
		' (get) Token: 0x0600EDB4 RID: 60852 RVA: 0x000682D2 File Offset: 0x000664D2
		' (set) Token: 0x0600EDB5 RID: 60853 RVA: 0x008F7A00 File Offset: 0x008F5C00
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

		' Token: 0x17005B32 RID: 23346
		' (get) Token: 0x0600EDB6 RID: 60854 RVA: 0x000682DC File Offset: 0x000664DC
		' (set) Token: 0x0600EDB7 RID: 60855 RVA: 0x008F7A44 File Offset: 0x008F5C44
		Private _TextBox25 As TextBox
		Friend Overridable Property TextBox25 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox25
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox25_TextChanged
				Dim textBox As TextBox = Me._TextBox25
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox25 = value
				textBox = Me._TextBox25
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B33 RID: 23347
		' (get) Token: 0x0600EDB8 RID: 60856 RVA: 0x000682E6 File Offset: 0x000664E6
		' (set) Token: 0x0600EDB9 RID: 60857 RVA: 0x000682F0 File Offset: 0x000664F0
		Friend Overridable Property Label28 As Label

		' Token: 0x17005B34 RID: 23348
		' (get) Token: 0x0600EDBA RID: 60858 RVA: 0x000682F9 File Offset: 0x000664F9
		' (set) Token: 0x0600EDBB RID: 60859 RVA: 0x00068303 File Offset: 0x00066503
		Friend Overridable Property Label29 As Label

		' Token: 0x17005B35 RID: 23349
		' (get) Token: 0x0600EDBC RID: 60860 RVA: 0x0006830C File Offset: 0x0006650C
		' (set) Token: 0x0600EDBD RID: 60861 RVA: 0x008F7A88 File Offset: 0x008F5C88
		Private _TextBox26 As TextBox
		Friend Overridable Property TextBox26 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox26
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox26_TextChanged
				Dim textBox As TextBox = Me._TextBox26
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox26 = value
				textBox = Me._TextBox26
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B36 RID: 23350
		' (get) Token: 0x0600EDBE RID: 60862 RVA: 0x00068316 File Offset: 0x00066516
		' (set) Token: 0x0600EDBF RID: 60863 RVA: 0x00068320 File Offset: 0x00066520
		Friend Overridable Property TextBox27 As TextBox

		' Token: 0x17005B37 RID: 23351
		' (get) Token: 0x0600EDC0 RID: 60864 RVA: 0x00068329 File Offset: 0x00066529
		' (set) Token: 0x0600EDC1 RID: 60865 RVA: 0x00068333 File Offset: 0x00066533
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005B38 RID: 23352
		' (get) Token: 0x0600EDC2 RID: 60866 RVA: 0x0006833C File Offset: 0x0006653C
		' (set) Token: 0x0600EDC3 RID: 60867 RVA: 0x00068346 File Offset: 0x00066546
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005B39 RID: 23353
		' (get) Token: 0x0600EDC4 RID: 60868 RVA: 0x0006834F File Offset: 0x0006654F
		' (set) Token: 0x0600EDC5 RID: 60869 RVA: 0x00068359 File Offset: 0x00066559
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005B3A RID: 23354
		' (get) Token: 0x0600EDC6 RID: 60870 RVA: 0x00068362 File Offset: 0x00066562
		' (set) Token: 0x0600EDC7 RID: 60871 RVA: 0x0006836C File Offset: 0x0006656C
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005B3B RID: 23355
		' (get) Token: 0x0600EDC8 RID: 60872 RVA: 0x00068375 File Offset: 0x00066575
		' (set) Token: 0x0600EDC9 RID: 60873 RVA: 0x0006837F File Offset: 0x0006657F
		Friend Overridable Property Label30 As Label

		' Token: 0x17005B3C RID: 23356
		' (get) Token: 0x0600EDCA RID: 60874 RVA: 0x00068388 File Offset: 0x00066588
		' (set) Token: 0x0600EDCB RID: 60875 RVA: 0x008F7ACC File Offset: 0x008F5CCC
		Private _TextBox28 As TextBox
		Friend Overridable Property TextBox28 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox28
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox28_TextChanged
				Dim textBox As TextBox = Me._TextBox28
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox28 = value
				textBox = Me._TextBox28
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B3D RID: 23357
		' (get) Token: 0x0600EDCC RID: 60876 RVA: 0x00068392 File Offset: 0x00066592
		' (set) Token: 0x0600EDCD RID: 60877 RVA: 0x008F7B10 File Offset: 0x008F5D10
		Private _TextBox29 As TextBox
		Friend Overridable Property TextBox29 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox29
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox29_TextChanged
				Dim textBox As TextBox = Me._TextBox29
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox29 = value
				textBox = Me._TextBox29
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B3E RID: 23358
		' (get) Token: 0x0600EDCE RID: 60878 RVA: 0x0006839C File Offset: 0x0006659C
		' (set) Token: 0x0600EDCF RID: 60879 RVA: 0x000683A6 File Offset: 0x000665A6
		Friend Overridable Property Label31 As Label

		' Token: 0x17005B3F RID: 23359
		' (get) Token: 0x0600EDD0 RID: 60880 RVA: 0x000683AF File Offset: 0x000665AF
		' (set) Token: 0x0600EDD1 RID: 60881 RVA: 0x008F7B54 File Offset: 0x008F5D54
		Private _TextBox30 As TextBox
		Friend Overridable Property TextBox30 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox30
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox30_TextChanged
				Dim textBox As TextBox = Me._TextBox30
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox30 = value
				textBox = Me._TextBox30
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B40 RID: 23360
		' (get) Token: 0x0600EDD2 RID: 60882 RVA: 0x000683B9 File Offset: 0x000665B9
		' (set) Token: 0x0600EDD3 RID: 60883 RVA: 0x008F7B98 File Offset: 0x008F5D98
		Private _TextBox31 As TextBox
		Friend Overridable Property TextBox31 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox31
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox31_TextChanged
				Dim textBox As TextBox = Me._TextBox31
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox31 = value
				textBox = Me._TextBox31
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B41 RID: 23361
		' (get) Token: 0x0600EDD4 RID: 60884 RVA: 0x000683C3 File Offset: 0x000665C3
		' (set) Token: 0x0600EDD5 RID: 60885 RVA: 0x000683CD File Offset: 0x000665CD
		Friend Overridable Property Label32 As Label

		' Token: 0x17005B42 RID: 23362
		' (get) Token: 0x0600EDD6 RID: 60886 RVA: 0x000683D6 File Offset: 0x000665D6
		' (set) Token: 0x0600EDD7 RID: 60887 RVA: 0x000683E0 File Offset: 0x000665E0
		Friend Overridable Property Label33 As Label

		' Token: 0x17005B43 RID: 23363
		' (get) Token: 0x0600EDD8 RID: 60888 RVA: 0x000683E9 File Offset: 0x000665E9
		' (set) Token: 0x0600EDD9 RID: 60889 RVA: 0x000683F3 File Offset: 0x000665F3
		Friend Overridable Property Label34 As Label

		' Token: 0x17005B44 RID: 23364
		' (get) Token: 0x0600EDDA RID: 60890 RVA: 0x000683FC File Offset: 0x000665FC
		' (set) Token: 0x0600EDDB RID: 60891 RVA: 0x008F7BDC File Offset: 0x008F5DDC
		Private _TextBox32 As TextBox
		Friend Overridable Property TextBox32 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox32
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox32_TextChanged
				Dim textBox As TextBox = Me._TextBox32
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox32 = value
				textBox = Me._TextBox32
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B45 RID: 23365
		' (get) Token: 0x0600EDDC RID: 60892 RVA: 0x00068406 File Offset: 0x00066606
		' (set) Token: 0x0600EDDD RID: 60893 RVA: 0x008F7C20 File Offset: 0x008F5E20
		Private _TextBox33 As TextBox
		Friend Overridable Property TextBox33 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox33
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox33_TextChanged
				Dim textBox As TextBox = Me._TextBox33
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox33 = value
				textBox = Me._TextBox33
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B46 RID: 23366
		' (get) Token: 0x0600EDDE RID: 60894 RVA: 0x00068410 File Offset: 0x00066610
		' (set) Token: 0x0600EDDF RID: 60895 RVA: 0x0006841A File Offset: 0x0006661A
		Friend Overridable Property Label35 As Label

		' Token: 0x17005B47 RID: 23367
		' (get) Token: 0x0600EDE0 RID: 60896 RVA: 0x00068423 File Offset: 0x00066623
		' (set) Token: 0x0600EDE1 RID: 60897 RVA: 0x008F7C64 File Offset: 0x008F5E64
		Private _TextBox34 As TextBox
		Friend Overridable Property TextBox34 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox34
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox34_TextChanged
				Dim textBox As TextBox = Me._TextBox34
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox34 = value
				textBox = Me._TextBox34
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B48 RID: 23368
		' (get) Token: 0x0600EDE2 RID: 60898 RVA: 0x0006842D File Offset: 0x0006662D
		' (set) Token: 0x0600EDE3 RID: 60899 RVA: 0x008F7CA8 File Offset: 0x008F5EA8
		Private _TextBox35 As TextBox
		Friend Overridable Property TextBox35 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox35_TextChanged
				Dim textBox As TextBox = Me._TextBox35
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox35 = value
				textBox = Me._TextBox35
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B49 RID: 23369
		' (get) Token: 0x0600EDE4 RID: 60900 RVA: 0x00068437 File Offset: 0x00066637
		' (set) Token: 0x0600EDE5 RID: 60901 RVA: 0x00068441 File Offset: 0x00066641
		Friend Overridable Property Label36 As Label

		' Token: 0x17005B4A RID: 23370
		' (get) Token: 0x0600EDE6 RID: 60902 RVA: 0x0006844A File Offset: 0x0006664A
		' (set) Token: 0x0600EDE7 RID: 60903 RVA: 0x00068454 File Offset: 0x00066654
		Friend Overridable Property Label37 As Label

		' Token: 0x17005B4B RID: 23371
		' (get) Token: 0x0600EDE8 RID: 60904 RVA: 0x0006845D File Offset: 0x0006665D
		' (set) Token: 0x0600EDE9 RID: 60905 RVA: 0x00068467 File Offset: 0x00066667
		Friend Overridable Property Label38 As Label

		' Token: 0x17005B4C RID: 23372
		' (get) Token: 0x0600EDEA RID: 60906 RVA: 0x00068470 File Offset: 0x00066670
		' (set) Token: 0x0600EDEB RID: 60907 RVA: 0x0006847A File Offset: 0x0006667A
		Friend Overridable Property TextBox36 As TextBox

		' Token: 0x17005B4D RID: 23373
		' (get) Token: 0x0600EDEC RID: 60908 RVA: 0x00068483 File Offset: 0x00066683
		' (set) Token: 0x0600EDED RID: 60909 RVA: 0x0006848D File Offset: 0x0006668D
		Friend Overridable Property Label39 As Label

		' Token: 0x17005B4E RID: 23374
		' (get) Token: 0x0600EDEE RID: 60910 RVA: 0x00068496 File Offset: 0x00066696
		' (set) Token: 0x0600EDEF RID: 60911 RVA: 0x000684A0 File Offset: 0x000666A0
		Friend Overridable Property Label40 As Label

		' Token: 0x17005B4F RID: 23375
		' (get) Token: 0x0600EDF0 RID: 60912 RVA: 0x000684A9 File Offset: 0x000666A9
		' (set) Token: 0x0600EDF1 RID: 60913 RVA: 0x000684B3 File Offset: 0x000666B3
		Friend Overridable Property Label41 As Label

		' Token: 0x17005B50 RID: 23376
		' (get) Token: 0x0600EDF2 RID: 60914 RVA: 0x000684BC File Offset: 0x000666BC
		' (set) Token: 0x0600EDF3 RID: 60915 RVA: 0x000684C6 File Offset: 0x000666C6
		Friend Overridable Property Label42 As Label

		' Token: 0x17005B51 RID: 23377
		' (get) Token: 0x0600EDF4 RID: 60916 RVA: 0x000684CF File Offset: 0x000666CF
		' (set) Token: 0x0600EDF5 RID: 60917 RVA: 0x000684D9 File Offset: 0x000666D9
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17005B52 RID: 23378
		' (get) Token: 0x0600EDF6 RID: 60918 RVA: 0x000684E2 File Offset: 0x000666E2
		' (set) Token: 0x0600EDF7 RID: 60919 RVA: 0x000684EC File Offset: 0x000666EC
		Friend Overridable Property Label43 As Label

		' Token: 0x17005B53 RID: 23379
		' (get) Token: 0x0600EDF8 RID: 60920 RVA: 0x000684F5 File Offset: 0x000666F5
		' (set) Token: 0x0600EDF9 RID: 60921 RVA: 0x000684FF File Offset: 0x000666FF
		Friend Overridable Property Label44 As Label

		' Token: 0x17005B54 RID: 23380
		' (get) Token: 0x0600EDFA RID: 60922 RVA: 0x00068508 File Offset: 0x00066708
		' (set) Token: 0x0600EDFB RID: 60923 RVA: 0x00068512 File Offset: 0x00066712
		Friend Overridable Property TextBox37 As TextBox

		' Token: 0x17005B55 RID: 23381
		' (get) Token: 0x0600EDFC RID: 60924 RVA: 0x0006851B File Offset: 0x0006671B
		' (set) Token: 0x0600EDFD RID: 60925 RVA: 0x008F7CEC File Offset: 0x008F5EEC
		Private _TextBox38 As TextBox
		Friend Overridable Property TextBox38 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox38
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox38_TextChanged
				Dim textBox As TextBox = Me._TextBox38
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox38 = value
				textBox = Me._TextBox38
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B56 RID: 23382
		' (get) Token: 0x0600EDFE RID: 60926 RVA: 0x00068525 File Offset: 0x00066725
		' (set) Token: 0x0600EDFF RID: 60927 RVA: 0x008F7D30 File Offset: 0x008F5F30
		Private _TextBox39 As TextBox
		Friend Overridable Property TextBox39 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox39
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox39_TextChanged
				Dim textBox As TextBox = Me._TextBox39
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox39 = value
				textBox = Me._TextBox39
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B57 RID: 23383
		' (get) Token: 0x0600EE00 RID: 60928 RVA: 0x0006852F File Offset: 0x0006672F
		' (set) Token: 0x0600EE01 RID: 60929 RVA: 0x00068539 File Offset: 0x00066739
		Friend Overridable Property Label46 As Label

		' Token: 0x17005B58 RID: 23384
		' (get) Token: 0x0600EE02 RID: 60930 RVA: 0x00068542 File Offset: 0x00066742
		' (set) Token: 0x0600EE03 RID: 60931 RVA: 0x0006854C File Offset: 0x0006674C
		Friend Overridable Property Label48 As Label

		' Token: 0x17005B59 RID: 23385
		' (get) Token: 0x0600EE04 RID: 60932 RVA: 0x00068555 File Offset: 0x00066755
		' (set) Token: 0x0600EE05 RID: 60933 RVA: 0x008F7D74 File Offset: 0x008F5F74
		Private _TextBox42 As TextBox
		Friend Overridable Property TextBox42 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox42
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox42_TextChanged
				Dim textBox As TextBox = Me._TextBox42
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox42 = value
				textBox = Me._TextBox42
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B5A RID: 23386
		' (get) Token: 0x0600EE06 RID: 60934 RVA: 0x0006855F File Offset: 0x0006675F
		' (set) Token: 0x0600EE07 RID: 60935 RVA: 0x00068569 File Offset: 0x00066769
		Friend Overridable Property Label50 As Label

		' Token: 0x17005B5B RID: 23387
		' (get) Token: 0x0600EE08 RID: 60936 RVA: 0x00068572 File Offset: 0x00066772
		' (set) Token: 0x0600EE09 RID: 60937 RVA: 0x0006857C File Offset: 0x0006677C
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17005B5C RID: 23388
		' (get) Token: 0x0600EE0A RID: 60938 RVA: 0x00068585 File Offset: 0x00066785
		' (set) Token: 0x0600EE0B RID: 60939 RVA: 0x0006858F File Offset: 0x0006678F
		Friend Overridable Property Label53 As Label

		' Token: 0x17005B5D RID: 23389
		' (get) Token: 0x0600EE0C RID: 60940 RVA: 0x00068598 File Offset: 0x00066798
		' (set) Token: 0x0600EE0D RID: 60941 RVA: 0x000685A2 File Offset: 0x000667A2
		Friend Overridable Property Label54 As Label

		' Token: 0x17005B5E RID: 23390
		' (get) Token: 0x0600EE0E RID: 60942 RVA: 0x000685AB File Offset: 0x000667AB
		' (set) Token: 0x0600EE0F RID: 60943 RVA: 0x008F7DB8 File Offset: 0x008F5FB8
		Private _TextBox41 As TextBox
		Friend Overridable Property TextBox41 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox41
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox41_TextChanged
				Dim textBox As TextBox = Me._TextBox41
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox41 = value
				textBox = Me._TextBox41
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B5F RID: 23391
		' (get) Token: 0x0600EE10 RID: 60944 RVA: 0x000685B5 File Offset: 0x000667B5
		' (set) Token: 0x0600EE11 RID: 60945 RVA: 0x000685BF File Offset: 0x000667BF
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17005B60 RID: 23392
		' (get) Token: 0x0600EE12 RID: 60946 RVA: 0x000685C8 File Offset: 0x000667C8
		' (set) Token: 0x0600EE13 RID: 60947 RVA: 0x000685D2 File Offset: 0x000667D2
		Friend Overridable Property Label45 As Label

		' Token: 0x17005B61 RID: 23393
		' (get) Token: 0x0600EE14 RID: 60948 RVA: 0x000685DB File Offset: 0x000667DB
		' (set) Token: 0x0600EE15 RID: 60949 RVA: 0x000685E5 File Offset: 0x000667E5
		Friend Overridable Property Label47 As Label

		' Token: 0x17005B62 RID: 23394
		' (get) Token: 0x0600EE16 RID: 60950 RVA: 0x000685EE File Offset: 0x000667EE
		' (set) Token: 0x0600EE17 RID: 60951 RVA: 0x008F7DFC File Offset: 0x008F5FFC
		Private _TextBox40 As TextBox
		Friend Overridable Property TextBox40 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox40
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox40_TextChanged
				Dim textBox As TextBox = Me._TextBox40
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox40 = value
				textBox = Me._TextBox40
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B63 RID: 23395
		' (get) Token: 0x0600EE18 RID: 60952 RVA: 0x000685F8 File Offset: 0x000667F8
		' (set) Token: 0x0600EE19 RID: 60953 RVA: 0x00068602 File Offset: 0x00066802
		Friend Overridable Property Panel8 As Panel

		' Token: 0x17005B64 RID: 23396
		' (get) Token: 0x0600EE1A RID: 60954 RVA: 0x0006860B File Offset: 0x0006680B
		' (set) Token: 0x0600EE1B RID: 60955 RVA: 0x00068615 File Offset: 0x00066815
		Friend Overridable Property Label49 As Label

		' Token: 0x17005B65 RID: 23397
		' (get) Token: 0x0600EE1C RID: 60956 RVA: 0x0006861E File Offset: 0x0006681E
		' (set) Token: 0x0600EE1D RID: 60957 RVA: 0x00068628 File Offset: 0x00066828
		Friend Overridable Property Label56 As Label

		' Token: 0x17005B66 RID: 23398
		' (get) Token: 0x0600EE1E RID: 60958 RVA: 0x00068631 File Offset: 0x00066831
		' (set) Token: 0x0600EE1F RID: 60959 RVA: 0x008F7E40 File Offset: 0x008F6040
		Private _TextBox46 As TextBox
		Friend Overridable Property TextBox46 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox46
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox46_TextChanged
				Dim textBox As TextBox = Me._TextBox46
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox46 = value
				textBox = Me._TextBox46
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B67 RID: 23399
		' (get) Token: 0x0600EE20 RID: 60960 RVA: 0x0006863B File Offset: 0x0006683B
		' (set) Token: 0x0600EE21 RID: 60961 RVA: 0x00068645 File Offset: 0x00066845
		Friend Overridable Property Label55 As Label

		' Token: 0x17005B68 RID: 23400
		' (get) Token: 0x0600EE22 RID: 60962 RVA: 0x0006864E File Offset: 0x0006684E
		' (set) Token: 0x0600EE23 RID: 60963 RVA: 0x008F7E84 File Offset: 0x008F6084
		Private _TextBox45 As TextBox
		Friend Overridable Property TextBox45 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox45
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox45_TextChanged
				Dim textBox As TextBox = Me._TextBox45
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox45 = value
				textBox = Me._TextBox45
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B69 RID: 23401
		' (get) Token: 0x0600EE24 RID: 60964 RVA: 0x00068658 File Offset: 0x00066858
		' (set) Token: 0x0600EE25 RID: 60965 RVA: 0x00068662 File Offset: 0x00066862
		Friend Overridable Property Label52 As Label

		' Token: 0x17005B6A RID: 23402
		' (get) Token: 0x0600EE26 RID: 60966 RVA: 0x0006866B File Offset: 0x0006686B
		' (set) Token: 0x0600EE27 RID: 60967 RVA: 0x008F7EC8 File Offset: 0x008F60C8
		Private _TextBox44 As TextBox
		Friend Overridable Property TextBox44 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox44
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox44_TextChanged
				Dim textBox As TextBox = Me._TextBox44
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox44 = value
				textBox = Me._TextBox44
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B6B RID: 23403
		' (get) Token: 0x0600EE28 RID: 60968 RVA: 0x00068675 File Offset: 0x00066875
		' (set) Token: 0x0600EE29 RID: 60969 RVA: 0x0006867F File Offset: 0x0006687F
		Friend Overridable Property Label57 As Label

		' Token: 0x17005B6C RID: 23404
		' (get) Token: 0x0600EE2A RID: 60970 RVA: 0x00068688 File Offset: 0x00066888
		' (set) Token: 0x0600EE2B RID: 60971 RVA: 0x008F7F0C File Offset: 0x008F610C
		Private _TextBox47 As TextBox
		Friend Overridable Property TextBox47 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox47
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox47_TextChanged
				Dim textBox As TextBox = Me._TextBox47
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox47 = value
				textBox = Me._TextBox47
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B6D RID: 23405
		' (get) Token: 0x0600EE2C RID: 60972 RVA: 0x00068692 File Offset: 0x00066892
		' (set) Token: 0x0600EE2D RID: 60973 RVA: 0x008F7F50 File Offset: 0x008F6150
		Private _TextBox51 As TextBox
		Friend Overridable Property TextBox51 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox51
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox51_TextChanged
				Dim textBox As TextBox = Me._TextBox51
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox51 = value
				textBox = Me._TextBox51
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B6E RID: 23406
		' (get) Token: 0x0600EE2E RID: 60974 RVA: 0x0006869C File Offset: 0x0006689C
		' (set) Token: 0x0600EE2F RID: 60975 RVA: 0x000686A6 File Offset: 0x000668A6
		Friend Overridable Property Label61 As Label

		' Token: 0x17005B6F RID: 23407
		' (get) Token: 0x0600EE30 RID: 60976 RVA: 0x000686AF File Offset: 0x000668AF
		' (set) Token: 0x0600EE31 RID: 60977 RVA: 0x000686B9 File Offset: 0x000668B9
		Friend Overridable Property Label60 As Label

		' Token: 0x17005B70 RID: 23408
		' (get) Token: 0x0600EE32 RID: 60978 RVA: 0x000686C2 File Offset: 0x000668C2
		' (set) Token: 0x0600EE33 RID: 60979 RVA: 0x008F7F94 File Offset: 0x008F6194
		Private _TextBox50 As TextBox
		Friend Overridable Property TextBox50 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox50
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox50_TextChanged
				Dim textBox As TextBox = Me._TextBox50
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox50 = value
				textBox = Me._TextBox50
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B71 RID: 23409
		' (get) Token: 0x0600EE34 RID: 60980 RVA: 0x000686CC File Offset: 0x000668CC
		' (set) Token: 0x0600EE35 RID: 60981 RVA: 0x000686D6 File Offset: 0x000668D6
		Friend Overridable Property Label58 As Label

		' Token: 0x17005B72 RID: 23410
		' (get) Token: 0x0600EE36 RID: 60982 RVA: 0x000686DF File Offset: 0x000668DF
		' (set) Token: 0x0600EE37 RID: 60983 RVA: 0x000686E9 File Offset: 0x000668E9
		Friend Overridable Property TextBox48 As TextBox

		' Token: 0x17005B73 RID: 23411
		' (get) Token: 0x0600EE38 RID: 60984 RVA: 0x000686F2 File Offset: 0x000668F2
		' (set) Token: 0x0600EE39 RID: 60985 RVA: 0x000686FC File Offset: 0x000668FC
		Friend Overridable Property Panel9 As Panel

		' Token: 0x17005B74 RID: 23412
		' (get) Token: 0x0600EE3A RID: 60986 RVA: 0x00068705 File Offset: 0x00066905
		' (set) Token: 0x0600EE3B RID: 60987 RVA: 0x0006870F File Offset: 0x0006690F
		Friend Overridable Property Label59 As Label

		' Token: 0x17005B75 RID: 23413
		' (get) Token: 0x0600EE3C RID: 60988 RVA: 0x00068718 File Offset: 0x00066918
		' (set) Token: 0x0600EE3D RID: 60989 RVA: 0x008F7FD8 File Offset: 0x008F61D8
		Private _TextBox49 As TextBox
		Friend Overridable Property TextBox49 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox49
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox49_TextChanged
				Dim textBox As TextBox = Me._TextBox49
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox49 = value
				textBox = Me._TextBox49
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B76 RID: 23414
		' (get) Token: 0x0600EE3E RID: 60990 RVA: 0x00068722 File Offset: 0x00066922
		' (set) Token: 0x0600EE3F RID: 60991 RVA: 0x008F801C File Offset: 0x008F621C
		Private _TextBox52 As TextBox
		Friend Overridable Property TextBox52 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox52
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox52_TextChanged
				Dim textBox As TextBox = Me._TextBox52
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox52 = value
				textBox = Me._TextBox52
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B77 RID: 23415
		' (get) Token: 0x0600EE40 RID: 60992 RVA: 0x0006872C File Offset: 0x0006692C
		' (set) Token: 0x0600EE41 RID: 60993 RVA: 0x00068736 File Offset: 0x00066936
		Friend Overridable Property Label63 As Label

		' Token: 0x17005B78 RID: 23416
		' (get) Token: 0x0600EE42 RID: 60994 RVA: 0x0006873F File Offset: 0x0006693F
		' (set) Token: 0x0600EE43 RID: 60995 RVA: 0x008F8060 File Offset: 0x008F6260
		Private _TextBox53 As TextBox
		Friend Overridable Property TextBox53 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox53
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox53_TextChanged
				Dim textBox As TextBox = Me._TextBox53
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox53 = value
				textBox = Me._TextBox53
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B79 RID: 23417
		' (get) Token: 0x0600EE44 RID: 60996 RVA: 0x00068749 File Offset: 0x00066949
		' (set) Token: 0x0600EE45 RID: 60997 RVA: 0x00068753 File Offset: 0x00066953
		Friend Overridable Property Label64 As Label

		' Token: 0x17005B7A RID: 23418
		' (get) Token: 0x0600EE46 RID: 60998 RVA: 0x0006875C File Offset: 0x0006695C
		' (set) Token: 0x0600EE47 RID: 60999 RVA: 0x008F80A4 File Offset: 0x008F62A4
		Private _TextBox54 As TextBox
		Friend Overridable Property TextBox54 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox54
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox54_TextChanged
				Dim textBox As TextBox = Me._TextBox54
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox54 = value
				textBox = Me._TextBox54
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B7B RID: 23419
		' (get) Token: 0x0600EE48 RID: 61000 RVA: 0x00068766 File Offset: 0x00066966
		' (set) Token: 0x0600EE49 RID: 61001 RVA: 0x00068770 File Offset: 0x00066970
		Friend Overridable Property Label65 As Label

		' Token: 0x17005B7C RID: 23420
		' (get) Token: 0x0600EE4A RID: 61002 RVA: 0x00068779 File Offset: 0x00066979
		' (set) Token: 0x0600EE4B RID: 61003 RVA: 0x00068783 File Offset: 0x00066983
		Friend Overridable Property Label66 As Label

		' Token: 0x17005B7D RID: 23421
		' (get) Token: 0x0600EE4C RID: 61004 RVA: 0x0006878C File Offset: 0x0006698C
		' (set) Token: 0x0600EE4D RID: 61005 RVA: 0x008F80E8 File Offset: 0x008F62E8
		Private _TextBox55 As TextBox
		Friend Overridable Property TextBox55 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox55
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox55_TextChanged
				Dim textBox As TextBox = Me._TextBox55
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox55 = value
				textBox = Me._TextBox55
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B7E RID: 23422
		' (get) Token: 0x0600EE4E RID: 61006 RVA: 0x00068796 File Offset: 0x00066996
		' (set) Token: 0x0600EE4F RID: 61007 RVA: 0x008F812C File Offset: 0x008F632C
		Private _TextBox56 As TextBox
		Friend Overridable Property TextBox56 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox56
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox56_TextChanged
				Dim textBox As TextBox = Me._TextBox56
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox56 = value
				textBox = Me._TextBox56
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B7F RID: 23423
		' (get) Token: 0x0600EE50 RID: 61008 RVA: 0x000687A0 File Offset: 0x000669A0
		' (set) Token: 0x0600EE51 RID: 61009 RVA: 0x008F8170 File Offset: 0x008F6370
		Private _TextBox57 As TextBox
		Friend Overridable Property TextBox57 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox57
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox57_TextChanged
				Dim textBox As TextBox = Me._TextBox57
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox57 = value
				textBox = Me._TextBox57
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B80 RID: 23424
		' (get) Token: 0x0600EE52 RID: 61010 RVA: 0x000687AA File Offset: 0x000669AA
		' (set) Token: 0x0600EE53 RID: 61011 RVA: 0x008F81B4 File Offset: 0x008F63B4
		Private _TextBox58 As TextBox
		Friend Overridable Property TextBox58 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox58
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox58_TextChanged
				Dim textBox As TextBox = Me._TextBox58
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox58 = value
				textBox = Me._TextBox58
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B81 RID: 23425
		' (get) Token: 0x0600EE54 RID: 61012 RVA: 0x000687B4 File Offset: 0x000669B4
		' (set) Token: 0x0600EE55 RID: 61013 RVA: 0x008F81F8 File Offset: 0x008F63F8
		Private _TextBox59 As TextBox
		Friend Overridable Property TextBox59 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox59
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox59_TextChanged
				Dim textBox As TextBox = Me._TextBox59
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox59 = value
				textBox = Me._TextBox59
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B82 RID: 23426
		' (get) Token: 0x0600EE56 RID: 61014 RVA: 0x000687BE File Offset: 0x000669BE
		' (set) Token: 0x0600EE57 RID: 61015 RVA: 0x008F823C File Offset: 0x008F643C
		Private _TextBox60 As TextBox
		Friend Overridable Property TextBox60 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox60
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox60_TextChanged
				Dim textBox As TextBox = Me._TextBox60
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox60 = value
				textBox = Me._TextBox60
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B83 RID: 23427
		' (get) Token: 0x0600EE58 RID: 61016 RVA: 0x000687C8 File Offset: 0x000669C8
		' (set) Token: 0x0600EE59 RID: 61017 RVA: 0x000687D2 File Offset: 0x000669D2
		Friend Overridable Property TextBox61 As TextBox

		' Token: 0x17005B84 RID: 23428
		' (get) Token: 0x0600EE5A RID: 61018 RVA: 0x000687DB File Offset: 0x000669DB
		' (set) Token: 0x0600EE5B RID: 61019 RVA: 0x000687E5 File Offset: 0x000669E5
		Friend Overridable Property TextBox62 As TextBox

		' Token: 0x17005B85 RID: 23429
		' (get) Token: 0x0600EE5C RID: 61020 RVA: 0x000687EE File Offset: 0x000669EE
		' (set) Token: 0x0600EE5D RID: 61021 RVA: 0x000687F8 File Offset: 0x000669F8
		Friend Overridable Property Label70 As Label

		' Token: 0x17005B86 RID: 23430
		' (get) Token: 0x0600EE5E RID: 61022 RVA: 0x00068801 File Offset: 0x00066A01
		' (set) Token: 0x0600EE5F RID: 61023 RVA: 0x0006880B File Offset: 0x00066A0B
		Friend Overridable Property TextBox63 As TextBox

		' Token: 0x17005B87 RID: 23431
		' (get) Token: 0x0600EE60 RID: 61024 RVA: 0x00068814 File Offset: 0x00066A14
		' (set) Token: 0x0600EE61 RID: 61025 RVA: 0x0006881E File Offset: 0x00066A1E
		Friend Overridable Property Panel10 As Panel

		' Token: 0x17005B88 RID: 23432
		' (get) Token: 0x0600EE62 RID: 61026 RVA: 0x00068827 File Offset: 0x00066A27
		' (set) Token: 0x0600EE63 RID: 61027 RVA: 0x00068831 File Offset: 0x00066A31
		Friend Overridable Property Panel11 As Panel

		' Token: 0x17005B89 RID: 23433
		' (get) Token: 0x0600EE64 RID: 61028 RVA: 0x0006883A File Offset: 0x00066A3A
		' (set) Token: 0x0600EE65 RID: 61029 RVA: 0x00068844 File Offset: 0x00066A44
		Friend Overridable Property Label74 As Label

		' Token: 0x17005B8A RID: 23434
		' (get) Token: 0x0600EE66 RID: 61030 RVA: 0x0006884D File Offset: 0x00066A4D
		' (set) Token: 0x0600EE67 RID: 61031 RVA: 0x00068857 File Offset: 0x00066A57
		Friend Overridable Property TextBox66 As TextBox

		' Token: 0x17005B8B RID: 23435
		' (get) Token: 0x0600EE68 RID: 61032 RVA: 0x00068860 File Offset: 0x00066A60
		' (set) Token: 0x0600EE69 RID: 61033 RVA: 0x0006886A File Offset: 0x00066A6A
		Friend Overridable Property Label75 As Label

		' Token: 0x17005B8C RID: 23436
		' (get) Token: 0x0600EE6A RID: 61034 RVA: 0x00068873 File Offset: 0x00066A73
		' (set) Token: 0x0600EE6B RID: 61035 RVA: 0x0006887D File Offset: 0x00066A7D
		Friend Overridable Property TextBox67 As TextBox

		' Token: 0x17005B8D RID: 23437
		' (get) Token: 0x0600EE6C RID: 61036 RVA: 0x00068886 File Offset: 0x00066A86
		' (set) Token: 0x0600EE6D RID: 61037 RVA: 0x00068890 File Offset: 0x00066A90
		Friend Overridable Property Label76 As Label

		' Token: 0x17005B8E RID: 23438
		' (get) Token: 0x0600EE6E RID: 61038 RVA: 0x00068899 File Offset: 0x00066A99
		' (set) Token: 0x0600EE6F RID: 61039 RVA: 0x000688A3 File Offset: 0x00066AA3
		Friend Overridable Property TextBox68 As TextBox

		' Token: 0x17005B8F RID: 23439
		' (get) Token: 0x0600EE70 RID: 61040 RVA: 0x000688AC File Offset: 0x00066AAC
		' (set) Token: 0x0600EE71 RID: 61041 RVA: 0x000688B6 File Offset: 0x00066AB6
		Friend Overridable Property Label77 As Label

		' Token: 0x17005B90 RID: 23440
		' (get) Token: 0x0600EE72 RID: 61042 RVA: 0x000688BF File Offset: 0x00066ABF
		' (set) Token: 0x0600EE73 RID: 61043 RVA: 0x000688C9 File Offset: 0x00066AC9
		Friend Overridable Property TextBox69 As TextBox

		' Token: 0x17005B91 RID: 23441
		' (get) Token: 0x0600EE74 RID: 61044 RVA: 0x000688D2 File Offset: 0x00066AD2
		' (set) Token: 0x0600EE75 RID: 61045 RVA: 0x000688DC File Offset: 0x00066ADC
		Friend Overridable Property Label78 As Label

		' Token: 0x17005B92 RID: 23442
		' (get) Token: 0x0600EE76 RID: 61046 RVA: 0x000688E5 File Offset: 0x00066AE5
		' (set) Token: 0x0600EE77 RID: 61047 RVA: 0x000688EF File Offset: 0x00066AEF
		Friend Overridable Property Label79 As Label

		' Token: 0x17005B93 RID: 23443
		' (get) Token: 0x0600EE78 RID: 61048 RVA: 0x000688F8 File Offset: 0x00066AF8
		' (set) Token: 0x0600EE79 RID: 61049 RVA: 0x00068902 File Offset: 0x00066B02
		Friend Overridable Property TextBox70 As TextBox

		' Token: 0x17005B94 RID: 23444
		' (get) Token: 0x0600EE7A RID: 61050 RVA: 0x0006890B File Offset: 0x00066B0B
		' (set) Token: 0x0600EE7B RID: 61051 RVA: 0x00068915 File Offset: 0x00066B15
		Friend Overridable Property Label80 As Label

		' Token: 0x17005B95 RID: 23445
		' (get) Token: 0x0600EE7C RID: 61052 RVA: 0x0006891E File Offset: 0x00066B1E
		' (set) Token: 0x0600EE7D RID: 61053 RVA: 0x008F8280 File Offset: 0x008F6480
		Private _TextBox64 As TextBox
		Friend Overridable Property TextBox64 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox64
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox64_TextChanged
				Dim textBox As TextBox = Me._TextBox64
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox64 = value
				textBox = Me._TextBox64
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B96 RID: 23446
		' (get) Token: 0x0600EE7E RID: 61054 RVA: 0x00068928 File Offset: 0x00066B28
		' (set) Token: 0x0600EE7F RID: 61055 RVA: 0x008F82C4 File Offset: 0x008F64C4
		Private _TextBox65 As TextBox
		Friend Overridable Property TextBox65 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox65
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox65_TextChanged
				Dim textBox As TextBox = Me._TextBox65
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox65 = value
				textBox = Me._TextBox65
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B97 RID: 23447
		' (get) Token: 0x0600EE80 RID: 61056 RVA: 0x00068932 File Offset: 0x00066B32
		' (set) Token: 0x0600EE81 RID: 61057 RVA: 0x0006893C File Offset: 0x00066B3C
		Friend Overridable Property TextBox71 As TextBox

		' Token: 0x17005B98 RID: 23448
		' (get) Token: 0x0600EE82 RID: 61058 RVA: 0x00068945 File Offset: 0x00066B45
		' (set) Token: 0x0600EE83 RID: 61059 RVA: 0x0006894F File Offset: 0x00066B4F
		Friend Overridable Property Label82 As Label

		' Token: 0x17005B99 RID: 23449
		' (get) Token: 0x0600EE84 RID: 61060 RVA: 0x00068958 File Offset: 0x00066B58
		' (set) Token: 0x0600EE85 RID: 61061 RVA: 0x00068962 File Offset: 0x00066B62
		Friend Overridable Property Label83 As Label

		' Token: 0x17005B9A RID: 23450
		' (get) Token: 0x0600EE86 RID: 61062 RVA: 0x0006896B File Offset: 0x00066B6B
		' (set) Token: 0x0600EE87 RID: 61063 RVA: 0x00068975 File Offset: 0x00066B75
		Friend Overridable Property Label84 As Label

		' Token: 0x17005B9B RID: 23451
		' (get) Token: 0x0600EE88 RID: 61064 RVA: 0x0006897E File Offset: 0x00066B7E
		' (set) Token: 0x0600EE89 RID: 61065 RVA: 0x008F8308 File Offset: 0x008F6508
		Private _TextBox72 As TextBox
		Friend Overridable Property TextBox72 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox72
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox72_TextChanged
				Dim textBox As TextBox = Me._TextBox72
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox72 = value
				textBox = Me._TextBox72
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005B9C RID: 23452
		' (get) Token: 0x0600EE8A RID: 61066 RVA: 0x00068988 File Offset: 0x00066B88
		' (set) Token: 0x0600EE8B RID: 61067 RVA: 0x00068992 File Offset: 0x00066B92
		Friend Overridable Property TextBox73 As TextBox

		' Token: 0x17005B9D RID: 23453
		' (get) Token: 0x0600EE8C RID: 61068 RVA: 0x0006899B File Offset: 0x00066B9B
		' (set) Token: 0x0600EE8D RID: 61069 RVA: 0x000689A5 File Offset: 0x00066BA5
		Friend Overridable Property Label86 As Label

		' Token: 0x17005B9E RID: 23454
		' (get) Token: 0x0600EE8E RID: 61070 RVA: 0x000689AE File Offset: 0x00066BAE
		' (set) Token: 0x0600EE8F RID: 61071 RVA: 0x000689B8 File Offset: 0x00066BB8
		Friend Overridable Property Panel12 As Panel

		' Token: 0x17005B9F RID: 23455
		' (get) Token: 0x0600EE90 RID: 61072 RVA: 0x000689C1 File Offset: 0x00066BC1
		' (set) Token: 0x0600EE91 RID: 61073 RVA: 0x000689CB File Offset: 0x00066BCB
		Friend Overridable Property TextBox74 As TextBox

		' Token: 0x17005BA0 RID: 23456
		' (get) Token: 0x0600EE92 RID: 61074 RVA: 0x000689D4 File Offset: 0x00066BD4
		' (set) Token: 0x0600EE93 RID: 61075 RVA: 0x000689DE File Offset: 0x00066BDE
		Friend Overridable Property Label85 As Label

		' Token: 0x17005BA1 RID: 23457
		' (get) Token: 0x0600EE94 RID: 61076 RVA: 0x000689E7 File Offset: 0x00066BE7
		' (set) Token: 0x0600EE95 RID: 61077 RVA: 0x000689F1 File Offset: 0x00066BF1
		Friend Overridable Property Label89 As Label

		' Token: 0x17005BA2 RID: 23458
		' (get) Token: 0x0600EE96 RID: 61078 RVA: 0x000689FA File Offset: 0x00066BFA
		' (set) Token: 0x0600EE97 RID: 61079 RVA: 0x008F834C File Offset: 0x008F654C
		Private _TextBox77 As TextBox
		Friend Overridable Property TextBox77 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox77
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox77_TextChanged
				Dim textBox As TextBox = Me._TextBox77
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox77 = value
				textBox = Me._TextBox77
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BA3 RID: 23459
		' (get) Token: 0x0600EE98 RID: 61080 RVA: 0x00068A04 File Offset: 0x00066C04
		' (set) Token: 0x0600EE99 RID: 61081 RVA: 0x00068A0E File Offset: 0x00066C0E
		Friend Overridable Property Label88 As Label

		' Token: 0x17005BA4 RID: 23460
		' (get) Token: 0x0600EE9A RID: 61082 RVA: 0x00068A17 File Offset: 0x00066C17
		' (set) Token: 0x0600EE9B RID: 61083 RVA: 0x00068A21 File Offset: 0x00066C21
		Friend Overridable Property Label87 As Label

		' Token: 0x17005BA5 RID: 23461
		' (get) Token: 0x0600EE9C RID: 61084 RVA: 0x00068A2A File Offset: 0x00066C2A
		' (set) Token: 0x0600EE9D RID: 61085 RVA: 0x008F8390 File Offset: 0x008F6590
		Private _TextBox76 As TextBox
		Friend Overridable Property TextBox76 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox76
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox76_TextChanged
				Dim textBox As TextBox = Me._TextBox76
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox76 = value
				textBox = Me._TextBox76
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BA6 RID: 23462
		' (get) Token: 0x0600EE9E RID: 61086 RVA: 0x00068A34 File Offset: 0x00066C34
		' (set) Token: 0x0600EE9F RID: 61087 RVA: 0x008F83D4 File Offset: 0x008F65D4
		Private _TextBox75 As TextBox
		Friend Overridable Property TextBox75 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox75
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox75_TextChanged
				Dim textBox As TextBox = Me._TextBox75
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox75 = value
				textBox = Me._TextBox75
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BA7 RID: 23463
		' (get) Token: 0x0600EEA0 RID: 61088 RVA: 0x00068A3E File Offset: 0x00066C3E
		' (set) Token: 0x0600EEA1 RID: 61089 RVA: 0x00068A48 File Offset: 0x00066C48
		Friend Overridable Property Label90 As Label

		' Token: 0x17005BA8 RID: 23464
		' (get) Token: 0x0600EEA2 RID: 61090 RVA: 0x00068A51 File Offset: 0x00066C51
		' (set) Token: 0x0600EEA3 RID: 61091 RVA: 0x008F8418 File Offset: 0x008F6618
		Private _TextBox80 As TextBox
		Friend Overridable Property TextBox80 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox80
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox80_TextChanged
				Dim textBox As TextBox = Me._TextBox80
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox80 = value
				textBox = Me._TextBox80
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BA9 RID: 23465
		' (get) Token: 0x0600EEA4 RID: 61092 RVA: 0x00068A5B File Offset: 0x00066C5B
		' (set) Token: 0x0600EEA5 RID: 61093 RVA: 0x008F845C File Offset: 0x008F665C
		Private _TextBox79 As TextBox
		Friend Overridable Property TextBox79 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox79
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox79_TextChanged
				Dim textBox As TextBox = Me._TextBox79
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox79 = value
				textBox = Me._TextBox79
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BAA RID: 23466
		' (get) Token: 0x0600EEA6 RID: 61094 RVA: 0x00068A65 File Offset: 0x00066C65
		' (set) Token: 0x0600EEA7 RID: 61095 RVA: 0x008F84A0 File Offset: 0x008F66A0
		Private _TextBox78 As TextBox
		Friend Overridable Property TextBox78 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox78
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox78_TextChanged
				Dim textBox As TextBox = Me._TextBox78
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox78 = value
				textBox = Me._TextBox78
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BAB RID: 23467
		' (get) Token: 0x0600EEA8 RID: 61096 RVA: 0x00068A6F File Offset: 0x00066C6F
		' (set) Token: 0x0600EEA9 RID: 61097 RVA: 0x00068A79 File Offset: 0x00066C79
		Friend Overridable Property Label91 As Label

		' Token: 0x17005BAC RID: 23468
		' (get) Token: 0x0600EEAA RID: 61098 RVA: 0x00068A82 File Offset: 0x00066C82
		' (set) Token: 0x0600EEAB RID: 61099 RVA: 0x00068A8C File Offset: 0x00066C8C
		Friend Overridable Property Label92 As Label

		' Token: 0x17005BAD RID: 23469
		' (get) Token: 0x0600EEAC RID: 61100 RVA: 0x00068A95 File Offset: 0x00066C95
		' (set) Token: 0x0600EEAD RID: 61101 RVA: 0x00068A9F File Offset: 0x00066C9F
		Friend Overridable Property Label93 As Label

		' Token: 0x17005BAE RID: 23470
		' (get) Token: 0x0600EEAE RID: 61102 RVA: 0x00068AA8 File Offset: 0x00066CA8
		' (set) Token: 0x0600EEAF RID: 61103 RVA: 0x00068AB2 File Offset: 0x00066CB2
		Friend Overridable Property Label94 As Label

		' Token: 0x17005BAF RID: 23471
		' (get) Token: 0x0600EEB0 RID: 61104 RVA: 0x00068ABB File Offset: 0x00066CBB
		' (set) Token: 0x0600EEB1 RID: 61105 RVA: 0x00068AC5 File Offset: 0x00066CC5
		Friend Overridable Property TextBox81 As TextBox

		' Token: 0x17005BB0 RID: 23472
		' (get) Token: 0x0600EEB2 RID: 61106 RVA: 0x00068ACE File Offset: 0x00066CCE
		' (set) Token: 0x0600EEB3 RID: 61107 RVA: 0x00068AD8 File Offset: 0x00066CD8
		Friend Overridable Property Panel13 As Panel

		' Token: 0x17005BB1 RID: 23473
		' (get) Token: 0x0600EEB4 RID: 61108 RVA: 0x00068AE1 File Offset: 0x00066CE1
		' (set) Token: 0x0600EEB5 RID: 61109 RVA: 0x008F84E4 File Offset: 0x008F66E4
		Private _TextBox82 As TextBox
		Friend Overridable Property TextBox82 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox82
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox82_TextChanged
				Dim textBox As TextBox = Me._TextBox82
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox82 = value
				textBox = Me._TextBox82
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BB2 RID: 23474
		' (get) Token: 0x0600EEB6 RID: 61110 RVA: 0x00068AEB File Offset: 0x00066CEB
		' (set) Token: 0x0600EEB7 RID: 61111 RVA: 0x00068AF5 File Offset: 0x00066CF5
		Friend Overridable Property TextBox83 As TextBox

		' Token: 0x17005BB3 RID: 23475
		' (get) Token: 0x0600EEB8 RID: 61112 RVA: 0x00068AFE File Offset: 0x00066CFE
		' (set) Token: 0x0600EEB9 RID: 61113 RVA: 0x00068B08 File Offset: 0x00066D08
		Friend Overridable Property Label95 As Label

		' Token: 0x17005BB4 RID: 23476
		' (get) Token: 0x0600EEBA RID: 61114 RVA: 0x00068B11 File Offset: 0x00066D11
		' (set) Token: 0x0600EEBB RID: 61115 RVA: 0x008F8528 File Offset: 0x008F6728
		Private _TextBox84 As TextBox
		Friend Overridable Property TextBox84 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox84
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox84_TextChanged
				Dim textBox As TextBox = Me._TextBox84
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox84 = value
				textBox = Me._TextBox84
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BB5 RID: 23477
		' (get) Token: 0x0600EEBC RID: 61116 RVA: 0x00068B1B File Offset: 0x00066D1B
		' (set) Token: 0x0600EEBD RID: 61117 RVA: 0x00068B25 File Offset: 0x00066D25
		Friend Overridable Property Label96 As Label

		' Token: 0x17005BB6 RID: 23478
		' (get) Token: 0x0600EEBE RID: 61118 RVA: 0x00068B2E File Offset: 0x00066D2E
		' (set) Token: 0x0600EEBF RID: 61119 RVA: 0x008F856C File Offset: 0x008F676C
		Private _TextBox85 As TextBox
		Friend Overridable Property TextBox85 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox85
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox85_TextChanged
				Dim textBox As TextBox = Me._TextBox85
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox85 = value
				textBox = Me._TextBox85
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BB7 RID: 23479
		' (get) Token: 0x0600EEC0 RID: 61120 RVA: 0x00068B38 File Offset: 0x00066D38
		' (set) Token: 0x0600EEC1 RID: 61121 RVA: 0x00068B42 File Offset: 0x00066D42
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17005BB8 RID: 23480
		' (get) Token: 0x0600EEC2 RID: 61122 RVA: 0x00068B4B File Offset: 0x00066D4B
		' (set) Token: 0x0600EEC3 RID: 61123 RVA: 0x008F85B0 File Offset: 0x008F67B0
		Private _TextBox86 As TextBox
		Friend Overridable Property TextBox86 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox86
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox86_TextChanged
				Dim textBox As TextBox = Me._TextBox86
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox86 = value
				textBox = Me._TextBox86
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BB9 RID: 23481
		' (get) Token: 0x0600EEC4 RID: 61124 RVA: 0x00068B55 File Offset: 0x00066D55
		' (set) Token: 0x0600EEC5 RID: 61125 RVA: 0x00068B5F File Offset: 0x00066D5F
		Friend Overridable Property Label101 As Label

		' Token: 0x17005BBA RID: 23482
		' (get) Token: 0x0600EEC6 RID: 61126 RVA: 0x00068B68 File Offset: 0x00066D68
		' (set) Token: 0x0600EEC7 RID: 61127 RVA: 0x008F85F4 File Offset: 0x008F67F4
		Private _TextBox87 As TextBox
		Friend Overridable Property TextBox87 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox87
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox87_TextChanged
				Dim textBox As TextBox = Me._TextBox87
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox87 = value
				textBox = Me._TextBox87
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BBB RID: 23483
		' (get) Token: 0x0600EEC8 RID: 61128 RVA: 0x00068B72 File Offset: 0x00066D72
		' (set) Token: 0x0600EEC9 RID: 61129 RVA: 0x00068B7C File Offset: 0x00066D7C
		Friend Overridable Property Label102 As Label

		' Token: 0x17005BBC RID: 23484
		' (get) Token: 0x0600EECA RID: 61130 RVA: 0x00068B85 File Offset: 0x00066D85
		' (set) Token: 0x0600EECB RID: 61131 RVA: 0x008F8638 File Offset: 0x008F6838
		Private _TextBox88 As TextBox
		Friend Overridable Property TextBox88 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox88
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox88_TextChanged
				Dim textBox As TextBox = Me._TextBox88
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox88 = value
				textBox = Me._TextBox88
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BBD RID: 23485
		' (get) Token: 0x0600EECC RID: 61132 RVA: 0x00068B8F File Offset: 0x00066D8F
		' (set) Token: 0x0600EECD RID: 61133 RVA: 0x00068B99 File Offset: 0x00066D99
		Friend Overridable Property Label67 As Label

		' Token: 0x17005BBE RID: 23486
		' (get) Token: 0x0600EECE RID: 61134 RVA: 0x00068BA2 File Offset: 0x00066DA2
		' (set) Token: 0x0600EECF RID: 61135 RVA: 0x00068BAC File Offset: 0x00066DAC
		Friend Overridable Property Label68 As Label

		' Token: 0x17005BBF RID: 23487
		' (get) Token: 0x0600EED0 RID: 61136 RVA: 0x00068BB5 File Offset: 0x00066DB5
		' (set) Token: 0x0600EED1 RID: 61137 RVA: 0x008F867C File Offset: 0x008F687C
		Private _TextBox89 As TextBox
		Friend Overridable Property TextBox89 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox89
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox89_TextChanged
				Dim textBox As TextBox = Me._TextBox89
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox89 = value
				textBox = Me._TextBox89
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BC0 RID: 23488
		' (get) Token: 0x0600EED2 RID: 61138 RVA: 0x00068BBF File Offset: 0x00066DBF
		' (set) Token: 0x0600EED3 RID: 61139 RVA: 0x008F86C0 File Offset: 0x008F68C0
		Private _TextBox90 As TextBox
		Friend Overridable Property TextBox90 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox90
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox90_TextChanged
				Dim textBox As TextBox = Me._TextBox90
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox90 = value
				textBox = Me._TextBox90
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BC1 RID: 23489
		' (get) Token: 0x0600EED4 RID: 61140 RVA: 0x00068BC9 File Offset: 0x00066DC9
		' (set) Token: 0x0600EED5 RID: 61141 RVA: 0x00068BD3 File Offset: 0x00066DD3
		Friend Overridable Property Label69 As Label

		' Token: 0x17005BC2 RID: 23490
		' (get) Token: 0x0600EED6 RID: 61142 RVA: 0x00068BDC File Offset: 0x00066DDC
		' (set) Token: 0x0600EED7 RID: 61143 RVA: 0x00068BE6 File Offset: 0x00066DE6
		Friend Overridable Property Label71 As Label

		' Token: 0x17005BC3 RID: 23491
		' (get) Token: 0x0600EED8 RID: 61144 RVA: 0x00068BEF File Offset: 0x00066DEF
		' (set) Token: 0x0600EED9 RID: 61145 RVA: 0x008F8704 File Offset: 0x008F6904
		Private _TextBox91 As TextBox
		Friend Overridable Property TextBox91 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox91
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox91_TextChanged
				Dim textBox As TextBox = Me._TextBox91
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox91 = value
				textBox = Me._TextBox91
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BC4 RID: 23492
		' (get) Token: 0x0600EEDA RID: 61146 RVA: 0x00068BF9 File Offset: 0x00066DF9
		' (set) Token: 0x0600EEDB RID: 61147 RVA: 0x00068C03 File Offset: 0x00066E03
		Friend Overridable Property Label72 As Label

		' Token: 0x17005BC5 RID: 23493
		' (get) Token: 0x0600EEDC RID: 61148 RVA: 0x00068C0C File Offset: 0x00066E0C
		' (set) Token: 0x0600EEDD RID: 61149 RVA: 0x00068C16 File Offset: 0x00066E16
		Friend Overridable Property Label73 As Label

		' Token: 0x17005BC6 RID: 23494
		' (get) Token: 0x0600EEDE RID: 61150 RVA: 0x00068C1F File Offset: 0x00066E1F
		' (set) Token: 0x0600EEDF RID: 61151 RVA: 0x008F8748 File Offset: 0x008F6948
		Private _TextBox92 As TextBox
		Friend Overridable Property TextBox92 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox92
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox92_TextChanged
				Dim textBox As TextBox = Me._TextBox92
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox92 = value
				textBox = Me._TextBox92
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BC7 RID: 23495
		' (get) Token: 0x0600EEE0 RID: 61152 RVA: 0x00068C29 File Offset: 0x00066E29
		' (set) Token: 0x0600EEE1 RID: 61153 RVA: 0x008F878C File Offset: 0x008F698C
		Private _TextBox93 As TextBox
		Friend Overridable Property TextBox93 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox93
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox93_TextChanged
				Dim textBox As TextBox = Me._TextBox93
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox93 = value
				textBox = Me._TextBox93
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BC8 RID: 23496
		' (get) Token: 0x0600EEE2 RID: 61154 RVA: 0x00068C33 File Offset: 0x00066E33
		' (set) Token: 0x0600EEE3 RID: 61155 RVA: 0x00068C3D File Offset: 0x00066E3D
		Friend Overridable Property Label51 As Label

		' Token: 0x17005BC9 RID: 23497
		' (get) Token: 0x0600EEE4 RID: 61156 RVA: 0x00068C46 File Offset: 0x00066E46
		' (set) Token: 0x0600EEE5 RID: 61157 RVA: 0x00068C50 File Offset: 0x00066E50
		Friend Overridable Property Label81 As Label

		' Token: 0x17005BCA RID: 23498
		' (get) Token: 0x0600EEE6 RID: 61158 RVA: 0x00068C59 File Offset: 0x00066E59
		' (set) Token: 0x0600EEE7 RID: 61159 RVA: 0x008F87D0 File Offset: 0x008F69D0
		Private _TextBox94 As TextBox
		Friend Overridable Property TextBox94 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox94
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox94_TextChanged
				Dim textBox As TextBox = Me._TextBox94
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox94 = value
				textBox = Me._TextBox94
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BCB RID: 23499
		' (get) Token: 0x0600EEE8 RID: 61160 RVA: 0x00068C63 File Offset: 0x00066E63
		' (set) Token: 0x0600EEE9 RID: 61161 RVA: 0x008F8814 File Offset: 0x008F6A14
		Private _TextBox95 As TextBox
		Friend Overridable Property TextBox95 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox95
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox95_TextChanged
				Dim textBox As TextBox = Me._TextBox95
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox95 = value
				textBox = Me._TextBox95
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BCC RID: 23500
		' (get) Token: 0x0600EEEA RID: 61162 RVA: 0x00068C6D File Offset: 0x00066E6D
		' (set) Token: 0x0600EEEB RID: 61163 RVA: 0x00068C77 File Offset: 0x00066E77
		Friend Overridable Property Label62 As Label

		' Token: 0x17005BCD RID: 23501
		' (get) Token: 0x0600EEEC RID: 61164 RVA: 0x00068C80 File Offset: 0x00066E80
		' (set) Token: 0x0600EEED RID: 61165 RVA: 0x00068C8A File Offset: 0x00066E8A
		Friend Overridable Property Label97 As Label

		' Token: 0x17005BCE RID: 23502
		' (get) Token: 0x0600EEEE RID: 61166 RVA: 0x00068C93 File Offset: 0x00066E93
		' (set) Token: 0x0600EEEF RID: 61167 RVA: 0x00068C9D File Offset: 0x00066E9D
		Friend Overridable Property Label98 As Label

		' Token: 0x17005BCF RID: 23503
		' (get) Token: 0x0600EEF0 RID: 61168 RVA: 0x00068CA6 File Offset: 0x00066EA6
		' (set) Token: 0x0600EEF1 RID: 61169 RVA: 0x008F8858 File Offset: 0x008F6A58
		Private _TextBox96 As TextBox
		Friend Overridable Property TextBox96 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox96
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox96_TextChanged
				Dim textBox As TextBox = Me._TextBox96
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox96 = value
				textBox = Me._TextBox96
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD0 RID: 23504
		' (get) Token: 0x0600EEF2 RID: 61170 RVA: 0x00068CB0 File Offset: 0x00066EB0
		' (set) Token: 0x0600EEF3 RID: 61171 RVA: 0x008F889C File Offset: 0x008F6A9C
		Private _TextBox97 As TextBox
		Friend Overridable Property TextBox97 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox97
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox97_TextChanged
				Dim textBox As TextBox = Me._TextBox97
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox97 = value
				textBox = Me._TextBox97
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD1 RID: 23505
		' (get) Token: 0x0600EEF4 RID: 61172 RVA: 0x00068CBA File Offset: 0x00066EBA
		' (set) Token: 0x0600EEF5 RID: 61173 RVA: 0x008F88E0 File Offset: 0x008F6AE0
		Private _TextBox103 As TextBox
		Friend Overridable Property TextBox103 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox103
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox103_TextChanged
				Dim textBox As TextBox = Me._TextBox103
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox103 = value
				textBox = Me._TextBox103
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD2 RID: 23506
		' (get) Token: 0x0600EEF6 RID: 61174 RVA: 0x00068CC4 File Offset: 0x00066EC4
		' (set) Token: 0x0600EEF7 RID: 61175 RVA: 0x008F8924 File Offset: 0x008F6B24
		Private _TextBox102 As TextBox
		Friend Overridable Property TextBox102 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox102
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox102_TextChanged
				Dim textBox As TextBox = Me._TextBox102
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox102 = value
				textBox = Me._TextBox102
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD3 RID: 23507
		' (get) Token: 0x0600EEF8 RID: 61176 RVA: 0x00068CCE File Offset: 0x00066ECE
		' (set) Token: 0x0600EEF9 RID: 61177 RVA: 0x008F8968 File Offset: 0x008F6B68
		Private _TextBox101 As TextBox
		Friend Overridable Property TextBox101 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox101
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox101_TextChanged
				Dim textBox As TextBox = Me._TextBox101
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox101 = value
				textBox = Me._TextBox101
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD4 RID: 23508
		' (get) Token: 0x0600EEFA RID: 61178 RVA: 0x00068CD8 File Offset: 0x00066ED8
		' (set) Token: 0x0600EEFB RID: 61179 RVA: 0x008F89AC File Offset: 0x008F6BAC
		Private _TextBox100 As TextBox
		Friend Overridable Property TextBox100 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox100
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox100_TextChanged
				Dim textBox As TextBox = Me._TextBox100
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox100 = value
				textBox = Me._TextBox100
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD5 RID: 23509
		' (get) Token: 0x0600EEFC RID: 61180 RVA: 0x00068CE2 File Offset: 0x00066EE2
		' (set) Token: 0x0600EEFD RID: 61181 RVA: 0x008F89F0 File Offset: 0x008F6BF0
		Private _TextBox99 As TextBox
		Friend Overridable Property TextBox99 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox99
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox99_TextChanged
				Dim textBox As TextBox = Me._TextBox99
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox99 = value
				textBox = Me._TextBox99
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD6 RID: 23510
		' (get) Token: 0x0600EEFE RID: 61182 RVA: 0x00068CEC File Offset: 0x00066EEC
		' (set) Token: 0x0600EEFF RID: 61183 RVA: 0x008F8A34 File Offset: 0x008F6C34
		Private _TextBox98 As TextBox
		Friend Overridable Property TextBox98 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox98
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox98_TextChanged
				Dim textBox As TextBox = Me._TextBox98
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox98 = value
				textBox = Me._TextBox98
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BD7 RID: 23511
		' (get) Token: 0x0600EF00 RID: 61184 RVA: 0x00068CF6 File Offset: 0x00066EF6
		' (set) Token: 0x0600EF01 RID: 61185 RVA: 0x00068D00 File Offset: 0x00066F00
		Friend Overridable Property Label99 As Label

		' Token: 0x17005BD8 RID: 23512
		' (get) Token: 0x0600EF02 RID: 61186 RVA: 0x00068D09 File Offset: 0x00066F09
		' (set) Token: 0x0600EF03 RID: 61187 RVA: 0x00068D13 File Offset: 0x00066F13
		Friend Overridable Property Label100 As Label

		' Token: 0x17005BD9 RID: 23513
		' (get) Token: 0x0600EF04 RID: 61188 RVA: 0x00068D1C File Offset: 0x00066F1C
		' (set) Token: 0x0600EF05 RID: 61189 RVA: 0x00068D26 File Offset: 0x00066F26
		Friend Overridable Property Label103 As Label

		' Token: 0x17005BDA RID: 23514
		' (get) Token: 0x0600EF06 RID: 61190 RVA: 0x00068D2F File Offset: 0x00066F2F
		' (set) Token: 0x0600EF07 RID: 61191 RVA: 0x00068D39 File Offset: 0x00066F39
		Friend Overridable Property Label104 As Label

		' Token: 0x17005BDB RID: 23515
		' (get) Token: 0x0600EF08 RID: 61192 RVA: 0x00068D42 File Offset: 0x00066F42
		' (set) Token: 0x0600EF09 RID: 61193 RVA: 0x00068D4C File Offset: 0x00066F4C
		Friend Overridable Property Label105 As Label

		' Token: 0x17005BDC RID: 23516
		' (get) Token: 0x0600EF0A RID: 61194 RVA: 0x00068D55 File Offset: 0x00066F55
		' (set) Token: 0x0600EF0B RID: 61195 RVA: 0x00068D5F File Offset: 0x00066F5F
		Friend Overridable Property Label106 As Label

		' Token: 0x17005BDD RID: 23517
		' (get) Token: 0x0600EF0C RID: 61196 RVA: 0x00068D68 File Offset: 0x00066F68
		' (set) Token: 0x0600EF0D RID: 61197 RVA: 0x008F8A78 File Offset: 0x008F6C78
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BDE RID: 23518
		' (get) Token: 0x0600EF0E RID: 61198 RVA: 0x00068D72 File Offset: 0x00066F72
		' (set) Token: 0x0600EF0F RID: 61199 RVA: 0x008F8ABC File Offset: 0x008F6CBC
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

		' Token: 0x17005BDF RID: 23519
		' (get) Token: 0x0600EF10 RID: 61200 RVA: 0x00068D7C File Offset: 0x00066F7C
		' (set) Token: 0x0600EF11 RID: 61201 RVA: 0x008F8B00 File Offset: 0x008F6D00
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

		' Token: 0x17005BE0 RID: 23520
		' (get) Token: 0x0600EF12 RID: 61202 RVA: 0x00068D86 File Offset: 0x00066F86
		' (set) Token: 0x0600EF13 RID: 61203 RVA: 0x008F8B44 File Offset: 0x008F6D44
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BE1 RID: 23521
		' (get) Token: 0x0600EF14 RID: 61204 RVA: 0x00068D90 File Offset: 0x00066F90
		' (set) Token: 0x0600EF15 RID: 61205 RVA: 0x008F8B88 File Offset: 0x008F6D88
		Private _Button7 As Button
		Friend Overridable Property Button7 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
				Dim button As Button = Me._Button7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button7 = value
				button = Me._Button7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BE2 RID: 23522
		' (get) Token: 0x0600EF16 RID: 61206 RVA: 0x00068D9A File Offset: 0x00066F9A
		' (set) Token: 0x0600EF17 RID: 61207 RVA: 0x008F8BCC File Offset: 0x008F6DCC
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

		' Token: 0x17005BE3 RID: 23523
		' (get) Token: 0x0600EF18 RID: 61208 RVA: 0x00068DA4 File Offset: 0x00066FA4
		' (set) Token: 0x0600EF19 RID: 61209 RVA: 0x008F8C10 File Offset: 0x008F6E10
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

		' Token: 0x0600EF1A RID: 61210 RVA: 0x008F8C54 File Offset: 0x008F6E54
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DateTimePicker1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600EF1B RID: 61211 RVA: 0x008F8D30 File Offset: 0x008F6F30
		Private Sub frmBalancesheet_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.a1()
			Me.b1()
			Me.b1d1()
			Me.b1d2()
			Me.c1()
			Me.c100()
			Me.d1()
			Me.d100()
			Me.e1()
			Me.f1()
			Me.f100()
			Me.g1()
			Me.h1()
			Me.h100()
			Me.i1()
			Me.i1d1()
			Me.i11()
			Me.i11d2()
			Me.i111()
			Me.i111D3()
			Me.j1()
			Me.l1()
			Me.m1()
			Me.m1d1()
			Me.m11()
			Me.m11d1()
			Me.m111()
			Me.m111d1()
			Me.PurchaseRCM()
			Me.Rcptbybank()
			Me.Rcptbybank1()
			Me.Rcptbybank2()
			Me.h123()
			Me.h124()
			Me.f11()
			Me.f12()
			Me.purrcm()
			Me.purrcmtb49()
			Me.d1pr()
			Me.d2pr()
			Me.salertnforcash()
			Me.purchasertncash()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600EF1C RID: 61212 RVA: 0x008F8E84 File Offset: 0x008F7084
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

		' Token: 0x0600EF1D RID: 61213 RVA: 0x008F8FFC File Offset: 0x008F71FC
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

		' Token: 0x0600EF1E RID: 61214 RVA: 0x008F90B8 File Offset: 0x008F72B8
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

		' Token: 0x0600EF1F RID: 61215 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600EF20 RID: 61216 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600EF21 RID: 61217 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600EF22 RID: 61218 RVA: 0x008F9184 File Offset: 0x008F7384
		Private Sub a1()
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.TextBox4.Text = ""
			Me.TextBox5.Text = ""
			Me.TextBox69.Text = ""
			Me.TextBox6.Text = ""
			Me.TextBox7.Text = ""
			Me.TextBox8.Text = ""
			Me.TextBox9.Text = ""
			Me.TextBox73.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)+Sum(FreightCharges)+Sum(Roundoff))+Sum(OtherCharges)), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), Sum(GrandTotal), Sum(TotalPaid) from invoiceinfo where invoicedate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox1.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox2.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox3.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox4.Text = Conversions.ToString(Me.rdr1.GetValue(3))
					Me.TextBox5.Text = Conversions.ToString(Me.rdr1.GetValue(4))
					Me.TextBox69.Text = Conversions.ToString(Me.rdr1.GetValue(4))
					Me.TextBox6.Text = Conversions.ToString(Me.rdr1.GetValue(5))
					Me.TextBox7.Text = Conversions.ToString(Me.rdr1.GetValue(6))
					Me.TextBox8.Text = Conversions.ToString(Me.rdr1.GetValue(7))
					Me.TextBox9.Text = Conversions.ToString(Me.rdr1.GetValue(8))
					Me.TextBox73.Text = Conversions.ToString(Me.rdr1.GetValue(9))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text), 2), "0.00")
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox6.Text), 2), "0.00")
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
			Me.TextBox8.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox8.Text), 2), "0.00")
			Me.TextBox9.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text), 2), "0.00")
			Me.TextBox73.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox73.Text), 2), "0.00")
			Me.TextBox69.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox69.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF23 RID: 61219 RVA: 0x008F96B8 File Offset: 0x008F78B8
		Private Sub b1()
			Me.TextBox13.Text = ""
			Me.TextBox12.Text = ""
			Me.TextBox11.Text = ""
			Me.TextBox10.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)+Sum(FreightCharges)+Sum(Roundoff))-(Sum(OtherCharges))), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), (Sum(GrandTotal)-Sum(PreviousDue)), Sum(TotalPayment) from stock where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox13.Text = Conversions.ToString(Me.rdr1.GetValue(5))
					Me.TextBox12.Text = Conversions.ToString(Me.rdr1.GetValue(6))
					Me.TextBox11.Text = Conversions.ToString(Me.rdr1.GetValue(7))
					Me.TextBox10.Text = Conversions.ToString(Me.rdr1.GetValue(8))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox18.Text), 2), "0.00")
			Me.TextBox13.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text), 2), "0.00")
			Me.TextBox12.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text), 2), "0.00")
			Me.TextBox11.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text), 2), "0.00")
			Me.TextBox10.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF24 RID: 61220 RVA: 0x008F9980 File Offset: 0x008F7B80
		Private Sub purrcm()
			Me.TextBox17.Text = ""
			Me.TextBox16.Text = ""
			Me.TextBox15.Text = ""
			Me.TextBox14.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS) from stock where ReferenceNo2='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox17.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox16.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox15.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox14.Text = Conversions.ToString(Me.rdr1.GetValue(3))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox17.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox17.Text), 2), "0.00")
			Me.TextBox16.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox16.Text), 2), "0.00")
			Me.TextBox15.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text), 2), "0.00")
			Me.TextBox14.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF25 RID: 61221 RVA: 0x008F9C18 File Offset: 0x008F7E18
		Private Sub purrcmtb49()
			Me.TextBox49.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from stock where ReferenceNo2='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox49.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox49.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox49.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF26 RID: 61222 RVA: 0x008F9D90 File Offset: 0x008F7F90
		Private Sub f11()
			Me.TextBox66.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(CESS) from stock where ReferenceNo2='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox66.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox66.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox66.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF27 RID: 61223 RVA: 0x008F9F08 File Offset: 0x008F8108
		Private Sub f12()
			Me.TextBox74.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(CESS) from stock where ReferenceNo2='Yes' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox74.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox74.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox74.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF28 RID: 61224 RVA: 0x008FA080 File Offset: 0x008F8280
		Private Sub salertnforcash()
			Me.TextBox82.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(GrandTotal) from SalesReturn where PaymentMode='Cash' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox82.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox82.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox82.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF29 RID: 61225 RVA: 0x008FA1F8 File Offset: 0x008F83F8
		Private Sub c1()
			Me.TextBox27.Text = ""
			Me.TextBox26.Text = ""
			Me.TextBox25.Text = ""
			Me.TextBox24.Text = ""
			Me.TextBox23.Text = ""
			Me.TextBox68.Text = ""
			Me.TextBox22.Text = ""
			Me.TextBox21.Text = ""
			Me.TextBox20.Text = ""
			Me.TextBox19.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(SubTotal), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), Sum(GrandTotal) from SalesReturn where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox27.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox26.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox25.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox24.Text = Conversions.ToString(Me.rdr1.GetValue(3))
					Me.TextBox23.Text = Conversions.ToString(Me.rdr1.GetValue(4))
					Me.TextBox68.Text = Conversions.ToString(Me.rdr1.GetValue(4))
					Me.TextBox22.Text = Conversions.ToString(Me.rdr1.GetValue(5))
					Me.TextBox21.Text = Conversions.ToString(Me.rdr1.GetValue(6))
					Me.TextBox20.Text = Conversions.ToString(Me.rdr1.GetValue(7))
					Me.TextBox19.Text = Conversions.ToString(Me.rdr1.GetValue(8))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox19.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text), 2), "0.00")
			Me.TextBox20.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox20.Text), 2), "0.00")
			Me.TextBox21.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox21.Text), 2), "0.00")
			Me.TextBox22.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox22.Text), 2), "0.00")
			Me.TextBox23.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox23.Text), 2), "0.00")
			Me.TextBox24.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text), 2), "0.00")
			Me.TextBox25.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox25.Text), 2), "0.00")
			Me.TextBox26.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text), 2), "0.00")
			Me.TextBox27.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox27.Text), 2), "0.00")
			Me.TextBox68.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox68.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2A RID: 61226 RVA: 0x008FA6CC File Offset: 0x008F88CC
		Private Sub c100()
			Me.TextBox48.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(SubTotal), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), Sum(GrandTotal) from SalesReturn where PaymentMode='Cash' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox48.Text = Conversions.ToString(Me.rdr1.GetValue(8))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox48.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox48.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2B RID: 61227 RVA: 0x008FA844 File Offset: 0x008F8A44
		Private Sub purchasertncash()
			Me.TextBox83.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(GrandTotal) from PurchaseReturn where PaymentMode='Cash' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox83.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox83.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2C RID: 61228 RVA: 0x008FA9BC File Offset: 0x008F8BBC
		Private Sub d1()
			Me.TextBox70.Text = ""
			Me.TextBox35.Text = ""
			Me.TextBox32.Text = ""
			Me.TextBox31.Text = ""
			Me.TextBox28.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(SubTotal), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), Sum(GrandTotal) from PurchaseReturn where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox70.Text = Conversions.ToString(Me.rdr1.GetValue(4))
					Me.TextBox35.Text = Conversions.ToString(Me.rdr1.GetValue(5))
					Me.TextBox32.Text = Conversions.ToString(Me.rdr1.GetValue(6))
					Me.TextBox31.Text = Conversions.ToString(Me.rdr1.GetValue(7))
					Me.TextBox28.Text = Conversions.ToString(Me.rdr1.GetValue(8))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox35.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox35.Text), 2), "0.00")
			Me.TextBox32.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox32.Text), 2), "0.00")
			Me.TextBox31.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox31.Text), 2), "0.00")
			Me.TextBox28.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text), 2), "0.00")
			Me.TextBox70.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox70.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2D RID: 61229 RVA: 0x008FACB8 File Offset: 0x008F8EB8
		Private Sub d100()
			Me.TextBox63.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(SubTotal), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), Sum(GrandTotal) from PurchaseReturn where PaymentMode='Cash' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox63.Text = Conversions.ToString(Me.rdr1.GetValue(8))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox63.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox63.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2E RID: 61230 RVA: 0x008FAE30 File Offset: 0x008F9030
		Private Sub d1pr()
			Me.TextBox30.Text = ""
			Me.TextBox33.Text = ""
			Me.TextBox34.Text = ""
			Me.TextBox36.Text = ""
			Me.TextBox55.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS),(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)),(Sum(CGST)+Sum(SGST)+Sum(IGST))  from PurchaseReturn where RCM='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox30.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox33.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox34.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox36.Text = Conversions.ToString(Me.rdr1.GetValue(3))
					Me.TextBox55.Text = Conversions.ToString(Me.rdr1.GetValue(5))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox30.Text), 2), "0.00")
			Me.TextBox33.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox33.Text), 2), "0.00")
			Me.TextBox34.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox34.Text), 2), "0.00")
			Me.TextBox36.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox36.Text), 2), "0.00")
			Me.TextBox55.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox55.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF2F RID: 61231 RVA: 0x008FB12C File Offset: 0x008F932C
		Private Sub d2pr()
			Me.TextBox81.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS) from PurchaseReturn where RCM='Yes' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox81.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox81.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox81.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF30 RID: 61232 RVA: 0x008FB2A4 File Offset: 0x008F94A4
		Private Sub e1()
			Me.TextBox38.Text = ""
			Me.TextBox42.Text = ""
			Me.TextBox67.Text = ""
			Me.TextBox37.Text = ""
			Me.TextBox47.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(RepairCharges)-Sum(Upfront)), Sum(Upfront), Sum(ServiceTax), (Sum(Upfront)+Sum(GrandTotal)), Sum(TotalPaid) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox38.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox42.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox67.Text = Conversions.ToString(Me.rdr1.GetValue(2))
					Me.TextBox37.Text = Conversions.ToString(Me.rdr1.GetValue(3))
					Me.TextBox47.Text = Conversions.ToString(Me.rdr1.GetValue(4))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox38.Text), 2), "0.00")
			Me.TextBox42.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox42.Text), 2), "0.00")
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox37.Text), 2), "0.00")
			Me.TextBox47.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox47.Text), 2), "0.00")
			Me.TextBox67.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox67.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF31 RID: 61233 RVA: 0x008FB5A0 File Offset: 0x008F97A0
		Private Sub f1()
			Me.TextBox41.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from CreditCustomerPayment where PaymentMode='By Cash' and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox41.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox41.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox41.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF32 RID: 61234 RVA: 0x008FB718 File Offset: 0x008F9918
		Private Sub f100()
			Me.TextBox84.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from CreditCustomerPayment where not PaymentMode='By Cash' and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox84.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox84.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox84.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF33 RID: 61235 RVA: 0x008FB890 File Offset: 0x008F9A90
		Private Sub g1()
			Me.TextBox39.Text = ""
			Me.TextBox45.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(AdvanceDeposit) from Service where ServiceCreationDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox39.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox45.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox39.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text), 2), "0.00")
			Me.TextBox45.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF34 RID: 61236 RVA: 0x008FBA68 File Offset: 0x008F9C68
		Private Sub h1()
			Me.TextBox50.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Payment where PaymentMode='By Cash' and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox50.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox50.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox50.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF35 RID: 61237 RVA: 0x008FBBE0 File Offset: 0x008F9DE0
		Private Sub h100()
			Me.TextBox85.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Payment where not PaymentMode='By Cash' and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox85.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox85.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox85.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF36 RID: 61238 RVA: 0x008FBD58 File Offset: 0x008F9F58
		Private Sub i1()
			Me.TextBox78.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Fixed Assets') and Date between @f1  And  @f2 and PModeD='Cash'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox78.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox78.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox78.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF37 RID: 61239 RVA: 0x008FBED0 File Offset: 0x008FA0D0
		Private Sub i1d1()
			Me.TextBox96.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Fixed Assets') and Date between @f1  And  @f2 and PModeD='Bank'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox96.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox96.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox96.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF38 RID: 61240 RVA: 0x008FC048 File Offset: 0x008FA248
		Private Sub i11()
			Me.TextBox79.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Loan & Advance (Assets)') and Date between @f1  And  @f2 and PModeD='Cash'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox79.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox79.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox79.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF39 RID: 61241 RVA: 0x008FC1C0 File Offset: 0x008FA3C0
		Private Sub i11d2()
			Me.TextBox97.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Loan & Advance (Assets)') and Date between @f1  And  @f2 and PModeD='Bank'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox97.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox97.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox97.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF3A RID: 61242 RVA: 0x008FC338 File Offset: 0x008FA538
		Private Sub i111()
			Me.TextBox80.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note not in ('Goods and Services Tax','Loan & Advance (Assets)','Fixed Assets') and Date between @f1  And  @f2 and PModeD='Cash'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox80.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox80.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox80.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF3B RID: 61243 RVA: 0x008FC4B0 File Offset: 0x008FA6B0
		Private Sub i111D3()
			Me.TextBox95.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note not in ('Goods and Services Tax','Loan & Advance (Assets)','Fixed Assets') and Date between @f1  And  @f2 and PModeD='Bank'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox95.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox95.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox95.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF3C RID: 61244 RVA: 0x008FC628 File Offset: 0x008FA828
		Private Sub j1()
			Me.TextBox62.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note not in ('Goods and Services Tax','Loan & Advance (Assets)','Fixed Assets') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox62.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox62.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox62.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF3D RID: 61245 RVA: 0x008FC7A0 File Offset: 0x008FA9A0
		Private Sub l1()
			Me.TextBox64.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Goods and Services Tax') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox64.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox64.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox64.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF3E RID: 61246 RVA: 0x008FC918 File Offset: 0x008FAB18
		Private Sub m1()
			Me.TextBox77.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Income (Direct/Indirect)') and Date between @f1  And  @f2 and PModeD='Cash'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox77.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox77.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox77.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF3F RID: 61247 RVA: 0x008FCAC0 File Offset: 0x008FACC0
		Private Sub m1d1()
			Me.TextBox91.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Income (Direct/Indirect)') and Date between @f1  And  @f2 and PModeD='Bank'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox91.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox91.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox91.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF40 RID: 61248 RVA: 0x008FCC68 File Offset: 0x008FAE68
		Private Sub m11()
			Me.TextBox75.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Loan (Liability)') and Date between @f1  And  @f2 and PModeD='Cash'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox75.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox75.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox75.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF41 RID: 61249 RVA: 0x008FCE10 File Offset: 0x008FB010
		Private Sub m11d1()
			Me.TextBox93.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Loan (Liability)') and Date between @f1  And  @f2 and PModeD='Bank'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox93.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox93.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox93.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF42 RID: 61250 RVA: 0x008FCFB8 File Offset: 0x008FB1B8
		Private Sub m111()
			Me.TextBox76.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Capital Account') and Date between @f1  And  @f2 and PModeD='Cash'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox76.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox76.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox76.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF43 RID: 61251 RVA: 0x008FD160 File Offset: 0x008FB360
		Private Sub m111d1()
			Me.TextBox92.Text = ""
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Capital Account') and Date between @f1  And  @f2 and PModeD='Bank'"
				Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
				Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
				Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = Me.rdr1.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
					If flag3 Then
						Me.TextBox92.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					End If
				End If
				ModCommonClasses.con.Close()
				Me.TextBox92.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox92.Text), 2), "0.00")
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600EF44 RID: 61252 RVA: 0x008FD308 File Offset: 0x008FB508
		Private Sub PurchaseRCM()
			Me.TextBox71.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Stock_Product.CGSTAmt)+Sum(Stock_Product.SGSTAmt)+Sum(Stock_Product.IGSTAmt)) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID  where ReferenceNo2='Yes' and Stock.Date between @f1 and @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox71.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox71.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox71.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF45 RID: 61253 RVA: 0x008FD480 File Offset: 0x008FB680
		Private Sub Rcptbybank()
			Me.Label83.Text = "0.00"
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from CustomerLedgerBook where Name='Bank Account' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.Label83.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.Label83.Text = Strings.Format(Math.Round(Conversion.Val(Me.Label83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF46 RID: 61254 RVA: 0x008FD5F8 File Offset: 0x008FB7F8
		Private Sub Rcptbybank1()
			Me.TextBox72.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(TotalPaid) from Invoice_Payment where PaymentMode in ('By Cheque','By Credit Card','By Debit Card','PhonePe','Google Pay','Paytm','E-Wallet') and PaymentDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox72.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox72.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox72.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF47 RID: 61255 RVA: 0x008FD770 File Offset: 0x008FB970
		Private Sub Rcptbybank2()
			Me.TextBox44.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(TotalPaid) from Invoice_Payment where PaymentMode in ('By Cash') and PaymentDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox44.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox44.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF48 RID: 61256 RVA: 0x008FD8E8 File Offset: 0x008FBAE8
		Private Sub h123()
			Me.TextBox86.Text = ""
			Me.adv = 0.0
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from AdvanceEntry where Workingdate  between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.adv = Conversions.ToDouble(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.emppay = 0.0
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "SELECT Sum(NetPay) from EmployeePayment where Modeofpayment in ('By Cash') and Paymentdate  between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text2, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag4 As Boolean = Me.rdr1.Read()
			Dim flag5 As Boolean = flag4
			If flag5 Then
				Dim flag6 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag6 Then
					Me.emppay = Conversions.ToDouble(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox86.Text = Conversions.ToString(Me.adv + Me.emppay)
			Me.TextBox86.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox86.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF49 RID: 61257 RVA: 0x008FDBC0 File Offset: 0x008FBDC0
		Private Sub h124()
			Me.TextBox87.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(NetPay) from EmployeePayment where Modeofpayment not in ('By Cash') and Paymentdate  between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox87.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox87.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox87.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF4A RID: 61258 RVA: 0x008FDD38 File Offset: 0x008FBF38
		Private Sub TextBox46_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) + Conversion.Val(Me.TextBox45.Text) + Conversion.Val(Me.TextBox47.Text) + Conversion.Val(Me.TextBox41.Text) + Conversion.Val(Me.TextBox83.Text), 2), "0.00")
			Me.TextBox103.Text = Conversions.ToString(Conversion.Val(Me.TextBox90.Text) + Conversion.Val(Me.TextBox46.Text))
		End Sub

		' Token: 0x0600EF4B RID: 61259 RVA: 0x008FDDF0 File Offset: 0x008FBFF0
		Private Sub TextBox41_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) + Conversion.Val(Me.TextBox45.Text) + Conversion.Val(Me.TextBox47.Text) + Conversion.Val(Me.TextBox41.Text) + Conversion.Val(Me.TextBox83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF4C RID: 61260 RVA: 0x008FDDF0 File Offset: 0x008FBFF0
		Private Sub TextBox47_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) + Conversion.Val(Me.TextBox45.Text) + Conversion.Val(Me.TextBox47.Text) + Conversion.Val(Me.TextBox41.Text) + Conversion.Val(Me.TextBox83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF4D RID: 61261 RVA: 0x008FDDF0 File Offset: 0x008FBFF0
		Private Sub TextBox45_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) + Conversion.Val(Me.TextBox45.Text) + Conversion.Val(Me.TextBox47.Text) + Conversion.Val(Me.TextBox41.Text) + Conversion.Val(Me.TextBox83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF4E RID: 61262 RVA: 0x008FDDF0 File Offset: 0x008FBFF0
		Private Sub TextBox44_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) + Conversion.Val(Me.TextBox45.Text) + Conversion.Val(Me.TextBox47.Text) + Conversion.Val(Me.TextBox41.Text) + Conversion.Val(Me.TextBox83.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF4F RID: 61263 RVA: 0x008FDE74 File Offset: 0x008FC074
		Private Sub TextBox51_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox51.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox50.Text) + Conversion.Val(Me.TextBox82.Text) + Conversion.Val(Me.TextBox40.Text), 2), "0.00")
			Me.TextBox102.Text = Conversions.ToString(Conversion.Val(Me.TextBox89.Text) + Conversion.Val(Me.TextBox51.Text))
		End Sub

		' Token: 0x0600EF50 RID: 61264 RVA: 0x008FDF08 File Offset: 0x008FC108
		Private Sub TextBox50_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox51.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox50.Text) + Conversion.Val(Me.TextBox82.Text) + Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF51 RID: 61265 RVA: 0x008FDF08 File Offset: 0x008FC108
		Private Sub TextBox40_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox51.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox50.Text) + Conversion.Val(Me.TextBox82.Text) + Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF52 RID: 61266 RVA: 0x008FDF08 File Offset: 0x008FC108
		Private Sub TextBox82_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox51.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox50.Text) + Conversion.Val(Me.TextBox82.Text) + Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF53 RID: 61267 RVA: 0x008FDF6C File Offset: 0x008FC16C
		Private Sub TextBox54_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox54.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text), 2), "0.00")
			Me.compute()
		End Sub

		' Token: 0x0600EF54 RID: 61268 RVA: 0x008FDFD4 File Offset: 0x008FC1D4
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox54.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text))
			Me.TextBox57.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text) - (Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF55 RID: 61269 RVA: 0x008FDFD4 File Offset: 0x008FC1D4
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox54.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text))
			Me.TextBox57.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text) - (Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF56 RID: 61270 RVA: 0x008FDFD4 File Offset: 0x008FC1D4
		Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox54.Text = Conversions.ToString(Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text))
			Me.TextBox57.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text) - (Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF57 RID: 61271 RVA: 0x008FE09C File Offset: 0x008FC29C
		Private Sub TextBox53_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox53.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text), 2), "0.00")
			Me.compute()
		End Sub

		' Token: 0x0600EF58 RID: 61272 RVA: 0x008FE104 File Offset: 0x008FC304
		Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox53.Text = Conversions.ToString(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text))
			Me.TextBox58.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text) - (Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF59 RID: 61273 RVA: 0x008FE104 File Offset: 0x008FC304
		Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox53.Text = Conversions.ToString(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text))
			Me.TextBox58.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text) - (Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF5A RID: 61274 RVA: 0x008FE104 File Offset: 0x008FC304
		Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox53.Text = Conversions.ToString(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text))
			Me.TextBox58.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text) - (Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF5B RID: 61275 RVA: 0x00068DAE File Offset: 0x00066FAE
		Private Sub TextBox49_TextChanged(sender As Object, e As EventArgs)
			Me.compute()
		End Sub

		' Token: 0x0600EF5C RID: 61276 RVA: 0x008FE1CC File Offset: 0x008FC3CC
		Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF5D RID: 61277 RVA: 0x008FE1CC File Offset: 0x008FC3CC
		Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF5E RID: 61278 RVA: 0x008FE1CC File Offset: 0x008FC3CC
		Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF5F RID: 61279 RVA: 0x00068DAE File Offset: 0x00066FAE
		Private Sub TextBox55_TextChanged(sender As Object, e As EventArgs)
			Me.compute()
		End Sub

		' Token: 0x0600EF60 RID: 61280 RVA: 0x008FE2F8 File Offset: 0x008FC4F8
		Private Sub TextBox30_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox60.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) - (Conversion.Val(Me.TextBox30.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox36.Text)), 2), "0.00")
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF61 RID: 61281 RVA: 0x008FE2F8 File Offset: 0x008FC4F8
		Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox60.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) - (Conversion.Val(Me.TextBox30.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox36.Text)), 2), "0.00")
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF62 RID: 61282 RVA: 0x008FE2F8 File Offset: 0x008FC4F8
		Private Sub TextBox34_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox60.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) - (Conversion.Val(Me.TextBox30.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox36.Text)), 2), "0.00")
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF63 RID: 61283 RVA: 0x00068DAE File Offset: 0x00066FAE
		Private Sub TextBox52_TextChanged(sender As Object, e As EventArgs)
			Me.compute()
		End Sub

		' Token: 0x0600EF64 RID: 61284 RVA: 0x008FE424 File Offset: 0x008FC624
		Private Sub compute()
			Me.TextBox52.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox54.Text) - Conversion.Val(Me.TextBox53.Text) - (Conversion.Val(Me.TextBox49.Text) - Conversion.Val(Me.TextBox55.Text)) - Conversion.Val(Me.TextBox64.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF65 RID: 61285 RVA: 0x008FE4A8 File Offset: 0x008FC6A8
		Private Sub TextBox56_TextChanged(sender As Object, e As EventArgs)
			Me.servicecompute()
			Me.TextBox61.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox56.Text) - Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF66 RID: 61286 RVA: 0x008FE500 File Offset: 0x008FC700
		Private Sub servicecompute()
			Me.TextBox56.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox38.Text) + Conversion.Val(Me.TextBox39.Text) + Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF67 RID: 61287 RVA: 0x00068DB8 File Offset: 0x00066FB8
		Private Sub TextBox38_TextChanged(sender As Object, e As EventArgs)
			Me.servicecompute()
		End Sub

		' Token: 0x0600EF68 RID: 61288 RVA: 0x00068DB8 File Offset: 0x00066FB8
		Private Sub TextBox39_TextChanged(sender As Object, e As EventArgs)
			Me.servicecompute()
		End Sub

		' Token: 0x0600EF69 RID: 61289 RVA: 0x008FE4A8 File Offset: 0x008FC6A8
		Private Sub TextBox42_TextChanged(sender As Object, e As EventArgs)
			Me.servicecompute()
			Me.TextBox61.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox56.Text) - Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF6A RID: 61290 RVA: 0x008FE564 File Offset: 0x008FC764
		Private Sub TextBox57_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox57.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox9.Text) - (Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF6B RID: 61291 RVA: 0x008FE5E8 File Offset: 0x008FC7E8
		Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox58.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text) - (Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF6C RID: 61292 RVA: 0x008FE5E8 File Offset: 0x008FC7E8
		Private Sub TextBox58_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox58.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text) - (Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox25.Text) + Conversion.Val(Me.TextBox26.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF6D RID: 61293 RVA: 0x008FE66C File Offset: 0x008FC86C
		Private Sub TextBox59_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF6E RID: 61294 RVA: 0x008FE1CC File Offset: 0x008FC3CC
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF6F RID: 61295 RVA: 0x008FE1CC File Offset: 0x008FC3CC
		Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox59.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF70 RID: 61296 RVA: 0x008FE6F0 File Offset: 0x008FC8F0
		Private Sub TextBox60_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox60.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) - (Conversion.Val(Me.TextBox30.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox36.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF71 RID: 61297 RVA: 0x008FE2F8 File Offset: 0x008FC4F8
		Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox60.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) - (Conversion.Val(Me.TextBox30.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox36.Text)), 2), "0.00")
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF72 RID: 61298 RVA: 0x00068DAE File Offset: 0x00066FAE
		Private Sub TextBox64_TextChanged(sender As Object, e As EventArgs)
			Me.compute()
		End Sub

		' Token: 0x0600EF73 RID: 61299 RVA: 0x008FE774 File Offset: 0x008FC974
		Private Sub TextBox65_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox65.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox75.Text) + Conversion.Val(Me.TextBox76.Text) + Conversion.Val(Me.TextBox77.Text), 2), "0.00")
			Me.TextBox101.Text = Conversions.ToString(Conversion.Val(Me.TextBox94.Text) + Conversion.Val(Me.TextBox65.Text))
		End Sub

		' Token: 0x0600EF74 RID: 61300 RVA: 0x008FE808 File Offset: 0x008FCA08
		Private Sub TextBox76_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox65.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox75.Text) + Conversion.Val(Me.TextBox76.Text) + Conversion.Val(Me.TextBox77.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF75 RID: 61301 RVA: 0x008FE808 File Offset: 0x008FCA08
		Private Sub TextBox75_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox65.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox75.Text) + Conversion.Val(Me.TextBox76.Text) + Conversion.Val(Me.TextBox77.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF76 RID: 61302 RVA: 0x008FE808 File Offset: 0x008FCA08
		Private Sub TextBox77_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox65.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox75.Text) + Conversion.Val(Me.TextBox76.Text) + Conversion.Val(Me.TextBox77.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF77 RID: 61303 RVA: 0x008FE86C File Offset: 0x008FCA6C
		Private Sub TextBox78_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox98.Text = Conversions.ToString(Conversion.Val(Me.TextBox78.Text) + Conversion.Val(Me.TextBox79.Text) + Conversion.Val(Me.TextBox80.Text) + Conversion.Val(Me.TextBox86.Text))
		End Sub

		' Token: 0x0600EF78 RID: 61304 RVA: 0x008FE86C File Offset: 0x008FCA6C
		Private Sub TextBox79_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox98.Text = Conversions.ToString(Conversion.Val(Me.TextBox78.Text) + Conversion.Val(Me.TextBox79.Text) + Conversion.Val(Me.TextBox80.Text) + Conversion.Val(Me.TextBox86.Text))
		End Sub

		' Token: 0x0600EF79 RID: 61305 RVA: 0x008FE86C File Offset: 0x008FCA6C
		Private Sub TextBox80_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox98.Text = Conversions.ToString(Conversion.Val(Me.TextBox78.Text) + Conversion.Val(Me.TextBox79.Text) + Conversion.Val(Me.TextBox80.Text) + Conversion.Val(Me.TextBox86.Text))
		End Sub

		' Token: 0x0600EF7A RID: 61306 RVA: 0x008FE8D0 File Offset: 0x008FCAD0
		Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF7B RID: 61307 RVA: 0x008FE8D0 File Offset: 0x008FCAD0
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF7C RID: 61308 RVA: 0x008FE8D0 File Offset: 0x008FCAD0
		Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF7D RID: 61309 RVA: 0x008FE8D0 File Offset: 0x008FCAD0
		Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) + Conversion.Val(Me.TextBox12.Text) - (Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox13.Text) + Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox15.Text) + Conversion.Val(Me.TextBox16.Text) + Conversion.Val(Me.TextBox17.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF7E RID: 61310 RVA: 0x008FE988 File Offset: 0x008FCB88
		Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF7F RID: 61311 RVA: 0x008FE988 File Offset: 0x008FCB88
		Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF80 RID: 61312 RVA: 0x008FE988 File Offset: 0x008FCB88
		Private Sub TextBox32_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF81 RID: 61313 RVA: 0x008FE988 File Offset: 0x008FCB88
		Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox32.Text) - (Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox35.Text) + Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox34.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox30.Text)), 2), "0.00")
		End Sub

		' Token: 0x0600EF82 RID: 61314 RVA: 0x008FE86C File Offset: 0x008FCA6C
		Private Sub TextBox86_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox98.Text = Conversions.ToString(Conversion.Val(Me.TextBox78.Text) + Conversion.Val(Me.TextBox79.Text) + Conversion.Val(Me.TextBox80.Text) + Conversion.Val(Me.TextBox86.Text))
		End Sub

		' Token: 0x0600EF83 RID: 61315 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBalancesheet_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600EF84 RID: 61316 RVA: 0x008FEA40 File Offset: 0x008FCC40
		Private Sub b1d1()
			Me.TextBox40.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)+Sum(FreightCharges)+Sum(Roundoff))-(Sum(OtherCharges))), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), (Sum(GrandTotal)-Sum(PreviousDue)), Sum(TotalPayment) from stock where date between @f1  And  @f2 and PurchaseType='Cash'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox40.Text = Conversions.ToString(Me.rdr1.GetValue(9))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox40.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF85 RID: 61317 RVA: 0x008FEBB8 File Offset: 0x008FCDB8
		Private Sub b1d2()
			Me.TextBox88.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)+Sum(FreightCharges)+Sum(Roundoff))-(Sum(OtherCharges))), Sum(CGST), Sum(SGST), Sum(IGST), Sum(CESS), Sum(FreightCharges), Sum(OtherCharges), Sum(Roundoff), (Sum(GrandTotal)-Sum(PreviousDue)), Sum(TotalPayment) from stock where date between @f1  And  @f2 and PurchaseType='Bank'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox88.Text = Conversions.ToString(Me.rdr1.GetValue(9))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox88.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox88.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF86 RID: 61318 RVA: 0x008FED30 File Offset: 0x008FCF30
		Private Sub TextBox89_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox89.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox88.Text) + Conversion.Val(Me.TextBox85.Text), 2), "0.00")
			Me.TextBox102.Text = Conversions.ToString(Conversion.Val(Me.TextBox89.Text) + Conversion.Val(Me.TextBox51.Text))
		End Sub

		' Token: 0x0600EF87 RID: 61319 RVA: 0x00068DC2 File Offset: 0x00066FC2
		Private Sub TextBox88_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox89.Text = Conversions.ToString(Conversion.Val(Me.TextBox88.Text) + Conversion.Val(Me.TextBox85.Text))
		End Sub

		' Token: 0x0600EF88 RID: 61320 RVA: 0x00068DC2 File Offset: 0x00066FC2
		Private Sub TextBox85_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox89.Text = Conversions.ToString(Conversion.Val(Me.TextBox88.Text) + Conversion.Val(Me.TextBox85.Text))
		End Sub

		' Token: 0x0600EF89 RID: 61321 RVA: 0x008FEDB4 File Offset: 0x008FCFB4
		Private Sub TextBox90_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox90.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox72.Text) + Conversion.Val(Me.TextBox84.Text), 2), "0.00")
			Me.TextBox103.Text = Conversions.ToString(Conversion.Val(Me.TextBox90.Text) + Conversion.Val(Me.TextBox46.Text))
		End Sub

		' Token: 0x0600EF8A RID: 61322 RVA: 0x00068DF7 File Offset: 0x00066FF7
		Private Sub TextBox72_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox90.Text = Conversions.ToString(Conversion.Val(Me.TextBox72.Text) + Conversion.Val(Me.TextBox84.Text))
		End Sub

		' Token: 0x0600EF8B RID: 61323 RVA: 0x00068DF7 File Offset: 0x00066FF7
		Private Sub TextBox84_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox90.Text = Conversions.ToString(Conversion.Val(Me.TextBox72.Text) + Conversion.Val(Me.TextBox84.Text))
		End Sub

		' Token: 0x0600EF8C RID: 61324 RVA: 0x008FEE38 File Offset: 0x008FD038
		Private Sub TextBox94_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox94.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox91.Text) + Conversion.Val(Me.TextBox92.Text) + Conversion.Val(Me.TextBox93.Text), 2), "0.00")
			Me.TextBox101.Text = Conversions.ToString(Conversion.Val(Me.TextBox94.Text) + Conversion.Val(Me.TextBox65.Text))
		End Sub

		' Token: 0x0600EF8D RID: 61325 RVA: 0x008FEECC File Offset: 0x008FD0CC
		Private Sub TextBox92_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox94.Text = Conversions.ToString(Conversion.Val(Me.TextBox91.Text) + Conversion.Val(Me.TextBox92.Text) + Conversion.Val(Me.TextBox93.Text))
		End Sub

		' Token: 0x0600EF8E RID: 61326 RVA: 0x008FEECC File Offset: 0x008FD0CC
		Private Sub TextBox93_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox94.Text = Conversions.ToString(Conversion.Val(Me.TextBox91.Text) + Conversion.Val(Me.TextBox92.Text) + Conversion.Val(Me.TextBox93.Text))
		End Sub

		' Token: 0x0600EF8F RID: 61327 RVA: 0x008FEECC File Offset: 0x008FD0CC
		Private Sub TextBox91_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox94.Text = Conversions.ToString(Conversion.Val(Me.TextBox91.Text) + Conversion.Val(Me.TextBox92.Text) + Conversion.Val(Me.TextBox93.Text))
		End Sub

		' Token: 0x0600EF90 RID: 61328 RVA: 0x008FEF20 File Offset: 0x008FD120
		Private Sub TextBox98_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox98.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox78.Text) + Conversion.Val(Me.TextBox79.Text) + Conversion.Val(Me.TextBox80.Text) + Conversion.Val(Me.TextBox86.Text), 2), "0.00")
			Me.TextBox100.Text = Conversions.ToString(Conversion.Val(Me.TextBox98.Text) + Conversion.Val(Me.TextBox99.Text))
		End Sub

		' Token: 0x0600EF91 RID: 61329 RVA: 0x008FEFC4 File Offset: 0x008FD1C4
		Private Sub TextBox99_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox99.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox96.Text) + Conversion.Val(Me.TextBox97.Text) + Conversion.Val(Me.TextBox95.Text) + Conversion.Val(Me.TextBox87.Text), 2), "0.00")
			Me.TextBox100.Text = Conversions.ToString(Conversion.Val(Me.TextBox98.Text) + Conversion.Val(Me.TextBox99.Text))
		End Sub

		' Token: 0x0600EF92 RID: 61330 RVA: 0x008FF068 File Offset: 0x008FD268
		Private Sub TextBox96_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox99.Text = Conversions.ToString(Conversion.Val(Me.TextBox96.Text) + Conversion.Val(Me.TextBox97.Text) + Conversion.Val(Me.TextBox95.Text) + Conversion.Val(Me.TextBox87.Text))
		End Sub

		' Token: 0x0600EF93 RID: 61331 RVA: 0x008FF068 File Offset: 0x008FD268
		Private Sub TextBox97_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox99.Text = Conversions.ToString(Conversion.Val(Me.TextBox96.Text) + Conversion.Val(Me.TextBox97.Text) + Conversion.Val(Me.TextBox95.Text) + Conversion.Val(Me.TextBox87.Text))
		End Sub

		' Token: 0x0600EF94 RID: 61332 RVA: 0x008FF068 File Offset: 0x008FD268
		Private Sub TextBox95_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox99.Text = Conversions.ToString(Conversion.Val(Me.TextBox96.Text) + Conversion.Val(Me.TextBox97.Text) + Conversion.Val(Me.TextBox95.Text) + Conversion.Val(Me.TextBox87.Text))
		End Sub

		' Token: 0x0600EF95 RID: 61333 RVA: 0x008FF068 File Offset: 0x008FD268
		Private Sub TextBox87_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox99.Text = Conversions.ToString(Conversion.Val(Me.TextBox96.Text) + Conversion.Val(Me.TextBox97.Text) + Conversion.Val(Me.TextBox95.Text) + Conversion.Val(Me.TextBox87.Text))
		End Sub

		' Token: 0x0600EF96 RID: 61334 RVA: 0x008FF0CC File Offset: 0x008FD2CC
		Private Sub TextBox103_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox103.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox90.Text) + Conversion.Val(Me.TextBox46.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF97 RID: 61335 RVA: 0x008FF11C File Offset: 0x008FD31C
		Private Sub TextBox102_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox102.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox89.Text) + Conversion.Val(Me.TextBox51.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF98 RID: 61336 RVA: 0x008FF16C File Offset: 0x008FD36C
		Private Sub TextBox101_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox101.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox94.Text) + Conversion.Val(Me.TextBox65.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF99 RID: 61337 RVA: 0x008FF1BC File Offset: 0x008FD3BC
		Private Sub TextBox100_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox100.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox98.Text) + Conversion.Val(Me.TextBox99.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EF9A RID: 61338 RVA: 0x008FF20C File Offset: 0x008FD40C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat.Chart2.Series("A").Points.Clear()
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Sale", New Object() { Me.TextBox9.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox10.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Sale Return", New Object() { Me.TextBox19.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Purchase Return", New Object() { Me.TextBox28.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Service", New Object() { Me.TextBox56.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Receipt", New Object() { Me.TextBox103.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Payment", New Object() { Me.TextBox102.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Income", New Object() { Me.TextBox101.Text })
			MyProject.Forms.frmChat.Chart2.Series("A").Points.AddXY("Expenses", New Object() { Me.TextBox100.Text })
			MyProject.Forms.frmChat.ShowDialog()
		End Sub

		' Token: 0x0600EF9B RID: 61339 RVA: 0x008FF4A8 File Offset: 0x008FD6A8
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.Clear()
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Sale", New Object() { Me.TextBox9.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox10.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Sale Return", New Object() { Me.TextBox19.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Purchase Return", New Object() { Me.TextBox28.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Service", New Object() { Me.TextBox56.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Receipt", New Object() { Me.TextBox103.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Payment", New Object() { Me.TextBox102.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Income", New Object() { Me.TextBox101.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Expenses", New Object() { Me.TextBox100.Text })
			MyProject.Forms.frmChat1.ShowDialog()
		End Sub

		' Token: 0x0600EF9C RID: 61340 RVA: 0x008FF744 File Offset: 0x008FD944
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.Clear()
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Sale", New Object() { Me.TextBox9.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox10.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Sale Return", New Object() { Me.TextBox19.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Purchase Return", New Object() { Me.TextBox28.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Service", New Object() { Me.TextBox56.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Receipt", New Object() { Me.TextBox103.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Payment", New Object() { Me.TextBox102.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Income", New Object() { Me.TextBox101.Text })
			MyProject.Forms.frmChat2.Chart3.Series("A").Points.AddXY("Expenses", New Object() { Me.TextBox100.Text })
			MyProject.Forms.frmChat2.ShowDialog()
		End Sub

		' Token: 0x0600EF9D RID: 61341 RVA: 0x008FF9E0 File Offset: 0x008FDBE0
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.Clear()
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Sale", New Object() { Me.TextBox9.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox10.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Sale Return", New Object() { Me.TextBox19.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Purchase Return", New Object() { Me.TextBox28.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Service", New Object() { Me.TextBox56.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Receipt", New Object() { Me.TextBox103.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Payment", New Object() { Me.TextBox102.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Income", New Object() { Me.TextBox101.Text })
			MyProject.Forms.frmChat3.Chart2.Series("A").Points.AddXY("Expenses", New Object() { Me.TextBox100.Text })
			MyProject.Forms.frmChat3.ShowDialog()
		End Sub

		' Token: 0x0600EF9E RID: 61342 RVA: 0x008FFC7C File Offset: 0x008FDE7C
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.Clear()
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Sale", New Object() { Me.TextBox9.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Purchase", New Object() { Me.TextBox10.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Sale Return", New Object() { Me.TextBox19.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Purchase Return", New Object() { Me.TextBox28.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Service", New Object() { Me.TextBox56.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Receipt", New Object() { Me.TextBox103.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Payment", New Object() { Me.TextBox102.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Income", New Object() { Me.TextBox101.Text })
			MyProject.Forms.frmChat4.Chart2.Series("A").Points.AddXY("Expenses", New Object() { Me.TextBox100.Text })
			MyProject.Forms.frmChat4.ShowDialog()
		End Sub

		' Token: 0x0600EF9F RID: 61343 RVA: 0x008FFF18 File Offset: 0x008FE118
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.a1()
			Me.b1()
			Me.b1d1()
			Me.b1d2()
			Me.c1()
			Me.c100()
			Me.d1()
			Me.d100()
			Me.e1()
			Me.f1()
			Me.f100()
			Me.g1()
			Me.h1()
			Me.h100()
			Me.i1()
			Me.i1d1()
			Me.i11()
			Me.i11d2()
			Me.i111()
			Me.i111D3()
			Me.j1()
			Me.l1()
			Me.m1()
			Me.m1d1()
			Me.m11()
			Me.m11d1()
			Me.m111()
			Me.m111d1()
			Me.PurchaseRCM()
			Me.Rcptbybank()
			Me.Rcptbybank1()
			Me.Rcptbybank2()
			Me.h123()
			Me.h124()
			Me.f11()
			Me.f12()
			Me.purrcm()
			Me.purrcmtb49()
			Me.d1pr()
			Me.d2pr()
			Me.salertnforcash()
			Me.purchasertncash()
		End Sub

		' Token: 0x0600EFA0 RID: 61344 RVA: 0x0090004C File Offset: 0x008FE24C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.a1()
			Me.b1()
			Me.b1d1()
			Me.b1d2()
			Me.c1()
			Me.c100()
			Me.d1()
			Me.d100()
			Me.e1()
			Me.f1()
			Me.f100()
			Me.g1()
			Me.h1()
			Me.h100()
			Me.i1()
			Me.i1d1()
			Me.i11()
			Me.i11d2()
			Me.i111()
			Me.i111D3()
			Me.j1()
			Me.l1()
			Me.m1()
			Me.m1d1()
			Me.m11()
			Me.m11d1()
			Me.m111()
			Me.m111d1()
			Me.PurchaseRCM()
			Me.Rcptbybank()
			Me.Rcptbybank1()
			Me.Rcptbybank2()
			Me.h123()
			Me.h124()
			Me.f11()
			Me.f12()
			Me.purrcm()
			Me.purrcmtb49()
			Me.d1pr()
			Me.d2pr()
			Me.salertnforcash()
			Me.purchasertncash()
		End Sub

		' Token: 0x04005B7C RID: 23420
		Private cmdimg As SqlCommand

		' Token: 0x04005B7D RID: 23421
		Private rdr1 As SqlDataReader

		' Token: 0x04005B7E RID: 23422
		Private adv As Double

		' Token: 0x04005B7F RID: 23423
		Private emppay As Double
	End Class
End Namespace
