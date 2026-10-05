Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005A9 RID: 1449
	<DesignerGenerated()>
	Public Partial Class frmSalesman
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011B21 RID: 72481 RVA: 0x00A39460 File Offset: 0x00A37660
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesman_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesman_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006DEF RID: 28143
		' (get) Token: 0x06011B24 RID: 72484 RVA: 0x00079AAB File Offset: 0x00077CAB
		' (set) Token: 0x06011B25 RID: 72485 RVA: 0x00079AB5 File Offset: 0x00077CB5
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006DF0 RID: 28144
		' (get) Token: 0x06011B26 RID: 72486 RVA: 0x00079ABE File Offset: 0x00077CBE
		' (set) Token: 0x06011B27 RID: 72487 RVA: 0x00079AC8 File Offset: 0x00077CC8
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006DF1 RID: 28145
		' (get) Token: 0x06011B28 RID: 72488 RVA: 0x00079AD1 File Offset: 0x00077CD1
		' (set) Token: 0x06011B29 RID: 72489 RVA: 0x00079ADB File Offset: 0x00077CDB
		Friend Overridable Property Label3 As Label

		' Token: 0x17006DF2 RID: 28146
		' (get) Token: 0x06011B2A RID: 72490 RVA: 0x00079AE4 File Offset: 0x00077CE4
		' (set) Token: 0x06011B2B RID: 72491 RVA: 0x00079AEE File Offset: 0x00077CEE
		Friend Overridable Property txtSalesmanID As TextBox

		' Token: 0x17006DF3 RID: 28147
		' (get) Token: 0x06011B2C RID: 72492 RVA: 0x00079AF7 File Offset: 0x00077CF7
		' (set) Token: 0x06011B2D RID: 72493 RVA: 0x00079B01 File Offset: 0x00077D01
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006DF4 RID: 28148
		' (get) Token: 0x06011B2E RID: 72494 RVA: 0x00079B0A File Offset: 0x00077D0A
		' (set) Token: 0x06011B2F RID: 72495 RVA: 0x00079B14 File Offset: 0x00077D14
		Friend Overridable Property Label1 As Label

		' Token: 0x17006DF5 RID: 28149
		' (get) Token: 0x06011B30 RID: 72496 RVA: 0x00079B1D File Offset: 0x00077D1D
		' (set) Token: 0x06011B31 RID: 72497 RVA: 0x00079B27 File Offset: 0x00077D27
		Friend Overridable Property Label7 As Label

		' Token: 0x17006DF6 RID: 28150
		' (get) Token: 0x06011B32 RID: 72498 RVA: 0x00079B30 File Offset: 0x00077D30
		' (set) Token: 0x06011B33 RID: 72499 RVA: 0x00079B3A File Offset: 0x00077D3A
		Friend Overridable Property Label6 As Label

		' Token: 0x17006DF7 RID: 28151
		' (get) Token: 0x06011B34 RID: 72500 RVA: 0x00079B43 File Offset: 0x00077D43
		' (set) Token: 0x06011B35 RID: 72501 RVA: 0x00079B4D File Offset: 0x00077D4D
		Friend Overridable Property Label5 As Label

		' Token: 0x17006DF8 RID: 28152
		' (get) Token: 0x06011B36 RID: 72502 RVA: 0x00079B56 File Offset: 0x00077D56
		' (set) Token: 0x06011B37 RID: 72503 RVA: 0x00A3BD68 File Offset: 0x00A39F68
		Private _txtAddress As TextBox
		Friend Overridable Property txtAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAddress_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtAddress = value
				textBox = Me._txtAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DF9 RID: 28153
		' (get) Token: 0x06011B38 RID: 72504 RVA: 0x00079B60 File Offset: 0x00077D60
		' (set) Token: 0x06011B39 RID: 72505 RVA: 0x00A3BDC8 File Offset: 0x00A39FC8
		Private _txtRemarks As TextBox
		Friend Overridable Property txtRemarks As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim textBox As TextBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				textBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DFA RID: 28154
		' (get) Token: 0x06011B3A RID: 72506 RVA: 0x00079B6A File Offset: 0x00077D6A
		' (set) Token: 0x06011B3B RID: 72507 RVA: 0x00079B74 File Offset: 0x00077D74
		Friend Overridable Property Label2 As Label

		' Token: 0x17006DFB RID: 28155
		' (get) Token: 0x06011B3C RID: 72508 RVA: 0x00079B7D File Offset: 0x00077D7D
		' (set) Token: 0x06011B3D RID: 72509 RVA: 0x00079B87 File Offset: 0x00077D87
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006DFC RID: 28156
		' (get) Token: 0x06011B3E RID: 72510 RVA: 0x00079B90 File Offset: 0x00077D90
		' (set) Token: 0x06011B3F RID: 72511 RVA: 0x00079B9A File Offset: 0x00077D9A
		Friend Overridable Property lblUser As Label

		' Token: 0x17006DFD RID: 28157
		' (get) Token: 0x06011B40 RID: 72512 RVA: 0x00079BA3 File Offset: 0x00077DA3
		' (set) Token: 0x06011B41 RID: 72513 RVA: 0x00A3BE0C File Offset: 0x00A3A00C
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtEmailID_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.txtEmailID_Validating
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtEmailID_KeyDown
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DFE RID: 28158
		' (get) Token: 0x06011B42 RID: 72514 RVA: 0x00079BAD File Offset: 0x00077DAD
		' (set) Token: 0x06011B43 RID: 72515 RVA: 0x00A3BE88 File Offset: 0x00A3A088
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DFF RID: 28159
		' (get) Token: 0x06011B44 RID: 72516 RVA: 0x00079BB7 File Offset: 0x00077DB7
		' (set) Token: 0x06011B45 RID: 72517 RVA: 0x00079BC1 File Offset: 0x00077DC1
		Friend Overridable Property Label10 As Label

		' Token: 0x17006E00 RID: 28160
		' (get) Token: 0x06011B46 RID: 72518 RVA: 0x00079BCA File Offset: 0x00077DCA
		' (set) Token: 0x06011B47 RID: 72519 RVA: 0x00079BD4 File Offset: 0x00077DD4
		Friend Overridable Property Label4 As Label

		' Token: 0x17006E01 RID: 28161
		' (get) Token: 0x06011B48 RID: 72520 RVA: 0x00079BDD File Offset: 0x00077DDD
		' (set) Token: 0x06011B49 RID: 72521 RVA: 0x00A3BF04 File Offset: 0x00A3A104
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCity_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E02 RID: 28162
		' (get) Token: 0x06011B4A RID: 72522 RVA: 0x00079BE7 File Offset: 0x00077DE7
		' (set) Token: 0x06011B4B RID: 72523 RVA: 0x00079BF1 File Offset: 0x00077DF1
		Public Overridable Property Picture As PictureBox

		' Token: 0x17006E03 RID: 28163
		' (get) Token: 0x06011B4C RID: 72524 RVA: 0x00079BFA File Offset: 0x00077DFA
		' (set) Token: 0x06011B4D RID: 72525 RVA: 0x00A3BF64 File Offset: 0x00A3A164
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E04 RID: 28164
		' (get) Token: 0x06011B4E RID: 72526 RVA: 0x00079C04 File Offset: 0x00077E04
		' (set) Token: 0x06011B4F RID: 72527 RVA: 0x00A3BFA8 File Offset: 0x00A3A1A8
		Private _Browse As Button
		Friend Overridable Property Browse As Button
			<CompilerGenerated()>
			Get
				Return Me._Browse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Browse_Click
				Dim button As Button = Me._Browse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Browse = value
				button = Me._Browse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E05 RID: 28165
		' (get) Token: 0x06011B50 RID: 72528 RVA: 0x00079C0E File Offset: 0x00077E0E
		' (set) Token: 0x06011B51 RID: 72529 RVA: 0x00A3BFEC File Offset: 0x00A3A1EC
		Private _BRemove As Button
		Friend Overridable Property BRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._BRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BRemove_Click
				Dim button As Button = Me._BRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BRemove = value
				button = Me._BRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E06 RID: 28166
		' (get) Token: 0x06011B52 RID: 72530 RVA: 0x00079C18 File Offset: 0x00077E18
		' (set) Token: 0x06011B53 RID: 72531 RVA: 0x00079C22 File Offset: 0x00077E22
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17006E07 RID: 28167
		' (get) Token: 0x06011B54 RID: 72532 RVA: 0x00079C2B File Offset: 0x00077E2B
		' (set) Token: 0x06011B55 RID: 72533 RVA: 0x00079C35 File Offset: 0x00077E35
		Friend Overridable Property Label12 As Label

		' Token: 0x17006E08 RID: 28168
		' (get) Token: 0x06011B56 RID: 72534 RVA: 0x00079C3E File Offset: 0x00077E3E
		' (set) Token: 0x06011B57 RID: 72535 RVA: 0x00079C48 File Offset: 0x00077E48
		Friend Overridable Property Label9 As Label

		' Token: 0x17006E09 RID: 28169
		' (get) Token: 0x06011B58 RID: 72536 RVA: 0x00079C51 File Offset: 0x00077E51
		' (set) Token: 0x06011B59 RID: 72537 RVA: 0x00A3C030 File Offset: 0x00A3A230
		Private _txtZipCode As TextBox
		Friend Overridable Property txtZipCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtZipCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtZipCode_KeyDown
				Dim textBox As TextBox = Me._txtZipCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtZipCode = value
				textBox = Me._txtZipCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E0A RID: 28170
		' (get) Token: 0x06011B5A RID: 72538 RVA: 0x00079C5B File Offset: 0x00077E5B
		' (set) Token: 0x06011B5B RID: 72539 RVA: 0x00A3C074 File Offset: 0x00A3A274
		Private _cmbState As ComboBox
		Friend Overridable Property cmbState As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbState
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbState_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbState_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbState = value
				comboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E0B RID: 28171
		' (get) Token: 0x06011B5C RID: 72540 RVA: 0x00079C65 File Offset: 0x00077E65
		' (set) Token: 0x06011B5D RID: 72541 RVA: 0x00079C6F File Offset: 0x00077E6F
		Friend Overridable Property Label11 As Label

		' Token: 0x17006E0C RID: 28172
		' (get) Token: 0x06011B5E RID: 72542 RVA: 0x00079C78 File Offset: 0x00077E78
		' (set) Token: 0x06011B5F RID: 72543 RVA: 0x00A3C0F0 File Offset: 0x00A3A2F0
		Private _txtCommissionPer As TextBox
		Friend Overridable Property txtCommissionPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCommissionPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCommissionPer_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCommissionPer_KeyDown
				Dim textBox As TextBox = Me._txtCommissionPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCommissionPer = value
				textBox = Me._txtCommissionPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E0D RID: 28173
		' (get) Token: 0x06011B60 RID: 72544 RVA: 0x00079C82 File Offset: 0x00077E82
		' (set) Token: 0x06011B61 RID: 72545 RVA: 0x00079C8C File Offset: 0x00077E8C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006E0E RID: 28174
		' (get) Token: 0x06011B62 RID: 72546 RVA: 0x00079C95 File Offset: 0x00077E95
		' (set) Token: 0x06011B63 RID: 72547 RVA: 0x00079C9F File Offset: 0x00077E9F
		Friend Overridable Property txtEmail As TextBox

		' Token: 0x17006E0F RID: 28175
		' (get) Token: 0x06011B64 RID: 72548 RVA: 0x00079CA8 File Offset: 0x00077EA8
		' (set) Token: 0x06011B65 RID: 72549 RVA: 0x00079CB2 File Offset: 0x00077EB2
		Friend Overridable Property Label16 As Label

		' Token: 0x17006E10 RID: 28176
		' (get) Token: 0x06011B66 RID: 72550 RVA: 0x00079CBB File Offset: 0x00077EBB
		' (set) Token: 0x06011B67 RID: 72551 RVA: 0x00079CC5 File Offset: 0x00077EC5
		Friend Overridable Property Label15 As Label

		' Token: 0x17006E11 RID: 28177
		' (get) Token: 0x06011B68 RID: 72552 RVA: 0x00079CCE File Offset: 0x00077ECE
		' (set) Token: 0x06011B69 RID: 72553 RVA: 0x00079CD8 File Offset: 0x00077ED8
		Friend Overridable Property Label14 As Label

		' Token: 0x17006E12 RID: 28178
		' (get) Token: 0x06011B6A RID: 72554 RVA: 0x00079CE1 File Offset: 0x00077EE1
		' (set) Token: 0x06011B6B RID: 72555 RVA: 0x00079CEB File Offset: 0x00077EEB
		Friend Overridable Property Label13 As Label

		' Token: 0x17006E13 RID: 28179
		' (get) Token: 0x06011B6C RID: 72556 RVA: 0x00079CF4 File Offset: 0x00077EF4
		' (set) Token: 0x06011B6D RID: 72557 RVA: 0x00079CFE File Offset: 0x00077EFE
		Friend Overridable Property Label33 As Label

		' Token: 0x17006E14 RID: 28180
		' (get) Token: 0x06011B6E RID: 72558 RVA: 0x00079D07 File Offset: 0x00077F07
		' (set) Token: 0x06011B6F RID: 72559 RVA: 0x00A3C150 File Offset: 0x00A3A350
		Private _cmbSalesmanName As ComboBox
		Friend Overridable Property cmbSalesmanName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSalesmanName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSalesmanName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSalesmanName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSalesmanName = value
				comboBox = Me._cmbSalesmanName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E15 RID: 28181
		' (get) Token: 0x06011B70 RID: 72560 RVA: 0x00079D11 File Offset: 0x00077F11
		' (set) Token: 0x06011B71 RID: 72561 RVA: 0x00A3C1B0 File Offset: 0x00A3A3B0
		Private _btnNext As Button
		Friend Overridable Property btnNext As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNext
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNext_Click
				Dim button As Button = Me._btnNext
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNext = value
				button = Me._btnNext
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E16 RID: 28182
		' (get) Token: 0x06011B72 RID: 72562 RVA: 0x00079D1B File Offset: 0x00077F1B
		' (set) Token: 0x06011B73 RID: 72563 RVA: 0x00A3C1F4 File Offset: 0x00A3A3F4
		Private _btnFirst As Button
		Friend Overridable Property btnFirst As Button
			<CompilerGenerated()>
			Get
				Return Me._btnFirst
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnFirst_Click
				Dim button As Button = Me._btnFirst
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnFirst = value
				button = Me._btnFirst
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E17 RID: 28183
		' (get) Token: 0x06011B74 RID: 72564 RVA: 0x00079D25 File Offset: 0x00077F25
		' (set) Token: 0x06011B75 RID: 72565 RVA: 0x00A3C238 File Offset: 0x00A3A438
		Private _txtPrev As Button
		Friend Overridable Property txtPrev As Button
			<CompilerGenerated()>
			Get
				Return Me._txtPrev
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.txtPrev_Click
				Dim button As Button = Me._txtPrev
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._txtPrev = value
				button = Me._txtPrev
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E18 RID: 28184
		' (get) Token: 0x06011B76 RID: 72566 RVA: 0x00079D2F File Offset: 0x00077F2F
		' (set) Token: 0x06011B77 RID: 72567 RVA: 0x00A3C27C File Offset: 0x00A3A47C
		Private _btnLast As Button
		Friend Overridable Property btnLast As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLast
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLast_Click
				Dim button As Button = Me._btnLast
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLast = value
				button = Me._btnLast
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E19 RID: 28185
		' (get) Token: 0x06011B78 RID: 72568 RVA: 0x00079D39 File Offset: 0x00077F39
		' (set) Token: 0x06011B79 RID: 72569 RVA: 0x00079D43 File Offset: 0x00077F43
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006E1A RID: 28186
		' (get) Token: 0x06011B7A RID: 72570 RVA: 0x00079D4C File Offset: 0x00077F4C
		' (set) Token: 0x06011B7B RID: 72571 RVA: 0x00A3C2C0 File Offset: 0x00A3A4C0
		Private _txtNP As TextBox
		Friend Overridable Property txtNP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtNP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtNP_KeyDown
				Dim textBox As TextBox = Me._txtNP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtNP = value
				textBox = Me._txtNP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E1B RID: 28187
		' (get) Token: 0x06011B7C RID: 72572 RVA: 0x00079D56 File Offset: 0x00077F56
		' (set) Token: 0x06011B7D RID: 72573 RVA: 0x00079D60 File Offset: 0x00077F60
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006E1C RID: 28188
		' (get) Token: 0x06011B7E RID: 72574 RVA: 0x00079D69 File Offset: 0x00077F69
		' (set) Token: 0x06011B7F RID: 72575 RVA: 0x00079D73 File Offset: 0x00077F73
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006E1D RID: 28189
		' (get) Token: 0x06011B80 RID: 72576 RVA: 0x00079D7C File Offset: 0x00077F7C
		' (set) Token: 0x06011B81 RID: 72577 RVA: 0x00A3C304 File Offset: 0x00A3A504
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click_1
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E1E RID: 28190
		' (get) Token: 0x06011B82 RID: 72578 RVA: 0x00079D86 File Offset: 0x00077F86
		' (set) Token: 0x06011B83 RID: 72579 RVA: 0x00A3C348 File Offset: 0x00A3A548
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E1F RID: 28191
		' (get) Token: 0x06011B84 RID: 72580 RVA: 0x00079D90 File Offset: 0x00077F90
		' (set) Token: 0x06011B85 RID: 72581 RVA: 0x00A3C38C File Offset: 0x00A3A58C
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E20 RID: 28192
		' (get) Token: 0x06011B86 RID: 72582 RVA: 0x00079D9A File Offset: 0x00077F9A
		' (set) Token: 0x06011B87 RID: 72583 RVA: 0x00A3C3D0 File Offset: 0x00A3A5D0
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E21 RID: 28193
		' (get) Token: 0x06011B88 RID: 72584 RVA: 0x00079DA4 File Offset: 0x00077FA4
		' (set) Token: 0x06011B89 RID: 72585 RVA: 0x00A3C414 File Offset: 0x00A3A614
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

		' Token: 0x06011B8A RID: 72586 RVA: 0x00A3C458 File Offset: 0x00A3A658
		Public Sub Reset()
			Me.cmbSalesmanName.Text = ""
			Me.txtAddress.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbSalesmanName.Text = ""
			Me.txtSalesmanID.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtEmailID.Text = ""
			Me.txtZipCode.Text = ""
			Me.txtCommissionPer.Text = "0.00"
			Me.txtCity.Text = ""
			Me.cmbSalesmanName.Focus()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.Picture.Image = Resources.photo
			Me.auto()
			Me.cmbState.SelectedIndex = -1
			Me.cmbSalesmanName.Enabled = True
			Me.fillSalesmanName()
			Me.fillSalesmanID()
		End Sub

		' Token: 0x06011B8B RID: 72587 RVA: 0x00A3C584 File Offset: 0x00A3A784
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 SM_ID FROM Salesman ORDER BY SM_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("SM_ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x06011B8C RID: 72588 RVA: 0x00A3C6F0 File Offset: 0x00A3A8F0
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtSalesmanID.Text = "SM-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011B8D RID: 72589 RVA: 0x00A3C764 File Offset: 0x00A3A964
		Public Sub fillSalesmanName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Salesman", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSalesmanName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSalesmanName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011B8E RID: 72590 RVA: 0x00A3C898 File Offset: 0x00A3AA98
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Salesman.SM_ID FROM Salesman INNER JOIN InvoiceInfo ON Salesman.SM_ID = InvoiceInfo.SalesmanID where Salesman.SM_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Billing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Return
				End If
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = If(("delete from Salesman where SM_ID =" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag3 As Boolean = num > 0
				If flag3 Then
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the Salesman record having Salesman id '" + Me.txtSalesmanID.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillSalesmanID()
					Me.Reset()
				Else
					MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillSalesmanID()
					Me.Reset()
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x06011B8F RID: 72591 RVA: 0x00079DAE File Offset: 0x00077FAE
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011B90 RID: 72592 RVA: 0x00A3CABC File Offset: 0x00A3ACBC
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
			Dim frmCamera As frmCamera = New frmCamera()
			frmCamera.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
			End If
		End Sub

		' Token: 0x06011B91 RID: 72593 RVA: 0x00A3CB14 File Offset: 0x00A3AD14
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim frmSalesmanRecord As frmSalesmanRecord = New frmSalesmanRecord()
			frmSalesmanRecord.lblSet.Text = "Salesman Entry"
			frmSalesmanRecord.Getdata()
			frmSalesmanRecord.ShowDialog()
		End Sub

		' Token: 0x06011B92 RID: 72594 RVA: 0x00A3CB48 File Offset: 0x00A3AD48
		Private Sub Browse_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.Picture.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x06011B93 RID: 72595 RVA: 0x00079DB8 File Offset: 0x00077FB8
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources.photo
		End Sub

		' Token: 0x06011B94 RID: 72596 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbState_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06011B95 RID: 72597 RVA: 0x00A3CBE8 File Offset: 0x00A3ADE8
		Private Sub txtCommissionPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCommissionPer.Text
					Dim selectionStart As Integer = Me.txtCommissionPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCommissionPer.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x06011B96 RID: 72598 RVA: 0x00A3CCE0 File Offset: 0x00A3AEE0
		Private Sub txtEmailID_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim text As String = "@"
			Dim flag As Boolean = e.KeyChar <> vbBack
			If flag Then
				Dim flag2 As Boolean = (Strings.Asc(e.KeyChar) < 97) Or (Strings.Asc(e.KeyChar) > 122)
				If flag2 Then
					Dim flag3 As Boolean = (Strings.Asc(e.KeyChar) <> 46) And (Strings.Asc(e.KeyChar) <> 95)
					If flag3 Then
						Dim flag4 As Boolean = (Strings.Asc(e.KeyChar) < 48) Or (Strings.Asc(e.KeyChar) > 57)
						If flag4 Then
							Dim flag5 As Boolean = text.IndexOf(e.KeyChar) = -1
							If flag5 Then
								e.Handled = True
							Else
								Dim flag6 As Boolean = Me.txtEmailID.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011B97 RID: 72599 RVA: 0x00A3CDE8 File Offset: 0x00A3AFE8
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
			Dim text As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
			Dim match As Match = Regex.Match(Me.txtEmailID.Text.Trim(), text, RegexOptions.IgnoreCase)
			Dim success As Boolean = match.Success
			If Not success Then
				MessageBox.Show("Please enter a valid email id", "Checking")
				Me.txtEmailID.Clear()
			End If
		End Sub

		' Token: 0x06011B98 RID: 72600 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06011B99 RID: 72601 RVA: 0x00079DCC File Offset: 0x00077FCC
		Private Sub frmSalesman_Load(sender As Object, e As EventArgs)
			Me.fillSalesmanName()
			Me.fillSalesmanID()
			Me.DataforNP()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011B9A RID: 72602 RVA: 0x00A3CE40 File Offset: 0x00A3B040
		Public Sub Convert_Language()
			Dim text As String = "SELECT RTRIM(default_lang_eng) AS default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
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
						Try
							For Each obj2 As Object In MyBase.Controls
								Dim control As Control = CType(obj2, Control)
								Dim flag2 As Boolean = TypeOf control Is DataGridView
								If flag2 Then
									Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
								End If
								Try
									For Each obj3 As Object In control.Controls
										Dim control2 As Control = CType(obj3, Control)
										Dim flag3 As Boolean = TypeOf control2 Is DataGridView
										If flag3 Then
											Me.UpdateDataGridViewHeaders(CType(control2, DataGridView))
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06011B9B RID: 72603 RVA: 0x00A3D0E0 File Offset: 0x00A3B2E0
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is RadioButton
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

		' Token: 0x06011B9C RID: 72604 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011B9D RID: 72605 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSalesmanName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011B9E RID: 72606 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011B9F RID: 72607 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCity_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA0 RID: 72608 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA1 RID: 72609 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtZipCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA2 RID: 72610 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA3 RID: 72611 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA4 RID: 72612 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCommissionPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA5 RID: 72613 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011BA6 RID: 72614 RVA: 0x00A3D194 File Offset: 0x00A3B394
		Public Sub fillSalesmanID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(SM_ID) FROM Salesman order by SM_ID ASC", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011BA7 RID: 72615 RVA: 0x00A3D2D0 File Offset: 0x00A3B4D0
		Public Sub NextPrev()
			Try
				ModCommonClasses.con101.Close()
				ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con101.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SM_ID),RTRIM(Salesman_ID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),CommissionPer,RTRIM(Remarks),Photo from Salesman where SM_ID=@d1", ModCommonClasses.con101)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = True
					Me.btnUpdate.Enabled = False
					Me.txtID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSalesmanID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.cmbSalesmanName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtCity.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtZipCode.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtEmailID.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtCommissionPer.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(11), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = True
					Me.btnUpdate.Enabled = False
				End If
				ModCommonClasses.con101.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011BA8 RID: 72616 RVA: 0x00079DEB File Offset: 0x00077FEB
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06011BA9 RID: 72617 RVA: 0x00A3D55C File Offset: 0x00A3B75C
		Private Sub DataforNP()
			ModCommonClasses.con101.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con101.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Salesman", ModCommonClasses.con101)
			Me.Dad.Fill(Me.Dst, "Salesman")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Salesman").Rows(Conversions.ToInteger(Me.CurrentRow))("SM_ID"))
				ModCommonClasses.con101.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con101.Close()
		End Sub

		' Token: 0x06011BAA RID: 72618 RVA: 0x00A3D638 File Offset: 0x00A3B838
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex < Me.cmbNP.Items.Count - 1
				If flag Then
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex + 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("Last Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011BAB RID: 72619 RVA: 0x00A3D6F4 File Offset: 0x00A3B8F4
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
				Dim flag As Boolean = Me.cmbNP.SelectedIndex > 0
				If flag Then
					' The following expression was wrapped in a checked-expression
					Me.cmbNP.SelectedIndex = Me.cmbNP.SelectedIndex - 1
					Me.NextPrev()
					Me.NextPrev()
					Me.NextPrev()
				Else
					MessageBox.Show("First Record is Reached", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011BAC RID: 72620 RVA: 0x00A3D7A0 File Offset: 0x00A3B9A0
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Salesman").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Salesman").Rows(Conversions.ToInteger(Me.CurrentRow))("SM_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011BAD RID: 72621 RVA: 0x00A3D858 File Offset: 0x00A3BA58
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Salesman").Rows(Conversions.ToInteger(Me.CurrentRow))("SM_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011BAE RID: 72622 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesman_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011BAF RID: 72623 RVA: 0x00A3D8F0 File Offset: 0x00A3BAF0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtCity.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtCity, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCity, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.cmbState.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.cmbState, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbState, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbSalesmanName.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbSalesmanName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSalesmanName, String.Empty)
			End If
		End Sub

		' Token: 0x06011BB0 RID: 72624 RVA: 0x00079DAE File Offset: 0x00077FAE
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011BB1 RID: 72625 RVA: 0x00A3DA7C File Offset: 0x00A3BC7C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesmanName.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please enter Salesman name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSalesmanName.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please Enter City", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtCity.Focus()
						Else
							Dim flag6 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
							If flag6 Then
								MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbState.Focus()
							Else
								Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
								If flag7 Then
									MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtContactNo.Focus()
								Else
									Me.auto()
									Try
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "select RTRIM(ContactNo) from Salesman where ContactNo=@d1"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
										If flag8 Then
											MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag9 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text3 As String = "insert into Salesman(SM_ID, Salesman_ID, [Name],CommissionPer, Address, City, ContactNo, EmailID,Remarks,State,ZipCode,Photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
											ModCommonClasses.cmd = New SqlCommand(text3)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSalesmanID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSalesmanName.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtCommissionPer.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtAddress.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCity.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtContactNo.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtEmailID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtRemarks.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbState.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtZipCode.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim buffer As Byte() = memoryStream.GetBuffer()
											Dim sqlParameter As SqlParameter = New SqlParameter("@d12", SqlDbType.Image)
											sqlParameter.Value = buffer
											ModCommonClasses.cmd.Parameters.Add(sqlParameter)
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
											Me.DataforNP()
											ModFunc.LogFunc(Me.lblUser.Text, "added the new Salesman having Salesman id '" + Me.txtSalesmanID.Text + "'")
											MessageBox.Show("Successfully Saved", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.fillSalesmanID()
											Me.btnUpdate.Enabled = False
											ModCommonClasses.con.Close()
											Me.fillSalesmanName()
										End If
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011BB2 RID: 72626 RVA: 0x00A3E004 File Offset: 0x00A3C204
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSalesmanName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Salesman name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSalesmanName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAddress.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter City", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtCity.Focus()
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
						If flag4 Then
							MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbState.Focus()
						Else
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtContactNo.Focus()
							Else
								Try
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text As String = "update Salesman set Salesman_ID=@d2,[Name]=@d3,CommissionPer=@d4, Address=@d5,City=@d6, ContactNo=@d7, EmailID=@d8,Remarks=@d9,State=@d10,ZipCode=@d11,Photo=@d12 where SM_ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSalesmanID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSalesmanName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtCommissionPer.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtAddress.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCity.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtContactNo.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtEmailID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbState.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtZipCode.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									Dim memoryStream As MemoryStream = New MemoryStream()
									Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
									bitmap.Save(memoryStream, ImageFormat.Jpeg)
									Dim buffer As Byte() = memoryStream.GetBuffer()
									Dim sqlParameter As SqlParameter = New SqlParameter("@d12", SqlDbType.Image)
									sqlParameter.Value = buffer
									ModCommonClasses.cmd.Parameters.Add(sqlParameter)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									ModFunc.LogFunc(Me.lblUser.Text, "updated the Salesman having Salesman id '" + Me.txtSalesmanID.Text + "'")
									MessageBox.Show("Successfully Updated", "Salesman Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnUpdate.Enabled = False
									Me.fillSalesmanName()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011BB3 RID: 72627 RVA: 0x00A3E414 File Offset: 0x00A3C614
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011BB4 RID: 72628 RVA: 0x00A3E47C File Offset: 0x00A3C67C
		Private Sub btnGetData_Click_1(sender As Object, e As EventArgs)
			Dim frmSalesmanRecord As frmSalesmanRecord = New frmSalesmanRecord()
			frmSalesmanRecord.lblSet.Text = "Salesman Entry"
			frmSalesmanRecord.Getdata()
			frmSalesmanRecord.ShowDialog()
			frmSalesmanRecord.Dispose()
		End Sub

		' Token: 0x04006ABB RID: 27323
		Private s As String

		' Token: 0x04006ABC RID: 27324
		Private Photoname As String

		' Token: 0x04006ABD RID: 27325
		Private IsImageChanged As Boolean

		' Token: 0x04006ABE RID: 27326
		Private Dad As SqlDataAdapter

		' Token: 0x04006ABF RID: 27327
		Private Dst As DataSet

		' Token: 0x04006AC0 RID: 27328
		Private CurrentRow As Object
	End Class
End Namespace
