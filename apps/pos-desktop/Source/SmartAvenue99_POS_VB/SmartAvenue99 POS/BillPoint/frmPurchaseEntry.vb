Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.Win32

Namespace BillPoint
	' Token: 0x020001EE RID: 494
	<DesignerGenerated()>
	Public Partial Class frmPurchaseEntry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06008477 RID: 33911 RVA: 0x00623310 File Offset: 0x00621510
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStock_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPurchaseEntry_KeyDown
			AddHandler MyBase.FormClosing, AddressOf Me.frmPurchaseEntry_FormClosing
			Me.dt = New DataTable()
			Me.keyPath = "HKEY_CURRENT_USER\Software\POS"
			Me.valueName = "MarginPurchaseEntry"
			Me.ntid = ""
			Me.gstid = ""
			Me.lastClickedButton = Nothing
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.Dst = New DataSet()
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.InitializeComponent()
		End Sub

		' Token: 0x17003095 RID: 12437
		' (get) Token: 0x0600847A RID: 33914 RVA: 0x00040D6C File Offset: 0x0003EF6C
		' (set) Token: 0x0600847B RID: 33915 RVA: 0x00040D76 File Offset: 0x0003EF76
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003096 RID: 12438
		' (get) Token: 0x0600847C RID: 33916 RVA: 0x00040D7F File Offset: 0x0003EF7F
		' (set) Token: 0x0600847D RID: 33917 RVA: 0x00040D89 File Offset: 0x0003EF89
		Friend Overridable Property Label3 As Label

		' Token: 0x17003097 RID: 12439
		' (get) Token: 0x0600847E RID: 33918 RVA: 0x00040D92 File Offset: 0x0003EF92
		' (set) Token: 0x0600847F RID: 33919 RVA: 0x00040D9C File Offset: 0x0003EF9C
		Friend Overridable Property txtInvoiceNo As TextBox

		' Token: 0x17003098 RID: 12440
		' (get) Token: 0x06008480 RID: 33920 RVA: 0x00040DA5 File Offset: 0x0003EFA5
		' (set) Token: 0x06008481 RID: 33921 RVA: 0x00638C6C File Offset: 0x00636E6C
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClose_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003099 RID: 12441
		' (get) Token: 0x06008482 RID: 33922 RVA: 0x00040DAF File Offset: 0x0003EFAF
		' (set) Token: 0x06008483 RID: 33923 RVA: 0x00040DB9 File Offset: 0x0003EFB9
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700309A RID: 12442
		' (get) Token: 0x06008484 RID: 33924 RVA: 0x00040DC2 File Offset: 0x0003EFC2
		' (set) Token: 0x06008485 RID: 33925 RVA: 0x00040DCC File Offset: 0x0003EFCC
		Friend Overridable Property Label1 As Label

		' Token: 0x1700309B RID: 12443
		' (get) Token: 0x06008486 RID: 33926 RVA: 0x00040DD5 File Offset: 0x0003EFD5
		' (set) Token: 0x06008487 RID: 33927 RVA: 0x00040DDF File Offset: 0x0003EFDF
		Friend Overridable Property Label2 As Label

		' Token: 0x1700309C RID: 12444
		' (get) Token: 0x06008488 RID: 33928 RVA: 0x00040DE8 File Offset: 0x0003EFE8
		' (set) Token: 0x06008489 RID: 33929 RVA: 0x00638CB0 File Offset: 0x00636EB0
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.DataGridView1_RowPostPaint
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.DataGridView1_CellFormatting
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700309D RID: 12445
		' (get) Token: 0x0600848A RID: 33930 RVA: 0x00040DF2 File Offset: 0x0003EFF2
		' (set) Token: 0x0600848B RID: 33931 RVA: 0x00040DFC File Offset: 0x0003EFFC
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700309E RID: 12446
		' (get) Token: 0x0600848C RID: 33932 RVA: 0x00040E05 File Offset: 0x0003F005
		' (set) Token: 0x0600848D RID: 33933 RVA: 0x00040E0F File Offset: 0x0003F00F
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x1700309F RID: 12447
		' (get) Token: 0x0600848E RID: 33934 RVA: 0x00040E18 File Offset: 0x0003F018
		' (set) Token: 0x0600848F RID: 33935 RVA: 0x00638D50 File Offset: 0x00636F50
		Private _txtPricePerQty As TextBox
		Friend Overridable Property txtPricePerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPricePerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtPricePerQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPricePerQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPricePerQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtPricePerQty_Leave
				Dim eventHandler3 As EventHandler = AddressOf Me.txtPricePerQty_GotFocus
				Dim eventHandler4 As EventHandler = AddressOf Me.txtPricePerQty_LostFocus
				Dim textBox As TextBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler2
					RemoveHandler textBox.GotFocus, eventHandler3
					RemoveHandler textBox.LostFocus, eventHandler4
				End If
				Me._txtPricePerQty = value
				textBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler2
					AddHandler textBox.GotFocus, eventHandler3
					AddHandler textBox.LostFocus, eventHandler4
				End If
			End Set
		End Property

		' Token: 0x170030A0 RID: 12448
		' (get) Token: 0x06008490 RID: 33936 RVA: 0x00040E22 File Offset: 0x0003F022
		' (set) Token: 0x06008491 RID: 33937 RVA: 0x00638E30 File Offset: 0x00637030
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtQty_KeyPress
				Dim eventHandler2 As EventHandler = AddressOf Me.txtQty_Leave
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Leave, eventHandler2
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Leave, eventHandler2
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030A1 RID: 12449
		' (get) Token: 0x06008492 RID: 33938 RVA: 0x00040E2C File Offset: 0x0003F02C
		' (set) Token: 0x06008493 RID: 33939 RVA: 0x00638ED0 File Offset: 0x006370D0
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

		' Token: 0x170030A2 RID: 12450
		' (get) Token: 0x06008494 RID: 33940 RVA: 0x00040E36 File Offset: 0x0003F036
		' (set) Token: 0x06008495 RID: 33941 RVA: 0x00040E40 File Offset: 0x0003F040
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x170030A3 RID: 12451
		' (get) Token: 0x06008496 RID: 33942 RVA: 0x00040E49 File Offset: 0x0003F049
		' (set) Token: 0x06008497 RID: 33943 RVA: 0x00040E53 File Offset: 0x0003F053
		Friend Overridable Property Label7 As Label

		' Token: 0x170030A4 RID: 12452
		' (get) Token: 0x06008498 RID: 33944 RVA: 0x00040E5C File Offset: 0x0003F05C
		' (set) Token: 0x06008499 RID: 33945 RVA: 0x00040E66 File Offset: 0x0003F066
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170030A5 RID: 12453
		' (get) Token: 0x0600849A RID: 33946 RVA: 0x00040E6F File Offset: 0x0003F06F
		' (set) Token: 0x0600849B RID: 33947 RVA: 0x00638F14 File Offset: 0x00637114
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030A6 RID: 12454
		' (get) Token: 0x0600849C RID: 33948 RVA: 0x00040E79 File Offset: 0x0003F079
		' (set) Token: 0x0600849D RID: 33949 RVA: 0x00040E83 File Offset: 0x0003F083
		Friend Overridable Property txtRemarks As RichTextBox

		' Token: 0x170030A7 RID: 12455
		' (get) Token: 0x0600849E RID: 33950 RVA: 0x00040E8C File Offset: 0x0003F08C
		' (set) Token: 0x0600849F RID: 33951 RVA: 0x00040E96 File Offset: 0x0003F096
		Friend Overridable Property Label12 As Label

		' Token: 0x170030A8 RID: 12456
		' (get) Token: 0x060084A0 RID: 33952 RVA: 0x00040E9F File Offset: 0x0003F09F
		' (set) Token: 0x060084A1 RID: 33953 RVA: 0x00638F74 File Offset: 0x00637174
		Private _txtSup_ID As TextBox
		Friend Overridable Property txtSup_ID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSup_ID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSup_ID_TextChanged
				Dim textBox As TextBox = Me._txtSup_ID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSup_ID = value
				textBox = Me._txtSup_ID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030A9 RID: 12457
		' (get) Token: 0x060084A2 RID: 33954 RVA: 0x00040EA9 File Offset: 0x0003F0A9
		' (set) Token: 0x060084A3 RID: 33955 RVA: 0x00040EB3 File Offset: 0x0003F0B3
		Friend Overridable Property txtST_ID As TextBox

		' Token: 0x170030AA RID: 12458
		' (get) Token: 0x060084A4 RID: 33956 RVA: 0x00040EBC File Offset: 0x0003F0BC
		' (set) Token: 0x060084A5 RID: 33957 RVA: 0x00040EC6 File Offset: 0x0003F0C6
		Friend Overridable Property lblUser As Label

		' Token: 0x170030AB RID: 12459
		' (get) Token: 0x060084A6 RID: 33958 RVA: 0x00040ECF File Offset: 0x0003F0CF
		' (set) Token: 0x060084A7 RID: 33959 RVA: 0x00040ED9 File Offset: 0x0003F0D9
		Friend Overridable Property lblSet As Label

		' Token: 0x170030AC RID: 12460
		' (get) Token: 0x060084A8 RID: 33960 RVA: 0x00040EE2 File Offset: 0x0003F0E2
		' (set) Token: 0x060084A9 RID: 33961 RVA: 0x00040EEC File Offset: 0x0003F0EC
		Friend Overridable Property lblUserType As Label

		' Token: 0x170030AD RID: 12461
		' (get) Token: 0x060084AA RID: 33962 RVA: 0x00040EF5 File Offset: 0x0003F0F5
		' (set) Token: 0x060084AB RID: 33963 RVA: 0x00638FB8 File Offset: 0x006371B8
		Private _txtProductID As TextBox
		Friend Overridable Property txtProductID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtProductID_TextChanged
				Dim textBox As TextBox = Me._txtProductID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtProductID = value
				textBox = Me._txtProductID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030AE RID: 12462
		' (get) Token: 0x060084AC RID: 33964 RVA: 0x00040EFF File Offset: 0x0003F0FF
		' (set) Token: 0x060084AD RID: 33965 RVA: 0x00040F09 File Offset: 0x0003F109
		Friend Overridable Property gbPartyInfo As GroupBox

		' Token: 0x170030AF RID: 12463
		' (get) Token: 0x060084AE RID: 33966 RVA: 0x00040F12 File Offset: 0x0003F112
		' (set) Token: 0x060084AF RID: 33967 RVA: 0x00638FFC File Offset: 0x006371FC
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030B0 RID: 12464
		' (get) Token: 0x060084B0 RID: 33968 RVA: 0x00040F1C File Offset: 0x0003F11C
		' (set) Token: 0x060084B1 RID: 33969 RVA: 0x00040F26 File Offset: 0x0003F126
		Friend Overridable Property Label10 As Label

		' Token: 0x170030B1 RID: 12465
		' (get) Token: 0x060084B2 RID: 33970 RVA: 0x00040F2F File Offset: 0x0003F12F
		' (set) Token: 0x060084B3 RID: 33971 RVA: 0x00639040 File Offset: 0x00637240
		Private _txtSupplierID As TextBox
		Friend Overridable Property txtSupplierID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierID_TextChanged
				Dim textBox As TextBox = Me._txtSupplierID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierID = value
				textBox = Me._txtSupplierID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030B2 RID: 12466
		' (get) Token: 0x060084B4 RID: 33972 RVA: 0x00040F39 File Offset: 0x0003F139
		' (set) Token: 0x060084B5 RID: 33973 RVA: 0x00040F43 File Offset: 0x0003F143
		Friend Overridable Property lblBalance As Label

		' Token: 0x170030B3 RID: 12467
		' (get) Token: 0x060084B6 RID: 33974 RVA: 0x00040F4C File Offset: 0x0003F14C
		' (set) Token: 0x060084B7 RID: 33975 RVA: 0x00040F56 File Offset: 0x0003F156
		Friend Overridable Property Label11 As Label

		' Token: 0x170030B4 RID: 12468
		' (get) Token: 0x060084B8 RID: 33976 RVA: 0x00040F5F File Offset: 0x0003F15F
		' (set) Token: 0x060084B9 RID: 33977 RVA: 0x00040F69 File Offset: 0x0003F169
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x170030B5 RID: 12469
		' (get) Token: 0x060084BA RID: 33978 RVA: 0x00040F72 File Offset: 0x0003F172
		' (set) Token: 0x060084BB RID: 33979 RVA: 0x00040F7C File Offset: 0x0003F17C
		Friend Overridable Property txtState As TextBox

		' Token: 0x170030B6 RID: 12470
		' (get) Token: 0x060084BC RID: 33980 RVA: 0x00040F85 File Offset: 0x0003F185
		' (set) Token: 0x060084BD RID: 33981 RVA: 0x00040F8F File Offset: 0x0003F18F
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x170030B7 RID: 12471
		' (get) Token: 0x060084BE RID: 33982 RVA: 0x00040F98 File Offset: 0x0003F198
		' (set) Token: 0x060084BF RID: 33983 RVA: 0x00040FA2 File Offset: 0x0003F1A2
		Friend Overridable Property Label36 As Label

		' Token: 0x170030B8 RID: 12472
		' (get) Token: 0x060084C0 RID: 33984 RVA: 0x00040FAB File Offset: 0x0003F1AB
		' (set) Token: 0x060084C1 RID: 33985 RVA: 0x00040FB5 File Offset: 0x0003F1B5
		Friend Overridable Property pnlCalc As Panel

		' Token: 0x170030B9 RID: 12473
		' (get) Token: 0x060084C2 RID: 33986 RVA: 0x00040FBE File Offset: 0x0003F1BE
		' (set) Token: 0x060084C3 RID: 33987 RVA: 0x00639084 File Offset: 0x00637284
		Private _txtDisc As TextBox
		Friend Overridable Property txtDisc As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDisc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDisc_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtDisc_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDisc_KeyDown
				Dim textBox As TextBox = Me._txtDisc
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDisc = value
				textBox = Me._txtDisc
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030BA RID: 12474
		' (get) Token: 0x060084C4 RID: 33988 RVA: 0x00040FC8 File Offset: 0x0003F1C8
		' (set) Token: 0x060084C5 RID: 33989 RVA: 0x00639100 File Offset: 0x00637300
		Private _txtDiscPer As TextBox
		Friend Overridable Property txtDiscPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscPer_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscPer_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscPer_KeyDown
				Dim textBox As TextBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscPer = value
				textBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030BB RID: 12475
		' (get) Token: 0x060084C6 RID: 33990 RVA: 0x00040FD2 File Offset: 0x0003F1D2
		' (set) Token: 0x060084C7 RID: 33991 RVA: 0x00040FDC File Offset: 0x0003F1DC
		Friend Overridable Property Label32 As Label

		' Token: 0x170030BC RID: 12476
		' (get) Token: 0x060084C8 RID: 33992 RVA: 0x00040FE5 File Offset: 0x0003F1E5
		' (set) Token: 0x060084C9 RID: 33993 RVA: 0x00040FEF File Offset: 0x0003F1EF
		Friend Overridable Property txtTotal As TextBox

		' Token: 0x170030BD RID: 12477
		' (get) Token: 0x060084CA RID: 33994 RVA: 0x00040FF8 File Offset: 0x0003F1F8
		' (set) Token: 0x060084CB RID: 33995 RVA: 0x0063917C File Offset: 0x0063737C
		Private _txtPreviousDue As TextBox
		Friend Overridable Property txtPreviousDue As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPreviousDue
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtPreviousDue_TextChanged
				Dim textBox As TextBox = Me._txtPreviousDue
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtPreviousDue = value
				textBox = Me._txtPreviousDue
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030BE RID: 12478
		' (get) Token: 0x060084CC RID: 33996 RVA: 0x00041002 File Offset: 0x0003F202
		' (set) Token: 0x060084CD RID: 33997 RVA: 0x0004100C File Offset: 0x0003F20C
		Friend Overridable Property txtBalance As TextBox

		' Token: 0x170030BF RID: 12479
		' (get) Token: 0x060084CE RID: 33998 RVA: 0x00041015 File Offset: 0x0003F215
		' (set) Token: 0x060084CF RID: 33999 RVA: 0x0004101F File Offset: 0x0003F21F
		Friend Overridable Property Label16 As Label

		' Token: 0x170030C0 RID: 12480
		' (get) Token: 0x060084D0 RID: 34000 RVA: 0x00041028 File Offset: 0x0003F228
		' (set) Token: 0x060084D1 RID: 34001 RVA: 0x006391C0 File Offset: 0x006373C0
		Private _txtRoundOff As TextBox
		Friend Overridable Property txtRoundOff As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRoundOff
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtRoundOff_TextChanged
				Dim textBox As TextBox = Me._txtRoundOff
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtRoundOff = value
				textBox = Me._txtRoundOff
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C1 RID: 12481
		' (get) Token: 0x060084D2 RID: 34002 RVA: 0x00041032 File Offset: 0x0003F232
		' (set) Token: 0x060084D3 RID: 34003 RVA: 0x00639204 File Offset: 0x00637404
		Private _txtTotalPaid As TextBox
		Friend Overridable Property txtTotalPaid As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTotalPaid
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTotalPaid_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtTotalPaid_KeyDown
				Dim textBox As TextBox = Me._txtTotalPaid
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtTotalPaid = value
				textBox = Me._txtTotalPaid
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C2 RID: 12482
		' (get) Token: 0x060084D4 RID: 34004 RVA: 0x0004103C File Offset: 0x0003F23C
		' (set) Token: 0x060084D5 RID: 34005 RVA: 0x00041046 File Offset: 0x0003F246
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x170030C3 RID: 12483
		' (get) Token: 0x060084D6 RID: 34006 RVA: 0x0004104F File Offset: 0x0003F24F
		' (set) Token: 0x060084D7 RID: 34007 RVA: 0x00639264 File Offset: 0x00637464
		Private _txtOtherCharges As TextBox
		Friend Overridable Property txtOtherCharges As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtOtherCharges
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtOtherCharges_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtOtherCharges_KeyDown
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtOtherCharges_KeyPress
				Dim textBox As TextBox = Me._txtOtherCharges
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
				End If
				Me._txtOtherCharges = value
				textBox = Me._txtOtherCharges
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C4 RID: 12484
		' (get) Token: 0x060084D8 RID: 34008 RVA: 0x00041059 File Offset: 0x0003F259
		' (set) Token: 0x060084D9 RID: 34009 RVA: 0x006392E0 File Offset: 0x006374E0
		Private _txtFreightCharges As TextBox
		Friend Overridable Property txtFreightCharges As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtFreightCharges
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtFreightCharges_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtFreightCharges_KeyDown
				Dim textBox As TextBox = Me._txtFreightCharges
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtFreightCharges = value
				textBox = Me._txtFreightCharges
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C5 RID: 12485
		' (get) Token: 0x060084DA RID: 34010 RVA: 0x00041063 File Offset: 0x0003F263
		' (set) Token: 0x060084DB RID: 34011 RVA: 0x00639340 File Offset: 0x00637540
		Private _txtSubTotal As TextBox
		Friend Overridable Property txtSubTotal As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSubTotal
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSubTotal_TextChanged
				Dim textBox As TextBox = Me._txtSubTotal
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSubTotal = value
				textBox = Me._txtSubTotal
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C6 RID: 12486
		' (get) Token: 0x060084DC RID: 34012 RVA: 0x0004106D File Offset: 0x0003F26D
		' (set) Token: 0x060084DD RID: 34013 RVA: 0x00041077 File Offset: 0x0003F277
		Friend Overridable Property Label31 As Label

		' Token: 0x170030C7 RID: 12487
		' (get) Token: 0x060084DE RID: 34014 RVA: 0x00041080 File Offset: 0x0003F280
		' (set) Token: 0x060084DF RID: 34015 RVA: 0x00639384 File Offset: 0x00637584
		Private _cmbPurchaseType As ComboBox
		Friend Overridable Property cmbPurchaseType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPurchaseType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbPurchaseType_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbPurchaseType_KeyDown
				Dim comboBox As ComboBox = Me._cmbPurchaseType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbPurchaseType = value
				comboBox = Me._cmbPurchaseType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C8 RID: 12488
		' (get) Token: 0x060084E0 RID: 34016 RVA: 0x0004108A File Offset: 0x0003F28A
		' (set) Token: 0x060084E1 RID: 34017 RVA: 0x006393E4 File Offset: 0x006375E4
		Private _txtBarcode As TextBox
		Friend Overridable Property txtBarcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBarcode_KeyDown
				Dim textBox As TextBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBarcode = value
				textBox = Me._txtBarcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030C9 RID: 12489
		' (get) Token: 0x060084E2 RID: 34018 RVA: 0x00041094 File Offset: 0x0003F294
		' (set) Token: 0x060084E3 RID: 34019 RVA: 0x0004109E File Offset: 0x0003F29E
		Friend Overridable Property lblUnit As Label

		' Token: 0x170030CA RID: 12490
		' (get) Token: 0x060084E4 RID: 34020 RVA: 0x000410A7 File Offset: 0x0003F2A7
		' (set) Token: 0x060084E5 RID: 34021 RVA: 0x000410B1 File Offset: 0x0003F2B1
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170030CB RID: 12491
		' (get) Token: 0x060084E6 RID: 34022 RVA: 0x000410BA File Offset: 0x0003F2BA
		' (set) Token: 0x060084E7 RID: 34023 RVA: 0x00639428 File Offset: 0x00637628
		Private _dtpSupplierInvoiceDate As DateTimePicker
		Friend Overridable Property dtpSupplierInvoiceDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpSupplierInvoiceDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpSupplierInvoiceDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpSupplierInvoiceDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpSupplierInvoiceDate = value
				dateTimePicker = Me._dtpSupplierInvoiceDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030CC RID: 12492
		' (get) Token: 0x060084E8 RID: 34024 RVA: 0x000410C4 File Offset: 0x0003F2C4
		' (set) Token: 0x060084E9 RID: 34025 RVA: 0x000410CE File Offset: 0x0003F2CE
		Friend Overridable Property Label39 As Label

		' Token: 0x170030CD RID: 12493
		' (get) Token: 0x060084EA RID: 34026 RVA: 0x000410D7 File Offset: 0x0003F2D7
		' (set) Token: 0x060084EB RID: 34027 RVA: 0x0063946C File Offset: 0x0063766C
		Private _txtSupplierInvoiceNo As TextBox
		Friend Overridable Property txtSupplierInvoiceNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierInvoiceNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSupplierInvoiceNo_KeyDown
				Dim textBox As TextBox = Me._txtSupplierInvoiceNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSupplierInvoiceNo = value
				textBox = Me._txtSupplierInvoiceNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030CE RID: 12494
		' (get) Token: 0x060084EC RID: 34028 RVA: 0x000410E1 File Offset: 0x0003F2E1
		' (set) Token: 0x060084ED RID: 34029 RVA: 0x000410EB File Offset: 0x0003F2EB
		Friend Overridable Property Label38 As Label

		' Token: 0x170030CF RID: 12495
		' (get) Token: 0x060084EE RID: 34030 RVA: 0x000410F4 File Offset: 0x0003F2F4
		' (set) Token: 0x060084EF RID: 34031 RVA: 0x000410FE File Offset: 0x0003F2FE
		Friend Overridable Property Label37 As Label

		' Token: 0x170030D0 RID: 12496
		' (get) Token: 0x060084F0 RID: 34032 RVA: 0x00041107 File Offset: 0x0003F307
		' (set) Token: 0x060084F1 RID: 34033 RVA: 0x006394B0 File Offset: 0x006376B0
		Private _txtReferenceNo1 As TextBox
		Friend Overridable Property txtReferenceNo1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtReferenceNo1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtReferenceNo1_KeyDown
				Dim textBox As TextBox = Me._txtReferenceNo1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtReferenceNo1 = value
				textBox = Me._txtReferenceNo1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030D1 RID: 12497
		' (get) Token: 0x060084F2 RID: 34034 RVA: 0x00041111 File Offset: 0x0003F311
		' (set) Token: 0x060084F3 RID: 34035 RVA: 0x0004111B File Offset: 0x0003F31B
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x170030D2 RID: 12498
		' (get) Token: 0x060084F4 RID: 34036 RVA: 0x00041124 File Offset: 0x0003F324
		' (set) Token: 0x060084F5 RID: 34037 RVA: 0x0004112E File Offset: 0x0003F32E
		Friend Overridable Property Label13 As Label

		' Token: 0x170030D3 RID: 12499
		' (get) Token: 0x060084F6 RID: 34038 RVA: 0x00041137 File Offset: 0x0003F337
		' (set) Token: 0x060084F7 RID: 34039 RVA: 0x00041141 File Offset: 0x0003F341
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x170030D4 RID: 12500
		' (get) Token: 0x060084F8 RID: 34040 RVA: 0x0004114A File Offset: 0x0003F34A
		' (set) Token: 0x060084F9 RID: 34041 RVA: 0x006394F4 File Offset: 0x006376F4
		Private _txtCESSPer As TextBox
		Friend Overridable Property txtCESSPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCESSPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCESSPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtCESSPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCESSPer_KeyDown
				Dim textBox As TextBox = Me._txtCESSPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCESSPer = value
				textBox = Me._txtCESSPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030D5 RID: 12501
		' (get) Token: 0x060084FA RID: 34042 RVA: 0x00041154 File Offset: 0x0003F354
		' (set) Token: 0x060084FB RID: 34043 RVA: 0x0004115E File Offset: 0x0003F35E
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x170030D6 RID: 12502
		' (get) Token: 0x060084FC RID: 34044 RVA: 0x00041167 File Offset: 0x0003F367
		' (set) Token: 0x060084FD RID: 34045 RVA: 0x00639570 File Offset: 0x00637770
		Private _txtIGSTPer As TextBox
		Friend Overridable Property txtIGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtIGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtIGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtIGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIGSTPer = value
				textBox = Me._txtIGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030D7 RID: 12503
		' (get) Token: 0x060084FE RID: 34046 RVA: 0x00041171 File Offset: 0x0003F371
		' (set) Token: 0x060084FF RID: 34047 RVA: 0x0004117B File Offset: 0x0003F37B
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x170030D8 RID: 12504
		' (get) Token: 0x06008500 RID: 34048 RVA: 0x00041184 File Offset: 0x0003F384
		' (set) Token: 0x06008501 RID: 34049 RVA: 0x006395EC File Offset: 0x006377EC
		Private _txtSGSTPer As TextBox
		Friend Overridable Property txtSGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtSGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtSGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtSGSTPer = value
				textBox = Me._txtSGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030D9 RID: 12505
		' (get) Token: 0x06008502 RID: 34050 RVA: 0x0004118E File Offset: 0x0003F38E
		' (set) Token: 0x06008503 RID: 34051 RVA: 0x00041198 File Offset: 0x0003F398
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x170030DA RID: 12506
		' (get) Token: 0x06008504 RID: 34052 RVA: 0x000411A1 File Offset: 0x0003F3A1
		' (set) Token: 0x06008505 RID: 34053 RVA: 0x00639668 File Offset: 0x00637868
		Private _txtCGSTPer As TextBox
		Friend Overridable Property txtCGSTPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCGSTPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtCGSTPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtCGSTPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCGSTPer_KeyDown
				Dim textBox As TextBox = Me._txtCGSTPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCGSTPer = value
				textBox = Me._txtCGSTPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030DB RID: 12507
		' (get) Token: 0x06008506 RID: 34054 RVA: 0x000411AB File Offset: 0x0003F3AB
		' (set) Token: 0x06008507 RID: 34055 RVA: 0x006396E4 File Offset: 0x006378E4
		Private _txtMRP As TextBox
		Friend Overridable Property txtMRP As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMRP
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtMRP_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtMRP_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtMRP_Leave
				Dim textBox As TextBox = Me._txtMRP
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler
				End If
				Me._txtMRP = value
				textBox = Me._txtMRP
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030DC RID: 12508
		' (get) Token: 0x06008508 RID: 34056 RVA: 0x000411B5 File Offset: 0x0003F3B5
		' (set) Token: 0x06008509 RID: 34057 RVA: 0x00639760 File Offset: 0x00637960
		Private _cmbDiscountType As ComboBox
		Friend Overridable Property cmbDiscountType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDiscountType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbDiscountType_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbDiscountType_KeyDown
				Dim comboBox As ComboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbDiscountType = value
				comboBox = Me._cmbDiscountType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030DD RID: 12509
		' (get) Token: 0x0600850A RID: 34058 RVA: 0x000411BF File Offset: 0x0003F3BF
		' (set) Token: 0x0600850B RID: 34059 RVA: 0x006397C0 File Offset: 0x006379C0
		Private _cmbProductName As ComboBox
		Friend Overridable Property cmbProductName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbProductName_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbProductName = value
				comboBox = Me._cmbProductName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030DE RID: 12510
		' (get) Token: 0x0600850C RID: 34060 RVA: 0x000411C9 File Offset: 0x0003F3C9
		' (set) Token: 0x0600850D RID: 34061 RVA: 0x00639804 File Offset: 0x00637A04
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

		' Token: 0x170030DF RID: 12511
		' (get) Token: 0x0600850E RID: 34062 RVA: 0x000411D3 File Offset: 0x0003F3D3
		' (set) Token: 0x0600850F RID: 34063 RVA: 0x000411DD File Offset: 0x0003F3DD
		Friend Overridable Property txtCompanyState As TextBox

		' Token: 0x170030E0 RID: 12512
		' (get) Token: 0x06008510 RID: 34064 RVA: 0x000411E6 File Offset: 0x0003F3E6
		' (set) Token: 0x06008511 RID: 34065 RVA: 0x000411F0 File Offset: 0x0003F3F0
		Friend Overridable Property txtTempQty As TextBox

		' Token: 0x170030E1 RID: 12513
		' (get) Token: 0x06008512 RID: 34066 RVA: 0x000411F9 File Offset: 0x0003F3F9
		' (set) Token: 0x06008513 RID: 34067 RVA: 0x00639848 File Offset: 0x00637A48
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
				Dim eventHandler2 As EventHandler = AddressOf Me.Button2_MouseHover
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170030E2 RID: 12514
		' (get) Token: 0x06008514 RID: 34068 RVA: 0x00041203 File Offset: 0x0003F403
		' (set) Token: 0x06008515 RID: 34069 RVA: 0x006398A8 File Offset: 0x00637AA8
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

		' Token: 0x170030E3 RID: 12515
		' (get) Token: 0x06008516 RID: 34070 RVA: 0x0004120D File Offset: 0x0003F40D
		' (set) Token: 0x06008517 RID: 34071 RVA: 0x00041217 File Offset: 0x0003F417
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x170030E4 RID: 12516
		' (get) Token: 0x06008518 RID: 34072 RVA: 0x00041220 File Offset: 0x0003F420
		' (set) Token: 0x06008519 RID: 34073 RVA: 0x0004122A File Offset: 0x0003F42A
		Friend Overridable Property txtGSTIN As TextBox

		' Token: 0x170030E5 RID: 12517
		' (get) Token: 0x0600851A RID: 34074 RVA: 0x00041233 File Offset: 0x0003F433
		' (set) Token: 0x0600851B RID: 34075 RVA: 0x0004123D File Offset: 0x0003F43D
		Friend Overridable Property Label47 As Label

		' Token: 0x170030E6 RID: 12518
		' (get) Token: 0x0600851C RID: 34076 RVA: 0x00041246 File Offset: 0x0003F446
		' (set) Token: 0x0600851D RID: 34077 RVA: 0x006398EC File Offset: 0x00637AEC
		Private _cmbReverse As ComboBox
		Friend Overridable Property cmbReverse As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbReverse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbReverse_SelectedIndexChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbReverse_KeyDown
				Dim comboBox As ComboBox = Me._cmbReverse
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbReverse = value
				comboBox = Me._cmbReverse
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030E7 RID: 12519
		' (get) Token: 0x0600851E RID: 34078 RVA: 0x00041250 File Offset: 0x0003F450
		' (set) Token: 0x0600851F RID: 34079 RVA: 0x0004125A File Offset: 0x0003F45A
		Friend Overridable Property lbltaxtype As Label

		' Token: 0x170030E8 RID: 12520
		' (get) Token: 0x06008520 RID: 34080 RVA: 0x00041263 File Offset: 0x0003F463
		' (set) Token: 0x06008521 RID: 34081 RVA: 0x0063994C File Offset: 0x00637B4C
		Private _txtSuplNameId As TextBox
		Friend Overridable Property txtSuplNameId As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSuplNameId
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSuplNameId_TextChanged
				Dim textBox As TextBox = Me._txtSuplNameId
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSuplNameId = value
				textBox = Me._txtSuplNameId
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030E9 RID: 12521
		' (get) Token: 0x06008522 RID: 34082 RVA: 0x0004126D File Offset: 0x0003F46D
		' (set) Token: 0x06008523 RID: 34083 RVA: 0x00041277 File Offset: 0x0003F477
		Friend Overridable Property Label50 As Label

		' Token: 0x170030EA RID: 12522
		' (get) Token: 0x06008524 RID: 34084 RVA: 0x00041280 File Offset: 0x0003F480
		' (set) Token: 0x06008525 RID: 34085 RVA: 0x00639990 File Offset: 0x00637B90
		Private _txtDiscAmtPerQty As TextBox
		Friend Overridable Property txtDiscAmtPerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscAmtPerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscAmtPerQty_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyDown
				Dim textBox As TextBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscAmtPerQty = value
				textBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030EB RID: 12523
		' (get) Token: 0x06008526 RID: 34086 RVA: 0x0004128A File Offset: 0x0003F48A
		' (set) Token: 0x06008527 RID: 34087 RVA: 0x00639A0C File Offset: 0x00637C0C
		Private _CheckBox4 As CheckBox
		Friend Overridable Property CheckBox4 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox4_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox4
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox4 = value
				checkBox = Me._CheckBox4
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030EC RID: 12524
		' (get) Token: 0x06008528 RID: 34088 RVA: 0x00041294 File Offset: 0x0003F494
		' (set) Token: 0x06008529 RID: 34089 RVA: 0x00639A50 File Offset: 0x00637C50
		Private _cmbBSundry As ComboBox
		Friend Overridable Property cmbBSundry As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbBSundry
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbBSundry_KeyDown
				Dim comboBox As ComboBox = Me._cmbBSundry
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbBSundry = value
				comboBox = Me._cmbBSundry
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030ED RID: 12525
		' (get) Token: 0x0600852A RID: 34090 RVA: 0x0004129E File Offset: 0x0003F49E
		' (set) Token: 0x0600852B RID: 34091 RVA: 0x00639A94 File Offset: 0x00637C94
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

		' Token: 0x170030EE RID: 12526
		' (get) Token: 0x0600852C RID: 34092 RVA: 0x000412A8 File Offset: 0x0003F4A8
		' (set) Token: 0x0600852D RID: 34093 RVA: 0x000412B2 File Offset: 0x0003F4B2
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x170030EF RID: 12527
		' (get) Token: 0x0600852E RID: 34094 RVA: 0x000412BB File Offset: 0x0003F4BB
		' (set) Token: 0x0600852F RID: 34095 RVA: 0x000412C5 File Offset: 0x0003F4C5
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170030F0 RID: 12528
		' (get) Token: 0x06008530 RID: 34096 RVA: 0x000412CE File Offset: 0x0003F4CE
		' (set) Token: 0x06008531 RID: 34097 RVA: 0x000412D8 File Offset: 0x0003F4D8
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x170030F1 RID: 12529
		' (get) Token: 0x06008532 RID: 34098 RVA: 0x000412E1 File Offset: 0x0003F4E1
		' (set) Token: 0x06008533 RID: 34099 RVA: 0x00639AD8 File Offset: 0x00637CD8
		Private _cmbUnit As ComboBox
		Friend Overridable Property cmbUnit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbUnit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbUnit_SelectedIndexChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbUnit_Validated
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbUnit_KeyDown
				Dim comboBox As ComboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validated, eventHandler2
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbUnit = value
				comboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validated, eventHandler2
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030F2 RID: 12530
		' (get) Token: 0x06008534 RID: 34100 RVA: 0x000412EB File Offset: 0x0003F4EB
		' (set) Token: 0x06008535 RID: 34101 RVA: 0x00639B54 File Offset: 0x00637D54
		Private _cmbaltunit As ComboBox
		Friend Overridable Property cmbaltunit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbaltunit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbaltunit_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbaltunit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbaltunit = value
				comboBox = Me._cmbaltunit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170030F3 RID: 12531
		' (get) Token: 0x06008536 RID: 34102 RVA: 0x000412F5 File Offset: 0x0003F4F5
		' (set) Token: 0x06008537 RID: 34103 RVA: 0x00639B98 File Offset: 0x00637D98
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

		' Token: 0x170030F4 RID: 12532
		' (get) Token: 0x06008538 RID: 34104 RVA: 0x000412FF File Offset: 0x0003F4FF
		' (set) Token: 0x06008539 RID: 34105 RVA: 0x00639BDC File Offset: 0x00637DDC
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

		' Token: 0x170030F5 RID: 12533
		' (get) Token: 0x0600853A RID: 34106 RVA: 0x00041309 File Offset: 0x0003F509
		' (set) Token: 0x0600853B RID: 34107 RVA: 0x00041313 File Offset: 0x0003F513
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x170030F6 RID: 12534
		' (get) Token: 0x0600853C RID: 34108 RVA: 0x0004131C File Offset: 0x0003F51C
		' (set) Token: 0x0600853D RID: 34109 RVA: 0x00041326 File Offset: 0x0003F526
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x170030F7 RID: 12535
		' (get) Token: 0x0600853E RID: 34110 RVA: 0x0004132F File Offset: 0x0003F52F
		' (set) Token: 0x0600853F RID: 34111 RVA: 0x00041339 File Offset: 0x0003F539
		Friend Overridable Property txtSuplLimitstatus As TextBox

		' Token: 0x170030F8 RID: 12536
		' (get) Token: 0x06008540 RID: 34112 RVA: 0x00041342 File Offset: 0x0003F542
		' (set) Token: 0x06008541 RID: 34113 RVA: 0x0004134C File Offset: 0x0003F54C
		Friend Overridable Property txtSuplLimit As TextBox

		' Token: 0x170030F9 RID: 12537
		' (get) Token: 0x06008542 RID: 34114 RVA: 0x00041355 File Offset: 0x0003F555
		' (set) Token: 0x06008543 RID: 34115 RVA: 0x00639C20 File Offset: 0x00637E20
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw4_RowPostPaint
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw4_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170030FA RID: 12538
		' (get) Token: 0x06008544 RID: 34116 RVA: 0x0004135F File Offset: 0x0003F55F
		' (set) Token: 0x06008545 RID: 34117 RVA: 0x00639CE0 File Offset: 0x00637EE0
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.TextBox5_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.TextBox5_KeyDown
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler2
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler
					AddHandler textBox.KeyDown, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170030FB RID: 12539
		' (get) Token: 0x06008546 RID: 34118 RVA: 0x00041369 File Offset: 0x0003F569
		' (set) Token: 0x06008547 RID: 34119 RVA: 0x00639D5C File Offset: 0x00637F5C
		Private _Button19 As Button
		Friend Overridable Property Button19 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button19
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button19_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button19_MouseHover
				Dim button As Button = Me._Button19
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button19 = value
				button = Me._Button19
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170030FC RID: 12540
		' (get) Token: 0x06008548 RID: 34120 RVA: 0x00041373 File Offset: 0x0003F573
		' (set) Token: 0x06008549 RID: 34121 RVA: 0x00639DBC File Offset: 0x00637FBC
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

		' Token: 0x170030FD RID: 12541
		' (get) Token: 0x0600854A RID: 34122 RVA: 0x0004137D File Offset: 0x0003F57D
		' (set) Token: 0x0600854B RID: 34123 RVA: 0x00041387 File Offset: 0x0003F587
		Friend Overridable Property txtNP As TextBox

		' Token: 0x170030FE RID: 12542
		' (get) Token: 0x0600854C RID: 34124 RVA: 0x00041390 File Offset: 0x0003F590
		' (set) Token: 0x0600854D RID: 34125 RVA: 0x00639E00 File Offset: 0x00638000
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

		' Token: 0x170030FF RID: 12543
		' (get) Token: 0x0600854E RID: 34126 RVA: 0x0004139A File Offset: 0x0003F59A
		' (set) Token: 0x0600854F RID: 34127 RVA: 0x00639E44 File Offset: 0x00638044
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

		' Token: 0x17003100 RID: 12544
		' (get) Token: 0x06008550 RID: 34128 RVA: 0x000413A4 File Offset: 0x0003F5A4
		' (set) Token: 0x06008551 RID: 34129 RVA: 0x00639E88 File Offset: 0x00638088
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

		' Token: 0x17003101 RID: 12545
		' (get) Token: 0x06008552 RID: 34130 RVA: 0x000413AE File Offset: 0x0003F5AE
		' (set) Token: 0x06008553 RID: 34131 RVA: 0x00639ECC File Offset: 0x006380CC
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

		' Token: 0x17003102 RID: 12546
		' (get) Token: 0x06008554 RID: 34132 RVA: 0x000413B8 File Offset: 0x0003F5B8
		' (set) Token: 0x06008555 RID: 34133 RVA: 0x00639F10 File Offset: 0x00638110
		Private _cmbSupplierName As ComboBox
		Friend Overridable Property cmbSupplierName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSupplierName_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbSupplierName_SelectedIndexChanged
				Dim eventHandler3 As EventHandler = AddressOf Me.cmbSupplierName_Validated
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSupplierName_KeyDown
				Dim comboBox As ComboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.TextChanged, eventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler2
					RemoveHandler comboBox.Validated, eventHandler3
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbSupplierName = value
				comboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.TextChanged, eventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler2
					AddHandler comboBox.Validated, eventHandler3
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003103 RID: 12547
		' (get) Token: 0x06008556 RID: 34134 RVA: 0x000413C2 File Offset: 0x0003F5C2
		' (set) Token: 0x06008557 RID: 34135 RVA: 0x000413CC File Offset: 0x0003F5CC
		Friend Overridable Property Label59 As Label

		' Token: 0x17003104 RID: 12548
		' (get) Token: 0x06008558 RID: 34136 RVA: 0x000413D5 File Offset: 0x0003F5D5
		' (set) Token: 0x06008559 RID: 34137 RVA: 0x00639FB0 File Offset: 0x006381B0
		Private _Picture As PictureBox
		Public Overridable Property Picture As PictureBox
			<CompilerGenerated()>
			Get
				Return Me._Picture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Dim eventHandler As EventHandler = AddressOf Me.Picture_DoubleClick
				Dim pictureBox As PictureBox = Me._Picture
				If pictureBox IsNot Nothing Then
					RemoveHandler pictureBox.DoubleClick, eventHandler
				End If
				Me._Picture = value
				pictureBox = Me._Picture
				If pictureBox IsNot Nothing Then
					AddHandler pictureBox.DoubleClick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003105 RID: 12549
		' (get) Token: 0x0600855A RID: 34138 RVA: 0x000413DF File Offset: 0x0003F5DF
		' (set) Token: 0x0600855B RID: 34139 RVA: 0x00639FF4 File Offset: 0x006381F4
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

		' Token: 0x17003106 RID: 12550
		' (get) Token: 0x0600855C RID: 34140 RVA: 0x000413E9 File Offset: 0x0003F5E9
		' (set) Token: 0x0600855D RID: 34141 RVA: 0x000413F3 File Offset: 0x0003F5F3
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17003107 RID: 12551
		' (get) Token: 0x0600855E RID: 34142 RVA: 0x000413FC File Offset: 0x0003F5FC
		' (set) Token: 0x0600855F RID: 34143 RVA: 0x00041406 File Offset: 0x0003F606
		Friend Overridable Property Label60 As Label

		' Token: 0x17003108 RID: 12552
		' (get) Token: 0x06008560 RID: 34144 RVA: 0x0004140F File Offset: 0x0003F60F
		' (set) Token: 0x06008561 RID: 34145 RVA: 0x0063A038 File Offset: 0x00638238
		Private _Button22 As Button
		Friend Overridable Property Button22 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button22
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button22_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button22_MouseHover
				Dim button As Button = Me._Button22
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button22 = value
				button = Me._Button22
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x17003109 RID: 12553
		' (get) Token: 0x06008562 RID: 34146 RVA: 0x00041419 File Offset: 0x0003F619
		' (set) Token: 0x06008563 RID: 34147 RVA: 0x00041423 File Offset: 0x0003F623
		Friend Overridable Property txtScode As TextBox

		' Token: 0x1700310A RID: 12554
		' (get) Token: 0x06008564 RID: 34148 RVA: 0x0004142C File Offset: 0x0003F62C
		' (set) Token: 0x06008565 RID: 34149 RVA: 0x0063A098 File Offset: 0x00638298
		Private _Button34 As Button
		Friend Overridable Property Button34 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button34
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button34_Click
				Dim button As Button = Me._Button34
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button34 = value
				button = Me._Button34
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700310B RID: 12555
		' (get) Token: 0x06008566 RID: 34150 RVA: 0x00041436 File Offset: 0x0003F636
		' (set) Token: 0x06008567 RID: 34151 RVA: 0x00041440 File Offset: 0x0003F640
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x1700310C RID: 12556
		' (get) Token: 0x06008568 RID: 34152 RVA: 0x00041449 File Offset: 0x0003F649
		' (set) Token: 0x06008569 RID: 34153 RVA: 0x0063A0DC File Offset: 0x006382DC
		Private _Button35 As Button
		Friend Overridable Property Button35 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button35
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button35_Click
				Dim button As Button = Me._Button35
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button35 = value
				button = Me._Button35
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700310D RID: 12557
		' (get) Token: 0x0600856A RID: 34154 RVA: 0x00041453 File Offset: 0x0003F653
		' (set) Token: 0x0600856B RID: 34155 RVA: 0x0004145D File Offset: 0x0003F65D
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x1700310E RID: 12558
		' (get) Token: 0x0600856C RID: 34156 RVA: 0x00041466 File Offset: 0x0003F666
		' (set) Token: 0x0600856D RID: 34157 RVA: 0x0063A120 File Offset: 0x00638320
		Private _Button33 As Button
		Friend Overridable Property Button33 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button33
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button33_Click
				Dim eventHandler2 As EventHandler = AddressOf Me.Button33_MouseHover
				Dim button As Button = Me._Button33
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
					RemoveHandler button.MouseHover, eventHandler2
				End If
				Me._Button33 = value
				button = Me._Button33
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
					AddHandler button.MouseHover, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700310F RID: 12559
		' (get) Token: 0x0600856E RID: 34158 RVA: 0x00041470 File Offset: 0x0003F670
		' (set) Token: 0x0600856F RID: 34159 RVA: 0x0004147A File Offset: 0x0003F67A
		Friend Overridable Property F2 As TextBox

		' Token: 0x17003110 RID: 12560
		' (get) Token: 0x06008570 RID: 34160 RVA: 0x00041483 File Offset: 0x0003F683
		' (set) Token: 0x06008571 RID: 34161 RVA: 0x0004148D File Offset: 0x0003F68D
		Friend Overridable Property F1 As TextBox

		' Token: 0x17003111 RID: 12561
		' (get) Token: 0x06008572 RID: 34162 RVA: 0x00041496 File Offset: 0x0003F696
		' (set) Token: 0x06008573 RID: 34163 RVA: 0x0063A180 File Offset: 0x00638380
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

		' Token: 0x17003112 RID: 12562
		' (get) Token: 0x06008574 RID: 34164 RVA: 0x000414A0 File Offset: 0x0003F6A0
		' (set) Token: 0x06008575 RID: 34165 RVA: 0x0063A1C4 File Offset: 0x006383C4
		Private _CheckBox2 As CheckBox
		Friend Overridable Property CheckBox2 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox2_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox2 = value
				checkBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003113 RID: 12563
		' (get) Token: 0x06008576 RID: 34166 RVA: 0x000414AA File Offset: 0x0003F6AA
		' (set) Token: 0x06008577 RID: 34167 RVA: 0x000414B4 File Offset: 0x0003F6B4
		Friend Overridable Property txtCurAmt As TextBox

		' Token: 0x17003114 RID: 12564
		' (get) Token: 0x06008578 RID: 34168 RVA: 0x000414BD File Offset: 0x0003F6BD
		' (set) Token: 0x06008579 RID: 34169 RVA: 0x000414C7 File Offset: 0x0003F6C7
		Friend Overridable Property Label61 As Label

		' Token: 0x17003115 RID: 12565
		' (get) Token: 0x0600857A RID: 34170 RVA: 0x000414D0 File Offset: 0x0003F6D0
		' (set) Token: 0x0600857B RID: 34171 RVA: 0x0063A208 File Offset: 0x00638408
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

		' Token: 0x17003116 RID: 12566
		' (get) Token: 0x0600857C RID: 34172 RVA: 0x000414DA File Offset: 0x0003F6DA
		' (set) Token: 0x0600857D RID: 34173 RVA: 0x000414E4 File Offset: 0x0003F6E4
		Friend Overridable Property txtTaxableAmtI As TextBox

		' Token: 0x17003117 RID: 12567
		' (get) Token: 0x0600857E RID: 34174 RVA: 0x000414ED File Offset: 0x0003F6ED
		' (set) Token: 0x0600857F RID: 34175 RVA: 0x000414F7 File Offset: 0x0003F6F7
		Friend Overridable Property txtGSTNonGST As TextBox

		' Token: 0x17003118 RID: 12568
		' (get) Token: 0x06008580 RID: 34176 RVA: 0x00041500 File Offset: 0x0003F700
		' (set) Token: 0x06008581 RID: 34177 RVA: 0x0063A24C File Offset: 0x0063844C
		Private _lblPTaxType As Label
		Friend Overridable Property lblPTaxType As Label
			<CompilerGenerated()>
			Get
				Return Me._lblPTaxType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim eventHandler As EventHandler = AddressOf Me.lblPTaxType_Click
				Dim label As Label = Me._lblPTaxType
				If label IsNot Nothing Then
					RemoveHandler label.Click, eventHandler
				End If
				Me._lblPTaxType = value
				label = Me._lblPTaxType
				If label IsNot Nothing Then
					AddHandler label.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003119 RID: 12569
		' (get) Token: 0x06008582 RID: 34178 RVA: 0x0004150A File Offset: 0x0003F70A
		' (set) Token: 0x06008583 RID: 34179 RVA: 0x0063A290 File Offset: 0x00638490
		Private _txtWholesale As TextBox
		Friend Overridable Property txtWholesale As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWholesale
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtWholesale_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtWholesale_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtWholesale_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtWholesale_Leave
				Dim textBox As TextBox = Me._txtWholesale
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtWholesale = value
				textBox = Me._txtWholesale
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700311A RID: 12570
		' (get) Token: 0x06008584 RID: 34180 RVA: 0x00041514 File Offset: 0x0003F714
		' (set) Token: 0x06008585 RID: 34181 RVA: 0x0063A330 File Offset: 0x00638530
		Private _txtRetail As TextBox
		Friend Overridable Property txtRetail As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRetail
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtRetail_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRetail_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtRetail_TextChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.txtRetail_Leave
				Dim textBox As TextBox = Me._txtRetail
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtRetail = value
				textBox = Me._txtRetail
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700311B RID: 12571
		' (get) Token: 0x06008586 RID: 34182 RVA: 0x0004151E File Offset: 0x0003F71E
		' (set) Token: 0x06008587 RID: 34183 RVA: 0x0063A3D0 File Offset: 0x006385D0
		Private _cmbSize As ComboBox
		Friend Overridable Property cmbSize As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSize
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSize_KeyDown
				Dim comboBox As ComboBox = Me._cmbSize
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbSize = value
				comboBox = Me._cmbSize
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700311C RID: 12572
		' (get) Token: 0x06008588 RID: 34184 RVA: 0x00041528 File Offset: 0x0003F728
		' (set) Token: 0x06008589 RID: 34185 RVA: 0x0063A414 File Offset: 0x00638614
		Private _cmbColor As ComboBox
		Friend Overridable Property cmbColor As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbColor
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbColor_KeyDown
				Dim comboBox As ComboBox = Me._cmbColor
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbColor = value
				comboBox = Me._cmbColor
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700311D RID: 12573
		' (get) Token: 0x0600858A RID: 34186 RVA: 0x00041532 File Offset: 0x0003F732
		' (set) Token: 0x0600858B RID: 34187 RVA: 0x0004153C File Offset: 0x0003F73C
		Friend Overridable Property Label67 As Label

		' Token: 0x1700311E RID: 12574
		' (get) Token: 0x0600858C RID: 34188 RVA: 0x00041545 File Offset: 0x0003F745
		' (set) Token: 0x0600858D RID: 34189 RVA: 0x0063A458 File Offset: 0x00638658
		Private _txtInfo As TextBox
		Friend Overridable Property txtInfo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtInfo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtInfo_KeyDown
				Dim textBox As TextBox = Me._txtInfo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtInfo = value
				textBox = Me._txtInfo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700311F RID: 12575
		' (get) Token: 0x0600858E RID: 34190 RVA: 0x0004154F File Offset: 0x0003F74F
		' (set) Token: 0x0600858F RID: 34191 RVA: 0x0063A49C File Offset: 0x0063869C
		Private _CheckBox3 As CheckBox
		Friend Overridable Property CheckBox3 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox3_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox3 = value
				checkBox = Me._CheckBox3
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003120 RID: 12576
		' (get) Token: 0x06008590 RID: 34192 RVA: 0x00041559 File Offset: 0x0003F759
		' (set) Token: 0x06008591 RID: 34193 RVA: 0x0063A4E0 File Offset: 0x006386E0
		Private _CheckBox5 As CheckBox
		Friend Overridable Property CheckBox5 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox5_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox5
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox5 = value
				checkBox = Me._CheckBox5
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003121 RID: 12577
		' (get) Token: 0x06008592 RID: 34194 RVA: 0x00041563 File Offset: 0x0003F763
		' (set) Token: 0x06008593 RID: 34195 RVA: 0x0004156D File Offset: 0x0003F76D
		Friend Overridable Property Label68 As Label

		' Token: 0x17003122 RID: 12578
		' (get) Token: 0x06008594 RID: 34196 RVA: 0x00041576 File Offset: 0x0003F776
		' (set) Token: 0x06008595 RID: 34197 RVA: 0x0063A524 File Offset: 0x00638724
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

		' Token: 0x17003123 RID: 12579
		' (get) Token: 0x06008596 RID: 34198 RVA: 0x00041580 File Offset: 0x0003F780
		' (set) Token: 0x06008597 RID: 34199 RVA: 0x0004158A File Offset: 0x0003F78A
		Friend Overridable Property txtExp As TextBox

		' Token: 0x17003124 RID: 12580
		' (get) Token: 0x06008598 RID: 34200 RVA: 0x00041593 File Offset: 0x0003F793
		' (set) Token: 0x06008599 RID: 34201 RVA: 0x0063A568 File Offset: 0x00638768
		Private _dtpExpiryDate As DateTimePicker
		Friend Overridable Property dtpExpiryDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpExpiryDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpExpiryDate_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.dtpExpiryDate_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._dtpExpiryDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._dtpExpiryDate = value
				dateTimePicker = Me._dtpExpiryDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003125 RID: 12581
		' (get) Token: 0x0600859A RID: 34202 RVA: 0x0004159D File Offset: 0x0003F79D
		' (set) Token: 0x0600859B RID: 34203 RVA: 0x000415A7 File Offset: 0x0003F7A7
		Friend Overridable Property txtMfg As TextBox

		' Token: 0x17003126 RID: 12582
		' (get) Token: 0x0600859C RID: 34204 RVA: 0x000415B0 File Offset: 0x0003F7B0
		' (set) Token: 0x0600859D RID: 34205 RVA: 0x0063A5C8 File Offset: 0x006387C8
		Private _dtpManufacturingDate As DateTimePicker
		Friend Overridable Property dtpManufacturingDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpManufacturingDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpManufacturingDate_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.dtpManufacturingDate_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._dtpManufacturingDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._dtpManufacturingDate = value
				dateTimePicker = Me._dtpManufacturingDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003127 RID: 12583
		' (get) Token: 0x0600859E RID: 34206 RVA: 0x000415BA File Offset: 0x0003F7BA
		' (set) Token: 0x0600859F RID: 34207 RVA: 0x0063A628 File Offset: 0x00638828
		Private _txtBatchNo As TextBox
		Friend Overridable Property txtBatchNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBatchNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBatchNo_KeyDown
				Dim textBox As TextBox = Me._txtBatchNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBatchNo = value
				textBox = Me._txtBatchNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003128 RID: 12584
		' (get) Token: 0x060085A0 RID: 34208 RVA: 0x000415C4 File Offset: 0x0003F7C4
		' (set) Token: 0x060085A1 RID: 34209 RVA: 0x0063A66C File Offset: 0x0063886C
		Private _NumericUpDown1 As NumericUpDown
		Friend Overridable Property NumericUpDown1 As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._NumericUpDown1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim eventHandler As EventHandler = AddressOf Me.NumericUpDown1_ValueChanged
				Dim numericUpDown As NumericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.ValueChanged, eventHandler
				End If
				Me._NumericUpDown1 = value
				numericUpDown = Me._NumericUpDown1
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003129 RID: 12585
		' (get) Token: 0x060085A2 RID: 34210 RVA: 0x000415CE File Offset: 0x0003F7CE
		' (set) Token: 0x060085A3 RID: 34211 RVA: 0x000415D8 File Offset: 0x0003F7D8
		Friend Overridable Property TextBox7 As TextBox

		' Token: 0x1700312A RID: 12586
		' (get) Token: 0x060085A4 RID: 34212 RVA: 0x000415E1 File Offset: 0x0003F7E1
		' (set) Token: 0x060085A5 RID: 34213 RVA: 0x000415EB File Offset: 0x0003F7EB
		Friend Overridable Property TextBox8 As TextBox

		' Token: 0x1700312B RID: 12587
		' (get) Token: 0x060085A6 RID: 34214 RVA: 0x000415F4 File Offset: 0x0003F7F4
		' (set) Token: 0x060085A7 RID: 34215 RVA: 0x0063A6B0 File Offset: 0x006388B0
		Private _CheckBox6 As CheckBox
		Friend Overridable Property CheckBox6 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox6_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox6
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox6 = value
				checkBox = Me._CheckBox6
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700312C RID: 12588
		' (get) Token: 0x060085A8 RID: 34216 RVA: 0x000415FE File Offset: 0x0003F7FE
		' (set) Token: 0x060085A9 RID: 34217 RVA: 0x0063A6F4 File Offset: 0x006388F4
		Private _CheckBox7 As CheckBox
		Friend Overridable Property CheckBox7 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox7_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox7 = value
				checkBox = Me._CheckBox7
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700312D RID: 12589
		' (get) Token: 0x060085AA RID: 34218 RVA: 0x00041608 File Offset: 0x0003F808
		' (set) Token: 0x060085AB RID: 34219 RVA: 0x0063A738 File Offset: 0x00638938
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

		' Token: 0x1700312E RID: 12590
		' (get) Token: 0x060085AC RID: 34220 RVA: 0x00041612 File Offset: 0x0003F812
		' (set) Token: 0x060085AD RID: 34221 RVA: 0x0063A77C File Offset: 0x0063897C
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

		' Token: 0x1700312F RID: 12591
		' (get) Token: 0x060085AE RID: 34222 RVA: 0x0004161C File Offset: 0x0003F81C
		' (set) Token: 0x060085AF RID: 34223 RVA: 0x00041626 File Offset: 0x0003F826
		Friend Overridable Property lblProductCat As Label

		' Token: 0x17003130 RID: 12592
		' (get) Token: 0x060085B0 RID: 34224 RVA: 0x0004162F File Offset: 0x0003F82F
		' (set) Token: 0x060085B1 RID: 34225 RVA: 0x00041639 File Offset: 0x0003F839
		Friend Overridable Property lblLastItemPurPrice As Label

		' Token: 0x17003131 RID: 12593
		' (get) Token: 0x060085B2 RID: 34226 RVA: 0x00041642 File Offset: 0x0003F842
		' (set) Token: 0x060085B3 RID: 34227 RVA: 0x0004164C File Offset: 0x0003F84C
		Friend Overridable Property lblSuplLastPur As Label

		' Token: 0x17003132 RID: 12594
		' (get) Token: 0x060085B4 RID: 34228 RVA: 0x00041655 File Offset: 0x0003F855
		' (set) Token: 0x060085B5 RID: 34229 RVA: 0x0004165F File Offset: 0x0003F85F
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17003133 RID: 12595
		' (get) Token: 0x060085B6 RID: 34230 RVA: 0x00041668 File Offset: 0x0003F868
		' (set) Token: 0x060085B7 RID: 34231 RVA: 0x00041672 File Offset: 0x0003F872
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x17003134 RID: 12596
		' (get) Token: 0x060085B8 RID: 34232 RVA: 0x0004167B File Offset: 0x0003F87B
		' (set) Token: 0x060085B9 RID: 34233 RVA: 0x00041685 File Offset: 0x0003F885
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17003135 RID: 12597
		' (get) Token: 0x060085BA RID: 34234 RVA: 0x0004168E File Offset: 0x0003F88E
		' (set) Token: 0x060085BB RID: 34235 RVA: 0x00041698 File Offset: 0x0003F898
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17003136 RID: 12598
		' (get) Token: 0x060085BC RID: 34236 RVA: 0x000416A1 File Offset: 0x0003F8A1
		' (set) Token: 0x060085BD RID: 34237 RVA: 0x000416AB File Offset: 0x0003F8AB
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x17003137 RID: 12599
		' (get) Token: 0x060085BE RID: 34238 RVA: 0x000416B4 File Offset: 0x0003F8B4
		' (set) Token: 0x060085BF RID: 34239 RVA: 0x000416BE File Offset: 0x0003F8BE
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x17003138 RID: 12600
		' (get) Token: 0x060085C0 RID: 34240 RVA: 0x000416C7 File Offset: 0x0003F8C7
		' (set) Token: 0x060085C1 RID: 34241 RVA: 0x000416D1 File Offset: 0x0003F8D1
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x17003139 RID: 12601
		' (get) Token: 0x060085C2 RID: 34242 RVA: 0x000416DA File Offset: 0x0003F8DA
		' (set) Token: 0x060085C3 RID: 34243 RVA: 0x000416E4 File Offset: 0x0003F8E4
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x1700313A RID: 12602
		' (get) Token: 0x060085C4 RID: 34244 RVA: 0x000416ED File Offset: 0x0003F8ED
		' (set) Token: 0x060085C5 RID: 34245 RVA: 0x000416F7 File Offset: 0x0003F8F7
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x1700313B RID: 12603
		' (get) Token: 0x060085C6 RID: 34246 RVA: 0x00041700 File Offset: 0x0003F900
		' (set) Token: 0x060085C7 RID: 34247 RVA: 0x0004170A File Offset: 0x0003F90A
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x1700313C RID: 12604
		' (get) Token: 0x060085C8 RID: 34248 RVA: 0x00041713 File Offset: 0x0003F913
		' (set) Token: 0x060085C9 RID: 34249 RVA: 0x0004171D File Offset: 0x0003F91D
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x1700313D RID: 12605
		' (get) Token: 0x060085CA RID: 34250 RVA: 0x00041726 File Offset: 0x0003F926
		' (set) Token: 0x060085CB RID: 34251 RVA: 0x00041730 File Offset: 0x0003F930
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x1700313E RID: 12606
		' (get) Token: 0x060085CC RID: 34252 RVA: 0x00041739 File Offset: 0x0003F939
		' (set) Token: 0x060085CD RID: 34253 RVA: 0x00041743 File Offset: 0x0003F943
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x1700313F RID: 12607
		' (get) Token: 0x060085CE RID: 34254 RVA: 0x0004174C File Offset: 0x0003F94C
		' (set) Token: 0x060085CF RID: 34255 RVA: 0x00041756 File Offset: 0x0003F956
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x17003140 RID: 12608
		' (get) Token: 0x060085D0 RID: 34256 RVA: 0x0004175F File Offset: 0x0003F95F
		' (set) Token: 0x060085D1 RID: 34257 RVA: 0x00041769 File Offset: 0x0003F969
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x17003141 RID: 12609
		' (get) Token: 0x060085D2 RID: 34258 RVA: 0x00041772 File Offset: 0x0003F972
		' (set) Token: 0x060085D3 RID: 34259 RVA: 0x0004177C File Offset: 0x0003F97C
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x17003142 RID: 12610
		' (get) Token: 0x060085D4 RID: 34260 RVA: 0x00041785 File Offset: 0x0003F985
		' (set) Token: 0x060085D5 RID: 34261 RVA: 0x0004178F File Offset: 0x0003F98F
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x17003143 RID: 12611
		' (get) Token: 0x060085D6 RID: 34262 RVA: 0x00041798 File Offset: 0x0003F998
		' (set) Token: 0x060085D7 RID: 34263 RVA: 0x000417A2 File Offset: 0x0003F9A2
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x17003144 RID: 12612
		' (get) Token: 0x060085D8 RID: 34264 RVA: 0x000417AB File Offset: 0x0003F9AB
		' (set) Token: 0x060085D9 RID: 34265 RVA: 0x000417B5 File Offset: 0x0003F9B5
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x17003145 RID: 12613
		' (get) Token: 0x060085DA RID: 34266 RVA: 0x000417BE File Offset: 0x0003F9BE
		' (set) Token: 0x060085DB RID: 34267 RVA: 0x000417C8 File Offset: 0x0003F9C8
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x17003146 RID: 12614
		' (get) Token: 0x060085DC RID: 34268 RVA: 0x000417D1 File Offset: 0x0003F9D1
		' (set) Token: 0x060085DD RID: 34269 RVA: 0x000417DB File Offset: 0x0003F9DB
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x17003147 RID: 12615
		' (get) Token: 0x060085DE RID: 34270 RVA: 0x000417E4 File Offset: 0x0003F9E4
		' (set) Token: 0x060085DF RID: 34271 RVA: 0x000417EE File Offset: 0x0003F9EE
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x17003148 RID: 12616
		' (get) Token: 0x060085E0 RID: 34272 RVA: 0x000417F7 File Offset: 0x0003F9F7
		' (set) Token: 0x060085E1 RID: 34273 RVA: 0x00041801 File Offset: 0x0003FA01
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x17003149 RID: 12617
		' (get) Token: 0x060085E2 RID: 34274 RVA: 0x0004180A File Offset: 0x0003FA0A
		' (set) Token: 0x060085E3 RID: 34275 RVA: 0x00041814 File Offset: 0x0003FA14
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x1700314A RID: 12618
		' (get) Token: 0x060085E4 RID: 34276 RVA: 0x0004181D File Offset: 0x0003FA1D
		' (set) Token: 0x060085E5 RID: 34277 RVA: 0x00041827 File Offset: 0x0003FA27
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x1700314B RID: 12619
		' (get) Token: 0x060085E6 RID: 34278 RVA: 0x00041830 File Offset: 0x0003FA30
		' (set) Token: 0x060085E7 RID: 34279 RVA: 0x0004183A File Offset: 0x0003FA3A
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x1700314C RID: 12620
		' (get) Token: 0x060085E8 RID: 34280 RVA: 0x00041843 File Offset: 0x0003FA43
		' (set) Token: 0x060085E9 RID: 34281 RVA: 0x0004184D File Offset: 0x0003FA4D
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x1700314D RID: 12621
		' (get) Token: 0x060085EA RID: 34282 RVA: 0x00041856 File Offset: 0x0003FA56
		' (set) Token: 0x060085EB RID: 34283 RVA: 0x00041860 File Offset: 0x0003FA60
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x1700314E RID: 12622
		' (get) Token: 0x060085EC RID: 34284 RVA: 0x00041869 File Offset: 0x0003FA69
		' (set) Token: 0x060085ED RID: 34285 RVA: 0x00041873 File Offset: 0x0003FA73
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x1700314F RID: 12623
		' (get) Token: 0x060085EE RID: 34286 RVA: 0x0004187C File Offset: 0x0003FA7C
		' (set) Token: 0x060085EF RID: 34287 RVA: 0x00041886 File Offset: 0x0003FA86
		Friend Overridable Property DataGridViewTextBoxColumn46 As DataGridViewTextBoxColumn

		' Token: 0x17003150 RID: 12624
		' (get) Token: 0x060085F0 RID: 34288 RVA: 0x0004188F File Offset: 0x0003FA8F
		' (set) Token: 0x060085F1 RID: 34289 RVA: 0x00041899 File Offset: 0x0003FA99
		Friend Overridable Property DataGridViewTextBoxColumn47 As DataGridViewTextBoxColumn

		' Token: 0x17003151 RID: 12625
		' (get) Token: 0x060085F2 RID: 34290 RVA: 0x000418A2 File Offset: 0x0003FAA2
		' (set) Token: 0x060085F3 RID: 34291 RVA: 0x000418AC File Offset: 0x0003FAAC
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17003152 RID: 12626
		' (get) Token: 0x060085F4 RID: 34292 RVA: 0x000418B5 File Offset: 0x0003FAB5
		' (set) Token: 0x060085F5 RID: 34293 RVA: 0x000418BF File Offset: 0x0003FABF
		Friend Overridable Property DataGridViewTextBoxColumn49 As DataGridViewTextBoxColumn

		' Token: 0x17003153 RID: 12627
		' (get) Token: 0x060085F6 RID: 34294 RVA: 0x000418C8 File Offset: 0x0003FAC8
		' (set) Token: 0x060085F7 RID: 34295 RVA: 0x000418D2 File Offset: 0x0003FAD2
		Friend Overridable Property DataGridViewTextBoxColumn50 As DataGridViewTextBoxColumn

		' Token: 0x17003154 RID: 12628
		' (get) Token: 0x060085F8 RID: 34296 RVA: 0x000418DB File Offset: 0x0003FADB
		' (set) Token: 0x060085F9 RID: 34297 RVA: 0x000418E5 File Offset: 0x0003FAE5
		Friend Overridable Property DataGridViewTextBoxColumn51 As DataGridViewTextBoxColumn

		' Token: 0x17003155 RID: 12629
		' (get) Token: 0x060085FA RID: 34298 RVA: 0x000418EE File Offset: 0x0003FAEE
		' (set) Token: 0x060085FB RID: 34299 RVA: 0x000418F8 File Offset: 0x0003FAF8
		Friend Overridable Property DataGridViewTextBoxColumn52 As DataGridViewTextBoxColumn

		' Token: 0x17003156 RID: 12630
		' (get) Token: 0x060085FC RID: 34300 RVA: 0x00041901 File Offset: 0x0003FB01
		' (set) Token: 0x060085FD RID: 34301 RVA: 0x0004190B File Offset: 0x0003FB0B
		Friend Overridable Property DataGridViewTextBoxColumn53 As DataGridViewTextBoxColumn

		' Token: 0x17003157 RID: 12631
		' (get) Token: 0x060085FE RID: 34302 RVA: 0x00041914 File Offset: 0x0003FB14
		' (set) Token: 0x060085FF RID: 34303 RVA: 0x0004191E File Offset: 0x0003FB1E
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17003158 RID: 12632
		' (get) Token: 0x06008600 RID: 34304 RVA: 0x00041927 File Offset: 0x0003FB27
		' (set) Token: 0x06008601 RID: 34305 RVA: 0x0063A7C0 File Offset: 0x006389C0
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003159 RID: 12633
		' (get) Token: 0x06008602 RID: 34306 RVA: 0x00041931 File Offset: 0x0003FB31
		' (set) Token: 0x06008603 RID: 34307 RVA: 0x0063A804 File Offset: 0x00638A04
		Private _txtIMEI2 As TextBox
		Friend Overridable Property txtIMEI2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIMEI2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIMEI2_KeyDown
				Dim textBox As TextBox = Me._txtIMEI2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIMEI2 = value
				textBox = Me._txtIMEI2
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700315A RID: 12634
		' (get) Token: 0x06008604 RID: 34308 RVA: 0x0004193B File Offset: 0x0003FB3B
		' (set) Token: 0x06008605 RID: 34309 RVA: 0x0063A848 File Offset: 0x00638A48
		Private _txtIMEI1 As TextBox
		Friend Overridable Property txtIMEI1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIMEI1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIMEI1_KeyDown
				Dim textBox As TextBox = Me._txtIMEI1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIMEI1 = value
				textBox = Me._txtIMEI1
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700315B RID: 12635
		' (get) Token: 0x06008606 RID: 34310 RVA: 0x00041945 File Offset: 0x0003FB45
		' (set) Token: 0x06008607 RID: 34311 RVA: 0x0004194F File Offset: 0x0003FB4F
		Friend Overridable Property dgwsale As DataGridView

		' Token: 0x1700315C RID: 12636
		' (get) Token: 0x06008608 RID: 34312 RVA: 0x00041958 File Offset: 0x0003FB58
		' (set) Token: 0x06008609 RID: 34313 RVA: 0x00041962 File Offset: 0x0003FB62
		Friend Overridable Property DataGridViewTextBoxColumn54 As DataGridViewTextBoxColumn

		' Token: 0x1700315D RID: 12637
		' (get) Token: 0x0600860A RID: 34314 RVA: 0x0004196B File Offset: 0x0003FB6B
		' (set) Token: 0x0600860B RID: 34315 RVA: 0x00041975 File Offset: 0x0003FB75
		Friend Overridable Property DataGridViewTextBoxColumn55 As DataGridViewTextBoxColumn

		' Token: 0x1700315E RID: 12638
		' (get) Token: 0x0600860C RID: 34316 RVA: 0x0004197E File Offset: 0x0003FB7E
		' (set) Token: 0x0600860D RID: 34317 RVA: 0x00041988 File Offset: 0x0003FB88
		Friend Overridable Property DataGridViewTextBoxColumn56 As DataGridViewTextBoxColumn

		' Token: 0x1700315F RID: 12639
		' (get) Token: 0x0600860E RID: 34318 RVA: 0x00041991 File Offset: 0x0003FB91
		' (set) Token: 0x0600860F RID: 34319 RVA: 0x0004199B File Offset: 0x0003FB9B
		Friend Overridable Property DataGridViewTextBoxColumn57 As DataGridViewTextBoxColumn

		' Token: 0x17003160 RID: 12640
		' (get) Token: 0x06008610 RID: 34320 RVA: 0x000419A4 File Offset: 0x0003FBA4
		' (set) Token: 0x06008611 RID: 34321 RVA: 0x0063A88C File Offset: 0x00638A8C
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
				Dim textBox As TextBox = Me._TextBox11
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._TextBox11 = value
				textBox = Me._TextBox11
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17003161 RID: 12641
		' (get) Token: 0x06008612 RID: 34322 RVA: 0x000419AE File Offset: 0x0003FBAE
		' (set) Token: 0x06008613 RID: 34323 RVA: 0x0063A8D0 File Offset: 0x00638AD0
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

		' Token: 0x17003162 RID: 12642
		' (get) Token: 0x06008614 RID: 34324 RVA: 0x000419B8 File Offset: 0x0003FBB8
		' (set) Token: 0x06008615 RID: 34325 RVA: 0x0063A914 File Offset: 0x00638B14
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

		' Token: 0x17003163 RID: 12643
		' (get) Token: 0x06008616 RID: 34326 RVA: 0x000419C2 File Offset: 0x0003FBC2
		' (set) Token: 0x06008617 RID: 34327 RVA: 0x0063A958 File Offset: 0x00638B58
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

		' Token: 0x17003164 RID: 12644
		' (get) Token: 0x06008618 RID: 34328 RVA: 0x000419CC File Offset: 0x0003FBCC
		' (set) Token: 0x06008619 RID: 34329 RVA: 0x000419D6 File Offset: 0x0003FBD6
		Public Overridable Property PictureBox1 As PictureBox

		' Token: 0x17003165 RID: 12645
		' (get) Token: 0x0600861A RID: 34330 RVA: 0x000419DF File Offset: 0x0003FBDF
		' (set) Token: 0x0600861B RID: 34331 RVA: 0x000419E9 File Offset: 0x0003FBE9
		Friend Overridable Property CheckBox8 As CheckBox

		' Token: 0x17003166 RID: 12646
		' (get) Token: 0x0600861C RID: 34332 RVA: 0x000419F2 File Offset: 0x0003FBF2
		' (set) Token: 0x0600861D RID: 34333 RVA: 0x000419FC File Offset: 0x0003FBFC
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17003167 RID: 12647
		' (get) Token: 0x0600861E RID: 34334 RVA: 0x00041A05 File Offset: 0x0003FC05
		' (set) Token: 0x0600861F RID: 34335 RVA: 0x0063A99C File Offset: 0x00638B9C
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click_1
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

		' Token: 0x17003168 RID: 12648
		' (get) Token: 0x06008620 RID: 34336 RVA: 0x00041A0F File Offset: 0x0003FC0F
		' (set) Token: 0x06008621 RID: 34337 RVA: 0x00041A19 File Offset: 0x0003FC19
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17003169 RID: 12649
		' (get) Token: 0x06008622 RID: 34338 RVA: 0x00041A22 File Offset: 0x0003FC22
		' (set) Token: 0x06008623 RID: 34339 RVA: 0x0063A9E0 File Offset: 0x00638BE0
		Private _LinkLabel5 As LinkLabel
		Friend Overridable Property LinkLabel5 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel5_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel5 = value
				linkLabel = Me._LinkLabel5
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700316A RID: 12650
		' (get) Token: 0x06008624 RID: 34340 RVA: 0x00041A2C File Offset: 0x0003FC2C
		' (set) Token: 0x06008625 RID: 34341 RVA: 0x00041A36 File Offset: 0x0003FC36
		Friend Overridable Property Label79 As Label

		' Token: 0x1700316B RID: 12651
		' (get) Token: 0x06008626 RID: 34342 RVA: 0x00041A3F File Offset: 0x0003FC3F
		' (set) Token: 0x06008627 RID: 34343 RVA: 0x00041A49 File Offset: 0x0003FC49
		Friend Overridable Property Label78 As Label

		' Token: 0x1700316C RID: 12652
		' (get) Token: 0x06008628 RID: 34344 RVA: 0x00041A52 File Offset: 0x0003FC52
		' (set) Token: 0x06008629 RID: 34345 RVA: 0x00041A5C File Offset: 0x0003FC5C
		Friend Overridable Property Label77 As Label

		' Token: 0x1700316D RID: 12653
		' (get) Token: 0x0600862A RID: 34346 RVA: 0x00041A65 File Offset: 0x0003FC65
		' (set) Token: 0x0600862B RID: 34347 RVA: 0x0063AA24 File Offset: 0x00638C24
		Private _txtWMarginNew As TextBox
		Friend Overridable Property txtWMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtWMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtWMarginNew_TextChanged
				Dim textBox As TextBox = Me._txtWMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtWMarginNew = value
				textBox = Me._txtWMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700316E RID: 12654
		' (get) Token: 0x0600862C RID: 34348 RVA: 0x00041A6F File Offset: 0x0003FC6F
		' (set) Token: 0x0600862D RID: 34349 RVA: 0x0063AA68 File Offset: 0x00638C68
		Private _txtSaaleMarginNew As TextBox
		Friend Overridable Property txtSaaleMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSaaleMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSaaleMarginNew_TextChanged
				Dim textBox As TextBox = Me._txtSaaleMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSaaleMarginNew = value
				textBox = Me._txtSaaleMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700316F RID: 12655
		' (get) Token: 0x0600862E RID: 34350 RVA: 0x00041A79 File Offset: 0x0003FC79
		' (set) Token: 0x0600862F RID: 34351 RVA: 0x0063AAAC File Offset: 0x00638CAC
		Private _txtMRPMarginNew As TextBox
		Friend Overridable Property txtMRPMarginNew As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtMRPMarginNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtMRPMarginNew_TextChanged
				Dim textBox As TextBox = Me._txtMRPMarginNew
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtMRPMarginNew = value
				textBox = Me._txtMRPMarginNew
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003170 RID: 12656
		' (get) Token: 0x06008630 RID: 34352 RVA: 0x00041A83 File Offset: 0x0003FC83
		' (set) Token: 0x06008631 RID: 34353 RVA: 0x0063AAF0 File Offset: 0x00638CF0
		Private _chkMarginOnOff As CheckBox
		Friend Overridable Property chkMarginOnOff As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkMarginOnOff
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkMarginOnOff_CheckedChanged
				Dim checkBox As CheckBox = Me._chkMarginOnOff
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkMarginOnOff = value
				checkBox = Me._chkMarginOnOff
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003171 RID: 12657
		' (get) Token: 0x06008632 RID: 34354 RVA: 0x00041A8D File Offset: 0x0003FC8D
		' (set) Token: 0x06008633 RID: 34355 RVA: 0x00041A97 File Offset: 0x0003FC97
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17003172 RID: 12658
		' (get) Token: 0x06008634 RID: 34356 RVA: 0x00041AA0 File Offset: 0x0003FCA0
		' (set) Token: 0x06008635 RID: 34357 RVA: 0x00041AAA File Offset: 0x0003FCAA
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17003173 RID: 12659
		' (get) Token: 0x06008636 RID: 34358 RVA: 0x00041AB3 File Offset: 0x0003FCB3
		' (set) Token: 0x06008637 RID: 34359 RVA: 0x00041ABD File Offset: 0x0003FCBD
		Friend Overridable Property Label80 As Label

		' Token: 0x17003174 RID: 12660
		' (get) Token: 0x06008638 RID: 34360 RVA: 0x00041AC6 File Offset: 0x0003FCC6
		' (set) Token: 0x06008639 RID: 34361 RVA: 0x00041AD0 File Offset: 0x0003FCD0
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17003175 RID: 12661
		' (get) Token: 0x0600863A RID: 34362 RVA: 0x00041AD9 File Offset: 0x0003FCD9
		' (set) Token: 0x0600863B RID: 34363 RVA: 0x00041AE3 File Offset: 0x0003FCE3
		Friend Overridable Property TabControl1 As TabControl

		' Token: 0x17003176 RID: 12662
		' (get) Token: 0x0600863C RID: 34364 RVA: 0x00041AEC File Offset: 0x0003FCEC
		' (set) Token: 0x0600863D RID: 34365 RVA: 0x00041AF6 File Offset: 0x0003FCF6
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x17003177 RID: 12663
		' (get) Token: 0x0600863E RID: 34366 RVA: 0x00041AFF File Offset: 0x0003FCFF
		' (set) Token: 0x0600863F RID: 34367 RVA: 0x00041B09 File Offset: 0x0003FD09
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x17003178 RID: 12664
		' (get) Token: 0x06008640 RID: 34368 RVA: 0x00041B12 File Offset: 0x0003FD12
		' (set) Token: 0x06008641 RID: 34369 RVA: 0x00041B1C File Offset: 0x0003FD1C
		Friend Overridable Property Panel7 As Panel

		' Token: 0x17003179 RID: 12665
		' (get) Token: 0x06008642 RID: 34370 RVA: 0x00041B25 File Offset: 0x0003FD25
		' (set) Token: 0x06008643 RID: 34371 RVA: 0x00041B2F File Offset: 0x0003FD2F
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700317A RID: 12666
		' (get) Token: 0x06008644 RID: 34372 RVA: 0x00041B38 File Offset: 0x0003FD38
		' (set) Token: 0x06008645 RID: 34373 RVA: 0x00041B42 File Offset: 0x0003FD42
		Friend Overridable Property MenuStrip2 As MenuStrip

		' Token: 0x1700317B RID: 12667
		' (get) Token: 0x06008646 RID: 34374 RVA: 0x00041B4B File Offset: 0x0003FD4B
		' (set) Token: 0x06008647 RID: 34375 RVA: 0x0063AB34 File Offset: 0x00638D34
		Private _MasterEntryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property MasterEntryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._MasterEntryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.MasterEntryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._MasterEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._MasterEntryToolStripMenuItem = value
				toolStripMenuItem = Me._MasterEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700317C RID: 12668
		' (get) Token: 0x06008648 RID: 34376 RVA: 0x00041B55 File Offset: 0x0003FD55
		' (set) Token: 0x06008649 RID: 34377 RVA: 0x00041B5F File Offset: 0x0003FD5F
		Friend Overridable Property TransactionToolStripMenuItem As ToolStripMenuItem

		' Token: 0x1700317D RID: 12669
		' (get) Token: 0x0600864A RID: 34378 RVA: 0x00041B68 File Offset: 0x0003FD68
		' (set) Token: 0x0600864B RID: 34379 RVA: 0x0063AB78 File Offset: 0x00638D78
		Private _EstimateToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property EstimateToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._EstimateToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.EstimateToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._EstimateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._EstimateToolStripMenuItem = value
				toolStripMenuItem = Me._EstimateToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700317E RID: 12670
		' (get) Token: 0x0600864C RID: 34380 RVA: 0x00041B72 File Offset: 0x0003FD72
		' (set) Token: 0x0600864D RID: 34381 RVA: 0x0063ABBC File Offset: 0x00638DBC
		Private _QuotationToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property QuotationToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._QuotationToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.QuotationToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._QuotationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._QuotationToolStripMenuItem = value
				toolStripMenuItem = Me._QuotationToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700317F RID: 12671
		' (get) Token: 0x0600864E RID: 34382 RVA: 0x00041B7C File Offset: 0x0003FD7C
		' (set) Token: 0x0600864F RID: 34383 RVA: 0x0063AC00 File Offset: 0x00638E00
		Private _PurchaseReturnToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnToolStripMenuItem1 = value
				toolStripMenuItem = Me._PurchaseReturnToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003180 RID: 12672
		' (get) Token: 0x06008650 RID: 34384 RVA: 0x00041B86 File Offset: 0x0003FD86
		' (set) Token: 0x06008651 RID: 34385 RVA: 0x0063AC44 File Offset: 0x00638E44
		Private _PurchaseOrderToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseOrderToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseOrderToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseOrderToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseOrderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseOrderToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseOrderToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003181 RID: 12673
		' (get) Token: 0x06008652 RID: 34386 RVA: 0x00041B90 File Offset: 0x0003FD90
		' (set) Token: 0x06008653 RID: 34387 RVA: 0x0063AC88 File Offset: 0x00638E88
		Private _PaymentToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PaymentToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PaymentToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PaymentToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PaymentToolStripMenuItem = value
				toolStripMenuItem = Me._PaymentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003182 RID: 12674
		' (get) Token: 0x06008654 RID: 34388 RVA: 0x00041B9A File Offset: 0x0003FD9A
		' (set) Token: 0x06008655 RID: 34389 RVA: 0x00041BA4 File Offset: 0x0003FDA4
		Friend Overridable Property VoucherToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17003183 RID: 12675
		' (get) Token: 0x06008656 RID: 34390 RVA: 0x00041BAD File Offset: 0x0003FDAD
		' (set) Token: 0x06008657 RID: 34391 RVA: 0x0063ACCC File Offset: 0x00638ECC
		Private _SupplierBulkEditorToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SupplierBulkEditorToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierBulkEditorToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierBulkEditorToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierBulkEditorToolStripMenuItem = value
				toolStripMenuItem = Me._SupplierBulkEditorToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003184 RID: 12676
		' (get) Token: 0x06008658 RID: 34392 RVA: 0x00041BB7 File Offset: 0x0003FDB7
		' (set) Token: 0x06008659 RID: 34393 RVA: 0x00041BC1 File Offset: 0x0003FDC1
		Friend Overridable Property AboutToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17003185 RID: 12677
		' (get) Token: 0x0600865A RID: 34394 RVA: 0x00041BCA File Offset: 0x0003FDCA
		' (set) Token: 0x0600865B RID: 34395 RVA: 0x0063AD10 File Offset: 0x00638F10
		Private _StockEntryToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem2 = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003186 RID: 12678
		' (get) Token: 0x0600865C RID: 34396 RVA: 0x00041BD4 File Offset: 0x0003FDD4
		' (set) Token: 0x0600865D RID: 34397 RVA: 0x0063AD54 File Offset: 0x00638F54
		Private _StockAdjustmentToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockAdjustmentToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockAdjustmentToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockAdjustmentToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockAdjustmentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockAdjustmentToolStripMenuItem = value
				toolStripMenuItem = Me._StockAdjustmentToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003187 RID: 12679
		' (get) Token: 0x0600865E RID: 34398 RVA: 0x00041BDE File Offset: 0x0003FDDE
		' (set) Token: 0x0600865F RID: 34399 RVA: 0x00041BE8 File Offset: 0x0003FDE8
		Friend Overridable Property RecordsToolStripMenuItem As ToolStripMenuItem

		' Token: 0x17003188 RID: 12680
		' (get) Token: 0x06008660 RID: 34400 RVA: 0x00041BF1 File Offset: 0x0003FDF1
		' (set) Token: 0x06008661 RID: 34401 RVA: 0x0063AD98 File Offset: 0x00638F98
		Private _SuppliersToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SuppliersToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SuppliersToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SuppliersToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SuppliersToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SuppliersToolStripMenuItem1 = value
				toolStripMenuItem = Me._SuppliersToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003189 RID: 12681
		' (get) Token: 0x06008662 RID: 34402 RVA: 0x00041BFB File Offset: 0x0003FDFB
		' (set) Token: 0x06008663 RID: 34403 RVA: 0x00041C05 File Offset: 0x0003FE05
		Friend Overridable Property ToolStripMenuItem9 As ToolStripMenuItem

		' Token: 0x1700318A RID: 12682
		' (get) Token: 0x06008664 RID: 34404 RVA: 0x00041C0E File Offset: 0x0003FE0E
		' (set) Token: 0x06008665 RID: 34405 RVA: 0x0063ADDC File Offset: 0x00638FDC
		Private _SupplierToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property SupplierToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierToolStripMenuItem1 = value
				toolStripMenuItem = Me._SupplierToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700318B RID: 12683
		' (get) Token: 0x06008666 RID: 34406 RVA: 0x00041C18 File Offset: 0x0003FE18
		' (set) Token: 0x06008667 RID: 34407 RVA: 0x0063AE20 File Offset: 0x00639020
		Private _ToolStripMenuItem20 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem20 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem20
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem20_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem20
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem20 = value
				toolStripMenuItem = Me._ToolStripMenuItem20
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700318C RID: 12684
		' (get) Token: 0x06008668 RID: 34408 RVA: 0x00041C22 File Offset: 0x0003FE22
		' (set) Token: 0x06008669 RID: 34409 RVA: 0x0063AE64 File Offset: 0x00639064
		Private _ToolStripMenuItem23 As ToolStripMenuItem
		Friend Overridable Property ToolStripMenuItem23 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ToolStripMenuItem23
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ToolStripMenuItem23_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ToolStripMenuItem23
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ToolStripMenuItem23 = value
				toolStripMenuItem = Me._ToolStripMenuItem23
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700318D RID: 12685
		' (get) Token: 0x0600866A RID: 34410 RVA: 0x00041C2C File Offset: 0x0003FE2C
		' (set) Token: 0x0600866B RID: 34411 RVA: 0x0063AEA8 File Offset: 0x006390A8
		Private _StockStatusToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockStatusToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockStatusToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockStatusToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockStatusToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockStatusToolStripMenuItem = value
				toolStripMenuItem = Me._StockStatusToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700318E RID: 12686
		' (get) Token: 0x0600866C RID: 34412 RVA: 0x00041C36 File Offset: 0x0003FE36
		' (set) Token: 0x0600866D RID: 34413 RVA: 0x0063AEEC File Offset: 0x006390EC
		Private _StockEntryToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700318F RID: 12687
		' (get) Token: 0x0600866E RID: 34414 RVA: 0x00041C40 File Offset: 0x0003FE40
		' (set) Token: 0x0600866F RID: 34415 RVA: 0x0063AF30 File Offset: 0x00639130
		Private _StockAdjustmentToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockAdjustmentToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockAdjustmentToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockAdjustmentToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockAdjustmentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockAdjustmentToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockAdjustmentToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003190 RID: 12688
		' (get) Token: 0x06008670 RID: 34416 RVA: 0x00041C4A File Offset: 0x0003FE4A
		' (set) Token: 0x06008671 RID: 34417 RVA: 0x0063AF74 File Offset: 0x00639174
		Private _PurchasesToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchasesToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchasesToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchasesToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchasesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchasesToolStripMenuItem = value
				toolStripMenuItem = Me._PurchasesToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003191 RID: 12689
		' (get) Token: 0x06008672 RID: 34418 RVA: 0x00041C54 File Offset: 0x0003FE54
		' (set) Token: 0x06008673 RID: 34419 RVA: 0x0063AFB8 File Offset: 0x006391B8
		Private _PurchaseReturnToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property PurchaseReturnToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseReturnToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseReturnToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseReturnToolStripMenuItem = value
				toolStripMenuItem = Me._PurchaseReturnToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003192 RID: 12690
		' (get) Token: 0x06008674 RID: 34420 RVA: 0x00041C5E File Offset: 0x0003FE5E
		' (set) Token: 0x06008675 RID: 34421 RVA: 0x0063AFFC File Offset: 0x006391FC
		Private _PurchaseOrderToolStripMenuItem2 As ToolStripMenuItem
		Friend Overridable Property PurchaseOrderToolStripMenuItem2 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseOrderToolStripMenuItem2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseOrderToolStripMenuItem2_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseOrderToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseOrderToolStripMenuItem2 = value
				toolStripMenuItem = Me._PurchaseOrderToolStripMenuItem2
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003193 RID: 12691
		' (get) Token: 0x06008676 RID: 34422 RVA: 0x00041C68 File Offset: 0x0003FE68
		' (set) Token: 0x06008677 RID: 34423 RVA: 0x0063B040 File Offset: 0x00639240
		Private _PaymentsToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PaymentsToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PaymentsToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PaymentsToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PaymentsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PaymentsToolStripMenuItem1 = value
				toolStripMenuItem = Me._PaymentsToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003194 RID: 12692
		' (get) Token: 0x06008678 RID: 34424 RVA: 0x00041C72 File Offset: 0x0003FE72
		' (set) Token: 0x06008679 RID: 34425 RVA: 0x00041C7C File Offset: 0x0003FE7C
		Friend Overridable Property ReportsToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17003195 RID: 12693
		' (get) Token: 0x0600867A RID: 34426 RVA: 0x00041C85 File Offset: 0x0003FE85
		' (set) Token: 0x0600867B RID: 34427 RVA: 0x00041C8F File Offset: 0x0003FE8F
		Friend Overridable Property ToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x17003196 RID: 12694
		' (get) Token: 0x0600867C RID: 34428 RVA: 0x00041C98 File Offset: 0x0003FE98
		' (set) Token: 0x0600867D RID: 34429 RVA: 0x0063B084 File Offset: 0x00639284
		Private _DashBoardToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property DashBoardToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._DashBoardToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.DashBoardToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._DashBoardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._DashBoardToolStripMenuItem = value
				toolStripMenuItem = Me._DashBoardToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003197 RID: 12695
		' (get) Token: 0x0600867E RID: 34430 RVA: 0x00041CA2 File Offset: 0x0003FEA2
		' (set) Token: 0x0600867F RID: 34431 RVA: 0x0063B0C8 File Offset: 0x006392C8
		Private _BalanceSheetToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property BalanceSheetToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._BalanceSheetToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.BalanceSheetToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._BalanceSheetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._BalanceSheetToolStripMenuItem = value
				toolStripMenuItem = Me._BalanceSheetToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003198 RID: 12696
		' (get) Token: 0x06008680 RID: 34432 RVA: 0x00041CAC File Offset: 0x0003FEAC
		' (set) Token: 0x06008681 RID: 34433 RVA: 0x0063B10C File Offset: 0x0063930C
		Private _ProfitAndLossToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProfitAndLossToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProfitAndLossToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProfitAndLossToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProfitAndLossToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProfitAndLossToolStripMenuItem = value
				toolStripMenuItem = Me._ProfitAndLossToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003199 RID: 12697
		' (get) Token: 0x06008682 RID: 34434 RVA: 0x00041CB6 File Offset: 0x0003FEB6
		' (set) Token: 0x06008683 RID: 34435 RVA: 0x0063B150 File Offset: 0x00639350
		Private _TrialBalanceToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property TrialBalanceToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TrialBalanceToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TrialBalanceToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TrialBalanceToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TrialBalanceToolStripMenuItem = value
				toolStripMenuItem = Me._TrialBalanceToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700319A RID: 12698
		' (get) Token: 0x06008684 RID: 34436 RVA: 0x00041CC0 File Offset: 0x0003FEC0
		' (set) Token: 0x06008685 RID: 34437 RVA: 0x00041CCA File Offset: 0x0003FECA
		Friend Overridable Property SupplierLedgerToolStripMenuItem1 As ToolStripMenuItem

		' Token: 0x1700319B RID: 12699
		' (get) Token: 0x06008686 RID: 34438 RVA: 0x00041CD3 File Offset: 0x0003FED3
		' (set) Token: 0x06008687 RID: 34439 RVA: 0x0063B194 File Offset: 0x00639394
		Private _SupplierLedgerToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SupplierLedgerToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SupplierLedgerToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SupplierLedgerToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SupplierLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SupplierLedgerToolStripMenuItem = value
				toolStripMenuItem = Me._SupplierLedgerToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700319C RID: 12700
		' (get) Token: 0x06008688 RID: 34440 RVA: 0x00041CDD File Offset: 0x0003FEDD
		' (set) Token: 0x06008689 RID: 34441 RVA: 0x0063B1D8 File Offset: 0x006393D8
		Private _TaxToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property TaxToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._TaxToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.TaxToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._TaxToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._TaxToolStripMenuItem1 = value
				toolStripMenuItem = Me._TaxToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700319D RID: 12701
		' (get) Token: 0x0600868A RID: 34442 RVA: 0x00041CE7 File Offset: 0x0003FEE7
		' (set) Token: 0x0600868B RID: 34443 RVA: 0x0063B21C File Offset: 0x0063941C
		Private _LowStockItemsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property LowStockItemsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._LowStockItemsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.LowStockItemsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._LowStockItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._LowStockItemsToolStripMenuItem = value
				toolStripMenuItem = Me._LowStockItemsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700319E RID: 12702
		' (get) Token: 0x0600868C RID: 34444 RVA: 0x00041CF1 File Offset: 0x0003FEF1
		' (set) Token: 0x0600868D RID: 34445 RVA: 0x0063B260 File Offset: 0x00639460
		Private _StockEntryToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockEntryToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockEntryToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockEntryToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockEntryToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockEntryToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700319F RID: 12703
		' (get) Token: 0x0600868E RID: 34446 RVA: 0x00041CFB File Offset: 0x0003FEFB
		' (set) Token: 0x0600868F RID: 34447 RVA: 0x0063B2A4 File Offset: 0x006394A4
		Private _StockInAndStockOutToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property StockInAndStockOutToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._StockInAndStockOutToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.StockInAndStockOutToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._StockInAndStockOutToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._StockInAndStockOutToolStripMenuItem1 = value
				toolStripMenuItem = Me._StockInAndStockOutToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031A0 RID: 12704
		' (get) Token: 0x06008690 RID: 34448 RVA: 0x00041D05 File Offset: 0x0003FF05
		' (set) Token: 0x06008691 RID: 34449 RVA: 0x00041D0F File Offset: 0x0003FF0F
		Friend Overridable Property StockMovementToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A1 RID: 12705
		' (get) Token: 0x06008692 RID: 34450 RVA: 0x00041D18 File Offset: 0x0003FF18
		' (set) Token: 0x06008693 RID: 34451 RVA: 0x0063B2E8 File Offset: 0x006394E8
		Private _PurchaseToolStripMenuItem1 As ToolStripMenuItem
		Friend Overridable Property PurchaseToolStripMenuItem1 As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._PurchaseToolStripMenuItem1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.PurchaseToolStripMenuItem1_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._PurchaseToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._PurchaseToolStripMenuItem1 = value
				toolStripMenuItem = Me._PurchaseToolStripMenuItem1
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031A2 RID: 12706
		' (get) Token: 0x06008694 RID: 34452 RVA: 0x00041D22 File Offset: 0x0003FF22
		' (set) Token: 0x06008695 RID: 34453 RVA: 0x00041D2C File Offset: 0x0003FF2C
		Friend Overridable Property GSTRToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A3 RID: 12707
		' (get) Token: 0x06008696 RID: 34454 RVA: 0x00041D35 File Offset: 0x0003FF35
		' (set) Token: 0x06008697 RID: 34455 RVA: 0x00041D3F File Offset: 0x0003FF3F
		Friend Overridable Property SaleRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A4 RID: 12708
		' (get) Token: 0x06008698 RID: 34456 RVA: 0x00041D48 File Offset: 0x0003FF48
		' (set) Token: 0x06008699 RID: 34457 RVA: 0x00041D52 File Offset: 0x0003FF52
		Friend Overridable Property PurchaseRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A5 RID: 12709
		' (get) Token: 0x0600869A RID: 34458 RVA: 0x00041D5B File Offset: 0x0003FF5B
		' (set) Token: 0x0600869B RID: 34459 RVA: 0x00041D65 File Offset: 0x0003FF65
		Friend Overridable Property SalesReturnRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A6 RID: 12710
		' (get) Token: 0x0600869C RID: 34460 RVA: 0x00041D6E File Offset: 0x0003FF6E
		' (set) Token: 0x0600869D RID: 34461 RVA: 0x00041D78 File Offset: 0x0003FF78
		Friend Overridable Property PurchaseReturnRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A7 RID: 12711
		' (get) Token: 0x0600869E RID: 34462 RVA: 0x00041D81 File Offset: 0x0003FF81
		' (set) Token: 0x0600869F RID: 34463 RVA: 0x00041D8B File Offset: 0x0003FF8B
		Friend Overridable Property TaxCalculatorToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A8 RID: 12712
		' (get) Token: 0x060086A0 RID: 34464 RVA: 0x00041D94 File Offset: 0x0003FF94
		' (set) Token: 0x060086A1 RID: 34465 RVA: 0x00041D9E File Offset: 0x0003FF9E
		Friend Overridable Property OutputTaxToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031A9 RID: 12713
		' (get) Token: 0x060086A2 RID: 34466 RVA: 0x00041DA7 File Offset: 0x0003FFA7
		' (set) Token: 0x060086A3 RID: 34467 RVA: 0x00041DB1 File Offset: 0x0003FFB1
		Friend Overridable Property InputTaxToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AA RID: 12714
		' (get) Token: 0x060086A4 RID: 34468 RVA: 0x00041DBA File Offset: 0x0003FFBA
		' (set) Token: 0x060086A5 RID: 34469 RVA: 0x00041DC4 File Offset: 0x0003FFC4
		Friend Overridable Property GSTRegisterToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AB RID: 12715
		' (get) Token: 0x060086A6 RID: 34470 RVA: 0x00041DCD File Offset: 0x0003FFCD
		' (set) Token: 0x060086A7 RID: 34471 RVA: 0x00041DD7 File Offset: 0x0003FFD7
		Friend Overridable Property SaleRegisterBillWiseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AC RID: 12716
		' (get) Token: 0x060086A8 RID: 34472 RVA: 0x00041DE0 File Offset: 0x0003FFE0
		' (set) Token: 0x060086A9 RID: 34473 RVA: 0x00041DEA File Offset: 0x0003FFEA
		Friend Overridable Property PurchaseRegisterBillWiseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AD RID: 12717
		' (get) Token: 0x060086AA RID: 34474 RVA: 0x00041DF3 File Offset: 0x0003FFF3
		' (set) Token: 0x060086AB RID: 34475 RVA: 0x00041DFD File Offset: 0x0003FFFD
		Friend Overridable Property SaleReturnBillWiseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AE RID: 12718
		' (get) Token: 0x060086AC RID: 34476 RVA: 0x00041E06 File Offset: 0x00040006
		' (set) Token: 0x060086AD RID: 34477 RVA: 0x00041E10 File Offset: 0x00040010
		Friend Overridable Property PurchaseReturnBillWiseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031AF RID: 12719
		' (get) Token: 0x060086AE RID: 34478 RVA: 0x00041E19 File Offset: 0x00040019
		' (set) Token: 0x060086AF RID: 34479 RVA: 0x00041E23 File Offset: 0x00040023
		Friend Overridable Property SalesRegisterDetailsToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B0 RID: 12720
		' (get) Token: 0x060086B0 RID: 34480 RVA: 0x00041E2C File Offset: 0x0004002C
		' (set) Token: 0x060086B1 RID: 34481 RVA: 0x00041E36 File Offset: 0x00040036
		Friend Overridable Property PurchaseRegisterItemWiseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B1 RID: 12721
		' (get) Token: 0x060086B2 RID: 34482 RVA: 0x00041E3F File Offset: 0x0004003F
		' (set) Token: 0x060086B3 RID: 34483 RVA: 0x00041E49 File Offset: 0x00040049
		Friend Overridable Property GSTR1ToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B2 RID: 12722
		' (get) Token: 0x060086B4 RID: 34484 RVA: 0x00041E52 File Offset: 0x00040052
		' (set) Token: 0x060086B5 RID: 34485 RVA: 0x00041E5C File Offset: 0x0004005C
		Friend Overridable Property GSTR3BToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B3 RID: 12723
		' (get) Token: 0x060086B6 RID: 34486 RVA: 0x00041E65 File Offset: 0x00040065
		' (set) Token: 0x060086B7 RID: 34487 RVA: 0x00041E6F File Offset: 0x0004006F
		Friend Overridable Property SaleGSTReportToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B4 RID: 12724
		' (get) Token: 0x060086B8 RID: 34488 RVA: 0x00041E78 File Offset: 0x00040078
		' (set) Token: 0x060086B9 RID: 34489 RVA: 0x00041E82 File Offset: 0x00040082
		Friend Overridable Property TCSToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B5 RID: 12725
		' (get) Token: 0x060086BA RID: 34490 RVA: 0x00041E8B File Offset: 0x0004008B
		' (set) Token: 0x060086BB RID: 34491 RVA: 0x00041E95 File Offset: 0x00040095
		Friend Overridable Property TCSValidationToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B6 RID: 12726
		' (get) Token: 0x060086BC RID: 34492 RVA: 0x00041E9E File Offset: 0x0004009E
		' (set) Token: 0x060086BD RID: 34493 RVA: 0x00041EA8 File Offset: 0x000400A8
		Friend Overridable Property TCSReceivedToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B7 RID: 12727
		' (get) Token: 0x060086BE RID: 34494 RVA: 0x00041EB1 File Offset: 0x000400B1
		' (set) Token: 0x060086BF RID: 34495 RVA: 0x00041EBB File Offset: 0x000400BB
		Friend Overridable Property TCSPaymentPurchaseToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B8 RID: 12728
		' (get) Token: 0x060086C0 RID: 34496 RVA: 0x00041EC4 File Offset: 0x000400C4
		' (set) Token: 0x060086C1 RID: 34497 RVA: 0x00041ECE File Offset: 0x000400CE
		Friend Overridable Property TCSPaymentSaleReturnToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031B9 RID: 12729
		' (get) Token: 0x060086C2 RID: 34498 RVA: 0x00041ED7 File Offset: 0x000400D7
		' (set) Token: 0x060086C3 RID: 34499 RVA: 0x00041EE1 File Offset: 0x000400E1
		Friend Overridable Property TCSReceivedPurchaseReturnToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031BA RID: 12730
		' (get) Token: 0x060086C4 RID: 34500 RVA: 0x00041EEA File Offset: 0x000400EA
		' (set) Token: 0x060086C5 RID: 34501 RVA: 0x00041EF4 File Offset: 0x000400F4
		Friend Overridable Property IncomeTaxCalculatorOnlineToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031BB RID: 12731
		' (get) Token: 0x060086C6 RID: 34502 RVA: 0x00041EFD File Offset: 0x000400FD
		' (set) Token: 0x060086C7 RID: 34503 RVA: 0x00041F07 File Offset: 0x00040107
		Friend Overridable Property GSTINValidationToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031BC RID: 12732
		' (get) Token: 0x060086C8 RID: 34504 RVA: 0x00041F10 File Offset: 0x00040110
		' (set) Token: 0x060086C9 RID: 34505 RVA: 0x00041F1A File Offset: 0x0004011A
		Friend Overridable Property ExportImportExcelToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031BD RID: 12733
		' (get) Token: 0x060086CA RID: 34506 RVA: 0x00041F23 File Offset: 0x00040123
		' (set) Token: 0x060086CB RID: 34507 RVA: 0x0063B32C File Offset: 0x0063952C
		Private _ProductsToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property ProductsToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._ProductsToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.ProductsToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._ProductsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._ProductsToolStripMenuItem = value
				toolStripMenuItem = Me._ProductsToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031BE RID: 12734
		' (get) Token: 0x060086CC RID: 34508 RVA: 0x00041F2D File Offset: 0x0004012D
		' (set) Token: 0x060086CD RID: 34509 RVA: 0x0063B370 File Offset: 0x00639570
		Private _SuppliersToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property SuppliersToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._SuppliersToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.SuppliersToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._SuppliersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._SuppliersToolStripMenuItem = value
				toolStripMenuItem = Me._SuppliersToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031BF RID: 12735
		' (get) Token: 0x060086CE RID: 34510 RVA: 0x00041F37 File Offset: 0x00040137
		' (set) Token: 0x060086CF RID: 34511 RVA: 0x00041F41 File Offset: 0x00040141
		Friend Overridable Property BarcodeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031C0 RID: 12736
		' (get) Token: 0x060086D0 RID: 34512 RVA: 0x00041F4A File Offset: 0x0004014A
		' (set) Token: 0x060086D1 RID: 34513 RVA: 0x00041F54 File Offset: 0x00040154
		Friend Overridable Property DBarcodeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031C1 RID: 12737
		' (get) Token: 0x060086D2 RID: 34514 RVA: 0x00041F5D File Offset: 0x0004015D
		' (set) Token: 0x060086D3 RID: 34515 RVA: 0x00041F67 File Offset: 0x00040167
		Friend Overridable Property CipherBarcodeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031C2 RID: 12738
		' (get) Token: 0x060086D4 RID: 34516 RVA: 0x00041F70 File Offset: 0x00040170
		' (set) Token: 0x060086D5 RID: 34517 RVA: 0x00041F7A File Offset: 0x0004017A
		Friend Overridable Property QRBarcodeReaderToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031C3 RID: 12739
		' (get) Token: 0x060086D6 RID: 34518 RVA: 0x00041F83 File Offset: 0x00040183
		' (set) Token: 0x060086D7 RID: 34519 RVA: 0x00041F8D File Offset: 0x0004018D
		Friend Overridable Property ComboPackBarcodeToolStripMenuItem As ToolStripMenuItem

		' Token: 0x170031C4 RID: 12740
		' (get) Token: 0x060086D8 RID: 34520 RVA: 0x00041F96 File Offset: 0x00040196
		' (set) Token: 0x060086D9 RID: 34521 RVA: 0x00041FA0 File Offset: 0x000401A0
		Friend Overridable Property lblCName As Label

		' Token: 0x170031C5 RID: 12741
		' (get) Token: 0x060086DA RID: 34522 RVA: 0x00041FA9 File Offset: 0x000401A9
		' (set) Token: 0x060086DB RID: 34523 RVA: 0x00041FB3 File Offset: 0x000401B3
		Friend Overridable Property Label26 As Label

		' Token: 0x170031C6 RID: 12742
		' (get) Token: 0x060086DC RID: 34524 RVA: 0x00041FBC File Offset: 0x000401BC
		' (set) Token: 0x060086DD RID: 34525 RVA: 0x0063B3B4 File Offset: 0x006395B4
		Private _AddNewProductToolStripMenuItem As ToolStripMenuItem
		Friend Overridable Property AddNewProductToolStripMenuItem As ToolStripMenuItem
			<CompilerGenerated()>
			Get
				Return Me._AddNewProductToolStripMenuItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ToolStripMenuItem)
				Dim eventHandler As EventHandler = AddressOf Me.AddNewProductToolStripMenuItem_Click
				Dim toolStripMenuItem As ToolStripMenuItem = Me._AddNewProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					RemoveHandler toolStripMenuItem.Click, eventHandler
				End If
				Me._AddNewProductToolStripMenuItem = value
				toolStripMenuItem = Me._AddNewProductToolStripMenuItem
				If toolStripMenuItem IsNot Nothing Then
					AddHandler toolStripMenuItem.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031C7 RID: 12743
		' (get) Token: 0x060086DE RID: 34526 RVA: 0x00041FC6 File Offset: 0x000401C6
		' (set) Token: 0x060086DF RID: 34527 RVA: 0x00041FD0 File Offset: 0x000401D0
		Friend Overridable Property Label20 As Label

		' Token: 0x170031C8 RID: 12744
		' (get) Token: 0x060086E0 RID: 34528 RVA: 0x00041FD9 File Offset: 0x000401D9
		' (set) Token: 0x060086E1 RID: 34529 RVA: 0x00041FE3 File Offset: 0x000401E3
		Friend Overridable Property Label30 As Label

		' Token: 0x170031C9 RID: 12745
		' (get) Token: 0x060086E2 RID: 34530 RVA: 0x00041FEC File Offset: 0x000401EC
		' (set) Token: 0x060086E3 RID: 34531 RVA: 0x00041FF6 File Offset: 0x000401F6
		Friend Overridable Property Label40 As Label

		' Token: 0x170031CA RID: 12746
		' (get) Token: 0x060086E4 RID: 34532 RVA: 0x00041FFF File Offset: 0x000401FF
		' (set) Token: 0x060086E5 RID: 34533 RVA: 0x00042009 File Offset: 0x00040209
		Friend Overridable Property Label51 As Label

		' Token: 0x170031CB RID: 12747
		' (get) Token: 0x060086E6 RID: 34534 RVA: 0x00042012 File Offset: 0x00040212
		' (set) Token: 0x060086E7 RID: 34535 RVA: 0x0004201C File Offset: 0x0004021C
		Friend Overridable Property Panel8 As Panel

		' Token: 0x170031CC RID: 12748
		' (get) Token: 0x060086E8 RID: 34536 RVA: 0x00042025 File Offset: 0x00040225
		' (set) Token: 0x060086E9 RID: 34537 RVA: 0x0063B3F8 File Offset: 0x006395F8
		Private _GelButton1 As Button
		Friend Overridable Property GelButton1 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim button As Button = Me._GelButton1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton1 = value
				button = Me._GelButton1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031CD RID: 12749
		' (get) Token: 0x060086EA RID: 34538 RVA: 0x0004202F File Offset: 0x0004022F
		' (set) Token: 0x060086EB RID: 34539 RVA: 0x0063B43C File Offset: 0x0063963C
		Private _GelButton3 As Button
		Friend Overridable Property GelButton3 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim button As Button = Me._GelButton3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton3 = value
				button = Me._GelButton3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031CE RID: 12750
		' (get) Token: 0x060086EC RID: 34540 RVA: 0x00042039 File Offset: 0x00040239
		' (set) Token: 0x060086ED RID: 34541 RVA: 0x0063B480 File Offset: 0x00639680
		Private _GelButton5 As Button
		Friend Overridable Property GelButton5 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim button As Button = Me._GelButton5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton5 = value
				button = Me._GelButton5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031CF RID: 12751
		' (get) Token: 0x060086EE RID: 34542 RVA: 0x00042043 File Offset: 0x00040243
		' (set) Token: 0x060086EF RID: 34543 RVA: 0x0063B4C4 File Offset: 0x006396C4
		Private _GelButton4 As Button
		Friend Overridable Property GelButton4 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim button As Button = Me._GelButton4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton4 = value
				button = Me._GelButton4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D0 RID: 12752
		' (get) Token: 0x060086F0 RID: 34544 RVA: 0x0004204D File Offset: 0x0004024D
		' (set) Token: 0x060086F1 RID: 34545 RVA: 0x0063B508 File Offset: 0x00639708
		Private _btnDelete As Button
		Friend Overridable Property btnDelete As Button
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim button As Button = Me._btnDelete
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnDelete = value
				button = Me._btnDelete
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D1 RID: 12753
		' (get) Token: 0x060086F2 RID: 34546 RVA: 0x00042057 File Offset: 0x00040257
		' (set) Token: 0x060086F3 RID: 34547 RVA: 0x0063B54C File Offset: 0x0063974C
		Private _btnUpdate As Button
		Friend Overridable Property btnUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim button As Button = Me._btnUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpdate = value
				button = Me._btnUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D2 RID: 12754
		' (get) Token: 0x060086F4 RID: 34548 RVA: 0x00042061 File Offset: 0x00040261
		' (set) Token: 0x060086F5 RID: 34549 RVA: 0x0063B590 File Offset: 0x00639790
		Private _btnNew As Button
		Friend Overridable Property btnNew As Button
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim button As Button = Me._btnNew
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnNew = value
				button = Me._btnNew
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D3 RID: 12755
		' (get) Token: 0x060086F6 RID: 34550 RVA: 0x0004206B File Offset: 0x0004026B
		' (set) Token: 0x060086F7 RID: 34551 RVA: 0x0063B5D4 File Offset: 0x006397D4
		Private _btnSave As Button
		Friend Overridable Property btnSave As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnSave
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSave = value
				button = Me._btnSave
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D4 RID: 12756
		' (get) Token: 0x060086F8 RID: 34552 RVA: 0x00042075 File Offset: 0x00040275
		' (set) Token: 0x060086F9 RID: 34553 RVA: 0x0063B618 File Offset: 0x00639818
		Private _btnPrint As Button
		Friend Overridable Property btnPrint As Button
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim button As Button = Me._btnPrint
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnPrint = value
				button = Me._btnPrint
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D5 RID: 12757
		' (get) Token: 0x060086FA RID: 34554 RVA: 0x0004207F File Offset: 0x0004027F
		' (set) Token: 0x060086FB RID: 34555 RVA: 0x0063B65C File Offset: 0x0063985C
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

		' Token: 0x170031D6 RID: 12758
		' (get) Token: 0x060086FC RID: 34556 RVA: 0x00042089 File Offset: 0x00040289
		' (set) Token: 0x060086FD RID: 34557 RVA: 0x0063B6A0 File Offset: 0x006398A0
		Private _btnAdd As Button
		Friend Overridable Property btnAdd As Button
			<CompilerGenerated()>
			Get
				Return Me._btnAdd
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnAdd_Click
				Dim button As Button = Me._btnAdd
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnAdd = value
				button = Me._btnAdd
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D7 RID: 12759
		' (get) Token: 0x060086FE RID: 34558 RVA: 0x00042093 File Offset: 0x00040293
		' (set) Token: 0x060086FF RID: 34559 RVA: 0x0063B6E4 File Offset: 0x006398E4
		Private _btnRemove As Button
		Friend Overridable Property btnRemove As Button
			<CompilerGenerated()>
			Get
				Return Me._btnRemove
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnRemove_Click
				Dim button As Button = Me._btnRemove
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnRemove = value
				button = Me._btnRemove
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D8 RID: 12760
		' (get) Token: 0x06008700 RID: 34560 RVA: 0x0004209D File Offset: 0x0004029D
		' (set) Token: 0x06008701 RID: 34561 RVA: 0x0063B728 File Offset: 0x00639928
		Private _btnGridUpdate As Button
		Friend Overridable Property btnGridUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGridUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGridUpdate_Click
				Dim button As Button = Me._btnGridUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGridUpdate = value
				button = Me._btnGridUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031D9 RID: 12761
		' (get) Token: 0x06008702 RID: 34562 RVA: 0x000420A7 File Offset: 0x000402A7
		' (set) Token: 0x06008703 RID: 34563 RVA: 0x0063B76C File Offset: 0x0063996C
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

		' Token: 0x170031DA RID: 12762
		' (get) Token: 0x06008704 RID: 34564 RVA: 0x000420B1 File Offset: 0x000402B1
		' (set) Token: 0x06008705 RID: 34565 RVA: 0x000420BB File Offset: 0x000402BB
		Friend Overridable Property TableLayoutPanel4 As TableLayoutPanel

		' Token: 0x170031DB RID: 12763
		' (get) Token: 0x06008706 RID: 34566 RVA: 0x000420C4 File Offset: 0x000402C4
		' (set) Token: 0x06008707 RID: 34567 RVA: 0x000420CE File Offset: 0x000402CE
		Friend Overridable Property Label81 As Label

		' Token: 0x170031DC RID: 12764
		' (get) Token: 0x06008708 RID: 34568 RVA: 0x000420D7 File Offset: 0x000402D7
		' (set) Token: 0x06008709 RID: 34569 RVA: 0x000420E1 File Offset: 0x000402E1
		Friend Overridable Property TableLayoutPanel5 As TableLayoutPanel

		' Token: 0x170031DD RID: 12765
		' (get) Token: 0x0600870A RID: 34570 RVA: 0x000420EA File Offset: 0x000402EA
		' (set) Token: 0x0600870B RID: 34571 RVA: 0x000420F4 File Offset: 0x000402F4
		Friend Overridable Property GroupBox9 As GroupBox

		' Token: 0x170031DE RID: 12766
		' (get) Token: 0x0600870C RID: 34572 RVA: 0x000420FD File Offset: 0x000402FD
		' (set) Token: 0x0600870D RID: 34573 RVA: 0x00042107 File Offset: 0x00040307
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x170031DF RID: 12767
		' (get) Token: 0x0600870E RID: 34574 RVA: 0x00042110 File Offset: 0x00040310
		' (set) Token: 0x0600870F RID: 34575 RVA: 0x0063B7B0 File Offset: 0x006399B0
		Private _txtCGST As TextBox
		Friend Overridable Property txtCGST As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCGST
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCGST_TextChanged
				Dim textBox As TextBox = Me._txtCGST
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCGST = value
				textBox = Me._txtCGST
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031E0 RID: 12768
		' (get) Token: 0x06008710 RID: 34576 RVA: 0x0004211A File Offset: 0x0004031A
		' (set) Token: 0x06008711 RID: 34577 RVA: 0x00042124 File Offset: 0x00040324
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x170031E1 RID: 12769
		' (get) Token: 0x06008712 RID: 34578 RVA: 0x0004212D File Offset: 0x0004032D
		' (set) Token: 0x06008713 RID: 34579 RVA: 0x00042137 File Offset: 0x00040337
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x170031E2 RID: 12770
		' (get) Token: 0x06008714 RID: 34580 RVA: 0x00042140 File Offset: 0x00040340
		' (set) Token: 0x06008715 RID: 34581 RVA: 0x0004214A File Offset: 0x0004034A
		Friend Overridable Property GroupBox7 As GroupBox

		' Token: 0x170031E3 RID: 12771
		' (get) Token: 0x06008716 RID: 34582 RVA: 0x00042153 File Offset: 0x00040353
		' (set) Token: 0x06008717 RID: 34583 RVA: 0x0004215D File Offset: 0x0004035D
		Friend Overridable Property GroupBox8 As GroupBox

		' Token: 0x170031E4 RID: 12772
		' (get) Token: 0x06008718 RID: 34584 RVA: 0x00042166 File Offset: 0x00040366
		' (set) Token: 0x06008719 RID: 34585 RVA: 0x00042170 File Offset: 0x00040370
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x170031E5 RID: 12773
		' (get) Token: 0x0600871A RID: 34586 RVA: 0x00042179 File Offset: 0x00040379
		' (set) Token: 0x0600871B RID: 34587 RVA: 0x00042183 File Offset: 0x00040383
		Friend Overridable Property TableLayoutPanel2 As TableLayoutPanel

		' Token: 0x170031E6 RID: 12774
		' (get) Token: 0x0600871C RID: 34588 RVA: 0x0004218C File Offset: 0x0004038C
		' (set) Token: 0x0600871D RID: 34589 RVA: 0x00042196 File Offset: 0x00040396
		Friend Overridable Property Label14 As Label

		' Token: 0x170031E7 RID: 12775
		' (get) Token: 0x0600871E RID: 34590 RVA: 0x0004219F File Offset: 0x0004039F
		' (set) Token: 0x0600871F RID: 34591 RVA: 0x000421A9 File Offset: 0x000403A9
		Friend Overridable Property Label23 As Label

		' Token: 0x170031E8 RID: 12776
		' (get) Token: 0x06008720 RID: 34592 RVA: 0x000421B2 File Offset: 0x000403B2
		' (set) Token: 0x06008721 RID: 34593 RVA: 0x000421BC File Offset: 0x000403BC
		Friend Overridable Property Label27 As Label

		' Token: 0x170031E9 RID: 12777
		' (get) Token: 0x06008722 RID: 34594 RVA: 0x000421C5 File Offset: 0x000403C5
		' (set) Token: 0x06008723 RID: 34595 RVA: 0x000421CF File Offset: 0x000403CF
		Friend Overridable Property Label43 As Label

		' Token: 0x170031EA RID: 12778
		' (get) Token: 0x06008724 RID: 34596 RVA: 0x000421D8 File Offset: 0x000403D8
		' (set) Token: 0x06008725 RID: 34597 RVA: 0x000421E2 File Offset: 0x000403E2
		Friend Overridable Property Label58 As Label

		' Token: 0x170031EB RID: 12779
		' (get) Token: 0x06008726 RID: 34598 RVA: 0x000421EB File Offset: 0x000403EB
		' (set) Token: 0x06008727 RID: 34599 RVA: 0x000421F5 File Offset: 0x000403F5
		Friend Overridable Property Label82 As Label

		' Token: 0x170031EC RID: 12780
		' (get) Token: 0x06008728 RID: 34600 RVA: 0x000421FE File Offset: 0x000403FE
		' (set) Token: 0x06008729 RID: 34601 RVA: 0x00042208 File Offset: 0x00040408
		Friend Overridable Property CheckBox9 As CheckBox

		' Token: 0x170031ED RID: 12781
		' (get) Token: 0x0600872A RID: 34602 RVA: 0x00042211 File Offset: 0x00040411
		' (set) Token: 0x0600872B RID: 34603 RVA: 0x0004221B File Offset: 0x0004041B
		Friend Overridable Property GroupBox10 As GroupBox

		' Token: 0x170031EE RID: 12782
		' (get) Token: 0x0600872C RID: 34604 RVA: 0x00042224 File Offset: 0x00040424
		' (set) Token: 0x0600872D RID: 34605 RVA: 0x0063B7F4 File Offset: 0x006399F4
		Private _Button8 As Button
		Friend Overridable Property Button8 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button8_Click
				Dim button As Button = Me._Button8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button8 = value
				button = Me._Button8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170031EF RID: 12783
		' (get) Token: 0x0600872E RID: 34606 RVA: 0x0004222E File Offset: 0x0004042E
		' (set) Token: 0x0600872F RID: 34607 RVA: 0x00042238 File Offset: 0x00040438
		Friend Overridable Property GroupBox11 As GroupBox

		' Token: 0x170031F0 RID: 12784
		' (get) Token: 0x06008730 RID: 34608 RVA: 0x00042241 File Offset: 0x00040441
		' (set) Token: 0x06008731 RID: 34609 RVA: 0x0004224B File Offset: 0x0004044B
		Friend Overridable Property Label5 As Label

		' Token: 0x170031F1 RID: 12785
		' (get) Token: 0x06008732 RID: 34610 RVA: 0x00042254 File Offset: 0x00040454
		' (set) Token: 0x06008733 RID: 34611 RVA: 0x0004225E File Offset: 0x0004045E
		Friend Overridable Property Label17 As Label

		' Token: 0x170031F2 RID: 12786
		' (get) Token: 0x06008734 RID: 34612 RVA: 0x00042267 File Offset: 0x00040467
		' (set) Token: 0x06008735 RID: 34613 RVA: 0x00042271 File Offset: 0x00040471
		Friend Overridable Property Label18 As Label

		' Token: 0x170031F3 RID: 12787
		' (get) Token: 0x06008736 RID: 34614 RVA: 0x0004227A File Offset: 0x0004047A
		' (set) Token: 0x06008737 RID: 34615 RVA: 0x00042284 File Offset: 0x00040484
		Friend Overridable Property Label19 As Label

		' Token: 0x170031F4 RID: 12788
		' (get) Token: 0x06008738 RID: 34616 RVA: 0x0004228D File Offset: 0x0004048D
		' (set) Token: 0x06008739 RID: 34617 RVA: 0x00042297 File Offset: 0x00040497
		Friend Overridable Property Label24 As Label

		' Token: 0x170031F5 RID: 12789
		' (get) Token: 0x0600873A RID: 34618 RVA: 0x000422A0 File Offset: 0x000404A0
		' (set) Token: 0x0600873B RID: 34619 RVA: 0x000422AA File Offset: 0x000404AA
		Friend Overridable Property Label29 As Label

		' Token: 0x170031F6 RID: 12790
		' (get) Token: 0x0600873C RID: 34620 RVA: 0x000422B3 File Offset: 0x000404B3
		' (set) Token: 0x0600873D RID: 34621 RVA: 0x000422BD File Offset: 0x000404BD
		Friend Overridable Property Label74 As Label

		' Token: 0x170031F7 RID: 12791
		' (get) Token: 0x0600873E RID: 34622 RVA: 0x000422C6 File Offset: 0x000404C6
		' (set) Token: 0x0600873F RID: 34623 RVA: 0x000422D0 File Offset: 0x000404D0
		Friend Overridable Property Label83 As Label

		' Token: 0x170031F8 RID: 12792
		' (get) Token: 0x06008740 RID: 34624 RVA: 0x000422D9 File Offset: 0x000404D9
		' (set) Token: 0x06008741 RID: 34625 RVA: 0x000422E3 File Offset: 0x000404E3
		Friend Overridable Property Label84 As Label

		' Token: 0x170031F9 RID: 12793
		' (get) Token: 0x06008742 RID: 34626 RVA: 0x000422EC File Offset: 0x000404EC
		' (set) Token: 0x06008743 RID: 34627 RVA: 0x000422F6 File Offset: 0x000404F6
		Friend Overridable Property Label86 As Label

		' Token: 0x170031FA RID: 12794
		' (get) Token: 0x06008744 RID: 34628 RVA: 0x000422FF File Offset: 0x000404FF
		' (set) Token: 0x06008745 RID: 34629 RVA: 0x00042309 File Offset: 0x00040509
		Friend Overridable Property Label88 As Label

		' Token: 0x170031FB RID: 12795
		' (get) Token: 0x06008746 RID: 34630 RVA: 0x00042312 File Offset: 0x00040512
		' (set) Token: 0x06008747 RID: 34631 RVA: 0x0004231C File Offset: 0x0004051C
		Friend Overridable Property Label89 As Label

		' Token: 0x170031FC RID: 12796
		' (get) Token: 0x06008748 RID: 34632 RVA: 0x00042325 File Offset: 0x00040525
		' (set) Token: 0x06008749 RID: 34633 RVA: 0x0004232F File Offset: 0x0004052F
		Friend Overridable Property Label90 As Label

		' Token: 0x170031FD RID: 12797
		' (get) Token: 0x0600874A RID: 34634 RVA: 0x00042338 File Offset: 0x00040538
		' (set) Token: 0x0600874B RID: 34635 RVA: 0x00042342 File Offset: 0x00040542
		Friend Overridable Property Label91 As Label

		' Token: 0x170031FE RID: 12798
		' (get) Token: 0x0600874C RID: 34636 RVA: 0x0004234B File Offset: 0x0004054B
		' (set) Token: 0x0600874D RID: 34637 RVA: 0x00042355 File Offset: 0x00040555
		Friend Overridable Property Label92 As Label

		' Token: 0x170031FF RID: 12799
		' (get) Token: 0x0600874E RID: 34638 RVA: 0x0004235E File Offset: 0x0004055E
		' (set) Token: 0x0600874F RID: 34639 RVA: 0x00042368 File Offset: 0x00040568
		Friend Overridable Property Label93 As Label

		' Token: 0x17003200 RID: 12800
		' (get) Token: 0x06008750 RID: 34640 RVA: 0x00042371 File Offset: 0x00040571
		' (set) Token: 0x06008751 RID: 34641 RVA: 0x0004237B File Offset: 0x0004057B
		Friend Overridable Property Label94 As Label

		' Token: 0x17003201 RID: 12801
		' (get) Token: 0x06008752 RID: 34642 RVA: 0x00042384 File Offset: 0x00040584
		' (set) Token: 0x06008753 RID: 34643 RVA: 0x0004238E File Offset: 0x0004058E
		Friend Overridable Property Label95 As Label

		' Token: 0x17003202 RID: 12802
		' (get) Token: 0x06008754 RID: 34644 RVA: 0x00042397 File Offset: 0x00040597
		' (set) Token: 0x06008755 RID: 34645 RVA: 0x000423A1 File Offset: 0x000405A1
		Friend Overridable Property Label96 As Label

		' Token: 0x17003203 RID: 12803
		' (get) Token: 0x06008756 RID: 34646 RVA: 0x000423AA File Offset: 0x000405AA
		' (set) Token: 0x06008757 RID: 34647 RVA: 0x000423B4 File Offset: 0x000405B4
		Friend Overridable Property Label97 As Label

		' Token: 0x17003204 RID: 12804
		' (get) Token: 0x06008758 RID: 34648 RVA: 0x000423BD File Offset: 0x000405BD
		' (set) Token: 0x06008759 RID: 34649 RVA: 0x000423C7 File Offset: 0x000405C7
		Friend Overridable Property Label98 As Label

		' Token: 0x17003205 RID: 12805
		' (get) Token: 0x0600875A RID: 34650 RVA: 0x000423D0 File Offset: 0x000405D0
		' (set) Token: 0x0600875B RID: 34651 RVA: 0x000423DA File Offset: 0x000405DA
		Friend Overridable Property Label99 As Label

		' Token: 0x17003206 RID: 12806
		' (get) Token: 0x0600875C RID: 34652 RVA: 0x000423E3 File Offset: 0x000405E3
		' (set) Token: 0x0600875D RID: 34653 RVA: 0x000423ED File Offset: 0x000405ED
		Friend Overridable Property Label100 As Label

		' Token: 0x17003207 RID: 12807
		' (get) Token: 0x0600875E RID: 34654 RVA: 0x000423F6 File Offset: 0x000405F6
		' (set) Token: 0x0600875F RID: 34655 RVA: 0x00042400 File Offset: 0x00040600
		Friend Overridable Property Label101 As Label

		' Token: 0x17003208 RID: 12808
		' (get) Token: 0x06008760 RID: 34656 RVA: 0x00042409 File Offset: 0x00040609
		' (set) Token: 0x06008761 RID: 34657 RVA: 0x00042413 File Offset: 0x00040613
		Friend Overridable Property Label102 As Label

		' Token: 0x17003209 RID: 12809
		' (get) Token: 0x06008762 RID: 34658 RVA: 0x0004241C File Offset: 0x0004061C
		' (set) Token: 0x06008763 RID: 34659 RVA: 0x00042426 File Offset: 0x00040626
		Friend Overridable Property Label103 As Label

		' Token: 0x1700320A RID: 12810
		' (get) Token: 0x06008764 RID: 34660 RVA: 0x0004242F File Offset: 0x0004062F
		' (set) Token: 0x06008765 RID: 34661 RVA: 0x00042439 File Offset: 0x00040639
		Friend Overridable Property Label104 As Label

		' Token: 0x1700320B RID: 12811
		' (get) Token: 0x06008766 RID: 34662 RVA: 0x00042442 File Offset: 0x00040642
		' (set) Token: 0x06008767 RID: 34663 RVA: 0x0004244C File Offset: 0x0004064C
		Friend Overridable Property Label105 As Label

		' Token: 0x1700320C RID: 12812
		' (get) Token: 0x06008768 RID: 34664 RVA: 0x00042455 File Offset: 0x00040655
		' (set) Token: 0x06008769 RID: 34665 RVA: 0x0004245F File Offset: 0x0004065F
		Friend Overridable Property Label106 As Label

		' Token: 0x1700320D RID: 12813
		' (get) Token: 0x0600876A RID: 34666 RVA: 0x00042468 File Offset: 0x00040668
		' (set) Token: 0x0600876B RID: 34667 RVA: 0x00042472 File Offset: 0x00040672
		Friend Overridable Property Label107 As Label

		' Token: 0x1700320E RID: 12814
		' (get) Token: 0x0600876C RID: 34668 RVA: 0x0004247B File Offset: 0x0004067B
		' (set) Token: 0x0600876D RID: 34669 RVA: 0x00042485 File Offset: 0x00040685
		Friend Overridable Property Label108 As Label

		' Token: 0x1700320F RID: 12815
		' (get) Token: 0x0600876E RID: 34670 RVA: 0x0004248E File Offset: 0x0004068E
		' (set) Token: 0x0600876F RID: 34671 RVA: 0x00042498 File Offset: 0x00040698
		Friend Overridable Property Label109 As Label

		' Token: 0x17003210 RID: 12816
		' (get) Token: 0x06008770 RID: 34672 RVA: 0x000424A1 File Offset: 0x000406A1
		' (set) Token: 0x06008771 RID: 34673 RVA: 0x000424AB File Offset: 0x000406AB
		Friend Overridable Property Label110 As Label

		' Token: 0x17003211 RID: 12817
		' (get) Token: 0x06008772 RID: 34674 RVA: 0x000424B4 File Offset: 0x000406B4
		' (set) Token: 0x06008773 RID: 34675 RVA: 0x000424BE File Offset: 0x000406BE
		Friend Overridable Property Label112 As Label

		' Token: 0x17003212 RID: 12818
		' (get) Token: 0x06008774 RID: 34676 RVA: 0x000424C7 File Offset: 0x000406C7
		' (set) Token: 0x06008775 RID: 34677 RVA: 0x000424D1 File Offset: 0x000406D1
		Friend Overridable Property Label113 As Label

		' Token: 0x17003213 RID: 12819
		' (get) Token: 0x06008776 RID: 34678 RVA: 0x000424DA File Offset: 0x000406DA
		' (set) Token: 0x06008777 RID: 34679 RVA: 0x000424E4 File Offset: 0x000406E4
		Friend Overridable Property Label114 As Label

		' Token: 0x17003214 RID: 12820
		' (get) Token: 0x06008778 RID: 34680 RVA: 0x000424ED File Offset: 0x000406ED
		' (set) Token: 0x06008779 RID: 34681 RVA: 0x000424F7 File Offset: 0x000406F7
		Friend Overridable Property Label115 As Label

		' Token: 0x17003215 RID: 12821
		' (get) Token: 0x0600877A RID: 34682 RVA: 0x00042500 File Offset: 0x00040700
		' (set) Token: 0x0600877B RID: 34683 RVA: 0x0004250A File Offset: 0x0004070A
		Friend Overridable Property Label116 As Label

		' Token: 0x17003216 RID: 12822
		' (get) Token: 0x0600877C RID: 34684 RVA: 0x00042513 File Offset: 0x00040713
		' (set) Token: 0x0600877D RID: 34685 RVA: 0x0004251D File Offset: 0x0004071D
		Friend Overridable Property Label117 As Label

		' Token: 0x17003217 RID: 12823
		' (get) Token: 0x0600877E RID: 34686 RVA: 0x00042526 File Offset: 0x00040726
		' (set) Token: 0x0600877F RID: 34687 RVA: 0x00042530 File Offset: 0x00040730
		Friend Overridable Property Label118 As Label

		' Token: 0x17003218 RID: 12824
		' (get) Token: 0x06008780 RID: 34688 RVA: 0x00042539 File Offset: 0x00040739
		' (set) Token: 0x06008781 RID: 34689 RVA: 0x00042543 File Offset: 0x00040743
		Friend Overridable Property Label119 As Label

		' Token: 0x17003219 RID: 12825
		' (get) Token: 0x06008782 RID: 34690 RVA: 0x0004254C File Offset: 0x0004074C
		' (set) Token: 0x06008783 RID: 34691 RVA: 0x00042556 File Offset: 0x00040756
		Friend Overridable Property Label120 As Label

		' Token: 0x1700321A RID: 12826
		' (get) Token: 0x06008784 RID: 34692 RVA: 0x0004255F File Offset: 0x0004075F
		' (set) Token: 0x06008785 RID: 34693 RVA: 0x00042569 File Offset: 0x00040769
		Friend Overridable Property Label121 As Label

		' Token: 0x1700321B RID: 12827
		' (get) Token: 0x06008786 RID: 34694 RVA: 0x00042572 File Offset: 0x00040772
		' (set) Token: 0x06008787 RID: 34695 RVA: 0x0004257C File Offset: 0x0004077C
		Friend Overridable Property Label8 As Label

		' Token: 0x1700321C RID: 12828
		' (get) Token: 0x06008788 RID: 34696 RVA: 0x00042585 File Offset: 0x00040785
		' (set) Token: 0x06008789 RID: 34697 RVA: 0x0004258F File Offset: 0x0004078F
		Friend Overridable Property Label73 As Label

		' Token: 0x1700321D RID: 12829
		' (get) Token: 0x0600878A RID: 34698 RVA: 0x00042598 File Offset: 0x00040798
		' (set) Token: 0x0600878B RID: 34699 RVA: 0x000425A2 File Offset: 0x000407A2
		Friend Overridable Property Label71 As Label

		' Token: 0x1700321E RID: 12830
		' (get) Token: 0x0600878C RID: 34700 RVA: 0x000425AB File Offset: 0x000407AB
		' (set) Token: 0x0600878D RID: 34701 RVA: 0x000425B5 File Offset: 0x000407B5
		Friend Overridable Property Label76 As Label

		' Token: 0x1700321F RID: 12831
		' (get) Token: 0x0600878E RID: 34702 RVA: 0x000425BE File Offset: 0x000407BE
		' (set) Token: 0x0600878F RID: 34703 RVA: 0x000425C8 File Offset: 0x000407C8
		Friend Overridable Property Label54 As Label

		' Token: 0x17003220 RID: 12832
		' (get) Token: 0x06008790 RID: 34704 RVA: 0x000425D1 File Offset: 0x000407D1
		' (set) Token: 0x06008791 RID: 34705 RVA: 0x000425DB File Offset: 0x000407DB
		Friend Overridable Property Label75 As Label

		' Token: 0x17003221 RID: 12833
		' (get) Token: 0x06008792 RID: 34706 RVA: 0x000425E4 File Offset: 0x000407E4
		' (set) Token: 0x06008793 RID: 34707 RVA: 0x000425EE File Offset: 0x000407EE
		Friend Overridable Property Label44 As Label

		' Token: 0x17003222 RID: 12834
		' (get) Token: 0x06008794 RID: 34708 RVA: 0x000425F7 File Offset: 0x000407F7
		' (set) Token: 0x06008795 RID: 34709 RVA: 0x00042601 File Offset: 0x00040801
		Friend Overridable Property Label21 As Label

		' Token: 0x17003223 RID: 12835
		' (get) Token: 0x06008796 RID: 34710 RVA: 0x0004260A File Offset: 0x0004080A
		' (set) Token: 0x06008797 RID: 34711 RVA: 0x00042614 File Offset: 0x00040814
		Friend Overridable Property Label48 As Label

		' Token: 0x17003224 RID: 12836
		' (get) Token: 0x06008798 RID: 34712 RVA: 0x0004261D File Offset: 0x0004081D
		' (set) Token: 0x06008799 RID: 34713 RVA: 0x00042627 File Offset: 0x00040827
		Friend Overridable Property Label49 As Label

		' Token: 0x17003225 RID: 12837
		' (get) Token: 0x0600879A RID: 34714 RVA: 0x00042630 File Offset: 0x00040830
		' (set) Token: 0x0600879B RID: 34715 RVA: 0x0004263A File Offset: 0x0004083A
		Friend Overridable Property Label4 As Label

		' Token: 0x17003226 RID: 12838
		' (get) Token: 0x0600879C RID: 34716 RVA: 0x00042643 File Offset: 0x00040843
		' (set) Token: 0x0600879D RID: 34717 RVA: 0x0004264D File Offset: 0x0004084D
		Friend Overridable Property Label56 As Label

		' Token: 0x17003227 RID: 12839
		' (get) Token: 0x0600879E RID: 34718 RVA: 0x00042656 File Offset: 0x00040856
		' (set) Token: 0x0600879F RID: 34719 RVA: 0x00042660 File Offset: 0x00040860
		Friend Overridable Property Label70 As Label

		' Token: 0x17003228 RID: 12840
		' (get) Token: 0x060087A0 RID: 34720 RVA: 0x00042669 File Offset: 0x00040869
		' (set) Token: 0x060087A1 RID: 34721 RVA: 0x00042673 File Offset: 0x00040873
		Friend Overridable Property Label15 As Label

		' Token: 0x17003229 RID: 12841
		' (get) Token: 0x060087A2 RID: 34722 RVA: 0x0004267C File Offset: 0x0004087C
		' (set) Token: 0x060087A3 RID: 34723 RVA: 0x00042686 File Offset: 0x00040886
		Friend Overridable Property Label69 As Label

		' Token: 0x1700322A RID: 12842
		' (get) Token: 0x060087A4 RID: 34724 RVA: 0x0004268F File Offset: 0x0004088F
		' (set) Token: 0x060087A5 RID: 34725 RVA: 0x00042699 File Offset: 0x00040899
		Friend Overridable Property lblAltUnit As Label

		' Token: 0x1700322B RID: 12843
		' (get) Token: 0x060087A6 RID: 34726 RVA: 0x000426A2 File Offset: 0x000408A2
		' (set) Token: 0x060087A7 RID: 34727 RVA: 0x000426AC File Offset: 0x000408AC
		Friend Overridable Property lblAltValue As Label

		' Token: 0x1700322C RID: 12844
		' (get) Token: 0x060087A8 RID: 34728 RVA: 0x000426B5 File Offset: 0x000408B5
		' (set) Token: 0x060087A9 RID: 34729 RVA: 0x000426BF File Offset: 0x000408BF
		Friend Overridable Property Label72 As Label

		' Token: 0x1700322D RID: 12845
		' (get) Token: 0x060087AA RID: 34730 RVA: 0x000426C8 File Offset: 0x000408C8
		' (set) Token: 0x060087AB RID: 34731 RVA: 0x000426D2 File Offset: 0x000408D2
		Friend Overridable Property Label57 As Label

		' Token: 0x1700322E RID: 12846
		' (get) Token: 0x060087AC RID: 34732 RVA: 0x000426DB File Offset: 0x000408DB
		' (set) Token: 0x060087AD RID: 34733 RVA: 0x000426E5 File Offset: 0x000408E5
		Friend Overridable Property lblQty_S As Label

		' Token: 0x1700322F RID: 12847
		' (get) Token: 0x060087AE RID: 34734 RVA: 0x000426EE File Offset: 0x000408EE
		' (set) Token: 0x060087AF RID: 34735 RVA: 0x000426F8 File Offset: 0x000408F8
		Friend Overridable Property Label6 As Label

		' Token: 0x17003230 RID: 12848
		' (get) Token: 0x060087B0 RID: 34736 RVA: 0x00042701 File Offset: 0x00040901
		' (set) Token: 0x060087B1 RID: 34737 RVA: 0x0004270B File Offset: 0x0004090B
		Friend Overridable Property Label53 As Label

		' Token: 0x17003231 RID: 12849
		' (get) Token: 0x060087B2 RID: 34738 RVA: 0x00042714 File Offset: 0x00040914
		' (set) Token: 0x060087B3 RID: 34739 RVA: 0x0004271E File Offset: 0x0004091E
		Friend Overridable Property Label46 As Label

		' Token: 0x17003232 RID: 12850
		' (get) Token: 0x060087B4 RID: 34740 RVA: 0x00042727 File Offset: 0x00040927
		' (set) Token: 0x060087B5 RID: 34741 RVA: 0x00042731 File Offset: 0x00040931
		Friend Overridable Property Label66 As Label

		' Token: 0x17003233 RID: 12851
		' (get) Token: 0x060087B6 RID: 34742 RVA: 0x0004273A File Offset: 0x0004093A
		' (set) Token: 0x060087B7 RID: 34743 RVA: 0x00042744 File Offset: 0x00040944
		Friend Overridable Property Label45 As Label

		' Token: 0x17003234 RID: 12852
		' (get) Token: 0x060087B8 RID: 34744 RVA: 0x0004274D File Offset: 0x0004094D
		' (set) Token: 0x060087B9 RID: 34745 RVA: 0x00042757 File Offset: 0x00040957
		Friend Overridable Property Label65 As Label

		' Token: 0x17003235 RID: 12853
		' (get) Token: 0x060087BA RID: 34746 RVA: 0x00042760 File Offset: 0x00040960
		' (set) Token: 0x060087BB RID: 34747 RVA: 0x0004276A File Offset: 0x0004096A
		Friend Overridable Property Label64 As Label

		' Token: 0x17003236 RID: 12854
		' (get) Token: 0x060087BC RID: 34748 RVA: 0x00042773 File Offset: 0x00040973
		' (set) Token: 0x060087BD RID: 34749 RVA: 0x0004277D File Offset: 0x0004097D
		Friend Overridable Property Label63 As Label

		' Token: 0x17003237 RID: 12855
		' (get) Token: 0x060087BE RID: 34750 RVA: 0x00042786 File Offset: 0x00040986
		' (set) Token: 0x060087BF RID: 34751 RVA: 0x00042790 File Offset: 0x00040990
		Friend Overridable Property Label52 As Label

		' Token: 0x17003238 RID: 12856
		' (get) Token: 0x060087C0 RID: 34752 RVA: 0x00042799 File Offset: 0x00040999
		' (set) Token: 0x060087C1 RID: 34753 RVA: 0x000427A3 File Offset: 0x000409A3
		Friend Overridable Property Label55 As Label

		' Token: 0x17003239 RID: 12857
		' (get) Token: 0x060087C2 RID: 34754 RVA: 0x000427AC File Offset: 0x000409AC
		' (set) Token: 0x060087C3 RID: 34755 RVA: 0x000427B6 File Offset: 0x000409B6
		Friend Overridable Property Label62 As Label

		' Token: 0x1700323A RID: 12858
		' (get) Token: 0x060087C4 RID: 34756 RVA: 0x000427BF File Offset: 0x000409BF
		' (set) Token: 0x060087C5 RID: 34757 RVA: 0x000427C9 File Offset: 0x000409C9
		Friend Overridable Property Label33 As Label

		' Token: 0x1700323B RID: 12859
		' (get) Token: 0x060087C6 RID: 34758 RVA: 0x000427D2 File Offset: 0x000409D2
		' (set) Token: 0x060087C7 RID: 34759 RVA: 0x000427DC File Offset: 0x000409DC
		Friend Overridable Property Label22 As Label

		' Token: 0x1700323C RID: 12860
		' (get) Token: 0x060087C8 RID: 34760 RVA: 0x000427E5 File Offset: 0x000409E5
		' (set) Token: 0x060087C9 RID: 34761 RVA: 0x000427EF File Offset: 0x000409EF
		Friend Overridable Property Label25 As Label

		' Token: 0x1700323D RID: 12861
		' (get) Token: 0x060087CA RID: 34762 RVA: 0x000427F8 File Offset: 0x000409F8
		' (set) Token: 0x060087CB RID: 34763 RVA: 0x00042802 File Offset: 0x00040A02
		Friend Overridable Property Label28 As Label

		' Token: 0x1700323E RID: 12862
		' (get) Token: 0x060087CC RID: 34764 RVA: 0x0004280B File Offset: 0x00040A0B
		' (set) Token: 0x060087CD RID: 34765 RVA: 0x00042815 File Offset: 0x00040A15
		Friend Overridable Property Label42 As Label

		' Token: 0x1700323F RID: 12863
		' (get) Token: 0x060087CE RID: 34766 RVA: 0x0004281E File Offset: 0x00040A1E
		' (set) Token: 0x060087CF RID: 34767 RVA: 0x00042828 File Offset: 0x00040A28
		Friend Overridable Property Label34 As Label

		' Token: 0x17003240 RID: 12864
		' (get) Token: 0x060087D0 RID: 34768 RVA: 0x00042831 File Offset: 0x00040A31
		' (set) Token: 0x060087D1 RID: 34769 RVA: 0x0004283B File Offset: 0x00040A3B
		Friend Overridable Property Label9 As Label

		' Token: 0x17003241 RID: 12865
		' (get) Token: 0x060087D2 RID: 34770 RVA: 0x00042844 File Offset: 0x00040A44
		' (set) Token: 0x060087D3 RID: 34771 RVA: 0x0004284E File Offset: 0x00040A4E
		Friend Overridable Property Label41 As Label

		' Token: 0x17003242 RID: 12866
		' (get) Token: 0x060087D4 RID: 34772 RVA: 0x00042857 File Offset: 0x00040A57
		' (set) Token: 0x060087D5 RID: 34773 RVA: 0x00042861 File Offset: 0x00040A61
		Friend Overridable Property Label35 As Label

		' Token: 0x17003243 RID: 12867
		' (get) Token: 0x060087D6 RID: 34774 RVA: 0x0004286A File Offset: 0x00040A6A
		' (set) Token: 0x060087D7 RID: 34775 RVA: 0x00042874 File Offset: 0x00040A74
		Friend Overridable Property Panel9 As Panel

		' Token: 0x17003244 RID: 12868
		' (get) Token: 0x060087D8 RID: 34776 RVA: 0x0004287D File Offset: 0x00040A7D
		' (set) Token: 0x060087D9 RID: 34777 RVA: 0x0063B838 File Offset: 0x00639A38
		Private _Button38 As Button
		Friend Overridable Property Button38 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button38
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button38_Click
				Dim button As Button = Me._Button38
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button38 = value
				button = Me._Button38
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003245 RID: 12869
		' (get) Token: 0x060087DA RID: 34778 RVA: 0x00042887 File Offset: 0x00040A87
		' (set) Token: 0x060087DB RID: 34779 RVA: 0x0063B87C File Offset: 0x00639A7C
		Private _GelButton2 As Button
		Friend Overridable Property GelButton2 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim button As Button = Me._GelButton2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton2 = value
				button = Me._GelButton2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003246 RID: 12870
		' (get) Token: 0x060087DC RID: 34780 RVA: 0x00042891 File Offset: 0x00040A91
		' (set) Token: 0x060087DD RID: 34781 RVA: 0x0063B8C0 File Offset: 0x00639AC0
		Private _btnGetdata As Button
		Friend Overridable Property btnGetdata As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetdata
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetdata_Click
				Dim button As Button = Me._btnGetdata
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetdata = value
				button = Me._btnGetdata
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003247 RID: 12871
		' (get) Token: 0x060087DE RID: 34782 RVA: 0x0004289B File Offset: 0x00040A9B
		' (set) Token: 0x060087DF RID: 34783 RVA: 0x0063B904 File Offset: 0x00639B04
		Private _btnProductSeting As Button
		Friend Overridable Property btnProductSeting As Button
			<CompilerGenerated()>
			Get
				Return Me._btnProductSeting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductSeting_Click
				Dim button As Button = Me._btnProductSeting
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnProductSeting = value
				button = Me._btnProductSeting
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003248 RID: 12872
		' (get) Token: 0x060087E0 RID: 34784 RVA: 0x000428A5 File Offset: 0x00040AA5
		' (set) Token: 0x060087E1 RID: 34785 RVA: 0x000428AF File Offset: 0x00040AAF
		Friend Overridable Property flpItems_BV As FlowLayoutPanel

		' Token: 0x17003249 RID: 12873
		' (get) Token: 0x060087E2 RID: 34786 RVA: 0x000428B8 File Offset: 0x00040AB8
		' (set) Token: 0x060087E3 RID: 34787 RVA: 0x000428C2 File Offset: 0x00040AC2
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x1700324A RID: 12874
		' (get) Token: 0x060087E4 RID: 34788 RVA: 0x000428CB File Offset: 0x00040ACB
		' (set) Token: 0x060087E5 RID: 34789 RVA: 0x000428D5 File Offset: 0x00040AD5
		Friend Overridable Property flpItemsCategory As FlowLayoutPanel

		' Token: 0x1700324B RID: 12875
		' (get) Token: 0x060087E6 RID: 34790 RVA: 0x000428DE File Offset: 0x00040ADE
		' (set) Token: 0x060087E7 RID: 34791 RVA: 0x0063B948 File Offset: 0x00639B48
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700324C RID: 12876
		' (get) Token: 0x060087E8 RID: 34792 RVA: 0x000428E8 File Offset: 0x00040AE8
		' (set) Token: 0x060087E9 RID: 34793 RVA: 0x0063B98C File Offset: 0x00639B8C
		Private _Button10 As Button
		Friend Overridable Property Button10 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button10_Click
				Dim button As Button = Me._Button10
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button10 = value
				button = Me._Button10
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700324D RID: 12877
		' (get) Token: 0x060087EA RID: 34794 RVA: 0x000428F2 File Offset: 0x00040AF2
		' (set) Token: 0x060087EB RID: 34795 RVA: 0x000428FC File Offset: 0x00040AFC
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700324E RID: 12878
		' (get) Token: 0x060087EC RID: 34796 RVA: 0x00042905 File Offset: 0x00040B05
		' (set) Token: 0x060087ED RID: 34797 RVA: 0x0004290F File Offset: 0x00040B0F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700324F RID: 12879
		' (get) Token: 0x060087EE RID: 34798 RVA: 0x00042918 File Offset: 0x00040B18
		' (set) Token: 0x060087EF RID: 34799 RVA: 0x00042922 File Offset: 0x00040B22
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17003250 RID: 12880
		' (get) Token: 0x060087F0 RID: 34800 RVA: 0x0004292B File Offset: 0x00040B2B
		' (set) Token: 0x060087F1 RID: 34801 RVA: 0x00042935 File Offset: 0x00040B35
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17003251 RID: 12881
		' (get) Token: 0x060087F2 RID: 34802 RVA: 0x0004293E File Offset: 0x00040B3E
		' (set) Token: 0x060087F3 RID: 34803 RVA: 0x00042948 File Offset: 0x00040B48
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17003252 RID: 12882
		' (get) Token: 0x060087F4 RID: 34804 RVA: 0x00042951 File Offset: 0x00040B51
		' (set) Token: 0x060087F5 RID: 34805 RVA: 0x0004295B File Offset: 0x00040B5B
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17003253 RID: 12883
		' (get) Token: 0x060087F6 RID: 34806 RVA: 0x00042964 File Offset: 0x00040B64
		' (set) Token: 0x060087F7 RID: 34807 RVA: 0x0004296E File Offset: 0x00040B6E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17003254 RID: 12884
		' (get) Token: 0x060087F8 RID: 34808 RVA: 0x00042977 File Offset: 0x00040B77
		' (set) Token: 0x060087F9 RID: 34809 RVA: 0x00042981 File Offset: 0x00040B81
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17003255 RID: 12885
		' (get) Token: 0x060087FA RID: 34810 RVA: 0x0004298A File Offset: 0x00040B8A
		' (set) Token: 0x060087FB RID: 34811 RVA: 0x00042994 File Offset: 0x00040B94
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17003256 RID: 12886
		' (get) Token: 0x060087FC RID: 34812 RVA: 0x0004299D File Offset: 0x00040B9D
		' (set) Token: 0x060087FD RID: 34813 RVA: 0x000429A7 File Offset: 0x00040BA7
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17003257 RID: 12887
		' (get) Token: 0x060087FE RID: 34814 RVA: 0x000429B0 File Offset: 0x00040BB0
		' (set) Token: 0x060087FF RID: 34815 RVA: 0x000429BA File Offset: 0x00040BBA
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17003258 RID: 12888
		' (get) Token: 0x06008800 RID: 34816 RVA: 0x000429C3 File Offset: 0x00040BC3
		' (set) Token: 0x06008801 RID: 34817 RVA: 0x000429CD File Offset: 0x00040BCD
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17003259 RID: 12889
		' (get) Token: 0x06008802 RID: 34818 RVA: 0x000429D6 File Offset: 0x00040BD6
		' (set) Token: 0x06008803 RID: 34819 RVA: 0x000429E0 File Offset: 0x00040BE0
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x1700325A RID: 12890
		' (get) Token: 0x06008804 RID: 34820 RVA: 0x000429E9 File Offset: 0x00040BE9
		' (set) Token: 0x06008805 RID: 34821 RVA: 0x000429F3 File Offset: 0x00040BF3
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700325B RID: 12891
		' (get) Token: 0x06008806 RID: 34822 RVA: 0x000429FC File Offset: 0x00040BFC
		' (set) Token: 0x06008807 RID: 34823 RVA: 0x00042A06 File Offset: 0x00040C06
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700325C RID: 12892
		' (get) Token: 0x06008808 RID: 34824 RVA: 0x00042A0F File Offset: 0x00040C0F
		' (set) Token: 0x06008809 RID: 34825 RVA: 0x00042A19 File Offset: 0x00040C19
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700325D RID: 12893
		' (get) Token: 0x0600880A RID: 34826 RVA: 0x00042A22 File Offset: 0x00040C22
		' (set) Token: 0x0600880B RID: 34827 RVA: 0x00042A2C File Offset: 0x00040C2C
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700325E RID: 12894
		' (get) Token: 0x0600880C RID: 34828 RVA: 0x00042A35 File Offset: 0x00040C35
		' (set) Token: 0x0600880D RID: 34829 RVA: 0x00042A3F File Offset: 0x00040C3F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x1700325F RID: 12895
		' (get) Token: 0x0600880E RID: 34830 RVA: 0x00042A48 File Offset: 0x00040C48
		' (set) Token: 0x0600880F RID: 34831 RVA: 0x00042A52 File Offset: 0x00040C52
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17003260 RID: 12896
		' (get) Token: 0x06008810 RID: 34832 RVA: 0x00042A5B File Offset: 0x00040C5B
		' (set) Token: 0x06008811 RID: 34833 RVA: 0x00042A65 File Offset: 0x00040C65
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17003261 RID: 12897
		' (get) Token: 0x06008812 RID: 34834 RVA: 0x00042A6E File Offset: 0x00040C6E
		' (set) Token: 0x06008813 RID: 34835 RVA: 0x00042A78 File Offset: 0x00040C78
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17003262 RID: 12898
		' (get) Token: 0x06008814 RID: 34836 RVA: 0x00042A81 File Offset: 0x00040C81
		' (set) Token: 0x06008815 RID: 34837 RVA: 0x00042A8B File Offset: 0x00040C8B
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17003263 RID: 12899
		' (get) Token: 0x06008816 RID: 34838 RVA: 0x00042A94 File Offset: 0x00040C94
		' (set) Token: 0x06008817 RID: 34839 RVA: 0x00042A9E File Offset: 0x00040C9E
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17003264 RID: 12900
		' (get) Token: 0x06008818 RID: 34840 RVA: 0x00042AA7 File Offset: 0x00040CA7
		' (set) Token: 0x06008819 RID: 34841 RVA: 0x00042AB1 File Offset: 0x00040CB1
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17003265 RID: 12901
		' (get) Token: 0x0600881A RID: 34842 RVA: 0x00042ABA File Offset: 0x00040CBA
		' (set) Token: 0x0600881B RID: 34843 RVA: 0x00042AC4 File Offset: 0x00040CC4
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17003266 RID: 12902
		' (get) Token: 0x0600881C RID: 34844 RVA: 0x00042ACD File Offset: 0x00040CCD
		' (set) Token: 0x0600881D RID: 34845 RVA: 0x00042AD7 File Offset: 0x00040CD7
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17003267 RID: 12903
		' (get) Token: 0x0600881E RID: 34846 RVA: 0x00042AE0 File Offset: 0x00040CE0
		' (set) Token: 0x0600881F RID: 34847 RVA: 0x00042AEA File Offset: 0x00040CEA
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17003268 RID: 12904
		' (get) Token: 0x06008820 RID: 34848 RVA: 0x00042AF3 File Offset: 0x00040CF3
		' (set) Token: 0x06008821 RID: 34849 RVA: 0x00042AFD File Offset: 0x00040CFD
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17003269 RID: 12905
		' (get) Token: 0x06008822 RID: 34850 RVA: 0x00042B06 File Offset: 0x00040D06
		' (set) Token: 0x06008823 RID: 34851 RVA: 0x00042B10 File Offset: 0x00040D10
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x1700326A RID: 12906
		' (get) Token: 0x06008824 RID: 34852 RVA: 0x00042B19 File Offset: 0x00040D19
		' (set) Token: 0x06008825 RID: 34853 RVA: 0x00042B23 File Offset: 0x00040D23
		Friend Overridable Property Column35 As DataGridViewTextBoxColumn

		' Token: 0x1700326B RID: 12907
		' (get) Token: 0x06008826 RID: 34854 RVA: 0x00042B2C File Offset: 0x00040D2C
		' (set) Token: 0x06008827 RID: 34855 RVA: 0x00042B36 File Offset: 0x00040D36
		Friend Overridable Property Column36 As DataGridViewTextBoxColumn

		' Token: 0x1700326C RID: 12908
		' (get) Token: 0x06008828 RID: 34856 RVA: 0x00042B3F File Offset: 0x00040D3F
		' (set) Token: 0x06008829 RID: 34857 RVA: 0x00042B49 File Offset: 0x00040D49
		Friend Overridable Property Column37 As DataGridViewTextBoxColumn

		' Token: 0x1700326D RID: 12909
		' (get) Token: 0x0600882A RID: 34858 RVA: 0x00042B52 File Offset: 0x00040D52
		' (set) Token: 0x0600882B RID: 34859 RVA: 0x00042B5C File Offset: 0x00040D5C
		Friend Overridable Property Column38 As DataGridViewTextBoxColumn

		' Token: 0x1700326E RID: 12910
		' (get) Token: 0x0600882C RID: 34860 RVA: 0x00042B65 File Offset: 0x00040D65
		' (set) Token: 0x0600882D RID: 34861 RVA: 0x00042B6F File Offset: 0x00040D6F
		Friend Overridable Property Column40 As DataGridViewTextBoxColumn

		' Token: 0x1700326F RID: 12911
		' (get) Token: 0x0600882E RID: 34862 RVA: 0x00042B78 File Offset: 0x00040D78
		' (set) Token: 0x0600882F RID: 34863 RVA: 0x00042B82 File Offset: 0x00040D82
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x17003270 RID: 12912
		' (get) Token: 0x06008830 RID: 34864 RVA: 0x00042B8B File Offset: 0x00040D8B
		' (set) Token: 0x06008831 RID: 34865 RVA: 0x00042B95 File Offset: 0x00040D95
		Friend Overridable Property Column49 As DataGridViewTextBoxColumn

		' Token: 0x17003271 RID: 12913
		' (get) Token: 0x06008832 RID: 34866 RVA: 0x00042B9E File Offset: 0x00040D9E
		' (set) Token: 0x06008833 RID: 34867 RVA: 0x00042BA8 File Offset: 0x00040DA8
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x17003272 RID: 12914
		' (get) Token: 0x06008834 RID: 34868 RVA: 0x00042BB1 File Offset: 0x00040DB1
		' (set) Token: 0x06008835 RID: 34869 RVA: 0x00042BBB File Offset: 0x00040DBB
		Friend Overridable Property variant_id As DataGridViewTextBoxColumn

		' Token: 0x17003273 RID: 12915
		' (get) Token: 0x06008836 RID: 34870 RVA: 0x00042BC4 File Offset: 0x00040DC4
		' (set) Token: 0x06008837 RID: 34871 RVA: 0x00042BCE File Offset: 0x00040DCE
		Friend Overridable Property btnVariant As DataGridViewButtonColumn

		' Token: 0x17003274 RID: 12916
		' (get) Token: 0x06008838 RID: 34872 RVA: 0x00042BD7 File Offset: 0x00040DD7
		' (set) Token: 0x06008839 RID: 34873 RVA: 0x00042BE1 File Offset: 0x00040DE1
		Friend Overridable Property serial_no As DataGridViewTextBoxColumn

		' Token: 0x17003275 RID: 12917
		' (get) Token: 0x0600883A RID: 34874 RVA: 0x00042BEA File Offset: 0x00040DEA
		' (set) Token: 0x0600883B RID: 34875 RVA: 0x00042BF4 File Offset: 0x00040DF4
		Friend Overridable Property btnSerial As DataGridViewButtonColumn

		' Token: 0x17003276 RID: 12918
		' (get) Token: 0x0600883C RID: 34876 RVA: 0x00042BFD File Offset: 0x00040DFD
		' (set) Token: 0x0600883D RID: 34877 RVA: 0x0063B9D0 File Offset: 0x00639BD0
		Private _BtnPurchaseWiseMerge As GelButton
		Friend Overridable Property BtnPurchaseWiseMerge As GelButton
			<CompilerGenerated()>
			Get
				Return Me._BtnPurchaseWiseMerge
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.BtnPurchaseWiseMerge_Click
				Dim gelButton As GelButton = Me._BtnPurchaseWiseMerge
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._BtnPurchaseWiseMerge = value
				gelButton = Me._BtnPurchaseWiseMerge
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003277 RID: 12919
		' (get) Token: 0x0600883E RID: 34878 RVA: 0x00042C07 File Offset: 0x00040E07
		' (set) Token: 0x0600883F RID: 34879 RVA: 0x0063BA14 File Offset: 0x00639C14
		Private _btnunhold As Button
		Friend Overridable Property btnunhold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnunhold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnunhold_Click
				Dim button As Button = Me._btnunhold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnunhold = value
				button = Me._btnunhold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003278 RID: 12920
		' (get) Token: 0x06008840 RID: 34880 RVA: 0x00042C11 File Offset: 0x00040E11
		' (set) Token: 0x06008841 RID: 34881 RVA: 0x0063BA58 File Offset: 0x00639C58
		Private _btnHold As Button
		Friend Overridable Property btnHold As Button
			<CompilerGenerated()>
			Get
				Return Me._btnHold
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnHold_Click
				Dim button As Button = Me._btnHold
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnHold = value
				button = Me._btnHold
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17003279 RID: 12921
		' (get) Token: 0x06008842 RID: 34882 RVA: 0x00042C1B File Offset: 0x00040E1B
		' (set) Token: 0x06008843 RID: 34883 RVA: 0x00042C25 File Offset: 0x00040E25
		Friend Overridable Property txtHold As TextBox

		' Token: 0x1700327A RID: 12922
		' (get) Token: 0x06008844 RID: 34884 RVA: 0x00042C2E File Offset: 0x00040E2E
		' (set) Token: 0x06008845 RID: 34885 RVA: 0x00042C38 File Offset: 0x00040E38
		Friend Overridable Property txtTill_Id As TextBox

		' Token: 0x1700327B RID: 12923
		' (get) Token: 0x06008846 RID: 34886 RVA: 0x00042C41 File Offset: 0x00040E41
		' (set) Token: 0x06008847 RID: 34887 RVA: 0x00042C4B File Offset: 0x00040E4B
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x1700327C RID: 12924
		' (get) Token: 0x06008848 RID: 34888 RVA: 0x00042C54 File Offset: 0x00040E54
		' (set) Token: 0x06008849 RID: 34889 RVA: 0x00042C5E File Offset: 0x00040E5E
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x1700327D RID: 12925
		' (get) Token: 0x0600884A RID: 34890 RVA: 0x00042C67 File Offset: 0x00040E67
		' (set) Token: 0x0600884B RID: 34891 RVA: 0x00042C71 File Offset: 0x00040E71
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x1700327E RID: 12926
		' (get) Token: 0x0600884C RID: 34892 RVA: 0x00042C7A File Offset: 0x00040E7A
		' (set) Token: 0x0600884D RID: 34893 RVA: 0x00042C84 File Offset: 0x00040E84
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x1700327F RID: 12927
		' (get) Token: 0x0600884E RID: 34894 RVA: 0x00042C8D File Offset: 0x00040E8D
		' (set) Token: 0x0600884F RID: 34895 RVA: 0x00042C97 File Offset: 0x00040E97
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17003280 RID: 12928
		' (get) Token: 0x06008850 RID: 34896 RVA: 0x00042CA0 File Offset: 0x00040EA0
		' (set) Token: 0x06008851 RID: 34897 RVA: 0x00042CAA File Offset: 0x00040EAA
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17003281 RID: 12929
		' (get) Token: 0x06008852 RID: 34898 RVA: 0x00042CB3 File Offset: 0x00040EB3
		' (set) Token: 0x06008853 RID: 34899 RVA: 0x00042CBD File Offset: 0x00040EBD
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17003282 RID: 12930
		' (get) Token: 0x06008854 RID: 34900 RVA: 0x00042CC6 File Offset: 0x00040EC6
		' (set) Token: 0x06008855 RID: 34901 RVA: 0x00042CD0 File Offset: 0x00040ED0
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17003283 RID: 12931
		' (get) Token: 0x06008856 RID: 34902 RVA: 0x00042CD9 File Offset: 0x00040ED9
		' (set) Token: 0x06008857 RID: 34903 RVA: 0x00042CE3 File Offset: 0x00040EE3
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17003284 RID: 12932
		' (get) Token: 0x06008858 RID: 34904 RVA: 0x00042CEC File Offset: 0x00040EEC
		' (set) Token: 0x06008859 RID: 34905 RVA: 0x00042CF6 File Offset: 0x00040EF6
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17003285 RID: 12933
		' (get) Token: 0x0600885A RID: 34906 RVA: 0x00042CFF File Offset: 0x00040EFF
		' (set) Token: 0x0600885B RID: 34907 RVA: 0x00042D09 File Offset: 0x00040F09
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17003286 RID: 12934
		' (get) Token: 0x0600885C RID: 34908 RVA: 0x00042D12 File Offset: 0x00040F12
		' (set) Token: 0x0600885D RID: 34909 RVA: 0x00042D1C File Offset: 0x00040F1C
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x17003287 RID: 12935
		' (get) Token: 0x0600885E RID: 34910 RVA: 0x00042D25 File Offset: 0x00040F25
		' (set) Token: 0x0600885F RID: 34911 RVA: 0x00042D2F File Offset: 0x00040F2F
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x17003288 RID: 12936
		' (get) Token: 0x06008860 RID: 34912 RVA: 0x00042D38 File Offset: 0x00040F38
		' (set) Token: 0x06008861 RID: 34913 RVA: 0x00042D42 File Offset: 0x00040F42
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x17003289 RID: 12937
		' (get) Token: 0x06008862 RID: 34914 RVA: 0x00042D4B File Offset: 0x00040F4B
		' (set) Token: 0x06008863 RID: 34915 RVA: 0x00042D55 File Offset: 0x00040F55
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x1700328A RID: 12938
		' (get) Token: 0x06008864 RID: 34916 RVA: 0x00042D5E File Offset: 0x00040F5E
		' (set) Token: 0x06008865 RID: 34917 RVA: 0x00042D68 File Offset: 0x00040F68
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x1700328B RID: 12939
		' (get) Token: 0x06008866 RID: 34918 RVA: 0x00042D71 File Offset: 0x00040F71
		' (set) Token: 0x06008867 RID: 34919 RVA: 0x00042D7B File Offset: 0x00040F7B
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x1700328C RID: 12940
		' (get) Token: 0x06008868 RID: 34920 RVA: 0x00042D84 File Offset: 0x00040F84
		' (set) Token: 0x06008869 RID: 34921 RVA: 0x00042D8E File Offset: 0x00040F8E
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x1700328D RID: 12941
		' (get) Token: 0x0600886A RID: 34922 RVA: 0x00042D97 File Offset: 0x00040F97
		' (set) Token: 0x0600886B RID: 34923 RVA: 0x00042DA1 File Offset: 0x00040FA1
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x1700328E RID: 12942
		' (get) Token: 0x0600886C RID: 34924 RVA: 0x00042DAA File Offset: 0x00040FAA
		' (set) Token: 0x0600886D RID: 34925 RVA: 0x00042DB4 File Offset: 0x00040FB4
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x1700328F RID: 12943
		' (get) Token: 0x0600886E RID: 34926 RVA: 0x00042DBD File Offset: 0x00040FBD
		' (set) Token: 0x0600886F RID: 34927 RVA: 0x00042DC7 File Offset: 0x00040FC7
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17003290 RID: 12944
		' (get) Token: 0x06008870 RID: 34928 RVA: 0x00042DD0 File Offset: 0x00040FD0
		' (set) Token: 0x06008871 RID: 34929 RVA: 0x00042DDA File Offset: 0x00040FDA
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17003291 RID: 12945
		' (get) Token: 0x06008872 RID: 34930 RVA: 0x00042DE3 File Offset: 0x00040FE3
		' (set) Token: 0x06008873 RID: 34931 RVA: 0x00042DED File Offset: 0x00040FED
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17003292 RID: 12946
		' (get) Token: 0x06008874 RID: 34932 RVA: 0x00042DF6 File Offset: 0x00040FF6
		' (set) Token: 0x06008875 RID: 34933 RVA: 0x00042E00 File Offset: 0x00041000
		Friend Overridable Property Column39 As DataGridViewTextBoxColumn

		' Token: 0x17003293 RID: 12947
		' (get) Token: 0x06008876 RID: 34934 RVA: 0x00042E09 File Offset: 0x00041009
		' (set) Token: 0x06008877 RID: 34935 RVA: 0x00042E13 File Offset: 0x00041013
		Friend Overridable Property Column41 As DataGridViewTextBoxColumn

		' Token: 0x17003294 RID: 12948
		' (get) Token: 0x06008878 RID: 34936 RVA: 0x00042E1C File Offset: 0x0004101C
		' (set) Token: 0x06008879 RID: 34937 RVA: 0x00042E26 File Offset: 0x00041026
		Friend Overridable Property Column42 As DataGridViewTextBoxColumn

		' Token: 0x17003295 RID: 12949
		' (get) Token: 0x0600887A RID: 34938 RVA: 0x00042E2F File Offset: 0x0004102F
		' (set) Token: 0x0600887B RID: 34939 RVA: 0x00042E39 File Offset: 0x00041039
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x17003296 RID: 12950
		' (get) Token: 0x0600887C RID: 34940 RVA: 0x00042E42 File Offset: 0x00041042
		' (set) Token: 0x0600887D RID: 34941 RVA: 0x00042E4C File Offset: 0x0004104C
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x17003297 RID: 12951
		' (get) Token: 0x0600887E RID: 34942 RVA: 0x00042E55 File Offset: 0x00041055
		' (set) Token: 0x0600887F RID: 34943 RVA: 0x00042E5F File Offset: 0x0004105F
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x17003298 RID: 12952
		' (get) Token: 0x06008880 RID: 34944 RVA: 0x00042E68 File Offset: 0x00041068
		' (set) Token: 0x06008881 RID: 34945 RVA: 0x00042E72 File Offset: 0x00041072
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x17003299 RID: 12953
		' (get) Token: 0x06008882 RID: 34946 RVA: 0x00042E7B File Offset: 0x0004107B
		' (set) Token: 0x06008883 RID: 34947 RVA: 0x00042E85 File Offset: 0x00041085
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x1700329A RID: 12954
		' (get) Token: 0x06008884 RID: 34948 RVA: 0x00042E8E File Offset: 0x0004108E
		' (set) Token: 0x06008885 RID: 34949 RVA: 0x00042E98 File Offset: 0x00041098
		Friend Overridable Property variant_id2 As DataGridViewTextBoxColumn

		' Token: 0x1700329B RID: 12955
		' (get) Token: 0x06008886 RID: 34950 RVA: 0x00042EA1 File Offset: 0x000410A1
		' (set) Token: 0x06008887 RID: 34951 RVA: 0x00042EAB File Offset: 0x000410AB
		Friend Overridable Property qty As DataGridViewTextBoxColumn

		' Token: 0x1700329C RID: 12956
		' (get) Token: 0x06008888 RID: 34952 RVA: 0x00042EB4 File Offset: 0x000410B4
		' (set) Token: 0x06008889 RID: 34953 RVA: 0x00042EBE File Offset: 0x000410BE
		Friend Overridable Property lblAQty As Label

		' Token: 0x1700329D RID: 12957
		' (get) Token: 0x0600888A RID: 34954 RVA: 0x00042EC7 File Offset: 0x000410C7
		' (set) Token: 0x0600888B RID: 34955 RVA: 0x00042ED1 File Offset: 0x000410D1
		Public Property dbOpeningstock As Double

		' Token: 0x1700329E RID: 12958
		' (get) Token: 0x0600888C RID: 34956 RVA: 0x00042EDA File Offset: 0x000410DA
		' (set) Token: 0x0600888D RID: 34957 RVA: 0x00042EE4 File Offset: 0x000410E4
		Public Property strBarcode As String

		' Token: 0x1700329F RID: 12959
		' (get) Token: 0x0600888E RID: 34958 RVA: 0x00042EED File Offset: 0x000410ED
		' (set) Token: 0x0600888F RID: 34959 RVA: 0x00042EF7 File Offset: 0x000410F7
		Public Property strStatus As String

		' Token: 0x170032A0 RID: 12960
		' (get) Token: 0x06008890 RID: 34960 RVA: 0x0063BA9C File Offset: 0x00639C9C
		' (set) Token: 0x06008891 RID: 34961 RVA: 0x00042F00 File Offset: 0x00041100
		Public Property ReceivedValue1 As Double
			Get
				Return Convert.ToDouble(Me._receivedValue1)
			End Get
			Set(value As Double)
				Me._receivedValue1 = New Decimal(value)
				Me.dbOpeningstock = value
			End Set
		End Property

		' Token: 0x170032A1 RID: 12961
		' (get) Token: 0x06008892 RID: 34962 RVA: 0x0063BABC File Offset: 0x00639CBC
		' (set) Token: 0x06008893 RID: 34963 RVA: 0x0063BAD4 File Offset: 0x00639CD4
		Public Property ReceivedValue As String
			Get
				Return Me._receivedValue
			End Get
			Set(value As String)
				Me._receivedValue = value
				Me.strBarcode = value
				Dim flag As Boolean = Operators.CompareString(Me.strBarcode, "", False) <> 0
				If flag Then
					Me.strStatus = "new"
					Me.getgriditemdata()
					Me.dgw4.Visible = True
					Dim flag2 As Boolean = Me.dgw4.Rows.Count = 1
					If flag2 Then
						Me.dgw4.Focus()
						Me.RetrieveData2()
					Else
						Dim flag3 As Boolean = Me.dgw4.Rows.Count > 1
						If flag3 Then
							Me.dgw4.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					Me.btnAdd_Click(Me, EventArgs.Empty)
				End If
			End Set
		End Property

		' Token: 0x170032A2 RID: 12962
		' (get) Token: 0x06008894 RID: 34964 RVA: 0x0063BB98 File Offset: 0x00639D98
		' (set) Token: 0x06008895 RID: 34965 RVA: 0x00042F17 File Offset: 0x00041117
		Public Property ReceivedValue3 As String
			Get
				Return Me._receivedValue3
			End Get
			Set(value As String)
				Me._receivedValue3 = value
				Me.strStatus = "variant"
				Me.getgriditemdata_variant(Me._receivedValue3)
			End Set
		End Property

		' Token: 0x06008896 RID: 34966 RVA: 0x0063BBB0 File Offset: 0x00639DB0
		Public Sub GetPurchaseTaxType()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(PurchaseTax) from Setting"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtGSTNonGST.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.txtGSTNonGST.Text = ""
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

		' Token: 0x06008897 RID: 34967 RVA: 0x0063BCB4 File Offset: 0x00639EB4
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Stock ORDER BY ST_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ST_ID"))
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

		' Token: 0x06008898 RID: 34968 RVA: 0x0063BE20 File Offset: 0x0063A020
		Private Function GenerateIDNoTax() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM PurcNoTax ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x06008899 RID: 34969 RVA: 0x0063BF8C File Offset: 0x0063A18C
		Private Function GenerateIDGST() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM PurcGST ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x0600889A RID: 34970 RVA: 0x0063C0F8 File Offset: 0x0063A2F8
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c1),RTRIM(c11) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "PGST"
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.txtInvCode1.Text, "", False) = 0
				If flag4 Then
					Me.txtInvCode1.Text = "PGST"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600889B RID: 34971 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600889C RID: 34972 RVA: 0x0063C2D0 File Offset: 0x0063A4D0
		Public Sub auto()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtGSTNonGST.Text, "NON GST", False) = 0
				If flag Then
					Me.txtST_ID.Text = Me.GenerateID()
					Me.ntid = Me.GenerateIDNoTax()
					Me.txtInvoiceNo.Text = "PINV-" + Me.GenerateIDNoTax() + "-" + Me.txtSuffix.Text
				Else
					Me.txtST_ID.Text = Me.GenerateID()
					Me.gstid = Me.GenerateIDGST()
					Me.txtInvoiceNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDGST(), "-", Me.txtSuffix.Text })
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600889D RID: 34973 RVA: 0x00042F3A File Offset: 0x0004113A
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Stock Entry"
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
		End Sub

		' Token: 0x0600889E RID: 34974 RVA: 0x0063C3EC File Offset: 0x0063A5EC
		Public Sub fillUnit()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbUnit.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbUnit.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600889F RID: 34975 RVA: 0x0063C520 File Offset: 0x0063A720
		Public Sub Reset()
			Me.Clear()
			Me.Picture.Image = Resources.Document
			Me.txtAddress.Text = ""
			Me.txtBalance.Text = ""
			Me.txtState.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtGSTIN.Text = ""
			Me.txtSubTotal.Text = ""
			Me.txtTotal.Text = ""
			Me.txtCurAmt.Text = ""
			Me.txtSupplierID.Text = ""
			Me.cmbSupplierName.Text = ""
			Me.txtSup_ID.Text = ""
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtMRP.Text = ""
			Me.txtFreightCharges.Text = "0.00"
			Me.txtGrandTotal.Text = ""
			Me.txtInvoiceNo.Text = ""
			Me.txtOtherCharges.Text = "0.00"
			Me.txtPreviousDue.Text = "0.00"
			Me.txtRemarks.Text = ""
			Me.txtRoundOff.Text = "0.00"
			Me.txtTotalPaid.Text = "0.00"
			Me.cmbPurchaseType.SelectedIndex = 1
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.DataGridView1.Enabled = True
			Me.btnAdd.Enabled = True
			Me.pnlCalc.Enabled = True
			Me.lblBalance.Text = "0.00"
			Me.txtTotalPaid.[ReadOnly] = True
			Me.txtTotalPaid.Enabled = False
			Me.DataGridView1.Rows.Clear()
			Me.DataGridView2.Rows.Clear()
			Me.btnSelection.Enabled = True
			Me.lblUnit.Text = "Unit"
			Me.GetPurchaseTaxType()
			Me.lblSet.Text = ""
			Me.btnSelection.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.auto()
			Me.txtSupplierInvoiceNo.Text = ""
			Me.dtpSupplierInvoiceDate.Value = DateAndTime.Today
			Me.cmbReverse.SelectedIndex = 0
			Me.lbltaxtype.Text = ""
			Me.cmbBSundry.Text = "Bill Sundry"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.lblQty_S.Visible = False
			Me.lblQty_S.Text = ""
			Me.dtpDate.Focus()
			Me.txtSuplLimit.Text = "0"
			Me.txtSuplLimitstatus.Text = ""
			Me.txtReferenceNo1.Text = ""
			Me.txtScode.Text = ""
			Me.cmbNP.SelectedIndex = -1
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
			Me.customerdetailenable()
			Me.NumericUpDown1.Value = Conversions.ToDecimal("30")
			Me.btnPrint.Enabled = False
			Me.txtMRPMarginNew.Text = "0.00"
			Me.txtSaaleMarginNew.Text = "0.00"
			Me.txtWMarginNew.Text = "0.00"
		End Sub

		' Token: 0x060088A0 RID: 34976 RVA: 0x0063C988 File Offset: 0x0063AB88
		Public Sub autoupdateretailsaleprice()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select SellingPrice from Product where PID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim num As Double = Conversion.Val(ModCommonClasses.rdr.GetValue(0).ToString())
				Dim flag2 As Boolean = Conversion.Val(Me.txtRetail.Text) > 0.0
				If flag2 Then
					Dim flag3 As Boolean = Conversion.Val(num) <> Conversion.Val(Me.txtRetail.Text)
					If flag3 Then
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Update Product set SellingPrice=@d1 where PID=@d2"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtRetail.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060088A1 RID: 34977 RVA: 0x0063CB5C File Offset: 0x0063AD5C
		Public Sub autoupdatewholesalesaleprice()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select ReorderPoint from Product where PID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim num As Double = Conversion.Val(ModCommonClasses.rdr.GetValue(0).ToString())
				Dim flag2 As Boolean = Conversion.Val(Me.txtWholesale.Text) > 0.0
				If flag2 Then
					Dim flag3 As Boolean = Conversion.Val(num) <> Conversion.Val(Me.txtWholesale.Text)
					If flag3 Then
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Update Product set ReorderPoint=@d1 where PID=@d2"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtWholesale.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060088A2 RID: 34978 RVA: 0x0063CD30 File Offset: 0x0063AF30
		Public Sub autoupdatepurchaseprice()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select CostPrice from Product where PID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim text2 As String = Conversions.ToString(Conversion.Val(ModCommonClasses.rdr.GetValue(0).ToString()))
				Dim flag2 As Boolean = Conversion.Val(Me.txtPricePerQty.Text) > 0.0
				If flag2 Then
					Dim flag3 As Boolean = Conversions.ToDouble(text2) <> Conversion.Val(Me.txtPricePerQty.Text)
					If flag3 Then
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "Update Product set CostPrice=@d1 where PID=@d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtPricePerQty.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060088A3 RID: 34979 RVA: 0x0063CF04 File Offset: 0x0063B104
		Public Sub autoupdateMRP()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select MRP from Product where PID=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = ModCommonClasses.rdr.Read()
			If flag Then
				Dim text2 As String = Conversions.ToString(Conversion.Val(ModCommonClasses.rdr.GetValue(0).ToString()))
				Dim flag2 As Boolean = Conversion.Val(Me.txtMRP.Text) > 0.0
				If flag2 Then
					Dim flag3 As Boolean = Conversions.ToDouble(text2) <> Conversion.Val(Me.txtMRP.Text)
					If flag3 Then
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "Update Product set MRP=@d1 where PID=@d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtMRP.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
				End If
				Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag4 Then
					ModCommonClasses.rdr.Close()
				End If
			End If
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x060088A4 RID: 34980 RVA: 0x0020DD08 File Offset: 0x0020BF08
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
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

		' Token: 0x060088A5 RID: 34981 RVA: 0x0063D0D8 File Offset: 0x0063B2D8
		Public Sub GenerateBarcode()
			Try
				Me.tempbarcode = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088A6 RID: 34982 RVA: 0x0063D140 File Offset: 0x0063B340
		Public Sub btnAdd_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtGSTNonGST.Text)) = 0
			If flag Then
				MessageBox.Show("Please configure Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.Clear()
				MyProject.Forms.frmTaxSetting.ShowDialog()
			Else
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtBarcode.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
							If flag4 Then
								MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtQty.Focus()
							Else
								Dim flag5 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
								If flag5 Then
									MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtQty.Focus()
								Else
									Me.alt()
									Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
									Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
									Dim flag6 As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
									If flag6 Then
										MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.cmbUnit.Text = Me.TextBox4.Text
										Me.cmbUnit.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.txtPricePerQty.Text, "", False) = 0
										If flag7 Then
											MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtPricePerQty.Focus()
										Else
											Dim flag8 As Boolean = Operators.CompareString(Me.txtRetail.Text, "", False) = 0
											If flag8 Then
												MessageBox.Show("Please enter Retail Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtRetail.Focus()
											Else
												Dim flag9 As Boolean = Operators.CompareString(Me.txtWholesale.Text, "", False) = 0
												If flag9 Then
													MessageBox.Show("Please enter Wholesale Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtWholesale.Focus()
												Else
													Try
														For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
															Dim flag10 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Conversion.Val(Me.txtProductID.Text), False), Operators.CompareObjectEqual(dataGridViewRow.Cells(3).Value, Me.txtBarcode.Text, False)))
															If flag10 Then
																MessageBox.Show("Same Product already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Me.Clear()
																Return
															End If
														Next
													Finally
														Dim enumerator As IEnumerator
														If TypeOf enumerator Is IDisposable Then
															TryCast(enumerator, IDisposable).Dispose()
														End If
													End Try
													Dim flag11 As Boolean = Conversion.Val(Me.txtPricePerQty.Text) > Conversion.Val(Me.txtMRP.Text)
													If flag11 Then
														Dim flag12 As Boolean = MessageBox.Show("You have enetered the MRP less than Sales Price, Do you really want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No
														If flag12 Then
															Return
														End If
													End If
													Me.autoupdatepurchaseprice()
													Me.autoupdateMRP()
													Me.autoupdateretailsaleprice()
													Me.autoupdatewholesalesaleprice()
													Dim checked As Boolean = Me.CheckBox8.Checked
													If checked Then
														Dim flag13 As Boolean = MessageBox.Show("Do you want to update the item's image ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
														If flag13 Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text3 As String = "update Product_Join set Photo=@d2 where ProductID=@d1"
															ModCommonClasses.cmd = New SqlCommand(text3)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															Dim memoryStream As MemoryStream = New MemoryStream()
															Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
															bitmap.Save(memoryStream, ImageFormat.Jpeg)
															Dim buffer As Byte() = memoryStream.GetBuffer()
															Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
															sqlParameter.Value = buffer
															ModCommonClasses.cmd.Parameters.Add(sqlParameter)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
															ModCommonClasses.cmd.ExecuteNonQuery()
															ModCommonClasses.con.Close()
														End If
													End If
													Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.cmbProductName.Text, Me.txtBarcode.Text, Conversion.Val(Me.TextBox2.Text), Conversion.Val(Me.txtMRP.Text), Conversion.Val(Me.txtPricePerQty.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtTotalAmount.Text), Conversion.Val(Me.txtQty.Text), Conversion.Val(Me.txtTaxableAmtI.Text), Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text), Me.lblAltUnit.Text, Me.lblPTaxType.Text, Conversion.Val(Me.txtRetail.Text), Conversion.Val(Me.txtWholesale.Text), Me.cmbColor.Text, Me.cmbSize.Text, Me.txtInfo.Text, Me.txtBatchNo.Text, Me.txtMfg.Text, Me.txtExp.Text, Me.TextBox7.Text, Me.TextBox8.Text, Me.lblProductCat.Text, Me.TextBox4.Text, Me.txtIMEI1.Text, Me.txtIMEI2.Text, Me.Label20.Text })
													Dim num As Double = Me.SubTotal()
													num = Math.Round(num, 2)
													Me.txtSubTotal.Text = Conversions.ToString(num)
													Me.Compute()
													Me.Clear()
													Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
													Me.GroupBox10.Visible = False
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				Catch ex As Exception
					Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
				End Try
			End If
		End Sub

		' Token: 0x060088A7 RID: 34983 RVA: 0x0063DA50 File Offset: 0x0063BC50
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("Column24").Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Return num
		End Function

		' Token: 0x060088A8 RID: 34984 RVA: 0x0063DB14 File Offset: 0x0063BD14
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.cmbProductName.Text = ""
			Me.TextBox5.Text = ""
			Me.txtQty.Text = Conversions.ToString(1)
			Me.txtPricePerQty.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtBarcode.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.cmbDiscountType.SelectedIndex = 0
			Me.txtDiscAmtPerQty.Enabled = False
			Me.txtTotalAmount.Text = "0.00"
			Me.cmbProductName.Enabled = True
			Me.btnGridUpdate.Enabled = False
			Me.btnRemove.Enabled = False
			Me.btnAdd.Enabled = True
			Me.txtTempQty.Text = ""
			Me.TextBox5.Focus()
			Me.txtMRP.Text = ""
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.lblQty_S.Visible = False
			Me.lblQty_S.Text = ""
			Me.dgw4.Visible = False
			Me.txtTaxableAmtI.Text = "0.00"
			Me.lblPTaxType.Text = ""
			Me.txtRetail.Text = "0.00"
			Me.txtWholesale.Text = "0.00"
			Me.cmbColor.SelectedIndex = -1
			Me.cmbColor.Text = ""
			Me.cmbSize.SelectedIndex = -1
			Me.cmbSize.Text = ""
			Me.txtInfo.Text = ""
			Me.txtBatchNo.Text = ""
			Me.txtMfg.Text = ""
			Me.txtExp.Text = ""
			Me.txtIMEI1.Text = ""
			Me.txtIMEI2.Text = ""
			Me.dtpManufacturingDate.Value = DateAndTime.Today
			Me.dtpExpiryDate.Value = DateAndTime.Today
			Me.lblProductCat.Text = ""
			Me.lblLastItemPurPrice.Text = "0.00"
			Me.lblSuplLastPur.Text = "0.00"
			Me.txtMRPMarginNew.Text = "0.00"
			Me.txtSaaleMarginNew.Text = "0.00"
			Me.txtWMarginNew.Text = "0.00"
			Me.dbOpeningstock = Conversions.ToDouble("0.00")
		End Sub

		' Token: 0x060088A9 RID: 34985 RVA: 0x0063DF14 File Offset: 0x0063C114
		Public Sub Fillproducts()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(ProductName) from Product order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbProductName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbProductName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088AA RID: 34986 RVA: 0x0063E018 File Offset: 0x0063C218
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(productid) as count from tbl_product_serial where invoice_no = @d1 AND sys_user = @d2 and barcode=@d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text.ToString())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblUser.Text.ToString())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), "0", False) <> 0
					If flag2 Then
						Dim flag3 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), Me.txtQty.Text.ToString(), False) <> 0
						If flag3 Then
							MessageBox.Show("Serial number already generated with this Barcode and Quantaty mismatch also!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.Clear()
							Return
						End If
					End If
					Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag4 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "select count(productid) as count from tbl_product_serial_final where invoice_no = @d1 AND sys_user = @d2 and barcode=@d3"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text.ToString())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblUser.Text.ToString())
				ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.ToString())
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
				If flag5 Then
					Dim flag6 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), "0", False) <> 0
					If flag6 Then
						Dim flag7 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), Me.txtQty.Text.ToString(), False) <> 0
						If flag7 Then
							MessageBox.Show("Serial number already generated with this Barcode and Quantaty mismatch also!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.Clear()
							Return
						End If
					End If
					Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag8 Then
						ModCommonClasses.rdr.Close()
					End If
				End If
				ModCommonClasses.con.Close()
				Try
					For Each obj As Object In Me.DataGridView1.SelectedRows
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Me.DataGridView1.Rows.Remove(dataGridViewRow)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim num As Double = Me.SubTotal()
				num = Math.Round(num, 2)
				Me.txtSubTotal.Text = Conversions.ToString(num)
				Me.Compute()
				Me.btnRemove.Enabled = False
				Me.DataGridView1.ClearSelection()
				Me.Clear()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag9 As Boolean = Me.DataGridView1.RowCount = 0
			If flag9 Then
				Me.customerdetailenable()
			End If
			Me.GroupBox10.Visible = False
		End Sub

		' Token: 0x060088AB RID: 34987 RVA: 0x0063E42C File Offset: 0x0063C62C
		Public Sub Compute()
			Dim flag As Boolean = Operators.CompareString(Me.cmbReverse.Text, "No", False) = 0
			If flag Then
				Me.GridCalc()
				Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtOtherCharges.Text) + Conversion.Val(Me.txtPreviousDue.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text)
				Me.num1 = Math.Round(Me.num1, 2)
				Me.txtTotal.Text = Conversions.ToString(Me.num1)
				Me.num2 = Math.Round(Me.num1, 0)
				Dim checked As Boolean = Me.CheckBox1.Checked
				If checked Then
					Me.num3 = Me.num2 - Me.num1
				Else
					Me.num3 = 0.0
				End If
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtRoundOff.Text = Conversions.ToString(Me.num3)
				Me.num4 = Conversion.Val(Me.txtTotal.Text) + Conversion.Val(Me.txtRoundOff.Text)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtGrandTotal.Text = Conversions.ToString(Me.num4)
				Me.num5 = Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtTotalPaid.Text)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtBalance.Text = Conversions.ToString(Me.num5)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbReverse.Text, "Yes", False) = 0
				If flag2 Then
					Me.GridCalc()
					Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtOtherCharges.Text) + Conversion.Val(Me.txtPreviousDue.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.txtTotal.Text = Conversions.ToString(Me.num1)
					Me.num2 = Math.Round(Me.num1, 0)
					Dim checked2 As Boolean = Me.CheckBox1.Checked
					If checked2 Then
						Me.num3 = Me.num2 - Me.num1
					Else
						Me.num3 = 0.0
					End If
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtRoundOff.Text = Conversions.ToString(Me.num3)
					Me.num4 = Conversion.Val(Me.txtTotal.Text) + Conversion.Val(Me.txtRoundOff.Text)
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtGrandTotal.Text = Conversions.ToString(Me.num4)
					Me.num5 = Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtTotalPaid.Text)
					Me.num5 = Math.Round(Me.num5, 2)
					Me.txtBalance.Text = Conversions.ToString(Me.num5)
				End If
			End If
			Me.num111 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtFreightCharges.Text) - Conversion.Val(Me.txtOtherCharges.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text)
			Me.num111 = Math.Round(Me.num111, 2)
			Me.txtCurAmt.Text = Conversions.ToString(Me.num111)
		End Sub

		' Token: 0x060088AC RID: 34988 RVA: 0x0063E880 File Offset: 0x0063CA80
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(10).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(12).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(14).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(16).Value))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			num = Math.Round(num, 2)
			num2 = Math.Round(num2, 2)
			num3 = Math.Round(num3, 2)
			num4 = Math.Round(num4, 2)
			Me.txtCGST.Text = Conversions.ToString(num)
			Me.txtSGST.Text = Conversions.ToString(num2)
			Me.txtIGST.Text = Conversions.ToString(num3)
			Me.txtCESS.Text = Conversions.ToString(num4)
		End Sub

		' Token: 0x060088AD RID: 34989 RVA: 0x0063EA10 File Offset: 0x0063CC10
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Me.btnRemove.Enabled = True
					Me.btnAdd.Enabled = False
					Me.btnGridUpdate.Enabled = True
					Me.cmbProductName.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtProductID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.lblPTaxType.Text = Conversions.ToString(dataGridViewRow.Cells(22).Value)
					Me.txtHSNCode.Text = Conversions.ToString(dataGridViewRow.Cells(1).Value)
					Me.cmbProductName.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.TextBox5.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.txtBarcode.Text = Conversions.ToString(dataGridViewRow.Cells(3).Value)
					Me.txtQty.Text = Conversions.ToString(dataGridViewRow.Cells(4).Value)
					Me.txtPricePerQty.Text = Conversions.ToString(dataGridViewRow.Cells(6).Value)
					Me.txtMRP.Text = Conversions.ToString(dataGridViewRow.Cells(5).Value)
					Me.txtDiscPer.Text = Conversions.ToString(dataGridViewRow.Cells(7).Value)
					Me.txtDisc.Text = Conversions.ToString(dataGridViewRow.Cells(8).Value)
					Me.txtCGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(9).Value)
					Me.txtCGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(10).Value)
					Me.txtSGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(11).Value)
					Me.txtSGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(12).Value)
					Me.txtIGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(13).Value)
					Me.txtIGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(14).Value)
					Me.txtCESSPer.Text = Conversions.ToString(dataGridViewRow.Cells(15).Value)
					Me.txtCESSAmt.Text = Conversions.ToString(dataGridViewRow.Cells(16).Value)
					Me.txtTotalAmount.Text = Conversions.ToString(dataGridViewRow.Cells(17).Value)
					Me.txtTempQty.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value)))
					Me.txtTaxableAmtI.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
					Me.txtRetail.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(23).Value)))
					Me.txtWholesale.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(24).Value)))
					Me.cmbColor.Text = Conversions.ToString(dataGridViewRow.Cells(25).Value)
					Me.cmbSize.Text = Conversions.ToString(dataGridViewRow.Cells(26).Value)
					Me.txtInfo.Text = Conversions.ToString(dataGridViewRow.Cells(27).Value)
					Me.txtBatchNo.Text = Conversions.ToString(dataGridViewRow.Cells(28).Value)
					Me.txtMfg.Text = Conversions.ToString(dataGridViewRow.Cells(29).Value)
					Me.txtExp.Text = Conversions.ToString(dataGridViewRow.Cells(30).Value)
					Me.lblProductCat.Text = Conversions.ToString(dataGridViewRow.Cells(33).Value)
					Me.txtIMEI1.Text = Conversions.ToString(dataGridViewRow.Cells(35).Value)
					Me.txtIMEI2.Text = Conversions.ToString(dataGridViewRow.Cells(36).Value)
					Me.txtMRPMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtMRP.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0, 2), "")
					Me.txtSaaleMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtRetail.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0, 2), "")
					Me.txtWMarginNew.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtWholesale.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0, 2), "")
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = If(("SELECT RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.lblAltUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
						Me.lblAltValue.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
					Me.conv()
					Me.alt()
					Me.dgw4.Visible = False
					Me.GetQty_S1()
					Me.GroupBox10.Visible = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060088AE RID: 34990 RVA: 0x0063F1A8 File Offset: 0x0063D3A8
		Private Sub alt()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(PurchaseUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmbaltunit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088AF RID: 34991 RVA: 0x0063F298 File Offset: 0x0063D498
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, New SolidBrush(Color.Black), CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x060088B0 RID: 34992 RVA: 0x0063F388 File Offset: 0x0063D588
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State),RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompanyState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
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

		' Token: 0x060088B1 RID: 34993 RVA: 0x0063F508 File Offset: 0x0063D708
		Private Sub frmStock_Load(sender As Object, e As EventArgs)
			MyBase.KeyPreview = True
			Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Registry.GetValue(Me.keyPath, Me.valueName, Nothing))
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Dim flag As Boolean = objectValue IsNot Nothing
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(objectValue.ToString(), "true", False) = 0
				If flag2 Then
					Me.chkMarginOnOff.Checked = True
					Me.CheckUncheckMargin()
				Else
					Me.chkMarginOnOff.Checked = False
					Me.CheckUncheckMargin()
				End If
			Else
				Me.chkMarginOnOff.Checked = False
				Me.CheckUncheckMargin()
			End If
			Me.CheckBox2.TabStop = False
			Me.CheckBox3.TabStop = False
			Me.CheckBox5.TabStop = False
			Me.CheckBox8.TabStop = False
			Me.GetCompanyState()
			Me.GetPurchaseTaxType()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.Invoicecode()
			Me.auto()
			Me.LinkLabel1.TabStop = False
			Me.fillUnit()
			Me.fillAccountInfo()
			Me.cmbProductName.DropDownHeight = 200
			Me.cmbProductName.DropDownWidth = 500
			Me.cmbUnit.DropDownHeight = 100
			Me.cmbUnit.DropDownWidth = 200
			Me.cmbBSundry.DropDownHeight = 80
			Me.cmbBSundry.DropDownWidth = 190
			Me.Autoroundoff()
			Me.GetPurchaseTaxType()
			Me.BillSundryType()
			Me.fillPurchaseID()
			frmPurchaseEntry.DoubleBuffered(Me.dgw4, True)
			frmPurchaseEntry.ProductDoubleBuffered(Me.DataGridView1, True)
			Me.CipherCode()
			Me.FillCategory()
			Me.txtTill_Id.Text = Dns.GetHostName()
			Me.Convert_Language()
			Me.DataGrid_control()
		End Sub

		' Token: 0x060088B2 RID: 34994 RVA: 0x0063F6E8 File Offset: 0x0063D8E8
		Public Sub DataGrid_control()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = 0
				Do
					Me.DataGridView1.Columns(num).Frozen = True
					num += 1
				Loop While num <= 17
				Me.DataGridView1.EnableHeadersVisualStyles = False
				Dim style As DataGridViewCellStyle = Me.DataGridView1.Columns(5).HeaderCell.Style
				style.BackColor = Color.Green
				style.ForeColor = Color.White
				style.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
				Dim num2 As Integer = 23
				Do
					Dim style2 As DataGridViewCellStyle = Me.DataGridView1.Columns(num2).HeaderCell.Style
					style2.BackColor = Color.Green
					style2.ForeColor = Color.White
					style2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
					num2 += 1
				Loop While num2 <= 30
				Me.DataGridView1.Refresh()
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x060088B3 RID: 34995 RVA: 0x0063F81C File Offset: 0x0063DA1C
		Public Sub PdfDataAddGrid()
			Dim flag As Boolean = frmPurchaseEntry.dtReceived IsNot Nothing AndAlso frmPurchaseEntry.dtReceived.Rows.Count > 0
			If flag Then
				Dim num As Integer = frmPurchaseEntry.dtReceived.Rows.Count - 1
				For i As Integer = 0 To num
					Me.strBarcode = frmPurchaseEntry.dtReceived.Rows(i)("Barcode").ToString()
					Dim flag2 As Boolean = Not String.IsNullOrEmpty(Me.strBarcode)
					If flag2 Then
						Me.strStatus = "new"
						Me.getgriditemdata()
						Me.dgw4.Visible = True
						Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
						If flag3 Then
							Me.dgw4.Focus()
							Me.RetrieveData2()
						Else
							Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
							If flag4 Then
								Me.dgw4.Focus()
								SendKeys.Send("{ENTER}")
							End If
						End If
						Me.btnAdd_Click(Me, EventArgs.Empty)
					End If
				Next
			End If
		End Sub

		' Token: 0x060088B4 RID: 34996 RVA: 0x0063F940 File Offset: 0x0063DB40
		Public Sub FillCategory()
			Dim num As Integer = 70
			Dim num2 As Integer = 70
			Dim num3 As Integer = 4
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT " & vbCrLf & "    RTRIM(b.category_name) AS category_name, " & vbCrLf & "    STUFF((" & vbCrLf & "        SELECT ',' + DISTINCT_VALUES.visual_status" & vbCrLf & "        FROM (" & vbCrLf & "            SELECT DISTINCT RTRIM(b2.visual_status) AS visual_status" & vbCrLf & "            FROM tbl_master_menu b2" & vbCrLf & "            INNER JOIN tbl_master_menu_header a2 " & vbCrLf & "                ON RTRIM(a2.category_name) = RTRIM(b2.category_name)" & vbCrLf & "            WHERE a2.is_deleted = 'false' " & vbCrLf & "              AND b2.visual_status <> ''" & vbCrLf & "              AND RTRIM(b2.category_name) = RTRIM(b.category_name)" & vbCrLf & "        ) AS DISTINCT_VALUES" & vbCrLf & "        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, ''" & vbCrLf & "    ) AS visual_status_merged" & vbCrLf & "FROM tbl_master_menu_header a" & vbCrLf & "INNER JOIN tbl_master_menu b " & vbCrLf & "    ON RTRIM(a.category_name) = RTRIM(b.category_name) " & vbCrLf & "WHERE a.is_deleted = 'false' " & vbCrLf & "  AND b.visual_status <> ''" & vbCrLf & "GROUP BY RTRIM(b.category_name)"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim text2 As String = sqlDataReader.GetValue(1).ToString()
							Dim array As String() = text2.Split(New Char() { ","c })
							Dim text3 As String = ""
							Dim text4 As String = ""
							For Each text5 As String In array
								Console.WriteLine(text5)
								Dim flag As Boolean = Operators.CompareString(text5, "P", False) = 0
								If flag Then
									Dim flag2 As Boolean = (Operators.CompareString(text3, text5, False) <> 0) And (Operators.CompareString(text4, sqlDataReader.GetValue(0).ToString(), False) <> 0)
									If flag2 Then
										text3 = text5
										text4 = sqlDataReader.GetValue(0).ToString()
										Dim dataTable As DataTable = New DataTable()
										dataTable = clsfun.ExecDataTable("SELECT icon_img FROM tbl_master_menu_header WHERE category_name='" + sqlDataReader.GetValue(0).ToString() + "'")
										Dim text6 As String = sqlDataReader.GetValue(0).ToString()
										Dim array3 As Byte() = If((Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows(0)("icon_img")))), CType(dataTable.Rows(0)("icon_img"), Byte()), Nothing)
										Dim button As Button = New Button()
										button.Tag = text6
										button.Size = New Size(num, num2)
										button.BackColor = Color.White
										button.FlatStyle = FlatStyle.Flat
										button.FlatAppearance.BorderSize = 0
										button.Margin = New Padding(num3)
										Dim flag3 As Boolean = array3 IsNot Nothing
										If flag3 Then
											Using memoryStream As MemoryStream = New MemoryStream(array3)
												Dim image As Image = Image.FromStream(memoryStream)
												Dim bitmap As Bitmap = New Bitmap(image, New Size(num, num2))
												bitmap.MakeTransparent(Color.White)
												button.BackgroundImage = bitmap
												button.BackgroundImageLayout = ImageLayout.Stretch
											End Using
										End If
										Me.flpItemsCategory.Controls.Add(button)
										AddHandler button.Click, AddressOf Me.btnCategory_Click
									End If
								End If
							Next
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x060088B5 RID: 34997 RVA: 0x0063FC6C File Offset: 0x0063DE6C
		Private Sub btnCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = Me.lastClickedButton Is button
				If flag Then
					Me.flpItems_BV.Visible = Not Me.flpItems_BV.Visible
				Else
					Me.flpItems_BV.Visible = True
					Me.lastClickedButton = button
					Dim text As String = button.Tag.ToString()
					Me.FillSubCategory(text)
					Application.DoEvents()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088B6 RID: 34998 RVA: 0x004FCD08 File Offset: 0x004FAF08
		Private Sub btnSubCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = button.Tag IsNot Nothing
				If flag Then
					Dim num As Integer = Conversions.ToInteger(button.Tag)
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, form_name FROM tbl_master_menu WHERE id = @id"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@id", num)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Dim text2 As String = sqlDataReader("form_name").ToString().Trim() + "1"
									Dim type As Type = MyProject.Forms.frmMainMenu.[GetType]()
									Dim method As MethodInfo = type.GetMethod(text2, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
									Dim flag3 As Boolean = method IsNot Nothing
									If flag3 Then
										method.Invoke(MyProject.Forms.frmMainMenu, Nothing)
									Else
										MessageBox.Show("Function '" + text2 + "' not found in frmMainMenu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End If
								End If
							End Using
						End Using
					End Using
				Else
					MessageBox.Show("Button tag is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088B7 RID: 34999 RVA: 0x0063FD14 File Offset: 0x0063DF14
		Public Sub FillSubCategory(strCategory As String)
			Dim num As Integer = 110
			Dim num2 As Integer = 110
			Dim num3 As Integer = 7
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, visual_status FROM tbl_master_menu WHERE is_deleted='false' and category_name = @Category and visual_status <> ''"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Category", strCategory)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim text2 As String = sqlDataReader.GetValue(3).ToString()
							Dim array As String() = text2.Split(New Char() { ","c })
							Dim text3 As String = ""
							Dim text4 As String = ""
							For Each text5 As String In array
								Console.WriteLine(text5)
								Dim flag As Boolean = Operators.CompareString(text5, "P", False) = 0
								If flag Then
									Dim flag2 As Boolean = (Operators.CompareString(text3, text5, False) <> 0) And (Operators.CompareString(text4, sqlDataReader.GetValue(1).ToString(), False) <> 0)
									If flag2 Then
										text3 = text5
										text4 = sqlDataReader.GetValue(1).ToString()
										Dim num4 As Short = Conversions.ToShort(sqlDataReader.GetValue(1))
										Dim array3 As Byte() = If((Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))), CType(sqlDataReader("icon_img"), Byte()), Nothing)
										Dim button As Button = New Button()
										button.Tag = num4
										button.Size = New Size(num, num2)
										button.BackColor = Color.White
										button.FlatStyle = FlatStyle.Flat
										button.FlatAppearance.BorderSize = 0
										button.FlatAppearance.MouseOverBackColor = button.BackColor
										button.FlatAppearance.MouseDownBackColor = button.BackColor
										button.Margin = New Padding(num3)
										Dim flag3 As Boolean = array3 IsNot Nothing
										If flag3 Then
											Using memoryStream As MemoryStream = New MemoryStream(array3)
												Dim image As Image = Image.FromStream(memoryStream)
												button.BackgroundImage = New Bitmap(image, New Size(num, num2))
												button.BackgroundImageLayout = ImageLayout.Stretch
											End Using
										End If
										AddHandler button.Click, AddressOf Me.btnSubCategory_Click
										Me.flpItems_BV.Controls.Add(button)
									End If
								End If
							Next
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x060088B8 RID: 35000 RVA: 0x0064002C File Offset: 0x0063E22C
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
						Me.UpdateDataGridViewHeaders(Me.dgw4, GlobalVariables.translations)
						Me.UpdateDataGridViewHeaders(Me.dgwsale, GlobalVariables.translations)
						Me.UpdateDataGridViewHeaders(Me.DataGridView1, GlobalVariables.translations)
						Me.UpdateDataGridViewHeaders(Me.DataGridView2, GlobalVariables.translations)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x060088B9 RID: 35001 RVA: 0x00640214 File Offset: 0x0063E414
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
				End If
			End If
			Dim flag3 As Boolean = TypeOf ctrl Is TabControl
			If flag3 Then
				Dim tabControl As TabControl = CType(ctrl, TabControl)
				Try
					For Each obj As Object In tabControl.TabPages
						Dim tabPage As TabPage = CType(obj, TabPage)
						Dim text2 As String = tabPage.Text
						Dim flag4 As Boolean = translations.ContainsKey(text2)
						If flag4 Then
							tabPage.Text = translations(text2)
						End If
						Try
							For Each obj2 As Object In tabPage.Controls
								Dim control As Control = CType(obj2, Control)
								Me.UpdateAllControls(control, translations)
							Next
						Finally
							Dim enumerator2 As IEnumerator
							If TypeOf enumerator2 Is IDisposable Then
								TryCast(enumerator2, IDisposable).Dispose()
							End If
						End Try
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End If
			Dim flag5 As Boolean = TypeOf ctrl Is MenuStrip
			If flag5 Then
				Dim menuStrip As MenuStrip = CType(ctrl, MenuStrip)
				Try
					For Each obj3 As Object In menuStrip.Items
						Dim toolStripMenuItem As ToolStripMenuItem = CType(obj3, ToolStripMenuItem)
						Me.UpdateMenuItems(toolStripMenuItem, translations)
					Next
				Finally
					Dim enumerator3 As IEnumerator
					If TypeOf enumerator3 Is IDisposable Then
						TryCast(enumerator3, IDisposable).Dispose()
					End If
				End Try
			End If
			Try
				For Each obj4 As Object In ctrl.Controls
					Dim control2 As Control = CType(obj4, Control)
					Me.UpdateAllControls(control2, translations)
				Next
			Finally
				Dim enumerator4 As IEnumerator
				If TypeOf enumerator4 Is IDisposable Then
					TryCast(enumerator4, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060088BA RID: 35002 RVA: 0x00208B7C File Offset: 0x00206D7C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView, translations As Dictionary(Of String, String))
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060088BB RID: 35003 RVA: 0x0064044C File Offset: 0x0063E64C
		Private Sub UpdateMenuItems(menuItem As ToolStripMenuItem, translations As Dictionary(Of String, String))
			Dim text As String = menuItem.Text
			Dim flag As Boolean = translations.ContainsKey(text)
			If flag Then
				menuItem.Text = translations(text)
			End If
			Try
				For Each toolStripMenuItem As ToolStripMenuItem In menuItem.DropDownItems.OfType(Of ToolStripMenuItem)()
					Me.UpdateMenuItems(toolStripMenuItem, translations)
				Next
			Finally
				Dim enumerator As IEnumerator(Of ToolStripMenuItem)
				If enumerator IsNot Nothing Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060088BC RID: 35004 RVA: 0x006404CC File Offset: 0x0063E6CC
		Public Sub BillSundryType()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Head) from BillSundry order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbBSundry.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbBSundry.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088BD RID: 35005 RVA: 0x006405DC File Offset: 0x0063E7DC
		Public Sub Autoroundoff()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(c1) from Autoroundoff"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					Me.TextBox1.Text = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.TextBox1.Text, "Yes", False) = 0
				If flag4 Then
					Me.CheckBox1.Checked = True
				Else
					Me.CheckBox1.Checked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088BE RID: 35006 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtPricePerQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088BF RID: 35007 RVA: 0x00640720 File Offset: 0x0063E920
		Private Sub updateMarginnew()
			Me.txtMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtMRPMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
			Me.txtRetail.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtSaaleMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
			Me.txtWholesale.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtWMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
		End Sub

		' Token: 0x060088C0 RID: 35008 RVA: 0x00640848 File Offset: 0x0063EA48
		Public Sub Calc()
			Dim flag As Boolean = (Operators.CompareString(Me.txtGSTNonGST.Text, "GST", False) = 0) Or (Operators.CompareString(Me.txtGSTNonGST.Text, "", False) = 0)
			If flag Then
				Dim flag2 As Boolean = (Operators.CompareString(Me.lblPTaxType.Text, "Exclusive", False) = 0) Or (Operators.CompareString(Me.lblPTaxType.Text, "", False) = 0)
				If flag2 Then
					Dim flag3 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag3 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
						Me.num7 = Math.Round(Me.num7, 2)
						Me.txtDisc.Text = Conversions.ToString(Me.num7)
					Else
						Dim flag4 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
						If flag4 Then
							Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
							Me.num1 = Math.Round(Me.num1, 2)
							Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
							Me.num7 = Math.Round(Me.num7, 4)
							Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
						End If
					End If
					Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
					Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
					Me.num2 = Math.Round(Me.num2, 2)
					Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
					Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
					Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
					Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
					Me.num5 = Math.Round(Me.num5, 2)
					Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
					Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
					Me.num6 = Math.Round(Me.num6, 2)
					Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.lblPTaxType.Text, "Exempt GST", False) = 0
				If flag5 Then
					Dim flag6 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag6 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
						Me.num7 = Math.Round(Me.num7, 2)
						Me.txtDisc.Text = Conversions.ToString(Me.num7)
					Else
						Dim flag7 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
						If flag7 Then
							Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
							Me.num1 = Math.Round(Me.num1, 2)
							Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
							Me.num7 = Math.Round(Me.num7, 4)
							Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
						End If
					End If
					Me.txtCGSTPer.Text = "0.00"
					Me.txtSGSTPer.Text = "0.00"
					Me.txtIGSTPer.Text = "0.00"
					Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
					Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
					Me.num2 = Math.Round(Me.num2, 2)
					Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
					Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
					Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
					Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
					Me.num5 = Math.Round(Me.num5, 2)
					Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
					Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
					Me.num6 = Math.Round(Me.num6, 2)
					Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				End If
				Dim flag8 As Boolean = Operators.CompareString(Me.lblPTaxType.Text, "No Taxes", False) = 0
				If flag8 Then
					Dim flag9 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag9 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
						Me.num7 = Math.Round(Me.num7, 2)
						Me.txtDisc.Text = Conversions.ToString(Me.num7)
					Else
						Dim flag10 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
						If flag10 Then
							Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
							Me.num1 = Math.Round(Me.num1, 2)
							Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
							Me.num7 = Math.Round(Me.num7, 4)
							Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
						End If
					End If
					Me.txtCGSTPer.Text = "0.00"
					Me.txtSGSTPer.Text = "0.00"
					Me.txtIGSTPer.Text = "0.00"
					Me.txtCESSPer.Text = "0.00"
					Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
					Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
					Me.num2 = Math.Round(Me.num2, 2)
					Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
					Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
					Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
					Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
					Me.num5 = Math.Round(Me.num5, 2)
					Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
					Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
					Me.num6 = Math.Round(Me.num6, 2)
					Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				End If
				Dim flag11 As Boolean = Operators.CompareString(Me.lblPTaxType.Text, "Inclusive", False) = 0
				If flag11 Then
					Dim flag12 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag12 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
						Me.num7 = Math.Round(Me.num7, 2)
						Me.txtDisc.Text = Conversions.ToString(Me.num7)
					Else
						Dim flag13 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
						If flag13 Then
							Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
							Me.num1 = Math.Round(Me.num1, 2)
							Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
							Me.num7 = Math.Round(Me.num7, 4)
							Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
						End If
					End If
					Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
					Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
					Me.num2 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
					Me.num2 = Math.Round(Me.num2, 2)
					Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2 / 2.0, 2), "0.00")
					Me.num3 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
					Me.num3 = Math.Round(Me.num3, 2)
					Me.txtSGSTAmt.Text = Conversions.ToString(Me.num3 / 2.0)
					Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3 / 2.0, 2), "0.00")
					Me.num4 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtIGSTPer.Text) / 100.0))
					Me.num4 = Math.Round(Me.num4, 2)
					Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
					Me.num5 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + Conversion.Val(Me.txtCESSPer.Text) / 100.0))
					Me.num5 = Math.Round(Me.num5, 2)
					Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
					Me.num6 = Me.num8
					Me.num6 = Math.Round(Me.num6, 2)
					Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				End If
				Me.numx = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
				Dim flag14 As Boolean = Operators.CompareString(Me.lblPTaxType.Text, "Inclusive", False) = 0
				Dim num As Double
				If flag14 Then
					num = Me.numx - Conversion.Val(Me.txtDisc.Text) - (Conversion.Val(Me.txtCGSTAmt.Text) + Conversion.Val(Me.txtSGSTAmt.Text) + Conversion.Val(Me.txtIGSTAmt.Text) + Conversion.Val(Me.txtCESSAmt.Text))
				Else
					num = Me.numx - Conversion.Val(Me.txtDisc.Text)
				End If
				Me.txtTaxableAmtI.Text = Strings.Format(Math.Round(num, 2), "0.00")
			End If
			Dim flag15 As Boolean = Operators.CompareString(Me.txtGSTNonGST.Text, "NON GST", False) = 0
			If flag15 Then
				Dim flag16 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag16 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag17 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag17 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.txtCGSTPer.Text = "0.00"
				Me.txtSGSTPer.Text = "0.00"
				Me.txtIGSTPer.Text = "0.00"
				Me.txtCESSPer.Text = "0.00"
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCGSTPer.Text) / 100.0)
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2, 2), "0.00")
				Me.txtCGSTPer.Text = "0.00"
				Me.num3 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtSGSTPer.Text) / 100.0)
				Me.num3 = Math.Round(Me.num3, 2)
				Me.txtSGSTAmt.Text = Strings.Format(Math.Round(Me.num3, 2), "0.00")
				Me.txtSGSTPer.Text = "0.00"
				Me.num4 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtIGSTPer.Text) / 100.0)
				Me.num4 = Math.Round(Me.num4, 2)
				Me.txtIGSTAmt.Text = Strings.Format(Math.Round(Me.num4, 2), "0.00")
				Me.txtIGSTPer.Text = "0.00"
				Me.num5 = Conversion.Val(Me.num8 * Conversion.Val(Me.txtCESSPer.Text) / 100.0)
				Me.num5 = Math.Round(Me.num5, 2)
				Me.txtCESSAmt.Text = Strings.Format(Math.Round(Me.num5, 2), "0.00")
				Me.txtCESSPer.Text = "0.00"
				Me.num6 = Me.num8 + Me.num2 + Me.num3 + Me.num4 + Me.num5
				Me.num6 = Math.Round(Me.num6, 2)
				Me.txtTotalAmount.Text = Conversions.ToString(Me.num6)
				Me.numx = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
				Dim flag18 As Boolean = Operators.CompareString(Me.lblPTaxType.Text, "Inclusive", False) = 0
				Dim num2 As Double
				If flag18 Then
					num2 = Me.numx - Conversion.Val(Me.txtDisc.Text) - (Conversion.Val(Me.txtCGSTAmt.Text) + Conversion.Val(Me.txtSGSTAmt.Text) + Conversion.Val(Me.txtIGSTAmt.Text) + Conversion.Val(Me.txtCESSAmt.Text))
				Else
					num2 = Me.numx - Conversion.Val(Me.txtDisc.Text)
				End If
				Me.txtTaxableAmtI.Text = Strings.Format(Math.Round(num2, 2), "0.00")
			End If
		End Sub

		' Token: 0x060088C1 RID: 35009 RVA: 0x00042F81 File Offset: 0x00041181
		Private Sub txtQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x060088C2 RID: 35010 RVA: 0x00641F0C File Offset: 0x0064010C
		Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtQty.Text
					Dim selectionStart As Integer = Me.txtQty.SelectionStart
					Dim selectionLength As Integer = Me.txtQty.SelectionLength
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

		' Token: 0x060088C3 RID: 35011 RVA: 0x00642004 File Offset: 0x00640204
		Private Sub txtRetail_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtRetail.Text
					Dim selectionStart As Integer = Me.txtRetail.SelectionStart
					Dim selectionLength As Integer = Me.txtRetail.SelectionLength
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

		' Token: 0x060088C4 RID: 35012 RVA: 0x006420FC File Offset: 0x006402FC
		Private Sub txtWholesale_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtWholesale.Text
					Dim selectionStart As Integer = Me.txtWholesale.SelectionStart
					Dim selectionLength As Integer = Me.txtWholesale.SelectionLength
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

		' Token: 0x060088C5 RID: 35013 RVA: 0x006421F4 File Offset: 0x006403F4
		Private Sub txtPricePerQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtPricePerQty.Text
					Dim selectionStart As Integer = Me.txtPricePerQty.SelectionStart
					Dim selectionLength As Integer = Me.txtPricePerQty.SelectionLength
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

		' Token: 0x060088C6 RID: 35014 RVA: 0x006422EC File Offset: 0x006404EC
		Private Sub txtTotalPayment_Validating(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = Conversion.Val(Me.txtTotalPaid.Text) > Conversion.Val(Me.txtGrandTotal.Text)
			If flag Then
				MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060088C7 RID: 35015 RVA: 0x00642338 File Offset: 0x00640538
		Public Sub GetSupplierBalance()
			Try
				Me.num1 = 0.0
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
				Me.lblBalance.Text = Conversions.ToString(Me.num1)
				Me.lblBalance.ForeColor = Color.DarkGreen
				Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
				If flag2 Then
					Me.str = "Cr"
					Me.lblBalance.ForeColor = Color.Red
				Else
					Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						Me.lblBalance.ForeColor = Color.Blue
					End If
				End If
				Me.txtPreviousDue.Text = Conversions.ToString(Me.num1)
				Me.lblBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblBalance.Text)), "0.00")
				Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
				Me.Compute()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088C8 RID: 35016 RVA: 0x00642564 File Offset: 0x00640764
		Public Sub GetSupplierInfo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(SupplierID),RTRIM(Name),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN),RTRIM(SCode) from Supplier Where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtSup_ID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSupplierID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.cmbSupplierName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtAddress.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
					Me.txtGSTIN.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
					Me.txtScode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(6))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060088C9 RID: 35017 RVA: 0x006426F0 File Offset: 0x006408F0
		Public Sub GetSupplierBalance1()
			Try
				Try
					Me.num1 = 0.0
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Me.lblBalance.ForeColor = Color.DarkGreen
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "Cr"
						Me.lblBalance.ForeColor = Color.Red
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "Dr"
							Me.lblBalance.ForeColor = Color.Blue
						End If
					End If
					Me.lblBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblBalance.Text)), "0.00")
					Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
					Me.Compute()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088CA RID: 35018 RVA: 0x00642948 File Offset: 0x00640B48
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select ST_ID from Stock,PurchaseReturn where PurchaseReturn.PurchaseID=Stock.ST_ID and ST_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Purchase Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Return
				End If
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "delete from Stock where ST_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag3 As Boolean = num > 0
				If flag3 Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag4 As Boolean = Not dataGridViewRow.IsNewRow
							If flag4 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Update Temp_Stock set Qty = Qty - ", dataGridViewRow.Cells(4).Value), " where ProductID=@d1 and Barcode=@d2"))
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value)).ToString()
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text4 As String = If(("Delete from Stock_Product where StockID=" + Conversions.ToString(Conversion.Val(Me.txtST_ID.Text))), "")
					ModCommonClasses.cmd = New SqlCommand(text4)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							Dim flag5 As Boolean = Not dataGridViewRow2.IsNewRow
							If flag5 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text6 As String = "delete from StockMovement where ProductID=@d1 and TransID=@d2"
									ModCommonClasses.cmd = New SqlCommand(text6)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
								End If
							End If
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					ModFunc.PurcGST(Me.txtInvoiceNo.Text)
					ModFunc.PurcNOTax(Me.txtInvoiceNo.Text)
					ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Payment")
					ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Purchase")
					ModFunc.SupplierLedgerDelete(Me.txtInvoiceNo.Text)
					ModFunc.BankAccountLedgerDelete(Me.txtInvoiceNo.Text, "Purchase-Bank")
					ModFunc.LogFunc(Me.lblUser.Text, "deleted the purchase record having Invoice No. '" + Me.txtInvoiceNo.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPurchaseID()
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillPurchaseID()
					Me.Reset()
				End If
				Dim flag7 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag7 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
			Me.fillColor()
			Me.fillSize()
		End Sub

		' Token: 0x060088CB RID: 35019 RVA: 0x00642FC4 File Offset: 0x006411C4
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.txtSupplierInvoiceNo.Focus()
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Purchase"
			MyProject.Forms.frmSupplierRecord.Label5.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplierRecord.btnaddCustomer.Visible = True
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x060088CC RID: 35020 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtDiscPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088CD RID: 35021 RVA: 0x00042F99 File Offset: 0x00041199
		Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
			Me.taxableamtcal()
		End Sub

		' Token: 0x060088CE RID: 35022 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtFreightCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088CF RID: 35023 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtOtherCharges_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088D0 RID: 35024 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtPreviousDue_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088D1 RID: 35025 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtRoundOff_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088D2 RID: 35026 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtTotalPaid_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088D3 RID: 35027 RVA: 0x00643060 File Offset: 0x00641260
		Private Sub cmbPurchaseType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbPurchaseType.SelectedIndex = 1
			If flag Then
				Me.txtTotalPaid.Text = "0.00"
				Me.txtTotalPaid.[ReadOnly] = True
				Me.txtTotalPaid.Enabled = False
			Else
				Me.txtTotalPaid.Text = "0.00"
				Me.txtTotalPaid.[ReadOnly] = False
				Me.txtTotalPaid.Enabled = True
			End If
			Dim flag2 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
			If flag2 Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x060088D4 RID: 35028 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtVATPer_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088D5 RID: 35029 RVA: 0x0064311C File Offset: 0x0064131C
		Private Sub txtCGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCGSTPer.Text
					Dim selectionStart As Integer = Me.txtCGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCGSTPer.SelectionLength
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

		' Token: 0x060088D6 RID: 35030 RVA: 0x00643214 File Offset: 0x00641414
		Private Sub txtSGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtSGSTPer.Text
					Dim selectionStart As Integer = Me.txtSGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtSGSTPer.SelectionLength
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

		' Token: 0x060088D7 RID: 35031 RVA: 0x0064330C File Offset: 0x0064150C
		Private Sub txtIGSTPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtIGSTPer.Text
					Dim selectionStart As Integer = Me.txtIGSTPer.SelectionStart
					Dim selectionLength As Integer = Me.txtIGSTPer.SelectionLength
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

		' Token: 0x060088D8 RID: 35032 RVA: 0x00643404 File Offset: 0x00641604
		Private Sub txtCESSPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtCESSPer.Text
					Dim selectionStart As Integer = Me.txtCESSPer.SelectionStart
					Dim selectionLength As Integer = Me.txtCESSPer.SelectionLength
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

		' Token: 0x060088D9 RID: 35033 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtCGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088DA RID: 35034 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtSGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088DB RID: 35035 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtIGSTPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088DC RID: 35036 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtCESSPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088DD RID: 35037 RVA: 0x006434FC File Offset: 0x006416FC
		Private Sub txtDiscPer_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscPer.Text
					Dim selectionStart As Integer = Me.txtDiscPer.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscPer.SelectionLength
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

		' Token: 0x060088DE RID: 35038 RVA: 0x006435F4 File Offset: 0x006417F4
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSupplierName.Focus()
			Else
				MyProject.Forms.frmProductRecord.lblSet.Text = "Stock"
				MyProject.Forms.frmProductRecord.Reset()
				MyProject.Forms.frmProductRecord.ShowDialog()
				MyProject.Forms.frmProductRecord.Dispose()
			End If
		End Sub

		' Token: 0x060088DF RID: 35039 RVA: 0x0064368C File Offset: 0x0064188C
		Private Sub Button2_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmProduct.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmProduct.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmProduct.lblCondn.Text = "Purchase_Add"
			MyProject.Forms.frmProduct.Reset()
			MyProject.Forms.frmProduct.ShowDialog()
			MyProject.Forms.frmProduct.Dispose()
		End Sub

		' Token: 0x060088E0 RID: 35040 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088E1 RID: 35041 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub cmbReverse_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088E2 RID: 35042 RVA: 0x00643724 File Offset: 0x00641924
		Private Sub txtSuplNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x060088E3 RID: 35043 RVA: 0x00643724 File Offset: 0x00641924
		Private Sub txtSupplierID_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x060088E4 RID: 35044 RVA: 0x00643774 File Offset: 0x00641974
		Public Sub limitsearch()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select Limit,Lstatus from Supplier where SupplierID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSuplLimit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.txtSuplLimitstatus.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag3 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088E5 RID: 35045 RVA: 0x00643724 File Offset: 0x00641924
		Private Sub cmbSupplierName_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x060088E6 RID: 35046 RVA: 0x00042FAA File Offset: 0x000411AA
		Private Sub txtCGST_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x060088E7 RID: 35047 RVA: 0x006438A4 File Offset: 0x00641AA4
		Private Sub txtMRP_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtMRP.Text
					Dim selectionStart As Integer = Me.txtMRP.SelectionStart
					Dim selectionLength As Integer = Me.txtMRP.SelectionLength
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

		' Token: 0x060088E8 RID: 35048 RVA: 0x0064399C File Offset: 0x00641B9C
		Private Sub txtDisc_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDisc.Text
					Dim selectionStart As Integer = Me.txtDisc.SelectionStart
					Dim selectionLength As Integer = Me.txtDisc.SelectionLength
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

		' Token: 0x060088E9 RID: 35049 RVA: 0x00643A94 File Offset: 0x00641C94
		Private Sub cmbDiscountType_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbDiscountType.SelectedIndex = 0
			If flag Then
				Me.txtDiscAmtPerQty.Enabled = False
				Me.txtDiscPer.Enabled = True
			Else
				Dim flag2 As Boolean = Me.cmbDiscountType.SelectedIndex = 1
				If flag2 Then
					Me.txtDiscPer.Enabled = False
					Me.txtDiscAmtPerQty.Enabled = True
				End If
			End If
			Me.Calc()
		End Sub

		' Token: 0x060088EA RID: 35050 RVA: 0x00042F77 File Offset: 0x00041177
		Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x060088EB RID: 35051 RVA: 0x00042FB4 File Offset: 0x000411B4
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060088EC RID: 35052 RVA: 0x00643B08 File Offset: 0x00641D08
		Private Sub cmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupplierName.Focus()
					Me.dgw4.Visible = False
					Return
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					Return
				End If
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(PurchaseUnit),RTRIM(SalesAltUnit),RTRIM(Conv),MRP,RTRIM(PTax) from Product where PID=@d1 and RTRIM(Barcode)=@d2"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
				If flag4 Then
					Me.txtProductID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.lblPTaxType.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(13))
					Me.txtHSNCode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.txtBarcode.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtPricePerQty.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtMRP.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(12))
					Me.txtDiscPer.Text = "0.00"
					Dim flag5 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) = 0
					If flag5 Then
						Me.txtCGSTPer.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(6))
						Me.txtSGSTPer.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(7))
						Me.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag6 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) <> 0
						If flag6 Then
							Me.txtCGSTPer.Text = Conversions.ToString(0)
							Me.txtSGSTPer.Text = Conversions.ToString(0)
							Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(6))) + Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(7))))
						End If
					End If
					Me.txtCESSPer.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(8))
					Me.lblUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.cmbaltunit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.lblAltUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.TextBox3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
					Me.lblAltValue.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
					Me.txtQty.Text = Conversions.ToString(1)
					Me.txtQty.Focus()
					Me.GetQty_S1()
					Me.alt()
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.cmbProductName.DropDownHeight = 200
			Me.cmbProductName.DropDownWidth = 500
		End Sub

		' Token: 0x060088ED RID: 35053 RVA: 0x00643FE0 File Offset: 0x006421E0
		Private Sub conv()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(PurchaseUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where ProductName=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbProductName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060088EE RID: 35054 RVA: 0x00042FD0 File Offset: 0x000411D0
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x060088EF RID: 35055 RVA: 0x006440D0 File Offset: 0x006422D0
		Private Sub altunitcal()
			Dim flag As Boolean = Operators.CompareString(Me.cmbUnit.Text, Me.cmbaltunit.Text, False) = 0
			If flag Then
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text) / Conversion.Val(Me.TextBox3.Text))
			Else
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text))
			End If
		End Sub

		' Token: 0x060088F0 RID: 35056 RVA: 0x00042FD0 File Offset: 0x000411D0
		Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x060088F1 RID: 35057 RVA: 0x00042FE1 File Offset: 0x000411E1
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x060088F2 RID: 35058 RVA: 0x00042FE1 File Offset: 0x000411E1
		Private Sub cmbaltunit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x060088F3 RID: 35059 RVA: 0x00042FEB File Offset: 0x000411EB
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.DataGridView1.ClearSelection()
			Me.GroupBox10.Visible = False
		End Sub

		' Token: 0x060088F4 RID: 35060 RVA: 0x0064415C File Offset: 0x0064235C
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Me.strStatus = "old"
			Dim flag As Boolean = Operators.CompareString(Me.TextBox5.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
			Me.strStatus = ""
		End Sub

		' Token: 0x060088F5 RID: 35061 RVA: 0x006441C4 File Offset: 0x006423C4
		Public Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim num As Integer = 5
				Dim flag As Boolean = (Operators.CompareString(Me.strStatus, "old", False) = 0) Or (Operators.CompareString(Me.strStatus, "", False) = 0)
				If flag Then
					Dim flag2 As Boolean = Not Me.CheckBox2.Checked And Not Me.CheckBox3.Checked
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2), Temp_Stock.Variant_id,RTRIM(Temp_Stock.Qty)  from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
					End If
					Dim flag3 As Boolean = Me.CheckBox2.Checked And Not Me.CheckBox3.Checked
					If flag3 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2), Temp_Stock.Variant_id,RTRIM(Temp_Stock.Qty)  from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and PartNo like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
					End If
					Dim flag4 As Boolean = Me.CheckBox3.Checked And Not Me.CheckBox2.Checked
					If flag4 Then
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2), Temp_Stock.Variant_id,RTRIM(Temp_Stock.Qty)  from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Barcode=N'", Me.TextBox5.Text, "' order by ProductName" }), ModCommonClasses.con)
					End If
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2), Temp_Stock.Variant_id,RTRIM(Temp_Stock.Qty) from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Temp_Stock.Barcode=N'", Me.strBarcode, "'" }), ModCommonClasses.con)
				End If
				ModCommonClasses.cmd.CommandTimeout = num
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060088F6 RID: 35062 RVA: 0x00644690 File Offset: 0x00642890
		Private Sub getgriditemdata_variant(strVarinatid As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = num To 0 Step -1
					Dim flag As Boolean = Operators.ConditionalCompareObjectNotEqual(Me.DataGridView1.Rows(i).Cells("Variant_id").Value, "", False)
					If flag Then
						Dim flag2 As Boolean = CDbl(Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Variant_id").Value))) = Conversion.Val(strVarinatid)
						If flag2 Then
							Me.DataGridView1.Rows.RemoveAt(i)
						End If
					End If
				Next
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Barcode) as barcode from Temp_Stock where Variant_id=N'" + strVarinatid + "'", ModCommonClasses.con)
				Me.dt.Rows.Clear()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				sqlDataAdapter.Fill(Me.dt)
				ModCommonClasses.con.Close()
				Dim num2 As Integer = Me.dt.Rows.Count - 1
				For j As Integer = 0 To num2
					Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dt.Rows(j)("barcode"))) AndAlso Not String.IsNullOrWhiteSpace(Me.dt.Rows(j)("barcode").ToString())
					If flag3 Then
						Me.strStatus = "variant"
						Dim text As String = Me.dt.Rows(j)("barcode").ToString()
						Me.dgw4.Visible = True
						Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
						Me.dgw4.RowHeadersVisible = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " Product.PID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName),RTRIM(Product.HSNCode),RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2), Temp_Stock.Variant_id, temp_product.qty from Temp_Stock,Product,Category,SubCategory,temp_product where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and Product.PID=temp_product.PID  and Temp_Stock.Barcode=N'", Me.dt.Rows(j)("barcode").ToString(), "'" }), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						Me.dgw4.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32) })
						End While
						ModCommonClasses.con.Close()
						Me.dgw4.Visible = True
						Dim flag4 As Boolean = Me.dgw4.Rows.Count = 1
						If flag4 Then
							Me.dgw4.Focus()
							Me.RetrieveData2()
						Else
							Dim flag5 As Boolean = Me.dgw4.Rows.Count > 1
							If flag5 Then
								Me.dgw4.Focus()
								SendKeys.Send("{ENTER}")
							End If
						End If
						Me.btnAdd_Click(Me, EventArgs.Empty)
						Me.dgw4.Visible = False
					End If
				Next
				Dim dataTable As DataTable = New DataTable()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT PID, qty, barcode from Temp_product where variant_id=N'" + strVarinatid + "'", ModCommonClasses.con)
				dataTable.Rows.Clear()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				sqlDataAdapter2.Fill(dataTable)
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060088F7 RID: 35063 RVA: 0x00644CA0 File Offset: 0x00642EA0
		Private Sub btnGridUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.TextBox5.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.TextBox5.Text, Me.cmbProductName.Text, False) <> 0
					If flag2 Then
						MessageBox.Show("Please retrieve correct product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtBarcode.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
							If flag4 Then
								MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtQty.Focus()
							Else
								Dim flag5 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
								If flag5 Then
									MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtQty.Focus()
								Else
									Me.alt()
									Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
									Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
									Dim flag6 As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
									If flag6 Then
										MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.cmbUnit.Text = Me.TextBox4.Text
										Me.cmbUnit.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.txtMRP.Text, "", False) = 0
										If flag7 Then
											MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtMRP.Focus()
										Else
											Dim flag8 As Boolean = Operators.CompareString(Me.txtPricePerQty.Text, "", False) = 0
											If flag8 Then
												MessageBox.Show("Please enter price per qty.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtPricePerQty.Focus()
											Else
												Dim flag9 As Boolean = Operators.CompareString(Me.txtRetail.Text, "", False) = 0
												If flag9 Then
													MessageBox.Show("Please enter Retail Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtRetail.Focus()
												Else
													Dim flag10 As Boolean = Operators.CompareString(Me.txtWholesale.Text, "", False) = 0
													If flag10 Then
														MessageBox.Show("Please enter Wholesale Sale Price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.txtWholesale.Focus()
													Else
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text3 As String = "Select RTRIM(Temp_Stock.Barcode),RTRIM(Product.ProductName) from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Temp_Stock.Barcode=@d1"
														ModCommonClasses.cmd = New SqlCommand(text3)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text.ToString())
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
														If flag11 Then
															Dim flag12 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(1).ToString(), Me.TextBox5.Text.ToString(), False) <> 0
															If flag12 Then
																MessageBox.Show("Product name is being missmatched with Barcode !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Me.Clear()
																Return
															End If
															Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag13 Then
																ModCommonClasses.rdr.Close()
															End If
														End If
														ModCommonClasses.con.Close()
														Dim flag14 As Boolean = Conversion.Val(Me.txtPricePerQty.Text) > Conversion.Val(Me.txtMRP.Text)
														If flag14 Then
															Dim flag15 As Boolean = MessageBox.Show("You have enetered the MRP less than Sales Price, Do you really want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No
															If flag15 Then
																Return
															End If
														End If
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text4 As String = "select count(productid) as count from tbl_product_serial where invoice_no = @d1 AND sys_user = @d2 and barcode=@d3"
														ModCommonClasses.cmd = New SqlCommand(text4)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblUser.Text.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.ToString())
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag16 As Boolean = ModCommonClasses.rdr.Read()
														If flag16 Then
															Dim flag17 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), "0", False) <> 0
															If flag17 Then
																Dim flag18 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), Me.txtQty.Text.ToString(), False) <> 0
																If flag18 Then
																	MessageBox.Show("Serial number already generated with this Barcode and Quantaty mismatch also!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																	Me.Clear()
																	Return
																End If
															End If
															Dim flag19 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag19 Then
																ModCommonClasses.rdr.Close()
															End If
														End If
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text5 As String = "select count(productid) as count from tbl_product_serial_final where invoice_no = @d1 AND sys_user = @d2 and barcode=@d3"
														ModCommonClasses.cmd = New SqlCommand(text5)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtInvoiceNo.Text.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.lblUser.Text.ToString())
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text.ToString())
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
														Dim flag20 As Boolean = ModCommonClasses.rdr.Read()
														If flag20 Then
															Dim flag21 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), "0", False) <> 0
															If flag21 Then
																Dim flag22 As Boolean = Operators.CompareString(ModCommonClasses.rdr.GetValue(0).ToString(), Me.txtQty.Text.ToString(), False) <> 0
																If flag22 Then
																	MessageBox.Show("Serial number already generated with this Barcode and Quantaty mismatch also!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																	Me.Clear()
																	Return
																End If
															End If
															Dim flag23 As Boolean = ModCommonClasses.rdr IsNot Nothing
															If flag23 Then
																ModCommonClasses.rdr.Close()
															End If
														End If
														ModCommonClasses.con.Close()
														Me.autoupdateretailsaleprice()
														Me.autoupdatewholesalesaleprice()
														Me.autoupdatepurchaseprice()
														Me.autoupdateMRP()
														Dim checked As Boolean = Me.CheckBox8.Checked
														If checked Then
															Dim flag24 As Boolean = MessageBox.Show("Do you want to update the item's image ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
															If flag24 Then
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text6 As String = "update Product_Join set Photo=@d2 where ProductID=@d1"
																ModCommonClasses.cmd = New SqlCommand(text6)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																Dim memoryStream As MemoryStream = New MemoryStream()
																Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
																bitmap.Save(memoryStream, ImageFormat.Jpeg)
																Dim buffer As Byte() = memoryStream.GetBuffer()
																Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																sqlParameter.Value = buffer
																ModCommonClasses.cmd.Parameters.Add(sqlParameter)
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
																ModCommonClasses.cmd.ExecuteNonQuery()
																ModCommonClasses.con.Close()
															End If
														End If
														Dim index As Integer = Me.DataGridView1.CurrentRow.Index
														Me.DataGridView1(0, index).Value = Me.txtProductID.Text
														Me.DataGridView1(1, index).Value = Me.txtHSNCode.Text
														Me.DataGridView1(2, index).Value = Me.cmbProductName.Text
														Me.DataGridView1(3, index).Value = Me.txtBarcode.Text
														Me.DataGridView1(4, index).Value = Conversion.Val(Me.TextBox2.Text)
														Me.DataGridView1(5, index).Value = Conversion.Val(Me.txtMRP.Text)
														Me.DataGridView1(6, index).Value = Conversion.Val(Me.txtPricePerQty.Text)
														Me.DataGridView1(7, index).Value = Conversion.Val(Me.txtDiscPer.Text)
														Me.DataGridView1(8, index).Value = Conversion.Val(Me.txtDisc.Text)
														Me.DataGridView1(9, index).Value = Conversion.Val(Me.txtCGSTPer.Text)
														Me.DataGridView1(10, index).Value = Conversion.Val(Me.txtCGSTAmt.Text)
														Me.DataGridView1(11, index).Value = Conversion.Val(Me.txtSGSTPer.Text)
														Me.DataGridView1(12, index).Value = Conversion.Val(Me.txtSGSTAmt.Text)
														Me.DataGridView1(13, index).Value = Conversion.Val(Me.txtIGSTPer.Text)
														Me.DataGridView1(14, index).Value = Conversion.Val(Me.txtIGSTAmt.Text)
														Me.DataGridView1(15, index).Value = Conversion.Val(Me.txtCESSPer.Text)
														Me.DataGridView1(16, index).Value = Conversion.Val(Me.txtCESSAmt.Text)
														Me.DataGridView1(17, index).Value = Conversion.Val(Me.txtTotalAmount.Text)
														Me.DataGridView1(18, index).Value = Conversion.Val(Me.txtTempQty.Text)
														Me.DataGridView1(19, index).Value = Conversion.Val(Me.txtTaxableAmtI.Text)
														Me.DataGridView1(20, index).Value = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text)
														Me.DataGridView1(21, index).Value = Me.lblAltUnit.Text
														Me.DataGridView1(22, index).Value = Me.lblPTaxType.Text
														Me.DataGridView1(23, index).Value = Conversion.Val(Me.txtRetail.Text)
														Me.DataGridView1(24, index).Value = Conversion.Val(Me.txtWholesale.Text)
														Me.DataGridView1(25, index).Value = Me.cmbColor.Text
														Me.DataGridView1(26, index).Value = Me.cmbSize.Text
														Me.DataGridView1(27, index).Value = Me.txtInfo.Text
														Me.DataGridView1(28, index).Value = Me.txtBatchNo.Text
														Me.DataGridView1(29, index).Value = Me.txtMfg.Text
														Me.DataGridView1(30, index).Value = Me.txtExp.Text
														Me.DataGridView1(31, index).Value = Me.TextBox7.Text
														Me.DataGridView1(32, index).Value = Me.TextBox8.Text
														Me.DataGridView1(33, index).Value = Me.lblProductCat.Text
														Me.DataGridView1(34, index).Value = Me.TextBox4.Text
														Me.DataGridView1(35, index).Value = Me.txtIMEI1.Text
														Me.DataGridView1(36, index).Value = Me.txtIMEI2.Text
														Dim num As Double = Me.SubTotal()
														num = Math.Round(num, 2)
														Me.txtSubTotal.Text = Conversions.ToString(num)
														Me.Compute()
														Me.Clear()
														Me.GroupBox10.Visible = False
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
		End Sub

		' Token: 0x060088F8 RID: 35064 RVA: 0x00645B08 File Offset: 0x00643D08
		Private Sub txtDiscAmtPerQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscAmtPerQty.Text
					Dim selectionStart As Integer = Me.txtDiscAmtPerQty.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscAmtPerQty.SelectionLength
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

		' Token: 0x060088F9 RID: 35065 RVA: 0x00645C00 File Offset: 0x00643E00
		Private Sub calc100()
			Me.txtDisc.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtDiscAmtPerQty.Text) * Conversion.Val(Me.txtQty.Text), 2), "0.00")
		End Sub

		' Token: 0x060088FA RID: 35066 RVA: 0x0004300E File Offset: 0x0004120E
		Private Sub txtDiscAmtPerQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
		End Sub

		' Token: 0x060088FB RID: 35067 RVA: 0x00645C50 File Offset: 0x00643E50
		Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox4.Checked
			If checked Then
				Me.txtDisc.[ReadOnly] = False
				Me.txtDisc.BackColor = Color.LightYellow
			Else
				Dim flag As Boolean = Not Me.CheckBox4.Checked
				If flag Then
					Me.txtDisc.[ReadOnly] = True
					Me.txtDisc.BackColor = Color.WhiteSmoke
				End If
			End If
		End Sub

		' Token: 0x060088FC RID: 35068 RVA: 0x00043018 File Offset: 0x00041218
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.cmbBSundry.Text = "Bill Sundry"
		End Sub

		' Token: 0x060088FD RID: 35069 RVA: 0x00645CC0 File Offset: 0x00643EC0
		Private Sub dtpDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060088FE RID: 35070 RVA: 0x00645D6C File Offset: 0x00643F6C
		Public Sub GetQty_S1()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select IsNull(Sum(Qty),0) from Temp_Stock where Temp_Stock.ProductID=@d1 and Temp_Stock.Barcode=@d2"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.lblQty_S.Visible = True
					Me.lblQty_S.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x060088FF RID: 35071 RVA: 0x00645EC0 File Offset: 0x006440C0
		Private Sub cmbUnit_Validated(sender As Object, e As EventArgs)
			Me.alt()
			Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
			Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
			Dim flag As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
			If flag Then
				MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbUnit.Text = Me.TextBox4.Text
				Me.cmbUnit.Focus()
			End If
		End Sub

		' Token: 0x06008900 RID: 35072 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw4_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x06008901 RID: 35073 RVA: 0x00645F70 File Offset: 0x00644170
		Private Sub TextBox5_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06008902 RID: 35074 RVA: 0x00645FB8 File Offset: 0x006441B8
		Private Sub dgw4_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				Me.dgw4.Visible = False
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = ""
			Else
				Dim flag2 As Boolean = e.KeyCode = Keys.Back
				If flag2 Then
					Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
					Me.TextBox5.Focus()
					Me.TextBox5.ScrollToCaret()
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox5.Text, "", False) > 0
					If flag3 Then
						' The following expression was wrapped in a checked-expression
						Me.TextBox5.Text = Me.TextBox5.Text.Remove(Me.TextBox5.Text.Length - 1, 1)
						Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
						Me.TextBox5.Focus()
						Me.TextBox5.ScrollToCaret()
					End If
				End If
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.A
			If flag4 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "a"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.B
			If flag5 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "b"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.C
			If flag6 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "c"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag7 As Boolean = e.KeyCode = Keys.D
			If flag7 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "d"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag8 As Boolean = e.KeyCode = Keys.E
			If flag8 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "e"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag9 As Boolean = e.KeyCode = Keys.F
			If flag9 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "f"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag10 As Boolean = e.KeyCode = Keys.G
			If flag10 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "g"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag11 As Boolean = e.KeyCode = Keys.H
			If flag11 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "h"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag12 As Boolean = e.KeyCode = Keys.I
			If flag12 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "i"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag13 As Boolean = e.KeyCode = Keys.J
			If flag13 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "j"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag14 As Boolean = e.KeyCode = Keys.K
			If flag14 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "k"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag15 As Boolean = e.KeyCode = Keys.L
			If flag15 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "l"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag16 As Boolean = e.KeyCode = Keys.M
			If flag16 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "m"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag17 As Boolean = e.KeyCode = Keys.N
			If flag17 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "n"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag18 As Boolean = e.KeyCode = Keys.O
			If flag18 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "o"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag19 As Boolean = e.KeyCode = Keys.P
			If flag19 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "p"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag20 As Boolean = e.KeyCode = Keys.Q
			If flag20 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "q"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag21 As Boolean = e.KeyCode = Keys.R
			If flag21 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "r"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag22 As Boolean = e.KeyCode = Keys.S
			If flag22 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "s"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag23 As Boolean = e.KeyCode = Keys.T
			If flag23 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "t"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag24 As Boolean = e.KeyCode = Keys.U
			If flag24 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "u"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag25 As Boolean = e.KeyCode = Keys.V
			If flag25 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "v"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag26 As Boolean = e.KeyCode = Keys.W
			If flag26 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "w"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag27 As Boolean = e.KeyCode = Keys.X
			If flag27 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "x"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag28 As Boolean = e.KeyCode = Keys.Y
			If flag28 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "y"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag29 As Boolean = e.KeyCode = Keys.Z
			If flag29 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "z"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag30 As Boolean = e.KeyCode = Keys.D0
			If flag30 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "0"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag31 As Boolean = e.KeyCode = Keys.D1
			If flag31 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "1"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag32 As Boolean = e.KeyCode = Keys.D2
			If flag32 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "2"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag33 As Boolean = e.KeyCode = Keys.D3
			If flag33 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "3"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag34 As Boolean = e.KeyCode = Keys.D4
			If flag34 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "4"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag35 As Boolean = e.KeyCode = Keys.D5
			If flag35 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "5"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag36 As Boolean = e.KeyCode = Keys.D6
			If flag36 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "6"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag37 As Boolean = e.KeyCode = Keys.D7
			If flag37 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "7"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag38 As Boolean = e.KeyCode = Keys.D8
			If flag38 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "8"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag39 As Boolean = e.KeyCode = Keys.D9
			If flag39 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "9"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag40 As Boolean = e.KeyCode = Keys.Oemplus
			If flag40 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "+"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag41 As Boolean = e.KeyCode = Keys.OemMinus
			If flag41 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "-"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag42 As Boolean = e.KeyCode = Keys.OemBackslash
			If flag42 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + "\"
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
			Dim flag43 As Boolean = e.KeyCode = Keys.Oemcomma
			If flag43 Then
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
				Me.TextBox5.Text = Me.TextBox5.Text + ","
				Me.TextBox5.[Select](Me.TextBox5.Text.Length, 0)
				Me.TextBox5.Focus()
				Me.TextBox5.ScrollToCaret()
			End If
		End Sub

		' Token: 0x06008903 RID: 35075 RVA: 0x0004302C File Offset: 0x0004122C
		Private Sub txtQty_Leave(sender As Object, e As EventArgs)
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x06008904 RID: 35076 RVA: 0x00647A00 File Offset: 0x00645C00
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x06008905 RID: 35077 RVA: 0x0004303C File Offset: 0x0004123C
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06008906 RID: 35078 RVA: 0x00647A28 File Offset: 0x00645C28
		Public Sub RetrieveData1()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.dgw4.Visible = False
					Me.cmbSupplierName.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Me.GroupBox10.Visible = True
						Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
						Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.lblPTaxType.Text = dataGridViewRow.Cells(22).Value.ToString()
						Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.TextBox5.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Me.txtPricePerQty.Text = dataGridViewRow.Cells(6).Value.ToString()
						Me.txtMRP.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.txtDiscPer.Text = "0.00"
						Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.TextBox4.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.cmbaltunit.Text = dataGridViewRow.Cells(18).Value.ToString()
						Me.lblAltUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
						Me.TextBox3.Text = dataGridViewRow.Cells(19).Value.ToString()
						Me.lblAltValue.Text = dataGridViewRow.Cells(19).Value.ToString()
						Dim flag4 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) = 0
						If flag4 Then
							Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) <> 0
							If flag5 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
						End If
						Me.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
						Me.txtRetail.Text = dataGridViewRow.Cells(15).Value.ToString()
						Me.txtWholesale.Text = dataGridViewRow.Cells(14).Value.ToString()
						Me.lblProductCat.Text = dataGridViewRow.Cells(23).Value.ToString()
						Dim flag6 As Boolean = Operators.CompareString(Me.strStatus, "variant", False) = 0
						If flag6 Then
							Me.txtQty.Text = dataGridViewRow.Cells(32).Value.ToString()
						Else
							Dim flag7 As Boolean = Operators.CompareString(Me.strStatus, "new", False) = 0
							If flag7 Then
								Me.txtQty.Text = Conversions.ToString(Me.dbOpeningstock)
							Else
								Me.txtQty.Text = Conversions.ToString(1)
							End If
						End If
						Me.cmbColor.Text = dataGridViewRow.Cells(24).Value.ToString()
						Me.cmbSize.Text = dataGridViewRow.Cells(25).Value.ToString()
						Me.txtBatchNo.Text = dataGridViewRow.Cells(26).Value.ToString()
						Me.txtMfg.Text = dataGridViewRow.Cells(27).Value.ToString()
						Me.txtExp.Text = dataGridViewRow.Cells(28).Value.ToString()
						Me.txtIMEI1.Text = dataGridViewRow.Cells(29).Value.ToString()
						Me.txtIMEI2.Text = dataGridViewRow.Cells(30).Value.ToString()
						Me.Label20.Text = dataGridViewRow.Cells(31).Value.ToString()
						Me.lblAQty.Text = dataGridViewRow.Cells(32).Value.ToString()
						Me.txtBarcode.Focus()
						Me.GetQty_S1()
						Me.dgw4.Visible = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008907 RID: 35079 RVA: 0x00648100 File Offset: 0x00646300
		Public Sub RetrieveData2()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.dgw4.Visible = False
					Me.cmbSupplierName.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
						Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
						Me.lblPTaxType.Text = dataGridViewRow.Cells(22).Value.ToString()
						Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.Label40.Text = dataGridViewRow.Cells(2).Value.ToString()
						Me.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
						Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
						Me.txtPricePerQty.Text = dataGridViewRow.Cells(6).Value.ToString()
						Me.txtMRP.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.txtDiscPer.Text = "0.00"
						Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.TextBox4.Text = dataGridViewRow.Cells(13).Value.ToString()
						Me.cmbaltunit.Text = dataGridViewRow.Cells(18).Value.ToString()
						Me.lblAltUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
						Me.TextBox3.Text = dataGridViewRow.Cells(19).Value.ToString()
						Me.lblAltValue.Text = dataGridViewRow.Cells(19).Value.ToString()
						Dim flag4 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) = 0
						If flag4 Then
							Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) <> 0
							If flag5 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
						End If
						Me.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
						Me.txtRetail.Text = dataGridViewRow.Cells(15).Value.ToString()
						Me.txtWholesale.Text = dataGridViewRow.Cells(14).Value.ToString()
						Me.lblProductCat.Text = dataGridViewRow.Cells(23).Value.ToString()
						Dim flag6 As Boolean = Operators.CompareString(Me.strStatus, "variant", False) = 0
						If flag6 Then
							Me.txtQty.Text = dataGridViewRow.Cells(32).Value.ToString()
						Else
							Me.txtQty.Text = Conversions.ToString(Me.dbOpeningstock)
						End If
						Me.cmbColor.Text = dataGridViewRow.Cells(24).Value.ToString()
						Me.cmbSize.Text = dataGridViewRow.Cells(25).Value.ToString()
						Me.txtBatchNo.Text = dataGridViewRow.Cells(26).Value.ToString()
						Me.txtMfg.Text = dataGridViewRow.Cells(27).Value.ToString()
						Me.txtExp.Text = dataGridViewRow.Cells(28).Value.ToString()
						Me.txtIMEI1.Text = dataGridViewRow.Cells(29).Value.ToString()
						Me.txtIMEI2.Text = dataGridViewRow.Cells(30).Value.ToString()
						Me.Label20.Text = dataGridViewRow.Cells(31).Value.ToString()
						Me.txtBarcode.Focus()
						Me.GetQty_S1()
						Me.dgw4.Visible = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008908 RID: 35080 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008909 RID: 35081 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtReferenceNo1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890A RID: 35082 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbReverse_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890B RID: 35083 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbPurchaseType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890C RID: 35084 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890D RID: 35085 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSupplierInvoiceNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890E RID: 35086 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpSupplierInvoiceDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600890F RID: 35087 RVA: 0x0064877C File Offset: 0x0064697C
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox5.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Return
				End If
				Me.getgriditemdata()
				Me.dgw4.Visible = True
				Dim flag3 As Boolean = Me.dgw4.Rows.Count = 1
				If flag3 Then
					Me.dgw4.Focus()
					Me.RetrieveData1()
				Else
					Dim flag4 As Boolean = Me.dgw4.Rows.Count > 1
					If flag4 Then
						Me.dgw4.Focus()
						SendKeys.Send("{ENTER}")
					End If
				End If
				e.SuppressKeyPress = True
			End If
			Dim flag5 As Boolean = e.KeyCode = Keys.Down
			If flag5 Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x06008910 RID: 35088 RVA: 0x00648888 File Offset: 0x00646A88
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.txtQty.Focus()
			End If
		End Sub

		' Token: 0x06008911 RID: 35089 RVA: 0x006488B4 File Offset: 0x00646AB4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.txtPricePerQty.Focus()
			End If
		End Sub

		' Token: 0x06008912 RID: 35090 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008913 RID: 35091 RVA: 0x006488E0 File Offset: 0x00646AE0
		Private Sub txtMRP_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.txtRetail.Focus()
			End If
		End Sub

		' Token: 0x06008914 RID: 35092 RVA: 0x0064890C File Offset: 0x00646B0C
		Private Sub txtPricePerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.txtMRP.Focus()
			End If
		End Sub

		' Token: 0x06008915 RID: 35093 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008916 RID: 35094 RVA: 0x00648938 File Offset: 0x00646B38
		Private Sub txtRetail_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.txtWholesale.Focus()
			End If
		End Sub

		' Token: 0x06008917 RID: 35095 RVA: 0x00648964 File Offset: 0x00646B64
		Private Sub txtWholesale_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.btnAdd.Focus()
			End If
		End Sub

		' Token: 0x06008918 RID: 35096 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbColor_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008919 RID: 35097 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSize_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600891A RID: 35098 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtInfo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600891B RID: 35099 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBatchNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600891C RID: 35100 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpManufacturingDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600891D RID: 35101 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpExpiryDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600891E RID: 35102 RVA: 0x00648990 File Offset: 0x00646B90
		Private Sub Button19_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				MyProject.Forms.frmSuplBalanceLedger.txtSupplierID.Text = Me.txtSupplierID.Text
				MyProject.Forms.frmSuplBalanceLedger.ShowDialog()
			End If
		End Sub

		' Token: 0x0600891F RID: 35103 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008920 RID: 35104 RVA: 0x00043046 File Offset: 0x00041246
		Private Sub dtpManufacturingDate_ValueChanged(sender As Object, e As EventArgs)
			Me.txtMfg.Text = Me.dtpManufacturingDate.Text
		End Sub

		' Token: 0x06008921 RID: 35105 RVA: 0x00043060 File Offset: 0x00041260
		Private Sub dtpExpiryDate_ValueChanged(sender As Object, e As EventArgs)
			Me.txtExp.Text = Me.dtpExpiryDate.Text
		End Sub

		' Token: 0x06008922 RID: 35106 RVA: 0x0004307A File Offset: 0x0004127A
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Me.txtMfg.Text = ""
			Me.txtExp.Text = ""
		End Sub

		' Token: 0x06008923 RID: 35107 RVA: 0x0004309F File Offset: 0x0004129F
		Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)
			Me.taxableamtcal()
		End Sub

		' Token: 0x06008924 RID: 35108 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscAmtPerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008925 RID: 35109 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008926 RID: 35110 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008927 RID: 35111 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIGSTPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008928 RID: 35112 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCESSPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008929 RID: 35113 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbBSundry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600892A RID: 35114 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtFreightCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600892B RID: 35115 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtOtherCharges_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600892C RID: 35116 RVA: 0x00648A04 File Offset: 0x00646C04
		Private Sub txtTotalPaid_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				SendKeys.Send("{TAB}")
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600892D RID: 35117 RVA: 0x000430A9 File Offset: 0x000412A9
		Private Sub taxableamtcal()
			Me.TextBox6.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtSubTotal.Text), 2), "0.00")
		End Sub

		' Token: 0x0600892E RID: 35118 RVA: 0x00648A4C File Offset: 0x00646C4C
		Private Sub cmbSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtSup_ID.Text = ""
				Me.txtSupplierID.Text = ""
				Me.txtAddress.Text = ""
				Me.txtState.Text = ""
				Me.txtContactNo.Text = ""
				Me.txtGSTIN.Text = ""
				Me.txtSuplLimit.Text = ""
				Me.txtSuplLimitstatus.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(SupplierID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN), RTRIM(Limit), RTRIM(Lstatus),RTRIM(SCode) from Supplier where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtSuplLimit.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtSuplLimitstatus.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtScode.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.GetSupplierBalance()
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
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x0600892F RID: 35119 RVA: 0x00648D1C File Offset: 0x00646F1C
		Public Sub fillPurchaseID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(ST_ID) FROM Stock order by ST_ID ASC", ModCommonClasses.con)
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

		' Token: 0x06008930 RID: 35120 RVA: 0x00648E58 File Offset: 0x00647058
		Public Sub NextPrev()
			Try
				ModCommonClasses.con101.Close()
				ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con101.Open()
				ModCommonClasses.cmd = ModCommonClasses.con101.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),RTRIM(TaxType),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name), SubTotal, CGST,SGST,IGST,CESS,FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks), RTRIM(Stock.BillSundry),Doc,RTRIM(Supplier.SCode),RTRIM(BankAccount) from Supplier,Stock where Supplier.ID=Stock.SupplierID  and ST_ID=@d1", ModCommonClasses.con101)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtST_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtInvoiceNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpDate.Value = Conversions.ToDate(ModCommonClasses.rdr.GetValue(2).ToString())
					Me.txtReferenceNo1.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.cmbReverse.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbPurchaseType.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtGSTNonGST.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.lbltaxtype.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtSupplierInvoiceNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.dtpSupplierInvoiceDate.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.cmbSupplierName.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtDiscPer.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtFreightCharges.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtOtherCharges.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.txtPreviousDue.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.txtTotal.Text = ModCommonClasses.rdr.GetValue(20).ToString()
					Me.txtRoundOff.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(22).ToString()
					Me.txtTotalPaid.Text = ModCommonClasses.rdr.GetValue(23).ToString()
					Me.txtBalance.Text = ModCommonClasses.rdr.GetValue(24).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(25).ToString()
					Me.cmbBSundry.Text = ModCommonClasses.rdr.GetValue(26).ToString()
					Me.txtScode.Text = ModCommonClasses.rdr.GetValue(28).ToString()
					Me.cmbAccountNo.Text = ModCommonClasses.rdr.GetValue(29).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(27), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Me.limitsearch()
					Me.btnSave.Enabled = False
					Me.GetSupplierBalance1()
					Me.btnDelete.Enabled = True
					Me.btnUpdate.Enabled = True
					Me.btnPrint.Enabled = True
					Me.GetSupplierInfo()
					Me.btnSelection.Enabled = False
					Me.lblSet.Text = "Not Allowed"
					ModCommonClasses.con101.Close()
					ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con101.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Stock_Product.Barcode),Qty,Stock_Product.MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,Qty,Stock_Product.TaxableAmt,Stock_Product.AltQty,Stock_Product.AltUnit,Stock_Product.PTaxType,Stock_Product.RPrice,Stock_Product.WPrice,RTRIM(Stock_Product.Color),RTRIM(Stock_Product.Size),RTRIM(Stock_Product.Info),RTRIM(Stock_Product.Batch),RTRIM(Stock_Product.Mfgdate),RTRIM(Stock_Product.Expdate),RTRIM(Stock_Product.RCipher),RTRIM(Stock_Product.WCipher),RTRIM(Stock_Product.Category),RTRIM(Stock_Product.MainUnit),RTRIM(Stock_Product.IMEI1),RTRIM(Stock_Product.IMEI2) from Product,Stock,Stock_Product where product.PID=Stock_product.ProductID and Stock.ST_ID=Stock_Product.StockID and ST_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con101)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					Me.DataGridView2.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34), ModCommonClasses.rdr(35), ModCommonClasses.rdr(36) })
						Me.DataGridView2.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33), ModCommonClasses.rdr(34) })
					End While
					ModCommonClasses.con101.Close()
					Me.DataGridView1.ClearSelection()
					Me.DataGridView2.ClearSelection()
					Me.Calc()
					Me.Compute()
					Me.GetQty_S1()
				End If
			Catch ex As Exception
			End Try
			Me.Clear()
		End Sub

		' Token: 0x06008931 RID: 35121 RVA: 0x0064989C File Offset: 0x00647A9C
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

		' Token: 0x06008932 RID: 35122 RVA: 0x0064993C File Offset: 0x00647B3C
		Private Sub Button22_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x06008933 RID: 35123 RVA: 0x0064999C File Offset: 0x00647B9C
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column6").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column3").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column26").Value)))
					Me.a3 = Me.DataGridView1.Rows(i).Cells("Column27").Value.ToString()
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { Me.a1 + " " + Me.a2 + Me.a3 + " " + Me.txtRsToWords.Text }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06008934 RID: 35124 RVA: 0x00649B64 File Offset: 0x00647D64
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x06008935 RID: 35125 RVA: 0x00649BA8 File Offset: 0x00647DA8
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x06008936 RID: 35126 RVA: 0x00649BF8 File Offset: 0x00647DF8
		Private Sub Button33_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				MyProject.Forms.frmProductLedgerPOS.txtCustomerID.Text = Conversions.ToString(Conversion.Val(Me.txtProductID.Text))
				MyProject.Forms.frmProductLedgerPOS.lblBarcode.Text = Me.txtBarcode.Text
				MyProject.Forms.frmProductLedgerPOS.Button3.Visible = True
				MyProject.Forms.frmProductLedgerPOS.ShowDialog()
			End If
		End Sub

		' Token: 0x06008937 RID: 35127 RVA: 0x00649CAC File Offset: 0x00647EAC
		Private Sub DataforNP()
			ModCommonClasses.con101.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con101.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Stock", ModCommonClasses.con101)
			Me.Dad.Fill(Me.Dst, "Stock")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Stock").Rows(Conversions.ToInteger(Me.CurrentRow))("ST_ID"))
				ModCommonClasses.con101.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con101.Close()
		End Sub

		' Token: 0x06008938 RID: 35128 RVA: 0x00649D88 File Offset: 0x00647F88
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtST_ID.Text))
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

		' Token: 0x06008939 RID: 35129 RVA: 0x00649E44 File Offset: 0x00648044
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtST_ID.Text))
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

		' Token: 0x0600893A RID: 35130 RVA: 0x00649EF0 File Offset: 0x006480F0
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Stock").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Stock").Rows(Conversions.ToInteger(Me.CurrentRow))("ST_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600893B RID: 35131 RVA: 0x00649FA8 File Offset: 0x006481A8
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Stock").Rows(Conversions.ToInteger(Me.CurrentRow))("ST_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600893C RID: 35132 RVA: 0x0064A040 File Offset: 0x00648240
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment_Withdrawal.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment_Withdrawal.Reset()
			MyProject.Forms.frmPayment_Withdrawal.ShowDialog()
			MyProject.Forms.frmPayment_Withdrawal.Dispose()
		End Sub

		' Token: 0x0600893D RID: 35133 RVA: 0x000430DD File Offset: 0x000412DD
		Private Sub lblPTaxType_Click(sender As Object, e As EventArgs)
			Me.Calc()
			Me.Compute()
		End Sub

		' Token: 0x0600893E RID: 35134 RVA: 0x000430EE File Offset: 0x000412EE
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
			Me.CheckBox3.Checked = False
		End Sub

		' Token: 0x0600893F RID: 35135 RVA: 0x0064A0A0 File Offset: 0x006482A0
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.txtBarcode.Text.Length > 0
			If flag Then
				MyProject.Forms.frmBarcodeLabelPrinting.txtBCode.Text = Me.txtBarcode.Text.ToString()
				MyProject.Forms.frmBarcodeLabelPrinting.SearchbyBCode()
				MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
			Else
				MessageBox.Show("You have not selected the Barcode !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06008940 RID: 35136 RVA: 0x0064A124 File Offset: 0x00648324
		Private Sub cmbSupplierName_Validated(sender As Object, e As EventArgs)
			Dim focused As Boolean = Me.cmbSupplierName.Focused
			If focused Then
				Dim flag As Boolean = Me.cmbSupplierName.SelectedIndex = -1
				If flag Then
					MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbSupplierName.Focus()
				End If
			End If
		End Sub

		' Token: 0x06008941 RID: 35137 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008942 RID: 35138 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIMEI1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008943 RID: 35139 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIMEI2_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06008944 RID: 35140 RVA: 0x0064A178 File Offset: 0x00648378
		Private Sub Picture_DoubleClick(sender As Object, e As EventArgs)
			MyProject.Forms.frmContactPhoto.PictureBox1.Image = Me.Picture.Image
			MyProject.Forms.frmContactPhoto.ShowDialog()
			MyProject.Forms.frmContactPhoto.Dispose()
		End Sub

		' Token: 0x06008945 RID: 35141 RVA: 0x00043128 File Offset: 0x00041328
		Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
			Me.CheckBox2.Checked = False
		End Sub

		' Token: 0x06008946 RID: 35142 RVA: 0x0064A1C8 File Offset: 0x006483C8
		Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox5.Checked
			If checked Then
				Me.Label65.Visible = True
				Me.Label66.Visible = True
				Me.Label67.Visible = True
				Me.cmbColor.Visible = True
				Me.cmbSize.Visible = True
				Me.txtInfo.Visible = True
				Me.Button7.Visible = True
				Me.txtMfg.Visible = True
				Me.txtExp.Visible = True
				Me.dtpManufacturingDate.Visible = True
				Me.dtpExpiryDate.Visible = True
				Me.txtBatchNo.Visible = True
				Me.Label68.Visible = True
				Me.Label69.Visible = True
				Me.Label70.Visible = True
				Me.Label75.Visible = True
				Me.Label76.Visible = True
				Me.txtIMEI1.Visible = True
				Me.txtIMEI2.Visible = True
				Me.Label25.Visible = True
				Me.Label22.Visible = True
				Me.txtCGSTPer.Visible = True
				Me.txtCGSTAmt.Visible = True
				Me.Label33.Visible = True
				Me.Label28.Visible = True
				Me.txtSGSTPer.Visible = True
				Me.txtSGSTAmt.Visible = True
				Me.Label35.Visible = True
				Me.Label34.Visible = True
				Me.txtIGSTPer.Visible = True
				Me.txtIGSTAmt.Visible = True
				Me.Label42.Visible = True
				Me.Label41.Visible = True
				Me.txtCESSPer.Visible = True
				Me.txtCESSAmt.Visible = True
				Me.Label63.Visible = True
				Me.txtRetail.Visible = True
				Me.Label64.Visible = True
				Me.txtWholesale.Visible = True
			Else
				Dim flag As Boolean = Not Me.CheckBox5.Checked
				If flag Then
					Me.Label65.Visible = False
					Me.Label66.Visible = False
					Me.Label67.Visible = False
					Me.cmbColor.Visible = False
					Me.cmbSize.Visible = False
					Me.txtInfo.Visible = False
					Me.Button7.Visible = False
					Me.txtMfg.Visible = False
					Me.txtExp.Visible = False
					Me.dtpManufacturingDate.Visible = False
					Me.dtpExpiryDate.Visible = False
					Me.txtBatchNo.Visible = False
					Me.Label68.Visible = False
					Me.Label69.Visible = False
					Me.Label70.Visible = False
					Me.Label75.Visible = False
					Me.Label76.Visible = False
					Me.txtIMEI1.Visible = False
					Me.txtIMEI2.Visible = False
					Me.Label25.Visible = False
					Me.Label22.Visible = False
					Me.txtCGSTPer.Visible = False
					Me.txtCGSTAmt.Visible = False
					Me.Label33.Visible = False
					Me.Label28.Visible = False
					Me.txtSGSTPer.Visible = False
					Me.txtSGSTAmt.Visible = False
					Me.Label35.Visible = False
					Me.Label34.Visible = False
					Me.txtIGSTPer.Visible = False
					Me.txtIGSTAmt.Visible = False
					Me.Label42.Visible = False
					Me.Label41.Visible = False
					Me.txtCESSPer.Visible = False
					Me.txtCESSAmt.Visible = False
					Me.Label63.Visible = False
					Me.txtRetail.Visible = False
					Me.Label64.Visible = False
					Me.txtWholesale.Visible = False
				End If
			End If
		End Sub

		' Token: 0x06008947 RID: 35143 RVA: 0x00043162 File Offset: 0x00041362
		Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
			Me.TextBox5.Text = ""
		End Sub

		' Token: 0x06008948 RID: 35144 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw4 As DataGridView, setting As Boolean)
			Dim type As Type = dgw4.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw4, setting, Nothing)
		End Sub

		' Token: 0x06008949 RID: 35145 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub ProductDoubleBuffered(DataGridView1 As DataGridView, setting As Boolean)
			Dim type As Type = DataGridView1.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(DataGridView1, setting, Nothing)
		End Sub

		' Token: 0x0600894A RID: 35146 RVA: 0x005ED880 File Offset: 0x005EBA80
		Public Sub Clear_SerialData()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim sqlCommand As SqlCommand = Nothing
			Try
				sqlConnection.Open()
				Dim text As String = "DELETE FROM tbl_product_serial"
				sqlCommand = New SqlCommand(text, sqlConnection)
				Dim num As Integer = sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = sqlCommand IsNot Nothing
				If flag Then
					sqlCommand.Dispose()
				End If
				Dim flag2 As Boolean = sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
					sqlConnection.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600894B RID: 35147 RVA: 0x0064A5FC File Offset: 0x006487FC
		Private Sub frmPurchaseEntry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					Me.Clear_SerialData()
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F2
			If flag3 Then
				e.Handled = True
				Me.GelButton5.PerformClick()
			End If
			Dim flag4 As Boolean = e.KeyCode = Keys.F3
			If flag4 Then
				e.Handled = True
				Dim flag5 As Boolean = Me.btnUpdate.Enabled AndAlso Me.btnUpdate.Visible
				If flag5 Then
					Me.btnUpdate.PerformClick()
				End If
			End If
			Dim flag6 As Boolean = e.KeyCode = Keys.F6
			If flag6 Then
				e.Handled = True
				Dim flag7 As Boolean = Me.btnPrint.Enabled AndAlso Me.btnPrint.Visible
				If flag7 Then
					Me.btnPrint.PerformClick()
				End If
			End If
		End Sub

		' Token: 0x0600894C RID: 35148 RVA: 0x0064A704 File Offset: 0x00648904
		Public Sub InvoiceHead()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(LIDS) from InvoiceHead"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.InvDateSts = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.InvDateSts = "No"
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

		' Token: 0x0600894D RID: 35149 RVA: 0x0064A7FC File Offset: 0x006489FC
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Stock order by ST_ID DESC"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.prevdate = Conversions.ToDate(ModCommonClasses.rdr.GetValue(0).ToString())
				Else
					Me.prevdate = DateAndTime.Today
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(Me.InvDateSts, "Yes", False) = 0
				If flag4 Then
					Me.dtpDate.Value = Me.prevdate
				Else
					Me.dtpDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600894E RID: 35150 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDisc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600894F RID: 35151 RVA: 0x00043176 File Offset: 0x00041376
		Public Sub customerdetaildisable()
			Me.cmbSupplierName.Enabled = False
			Me.btnSelection.Enabled = False
		End Sub

		' Token: 0x06008950 RID: 35152 RVA: 0x00043193 File Offset: 0x00041393
		Public Sub customerdetailenable()
			Me.cmbSupplierName.Enabled = True
			Me.btnSelection.Enabled = True
		End Sub

		' Token: 0x06008951 RID: 35153 RVA: 0x0064A93C File Offset: 0x00648B3C
		Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = Me.DataGridView1.RowCount > 0
			If flag Then
				Me.customerdetaildisable()
			End If
		End Sub

		' Token: 0x06008952 RID: 35154 RVA: 0x0064A968 File Offset: 0x00648B68
		Public Sub fillColor()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Color) FROM Stock_Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbColor.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbColor.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06008953 RID: 35155 RVA: 0x0064AAA4 File Offset: 0x00648CA4
		Public Sub fillSize()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Size) FROM Stock_Product", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSize.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSize.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06008954 RID: 35156 RVA: 0x0064ABE0 File Offset: 0x00648DE0
		Public Sub CipherCode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(c0),RTRIM(c1),RTRIM(c2),RTRIM(c3),RTRIM(c4),RTRIM(c5),RTRIM(c6),RTRIM(c7),RTRIM(c8),RTRIM(c9),RTRIM(c12),RTRIM(c13),RTRIM(c14) from CipherCode", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.b0 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
					Me.b1 = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.b2 = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.b3 = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.b4 = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.b5 = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.b6 = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.b7 = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.b8 = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.b9 = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.b12 = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.b13 = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.b14 = ModCommonClasses.rdr.GetValue(12).ToString()
				Else
					Me.b0 = Conversions.ToString(0)
					Me.b1 = Conversions.ToString(1)
					Me.b2 = Conversions.ToString(2)
					Me.b3 = Conversions.ToString(3)
					Me.b4 = Conversions.ToString(4)
					Me.b5 = Conversions.ToString(5)
					Me.b6 = Conversions.ToString(6)
					Me.b7 = Conversions.ToString(7)
					Me.b8 = Conversions.ToString(8)
					Me.b9 = Conversions.ToString(9)
					Me.b12 = Conversions.ToString(0)
					Me.b13 = Conversions.ToString(0)
					Me.b14 = "No"
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				Me.b0 = Conversions.ToString(0)
				Me.b1 = Conversions.ToString(1)
				Me.b2 = Conversions.ToString(2)
				Me.b3 = Conversions.ToString(3)
				Me.b4 = Conversions.ToString(4)
				Me.b5 = Conversions.ToString(5)
				Me.b6 = Conversions.ToString(6)
				Me.b7 = Conversions.ToString(7)
				Me.b8 = Conversions.ToString(8)
				Me.b9 = Conversions.ToString(9)
				Me.b12 = Conversions.ToString(0)
				Me.b13 = Conversions.ToString(0)
				Me.b14 = "No"
			End Try
		End Sub

		' Token: 0x06008955 RID: 35157 RVA: 0x0064AEE4 File Offset: 0x006490E4
		Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox6.Checked
			If checked Then
				Me.TextBox7.Text = Me.TextBox9.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox7.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox7.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox7.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox7.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox7.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox7.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox7.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox7.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox7.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox7.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
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
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox7.Text, "", False) = 0
					If flag11 Then
						Me.TextBox7.Text = Me.TextBox9.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox6.Checked
				If flag12 Then
					Me.TextBox7.Text = Me.TextBox9.Text
				End If
			End If
		End Sub

		' Token: 0x06008956 RID: 35158 RVA: 0x0064B2B4 File Offset: 0x006494B4
		Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox9.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtRetail.Text)) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox9.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtRetail.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox6.Checked
			If checked Then
				Me.TextBox7.Text = Me.TextBox9.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox7.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox7.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox7.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox7.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox7.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox7.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox7.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox7.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox7.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox7.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox7.Text = Strings.Replace(Me.TextBox7.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
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
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox7.Text, "", False) = 0
					If flag12 Then
						Me.TextBox7.Text = Me.TextBox9.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox6.Checked
				If flag13 Then
					Me.TextBox7.Text = Me.TextBox9.Text
				End If
			End If
		End Sub

		' Token: 0x06008957 RID: 35159 RVA: 0x0064B6FC File Offset: 0x006498FC
		Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.TextBox8.Text = Me.TextBox10.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag As Boolean = Strings.InStr(Me.TextBox8.Text, "0", CompareMethod.Binary) <> 0
					If flag Then
						Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag2 As Boolean = Strings.InStr(Me.TextBox8.Text, "1", CompareMethod.Binary) <> 0
						If flag2 Then
							Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag3 As Boolean = Strings.InStr(Me.TextBox8.Text, "2", CompareMethod.Binary) <> 0
							If flag3 Then
								Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag4 As Boolean = Strings.InStr(Me.TextBox8.Text, "3", CompareMethod.Binary) <> 0
								If flag4 Then
									Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag5 As Boolean = Strings.InStr(Me.TextBox8.Text, "4", CompareMethod.Binary) <> 0
									If flag5 Then
										Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag6 As Boolean = Strings.InStr(Me.TextBox8.Text, "5", CompareMethod.Binary) <> 0
										If flag6 Then
											Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag7 As Boolean = Strings.InStr(Me.TextBox8.Text, "6", CompareMethod.Binary) <> 0
											If flag7 Then
												Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag8 As Boolean = Strings.InStr(Me.TextBox8.Text, "7", CompareMethod.Binary) <> 0
												If flag8 Then
													Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag9 As Boolean = Strings.InStr(Me.TextBox8.Text, "8", CompareMethod.Binary) <> 0
													If flag9 Then
														Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag10 As Boolean = Strings.InStr(Me.TextBox8.Text, "9", CompareMethod.Binary) <> 0
														If flag10 Then
															Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
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
					Dim flag11 As Boolean = Operators.CompareString(Me.TextBox8.Text, "", False) = 0
					If flag11 Then
						Me.TextBox8.Text = Me.TextBox10.Text
					End If
				End While
			Else
				Dim flag12 As Boolean = Not Me.CheckBox7.Checked
				If flag12 Then
					Me.TextBox8.Text = Me.TextBox10.Text
				End If
			End If
		End Sub

		' Token: 0x06008958 RID: 35160 RVA: 0x0064BACC File Offset: 0x00649CCC
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox10.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtWholesale.Text)) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox10.Text = Conversions.ToString(Math.Round(Conversion.Val(Me.txtWholesale.Text)))
			End If
			Dim checked As Boolean = Me.CheckBox7.Checked
			If checked Then
				Me.TextBox8.Text = Me.TextBox10.Text
				Dim i As Integer = 0
				While i < 1000
					i += 1
					Dim flag2 As Boolean = Strings.InStr(Me.TextBox8.Text, "0", CompareMethod.Binary) <> 0
					If flag2 Then
						Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(0), Me.b0, 1, -1, CompareMethod.Binary)
					Else
						Dim flag3 As Boolean = Strings.InStr(Me.TextBox8.Text, "1", CompareMethod.Binary) <> 0
						If flag3 Then
							Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(1), Me.b1, 1, -1, CompareMethod.Binary)
						Else
							Dim flag4 As Boolean = Strings.InStr(Me.TextBox8.Text, "2", CompareMethod.Binary) <> 0
							If flag4 Then
								Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(2), Me.b2, 1, -1, CompareMethod.Binary)
							Else
								Dim flag5 As Boolean = Strings.InStr(Me.TextBox8.Text, "3", CompareMethod.Binary) <> 0
								If flag5 Then
									Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(3), Me.b3, 1, -1, CompareMethod.Binary)
								Else
									Dim flag6 As Boolean = Strings.InStr(Me.TextBox8.Text, "4", CompareMethod.Binary) <> 0
									If flag6 Then
										Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(4), Me.b4, 1, -1, CompareMethod.Binary)
									Else
										Dim flag7 As Boolean = Strings.InStr(Me.TextBox8.Text, "5", CompareMethod.Binary) <> 0
										If flag7 Then
											Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(5), Me.b5, 1, -1, CompareMethod.Binary)
										Else
											Dim flag8 As Boolean = Strings.InStr(Me.TextBox8.Text, "6", CompareMethod.Binary) <> 0
											If flag8 Then
												Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(6), Me.b6, 1, -1, CompareMethod.Binary)
											Else
												Dim flag9 As Boolean = Strings.InStr(Me.TextBox8.Text, "7", CompareMethod.Binary) <> 0
												If flag9 Then
													Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(7), Me.b7, 1, -1, CompareMethod.Binary)
												Else
													Dim flag10 As Boolean = Strings.InStr(Me.TextBox8.Text, "8", CompareMethod.Binary) <> 0
													If flag10 Then
														Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(8), Me.b8, 1, -1, CompareMethod.Binary)
													Else
														Dim flag11 As Boolean = Strings.InStr(Me.TextBox8.Text, "9", CompareMethod.Binary) <> 0
														If flag11 Then
															Me.TextBox8.Text = Strings.Replace(Me.TextBox8.Text, Conversions.ToString(9), Me.b9, 1, -1, CompareMethod.Binary)
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
					Dim flag12 As Boolean = Operators.CompareString(Me.TextBox8.Text, "", False) = 0
					If flag12 Then
						Me.TextBox8.Text = Me.TextBox10.Text
					End If
				End While
			Else
				Dim flag13 As Boolean = Not Me.CheckBox7.Checked
				If flag13 Then
					Me.TextBox8.Text = Me.TextBox10.Text
				End If
			End If
		End Sub

		' Token: 0x06008959 RID: 35161 RVA: 0x0064BF14 File Offset: 0x0064A114
		Private Sub txtRetail_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox9.Text = Conversions.ToString(Conversion.Val(Me.txtRetail.Text) + Conversions.ToDouble(Me.b12))
			Else
				Me.TextBox9.Text = Conversions.ToString(Conversion.Val(Me.txtRetail.Text))
			End If
		End Sub

		' Token: 0x0600895A RID: 35162 RVA: 0x0064BF90 File Offset: 0x0064A190
		Private Sub txtWholesale_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.b14, "Yes", False) = 0
			If flag Then
				Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.txtWholesale.Text) + Conversions.ToDouble(Me.b13))
			Else
				Me.TextBox10.Text = Conversions.ToString(Conversion.Val(Me.txtWholesale.Text))
			End If
		End Sub

		' Token: 0x0600895B RID: 35163 RVA: 0x0064C00C File Offset: 0x0064A20C
		Public Sub SpplLastItemAmount()
			Dim flag As Boolean = (Me.txtSup_ID.Text.Length > 0) And (Me.txtProductID.Text.Length > 0)
			If flag Then
				Try
					ModCommonClasses.con102 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con102.Open()
					ModCommonClasses.cmd102 = ModCommonClasses.con102.CreateCommand()
					ModCommonClasses.cmd102.CommandText = "SELECT Top 1 RTRIM(Stock_Product.Price),Stock.Date from Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID WHERE RTRIM(Supplier.ID)=@d1 and RTRIM(Product.PID)=@d2 order by ST_ID DESC"
					ModCommonClasses.cmd102.Parameters.AddWithValue("@d1", Me.txtSup_ID.Text)
					ModCommonClasses.cmd102.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
					ModCommonClasses.rdr102 = ModCommonClasses.cmd102.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr102.Read()
					If flag2 Then
						Me.lblSuplLastPur.Text = ModCommonClasses.rdr102.GetValue(0).ToString()
					Else
						Me.lblSuplLastPur.Text = "0"
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr102 IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr102.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con102.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con102.Close()
					End If
					Me.lblSuplLastPur.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblSuplLastPur.Text), 2), "0.00")
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600895C RID: 35164 RVA: 0x0064C1C0 File Offset: 0x0064A3C0
		Public Sub SpplLastItemAmount1()
			Dim flag As Boolean = (Me.txtSup_ID.Text.Length > 0) And (Me.txtProductID.Text.Length > 0)
			If flag Then
				Try
					ModCommonClasses.con101 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con101.Open()
					ModCommonClasses.cmd101 = ModCommonClasses.con101.CreateCommand()
					ModCommonClasses.cmd101.CommandText = "SELECT Top 1 RTRIM(Stock_Product.Price),Stock.Date from Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID WHERE RTRIM(Supplier.ID)=@d1 and RTRIM(Product.PID)=@d2 order by ST_ID DESC"
					ModCommonClasses.cmd101.Parameters.AddWithValue("@d1", Me.txtSup_ID.Text)
					ModCommonClasses.cmd101.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
					ModCommonClasses.rdr101 = ModCommonClasses.cmd101.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr101.Read()
					If flag2 Then
						Me.lblSuplLastPur.Text = ModCommonClasses.rdr101.GetValue(0).ToString()
					Else
						Me.lblSuplLastPur.Text = "0"
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr101 IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr101.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con101.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con101.Close()
					End If
					Me.lblSuplLastPur.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblSuplLastPur.Text), 2), "0.00")
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600895D RID: 35165 RVA: 0x0064C374 File Offset: 0x0064A574
		Public Sub LastItemPurcAmount()
			Dim flag As Boolean = Me.txtProductID.Text.Length > 0
			If flag Then
				Try
					ModCommonClasses.con102 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con102.Open()
					Dim num As Integer = 5
					ModCommonClasses.cmd102 = ModCommonClasses.con102.CreateCommand()
					ModCommonClasses.cmd102.CommandText = "SELECT Top 1 RTRIM(Stock_Product.Price),Stock.Date from Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Product ON Stock_Product.ProductID = Product.PID WHERE RTRIM(Product.PID)=@d2 order by ST_ID DESC"
					ModCommonClasses.cmd102.Parameters.AddWithValue("@d2", Me.txtProductID.Text)
					ModCommonClasses.cmd102.CommandTimeout = num
					ModCommonClasses.rdr102 = ModCommonClasses.cmd102.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr102.Read()
					If flag2 Then
						Me.lblLastItemPurPrice.Text = ModCommonClasses.rdr102.GetValue(0).ToString()
					Else
						Me.lblSuplLastPur.Text = "0"
					End If
					Dim flag3 As Boolean = ModCommonClasses.rdr102 IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr102.Close()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con102.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con102.Close()
					End If
					Me.lblLastItemPurPrice.Text = Strings.Format(Math.Round(Conversion.Val(Me.lblLastItemPurPrice.Text), 2), "0.00")
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600895E RID: 35166 RVA: 0x000431B0 File Offset: 0x000413B0
		Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs)
			Me.SpplLastItemAmount()
			Me.LastItemPurcAmount()
			Me.UnitInfo()
			Me.Item_Img()
		End Sub

		' Token: 0x0600895F RID: 35167 RVA: 0x000431CF File Offset: 0x000413CF
		Private Sub txtSup_ID_TextChanged(sender As Object, e As EventArgs)
			Me.SpplLastItemAmount1()
		End Sub

		' Token: 0x06008960 RID: 35168 RVA: 0x0064C504 File Offset: 0x0064A704
		Private Sub Print()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("PID")
				dataTable2.Columns.Add("ProductName")
				dataTable2.Columns.Add("HSNC")
				dataTable2.Columns.Add("MainQty")
				dataTable2.Columns.Add("AltQty")
				dataTable2.Columns.Add("AltUnit")
				dataTable2.Columns.Add("MRP")
				dataTable2.Columns.Add("Rate")
				dataTable2.Columns.Add("DiscPer")
				dataTable2.Columns.Add("Disc")
				dataTable2.Columns.Add("TaxableAmt")
				dataTable2.Columns.Add("CGSTPer")
				dataTable2.Columns.Add("CGST")
				dataTable2.Columns.Add("SGSTPer")
				dataTable2.Columns.Add("SGST")
				dataTable2.Columns.Add("IGSTPer")
				dataTable2.Columns.Add("IGST")
				dataTable2.Columns.Add("CESSPer")
				dataTable2.Columns.Add("CESS")
				dataTable2.Columns.Add("Amount")
				dataTable2.Columns.Add("Barcode")
				dataTable2.Columns.Add("Batch")
				dataTable2.Columns.Add("Mfg")
				dataTable2.Columns.Add("Exp")
				dataTable2.Columns.Add("Size")
				dataTable2.Columns.Add("Colour")
				dataTable2.Columns.Add("MainUnit")
				dataTable2.Columns.Add("IMEI1")
				dataTable2.Columns.Add("IMEI2")
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(20).Value, dataGridViewRow.Cells(21).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(19).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value, dataGridViewRow.Cells(11).Value, dataGridViewRow.Cells(12).Value, dataGridViewRow.Cells(13).Value, dataGridViewRow.Cells(14).Value, dataGridViewRow.Cells(15).Value, dataGridViewRow.Cells(16).Value, dataGridViewRow.Cells(17).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(28).Value, dataGridViewRow.Cells(29).Value, dataGridViewRow.Cells(30).Value, dataGridViewRow.Cells(26).Value, dataGridViewRow.Cells(25).Value, dataGridViewRow.Cells(34).Value, dataGridViewRow.Cells(35).Value, dataGridViewRow.Cells(36).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New ReportDocument()
				reportDocument = New A4PurchaseInv()
				reportDocument.SetDataSource(dataTable)
				reportDocument.SetParameterValue("P5", Me.cmbBSundry.Text)
				reportDocument.SetParameterValue("Bill Sundry", Me.txtFreightCharges.Text)
				reportDocument.SetParameterValue("Bill Discount", Me.txtOtherCharges.Text)
				reportDocument.SetParameterValue("Grand Total", Me.txtCurAmt.Text)
				reportDocument.SetParameterValue("Roundoff", Me.txtRoundOff.Text)
				reportDocument.SetParameterValue("Net Total", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("PrevDue", Me.txtPreviousDue.Text)
				reportDocument.SetParameterValue("Paid", Me.txtTotalPaid.Text)
				reportDocument.SetParameterValue("Pending", Me.txtBalance.Text)
				reportDocument.SetParameterValue("SuplName", Me.cmbSupplierName.Text)
				reportDocument.SetParameterValue("Address", Me.txtAddress.Text)
				reportDocument.SetParameterValue("CompContact", Me.txtContactNo.Text)
				reportDocument.SetParameterValue("CompGSTIN", Me.txtGSTIN.Text)
				reportDocument.SetParameterValue("State", Me.txtState.Text)
				reportDocument.SetParameterValue("SuplInv", Me.txtSupplierInvoiceNo.Text)
				reportDocument.SetParameterValue("SuplDate", Me.dtpSupplierInvoiceDate.Text)
				reportDocument.SetParameterValue("Invoice No", Me.txtInvoiceNo.Text)
				reportDocument.SetParameterValue("Inv Date", Me.dtpDate.Text)
				reportDocument.SetParameterValue("RefNo", Me.txtReferenceNo1.Text)
				reportDocument.SetParameterValue("Reverse", Me.cmbReverse.Text)
				reportDocument.SetParameterValue("PurcType", Me.cmbPurchaseType.Text)
				reportDocument.SetParameterValue("TaxType", Me.txtGSTNonGST.Text)
				reportDocument.SetParameterValue("CGSTTot", Me.txtCGST.Text)
				reportDocument.SetParameterValue("SGSTTot", Me.txtSGST.Text)
				reportDocument.SetParameterValue("IGSTTot", Me.txtIGST.Text)
				reportDocument.SetParameterValue("CESSTot", Me.txtCESS.Text)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008961 RID: 35169 RVA: 0x0064CD08 File Offset: 0x0064AF08
		Public Sub UnitInfo()
			Try
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				Dim text As String = "SELECT DISTINCT RTRIM(a2) FROM ExtDB1 WHERE a1=@d1"
				ModCommonClasses.cmd1 = New SqlCommand(text)
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd1.Connection = ModCommonClasses.con1
				ModCommonClasses.cmd1.CommandTimeout = 0
				Me.cmbUnit.Items.Clear()
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader()
				While ModCommonClasses.rdr1.Read()
					Me.cmbUnit.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr1.GetValue(0)))
				End While
				ModCommonClasses.rdr1.Close()
				ModCommonClasses.con1.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008962 RID: 35170 RVA: 0x0064CE28 File Offset: 0x0064B028
		Private Sub Button2_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button2, "Add Product")
		End Sub

		' Token: 0x06008963 RID: 35171 RVA: 0x0064CE78 File Offset: 0x0064B078
		Private Sub Button33_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button33, "Product Dashboard")
		End Sub

		' Token: 0x06008964 RID: 35172 RVA: 0x000431D9 File Offset: 0x000413D9
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
			Me.Label51.Text = "new"
		End Sub

		' Token: 0x06008965 RID: 35173 RVA: 0x0064CEC8 File Offset: 0x0064B0C8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Stock where Date between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dateTime2
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 vouchers for current month in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
			End If
			Me.auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text2 As String = "Select * from Company"
			ModCommonClasses.cmd = New SqlCommand(text2)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
			If flag4 Then
				MessageBox.Show("Add company profile first In master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag5 Then
					ModCommonClasses.rdr.Close()
				End If
				ModCommonClasses.con.Close()
			Else
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupplierName.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.cmbSupplierName.Focus()
					Else
						Dim flag8 As Boolean = Me.DataGridView1.Rows.Count = 0
						If flag8 Then
							MessageBox.Show("Sorry no product info added To grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag9 As Boolean = Operators.CompareString(Me.cmbBSundry.Text, "", False) = 0
							If flag9 Then
								MessageBox.Show("Not allowed To empty box Of Bill Sundry Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbBSundry.Focus()
							Else
								Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtFreightCharges.Text)) = 0
								If flag10 Then
									MessageBox.Show("Please enter Bill Sundry charges", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtFreightCharges.Focus()
								Else
									Dim flag11 As Boolean = Strings.Len(Strings.Trim(Me.txtOtherCharges.Text)) = 0
									If flag11 Then
										MessageBox.Show("Please enter Bill Discount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtOtherCharges.Focus()
									Else
										Dim flag12 As Boolean = Strings.Len(Strings.Trim(Me.txtRoundOff.Text)) = 0
										If flag12 Then
											MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtRoundOff.Focus()
										Else
											Dim flag13 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
											If flag13 Then
												Dim flag14 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
												If flag14 Then
													MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.cmbAccountNo.Focus()
													Return
												End If
											End If
											Dim flag15 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
											If flag15 Then
												Dim flag16 As Boolean = Strings.Len(Strings.Trim(Me.txtTotalPaid.Text)) = 0
												If flag16 Then
													MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtTotalPaid.Focus()
													Return
												End If
												Dim flag17 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) = 0.0
												If flag17 Then
													MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtTotalPaid.Focus()
													Return
												End If
											End If
											Dim flag18 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
											If flag18 Then
												Dim flag19 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) > Conversion.Val(Me.txtGrandTotal.Text)
												If flag19 Then
													MessageBox.Show("Total paid can Not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.txtTotalPaid.Focus()
													Return
												End If
											End If
											Dim flag20 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
											If flag20 Then
												Dim flag21 As Boolean = Strings.Len(Strings.Trim(Me.txtTotalPaid.Text)) = 0
												If flag21 Then
													MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtTotalPaid.Focus()
													Return
												End If
												Dim flag22 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) = 0.0
												If flag22 Then
													MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.txtTotalPaid.Focus()
													Return
												End If
											End If
											Dim flag23 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
											If flag23 Then
												Dim flag24 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) > Conversion.Val(Me.txtGrandTotal.Text)
												If flag24 Then
													MessageBox.Show("Total paid can Not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.txtTotalPaid.Focus()
													Return
												End If
											End If
											Dim flag25 As Boolean = (Conversion.Val(Me.txtBalance.Text) > Conversion.Val(Me.txtSuplLimit.Text)) And (Operators.CompareString(Me.txtSuplLimitstatus.Text, "Yes", False) = 0)
											If flag25 Then
												MessageBox.Show("Supplier Credit limit is exceeded", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Else
												Try
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "insert into Stock(ST_ID, InvoiceNo, Date,PurchaseType, SupplierID, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks,ReferenceNo1,ReferenceNo2,TaxType,SupplierInvoiceNo,SupplierInvoiceDate,CGST,SGST,IGST,CESS,BillSundry,TaxableAmt,BankAccount,Doc) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30)"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPurchaseType.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSup_ID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtPreviousDue.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtFreightCharges.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtOtherCharges.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtRoundOff.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtGrandTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.txtTotalPaid.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(Me.txtBalance.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtRemarks.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtReferenceNo1.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.cmbReverse.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.txtGSTNonGST.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.txtSupplierInvoiceNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.dtpSupplierInvoiceDate.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(Me.txtCGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(Me.txtSGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.txtIGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Conversion.Val(Me.txtCESS.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.cmbBSundry.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.TextBox6.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Me.cmbAccountNo.Text.ToString())
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													Dim memoryStream As MemoryStream = New MemoryStream()
													Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
													bitmap.Save(memoryStream, ImageFormat.Jpeg)
													Dim buffer As Byte() = memoryStream.GetBuffer()
													Dim sqlParameter As SqlParameter = New SqlParameter("@d30", SqlDbType.Image)
													sqlParameter.Value = buffer
													ModCommonClasses.cmd.Parameters.Add(sqlParameter)
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text4 As String = "insert into Stock_Product(StockID, ProductID,Barcode, Qty,MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,SCode,TaxableAmt,AltQty,AltUnit,PTaxType,RPrice,WPrice,Color,Size,Info,Batch,Mfgdate,Expdate,RCipher,WCipher,Category,MainUnit,IMEI1,IMEI2) VALUES (" + Me.txtST_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35)"
													ModCommonClasses.cmd = New SqlCommand(text4)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Prepare()
													Try
														For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
															Dim flag26 As Boolean = Not dataGridViewRow.IsNewRow
															If flag26 Then
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtScode.Text)
																ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d21", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(23).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(24).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(26).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(28).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d28", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d30", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(31).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d31", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(32).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(33).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d33", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(34).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d34", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(35).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d35", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(36).Value))
																ModCommonClasses.cmd.ExecuteNonQuery()
																ModCommonClasses.cmd.Parameters.Clear()
															End If
														Next
													Finally
														Dim enumerator As IEnumerator
														If TypeOf enumerator Is IDisposable Then
															TryCast(enumerator, IDisposable).Dispose()
														End If
													End Try
													ModCommonClasses.con.Close()
													Dim flag27 As Boolean = Operators.CompareString(Me.txtGSTNonGST.Text, "NON GST", False) = 0
													If flag27 Then
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text5 As String = "insert into PurcNoTax(ID, InvNo) Values (@d1,@d2)"
														ModCommonClasses.cmd = New SqlCommand(text5)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteReader()
														ModCommonClasses.con.Close()
													End If
													Dim flag28 As Boolean = Operators.CompareString(Me.txtGSTNonGST.Text, "NON GST", False) <> 0
													If flag28 Then
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text6 As String = "insert into PurcGST(ID, InvNo) Values (@d1,@d2)"
														ModCommonClasses.cmd = New SqlCommand(text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.gstid))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteReader()
														ModCommonClasses.con.Close()
													End If
													Try
														For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
															Dim flag29 As Boolean = Not dataGridViewRow2.IsNewRow
															If flag29 Then
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text7 As String = "Select ProductID from Temp_Stock where ProductID=@d1 And Barcode=@d2"
																ModCommonClasses.cmd = New SqlCommand(text7)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(3).Value.ToString())
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag30 As Boolean = ModCommonClasses.rdr.Read()
																If flag30 Then
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text8 As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Update Temp_Stock Set Qty = Qty + ", dataGridViewRow2.Cells(4).Value), ",StLimit=@d3, MRP=@d4, Batch=@d5, Mfgdate=@d6, Expdate=@d7, Size=@d8, Colour=@d9, SPrice=@d10, WPrice=@d11, SalePrice=@d12, WSalePrice=@d13, SuplName=@d14, IMEI1=@d15, IMEI2=@d16, PPrice=@d17, EPPrice=@d18  where ProductID=@d1 And Barcode=@d2"))
																	ModCommonClasses.cmd = New SqlCommand(text8)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow2.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow2.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow2.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow2.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow2.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow2.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.cmbSupplierName.Text.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", dataGridViewRow2.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow2.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(19).Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value)))
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text9 As String = "Update Product_OpeningStock Set MRP=@d1, Batch=@d2, Mfgdate=@d3, Expdate=@d4, Size=@d5, Colour=@d6, SalePrice=@d7, WSalePrice=@d8, RCipher=@d9, WCipher=@d10, PPrice=@d11, OPSValue=@d12, IMEI1=@d13, IMEI2=@d14 where ProductID=@d15 And Barcode=@d16"
																	ModCommonClasses.cmd = New SqlCommand(text9)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow2.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow2.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow2.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow2.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow2.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow2.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "0.00")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow2.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow2.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																Else
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text10 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SPrice,WPrice,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)"
																	ModCommonClasses.cmd = New SqlCommand(text10)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow2.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow2.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow2.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow2.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow2.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow2.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow2.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.cmbSupplierName.Text.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow2.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow2.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(19).Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value)))
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text11 As String = "insert into Product_OpeningStock(ProductID,Qty,Barcode,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
																	ModCommonClasses.cmd = New SqlCommand(text11)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow2.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow2.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow2.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow2.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow2.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow2.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow2.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "0.00")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow2.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow2.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																End If
															End If
														Next
													Finally
														Dim enumerator2 As IEnumerator
														If TypeOf enumerator2 Is IDisposable Then
															TryCast(enumerator2, IDisposable).Dispose()
														End If
													End Try
													Dim flag35 As Boolean
													Try
														For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
															Dim flag31 As Boolean = Not dataGridViewRow3.IsNewRow
															If flag31 Then
																Dim flag32 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value)) > 0.0
																If flag32 Then
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text12 As String = "select ProductID from StockMovement where ProductID=@d1"
																	ModCommonClasses.cmd = New SqlCommand(text12)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																	ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																	Dim flag33 As Boolean = Not ModCommonClasses.rdr.Read()
																	If flag33 Then
																		ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), 0D, New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value))), 0D, Me.dtpDate.Value.[Date], Me.txtInvoiceNo.Text)
																	Else
																		ModCommonClasses.con = New SqlConnection(ModCS.cs)
																		ModCommonClasses.con.Open()
																		Dim text13 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
																		ModCommonClasses.cmd = New SqlCommand(text13)
																		ModCommonClasses.cmd.Connection = ModCommonClasses.con
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
																		ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																		Dim flag34 As Boolean = ModCommonClasses.rdr.Read()
																		Dim num As Double
																		If flag34 Then
																			num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
																		Else
																			num = 0.0
																		End If
																		ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))), New Decimal(num), New Decimal(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value))), 0D, Me.dtpDate.Value.[Date], Me.txtInvoiceNo.Text)
																	End If
																	ModCommonClasses.con.Close()
																End If
															End If
														Next
													Finally
														Dim enumerator3 As IEnumerator
														If TypeOf enumerator3 Is IDisposable Then
															TryCast(enumerator3, IDisposable).Dispose()
														End If
													End Try
													flag35 = Me.cmbPurchaseType.SelectedIndex = 1
													If flag35 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag36 As Boolean = Me.cmbPurchaseType.SelectedIndex = 1
													If flag36 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													Dim flag37 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
													If flag37 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag38 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
													If flag38 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													Dim flag39 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag39 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag40 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag40 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													Dim flag41 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag41 Then
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtInvoiceNo.Text, "Purchase-Bank", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D)
													End If
													ModFunc.RefreshRecords()
													Me.InsertSerial_final(Me.txtInvoiceNo.Text, Me.lblUser.Text)
													Me.Clear_SerialData()
													ModFunc.LogFunc(Me.lblUser.Text, "added the New Purchase having Invoice No. '" + Me.txtInvoiceNo.Text + "'")
													MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.fillPurchaseID()
													Me.btnSave.Enabled = False
													Me.btnPrint.Enabled = True
													ModCommonClasses.con.Close()
													Me.fillColor()
													Me.fillSize()
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
		End Sub

		' Token: 0x06008966 RID: 35174 RVA: 0x0064FCA0 File Offset: 0x0064DEA0
		Public Sub InsertSerial_final(InvoiceNo As String, SysUser As String)
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT * FROM tbl_product_serial  " & vbCrLf & "                                     where invoice_no = @d2 " & vbCrLf & "                                     AND sys_user = @sysUser", sqlConnection)
				sqlCommand.Parameters.Add("@d2", SqlDbType.VarChar).Value = InvoiceNo
				sqlCommand.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count > 0
				If flag Then
					Try
						For Each obj As Object In dataTable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim sqlCommand2 As SqlCommand = New SqlCommand("INSERT INTO tbl_product_serial_final (productid, barcode, serialno1, serialno2, status, sys_user, invoice_no)" & vbCrLf & "                                             VALUES (@productid, @barcode, @serialno1, @serialno2, @status, @sysUser, @invoice_no)", sqlConnection)
							sqlCommand2.Parameters.Add("@productid", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("productid"))
							sqlCommand2.Parameters.Add("@barcode", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("barcode"))
							sqlCommand2.Parameters.Add("@serialno1", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno1"))
							sqlCommand2.Parameters.Add("@serialno2", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("serialno2"))
							sqlCommand2.Parameters.Add("@status", SqlDbType.VarChar).Value = RuntimeHelpers.GetObjectValue(dataRow("status"))
							sqlCommand2.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
							sqlCommand2.Parameters.Add("@invoice_no", SqlDbType.VarChar).Value = InvoiceNo
							sqlCommand2.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim sqlCommand3 As SqlCommand = New SqlCommand("DELETE FROM tbl_product_serial " & vbCrLf & "                                         WHERE invoice_no = @invoice_no AND sys_user = @sysUser", sqlConnection)
					sqlCommand3.Parameters.Add("@invoice_no", SqlDbType.VarChar).Value = InvoiceNo
					sqlCommand3.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
					sqlCommand3.ExecuteNonQuery()
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			Finally
				Dim flag2 As Boolean = sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
				End If
			End Try
		End Sub

		' Token: 0x06008967 RID: 35175 RVA: 0x0064FF70 File Offset: 0x0064E170
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Conversion.Val(Me.txtBalance.Text) > Conversion.Val(Me.txtSuplLimit.Text)) And (Operators.CompareString(Me.txtSuplLimitstatus.Text.Trim(), "Yes", False) = 0)
			If flag Then
				MessageBox.Show("Supplier Credit limit is exceeded", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select ST_ID from Stock,PurchaseReturn where PurchaseReturn.PurchaseID=Stock.ST_ID and ST_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					MessageBox.Show("Unable to update..Already in use in Purchase Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierID.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtSupplierID.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please select correct supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.cmbSupplierName.Focus()
						Else
							Dim flag6 As Boolean = Me.DataGridView1.Rows.Count = 0
							If flag6 Then
								MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.cmbBSundry.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Not allowed to empty box of Bill Sundry Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbBSundry.Focus()
								Else
									Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtFreightCharges.Text)) = 0
									If flag8 Then
										MessageBox.Show("Please enter Bill Sundry charges", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtFreightCharges.Focus()
									Else
										Dim flag9 As Boolean = Strings.Len(Strings.Trim(Me.txtOtherCharges.Text)) = 0
										If flag9 Then
											MessageBox.Show("Please enter Bill Discount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtOtherCharges.Focus()
										Else
											Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtRoundOff.Text)) = 0
											If flag10 Then
												MessageBox.Show("Please enter Round off", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtRoundOff.Focus()
											Else
												Dim flag11 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
												If flag11 Then
													Dim flag12 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
													If flag12 Then
														MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.cmbAccountNo.Focus()
														Return
													End If
												End If
												Dim flag13 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
												If flag13 Then
													Dim flag14 As Boolean = Strings.Len(Strings.Trim(Me.txtTotalPaid.Text)) = 0
													If flag14 Then
														MessageBox.Show("Please enter total paid", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.txtTotalPaid.Focus()
														Return
													End If
													Dim flag15 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) = 0.0
													If flag15 Then
														MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Me.txtTotalPaid.Focus()
														Return
													End If
												End If
												Dim flag16 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
												If flag16 Then
													Dim flag17 As Boolean = Conversion.Val(Me.txtTotalPaid.Text) > Conversion.Val(Me.txtGrandTotal.Text)
													If flag17 Then
														MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Me.txtTotalPaid.Focus()
														Return
													End If
												End If
												Try
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text2 As String = "Update Stock set InvoiceNo=@d2, Date=@d3,PurchaseType=@d4, SupplierID=@d5, SubTotal=@d6, PreviousDue=@d7, FreightCharges=@d8, OtherCharges=@d9, Total=@d10, RoundOff=@d11, GrandTotal=@d12, TotalPayment=@d13, PaymentDue=@d14, Remarks=@d15,ReferenceNo1=@d16,ReferenceNo2=@d17,TaxType=@d18,SupplierInvoiceNo=@d19,SupplierInvoiceDate=@d20,CGST=@d21,SGST=@d22,IGST=@d23,CESS=@d24,BillSundry=@d25,TaxableAmt=@d26,BankAccount=@d27,Doc=@d28 where ST_ID=@d1"
													ModCommonClasses.cmd = New SqlCommand(text2)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtST_ID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPurchaseType.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSup_ID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtPreviousDue.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtFreightCharges.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtOtherCharges.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtRoundOff.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtGrandTotal.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtTotalPaid.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtBalance.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtRemarks.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtReferenceNo1.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.cmbReverse.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtGSTNonGST.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.txtSupplierInvoiceNo.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.dtpSupplierInvoiceDate.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtCGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(Me.txtSGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(Me.txtIGST.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(Me.txtCESS.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.cmbBSundry.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Conversion.Val(Me.TextBox6.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.cmbAccountNo.Text.ToString())
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													Dim memoryStream As MemoryStream = New MemoryStream()
													Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
													bitmap.Save(memoryStream, ImageFormat.Jpeg)
													Dim buffer As Byte() = memoryStream.GetBuffer()
													Dim sqlParameter As SqlParameter = New SqlParameter("@d28", SqlDbType.Image)
													sqlParameter.Value = buffer
													ModCommonClasses.cmd.Parameters.Add(sqlParameter)
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = If(("Delete from Stock_Product where StockID=" + Conversions.ToString(Conversion.Val(Me.txtST_ID.Text))), "")
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text4 As String = "insert into Stock_Product(StockID, ProductID,Barcode, Qty,MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,SCode,TaxableAmt,AltQty,AltUnit,PTaxType,RPrice,WPrice,Color,Size,Info,Batch,Mfgdate,Expdate,RCipher,WCipher,Category,MainUnit,IMEI1,IMEI2) VALUES (" + Me.txtST_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35)"
													ModCommonClasses.cmd = New SqlCommand(text4)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Prepare()
													Try
														For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
															Dim flag18 As Boolean = Not dataGridViewRow.IsNewRow
															If flag18 Then
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtScode.Text)
																ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d21", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(23).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(24).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(26).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(28).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d28", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d30", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(31).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d31", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(32).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(33).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d33", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(34).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d34", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(35).Value))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d35", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(36).Value))
																ModCommonClasses.cmd.ExecuteNonQuery()
																ModCommonClasses.cmd.Parameters.Clear()
															End If
														Next
													Finally
														Dim enumerator As IEnumerator
														If TypeOf enumerator Is IDisposable Then
															TryCast(enumerator, IDisposable).Dispose()
														End If
													End Try
													ModCommonClasses.con.Close()
													Try
														For Each obj2 As Object In CType(Me.DataGridView2.Rows, IEnumerable)
															Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
															Dim flag19 As Boolean = Not dataGridViewRow2.IsNewRow
															If flag19 Then
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text5 As String = "Select ProductID from Temp_Stock where ProductID=@d1 And Barcode=@d2"
																ModCommonClasses.cmd = New SqlCommand(text5)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag20 As Boolean = ModCommonClasses.rdr.Read()
																If flag20 Then
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text6 As String = "Update Temp_Stock set Qty = Qty - (" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(4).Value))) + ") where ProductID=@d1 and Barcode=@d2"
																	ModCommonClasses.cmd = New SqlCommand(text6)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value))
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																End If
															End If
														Next
													Finally
														Dim enumerator2 As IEnumerator
														If TypeOf enumerator2 Is IDisposable Then
															TryCast(enumerator2, IDisposable).Dispose()
														End If
													End Try
													Try
														For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow3 As DataGridViewRow = CType(obj3, DataGridViewRow)
															Dim flag21 As Boolean = Not dataGridViewRow3.IsNewRow
															If flag21 Then
																ModCommonClasses.con = New SqlConnection(ModCS.cs)
																ModCommonClasses.con.Open()
																Dim text7 As String = "Select ProductID from Temp_Stock where ProductID=@d1 And Barcode=@d2"
																ModCommonClasses.cmd = New SqlCommand(text7)
																ModCommonClasses.cmd.Connection = ModCommonClasses.con
																ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(3).Value))
																ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																Dim flag22 As Boolean = ModCommonClasses.rdr.Read()
																If flag22 Then
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text8 As String = "Update Temp_Stock set Qty = Qty + (" + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value))) + "), StLimit=@d3, MRP=@d4, Batch=@d5, Mfgdate=@d6, Expdate=@d7, Size=@d8, Colour=@d9, SPrice=@d10, WPrice=@d11, SalePrice=@d12, WSalePrice=@d13, SuplName=@d14, IMEI1=@d15, IMEI2=@d16, PPrice=@d17, EPPrice=@d18 where ProductID=@d1 and Barcode=@d2"
																	ModCommonClasses.cmd = New SqlCommand(text8)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", dataGridViewRow3.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow3.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.cmbSupplierName.Text.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", dataGridViewRow3.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(19).Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value)))
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text9 As String = "Update Product_OpeningStock Set MRP=@d1, Batch=@d2, Mfgdate=@d3, Expdate=@d4, Size=@d5, Colour=@d6, SalePrice=@d7, WSalePrice=@d8, RCipher=@d9, WCipher=@d10, PPrice=@d11, OPSValue=@d12, IMEI1=@d13, IMEI2=@d14 where ProductID=@d15 And Barcode=@d16"
																	ModCommonClasses.cmd = New SqlCommand(text9)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", dataGridViewRow3.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", dataGridViewRow3.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "0.00")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow3.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow3.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																Else
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text10 As String = "insert into Temp_Stock(ProductID,Qty,Barcode,StLimit,MRP,Batch,Mfgdate,Expdate,Size,Colour,SPrice,WPrice,SalePrice,WSalePrice,SuplName,IMEI1,IMEI2,PPrice,EPPrice) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19)"
																	ModCommonClasses.cmd = New SqlCommand(text10)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", dataGridViewRow3.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow3.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow3.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.cmbSupplierName.Text.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", dataGridViewRow3.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(19).Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(4).Value)))
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text11 As String = "insert into Product_OpeningStock(ProductID,Qty,Barcode,MRP,Batch,Mfgdate,Expdate,Size,Colour,SalePrice,WSalePrice,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)"
																	ModCommonClasses.cmd = New SqlCommand(text11)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 0)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d3", dataGridViewRow3.Cells(3).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(5).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d5", dataGridViewRow3.Cells(28).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d6", dataGridViewRow3.Cells(29).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d7", dataGridViewRow3.Cells(30).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d8", dataGridViewRow3.Cells(26).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d9", dataGridViewRow3.Cells(25).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(23).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(24).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d12", DateTime.Today)
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d13", dataGridViewRow3.Cells(31).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d14", dataGridViewRow3.Cells(32).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(6).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "0.00")
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d17", dataGridViewRow3.Cells(35).Value.ToString())
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d18", dataGridViewRow3.Cells(36).Value.ToString())
																	ModCommonClasses.cmd.ExecuteReader()
																	ModCommonClasses.con.Close()
																End If
															End If
														Next
													Finally
														Dim enumerator3 As IEnumerator
														If TypeOf enumerator3 Is IDisposable Then
															TryCast(enumerator3, IDisposable).Dispose()
														End If
													End Try
													Try
														For Each obj4 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow4 As DataGridViewRow = CType(obj4, DataGridViewRow)
															Dim flag23 As Boolean = Not dataGridViewRow4.IsNewRow
															If flag23 Then
																Dim flag24 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(4).Value)) > 0.0
																If flag24 Then
																	ModCommonClasses.con = New SqlConnection(ModCS.cs)
																	ModCommonClasses.con.Open()
																	Dim text12 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
																	ModCommonClasses.cmd = New SqlCommand(text12)
																	ModCommonClasses.cmd.Connection = ModCommonClasses.con
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value)))
																	ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtInvoiceNo.Text)
																	ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
																	Dim flag25 As Boolean = ModCommonClasses.rdr.Read()
																	If flag25 Then
																		ModCommonClasses.con = New SqlConnection(ModCS.cs)
																		ModCommonClasses.con.Open()
																		Dim text13 As String = "Update StockMovement set StockIn=@d1, Date=@d2 where ProductID=@d4 and TransID=@d3"
																		ModCommonClasses.cmd = New SqlCommand(text13)
																		ModCommonClasses.cmd.Connection = ModCommonClasses.con
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(4).Value)))
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtInvoiceNo.Text)
																		ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value)))
																		ModCommonClasses.cmd.ExecuteReader()
																		ModCommonClasses.con.Close()
																	End If
																End If
															End If
														Next
													Finally
														Dim enumerator4 As IEnumerator
														If TypeOf enumerator4 Is IDisposable Then
															TryCast(enumerator4, IDisposable).Dispose()
														End If
													End Try
													ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Payment")
													ModFunc.LedgerDelete(Me.txtInvoiceNo.Text, "Purchase")
													ModFunc.SupplierLedgerDelete(Me.txtInvoiceNo.Text)
													Dim flag26 As Boolean = Me.cmbPurchaseType.SelectedIndex = 1
													If flag26 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag27 As Boolean = Me.cmbPurchaseType.SelectedIndex = 1
													If flag27 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													Dim flag28 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
													If flag28 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag29 As Boolean = Me.cmbPurchaseType.SelectedIndex = 0
													If flag29 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Cash Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													Dim flag30 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag30 Then
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														ModFunc.SupplierLedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
													End If
													Dim flag31 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag31 Then
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], Me.cmbSupplierName.Text, Me.txtInvoiceNo.Text, "Purchase", 0D, New Decimal(Conversion.Val(Me.txtGrandTotal.Text) - Conversion.Val(Me.txtPreviousDue.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
														ModFunc.LedgerSave(Me.dtpDate.Value.[Date], "Bank Account", Me.txtInvoiceNo.Text, "Payment", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
													End If
													ModFunc.BankAccountLedgerDelete(Me.txtInvoiceNo.Text, "Purchase-Bank")
													Dim flag32 As Boolean = Me.cmbPurchaseType.SelectedIndex = 2
													If flag32 Then
														ModFunc.BankAccountLedgerSave(Me.dtpDate.Value.[Date], Me.cmbAccountNo.Text, Me.txtInvoiceNo.Text, "Purchase-Bank", New Decimal(Conversion.Val(Me.txtTotalPaid.Text)), 0D)
													End If
													Me.Clear_SerialData_finaltable(Me.txtInvoiceNo.Text, Me.lblUser.Text)
													Me.InsertSerial_final(Me.txtInvoiceNo.Text, Me.lblUser.Text)
													ModFunc.RefreshRecords()
													ModFunc.LogFunc(Me.lblUser.Text, "Updated the Purchase record having Invoice No. '" + Me.txtInvoiceNo.Text + "'")
													MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.btnUpdate.Enabled = False
													Me.btnPrint.Enabled = True
													ModCommonClasses.con.Close()
													Me.DataforNP()
													Me.fillColor()
													Me.fillSize()
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
		End Sub

		' Token: 0x06008968 RID: 35176 RVA: 0x00652C00 File Offset: 0x00650E00
		Public Sub Clear_SerialData_finaltable(InvoiceNo As String, SysUser As String)
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			Dim sqlCommand As SqlCommand = Nothing
			Try
				sqlConnection.Open()
				Dim text As String = "DELETE FROM tbl_product_serial_final WHERE invoice_no = @invoice_no AND sys_user = @sysUser"
				sqlCommand = New SqlCommand(text, sqlConnection)
				sqlCommand.Parameters.Add("@invoice_no", SqlDbType.VarChar).Value = InvoiceNo
				sqlCommand.Parameters.Add("@sysUser", SqlDbType.VarChar).Value = SysUser
				Dim num As Integer = sqlCommand.ExecuteNonQuery()
			Catch ex As Exception
				MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag As Boolean = sqlCommand IsNot Nothing
				If flag Then
					sqlCommand.Dispose()
				End If
				Dim flag2 As Boolean = sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open
				If flag2 Then
					sqlConnection.Close()
					sqlConnection.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06008969 RID: 35177 RVA: 0x00652CF4 File Offset: 0x00650EF4
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

		' Token: 0x0600896A RID: 35178 RVA: 0x00652D5C File Offset: 0x00650F5C
		Private Sub btnGetdata_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmPurchaseRecord.lblSet.Text = "Purchase"
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.ShowDialog()
			MyProject.Forms.frmPurchaseRecord.Dispose()
		End Sub

		' Token: 0x0600896B RID: 35179 RVA: 0x000431FB File Offset: 0x000413FB
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600896C RID: 35180 RVA: 0x00043205 File Offset: 0x00041405
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeLabelPrinting.txtPInv.Text = Me.txtInvoiceNo.Text.ToString()
			MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
		End Sub

		' Token: 0x0600896D RID: 35181 RVA: 0x0004323D File Offset: 0x0004143D
		Private Sub Button4_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomiseBarcode.ShowDialog()
			MyProject.Forms.frmCustomiseBarcode.Dispose()
		End Sub

		' Token: 0x0600896E RID: 35182 RVA: 0x00043260 File Offset: 0x00041460
		Private Sub Button38_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurcOrderRetrieve1.ShowDialog()
		End Sub

		' Token: 0x0600896F RID: 35183 RVA: 0x00652DBC File Offset: 0x00650FBC
		Private Sub btnExport_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.DataGridView1.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008970 RID: 35184 RVA: 0x00113F98 File Offset: 0x00112198
		Private Function GenerateDate(mfgDate As String) As String
			Dim text As String = ""
			Try
				Dim list As List(Of String) = mfgDate.Split(New Char() { " "c }).First().Split(New Char() { "/"c }).ToList()
				Dim num As Integer = Convert.ToInt32(list(0))
				Dim num2 As Integer = Convert.ToInt32(list(1))
				Dim num3 As Integer = Convert.ToInt32(list(2))
				Dim flag As Boolean = num < 10
				Dim text2 As String
				If flag Then
					text2 = "0" + num.ToString()
				Else
					text2 = Conversions.ToString(num)
				End If
				Dim flag2 As Boolean = num2 < 10
				Dim text3 As String
				If flag2 Then
					text3 = "0" + num2.ToString()
				Else
					text3 = Conversions.ToString(num2)
				End If
				Dim flag3 As Boolean = num3 < 1000
				Dim text4 As String
				If flag3 Then
					text4 = "00" + num3.ToString()
				Else
					text4 = Conversions.ToString(num3)
				End If
				text = String.Concat(New String() { text2, "/", text3, "/", text4 })
			Catch ex As Exception
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x06008971 RID: 35185 RVA: 0x00653068 File Offset: 0x00651268
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Sheet1$]", oleDbConnection)
					oleDbConnection.Open()
					Dim dataSet As DataSet = New DataSet()
					oleDbDataAdapter.Fill(dataSet)
					Me.DataGridView1.Visible = True
					Me.DataGridView1.Rows.Clear()
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtGSTNonGST.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please configure Tax Type", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.Clear()
						MyProject.Forms.frmTaxSetting.ShowDialog()
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
						If flag3 Then
							MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.dgw4.Visible = False
							Me.cmbSupplierName.Focus()
						Else
							Dim list As List(Of String) = New List(Of String)()
							Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
							Dim num As Integer = dataSet.Tables(0).Rows.Count - 1
							For i As Integer = 0 To num
								Dim text As String = dataSet.Tables(0).Rows(i)(0).ToString()
								Dim text2 As String = dataSet.Tables(0).Rows(i)(1).ToString()
								Dim text3 As String = dataSet.Tables(0).Rows(i)(2).ToString()
								Dim text4 As String = dataSet.Tables(0).Rows(i)(3).ToString()
								Dim text5 As String = dataSet.Tables(0).Rows(i)(4).ToString()
								Dim text6 As String = dataSet.Tables(0).Rows(i)(5).ToString()
								Dim text7 As String = dataSet.Tables(0).Rows(i)(6).ToString()
								Dim flag4 As Boolean = (Operators.CompareString(text2, "", False) = 0) Or (Operators.CompareString(text3, "", False) = 0) Or (Operators.CompareString(text4, "", False) = 0) Or (Operators.CompareString(text5, "", False) = 0) Or (Operators.CompareString(text6, "", False) = 0)
								If flag4 Then
									MessageBox.Show("Please insert required information in excel data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Return
								End If
								Dim num2 As Decimal = Convert.ToDecimal(text4)
								Dim num3 As Decimal = Convert.ToDecimal(text6)
								Dim flag5 As Boolean = Decimal.Compare(num3, num2) > 0
								If flag5 Then
									MessageBox.Show(text2 + " MRP should always be greater than retail price ")
									Return
								End If
								Dim flag6 As Boolean = (Conversions.ToDouble(text5) > Convert.ToDouble(num2)) Or (Conversions.ToDouble(text5) > Convert.ToDouble(num3))
								If flag6 Then
									MessageBox.Show(text2 + " price should always be lesser than retail price/MRP ")
									Return
								End If
								Dim flag7 As Boolean = dictionary.ContainsKey(text2)
								If flag7 Then
									MessageBox.Show("DUPILCATE BARCODE: " + text2)
									Return
								End If
								dictionary(text2) = Conversions.ToString(i)
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text8 As String = "select Barcode from Temp_Stock Where Barcode=@d1"
								ModCommonClasses.cmd = New SqlCommand(text8)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
								If Not flag8 Then
									MessageBox.Show("Barcode '" + text2 + "' not found in product entry, please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Return
								End If
								Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag9 Then
									ModCommonClasses.rdr.Close()
								End If
								ModCommonClasses.con.Close()
							Next
							Dim num4 As Integer = dataSet.Tables(0).Rows.Count - 1
							For j As Integer = 0 To num4
								Dim regex As Regex = New Regex("(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$")
								Dim flag10 As Boolean = Operators.CompareString(dataSet.Tables(0).Rows(j)(7).ToString(), "", False) = 0
								If Not flag10 Then
									Dim text9 As String = Me.GenerateDate(dataSet.Tables(0).Rows(j)(7).ToString())
									Dim flag11 As Boolean = regex.IsMatch(text9)
									Dim dateTime As DateTime
									flag11 = DateTime.TryParseExact(text9, "dd/MM/yyyy", New CultureInfo("en-GB"), DateTimeStyles.None, dateTime)
									Dim flag12 As Boolean = Not flag11
									If flag12 Then
										MessageBox.Show("Manufacturer date invalid " + text9)
										Return
									End If
								End If
								Dim flag13 As Boolean = Operators.CompareString(dataSet.Tables(0).Rows(j)(8).ToString(), "", False) = 0
								If Not flag13 Then
									Dim text10 As String = Me.GenerateDate(dataSet.Tables(0).Rows(j)(8).ToString())
									Dim flag14 As Boolean = regex.IsMatch(text10)
									Dim dateTime2 As DateTime
									flag14 = DateTime.TryParseExact(text10, "dd/MM/yyyy", New CultureInfo("en-GB"), DateTimeStyles.None, dateTime2)
									Dim flag15 As Boolean = Not flag14
									If flag15 Then
										MessageBox.Show("Expiry date invalid " + text10)
										Return
									End If
								End If
								Dim text11 As String = dataSet.Tables(0).Rows(j)(0).ToString()
								Dim text12 As String = dataSet.Tables(0).Rows(j)(1).ToString()
								Dim text13 As String = dataSet.Tables(0).Rows(j)(2).ToString()
								Dim text14 As String = dataSet.Tables(0).Rows(j)(3).ToString()
								Dim text15 As String = dataSet.Tables(0).Rows(j)(4).ToString()
								Dim text16 As String = dataSet.Tables(0).Rows(j)(5).ToString()
								Dim text17 As String = dataSet.Tables(0).Rows(j)(6).ToString()
								Dim text18 As String = dataSet.Tables(0).Rows(j)(7).ToString()
								Dim text19 As String = dataSet.Tables(0).Rows(j)(8).ToString()
								Me.CheckBox3.Checked = True
								Me.TextBox5.Text = text12
								Me.dgw4_MouseClick(RuntimeHelpers.GetObjectValue(sender), CType(e, MouseEventArgs))
								Me.RetrieveData1()
								Me.txtQty.Text = text13
								Me.txtMRP.Text = text14
								Me.txtPricePerQty.Text = text15
								Me.txtRetail.Text = text16
								Me.txtDiscPer.Text = text17
								Me.txtMfg.Text = text18
								Me.txtExp.Text = text19
								Me.btnAdd_Click(RuntimeHelpers.GetObjectValue(sender), e)
							Next
							MyBase.WindowState = FormWindowState.Minimized
							MyBase.WindowState = FormWindowState.Maximized
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06008972 RID: 35186 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
		End Sub

		' Token: 0x06008973 RID: 35187 RVA: 0x00043273 File Offset: 0x00041473
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.DataGridView1.Rows.Clear()
		End Sub

		' Token: 0x06008974 RID: 35188 RVA: 0x00653908 File Offset: 0x00651B08
		Private Sub txtMRPMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtMRP.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtMRPMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
			End If
		End Sub

		' Token: 0x06008975 RID: 35189 RVA: 0x00653984 File Offset: 0x00651B84
		Private Sub txtSaaleMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtRetail.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtSaaleMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
			End If
		End Sub

		' Token: 0x06008976 RID: 35190 RVA: 0x00653A00 File Offset: 0x00651C00
		Private Sub txtWMarginNew_TextChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtWholesale.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtPricePerQty.Text) * Conversion.Val(Me.txtWMarginNew.Text) / 100.0 + Conversion.Val(Me.txtPricePerQty.Text), 2), "")
			End If
		End Sub

		' Token: 0x06008977 RID: 35191 RVA: 0x00653A7C File Offset: 0x00651C7C
		Private Sub txtMRP_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtMRPMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtMRP.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06008978 RID: 35192 RVA: 0x00653AE4 File Offset: 0x00651CE4
		Private Sub txtWholesale_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtWMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtWholesale.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0)
			End If
		End Sub

		' Token: 0x06008979 RID: 35193 RVA: 0x00653B4C File Offset: 0x00651D4C
		Private Sub txtRetail_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.txtSaaleMarginNew.Text = Conversions.ToString(Conversion.Val(Me.txtRetail.Text) * 100.0 / Conversion.Val(Me.txtPricePerQty.Text) - 100.0)
			End If
		End Sub

		' Token: 0x0600897A RID: 35194 RVA: 0x00653BB4 File Offset: 0x00651DB4
		Private Sub txtPricePerQty_Leave(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			If checked Then
				Me.updateMarginnew()
			End If
		End Sub

		' Token: 0x0600897B RID: 35195 RVA: 0x00043287 File Offset: 0x00041487
		Private Sub chkMarginOnOff_CheckedChanged(sender As Object, e As EventArgs)
			Me.CheckUncheckMargin()
		End Sub

		' Token: 0x0600897C RID: 35196 RVA: 0x00653BDC File Offset: 0x00651DDC
		Private Sub CheckUncheckMargin()
			Dim checked As Boolean = Me.chkMarginOnOff.Checked
			Dim text As String
			If checked Then
				text = "true"
				Me.Label78.Visible = True
				Me.Label79.Visible = True
				Me.txtSaaleMarginNew.Visible = True
				Me.txtWMarginNew.Visible = True
			Else
				text = "false"
				Me.Label78.Visible = False
				Me.Label79.Visible = False
				Me.txtSaaleMarginNew.Visible = False
				Me.txtWMarginNew.Visible = False
			End If
			Registry.SetValue(Me.keyPath, Me.valueName, text)
		End Sub

		' Token: 0x0600897D RID: 35197 RVA: 0x0064993C File Offset: 0x00647B3C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplier.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplier.Reset()
			MyProject.Forms.frmSupplier.ShowDialog()
			MyProject.Forms.frmSupplier.Dispose()
		End Sub

		' Token: 0x0600897E RID: 35198 RVA: 0x00653C88 File Offset: 0x00651E88
		Private Sub MasterEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
			MyProject.Forms.frmPayment.Dispose()
		End Sub

		' Token: 0x0600897F RID: 35199 RVA: 0x00653D08 File Offset: 0x00651F08
		Private Sub EstimateToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEstimate.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmEstimate.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmEstimate.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmEstimate.Reset()
			MyProject.Forms.frmEstimate.ShowDialog()
			MyProject.Forms.frmEstimate.Dispose()
		End Sub

		' Token: 0x06008980 RID: 35200 RVA: 0x00653DA8 File Offset: 0x00651FA8
		Private Sub QuotationToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmQuotation.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmQuotation.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmQuotation.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmQuotation.Reset()
			MyProject.Forms.frmQuotation.ShowDialog()
			MyProject.Forms.frmQuotation.Dispose()
		End Sub

		' Token: 0x06008981 RID: 35201 RVA: 0x00653E48 File Offset: 0x00652048
		Private Sub PurchaseReturnToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturn.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturn.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmPurchaseReturn.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseReturn.Reset()
			MyProject.Forms.frmPurchaseReturn.ShowDialog()
			MyProject.Forms.frmPurchaseReturn.Dispose()
		End Sub

		' Token: 0x06008982 RID: 35202 RVA: 0x00653EE8 File Offset: 0x006520E8
		Private Sub PurchaseOrderToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseOrder.Reset()
			MyProject.Forms.frmPurchaseOrder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseOrder.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPurchaseOrder.ShowDialog()
			MyProject.Forms.frmPurchaseOrder.Dispose()
		End Sub

		' Token: 0x06008983 RID: 35203 RVA: 0x00653C88 File Offset: 0x00651E88
		Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPayment.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmPayment.lblCPhone.Text = Me.lblCName.Text
			MyProject.Forms.frmPayment.Reset()
			MyProject.Forms.frmPayment.ShowDialog()
			MyProject.Forms.frmPayment.Dispose()
		End Sub

		' Token: 0x06008984 RID: 35204 RVA: 0x00043291 File Offset: 0x00041491
		Private Sub SupplierBulkEditorToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierBulkUpdate.ShowDialog()
			MyProject.Forms.frmSupplierBulkUpdate.Dispose()
		End Sub

		' Token: 0x06008985 RID: 35205 RVA: 0x00653F68 File Offset: 0x00652168
		Private Sub StockEntryToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntry.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockEntry.Reset()
			MyProject.Forms.frmStockEntry.ShowDialog()
			MyProject.Forms.frmStockEntry.Dispose()
		End Sub

		' Token: 0x06008986 RID: 35206 RVA: 0x00653FC8 File Offset: 0x006521C8
		Private Sub StockAdjustmentToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockAdjustment_Store.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmStockAdjustment_Store.Reset()
			MyProject.Forms.frmStockAdjustment_Store.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store.Dispose()
		End Sub

		' Token: 0x06008987 RID: 35207 RVA: 0x00654028 File Offset: 0x00652228
		Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_ProductsRecord.Reset()
				MyProject.Forms.frmExportImportExcel_ProductsRecord.ShowDialog()
			End If
		End Sub

		' Token: 0x06008988 RID: 35208 RVA: 0x0065408C File Offset: 0x0065228C
		Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCName.Text, "Trial", False) = 0
			If flag Then
				MessageBox.Show("You are not allowed in Trial Mode", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				MyProject.Forms.frmExportImportExcel_Suppliers.Reset()
				MyProject.Forms.frmExportImportExcel_Suppliers.ShowDialog()
			End If
		End Sub

		' Token: 0x06008989 RID: 35209 RVA: 0x000432B4 File Offset: 0x000414B4
		Private Sub SuppliersToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x0600898A RID: 35210 RVA: 0x00033D39 File Offset: 0x00031F39
		Private Sub SupplierToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierOutstanding.ShowDialog()
			MyProject.Forms.frmSupplierOutstanding.Dispose()
		End Sub

		' Token: 0x0600898B RID: 35211 RVA: 0x006540F0 File Offset: 0x006522F0
		Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseRecord_GSTR.Label6.Visible = False
			MyProject.Forms.frmPurchaseRecord_GSTR.Label1.Text = "Purchase Dashboard"
			MyProject.Forms.frmPurchaseRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600898C RID: 35212 RVA: 0x00654174 File Offset: 0x00652374
		Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Panel2.Visible = True
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Label1.Text = "Purchase Return Dashboard"
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Reset()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord_GSTR.Dispose()
		End Sub

		' Token: 0x0600898D RID: 35213 RVA: 0x000387B4 File Offset: 0x000369B4
		Private Sub StockEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntryRecord1.Reset()
			MyProject.Forms.frmStockEntryRecord1.ShowDialog()
			MyProject.Forms.frmStockEntryRecord1.Dispose()
		End Sub

		' Token: 0x0600898E RID: 35214 RVA: 0x0049A3A4 File Offset: 0x004985A4
		Private Sub StockStatusToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.lblSet.Text = ""
			MyProject.Forms.frmCurrentStock.Reset()
			MyProject.Forms.frmCurrentStock.ShowDialog()
			MyProject.Forms.frmCurrentStock.Dispose()
		End Sub

		' Token: 0x0600898F RID: 35215 RVA: 0x00525874 File Offset: 0x00523A74
		Private Sub StockAdjustmentToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockAdjustment_Store_Record.lblSet.Text = ""
			MyProject.Forms.frmStockAdjustment_Store_Record.Reset()
			MyProject.Forms.frmStockAdjustment_Store_Record.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store_Record.Dispose()
		End Sub

		' Token: 0x06008990 RID: 35216 RVA: 0x006541E4 File Offset: 0x006523E4
		Private Sub PurchasesToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseRecord.Reset()
			MyProject.Forms.frmPurchaseRecord.ShowDialog()
			MyProject.Forms.frmPurchaseRecord.Dispose()
		End Sub

		' Token: 0x06008991 RID: 35217 RVA: 0x00654254 File Offset: 0x00652454
		Private Sub PurchaseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.lblSet.Text = Me.lblUser.Text
			MyProject.Forms.frmPurchaseReturnRecord.Reset()
			MyProject.Forms.frmPurchaseReturnRecord.ShowDialog()
			MyProject.Forms.frmPurchaseReturnRecord.Dispose()
		End Sub

		' Token: 0x06008992 RID: 35218 RVA: 0x006542C4 File Offset: 0x006524C4
		Private Sub PurchaseOrderToolStripMenuItem2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.lblSet.Text = ""
			MyProject.Forms.frmPurchaseOrderRecord.Reset()
			MyProject.Forms.frmPurchaseOrderRecord.ShowDialog()
			MyProject.Forms.frmPurchaseOrderRecord.Dispose()
		End Sub

		' Token: 0x06008993 RID: 35219 RVA: 0x0065432C File Offset: 0x0065252C
		Private Sub PaymentsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.lblSet.Text = ""
			MyProject.Forms.frmPaymentRecord.Reset()
			MyProject.Forms.frmPaymentRecord.ShowDialog()
			MyProject.Forms.frmPaymentRecord.Dispose()
		End Sub

		' Token: 0x06008994 RID: 35220 RVA: 0x000432E7 File Offset: 0x000414E7
		Private Sub DashBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmBalancesheet.ShowDialog()
			MyProject.Forms.frmBalancesheet.Dispose()
		End Sub

		' Token: 0x06008995 RID: 35221 RVA: 0x0004330A File Offset: 0x0004150A
		Private Sub BalanceSheetToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.BalanceSheetForm.ShowDialog()
			MyProject.Forms.BalanceSheetForm.Dispose()
		End Sub

		' Token: 0x06008996 RID: 35222 RVA: 0x0004332D File Offset: 0x0004152D
		Private Sub ProfitAndLossToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProfitloss.ShowDialog()
			MyProject.Forms.frmProfitloss.Dispose()
		End Sub

		' Token: 0x06008997 RID: 35223 RVA: 0x00043350 File Offset: 0x00041550
		Private Sub TrialBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmTrialBalance.Reset()
			MyProject.Forms.frmTrialBalance.ShowDialog()
			MyProject.Forms.frmTrialBalance.Dispose()
		End Sub

		' Token: 0x06008998 RID: 35224 RVA: 0x00043383 File Offset: 0x00041583
		Private Sub SupplierLedgerToolStripMenuItem_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierLedger.Reset()
			MyProject.Forms.frmSupplierLedger.ShowDialog()
			MyProject.Forms.frmSupplierLedger.Dispose()
		End Sub

		' Token: 0x06008999 RID: 35225 RVA: 0x00038606 File Offset: 0x00036806
		Private Sub TaxToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmDebtorsReport.ShowDialog()
			MyProject.Forms.frmDebtorsReport.Dispose()
		End Sub

		' Token: 0x0600899A RID: 35226 RVA: 0x00654394 File Offset: 0x00652594
		Private Sub LowStockItemsToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ProductCode,Product.HSNCode,ProductName,Minstock,sum(Temp_Stock.Qty) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID group by ProductCode,Product.HSNCode,ProductName,MinStock having (sum(Temp_Stock.Qty)< MinStock) order by ProductName", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("LowStock.xml")
				Dim rptLowStock As rptLowStock = New rptLowStock()
				rptLowStock.SetDataSource(ModCommonClasses.ds)
				rptLowStock.SetParameterValue("p1", DateAndTime.Today)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptLowStock
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600899B RID: 35227 RVA: 0x0003868F File Offset: 0x0003688F
		Private Sub StockEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockEntryReport.Reset()
			MyProject.Forms.frmStockEntryReport.ShowDialog()
			MyProject.Forms.frmStockEntryReport.Dispose()
		End Sub

		' Token: 0x0600899C RID: 35228 RVA: 0x000386C2 File Offset: 0x000368C2
		Private Sub StockInAndStockOutToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockInAndOutReport.ShowDialog()
			MyProject.Forms.frmStockInAndOutReport.Dispose()
		End Sub

		' Token: 0x0600899D RID: 35229 RVA: 0x000433B6 File Offset: 0x000415B6
		Private Sub PurchaseToolStripMenuItem1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseReport.Reset()
			MyProject.Forms.frmPurchaseReport.ShowDialog()
			MyProject.Forms.frmPurchaseReport.Dispose()
		End Sub

		' Token: 0x0600899E RID: 35230 RVA: 0x006544D4 File Offset: 0x006526D4
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.dgw4.Visible = False
				Me.cmbSupplierName.Focus()
			Else
				MyProject.Forms.frmProductRec1.ShowDialog()
				MyProject.Forms.frmProductRec1.Dispose()
			End If
		End Sub

		' Token: 0x0600899F RID: 35231 RVA: 0x0003FB9B File Offset: 0x0003DD9B
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSeting.ShowDialog()
		End Sub

		' Token: 0x060089A0 RID: 35232 RVA: 0x00654550 File Offset: 0x00652750
		Private Sub txtOtherCharges_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x060089A1 RID: 35233 RVA: 0x006544D4 File Offset: 0x006526D4
		Private Sub AddNewProductToolStripMenuItem_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.dgw4.Visible = False
				Me.cmbSupplierName.Focus()
			Else
				MyProject.Forms.frmProductRec1.ShowDialog()
				MyProject.Forms.frmProductRec1.Dispose()
			End If
		End Sub

		' Token: 0x060089A2 RID: 35234 RVA: 0x0065458C File Offset: 0x0065278C
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnVariant").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim flag2 As Boolean = Operators.ConditionalCompareObjectNotEqual(dataGridViewRow.Cells("Variant_id").Value, "", False)
				If flag2 Then
					Dim text As String = Conversions.ToString(dataGridViewRow.Cells("Variant_id").Value)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT * from Temp_Stock where Variant_id=N'" + text + "'", ModCommonClasses.con)
					Dim dataTable As DataTable = New DataTable()
					dataTable.Rows.Clear()
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
					sqlDataAdapter.Fill(dataTable)
					ModCommonClasses.con.Close()
					Dim flag3 As Boolean = dataTable.Rows.Count = 1
					If flag3 Then
						MyProject.Forms.frmProductRec_variant.Label14.Text = text
						MyProject.Forms.frmProductRec_variant.Label13.Text = dataGridViewRow.Cells("Column4").Value.ToString()
						MyProject.Forms.frmProductRec_variant.ShowDialog()
					Else
						MessageBox.Show("This product variants already created!")
					End If
				Else
					MessageBox.Show("Variant Id not found!")
				End If
			End If
			Dim flag4 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns("btnSerial").Index AndAlso e.RowIndex >= 0
			If flag4 Then
				Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
				Dim flag5 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow2.Cells("Serial_no").Value, "", False)
				If flag5 Then
					Dim text2 As String = Conversions.ToString(dataGridViewRow2.Cells("Column1").Value)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT * from Temp_Stock where ProductID='" + text2 + "'", ModCommonClasses.con)
					Dim dataTable2 As DataTable = New DataTable()
					dataTable2.Rows.Clear()
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
					sqlDataAdapter2.Fill(dataTable2)
					ModCommonClasses.con.Close()
					Dim flag6 As Boolean = dataTable2.Rows.Count = 1
					If flag6 Then
						MyProject.Forms.frmProductRec_serial.Label14.Text = text2
						MyProject.Forms.frmProductRec_serial.Label13.Text = dataGridViewRow2.Cells("Column4").Value.ToString()
						MyProject.Forms.frmProductRec_serial.lblUser.Text = Me.lblUser.Text
						MyProject.Forms.frmProductRec_serial.lblInvoiceno.Text = Me.txtInvoiceNo.Text
						MyProject.Forms.frmProductRec_serial.lblstatus.Text = Me.Label51.Text
						MyProject.Forms.frmProductRec_serial.ShowDialog()
					Else
						MessageBox.Show("This product serial already created!")
					End If
				Else
					MessageBox.Show("Serial No. not found!")
				End If
			End If
		End Sub

		' Token: 0x060089A3 RID: 35235 RVA: 0x00654920 File Offset: 0x00652B20
		Private Sub Button19_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button19, "Supplier Dashboard")
		End Sub

		' Token: 0x060089A4 RID: 35236 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmPurchaseEntry_FormClosing(sender As Object, e As FormClosingEventArgs)
		End Sub

		' Token: 0x060089A5 RID: 35237 RVA: 0x00642FC4 File Offset: 0x006411C4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.txtSupplierInvoiceNo.Focus()
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Purchase"
			MyProject.Forms.frmSupplierRecord.Label5.Text = Me.lblUser.Text
			MyProject.Forms.frmSupplierRecord.btnaddCustomer.Visible = True
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
			MyProject.Forms.frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x060089A6 RID: 35238 RVA: 0x00654970 File Offset: 0x00652B70
		Private Sub Button8_Click(sender As Object, e As EventArgs)
			Dim visible As Boolean = Me.GroupBox11.Visible
			If visible Then
				Me.GroupBox11.Visible = False
			Else
				Me.GroupBox11.Visible = True
			End If
		End Sub

		' Token: 0x060089A7 RID: 35239 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
		End Sub

		' Token: 0x060089A8 RID: 35240 RVA: 0x006549AC File Offset: 0x00652BAC
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.dgw4.Visible = False
				Me.cmbSupplierName.Focus()
			Else
				MyProject.Forms.frmPdfReader.ShowDialog()
				MyProject.Forms.frmPdfReader.Dispose()
			End If
		End Sub

		' Token: 0x060089A9 RID: 35241 RVA: 0x00654A28 File Offset: 0x00652C28
		Private Sub Button10_Click(sender As Object, e As EventArgs)
			Dim text As String = ""
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Try
						Try
							For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								text = text + "'" + dataGridViewRow.Cells(0).Value.ToString() + "',"
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Dim flag2 As Boolean = text.EndsWith(",")
						If flag2 Then
							' The following expression was wrapped in a checked-expression
							text = text.Substring(0, text.Length - 1)
						End If
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Store ON Product.PID = StockAdjustment_Store.ProductID where PID in(" + text + ")"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Unable to delete..Already in use in Stock Adjustment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "SELECT PID FROM Product INNER JOIN Stock_Store_Join ON Product.PID = Stock_Store_Join.ProductID where PID in(" + text + ")"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Unable to delete..Already in use in Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text4 As String = "SELECT PID FROM Product INNER JOIN PurchaseOrder_Join ON Product.PID = PurchaseOrder_Join.ProductID where  PID in(" + text + ")"
								ModCommonClasses.cmd = New SqlCommand(text4)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
								If flag7 Then
									MessageBox.Show("Unable to delete..Already in use in Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag8 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text5 As String = "SELECT PID FROM Product INNER JOIN Stock_Product ON Product.PID = Stock_Product.ProductID where  PID in(" + text + ")"
									ModCommonClasses.cmd = New SqlCommand(text5)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
									If flag9 Then
										MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text6 As String = "SELECT PID FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID where PID in(" + text + ")"
										ModCommonClasses.cmd = New SqlCommand(text6)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
										If flag11 Then
											MessageBox.Show("Unable to delete..Already in use in Sale Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag12 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text7 As String = "SELECT PID FROM Product INNER JOIN Quotation_Join ON Product.PID = Quotation_Join.ProductID where  PID in(" + text + ")"
											ModCommonClasses.cmd = New SqlCommand(text7)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
											If flag13 Then
												MessageBox.Show("Unable to delete..Already in use in Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag14 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text8 As String = "SELECT PID FROM Product INNER JOIN Estimate_Join ON Product.PID = Estimate_Join.ProductID where  PID in(" + text + ")"
												ModCommonClasses.cmd = New SqlCommand(text8)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
												If flag15 Then
													MessageBox.Show("Unable to delete..Already in use in Estimate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag16 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag16 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text9 As String = "select ProductID from StockMovement where ProductID in(" + text + ")"
													ModCommonClasses.cmd = New SqlCommand(text9)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(text))
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag17 As Boolean = ModCommonClasses.rdr.Read()
													If flag17 Then
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text10 As String = "delete from StockMovement where ProductID  in(" + text + ")"
														ModCommonClasses.cmd = New SqlCommand(text10)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
													End If
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text11 As String = "delete from Product_OpeningStock where ProductID in(" + text + ")"
													ModCommonClasses.cmd = New SqlCommand(text11)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
													Dim flag18 As Boolean = num > 0
													If flag18 Then
														ModCommonClasses.con.Close()
													End If
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text12 As String = "delete from ExtDB1 where a1 in(" + text + ")"
													ModCommonClasses.cmd = New SqlCommand(text12)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.ExecuteReader()
													ModCommonClasses.con.Close()
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text13 As String = "delete from Product where  PID in(" + text + ")"
													ModCommonClasses.cmd = New SqlCommand(text13)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													num = ModCommonClasses.cmd.ExecuteNonQuery()
													Dim flag19 As Boolean = num > 0
													If flag19 Then
														MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Else
														MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Dim flag20 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
														If flag20 Then
															ModCommonClasses.con.Close()
														End If
														ModCommonClasses.con.Close()
													End If
													Me.DataforNP()
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
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060089AA RID: 35242 RVA: 0x000433E9 File Offset: 0x000415E9
		Private Sub BtnPurchaseWiseMerge_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmPurchaseWiseMerge.ShowDialog()
			MyProject.Forms.frmPurchaseWiseMerge.Dispose()
		End Sub

		' Token: 0x060089AB RID: 35243 RVA: 0x006552A0 File Offset: 0x006534A0
		Private Sub Button22_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button22, "Add Supplier")
		End Sub

		' Token: 0x060089AC RID: 35244 RVA: 0x006552F0 File Offset: 0x006534F0
		Public Sub fillAccountInfo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060089AD RID: 35245 RVA: 0x00655418 File Offset: 0x00653618
		Private Sub txtPricePerQty_GotFocus(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Stock Having count(*) >= 1 and " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " > 0"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dgwsale.Visible = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP 5 Stock.Date, RTRIM(Stock.InvoiceNo), RTRIM(Supplier.Name), Stock_Product.Price FROM Stock INNER JOIN Stock_Product ON Stock.ST_ID = Stock_Product.StockID INNER JOIN Supplier ON Stock.SupplierID = Supplier.ID INNER JOIN Product ON Stock_Product.ProductID = Product.PID where Stock_Product.ProductID = " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " order by Stock.Date DESC", ModCommonClasses.con)
					ModCommonClasses.cmd.CommandTimeout = 0
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgwsale.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgwsale.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
					End While
					Me.dgwsale.ClearSelection()
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060089AE RID: 35246 RVA: 0x0004340C File Offset: 0x0004160C
		Private Sub txtPricePerQty_LostFocus(sender As Object, e As EventArgs)
			Me.dgwsale.Visible = False
		End Sub

		' Token: 0x060089AF RID: 35247 RVA: 0x00655600 File Offset: 0x00653800
		Public Sub BarcodeEntry()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "select Barcode from Temp_Stock where Barcode=@d1"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox11.Text.ToString())
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
			Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
			If flag Then
				MessageBox.Show("Barcode is not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.TextBox11.Focus()
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
			Else
				ModCommonClasses.con.Close()
				Try
					Dim flag3 As Boolean = Operators.CompareString(Me.txtSupplierID.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please retrieve supplier info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.dgw4.Visible = False
						Me.cmbSupplierName.Focus()
						Return
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "select * from Company"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag4 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag4 Then
						MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag5 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag6 Then
							ModCommonClasses.con.Close()
						End If
						Return
					End If
					ModCommonClasses.con.Close()
					ModCommonClasses.con29 = New SqlConnection(ModCS.cs)
					ModCommonClasses.con29.Open()
					Dim text3 As String = "SELECT PID, RTRIM(Product.ProductCode), RTRIM(Product.ProductName), RTRIM(Product.HSNCode), RTRIM(Product.PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.PPrice),(Temp_Stock.MRP),(Product.Discount),Product.CGST,Product.SGST,Product.CESS,Product.CESS,RTRIM(Product.SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.SPrice),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Product.SalesAltUnit),RTRIM(Product.Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.PTax),RTRIM(Category),RTRIM(Colour),RTRIM(Size),RTRIM(Batch),RTRIM(Mfgdate),RTRIM(Expdate),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2) from Temp_Stock,Product,Category,SubCategory where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1"
					ModCommonClasses.cmd555 = New SqlCommand(text3)
					ModCommonClasses.cmd555.Parameters.AddWithValue("@d1", Me.TextBox11.Text.ToString())
					ModCommonClasses.cmd555.Connection = ModCommonClasses.con29
					ModCommonClasses.rdr555 = ModCommonClasses.cmd555.ExecuteReader()
					Dim flag7 As Boolean = ModCommonClasses.rdr555.Read()
					If flag7 Then
						Me.txtProductID.Text = ModCommonClasses.rdr555.GetValue(0).ToString()
						Me.lblPTaxType.Text = ModCommonClasses.rdr555.GetValue(22).ToString()
						Me.cmbProductName.Text = ModCommonClasses.rdr555.GetValue(2).ToString()
						Me.TextBox5.Text = ModCommonClasses.rdr555.GetValue(2).ToString()
						Me.dgw4.Visible = False
						Me.txtHSNCode.Text = ModCommonClasses.rdr555.GetValue(3).ToString()
						Me.txtBarcode.Text = ModCommonClasses.rdr555.GetValue(5).ToString()
						Me.txtPricePerQty.Text = ModCommonClasses.rdr555.GetValue(6).ToString()
						Me.txtMRP.Text = ModCommonClasses.rdr555.GetValue(7).ToString()
						Me.lblUnit.Text = ModCommonClasses.rdr555.GetValue(13).ToString()
						Me.cmbUnit.Text = ModCommonClasses.rdr555.GetValue(13).ToString()
						Me.TextBox4.Text = ModCommonClasses.rdr555.GetValue(13).ToString()
						Me.cmbaltunit.Text = ModCommonClasses.rdr555.GetValue(18).ToString()
						Me.lblAltUnit.Text = ModCommonClasses.rdr555.GetValue(18).ToString()
						Me.TextBox3.Text = ModCommonClasses.rdr555.GetValue(19).ToString()
						Me.lblAltValue.Text = ModCommonClasses.rdr555.GetValue(19).ToString()
						Dim flag8 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) = 0
						If flag8 Then
							Me.txtCGSTPer.Text = ModCommonClasses.rdr555.GetValue(9).ToString()
							Me.txtSGSTPer.Text = ModCommonClasses.rdr555.GetValue(10).ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag9 As Boolean = Operators.CompareString(Me.txtState.Text, Me.txtCompanyState.Text, False) <> 0
							If flag9 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr555.GetValue(9))) + Conversion.Val(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr555.GetValue(10))))
							End If
						End If
						Me.txtCESSPer.Text = ModCommonClasses.rdr555.GetValue(11).ToString()
						Me.txtRetail.Text = ModCommonClasses.rdr555.GetValue(15).ToString()
						Me.txtWholesale.Text = ModCommonClasses.rdr555.GetValue(14).ToString()
						Me.lblProductCat.Text = ModCommonClasses.rdr555.GetValue(23).ToString()
						Me.cmbColor.Text = ModCommonClasses.rdr555.GetValue(24).ToString()
						Me.cmbSize.Text = ModCommonClasses.rdr555.GetValue(25).ToString()
						Me.txtBatchNo.Text = ModCommonClasses.rdr555.GetValue(26).ToString()
						Me.txtMfg.Text = ModCommonClasses.rdr555.GetValue(27).ToString()
						Me.txtExp.Text = ModCommonClasses.rdr555.GetValue(28).ToString()
						Me.txtIMEI1.Text = ModCommonClasses.rdr555.GetValue(29).ToString()
						Me.txtIMEI2.Text = ModCommonClasses.rdr555.GetValue(30).ToString()
						Me.GetQty_S1()
						Dim flag10 As Boolean = ModCommonClasses.rdr555 IsNot Nothing
						If flag10 Then
							ModCommonClasses.rdr555.Close()
						End If
						Dim flag11 As Boolean = ModCommonClasses.con29.State = ConnectionState.Open
						If flag11 Then
							ModCommonClasses.con29.Close()
						End If
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.btnAdd_Click(Me.btnAdd, EventArgs.Empty)
				Me.TextBox11.Focus()
				Me.TextBox11.Text = ""
			End If
		End Sub

		' Token: 0x060089B0 RID: 35248 RVA: 0x00655D18 File Offset: 0x00653F18
		Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.BarcodeEntry()
			End If
		End Sub

		' Token: 0x060089B1 RID: 35249 RVA: 0x00655D40 File Offset: 0x00653F40
		Public Sub SuplRetrive()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(SupplierID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN), RTRIM(Limit), RTRIM(Lstatus),RTRIM(SCode) from Supplier where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtSup_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtSuplLimit.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtSuplLimitstatus.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtScode.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.GetSupplierBalance()
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

		' Token: 0x060089B2 RID: 35250 RVA: 0x00655F34 File Offset: 0x00654134
		Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Dim cam As New frmCamera()
			cam.Label2.Text = "PurchaseEntry"
			cam.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
			End If
		End Sub

		' Token: 0x060089B3 RID: 35251 RVA: 0x00655F9C File Offset: 0x0065419C
		Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060089B4 RID: 35252 RVA: 0x0004341C File Offset: 0x0004161C
		Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Me.PictureBox1.Image = Resources._12
		End Sub

		' Token: 0x060089B5 RID: 35253 RVA: 0x0065603C File Offset: 0x0065423C
		Public Sub Item_Img()
			Dim sqlCommand As SqlCommand = New SqlCommand("Select Photo from Product_Join where ProductID = @idn", ModCommonClasses.con)
			sqlCommand.Parameters.AddWithValue("@idn", Conversion.Val(Me.txtProductID.Text))
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
			Dim dataTable As DataTable = New DataTable()
			Try
				sqlDataAdapter.Fill(dataTable)
				Dim flag As Boolean = dataTable.Rows.Count = 1
				If flag Then
					Dim array As Byte() = CType(dataTable.AsEnumerable().ElementAtOrDefault(0)(0), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.PictureBox1.Image = Image.FromStream(memoryStream)
				Else
					Me.PictureBox1.Image = Resources._12
				End If
			Catch ex As Exception
				Me.PictureBox1.Image = Resources._12
			End Try
		End Sub

		' Token: 0x060089B6 RID: 35254 RVA: 0x00656128 File Offset: 0x00654328
		Private Sub CopyDataGridView(source As DataGridView, destination As DataGridView)
			destination.Columns.Clear()
			Try
				For Each obj As Object In source.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					destination.Columns.Add(CType(dataGridViewColumn.Clone(), DataGridViewColumn))
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			destination.Rows.Clear()
			Try
				For Each obj2 As Object In CType(source.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
					Dim flag As Boolean = Not dataGridViewRow.IsNewRow
					If flag Then
						Dim dataGridViewRow2 As DataGridViewRow = CType(dataGridViewRow.Clone(), DataGridViewRow)
						Dim num As Integer = dataGridViewRow.Cells.Count - 1
						For i As Integer = 0 To num
							dataGridViewRow2.Cells(i).Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(i).Value)
						Next
						destination.Rows.Add(dataGridViewRow2)
					End If
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x060089B7 RID: 35255 RVA: 0x00656280 File Offset: 0x00654480
		Private Function GenerateID2() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Stock_Hold ORDER BY ST_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ST_ID"))
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

		' Token: 0x060089B8 RID: 35256 RVA: 0x006563EC File Offset: 0x006545EC
		Public Sub auto2()
			Try
				Me.txtHold.Text = "H-" + Me.GenerateID2()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060089B9 RID: 35257 RVA: 0x00656450 File Offset: 0x00654650
		Private Sub btnHold_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Try
					Me.auto()
					Me.auto2()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "insert into Stock_Hold(Hold_ID, Date,PurchaseType, SupplierID, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks, ReferenceNo1,ReferenceNo2,TaxType,SupplierInvoiceNo,SupplierInvoiceDate,CGST,SGST,IGST,CESS,BillSundry,TaxableAmt,BankAccount,Doc,TillID) VALUES (@d2,@d3,@d4,@d5,@d6,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31)"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtHold.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
					ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbPurchaseType.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtSup_ID.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtPreviousDue.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtFreightCharges.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtOtherCharges.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtTotal.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtRoundOff.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.txtGrandTotal.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.txtTotalPaid.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(Me.txtBalance.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtRemarks.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtReferenceNo1.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.cmbReverse.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.txtGSTNonGST.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.txtSupplierInvoiceNo.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.dtpSupplierInvoiceDate.Value.[Date])
					ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(Me.txtCGST.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(Me.txtSGST.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.txtIGST.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Conversion.Val(Me.txtCESS.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.cmbBSundry.Text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.TextBox6.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Me.cmbAccountNo.Text.ToString())
					ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.txtTill_Id.Text.ToString())
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d30", SqlDbType.Image)
					sqlParameter.Value = buffer
					ModCommonClasses.cmd.Parameters.Add(sqlParameter)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "insert into Stock_Product_Hold(Hold_ID, ProductID,Barcode, Qty,MRP, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,SCode,TaxableAmt,AltQty,AltUnit,PTaxType,RPrice,WPrice,Color,Size,Info,Batch,Mfgdate,Expdate,RCipher,WCipher,Category,MainUnit,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33,@d34,@d35)"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Prepare()
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Me.txtHold.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(8).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(14).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtScode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d21", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(22).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(23).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(24).Value)))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(26).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(28).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d30", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(31).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d31", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(32).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(33).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d33", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(34).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d34", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(35).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d35", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(36).Value))
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.cmd.Parameters.Clear()
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					ModCommonClasses.con.Close()
					Dim text3 As String = "added the new hold purchase (Products) having Hold No. '" + Me.txtHold.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text3)
					MessageBox.Show("Successfully Hold", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060089BA RID: 35258 RVA: 0x006571CC File Offset: 0x006553CC
		Private Sub btnunhold_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmHoldrecord_Purchase.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmHoldrecord_Purchase.Label4.Text = "frmPurchaseEntry"
			MyProject.Forms.frmHoldrecord_Purchase.ShowDialog()
			MyProject.Forms.frmHoldrecord_Purchase.Dispose()
		End Sub

		' Token: 0x060089BB RID: 35259 RVA: 0x00657234 File Offset: 0x00655434
		Private Sub DeleteHoldRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from stock_hold where Hold_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "delete from stock_product_hold where Hold_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtHold.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				num = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag3 As Boolean = num > 0
				If flag3 Then
				End If
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04003CA0 RID: 15520
		Private _receivedValue3 As String

		' Token: 0x04003CA1 RID: 15521
		Private strVariant_id As String

		' Token: 0x04003CA2 RID: 15522
		Private _receivedValue1 As Decimal

		' Token: 0x04003CA3 RID: 15523
		Private _receivedValue As String

		' Token: 0x04003CA7 RID: 15527
		Private dt As DataTable

		' Token: 0x04003CA8 RID: 15528
		Private str As String

		' Token: 0x04003CA9 RID: 15529
		Private OBType As String

		' Token: 0x04003CAA RID: 15530
		Private tempbarcode As String

		' Token: 0x04003CAB RID: 15531
		Private num1 As Double

		' Token: 0x04003CAC RID: 15532
		Private num2 As Double

		' Token: 0x04003CAD RID: 15533
		Private num3 As Double

		' Token: 0x04003CAE RID: 15534
		Private num4 As Double

		' Token: 0x04003CAF RID: 15535
		Private num5 As Double

		' Token: 0x04003CB0 RID: 15536
		Private num6 As Double

		' Token: 0x04003CB1 RID: 15537
		Private num7 As Double

		' Token: 0x04003CB2 RID: 15538
		Private num8 As Double

		' Token: 0x04003CB3 RID: 15539
		Private num9 As Double

		' Token: 0x04003CB4 RID: 15540
		Private num10 As Double

		' Token: 0x04003CB5 RID: 15541
		Private num11 As Double

		' Token: 0x04003CB6 RID: 15542
		Private num111 As Double

		' Token: 0x04003CB7 RID: 15543
		Private numx As Double

		' Token: 0x04003CB8 RID: 15544
		Private OPQty As String

		' Token: 0x04003CB9 RID: 15545
		Private barcode_count As Integer

		' Token: 0x04003CBA RID: 15546
		Private InvoiceCount As Integer

		' Token: 0x04003CBB RID: 15547
		Public Shared dtReceived As DataTable

		' Token: 0x04003CBC RID: 15548
		Private keyPath As String

		' Token: 0x04003CBD RID: 15549
		Private valueName As String

		' Token: 0x04003CBE RID: 15550
		Private ntid As String

		' Token: 0x04003CBF RID: 15551
		Private gstid As String

		' Token: 0x04003CC0 RID: 15552
		Private lastClickedButton As Button

		' Token: 0x04003CC1 RID: 15553
		Private Dad As SqlDataAdapter

		' Token: 0x04003CC2 RID: 15554
		Private voice As Object

		' Token: 0x04003CC3 RID: 15555
		Private a1 As String

		' Token: 0x04003CC4 RID: 15556
		Private a2 As String

		' Token: 0x04003CC5 RID: 15557
		Private a3 As String

		' Token: 0x04003CC6 RID: 15558
		Private Dst As DataSet

		' Token: 0x04003CC7 RID: 15559
		Private CurrentRow As Object

		' Token: 0x04003CC8 RID: 15560
		Private InvDateSts As String

		' Token: 0x04003CC9 RID: 15561
		Private prevdate As DateTime

		' Token: 0x04003CCA RID: 15562
		Private b0 As String

		' Token: 0x04003CCB RID: 15563
		Private b1 As String

		' Token: 0x04003CCC RID: 15564
		Private b2 As String

		' Token: 0x04003CCD RID: 15565
		Private b3 As String

		' Token: 0x04003CCE RID: 15566
		Private b4 As String

		' Token: 0x04003CCF RID: 15567
		Private b5 As String

		' Token: 0x04003CD0 RID: 15568
		Private b6 As String

		' Token: 0x04003CD1 RID: 15569
		Private b7 As String

		' Token: 0x04003CD2 RID: 15570
		Private b8 As String

		' Token: 0x04003CD3 RID: 15571
		Private b9 As String

		' Token: 0x04003CD4 RID: 15572
		Private b12 As String

		' Token: 0x04003CD5 RID: 15573
		Private b13 As String

		' Token: 0x04003CD6 RID: 15574
		Private b14 As String

		' Token: 0x04003CD7 RID: 15575
		Private Photoname As String

		' Token: 0x04003CD8 RID: 15576
		Private IsImageChanged As Boolean
	End Class
End Namespace
