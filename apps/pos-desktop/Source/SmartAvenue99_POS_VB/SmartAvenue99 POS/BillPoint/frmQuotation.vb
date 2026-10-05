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
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020002AB RID: 683
	<DesignerGenerated()>
	Public Partial Class frmQuotation
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600AF07 RID: 44807 RVA: 0x0074B3E8 File Offset: 0x007495E8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmQuotation_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmQuotation_KeyDown
			Me.a = 0D
			Me.caddress = ""
			Me.clsprint = New clsprint()
			Me.dtprint = New DataTable()
			Me.strcompany = ""
			Me.strbankac = ""
			Me.strbankifsc = ""
			Me.ntid = ""
			Me.Dst = New DataSet()
			Me.voice = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SAPI.spvoice", ""))
			Me.InitializeComponent()
		End Sub

		' Token: 0x170043A5 RID: 17317
		' (get) Token: 0x0600AF0A RID: 44810 RVA: 0x0005157D File Offset: 0x0004F77D
		' (set) Token: 0x0600AF0B RID: 44811 RVA: 0x00051587 File Offset: 0x0004F787
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170043A6 RID: 17318
		' (get) Token: 0x0600AF0C RID: 44812 RVA: 0x00051590 File Offset: 0x0004F790
		' (set) Token: 0x0600AF0D RID: 44813 RVA: 0x0005159A File Offset: 0x0004F79A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170043A7 RID: 17319
		' (get) Token: 0x0600AF0E RID: 44814 RVA: 0x000515A3 File Offset: 0x0004F7A3
		' (set) Token: 0x0600AF0F RID: 44815 RVA: 0x00754F48 File Offset: 0x00753148
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

		' Token: 0x170043A8 RID: 17320
		' (get) Token: 0x0600AF10 RID: 44816 RVA: 0x000515AD File Offset: 0x0004F7AD
		' (set) Token: 0x0600AF11 RID: 44817 RVA: 0x000515B7 File Offset: 0x0004F7B7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170043A9 RID: 17321
		' (get) Token: 0x0600AF12 RID: 44818 RVA: 0x000515C0 File Offset: 0x0004F7C0
		' (set) Token: 0x0600AF13 RID: 44819 RVA: 0x000515CA File Offset: 0x0004F7CA
		Friend Overridable Property Label1 As Label

		' Token: 0x170043AA RID: 17322
		' (get) Token: 0x0600AF14 RID: 44820 RVA: 0x000515D3 File Offset: 0x0004F7D3
		' (set) Token: 0x0600AF15 RID: 44821 RVA: 0x000515DD File Offset: 0x0004F7DD
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170043AB RID: 17323
		' (get) Token: 0x0600AF16 RID: 44822 RVA: 0x000515E6 File Offset: 0x0004F7E6
		' (set) Token: 0x0600AF17 RID: 44823 RVA: 0x00754F8C File Offset: 0x0075318C
		Private _dtpQuotationDate As DateTimePicker
		Friend Overridable Property dtpQuotationDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpQuotationDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpQuotationDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpQuotationDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpQuotationDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpQuotationDate = value
				dateTimePicker = Me._dtpQuotationDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170043AC RID: 17324
		' (get) Token: 0x0600AF18 RID: 44824 RVA: 0x000515F0 File Offset: 0x0004F7F0
		' (set) Token: 0x0600AF19 RID: 44825 RVA: 0x000515FA File Offset: 0x0004F7FA
		Friend Overridable Property txtQuotationNo As TextBox

		' Token: 0x170043AD RID: 17325
		' (get) Token: 0x0600AF1A RID: 44826 RVA: 0x00051603 File Offset: 0x0004F803
		' (set) Token: 0x0600AF1B RID: 44827 RVA: 0x0005160D File Offset: 0x0004F80D
		Friend Overridable Property Label4 As Label

		' Token: 0x170043AE RID: 17326
		' (get) Token: 0x0600AF1C RID: 44828 RVA: 0x00051616 File Offset: 0x0004F816
		' (set) Token: 0x0600AF1D RID: 44829 RVA: 0x00754FEC File Offset: 0x007531EC
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

		' Token: 0x170043AF RID: 17327
		' (get) Token: 0x0600AF1E RID: 44830 RVA: 0x00051620 File Offset: 0x0004F820
		' (set) Token: 0x0600AF1F RID: 44831 RVA: 0x00755030 File Offset: 0x00753230
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

		' Token: 0x170043B0 RID: 17328
		' (get) Token: 0x0600AF20 RID: 44832 RVA: 0x0005162A File Offset: 0x0004F82A
		' (set) Token: 0x0600AF21 RID: 44833 RVA: 0x00051634 File Offset: 0x0004F834
		Friend Overridable Property lblUserType As Label

		' Token: 0x170043B1 RID: 17329
		' (get) Token: 0x0600AF22 RID: 44834 RVA: 0x0005163D File Offset: 0x0004F83D
		' (set) Token: 0x0600AF23 RID: 44835 RVA: 0x00051647 File Offset: 0x0004F847
		Friend Overridable Property lblSet As Label

		' Token: 0x170043B2 RID: 17330
		' (get) Token: 0x0600AF24 RID: 44836 RVA: 0x00051650 File Offset: 0x0004F850
		' (set) Token: 0x0600AF25 RID: 44837 RVA: 0x0005165A File Offset: 0x0004F85A
		Friend Overridable Property lblUser As Label

		' Token: 0x170043B3 RID: 17331
		' (get) Token: 0x0600AF26 RID: 44838 RVA: 0x00051663 File Offset: 0x0004F863
		' (set) Token: 0x0600AF27 RID: 44839 RVA: 0x0005166D File Offset: 0x0004F86D
		Friend Overridable Property txtCID As TextBox

		' Token: 0x170043B4 RID: 17332
		' (get) Token: 0x0600AF28 RID: 44840 RVA: 0x00051676 File Offset: 0x0004F876
		' (set) Token: 0x0600AF29 RID: 44841 RVA: 0x00051680 File Offset: 0x0004F880
		Friend Overridable Property txtTotalQty As TextBox

		' Token: 0x170043B5 RID: 17333
		' (get) Token: 0x0600AF2A RID: 44842 RVA: 0x00051689 File Offset: 0x0004F889
		' (set) Token: 0x0600AF2B RID: 44843 RVA: 0x00755074 File Offset: 0x00753274
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

		' Token: 0x170043B6 RID: 17334
		' (get) Token: 0x0600AF2C RID: 44844 RVA: 0x00051693 File Offset: 0x0004F893
		' (set) Token: 0x0600AF2D RID: 44845 RVA: 0x0005169D File Offset: 0x0004F89D
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x170043B7 RID: 17335
		' (get) Token: 0x0600AF2E RID: 44846 RVA: 0x000516A6 File Offset: 0x0004F8A6
		' (set) Token: 0x0600AF2F RID: 44847 RVA: 0x000516B0 File Offset: 0x0004F8B0
		Friend Overridable Property txtQ_ID As TextBox

		' Token: 0x170043B8 RID: 17336
		' (get) Token: 0x0600AF30 RID: 44848 RVA: 0x000516B9 File Offset: 0x0004F8B9
		' (set) Token: 0x0600AF31 RID: 44849 RVA: 0x007550B8 File Offset: 0x007532B8
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

		' Token: 0x170043B9 RID: 17337
		' (get) Token: 0x0600AF32 RID: 44850 RVA: 0x000516C3 File Offset: 0x0004F8C3
		' (set) Token: 0x0600AF33 RID: 44851 RVA: 0x000516CD File Offset: 0x0004F8CD
		Friend Overridable Property Label8 As Label

		' Token: 0x170043BA RID: 17338
		' (get) Token: 0x0600AF34 RID: 44852 RVA: 0x000516D6 File Offset: 0x0004F8D6
		' (set) Token: 0x0600AF35 RID: 44853 RVA: 0x007550FC File Offset: 0x007532FC
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

		' Token: 0x170043BB RID: 17339
		' (get) Token: 0x0600AF36 RID: 44854 RVA: 0x000516E0 File Offset: 0x0004F8E0
		' (set) Token: 0x0600AF37 RID: 44855 RVA: 0x00755140 File Offset: 0x00753340
		Private _btnListUpdate As Button
		Friend Overridable Property btnListUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListUpdate_Click
				Dim button As Button = Me._btnListUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListUpdate = value
				button = Me._btnListUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170043BC RID: 17340
		' (get) Token: 0x0600AF38 RID: 44856 RVA: 0x000516EA File Offset: 0x0004F8EA
		' (set) Token: 0x0600AF39 RID: 44857 RVA: 0x00755184 File Offset: 0x00753384
		Private _btnListReset As Button
		Friend Overridable Property btnListReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnListReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnListReset_Click
				Dim button As Button = Me._btnListReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnListReset = value
				button = Me._btnListReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170043BD RID: 17341
		' (get) Token: 0x0600AF3A RID: 44858 RVA: 0x000516F4 File Offset: 0x0004F8F4
		' (set) Token: 0x0600AF3B RID: 44859 RVA: 0x000516FE File Offset: 0x0004F8FE
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170043BE RID: 17342
		' (get) Token: 0x0600AF3C RID: 44860 RVA: 0x00051707 File Offset: 0x0004F907
		' (set) Token: 0x0600AF3D RID: 44861 RVA: 0x007551C8 File Offset: 0x007533C8
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtContactNo_Leave
				Dim eventHandler2 As EventHandler = AddressOf Me.txtContactNo_TextChanged
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler
					RemoveHandler textBox.TextChanged, eventHandler2
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler
					AddHandler textBox.TextChanged, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170043BF RID: 17343
		' (get) Token: 0x0600AF3E RID: 44862 RVA: 0x00051711 File Offset: 0x0004F911
		' (set) Token: 0x0600AF3F RID: 44863 RVA: 0x0005171B File Offset: 0x0004F91B
		Friend Overridable Property Label9 As Label

		' Token: 0x170043C0 RID: 17344
		' (get) Token: 0x0600AF40 RID: 44864 RVA: 0x00051724 File Offset: 0x0004F924
		' (set) Token: 0x0600AF41 RID: 44865 RVA: 0x0005172E File Offset: 0x0004F92E
		Friend Overridable Property Label2 As Label

		' Token: 0x170043C1 RID: 17345
		' (get) Token: 0x0600AF42 RID: 44866 RVA: 0x00051737 File Offset: 0x0004F937
		' (set) Token: 0x0600AF43 RID: 44867 RVA: 0x00755244 File Offset: 0x00753444
		Private _btnCustomerSelection As Button
		Friend Overridable Property btnCustomerSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCustomerSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelect_Click_1
				Dim button As Button = Me._btnCustomerSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCustomerSelection = value
				button = Me._btnCustomerSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170043C2 RID: 17346
		' (get) Token: 0x0600AF44 RID: 44868 RVA: 0x00051741 File Offset: 0x0004F941
		' (set) Token: 0x0600AF45 RID: 44869 RVA: 0x0005174B File Offset: 0x0004F94B
		Friend Overridable Property Label3 As Label

		' Token: 0x170043C3 RID: 17347
		' (get) Token: 0x0600AF46 RID: 44870 RVA: 0x00051754 File Offset: 0x0004F954
		' (set) Token: 0x0600AF47 RID: 44871 RVA: 0x0005175E File Offset: 0x0004F95E
		Friend Overridable Property txtCustomerID As TextBox

		' Token: 0x170043C4 RID: 17348
		' (get) Token: 0x0600AF48 RID: 44872 RVA: 0x00051767 File Offset: 0x0004F967
		' (set) Token: 0x0600AF49 RID: 44873 RVA: 0x00051771 File Offset: 0x0004F971
		Friend Overridable Property Label13 As Label

		' Token: 0x170043C5 RID: 17349
		' (get) Token: 0x0600AF4A RID: 44874 RVA: 0x0005177A File Offset: 0x0004F97A
		' (set) Token: 0x0600AF4B RID: 44875 RVA: 0x00051784 File Offset: 0x0004F984
		Friend Overridable Property Label7 As Label

		' Token: 0x170043C6 RID: 17350
		' (get) Token: 0x0600AF4C RID: 44876 RVA: 0x0005178D File Offset: 0x0004F98D
		' (set) Token: 0x0600AF4D RID: 44877 RVA: 0x00051797 File Offset: 0x0004F997
		Friend Overridable Property txtGSTIN As TextBox

		' Token: 0x170043C7 RID: 17351
		' (get) Token: 0x0600AF4E RID: 44878 RVA: 0x000517A0 File Offset: 0x0004F9A0
		' (set) Token: 0x0600AF4F RID: 44879 RVA: 0x000517AA File Offset: 0x0004F9AA
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170043C8 RID: 17352
		' (get) Token: 0x0600AF50 RID: 44880 RVA: 0x000517B3 File Offset: 0x0004F9B3
		' (set) Token: 0x0600AF51 RID: 44881 RVA: 0x000517BD File Offset: 0x0004F9BD
		Friend Overridable Property txtCESSAmt As TextBox

		' Token: 0x170043C9 RID: 17353
		' (get) Token: 0x0600AF52 RID: 44882 RVA: 0x000517C6 File Offset: 0x0004F9C6
		' (set) Token: 0x0600AF53 RID: 44883 RVA: 0x000517D0 File Offset: 0x0004F9D0
		Friend Overridable Property txtIGSTAmt As TextBox

		' Token: 0x170043CA RID: 17354
		' (get) Token: 0x0600AF54 RID: 44884 RVA: 0x000517D9 File Offset: 0x0004F9D9
		' (set) Token: 0x0600AF55 RID: 44885 RVA: 0x000517E3 File Offset: 0x0004F9E3
		Friend Overridable Property Label34 As Label

		' Token: 0x170043CB RID: 17355
		' (get) Token: 0x0600AF56 RID: 44886 RVA: 0x000517EC File Offset: 0x0004F9EC
		' (set) Token: 0x0600AF57 RID: 44887 RVA: 0x000517F6 File Offset: 0x0004F9F6
		Friend Overridable Property Label41 As Label

		' Token: 0x170043CC RID: 17356
		' (get) Token: 0x0600AF58 RID: 44888 RVA: 0x000517FF File Offset: 0x0004F9FF
		' (set) Token: 0x0600AF59 RID: 44889 RVA: 0x00051809 File Offset: 0x0004FA09
		Friend Overridable Property Label35 As Label

		' Token: 0x170043CD RID: 17357
		' (get) Token: 0x0600AF5A RID: 44890 RVA: 0x00051812 File Offset: 0x0004FA12
		' (set) Token: 0x0600AF5B RID: 44891 RVA: 0x0005181C File Offset: 0x0004FA1C
		Friend Overridable Property txtIGSTPer As TextBox

		' Token: 0x170043CE RID: 17358
		' (get) Token: 0x0600AF5C RID: 44892 RVA: 0x00051825 File Offset: 0x0004FA25
		' (set) Token: 0x0600AF5D RID: 44893 RVA: 0x0005182F File Offset: 0x0004FA2F
		Friend Overridable Property Label42 As Label

		' Token: 0x170043CF RID: 17359
		' (get) Token: 0x0600AF5E RID: 44894 RVA: 0x00051838 File Offset: 0x0004FA38
		' (set) Token: 0x0600AF5F RID: 44895 RVA: 0x00755288 File Offset: 0x00753488
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

		' Token: 0x170043D0 RID: 17360
		' (get) Token: 0x0600AF60 RID: 44896 RVA: 0x00051842 File Offset: 0x0004FA42
		' (set) Token: 0x0600AF61 RID: 44897 RVA: 0x0005184C File Offset: 0x0004FA4C
		Friend Overridable Property Label28 As Label

		' Token: 0x170043D1 RID: 17361
		' (get) Token: 0x0600AF62 RID: 44898 RVA: 0x00051855 File Offset: 0x0004FA55
		' (set) Token: 0x0600AF63 RID: 44899 RVA: 0x0005185F File Offset: 0x0004FA5F
		Friend Overridable Property txtCESSPer As TextBox

		' Token: 0x170043D2 RID: 17362
		' (get) Token: 0x0600AF64 RID: 44900 RVA: 0x00051868 File Offset: 0x0004FA68
		' (set) Token: 0x0600AF65 RID: 44901 RVA: 0x00051872 File Offset: 0x0004FA72
		Friend Overridable Property txtSGSTAmt As TextBox

		' Token: 0x170043D3 RID: 17363
		' (get) Token: 0x0600AF66 RID: 44902 RVA: 0x0005187B File Offset: 0x0004FA7B
		' (set) Token: 0x0600AF67 RID: 44903 RVA: 0x00051885 File Offset: 0x0004FA85
		Friend Overridable Property Label6 As Label

		' Token: 0x170043D4 RID: 17364
		' (get) Token: 0x0600AF68 RID: 44904 RVA: 0x0005188E File Offset: 0x0004FA8E
		' (set) Token: 0x0600AF69 RID: 44905 RVA: 0x00051898 File Offset: 0x0004FA98
		Friend Overridable Property Label45 As Label

		' Token: 0x170043D5 RID: 17365
		' (get) Token: 0x0600AF6A RID: 44906 RVA: 0x000518A1 File Offset: 0x0004FAA1
		' (set) Token: 0x0600AF6B RID: 44907 RVA: 0x000518AB File Offset: 0x0004FAAB
		Friend Overridable Property txtTotalAmount As TextBox

		' Token: 0x170043D6 RID: 17366
		' (get) Token: 0x0600AF6C RID: 44908 RVA: 0x000518B4 File Offset: 0x0004FAB4
		' (set) Token: 0x0600AF6D RID: 44909 RVA: 0x000518BE File Offset: 0x0004FABE
		Friend Overridable Property Label46 As Label

		' Token: 0x170043D7 RID: 17367
		' (get) Token: 0x0600AF6E RID: 44910 RVA: 0x000518C7 File Offset: 0x0004FAC7
		' (set) Token: 0x0600AF6F RID: 44911 RVA: 0x00755304 File Offset: 0x00753504
		Private _txtDiscPer As TextBox
		Friend Overridable Property txtDiscPer As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscPer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscPer_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscPer_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscPer_KeyDown
				Dim textBox As TextBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscPer = value
				textBox = Me._txtDiscPer
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170043D8 RID: 17368
		' (get) Token: 0x0600AF70 RID: 44912 RVA: 0x000518D1 File Offset: 0x0004FAD1
		' (set) Token: 0x0600AF71 RID: 44913 RVA: 0x000518DB File Offset: 0x0004FADB
		Friend Overridable Property lblUnit As Label

		' Token: 0x170043D9 RID: 17369
		' (get) Token: 0x0600AF72 RID: 44914 RVA: 0x000518E4 File Offset: 0x0004FAE4
		' (set) Token: 0x0600AF73 RID: 44915 RVA: 0x000518EE File Offset: 0x0004FAEE
		Friend Overridable Property Label21 As Label

		' Token: 0x170043DA RID: 17370
		' (get) Token: 0x0600AF74 RID: 44916 RVA: 0x000518F7 File Offset: 0x0004FAF7
		' (set) Token: 0x0600AF75 RID: 44917 RVA: 0x00051901 File Offset: 0x0004FB01
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x170043DB RID: 17371
		' (get) Token: 0x0600AF76 RID: 44918 RVA: 0x0005190A File Offset: 0x0004FB0A
		' (set) Token: 0x0600AF77 RID: 44919 RVA: 0x00051914 File Offset: 0x0004FB14
		Friend Overridable Property Label33 As Label

		' Token: 0x170043DC RID: 17372
		' (get) Token: 0x0600AF78 RID: 44920 RVA: 0x0005191D File Offset: 0x0004FB1D
		' (set) Token: 0x0600AF79 RID: 44921 RVA: 0x00051927 File Offset: 0x0004FB27
		Friend Overridable Property txtCGSTAmt As TextBox

		' Token: 0x170043DD RID: 17373
		' (get) Token: 0x0600AF7A RID: 44922 RVA: 0x00051930 File Offset: 0x0004FB30
		' (set) Token: 0x0600AF7B RID: 44923 RVA: 0x00755380 File Offset: 0x00753580
		Private _txtPricePerQty As TextBox
		Friend Overridable Property txtPricePerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPricePerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPricePerQty_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtPricePerQty_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPricePerQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtPricePerQty_GotFocus
				Dim eventHandler3 As EventHandler = AddressOf Me.txtPricePerQty_LostFocus
				Dim textBox As TextBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.GotFocus, eventHandler2
					RemoveHandler textBox.LostFocus, eventHandler3
				End If
				Me._txtPricePerQty = value
				textBox = Me._txtPricePerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.GotFocus, eventHandler2
					AddHandler textBox.LostFocus, eventHandler3
				End If
			End Set
		End Property

		' Token: 0x170043DE RID: 17374
		' (get) Token: 0x0600AF7C RID: 44924 RVA: 0x0005193A File Offset: 0x0004FB3A
		' (set) Token: 0x0600AF7D RID: 44925 RVA: 0x00051944 File Offset: 0x0004FB44
		Friend Overridable Property txtSGSTPer As TextBox

		' Token: 0x170043DF RID: 17375
		' (get) Token: 0x0600AF7E RID: 44926 RVA: 0x0005194D File Offset: 0x0004FB4D
		' (set) Token: 0x0600AF7F RID: 44927 RVA: 0x00755440 File Offset: 0x00753640
		Private _txtQty As TextBox
		Friend Overridable Property txtQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtQty_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.txtQty_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.txtQty_Leave
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Leave, eventHandler2
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Leave, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x170043E0 RID: 17376
		' (get) Token: 0x0600AF80 RID: 44928 RVA: 0x00051957 File Offset: 0x0004FB57
		' (set) Token: 0x0600AF81 RID: 44929 RVA: 0x00051961 File Offset: 0x0004FB61
		Friend Overridable Property txtCGSTPer As TextBox

		' Token: 0x170043E1 RID: 17377
		' (get) Token: 0x0600AF82 RID: 44930 RVA: 0x0005196A File Offset: 0x0004FB6A
		' (set) Token: 0x0600AF83 RID: 44931 RVA: 0x00051974 File Offset: 0x0004FB74
		Friend Overridable Property Label25 As Label

		' Token: 0x170043E2 RID: 17378
		' (get) Token: 0x0600AF84 RID: 44932 RVA: 0x0005197D File Offset: 0x0004FB7D
		' (set) Token: 0x0600AF85 RID: 44933 RVA: 0x00051987 File Offset: 0x0004FB87
		Friend Overridable Property Label10 As Label

		' Token: 0x170043E3 RID: 17379
		' (get) Token: 0x0600AF86 RID: 44934 RVA: 0x00051990 File Offset: 0x0004FB90
		' (set) Token: 0x0600AF87 RID: 44935 RVA: 0x0005199A File Offset: 0x0004FB9A
		Friend Overridable Property Label22 As Label

		' Token: 0x170043E4 RID: 17380
		' (get) Token: 0x0600AF88 RID: 44936 RVA: 0x000519A3 File Offset: 0x0004FBA3
		' (set) Token: 0x0600AF89 RID: 44937 RVA: 0x000519AD File Offset: 0x0004FBAD
		Friend Overridable Property Label11 As Label

		' Token: 0x170043E5 RID: 17381
		' (get) Token: 0x0600AF8A RID: 44938 RVA: 0x000519B6 File Offset: 0x0004FBB6
		' (set) Token: 0x0600AF8B RID: 44939 RVA: 0x007554E0 File Offset: 0x007536E0
		Private _btnProductSelection As Button
		Friend Overridable Property btnProductSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnProductSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnProductSelection_Click
				Dim button As Button = Me._btnProductSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnProductSelection = value
				button = Me._btnProductSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170043E6 RID: 17382
		' (get) Token: 0x0600AF8C RID: 44940 RVA: 0x000519C0 File Offset: 0x0004FBC0
		' (set) Token: 0x0600AF8D RID: 44941 RVA: 0x000519CA File Offset: 0x0004FBCA
		Friend Overridable Property txtHSNCode As TextBox

		' Token: 0x170043E7 RID: 17383
		' (get) Token: 0x0600AF8E RID: 44942 RVA: 0x000519D3 File Offset: 0x0004FBD3
		' (set) Token: 0x0600AF8F RID: 44943 RVA: 0x000519DD File Offset: 0x0004FBDD
		Friend Overridable Property Label12 As Label

		' Token: 0x170043E8 RID: 17384
		' (get) Token: 0x0600AF90 RID: 44944 RVA: 0x000519E6 File Offset: 0x0004FBE6
		' (set) Token: 0x0600AF91 RID: 44945 RVA: 0x000519F0 File Offset: 0x0004FBF0
		Friend Overridable Property Label14 As Label

		' Token: 0x170043E9 RID: 17385
		' (get) Token: 0x0600AF92 RID: 44946 RVA: 0x000519F9 File Offset: 0x0004FBF9
		' (set) Token: 0x0600AF93 RID: 44947 RVA: 0x00755524 File Offset: 0x00753724
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
				Dim dataGridViewRowsRemovedEventHandler As DataGridViewRowsRemovedEventHandler = AddressOf Me.DataGridView1_RowsRemoved
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.DataGridView1_CellFormatting
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.RowsRemoved, dataGridViewRowsRemovedEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.RowsRemoved, dataGridViewRowsRemovedEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
				End If
			End Set
		End Property

		' Token: 0x170043EA RID: 17386
		' (get) Token: 0x0600AF94 RID: 44948 RVA: 0x00051A03 File Offset: 0x0004FC03
		' (set) Token: 0x0600AF95 RID: 44949 RVA: 0x00051A0D File Offset: 0x0004FC0D
		Friend Overridable Property pnlCalc As Panel

		' Token: 0x170043EB RID: 17387
		' (get) Token: 0x0600AF96 RID: 44950 RVA: 0x00051A16 File Offset: 0x0004FC16
		' (set) Token: 0x0600AF97 RID: 44951 RVA: 0x00051A20 File Offset: 0x0004FC20
		Friend Overridable Property Label43 As Label

		' Token: 0x170043EC RID: 17388
		' (get) Token: 0x0600AF98 RID: 44952 RVA: 0x00051A29 File Offset: 0x0004FC29
		' (set) Token: 0x0600AF99 RID: 44953 RVA: 0x00051A33 File Offset: 0x0004FC33
		Friend Overridable Property txtCESS As TextBox

		' Token: 0x170043ED RID: 17389
		' (get) Token: 0x0600AF9A RID: 44954 RVA: 0x00051A3C File Offset: 0x0004FC3C
		' (set) Token: 0x0600AF9B RID: 44955 RVA: 0x00051A46 File Offset: 0x0004FC46
		Friend Overridable Property txtIGST As TextBox

		' Token: 0x170043EE RID: 17390
		' (get) Token: 0x0600AF9C RID: 44956 RVA: 0x00051A4F File Offset: 0x0004FC4F
		' (set) Token: 0x0600AF9D RID: 44957 RVA: 0x00051A59 File Offset: 0x0004FC59
		Friend Overridable Property Label15 As Label

		' Token: 0x170043EF RID: 17391
		' (get) Token: 0x0600AF9E RID: 44958 RVA: 0x00051A62 File Offset: 0x0004FC62
		' (set) Token: 0x0600AF9F RID: 44959 RVA: 0x00051A6C File Offset: 0x0004FC6C
		Friend Overridable Property txtSGST As TextBox

		' Token: 0x170043F0 RID: 17392
		' (get) Token: 0x0600AFA0 RID: 44960 RVA: 0x00051A75 File Offset: 0x0004FC75
		' (set) Token: 0x0600AFA1 RID: 44961 RVA: 0x00051A7F File Offset: 0x0004FC7F
		Friend Overridable Property Label23 As Label

		' Token: 0x170043F1 RID: 17393
		' (get) Token: 0x0600AFA2 RID: 44962 RVA: 0x00051A88 File Offset: 0x0004FC88
		' (set) Token: 0x0600AFA3 RID: 44963 RVA: 0x00051A92 File Offset: 0x0004FC92
		Friend Overridable Property txtCGST As TextBox

		' Token: 0x170043F2 RID: 17394
		' (get) Token: 0x0600AFA4 RID: 44964 RVA: 0x00051A9B File Offset: 0x0004FC9B
		' (set) Token: 0x0600AFA5 RID: 44965 RVA: 0x00051AA5 File Offset: 0x0004FCA5
		Friend Overridable Property Label16 As Label

		' Token: 0x170043F3 RID: 17395
		' (get) Token: 0x0600AFA6 RID: 44966 RVA: 0x00051AAE File Offset: 0x0004FCAE
		' (set) Token: 0x0600AFA7 RID: 44967 RVA: 0x00051AB8 File Offset: 0x0004FCB8
		Friend Overridable Property Label32 As Label

		' Token: 0x170043F4 RID: 17396
		' (get) Token: 0x0600AFA8 RID: 44968 RVA: 0x00051AC1 File Offset: 0x0004FCC1
		' (set) Token: 0x0600AFA9 RID: 44969 RVA: 0x00051ACB File Offset: 0x0004FCCB
		Friend Overridable Property txtTotal As TextBox

		' Token: 0x170043F5 RID: 17397
		' (get) Token: 0x0600AFAA RID: 44970 RVA: 0x00051AD4 File Offset: 0x0004FCD4
		' (set) Token: 0x0600AFAB RID: 44971 RVA: 0x00051ADE File Offset: 0x0004FCDE
		Friend Overridable Property Label17 As Label

		' Token: 0x170043F6 RID: 17398
		' (get) Token: 0x0600AFAC RID: 44972 RVA: 0x00051AE7 File Offset: 0x0004FCE7
		' (set) Token: 0x0600AFAD RID: 44973 RVA: 0x00051AF1 File Offset: 0x0004FCF1
		Friend Overridable Property Label18 As Label

		' Token: 0x170043F7 RID: 17399
		' (get) Token: 0x0600AFAE RID: 44974 RVA: 0x00051AFA File Offset: 0x0004FCFA
		' (set) Token: 0x0600AFAF RID: 44975 RVA: 0x00051B04 File Offset: 0x0004FD04
		Friend Overridable Property txtRoundOff As TextBox

		' Token: 0x170043F8 RID: 17400
		' (get) Token: 0x0600AFB0 RID: 44976 RVA: 0x00051B0D File Offset: 0x0004FD0D
		' (set) Token: 0x0600AFB1 RID: 44977 RVA: 0x00051B17 File Offset: 0x0004FD17
		Friend Overridable Property txtGrandTotal As TextBox

		' Token: 0x170043F9 RID: 17401
		' (get) Token: 0x0600AFB2 RID: 44978 RVA: 0x00051B20 File Offset: 0x0004FD20
		' (set) Token: 0x0600AFB3 RID: 44979 RVA: 0x00051B2A File Offset: 0x0004FD2A
		Friend Overridable Property txtSubTotal As TextBox

		' Token: 0x170043FA RID: 17402
		' (get) Token: 0x0600AFB4 RID: 44980 RVA: 0x00051B33 File Offset: 0x0004FD33
		' (set) Token: 0x0600AFB5 RID: 44981 RVA: 0x00051B3D File Offset: 0x0004FD3D
		Friend Overridable Property Label31 As Label

		' Token: 0x170043FB RID: 17403
		' (get) Token: 0x0600AFB6 RID: 44982 RVA: 0x00051B46 File Offset: 0x0004FD46
		' (set) Token: 0x0600AFB7 RID: 44983 RVA: 0x00051B50 File Offset: 0x0004FD50
		Friend Overridable Property txtCustomerState As TextBox

		' Token: 0x170043FC RID: 17404
		' (get) Token: 0x0600AFB8 RID: 44984 RVA: 0x00051B59 File Offset: 0x0004FD59
		' (set) Token: 0x0600AFB9 RID: 44985 RVA: 0x00051B63 File Offset: 0x0004FD63
		Friend Overridable Property Label19 As Label

		' Token: 0x170043FD RID: 17405
		' (get) Token: 0x0600AFBA RID: 44986 RVA: 0x00051B6C File Offset: 0x0004FD6C
		' (set) Token: 0x0600AFBB RID: 44987 RVA: 0x00051B76 File Offset: 0x0004FD76
		Friend Overridable Property txtCompanyState As TextBox

		' Token: 0x170043FE RID: 17406
		' (get) Token: 0x0600AFBC RID: 44988 RVA: 0x00051B7F File Offset: 0x0004FD7F
		' (set) Token: 0x0600AFBD RID: 44989 RVA: 0x007555C4 File Offset: 0x007537C4
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

		' Token: 0x170043FF RID: 17407
		' (get) Token: 0x0600AFBE RID: 44990 RVA: 0x00051B89 File Offset: 0x0004FD89
		' (set) Token: 0x0600AFBF RID: 44991 RVA: 0x00755624 File Offset: 0x00753824
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

		' Token: 0x17004400 RID: 17408
		' (get) Token: 0x0600AFC0 RID: 44992 RVA: 0x00051B93 File Offset: 0x0004FD93
		' (set) Token: 0x0600AFC1 RID: 44993 RVA: 0x00051B9D File Offset: 0x0004FD9D
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17004401 RID: 17409
		' (get) Token: 0x0600AFC2 RID: 44994 RVA: 0x00051BA6 File Offset: 0x0004FDA6
		' (set) Token: 0x0600AFC3 RID: 44995 RVA: 0x00051BB0 File Offset: 0x0004FDB0
		Friend Overridable Property Label24 As Label

		' Token: 0x17004402 RID: 17410
		' (get) Token: 0x0600AFC4 RID: 44996 RVA: 0x00051BB9 File Offset: 0x0004FDB9
		' (set) Token: 0x0600AFC5 RID: 44997 RVA: 0x00051BC3 File Offset: 0x0004FDC3
		Friend Overridable Property Label20 As Label

		' Token: 0x17004403 RID: 17411
		' (get) Token: 0x0600AFC6 RID: 44998 RVA: 0x00051BCC File Offset: 0x0004FDCC
		' (set) Token: 0x0600AFC7 RID: 44999 RVA: 0x00051BD6 File Offset: 0x0004FDD6
		Friend Overridable Property Label26 As Label

		' Token: 0x17004404 RID: 17412
		' (get) Token: 0x0600AFC8 RID: 45000 RVA: 0x00051BDF File Offset: 0x0004FDDF
		' (set) Token: 0x0600AFC9 RID: 45001 RVA: 0x00051BE9 File Offset: 0x0004FDE9
		Friend Overridable Property txtInvCode1 As TextBox

		' Token: 0x17004405 RID: 17413
		' (get) Token: 0x0600AFCA RID: 45002 RVA: 0x00051BF2 File Offset: 0x0004FDF2
		' (set) Token: 0x0600AFCB RID: 45003 RVA: 0x00051BFC File Offset: 0x0004FDFC
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x17004406 RID: 17414
		' (get) Token: 0x0600AFCC RID: 45004 RVA: 0x00051C05 File Offset: 0x0004FE05
		' (set) Token: 0x0600AFCD RID: 45005 RVA: 0x00051C0F File Offset: 0x0004FE0F
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x17004407 RID: 17415
		' (get) Token: 0x0600AFCE RID: 45006 RVA: 0x00051C18 File Offset: 0x0004FE18
		' (set) Token: 0x0600AFCF RID: 45007 RVA: 0x00051C22 File Offset: 0x0004FE22
		Friend Overridable Property txtSuffix As TextBox

		' Token: 0x17004408 RID: 17416
		' (get) Token: 0x0600AFD0 RID: 45008 RVA: 0x00051C2B File Offset: 0x0004FE2B
		' (set) Token: 0x0600AFD1 RID: 45009 RVA: 0x00051C35 File Offset: 0x0004FE35
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x17004409 RID: 17417
		' (get) Token: 0x0600AFD2 RID: 45010 RVA: 0x00051C3E File Offset: 0x0004FE3E
		' (set) Token: 0x0600AFD3 RID: 45011 RVA: 0x00755668 File Offset: 0x00753868
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

		' Token: 0x1700440A RID: 17418
		' (get) Token: 0x0600AFD4 RID: 45012 RVA: 0x00051C48 File Offset: 0x0004FE48
		' (set) Token: 0x0600AFD5 RID: 45013 RVA: 0x007556AC File Offset: 0x007538AC
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

		' Token: 0x1700440B RID: 17419
		' (get) Token: 0x0600AFD6 RID: 45014 RVA: 0x00051C52 File Offset: 0x0004FE52
		' (set) Token: 0x0600AFD7 RID: 45015 RVA: 0x007556F0 File Offset: 0x007538F0
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

		' Token: 0x1700440C RID: 17420
		' (get) Token: 0x0600AFD8 RID: 45016 RVA: 0x00051C5C File Offset: 0x0004FE5C
		' (set) Token: 0x0600AFD9 RID: 45017 RVA: 0x00755734 File Offset: 0x00753934
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbUnit_KeyDown
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbUnit_Validated
				Dim comboBox As ComboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validated, eventHandler2
				End If
				Me._cmbUnit = value
				comboBox = Me._cmbUnit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validated, eventHandler2
				End If
			End Set
		End Property

		' Token: 0x1700440D RID: 17421
		' (get) Token: 0x0600AFDA RID: 45018 RVA: 0x00051C66 File Offset: 0x0004FE66
		' (set) Token: 0x0600AFDB RID: 45019 RVA: 0x00051C70 File Offset: 0x0004FE70
		Friend Overridable Property Label27 As Label

		' Token: 0x1700440E RID: 17422
		' (get) Token: 0x0600AFDC RID: 45020 RVA: 0x00051C79 File Offset: 0x0004FE79
		' (set) Token: 0x0600AFDD RID: 45021 RVA: 0x00051C83 File Offset: 0x0004FE83
		Friend Overridable Property Label29 As Label

		' Token: 0x1700440F RID: 17423
		' (get) Token: 0x0600AFDE RID: 45022 RVA: 0x00051C8C File Offset: 0x0004FE8C
		' (set) Token: 0x0600AFDF RID: 45023 RVA: 0x007557B0 File Offset: 0x007539B0
		Private _txtDiscAmtPerQty As TextBox
		Friend Overridable Property txtDiscAmtPerQty As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscAmtPerQty
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDiscAmtPerQty_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscAmtPerQty_KeyDown
				Dim textBox As TextBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscAmtPerQty = value
				textBox = Me._txtDiscAmtPerQty
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004410 RID: 17424
		' (get) Token: 0x0600AFE0 RID: 45024 RVA: 0x00051C96 File Offset: 0x0004FE96
		' (set) Token: 0x0600AFE1 RID: 45025 RVA: 0x00051CA0 File Offset: 0x0004FEA0
		Friend Overridable Property Label72 As Label

		' Token: 0x17004411 RID: 17425
		' (get) Token: 0x0600AFE2 RID: 45026 RVA: 0x00051CA9 File Offset: 0x0004FEA9
		' (set) Token: 0x0600AFE3 RID: 45027 RVA: 0x00051CB3 File Offset: 0x0004FEB3
		Friend Overridable Property lblAltValue As Label

		' Token: 0x17004412 RID: 17426
		' (get) Token: 0x0600AFE4 RID: 45028 RVA: 0x00051CBC File Offset: 0x0004FEBC
		' (set) Token: 0x0600AFE5 RID: 45029 RVA: 0x00051CC6 File Offset: 0x0004FEC6
		Friend Overridable Property lblAltUnit As Label

		' Token: 0x17004413 RID: 17427
		' (get) Token: 0x0600AFE6 RID: 45030 RVA: 0x00051CCF File Offset: 0x0004FECF
		' (set) Token: 0x0600AFE7 RID: 45031 RVA: 0x00051CD9 File Offset: 0x0004FED9
		Friend Overridable Property Label55 As Label

		' Token: 0x17004414 RID: 17428
		' (get) Token: 0x0600AFE8 RID: 45032 RVA: 0x00051CE2 File Offset: 0x0004FEE2
		' (set) Token: 0x0600AFE9 RID: 45033 RVA: 0x00051CEC File Offset: 0x0004FEEC
		Friend Overridable Property Label53 As Label

		' Token: 0x17004415 RID: 17429
		' (get) Token: 0x0600AFEA RID: 45034 RVA: 0x00051CF5 File Offset: 0x0004FEF5
		' (set) Token: 0x0600AFEB RID: 45035 RVA: 0x00051CFF File Offset: 0x0004FEFF
		Friend Overridable Property Label52 As Label

		' Token: 0x17004416 RID: 17430
		' (get) Token: 0x0600AFEC RID: 45036 RVA: 0x00051D08 File Offset: 0x0004FF08
		' (set) Token: 0x0600AFED RID: 45037 RVA: 0x0075582C File Offset: 0x00753A2C
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
				Dim eventHandler As EventHandler = AddressOf Me.TextBox5_TextChanged
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.TextBox5_KeyUp
				Dim textBox As TextBox = Me._TextBox5
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler2
				End If
				Me._TextBox5 = value
				textBox = Me._TextBox5
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17004417 RID: 17431
		' (get) Token: 0x0600AFEE RID: 45038 RVA: 0x00051D12 File Offset: 0x0004FF12
		' (set) Token: 0x0600AFEF RID: 45039 RVA: 0x007558A8 File Offset: 0x00753AA8
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyUp
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw4_RowPostPaint
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyUp, keyEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler2
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyUp, keyEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler2
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004418 RID: 17432
		' (get) Token: 0x0600AFF0 RID: 45040 RVA: 0x00051D1C File Offset: 0x0004FF1C
		' (set) Token: 0x0600AFF1 RID: 45041 RVA: 0x00051D26 File Offset: 0x0004FF26
		Friend Overridable Property cmbProductName As ComboBox

		' Token: 0x17004419 RID: 17433
		' (get) Token: 0x0600AFF2 RID: 45042 RVA: 0x00051D2F File Offset: 0x0004FF2F
		' (set) Token: 0x0600AFF3 RID: 45043 RVA: 0x00755948 File Offset: 0x00753B48
		Private _cmbCustomerName As ComboBox
		Friend Overridable Property cmbCustomerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_SelectedIndexChanged
				Dim eventHandler2 As EventHandler = AddressOf Me.cmbCustomerName_Validated
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCustomerName_KeyDown
				Dim eventHandler3 As EventHandler = AddressOf Me.cmbCustomerName_Leave
				Dim eventHandler4 As EventHandler = AddressOf Me.cmbCustomerName_TextChanged
				Dim comboBox As ComboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validated, eventHandler2
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Leave, eventHandler3
					RemoveHandler comboBox.TextChanged, eventHandler4
				End If
				Me._cmbCustomerName = value
				comboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validated, eventHandler2
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Leave, eventHandler3
					AddHandler comboBox.TextChanged, eventHandler4
				End If
			End Set
		End Property

		' Token: 0x1700441A RID: 17434
		' (get) Token: 0x0600AFF4 RID: 45044 RVA: 0x00051D39 File Offset: 0x0004FF39
		' (set) Token: 0x0600AFF5 RID: 45045 RVA: 0x00755A08 File Offset: 0x00753C08
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

		' Token: 0x1700441B RID: 17435
		' (get) Token: 0x0600AFF6 RID: 45046 RVA: 0x00051D43 File Offset: 0x0004FF43
		' (set) Token: 0x0600AFF7 RID: 45047 RVA: 0x00755A4C File Offset: 0x00753C4C
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

		' Token: 0x1700441C RID: 17436
		' (get) Token: 0x0600AFF8 RID: 45048 RVA: 0x00051D4D File Offset: 0x0004FF4D
		' (set) Token: 0x0600AFF9 RID: 45049 RVA: 0x00755A90 File Offset: 0x00753C90
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

		' Token: 0x1700441D RID: 17437
		' (get) Token: 0x0600AFFA RID: 45050 RVA: 0x00051D57 File Offset: 0x0004FF57
		' (set) Token: 0x0600AFFB RID: 45051 RVA: 0x00755AD4 File Offset: 0x00753CD4
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

		' Token: 0x1700441E RID: 17438
		' (get) Token: 0x0600AFFC RID: 45052 RVA: 0x00051D61 File Offset: 0x0004FF61
		' (set) Token: 0x0600AFFD RID: 45053 RVA: 0x00755B18 File Offset: 0x00753D18
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

		' Token: 0x1700441F RID: 17439
		' (get) Token: 0x0600AFFE RID: 45054 RVA: 0x00051D6B File Offset: 0x0004FF6B
		' (set) Token: 0x0600AFFF RID: 45055 RVA: 0x00755B5C File Offset: 0x00753D5C
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

		' Token: 0x17004420 RID: 17440
		' (get) Token: 0x0600B000 RID: 45056 RVA: 0x00051D75 File Offset: 0x0004FF75
		' (set) Token: 0x0600B001 RID: 45057 RVA: 0x00755BA0 File Offset: 0x00753DA0
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

		' Token: 0x17004421 RID: 17441
		' (get) Token: 0x0600B002 RID: 45058 RVA: 0x00051D7F File Offset: 0x0004FF7F
		' (set) Token: 0x0600B003 RID: 45059 RVA: 0x00755BE4 File Offset: 0x00753DE4
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

		' Token: 0x17004422 RID: 17442
		' (get) Token: 0x0600B004 RID: 45060 RVA: 0x00051D89 File Offset: 0x0004FF89
		' (set) Token: 0x0600B005 RID: 45061 RVA: 0x00051D93 File Offset: 0x0004FF93
		Friend Overridable Property txtRsToWords As Label

		' Token: 0x17004423 RID: 17443
		' (get) Token: 0x0600B006 RID: 45062 RVA: 0x00051D9C File Offset: 0x0004FF9C
		' (set) Token: 0x0600B007 RID: 45063 RVA: 0x00755C28 File Offset: 0x00753E28
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

		' Token: 0x17004424 RID: 17444
		' (get) Token: 0x0600B008 RID: 45064 RVA: 0x00051DA6 File Offset: 0x0004FFA6
		' (set) Token: 0x0600B009 RID: 45065 RVA: 0x00051DB0 File Offset: 0x0004FFB0
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17004425 RID: 17445
		' (get) Token: 0x0600B00A RID: 45066 RVA: 0x00051DB9 File Offset: 0x0004FFB9
		' (set) Token: 0x0600B00B RID: 45067 RVA: 0x00051DC3 File Offset: 0x0004FFC3
		Friend Overridable Property F2 As TextBox

		' Token: 0x17004426 RID: 17446
		' (get) Token: 0x0600B00C RID: 45068 RVA: 0x00051DCC File Offset: 0x0004FFCC
		' (set) Token: 0x0600B00D RID: 45069 RVA: 0x00051DD6 File Offset: 0x0004FFD6
		Friend Overridable Property F1 As TextBox

		' Token: 0x17004427 RID: 17447
		' (get) Token: 0x0600B00E RID: 45070 RVA: 0x00051DDF File Offset: 0x0004FFDF
		' (set) Token: 0x0600B00F RID: 45071 RVA: 0x00755C6C File Offset: 0x00753E6C
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

		' Token: 0x17004428 RID: 17448
		' (get) Token: 0x0600B010 RID: 45072 RVA: 0x00051DE9 File Offset: 0x0004FFE9
		' (set) Token: 0x0600B011 RID: 45073 RVA: 0x00755CCC File Offset: 0x00753ECC
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

		' Token: 0x17004429 RID: 17449
		' (get) Token: 0x0600B012 RID: 45074 RVA: 0x00051DF3 File Offset: 0x0004FFF3
		' (set) Token: 0x0600B013 RID: 45075 RVA: 0x00051DFD File Offset: 0x0004FFFD
		Friend Overridable Property RichTextBox1 As RichTextBox

		' Token: 0x1700442A RID: 17450
		' (get) Token: 0x0600B014 RID: 45076 RVA: 0x00051E06 File Offset: 0x00050006
		' (set) Token: 0x0600B015 RID: 45077 RVA: 0x00051E10 File Offset: 0x00050010
		Friend Overridable Property txtTaxType As TextBox

		' Token: 0x1700442B RID: 17451
		' (get) Token: 0x0600B016 RID: 45078 RVA: 0x00051E19 File Offset: 0x00050019
		' (set) Token: 0x0600B017 RID: 45079 RVA: 0x00051E23 File Offset: 0x00050023
		Friend Overridable Property txtTaxableAmtI As TextBox

		' Token: 0x1700442C RID: 17452
		' (get) Token: 0x0600B018 RID: 45080 RVA: 0x00051E2C File Offset: 0x0005002C
		' (set) Token: 0x0600B019 RID: 45081 RVA: 0x00051E36 File Offset: 0x00050036
		Friend Overridable Property Label30 As Label

		' Token: 0x1700442D RID: 17453
		' (get) Token: 0x0600B01A RID: 45082 RVA: 0x00051E3F File Offset: 0x0005003F
		' (set) Token: 0x0600B01B RID: 45083 RVA: 0x00051E49 File Offset: 0x00050049
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x1700442E RID: 17454
		' (get) Token: 0x0600B01C RID: 45084 RVA: 0x00051E52 File Offset: 0x00050052
		' (set) Token: 0x0600B01D RID: 45085 RVA: 0x00051E5C File Offset: 0x0005005C
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x1700442F RID: 17455
		' (get) Token: 0x0600B01E RID: 45086 RVA: 0x00051E65 File Offset: 0x00050065
		' (set) Token: 0x0600B01F RID: 45087 RVA: 0x00051E6F File Offset: 0x0005006F
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x17004430 RID: 17456
		' (get) Token: 0x0600B020 RID: 45088 RVA: 0x00051E78 File Offset: 0x00050078
		' (set) Token: 0x0600B021 RID: 45089 RVA: 0x00051E82 File Offset: 0x00050082
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x17004431 RID: 17457
		' (get) Token: 0x0600B022 RID: 45090 RVA: 0x00051E8B File Offset: 0x0005008B
		' (set) Token: 0x0600B023 RID: 45091 RVA: 0x00051E95 File Offset: 0x00050095
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17004432 RID: 17458
		' (get) Token: 0x0600B024 RID: 45092 RVA: 0x00051E9E File Offset: 0x0005009E
		' (set) Token: 0x0600B025 RID: 45093 RVA: 0x00051EA8 File Offset: 0x000500A8
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x17004433 RID: 17459
		' (get) Token: 0x0600B026 RID: 45094 RVA: 0x00051EB1 File Offset: 0x000500B1
		' (set) Token: 0x0600B027 RID: 45095 RVA: 0x00051EBB File Offset: 0x000500BB
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x17004434 RID: 17460
		' (get) Token: 0x0600B028 RID: 45096 RVA: 0x00051EC4 File Offset: 0x000500C4
		' (set) Token: 0x0600B029 RID: 45097 RVA: 0x00051ECE File Offset: 0x000500CE
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x17004435 RID: 17461
		' (get) Token: 0x0600B02A RID: 45098 RVA: 0x00051ED7 File Offset: 0x000500D7
		' (set) Token: 0x0600B02B RID: 45099 RVA: 0x00051EE1 File Offset: 0x000500E1
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x17004436 RID: 17462
		' (get) Token: 0x0600B02C RID: 45100 RVA: 0x00051EEA File Offset: 0x000500EA
		' (set) Token: 0x0600B02D RID: 45101 RVA: 0x00051EF4 File Offset: 0x000500F4
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x17004437 RID: 17463
		' (get) Token: 0x0600B02E RID: 45102 RVA: 0x00051EFD File Offset: 0x000500FD
		' (set) Token: 0x0600B02F RID: 45103 RVA: 0x00051F07 File Offset: 0x00050107
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x17004438 RID: 17464
		' (get) Token: 0x0600B030 RID: 45104 RVA: 0x00051F10 File Offset: 0x00050110
		' (set) Token: 0x0600B031 RID: 45105 RVA: 0x00051F1A File Offset: 0x0005011A
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x17004439 RID: 17465
		' (get) Token: 0x0600B032 RID: 45106 RVA: 0x00051F23 File Offset: 0x00050123
		' (set) Token: 0x0600B033 RID: 45107 RVA: 0x00051F2D File Offset: 0x0005012D
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x1700443A RID: 17466
		' (get) Token: 0x0600B034 RID: 45108 RVA: 0x00051F36 File Offset: 0x00050136
		' (set) Token: 0x0600B035 RID: 45109 RVA: 0x00051F40 File Offset: 0x00050140
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x1700443B RID: 17467
		' (get) Token: 0x0600B036 RID: 45110 RVA: 0x00051F49 File Offset: 0x00050149
		' (set) Token: 0x0600B037 RID: 45111 RVA: 0x00051F53 File Offset: 0x00050153
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x1700443C RID: 17468
		' (get) Token: 0x0600B038 RID: 45112 RVA: 0x00051F5C File Offset: 0x0005015C
		' (set) Token: 0x0600B039 RID: 45113 RVA: 0x00051F66 File Offset: 0x00050166
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x1700443D RID: 17469
		' (get) Token: 0x0600B03A RID: 45114 RVA: 0x00051F6F File Offset: 0x0005016F
		' (set) Token: 0x0600B03B RID: 45115 RVA: 0x00051F79 File Offset: 0x00050179
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x1700443E RID: 17470
		' (get) Token: 0x0600B03C RID: 45116 RVA: 0x00051F82 File Offset: 0x00050182
		' (set) Token: 0x0600B03D RID: 45117 RVA: 0x00051F8C File Offset: 0x0005018C
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x1700443F RID: 17471
		' (get) Token: 0x0600B03E RID: 45118 RVA: 0x00051F95 File Offset: 0x00050195
		' (set) Token: 0x0600B03F RID: 45119 RVA: 0x00051F9F File Offset: 0x0005019F
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x17004440 RID: 17472
		' (get) Token: 0x0600B040 RID: 45120 RVA: 0x00051FA8 File Offset: 0x000501A8
		' (set) Token: 0x0600B041 RID: 45121 RVA: 0x00051FB2 File Offset: 0x000501B2
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17004441 RID: 17473
		' (get) Token: 0x0600B042 RID: 45122 RVA: 0x00051FBB File Offset: 0x000501BB
		' (set) Token: 0x0600B043 RID: 45123 RVA: 0x00051FC5 File Offset: 0x000501C5
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17004442 RID: 17474
		' (get) Token: 0x0600B044 RID: 45124 RVA: 0x00051FCE File Offset: 0x000501CE
		' (set) Token: 0x0600B045 RID: 45125 RVA: 0x00051FD8 File Offset: 0x000501D8
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17004443 RID: 17475
		' (get) Token: 0x0600B046 RID: 45126 RVA: 0x00051FE1 File Offset: 0x000501E1
		' (set) Token: 0x0600B047 RID: 45127 RVA: 0x00051FEB File Offset: 0x000501EB
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17004444 RID: 17476
		' (get) Token: 0x0600B048 RID: 45128 RVA: 0x00051FF4 File Offset: 0x000501F4
		' (set) Token: 0x0600B049 RID: 45129 RVA: 0x00051FFE File Offset: 0x000501FE
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17004445 RID: 17477
		' (get) Token: 0x0600B04A RID: 45130 RVA: 0x00052007 File Offset: 0x00050207
		' (set) Token: 0x0600B04B RID: 45131 RVA: 0x00052011 File Offset: 0x00050211
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17004446 RID: 17478
		' (get) Token: 0x0600B04C RID: 45132 RVA: 0x0005201A File Offset: 0x0005021A
		' (set) Token: 0x0600B04D RID: 45133 RVA: 0x00052024 File Offset: 0x00050224
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004447 RID: 17479
		' (get) Token: 0x0600B04E RID: 45134 RVA: 0x0005202D File Offset: 0x0005022D
		' (set) Token: 0x0600B04F RID: 45135 RVA: 0x00052037 File Offset: 0x00050237
		Friend Overridable Property dgw As DataGridView

		' Token: 0x17004448 RID: 17480
		' (get) Token: 0x0600B050 RID: 45136 RVA: 0x00052040 File Offset: 0x00050240
		' (set) Token: 0x0600B051 RID: 45137 RVA: 0x0005204A File Offset: 0x0005024A
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x17004449 RID: 17481
		' (get) Token: 0x0600B052 RID: 45138 RVA: 0x00052053 File Offset: 0x00050253
		' (set) Token: 0x0600B053 RID: 45139 RVA: 0x00755D10 File Offset: 0x00753F10
		Private _CheckBox13 As CheckBox
		Friend Overridable Property CheckBox13 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox13
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox13_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox13
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox13 = value
				checkBox = Me._CheckBox13
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700444A RID: 17482
		' (get) Token: 0x0600B054 RID: 45140 RVA: 0x0005205D File Offset: 0x0005025D
		' (set) Token: 0x0600B055 RID: 45141 RVA: 0x00052067 File Offset: 0x00050267
		Friend Overridable Property lblCPhone As Label

		' Token: 0x1700444B RID: 17483
		' (get) Token: 0x0600B056 RID: 45142 RVA: 0x00052070 File Offset: 0x00050270
		' (set) Token: 0x0600B057 RID: 45143 RVA: 0x0005207A File Offset: 0x0005027A
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x1700444C RID: 17484
		' (get) Token: 0x0600B058 RID: 45144 RVA: 0x00052083 File Offset: 0x00050283
		' (set) Token: 0x0600B059 RID: 45145 RVA: 0x0005208D File Offset: 0x0005028D
		Friend Overridable Property NumericUpDown1 As NumericUpDown

		' Token: 0x1700444D RID: 17485
		' (get) Token: 0x0600B05A RID: 45146 RVA: 0x00052096 File Offset: 0x00050296
		' (set) Token: 0x0600B05B RID: 45147 RVA: 0x000520A0 File Offset: 0x000502A0
		Friend Overridable Property dgwsale As DataGridView

		' Token: 0x1700444E RID: 17486
		' (get) Token: 0x0600B05C RID: 45148 RVA: 0x000520A9 File Offset: 0x000502A9
		' (set) Token: 0x0600B05D RID: 45149 RVA: 0x000520B3 File Offset: 0x000502B3
		Friend Overridable Property DataGridViewTextBoxColumn41 As DataGridViewTextBoxColumn

		' Token: 0x1700444F RID: 17487
		' (get) Token: 0x0600B05E RID: 45150 RVA: 0x000520BC File Offset: 0x000502BC
		' (set) Token: 0x0600B05F RID: 45151 RVA: 0x000520C6 File Offset: 0x000502C6
		Friend Overridable Property DataGridViewTextBoxColumn42 As DataGridViewTextBoxColumn

		' Token: 0x17004450 RID: 17488
		' (get) Token: 0x0600B060 RID: 45152 RVA: 0x000520CF File Offset: 0x000502CF
		' (set) Token: 0x0600B061 RID: 45153 RVA: 0x000520D9 File Offset: 0x000502D9
		Friend Overridable Property DataGridViewTextBoxColumn43 As DataGridViewTextBoxColumn

		' Token: 0x17004451 RID: 17489
		' (get) Token: 0x0600B062 RID: 45154 RVA: 0x000520E2 File Offset: 0x000502E2
		' (set) Token: 0x0600B063 RID: 45155 RVA: 0x000520EC File Offset: 0x000502EC
		Friend Overridable Property DataGridViewTextBoxColumn44 As DataGridViewTextBoxColumn

		' Token: 0x17004452 RID: 17490
		' (get) Token: 0x0600B064 RID: 45156 RVA: 0x000520F5 File Offset: 0x000502F5
		' (set) Token: 0x0600B065 RID: 45157 RVA: 0x00755D54 File Offset: 0x00753F54
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
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

		' Token: 0x17004453 RID: 17491
		' (get) Token: 0x0600B066 RID: 45158 RVA: 0x000520FF File Offset: 0x000502FF
		' (set) Token: 0x0600B067 RID: 45159 RVA: 0x00755D98 File Offset: 0x00753F98
		Private _btnPrint As GelButton
		Friend Overridable Property btnPrint As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnPrint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnPrint_Click
				Dim gelButton As GelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnPrint = value
				gelButton = Me._btnPrint
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004454 RID: 17492
		' (get) Token: 0x0600B068 RID: 45160 RVA: 0x00052109 File Offset: 0x00050309
		' (set) Token: 0x0600B069 RID: 45161 RVA: 0x00755DDC File Offset: 0x00753FDC
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

		' Token: 0x17004455 RID: 17493
		' (get) Token: 0x0600B06A RID: 45162 RVA: 0x00052113 File Offset: 0x00050313
		' (set) Token: 0x0600B06B RID: 45163 RVA: 0x00755E20 File Offset: 0x00754020
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

		' Token: 0x17004456 RID: 17494
		' (get) Token: 0x0600B06C RID: 45164 RVA: 0x0005211D File Offset: 0x0005031D
		' (set) Token: 0x0600B06D RID: 45165 RVA: 0x00755E64 File Offset: 0x00754064
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

		' Token: 0x17004457 RID: 17495
		' (get) Token: 0x0600B06E RID: 45166 RVA: 0x00052127 File Offset: 0x00050327
		' (set) Token: 0x0600B06F RID: 45167 RVA: 0x00755EA8 File Offset: 0x007540A8
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

		' Token: 0x17004458 RID: 17496
		' (get) Token: 0x0600B070 RID: 45168 RVA: 0x00052131 File Offset: 0x00050331
		' (set) Token: 0x0600B071 RID: 45169 RVA: 0x0005213B File Offset: 0x0005033B
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004459 RID: 17497
		' (get) Token: 0x0600B072 RID: 45170 RVA: 0x00052144 File Offset: 0x00050344
		' (set) Token: 0x0600B073 RID: 45171 RVA: 0x0005214E File Offset: 0x0005034E
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700445A RID: 17498
		' (get) Token: 0x0600B074 RID: 45172 RVA: 0x00052157 File Offset: 0x00050357
		' (set) Token: 0x0600B075 RID: 45173 RVA: 0x00052161 File Offset: 0x00050361
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x1700445B RID: 17499
		' (get) Token: 0x0600B076 RID: 45174 RVA: 0x0005216A File Offset: 0x0005036A
		' (set) Token: 0x0600B077 RID: 45175 RVA: 0x00052174 File Offset: 0x00050374
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x1700445C RID: 17500
		' (get) Token: 0x0600B078 RID: 45176 RVA: 0x0005217D File Offset: 0x0005037D
		' (set) Token: 0x0600B079 RID: 45177 RVA: 0x00052187 File Offset: 0x00050387
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700445D RID: 17501
		' (get) Token: 0x0600B07A RID: 45178 RVA: 0x00052190 File Offset: 0x00050390
		' (set) Token: 0x0600B07B RID: 45179 RVA: 0x0005219A File Offset: 0x0005039A
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700445E RID: 17502
		' (get) Token: 0x0600B07C RID: 45180 RVA: 0x000521A3 File Offset: 0x000503A3
		' (set) Token: 0x0600B07D RID: 45181 RVA: 0x000521AD File Offset: 0x000503AD
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700445F RID: 17503
		' (get) Token: 0x0600B07E RID: 45182 RVA: 0x000521B6 File Offset: 0x000503B6
		' (set) Token: 0x0600B07F RID: 45183 RVA: 0x000521C0 File Offset: 0x000503C0
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17004460 RID: 17504
		' (get) Token: 0x0600B080 RID: 45184 RVA: 0x000521C9 File Offset: 0x000503C9
		' (set) Token: 0x0600B081 RID: 45185 RVA: 0x000521D3 File Offset: 0x000503D3
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004461 RID: 17505
		' (get) Token: 0x0600B082 RID: 45186 RVA: 0x000521DC File Offset: 0x000503DC
		' (set) Token: 0x0600B083 RID: 45187 RVA: 0x000521E6 File Offset: 0x000503E6
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004462 RID: 17506
		' (get) Token: 0x0600B084 RID: 45188 RVA: 0x000521EF File Offset: 0x000503EF
		' (set) Token: 0x0600B085 RID: 45189 RVA: 0x000521F9 File Offset: 0x000503F9
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004463 RID: 17507
		' (get) Token: 0x0600B086 RID: 45190 RVA: 0x00052202 File Offset: 0x00050402
		' (set) Token: 0x0600B087 RID: 45191 RVA: 0x0005220C File Offset: 0x0005040C
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004464 RID: 17508
		' (get) Token: 0x0600B088 RID: 45192 RVA: 0x00052215 File Offset: 0x00050415
		' (set) Token: 0x0600B089 RID: 45193 RVA: 0x0005221F File Offset: 0x0005041F
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004465 RID: 17509
		' (get) Token: 0x0600B08A RID: 45194 RVA: 0x00052228 File Offset: 0x00050428
		' (set) Token: 0x0600B08B RID: 45195 RVA: 0x00052232 File Offset: 0x00050432
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004466 RID: 17510
		' (get) Token: 0x0600B08C RID: 45196 RVA: 0x0005223B File Offset: 0x0005043B
		' (set) Token: 0x0600B08D RID: 45197 RVA: 0x00052245 File Offset: 0x00050445
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004467 RID: 17511
		' (get) Token: 0x0600B08E RID: 45198 RVA: 0x0005224E File Offset: 0x0005044E
		' (set) Token: 0x0600B08F RID: 45199 RVA: 0x00052258 File Offset: 0x00050458
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004468 RID: 17512
		' (get) Token: 0x0600B090 RID: 45200 RVA: 0x00052261 File Offset: 0x00050461
		' (set) Token: 0x0600B091 RID: 45201 RVA: 0x0005226B File Offset: 0x0005046B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004469 RID: 17513
		' (get) Token: 0x0600B092 RID: 45202 RVA: 0x00052274 File Offset: 0x00050474
		' (set) Token: 0x0600B093 RID: 45203 RVA: 0x0005227E File Offset: 0x0005047E
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x1700446A RID: 17514
		' (get) Token: 0x0600B094 RID: 45204 RVA: 0x00052287 File Offset: 0x00050487
		' (set) Token: 0x0600B095 RID: 45205 RVA: 0x00052291 File Offset: 0x00050491
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x1700446B RID: 17515
		' (get) Token: 0x0600B096 RID: 45206 RVA: 0x0005229A File Offset: 0x0005049A
		' (set) Token: 0x0600B097 RID: 45207 RVA: 0x000522A4 File Offset: 0x000504A4
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x1700446C RID: 17516
		' (get) Token: 0x0600B098 RID: 45208 RVA: 0x000522AD File Offset: 0x000504AD
		' (set) Token: 0x0600B099 RID: 45209 RVA: 0x000522B7 File Offset: 0x000504B7
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x1700446D RID: 17517
		' (get) Token: 0x0600B09A RID: 45210 RVA: 0x000522C0 File Offset: 0x000504C0
		' (set) Token: 0x0600B09B RID: 45211 RVA: 0x000522CA File Offset: 0x000504CA
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x1700446E RID: 17518
		' (get) Token: 0x0600B09C RID: 45212 RVA: 0x000522D3 File Offset: 0x000504D3
		' (set) Token: 0x0600B09D RID: 45213 RVA: 0x000522DD File Offset: 0x000504DD
		Friend Overridable Property Column29 As DataGridViewImageColumn

		' Token: 0x1700446F RID: 17519
		' (get) Token: 0x0600B09E RID: 45214 RVA: 0x000522E6 File Offset: 0x000504E6
		' (set) Token: 0x0600B09F RID: 45215 RVA: 0x00755EEC File Offset: 0x007540EC
		Private _Picimage As PictureBox
		Friend Overridable Property Picimage As PictureBox
			<CompilerGenerated()>
			Get
				Return Me._Picimage
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Dim eventHandler As EventHandler = AddressOf Me.PictureBox3_Click
				Dim pictureBox As PictureBox = Me._Picimage
				If pictureBox IsNot Nothing Then
					RemoveHandler pictureBox.Click, eventHandler
				End If
				Me._Picimage = value
				pictureBox = Me._Picimage
				If pictureBox IsNot Nothing Then
					AddHandler pictureBox.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004470 RID: 17520
		' (get) Token: 0x0600B0A0 RID: 45216 RVA: 0x000522F0 File Offset: 0x000504F0
		' (set) Token: 0x0600B0A1 RID: 45217 RVA: 0x00755F30 File Offset: 0x00754130
		Private _GridGetCustomer As DataGridView
		Friend Overridable Property GridGetCustomer As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._GridGetCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.GridGetCustomer_KeyDown
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.GridGetCustomer_CellContentClick
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.GridGetCustomer_EditingControlShowing
				Dim dataGridView As DataGridView = Me._GridGetCustomer
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
				Me._GridGetCustomer = value
				dataGridView = Me._GridGetCustomer
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004471 RID: 17521
		' (get) Token: 0x0600B0A2 RID: 45218 RVA: 0x000522FA File Offset: 0x000504FA
		' (set) Token: 0x0600B0A3 RID: 45219 RVA: 0x00052304 File Offset: 0x00050504
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17004472 RID: 17522
		' (get) Token: 0x0600B0A4 RID: 45220 RVA: 0x0005230D File Offset: 0x0005050D
		' (set) Token: 0x0600B0A5 RID: 45221 RVA: 0x00052317 File Offset: 0x00050517
		Public Overridable Property Picture As PictureBox

		' Token: 0x17004473 RID: 17523
		' (get) Token: 0x0600B0A6 RID: 45222 RVA: 0x00052320 File Offset: 0x00050520
		' (set) Token: 0x0600B0A7 RID: 45223 RVA: 0x0005232A File Offset: 0x0005052A
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x17004474 RID: 17524
		' (get) Token: 0x0600B0A8 RID: 45224 RVA: 0x00052333 File Offset: 0x00050533
		' (set) Token: 0x0600B0A9 RID: 45225 RVA: 0x0005233D File Offset: 0x0005053D
		Friend Overridable Property CustomerID As DataGridViewTextBoxColumn

		' Token: 0x17004475 RID: 17525
		' (get) Token: 0x0600B0AA RID: 45226 RVA: 0x00052346 File Offset: 0x00050546
		' (set) Token: 0x0600B0AB RID: 45227 RVA: 0x00052350 File Offset: 0x00050550
		Friend Overridable Property contactNo As DataGridViewTextBoxColumn

		' Token: 0x17004476 RID: 17526
		' (get) Token: 0x0600B0AC RID: 45228 RVA: 0x00052359 File Offset: 0x00050559
		' (set) Token: 0x0600B0AD RID: 45229 RVA: 0x00052363 File Offset: 0x00050563
		Friend Overridable Property state As DataGridViewComboBoxColumn

		' Token: 0x17004477 RID: 17527
		' (get) Token: 0x0600B0AE RID: 45230 RVA: 0x0005236C File Offset: 0x0005056C
		' (set) Token: 0x0600B0AF RID: 45231 RVA: 0x00052376 File Offset: 0x00050576
		Friend Overridable Property GSTIN As DataGridViewTextBoxColumn

		' Token: 0x17004478 RID: 17528
		' (get) Token: 0x0600B0B0 RID: 45232 RVA: 0x0005237F File Offset: 0x0005057F
		' (set) Token: 0x0600B0B1 RID: 45233 RVA: 0x00052389 File Offset: 0x00050589
		Friend Overridable Property customerName As DataGridViewTextBoxColumn

		' Token: 0x17004479 RID: 17529
		' (get) Token: 0x0600B0B2 RID: 45234 RVA: 0x00052392 File Offset: 0x00050592
		' (set) Token: 0x0600B0B3 RID: 45235 RVA: 0x0005239C File Offset: 0x0005059C
		Friend Overridable Property Column60 As DataGridViewTextBoxColumn

		' Token: 0x1700447A RID: 17530
		' (get) Token: 0x0600B0B4 RID: 45236 RVA: 0x000523A5 File Offset: 0x000505A5
		' (set) Token: 0x0600B0B5 RID: 45237 RVA: 0x000523AF File Offset: 0x000505AF
		Friend Overridable Property Column61 As DataGridViewTextBoxColumn

		' Token: 0x1700447B RID: 17531
		' (get) Token: 0x0600B0B6 RID: 45238 RVA: 0x000523B8 File Offset: 0x000505B8
		' (set) Token: 0x0600B0B7 RID: 45239 RVA: 0x000523C2 File Offset: 0x000505C2
		Friend Overridable Property Column62 As DataGridViewTextBoxColumn

		' Token: 0x1700447C RID: 17532
		' (get) Token: 0x0600B0B8 RID: 45240 RVA: 0x000523CB File Offset: 0x000505CB
		' (set) Token: 0x0600B0B9 RID: 45241 RVA: 0x000523D5 File Offset: 0x000505D5
		Friend Overridable Property Column63 As DataGridViewTextBoxColumn

		' Token: 0x1700447D RID: 17533
		' (get) Token: 0x0600B0BA RID: 45242 RVA: 0x000523DE File Offset: 0x000505DE
		' (set) Token: 0x0600B0BB RID: 45243 RVA: 0x000523E8 File Offset: 0x000505E8
		Friend Overridable Property Column64 As DataGridViewTextBoxColumn

		' Token: 0x1700447E RID: 17534
		' (get) Token: 0x0600B0BC RID: 45244 RVA: 0x000523F1 File Offset: 0x000505F1
		' (set) Token: 0x0600B0BD RID: 45245 RVA: 0x000523FB File Offset: 0x000505FB
		Friend Overridable Property custbtnSave As DataGridViewButtonColumn

		' Token: 0x1700447F RID: 17535
		' (get) Token: 0x0600B0BE RID: 45246 RVA: 0x00052404 File Offset: 0x00050604
		' (set) Token: 0x0600B0BF RID: 45247 RVA: 0x0005240E File Offset: 0x0005060E
		Friend Overridable Property lblLead_Id As Label

		' Token: 0x0600B0C0 RID: 45248 RVA: 0x00755FAC File Offset: 0x007541AC
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

		' Token: 0x0600B0C1 RID: 45249 RVA: 0x007560B0 File Offset: 0x007542B0
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(State),RTRIM(FYFrom),RTRIM(FYTo),RTRIM(Bankholder),RTRIM(Bankacno),RTRIM(Bankname),RTRIM(Bankifsc),RTRIM(CompanyName),RTRIM(Address),RTRIM(ContactNo),RTRIM(EmailID),RTRIM(GSTIN) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompanyState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
					Me.RichTextBox1.Text = If(String.Concat(New String() { "Bank Holder Name : ", ModCommonClasses.rdr.GetValue(3).ToString(), vbCrLf & "Bank A/c No : ", ModCommonClasses.rdr.GetValue(4).ToString(), vbCrLf & "Bank Name & Branch : ", ModCommonClasses.rdr.GetValue(5).ToString(), vbCrLf & "IFSC : ", ModCommonClasses.rdr.GetValue(6).ToString() }), "")
					Me.strcompany = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.Company1 = Me.strcompany
					Me.Address1 = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.Contact1 = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.Email1 = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.Gstin1 = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.strbankac = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.strbankifsc = ModCommonClasses.rdr.GetValue(6).ToString()
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

		' Token: 0x0600B0C2 RID: 45250 RVA: 0x00756364 File Offset: 0x00754564
		Public Sub Reset()
			Me.RadioButton1.Checked = True
			Me.RadioButton1.Enabled = True
			Me.RadioButton2.Enabled = True
			Me.txtCID.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.cmbCustomerName.SelectedIndex = -1
			Me.txtContactNo.Text = ""
			Me.txtGSTIN.Text = ""
			Me.txtCustomerState.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnRemove.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnPrint.Enabled = False
			Me.txtContactNo.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.auto()
			Me.lblSet.Text = "Allowed"
			Me.DataGridView1.Rows.Clear()
			Me.GetCompanyState()
			Me.btnCustomerSelection.Enabled = True
			Me.txtCustomerID.Text = ""
			Me.txtSubTotal.Text = "0.00"
			Me.txtCGST.Text = "0.00"
			Me.txtSGST.Text = "0.00"
			Me.txtCESS.Text = "0.00"
			Me.txtIGST.Text = "0.00"
			Me.txtTotal.Text = "0.00"
			Me.txtRoundOff.Text = "0.00"
			Me.txtGrandTotal.Text = "0.00"
			Me.Clear()
			Me.dtpQuotationDate.Focus()
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.txtDiscAmtPerQty.Enabled = False
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
			Me.cmbNP.SelectedIndex = -1
			Me.NumericUpDown1.Value = Conversions.ToDecimal("30")
			Me.customerdetailenable()
			Me.GridGetCustomer.Visible = False
			Me.GetDefaultCustomer()
		End Sub

		' Token: 0x0600B0C3 RID: 45251 RVA: 0x00756648 File Offset: 0x00754848
		Public Sub GetDefaultCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT ID, CustomerID,RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),RTRIM(Name),RTRIM(EmailID),RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status) from Customer where CustomerID='C-0001'  order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Dim text2 As String = ModCommonClasses.rdr.GetValue(1).ToString().Trim()
					Me.txtCustomerID.Text = text2
					Me.txtContactNo.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.txtCustomerState.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
					Me.txtGSTIN.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(4))
					Me.cmbCustomerName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(5))
				End If
				ModCommonClasses.con.Close()
				Me.GridGetCustomer.Visible = False
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B0C4 RID: 45252 RVA: 0x007567AC File Offset: 0x007549AC
		Public Function SubTotal() As Double
			Dim num As Double = 0.0
			Try
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
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

		' Token: 0x0600B0C5 RID: 45253 RVA: 0x0075686C File Offset: 0x00754A6C
		Public Sub Compute()
			Me.GridCalc()
			Me.num1 = Conversion.Val(Me.txtSubTotal.Text) + Conversion.Val(Me.txtCGST.Text) + Conversion.Val(Me.txtSGST.Text) + Conversion.Val(Me.txtIGST.Text) + Conversion.Val(Me.txtCESS.Text)
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
		End Sub

		' Token: 0x0600B0C6 RID: 45254 RVA: 0x007569C8 File Offset: 0x00754BC8
		Public Sub GridCalc()
			Dim num As Double = 0.0
			Dim num2 As Double = 0.0
			Dim num3 As Double = 0.0
			Dim num4 As Double = 0.0
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(9).Value))
					num2 = Conversions.ToDouble(Operators.AddObject(num2, dataGridViewRow.Cells(11).Value))
					num3 = Conversions.ToDouble(Operators.AddObject(num3, dataGridViewRow.Cells(13).Value))
					num4 = Conversions.ToDouble(Operators.AddObject(num4, dataGridViewRow.Cells(15).Value))
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

		' Token: 0x0600B0C7 RID: 45255 RVA: 0x00756B58 File Offset: 0x00754D58
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrQuotation ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600B0C8 RID: 45256 RVA: 0x00756CC4 File Offset: 0x00754EC4
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 Q_ID FROM Quotation order BY Q_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("Q_ID"))
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

		' Token: 0x0600B0C9 RID: 45257 RVA: 0x00756E30 File Offset: 0x00755030
		Private Sub Invoicecode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(c4),RTRIM(c14) from Invcode"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtInvCode1.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSuffix.Text = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.txtInvCode1.Text = "Q"
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
					Me.txtInvCode1.Text = "Q"
				End If
				Dim flag5 As Boolean = Operators.CompareString(Me.txtSuffix.Text, "", False) = 0
				If flag5 Then
					Me.txtSuffix.Text = Me.F1.Text + "/" + Me.F2.Text
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0CA RID: 45258 RVA: 0x00757008 File Offset: 0x00755208
		Public Sub auto()
			Try
				Me.txtQ_ID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtQuotationNo.Text = String.Concat(New String() { Me.txtInvCode1.Text, "-", Me.GenerateIDSr(), "-", Me.txtSuffix.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0CB RID: 45259 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600B0CC RID: 45260 RVA: 0x00052417 File Offset: 0x00050617
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductRecord.lblSet.Text = "Quotation"
			MyProject.Forms.frmProductRecord.Reset()
			MyProject.Forms.frmProductRecord.ShowDialog()
		End Sub

		' Token: 0x0600B0CD RID: 45261 RVA: 0x007570B8 File Offset: 0x007552B8
		Private Sub qrcodeupi()
			Try
				Dim bank As Bank = New Bank()
				bank.AccountNo = Me.strbankac
				bank.IfscCode = Me.strbankifsc
				bank.PayeeName = Me.strcompany
				Try
					bank.Amount = New Double?(Double.Parse(Me.txtGrandTotal.Text))
				Catch ex As Exception
					bank.Amount = Nothing
				End Try
				bank.TxnNote = Me.txtQuotationNo.Text
				Dim bitmap As Bitmap = UPI.Generate(bank)
				Me.PictureBox1.Image = bitmap
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0CE RID: 45262 RVA: 0x007571A0 File Offset: 0x007553A0
		Public Sub Print()
			Me.qrcodeupi()
			Dim flag As Boolean = Me.PictureBox1.Image IsNot Nothing
			If flag Then
				Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
				Dim flag2 As Boolean = Not Directory.Exists("C:\Temp")
				If flag2 Then
					Directory.CreateDirectory("C:\Temp")
				End If
				bitmap.Save(Path.Combine(New String() { "C:\Temp\QRImage.jpg" }), ImageFormat.Jpeg)
				bitmap.Dispose()
			End If
			Dim flag3 As Boolean = Me.PictureBox2.Image IsNot Nothing
			If flag3 Then
				Dim bitmap2 As Bitmap = New Bitmap(Me.PictureBox2.Image)
				Dim flag4 As Boolean = Not Directory.Exists("C:\Temp")
				If flag4 Then
					Directory.CreateDirectory("C:\Temp")
				End If
				bitmap2.Save(Path.Combine(New String() { "C:\Temp\Company.jpg" }), ImageFormat.Jpeg)
				bitmap2.Dispose()
			End If
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("PID")
				dataTable2.Columns.Add("HSNC")
				dataTable2.Columns.Add("ProductName")
				dataTable2.Columns.Add("Barcode")
				dataTable2.Columns.Add("MainQty")
				dataTable2.Columns.Add("Rate")
				dataTable2.Columns.Add("DiscPer")
				dataTable2.Columns.Add("Disc")
				dataTable2.Columns.Add("CGSTPer")
				dataTable2.Columns.Add("CGST")
				dataTable2.Columns.Add("SGSTPer")
				dataTable2.Columns.Add("SGST")
				dataTable2.Columns.Add("IGSTPer")
				dataTable2.Columns.Add("IGST")
				dataTable2.Columns.Add("CESSPer")
				dataTable2.Columns.Add("CESS")
				dataTable2.Columns.Add("Total")
				dataTable2.Columns.Add("AltQty")
				dataTable2.Columns.Add("AltUnit")
				dataTable2.Columns.Add("TaxableAmt")
				dataTable2.Columns.Add("MainUnit")
				dataTable2.Columns.Add("PImage")
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value, dataGridViewRow.Cells(10).Value, dataGridViewRow.Cells(11).Value, dataGridViewRow.Cells(12).Value, dataGridViewRow.Cells(13).Value, dataGridViewRow.Cells(14).Value, dataGridViewRow.Cells(15).Value, dataGridViewRow.Cells(16).Value, dataGridViewRow.Cells(17).Value, dataGridViewRow.Cells(18).Value, dataGridViewRow.Cells(20).Value, dataGridViewRow.Cells(21).Value, dataGridViewRow.Cells(22).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim text As String = ""
				Dim num As Integer = dataTable.Rows.Count - 1
				For i As Integer = 0 To num
					text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows(i)(0), ","))
				Next
				text = text.Remove(text.Length - 1)
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				Dim text2 As String = "SELECT PID as PID,RTRIM(p.HSNCode) as HSNC,RTRIM(Productname) as ProductName,RTRIM(Quotation_Join.Barcode) as Barcode,Quotation_Join.Qty as MainQty, Quotation_Join.Price as Rate,Quotation_Join.DiscountPer as DiscPer,Quotation_Join.DiscountAmt as Disc,Quotation_Join. CGSTPer as CGSTPer, Quotation_Join.CGSTAmt as CGST,Quotation_Join. SGSTPer AS SGSTPer,Quotation_Join. SGSTAmt AS SGST,Quotation_Join. IGSTPer AS IGSTPer,Quotation_Join. IGSTAmt AS IGST,Quotation_Join. CESSPer AS CESSPer,Quotation_Join.CESSAmt AS CESS,Quotation_Join.TotalAmount AS Total,Quotation_Join.AltQty AS AltQty,RTRIM(Quotation_Join.AltUnit) AS AltUnit,RTRIM(Quotation_Join.STaxType),Quotation_Join.TaxableAmt AS TaxableAmt,RTRIM(Quotation_Join.MainUnit) AS MainUnit,Photo as PImage" & vbCrLf & "from quotation,Quotation_Join,Product as p,Product_Join as j" & vbCrLf & "where quotation.Q_ID=Quotation_Join.QuotationID and p.PID=Quotation_Join.ProductID and j.ProductID=p.PID and quotation.QuotationNo='" + Me.txtQuotationNo.Text + "'"
				sqlCommand.CommandText = text2
				sqlCommand.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				dataSet.Tables.Add(dataTable)
				sqlDataAdapter.Fill(dataSet, "DataTable3")
				Dim reportDocument As ReportDocument = New ReportDocument()
				reportDocument.Load(Application.StartupPath + "\CryReport\rptQuotation1.rpt")
				reportDocument.SetDataSource(dataSet)
				reportDocument.SetParameterValue("P1", Me.txtSubTotal.Text)
				reportDocument.SetParameterValue("CGST", Me.txtCGST.Text)
				reportDocument.SetParameterValue("SGST", Me.txtSGST.Text)
				reportDocument.SetParameterValue("IGST", Me.txtIGST.Text)
				reportDocument.SetParameterValue("CESS", Me.txtCESS.Text)
				reportDocument.SetParameterValue("TOTAL", Me.txtTotal.Text)
				reportDocument.SetParameterValue("Roff", Me.txtRoundOff.Text)
				reportDocument.SetParameterValue("Net", Me.txtGrandTotal.Text)
				reportDocument.SetParameterValue("P2", Me.RichTextBox1.Text)
				reportDocument.SetParameterValue("Company", Me.Company1)
				reportDocument.SetParameterValue("State", Me.txtCompanyState.Text)
				reportDocument.SetParameterValue("Address", Me.Address1)
				reportDocument.SetParameterValue("Contact", Me.Contact1)
				reportDocument.SetParameterValue("Email", Me.Email1)
				reportDocument.SetParameterValue("Gstin", Me.Gstin1)
				reportDocument.SetParameterValue("QN", Me.txtQuotationNo.Text)
				reportDocument.SetParameterValue("QDate", Me.dtpQuotationDate.Text)
				reportDocument.SetParameterValue("CName", Me.cmbCustomerName.Text)
				reportDocument.SetParameterValue("CAddress", Me.caddress)
				reportDocument.SetParameterValue("CState", Me.txtCustomerState.Text)
				reportDocument.SetParameterValue("CContact", Me.txtContactNo.Text)
				reportDocument.SetParameterValue("CGstin", Me.txtGSTIN.Text)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0CF RID: 45263 RVA: 0x00757A50 File Offset: 0x00755C50
		Private Sub btnAdd_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Me.cmbProductName.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox5.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.TextBox5.Text, Me.cmbProductName.Text, False) <> 0
							If flag4 Then
								MessageBox.Show("Please retrieve correct product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.TextBox5.Focus()
							Else
								Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtPricePerQty.Text)) = 0
								If flag5 Then
									MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPricePerQty.Focus()
								Else
									Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscPer.Text)) = 0
									If flag6 Then
										MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtDiscPer.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
										If flag7 Then
											MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtQty.Focus()
										Else
											Dim flag8 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
											If flag8 Then
												MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtQty.Focus()
											Else
												Me.RadioButton1.Enabled = False
												Me.RadioButton2.Enabled = False
												Me.alt()
												Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
												Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
												Dim flag9 As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
												If flag9 Then
													MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.cmbUnit.Text = Me.TextBox4.Text
													Me.cmbUnit.Focus()
												Else
													ModCommonClasses.con.Open()
													ModCommonClasses.cmd = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
													MyProject.Forms.frmProduct.dgw.Rows.Clear()
													While ModCommonClasses.rdr.Read()
														Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
														Dim memoryStream As MemoryStream = New MemoryStream(array)
														Dim image As Image = Image.FromStream(memoryStream)
														Me.Picimage.Image = image
													End While
													ModCommonClasses.con.Close()
													Try
														For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
															Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
															Dim flag10 As Boolean = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(0).Value, Me.txtProductID.Text, False), Operators.CompareObjectEqual(dataGridViewRow.Cells(3).Value, Me.txtBarcode.Text, False)))
															If flag10 Then
																dataGridViewRow.Cells(0).Value = Me.txtProductID.Text
																dataGridViewRow.Cells(1).Value = Me.txtHSNCode.Text
																dataGridViewRow.Cells(2).Value = Me.cmbProductName.Text
																dataGridViewRow.Cells(3).Value = Me.txtBarcode.Text
																dataGridViewRow.Cells(4).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)) + Conversion.Val(Me.TextBox2.Text)
																dataGridViewRow.Cells(5).Value = Conversion.Val(Me.txtPricePerQty.Text)
																dataGridViewRow.Cells(6).Value = Conversion.Val(Me.txtDiscPer.Text)
																dataGridViewRow.Cells(7).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value)) + Conversion.Val(Me.txtDisc.Text)
																dataGridViewRow.Cells(8).Value = Me.txtCGSTPer.Text
																dataGridViewRow.Cells(9).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(Me.txtCGSTAmt.Text)
																dataGridViewRow.Cells(10).Value = Me.txtSGSTPer.Text
																dataGridViewRow.Cells(11).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)) + Conversion.Val(Me.txtSGSTAmt.Text)
																dataGridViewRow.Cells(12).Value = Me.txtIGSTPer.Text
																dataGridViewRow.Cells(13).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)) + Conversion.Val(Me.txtIGSTAmt.Text)
																dataGridViewRow.Cells(14).Value = Me.txtCESSPer.Text
																dataGridViewRow.Cells(15).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value)) + Conversion.Val(Me.txtCESSAmt.Text)
																dataGridViewRow.Cells(16).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)) + Conversion.Val(Me.txtTotalAmount.Text)
																dataGridViewRow.Cells(17).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value)) * Conversion.Val(Me.lblAltValue.Text)
																dataGridViewRow.Cells(18).Value = Me.lblAltUnit.Text
																dataGridViewRow.Cells(19).Value = Me.txtTaxType.Text
																dataGridViewRow.Cells(20).Value = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)) + Conversion.Val(Me.txtTaxableAmtI.Text)
																Dim num As Double = Me.SubTotal()
																num = Conversions.ToDouble(Strings.Format(Math.Round(num, 2), "0.00"))
																Me.txtSubTotal.Text = Conversions.ToString(num)
																Me.Compute()
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
													Me.DataGridView1.Rows.Add(New Object() { Me.txtProductID.Text, Me.txtHSNCode.Text, Me.cmbProductName.Text, Me.txtBarcode.Text, Conversion.Val(Me.TextBox2.Text), Conversion.Val(Me.txtPricePerQty.Text), Conversion.Val(Me.txtDiscPer.Text), Conversion.Val(Me.txtDisc.Text), Conversion.Val(Me.txtCGSTPer.Text), Conversion.Val(Me.txtCGSTAmt.Text), Conversion.Val(Me.txtSGSTPer.Text), Conversion.Val(Me.txtSGSTAmt.Text), Conversion.Val(Me.txtIGSTPer.Text), Conversion.Val(Me.txtIGSTAmt.Text), Conversion.Val(Me.txtCESSPer.Text), Conversion.Val(Me.txtCESSAmt.Text), Conversion.Val(Me.txtTotalAmount.Text), Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text), Me.lblAltUnit.Text, Me.txtTaxType.Text, Conversion.Val(Me.txtTaxableAmtI.Text), Me.TextBox4.Text, Me.Picimage.Image })
													Dim num2 As Double = Me.SubTotal()
													num2 = Math.Round(num2, 2)
													Me.txtSubTotal.Text = Conversions.ToString(num2)
													Me.Compute()
													Me.Clear()
													Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(2)
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
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600B0D0 RID: 45264 RVA: 0x007585C4 File Offset: 0x007567C4
		Public Sub Clear()
			Me.txtHSNCode.Text = ""
			Me.cmbProductName.Text = ""
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
			Me.txtQty.Text = Conversions.ToString(1)
			Me.txtPricePerQty.Text = ""
			Me.txtDiscPer.Text = "0.00"
			Me.txtDisc.Text = "0.00"
			Me.txtCESSPer.Text = "0.00"
			Me.txtCESSAmt.Text = "0.00"
			Me.txtCGSTPer.Text = "0.00"
			Me.txtCGSTAmt.Text = "0.00"
			Me.txtSGSTPer.Text = "0.00"
			Me.txtSGSTAmt.Text = "0.00"
			Me.txtIGSTPer.Text = "0.00"
			Me.txtIGSTAmt.Text = "0.00"
			Me.txtTaxableAmtI.Text = "0.00"
			Me.txtBarcode.Text = ""
			Me.txtTaxType.Text = ""
			Me.lblUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.cmbUnit.Text = "Unit"
			Me.cmbaltunit.Text = "Unit"
			Me.TextBox3.Text = "1"
			Me.TextBox4.Text = "Unit"
			Me.txtProductID.Text = ""
			Me.btnListUpdate.Enabled = False
			Me.btnAdd.Enabled = True
			Me.btnRemove.Enabled = False
			Me.cmbDiscountType.SelectedIndex = 0
			Me.txtDisc.Enabled = False
			Me.txtTotalAmount.Text = "0.00"
			Me.txtDiscAmtPerQty.Text = "0.00"
			Me.lblAltUnit.Text = "Alt Unit"
			Me.lblAltValue.Text = "1"
		End Sub

		' Token: 0x0600B0D1 RID: 45265 RVA: 0x0075881C File Offset: 0x00756A1C
		Public Sub Calc()
			Dim flag As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Exclusive", False) = 0
			If flag Then
				Dim flag2 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag2 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag3 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag3 Then
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
			Dim flag4 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			If flag4 Then
				Dim flag5 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag5 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag6 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag6 Then
						Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
						Me.num1 = Math.Round(Me.num1, 2)
						Me.num7 = Conversion.Val(Me.txtDisc.Text) * 100.0 / Conversion.Val(Me.num1)
						Me.num7 = Math.Round(Me.num7, 4)
						Me.txtDiscPer.Text = Conversions.ToString(Me.num7)
					End If
				End If
				Me.num8 = Me.num1 - Conversion.Val(Me.txtDisc.Text)
				Me.num2 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num2 = Math.Round(Me.num2, 2)
				Me.txtCGSTAmt.Text = Strings.Format(Math.Round(Me.num2 / 2.0, 2), "0.00")
				Me.num3 = Me.num8 - Conversion.Val(Me.num8 / (1.0 + (Conversion.Val(Me.txtCGSTPer.Text) + Conversion.Val(Me.txtSGSTPer.Text)) / 100.0))
				Me.num3 = Math.Round(Me.num3, 2)
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
			Dim flag7 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Exempt GST", False) = 0
			If flag7 Then
				Dim flag8 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag8 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag9 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag9 Then
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
			Dim flag10 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "No Taxes", False) = 0
			If flag10 Then
				Dim flag11 As Boolean = (Me.cmbDiscountType.SelectedIndex = 0) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
				If flag11 Then
					Me.num1 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
					Me.num1 = Math.Round(Me.num1, 2)
					Me.num7 = Conversion.Val(Me.num1 * Conversion.Val(Me.txtDiscPer.Text) / 100.0)
					Me.num7 = Math.Round(Me.num7, 2)
					Me.txtDisc.Text = Conversions.ToString(Me.num7)
				Else
					Dim flag12 As Boolean = (Me.cmbDiscountType.SelectedIndex = 1) And (Operators.CompareString(Me.cmbProductName.Text, "", False) <> 0)
					If flag12 Then
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
			Me.num11 = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.txtPricePerQty.Text)
			Dim flag13 As Boolean = Operators.CompareString(Me.txtTaxType.Text, "Inclusive", False) = 0
			Dim num As Double
			If flag13 Then
				num = Me.num11 - Conversion.Val(Me.txtDisc.Text) - (Conversion.Val(Me.txtCGSTAmt.Text) + Conversion.Val(Me.txtSGSTAmt.Text) + Conversion.Val(Me.txtIGSTAmt.Text) + Conversion.Val(Me.txtCESSAmt.Text))
			Else
				num = Me.num11 - Conversion.Val(Me.txtDisc.Text)
			End If
			Me.txtTaxableAmtI.Text = Strings.Format(Math.Round(num, 2), "0.00")
		End Sub

		' Token: 0x0600B0D2 RID: 45266 RVA: 0x00759908 File Offset: 0x00757B08
		Private Sub btnRemove_Click(sender As Object, e As EventArgs)
			Try
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
				Me.Clear()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag As Boolean = Me.DataGridView1.RowCount = 0
			If flag Then
				Me.customerdetailenable()
			End If
		End Sub

		' Token: 0x0600B0D3 RID: 45267 RVA: 0x00759A10 File Offset: 0x00757C10
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from Quotation where Q_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.SrQuotationDelete(Me.txtQuotationNo.Text)
					Dim text2 As String = "deleted the invoice no. '" + Me.txtQuotationNo.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillQuotationID()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.fillQuotationID()
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.DataforNP()
		End Sub

		' Token: 0x0600B0D4 RID: 45268 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateID1() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600B0D5 RID: 45269 RVA: 0x00759B8C File Offset: 0x00757D8C
		Public Sub auto1()
			Try
				Me.txtCID.Text = Me.GenerateID1()
				Me.txtCustomerID.Text = "C-" + Me.GenerateID1()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0D6 RID: 45270 RVA: 0x00052454 File Offset: 0x00050654
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600B0D7 RID: 45271 RVA: 0x00052470 File Offset: 0x00050670
		Private Sub btnListReset_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x0600B0D8 RID: 45272 RVA: 0x00759C00 File Offset: 0x00757E00
		Private Sub btnListUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
				Else
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbProductName.Text, "", False) = 0
					If flag2 Then
						MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.TextBox5.Focus()
					Else
						Dim flag3 As Boolean = Me.cmbProductName.SelectedIndex = -1
						If flag3 Then
							MessageBox.Show("Please retrieve product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.TextBox5.Focus()
						Else
							Dim flag4 As Boolean = Operators.CompareString(Me.TextBox5.Text, Me.cmbProductName.Text, False) <> 0
							If flag4 Then
								MessageBox.Show("Please retrieve correct product info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.TextBox5.Focus()
							Else
								Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtPricePerQty.Text)) = 0
								If flag5 Then
									MessageBox.Show("Please enter price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPricePerQty.Focus()
								Else
									Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtDiscPer.Text)) = 0
									If flag6 Then
										MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtDiscPer.Focus()
									Else
										Dim flag7 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
										If flag7 Then
											MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtQty.Focus()
										Else
											Dim flag8 As Boolean = Conversions.ToDouble(Me.txtQty.Text) = 0.0
											If flag8 Then
												MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.txtQty.Focus()
											Else
												Me.alt()
												Dim text As String = Conversions.ToString(Operators.CompareString(Me.cmbUnit.Text, Me.TextBox4.Text, False) <> 0)
												Dim text2 As String = Conversions.ToString(Operators.CompareString(Me.cmbaltunit.Text, Me.cmbUnit.Text, False) <> 0)
												Dim flag9 As Boolean = Conversions.ToBoolean(text) AndAlso Conversions.ToBoolean(text2)
												If flag9 Then
													MessageBox.Show("Invalid Item Unit", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.cmbUnit.Text = Me.TextBox4.Text
													Me.cmbUnit.Focus()
												Else
													Dim index As Integer = Me.DataGridView1.CurrentRow.Index
													Me.DataGridView1(0, index).Value = Me.txtProductID.Text
													Me.DataGridView1(1, index).Value = Me.txtHSNCode.Text
													Me.DataGridView1(2, index).Value = Me.cmbProductName.Text
													Me.DataGridView1(3, index).Value = Me.txtBarcode.Text
													Me.DataGridView1(4, index).Value = Conversion.Val(Me.TextBox2.Text)
													Me.DataGridView1(5, index).Value = Conversion.Val(Me.txtPricePerQty.Text)
													Me.DataGridView1(6, index).Value = Conversion.Val(Me.txtDiscPer.Text)
													Me.DataGridView1(7, index).Value = Conversion.Val(Me.txtDisc.Text)
													Me.DataGridView1(8, index).Value = Conversion.Val(Me.txtCGSTPer.Text)
													Me.DataGridView1(9, index).Value = Conversion.Val(Me.txtCGSTAmt.Text)
													Me.DataGridView1(10, index).Value = Conversion.Val(Me.txtSGSTPer.Text)
													Me.DataGridView1(11, index).Value = Conversion.Val(Me.txtSGSTAmt.Text)
													Me.DataGridView1(12, index).Value = Conversion.Val(Me.txtIGSTPer.Text)
													Me.DataGridView1(13, index).Value = Conversion.Val(Me.txtIGSTAmt.Text)
													Me.DataGridView1(14, index).Value = Conversion.Val(Me.txtCESSPer.Text)
													Me.DataGridView1(15, index).Value = Conversion.Val(Me.txtCESSAmt.Text)
													Me.DataGridView1(16, index).Value = Conversion.Val(Me.txtTotalAmount.Text)
													Me.DataGridView1(17, index).Value = Conversion.Val(Me.TextBox2.Text) * Conversion.Val(Me.lblAltValue.Text)
													Me.DataGridView1(18, index).Value = Me.lblAltUnit.Text
													Me.DataGridView1(19, index).Value = Me.txtTaxType.Text
													Me.DataGridView1(20, index).Value = Conversion.Val(Me.txtTaxableAmtI.Text)
													Me.DataGridView1(21, index).Value = Me.TextBox4.Text
													Dim num As Double = Me.SubTotal()
													num = Math.Round(num, 2)
													Me.txtSubTotal.Text = Conversions.ToString(num)
													Me.Compute()
													Me.Clear()
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
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x0600B0D9 RID: 45273 RVA: 0x0075A2A0 File Offset: 0x007584A0
		Private Sub btnSelect_Click_1(sender As Object, e As EventArgs)
			Me.TextBox5.Focus()
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Quotation"
			MyProject.Forms.frmCustomerRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = True
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x0600B0DA RID: 45274 RVA: 0x0075A33C File Offset: 0x0075853C
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

		' Token: 0x0600B0DB RID: 45275 RVA: 0x0075A434 File Offset: 0x00758634
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

		' Token: 0x0600B0DC RID: 45276 RVA: 0x0075A52C File Offset: 0x0075872C
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

		' Token: 0x0600B0DD RID: 45277 RVA: 0x00052486 File Offset: 0x00050686
		Private Sub txtPricePerQty_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600B0DE RID: 45278 RVA: 0x00052490 File Offset: 0x00050690
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x0600B0DF RID: 45279 RVA: 0x0005249A File Offset: 0x0005069A
		Private Sub txtQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600B0E0 RID: 45280 RVA: 0x00052486 File Offset: 0x00050686
		Private Sub txtDiscPer_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600B0E1 RID: 45281 RVA: 0x0075A624 File Offset: 0x00758824
		Private Sub btnProductSelection_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Please retrieve customer info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
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
						ModCommonClasses.con.Close()
						Me.txtQty.Focus()
						MyProject.Forms.frmProductRecord.lblSet.Text = "Quotation"
						MyProject.Forms.frmProductRecord.Reset()
						MyProject.Forms.frmProductRecord.ShowDialog()
						MyProject.Forms.frmProductRecord.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0E2 RID: 45282 RVA: 0x0075A7A8 File Offset: 0x007589A8
		Private Sub frmQuotation_Load(sender As Object, e As EventArgs)
			Me.GetCompanyState()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.DataforNP()
			Me.Invoicecode()
			Me.auto()
			Me.fillUnit()
			Me.Autoroundoff()
			Me.Fillproducts()
			Me.FillCustomers()
			Me.fillQuotationID()
			Me.CheckBox4.TabStop = False
			Me.cmbUnit.DropDownHeight = 100
			Me.cmbUnit.DropDownWidth = 200
			Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			frmQuotation.DoubleBuffered(Me.dgw4, True)
			Me.PDBoardAll6()
			Me.GetDefaultCustomer()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600B0E3 RID: 45283 RVA: 0x0075A8C0 File Offset: 0x00758AC0
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

		' Token: 0x0600B0E4 RID: 45284 RVA: 0x0075AB60 File Offset: 0x00758D60
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

		' Token: 0x0600B0E5 RID: 45285 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600B0E6 RID: 45286 RVA: 0x0075AC2C File Offset: 0x00758E2C
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

		' Token: 0x0600B0E7 RID: 45287 RVA: 0x0075AD70 File Offset: 0x00758F70
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count > 0
				If flag Then
					Me.btnRemove.Enabled = True
					Me.btnListUpdate.Enabled = True
					Me.btnAdd.Enabled = False
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
					Me.txtProductID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.txtTaxType.Text = Conversions.ToString(dataGridViewRow.Cells(19).Value)
					Me.txtHSNCode.Text = Conversions.ToString(dataGridViewRow.Cells(1).Value)
					Me.cmbProductName.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.TextBox5.Text = Conversions.ToString(dataGridViewRow.Cells(2).Value)
					Me.txtBarcode.Text = Conversions.ToString(dataGridViewRow.Cells(3).Value)
					Me.txtQty.Text = Conversions.ToString(dataGridViewRow.Cells(4).Value)
					Me.txtPricePerQty.Text = Conversions.ToString(dataGridViewRow.Cells(5).Value)
					Me.txtDiscPer.Text = Conversions.ToString(dataGridViewRow.Cells(6).Value)
					Me.txtDisc.Text = Conversions.ToString(dataGridViewRow.Cells(7).Value)
					Me.txtCGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(8).Value)
					Me.txtCGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(9).Value)
					Me.txtSGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(10).Value)
					Me.txtSGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(11).Value)
					Me.txtIGSTPer.Text = Conversions.ToString(dataGridViewRow.Cells(12).Value)
					Me.txtIGSTAmt.Text = Conversions.ToString(dataGridViewRow.Cells(13).Value)
					Me.txtCESSPer.Text = Conversions.ToString(dataGridViewRow.Cells(14).Value)
					Me.txtCESSAmt.Text = Conversions.ToString(dataGridViewRow.Cells(15).Value)
					Me.txtTotalAmount.Text = Conversions.ToString(dataGridViewRow.Cells(16).Value)
					Me.txtTaxableAmtI.Text = Conversions.ToString(dataGridViewRow.Cells(20).Value)
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
					ModCommonClasses.cmd.CommandText = If(("SELECT RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=" + Conversions.ToString(Conversion.Val(Me.txtProductID.Text))), "")
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B0E8 RID: 45288 RVA: 0x0075B1BC File Offset: 0x007593BC
		Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.DataGridView1.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.DataGridView1.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600B0E9 RID: 45289 RVA: 0x0075B2A4 File Offset: 0x007594A4
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

		' Token: 0x0600B0EA RID: 45290 RVA: 0x0075B318 File Offset: 0x00759518
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

		' Token: 0x0600B0EB RID: 45291 RVA: 0x00052486 File Offset: 0x00050686
		Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
		End Sub

		' Token: 0x0600B0EC RID: 45292 RVA: 0x000524B2 File Offset: 0x000506B2
		Private Sub txtProductID_TextChanged(sender As Object, e As EventArgs)
			Me.alt1()
			Me.UnitInfo()
			Me.ProductImageRetrieve()
		End Sub

		' Token: 0x0600B0ED RID: 45293 RVA: 0x0075B410 File Offset: 0x00759610
		Private Sub dtpQuotationDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpQuotationDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpQuotationDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpQuotationDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpQuotationDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B0EE RID: 45294 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpQuotationDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0EF RID: 45295 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0F0 RID: 45296 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPricePerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0F1 RID: 45297 RVA: 0x000524CA File Offset: 0x000506CA
		Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600B0F2 RID: 45298 RVA: 0x000524DB File Offset: 0x000506DB
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x0600B0F3 RID: 45299 RVA: 0x000524DB File Offset: 0x000506DB
		Private Sub cmbaltunit_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.altunitcal()
		End Sub

		' Token: 0x0600B0F4 RID: 45300 RVA: 0x000524CA File Offset: 0x000506CA
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Me.Calc()
			Me.altunitcal()
		End Sub

		' Token: 0x0600B0F5 RID: 45301 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscountType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0F6 RID: 45302 RVA: 0x000524E5 File Offset: 0x000506E5
		Private Sub txtDiscAmtPerQty_TextChanged(sender As Object, e As EventArgs)
			Me.calc100()
		End Sub

		' Token: 0x0600B0F7 RID: 45303 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscPer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0F8 RID: 45304 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDisc_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0F9 RID: 45305 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0FA RID: 45306 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbUnit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B0FB RID: 45307 RVA: 0x0075B4BC File Offset: 0x007596BC
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

		' Token: 0x0600B0FC RID: 45308 RVA: 0x0075B5F0 File Offset: 0x007597F0
		Public Sub alt1()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.cmbaltunit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.cmbUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.TextBox4.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(9))
					Me.TextBox3.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
					Me.lblAltUnit.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(10))
					Me.lblAltValue.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(11))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B0FD RID: 45309 RVA: 0x0075B780 File Offset: 0x00759980
		Public Sub alt()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
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

		' Token: 0x0600B0FE RID: 45310 RVA: 0x0075B870 File Offset: 0x00759A70
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

		' Token: 0x0600B0FF RID: 45311 RVA: 0x0075B920 File Offset: 0x00759B20
		Private Sub conv()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT PID, RTRIM(Product.HSNCode),RTRIM(Barcode),(CostPrice),(SellingPrice),(Discount),(CGST),SGST,CESS,RTRIM(SalesUnit),RTRIM(SalesAltUnit),RTRIM(Conv) from Product where PID=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtProductID.Text)
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

		' Token: 0x0600B100 RID: 45312 RVA: 0x0075BA10 File Offset: 0x00759C10
		Private Sub altunitcal()
			Dim flag As Boolean = Operators.CompareString(Me.cmbUnit.Text, Me.cmbaltunit.Text, False) = 0
			If flag Then
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text) / Conversion.Val(Me.TextBox3.Text))
			Else
				Me.TextBox2.Text = Conversions.ToString(Conversion.Val(Me.txtQty.Text))
			End If
		End Sub

		' Token: 0x0600B101 RID: 45313 RVA: 0x0075BA9C File Offset: 0x00759C9C
		Private Sub calc100()
			Me.txtDisc.Text = Strings.Format(Math.Round(Conversion.Val(Me.txtDiscAmtPerQty.Text) * Conversion.Val(Me.txtQty.Text), 2), "0.00")
		End Sub

		' Token: 0x0600B102 RID: 45314 RVA: 0x0075BAEC File Offset: 0x00759CEC
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

		' Token: 0x0600B103 RID: 45315 RVA: 0x0075BBE4 File Offset: 0x00759DE4
		Public Sub FillCustomers()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT distinct RTRIM(Name) from Customer order by 1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.cmbCustomerName.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.cmbCustomerName.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B104 RID: 45316 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscAmtPerQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600B105 RID: 45317 RVA: 0x0075BCF4 File Offset: 0x00759EF4
		Private Sub cmbCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCID.Text = ""
				Me.txtCustomerID.Text = ""
				Me.txtCustomerState.Text = ""
				Me.txtContactNo.Text = ""
				Me.txtGSTIN.Text = ""
				Me.txtContactNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT ID, RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),RTRIM(GSTIN) from Customer where Name=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						Me.txtCustomerState.Text = Me.txtCompanyState.Text
					Else
						Me.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					End If
					Me.caddress = ModCommonClasses.rdr.GetValue(2).ToString()
				End If
				Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag3 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B106 RID: 45318 RVA: 0x0075BF40 File Offset: 0x0075A140
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Not Me.CheckBox4.Checked
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(CostPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.STax),(Temp_Stock.MRP) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
				End If
				Dim checked As Boolean = Me.CheckBox4.Checked
				If checked Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(CostPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(CostPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Temp_Stock.Damage),RTRIM(Product.MinStock),RTRIM(Product.STax),(Temp_Stock.MRP) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and PartNo like N'", Me.TextBox5.Text, "%' order by ProductName" }), ModCommonClasses.con)
				End If
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw4.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B107 RID: 45319 RVA: 0x000524EF File Offset: 0x000506EF
		Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)
			Me.cmbProductName.SelectedIndex = -1
			Me.TextBox5.Text = ""
			Me.TextBox5.Focus()
		End Sub

		' Token: 0x0600B108 RID: 45320 RVA: 0x0075C254 File Offset: 0x0075A454
		Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.TextBox5.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid product name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
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
			End If
		End Sub

		' Token: 0x0600B109 RID: 45321 RVA: 0x0075C320 File Offset: 0x0075A520
		Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.TextBox5.Text.TrimEnd(New Char(-1) {}), "", False) > 0
			If flag Then
				Me.getgriditemdata()
			Else
				Me.dgw4.Visible = False
			End If
		End Sub

		' Token: 0x0600B10A RID: 45322 RVA: 0x0075C370 File Offset: 0x0075A570
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

		' Token: 0x0600B10B RID: 45323 RVA: 0x0075C3B8 File Offset: 0x0075A5B8
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

		' Token: 0x0600B10C RID: 45324 RVA: 0x0005251C File Offset: 0x0005071C
		Private Sub txtQty_Leave(sender As Object, e As EventArgs)
			Me.dgw4.Visible = False
		End Sub

		' Token: 0x0600B10D RID: 45325 RVA: 0x0075DE00 File Offset: 0x0075C000
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x0600B10E RID: 45326 RVA: 0x0075DE28 File Offset: 0x0075C028
		Public Sub RetrieveData1()
			Try
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
				Else
					Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
					Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtTaxType.Text = dataGridViewRow.Cells(22).Value.ToString()
					Me.cmbProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.TextBox5.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtHSNCode.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
					Dim checked As Boolean = Me.RadioButton1.Checked
					If checked Then
						Me.txtPricePerQty.Text = dataGridViewRow.Cells(7).Value.ToString()
					Else
						Dim checked2 As Boolean = Me.RadioButton2.Checked
						If checked2 Then
							Me.txtPricePerQty.Text = dataGridViewRow.Cells(14).Value.ToString()
						End If
					End If
					Me.txtDiscPer.Text = dataGridViewRow.Cells(8).Value.ToString()
					Me.lblUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.cmbUnit.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.TextBox4.Text = dataGridViewRow.Cells(13).Value.ToString()
					Me.cmbaltunit.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.lblAltUnit.Text = dataGridViewRow.Cells(18).Value.ToString()
					Me.TextBox3.Text = dataGridViewRow.Cells(19).Value.ToString()
					Me.lblAltValue.Text = dataGridViewRow.Cells(19).Value.ToString()
					Dim flag3 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) = 0)
					If flag3 Then
						Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
						Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
						Me.txtIGSTPer.Text = Conversions.ToString(0)
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) = 0)
						If flag4 Then
							Me.txtCGSTPer.Text = dataGridViewRow.Cells(9).Value.ToString()
							Me.txtSGSTPer.Text = dataGridViewRow.Cells(10).Value.ToString()
							Me.txtIGSTPer.Text = Conversions.ToString(0)
						Else
							Dim flag5 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) <> 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) <> 0)
							If flag5 Then
								Me.txtCGSTPer.Text = Conversions.ToString(0)
								Me.txtSGSTPer.Text = Conversions.ToString(0)
								Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							Else
								Dim flag6 As Boolean = (Operators.CompareString(Me.txtGSTIN.Text, "", False) = 0) And (Operators.CompareString(Me.txtCustomerState.Text, Me.txtCompanyState.Text, False) <> 0)
								If flag6 Then
									Me.txtCGSTPer.Text = Conversions.ToString(0)
									Me.txtSGSTPer.Text = Conversions.ToString(0)
									Me.txtIGSTPer.Text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
								End If
							End If
						End If
					End If
					Me.txtCESSPer.Text = dataGridViewRow.Cells(11).Value.ToString()
					Me.Calc()
					Me.txtQty.Text = Conversions.ToString(1)
					Me.txtQty.Focus()
					Me.dgw4.Visible = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B10F RID: 45327 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw4_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
		End Sub

		' Token: 0x0600B110 RID: 45328 RVA: 0x0005252C File Offset: 0x0005072C
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x0600B111 RID: 45329 RVA: 0x0075E444 File Offset: 0x0075C644
		Private Sub cmbCustomerName_Validated(sender As Object, e As EventArgs)
			Dim focused As Boolean = Me.cmbCustomerName.Focused
			If focused Then
				Dim flag As Boolean = Me.cmbCustomerName.SelectedIndex = -1
				If flag Then
					MessageBox.Show("Please select correct customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbCustomerName.Focus()
				End If
			End If
		End Sub

		' Token: 0x0600B112 RID: 45330 RVA: 0x0075E498 File Offset: 0x0075C698
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid Name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getgridCustomerdata()
					Me.GridGetCustomer.Visible = True
					Dim flag3 As Boolean = Me.GridGetCustomer.Rows.Count = 1
					If flag3 Then
						Me.GridGetCustomer.Focus()
						Me.RetrieveDataCustomer()
						Dim num As Integer = Me.GridGetCustomer.Rows.Count - 1
						Dim num2 As Integer = 2
						Me.GridGetCustomer.CurrentCell = Me.GridGetCustomer.Rows(num - 1).Cells(num2)
						Dim num3 As Integer = If(-If((Me.GridGetCustomer.Rows.Count > 1 > False), 1, 0), 1, 0)
						Me.GridGetCustomer.Rows(num - 1).Cells(num2).[ReadOnly] = False
						Me.GridGetCustomer.Rows(num - 1).[ReadOnly] = False
						Me.GridGetCustomer.BeginEdit(True)
					Else
						Dim flag4 As Boolean = Me.GridGetCustomer.Rows.Count > 1
						If flag4 Then
							Me.GridGetCustomer.Focus()
							SendKeys.Send("{ENTER}")
						End If
					End If
					e.SuppressKeyPress = True
				End If
			End If
		End Sub

		' Token: 0x0600B113 RID: 45331 RVA: 0x00052536 File Offset: 0x00050736
		Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
			Me.RetrieveData1()
			Me.Clear()
		End Sub

		' Token: 0x0600B114 RID: 45332 RVA: 0x00052536 File Offset: 0x00050736
		Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
			Me.RetrieveData1()
			Me.Clear()
		End Sub

		' Token: 0x0600B115 RID: 45333 RVA: 0x0075E614 File Offset: 0x0075C814
		Public Sub fillQuotationID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(Q_ID) FROM Quotation order by Q_ID ASC", ModCommonClasses.con)
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

		' Token: 0x0600B116 RID: 45334 RVA: 0x0075E750 File Offset: 0x0075C950
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(quotation.Remarks) from Customer,quotation where Customer.ID=quotation.CustomerID and quotation.Q_ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtQ_ID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtQuotationNo.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.dtpQuotationDate.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtCID.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbCustomerName.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
					If flag2 Then
						Me.txtCustomerState.Text = Me.txtCompanyState.Text
					Else
						Me.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					End If
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtSubTotal.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtCGST.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtSGST.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtIGST.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtCESS.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtTotal.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtRoundOff.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtGrandTotal.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.btnSave.Enabled = False
					Me.btnUpdate.Enabled = True
					Me.btnPrint.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnCustomerSelection.Enabled = False
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Quotation_Join.Barcode),Quotation_Join.Qty, Quotation_Join.Price,Quotation_Join.DiscountPer,Quotation_Join.DiscountAmt,Quotation_Join. CGSTPer, Quotation_Join.CGSTAmt,Quotation_Join. SGSTPer,Quotation_Join. SGSTAmt,Quotation_Join. IGSTPer,Quotation_Join. IGSTAmt,Quotation_Join. CESSPer,Quotation_Join. CESSAmt,Quotation_Join.TotalAmount, Quotation_Join.AltQty,RTRIM(Quotation_Join.AltUnit),RTRIM(Quotation_Join.STaxType),Quotation_Join.TaxableAmt,RTRIM(Quotation_Join.MainUnit) from quotation,Quotation_Join,Product where quotation.Q_ID=Quotation_Join.QuotationID and Product.PID=Quotation_Join.ProductID and quotation.Q_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.DataGridView1.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
					End While
				End If
				ModCommonClasses.con.Close()
				Me.DataGridView1.ClearSelection()
				Me.Calc()
				Me.Compute()
				Me.CTypeStatus()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B117 RID: 45335 RVA: 0x00052547 File Offset: 0x00050747
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x0600B118 RID: 45336 RVA: 0x0075ECC8 File Offset: 0x0075CEC8
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Quotation", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Quotation")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Quotation").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600B119 RID: 45337 RVA: 0x0075EDA4 File Offset: 0x0075CFA4
		Private Sub btnNext_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))
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

		' Token: 0x0600B11A RID: 45338 RVA: 0x0075EE60 File Offset: 0x0075D060
		Private Sub txtPrev_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbNP.Text = Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))
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

		' Token: 0x0600B11B RID: 45339 RVA: 0x0075EF0C File Offset: 0x0075D10C
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0600B11C RID: 45340 RVA: 0x0075EF5C File Offset: 0x0075D15C
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Quotation").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Quotation").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B11D RID: 45341 RVA: 0x0075F014 File Offset: 0x0075D214
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Quotation").Rows(Conversions.ToInteger(Me.CurrentRow))("Q_ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B11E RID: 45342 RVA: 0x0075F0AC File Offset: 0x0075D2AC
		Public Sub CTypeStatus()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CType) from Quotation where QuotationNo=@d1 "
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtQuotationNo.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.rb = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Dim flag2 As Boolean = Operators.CompareString(Me.rb, "Retail", False) = 0
					If flag2 Then
						Me.RadioButton1.Checked = True
						Me.RadioButton2.Checked = False
						Me.RadioButton1.Enabled = False
						Me.RadioButton2.Enabled = False
					Else
						Dim flag3 As Boolean = Operators.CompareString(Me.rb, "Wholesale", False) = 0
						If flag3 Then
							Me.RadioButton1.Checked = False
							Me.RadioButton2.Checked = True
							Me.RadioButton1.Enabled = False
							Me.RadioButton2.Enabled = False
						End If
					End If
				Else
					Me.RadioButton1.Checked = True
					Me.RadioButton2.Checked = False
					Me.RadioButton1.Enabled = False
					Me.RadioButton2.Enabled = False
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B11F RID: 45343 RVA: 0x0075F264 File Offset: 0x0075D464
		Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column4").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column4").Value))
						End If

				Next
				Dim flag2 As Boolean = num2 <= 0.0
				If flag2 Then
					Me.RadioButton1.Enabled = True
					Me.RadioButton2.Enabled = True
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B120 RID: 45344 RVA: 0x0075F350 File Offset: 0x0075D550
		Public Sub Speaker()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				For i As Integer = 0 To num
					Dim num2 As Double = Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column6").Value))
					Me.txtRsToWords.Text = Conversions.ToString(RupModule1.RupeesToWord(Conversion.Val(num2)))
					Me.a1 = Me.DataGridView1.Rows(i).Cells("Column3").Value.ToString()
					Me.a2 = Conversions.ToString(Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(i).Cells("Column24").Value)))
					Me.a3 = Me.DataGridView1.Rows(i).Cells("Column25").Value.ToString()
					NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { Me.a1 + " " + Me.a2 + Me.a3 + " " + Me.txtRsToWords.Text }, Nothing, Nothing, Nothing, True)
				Next
				NewLateBinding.LateCall(Me.voice, Nothing, "speak", New Object() { "Thank You" }, Nothing, Nothing, Nothing, True)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B121 RID: 45345 RVA: 0x0075F518 File Offset: 0x0075D718
		Private Sub Button34_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
			If flag Then
				MessageBox.Show("You have not added the products into grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Speaker()
			End If
		End Sub

		' Token: 0x0600B122 RID: 45346 RVA: 0x0075F55C File Offset: 0x0075D75C
		Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Me.CheckBox13.Checked
			If flag Then
				Me.dgw.Visible = False
			Else
				Dim checked As Boolean = Me.CheckBox13.Checked
				If checked Then
					Me.dgw.Visible = True
				End If
			End If
			Dim checked2 As Boolean = Me.CheckBox13.Checked
			If checked2 Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Update AutoSet set Set1=@d1 where ID=@d2"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 9)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "Yes")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			End If
			Dim flag2 As Boolean = Not Me.CheckBox13.Checked
			If flag2 Then
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text2 As String = "Update AutoSet set Set1=@d1 where ID=@d2"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", 9)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "No")
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteNonQuery()
				ModCommonClasses.con.Close()
			End If
		End Sub

		' Token: 0x0600B123 RID: 45347 RVA: 0x0005255F File Offset: 0x0005075F
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600B124 RID: 45348 RVA: 0x0075F6FC File Offset: 0x0075D8FC
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpQuotationDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Quotation where Date between @d1 and @d2 having count(*) >= 5"
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
			Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
			If flag4 Then
				MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag5 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag5 Then
					MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "select * from Company"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag6 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag6 Then
							MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag7 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = "insert into Quotation(Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS,Total,RoundOff, GrandTotal, Remarks, CType) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpQuotationDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "GST")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtCGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtSGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtRoundOff.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtRemarks.Text)
							Dim flag8 As Boolean = Me.RadioButton1.Checked And Not Me.RadioButton2.Checked
							If flag8 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
							Else
								Dim flag9 As Boolean = Me.RadioButton2.Checked And Not Me.RadioButton1.Checked
								If flag9 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Wholesale")
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
								End If
							End If
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "insert into Quotation_Join(QuotationID, ProductID,Barcode, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,AltQty,AltUnit,STaxType,TaxableAmt,MainUnit) VALUES (" + Me.txtQ_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag10 As Boolean = Not dataGridViewRow.IsNewRow
									If flag10 Then
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
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
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
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text5 As String = "insert into SrQuotation(ID, InvNo) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text5)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Dim text6 As String = "added the new quotation having quotation no. '" + Me.txtQuotationNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text6)
							Me.btnSave.Enabled = False
							Dim flag11 As Boolean = ModFunc.CheckForInternetConnection()
							If flag11 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text7 As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
								ModCommonClasses.cmd = New SqlCommand(text7)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
								If flag12 Then
									Me.st2 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
									Dim text8 As String = If(("Hello, " + Me.cmbCustomerName.Text + " you have successfully applied for quotation having quotation no. " + Me.txtQuotationNo.Text), "")
									ModFunc.SMSFunc(Me.txtContactNo.Text, text8, Me.st2)
									ModFunc.SMS(text8)
									Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag13 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
							End If
							ModCommonClasses.con.Close()
							Me.DataforNP()
							Dim flag14 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print the Quotation Invoice ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
							If flag14 Then
								Me.Print()
							End If
							Me.fillQuotationID()
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600B125 RID: 45349 RVA: 0x007603E0 File Offset: 0x0075E5E0
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag2 Then
					MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "select * from Company"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = Not ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "Update Quotation set QuotationNo=@d2, Date=@d3, TaxType=@d4, CustomerID=@d5, SubTotal=@d6, CGST=@d7, SGST=@d8, IGST=@d9, CESS=@d10,Total=@d11,RoundOff=@d12, GrandTotal=@d13, Remarks=@d14, CType=@d15 where Q_ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQ_ID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtQuotationNo.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpQuotationDate.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", "GST")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.txtCID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtSubTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.txtCGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtSGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtIGST.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.txtCESS.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.txtTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(Me.txtRoundOff.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(Me.txtGrandTotal.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtRemarks.Text)
							Dim flag5 As Boolean = Me.RadioButton1.Checked And Not Me.RadioButton2.Checked
							If flag5 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
							Else
								Dim flag6 As Boolean = Me.RadioButton2.Checked And Not Me.RadioButton1.Checked
								If flag6 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Wholesale")
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "Retail")
								End If
							End If
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text3 As String = If(("Delete from Quotation_Join where QuotationID=" + Conversions.ToString(Conversion.Val(Me.txtQ_ID.Text))), "")
							ModCommonClasses.cmd = New SqlCommand(text3)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "insert into Quotation_Join(QuotationID, ProductID,Barcode, Qty, Price,DiscountPer,DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt,TotalAmount,AltQty,AltUnit,STaxType,TaxableAmt,MainUnit) VALUES (" + Me.txtQ_ID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
									Dim flag7 As Boolean = Not dataGridViewRow.IsNewRow
									If flag7 Then
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
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value)))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
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
							Dim text5 As String = "Updated the quotation having quotation no. '" + Me.txtQuotationNo.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text5)
							MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600B126 RID: 45350 RVA: 0x00760E20 File Offset: 0x0075F020
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

		' Token: 0x0600B127 RID: 45351 RVA: 0x00760E88 File Offset: 0x0075F088
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Reset()
			MyProject.Forms.frmQuotationRecord.Label3.Text = "Qtn"
			MyProject.Forms.frmQuotationRecord.Reset()
			MyProject.Forms.frmQuotationRecord.ShowDialog()
			MyProject.Forms.frmQuotationRecord.Dispose()
		End Sub

		' Token: 0x0600B128 RID: 45352 RVA: 0x00052569 File Offset: 0x00050769
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600B129 RID: 45353 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600B12A RID: 45354 RVA: 0x00760EE8 File Offset: 0x0075F0E8
		Private Sub getgridCustomerdata()
			Try
				Me.GridGetCustomer.Visible = True
				Me.GridGetCustomer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.GridGetCustomer.RowHeadersVisible = False
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim flag As Boolean = Operators.CompareString(Me.strSearchtype, "number", False) = 0
				If flag Then
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " ID, CustomerID,RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),RTRIM(Name),RTRIM(EmailID),RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status) from Customer where ContactNo like N'", Me.txtContactNo.Text, "%' order by ID" }), ModCommonClasses.con)
				Else
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Conversions.ToString(Me.NumericUpDown1.Value), " ID, CustomerID,RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),RTRIM(Name),RTRIM(EmailID),RTRIM(PAN),RTRIM(Tcs),RTRIM(CardNo),RTRIM(Status) from Customer where Name like N'", Me.cmbCustomerName.Text, "%' order by Name" }), ModCommonClasses.con)
				End If
				Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.GridGetCustomer.Rows.Clear()
				While sqlDataReader.Read()
					Me.GridGetCustomer.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10) })
				End While
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B12B RID: 45355 RVA: 0x007610F8 File Offset: 0x0075F2F8
		Public Sub RetrieveDataCustomer()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.GridGetCustomer.SelectedRows(0)
				Dim flag As Boolean = dataGridViewRow.Cells(1).Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dataGridViewRow.Cells(1).Value.ToString())
				If flag Then
					Me.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtCustomerState.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtGSTIN.Text = dataGridViewRow.Cells(4).Value.ToString()
					Me.cmbCustomerName.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.GridGetCustomer.Visible = False
					Me.txtBarcode.Focus()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600B12C RID: 45356 RVA: 0x0076126C File Offset: 0x0075F46C
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Enter the valid contact number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "1234567890", False) = 0
					If flag3 Then
						MessageBox.Show("Enter the valid contact number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						Me.getgridCustomerdata()
						Me.GridGetCustomer.Visible = True
						Dim flag4 As Boolean = Me.GridGetCustomer.Rows.Count = 1
						If flag4 Then
							Me.GridGetCustomer.Focus()
							Me.RetrieveDataCustomer()
							Dim num As Integer = Me.GridGetCustomer.Rows.Count - 1
							Dim num2 As Integer = 2
							Me.GridGetCustomer.CurrentCell = Me.GridGetCustomer.Rows(num - 1).Cells(num2)
							Dim num3 As Integer = If(-If((Me.GridGetCustomer.Rows.Count > 1 > False), 1, 0), 1, 0)
							Me.GridGetCustomer.Rows(num - 1).Cells(num2).[ReadOnly] = False
							Me.GridGetCustomer.Rows(num - 1).[ReadOnly] = False
							Me.GridGetCustomer.BeginEdit(True)
						Else
							Dim flag5 As Boolean = Me.GridGetCustomer.Rows.Count > 1
							If flag5 Then
								Me.GridGetCustomer.Focus()
								SendKeys.Send("{ENTER}")
							End If
						End If
						e.SuppressKeyPress = True
					End If
				End If
			End If
		End Sub

		' Token: 0x0600B12D RID: 45357 RVA: 0x00761420 File Offset: 0x0075F620
		Private Sub txtContactNo_Leave(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.GridGetCustomer.Rows.Count = 1
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = CType(Me.GridGetCustomer.RowTemplate.Clone(), DataGridViewRow)
				dataGridViewRow.CreateCells(Me.GridGetCustomer)
				dataGridViewRow.Cells(Me.GridGetCustomer.Columns("ContactNo").Index).Value = Me.txtContactNo.Text
				Me.GridGetCustomer.Rows.Add(dataGridViewRow)
				Dim num As Integer = Me.GridGetCustomer.Rows.Count - 1
				Me.GridGetCustomer.CurrentCell = Me.GridGetCustomer.Rows(num).Cells(Me.GridGetCustomer.Columns("customerName").Index)
				Me.GridGetCustomer.BeginEdit(True)
			End If
		End Sub

		' Token: 0x0600B12E RID: 45358 RVA: 0x00761518 File Offset: 0x0075F718
		Private Sub cmbCustomerName_Leave(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.GridGetCustomer.Rows.Count = 1
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = CType(Me.GridGetCustomer.RowTemplate.Clone(), DataGridViewRow)
				dataGridViewRow.CreateCells(Me.GridGetCustomer)
				dataGridViewRow.Cells(Me.GridGetCustomer.Columns("customerName").Index).Value = Me.cmbCustomerName.Text
				Me.GridGetCustomer.Rows.Add(dataGridViewRow)
				Dim num As Integer = Me.GridGetCustomer.Rows.Count - 1
				Me.GridGetCustomer.CurrentCell = Me.GridGetCustomer.Rows(num).Cells(Me.GridGetCustomer.Columns("ContactNo").Index)
				Me.GridGetCustomer.BeginEdit(True)
			End If
		End Sub

		' Token: 0x0600B12F RID: 45359 RVA: 0x00761610 File Offset: 0x0075F810
		Private Sub GridGetCustomer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.GridGetCustomer.SelectedRows(0)
			Dim flag As Boolean = dataGridViewRow.Cells(1).Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dataGridViewRow.Cells(1).Value.ToString())
			If flag Then
				Dim flag2 As Boolean = e.KeyCode = Keys.[Return]
				If flag2 Then
					Me.RetrieveDataCustomer()
				End If
			Else
				Dim flag3 As Boolean = e.KeyCode = Keys.[Return]
				If flag3 Then
					e.Handled = True
					Dim rowIndex As Integer = Me.GridGetCustomer.CurrentCell.RowIndex
					Dim num As Integer = Me.GridGetCustomer.CurrentCell.ColumnIndex
					Do
						Dim flag4 As Boolean = num >= Me.GridGetCustomer.ColumnCount - 1
						If flag4 Then
							Exit Do
						End If
						num += 1
					Loop While Not Me.GridGetCustomer.Columns(num).Visible
					Me.GridGetCustomer.CurrentCell = Me.GridGetCustomer(num, rowIndex)
					Dim flag5 As Boolean = TypeOf Me.GridGetCustomer.Columns(num)Is DataGridViewButtonColumn
					If flag5 Then
						Me.GridGetCustomer_CellContentClick(Me.GridGetCustomer, New DataGridViewCellEventArgs(num, rowIndex))
					End If
				End If
			End If
		End Sub

		' Token: 0x0600B130 RID: 45360 RVA: 0x00761760 File Offset: 0x0075F960
		Public Sub autoCust()
			Try
				Me.txtCID.Text = Me.GenerateIDCus()
				Me.txtCustomerID.Text = "C-" + Me.GenerateIDCus()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B131 RID: 45361 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateIDCus() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600B132 RID: 45362 RVA: 0x007617D4 File Offset: 0x0075F9D4
		Private Sub GridGetCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = Me.GridGetCustomer.Columns("custbtnSave").Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.GridGetCustomer.Rows(e.RowIndex)
				Me.autoCust()
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("customerName").Value))) = 0
				If flag2 Then
					MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("contactNo").Value))) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						NewLateBinding.LateCall(dataGridViewRow.Cells("contactNo").Value, Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
					Else
						Try
							Dim flag4 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("customerName").Value, "", False)
							If flag4 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "select RTRIM(Name) from Customer where Name=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Operators.AddObject(Operators.AddObject(dataGridViewRow.Cells("customerName").Value, "_"), dataGridViewRow.Cells("contactNo").Value))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									NewLateBinding.LateCall(dataGridViewRow.Cells("customerName").Value, Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
									Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag6 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
								ModCommonClasses.con.Close()
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select RTRIM(ContactNo) from Customer where ContactNo=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("contactNo").Value))
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								NewLateBinding.LateCall(dataGridViewRow.Cells("contactNo").Value, Nothing, "Focus", New Object(-1) {}, Nothing, Nothing, Nothing, True)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "select RTRIM(State) from Company where Id=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", "1")
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
								Dim text4 As String
								If flag9 Then
									text4 = ModCommonClasses.rdr(0).ToString()
									Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag10 Then
										ModCommonClasses.rdr.Close()
									End If
								End If
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = "insert into Customer(ID, CustomerID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,Optype,Opbal,Photo,Tcs,Limit,Lstatus,Route,Taround,DiscPer,DiscStatus,QrCustomer) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@qr)"
								ModCommonClasses.cmd = New SqlCommand(text5)
								Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow.Cells("contactNo").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtCID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustomerID.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Operators.AddObject(Operators.AddObject(dataGridViewRow.Cells("customerName").Value, "_"), dataGridViewRow.Cells("contactNo").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "local")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "localcity")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("contactNo").Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "abc@gmail.com")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", String.Empty)
								Dim flag11 As Boolean = dataGridViewRow.Cells("state").Value Is Nothing
								If flag11 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text4)
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("state").Value))
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", String.Empty)
								Dim flag12 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("GSTIN").Value, "", False)
								If flag12 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
								Else
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("GSTIN").Value))
								End If
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d21", "Cr")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "No")
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d23", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@qr", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModFunc.LedgerSave(DateAndTime.Today, Conversions.ToString(Operators.AddObject(Operators.AddObject(dataGridViewRow.Cells("customerName").Value, "_"), dataGridViewRow.Cells("contactNo").Value)), Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustomerID.Text, Conversions.ToString(Operators.AddObject(Operators.AddObject(dataGridViewRow.Cells("customerName").Value, "_"), dataGridViewRow.Cells("contactNo").Value)))
								ModFunc.CustomerLedgerSave(DateAndTime.Today, Conversions.ToString(Operators.AddObject(Operators.AddObject(dataGridViewRow.Cells("customerName").Value, "_"), dataGridViewRow.Cells("contactNo").Value)), Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustomerID.Text, Me.txtCustomerID.Text, String.Empty)
								ModFunc.LogFunc(Me.lblUser.Text, "added the new Customer having Customer id '" + Me.txtCustomerID.Text + "'")
								MessageBox.Show("Customer Data Inserted succesfully")
								Me.getgridCustomerdata()
								Me.RetrieveDataCustomer()
								Me.GridGetCustomer.Visible = False
							End If
						Catch ex As Exception
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600B133 RID: 45363 RVA: 0x007622A8 File Offset: 0x007604A8
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600B134 RID: 45364 RVA: 0x0076232C File Offset: 0x0076052C
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
			Me.strSearchtype = "number"
			Dim flag As Boolean = Operators.CompareString(Me.strSearchtype, "number", False) = 0
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "1234567890", False) <> 0
				If flag2 Then
					Me.getgridCustomerdata()
				Else
					Me.GridGetCustomer.Visible = False
				End If
			End If
		End Sub

		' Token: 0x0600B135 RID: 45365 RVA: 0x00762398 File Offset: 0x00760598
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Me.strSearchtype = "name"
			Dim flag As Boolean = Operators.CompareString(Me.strSearchtype, "name", False) = 0
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbCustomerName.Text, "Cash", False) <> 0
				If flag2 Then
					Me.getgridCustomerdata()
				Else
					Me.GridGetCustomer.Visible = False
				End If
			End If
		End Sub

		' Token: 0x0600B136 RID: 45366 RVA: 0x00762404 File Offset: 0x00760604
		Public Sub PDBoardAll6()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select RTRIM(Set1) from AutoSet where ID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 9)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim text As String
				If flag Then
					text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					text = "No"
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
				Dim flag4 As Boolean = Operators.CompareString(text, "Yes", False) = 0
				If flag4 Then
					Me.CheckBox13.Checked = True
				Else
					Me.CheckBox13.Checked = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B137 RID: 45367 RVA: 0x0076254C File Offset: 0x0076074C
		Public Sub ProductImageRetrieve()
			Dim checked As Boolean = Me.CheckBox13.Checked
			If checked Then
				ModCommonClasses.con1 = New SqlConnection(ModCS.cs)
				ModCommonClasses.con1.Open()
				ModCommonClasses.cmd1 = New SqlCommand("SELECT Photo from Product,Product_Join where Product.PID=Product_Join.ProductID and Product.PID=@d1", ModCommonClasses.con1)
				ModCommonClasses.cmd1.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.rdr1 = ModCommonClasses.cmd1.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr1.Read()
					Dim array As Byte() = CType(ModCommonClasses.rdr1(0), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Dim image As Image = Image.FromStream(memoryStream)
					Me.dgw.Rows.Add(New Object() { image })
				End While
				ModCommonClasses.con1.Close()
			End If
		End Sub

		' Token: 0x0600B138 RID: 45368 RVA: 0x001B3140 File Offset: 0x001B1340
		Public Shared Sub DoubleBuffered(dgw4 As DataGridView, setting As Boolean)
			Dim type As Type = dgw4.[GetType]()
			Dim [property] As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
			[property].SetValue(dgw4, setting, Nothing)
		End Sub

		' Token: 0x0600B139 RID: 45369 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmQuotation_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B13A RID: 45370 RVA: 0x00762640 File Offset: 0x00760840
		Private Sub Button33_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtProductID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				MyProject.Forms.frmProductLedgerPOS.txtCustomerID.Text = Conversions.ToString(Conversion.Val(Me.txtProductID.Text))
				MyProject.Forms.frmProductLedgerPOS.Button3.Visible = True
				MyProject.Forms.frmProductLedgerPOS.ShowDialog()
			End If
		End Sub

		' Token: 0x0600B13B RID: 45371 RVA: 0x007626D4 File Offset: 0x007608D4
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

		' Token: 0x0600B13C RID: 45372 RVA: 0x007627CC File Offset: 0x007609CC
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 Date from Quotation order by Q_ID DESC"
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
					Me.dtpQuotationDate.Value = Me.prevdate
				Else
					Me.dtpQuotationDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B13D RID: 45373 RVA: 0x00052573 File Offset: 0x00050773
		Public Sub customerdetaildisable()
			Me.cmbCustomerName.Enabled = False
			Me.btnCustomerSelection.Enabled = False
			Me.txtContactNo.[ReadOnly] = True
		End Sub

		' Token: 0x0600B13E RID: 45374 RVA: 0x0005259D File Offset: 0x0005079D
		Public Sub customerdetailenable()
			Me.cmbCustomerName.Enabled = True
			Me.btnCustomerSelection.Enabled = True
			Me.txtContactNo.[ReadOnly] = False
		End Sub

		' Token: 0x0600B13F RID: 45375 RVA: 0x0076290C File Offset: 0x00760B0C
		Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = Me.DataGridView1.RowCount > 0
			If flag Then
				Me.customerdetaildisable()
			End If
		End Sub

		' Token: 0x0600B140 RID: 45376 RVA: 0x00762938 File Offset: 0x00760B38
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

		' Token: 0x0600B141 RID: 45377 RVA: 0x00762A58 File Offset: 0x00760C58
		Private Sub Button33_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.Button33, "Product Dashboard")
		End Sub

		' Token: 0x0600B142 RID: 45378 RVA: 0x00762AA8 File Offset: 0x00760CA8
		Private Sub txtPricePerQty_GotFocus(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from InvoiceInfo Having count(*) >= 1 and " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " > 0"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dgwsale.Visible = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("SELECT TOP 5 InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.InvoiceNo),  RTRIM(Customer.Name), Invoice_Product.SalesRate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID WHERE Invoice_Product.ProductID = " + Conversions.ToString(Conversion.Val(Me.txtProductID.Text)) + " order by Invoiceinfo.InvoiceDate DESC", ModCommonClasses.con)
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

		' Token: 0x0600B143 RID: 45379 RVA: 0x000525C7 File Offset: 0x000507C7
		Private Sub txtPricePerQty_LostFocus(sender As Object, e As EventArgs)
			Me.dgwsale.Visible = False
		End Sub

		' Token: 0x0600B144 RID: 45380 RVA: 0x00762C90 File Offset: 0x00760E90
		Private Sub GridGetCustomer_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = TypeOf Me.GridGetCustomer.CurrentCell Is DataGridViewTextBoxCell
			If flag Then
				Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
				RemoveHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
				AddHandler dataGridViewTextBoxEditingControl.PreviewKeyDown, AddressOf Me.PreTranslateDGV_PreviewKeyDown
			End If
		End Sub

		' Token: 0x0600B145 RID: 45381 RVA: 0x00762CEC File Offset: 0x00760EEC
		Private Sub PreTranslateDGV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
			Dim dataGridViewTextBoxEditingControl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
			Dim editingControlDataGridView As DataGridView = dataGridViewTextBoxEditingControl.EditingControlDataGridView
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = editingControlDataGridView.ColumnCount - 1
				Dim num As Integer
				Dim num2 As Integer
				If flag2 Then
					num = editingControlDataGridView.CurrentCell.RowIndex + 1
					num2 = 0
					Dim flag3 As Boolean = num = editingControlDataGridView.RowCount
					If flag3 Then
						editingControlDataGridView.Rows.Add(1)
					End If
				Else
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 = editingControlDataGridView.CurrentCell.ColumnIndex + 1
				End If
				Dim flag4 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 2
				If flag4 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 += 2
				End If
				Dim flag5 As Boolean = editingControlDataGridView.CurrentCell.ColumnIndex = 5
				If flag5 Then
					num = editingControlDataGridView.CurrentCell.RowIndex
					num2 += 5
				End If
				editingControlDataGridView.CurrentCell = editingControlDataGridView.Rows(num).Cells(num2)
			End If
		End Sub

		' Token: 0x04004A04 RID: 18948
		Private st2 As String

		' Token: 0x04004A05 RID: 18949
		Private num1 As Double

		' Token: 0x04004A06 RID: 18950
		Private num2 As Double

		' Token: 0x04004A07 RID: 18951
		Private num3 As Double

		' Token: 0x04004A08 RID: 18952
		Private num4 As Double

		' Token: 0x04004A09 RID: 18953
		Private num5 As Double

		' Token: 0x04004A0A RID: 18954
		Private num6 As Double

		' Token: 0x04004A0B RID: 18955
		Private num7 As Double

		' Token: 0x04004A0C RID: 18956
		Private num8 As Double

		' Token: 0x04004A0D RID: 18957
		Private num9 As Double

		' Token: 0x04004A0E RID: 18958
		Private num10 As Double

		' Token: 0x04004A0F RID: 18959
		Private num11 As Double

		' Token: 0x04004A10 RID: 18960
		Private a As Decimal

		' Token: 0x04004A11 RID: 18961
		Public Company1 As String

		' Token: 0x04004A12 RID: 18962
		Public Address1 As String

		' Token: 0x04004A13 RID: 18963
		Public State1 As String

		' Token: 0x04004A14 RID: 18964
		Public Contact1 As String

		' Token: 0x04004A15 RID: 18965
		Public Email1 As String

		' Token: 0x04004A16 RID: 18966
		Public Gstin1 As String

		' Token: 0x04004A17 RID: 18967
		Public Cin1 As String

		' Token: 0x04004A18 RID: 18968
		Private caddress As String

		' Token: 0x04004A19 RID: 18969
		Private clsprint As clsprint

		' Token: 0x04004A1A RID: 18970
		Private dtprint As DataTable

		' Token: 0x04004A1B RID: 18971
		Private strSearchtype As String

		' Token: 0x04004A1C RID: 18972
		Private strcompany As String

		' Token: 0x04004A1D RID: 18973
		Private strbankac As String

		' Token: 0x04004A1E RID: 18974
		Private strbankifsc As String

		' Token: 0x04004A1F RID: 18975
		Private ntid As String

		' Token: 0x04004A20 RID: 18976
		Private Dad As SqlDataAdapter

		' Token: 0x04004A21 RID: 18977
		Private Dst As DataSet

		' Token: 0x04004A22 RID: 18978
		Private CurrentRow As Object

		' Token: 0x04004A23 RID: 18979
		Private rb As String

		' Token: 0x04004A24 RID: 18980
		Private voice As Object

		' Token: 0x04004A25 RID: 18981
		Private a1 As String

		' Token: 0x04004A26 RID: 18982
		Private a2 As String

		' Token: 0x04004A27 RID: 18983
		Private a3 As String

		' Token: 0x04004A28 RID: 18984
		Private InvDateSts As String

		' Token: 0x04004A29 RID: 18985
		Private prevdate As DateTime
	End Class
End Namespace
