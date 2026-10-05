Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004C1 RID: 1217
	<DesignerGenerated()>
	Public Partial Class frmDamageProduct
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F3E7 RID: 62439 RVA: 0x00923FC0 File Offset: 0x009221C0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmDamageProduct_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmDamageProduct_KeyDown
			Me.UserButtons = New List(Of Button)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D5B RID: 23899
		' (get) Token: 0x0600F3EA RID: 62442 RVA: 0x0006AC02 File Offset: 0x00068E02
		' (set) Token: 0x0600F3EB RID: 62443 RVA: 0x0006AC0C File Offset: 0x00068E0C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005D5C RID: 23900
		' (get) Token: 0x0600F3EC RID: 62444 RVA: 0x0006AC15 File Offset: 0x00068E15
		' (set) Token: 0x0600F3ED RID: 62445 RVA: 0x0006AC1F File Offset: 0x00068E1F
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D5D RID: 23901
		' (get) Token: 0x0600F3EE RID: 62446 RVA: 0x0006AC28 File Offset: 0x00068E28
		' (set) Token: 0x0600F3EF RID: 62447 RVA: 0x0006AC32 File Offset: 0x00068E32
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005D5E RID: 23902
		' (get) Token: 0x0600F3F0 RID: 62448 RVA: 0x0006AC3B File Offset: 0x00068E3B
		' (set) Token: 0x0600F3F1 RID: 62449 RVA: 0x009260A4 File Offset: 0x009242A4
		Private _cmbProductID As ComboBox
		Friend Overridable Property cmbProductID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbProductID_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbProductID_KeyDown
				Dim comboBox As ComboBox = Me._cmbProductID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbProductID = value
				comboBox = Me._cmbProductID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D5F RID: 23903
		' (get) Token: 0x0600F3F2 RID: 62450 RVA: 0x0006AC45 File Offset: 0x00068E45
		' (set) Token: 0x0600F3F3 RID: 62451 RVA: 0x0006AC4F File Offset: 0x00068E4F
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D60 RID: 23904
		' (get) Token: 0x0600F3F4 RID: 62452 RVA: 0x0006AC58 File Offset: 0x00068E58
		' (set) Token: 0x0600F3F5 RID: 62453 RVA: 0x0006AC62 File Offset: 0x00068E62
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17005D61 RID: 23905
		' (get) Token: 0x0600F3F6 RID: 62454 RVA: 0x0006AC6B File Offset: 0x00068E6B
		' (set) Token: 0x0600F3F7 RID: 62455 RVA: 0x0006AC75 File Offset: 0x00068E75
		Friend Overridable Property Label5 As Label

		' Token: 0x17005D62 RID: 23906
		' (get) Token: 0x0600F3F8 RID: 62456 RVA: 0x0006AC7E File Offset: 0x00068E7E
		' (set) Token: 0x0600F3F9 RID: 62457 RVA: 0x0006AC88 File Offset: 0x00068E88
		Friend Overridable Property TextBox3 As TextBox

		' Token: 0x17005D63 RID: 23907
		' (get) Token: 0x0600F3FA RID: 62458 RVA: 0x0006AC91 File Offset: 0x00068E91
		' (set) Token: 0x0600F3FB RID: 62459 RVA: 0x0006AC9B File Offset: 0x00068E9B
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17005D64 RID: 23908
		' (get) Token: 0x0600F3FC RID: 62460 RVA: 0x0006ACA4 File Offset: 0x00068EA4
		' (set) Token: 0x0600F3FD RID: 62461 RVA: 0x0006ACAE File Offset: 0x00068EAE
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005D65 RID: 23909
		' (get) Token: 0x0600F3FE RID: 62462 RVA: 0x0006ACB7 File Offset: 0x00068EB7
		' (set) Token: 0x0600F3FF RID: 62463 RVA: 0x0006ACC1 File Offset: 0x00068EC1
		Friend Overridable Property Label4 As Label

		' Token: 0x17005D66 RID: 23910
		' (get) Token: 0x0600F400 RID: 62464 RVA: 0x0006ACCA File Offset: 0x00068ECA
		' (set) Token: 0x0600F401 RID: 62465 RVA: 0x0006ACD4 File Offset: 0x00068ED4
		Friend Overridable Property Label3 As Label

		' Token: 0x17005D67 RID: 23911
		' (get) Token: 0x0600F402 RID: 62466 RVA: 0x0006ACDD File Offset: 0x00068EDD
		' (set) Token: 0x0600F403 RID: 62467 RVA: 0x0006ACE7 File Offset: 0x00068EE7
		Friend Overridable Property TextBox6 As TextBox

		' Token: 0x17005D68 RID: 23912
		' (get) Token: 0x0600F404 RID: 62468 RVA: 0x0006ACF0 File Offset: 0x00068EF0
		' (set) Token: 0x0600F405 RID: 62469 RVA: 0x00926104 File Offset: 0x00924304
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

		' Token: 0x17005D69 RID: 23913
		' (get) Token: 0x0600F406 RID: 62470 RVA: 0x0006ACFA File Offset: 0x00068EFA
		' (set) Token: 0x0600F407 RID: 62471 RVA: 0x0006AD04 File Offset: 0x00068F04
		Friend Overridable Property Label7 As Label

		' Token: 0x17005D6A RID: 23914
		' (get) Token: 0x0600F408 RID: 62472 RVA: 0x0006AD0D File Offset: 0x00068F0D
		' (set) Token: 0x0600F409 RID: 62473 RVA: 0x0006AD17 File Offset: 0x00068F17
		Friend Overridable Property Label6 As Label

		' Token: 0x17005D6B RID: 23915
		' (get) Token: 0x0600F40A RID: 62474 RVA: 0x0006AD20 File Offset: 0x00068F20
		' (set) Token: 0x0600F40B RID: 62475 RVA: 0x0006AD2A File Offset: 0x00068F2A
		Friend Overridable Property Label8 As Label

		' Token: 0x17005D6C RID: 23916
		' (get) Token: 0x0600F40C RID: 62476 RVA: 0x0006AD33 File Offset: 0x00068F33
		' (set) Token: 0x0600F40D RID: 62477 RVA: 0x00926148 File Offset: 0x00924348
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox7_KeyDown
				Dim textBox As TextBox = Me._TextBox7
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox7 = value
				textBox = Me._TextBox7
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D6D RID: 23917
		' (get) Token: 0x0600F40E RID: 62478 RVA: 0x0006AD3D File Offset: 0x00068F3D
		' (set) Token: 0x0600F40F RID: 62479 RVA: 0x009261A8 File Offset: 0x009243A8
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D6E RID: 23918
		' (get) Token: 0x0600F410 RID: 62480 RVA: 0x0006AD47 File Offset: 0x00068F47
		' (set) Token: 0x0600F411 RID: 62481 RVA: 0x009261EC File Offset: 0x009243EC
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
				Dim textBox As TextBox = Me._TextBox8
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox8 = value
				textBox = Me._TextBox8
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D6F RID: 23919
		' (get) Token: 0x0600F412 RID: 62482 RVA: 0x0006AD51 File Offset: 0x00068F51
		' (set) Token: 0x0600F413 RID: 62483 RVA: 0x0006AD5B File Offset: 0x00068F5B
		Friend Overridable Property lblUser As Label

		' Token: 0x17005D70 RID: 23920
		' (get) Token: 0x0600F414 RID: 62484 RVA: 0x0006AD64 File Offset: 0x00068F64
		' (set) Token: 0x0600F415 RID: 62485 RVA: 0x0006AD6E File Offset: 0x00068F6E
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005D71 RID: 23921
		' (get) Token: 0x0600F416 RID: 62486 RVA: 0x0006AD77 File Offset: 0x00068F77
		' (set) Token: 0x0600F417 RID: 62487 RVA: 0x00926230 File Offset: 0x00924430
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox9_KeyDown
				Dim textBox As TextBox = Me._TextBox9
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox9 = value
				textBox = Me._TextBox9
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D72 RID: 23922
		' (get) Token: 0x0600F418 RID: 62488 RVA: 0x0006AD81 File Offset: 0x00068F81
		' (set) Token: 0x0600F419 RID: 62489 RVA: 0x0006AD8B File Offset: 0x00068F8B
		Friend Overridable Property Label9 As Label

		' Token: 0x17005D73 RID: 23923
		' (get) Token: 0x0600F41A RID: 62490 RVA: 0x0006AD94 File Offset: 0x00068F94
		' (set) Token: 0x0600F41B RID: 62491 RVA: 0x0006AD9E File Offset: 0x00068F9E
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005D74 RID: 23924
		' (get) Token: 0x0600F41C RID: 62492 RVA: 0x0006ADA7 File Offset: 0x00068FA7
		' (set) Token: 0x0600F41D RID: 62493 RVA: 0x00926290 File Offset: 0x00924490
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

		' Token: 0x17005D75 RID: 23925
		' (get) Token: 0x0600F41E RID: 62494 RVA: 0x0006ADB1 File Offset: 0x00068FB1
		' (set) Token: 0x0600F41F RID: 62495 RVA: 0x0006ADBB File Offset: 0x00068FBB
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x17005D76 RID: 23926
		' (get) Token: 0x0600F420 RID: 62496 RVA: 0x0006ADC4 File Offset: 0x00068FC4
		' (set) Token: 0x0600F421 RID: 62497 RVA: 0x009262D4 File Offset: 0x009244D4
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

		' Token: 0x17005D77 RID: 23927
		' (get) Token: 0x0600F422 RID: 62498 RVA: 0x0006ADCE File Offset: 0x00068FCE
		' (set) Token: 0x0600F423 RID: 62499 RVA: 0x0006ADD8 File Offset: 0x00068FD8
		Friend Overridable Property Label10 As Label

		' Token: 0x17005D78 RID: 23928
		' (get) Token: 0x0600F424 RID: 62500 RVA: 0x0006ADE1 File Offset: 0x00068FE1
		' (set) Token: 0x0600F425 RID: 62501 RVA: 0x0006ADEB File Offset: 0x00068FEB
		Friend Overridable Property Label11 As Label

		' Token: 0x17005D79 RID: 23929
		' (get) Token: 0x0600F426 RID: 62502 RVA: 0x0006ADF4 File Offset: 0x00068FF4
		' (set) Token: 0x0600F427 RID: 62503 RVA: 0x00926318 File Offset: 0x00924518
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

		' Token: 0x17005D7A RID: 23930
		' (get) Token: 0x0600F428 RID: 62504 RVA: 0x0006ADFE File Offset: 0x00068FFE
		' (set) Token: 0x0600F429 RID: 62505 RVA: 0x0092635C File Offset: 0x0092455C
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click_1
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D7B RID: 23931
		' (get) Token: 0x0600F42A RID: 62506 RVA: 0x0006AE08 File Offset: 0x00069008
		' (set) Token: 0x0600F42B RID: 62507 RVA: 0x0006AE12 File Offset: 0x00069012
		Friend Overridable Property txtTotDamage As TextBox

		' Token: 0x17005D7C RID: 23932
		' (get) Token: 0x0600F42C RID: 62508 RVA: 0x0006AE1B File Offset: 0x0006901B
		' (set) Token: 0x0600F42D RID: 62509 RVA: 0x0006AE25 File Offset: 0x00069025
		Friend Overridable Property Label12 As Label

		' Token: 0x17005D7D RID: 23933
		' (get) Token: 0x0600F42E RID: 62510 RVA: 0x0006AE2E File Offset: 0x0006902E
		' (set) Token: 0x0600F42F RID: 62511 RVA: 0x0006AE38 File Offset: 0x00069038
		Friend Overridable Property txtGoodQty As TextBox

		' Token: 0x17005D7E RID: 23934
		' (get) Token: 0x0600F430 RID: 62512 RVA: 0x0006AE41 File Offset: 0x00069041
		' (set) Token: 0x0600F431 RID: 62513 RVA: 0x0006AE4B File Offset: 0x0006904B
		Friend Overridable Property Label13 As Label

		' Token: 0x17005D7F RID: 23935
		' (get) Token: 0x0600F432 RID: 62514 RVA: 0x0006AE54 File Offset: 0x00069054
		' (set) Token: 0x0600F433 RID: 62515 RVA: 0x0006AE5E File Offset: 0x0006905E
		Friend Overridable Property txtTotAvlQty As TextBox

		' Token: 0x17005D80 RID: 23936
		' (get) Token: 0x0600F434 RID: 62516 RVA: 0x0006AE67 File Offset: 0x00069067
		' (set) Token: 0x0600F435 RID: 62517 RVA: 0x0006AE71 File Offset: 0x00069071
		Friend Overridable Property Label14 As Label

		' Token: 0x17005D81 RID: 23937
		' (get) Token: 0x0600F436 RID: 62518 RVA: 0x0006AE7A File Offset: 0x0006907A
		' (set) Token: 0x0600F437 RID: 62519 RVA: 0x0006AE84 File Offset: 0x00069084
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17005D82 RID: 23938
		' (get) Token: 0x0600F438 RID: 62520 RVA: 0x0006AE8D File Offset: 0x0006908D
		' (set) Token: 0x0600F439 RID: 62521 RVA: 0x009263A0 File Offset: 0x009245A0
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

		' Token: 0x17005D83 RID: 23939
		' (get) Token: 0x0600F43A RID: 62522 RVA: 0x0006AE97 File Offset: 0x00069097
		' (set) Token: 0x0600F43B RID: 62523 RVA: 0x0006AEA1 File Offset: 0x000690A1
		Friend Overridable Property CheckBox2 As CheckBox

		' Token: 0x17005D84 RID: 23940
		' (get) Token: 0x0600F43C RID: 62524 RVA: 0x0006AEAA File Offset: 0x000690AA
		' (set) Token: 0x0600F43D RID: 62525 RVA: 0x009263E4 File Offset: 0x009245E4
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button4 = value
				gelButton = Me._Button4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D85 RID: 23941
		' (get) Token: 0x0600F43E RID: 62526 RVA: 0x0006AEB4 File Offset: 0x000690B4
		' (set) Token: 0x0600F43F RID: 62527 RVA: 0x00926428 File Offset: 0x00924628
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600F440 RID: 62528
		Public Declare Ansi Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600F441 RID: 62529
		Public Declare Ansi Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean

		' Token: 0x0600F442 RID: 62530 RVA: 0x0092646C File Offset: 0x0092466C
		Public Sub fillProductid()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Barcode) FROM Temp_Stock", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbProductID.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbProductID.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600F443 RID: 62531 RVA: 0x0006AEBE File Offset: 0x000690BE
		Private Sub frmDamageProduct_Load(sender As Object, e As EventArgs)
			Me.fillProductid()
			Me.TotDamage()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F444 RID: 62532 RVA: 0x00926594 File Offset: 0x00924794
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

		' Token: 0x0600F445 RID: 62533 RVA: 0x0092670C File Offset: 0x0092490C
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

		' Token: 0x0600F446 RID: 62534 RVA: 0x009267C8 File Offset: 0x009249C8
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

		' Token: 0x0600F447 RID: 62535 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F448 RID: 62536 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F449 RID: 62537 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F44A RID: 62538 RVA: 0x00926894 File Offset: 0x00924A94
		Private Sub cmbProductID_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.TextBox1.Text = ""
				Me.TextBox2.Text = ""
				Me.TextBox4.Text = "0.000"
				Me.TextBox3.Text = ""
				Me.TextBox5.Text = "0.000"
				Me.TextBox6.Text = "0.000"
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(ProductCode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Temp_Stock.Qty,Temp_Stock.Damage,RTRIM(SalesUnit),RTRIM(ReorderPoint),(Temp_Stock.Qty - Temp_Stock.Damage),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1 order by ProductName"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.TextBox2.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.TextBox4.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.TextBox3.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.TextBox5.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.TextBox6.Text = ModCommonClasses.rdr.GetValue(15).ToString()
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

		' Token: 0x0600F44B RID: 62539 RVA: 0x0006AED6 File Offset: 0x000690D6
		Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox7.Text))
		End Sub

		' Token: 0x0600F44C RID: 62540 RVA: 0x00926AA8 File Offset: 0x00924CA8
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox7.Text))
			Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) - Conversion.Val(Me.TextBox9.Text))
		End Sub

		' Token: 0x0600F44D RID: 62541 RVA: 0x0006AED6 File Offset: 0x000690D6
		Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox8.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) + Conversion.Val(Me.TextBox7.Text))
		End Sub

		' Token: 0x0600F44E RID: 62542 RVA: 0x00926B1C File Offset: 0x00924D1C
		Public Sub clear()
			Me.cmbProductID.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox4.Text = "0.000"
			Me.TextBox3.Text = ""
			Me.TextBox5.Text = "0.000"
			Me.TextBox6.Text = "0.000"
			Me.TextBox7.Text = ""
			Me.TextBox9.Text = ""
			Me.cmbProductID.Focus()
		End Sub

		' Token: 0x0600F44F RID: 62543 RVA: 0x0006AF0B File Offset: 0x0006910B
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.clear()
			Me.TextBox12.Text = ""
			Me.TextBox11.Text = ""
		End Sub

		' Token: 0x0600F450 RID: 62544 RVA: 0x0006AF37 File Offset: 0x00069137
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) - Conversion.Val(Me.TextBox9.Text))
		End Sub

		' Token: 0x0600F451 RID: 62545 RVA: 0x0006AF37 File Offset: 0x00069137
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.TextBox5.Text) - Conversion.Val(Me.TextBox9.Text))
		End Sub

		' Token: 0x0600F452 RID: 62546 RVA: 0x00926BCC File Offset: 0x00924DCC
		Public Sub FillProductList()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT PID, RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,Damage,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Qty - Damage),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),RTRIM(ProductCode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID order by ProductName"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Me.FlowLayoutPanel1.Controls.Clear()
				While ModCommonClasses.rdr.Read()
					Dim button As Button = New Button()
					button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim(), vbCrLf, "Group : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Product Code : ".ToString(), ModCommonClasses.rdr.GetValue(19).ToString().Trim(), vbCrLf, "Total Qty : ".ToString(), ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
					button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(19).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
					button.TextAlign = ContentAlignment.MiddleLeft
					Dim green As Color = Color.Green
					Dim crimson As Color = Color.Crimson
					Dim deepSkyBlue As Color = Color.DeepSkyBlue
					Dim flag As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) > 0.0
					If flag Then
						button.BackColor = green
					Else
						Dim flag2 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) <= 0.0
						If flag2 Then
							button.BackColor = crimson
						Else
							button.BackColor = deepSkyBlue
						End If
					End If
					button.ForeColor = Color.White
					button.FlatStyle = FlatStyle.Popup
					button.Cursor = Cursors.Hand
					button.Width = 180
					button.Height = 100
					button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
					Me.UserButtons.Add(button)
					Me.FlowLayoutPanel1.Controls.Add(button)
					AddHandler button.Click, AddressOf Me.Button2_Click
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F453 RID: 62547 RVA: 0x00926F5C File Offset: 0x0092515C
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(button.Tag))
				Me.cmbProductID.Text = text.Split(New Char() { ","c })(1).ToString()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F454 RID: 62548 RVA: 0x00926FE0 File Offset: 0x009251E0
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID, RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,Damage,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Qty - Damage),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),RTRIM(ProductCode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and ProductName like N'%" + Me.TextBox11.Text + "%' order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Me.FlowLayoutPanel1.Controls.Clear()
					While ModCommonClasses.rdr.Read()
						Dim button As Button = New Button()
						button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim(), vbCrLf, "Group : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Product Code : ".ToString(), ModCommonClasses.rdr.GetValue(19).ToString().Trim(), vbCrLf, "Total Qty : ".ToString(), ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
						button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(19).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
						button.TextAlign = ContentAlignment.MiddleLeft
						Dim green As Color = Color.Green
						Dim crimson As Color = Color.Crimson
						Dim deepSkyBlue As Color = Color.DeepSkyBlue
						Dim flag As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) > 0.0
						If flag Then
							button.BackColor = green
						Else
							Dim flag2 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) <= 0.0
							If flag2 Then
								button.BackColor = crimson
							Else
								button.BackColor = deepSkyBlue
							End If
						End If
						button.ForeColor = Color.White
						button.FlatStyle = FlatStyle.Popup
						button.Cursor = Cursors.Hand
						button.Width = 180
						button.Height = 100
						button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
						Me.UserButtons.Add(button)
						Me.FlowLayoutPanel1.Controls.Add(button)
						AddHandler button.Click, AddressOf Me.Button2_Click
					End While
					ModCommonClasses.con.Close()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600F455 RID: 62549 RVA: 0x0092739C File Offset: 0x0092559C
		Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID, RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,Damage,RTRIM(SalesUnit),RTRIM(Temp_Stock.WPrice),(Qty - Damage),RTRIM(Category),RTRIM(SubCategoryName),RTRIM(Product.LastPrice),RTRIM(ProductCode) from Temp_Stock,Product,SubCategory where Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and RTRIM(Temp_Stock.Barcode) like N'%" + Me.TextBox12.Text + "%' order by ProductName"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Me.FlowLayoutPanel1.Controls.Clear()
					While ModCommonClasses.rdr.Read()
						Dim button As Button = New Button()
						button.Text = String.Concat(New String() { "Product : ".ToString(), ModCommonClasses.rdr.GetValue(1).ToString().Trim(), vbCrLf, "Barcode : ".ToString(), ModCommonClasses.rdr.GetValue(4).ToString().Trim(), vbCrLf, "Group : ".ToString(), ModCommonClasses.rdr.GetValue(3).ToString().Trim(), vbCrLf, "Product Code : ".ToString(), ModCommonClasses.rdr.GetValue(19).ToString().Trim(), vbCrLf, "Total Qty : ".ToString(), ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
						button.Tag = String.Concat(New String() { ModCommonClasses.rdr.GetValue(1).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(4).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(3).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(19).ToString().Trim(), ",", ModCommonClasses.rdr.GetValue(11).ToString().Trim() })
						button.TextAlign = ContentAlignment.MiddleLeft
						Dim green As Color = Color.Green
						Dim crimson As Color = Color.Crimson
						Dim deepSkyBlue As Color = Color.DeepSkyBlue
						Dim flag As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) > 0.0
						If flag Then
							button.BackColor = green
						Else
							Dim flag2 As Boolean = Conversion.Val(ModCommonClasses.rdr.GetValue(11).ToString().Trim()) <= 0.0
							If flag2 Then
								button.BackColor = crimson
							Else
								button.BackColor = deepSkyBlue
							End If
						End If
						button.ForeColor = Color.White
						button.FlatStyle = FlatStyle.Popup
						button.Cursor = Cursors.Hand
						button.Width = 180
						button.Height = 100
						button.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0)
						Me.UserButtons.Add(button)
						Me.FlowLayoutPanel1.Controls.Add(button)
						AddHandler button.Click, AddressOf Me.Button2_Click
					End While
					ModCommonClasses.con.Close()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600F456 RID: 62550 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbProductID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F457 RID: 62551 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox7_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F458 RID: 62552 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600F459 RID: 62553 RVA: 0x00927758 File Offset: 0x00925958
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			Dim is64BitOperatingSystem As Boolean = Environment.Is64BitOperatingSystem
			If is64BitOperatingSystem Then
				Dim num As Long
				Dim flag As Boolean = frmDamageProduct.Wow64DisableWow64FsRedirection(num)
				If flag Then
					Process.Start("osk.exe")
					frmDamageProduct.Wow64EnableWow64FsRedirection(num)
				End If
			Else
				Process.Start("osk.exe")
			End If
		End Sub

		' Token: 0x0600F45A RID: 62554 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmDamageProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F45B RID: 62555 RVA: 0x009277A0 File Offset: 0x009259A0
		Private Sub TotDamage()
			Me.txtTotDamage.Text = ""
			Me.txtGoodQty.Text = ""
			Me.txtTotAvlQty.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT isNULL(Sum(Damage),0), isNULL(Sum(Qty),0)-IsNull(Sum(Damage),0), isNULL(Sum(Qty),0) from Temp_Stock"
			ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
			ModCommonClasses.rdr1 = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = ModCommonClasses.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr1.GetValue(0)))
				If flag3 Then
					Me.txtTotDamage.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(0))
					Me.txtGoodQty.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(1))
					Me.txtTotAvlQty.Text = Conversions.ToString(ModCommonClasses.rdr1.GetValue(2))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.txtTotDamage.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtTotDamage.Text), 3), "0.000")
			Me.txtGoodQty.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtGoodQty.Text), 3), "0.000")
			Me.txtTotAvlQty.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtTotAvlQty.Text), 3), "0.000")
		End Sub

		' Token: 0x0600F45C RID: 62556 RVA: 0x00927944 File Offset: 0x00925B44
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Me.FillProductList()
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Me.FlowLayoutPanel1.Controls.Clear()
				End If
			End If
		End Sub

		' Token: 0x0600F45D RID: 62557 RVA: 0x00927990 File Offset: 0x00925B90
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbProductID.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please fill product id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbProductID.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox7.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill damage quantities", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox7.Focus()
				Else
					Dim flag3 As Boolean = Not Me.CheckBox2.Checked
					If flag3 Then
						Dim flag4 As Boolean = Conversion.Val(Me.TextBox4.Text) - Conversion.Val(Me.TextBox5.Text) < Conversion.Val(Me.TextBox7.Text)
						If flag4 Then
							MessageBox.Show("Damage quantities are exceeded than avaliable quantities", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.TextBox7.Focus()
							Return
						End If
					End If
					Me.Button1.Enabled = False
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update Temp_Stock set Damage=@d0 where Barcode=@d2"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbProductID.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.TextBox8.Text))
						ModCommonClasses.cmd.ExecuteReader()
						Dim text2 As String = String.Concat(New String() { "Damage qty '", Me.TextBox7.Text, "' ,  are added in Product name : '", Me.TextBox1.Text, "'" })
						ModFunc.LogFunc(Me.lblUser.Text, text2)
						MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.clear()
						Me.Button1.Enabled = True
						Me.TotDamage()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600F45E RID: 62558 RVA: 0x00927BF0 File Offset: 0x00925DF0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbProductID.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Please fill product id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbProductID.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox9.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill recover quantities", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox9.Focus()
				Else
					Dim flag3 As Boolean = Not Me.CheckBox2.Checked
					If flag3 Then
						Dim flag4 As Boolean = Conversion.Val(Me.TextBox9.Text) > Conversion.Val(Me.TextBox5.Text)
						If flag4 Then
							MessageBox.Show("Recover quantities are exceeded than avaliable damage quantities", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.TextBox9.Focus()
							Return
						End If
					End If
					Me.Button4.Enabled = False
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "Update Temp_Stock set Damage=@d0 where Barcode=@d2"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.cmbProductID.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.TextBox10.Text))
						ModCommonClasses.cmd.ExecuteReader()
						Dim text2 As String = String.Concat(New String() { "Recover qty '", Me.TextBox9.Text, "' ,  are added in Product name : '", Me.TextBox1.Text, "'" })
						ModFunc.LogFunc(Me.lblUser.Text, text2)
						MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.clear()
						Me.Button4.Enabled = True
						Me.TotDamage()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x04005D67 RID: 23911
		Private UserButtons As List(Of Button)
	End Class
End Namespace
