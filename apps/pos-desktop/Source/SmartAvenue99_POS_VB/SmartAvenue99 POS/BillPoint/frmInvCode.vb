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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004CE RID: 1230
	<DesignerGenerated()>
	Public Partial Class frmInvCode
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FA7B RID: 64123 RVA: 0x0006DDCC File Offset: 0x0006BFCC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmInvCode_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmInvCode_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005FE5 RID: 24549
		' (get) Token: 0x0600FA7E RID: 64126 RVA: 0x0006DDFE File Offset: 0x0006BFFE
		' (set) Token: 0x0600FA7F RID: 64127 RVA: 0x0006DE08 File Offset: 0x0006C008
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005FE6 RID: 24550
		' (get) Token: 0x0600FA80 RID: 64128 RVA: 0x0006DE11 File Offset: 0x0006C011
		' (set) Token: 0x0600FA81 RID: 64129 RVA: 0x0006DE1B File Offset: 0x0006C01B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005FE7 RID: 24551
		' (get) Token: 0x0600FA82 RID: 64130 RVA: 0x0006DE24 File Offset: 0x0006C024
		' (set) Token: 0x0600FA83 RID: 64131 RVA: 0x0006DE2E File Offset: 0x0006C02E
		Friend Overridable Property Label1 As Label

		' Token: 0x17005FE8 RID: 24552
		' (get) Token: 0x0600FA84 RID: 64132 RVA: 0x0006DE37 File Offset: 0x0006C037
		' (set) Token: 0x0600FA85 RID: 64133 RVA: 0x0006DE41 File Offset: 0x0006C041
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17005FE9 RID: 24553
		' (get) Token: 0x0600FA86 RID: 64134 RVA: 0x0006DE4A File Offset: 0x0006C04A
		' (set) Token: 0x0600FA87 RID: 64135 RVA: 0x0006DE54 File Offset: 0x0006C054
		Friend Overridable Property Label3 As Label

		' Token: 0x17005FEA RID: 24554
		' (get) Token: 0x0600FA88 RID: 64136 RVA: 0x0006DE5D File Offset: 0x0006C05D
		' (set) Token: 0x0600FA89 RID: 64137 RVA: 0x00962E38 File Offset: 0x00961038
		Private _TextBox0 As TextBox
		Friend Overridable Property TextBox0 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox0_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.TextBox0_TextChanged
				Dim textBox As TextBox = Me._TextBox0
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox0 = value
				textBox = Me._TextBox0
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FEB RID: 24555
		' (get) Token: 0x0600FA8A RID: 64138 RVA: 0x0006DE67 File Offset: 0x0006C067
		' (set) Token: 0x0600FA8B RID: 64139 RVA: 0x00962EB4 File Offset: 0x009610B4
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox3_KeyDown
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FEC RID: 24556
		' (get) Token: 0x0600FA8C RID: 64140 RVA: 0x0006DE71 File Offset: 0x0006C071
		' (set) Token: 0x0600FA8D RID: 64141 RVA: 0x0006DE7B File Offset: 0x0006C07B
		Friend Overridable Property Label5 As Label

		' Token: 0x17005FED RID: 24557
		' (get) Token: 0x0600FA8E RID: 64142 RVA: 0x0006DE84 File Offset: 0x0006C084
		' (set) Token: 0x0600FA8F RID: 64143 RVA: 0x00962F14 File Offset: 0x00961114
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox2_KeyDown
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FEE RID: 24558
		' (get) Token: 0x0600FA90 RID: 64144 RVA: 0x0006DE8E File Offset: 0x0006C08E
		' (set) Token: 0x0600FA91 RID: 64145 RVA: 0x0006DE98 File Offset: 0x0006C098
		Friend Overridable Property Label4 As Label

		' Token: 0x17005FEF RID: 24559
		' (get) Token: 0x0600FA92 RID: 64146 RVA: 0x0006DEA1 File Offset: 0x0006C0A1
		' (set) Token: 0x0600FA93 RID: 64147 RVA: 0x00962F74 File Offset: 0x00961174
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox1_KeyDown
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FF0 RID: 24560
		' (get) Token: 0x0600FA94 RID: 64148 RVA: 0x0006DEAB File Offset: 0x0006C0AB
		' (set) Token: 0x0600FA95 RID: 64149 RVA: 0x0006DEB5 File Offset: 0x0006C0B5
		Friend Overridable Property Label2 As Label

		' Token: 0x17005FF1 RID: 24561
		' (get) Token: 0x0600FA96 RID: 64150 RVA: 0x0006DEBE File Offset: 0x0006C0BE
		' (set) Token: 0x0600FA97 RID: 64151 RVA: 0x00962FD4 File Offset: 0x009611D4
		Private _TextBox5 As TextBox
		Friend Overridable Property TextBox5 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FF2 RID: 24562
		' (get) Token: 0x0600FA98 RID: 64152 RVA: 0x0006DEC8 File Offset: 0x0006C0C8
		' (set) Token: 0x0600FA99 RID: 64153 RVA: 0x0006DED2 File Offset: 0x0006C0D2
		Friend Overridable Property Label7 As Label

		' Token: 0x17005FF3 RID: 24563
		' (get) Token: 0x0600FA9A RID: 64154 RVA: 0x0006DEDB File Offset: 0x0006C0DB
		' (set) Token: 0x0600FA9B RID: 64155 RVA: 0x00963034 File Offset: 0x00961234
		Private _TextBox4 As TextBox
		Friend Overridable Property TextBox4 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox4_KeyDown
				Dim textBox As TextBox = Me._TextBox4
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox4 = value
				textBox = Me._TextBox4
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FF4 RID: 24564
		' (get) Token: 0x0600FA9C RID: 64156 RVA: 0x0006DEE5 File Offset: 0x0006C0E5
		' (set) Token: 0x0600FA9D RID: 64157 RVA: 0x0006DEEF File Offset: 0x0006C0EF
		Friend Overridable Property Label6 As Label

		' Token: 0x17005FF5 RID: 24565
		' (get) Token: 0x0600FA9E RID: 64158 RVA: 0x0006DEF8 File Offset: 0x0006C0F8
		' (set) Token: 0x0600FA9F RID: 64159 RVA: 0x0006DF02 File Offset: 0x0006C102
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17005FF6 RID: 24566
		' (get) Token: 0x0600FAA0 RID: 64160 RVA: 0x0006DF0B File Offset: 0x0006C10B
		' (set) Token: 0x0600FAA1 RID: 64161 RVA: 0x0006DF15 File Offset: 0x0006C115
		Friend Overridable Property Label10 As Label

		' Token: 0x17005FF7 RID: 24567
		' (get) Token: 0x0600FAA2 RID: 64162 RVA: 0x0006DF1E File Offset: 0x0006C11E
		' (set) Token: 0x0600FAA3 RID: 64163 RVA: 0x00963094 File Offset: 0x00961294
		Private _TextBox8 As TextBox
		Friend Overridable Property TextBox8 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox8_KeyDown
				Dim textBox As TextBox = Me._TextBox8
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox8 = value
				textBox = Me._TextBox8
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FF8 RID: 24568
		' (get) Token: 0x0600FAA4 RID: 64164 RVA: 0x0006DF28 File Offset: 0x0006C128
		' (set) Token: 0x0600FAA5 RID: 64165 RVA: 0x009630F4 File Offset: 0x009612F4
		Private _TextBox7 As TextBox
		Friend Overridable Property TextBox7 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox7_KeyDown
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FF9 RID: 24569
		' (get) Token: 0x0600FAA6 RID: 64166 RVA: 0x0006DF32 File Offset: 0x0006C132
		' (set) Token: 0x0600FAA7 RID: 64167 RVA: 0x0006DF3C File Offset: 0x0006C13C
		Friend Overridable Property Label9 As Label

		' Token: 0x17005FFA RID: 24570
		' (get) Token: 0x0600FAA8 RID: 64168 RVA: 0x0006DF45 File Offset: 0x0006C145
		' (set) Token: 0x0600FAA9 RID: 64169 RVA: 0x0006DF4F File Offset: 0x0006C14F
		Friend Overridable Property Label12 As Label

		' Token: 0x17005FFB RID: 24571
		' (get) Token: 0x0600FAAA RID: 64170 RVA: 0x0006DF58 File Offset: 0x0006C158
		' (set) Token: 0x0600FAAB RID: 64171 RVA: 0x00963154 File Offset: 0x00961354
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox10_KeyDown
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FFC RID: 24572
		' (get) Token: 0x0600FAAC RID: 64172 RVA: 0x0006DF62 File Offset: 0x0006C162
		' (set) Token: 0x0600FAAD RID: 64173 RVA: 0x0006DF6C File Offset: 0x0006C16C
		Friend Overridable Property Label11 As Label

		' Token: 0x17005FFD RID: 24573
		' (get) Token: 0x0600FAAE RID: 64174 RVA: 0x0006DF75 File Offset: 0x0006C175
		' (set) Token: 0x0600FAAF RID: 64175 RVA: 0x009631B4 File Offset: 0x009613B4
		Private _TextBox9 As TextBox
		Friend Overridable Property TextBox9 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox9_KeyDown
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FFE RID: 24574
		' (get) Token: 0x0600FAB0 RID: 64176 RVA: 0x0006DF7F File Offset: 0x0006C17F
		' (set) Token: 0x0600FAB1 RID: 64177 RVA: 0x00963214 File Offset: 0x00961414
		Private _TextBox11 As TextBox
		Friend Overridable Property TextBox11 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox11
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox11_KeyDown
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005FFF RID: 24575
		' (get) Token: 0x0600FAB2 RID: 64178 RVA: 0x0006DF89 File Offset: 0x0006C189
		' (set) Token: 0x0600FAB3 RID: 64179 RVA: 0x00963274 File Offset: 0x00961474
		Private _TextBox12 As TextBox
		Friend Overridable Property TextBox12 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox12
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox12_KeyDown
				Dim textBox As TextBox = Me._TextBox12
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox12 = value
				textBox = Me._TextBox12
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006000 RID: 24576
		' (get) Token: 0x0600FAB4 RID: 64180 RVA: 0x0006DF93 File Offset: 0x0006C193
		' (set) Token: 0x0600FAB5 RID: 64181 RVA: 0x009632D4 File Offset: 0x009614D4
		Private _TextBox13 As TextBox
		Friend Overridable Property TextBox13 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox13_KeyDown
				Dim textBox As TextBox = Me._TextBox13
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox13 = value
				textBox = Me._TextBox13
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006001 RID: 24577
		' (get) Token: 0x0600FAB6 RID: 64182 RVA: 0x0006DF9D File Offset: 0x0006C19D
		' (set) Token: 0x0600FAB7 RID: 64183 RVA: 0x00963334 File Offset: 0x00961534
		Private _TextBox14 As TextBox
		Friend Overridable Property TextBox14 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox14
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox14_KeyDown
				Dim textBox As TextBox = Me._TextBox14
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox14 = value
				textBox = Me._TextBox14
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006002 RID: 24578
		' (get) Token: 0x0600FAB8 RID: 64184 RVA: 0x0006DFA7 File Offset: 0x0006C1A7
		' (set) Token: 0x0600FAB9 RID: 64185 RVA: 0x00963394 File Offset: 0x00961594
		Private _TextBox15 As TextBox
		Friend Overridable Property TextBox15 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox15
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox15_KeyDown
				Dim textBox As TextBox = Me._TextBox15
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox15 = value
				textBox = Me._TextBox15
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006003 RID: 24579
		' (get) Token: 0x0600FABA RID: 64186 RVA: 0x0006DFB1 File Offset: 0x0006C1B1
		' (set) Token: 0x0600FABB RID: 64187 RVA: 0x009633F4 File Offset: 0x009615F4
		Private _TextBox16 As TextBox
		Friend Overridable Property TextBox16 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox16_KeyDown
				Dim textBox As TextBox = Me._TextBox16
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox16 = value
				textBox = Me._TextBox16
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006004 RID: 24580
		' (get) Token: 0x0600FABC RID: 64188 RVA: 0x0006DFBB File Offset: 0x0006C1BB
		' (set) Token: 0x0600FABD RID: 64189 RVA: 0x00963454 File Offset: 0x00961654
		Private _TextBox17 As TextBox
		Friend Overridable Property TextBox17 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox17
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox17_KeyDown
				Dim textBox As TextBox = Me._TextBox17
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox17 = value
				textBox = Me._TextBox17
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006005 RID: 24581
		' (get) Token: 0x0600FABE RID: 64190 RVA: 0x0006DFC5 File Offset: 0x0006C1C5
		' (set) Token: 0x0600FABF RID: 64191 RVA: 0x009634B4 File Offset: 0x009616B4
		Private _TextBox18 As TextBox
		Friend Overridable Property TextBox18 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox18
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox18_KeyDown
				Dim textBox As TextBox = Me._TextBox18
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox18 = value
				textBox = Me._TextBox18
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006006 RID: 24582
		' (get) Token: 0x0600FAC0 RID: 64192 RVA: 0x0006DFCF File Offset: 0x0006C1CF
		' (set) Token: 0x0600FAC1 RID: 64193 RVA: 0x00963514 File Offset: 0x00961714
		Private _TextBox19 As TextBox
		Friend Overridable Property TextBox19 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox19_KeyDown
				Dim textBox As TextBox = Me._TextBox19
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox19 = value
				textBox = Me._TextBox19
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006007 RID: 24583
		' (get) Token: 0x0600FAC2 RID: 64194 RVA: 0x0006DFD9 File Offset: 0x0006C1D9
		' (set) Token: 0x0600FAC3 RID: 64195 RVA: 0x00963574 File Offset: 0x00961774
		Private _TextBox20 As TextBox
		Friend Overridable Property TextBox20 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox20_KeyDown
				Dim textBox As TextBox = Me._TextBox20
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox20 = value
				textBox = Me._TextBox20
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006008 RID: 24584
		' (get) Token: 0x0600FAC4 RID: 64196 RVA: 0x0006DFE3 File Offset: 0x0006C1E3
		' (set) Token: 0x0600FAC5 RID: 64197 RVA: 0x0006DFED File Offset: 0x0006C1ED
		Friend Overridable Property Label14 As Label

		' Token: 0x17006009 RID: 24585
		' (get) Token: 0x0600FAC6 RID: 64198 RVA: 0x0006DFF6 File Offset: 0x0006C1F6
		' (set) Token: 0x0600FAC7 RID: 64199 RVA: 0x0006E000 File Offset: 0x0006C200
		Friend Overridable Property Label13 As Label

		' Token: 0x1700600A RID: 24586
		' (get) Token: 0x0600FAC8 RID: 64200 RVA: 0x0006E009 File Offset: 0x0006C209
		' (set) Token: 0x0600FAC9 RID: 64201 RVA: 0x009635D4 File Offset: 0x009617D4
		Private _TextBox22 As TextBox
		Friend Overridable Property TextBox22 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Seven_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox22_KeyDown
				Dim textBox As TextBox = Me._TextBox22
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox22 = value
				textBox = Me._TextBox22
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700600B RID: 24587
		' (get) Token: 0x0600FACA RID: 64202 RVA: 0x0006E013 File Offset: 0x0006C213
		' (set) Token: 0x0600FACB RID: 64203 RVA: 0x00963634 File Offset: 0x00961834
		Private _TextBox21 As TextBox
		Friend Overridable Property TextBox21 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox21
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Four_Char
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox21_KeyDown
				Dim textBox As TextBox = Me._TextBox21
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox21 = value
				textBox = Me._TextBox21
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700600C RID: 24588
		' (get) Token: 0x0600FACC RID: 64204 RVA: 0x0006E01D File Offset: 0x0006C21D
		' (set) Token: 0x0600FACD RID: 64205 RVA: 0x0006E027 File Offset: 0x0006C227
		Friend Overridable Property Label8 As Label

		' Token: 0x1700600D RID: 24589
		' (get) Token: 0x0600FACE RID: 64206 RVA: 0x0006E030 File Offset: 0x0006C230
		' (set) Token: 0x0600FACF RID: 64207 RVA: 0x00963694 File Offset: 0x00961894
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600FAD0 RID: 64208 RVA: 0x0006E03A File Offset: 0x0006C23A
		Private Sub frmInvCode_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FAD1 RID: 64209 RVA: 0x009636D8 File Offset: 0x009618D8
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

		' Token: 0x0600FAD2 RID: 64210 RVA: 0x00963850 File Offset: 0x00961A50
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

		' Token: 0x0600FAD3 RID: 64211 RVA: 0x0096390C File Offset: 0x00961B0C
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

		' Token: 0x0600FAD4 RID: 64212 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FAD5 RID: 64213 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FAD6 RID: 64214 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FAD7 RID: 64215 RVA: 0x009639D8 File Offset: 0x00961BD8
		Private Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(Code), RTRIM(c1), RTRIM(c2), RTRIM(c3), RTRIM(c4), RTRIM(c5), RTRIM(c6), RTRIM(c7), RTRIM(c8), RTRIM(c9), RTRIM(c10), RTRIM(c11), RTRIM(c12), RTRIM(c13), RTRIM(c14), RTRIM(c15), RTRIM(c16), RTRIM(c17), RTRIM(c18), RTRIM(c19), RTRIM(c20), RTRIM(c21) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox6.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.TextBox0.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.TextBox4.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.TextBox5.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.TextBox7.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.TextBox8.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.TextBox9.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.TextBox10.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.TextBox11.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.TextBox12.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox13.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.TextBox14.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.TextBox15.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.TextBox16.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.TextBox17.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.TextBox18.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.TextBox19.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.TextBox20.Text = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.TextBox21.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.TextBox22.Text = ModCommonClasses.rdr.GetValue(22).ToString()
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FAD8 RID: 64216 RVA: 0x00963D50 File Offset: 0x00961F50
		Private Sub Four_Char(sender As Object, e As KeyPressEventArgs)
			Me.TextBox0.MaxLength = 4
			Me.TextBox1.MaxLength = 4
			Me.TextBox2.MaxLength = 4
			Me.TextBox3.MaxLength = 4
			Me.TextBox4.MaxLength = 4
			Me.TextBox5.MaxLength = 4
			Me.TextBox7.MaxLength = 4
			Me.TextBox8.MaxLength = 4
			Me.TextBox9.MaxLength = 4
			Me.TextBox10.MaxLength = 4
			Me.TextBox21.MaxLength = 4
			e.KeyChar = Strings.UCase(e.KeyChar)
			e.Handled = (e.KeyChar <> vbBack) And (Operators.CompareString(Conversions.ToString(e.KeyChar), "/", False) <> 0) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsDigit(e.KeyChar)
		End Sub

		' Token: 0x0600FAD9 RID: 64217 RVA: 0x00963E5C File Offset: 0x0096205C
		Private Sub Seven_Char(sender As Object, e As KeyPressEventArgs)
			Me.TextBox11.MaxLength = 7
			Me.TextBox12.MaxLength = 7
			Me.TextBox13.MaxLength = 7
			Me.TextBox14.MaxLength = 7
			Me.TextBox15.MaxLength = 7
			Me.TextBox16.MaxLength = 7
			Me.TextBox17.MaxLength = 7
			Me.TextBox18.MaxLength = 7
			Me.TextBox19.MaxLength = 7
			Me.TextBox20.MaxLength = 7
			Me.TextBox22.MaxLength = 7
			e.KeyChar = Strings.UCase(e.KeyChar)
			e.Handled = (e.KeyChar <> vbBack) And (Operators.CompareString(Conversions.ToString(e.KeyChar), "/", False) <> 0) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsDigit(e.KeyChar)
		End Sub

		' Token: 0x0600FADA RID: 64218 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox0_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FADB RID: 64219 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FADC RID: 64220 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FADD RID: 64221 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox12_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FADE RID: 64222 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FADF RID: 64223 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox13_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE0 RID: 64224 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE1 RID: 64225 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE2 RID: 64226 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE3 RID: 64227 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox15_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE4 RID: 64228 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE5 RID: 64229 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox16_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE6 RID: 64230 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE7 RID: 64231 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox17_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE8 RID: 64232 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAE9 RID: 64233 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox18_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAEA RID: 64234 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAEB RID: 64235 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox19_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAEC RID: 64236 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAED RID: 64237 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox20_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAEE RID: 64238 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox21_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAEF RID: 64239 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox22_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600FAF0 RID: 64240 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmInvCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600FAF1 RID: 64241 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox0_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600FAF2 RID: 64242 RVA: 0x00963F68 File Offset: 0x00962168
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.TextBox0.Text.Length > 4
			If flag Then
				MessageBox.Show("Maximum 4 alphabet characters are allowed in Sale Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.TextBox0.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox0.Text, "SINV", False) = 0
				If flag2 Then
					MessageBox.Show("Not allowed to put 'SINV' code", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox0.Focus()
				Else
					Dim flag3 As Boolean = Me.TextBox1.Text.Length > 4
					If flag3 Then
						MessageBox.Show("Maximum 4 alphabet characters are allowed in Purchase Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox1.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "PINV", False) = 0
						If flag4 Then
							MessageBox.Show("Not allowed to put 'PINV' code", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.TextBox1.Focus()
						Else
							Dim flag5 As Boolean = Me.TextBox2.Text.Length > 4
							If flag5 Then
								MessageBox.Show("Maximum 4 alphabet characters are allowedin in Sale Return Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.TextBox2.Focus()
							Else
								Dim flag6 As Boolean = Me.TextBox3.Text.Length > 4
								If flag6 Then
									MessageBox.Show("Maximum 4 alphabet characters are allowed in Purchase Return Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.TextBox3.Focus()
								Else
									Dim flag7 As Boolean = Me.TextBox4.Text.Length > 4
									If flag7 Then
										MessageBox.Show("Maximum 4 alphabet characters are allowed in Quotation Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.TextBox4.Focus()
									Else
										Dim flag8 As Boolean = Me.TextBox5.Text.Length > 4
										If flag8 Then
											MessageBox.Show("Maximum 4 alphabet characters are allowed in Purchase Order Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.TextBox5.Focus()
										Else
											Dim flag9 As Boolean = Me.TextBox7.Text.Length > 4
											If flag9 Then
												MessageBox.Show("Maximum 4 alphabet characters are allowed in Receipt Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.TextBox7.Focus()
											Else
												Dim flag10 As Boolean = Me.TextBox8.Text.Length > 4
												If flag10 Then
													MessageBox.Show("Maximum 4 alphabet characters are allowed in Payment Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.TextBox8.Focus()
												Else
													Dim flag11 As Boolean = Me.TextBox9.Text.Length > 4
													If flag11 Then
														MessageBox.Show("Maximum 4 alphabet characters are allowed in Income Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.TextBox9.Focus()
													Else
														Dim flag12 As Boolean = Me.TextBox10.Text.Length > 4
														If flag12 Then
															MessageBox.Show("Maximum 4 alphabet characters are allowed in Expense Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Me.TextBox10.Focus()
														Else
															Dim flag13 As Boolean = Me.TextBox21.Text.Length > 4
															If flag13 Then
																MessageBox.Show("Maximum 4 alphabet characters are allowed in Expense Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Me.TextBox21.Focus()
															Else
																Dim flag14 As Boolean = Me.TextBox11.Text.Length > 7
																If flag14 Then
																	MessageBox.Show("Maximum 7 alphabet characters are allowed in Sale Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																	Me.TextBox11.Focus()
																Else
																	Dim flag15 As Boolean = Me.TextBox12.Text.Length > 7
																	If flag15 Then
																		MessageBox.Show("Maximum 7 alphabet characters are allowed in Purchase Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																		Me.TextBox12.Focus()
																	Else
																		Dim flag16 As Boolean = Me.TextBox13.Text.Length > 7
																		If flag16 Then
																			MessageBox.Show("Maximum 7 alphabet characters are allowedin in Sale Return Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Me.TextBox13.Focus()
																		Else
																			Dim flag17 As Boolean = Me.TextBox14.Text.Length > 7
																			If flag17 Then
																				MessageBox.Show("Maximum 7 alphabet characters are allowed in Purchase Return Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																				Me.TextBox14.Focus()
																			Else
																				Dim flag18 As Boolean = Me.TextBox15.Text.Length > 7
																				If flag18 Then
																					MessageBox.Show("Maximum 7 alphabet characters are allowed in Quotation Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																					Me.TextBox15.Focus()
																				Else
																					Dim flag19 As Boolean = Me.TextBox16.Text.Length > 7
																					If flag19 Then
																						MessageBox.Show("Maximum 7 alphabet characters are allowed in Purchase Order Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																						Me.TextBox16.Focus()
																					Else
																						Dim flag20 As Boolean = Me.TextBox17.Text.Length > 7
																						If flag20 Then
																							MessageBox.Show("Maximum 7 alphabet characters are allowed in Receipt Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																							Me.TextBox17.Focus()
																						Else
																							Dim flag21 As Boolean = Me.TextBox18.Text.Length > 7
																							If flag21 Then
																								MessageBox.Show("Maximum 7 alphabet characters are allowed in Payment Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																								Me.TextBox18.Focus()
																							Else
																								Dim flag22 As Boolean = Me.TextBox19.Text.Length > 7
																								If flag22 Then
																									MessageBox.Show("Maximum 7 alphabet characters are allowed in Income Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																									Me.TextBox19.Focus()
																								Else
																									Dim flag23 As Boolean = Me.TextBox20.Text.Length > 7
																									If flag23 Then
																										MessageBox.Show("Maximum 7 alphabet characters are allowed in Expense Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																										Me.TextBox20.Focus()
																									Else
																										Dim flag24 As Boolean = Me.TextBox22.Text.Length > 7
																										If flag24 Then
																											MessageBox.Show("Maximum 7 alphabet characters are allowed in Expense Invoice Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																											Me.TextBox22.Focus()
																										Else
																											Try
																												ModCommonClasses.con = New SqlConnection(ModCS.cs)
																												ModCommonClasses.con.Open()
																												Dim text As String = "Update Invcode set Code=@d1,c1=@d2,c2=@d3,c3=@d4,c4=@d5,c5=@d6,c6=@d7,c7=@d8,c8=@d9,c9=@d10,c10=@d11,c11=@d12,c12=@d13,c13=@d14,c14=@d15,c15=@d16,c16=@d17,c17=@d18,c18=@d19,c19=@d20,c20=@d21,c21=@d22 where ID=@d0"
																												ModCommonClasses.cmd = New SqlCommand(text)
																												ModCommonClasses.cmd.Connection = ModCommonClasses.con
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.TextBox6.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox0.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox2.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.TextBox3.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.TextBox4.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.TextBox5.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.TextBox7.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.TextBox8.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.TextBox9.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.TextBox10.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.TextBox11.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.TextBox12.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.TextBox13.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.TextBox14.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.TextBox15.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.TextBox16.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.TextBox17.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.TextBox18.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.TextBox19.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.TextBox20.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.TextBox21.Text)
																												ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.TextBox22.Text)
																												ModCommonClasses.cmd.ExecuteReader()
																												MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																												Me.Getdata()
																											Catch ex As Exception
																												MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																											End Try
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub
	End Class
End Namespace
