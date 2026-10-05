Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200023A RID: 570
	<DesignerGenerated()>
	Public Partial Class BalanceSheetForm
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06009DB3 RID: 40371 RVA: 0x006E90F0 File Offset: 0x006E72F0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.BalanceSheetForm_Load
			AddHandler MyBase.KeyDown, AddressOf Me.BalanceSheetForm_KeyDown
			Me.rdr1 = Nothing
			Me.PrintDoc1 = New PrintDocument()
			Me.PrintPreviewDialog1 = New PrintPreviewDialog()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003C21 RID: 15393
		' (get) Token: 0x06009DB6 RID: 40374 RVA: 0x0004B584 File Offset: 0x00049784
		' (set) Token: 0x06009DB7 RID: 40375 RVA: 0x0004B58E File Offset: 0x0004978E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003C22 RID: 15394
		' (get) Token: 0x06009DB8 RID: 40376 RVA: 0x0004B597 File Offset: 0x00049797
		' (set) Token: 0x06009DB9 RID: 40377 RVA: 0x0004B5A1 File Offset: 0x000497A1
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003C23 RID: 15395
		' (get) Token: 0x06009DBA RID: 40378 RVA: 0x0004B5AA File Offset: 0x000497AA
		' (set) Token: 0x06009DBB RID: 40379 RVA: 0x006EEC58 File Offset: 0x006ECE58
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
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

		' Token: 0x17003C24 RID: 15396
		' (get) Token: 0x06009DBC RID: 40380 RVA: 0x0004B5B4 File Offset: 0x000497B4
		' (set) Token: 0x06009DBD RID: 40381 RVA: 0x0004B5BE File Offset: 0x000497BE
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17003C25 RID: 15397
		' (get) Token: 0x06009DBE RID: 40382 RVA: 0x0004B5C7 File Offset: 0x000497C7
		' (set) Token: 0x06009DBF RID: 40383 RVA: 0x0004B5D1 File Offset: 0x000497D1
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17003C26 RID: 15398
		' (get) Token: 0x06009DC0 RID: 40384 RVA: 0x0004B5DA File Offset: 0x000497DA
		' (set) Token: 0x06009DC1 RID: 40385 RVA: 0x006EEC9C File Offset: 0x006ECE9C
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
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C27 RID: 15399
		' (get) Token: 0x06009DC2 RID: 40386 RVA: 0x0004B5E4 File Offset: 0x000497E4
		' (set) Token: 0x06009DC3 RID: 40387 RVA: 0x0004B5EE File Offset: 0x000497EE
		Friend Overridable Property Label12 As Label

		' Token: 0x17003C28 RID: 15400
		' (get) Token: 0x06009DC4 RID: 40388 RVA: 0x0004B5F7 File Offset: 0x000497F7
		' (set) Token: 0x06009DC5 RID: 40389 RVA: 0x0004B601 File Offset: 0x00049801
		Friend Overridable Property Label13 As Label

		' Token: 0x17003C29 RID: 15401
		' (get) Token: 0x06009DC6 RID: 40390 RVA: 0x0004B60A File Offset: 0x0004980A
		' (set) Token: 0x06009DC7 RID: 40391 RVA: 0x006EECE0 File Offset: 0x006ECEE0
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

		' Token: 0x17003C2A RID: 15402
		' (get) Token: 0x06009DC8 RID: 40392 RVA: 0x0004B614 File Offset: 0x00049814
		' (set) Token: 0x06009DC9 RID: 40393 RVA: 0x006EED24 File Offset: 0x006ECF24
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

		' Token: 0x17003C2B RID: 15403
		' (get) Token: 0x06009DCA RID: 40394 RVA: 0x0004B61E File Offset: 0x0004981E
		' (set) Token: 0x06009DCB RID: 40395 RVA: 0x006EED68 File Offset: 0x006ECF68
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
				Dim textBox As TextBox = Me._TextBox6
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox6 = value
				textBox = Me._TextBox6
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C2C RID: 15404
		' (get) Token: 0x06009DCC RID: 40396 RVA: 0x0004B628 File Offset: 0x00049828
		' (set) Token: 0x06009DCD RID: 40397 RVA: 0x006EEDAC File Offset: 0x006ECFAC
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

		' Token: 0x17003C2D RID: 15405
		' (get) Token: 0x06009DCE RID: 40398 RVA: 0x0004B632 File Offset: 0x00049832
		' (set) Token: 0x06009DCF RID: 40399 RVA: 0x006EEDF0 File Offset: 0x006ECFF0
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

		' Token: 0x17003C2E RID: 15406
		' (get) Token: 0x06009DD0 RID: 40400 RVA: 0x0004B63C File Offset: 0x0004983C
		' (set) Token: 0x06009DD1 RID: 40401 RVA: 0x006EEE34 File Offset: 0x006ED034
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

		' Token: 0x17003C2F RID: 15407
		' (get) Token: 0x06009DD2 RID: 40402 RVA: 0x0004B646 File Offset: 0x00049846
		' (set) Token: 0x06009DD3 RID: 40403 RVA: 0x006EEE78 File Offset: 0x006ED078
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

		' Token: 0x17003C30 RID: 15408
		' (get) Token: 0x06009DD4 RID: 40404 RVA: 0x0004B650 File Offset: 0x00049850
		' (set) Token: 0x06009DD5 RID: 40405 RVA: 0x006EEEBC File Offset: 0x006ED0BC
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
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C31 RID: 15409
		' (get) Token: 0x06009DD6 RID: 40406 RVA: 0x0004B65A File Offset: 0x0004985A
		' (set) Token: 0x06009DD7 RID: 40407 RVA: 0x006EEF00 File Offset: 0x006ED100
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

		' Token: 0x17003C32 RID: 15410
		' (get) Token: 0x06009DD8 RID: 40408 RVA: 0x0004B664 File Offset: 0x00049864
		' (set) Token: 0x06009DD9 RID: 40409 RVA: 0x006EEF44 File Offset: 0x006ED144
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

		' Token: 0x17003C33 RID: 15411
		' (get) Token: 0x06009DDA RID: 40410 RVA: 0x0004B66E File Offset: 0x0004986E
		' (set) Token: 0x06009DDB RID: 40411 RVA: 0x006EEF88 File Offset: 0x006ED188
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

		' Token: 0x17003C34 RID: 15412
		' (get) Token: 0x06009DDC RID: 40412 RVA: 0x0004B678 File Offset: 0x00049878
		' (set) Token: 0x06009DDD RID: 40413 RVA: 0x006EEFCC File Offset: 0x006ED1CC
		Private _Label16 As Label
		Friend Overridable Property Label16 As Label
			<CompilerGenerated()>
			Get
				Return Me._Label16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.Label16_TextChanged
				Dim label As Label = Me._Label16
				If label IsNot Nothing Then
					RemoveHandler label.TextChanged, eventHandler
				End If
				Me._Label16 = value
				label = Me._Label16
				If label IsNot Nothing Then
					AddHandler label.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C35 RID: 15413
		' (get) Token: 0x06009DDE RID: 40414 RVA: 0x0004B682 File Offset: 0x00049882
		' (set) Token: 0x06009DDF RID: 40415 RVA: 0x0004B68C File Offset: 0x0004988C
		Friend Overridable Property Label1 As Label

		' Token: 0x17003C36 RID: 15414
		' (get) Token: 0x06009DE0 RID: 40416 RVA: 0x0004B695 File Offset: 0x00049895
		' (set) Token: 0x06009DE1 RID: 40417 RVA: 0x0004B69F File Offset: 0x0004989F
		Friend Overridable Property Label3 As Label

		' Token: 0x17003C37 RID: 15415
		' (get) Token: 0x06009DE2 RID: 40418 RVA: 0x0004B6A8 File Offset: 0x000498A8
		' (set) Token: 0x06009DE3 RID: 40419 RVA: 0x0004B6B2 File Offset: 0x000498B2
		Friend Overridable Property Label2 As Label

		' Token: 0x17003C38 RID: 15416
		' (get) Token: 0x06009DE4 RID: 40420 RVA: 0x0004B6BB File Offset: 0x000498BB
		' (set) Token: 0x06009DE5 RID: 40421 RVA: 0x0004B6C5 File Offset: 0x000498C5
		Friend Overridable Property Label4 As Label

		' Token: 0x17003C39 RID: 15417
		' (get) Token: 0x06009DE6 RID: 40422 RVA: 0x0004B6CE File Offset: 0x000498CE
		' (set) Token: 0x06009DE7 RID: 40423 RVA: 0x006EF010 File Offset: 0x006ED210
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

		' Token: 0x17003C3A RID: 15418
		' (get) Token: 0x06009DE8 RID: 40424 RVA: 0x0004B6D8 File Offset: 0x000498D8
		' (set) Token: 0x06009DE9 RID: 40425 RVA: 0x0004B6E2 File Offset: 0x000498E2
		Friend Overridable Property Label5 As Label

		' Token: 0x17003C3B RID: 15419
		' (get) Token: 0x06009DEA RID: 40426 RVA: 0x0004B6EB File Offset: 0x000498EB
		' (set) Token: 0x06009DEB RID: 40427 RVA: 0x006EF054 File Offset: 0x006ED254
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

		' Token: 0x17003C3C RID: 15420
		' (get) Token: 0x06009DEC RID: 40428 RVA: 0x0004B6F5 File Offset: 0x000498F5
		' (set) Token: 0x06009DED RID: 40429 RVA: 0x0004B6FF File Offset: 0x000498FF
		Friend Overridable Property Label6 As Label

		' Token: 0x17003C3D RID: 15421
		' (get) Token: 0x06009DEE RID: 40430 RVA: 0x0004B708 File Offset: 0x00049908
		' (set) Token: 0x06009DEF RID: 40431 RVA: 0x006EF098 File Offset: 0x006ED298
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

		' Token: 0x17003C3E RID: 15422
		' (get) Token: 0x06009DF0 RID: 40432 RVA: 0x0004B712 File Offset: 0x00049912
		' (set) Token: 0x06009DF1 RID: 40433 RVA: 0x0004B71C File Offset: 0x0004991C
		Friend Overridable Property Label7 As Label

		' Token: 0x17003C3F RID: 15423
		' (get) Token: 0x06009DF2 RID: 40434 RVA: 0x0004B725 File Offset: 0x00049925
		' (set) Token: 0x06009DF3 RID: 40435 RVA: 0x006EF0DC File Offset: 0x006ED2DC
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

		' Token: 0x17003C40 RID: 15424
		' (get) Token: 0x06009DF4 RID: 40436 RVA: 0x0004B72F File Offset: 0x0004992F
		' (set) Token: 0x06009DF5 RID: 40437 RVA: 0x0004B739 File Offset: 0x00049939
		Friend Overridable Property Label10 As Label

		' Token: 0x17003C41 RID: 15425
		' (get) Token: 0x06009DF6 RID: 40438 RVA: 0x0004B742 File Offset: 0x00049942
		' (set) Token: 0x06009DF7 RID: 40439 RVA: 0x0004B74C File Offset: 0x0004994C
		Friend Overridable Property Label9 As Label

		' Token: 0x17003C42 RID: 15426
		' (get) Token: 0x06009DF8 RID: 40440 RVA: 0x0004B755 File Offset: 0x00049955
		' (set) Token: 0x06009DF9 RID: 40441 RVA: 0x0004B75F File Offset: 0x0004995F
		Friend Overridable Property Label8 As Label

		' Token: 0x17003C43 RID: 15427
		' (get) Token: 0x06009DFA RID: 40442 RVA: 0x0004B768 File Offset: 0x00049968
		' (set) Token: 0x06009DFB RID: 40443 RVA: 0x0004B772 File Offset: 0x00049972
		Friend Overridable Property Label14 As Label

		' Token: 0x17003C44 RID: 15428
		' (get) Token: 0x06009DFC RID: 40444 RVA: 0x0004B77B File Offset: 0x0004997B
		' (set) Token: 0x06009DFD RID: 40445 RVA: 0x0004B785 File Offset: 0x00049985
		Friend Overridable Property Label11 As Label

		' Token: 0x17003C45 RID: 15429
		' (get) Token: 0x06009DFE RID: 40446 RVA: 0x0004B78E File Offset: 0x0004998E
		' (set) Token: 0x06009DFF RID: 40447 RVA: 0x0004B798 File Offset: 0x00049998
		Friend Overridable Property Label15 As Label

		' Token: 0x17003C46 RID: 15430
		' (get) Token: 0x06009E00 RID: 40448 RVA: 0x0004B7A1 File Offset: 0x000499A1
		' (set) Token: 0x06009E01 RID: 40449 RVA: 0x0004B7AB File Offset: 0x000499AB
		Friend Overridable Property Label21 As Label

		' Token: 0x17003C47 RID: 15431
		' (get) Token: 0x06009E02 RID: 40450 RVA: 0x0004B7B4 File Offset: 0x000499B4
		' (set) Token: 0x06009E03 RID: 40451 RVA: 0x0004B7BE File Offset: 0x000499BE
		Friend Overridable Property Label19 As Label

		' Token: 0x17003C48 RID: 15432
		' (get) Token: 0x06009E04 RID: 40452 RVA: 0x0004B7C7 File Offset: 0x000499C7
		' (set) Token: 0x06009E05 RID: 40453 RVA: 0x0004B7D1 File Offset: 0x000499D1
		Friend Overridable Property Label20 As Label

		' Token: 0x17003C49 RID: 15433
		' (get) Token: 0x06009E06 RID: 40454 RVA: 0x0004B7DA File Offset: 0x000499DA
		' (set) Token: 0x06009E07 RID: 40455 RVA: 0x0004B7E4 File Offset: 0x000499E4
		Friend Overridable Property Label18 As Label

		' Token: 0x17003C4A RID: 15434
		' (get) Token: 0x06009E08 RID: 40456 RVA: 0x0004B7ED File Offset: 0x000499ED
		' (set) Token: 0x06009E09 RID: 40457 RVA: 0x0004B7F7 File Offset: 0x000499F7
		Friend Overridable Property Label17 As Label

		' Token: 0x17003C4B RID: 15435
		' (get) Token: 0x06009E0A RID: 40458 RVA: 0x0004B800 File Offset: 0x00049A00
		' (set) Token: 0x06009E0B RID: 40459 RVA: 0x0004B80A File Offset: 0x00049A0A
		Friend Overridable Property Label23 As Label

		' Token: 0x17003C4C RID: 15436
		' (get) Token: 0x06009E0C RID: 40460 RVA: 0x0004B813 File Offset: 0x00049A13
		' (set) Token: 0x06009E0D RID: 40461 RVA: 0x006EF120 File Offset: 0x006ED320
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

		' Token: 0x17003C4D RID: 15437
		' (get) Token: 0x06009E0E RID: 40462 RVA: 0x0004B81D File Offset: 0x00049A1D
		' (set) Token: 0x06009E0F RID: 40463 RVA: 0x006EF164 File Offset: 0x006ED364
		Private _TextBox27 As TextBox
		Friend Overridable Property TextBox27 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox27
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox27_TextChanged
				Dim textBox As TextBox = Me._TextBox27
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox27 = value
				textBox = Me._TextBox27
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C4E RID: 15438
		' (get) Token: 0x06009E10 RID: 40464 RVA: 0x0004B827 File Offset: 0x00049A27
		' (set) Token: 0x06009E11 RID: 40465 RVA: 0x006EF1A8 File Offset: 0x006ED3A8
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

		' Token: 0x17003C4F RID: 15439
		' (get) Token: 0x06009E12 RID: 40466 RVA: 0x0004B831 File Offset: 0x00049A31
		' (set) Token: 0x06009E13 RID: 40467 RVA: 0x006EF1EC File Offset: 0x006ED3EC
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

		' Token: 0x17003C50 RID: 15440
		' (get) Token: 0x06009E14 RID: 40468 RVA: 0x0004B83B File Offset: 0x00049A3B
		' (set) Token: 0x06009E15 RID: 40469 RVA: 0x006EF230 File Offset: 0x006ED430
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

		' Token: 0x17003C51 RID: 15441
		' (get) Token: 0x06009E16 RID: 40470 RVA: 0x0004B845 File Offset: 0x00049A45
		' (set) Token: 0x06009E17 RID: 40471 RVA: 0x006EF274 File Offset: 0x006ED474
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

		' Token: 0x17003C52 RID: 15442
		' (get) Token: 0x06009E18 RID: 40472 RVA: 0x0004B84F File Offset: 0x00049A4F
		' (set) Token: 0x06009E19 RID: 40473 RVA: 0x006EF2B8 File Offset: 0x006ED4B8
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
				Dim textBox As TextBox = Me._TextBox22
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox22 = value
				textBox = Me._TextBox22
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C53 RID: 15443
		' (get) Token: 0x06009E1A RID: 40474 RVA: 0x0004B859 File Offset: 0x00049A59
		' (set) Token: 0x06009E1B RID: 40475 RVA: 0x006EF2FC File Offset: 0x006ED4FC
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

		' Token: 0x17003C54 RID: 15444
		' (get) Token: 0x06009E1C RID: 40476 RVA: 0x0004B863 File Offset: 0x00049A63
		' (set) Token: 0x06009E1D RID: 40477 RVA: 0x006EF340 File Offset: 0x006ED540
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
				Dim textBox As TextBox = Me._TextBox20
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox20 = value
				textBox = Me._TextBox20
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C55 RID: 15445
		' (get) Token: 0x06009E1E RID: 40478 RVA: 0x0004B86D File Offset: 0x00049A6D
		' (set) Token: 0x06009E1F RID: 40479 RVA: 0x006EF384 File Offset: 0x006ED584
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

		' Token: 0x17003C56 RID: 15446
		' (get) Token: 0x06009E20 RID: 40480 RVA: 0x0004B877 File Offset: 0x00049A77
		' (set) Token: 0x06009E21 RID: 40481 RVA: 0x006EF3C8 File Offset: 0x006ED5C8
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

		' Token: 0x17003C57 RID: 15447
		' (get) Token: 0x06009E22 RID: 40482 RVA: 0x0004B881 File Offset: 0x00049A81
		' (set) Token: 0x06009E23 RID: 40483 RVA: 0x006EF40C File Offset: 0x006ED60C
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

		' Token: 0x17003C58 RID: 15448
		' (get) Token: 0x06009E24 RID: 40484 RVA: 0x0004B88B File Offset: 0x00049A8B
		' (set) Token: 0x06009E25 RID: 40485 RVA: 0x006EF450 File Offset: 0x006ED650
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

		' Token: 0x17003C59 RID: 15449
		' (get) Token: 0x06009E26 RID: 40486 RVA: 0x0004B895 File Offset: 0x00049A95
		' (set) Token: 0x06009E27 RID: 40487 RVA: 0x0004B89F File Offset: 0x00049A9F
		Friend Overridable Property Label22 As Label

		' Token: 0x17003C5A RID: 15450
		' (get) Token: 0x06009E28 RID: 40488 RVA: 0x0004B8A8 File Offset: 0x00049AA8
		' (set) Token: 0x06009E29 RID: 40489 RVA: 0x006EF494 File Offset: 0x006ED694
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

		' Token: 0x17003C5B RID: 15451
		' (get) Token: 0x06009E2A RID: 40490 RVA: 0x0004B8B2 File Offset: 0x00049AB2
		' (set) Token: 0x06009E2B RID: 40491 RVA: 0x006EF4D8 File Offset: 0x006ED6D8
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

		' Token: 0x17003C5C RID: 15452
		' (get) Token: 0x06009E2C RID: 40492 RVA: 0x0004B8BC File Offset: 0x00049ABC
		' (set) Token: 0x06009E2D RID: 40493 RVA: 0x0004B8C6 File Offset: 0x00049AC6
		Friend Overridable Property Label25 As Label

		' Token: 0x17003C5D RID: 15453
		' (get) Token: 0x06009E2E RID: 40494 RVA: 0x0004B8CF File Offset: 0x00049ACF
		' (set) Token: 0x06009E2F RID: 40495 RVA: 0x006EF51C File Offset: 0x006ED71C
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

		' Token: 0x17003C5E RID: 15454
		' (get) Token: 0x06009E30 RID: 40496 RVA: 0x0004B8D9 File Offset: 0x00049AD9
		' (set) Token: 0x06009E31 RID: 40497 RVA: 0x0004B8E3 File Offset: 0x00049AE3
		Friend Overridable Property Label24 As Label

		' Token: 0x17003C5F RID: 15455
		' (get) Token: 0x06009E32 RID: 40498 RVA: 0x0004B8EC File Offset: 0x00049AEC
		' (set) Token: 0x06009E33 RID: 40499 RVA: 0x006EF560 File Offset: 0x006ED760
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

		' Token: 0x17003C60 RID: 15456
		' (get) Token: 0x06009E34 RID: 40500 RVA: 0x0004B8F6 File Offset: 0x00049AF6
		' (set) Token: 0x06009E35 RID: 40501 RVA: 0x0004B900 File Offset: 0x00049B00
		Friend Overridable Property Label27 As Label

		' Token: 0x17003C61 RID: 15457
		' (get) Token: 0x06009E36 RID: 40502 RVA: 0x0004B909 File Offset: 0x00049B09
		' (set) Token: 0x06009E37 RID: 40503 RVA: 0x006EF5A4 File Offset: 0x006ED7A4
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

		' Token: 0x17003C62 RID: 15458
		' (get) Token: 0x06009E38 RID: 40504 RVA: 0x0004B913 File Offset: 0x00049B13
		' (set) Token: 0x06009E39 RID: 40505 RVA: 0x0004B91D File Offset: 0x00049B1D
		Friend Overridable Property Label26 As Label

		' Token: 0x17003C63 RID: 15459
		' (get) Token: 0x06009E3A RID: 40506 RVA: 0x0004B926 File Offset: 0x00049B26
		' (set) Token: 0x06009E3B RID: 40507 RVA: 0x006EF5E8 File Offset: 0x006ED7E8
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

		' Token: 0x17003C64 RID: 15460
		' (get) Token: 0x06009E3C RID: 40508 RVA: 0x0004B930 File Offset: 0x00049B30
		' (set) Token: 0x06009E3D RID: 40509 RVA: 0x006EF62C File Offset: 0x006ED82C
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

		' Token: 0x17003C65 RID: 15461
		' (get) Token: 0x06009E3E RID: 40510 RVA: 0x0004B93A File Offset: 0x00049B3A
		' (set) Token: 0x06009E3F RID: 40511 RVA: 0x0004B944 File Offset: 0x00049B44
		Friend Overridable Property Label28 As Label

		' Token: 0x17003C66 RID: 15462
		' (get) Token: 0x06009E40 RID: 40512 RVA: 0x0004B94D File Offset: 0x00049B4D
		' (set) Token: 0x06009E41 RID: 40513 RVA: 0x006EF670 File Offset: 0x006ED870
		Private _TextBox37 As TextBox
		Friend Overridable Property TextBox37 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox37
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox37_TextChanged
				Dim textBox As TextBox = Me._TextBox37
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox37 = value
				textBox = Me._TextBox37
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C67 RID: 15463
		' (get) Token: 0x06009E42 RID: 40514 RVA: 0x0004B957 File Offset: 0x00049B57
		' (set) Token: 0x06009E43 RID: 40515 RVA: 0x006EF6B4 File Offset: 0x006ED8B4
		Private _TextBox36 As TextBox
		Friend Overridable Property TextBox36 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox36
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox36_TextChanged
				Dim textBox As TextBox = Me._TextBox36
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox36 = value
				textBox = Me._TextBox36
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C68 RID: 15464
		' (get) Token: 0x06009E44 RID: 40516 RVA: 0x0004B961 File Offset: 0x00049B61
		' (set) Token: 0x06009E45 RID: 40517 RVA: 0x006EF6F8 File Offset: 0x006ED8F8
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

		' Token: 0x17003C69 RID: 15465
		' (get) Token: 0x06009E46 RID: 40518 RVA: 0x0004B96B File Offset: 0x00049B6B
		' (set) Token: 0x06009E47 RID: 40519 RVA: 0x006EF73C File Offset: 0x006ED93C
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

		' Token: 0x17003C6A RID: 15466
		' (get) Token: 0x06009E48 RID: 40520 RVA: 0x0004B975 File Offset: 0x00049B75
		' (set) Token: 0x06009E49 RID: 40521 RVA: 0x006EF780 File Offset: 0x006ED980
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

		' Token: 0x17003C6B RID: 15467
		' (get) Token: 0x06009E4A RID: 40522 RVA: 0x0004B97F File Offset: 0x00049B7F
		' (set) Token: 0x06009E4B RID: 40523 RVA: 0x006EF7C4 File Offset: 0x006ED9C4
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

		' Token: 0x17003C6C RID: 15468
		' (get) Token: 0x06009E4C RID: 40524 RVA: 0x0004B989 File Offset: 0x00049B89
		' (set) Token: 0x06009E4D RID: 40525 RVA: 0x006EF808 File Offset: 0x006EDA08
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

		' Token: 0x17003C6D RID: 15469
		' (get) Token: 0x06009E4E RID: 40526 RVA: 0x0004B993 File Offset: 0x00049B93
		' (set) Token: 0x06009E4F RID: 40527 RVA: 0x0004B99D File Offset: 0x00049B9D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17003C6E RID: 15470
		' (get) Token: 0x06009E50 RID: 40528 RVA: 0x0004B9A6 File Offset: 0x00049BA6
		' (set) Token: 0x06009E51 RID: 40529 RVA: 0x006EF84C File Offset: 0x006EDA4C
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

		' Token: 0x17003C6F RID: 15471
		' (get) Token: 0x06009E52 RID: 40530 RVA: 0x0004B9B0 File Offset: 0x00049BB0
		' (set) Token: 0x06009E53 RID: 40531 RVA: 0x006EF890 File Offset: 0x006EDA90
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

		' Token: 0x17003C70 RID: 15472
		' (get) Token: 0x06009E54 RID: 40532 RVA: 0x0004B9BA File Offset: 0x00049BBA
		' (set) Token: 0x06009E55 RID: 40533 RVA: 0x006EF8D4 File Offset: 0x006EDAD4
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

		' Token: 0x17003C71 RID: 15473
		' (get) Token: 0x06009E56 RID: 40534 RVA: 0x0004B9C4 File Offset: 0x00049BC4
		' (set) Token: 0x06009E57 RID: 40535 RVA: 0x006EF918 File Offset: 0x006EDB18
		Private _TextBox43 As TextBox
		Friend Overridable Property TextBox43 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox43
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox43_TextChanged
				Dim textBox As TextBox = Me._TextBox43
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox43 = value
				textBox = Me._TextBox43
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C72 RID: 15474
		' (get) Token: 0x06009E58 RID: 40536 RVA: 0x0004B9CE File Offset: 0x00049BCE
		' (set) Token: 0x06009E59 RID: 40537 RVA: 0x0004B9D8 File Offset: 0x00049BD8
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17003C73 RID: 15475
		' (get) Token: 0x06009E5A RID: 40538 RVA: 0x0004B9E1 File Offset: 0x00049BE1
		' (set) Token: 0x06009E5B RID: 40539 RVA: 0x006EF95C File Offset: 0x006EDB5C
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C74 RID: 15476
		' (get) Token: 0x06009E5C RID: 40540 RVA: 0x0004B9EB File Offset: 0x00049BEB
		' (set) Token: 0x06009E5D RID: 40541 RVA: 0x006EF9A0 File Offset: 0x006EDBA0
		Private _LinkLabel2 As LinkLabel
		Friend Overridable Property LinkLabel2 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel2_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel2 = value
				linkLabel = Me._LinkLabel2
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C75 RID: 15477
		' (get) Token: 0x06009E5E RID: 40542 RVA: 0x0004B9F5 File Offset: 0x00049BF5
		' (set) Token: 0x06009E5F RID: 40543 RVA: 0x006EF9E4 File Offset: 0x006EDBE4
		Private _LinkLabel3 As LinkLabel
		Friend Overridable Property LinkLabel3 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel3_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel3 = value
				linkLabel = Me._LinkLabel3
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C76 RID: 15478
		' (get) Token: 0x06009E60 RID: 40544 RVA: 0x0004B9FF File Offset: 0x00049BFF
		' (set) Token: 0x06009E61 RID: 40545 RVA: 0x0004BA09 File Offset: 0x00049C09
		Friend Overridable Property Label29 As Label

		' Token: 0x17003C77 RID: 15479
		' (get) Token: 0x06009E62 RID: 40546 RVA: 0x0004BA12 File Offset: 0x00049C12
		' (set) Token: 0x06009E63 RID: 40547 RVA: 0x006EFA28 File Offset: 0x006EDC28
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

		' Token: 0x17003C78 RID: 15480
		' (get) Token: 0x06009E64 RID: 40548 RVA: 0x0004BA1C File Offset: 0x00049C1C
		' (set) Token: 0x06009E65 RID: 40549 RVA: 0x0004BA26 File Offset: 0x00049C26
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17003C79 RID: 15481
		' (get) Token: 0x06009E66 RID: 40550 RVA: 0x0004BA2F File Offset: 0x00049C2F
		' (set) Token: 0x06009E67 RID: 40551 RVA: 0x006EFA6C File Offset: 0x006EDC6C
		Private _LinkLabel4 As LinkLabel
		Friend Overridable Property LinkLabel4 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel4_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel4 = value
				linkLabel = Me._LinkLabel4
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C7A RID: 15482
		' (get) Token: 0x06009E68 RID: 40552 RVA: 0x0004BA39 File Offset: 0x00049C39
		' (set) Token: 0x06009E69 RID: 40553 RVA: 0x006EFAB0 File Offset: 0x006EDCB0
		Private _LinkLabel7 As LinkLabel
		Friend Overridable Property LinkLabel7 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel7_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel7
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel7 = value
				linkLabel = Me._LinkLabel7
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C7B RID: 15483
		' (get) Token: 0x06009E6A RID: 40554 RVA: 0x0004BA43 File Offset: 0x00049C43
		' (set) Token: 0x06009E6B RID: 40555 RVA: 0x006EFAF4 File Offset: 0x006EDCF4
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

		' Token: 0x17003C7C RID: 15484
		' (get) Token: 0x06009E6C RID: 40556 RVA: 0x0004BA4D File Offset: 0x00049C4D
		' (set) Token: 0x06009E6D RID: 40557 RVA: 0x006EFB38 File Offset: 0x006EDD38
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

		' Token: 0x17003C7D RID: 15485
		' (get) Token: 0x06009E6E RID: 40558 RVA: 0x0004BA57 File Offset: 0x00049C57
		' (set) Token: 0x06009E6F RID: 40559 RVA: 0x006EFB7C File Offset: 0x006EDD7C
		Private _TextBox48 As TextBox
		Friend Overridable Property TextBox48 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox48
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox48_TextChanged
				Dim textBox As TextBox = Me._TextBox48
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox48 = value
				textBox = Me._TextBox48
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C7E RID: 15486
		' (get) Token: 0x06009E70 RID: 40560 RVA: 0x0004BA61 File Offset: 0x00049C61
		' (set) Token: 0x06009E71 RID: 40561 RVA: 0x0004BA6B File Offset: 0x00049C6B
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17003C7F RID: 15487
		' (get) Token: 0x06009E72 RID: 40562 RVA: 0x0004BA74 File Offset: 0x00049C74
		' (set) Token: 0x06009E73 RID: 40563 RVA: 0x0004BA7E File Offset: 0x00049C7E
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003C80 RID: 15488
		' (get) Token: 0x06009E74 RID: 40564 RVA: 0x0004BA87 File Offset: 0x00049C87
		' (set) Token: 0x06009E75 RID: 40565 RVA: 0x0004BA91 File Offset: 0x00049C91
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17003C81 RID: 15489
		' (get) Token: 0x06009E76 RID: 40566 RVA: 0x0004BA9A File Offset: 0x00049C9A
		' (set) Token: 0x06009E77 RID: 40567 RVA: 0x0004BAA4 File Offset: 0x00049CA4
		Friend Overridable Property dgw2 As DataGridView

		' Token: 0x17003C82 RID: 15490
		' (get) Token: 0x06009E78 RID: 40568 RVA: 0x0004BAAD File Offset: 0x00049CAD
		' (set) Token: 0x06009E79 RID: 40569 RVA: 0x0004BAB7 File Offset: 0x00049CB7
		Friend Overridable Property dgw3 As DataGridView

		' Token: 0x17003C83 RID: 15491
		' (get) Token: 0x06009E7A RID: 40570 RVA: 0x0004BAC0 File Offset: 0x00049CC0
		' (set) Token: 0x06009E7B RID: 40571 RVA: 0x006EFBC0 File Offset: 0x006EDDC0
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

		' Token: 0x17003C84 RID: 15492
		' (get) Token: 0x06009E7C RID: 40572 RVA: 0x0004BACA File Offset: 0x00049CCA
		' (set) Token: 0x06009E7D RID: 40573 RVA: 0x0004BAD4 File Offset: 0x00049CD4
		Friend Overridable Property Label31 As Label

		' Token: 0x17003C85 RID: 15493
		' (get) Token: 0x06009E7E RID: 40574 RVA: 0x0004BADD File Offset: 0x00049CDD
		' (set) Token: 0x06009E7F RID: 40575 RVA: 0x0004BAE7 File Offset: 0x00049CE7
		Friend Overridable Property Label30 As Label

		' Token: 0x17003C86 RID: 15494
		' (get) Token: 0x06009E80 RID: 40576 RVA: 0x0004BAF0 File Offset: 0x00049CF0
		' (set) Token: 0x06009E81 RID: 40577 RVA: 0x006EFC04 File Offset: 0x006EDE04
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

		' Token: 0x17003C87 RID: 15495
		' (get) Token: 0x06009E82 RID: 40578 RVA: 0x0004BAFA File Offset: 0x00049CFA
		' (set) Token: 0x06009E83 RID: 40579 RVA: 0x0004BB04 File Offset: 0x00049D04
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003C88 RID: 15496
		' (get) Token: 0x06009E84 RID: 40580 RVA: 0x0004BB0D File Offset: 0x00049D0D
		' (set) Token: 0x06009E85 RID: 40581 RVA: 0x0004BB17 File Offset: 0x00049D17
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003C89 RID: 15497
		' (get) Token: 0x06009E86 RID: 40582 RVA: 0x0004BB20 File Offset: 0x00049D20
		' (set) Token: 0x06009E87 RID: 40583 RVA: 0x0004BB2A File Offset: 0x00049D2A
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003C8A RID: 15498
		' (get) Token: 0x06009E88 RID: 40584 RVA: 0x0004BB33 File Offset: 0x00049D33
		' (set) Token: 0x06009E89 RID: 40585 RVA: 0x0004BB3D File Offset: 0x00049D3D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17003C8B RID: 15499
		' (get) Token: 0x06009E8A RID: 40586 RVA: 0x0004BB46 File Offset: 0x00049D46
		' (set) Token: 0x06009E8B RID: 40587 RVA: 0x0004BB50 File Offset: 0x00049D50
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17003C8C RID: 15500
		' (get) Token: 0x06009E8C RID: 40588 RVA: 0x0004BB59 File Offset: 0x00049D59
		' (set) Token: 0x06009E8D RID: 40589 RVA: 0x0004BB63 File Offset: 0x00049D63
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17003C8D RID: 15501
		' (get) Token: 0x06009E8E RID: 40590 RVA: 0x0004BB6C File Offset: 0x00049D6C
		' (set) Token: 0x06009E8F RID: 40591 RVA: 0x0004BB76 File Offset: 0x00049D76
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17003C8E RID: 15502
		' (get) Token: 0x06009E90 RID: 40592 RVA: 0x0004BB7F File Offset: 0x00049D7F
		' (set) Token: 0x06009E91 RID: 40593 RVA: 0x0004BB89 File Offset: 0x00049D89
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17003C8F RID: 15503
		' (get) Token: 0x06009E92 RID: 40594 RVA: 0x0004BB92 File Offset: 0x00049D92
		' (set) Token: 0x06009E93 RID: 40595 RVA: 0x0004BB9C File Offset: 0x00049D9C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003C90 RID: 15504
		' (get) Token: 0x06009E94 RID: 40596 RVA: 0x0004BBA5 File Offset: 0x00049DA5
		' (set) Token: 0x06009E95 RID: 40597 RVA: 0x006EFC48 File Offset: 0x006EDE48
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003C91 RID: 15505
		' (get) Token: 0x06009E96 RID: 40598 RVA: 0x0004BBAF File Offset: 0x00049DAF
		' (set) Token: 0x06009E97 RID: 40599 RVA: 0x0004BBB9 File Offset: 0x00049DB9
		Friend Overridable Property btnReset As GelButton

		' Token: 0x06009E98 RID: 40600 RVA: 0x006EFC8C File Offset: 0x006EDE8C
		Private Sub FYDate()
			Dim year As Integer = Me.DateTimePicker1.Value.Year
			Me.DateTimePicker1.MinDate = DateTimePicker.MinimumDateTime
			Me.DateTimePicker1.MaxDate = New DateTime(year + 1, 3, 31)
			Me.DateTimePicker1.MinDate = New DateTime(year, 4, 1)
			Me.DateTimePicker1.Value = New DateTime(year, 4, 1)
		End Sub

		' Token: 0x06009E99 RID: 40601 RVA: 0x006EFD00 File Offset: 0x006EDF00
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo),RTRIM(CurSym) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DateTimePicker1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.Label30.Text = "(" + NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(2), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString() + ")"
					Me.Label31.Text = "(" + NewLateBinding.LateGet(ModCommonClasses.rdr.GetValue(2), Nothing, "TrimEnd", New Object(-1) {}, Nothing, Nothing, Nothing).ToString() + ")"
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

		' Token: 0x06009E9A RID: 40602 RVA: 0x006EFE6C File Offset: 0x006EE06C
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.c11()
			Me.c111()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.f11()
			Me.g1()
			Me.h1()
			Me.cih()
			Me.Bank()
			Me.SD()
			Me.SC()
			Me.PurRtn()
			Me.ServiceTax()
			Me.Taxpaid()
			Me.fixedassets()
			Me.loan()
			Me.h123()
			Me.h124()
			Me.bpr1()
			Me.frtn1()
			Me.f11rtn()
			Me.PurchaseValue()
			Me.PurchaseValue_by_Sales()
			Me.Calculate()
		End Sub

		' Token: 0x06009E9B RID: 40603 RVA: 0x006EFF48 File Offset: 0x006EE148
		Private Sub OPS()
			Me.TextBox50.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(PPrice * Qty)) from Product_OpeningStock where PAddDate between @f1  And  @f2"
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

		' Token: 0x06009E9C RID: 40604 RVA: 0x006F00C0 File Offset: 0x006EE2C0
		Private Sub a1()
			Me.TextBox1.Text = ""
			Me.TextBox21.Text = ""
			Me.TextBox26.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS))),(Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS) from invoiceinfo where invoicedate between @f1  And  @f2"
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
					Me.TextBox26.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox21.Text = Conversions.ToString(Me.rdr1.GetValue(2))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
			Me.TextBox26.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text), 2), "0.00")
			Me.TextBox21.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox21.Text), 2), "0.00")
		End Sub

		' Token: 0x06009E9D RID: 40605 RVA: 0x006F02F8 File Offset: 0x006EE4F8
		Private Sub b1()
			Me.TextBox39.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(GrandTotal) from PurchaseReturn where date between @f1  And  @f2"
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
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox39.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text), 2), "0.00")
		End Sub

		' Token: 0x06009E9E RID: 40606 RVA: 0x006F0470 File Offset: 0x006EE670
		Private Sub bpr1()
			Me.TextBox40.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from PurchaseReturn where RCM='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox40.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox40.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x06009E9F RID: 40607 RVA: 0x006F05E8 File Offset: 0x006EE7E8
		Private Sub c1()
			Me.TextBox5.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Income (Direct/Indirect)') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox5.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox5.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox5.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA0 RID: 40608 RVA: 0x006F0760 File Offset: 0x006EE960
		Private Sub c11()
			Me.TextBox33.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Capital Account') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox33.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox33.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox33.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA1 RID: 40609 RVA: 0x006F08D8 File Offset: 0x006EEAD8
		Private Sub c111()
			Me.TextBox34.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Income_OtherDetails where Note in ('Loan (Liability)') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox34.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox34.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox34.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA2 RID: 40610 RVA: 0x006F0A50 File Offset: 0x006EEC50
		Private Sub d1()
			Me.TextBox3.Text = ""
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
					Me.TextBox3.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox3.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox3.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA3 RID: 40611 RVA: 0x006F0BC8 File Offset: 0x006EEDC8
		Private Sub e1()
			Me.TextBox4.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(RepairCharges)-Sum(Upfront)) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox4.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox4.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox4.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA4 RID: 40612 RVA: 0x006F0D40 File Offset: 0x006EEF40
		Private Sub f1()
			Me.TextBox41.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-Sum(PreviousDue)) from stock where date between @f1  And  @f2"
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

		' Token: 0x06009EA5 RID: 40613 RVA: 0x006F0EB8 File Offset: 0x006EF0B8
		Private Sub frtn1()
			Me.TextBox24.Text = ""
			Me.TextBox19.Text = ""
			Me.TextBox42.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS), (Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS)) from stock where ReferenceNo2='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox24.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox19.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox42.Text = Conversions.ToString(Me.rdr1.GetValue(2))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox24.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text), 2), "0.00")
			Me.TextBox19.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox19.Text), 2), "0.00")
			Me.TextBox42.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA6 RID: 40614 RVA: 0x006F10F0 File Offset: 0x006EF2F0
		Private Sub f11()
			Me.TextBox43.Text = ""
			Me.TextBox44.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS) from stock where ReferenceNo2='Yes' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox43.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox44.Text = Conversions.ToString(Me.rdr1.GetValue(1))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox43.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox43.Text), 2), "0.00")
			Me.TextBox44.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA7 RID: 40615 RVA: 0x006F12C8 File Offset: 0x006EF4C8
		Private Sub f11rtn()
			Me.TextBox45.Text = ""
			Me.TextBox46.Text = ""
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
					Me.TextBox45.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox46.Text = Conversions.ToString(Me.rdr1.GetValue(1))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox45.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox45.Text), 2), "0.00")
			Me.TextBox46.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox46.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA8 RID: 40616 RVA: 0x006F14A0 File Offset: 0x006EF6A0
		Private Sub g1()
			Me.TextBox7.Text = ""
			Me.TextBox25.Text = ""
			Me.TextBox20.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(GrandTotal)-(Sum(CGST)+Sum(SGST)+Sum(IGST)+Sum(CESS))),(Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS) from SalesReturn where date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox7.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox25.Text = Conversions.ToString(Me.rdr1.GetValue(1))
					Me.TextBox20.Text = Conversions.ToString(Me.rdr1.GetValue(2))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox7.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox7.Text), 2), "0.00")
			Me.TextBox25.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox25.Text), 2), "0.00")
			Me.TextBox20.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox20.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EA9 RID: 40617 RVA: 0x006F16D8 File Offset: 0x006EF8D8
		Private Sub h1()
			Me.TextBox8.Text = ""
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
					Me.TextBox8.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox8.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox8.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EAA RID: 40618 RVA: 0x006F1850 File Offset: 0x006EFA50
		Private Sub cal1()
			Me.TextBox9.Text = Conversions.ToString(Conversion.Val(Me.TextBox6.Text) + Conversion.Val(Me.TextBox7.Text) + Conversion.Val(Me.TextBox8.Text) + Conversion.Val(Me.TextBox48.Text) + Conversion.Val(Me.TextBox49.Text))
		End Sub

		' Token: 0x06009EAB RID: 40619 RVA: 0x0004BBC2 File Offset: 0x00049DC2
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
			Me.cal3()
		End Sub

		' Token: 0x06009EAC RID: 40620 RVA: 0x006F18C4 File Offset: 0x006EFAC4
		Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox41.Text) - Conversion.Val(Me.TextBox42.Text), 2), "0.00")
			Me.cal1()
		End Sub

		' Token: 0x06009EAD RID: 40621 RVA: 0x0004BBD3 File Offset: 0x00049DD3
		Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x06009EAE RID: 40622 RVA: 0x0004BBD3 File Offset: 0x00049DD3
		Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x06009EAF RID: 40623 RVA: 0x006F191C File Offset: 0x006EFB1C
		Private Sub cal2()
			Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.TextBox1.Text) + Conversion.Val(Me.TextBox2.Text) + Conversion.Val(Me.TextBox3.Text) + Conversion.Val(Me.TextBox4.Text) + Conversion.Val(Me.TextBox5.Text))
		End Sub

		' Token: 0x06009EB0 RID: 40624 RVA: 0x0004BBDD File Offset: 0x00049DDD
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
			Me.cal3()
		End Sub

		' Token: 0x06009EB1 RID: 40625 RVA: 0x0004BBEE File Offset: 0x00049DEE
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x06009EB2 RID: 40626 RVA: 0x006F1990 File Offset: 0x006EFB90
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text) - Conversion.Val(Me.TextBox40.Text), 2), "0.00")
			Me.cal2()
		End Sub

		' Token: 0x06009EB3 RID: 40627 RVA: 0x0004BBEE File Offset: 0x00049DEE
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x06009EB4 RID: 40628 RVA: 0x0004BBEE File Offset: 0x00049DEE
		Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x06009EB5 RID: 40629 RVA: 0x0004BBEE File Offset: 0x00049DEE
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Me.cal2()
		End Sub

		' Token: 0x06009EB6 RID: 40630 RVA: 0x006F19E8 File Offset: 0x006EFBE8
		Private Sub cal3()
			Me.TextBox11.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox10.Text) - (Conversion.Val(Me.TextBox9.Text) + Conversion.Val(Me.TextBox50.Text)), 2), "0.00")
			Dim flag As Boolean = Conversion.Val(Me.TextBox11.Text) < 0.0
			If flag Then
				Me.Label16.Text = "Net Loss :"
				Me.TextBox11.ForeColor = Color.Red
				Me.TextBox11.BackColor = Color.White
			Else
				Dim flag2 As Boolean = Conversion.Val(Me.TextBox11.Text) > 0.0
				If flag2 Then
					Me.Label16.Text = "Net Profit :"
					Me.TextBox11.ForeColor = Color.Blue
					Me.TextBox11.BackColor = Color.White
				Else
					Dim flag3 As Boolean = Conversion.Val(Me.TextBox11.Text) = 0.0
					If flag3 Then
						Me.Label16.Text = "Profit / Loss :"
						Me.TextBox11.ForeColor = Color.Black
						Me.TextBox11.BackColor = Color.White
					End If
				End If
			End If
		End Sub

		' Token: 0x06009EB7 RID: 40631 RVA: 0x006F1B4C File Offset: 0x006EFD4C
		Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EB8 RID: 40632 RVA: 0x0004BBF8 File Offset: 0x00049DF8
		Private Sub TextBox50_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
		End Sub

		' Token: 0x06009EB9 RID: 40633 RVA: 0x0004BBF8 File Offset: 0x00049DF8
		Private Sub Label16_TextChanged(sender As Object, e As EventArgs)
			Me.cal3()
		End Sub

		' Token: 0x06009EBA RID: 40634 RVA: 0x006F1BD8 File Offset: 0x006EFDD8
		Private Sub BalanceSheetForm_Load(sender As Object, e As EventArgs)
			Me.Timer1.Enabled = True
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.c11()
			Me.c111()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.g1()
			Me.h1()
			Me.cih()
			Me.Bank()
			Me.SD()
			Me.SC()
			Me.f11()
			Me.PurRtn()
			Me.ServiceTax()
			Me.Taxpaid()
			Me.fixedassets()
			Me.loan()
			Me.h123()
			Me.h124()
			Me.bpr1()
			Me.frtn1()
			Me.f11rtn()
			Me.PurchaseValue()
			Me.PurchaseValue_by_Sales()
			Me.Calculate()
			Me.Convert_Language()
		End Sub

		' Token: 0x06009EBB RID: 40635 RVA: 0x006F1CE0 File Offset: 0x006EFEE0
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

		' Token: 0x06009EBC RID: 40636 RVA: 0x006F1E58 File Offset: 0x006F0058
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

		' Token: 0x06009EBD RID: 40637 RVA: 0x006F1F14 File Offset: 0x006F0114
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

		' Token: 0x06009EBE RID: 40638 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06009EBF RID: 40639 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06009EC0 RID: 40640 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06009EC1 RID: 40641 RVA: 0x006F1FE0 File Offset: 0x006F01E0
		Private Sub cih()
			Me.TextBox12.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from LedgerBook where Date between @f1  And  @f2 and Name='Cash Account'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox12.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox12.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC2 RID: 40642 RVA: 0x006F2158 File Offset: 0x006F0358
		Private Sub Bank1()
			Me.TextBox13.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from BankAccountLedger where Date between @f1 and @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox13.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox13.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC3 RID: 40643 RVA: 0x006F22D0 File Offset: 0x006F04D0
		Private Sub Bank()
			Me.TextBox13.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(Credit)-Sum(Debit)) from LedgerBook where Date between @f1  And  @f2 and Name='Bank Account'"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox13.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox13.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox13.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC4 RID: 40644 RVA: 0x006F2448 File Offset: 0x006F0648
		Private Sub SD()
			Me.TextBox14.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT isNULL(Sum(Debit),0)-IsNull(Sum(Credit),0) from CustomerLedgerBook WHERE Date between @f1 and @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox14.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox14.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox14.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC5 RID: 40645 RVA: 0x006F25C0 File Offset: 0x006F07C0
		Private Sub SC()
			Me.TextBox15.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook WHERE Date between @f1 and @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox15.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox15.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox15.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC6 RID: 40646 RVA: 0x006F2738 File Offset: 0x006F0938
		Private Sub PurRtn()
			Me.TextBox22.Text = ""
			Me.TextBox18.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT (Sum(CGST)+Sum(SGST)+Sum(IGST)), Sum(CESS) from PurchaseReturn where RCM='No' and date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox22.Text = Conversions.ToString(Me.rdr1.GetValue(0))
					Me.TextBox18.Text = Conversions.ToString(Me.rdr1.GetValue(1))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox22.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox22.Text), 2), "0.00")
			Me.TextBox18.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC7 RID: 40647 RVA: 0x006F2910 File Offset: 0x006F0B10
		Private Sub ServiceTax()
			Me.TextBox17.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(ServiceTax) from InvoiceInfo1 where InvoiceDate between @f1  And  @f2"
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
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox17.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC8 RID: 40648 RVA: 0x006F2A88 File Offset: 0x006F0C88
		Private Sub Taxpaid()
			Me.TextBox16.Text = ""
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
					Me.TextBox16.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox16.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EC9 RID: 40649 RVA: 0x006F2C00 File Offset: 0x006F0E00
		Private Sub fixedassets()
			Me.TextBox31.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Fixed Assets') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox31.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox31.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox31.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ECA RID: 40650 RVA: 0x006F2D78 File Offset: 0x006F0F78
		Private Sub loan()
			Me.TextBox32.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(Amount) from Voucher_OtherDetails where Note in ('Loan & Advance (Assets)') and Date between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(0.0)
			Me.rdr1 = Me.cmdimg.ExecuteReader(CommandBehavior.CloseConnection)
			Dim flag As Boolean = Me.rdr1.Read()
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.rdr1.GetValue(0)))
				If flag3 Then
					Me.TextBox32.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
			Me.TextBox32.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox32.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ECB RID: 40651 RVA: 0x006F2EF0 File Offset: 0x006F10F0
		Private Sub h123()
			Me.TextBox48.Text = ""
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
					Me.TextBox48.Text = Conversions.ToString(Me.rdr1.GetValue(0))
				End If
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06009ECC RID: 40652 RVA: 0x006F3038 File Offset: 0x006F1238
		Private Sub h124()
			Me.TextBox49.Text = ""
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT Sum(NetPay) from EmployeePayment where Paymentdate  between @f1  And  @f2"
			Me.cmdimg = New SqlCommand(text, ModCommonClasses.con)
			Me.cmdimg.Parameters.Add("@f1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
			Me.cmdimg.Parameters.Add("@f2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date].AddDays(1.0)
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
		End Sub

		' Token: 0x06009ECD RID: 40653 RVA: 0x006F3180 File Offset: 0x006F1380
		Private Sub TextBox29_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
			Me.TextBox27.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox29.Text) - Conversion.Val(Me.TextBox30.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ECE RID: 40654 RVA: 0x006F3258 File Offset: 0x006F1458
		Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ECF RID: 40655 RVA: 0x006F3258 File Offset: 0x006F1458
		Private Sub TextBox25_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED0 RID: 40656 RVA: 0x006F3258 File Offset: 0x006F1458
		Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED1 RID: 40657 RVA: 0x006F3258 File Offset: 0x006F1458
		Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED2 RID: 40658 RVA: 0x006F3258 File Offset: 0x006F1458
		Private Sub TextBox17_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox29.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox26.Text) - Conversion.Val(Me.TextBox25.Text) + (Conversion.Val(Me.TextBox21.Text) - Conversion.Val(Me.TextBox20.Text)) + Conversion.Val(Me.TextBox17.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED3 RID: 40659 RVA: 0x006F32DC File Offset: 0x006F14DC
		Private Sub TextBox30_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
			Me.TextBox27.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox29.Text) - Conversion.Val(Me.TextBox30.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED4 RID: 40660 RVA: 0x006F33C4 File Offset: 0x006F15C4
		Private Sub TextBox24_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED5 RID: 40661 RVA: 0x006F33C4 File Offset: 0x006F15C4
		Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED6 RID: 40662 RVA: 0x006F33C4 File Offset: 0x006F15C4
		Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED7 RID: 40663 RVA: 0x006F33C4 File Offset: 0x006F15C4
		Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009ED8 RID: 40664 RVA: 0x006F3458 File Offset: 0x006F1658
		Private Sub TextBox27_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox27.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox29.Text) - Conversion.Val(Me.TextBox30.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009ED9 RID: 40665 RVA: 0x006F3530 File Offset: 0x006F1730
		Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox27.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox29.Text) - Conversion.Val(Me.TextBox30.Text) - Conversion.Val(Me.TextBox16.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EDA RID: 40666 RVA: 0x006F3594 File Offset: 0x006F1794
		Private Sub TextBox36_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox36.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox37.Text), 2), "0.00")
			Me.TextBox35.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox38.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EDB RID: 40667 RVA: 0x006F3618 File Offset: 0x006F1818
		Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EDC RID: 40668 RVA: 0x006F3618 File Offset: 0x006F1818
		Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EDD RID: 40669 RVA: 0x006F3618 File Offset: 0x006F1818
		Private Sub TextBox34_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EDE RID: 40670 RVA: 0x006F369C File Offset: 0x006F189C
		Private Sub TextBox35_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox35.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox38.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EDF RID: 40671 RVA: 0x006F36EC File Offset: 0x006F18EC
		Private Sub TextBox38_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox38.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox11.Text) + Conversion.Val(Me.TextBox15.Text) + (Conversion.Val(Me.TextBox27.Text) + Conversion.Val(Me.TextBox33.Text) + Conversion.Val(Me.TextBox34.Text)), 2), "0.00")
			Me.TextBox35.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox36.Text) + Conversion.Val(Me.TextBox38.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EE0 RID: 40672 RVA: 0x006F37B4 File Offset: 0x006F19B4
		Private Sub TextBox37_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
			Me.TextBox35.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox37.Text) + Conversion.Val(Me.TextBox38.Text) * 2.0, 2), "0.00")
			Me.TextBox36.Text = Conversions.ToString(Conversion.Val(Me.TextBox37.Text))
		End Sub

		' Token: 0x06009EE1 RID: 40673 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox32_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EE2 RID: 40674 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EE3 RID: 40675 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EE4 RID: 40676 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EE5 RID: 40677 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox31_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EE6 RID: 40678 RVA: 0x006F394C File Offset: 0x006F1B4C
		Private Sub TextBox39_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text) - Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EE7 RID: 40679 RVA: 0x006F394C File Offset: 0x006F1B4C
		Private Sub TextBox40_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox2.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox39.Text) - Conversion.Val(Me.TextBox40.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EE8 RID: 40680 RVA: 0x006F399C File Offset: 0x006F1B9C
		Private Sub TextBox41_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox41.Text) - Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EE9 RID: 40681 RVA: 0x006F399C File Offset: 0x006F1B9C
		Private Sub TextBox42_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox41.Text) - Conversion.Val(Me.TextBox42.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EEA RID: 40682 RVA: 0x006F39EC File Offset: 0x006F1BEC
		Private Sub TextBox23_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox23.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox43.Text) - Conversion.Val(Me.TextBox45.Text), 2), "0.00")
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EEB RID: 40683 RVA: 0x006F3AC4 File Offset: 0x006F1CC4
		Private Sub TextBox43_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox23.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox43.Text) - Conversion.Val(Me.TextBox45.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EEC RID: 40684 RVA: 0x006F3AC4 File Offset: 0x006F1CC4
		Private Sub TextBox45_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox23.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox43.Text) - Conversion.Val(Me.TextBox45.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EED RID: 40685 RVA: 0x006F3B14 File Offset: 0x006F1D14
		Private Sub TextBox28_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox28.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) - Conversion.Val(Me.TextBox46.Text), 2), "0.00")
			Me.TextBox30.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox24.Text) + Conversion.Val(Me.TextBox23.Text) + Conversion.Val(Me.TextBox28.Text) + Conversion.Val(Me.TextBox19.Text) - Conversion.Val(Me.TextBox22.Text) + Conversion.Val(Me.TextBox18.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EEE RID: 40686 RVA: 0x006F3BEC File Offset: 0x006F1DEC
		Private Sub TextBox44_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox28.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) - Conversion.Val(Me.TextBox46.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EEF RID: 40687 RVA: 0x006F3BEC File Offset: 0x006F1DEC
		Private Sub TextBox46_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox28.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox44.Text) - Conversion.Val(Me.TextBox46.Text), 2), "0.00")
		End Sub

		' Token: 0x06009EF0 RID: 40688 RVA: 0x0004332D File Offset: 0x0004152D
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.frmProfitloss.ShowDialog()
			MyProject.Forms.frmProfitloss.Dispose()
		End Sub

		' Token: 0x06009EF1 RID: 40689 RVA: 0x00033D39 File Offset: 0x00031F39
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.frmSupplierOutstanding.ShowDialog()
			MyProject.Forms.frmSupplierOutstanding.Dispose()
		End Sub

		' Token: 0x06009EF2 RID: 40690 RVA: 0x00033D16 File Offset: 0x00031F16
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.frmCustomerOutstanding.ShowDialog()
			MyProject.Forms.frmCustomerOutstanding.Dispose()
		End Sub

		' Token: 0x06009EF3 RID: 40691 RVA: 0x006F38B8 File Offset: 0x006F1AB8
		Private Sub TextBox47_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox37.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox12.Text) + Conversion.Val(Me.TextBox13.Text) + (Conversion.Val(Me.TextBox14.Text) + Conversion.Val(Me.TextBox31.Text) + Conversion.Val(Me.TextBox32.Text) + Conversion.Val(Me.TextBox47.Text)), 2), "0.00")
		End Sub

		' Token: 0x06009EF4 RID: 40692 RVA: 0x00038527 File Offset: 0x00036727
		Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.frmCashLedger.ShowDialog()
			MyProject.Forms.frmCashLedger.Dispose()
		End Sub

		' Token: 0x06009EF5 RID: 40693 RVA: 0x000385B0 File Offset: 0x000367B0
		Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.frmBankLedger.ShowDialog()
			MyProject.Forms.frmBankLedger.Dispose()
		End Sub

		' Token: 0x06009EF6 RID: 40694 RVA: 0x006F3C3C File Offset: 0x006F1E3C
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.PrintPreviewDialog1.Document = Me.PrintDoc1
			Me.PrintDoc1.OriginAtMargins = False
			AddHandler Me.PrintDoc1.PrintPage, AddressOf Me.PDoc_PrintPage
			Me.PrintPreviewDialog1.ShowDialog()
		End Sub

		' Token: 0x06009EF7 RID: 40695 RVA: 0x006F3C90 File Offset: 0x006F1E90
		Private Sub PDoc_PrintPage(sender As Object, e As PrintPageEventArgs)
			Dim bitmap As Bitmap = New Bitmap(MyBase.Width, MyBase.Height)
			MyBase.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
			Dim flag As Boolean = (MyBase.Width > 700) Or (MyBase.Height > 1100)
			If flag Then
				Dim bitmap2 As Bitmap = New Bitmap(bitmap)
				Dim num As Integer = CInt(Math.Round(700.0 * CDbl(MyBase.Height) / CDbl(MyBase.Width)))
				Dim bitmap3 As Bitmap = New Bitmap(bitmap2, 700, num)
				e.Graphics.DrawImage(bitmap3, 50, 50)
			Else
				e.Graphics.DrawImage(bitmap, 50, 50)
			End If
		End Sub

		' Token: 0x06009EF8 RID: 40696 RVA: 0x0004BBD3 File Offset: 0x00049DD3
		Private Sub TextBox48_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x06009EF9 RID: 40697 RVA: 0x0004BBD3 File Offset: 0x00049DD3
		Private Sub TextBox49_TextChanged(sender As Object, e As EventArgs)
			Me.cal1()
		End Sub

		' Token: 0x06009EFA RID: 40698 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub BalanceSheetForm_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06009EFB RID: 40699 RVA: 0x006F3D48 File Offset: 0x006F1F48
		Private Sub PurchaseValue()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Product.ProductName), (Stock_Product.TotalAmount-(Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt)), Stock.Date, Stock_Product.DiscountAmt,(Stock_Product.CGSTAmt + Stock_Product.SGSTAmt + Stock_Product.IGSTAmt + Stock_Product.CESSAmt) FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID WHERE Stock.Date between @d1 and @d2 order by Stock.Date ASC, Stock.ST_ID ASC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw2.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009EFC RID: 40700 RVA: 0x006F3EC8 File Offset: 0x006F20C8
		Private Sub PurchaseValue_by_Sales()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Product.ProductName), (Invoice_Product.PurchaseRate * Invoice_Product.Qty), InvoiceInfo.InvoiceDate, ((Invoice_Product.PurchaseRate * Invoice_Product.Qty) * ((Invoice_Product.CGSTPer + Invoice_Product.SGSTPer + Invoice_Product.IGSTPer + Invoice_Product.CESSPer) * 0.01)) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID WHERE InvoiceInfo.InvoiceDate between @d1 and @d2 order by InvoiceInfo.InvoiceDate ASC, InvoiceInfo.Inv_ID ASC", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw3.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw3.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06009EFD RID: 40701 RVA: 0x006F4038 File Offset: 0x006F2238
		Private Sub Calculate()
			Try
				Dim num2 As Double
				Dim num4 As Double
				Dim num8 As Double
				Dim num10 As Double
				Dim num As Integer = Me.dgw2.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(i).Cells("Column18").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(i).Cells("Column18").Value))
						End If

				Next
				Dim num3 As Integer = Me.dgw3.Rows.Count - 1
				For j As Integer = 0 To num3
					Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn2").Value))

						If flag2 Then
							num4 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(j).Cells("DataGridViewTextBoxColumn2").Value))
						End If

				Next
				Dim num5 As Integer = Me.dgw2.Rows.Count - 1
				For k As Integer = 0 To num5
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(k).Cells("Column1").Value))

						If flag3 Then
							Dim num6 As Double
							num6 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(k).Cells("Column1").Value))
						End If

				Next
				Dim num7 As Integer = Me.dgw2.Rows.Count - 1
				For l As Integer = 0 To num7
					Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(l).Cells("Column2").Value))

						If flag4 Then
							num8 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw2.Rows(l).Cells("Column2").Value))
						End If

				Next
				Dim num9 As Integer = Me.dgw3.Rows.Count - 1
				For m As Integer = 0 To num9
					Dim flag5 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(m).Cells("Column3").Value))

						If flag5 Then
							num10 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw3.Rows(m).Cells("Column3").Value))
						End If

				Next
				Me.TextBox47.Text = Conversions.ToString(Conversion.Val(Me.TextBox50.Text) + (num2 + num8) - (num4 + num10))
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox47.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox47.Text) + 0.0, 2), "0.00")
		End Sub

		' Token: 0x06009EFE RID: 40702 RVA: 0x006F43CC File Offset: 0x006F25CC
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.Clear()
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Profit & Loss", New Object() { Me.TextBox11.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("S.Creditor", New Object() { Me.TextBox15.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Duties & Taxes", New Object() { Me.TextBox27.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Capital A/c", New Object() { Me.TextBox33.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Loan(Libility)", New Object() { Me.TextBox34.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Fixed Asset", New Object() { Me.TextBox31.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Cash-in-Hand", New Object() { Me.TextBox12.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Bank Balance", New Object() { Me.TextBox13.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("S.Debtor", New Object() { Me.TextBox14.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Loan(Asset)", New Object() { Me.TextBox32.Text })
			MyProject.Forms.frmChat1.Chart3.Series("A").Points.AddXY("Stock-in-Hand", New Object() { Me.TextBox47.Text })
			MyProject.Forms.frmChat1.ShowDialog()
		End Sub

		' Token: 0x06009EFF RID: 40703 RVA: 0x006F46EC File Offset: 0x006F28EC
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.OPS()
			Me.a1()
			Me.b1()
			Me.c1()
			Me.c11()
			Me.c111()
			Me.d1()
			Me.e1()
			Me.f1()
			Me.g1()
			Me.h1()
			Me.cih()
			Me.Bank()
			Me.SD()
			Me.SC()
			Me.f11()
			Me.PurRtn()
			Me.ServiceTax()
			Me.Taxpaid()
			Me.fixedassets()
			Me.loan()
			Me.h123()
			Me.h124()
			Me.bpr1()
			Me.frtn1()
			Me.f11rtn()
			Me.PurchaseValue()
			Me.PurchaseValue_by_Sales()
			Me.Calculate()
		End Sub

		' Token: 0x06009F00 RID: 40704 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Button2_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x040044D9 RID: 17625
		Private cmdimg As SqlCommand

		' Token: 0x040044DA RID: 17626
		Private rdr1 As SqlDataReader

		' Token: 0x040044DB RID: 17627
		Private PrintDoc1 As PrintDocument

		' Token: 0x040044DC RID: 17628
		Private PrintPreviewDialog1 As PrintPreviewDialog
	End Class
End Namespace
