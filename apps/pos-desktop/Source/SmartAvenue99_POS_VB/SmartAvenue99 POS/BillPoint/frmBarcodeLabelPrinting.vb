Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200058E RID: 1422
	<DesignerGenerated()>
	Public Partial Class frmBarcodeLabelPrinting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060115FD RID: 71165 RVA: 0x00A1320C File Offset: 0x00A1140C
		Public Sub New()
			AddHandler MyBase.Click, AddressOf Me.Card_Click
			AddHandler MyBase.Load, AddressOf Me.frmBarcodeLabelPrinting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBarcodeLabelPrinting_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmBarcodeLabelPrinting_Closed
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006BCB RID: 27595
		' (get) Token: 0x06011600 RID: 71168 RVA: 0x00077969 File Offset: 0x00075B69
		' (set) Token: 0x06011601 RID: 71169 RVA: 0x00A15830 File Offset: 0x00A13A30
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

		' Token: 0x17006BCC RID: 27596
		' (get) Token: 0x06011602 RID: 71170 RVA: 0x00077973 File Offset: 0x00075B73
		' (set) Token: 0x06011603 RID: 71171 RVA: 0x0007797D File Offset: 0x00075B7D
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006BCD RID: 27597
		' (get) Token: 0x06011604 RID: 71172 RVA: 0x00077986 File Offset: 0x00075B86
		' (set) Token: 0x06011605 RID: 71173 RVA: 0x00077990 File Offset: 0x00075B90
		Friend Overridable Property Label2 As Label

		' Token: 0x17006BCE RID: 27598
		' (get) Token: 0x06011606 RID: 71174 RVA: 0x00077999 File Offset: 0x00075B99
		' (set) Token: 0x06011607 RID: 71175 RVA: 0x000779A3 File Offset: 0x00075BA3
		Friend Overridable Property Label3 As Label

		' Token: 0x17006BCF RID: 27599
		' (get) Token: 0x06011608 RID: 71176 RVA: 0x000779AC File Offset: 0x00075BAC
		' (set) Token: 0x06011609 RID: 71177 RVA: 0x00A15874 File Offset: 0x00A13A74
		Private _listView1 As ListView
		Friend Overridable Property listView1 As ListView
			<CompilerGenerated()>
			Get
				Return Me._listView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.LV
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.listView1_MouseDoubleClick
				Dim listView As ListView = Me._listView1
				If listView IsNot Nothing Then
					RemoveHandler listView.KeyDown, keyEventHandler
					RemoveHandler listView.MouseDoubleClick, mouseEventHandler
				End If
				Me._listView1 = value
				listView = Me._listView1
				If listView IsNot Nothing Then
					AddHandler listView.KeyDown, keyEventHandler
					AddHandler listView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BD0 RID: 27600
		' (get) Token: 0x0601160A RID: 71178 RVA: 0x000779B6 File Offset: 0x00075BB6
		' (set) Token: 0x0601160B RID: 71179 RVA: 0x000779C0 File Offset: 0x00075BC0
		Friend Overridable Property columnHeader1 As ColumnHeader

		' Token: 0x17006BD1 RID: 27601
		' (get) Token: 0x0601160C RID: 71180 RVA: 0x000779C9 File Offset: 0x00075BC9
		' (set) Token: 0x0601160D RID: 71181 RVA: 0x000779D3 File Offset: 0x00075BD3
		Friend Overridable Property columnHeader3 As ColumnHeader

		' Token: 0x17006BD2 RID: 27602
		' (get) Token: 0x0601160E RID: 71182 RVA: 0x000779DC File Offset: 0x00075BDC
		' (set) Token: 0x0601160F RID: 71183 RVA: 0x000779E6 File Offset: 0x00075BE6
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x17006BD3 RID: 27603
		' (get) Token: 0x06011610 RID: 71184 RVA: 0x000779EF File Offset: 0x00075BEF
		' (set) Token: 0x06011611 RID: 71185 RVA: 0x000779F9 File Offset: 0x00075BF9
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x17006BD4 RID: 27604
		' (get) Token: 0x06011612 RID: 71186 RVA: 0x00077A02 File Offset: 0x00075C02
		' (set) Token: 0x06011613 RID: 71187 RVA: 0x00077A0C File Offset: 0x00075C0C
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17006BD5 RID: 27605
		' (get) Token: 0x06011614 RID: 71188 RVA: 0x00077A15 File Offset: 0x00075C15
		' (set) Token: 0x06011615 RID: 71189 RVA: 0x00077A1F File Offset: 0x00075C1F
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006BD6 RID: 27606
		' (get) Token: 0x06011616 RID: 71190 RVA: 0x00077A28 File Offset: 0x00075C28
		' (set) Token: 0x06011617 RID: 71191 RVA: 0x00A158D4 File Offset: 0x00A13AD4
		Private _txtNoOfCopies As TextBox
		Friend Overridable Property txtNoOfCopies As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNoOfCopies
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtNoOfCopies_KeyPress
				Dim textBox As TextBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtNoOfCopies = value
				textBox = Me._txtNoOfCopies
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BD7 RID: 27607
		' (get) Token: 0x06011618 RID: 71192 RVA: 0x00077A32 File Offset: 0x00075C32
		' (set) Token: 0x06011619 RID: 71193 RVA: 0x00077A3C File Offset: 0x00075C3C
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x17006BD8 RID: 27608
		' (get) Token: 0x0601161A RID: 71194 RVA: 0x00077A45 File Offset: 0x00075C45
		' (set) Token: 0x0601161B RID: 71195 RVA: 0x00A15918 File Offset: 0x00A13B18
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BD9 RID: 27609
		' (get) Token: 0x0601161C RID: 71196 RVA: 0x00077A4F File Offset: 0x00075C4F
		' (set) Token: 0x0601161D RID: 71197 RVA: 0x00A1595C File Offset: 0x00A13B5C
		Private _txtPCode As TextBox
		Friend Overridable Property txtPCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPCode_KeyUp
				Dim textBox As TextBox = Me._txtPCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPCode = value
				textBox = Me._txtPCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BDA RID: 27610
		' (get) Token: 0x0601161E RID: 71198 RVA: 0x00077A59 File Offset: 0x00075C59
		' (set) Token: 0x0601161F RID: 71199 RVA: 0x00A159A0 File Offset: 0x00A13BA0
		Private _txtBCode As TextBox
		Friend Overridable Property txtBCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtBCode_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBCode_KeyUp
				Dim textBox As TextBox = Me._txtBCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtBCode = value
				textBox = Me._txtBCode
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BDB RID: 27611
		' (get) Token: 0x06011620 RID: 71200 RVA: 0x00077A63 File Offset: 0x00075C63
		' (set) Token: 0x06011621 RID: 71201 RVA: 0x00077A6D File Offset: 0x00075C6D
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17006BDC RID: 27612
		' (get) Token: 0x06011622 RID: 71202 RVA: 0x00077A76 File Offset: 0x00075C76
		' (set) Token: 0x06011623 RID: 71203 RVA: 0x00A15A00 File Offset: 0x00A13C00
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.TextBox1_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_LostFocus
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.LostFocus, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.LostFocus, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BDD RID: 27613
		' (get) Token: 0x06011624 RID: 71204 RVA: 0x00077A80 File Offset: 0x00075C80
		' (set) Token: 0x06011625 RID: 71205 RVA: 0x00A15A60 File Offset: 0x00A13C60
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

		' Token: 0x17006BDE RID: 27614
		' (get) Token: 0x06011626 RID: 71206 RVA: 0x00077A8A File Offset: 0x00075C8A
		' (set) Token: 0x06011627 RID: 71207 RVA: 0x00077A94 File Offset: 0x00075C94
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17006BDF RID: 27615
		' (get) Token: 0x06011628 RID: 71208 RVA: 0x00077A9D File Offset: 0x00075C9D
		' (set) Token: 0x06011629 RID: 71209 RVA: 0x00077AA7 File Offset: 0x00075CA7
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17006BE0 RID: 27616
		' (get) Token: 0x0601162A RID: 71210 RVA: 0x00077AB0 File Offset: 0x00075CB0
		' (set) Token: 0x0601162B RID: 71211 RVA: 0x00A15AA4 File Offset: 0x00A13CA4
		Private _RadioButton2 As RadioButton
		Friend Overridable Property RadioButton2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton2_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton2 = value
				radioButton = Me._RadioButton2
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BE1 RID: 27617
		' (get) Token: 0x0601162C RID: 71212 RVA: 0x00077ABA File Offset: 0x00075CBA
		' (set) Token: 0x0601162D RID: 71213 RVA: 0x00A15AE8 File Offset: 0x00A13CE8
		Private _RadioButton1 As RadioButton
		Friend Overridable Property RadioButton1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._RadioButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.RadioButton1_CheckedChanged
				Dim radioButton As RadioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._RadioButton1 = value
				radioButton = Me._RadioButton1
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BE2 RID: 27618
		' (get) Token: 0x0601162E RID: 71214 RVA: 0x00077AC4 File Offset: 0x00075CC4
		' (set) Token: 0x0601162F RID: 71215 RVA: 0x00077ACE File Offset: 0x00075CCE
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17006BE3 RID: 27619
		' (get) Token: 0x06011630 RID: 71216 RVA: 0x00077AD7 File Offset: 0x00075CD7
		' (set) Token: 0x06011631 RID: 71217 RVA: 0x00A15B2C File Offset: 0x00A13D2C
		Private _txtPInv As TextBox
		Friend Overridable Property txtPInv As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPInv
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPInv_KeyUp
				Dim textBox As TextBox = Me._txtPInv
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyUp, keyEventHandler
				End If
				Me._txtPInv = value
				textBox = Me._txtPInv
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyUp, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BE4 RID: 27620
		' (get) Token: 0x06011632 RID: 71218 RVA: 0x00077AE1 File Offset: 0x00075CE1
		' (set) Token: 0x06011633 RID: 71219 RVA: 0x00077AEB File Offset: 0x00075CEB
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17006BE5 RID: 27621
		' (get) Token: 0x06011634 RID: 71220 RVA: 0x00077AF4 File Offset: 0x00075CF4
		' (set) Token: 0x06011635 RID: 71221 RVA: 0x00077AFE File Offset: 0x00075CFE
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17006BE6 RID: 27622
		' (get) Token: 0x06011636 RID: 71222 RVA: 0x00077B07 File Offset: 0x00075D07
		' (set) Token: 0x06011637 RID: 71223 RVA: 0x00077B11 File Offset: 0x00075D11
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x17006BE7 RID: 27623
		' (get) Token: 0x06011638 RID: 71224 RVA: 0x00077B1A File Offset: 0x00075D1A
		' (set) Token: 0x06011639 RID: 71225 RVA: 0x00077B24 File Offset: 0x00075D24
		Friend Overridable Property ColumnHeader12 As ColumnHeader

		' Token: 0x17006BE8 RID: 27624
		' (get) Token: 0x0601163A RID: 71226 RVA: 0x00077B2D File Offset: 0x00075D2D
		' (set) Token: 0x0601163B RID: 71227 RVA: 0x00077B37 File Offset: 0x00075D37
		Friend Overridable Property ColumnHeader13 As ColumnHeader

		' Token: 0x17006BE9 RID: 27625
		' (get) Token: 0x0601163C RID: 71228 RVA: 0x00077B40 File Offset: 0x00075D40
		' (set) Token: 0x0601163D RID: 71229 RVA: 0x00077B4A File Offset: 0x00075D4A
		Friend Overridable Property ColumnHeader14 As ColumnHeader

		' Token: 0x17006BEA RID: 27626
		' (get) Token: 0x0601163E RID: 71230 RVA: 0x00077B53 File Offset: 0x00075D53
		' (set) Token: 0x0601163F RID: 71231 RVA: 0x00077B5D File Offset: 0x00075D5D
		Friend Overridable Property ColumnHeader15 As ColumnHeader

		' Token: 0x17006BEB RID: 27627
		' (get) Token: 0x06011640 RID: 71232 RVA: 0x00077B66 File Offset: 0x00075D66
		' (set) Token: 0x06011641 RID: 71233 RVA: 0x00077B70 File Offset: 0x00075D70
		Friend Overridable Property ColumnHeader16 As ColumnHeader

		' Token: 0x17006BEC RID: 27628
		' (get) Token: 0x06011642 RID: 71234 RVA: 0x00077B79 File Offset: 0x00075D79
		' (set) Token: 0x06011643 RID: 71235 RVA: 0x00077B83 File Offset: 0x00075D83
		Friend Overridable Property ColumnHeader17 As ColumnHeader

		' Token: 0x17006BED RID: 27629
		' (get) Token: 0x06011644 RID: 71236 RVA: 0x00077B8C File Offset: 0x00075D8C
		' (set) Token: 0x06011645 RID: 71237 RVA: 0x00077B96 File Offset: 0x00075D96
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x17006BEE RID: 27630
		' (get) Token: 0x06011646 RID: 71238 RVA: 0x00077B9F File Offset: 0x00075D9F
		' (set) Token: 0x06011647 RID: 71239 RVA: 0x00A15B70 File Offset: 0x00A13D70
		Private _txtSearch As TextBox
		Friend Overridable Property txtSearch As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearch_KeyDown
				Dim textBox As TextBox = Me._txtSearch
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSearch = value
				textBox = Me._txtSearch
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BEF RID: 27631
		' (get) Token: 0x06011648 RID: 71240 RVA: 0x00077BA9 File Offset: 0x00075DA9
		' (set) Token: 0x06011649 RID: 71241 RVA: 0x00A15BB4 File Offset: 0x00A13DB4
		Private _ComboBox2 As ComboBox
		Friend Overridable Property ComboBox2 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox2_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox2 = value
				comboBox = Me._ComboBox2
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BF0 RID: 27632
		' (get) Token: 0x0601164A RID: 71242 RVA: 0x00077BB3 File Offset: 0x00075DB3
		' (set) Token: 0x0601164B RID: 71243 RVA: 0x00077BBD File Offset: 0x00075DBD
		Friend Overridable Property Label1 As Label

		' Token: 0x17006BF1 RID: 27633
		' (get) Token: 0x0601164C RID: 71244 RVA: 0x00077BC6 File Offset: 0x00075DC6
		' (set) Token: 0x0601164D RID: 71245 RVA: 0x00A15BF8 File Offset: 0x00A13DF8
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

		' Token: 0x17006BF2 RID: 27634
		' (get) Token: 0x0601164E RID: 71246 RVA: 0x00077BD0 File Offset: 0x00075DD0
		' (set) Token: 0x0601164F RID: 71247 RVA: 0x00A15C3C File Offset: 0x00A13E3C
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

		' Token: 0x17006BF3 RID: 27635
		' (get) Token: 0x06011650 RID: 71248 RVA: 0x00077BDA File Offset: 0x00075DDA
		' (set) Token: 0x06011651 RID: 71249 RVA: 0x00A15C80 File Offset: 0x00A13E80
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnAddCustomer = value
				gelButton = Me._btnAddCustomer
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BF4 RID: 27636
		' (get) Token: 0x06011652 RID: 71250 RVA: 0x00077BE4 File Offset: 0x00075DE4
		' (set) Token: 0x06011653 RID: 71251 RVA: 0x00077BEE File Offset: 0x00075DEE
		Friend Overridable Property ColumnHeader18 As ColumnHeader

		' Token: 0x17006BF5 RID: 27637
		' (get) Token: 0x06011654 RID: 71252 RVA: 0x00077BF7 File Offset: 0x00075DF7
		' (set) Token: 0x06011655 RID: 71253 RVA: 0x00077C01 File Offset: 0x00075E01
		Friend Overridable Property txtVariant As TextBox

		' Token: 0x17006BF6 RID: 27638
		' (get) Token: 0x06011656 RID: 71254 RVA: 0x00077C0A File Offset: 0x00075E0A
		' (set) Token: 0x06011657 RID: 71255 RVA: 0x00077C14 File Offset: 0x00075E14
		Friend Overridable Property txtIDs As TextBox

		' Token: 0x17006BF7 RID: 27639
		' (get) Token: 0x06011658 RID: 71256 RVA: 0x00077C1D File Offset: 0x00075E1D
		' (set) Token: 0x06011659 RID: 71257 RVA: 0x00A15CC4 File Offset: 0x00A13EC4
		Private _dgwBill As DataGridView
		Friend Overridable Property dgwBill As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgwBill
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgwBill_CellContentClick
				Dim dataGridView As DataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgwBill = value
				dataGridView = Me._dgwBill
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006BF8 RID: 27640
		' (get) Token: 0x0601165A RID: 71258 RVA: 0x00077C27 File Offset: 0x00075E27
		' (set) Token: 0x0601165B RID: 71259 RVA: 0x00077C31 File Offset: 0x00075E31
		Friend Overridable Property PictureBox5 As PictureBox

		' Token: 0x17006BF9 RID: 27641
		' (get) Token: 0x0601165C RID: 71260 RVA: 0x00077C3A File Offset: 0x00075E3A
		' (set) Token: 0x0601165D RID: 71261 RVA: 0x00077C44 File Offset: 0x00075E44
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17006BFA RID: 27642
		' (get) Token: 0x0601165E RID: 71262 RVA: 0x00077C4D File Offset: 0x00075E4D
		' (set) Token: 0x0601165F RID: 71263 RVA: 0x00077C57 File Offset: 0x00075E57
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17006BFB RID: 27643
		' (get) Token: 0x06011660 RID: 71264 RVA: 0x00077C60 File Offset: 0x00075E60
		' (set) Token: 0x06011661 RID: 71265 RVA: 0x00077C6A File Offset: 0x00075E6A
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17006BFC RID: 27644
		' (get) Token: 0x06011662 RID: 71266 RVA: 0x00077C73 File Offset: 0x00075E73
		' (set) Token: 0x06011663 RID: 71267 RVA: 0x00077C7D File Offset: 0x00075E7D
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x17006BFD RID: 27645
		' (get) Token: 0x06011664 RID: 71268 RVA: 0x00077C86 File Offset: 0x00075E86
		' (set) Token: 0x06011665 RID: 71269 RVA: 0x00A15D08 File Offset: 0x00A13F08
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

		' Token: 0x17006BFE RID: 27646
		' (get) Token: 0x06011666 RID: 71270 RVA: 0x00077C90 File Offset: 0x00075E90
		' (set) Token: 0x06011667 RID: 71271 RVA: 0x00077C9A File Offset: 0x00075E9A
		Friend Overridable Property pnlPrinterSeting As Panel

		' Token: 0x17006BFF RID: 27647
		' (get) Token: 0x06011668 RID: 71272 RVA: 0x00077CA3 File Offset: 0x00075EA3
		' (set) Token: 0x06011669 RID: 71273 RVA: 0x00077CAD File Offset: 0x00075EAD
		Friend Overridable Property chkShowImageSetting As CheckBox

		' Token: 0x17006C00 RID: 27648
		' (get) Token: 0x0601166A RID: 71274 RVA: 0x00077CB6 File Offset: 0x00075EB6
		' (set) Token: 0x0601166B RID: 71275 RVA: 0x00077CC0 File Offset: 0x00075EC0
		Friend Overridable Property chkSettingCashDraw As CheckBox

		' Token: 0x17006C01 RID: 27649
		' (get) Token: 0x0601166C RID: 71276 RVA: 0x00077CC9 File Offset: 0x00075EC9
		' (set) Token: 0x0601166D RID: 71277 RVA: 0x00077CD3 File Offset: 0x00075ED3
		Friend Overridable Property Label196 As Label

		' Token: 0x17006C02 RID: 27650
		' (get) Token: 0x0601166E RID: 71278 RVA: 0x00077CDC File Offset: 0x00075EDC
		' (set) Token: 0x0601166F RID: 71279 RVA: 0x00077CE6 File Offset: 0x00075EE6
		Friend Overridable Property cmbPrinterType As ComboBox

		' Token: 0x17006C03 RID: 27651
		' (get) Token: 0x06011670 RID: 71280 RVA: 0x00077CEF File Offset: 0x00075EEF
		' (set) Token: 0x06011671 RID: 71281 RVA: 0x00077CF9 File Offset: 0x00075EF9
		Friend Overridable Property Label197 As Label

		' Token: 0x17006C04 RID: 27652
		' (get) Token: 0x06011672 RID: 71282 RVA: 0x00077D02 File Offset: 0x00075F02
		' (set) Token: 0x06011673 RID: 71283 RVA: 0x00077D0C File Offset: 0x00075F0C
		Friend Overridable Property txtTillID As TextBox

		' Token: 0x17006C05 RID: 27653
		' (get) Token: 0x06011674 RID: 71284 RVA: 0x00077D15 File Offset: 0x00075F15
		' (set) Token: 0x06011675 RID: 71285 RVA: 0x00077D1F File Offset: 0x00075F1F
		Friend Overridable Property ColumnHeader19 As ColumnHeader

		' Token: 0x17006C06 RID: 27654
		' (get) Token: 0x06011676 RID: 71286 RVA: 0x00077D28 File Offset: 0x00075F28
		' (set) Token: 0x06011677 RID: 71287 RVA: 0x00A15D4C File Offset: 0x00A13F4C
		Private _FlowPanelBill As FlowLayoutPanel
		Friend Overridable Property FlowPanelBill As FlowLayoutPanel
			<CompilerGenerated()>
			Get
				Return Me._FlowPanelBill
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As FlowLayoutPanel)
				Dim paintEventHandler As PaintEventHandler = AddressOf Me.FlowPanelBill_Paint
				Dim flowLayoutPanel As FlowLayoutPanel = Me._FlowPanelBill
				If flowLayoutPanel IsNot Nothing Then
					RemoveHandler flowLayoutPanel.Paint, paintEventHandler
				End If
				Me._FlowPanelBill = value
				flowLayoutPanel = Me._FlowPanelBill
				If flowLayoutPanel IsNot Nothing Then
					AddHandler flowLayoutPanel.Paint, paintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C07 RID: 27655
		' (get) Token: 0x06011678 RID: 71288 RVA: 0x00077D32 File Offset: 0x00075F32
		' (set) Token: 0x06011679 RID: 71289 RVA: 0x00077D3C File Offset: 0x00075F3C
		Friend Overridable Property lblCategoryId As Label

		' Token: 0x17006C08 RID: 27656
		' (get) Token: 0x0601167A RID: 71290 RVA: 0x00077D45 File Offset: 0x00075F45
		' (set) Token: 0x0601167B RID: 71291 RVA: 0x00077D4F File Offset: 0x00075F4F
		Public Property CheckedValues As List(Of Integer)

		' Token: 0x0601167C RID: 71292 RVA: 0x00A15D90 File Offset: 0x00A13F90
		Public Sub GetData()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 "
				Dim flag As Boolean = Conversion.Val(Me.lblCategoryId.Text) > 0.0
				If flag Then
					text += " AND Product.SubCategoryID = @CategoryId "
				End If
				text += " ORDER BY ProductName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				Dim flag2 As Boolean = Conversion.Val(Me.lblCategoryId.Text) > 0.0
				If flag2 Then
					ModCommonClasses.cmd.Parameters.AddWithValue("@CategoryId", Conversion.Val(Me.lblCategoryId.Text))
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601167D RID: 71293 RVA: 0x00A161BC File Offset: 0x00A143BC
		Public Sub SearchbyPCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and ProductCode like N'" + Me.txtPCode.Text + "%' order by Productname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601167E RID: 71294 RVA: 0x00A1654C File Offset: 0x00A1474C
		Public Sub SearchbyBCode()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Temp_Stock.Barcode like N'" + Me.txtBCode.Text + "%' ", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601167F RID: 71295 RVA: 0x00A168DC File Offset: 0x00A14ADC
		Public Sub GetDataPINV()
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.Barcode),Temp_Stock.Qty, Stock_Product.qty, RTRIM(Product.PartNo),RTRIM(HSNCode),(Stock_Product.MRP),(Stock_Product.RPrice),(Stock_Product.WPrice),(Stock_Product.Batch),(Stock_Product.Mfgdate),(Stock_Product.Expdate),(Stock_Product.Size),(Stock_Product.Color),((Stock_Product.CGSTPer)+(Stock_Product.SGSTPer)+(Stock_Product.IGSTPer)),RTRIM(Stock.InvoiceNo),QrBarcode,Product.Discount from Product,Stock,Stock_Product,Temp_Stock where Stock.St_ID=Stock_Product.StockID and Product.PID=Stock_Product.ProductID and Temp_Stock.Barcode=Stock_Product.Barcode and InvoiceNo like N'" + Me.txtPInv.Text + "%' order by ProductCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(5)))))
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011680 RID: 71296 RVA: 0x00A16C80 File Offset: 0x00A14E80
		Public Sub SearchbyVariant(strId As String)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Temp_Stock.Variant_id = '" + strId + "' order by ProductCode asc", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011681 RID: 71297 RVA: 0x00A17014 File Offset: 0x00A15214
		Public Sub SearchbyProductIds(intIds As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = "SELECT RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Category), RTRIM(Temp_Stock.Barcode), Temp_Stock.Qty, RTRIM(PartNo), RTRIM(HSNCode), Temp_Stock.MRP, Temp_Stock.SPrice, Temp_Stock.WPrice, Temp_Stock.Batch, Temp_Stock.Mfgdate, Temp_Stock.Expdate, Temp_Stock.Size, Temp_Stock.Colour, ((Product.CGST) + (Product.SGST)), '', QrBarcode,Product.Discount FROM Category INNER JOIN SubCategory ON Category.CategoryName = SubCategory.Category INNER JOIN Product ON Product.SubCategoryID = SubCategory.ID INNER JOIN Temp_Stock ON Temp_Stock.ProductID = Product.PID WHERE Product.Status = 'Yes' AND Temp_Stock.ProductID IN (" + intIds + ") ORDER BY ProductCode ASC"
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.listView1.Items.Clear()
							While sqlDataReader.Read()
								Dim listViewItem As ListViewItem = New ListViewItem()
								listViewItem.Text = sqlDataReader(0).ToString().Trim()
								listViewItem.SubItems.Add(sqlDataReader(1).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(2).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(3).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(4).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(5).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(6).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(7).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(8).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(9).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(10).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(11).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(12).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(13).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(14).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(15).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(16).ToString().Trim())
								listViewItem.SubItems.Add(sqlDataReader(17).ToString().Trim())
								Me.listView1.Items.Add(listViewItem)
							End While
							Dim num As Integer = Me.listView1.Items.Count - 1
							For i As Integer = 0 To num
								Me.listView1.Items(i).Checked = True
							Next
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011682 RID: 71298 RVA: 0x00A173AC File Offset: 0x00A155AC
		Public Sub Reset()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.txtSearch.Text = ""
			Me.txtNoOfCopies.Text = Conversions.ToString(1)
			Me.GetData()
			Me.chkSelectAll.Checked = True
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
		End Sub

		' Token: 0x06011683 RID: 71299 RVA: 0x00A17468 File Offset: 0x00A15668
		Public Sub FillCompany()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "Select RTRIM(CompanyName) from Company"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Me.txtCompany.Text = ModCommonClasses.rdr.GetString(0)
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06011684 RID: 71300 RVA: 0x00A174EC File Offset: 0x00A156EC
		Public Sub Getdata_BarcodeLayout()
			Try
				Me.FlowPanelBill.Controls.Clear()
				Dim text As String = ""
				Dim text2 As String = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where 1=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " AND PrintPreviewType='" + text + "'"
				End If
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							While sqlDataReader.Read()

								Dim card As Panel = New Panel() With { .Width = 200, .Height = 200, .Margin = New Padding(6), .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle, .Tag = RuntimeHelpers.GetObjectValue(sqlDataReader("BarcodeStyleId")) }

								Dim text3 As String = sqlDataReader("BarcodeStyleImage").ToString().Trim()

								Dim text4 As String = Application.StartupPath + "\Bill_Barcode\" + text3

								Dim pictureBox As PictureBox = New PictureBox() With { .Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom, .BackColor = Color.White }

								Dim flag2 As Boolean = File.Exists(text4)

								If flag2 Then

									pictureBox.Image = Image.FromFile(text4)

								Else

									pictureBox.BackColor = Color.LightGray

								End If

								AddHandler pictureBox.Click, AddressOf Me.Card_Click

								AddHandler card.Click, AddressOf Me.Card_Click

								AddHandler card.MouseEnter, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.Fixed3D

								End Sub

								AddHandler card.MouseLeave, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.FixedSingle

								End Sub

								AddHandler pictureBox.MouseEnter, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.Fixed3D

								End Sub

								AddHandler pictureBox.MouseLeave, Sub(a0 As Object, a1 As EventArgs)

									card.BorderStyle = BorderStyle.FixedSingle

								End Sub

								card.Controls.Add(pictureBox)

								Me.FlowPanelBill.Controls.Add(card)

							End While
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011685 RID: 71301 RVA: 0x00A177D0 File Offset: 0x00A159D0
		Private Sub Card_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = TypeOf sender Is Panel
				Dim panel As Panel
				If flag Then
					panel = CType(sender, Panel)
				Else
					panel = CType(CType(sender, Control).Parent, Panel)
				End If
				Dim flag2 As Boolean = panel Is Nothing
				If Not flag2 Then
					Dim flag3 As Boolean = panel.Tag Is Nothing
					If Not flag3 Then
						Dim num As Integer = Conversions.ToInteger(panel.Tag)
						Me.StyleId = Conversions.ToString(num)
						Dim text As String = ""
						Dim text2 As String = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview " & vbCrLf & "             WHERE BarcodeStyleId=" + Conversions.ToString(num)
						Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection.Open()
							Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
								Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
									Dim flag4 As Boolean = sqlDataReader.Read()
									If Not flag4 Then
										MessageBox.Show("Record not found!", "Warning")
										Return
									End If
									Me.StyleId = sqlDataReader("BarcodeStyleId").ToString()
									Me.testval = sqlDataReader("BarcodeStyleName").ToString()
									Me.pagetype = sqlDataReader("PrintPreviewType").ToString()
									text = sqlDataReader("BarcodeStyleImage").ToString()
								End Using
							End Using
						End Using
						Dim flag5 As Boolean = Operators.CompareString(text, "", False) <> 0
						If flag5 Then
							Dim text3 As String = Application.StartupPath + "\Bill_Barcode\" + text
							Dim flag6 As Boolean = File.Exists(text3)
							If flag6 Then
								Me.PictureBox5.Image = Image.FromFile(text3)
							Else
								MessageBox.Show("Image file not found: " + text3)
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06011686 RID: 71302 RVA: 0x00A17A24 File Offset: 0x00A15C24
		Public Sub Getdata_BarcodeLayout_4Grid()
			Try
				Dim text As String = ""
				Dim text2 As String = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where 1=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgwBill.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgwBill.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgwBill.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011687 RID: 71303 RVA: 0x00A17B7C File Offset: 0x00A15D7C
		Public Sub DefaultBarcode_Printer()
			Try
				Dim text As String = ""
				Dim text2 As String = "Select BarcodeStyleId,BarcodeStyleName,PrintPreviewType,BarcodeStyleImage from BarcodePreview where is_active=1"
				Dim flag As Boolean = Operators.CompareString(text, "", False) <> 0
				If flag Then
					text2 = text2 + " and PrintPreviewType='" + text + "'"
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(text2, ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim text3 As String = Application.StartupPath + "\Bill_Barcode\" + ModCommonClasses.rdr(3).ToString()
					Dim flag3 As Boolean = File.Exists(text3)
					If flag3 Then
						Me.PictureBox5.Image = Image.FromFile(text3)
					Else
						Me.PictureBox5.Image = Nothing
						MessageBox.Show("Image not found at: " + text3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End If
					Me.testval = ModCommonClasses.rdr(1).ToString()
					Me.StyleId = ModCommonClasses.rdr(0).ToString()
					Me.pagetype = ModCommonClasses.rdr(2).ToString()
				End If
				Try
					For Each obj As Object In CType(Me.dgwBill.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag4 As Boolean = Operators.CompareString(dataGridViewRow.Cells(2).Value.ToString(), ModCommonClasses.rdr(2).ToString(), False) = 0
						If flag4 Then
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow
							Exit For
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011688 RID: 71304 RVA: 0x00A17DC4 File Offset: 0x00A15FC4
		Private Sub frmBarcodeLabelPrinting_Load(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.CheckedValues IsNot Nothing
			If flag Then
				Me.txtIDs.Text = String.Join(", ", Me.CheckedValues)
			End If
			Me.FillCompany()
			Me.Getdata_BarcodeLayout_4Grid()
			Me.Getdata_BarcodeLayout()
			Me.DefaultBarcode_Printer()
			Dim flag2 As Boolean = Me.txtPCode.Text.Length > 0
			If flag2 Then
				Me.SearchbyPCode()
			Else
				Dim flag3 As Boolean = Me.txtBCode.Text.Length > 0
				If flag3 Then
					Me.SearchbyBCode()
				Else
					Dim flag4 As Boolean = Me.txtPInv.Text.Length > 0
					If flag4 Then
						Me.GetDataPINV()
					Else
						Dim flag5 As Boolean = Me.txtVariant.Text.Length > 0
						If flag5 Then
							Me.SearchbyVariant(Me.txtVariant.Text)
						Else
							Dim flag6 As Boolean = Me.txtIDs.Text.Length > 0
							If flag6 Then
								Me.SearchbyProductIds(Me.txtIDs.Text)
							Else
								Me.txtPCode.Text = ""
								Me.txtBCode.Text = ""
								Me.txtPInv.Text = ""
								Me.GetData()
							End If
						End If
					End If
				End If
			End If
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Checked = False
			Me.RadioButton1.Checked = True
			Me.RadioButton2.Checked = False
			Me.RadioButton1.TabStop = False
			Me.RadioButton2.TabStop = False
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox2.SelectedIndex = -1
			Me.txtSearch.Text = ""
			Me.txtIDs.Text = ""
			Me.txtVariant.Text = Conversions.ToString(0)
			Me.Convert_Language()
		End Sub

		' Token: 0x06011689 RID: 71305 RVA: 0x00A17FC0 File Offset: 0x00A161C0
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

		' Token: 0x0601168A RID: 71306 RVA: 0x00A18138 File Offset: 0x00A16338
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

		' Token: 0x0601168B RID: 71307 RVA: 0x00A181F4 File Offset: 0x00A163F4
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

		' Token: 0x0601168C RID: 71308 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601168D RID: 71309 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601168E RID: 71310 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601168F RID: 71311 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtNoOfCopies_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06011690 RID: 71312 RVA: 0x00077D58 File Offset: 0x00075F58
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011691 RID: 71313 RVA: 0x00A182C0 File Offset: 0x00A164C0
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.listView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.listView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.listView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.listView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x06011692 RID: 71314 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBarcodeLabelPrinting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011693 RID: 71315 RVA: 0x00077D74 File Offset: 0x00075F74
		Private Sub txtBCode_TextChanged(sender As Object, e As EventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x06011694 RID: 71316 RVA: 0x00A183AC File Offset: 0x00A165AC
		Private Sub LV(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = Me.listView1.SelectedItems.Count = 0
			If Not flag Then
				Dim keyCode As Keys = e.KeyCode
				If keyCode = Keys.F2 Then
					e.Handled = True
					Me.BeginEditListItem(Me.listView1.SelectedItems(0), 2)
				End If
			End If
		End Sub

		' Token: 0x06011695 RID: 71317 RVA: 0x00A18408 File Offset: 0x00A16608
		Private Sub listView1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Me.CurrentItem = Me.listView1.GetItemAt(e.X, e.Y)
			Dim flag As Boolean = Me.CurrentItem Is Nothing
			If Not flag Then
				Me.CurrentSB = Me.CurrentItem.GetSubItemAt(e.X, e.Y)
				Dim num As Integer = Me.CurrentItem.SubItems.IndexOf(Me.CurrentSB)
				If num = 5 Then
					Dim flag2 As Boolean = num = 0
					If flag2 Then
						Me.CurrentItem.BeginEdit()
					Else
						Dim num2 As Integer = Me.CurrentSB.Bounds.Left + 2
						Dim width As Integer = Me.CurrentSB.Bounds.Width
						Dim textBox As TextBox = Me.TextBox1
						textBox.SetBounds(num2 + Me.listView1.Left, Me.CurrentSB.Bounds.Top + Me.listView1.Top, width, Me.CurrentSB.Bounds.Height)
						textBox.Text = Me.CurrentSB.Text
						textBox.Show()
						textBox.Focus()
					End If
				End If
			End If
		End Sub

		' Token: 0x06011696 RID: 71318 RVA: 0x00A1854C File Offset: 0x00A1674C
		Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			If keyChar <> vbCr Then
				If keyChar = ChrW(27) Then
					Me.bCancelEdit = True
					e.Handled = True
					Me.TextBox1.Hide()
				End If
			Else
				Me.bCancelEdit = False
				e.Handled = True
				Me.TextBox1.Hide()
			End If
		End Sub

		' Token: 0x06011697 RID: 71319 RVA: 0x00A185B0 File Offset: 0x00A167B0
		Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs)
			Me.TextBox1.Hide()
			Dim flag As Boolean = Not Me.bCancelEdit
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox1.Text.Trim(), "", False) <> 0
				If flag2 Then
					Dim flag3 As Boolean = Not Versioned.IsNumeric(Me.TextBox1.Text)
					If flag3 Then
						Interaction.MsgBox("Please enter a numeric value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Dim flag4 As Boolean = Conversion.Val(Me.TextBox1.Text) = 0.0
					If flag4 Then
						Interaction.MsgBox("Not allowed to enter 0 value in this field.", MsgBoxStyle.Exclamation, Nothing)
						Return
					End If
					Me.CurrentSB.Text = Conversions.ToInteger(Me.TextBox1.Text).ToString()
				End If
			Else
				Me.bCancelEdit = False
			End If
			Me.listView1.Focus()
		End Sub

		' Token: 0x06011698 RID: 71320 RVA: 0x00A18694 File Offset: 0x00A16894
		Private Sub BeginEditListItem(iTm As ListViewItem, SubItemIndex As Integer)
			Dim location As Point = iTm.SubItems(SubItemIndex).Bounds.Location
			Dim e As MouseEventArgs = New MouseEventArgs(MouseButtons.Left, 2, location.X, location.Y, 0)
			Me.listView1_MouseDoubleClick(Me.listView1, e)
		End Sub

		' Token: 0x06011699 RID: 71321 RVA: 0x00A186E8 File Offset: 0x00A168E8
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.txtNoOfCopies.Focus()
			End If
		End Sub

		' Token: 0x0601169A RID: 71322 RVA: 0x00A18714 File Offset: 0x00A16914
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x0601169B RID: 71323 RVA: 0x00A18714 File Offset: 0x00A16914
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Me.RadioButton2.Checked = False
			Else
				Dim flag As Boolean = Not Me.RadioButton1.Checked
				If flag Then
					Me.RadioButton2.Checked = True
				End If
			End If
		End Sub

		' Token: 0x0601169C RID: 71324 RVA: 0x00077D7E File Offset: 0x00075F7E
		Private Sub txtPCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyPCode()
		End Sub

		' Token: 0x0601169D RID: 71325 RVA: 0x00077D74 File Offset: 0x00075F74
		Private Sub txtBCode_KeyUp(sender As Object, e As KeyEventArgs)
			Me.SearchbyBCode()
		End Sub

		' Token: 0x0601169E RID: 71326 RVA: 0x00077D88 File Offset: 0x00075F88
		Private Sub txtPInv_KeyUp(sender As Object, e As KeyEventArgs)
			Me.GetDataPINV()
		End Sub

		' Token: 0x0601169F RID: 71327 RVA: 0x00077D92 File Offset: 0x00075F92
		Private Sub frmBarcodeLabelPrinting_Closed(sender As Object, e As EventArgs)
			Me.txtPCode.Text = ""
			Me.txtBCode.Text = ""
			Me.txtPInv.Text = ""
		End Sub

		' Token: 0x060116A0 RID: 71328 RVA: 0x00A18764 File Offset: 0x00A16964
		Public Sub Print()
			Dim dataSet As DataSet = New DataSet()
			Dim dataTable As DataTable = New DataTable()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.StyleId, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim dataTable2 As DataTable = New DataTable()
							Dim dataTable3 As DataTable = dataTable2
							dataTable3.Columns.Add("PCode")
							dataTable3.Columns.Add("ProductName")
							dataTable3.Columns.Add("Category")
							dataTable3.Columns.Add("Barcode")
							dataTable3.Columns.Add("AvlQty")
							dataTable3.Columns.Add("NoCopy")
							dataTable3.Columns.Add("PartNo")
							dataTable3.Columns.Add("HSNC")
							dataTable3.Columns.Add("MRP")
							dataTable3.Columns.Add("SalePrice")
							dataTable3.Columns.Add("WholesalePrice")
							dataTable3.Columns.Add("Batch")
							dataTable3.Columns.Add("Mfg")
							dataTable3.Columns.Add("Exp")
							dataTable3.Columns.Add("Size")
							dataTable3.Columns.Add("Colour")
							dataTable3.Columns.Add("GST")
							dataTable3.Columns.Add("PurInv")
							dataTable3.Columns.Add("QrBarcode")
							dataTable3.Columns.Add("Discount")
							Dim dictionary As Dictionary(Of String, List(Of DataTable)) = New Dictionary(Of String, List(Of DataTable))()
							Dim text As String = ""
							Dim list As List(Of Integer) = New List(Of Integer)()
							Dim list2 As List(Of DataTable) = New List(Of DataTable)()
							Dim num As Integer
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									dataSet = Me.printCustomBarcode("'" + listViewItem.SubItems(3).Text + "'")
									dataTable = dataSet.Tables(0).Clone()
									Dim checked As Boolean = Me.CheckBox1.Checked
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
										text = "A"
									Else
										text = "I"
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text)))
									End If
									Dim num2 As Integer = num - 1
									For i As Integer = 0 To num2
										Dim text2 As String = listViewItem.SubItems(0).Text
										Dim text3 As String = listViewItem.SubItems(1).Text
										Dim text4 As String = listViewItem.SubItems(2).Text
										Dim text5 As String = listViewItem.SubItems(3).Text
										Dim text6 As String = listViewItem.SubItems(4).Text
										Dim text7 As String = listViewItem.SubItems(5).Text
										Dim text8 As String = listViewItem.SubItems(6).Text
										Dim text9 As String = listViewItem.SubItems(7).Text
										Dim text10 As String = listViewItem.SubItems(8).Text
										Dim text11 As String = listViewItem.SubItems(9).Text
										Dim text12 As String = listViewItem.SubItems(10).Text
										Dim text13 As String = listViewItem.SubItems(11).Text
										Dim text14 As String = listViewItem.SubItems(12).Text
										Dim text15 As String = listViewItem.SubItems(13).Text
										Dim text16 As String = listViewItem.SubItems(14).Text
										Dim text17 As String = listViewItem.SubItems(15).Text
										Dim text18 As String = listViewItem.SubItems(16).Text
										Dim text19 As String = listViewItem.SubItems(17).Text
										Dim text20 As String = listViewItem.SubItems(18).Text
										dataTable2.Rows.Add(New Object() { text2, listViewItem.SubItems(1).Text, listViewItem.SubItems(2).Text, listViewItem.SubItems(3).Text, listViewItem.SubItems(4).Text, listViewItem.SubItems(5).Text, listViewItem.SubItems(6).Text, listViewItem.SubItems(7).Text, listViewItem.SubItems(8).Text, listViewItem.SubItems(9).Text, listViewItem.SubItems(10).Text, listViewItem.SubItems(11).Text, listViewItem.SubItems(12).Text, listViewItem.SubItems(13).Text, listViewItem.SubItems(14).Text, listViewItem.SubItems(15).Text, listViewItem.SubItems(16).Text, listViewItem.SubItems(17).Text, listViewItem.SubItems(18).Text })
									Next
									list.Add(num - 1)
									list2.Add(dataSet.Tables(0))
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim checked2 As Boolean = Me.CheckBox1.Checked
							If checked2 Then
								num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text)))
							End If
							Dim flag4 As Boolean = Operators.CompareString(text, "A", False) = 0
							If flag4 Then
								Dim num3 As Integer = num - 1
								For j As Integer = 0 To num3
									Try
										For Each dataTable4 As DataTable In list2
											Try
												For Each obj2 As Object In dataTable4.Rows
													Dim dataRow As DataRow = CType(obj2, DataRow)
													dataTable.ImportRow(dataRow)
												Next
											Finally
												Dim enumerator3 As IEnumerator
												If TypeOf enumerator3 Is IDisposable Then
													TryCast(enumerator3, IDisposable).Dispose()
												End If
											End Try
										Next
									Finally
										Dim enumerator2 As List(Of DataTable).Enumerator
										CType(enumerator2, IDisposable).Dispose()
									End Try
								Next
							Else
								Dim flag5 As Boolean = Operators.CompareString(text, "I", False) = 0
								If flag5 Then
									Dim count As Integer = list2.Count
									Dim num4 As Integer = 0
									Try
										For Each num5 As Integer In list
											Dim flag6 As Boolean = num5 = 0
											If flag6 Then
												Dim dataTable5 As DataTable = list2(num4)
												Dim flag7 As Boolean = dataTable5.Rows.Count > 0
												If flag7 Then
													Try
														For Each obj3 As Object In dataTable5.Rows
															Dim dataRow2 As DataRow = CType(obj3, DataRow)
															dataTable.ImportRow(dataRow2)
														Next
													Finally
														Dim enumerator5 As IEnumerator
														If TypeOf enumerator5 Is IDisposable Then
															TryCast(enumerator5, IDisposable).Dispose()
														End If
													End Try
												End If
											Else
												Dim num6 As Integer = num5
												For k As Integer = 0 To num6
													Dim dataTable6 As DataTable = list2(num4)
													Try
														For Each obj4 As Object In dataTable6.Rows
															Dim dataRow3 As DataRow = CType(obj4, DataRow)
															dataTable.ImportRow(dataRow3)
														Next
													Finally
														Dim enumerator6 As IEnumerator
														If TypeOf enumerator6 Is IDisposable Then
															TryCast(enumerator6, IDisposable).Dispose()
														End If
													End Try
												Next
											End If
											num4 += 1
										Next
									Finally
										Dim enumerator4 As List(Of Integer).Enumerator
										CType(enumerator4, IDisposable).Dispose()
									End Try
								End If
							End If
							dataTable.DefaultView.Sort = "Barcode ASC"
							dataTable = dataTable.DefaultView.ToTable()
							Dim reportDocument As ReportDocument = New ReportDocument()
							Dim flag8 As Boolean = Conversions.ToDouble(Me.StyleId) = 1.0
							If flag8 Then
								Dim reportDocument2 As ReportDocument = New ReportDocument()
								reportDocument2.Load(Application.StartupPath + "\CryReport\BarcodeT1.rpt")
								reportDocument2.SetDataSource(dataTable)
								reportDocument2.SetParameterValue("P1", Me.txtCompany.Text)
								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument2
								MyProject.Forms.frmReport.ShowDialog()
								MyProject.Forms.frmReport.Dispose()
							Else
								Dim flag9 As Boolean = Conversions.ToDouble(Me.StyleId) = 2.0
								If flag9 Then
									Dim reportDocument3 As ReportDocument = New ReportDocument()
									reportDocument3.Load(Application.StartupPath + "\CryReport\BarcodeT2.rpt")
									reportDocument3.SetDataSource(dataTable)
									reportDocument3.SetParameterValue("P1", Me.txtCompany.Text)
									MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument3
									MyProject.Forms.frmReport.ShowDialog()
									MyProject.Forms.frmReport.Dispose()
								Else
									Dim flag10 As Boolean = Conversions.ToDouble(Me.StyleId) = 3.0
									If flag10 Then
										reportDocument = New BarcodeT3()
									End If
									Dim flag11 As Boolean = Conversions.ToDouble(Me.StyleId) = 4.0
									If flag11 Then
										reportDocument = New BarcodeT4()
									End If
									Dim flag12 As Boolean = Conversions.ToDouble(Me.StyleId) = 5.0
									If flag12 Then
										reportDocument = New BarcodeT5()
									End If
									Dim flag13 As Boolean = Conversions.ToDouble(Me.StyleId) = 6.0
									If flag13 Then
										Dim reportDocument4 As ReportDocument = New ReportDocument()
										reportDocument4.Load(Application.StartupPath + "\CryReport\BarcodeT6.rpt")
										reportDocument4.SetDataSource(dataTable)
										reportDocument4.SetParameterValue("P1", Me.txtCompany.Text)
										MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument4
										MyProject.Forms.frmReport.ShowDialog()
										MyProject.Forms.frmReport.Dispose()
									Else
										Dim flag14 As Boolean = Conversions.ToDouble(Me.StyleId) = 7.0
										If flag14 Then
											Dim reportDocument5 As ReportDocument = New ReportDocument()
											reportDocument5.Load(Application.StartupPath + "\CryReport\BarcodeT7.rpt")
											reportDocument5.SetDataSource(dataTable)
											reportDocument5.SetParameterValue("P1", Me.txtCompany.Text)
											MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument5
											MyProject.Forms.frmReport.ShowDialog()
											MyProject.Forms.frmReport.Dispose()
										Else
											Dim flag15 As Boolean = Conversions.ToDouble(Me.StyleId) = 8.0
											If flag15 Then
												Dim reportDocument6 As ReportDocument = New ReportDocument()
												reportDocument6.Load(Application.StartupPath + "\CryReport\BarcodeT8.rpt")
												reportDocument6.SetDataSource(dataTable)
												reportDocument6.SetParameterValue("P1", Me.txtCompany.Text)
												MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument6
												MyProject.Forms.frmReport.ShowDialog()
												MyProject.Forms.frmReport.Dispose()
											Else
												Dim flag16 As Boolean = Conversions.ToDouble(Me.StyleId) = 9.0
												If flag16 Then
													Dim reportDocument7 As ReportDocument = New ReportDocument()
													reportDocument7.Load(Application.StartupPath + "\CryReport\BarcodeT9.rpt")
													reportDocument7.SetDataSource(dataTable)
													reportDocument7.SetParameterValue("P1", Me.txtCompany.Text)
													MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument7
													MyProject.Forms.frmReport.ShowDialog()
													MyProject.Forms.frmReport.Dispose()
												Else
													Dim flag17 As Boolean = Conversions.ToDouble(Me.StyleId) = 10.0
													If flag17 Then
														Dim reportDocument8 As ReportDocument = New ReportDocument()
														reportDocument8.Load(Application.StartupPath + "\CryReport\BarcodeT10.rpt")
														reportDocument8.SetDataSource(dataTable)
														reportDocument8.SetParameterValue("P1", Me.txtCompany.Text)
														MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument8
														MyProject.Forms.frmReport.ShowDialog()
														MyProject.Forms.frmReport.Dispose()
													Else
														Dim flag18 As Boolean = Conversions.ToDouble(Me.StyleId) = 11.0
														If flag18 Then
															Dim reportDocument9 As ReportDocument = New ReportDocument()
															reportDocument9.Load(Application.StartupPath + "\CryReport\BarcodeT11.rpt")
															reportDocument9.SetDataSource(dataTable)
															reportDocument9.SetParameterValue("P1", Me.txtCompany.Text)
															MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument9
															MyProject.Forms.frmReport.ShowDialog()
															MyProject.Forms.frmReport.Dispose()
														Else
															Dim flag19 As Boolean = Conversions.ToDouble(Me.StyleId) = 12.0
															If flag19 Then
																Dim reportDocument10 As ReportDocument = New ReportDocument()
																reportDocument10.Load(Application.StartupPath + "\CryReport\BarcodeT12.rpt")
																reportDocument10.SetDataSource(dataTable)
																reportDocument10.SetParameterValue("P1", Me.txtCompany.Text)
																MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument10
																MyProject.Forms.frmReport.ShowDialog()
																MyProject.Forms.frmReport.Dispose()
															Else
																Dim flag20 As Boolean = Conversions.ToDouble(Me.StyleId) = 13.0
																If flag20 Then
																	Dim reportDocument11 As ReportDocument = New ReportDocument()
																	reportDocument11.Load(Application.StartupPath + "\CryReport\BarcodeCustomise1.rpt")
																	reportDocument11.SetDataSource(dataTable)
																	reportDocument11.SetParameterValue("P1", Me.txtCompany.Text)
																	MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument11
																	MyProject.Forms.frmReport.ShowDialog()
																	MyProject.Forms.frmReport.Dispose()
																Else
																	Dim flag21 As Boolean = Conversions.ToDouble(Me.StyleId) = 14.0
																	If flag21 Then
																		Dim reportDocument12 As ReportDocument = New ReportDocument()
																		reportDocument12.Load(Application.StartupPath + "\CryReport\BarcodeCustomise2.rpt")
																		reportDocument12.SetDataSource(dataTable)
																		reportDocument12.SetParameterValue("P1", Me.txtCompany.Text)
																		MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument12
																		MyProject.Forms.frmReport.ShowDialog()
																		MyProject.Forms.frmReport.Dispose()
																	Else
																		Dim flag22 As Boolean = Conversions.ToDouble(Me.StyleId) = 15.0
																		If flag22 Then
																			Dim reportDocument13 As ReportDocument = New ReportDocument()
																			reportDocument13.Load(Application.StartupPath + "\CryReport\BarcodeT13.rpt")
																			reportDocument13.SetDataSource(dataTable)
																			reportDocument13.SetParameterValue("P1", Me.txtCompany.Text)
																			MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument13
																			MyProject.Forms.frmReport.ShowDialog()
																			MyProject.Forms.frmReport.Dispose()
																		Else
																			Dim flag23 As Boolean = Conversions.ToDouble(Me.StyleId) = 16.0
																			If flag23 Then
																				Dim reportDocument14 As ReportDocument = New ReportDocument()
																				reportDocument14.Load(Application.StartupPath + "\CryReport\BarcodeT14.rpt")
																				reportDocument14.SetDataSource(dataTable)
																				reportDocument14.SetParameterValue("P1", Me.txtCompany.Text)
																				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument14
																				MyProject.Forms.frmReport.ShowDialog()
																				MyProject.Forms.frmReport.Dispose()
																			Else
																				Dim flag24 As Boolean = Conversions.ToDouble(Me.StyleId) = 17.0
																				If flag24 Then
																					Dim reportDocument15 As ReportDocument = New ReportDocument()
																					reportDocument15.Load(Application.StartupPath + "\CryReport\BarcodeT15.rpt")
																					reportDocument15.SetDataSource(dataTable)
																					reportDocument15.SetParameterValue("P1", Me.txtCompany.Text)
																					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument15
																					MyProject.Forms.frmReport.ShowDialog()
																					MyProject.Forms.frmReport.Dispose()
																				Else
																					Dim flag25 As Boolean = Conversions.ToDouble(Me.StyleId) = 18.0
																					If flag25 Then
																						Dim reportDocument16 As ReportDocument = New ReportDocument()
																						reportDocument16.Load(Application.StartupPath + "\CryReport\BarcodeT16.rpt")
																						reportDocument16.SetDataSource(dataTable)
																						reportDocument16.SetParameterValue("P1", Me.txtCompany.Text)
																						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument16
																						MyProject.Forms.frmReport.ShowDialog()
																						MyProject.Forms.frmReport.Dispose()
																					Else
																						Dim flag26 As Boolean = Conversions.ToDouble(Me.StyleId) = 19.0
																						If flag26 Then
																							Dim reportDocument17 As ReportDocument = New ReportDocument()
																							reportDocument17.Load(Application.StartupPath + "\CryReport\BarcodeT17.rpt")
																							reportDocument17.SetDataSource(dataTable)
																							reportDocument17.SetParameterValue("P1", Me.txtCompany.Text)
																							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument17
																							MyProject.Forms.frmReport.ShowDialog()
																							MyProject.Forms.frmReport.Dispose()
																						Else
																							Dim flag27 As Boolean = Conversions.ToDouble(Me.StyleId) = 20.0
																							If flag27 Then
																								Dim reportDocument18 As ReportDocument = New ReportDocument()
																								reportDocument18.Load(Application.StartupPath + "\CryReport\BarcodeT18.rpt")
																								reportDocument18.SetDataSource(dataTable)
																								reportDocument18.SetParameterValue("P1", Me.txtCompany.Text)
																								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument18
																								MyProject.Forms.frmReport.ShowDialog()
																								MyProject.Forms.frmReport.Dispose()
																							Else
																								reportDocument.SetDataSource(dataTable2)
																								reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
																								MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
																								MyProject.Forms.frmReport.ShowDialog()
																								MyProject.Forms.frmReport.Dispose()
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
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060116A1 RID: 71329 RVA: 0x00A19CB8 File Offset: 0x00A17EB8
		Public Sub PrintQRBarcode()
			Dim dataSet As DataSet = New DataSet()
			Dim flag As Boolean = Me.listView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Barcode list not found", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.listView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select Barcode list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Me.ComboBox2.SelectedIndex = -1
					If flag3 Then
						MessageBox.Show("Please select Barcode Template", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Try
								For Each obj As Object In Me.listView1.CheckedItems
									Dim listViewItem As ListViewItem = CType(obj, ListViewItem)
									Dim checked As Boolean = Me.CheckBox1.Checked
									Dim num As Integer
									If checked Then
										num = Integer.Parse(Conversions.ToString(Conversion.Val(Me.txtNoOfCopies.Text))) - 1
									Else
										num = Integer.Parse(Conversions.ToString(Conversion.Val(listViewItem.SubItems(5).Text))) - 1
									End If
									Dim num2 As Integer = num
									For i As Integer = 0 To num2
										dataSet = Me.printCustomBarcode(listViewItem.SubItems(3).Text)
									Next
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							Dim reportDocument As ReportDocument = New ReportDocument()
							reportDocument = New BarcodeCustomise1()
							reportDocument.SetDataSource(dataSet)
							reportDocument.SetParameterValue("P1", Me.txtCompany.Text)
							MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
							MyProject.Forms.frmReport.ShowDialog()
							MyProject.Forms.frmReport.Dispose()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060116A2 RID: 71330 RVA: 0x00A19EF0 File Offset: 0x00A180F0
		Private Function printCustomBarcode(barcode As String) As DataSet
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
			Dim sqlCommand As SqlCommand = New SqlCommand()
			Dim sqlCommand2 As SqlCommand = New SqlCommand()
			Dim dataSet As DataSet = New DataSet()
			Dim dataSet2 As DataSet = New DataSet()
			Try
				Dim text As String = "Select ProductCode,ProductName,(Category),Temp_Stock.Barcode,Temp_Stock.Qty,(PartNo),(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),(Product.CGST),(Product.SGST),QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.barcode in(" + barcode + ")"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = ModCommonClasses.con
				sqlCommand.CommandText = text
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				ModCommonClasses.con.Open()
				sqlDataAdapter.Fill(dataSet, "DataTable2")
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Return dataSet
		End Function

		' Token: 0x060116A3 RID: 71331 RVA: 0x00A19FD8 File Offset: 0x00A181D8
		Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Me.ComboBox1.SelectedIndex = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and ProductName like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 1
				If flag2 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Category like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 2
				If flag3 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Barcode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 3
				If flag4 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and PartNo like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 4
				If flag5 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and HSNCode like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 5
				If flag6 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Batch like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag7 As Boolean = Me.ComboBox1.SelectedIndex = 6
				If flag7 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Size like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				Dim flag8 As Boolean = Me.ComboBox1.SelectedIndex = 7
				If flag8 Then
					ModCommonClasses.cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock.Barcode),Temp_Stock.Qty,RTRIM(PartNo),RTRIM(HSNCode),(Temp_Stock.MRP),(Temp_Stock.SPrice),(Temp_Stock.WPrice),(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),(Temp_Stock.Size),(Temp_Stock.Colour),((Product.CGST)+(Product.SGST)),'',QrBarcode,Product.Discount from Category,SubCategory,Product,Temp_Stock where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Temp_Stock.ProductID=Product.PID and Product.Status='Yes' and Qty > 0 and Temp_Stock.Colour like N'" + Me.txtSearch.Text + "%' order by Productname", ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.listView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add("1")
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(6).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(7).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(8).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(9).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(10).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(11).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(12).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(13).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(14).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(15).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(16).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(17).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(18).ToString().Trim())
					Me.listView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.listView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.listView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060116A4 RID: 71332 RVA: 0x00077DC8 File Offset: 0x00075FC8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060116A5 RID: 71333 RVA: 0x00A1A570 File Offset: 0x00A18770
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.RadioButton1.Checked
			If checked Then
				Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise1.rpt")
			Else
				Dim checked2 As Boolean = Me.RadioButton2.Checked
				If checked2 Then
					Process.Start(MyProject.Application.Info.DirectoryPath + "\CryReport\BarcodeCustomise2.rpt")
				End If
			End If
		End Sub

		' Token: 0x060116A6 RID: 71334 RVA: 0x00A1A5E0 File Offset: 0x00A187E0
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.StyleId, "", False) <> 0
			If flag Then
				Me.defaulyprinterUpdate()
				Me.Print()
			Else
				MessageBox.Show("Barcode Style Not Selected!")
			End If
		End Sub

		' Token: 0x060116A7 RID: 71335 RVA: 0x00A1A624 File Offset: 0x00A18824
		Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim text As String = Me.ComboBox2.Text.ToString()
				Dim text2 As String = Application.StartupPath + "\Bill_barcode\" + text + ".JPG"
				Dim flag As Boolean = File.Exists(text2)
				If flag Then
					Me.PictureBox5.Image = Image.FromFile(text2)
				Else
					MessageBox.Show("Image not found at: " + text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060116A8 RID: 71336 RVA: 0x00A1A6D4 File Offset: 0x00A188D4
		Private Sub dgwBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgwBill.SelectedRows(0)
				Dim text As String = Application.StartupPath + "\Bill_Barcode\" + dataGridViewRow.Cells(3).Value.ToString()
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					Me.PictureBox5.Image = Image.FromFile(text)
				Else
					Me.PictureBox5.Image = Nothing
					MessageBox.Show("Image not found at: " + text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
				Me.testval = dataGridViewRow.Cells(1).Value.ToString()
				Me.StyleId = dataGridViewRow.Cells(0).Value.ToString()
				Me.pagetype = dataGridViewRow.Cells(2).Value.ToString()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060116A9 RID: 71337 RVA: 0x00A1A7F8 File Offset: 0x00A189F8
		Private Sub defaulyprinterUpdate()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				Dim text As String = "update BarcodePreview set is_active=0"
				ModCommonClasses.cmd1 = New SqlCommand(text)
				ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
				ModCommonClasses.cmd1.ExecuteReader()
				ModCommonClasses.con1.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "update BarcodePreview set is_active=1 where BarcodeStyleId=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.StyleId)
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060116AA RID: 71338 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub FlowPanelBill_Paint(sender As Object, e As PaintEventArgs)
		End Sub

		' Token: 0x060116AB RID: 71339 RVA: 0x00A1A8FC File Offset: 0x00A18AFC
		Private Sub GelButton11_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.StyleId, "", False) <> 0
			If flag Then
				Me.defaulyprinterUpdate()
			Else
				MessageBox.Show("Barcode Style Not Selected!")
			End If
		End Sub

		' Token: 0x040068F1 RID: 26865
		Private st As String

		' Token: 0x040068F2 RID: 26866
		Private testval As String

		' Token: 0x040068F3 RID: 26867
		Private StyleId As String

		' Token: 0x040068F4 RID: 26868
		Private pagetype As String

		' Token: 0x040068F6 RID: 26870
		Private bCancelEdit As Boolean

		' Token: 0x040068F7 RID: 26871
		Private CurrentSB As ListViewItem.ListViewSubItem

		' Token: 0x040068F8 RID: 26872
		Private CurrentItem As ListViewItem
	End Class
End Namespace
