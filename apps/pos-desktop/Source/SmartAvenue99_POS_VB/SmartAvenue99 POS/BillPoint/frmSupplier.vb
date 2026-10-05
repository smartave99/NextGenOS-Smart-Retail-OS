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
Imports System.Net.Http
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports CrystalDecisions.CrystalReports.Engine
Imports DevNet.GS
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace BillPoint
	' Token: 0x020005E3 RID: 1507
	<DesignerGenerated()>
	Public Partial Class frmSupplier
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060128B8 RID: 75960 RVA: 0x00AAC2A8 File Offset: 0x00AAA4A8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSupplier_Load
			AddHandler MyBase.Closing, AddressOf Me.frmSupplier_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplier_KeyDown
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.apiKey = ""
			Me.url = ""
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700730C RID: 29452
		' (get) Token: 0x060128BB RID: 75963 RVA: 0x0007F2B8 File Offset: 0x0007D4B8
		' (set) Token: 0x060128BC RID: 75964 RVA: 0x0007F2C2 File Offset: 0x0007D4C2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700730D RID: 29453
		' (get) Token: 0x060128BD RID: 75965 RVA: 0x0007F2CB File Offset: 0x0007D4CB
		' (set) Token: 0x060128BE RID: 75966 RVA: 0x0007F2D5 File Offset: 0x0007D4D5
		Friend Overridable Property Panel4 As Panel

		' Token: 0x1700730E RID: 29454
		' (get) Token: 0x060128BF RID: 75967 RVA: 0x0007F2DE File Offset: 0x0007D4DE
		' (set) Token: 0x060128C0 RID: 75968 RVA: 0x0007F2E8 File Offset: 0x0007D4E8
		Friend Overridable Property Label3 As Label

		' Token: 0x1700730F RID: 29455
		' (get) Token: 0x060128C1 RID: 75969 RVA: 0x0007F2F1 File Offset: 0x0007D4F1
		' (set) Token: 0x060128C2 RID: 75970 RVA: 0x00AB0520 File Offset: 0x00AAE720
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

		' Token: 0x17007310 RID: 29456
		' (get) Token: 0x060128C3 RID: 75971 RVA: 0x0007F2FB File Offset: 0x0007D4FB
		' (set) Token: 0x060128C4 RID: 75972 RVA: 0x0007F305 File Offset: 0x0007D505
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17007311 RID: 29457
		' (get) Token: 0x060128C5 RID: 75973 RVA: 0x0007F30E File Offset: 0x0007D50E
		' (set) Token: 0x060128C6 RID: 75974 RVA: 0x0007F318 File Offset: 0x0007D518
		Friend Overridable Property Label1 As Label

		' Token: 0x17007312 RID: 29458
		' (get) Token: 0x060128C7 RID: 75975 RVA: 0x0007F321 File Offset: 0x0007D521
		' (set) Token: 0x060128C8 RID: 75976 RVA: 0x0007F32B File Offset: 0x0007D52B
		Friend Overridable Property Label7 As Label

		' Token: 0x17007313 RID: 29459
		' (get) Token: 0x060128C9 RID: 75977 RVA: 0x0007F334 File Offset: 0x0007D534
		' (set) Token: 0x060128CA RID: 75978 RVA: 0x0007F33E File Offset: 0x0007D53E
		Friend Overridable Property Label6 As Label

		' Token: 0x17007314 RID: 29460
		' (get) Token: 0x060128CB RID: 75979 RVA: 0x0007F347 File Offset: 0x0007D547
		' (set) Token: 0x060128CC RID: 75980 RVA: 0x0007F351 File Offset: 0x0007D551
		Friend Overridable Property Label5 As Label

		' Token: 0x17007315 RID: 29461
		' (get) Token: 0x060128CD RID: 75981 RVA: 0x0007F35A File Offset: 0x0007D55A
		' (set) Token: 0x060128CE RID: 75982 RVA: 0x00AB0564 File Offset: 0x00AAE764
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

		' Token: 0x17007316 RID: 29462
		' (get) Token: 0x060128CF RID: 75983 RVA: 0x0007F364 File Offset: 0x0007D564
		' (set) Token: 0x060128D0 RID: 75984 RVA: 0x00AB05C4 File Offset: 0x00AAE7C4
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

		' Token: 0x17007317 RID: 29463
		' (get) Token: 0x060128D1 RID: 75985 RVA: 0x0007F36E File Offset: 0x0007D56E
		' (set) Token: 0x060128D2 RID: 75986 RVA: 0x0007F378 File Offset: 0x0007D578
		Friend Overridable Property Label2 As Label

		' Token: 0x17007318 RID: 29464
		' (get) Token: 0x060128D3 RID: 75987 RVA: 0x0007F381 File Offset: 0x0007D581
		' (set) Token: 0x060128D4 RID: 75988 RVA: 0x0007F38B File Offset: 0x0007D58B
		Friend Overridable Property txtID As TextBox

		' Token: 0x17007319 RID: 29465
		' (get) Token: 0x060128D5 RID: 75989 RVA: 0x0007F394 File Offset: 0x0007D594
		' (set) Token: 0x060128D6 RID: 75990 RVA: 0x0007F39E File Offset: 0x0007D59E
		Friend Overridable Property lblUser As Label

		' Token: 0x1700731A RID: 29466
		' (get) Token: 0x060128D7 RID: 75991 RVA: 0x0007F3A7 File Offset: 0x0007D5A7
		' (set) Token: 0x060128D8 RID: 75992 RVA: 0x00AB0608 File Offset: 0x00AAE808
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

		' Token: 0x1700731B RID: 29467
		' (get) Token: 0x060128D9 RID: 75993 RVA: 0x0007F3B1 File Offset: 0x0007D5B1
		' (set) Token: 0x060128DA RID: 75994 RVA: 0x00AB0684 File Offset: 0x00AAE884
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

		' Token: 0x1700731C RID: 29468
		' (get) Token: 0x060128DB RID: 75995 RVA: 0x0007F3BB File Offset: 0x0007D5BB
		' (set) Token: 0x060128DC RID: 75996 RVA: 0x0007F3C5 File Offset: 0x0007D5C5
		Friend Overridable Property Label10 As Label

		' Token: 0x1700731D RID: 29469
		' (get) Token: 0x060128DD RID: 75997 RVA: 0x0007F3CE File Offset: 0x0007D5CE
		' (set) Token: 0x060128DE RID: 75998 RVA: 0x0007F3D8 File Offset: 0x0007D5D8
		Friend Overridable Property Label4 As Label

		' Token: 0x1700731E RID: 29470
		' (get) Token: 0x060128DF RID: 75999 RVA: 0x0007F3E1 File Offset: 0x0007D5E1
		' (set) Token: 0x060128E0 RID: 76000 RVA: 0x00AB0700 File Offset: 0x00AAE900
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

		' Token: 0x1700731F RID: 29471
		' (get) Token: 0x060128E1 RID: 76001 RVA: 0x0007F3EB File Offset: 0x0007D5EB
		' (set) Token: 0x060128E2 RID: 76002 RVA: 0x0007F3F5 File Offset: 0x0007D5F5
		Friend Overridable Property Label12 As Label

		' Token: 0x17007320 RID: 29472
		' (get) Token: 0x060128E3 RID: 76003 RVA: 0x0007F3FE File Offset: 0x0007D5FE
		' (set) Token: 0x060128E4 RID: 76004 RVA: 0x0007F408 File Offset: 0x0007D608
		Friend Overridable Property Label9 As Label

		' Token: 0x17007321 RID: 29473
		' (get) Token: 0x060128E5 RID: 76005 RVA: 0x0007F411 File Offset: 0x0007D611
		' (set) Token: 0x060128E6 RID: 76006 RVA: 0x00AB0760 File Offset: 0x00AAE960
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

		' Token: 0x17007322 RID: 29474
		' (get) Token: 0x060128E7 RID: 76007 RVA: 0x0007F41B File Offset: 0x0007D61B
		' (set) Token: 0x060128E8 RID: 76008 RVA: 0x00AB07A4 File Offset: 0x00AAE9A4
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
				Dim eventHandler As EventHandler = AddressOf Me.cmbState_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbState = value
				comboBox = Me._cmbState
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007323 RID: 29475
		' (get) Token: 0x060128E9 RID: 76009 RVA: 0x0007F425 File Offset: 0x0007D625
		' (set) Token: 0x060128EA RID: 76010 RVA: 0x0007F42F File Offset: 0x0007D62F
		Friend Overridable Property txtSupName As TextBox

		' Token: 0x17007324 RID: 29476
		' (get) Token: 0x060128EB RID: 76011 RVA: 0x0007F438 File Offset: 0x0007D638
		' (set) Token: 0x060128EC RID: 76012 RVA: 0x0007F442 File Offset: 0x0007D642
		Friend Overridable Property txtT_ID As TextBox

		' Token: 0x17007325 RID: 29477
		' (get) Token: 0x060128ED RID: 76013 RVA: 0x0007F44B File Offset: 0x0007D64B
		' (set) Token: 0x060128EE RID: 76014 RVA: 0x0007F455 File Offset: 0x0007D655
		Friend Overridable Property txtTransactionNo As TextBox

		' Token: 0x17007326 RID: 29478
		' (get) Token: 0x060128EF RID: 76015 RVA: 0x0007F45E File Offset: 0x0007D65E
		' (set) Token: 0x060128F0 RID: 76016 RVA: 0x00AB0844 File Offset: 0x00AAEA44
		Private _txtPAN As TextBox
		Friend Overridable Property txtPAN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPAN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtPAN_KeyDown
				Dim textBox As TextBox = Me._txtPAN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtPAN = value
				textBox = Me._txtPAN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007327 RID: 29479
		' (get) Token: 0x060128F1 RID: 76017 RVA: 0x0007F468 File Offset: 0x0007D668
		' (set) Token: 0x060128F2 RID: 76018 RVA: 0x0007F472 File Offset: 0x0007D672
		Friend Overridable Property Label14 As Label

		' Token: 0x17007328 RID: 29480
		' (get) Token: 0x060128F3 RID: 76019 RVA: 0x0007F47B File Offset: 0x0007D67B
		' (set) Token: 0x060128F4 RID: 76020 RVA: 0x0007F485 File Offset: 0x0007D685
		Friend Overridable Property Label8 As Label

		' Token: 0x17007329 RID: 29481
		' (get) Token: 0x060128F5 RID: 76021 RVA: 0x0007F48E File Offset: 0x0007D68E
		' (set) Token: 0x060128F6 RID: 76022 RVA: 0x00AB0888 File Offset: 0x00AAEA88
		Private _txtGSTIN As TextBox
		Friend Overridable Property txtGSTIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtGSTIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtGSTIN_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtGSTIN_TextChanged
				Dim textBox As TextBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtGSTIN = value
				textBox = Me._txtGSTIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700732A RID: 29482
		' (get) Token: 0x060128F7 RID: 76023 RVA: 0x0007F498 File Offset: 0x0007D698
		' (set) Token: 0x060128F8 RID: 76024 RVA: 0x00AB08E8 File Offset: 0x00AAEAE8
		Private _txtCIN As TextBox
		Friend Overridable Property txtCIN As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCIN_KeyDown
				Dim textBox As TextBox = Me._txtCIN
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCIN = value
				textBox = Me._txtCIN
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700732B RID: 29483
		' (get) Token: 0x060128F9 RID: 76025 RVA: 0x0007F4A2 File Offset: 0x0007D6A2
		' (set) Token: 0x060128FA RID: 76026 RVA: 0x0007F4AC File Offset: 0x0007D6AC
		Friend Overridable Property txtSTNo As TextBox

		' Token: 0x1700732C RID: 29484
		' (get) Token: 0x060128FB RID: 76027 RVA: 0x0007F4B5 File Offset: 0x0007D6B5
		' (set) Token: 0x060128FC RID: 76028 RVA: 0x0007F4BF File Offset: 0x0007D6BF
		Friend Overridable Property Label13 As Label

		' Token: 0x1700732D RID: 29485
		' (get) Token: 0x060128FD RID: 76029 RVA: 0x0007F4C8 File Offset: 0x0007D6C8
		' (set) Token: 0x060128FE RID: 76030 RVA: 0x0007F4D2 File Offset: 0x0007D6D2
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700732E RID: 29486
		' (get) Token: 0x060128FF RID: 76031 RVA: 0x0007F4DB File Offset: 0x0007D6DB
		' (set) Token: 0x06012900 RID: 76032 RVA: 0x00AB092C File Offset: 0x00AAEB2C
		Private _txtBank As TextBox
		Public Overridable Property txtBank As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBank
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBank_KeyDown
				Dim textBox As TextBox = Me._txtBank
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBank = value
				textBox = Me._txtBank
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700732F RID: 29487
		' (get) Token: 0x06012901 RID: 76033 RVA: 0x0007F4E5 File Offset: 0x0007D6E5
		' (set) Token: 0x06012902 RID: 76034 RVA: 0x0007F4EF File Offset: 0x0007D6EF
		Friend Overridable Property Label22 As Label

		' Token: 0x17007330 RID: 29488
		' (get) Token: 0x06012903 RID: 76035 RVA: 0x0007F4F8 File Offset: 0x0007D6F8
		' (set) Token: 0x06012904 RID: 76036 RVA: 0x0007F502 File Offset: 0x0007D702
		Friend Overridable Property Label17 As Label

		' Token: 0x17007331 RID: 29489
		' (get) Token: 0x06012905 RID: 76037 RVA: 0x0007F50B File Offset: 0x0007D70B
		' (set) Token: 0x06012906 RID: 76038 RVA: 0x00AB0970 File Offset: 0x00AAEB70
		Private _txtIFSCcode As TextBox
		Public Overridable Property txtIFSCcode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtIFSCcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtIFSCcode_KeyDown
				Dim textBox As TextBox = Me._txtIFSCcode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtIFSCcode = value
				textBox = Me._txtIFSCcode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007332 RID: 29490
		' (get) Token: 0x06012907 RID: 76039 RVA: 0x0007F515 File Offset: 0x0007D715
		' (set) Token: 0x06012908 RID: 76040 RVA: 0x0007F51F File Offset: 0x0007D71F
		Friend Overridable Property Label18 As Label

		' Token: 0x17007333 RID: 29491
		' (get) Token: 0x06012909 RID: 76041 RVA: 0x0007F528 File Offset: 0x0007D728
		' (set) Token: 0x0601290A RID: 76042 RVA: 0x00AB09B4 File Offset: 0x00AAEBB4
		Private _txtBranch As TextBox
		Public Overridable Property txtBranch As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtBranch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtBranch_KeyDown
				Dim textBox As TextBox = Me._txtBranch
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtBranch = value
				textBox = Me._txtBranch
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007334 RID: 29492
		' (get) Token: 0x0601290B RID: 76043 RVA: 0x0007F532 File Offset: 0x0007D732
		' (set) Token: 0x0601290C RID: 76044 RVA: 0x0007F53C File Offset: 0x0007D73C
		Friend Overridable Property Label20 As Label

		' Token: 0x17007335 RID: 29493
		' (get) Token: 0x0601290D RID: 76045 RVA: 0x0007F545 File Offset: 0x0007D745
		' (set) Token: 0x0601290E RID: 76046 RVA: 0x0007F54F File Offset: 0x0007D74F
		Friend Overridable Property Label21 As Label

		' Token: 0x17007336 RID: 29494
		' (get) Token: 0x0601290F RID: 76047 RVA: 0x0007F558 File Offset: 0x0007D758
		' (set) Token: 0x06012910 RID: 76048 RVA: 0x00AB09F8 File Offset: 0x00AAEBF8
		Private _txtAccountNo As TextBox
		Public Overridable Property txtAccountNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAccountNo_KeyDown
				Dim textBox As TextBox = Me._txtAccountNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAccountNo = value
				textBox = Me._txtAccountNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007337 RID: 29495
		' (get) Token: 0x06012911 RID: 76049 RVA: 0x0007F562 File Offset: 0x0007D762
		' (set) Token: 0x06012912 RID: 76050 RVA: 0x00AB0A3C File Offset: 0x00AAEC3C
		Private _txtAccountName As TextBox
		Public Overridable Property txtAccountName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAccountName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtAccountName_KeyDown
				Dim textBox As TextBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtAccountName = value
				textBox = Me._txtAccountName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007338 RID: 29496
		' (get) Token: 0x06012913 RID: 76051 RVA: 0x0007F56C File Offset: 0x0007D76C
		' (set) Token: 0x06012914 RID: 76052 RVA: 0x00AB0A80 File Offset: 0x00AAEC80
		Private _txtOpeningBalance As TextBox
		Friend Overridable Property txtOpeningBalance As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtOpeningBalance
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtOpeningBalance_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtOpeningBalance_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtOpeningBalance
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtOpeningBalance = value
				textBox = Me._txtOpeningBalance
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007339 RID: 29497
		' (get) Token: 0x06012915 RID: 76053 RVA: 0x0007F576 File Offset: 0x0007D776
		' (set) Token: 0x06012916 RID: 76054 RVA: 0x0007F580 File Offset: 0x0007D780
		Friend Overridable Property Label15 As Label

		' Token: 0x1700733A RID: 29498
		' (get) Token: 0x06012917 RID: 76055 RVA: 0x0007F589 File Offset: 0x0007D789
		' (set) Token: 0x06012918 RID: 76056 RVA: 0x00AB0AFC File Offset: 0x00AAECFC
		Private _cmbOpeningBalanceType As ComboBox
		Friend Overridable Property cmbOpeningBalanceType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbOpeningBalanceType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbOpeningBalanceType_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.cmbOpeningBalanceType_MouseHover
				Dim comboBox As ComboBox = Me._cmbOpeningBalanceType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.MouseHover, eventHandler
				End If
				Me._cmbOpeningBalanceType = value
				comboBox = Me._cmbOpeningBalanceType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.MouseHover, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700733B RID: 29499
		' (get) Token: 0x06012919 RID: 76057 RVA: 0x0007F593 File Offset: 0x0007D793
		' (set) Token: 0x0601291A RID: 76058 RVA: 0x00AB0B5C File Offset: 0x00AAED5C
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

		' Token: 0x1700733C RID: 29500
		' (get) Token: 0x0601291B RID: 76059 RVA: 0x0007F59D File Offset: 0x0007D79D
		' (set) Token: 0x0601291C RID: 76060 RVA: 0x00AB0BA0 File Offset: 0x00AAEDA0
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

		' Token: 0x1700733D RID: 29501
		' (get) Token: 0x0601291D RID: 76061 RVA: 0x0007F5A7 File Offset: 0x0007D7A7
		' (set) Token: 0x0601291E RID: 76062 RVA: 0x00AB0BE4 File Offset: 0x00AAEDE4
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

		' Token: 0x1700733E RID: 29502
		' (get) Token: 0x0601291F RID: 76063 RVA: 0x0007F5B1 File Offset: 0x0007D7B1
		' (set) Token: 0x06012920 RID: 76064 RVA: 0x00AB0C28 File Offset: 0x00AAEE28
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

		' Token: 0x1700733F RID: 29503
		' (get) Token: 0x06012921 RID: 76065 RVA: 0x0007F5BB File Offset: 0x0007D7BB
		' (set) Token: 0x06012922 RID: 76066 RVA: 0x00AB0C6C File Offset: 0x00AAEE6C
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

		' Token: 0x17007340 RID: 29504
		' (get) Token: 0x06012923 RID: 76067 RVA: 0x0007F5C5 File Offset: 0x0007D7C5
		' (set) Token: 0x06012924 RID: 76068 RVA: 0x0007F5CF File Offset: 0x0007D7CF
		Public Overridable Property Picture As PictureBox

		' Token: 0x17007341 RID: 29505
		' (get) Token: 0x06012925 RID: 76069 RVA: 0x0007F5D8 File Offset: 0x0007D7D8
		' (set) Token: 0x06012926 RID: 76070 RVA: 0x0007F5E2 File Offset: 0x0007D7E2
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17007342 RID: 29506
		' (get) Token: 0x06012927 RID: 76071 RVA: 0x0007F5EB File Offset: 0x0007D7EB
		' (set) Token: 0x06012928 RID: 76072 RVA: 0x00AB0CB0 File Offset: 0x00AAEEB0
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbSupplierName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.TextChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbSupplierName = value
				comboBox = Me._cmbSupplierName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.TextChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007343 RID: 29507
		' (get) Token: 0x06012929 RID: 76073 RVA: 0x0007F5F5 File Offset: 0x0007D7F5
		' (set) Token: 0x0601292A RID: 76074 RVA: 0x0007F5FF File Offset: 0x0007D7FF
		Friend Overridable Property txtPhNo As TextBox

		' Token: 0x17007344 RID: 29508
		' (get) Token: 0x0601292B RID: 76075 RVA: 0x0007F608 File Offset: 0x0007D808
		' (set) Token: 0x0601292C RID: 76076 RVA: 0x00AB0D2C File Offset: 0x00AAEF2C
		Private _cmbcrlimit As ComboBox
		Friend Overridable Property cmbcrlimit As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbcrlimit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbcrlimit_KeyDown
				Dim comboBox As ComboBox = Me._cmbcrlimit
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbcrlimit = value
				comboBox = Me._cmbcrlimit
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007345 RID: 29509
		' (get) Token: 0x0601292D RID: 76077 RVA: 0x0007F612 File Offset: 0x0007D812
		' (set) Token: 0x0601292E RID: 76078 RVA: 0x0007F61C File Offset: 0x0007D81C
		Friend Overridable Property Label28 As Label

		' Token: 0x17007346 RID: 29510
		' (get) Token: 0x0601292F RID: 76079 RVA: 0x0007F625 File Offset: 0x0007D825
		' (set) Token: 0x06012930 RID: 76080 RVA: 0x00AB0D70 File Offset: 0x00AAEF70
		Private _txtcrlimit As TextBox
		Friend Overridable Property txtcrlimit As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtcrlimit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtcrlimit_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtcrlimit
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtcrlimit = value
				textBox = Me._txtcrlimit
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007347 RID: 29511
		' (get) Token: 0x06012931 RID: 76081 RVA: 0x0007F62F File Offset: 0x0007D82F
		' (set) Token: 0x06012932 RID: 76082 RVA: 0x00AB0DD0 File Offset: 0x00AAEFD0
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

		' Token: 0x17007348 RID: 29512
		' (get) Token: 0x06012933 RID: 76083 RVA: 0x0007F639 File Offset: 0x0007D839
		' (set) Token: 0x06012934 RID: 76084 RVA: 0x00AB0E14 File Offset: 0x00AAF014
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

		' Token: 0x17007349 RID: 29513
		' (get) Token: 0x06012935 RID: 76085 RVA: 0x0007F643 File Offset: 0x0007D843
		' (set) Token: 0x06012936 RID: 76086 RVA: 0x00AB0E58 File Offset: 0x00AAF058
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

		' Token: 0x1700734A RID: 29514
		' (get) Token: 0x06012937 RID: 76087 RVA: 0x0007F64D File Offset: 0x0007D84D
		' (set) Token: 0x06012938 RID: 76088 RVA: 0x00AB0E9C File Offset: 0x00AAF09C
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

		' Token: 0x1700734B RID: 29515
		' (get) Token: 0x06012939 RID: 76089 RVA: 0x0007F657 File Offset: 0x0007D857
		' (set) Token: 0x0601293A RID: 76090 RVA: 0x00AB0EE0 File Offset: 0x00AAF0E0
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

		' Token: 0x1700734C RID: 29516
		' (get) Token: 0x0601293B RID: 76091 RVA: 0x0007F661 File Offset: 0x0007D861
		' (set) Token: 0x0601293C RID: 76092 RVA: 0x00AB0F24 File Offset: 0x00AAF124
		Private _txtSCode As TextBox
		Friend Overridable Property txtSCode As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtSCode_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSCode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSCode
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSCode = value
				textBox = Me._txtSCode
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700734D RID: 29517
		' (get) Token: 0x0601293D RID: 76093 RVA: 0x0007F66B File Offset: 0x0007D86B
		' (set) Token: 0x0601293E RID: 76094 RVA: 0x0007F675 File Offset: 0x0007D875
		Friend Overridable Property Label29 As Label

		' Token: 0x1700734E RID: 29518
		' (get) Token: 0x0601293F RID: 76095 RVA: 0x0007F67E File Offset: 0x0007D87E
		' (set) Token: 0x06012940 RID: 76096 RVA: 0x0007F688 File Offset: 0x0007D888
		Friend Overridable Property CheckBox1 As CheckBox

		' Token: 0x1700734F RID: 29519
		' (get) Token: 0x06012941 RID: 76097 RVA: 0x0007F691 File Offset: 0x0007D891
		' (set) Token: 0x06012942 RID: 76098 RVA: 0x0007F69B File Offset: 0x0007D89B
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17007350 RID: 29520
		' (get) Token: 0x06012943 RID: 76099 RVA: 0x0007F6A4 File Offset: 0x0007D8A4
		' (set) Token: 0x06012944 RID: 76100 RVA: 0x0007F6AE File Offset: 0x0007D8AE
		Friend Overridable Property Label31 As Label

		' Token: 0x17007351 RID: 29521
		' (get) Token: 0x06012945 RID: 76101 RVA: 0x0007F6B7 File Offset: 0x0007D8B7
		' (set) Token: 0x06012946 RID: 76102 RVA: 0x0007F6C1 File Offset: 0x0007D8C1
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17007352 RID: 29522
		' (get) Token: 0x06012947 RID: 76103 RVA: 0x0007F6CA File Offset: 0x0007D8CA
		' (set) Token: 0x06012948 RID: 76104 RVA: 0x0007F6D4 File Offset: 0x0007D8D4
		Friend Overridable Property lbl_Result As Label

		' Token: 0x17007353 RID: 29523
		' (get) Token: 0x06012949 RID: 76105 RVA: 0x0007F6DD File Offset: 0x0007D8DD
		' (set) Token: 0x0601294A RID: 76106 RVA: 0x0007F6E7 File Offset: 0x0007D8E7
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17007354 RID: 29524
		' (get) Token: 0x0601294B RID: 76107 RVA: 0x0007F6F0 File Offset: 0x0007D8F0
		' (set) Token: 0x0601294C RID: 76108 RVA: 0x0007F6FA File Offset: 0x0007D8FA
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17007355 RID: 29525
		' (get) Token: 0x0601294D RID: 76109 RVA: 0x0007F703 File Offset: 0x0007D903
		' (set) Token: 0x0601294E RID: 76110 RVA: 0x00AB0FA0 File Offset: 0x00AAF1A0
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

		' Token: 0x17007356 RID: 29526
		' (get) Token: 0x0601294F RID: 76111 RVA: 0x0007F70D File Offset: 0x0007D90D
		' (set) Token: 0x06012950 RID: 76112 RVA: 0x0007F717 File Offset: 0x0007D917
		Friend Overridable Property lblCode As Label

		' Token: 0x17007357 RID: 29527
		' (get) Token: 0x06012951 RID: 76113 RVA: 0x0007F720 File Offset: 0x0007D920
		' (set) Token: 0x06012952 RID: 76114 RVA: 0x0007F72A File Offset: 0x0007D92A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17007358 RID: 29528
		' (get) Token: 0x06012953 RID: 76115 RVA: 0x0007F733 File Offset: 0x0007D933
		' (set) Token: 0x06012954 RID: 76116 RVA: 0x00AB0FE4 File Offset: 0x00AAF1E4
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

		' Token: 0x17007359 RID: 29529
		' (get) Token: 0x06012955 RID: 76117 RVA: 0x0007F73D File Offset: 0x0007D93D
		' (set) Token: 0x06012956 RID: 76118 RVA: 0x00AB1028 File Offset: 0x00AAF228
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

		' Token: 0x1700735A RID: 29530
		' (get) Token: 0x06012957 RID: 76119 RVA: 0x0007F747 File Offset: 0x0007D947
		' (set) Token: 0x06012958 RID: 76120 RVA: 0x00AB106C File Offset: 0x00AAF26C
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

		' Token: 0x1700735B RID: 29531
		' (get) Token: 0x06012959 RID: 76121 RVA: 0x0007F751 File Offset: 0x0007D951
		' (set) Token: 0x0601295A RID: 76122 RVA: 0x00AB10B0 File Offset: 0x00AAF2B0
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

		' Token: 0x1700735C RID: 29532
		' (get) Token: 0x0601295B RID: 76123 RVA: 0x0007F75B File Offset: 0x0007D95B
		' (set) Token: 0x0601295C RID: 76124 RVA: 0x00AB10F4 File Offset: 0x00AAF2F4
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

		' Token: 0x1700735D RID: 29533
		' (get) Token: 0x0601295D RID: 76125 RVA: 0x0007F765 File Offset: 0x0007D965
		' (set) Token: 0x0601295E RID: 76126 RVA: 0x00AB1138 File Offset: 0x00AAF338
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
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

		' Token: 0x1700735E RID: 29534
		' (get) Token: 0x0601295F RID: 76127 RVA: 0x0007F76F File Offset: 0x0007D96F
		' (set) Token: 0x06012960 RID: 76128 RVA: 0x00AB117C File Offset: 0x00AAF37C
		Private _btnExtract As GelButton
		Friend Overridable Property btnExtract As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExtract
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExtract_Click
				Dim gelButton As GelButton = Me._btnExtract
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExtract = value
				gelButton = Me._btnExtract
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700735F RID: 29535
		' (get) Token: 0x06012961 RID: 76129 RVA: 0x0007F779 File Offset: 0x0007D979
		' (set) Token: 0x06012962 RID: 76130 RVA: 0x0007F783 File Offset: 0x0007D983
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17007360 RID: 29536
		' (get) Token: 0x06012963 RID: 76131 RVA: 0x0007F78C File Offset: 0x0007D98C
		' (set) Token: 0x06012964 RID: 76132 RVA: 0x00AB11C0 File Offset: 0x00AAF3C0
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

		' Token: 0x06012965 RID: 76133 RVA: 0x00AB1204 File Offset: 0x00AAF404
		Public Sub Reset()
			Me.fillSupplierName()
			Me.cmbSupplierName.Text = ""
			Me.cmbSupplierName.SelectedIndex = -1
			Me.txtAddress.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbSupplierName.Text = ""
			Me.txtSupplierID.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtEmailID.Text = ""
			Me.cmbState.SelectedIndex = -1
			Me.txtZipCode.Text = ""
			Me.txtCity.Text = ""
			Me.cmbSupplierName.Focus()
			Me.txtGSTIN.Text = ""
			Me.txtPAN.Text = ""
			Me.txtCIN.Text = ""
			Me.txtSTNo.Text = ""
			Me.txtAccountName.Text = ""
			Me.txtAccountNo.Text = ""
			Me.txtBank.Text = ""
			Me.txtBranch.Text = ""
			Me.txtIFSCcode.Text = ""
			Me.Picture.Image = Resources.photo
			Me.cmbOpeningBalanceType.SelectedIndex = 0
			Me.txtOpeningBalance.Text = "0.00"
			Me.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDownList
			Me.cmbOpeningBalanceType.Enabled = True
			Me.txtOpeningBalance.[ReadOnly] = False
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.auto()
			Me.txtPhNo.Text = ""
			Me.txtcrlimit.Text = "0.00"
			Me.cmbcrlimit.SelectedIndex = 0
			Me.txtSCode.Text = ""
			Me.CheckBox1.Checked = True
			Me.cmbNP.SelectedIndex = -1
		End Sub

		' Token: 0x06012966 RID: 76134 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06012967 RID: 76135 RVA: 0x00124674 File Offset: 0x00122874
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Supplier ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06012968 RID: 76136 RVA: 0x00AB1450 File Offset: 0x00AAF650
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtSupplierID.Text = "S-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012969 RID: 76137 RVA: 0x00AB14C4 File Offset: 0x00AAF6C4
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT Supplier.ID FROM Supplier INNER JOIN PurchaseOrder ON Supplier.ID = PurchaseOrder.SupplierID where Supplier.ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Purchase order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "SELECT Supplier.ID FROM Supplier INNER JOIN Stock ON Supplier.ID = Stock.SupplierID where Supplier.ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
					If flag3 Then
						MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						ModCommonClasses.con.Close()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "SELECT RTRIM(CSID) FROM Journal where CSID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text.ToString())
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
						If flag5 Then
							MessageBox.Show("Unable to delete..Already in use in Journal Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag6 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "SELECT Supplier.ID FROM Supplier INNER JOIN Payment ON Supplier.ID = Payment.SupplierID where Supplier.ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Unable to delete..Already in use in Payment Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text5 As String = If(("delete from Supplier where ID =" + Me.txtID.Text), "")
								ModCommonClasses.cmd = New SqlCommand(text5)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
								Dim flag9 As Boolean = num > 0
								If flag9 Then
									ModFunc.LedgerDelete(Me.txtSupplierID.Text, "Opening Balance")
									ModFunc.SupplierLedgerDelete(Me.txtSupplierID.Text)
									ModFunc.LogFunc(Me.lblUser.Text, "deleted the supplier record having supplier id '" + Me.txtSupplierID.Text + "'")
									MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.Reset()
								Else
									MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.Reset()
									Dim flag10 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
									If flag10 Then
										ModCommonClasses.con.Close()
									End If
									ModCommonClasses.con.Close()
								End If
								Me.DataforNP()
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601296A RID: 76138 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbState_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0601296B RID: 76139 RVA: 0x00AB194C File Offset: 0x00AAFB4C
		Private Sub txtOpeningBalance_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtOpeningBalance.Text
					Dim selectionStart As Integer = Me.txtOpeningBalance.SelectionStart
					Dim selectionLength As Integer = Me.txtOpeningBalance.SelectionLength
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

		' Token: 0x0601296C RID: 76140 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0601296D RID: 76141 RVA: 0x00AB1A44 File Offset: 0x00AAFC44
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

		' Token: 0x0601296E RID: 76142 RVA: 0x00AB1B4C File Offset: 0x00AAFD4C
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
			Dim text As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
			Dim match As Match = Regex.Match(Me.txtEmailID.Text.Trim(), text, RegexOptions.IgnoreCase)
			Dim success As Boolean = match.Success
			If Not success Then
				MessageBox.Show("Please enter a valid email id", "Checking")
				Me.txtEmailID.Clear()
			End If
		End Sub

		' Token: 0x0601296F RID: 76143 RVA: 0x00AB1BA4 File Offset: 0x00AAFDA4
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.FrmValidate.TBoxGSTIN.Text = Me.txtGSTIN.Text
			MyProject.Forms.FrmValidate.Button1.Visible = True
			MyProject.Forms.FrmValidate.ShowDialog()
		End Sub

		' Token: 0x06012970 RID: 76144 RVA: 0x00AB1BF8 File Offset: 0x00AAFDF8
		Private Sub txtSuplNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06012971 RID: 76145 RVA: 0x00AB1BF8 File Offset: 0x00AAFDF8
		Private Sub cmbSupplierName_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06012972 RID: 76146 RVA: 0x00AB1BF8 File Offset: 0x00AAFDF8
		Private Sub txtSupplierID_TextChanged(sender As Object, e As EventArgs)
			Me.txtSuplNameId.Text = Me.cmbSupplierName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtSupplierID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06012973 RID: 76147 RVA: 0x0007F796 File Offset: 0x0007D996
		Private Sub frmSupplier_Load(sender As Object, e As EventArgs)
			Me.LinkLabel1.TabStop = False
			Me.fillSupplierName()
			Me.DataforNP()
			Me.fillSupplierID()
			Me.Convert_Language()
			Me.GetApiDtl()
		End Sub

		' Token: 0x06012974 RID: 76148 RVA: 0x00AB1C48 File Offset: 0x00AAFE48
		Public Sub GetApiDtl()
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "select * from tbl_api_setting where isDefault='Yes' and isEnabled='Yes' "
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count > 0
			If flag Then
				Me.apiKey = dataTable.Rows(0)(2).ToString()
				Me.url = dataTable.Rows(0)(1).ToString()
			End If
			sqlConnection.Close()
		End Sub

		' Token: 0x06012975 RID: 76149 RVA: 0x00AB1CDC File Offset: 0x00AAFEDC
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06012976 RID: 76150 RVA: 0x00AB1E4C File Offset: 0x00AB004C
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

		' Token: 0x06012977 RID: 76151 RVA: 0x00AB1F08 File Offset: 0x00AB0108
		Public Sub fillSupplierName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Supplier", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbSupplierName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbSupplierName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06012978 RID: 76152 RVA: 0x00AB203C File Offset: 0x00AB023C
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

		' Token: 0x06012979 RID: 76153 RVA: 0x0007F7C9 File Offset: 0x0007D9C9
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources.photo
		End Sub

		' Token: 0x0601297A RID: 76154 RVA: 0x00AB20DC File Offset: 0x00AB02DC
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

		' Token: 0x0601297B RID: 76155 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601297C RID: 76156 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601297D RID: 76157 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCity_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601297E RID: 76158 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601297F RID: 76159 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtZipCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012980 RID: 76160 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012981 RID: 76161 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012982 RID: 76162 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012983 RID: 76163 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012984 RID: 76164 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPAN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012985 RID: 76165 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtOpeningBalance_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012986 RID: 76166 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbOpeningBalanceType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012987 RID: 76167 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012988 RID: 76168 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtcrlimit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012989 RID: 76169 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbcrlimit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298A RID: 76170 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298B RID: 76171 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298C RID: 76172 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298D RID: 76173 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBranch_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298E RID: 76174 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIFSCcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601298F RID: 76175 RVA: 0x00AB2134 File Offset: 0x00AB0334
		Public Sub fillSupplierID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(ID) FROM Supplier order by ID ASC", ModCommonClasses.con)
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

		' Token: 0x06012990 RID: 76176 RVA: 0x00AB2270 File Offset: 0x00AB0470
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(SupplierID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),OpeningBalance,RTRIM(OpeningBalanceType),RTRIM(Remarks),Photo,RTRIM(Limit),RTRIM(Lstatus),RTRIM(SCode) from Supplier where ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Me.chkvalid()
					Me.txtID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtSupplierID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.cmbSupplierName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtSupName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtAddress.Text = ModCommonClasses.rdr.GetValue(3).ToString()
					Me.txtCity.Text = ModCommonClasses.rdr.GetValue(4).ToString()
					Me.cmbState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
					Me.txtZipCode.Text = ModCommonClasses.rdr.GetValue(6).ToString()
					Me.txtContactNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtPhNo.Text = ModCommonClasses.rdr.GetValue(7).ToString()
					Me.txtEmailID.Text = ModCommonClasses.rdr.GetValue(8).ToString()
					Me.txtGSTIN.Text = ModCommonClasses.rdr.GetValue(9).ToString()
					Me.txtCIN.Text = ModCommonClasses.rdr.GetValue(10).ToString()
					Me.txtPAN.Text = ModCommonClasses.rdr.GetValue(11).ToString()
					Me.txtAccountName.Text = ModCommonClasses.rdr.GetValue(12).ToString()
					Me.txtAccountNo.Text = ModCommonClasses.rdr.GetValue(13).ToString()
					Me.txtBank.Text = ModCommonClasses.rdr.GetValue(14).ToString()
					Me.txtBranch.Text = ModCommonClasses.rdr.GetValue(15).ToString()
					Me.txtIFSCcode.Text = ModCommonClasses.rdr.GetValue(16).ToString()
					Me.txtOpeningBalance.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
					Me.cmbOpeningBalanceType.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.txtcrlimit.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.cmbcrlimit.Text = ModCommonClasses.rdr.GetValue(22).ToString()
					Me.txtSCode.Text = ModCommonClasses.rdr.GetValue(23).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(20), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012991 RID: 76177 RVA: 0x0007F7DD File Offset: 0x0007D9DD
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06012992 RID: 76178 RVA: 0x00AB267C File Offset: 0x00AB087C
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Supplier", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Supplier")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Supplier").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x06012993 RID: 76179 RVA: 0x00AB2758 File Offset: 0x00AB0958
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

		' Token: 0x06012994 RID: 76180 RVA: 0x00AB2814 File Offset: 0x00AB0A14
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

		' Token: 0x06012995 RID: 76181 RVA: 0x00AB28C0 File Offset: 0x00AB0AC0
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Supplier").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Supplier").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012996 RID: 76182 RVA: 0x00AB2978 File Offset: 0x00AB0B78
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Supplier").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012997 RID: 76183 RVA: 0x00AB2A10 File Offset: 0x00AB0C10
		Private Sub txtSCode_KeyPress(sender As Object, e As KeyPressEventArgs)
			Me.txtSCode.MaxLength = 4
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				e.Handled = False
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					e.Handled = False
				End If
			End If
		End Sub

		' Token: 0x06012998 RID: 76184 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtSCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012999 RID: 76185 RVA: 0x0007F7F5 File Offset: 0x0007D9F5
		Private Sub frmSupplier_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmSupplierRecord.Reset()
		End Sub

		' Token: 0x0601299A RID: 76186 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplier_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601299B RID: 76187 RVA: 0x00AB2A60 File Offset: 0x00AB0C60
		Public Sub chkvalid()
			Dim flag As Boolean = Operators.CompareString(Me.Label31.Text, "Admin", False) = 0 OrElse Operators.CompareString(Me.Label31.Text, "Moderator", False) = 0
			If flag Then
				Me.txtOpeningBalance.[ReadOnly] = False
				Me.cmbOpeningBalanceType.Enabled = True
			Else
				Me.txtOpeningBalance.[ReadOnly] = True
				Me.cmbOpeningBalanceType.Enabled = False
			End If
		End Sub

		' Token: 0x0601299C RID: 76188 RVA: 0x00AB2AE0 File Offset: 0x00AB0CE0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSCode.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSCode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSCode, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtCity.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtCity, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCity, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtAddress.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAddress, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbSupplierName.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbSupplierName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbSupplierName, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.cmbState.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.cmbState, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbState, String.Empty)
			End If
			Dim flag7 As Boolean = String.IsNullOrEmpty(Me.txtOpeningBalance.Text.Trim())
			If flag7 Then
				Me.ErrorProvider1.SetError(Me.txtOpeningBalance, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtOpeningBalance, String.Empty)
			End If
			Dim flag8 As Boolean = String.IsNullOrEmpty(Me.txtcrlimit.Text.Trim())
			If flag8 Then
				Me.ErrorProvider1.SetError(Me.txtcrlimit, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtcrlimit, String.Empty)
			End If
		End Sub

		' Token: 0x0601299D RID: 76189 RVA: 0x00AB2D58 File Offset: 0x00AB0F58
		Private Async Sub txtGSTIN_TextChanged(sender As Object, e As EventArgs)
			Dim validator As GSTINValidator = New GSTINValidator()
			Try
				Dim result As Dictionary(Of String, String) = Await validator.ValidateGSTINAsync(Me.txtGSTIN.Text)
				If Not result.ContainsKey("Error") Then
					Dim dictionary As Dictionary(Of String, String) = result
					Dim text As String = "State"
					Dim text2 As String = ""
					Dim strState As String = If(dictionary.TryGetValue(text, text2), result("State"), "NA")
					If Operators.CompareString(strState, "Not Available", False) <> 0 Then
						Me.lbl_Result.ForeColor = Color.Green
						Me.lbl_Result.Text = "Valid GSTIN."
					End If
				End If
			Catch ex As Exception
				Me.lbl_Result.ForeColor = Color.Red
				Me.lbl_Result.Text = ex.Message
			End Try
		End Sub

		' Token: 0x0601299E RID: 76190 RVA: 0x00AB2DA0 File Offset: 0x00AB0FA0
		Private Sub cmbOpeningBalanceType_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.cmbOpeningBalanceType, "'CR' for Payable Amount to Supplier" & vbCrLf & "'DR' for Receivable Amount from Supplier")
		End Sub

		' Token: 0x0601299F RID: 76191 RVA: 0x0007F808 File Offset: 0x0007DA08
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Me.code_generate()
		End Sub

		' Token: 0x060129A0 RID: 76192 RVA: 0x00AB2DF0 File Offset: 0x00AB0FF0
		Public Sub code_generate()
			Dim text As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			Dim text2 As String = Me.cmbSupplierName.Text.ToString()
			Dim text3 As String = DateAndTime.Now.ToString("ss")
			Dim text4 As String = text3
			text4 = text4 + Convert.ToString(text + text2) + text3
			Dim num As Integer = Integer.Parse(Conversions.ToString(4))
			Dim text5 As String = String.Empty
			Dim num2 As Integer = num - 1
			For i As Integer = 0 To num2
				Dim text6 As String = String.Empty
				Do
					Dim num3 As Integer = New Random().[Next](0, text4.Length)
					text6 = text4.ToCharArray()(num3).ToString()
				Loop While text5.IndexOf(text6) <> -1
				text5 += text6
			Next
			Me.txtSCode.Text = text5
		End Sub

		' Token: 0x060129A1 RID: 76193 RVA: 0x00AB2EC8 File Offset: 0x00AB10C8
		Public Sub strsatecondition()
			Dim flag As Boolean = Operators.CompareString(Me.cmbState.Text, "Andaman and Nicobar Islands", False) = 0
			If flag Then
				Me.lblCode.Text = "(Code : 35)"
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.cmbState.Text, "Andhra Pradesh", False) = 0
				If flag2 Then
					Me.lblCode.Text = "(Code : 37)"
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.cmbState.Text, "Arunachal Pradesh", False) = 0
					If flag3 Then
						Me.lblCode.Text = "(Code : 12)"
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.cmbState.Text, "Assam", False) = 0
						If flag4 Then
							Me.lblCode.Text = "(Code : 18)"
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.cmbState.Text, "Bihar", False) = 0
							If flag5 Then
								Me.lblCode.Text = "(Code : 10)"
							Else
								Dim flag6 As Boolean = Operators.CompareString(Me.cmbState.Text, "Chandigarh", False) = 0
								If flag6 Then
									Me.lblCode.Text = "(Code : 4)"
								Else
									Dim flag7 As Boolean = Operators.CompareString(Me.cmbState.Text, "Chhattisgarh", False) = 0
									If flag7 Then
										Me.lblCode.Text = "(Code : 22)"
									Else
										Dim flag8 As Boolean = Operators.CompareString(Me.cmbState.Text, "Dadra and Nagar Haveli and Daman and Diu", False) = 0
										If flag8 Then
											Me.lblCode.Text = "(Code : 26)"
										Else
											Dim flag9 As Boolean = Operators.CompareString(Me.cmbState.Text, "Delhi", False) = 0
											If flag9 Then
												Me.lblCode.Text = "(Code : 7)"
											Else
												Dim flag10 As Boolean = Operators.CompareString(Me.cmbState.Text, "Goa", False) = 0
												If flag10 Then
													Me.lblCode.Text = "(Code : 30)"
												Else
													Dim flag11 As Boolean = Operators.CompareString(Me.cmbState.Text, "Gujarat", False) = 0
													If flag11 Then
														Me.lblCode.Text = "(Code : 24)"
													Else
														Dim flag12 As Boolean = Operators.CompareString(Me.cmbState.Text, "Haryana", False) = 0
														If flag12 Then
															Me.lblCode.Text = "(Code : 6)"
														Else
															Dim flag13 As Boolean = Operators.CompareString(Me.cmbState.Text, "Himachal Pradesh", False) = 0
															If flag13 Then
																Me.lblCode.Text = "(Code : 2)"
															Else
																Dim flag14 As Boolean = Operators.CompareString(Me.cmbState.Text, "Jammu and Kashmir", False) = 0
																If flag14 Then
																	Me.lblCode.Text = "(Code : 1)"
																Else
																	Dim flag15 As Boolean = Operators.CompareString(Me.cmbState.Text, "Jharkhand", False) = 0
																	If flag15 Then
																		Me.lblCode.Text = "(Code : 20)"
																	Else
																		Dim flag16 As Boolean = Operators.CompareString(Me.cmbState.Text, "Karnataka", False) = 0
																		If flag16 Then
																			Me.lblCode.Text = "(Code : 29)"
																		Else
																			Dim flag17 As Boolean = Operators.CompareString(Me.cmbState.Text, "Kerala", False) = 0
																			If flag17 Then
																				Me.lblCode.Text = "(Code : 32)"
																			Else
																				Dim flag18 As Boolean = Operators.CompareString(Me.cmbState.Text, "Ladakh", False) = 0
																				If flag18 Then
																					Me.lblCode.Text = "(Code : 38)"
																				Else
																					Dim flag19 As Boolean = Operators.CompareString(Me.cmbState.Text, "Lakshadweep", False) = 0
																					If flag19 Then
																						Me.lblCode.Text = "(Code : 31)"
																					Else
																						Dim flag20 As Boolean = Operators.CompareString(Me.cmbState.Text, "Madhya Pradesh", False) = 0
																						If flag20 Then
																							Me.lblCode.Text = "(Code : 23)"
																						Else
																							Dim flag21 As Boolean = Operators.CompareString(Me.cmbState.Text, "Maharashtra", False) = 0
																							If flag21 Then
																								Me.lblCode.Text = "(Code : 27)"
																							Else
																								Dim flag22 As Boolean = Operators.CompareString(Me.cmbState.Text, "Manipur", False) = 0
																								If flag22 Then
																									Me.lblCode.Text = "(Code : 14)"
																								Else
																									Dim flag23 As Boolean = Operators.CompareString(Me.cmbState.Text, "Meghalaya", False) = 0
																									If flag23 Then
																										Me.lblCode.Text = "(Code : 17)"
																									Else
																										Dim flag24 As Boolean = Operators.CompareString(Me.cmbState.Text, "Mizoram", False) = 0
																										If flag24 Then
																											Me.lblCode.Text = "(Code : 15)"
																										Else
																											Dim flag25 As Boolean = Operators.CompareString(Me.cmbState.Text, "Nagaland", False) = 0
																											If flag25 Then
																												Me.lblCode.Text = "(Code : 13)"
																											Else
																												Dim flag26 As Boolean = Operators.CompareString(Me.cmbState.Text, "Odisha", False) = 0
																												If flag26 Then
																													Me.lblCode.Text = "(Code : 21)"
																												Else
																													Dim flag27 As Boolean = Operators.CompareString(Me.cmbState.Text, "Puducherry", False) = 0
																													If flag27 Then
																														Me.lblCode.Text = "(Code : 34)"
																													Else
																														Dim flag28 As Boolean = Operators.CompareString(Me.cmbState.Text, "Punjab", False) = 0
																														If flag28 Then
																															Me.lblCode.Text = "(Code : 3)"
																														Else
																															Dim flag29 As Boolean = Operators.CompareString(Me.cmbState.Text, "Rajasthan", False) = 0
																															If flag29 Then
																																Me.lblCode.Text = "(Code : 8)"
																															Else
																																Dim flag30 As Boolean = Operators.CompareString(Me.cmbState.Text, "Sikkim", False) = 0
																																If flag30 Then
																																	Me.lblCode.Text = "(Code : 11)"
																																Else
																																	Dim flag31 As Boolean = Operators.CompareString(Me.cmbState.Text, "Tamil Nadu", False) = 0
																																	If flag31 Then
																																		Me.lblCode.Text = "(Code : 33)"
																																	Else
																																		Dim flag32 As Boolean = Operators.CompareString(Me.cmbState.Text, "Telangana", False) = 0
																																		If flag32 Then
																																			Me.lblCode.Text = "(Code : 36)"
																																		Else
																																			Dim flag33 As Boolean = Operators.CompareString(Me.cmbState.Text, "Tripura", False) = 0
																																			If flag33 Then
																																				Me.lblCode.Text = "(Code : 16)"
																																			Else
																																				Dim flag34 As Boolean = Operators.CompareString(Me.cmbState.Text, "Uttar Pradesh", False) = 0
																																				If flag34 Then
																																					Me.lblCode.Text = "(Code : 9)"
																																				Else
																																					Dim flag35 As Boolean = Operators.CompareString(Me.cmbState.Text, "Uttarakhand", False) = 0
																																					If flag35 Then
																																						Me.lblCode.Text = "(Code : 5)"
																																					Else
																																						Dim flag36 As Boolean = Operators.CompareString(Me.cmbState.Text, "West Bengal", False) = 0
																																						If flag36 Then
																																							Me.lblCode.Text = "(Code : 19)"
																																						Else
																																							Dim flag37 As Boolean = Operators.CompareString(Me.cmbState.Text, "Other Territory", False) = 0
																																							If flag37 Then
																																								Me.lblCode.Text = "(Code : 97)"
																																							Else
																																								Me.lblCode.Text = ""
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

		' Token: 0x060129A2 RID: 76194 RVA: 0x0007F812 File Offset: 0x0007DA12
		Private Sub cmbState_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.strsatecondition()
		End Sub

		' Token: 0x060129A3 RID: 76195 RVA: 0x00AB36A8 File Offset: 0x00AB18A8
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbSupplierName.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim reportDocument As ReportDocument = New rptSupplierEnvolve()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text15"), TextObject)
				textObject.Text = Me.cmbSupplierName.Text
				Dim textObject2 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text16"), TextObject)
				textObject2.Text = Me.txtAddress.Text
				Dim textObject3 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text17"), TextObject)
				textObject3.Text = Me.cmbState.Text
				Dim textObject4 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text18"), TextObject)
				textObject4.Text = "PIN :" + Me.txtZipCode.Text
				Dim textObject5 As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text20"), TextObject)
				textObject5.Text = "Contact :" + Me.txtContactNo.Text
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x060129A4 RID: 76196 RVA: 0x00AB3864 File Offset: 0x00AB1A64
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim frmSupplierRecord As frmSupplierRecord = New frmSupplierRecord()
			frmSupplierRecord.lblSet.Text = "Supplier Entry"
			frmSupplierRecord.Getdata()
			frmSupplierRecord.ShowDialog()
			frmSupplierRecord.Dispose()
		End Sub

		' Token: 0x060129A5 RID: 76197 RVA: 0x00AB38A0 File Offset: 0x00AB1AA0
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

		' Token: 0x060129A6 RID: 76198 RVA: 0x00AB3908 File Offset: 0x00AB1B08
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbSupplierName.Focus()
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
								Dim flag6 As Boolean = Operators.CompareString(Me.txtSCode.Text, "", False) = 0
								If flag6 Then
									MessageBox.Show("Please fill supplier's code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtSCode.Focus()
								Else
									Try
										Dim flag7 As Boolean = Operators.CompareString(Me.txtSupName.Text, Me.cmbSupplierName.Text, False) = 0
										If Not flag7 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = "select RTRIM(Name) from Supplier where Name=@d1"
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.cmbSupplierName.Focus()
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
												Return
											End If
											ModCommonClasses.con.Close()
										End If
										Dim flag10 As Boolean = Operators.CompareString(Me.txtPhNo.Text, Me.txtContactNo.Text, False) = 0
										If Not flag10 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "select RTRIM(ContactNo) from Supplier where ContactNo=@d1"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
											If flag11 Then
												MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.txtContactNo.Focus()
												Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag12 Then
													ModCommonClasses.rdr.Close()
												End If
												Return
											End If
											ModCommonClasses.con.Close()
										End If
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "update LedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSupName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSupplierName.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text4 As String = "update SupplierLedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
										ModCommonClasses.cmd = New SqlCommand(text4)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSupName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSupplierName.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text5 As String = "update SupplierLedgerBook set SuplNameid=@d3 where PartyID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text5)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtSuplNameId.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text6 As String = "update Journal set Name=@d3 where CSID=@d1 and Name=@d2"
										ModCommonClasses.cmd = New SqlCommand(text6)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSupName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSupplierName.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text7 As String = "update supplier set SupplierID=@d2,[Name]=@d3, Address=@d5,City=@d6, ContactNo=@d7, EmailID=@d8,Remarks=@d9,State=@d10,ZipCode=@d11,GSTIN=@d12,CIN=@d14,PAN=@d15,AccountName=@d16,AccountNumber=@d17,Bank=@d18,Branch=@d19,IFSCCode=@d20,Photo=@d21,Limit=@d22,Lstatus=@d23,SCode=@d24,OpeningBalance=@d25,OpeningBalanceType=@d26 where ID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text7)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSupplierID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSupplierName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtAddress.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCity.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtContactNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtEmailID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtRemarks.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbState.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtZipCode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtGSTIN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtCIN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtPAN.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtAccountName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtAccountNo.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtBank.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.txtBranch.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.txtIFSCcode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(Me.txtcrlimit.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.cmbcrlimit.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.txtSCode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.txtOpeningBalance.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbOpeningBalanceType.Text)
										Dim memoryStream As MemoryStream = New MemoryStream()
										Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
										bitmap.Save(memoryStream, ImageFormat.Jpeg)
										Dim buffer As Byte() = memoryStream.GetBuffer()
										Dim sqlParameter As SqlParameter = New SqlParameter("@d21", SqlDbType.Image)
										sqlParameter.Value = buffer
										ModCommonClasses.cmd.Parameters.Add(sqlParameter)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModFunc.LogFunc(Me.lblUser.Text, "updated the supplier having supplier id '" + Me.txtSupplierID.Text + "'")
										MessageBox.Show("Successfully Updated", "Supplier Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.fillSupplierID()
										Me.btnUpdate.Enabled = False
										ModCommonClasses.con.Close()
										Me.fillSupplierName()
										Me.txtPhNo.Text = ""
										Dim flag13 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 0
										If flag13 Then
											ModFunc.LedgerUpdate1(Me.cmbSupplierName.Text, 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance")
											ModFunc.SupplierLedgerUpdate1(Me.cmbSupplierName.Text, 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtSuplNameId.Text, Me.txtRemarks.Text, Me.txtSupplierID.Text, "Opening Balance")
										End If
										Dim flag14 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 1
										If flag14 Then
											ModFunc.LedgerUpdate1(Me.cmbSupplierName.Text, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance")
											ModFunc.SupplierLedgerUpdate1(Me.cmbSupplierName.Text, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtSuplNameId.Text, Me.txtRemarks.Text, Me.txtSupplierID.Text, "Opening Balance")
										End If
										Me.DataforNP()
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

		' Token: 0x060129A7 RID: 76199 RVA: 0x00AB4510 File Offset: 0x00AB2710
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Supplier having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag3 Then
						ModCommonClasses.rdr.Close()
					End If
					MessageBox.Show("You are not allowed to enter more than 5 entry in trial version, Please buy register version to use without any limitation." & vbCrLf & "Thank You !", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Return
				End If
				ModCommonClasses.con.Close()
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
				ModCommonClasses.con.Close()
			Else
				Me.auto()
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbSupplierName.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please enter supplier name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbSupplierName.Focus()
				Else
					Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtAddress.Text)) = 0
					If flag7 Then
						MessageBox.Show("Please Enter Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAddress.Focus()
					Else
						Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtCity.Text)) = 0
						If flag8 Then
							MessageBox.Show("Please Enter City", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtCity.Focus()
						Else
							Dim flag9 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
							If flag9 Then
								MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbState.Focus()
							Else
								Dim flag10 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
								If flag10 Then
									MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtContactNo.Focus()
								Else
									Dim flag11 As Boolean = Strings.Len(Strings.Trim(Me.txtOpeningBalance.Text)) = 0
									If flag11 Then
										MessageBox.Show("Please Enter Opening Balance", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.txtOpeningBalance.Focus()
									Else
										Dim flag12 As Boolean = Operators.CompareString(Me.txtSCode.Text, "", False) = 0
										If flag12 Then
											Me.code_generate()
										End If
										Try
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text3 As String = "select RTRIM(Name) from Supplier where Name=@d1"
											ModCommonClasses.cmd = New SqlCommand(text3)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbSupplierName.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
											If flag13 Then
												MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.cmbSupplierName.Focus()
												Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag14 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text4 As String = "select RTRIM(SCode) from Supplier where SCode=@d1"
												ModCommonClasses.cmd = New SqlCommand(text4)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSCode.Text.ToString())
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
												If flag15 Then
													MessageBox.Show("Duplicate Supplier Code Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.txtSCode.Focus()
													Dim flag16 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag16 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text5 As String = "select RTRIM(ContactNo) from Supplier where ContactNo=@d1"
													ModCommonClasses.cmd = New SqlCommand(text5)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag17 As Boolean = ModCommonClasses.rdr.Read()
													If flag17 Then
														MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Me.txtContactNo.Focus()
														Dim flag18 As Boolean = ModCommonClasses.rdr IsNot Nothing
														If flag18 Then
															ModCommonClasses.rdr.Close()
														End If
													Else
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text6 As String = "insert into Supplier(ID, SupplierID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,OpeningBalance,OpeningBalanceType,Photo,Limit,Lstatus,SCode) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26)"
														ModCommonClasses.cmd = New SqlCommand(text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSupplierID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbSupplierName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtAddress.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtCity.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtContactNo.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.txtEmailID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.txtRemarks.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.cmbState.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtZipCode.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.txtGSTIN.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.txtCIN.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Me.txtPAN.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.txtAccountName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d17", Me.txtAccountNo.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d18", Me.txtBank.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d19", Me.txtBranch.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d20", Me.txtIFSCcode.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtOpeningBalance.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Me.cmbOpeningBalanceType.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Conversion.Val(Me.txtcrlimit.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Me.cmbcrlimit.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.txtSCode.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														Dim memoryStream As MemoryStream = New MemoryStream()
														Dim bitmap As Bitmap = New Bitmap(Me.Picture.Image)
														bitmap.Save(memoryStream, ImageFormat.Jpeg)
														Dim buffer As Byte() = memoryStream.GetBuffer()
														Dim sqlParameter As SqlParameter = New SqlParameter("@d23", SqlDbType.Image)
														sqlParameter.Value = buffer
														ModCommonClasses.cmd.Parameters.Add(sqlParameter)
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														Me.DataforNP()
														Dim flag19 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 0
														If flag19 Then
															ModFunc.LedgerSave(DateAndTime.Today, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
															ModFunc.SupplierLedgerSave(DateAndTime.Today, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														End If
														Dim flag20 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 1
														If flag20 Then
															ModFunc.LedgerSave(DateAndTime.Today, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtSupplierID.Text, Me.cmbSupplierName.Text)
															ModFunc.SupplierLedgerSave(DateAndTime.Today, Me.cmbSupplierName.Text, Me.txtSupplierID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtSupplierID.Text, Me.txtSuplNameId.Text, Me.txtRemarks.Text)
														End If
														ModFunc.LogFunc(Me.lblUser.Text, "added the new supplier having supplier id '" + Me.txtSupplierID.Text + "'")
														MessageBox.Show("Successfully Saved", "Supplier Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.fillSupplierID()
														Me.btnSave.Enabled = False
														Me.fillSupplierName()
														Me.txtPhNo.Text = ""
													End If
												End If
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
			End If
		End Sub

		' Token: 0x060129A8 RID: 76200 RVA: 0x0007F81C File Offset: 0x0007DA1C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060129A9 RID: 76201 RVA: 0x00AB50A0 File Offset: 0x00AB32A0
		Private Async Sub btnExtract_Click(sender As Object, e As EventArgs)
			Dim ofd As OpenFileDialog = New OpenFileDialog()
			ofd.Filter = "Supported Files|*.pdf;*.jpg;*.jpeg;*.png"
			Dim flag As Boolean = ofd.ShowDialog() = DialogResult.OK
			If flag Then
				Dim filePath As String = ofd.FileName
				Dim extension As String = Path.GetExtension(filePath).ToLower()
				Me.ProgressBar1.Visible = True
				Me.ProgressBar1.Style = ProgressBarStyle.Marquee
				Me.ProgressBar1.MarqueeAnimationSpeed = 30
				Try
					Dim flag2 As Boolean = Operators.CompareString(extension, ".pdf", False) = 0
					If Not flag2 Then
						Dim flag3 As Boolean = Operators.CompareString(extension, ".jpg", False) = 0 OrElse Operators.CompareString(extension, ".jpeg", False) = 0 OrElse Operators.CompareString(extension, ".png", False) = 0
						If flag3 Then
							Await Me.PerformOCR(filePath)
						Else
							MessageBox.Show("Unsupported file type.")
						End If
					End If
				Catch ex As Exception
					MessageBox.Show("Error: " + ex.Message)
				Finally
					Me.ProgressBar1.Style = ProgressBarStyle.Blocks
					Me.ProgressBar1.Visible = False
				End Try
			End If
		End Sub

		' Token: 0x060129AA RID: 76202 RVA: 0x00AB50E8 File Offset: 0x00AB32E8
		Public Async Function PerformOCR(imagePath As String) As Task
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim requestData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From { { "model", "gpt-4o-mini" }, { "messages", New List(Of Object)() From { New Dictionary(Of String, String)() From { { "role", "system" }, { "content", "You are an OCR assistant. From the invoice image, extract only the supplier details and return them in JSON format with the following fields:" & vbCrLf & vbCrLf & "supplier: {" & vbCrLf & "    name: Supplier's full name or company name," & vbCrLf & "    address: Complete address as found in the invoice," & vbCrLf & "    city: City name (if present or identify from address also)," & vbCrLf & "    state: State name (if present or identify from address also)," & vbCrLf & "    pincode: Postal/ZIP code (if present or identify from address also)," & vbCrLf & "    gst_number: Supplier's GSTIN number (if present)," & vbCrLf & "    phone_number: Supplier's phone number (if present)," & vbCrLf & "    email: Supplier's email address (if present)" & vbCrLf & "}" & vbCrLf & vbCrLf & "If any field is missing or not visible in the image, set it as null. Return only the structured JSON. Do not include explanations or other text." } }, New Dictionary(Of String, Object)() From { { "role", "user" }, { "content", New List(Of Object)() From { New Dictionary(Of String, Object)() From { { "type", "image_url" }, { "image_url", New Dictionary(Of String, String)() From { { "url", "data:image/jpeg;base64," + base64Image } } } } } } } } }, { "temperature", 0.2 } }
					Dim jsonData As String = JsonConvert.SerializeObject(requestData)
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim content As StringContent = New StringContent(jsonData, Encoding.UTF8, "application/json")
						Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/chat/completions", content)
						If response.IsSuccessStatusCode Then
							Dim responseString As String = Await response.Content.ReadAsStringAsync()
							Dim jsonResponse As JObject = JObject.Parse(responseString)
							Dim rawContent As String = jsonResponse("choices")(0)("message")("content").ToString()
							Dim cleanJson As String = rawContent.Replace("```json", "").Replace("```", "").Trim()
							Dim parsedJson As JObject = JObject.Parse(cleanJson)
							If parsedJson("supplier") IsNot Nothing Then
								Dim supplier As JObject = CType(parsedJson("supplier"), JObject)
								Me.Invoke(New VB_AnonymousDelegate_0(Sub()
									Dim cmbSupplierName As ComboBox = Me.cmbSupplierName
									Dim jtoken As JToken = supplier("name")
									cmbSupplierName.Text = If((jtoken IsNot Nothing), jtoken.ToString(), Nothing)
									Dim txtAddress As TextBox = Me.txtAddress
									Dim jtoken2 As JToken = supplier("address")
									txtAddress.Text = If((jtoken2 IsNot Nothing), jtoken2.ToString(), Nothing)
									Dim txtCity As TextBox = Me.txtCity
									Dim jtoken3 As JToken = supplier("city")
									txtCity.Text = If((jtoken3 IsNot Nothing), jtoken3.ToString(), Nothing)
									Dim cmbState As ComboBox = Me.cmbState
									Dim jtoken4 As JToken = supplier("state")
									cmbState.Text = If((jtoken4 IsNot Nothing), jtoken4.ToString(), Nothing)
									Dim txtZipCode As TextBox = Me.txtZipCode
									Dim jtoken5 As JToken = supplier("pincode")
									txtZipCode.Text = If((jtoken5 IsNot Nothing), jtoken5.ToString(), Nothing)
									Dim txtGSTIN As TextBox = Me.txtGSTIN
									Dim jtoken6 As JToken = supplier("gst_number")
									txtGSTIN.Text = If((jtoken6 IsNot Nothing), jtoken6.ToString(), Nothing)
									Dim txtContactNo As TextBox = Me.txtContactNo
									Dim jtoken7 As JToken = supplier("phone_number")
									txtContactNo.Text = If((jtoken7 IsNot Nothing), jtoken7.ToString(), Nothing)
									Dim txtEmailID As TextBox = Me.txtEmailID
									Dim jtoken8 As JToken = supplier("email")
									txtEmailID.Text = If((jtoken8 IsNot Nothing), jtoken8.ToString(), Nothing)
								End Sub))
							Else
								MessageBox.Show("No supplier details found in OCR response.")
							End If
						Else
							MessageBox.Show("API Error: " + response.StatusCode.ToString())
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Exception: " + ex.Message)
			End Try
		End Function

		' Token: 0x060129AB RID: 76203 RVA: 0x00AB5134 File Offset: 0x00AB3334
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSuppliers.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSuppliers.lblUserType.Text = Me.Label31.Text
			MyProject.Forms.frmSuppliers.lblCPhone.Text = Me.lblCPhone.Text
			MyProject.Forms.frmSuppliers.Reset()
			MyProject.Forms.frmSuppliers.ShowDialog()
			MyProject.Forms.frmSuppliers.Dispose()
		End Sub

		' Token: 0x04006FF6 RID: 28662
		Private Photoname As String

		' Token: 0x04006FF7 RID: 28663
		Private IsImageChanged As Boolean

		' Token: 0x04006FF8 RID: 28664
		Private apiKey As String

		' Token: 0x04006FF9 RID: 28665
		Private url As String

		' Token: 0x04006FFA RID: 28666
		Private Dad As SqlDataAdapter

		' Token: 0x04006FFB RID: 28667
		Private Dst As DataSet

		' Token: 0x04006FFC RID: 28668
		Private CurrentRow As Object
	End Class
End Namespace
