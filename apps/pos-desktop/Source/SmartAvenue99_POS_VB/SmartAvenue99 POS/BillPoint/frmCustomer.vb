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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000583 RID: 1411
	<DesignerGenerated()>
	Public Partial Class frmCustomer
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601113E RID: 69950 RVA: 0x009E5238 File Offset: 0x009E3438
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomer_Load
			AddHandler MyBase.Closing, AddressOf Me.frmCustomer_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomer_KeyDown
			AddHandler MyBase.Closed, AddressOf Me.frmCustomer_Closed
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.apiKey = ""
			Me.url = ""
			Me.Dst = New DataSet()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170069FB RID: 27131
		' (get) Token: 0x06011141 RID: 69953 RVA: 0x000757F6 File Offset: 0x000739F6
		' (set) Token: 0x06011142 RID: 69954 RVA: 0x00075800 File Offset: 0x00073A00
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170069FC RID: 27132
		' (get) Token: 0x06011143 RID: 69955 RVA: 0x00075809 File Offset: 0x00073A09
		' (set) Token: 0x06011144 RID: 69956 RVA: 0x00075813 File Offset: 0x00073A13
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170069FD RID: 27133
		' (get) Token: 0x06011145 RID: 69957 RVA: 0x0007581C File Offset: 0x00073A1C
		' (set) Token: 0x06011146 RID: 69958 RVA: 0x00075826 File Offset: 0x00073A26
		Friend Overridable Property Label3 As Label

		' Token: 0x170069FE RID: 27134
		' (get) Token: 0x06011147 RID: 69959 RVA: 0x0007582F File Offset: 0x00073A2F
		' (set) Token: 0x06011148 RID: 69960 RVA: 0x009E9EAC File Offset: 0x009E80AC
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerID_TextChanged
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170069FF RID: 27135
		' (get) Token: 0x06011149 RID: 69961 RVA: 0x00075839 File Offset: 0x00073A39
		' (set) Token: 0x0601114A RID: 69962 RVA: 0x00075843 File Offset: 0x00073A43
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006A00 RID: 27136
		' (get) Token: 0x0601114B RID: 69963 RVA: 0x0007584C File Offset: 0x00073A4C
		' (set) Token: 0x0601114C RID: 69964 RVA: 0x00075856 File Offset: 0x00073A56
		Friend Overridable Property Label1 As Label

		' Token: 0x17006A01 RID: 27137
		' (get) Token: 0x0601114D RID: 69965 RVA: 0x0007585F File Offset: 0x00073A5F
		' (set) Token: 0x0601114E RID: 69966 RVA: 0x00075869 File Offset: 0x00073A69
		Friend Overridable Property Label7 As Label

		' Token: 0x17006A02 RID: 27138
		' (get) Token: 0x0601114F RID: 69967 RVA: 0x00075872 File Offset: 0x00073A72
		' (set) Token: 0x06011150 RID: 69968 RVA: 0x0007587C File Offset: 0x00073A7C
		Friend Overridable Property Label6 As Label

		' Token: 0x17006A03 RID: 27139
		' (get) Token: 0x06011151 RID: 69969 RVA: 0x00075885 File Offset: 0x00073A85
		' (set) Token: 0x06011152 RID: 69970 RVA: 0x0007588F File Offset: 0x00073A8F
		Friend Overridable Property Label5 As Label

		' Token: 0x17006A04 RID: 27140
		' (get) Token: 0x06011153 RID: 69971 RVA: 0x00075898 File Offset: 0x00073A98
		' (set) Token: 0x06011154 RID: 69972 RVA: 0x009E9EF0 File Offset: 0x009E80F0
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

		' Token: 0x17006A05 RID: 27141
		' (get) Token: 0x06011155 RID: 69973 RVA: 0x000758A2 File Offset: 0x00073AA2
		' (set) Token: 0x06011156 RID: 69974 RVA: 0x009E9F50 File Offset: 0x009E8150
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

		' Token: 0x17006A06 RID: 27142
		' (get) Token: 0x06011157 RID: 69975 RVA: 0x000758AC File Offset: 0x00073AAC
		' (set) Token: 0x06011158 RID: 69976 RVA: 0x000758B6 File Offset: 0x00073AB6
		Friend Overridable Property Label2 As Label

		' Token: 0x17006A07 RID: 27143
		' (get) Token: 0x06011159 RID: 69977 RVA: 0x000758BF File Offset: 0x00073ABF
		' (set) Token: 0x0601115A RID: 69978 RVA: 0x000758C9 File Offset: 0x00073AC9
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006A08 RID: 27144
		' (get) Token: 0x0601115B RID: 69979 RVA: 0x000758D2 File Offset: 0x00073AD2
		' (set) Token: 0x0601115C RID: 69980 RVA: 0x000758DC File Offset: 0x00073ADC
		Friend Overridable Property lblUser As Label

		' Token: 0x17006A09 RID: 27145
		' (get) Token: 0x0601115D RID: 69981 RVA: 0x000758E5 File Offset: 0x00073AE5
		' (set) Token: 0x0601115E RID: 69982 RVA: 0x009E9F94 File Offset: 0x009E8194
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

		' Token: 0x17006A0A RID: 27146
		' (get) Token: 0x0601115F RID: 69983 RVA: 0x000758EF File Offset: 0x00073AEF
		' (set) Token: 0x06011160 RID: 69984 RVA: 0x009EA010 File Offset: 0x009E8210
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

		' Token: 0x17006A0B RID: 27147
		' (get) Token: 0x06011161 RID: 69985 RVA: 0x000758F9 File Offset: 0x00073AF9
		' (set) Token: 0x06011162 RID: 69986 RVA: 0x00075903 File Offset: 0x00073B03
		Friend Overridable Property Label10 As Label

		' Token: 0x17006A0C RID: 27148
		' (get) Token: 0x06011163 RID: 69987 RVA: 0x0007590C File Offset: 0x00073B0C
		' (set) Token: 0x06011164 RID: 69988 RVA: 0x00075916 File Offset: 0x00073B16
		Friend Overridable Property Label4 As Label

		' Token: 0x17006A0D RID: 27149
		' (get) Token: 0x06011165 RID: 69989 RVA: 0x0007591F File Offset: 0x00073B1F
		' (set) Token: 0x06011166 RID: 69990 RVA: 0x009EA08C File Offset: 0x009E828C
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

		' Token: 0x17006A0E RID: 27150
		' (get) Token: 0x06011167 RID: 69991 RVA: 0x00075929 File Offset: 0x00073B29
		' (set) Token: 0x06011168 RID: 69992 RVA: 0x00075933 File Offset: 0x00073B33
		Friend Overridable Property Label12 As Label

		' Token: 0x17006A0F RID: 27151
		' (get) Token: 0x06011169 RID: 69993 RVA: 0x0007593C File Offset: 0x00073B3C
		' (set) Token: 0x0601116A RID: 69994 RVA: 0x00075946 File Offset: 0x00073B46
		Friend Overridable Property Label9 As Label

		' Token: 0x17006A10 RID: 27152
		' (get) Token: 0x0601116B RID: 69995 RVA: 0x0007594F File Offset: 0x00073B4F
		' (set) Token: 0x0601116C RID: 69996 RVA: 0x009EA0EC File Offset: 0x009E82EC
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

		' Token: 0x17006A11 RID: 27153
		' (get) Token: 0x0601116D RID: 69997 RVA: 0x00075959 File Offset: 0x00073B59
		' (set) Token: 0x0601116E RID: 69998 RVA: 0x009EA130 File Offset: 0x009E8330
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

		' Token: 0x17006A12 RID: 27154
		' (get) Token: 0x0601116F RID: 69999 RVA: 0x00075963 File Offset: 0x00073B63
		' (set) Token: 0x06011170 RID: 70000 RVA: 0x0007596D File Offset: 0x00073B6D
		Friend Overridable Property txtCustName As TextBox

		' Token: 0x17006A13 RID: 27155
		' (get) Token: 0x06011171 RID: 70001 RVA: 0x00075976 File Offset: 0x00073B76
		' (set) Token: 0x06011172 RID: 70002 RVA: 0x009EA1D0 File Offset: 0x009E83D0
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

		' Token: 0x17006A14 RID: 27156
		' (get) Token: 0x06011173 RID: 70003 RVA: 0x00075980 File Offset: 0x00073B80
		' (set) Token: 0x06011174 RID: 70004 RVA: 0x0007598A File Offset: 0x00073B8A
		Friend Overridable Property Label14 As Label

		' Token: 0x17006A15 RID: 27157
		' (get) Token: 0x06011175 RID: 70005 RVA: 0x00075993 File Offset: 0x00073B93
		' (set) Token: 0x06011176 RID: 70006 RVA: 0x0007599D File Offset: 0x00073B9D
		Friend Overridable Property Label8 As Label

		' Token: 0x17006A16 RID: 27158
		' (get) Token: 0x06011177 RID: 70007 RVA: 0x000759A6 File Offset: 0x00073BA6
		' (set) Token: 0x06011178 RID: 70008 RVA: 0x009EA214 File Offset: 0x009E8414
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

		' Token: 0x17006A17 RID: 27159
		' (get) Token: 0x06011179 RID: 70009 RVA: 0x000759B0 File Offset: 0x00073BB0
		' (set) Token: 0x0601117A RID: 70010 RVA: 0x009EA274 File Offset: 0x009E8474
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

		' Token: 0x17006A18 RID: 27160
		' (get) Token: 0x0601117B RID: 70011 RVA: 0x000759BA File Offset: 0x00073BBA
		' (set) Token: 0x0601117C RID: 70012 RVA: 0x000759C4 File Offset: 0x00073BC4
		Friend Overridable Property Label13 As Label

		' Token: 0x17006A19 RID: 27161
		' (get) Token: 0x0601117D RID: 70013 RVA: 0x000759CD File Offset: 0x00073BCD
		' (set) Token: 0x0601117E RID: 70014 RVA: 0x000759D7 File Offset: 0x00073BD7
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006A1A RID: 27162
		' (get) Token: 0x0601117F RID: 70015 RVA: 0x000759E0 File Offset: 0x00073BE0
		' (set) Token: 0x06011180 RID: 70016 RVA: 0x009EA2B8 File Offset: 0x009E84B8
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

		' Token: 0x17006A1B RID: 27163
		' (get) Token: 0x06011181 RID: 70017 RVA: 0x000759EA File Offset: 0x00073BEA
		' (set) Token: 0x06011182 RID: 70018 RVA: 0x000759F4 File Offset: 0x00073BF4
		Friend Overridable Property Label22 As Label

		' Token: 0x17006A1C RID: 27164
		' (get) Token: 0x06011183 RID: 70019 RVA: 0x000759FD File Offset: 0x00073BFD
		' (set) Token: 0x06011184 RID: 70020 RVA: 0x00075A07 File Offset: 0x00073C07
		Friend Overridable Property Label17 As Label

		' Token: 0x17006A1D RID: 27165
		' (get) Token: 0x06011185 RID: 70021 RVA: 0x00075A10 File Offset: 0x00073C10
		' (set) Token: 0x06011186 RID: 70022 RVA: 0x009EA2FC File Offset: 0x009E84FC
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

		' Token: 0x17006A1E RID: 27166
		' (get) Token: 0x06011187 RID: 70023 RVA: 0x00075A1A File Offset: 0x00073C1A
		' (set) Token: 0x06011188 RID: 70024 RVA: 0x00075A24 File Offset: 0x00073C24
		Friend Overridable Property Label18 As Label

		' Token: 0x17006A1F RID: 27167
		' (get) Token: 0x06011189 RID: 70025 RVA: 0x00075A2D File Offset: 0x00073C2D
		' (set) Token: 0x0601118A RID: 70026 RVA: 0x009EA340 File Offset: 0x009E8540
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

		' Token: 0x17006A20 RID: 27168
		' (get) Token: 0x0601118B RID: 70027 RVA: 0x00075A37 File Offset: 0x00073C37
		' (set) Token: 0x0601118C RID: 70028 RVA: 0x00075A41 File Offset: 0x00073C41
		Friend Overridable Property Label20 As Label

		' Token: 0x17006A21 RID: 27169
		' (get) Token: 0x0601118D RID: 70029 RVA: 0x00075A4A File Offset: 0x00073C4A
		' (set) Token: 0x0601118E RID: 70030 RVA: 0x00075A54 File Offset: 0x00073C54
		Friend Overridable Property Label21 As Label

		' Token: 0x17006A22 RID: 27170
		' (get) Token: 0x0601118F RID: 70031 RVA: 0x00075A5D File Offset: 0x00073C5D
		' (set) Token: 0x06011190 RID: 70032 RVA: 0x009EA384 File Offset: 0x009E8584
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

		' Token: 0x17006A23 RID: 27171
		' (get) Token: 0x06011191 RID: 70033 RVA: 0x00075A67 File Offset: 0x00073C67
		' (set) Token: 0x06011192 RID: 70034 RVA: 0x009EA3C8 File Offset: 0x009E85C8
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

		' Token: 0x17006A24 RID: 27172
		' (get) Token: 0x06011193 RID: 70035 RVA: 0x00075A71 File Offset: 0x00073C71
		' (set) Token: 0x06011194 RID: 70036 RVA: 0x009EA40C File Offset: 0x009E860C
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

		' Token: 0x17006A25 RID: 27173
		' (get) Token: 0x06011195 RID: 70037 RVA: 0x00075A7B File Offset: 0x00073C7B
		' (set) Token: 0x06011196 RID: 70038 RVA: 0x00075A85 File Offset: 0x00073C85
		Friend Overridable Property Label15 As Label

		' Token: 0x17006A26 RID: 27174
		' (get) Token: 0x06011197 RID: 70039 RVA: 0x00075A8E File Offset: 0x00073C8E
		' (set) Token: 0x06011198 RID: 70040 RVA: 0x009EA46C File Offset: 0x009E866C
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
				Dim textBox As TextBox = Me._txtOpeningBalance
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtOpeningBalance = value
				textBox = Me._txtOpeningBalance
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A27 RID: 27175
		' (get) Token: 0x06011199 RID: 70041 RVA: 0x00075A98 File Offset: 0x00073C98
		' (set) Token: 0x0601119A RID: 70042 RVA: 0x009EA4CC File Offset: 0x009E86CC
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

		' Token: 0x17006A28 RID: 27176
		' (get) Token: 0x0601119B RID: 70043 RVA: 0x00075AA2 File Offset: 0x00073CA2
		' (set) Token: 0x0601119C RID: 70044 RVA: 0x009EA510 File Offset: 0x009E8710
		Private _txtCustNameId As TextBox
		Friend Overridable Property txtCustNameId As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustNameId
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustNameId_TextChanged
				Dim textBox As TextBox = Me._txtCustNameId
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustNameId = value
				textBox = Me._txtCustNameId
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A29 RID: 27177
		' (get) Token: 0x0601119D RID: 70045 RVA: 0x00075AAC File Offset: 0x00073CAC
		' (set) Token: 0x0601119E RID: 70046 RVA: 0x00075AB6 File Offset: 0x00073CB6
		Public Overridable Property Picture As PictureBox

		' Token: 0x17006A2A RID: 27178
		' (get) Token: 0x0601119F RID: 70047 RVA: 0x00075ABF File Offset: 0x00073CBF
		' (set) Token: 0x060111A0 RID: 70048 RVA: 0x009EA554 File Offset: 0x009E8754
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

		' Token: 0x17006A2B RID: 27179
		' (get) Token: 0x060111A1 RID: 70049 RVA: 0x00075AC9 File Offset: 0x00073CC9
		' (set) Token: 0x060111A2 RID: 70050 RVA: 0x009EA598 File Offset: 0x009E8798
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

		' Token: 0x17006A2C RID: 27180
		' (get) Token: 0x060111A3 RID: 70051 RVA: 0x00075AD3 File Offset: 0x00073CD3
		' (set) Token: 0x060111A4 RID: 70052 RVA: 0x009EA5DC File Offset: 0x009E87DC
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

		' Token: 0x17006A2D RID: 27181
		' (get) Token: 0x060111A5 RID: 70053 RVA: 0x00075ADD File Offset: 0x00073CDD
		' (set) Token: 0x060111A6 RID: 70054 RVA: 0x00075AE7 File Offset: 0x00073CE7
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17006A2E RID: 27182
		' (get) Token: 0x060111A7 RID: 70055 RVA: 0x00075AF0 File Offset: 0x00073CF0
		' (set) Token: 0x060111A8 RID: 70056 RVA: 0x009EA620 File Offset: 0x009E8820
		Private _cmbTCS As ComboBox
		Friend Overridable Property cmbTCS As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTCS
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbTCS_KeyDown
				Dim comboBox As ComboBox = Me._cmbTCS
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbTCS = value
				comboBox = Me._cmbTCS
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A2F RID: 27183
		' (get) Token: 0x060111A9 RID: 70057 RVA: 0x00075AFA File Offset: 0x00073CFA
		' (set) Token: 0x060111AA RID: 70058 RVA: 0x00075B04 File Offset: 0x00073D04
		Friend Overridable Property Label27 As Label

		' Token: 0x17006A30 RID: 27184
		' (get) Token: 0x060111AB RID: 70059 RVA: 0x00075B0D File Offset: 0x00073D0D
		' (set) Token: 0x060111AC RID: 70060 RVA: 0x009EA664 File Offset: 0x009E8864
		Private _cmbCustomerName As ComboBox
		Friend Overridable Property cmbCustomerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbCustomerName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbCustomerName_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.TextChanged, eventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbCustomerName = value
				comboBox = Me._cmbCustomerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.TextChanged, eventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A31 RID: 27185
		' (get) Token: 0x060111AD RID: 70061 RVA: 0x00075B17 File Offset: 0x00073D17
		' (set) Token: 0x060111AE RID: 70062 RVA: 0x00075B21 File Offset: 0x00073D21
		Friend Overridable Property txtPhNo As TextBox

		' Token: 0x17006A32 RID: 27186
		' (get) Token: 0x060111AF RID: 70063 RVA: 0x00075B2A File Offset: 0x00073D2A
		' (set) Token: 0x060111B0 RID: 70064 RVA: 0x009EA6E0 File Offset: 0x009E88E0
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

		' Token: 0x17006A33 RID: 27187
		' (get) Token: 0x060111B1 RID: 70065 RVA: 0x00075B34 File Offset: 0x00073D34
		' (set) Token: 0x060111B2 RID: 70066 RVA: 0x00075B3E File Offset: 0x00073D3E
		Friend Overridable Property Label28 As Label

		' Token: 0x17006A34 RID: 27188
		' (get) Token: 0x060111B3 RID: 70067 RVA: 0x00075B47 File Offset: 0x00073D47
		' (set) Token: 0x060111B4 RID: 70068 RVA: 0x009EA724 File Offset: 0x009E8924
		Private _txtcrlimit As TextBox
		Friend Overridable Property txtcrlimit As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtcrlimit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtcrlimit_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtcrlimit_KeyDown
				Dim textBox As TextBox = Me._txtcrlimit
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtcrlimit = value
				textBox = Me._txtcrlimit
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A35 RID: 27189
		' (get) Token: 0x060111B5 RID: 70069 RVA: 0x00075B51 File Offset: 0x00073D51
		' (set) Token: 0x060111B6 RID: 70070 RVA: 0x009EA784 File Offset: 0x009E8984
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

		' Token: 0x17006A36 RID: 27190
		' (get) Token: 0x060111B7 RID: 70071 RVA: 0x00075B5B File Offset: 0x00073D5B
		' (set) Token: 0x060111B8 RID: 70072 RVA: 0x009EA7C8 File Offset: 0x009E89C8
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

		' Token: 0x17006A37 RID: 27191
		' (get) Token: 0x060111B9 RID: 70073 RVA: 0x00075B65 File Offset: 0x00073D65
		' (set) Token: 0x060111BA RID: 70074 RVA: 0x009EA80C File Offset: 0x009E8A0C
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

		' Token: 0x17006A38 RID: 27192
		' (get) Token: 0x060111BB RID: 70075 RVA: 0x00075B6F File Offset: 0x00073D6F
		' (set) Token: 0x060111BC RID: 70076 RVA: 0x009EA850 File Offset: 0x009E8A50
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

		' Token: 0x17006A39 RID: 27193
		' (get) Token: 0x060111BD RID: 70077 RVA: 0x00075B79 File Offset: 0x00073D79
		' (set) Token: 0x060111BE RID: 70078 RVA: 0x009EA894 File Offset: 0x009E8A94
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

		' Token: 0x17006A3A RID: 27194
		' (get) Token: 0x060111BF RID: 70079 RVA: 0x00075B83 File Offset: 0x00073D83
		' (set) Token: 0x060111C0 RID: 70080 RVA: 0x009EA8D8 File Offset: 0x009E8AD8
		Private _cmbRoute As ComboBox
		Friend Overridable Property cmbRoute As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbRoute
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbRoute_KeyDown
				Dim comboBox As ComboBox = Me._cmbRoute
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbRoute = value
				comboBox = Me._cmbRoute
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A3B RID: 27195
		' (get) Token: 0x060111C1 RID: 70081 RVA: 0x00075B8D File Offset: 0x00073D8D
		' (set) Token: 0x060111C2 RID: 70082 RVA: 0x00075B97 File Offset: 0x00073D97
		Friend Overridable Property Label29 As Label

		' Token: 0x17006A3C RID: 27196
		' (get) Token: 0x060111C3 RID: 70083 RVA: 0x00075BA0 File Offset: 0x00073DA0
		' (set) Token: 0x060111C4 RID: 70084 RVA: 0x009EA91C File Offset: 0x009E8B1C
		Private _Num1 As NumericUpDown
		Friend Overridable Property Num1 As NumericUpDown
			<CompilerGenerated()>
			Get
				Return Me._Num1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As NumericUpDown)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.Num1_KeyDown
				Dim numericUpDown As NumericUpDown = Me._Num1
				If numericUpDown IsNot Nothing Then
					RemoveHandler numericUpDown.KeyDown, keyEventHandler
				End If
				Me._Num1 = value
				numericUpDown = Me._Num1
				If numericUpDown IsNot Nothing Then
					AddHandler numericUpDown.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A3D RID: 27197
		' (get) Token: 0x060111C5 RID: 70085 RVA: 0x00075BAA File Offset: 0x00073DAA
		' (set) Token: 0x060111C6 RID: 70086 RVA: 0x00075BB4 File Offset: 0x00073DB4
		Friend Overridable Property Label30 As Label

		' Token: 0x17006A3E RID: 27198
		' (get) Token: 0x060111C7 RID: 70087 RVA: 0x00075BBD File Offset: 0x00073DBD
		' (set) Token: 0x060111C8 RID: 70088 RVA: 0x009EA960 File Offset: 0x009E8B60
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

		' Token: 0x17006A3F RID: 27199
		' (get) Token: 0x060111C9 RID: 70089 RVA: 0x00075BC7 File Offset: 0x00073DC7
		' (set) Token: 0x060111CA RID: 70090 RVA: 0x00075BD1 File Offset: 0x00073DD1
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x17006A40 RID: 27200
		' (get) Token: 0x060111CB RID: 70091 RVA: 0x00075BDA File Offset: 0x00073DDA
		' (set) Token: 0x060111CC RID: 70092 RVA: 0x00075BE4 File Offset: 0x00073DE4
		Friend Overridable Property Label31 As Label

		' Token: 0x17006A41 RID: 27201
		' (get) Token: 0x060111CD RID: 70093 RVA: 0x00075BED File Offset: 0x00073DED
		' (set) Token: 0x060111CE RID: 70094 RVA: 0x00075BF7 File Offset: 0x00073DF7
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006A42 RID: 27202
		' (get) Token: 0x060111CF RID: 70095 RVA: 0x00075C00 File Offset: 0x00073E00
		' (set) Token: 0x060111D0 RID: 70096 RVA: 0x00075C0A File Offset: 0x00073E0A
		Friend Overridable Property lbl_Result As Label

		' Token: 0x17006A43 RID: 27203
		' (get) Token: 0x060111D1 RID: 70097 RVA: 0x00075C13 File Offset: 0x00073E13
		' (set) Token: 0x060111D2 RID: 70098 RVA: 0x00075C1D File Offset: 0x00073E1D
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17006A44 RID: 27204
		' (get) Token: 0x060111D3 RID: 70099 RVA: 0x00075C26 File Offset: 0x00073E26
		' (set) Token: 0x060111D4 RID: 70100 RVA: 0x009EA9A4 File Offset: 0x009E8BA4
		Private _cmbDiscStatus As ComboBox
		Friend Overridable Property cmbDiscStatus As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbDiscStatus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbDiscStatus_KeyDown
				Dim comboBox As ComboBox = Me._cmbDiscStatus
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbDiscStatus = value
				comboBox = Me._cmbDiscStatus
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A45 RID: 27205
		' (get) Token: 0x060111D5 RID: 70101 RVA: 0x00075C30 File Offset: 0x00073E30
		' (set) Token: 0x060111D6 RID: 70102 RVA: 0x00075C3A File Offset: 0x00073E3A
		Friend Overridable Property Label11 As Label

		' Token: 0x17006A46 RID: 27206
		' (get) Token: 0x060111D7 RID: 70103 RVA: 0x00075C43 File Offset: 0x00073E43
		' (set) Token: 0x060111D8 RID: 70104 RVA: 0x009EA9E8 File Offset: 0x009E8BE8
		Private _txtDiscItem As TextBox
		Friend Overridable Property txtDiscItem As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDiscItem
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtDiscItem_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtDiscItem_KeyDown
				Dim textBox As TextBox = Me._txtDiscItem
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtDiscItem = value
				textBox = Me._txtDiscItem
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A47 RID: 27207
		' (get) Token: 0x060111D9 RID: 70105 RVA: 0x00075C4D File Offset: 0x00073E4D
		' (set) Token: 0x060111DA RID: 70106 RVA: 0x00075C57 File Offset: 0x00073E57
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17006A48 RID: 27208
		' (get) Token: 0x060111DB RID: 70107 RVA: 0x00075C60 File Offset: 0x00073E60
		' (set) Token: 0x060111DC RID: 70108 RVA: 0x00075C6A File Offset: 0x00073E6A
		Friend Overridable Property Label16 As Label

		' Token: 0x17006A49 RID: 27209
		' (get) Token: 0x060111DD RID: 70109 RVA: 0x00075C73 File Offset: 0x00073E73
		' (set) Token: 0x060111DE RID: 70110 RVA: 0x00075C7D File Offset: 0x00073E7D
		Friend Overridable Property lblCode As Label

		' Token: 0x17006A4A RID: 27210
		' (get) Token: 0x060111DF RID: 70111 RVA: 0x00075C86 File Offset: 0x00073E86
		' (set) Token: 0x060111E0 RID: 70112 RVA: 0x009EAA48 File Offset: 0x009E8C48
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

		' Token: 0x17006A4B RID: 27211
		' (get) Token: 0x060111E1 RID: 70113 RVA: 0x00075C90 File Offset: 0x00073E90
		' (set) Token: 0x060111E2 RID: 70114 RVA: 0x00075C9A File Offset: 0x00073E9A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006A4C RID: 27212
		' (get) Token: 0x060111E3 RID: 70115 RVA: 0x00075CA3 File Offset: 0x00073EA3
		' (set) Token: 0x060111E4 RID: 70116 RVA: 0x009EAA8C File Offset: 0x009E8C8C
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

		' Token: 0x17006A4D RID: 27213
		' (get) Token: 0x060111E5 RID: 70117 RVA: 0x00075CAD File Offset: 0x00073EAD
		' (set) Token: 0x060111E6 RID: 70118 RVA: 0x009EAAD0 File Offset: 0x009E8CD0
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

		' Token: 0x17006A4E RID: 27214
		' (get) Token: 0x060111E7 RID: 70119 RVA: 0x00075CB7 File Offset: 0x00073EB7
		' (set) Token: 0x060111E8 RID: 70120 RVA: 0x009EAB14 File Offset: 0x009E8D14
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

		' Token: 0x17006A4F RID: 27215
		' (get) Token: 0x060111E9 RID: 70121 RVA: 0x00075CC1 File Offset: 0x00073EC1
		' (set) Token: 0x060111EA RID: 70122 RVA: 0x009EAB58 File Offset: 0x009E8D58
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

		' Token: 0x17006A50 RID: 27216
		' (get) Token: 0x060111EB RID: 70123 RVA: 0x00075CCB File Offset: 0x00073ECB
		' (set) Token: 0x060111EC RID: 70124 RVA: 0x009EAB9C File Offset: 0x009E8D9C
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

		' Token: 0x17006A51 RID: 27217
		' (get) Token: 0x060111ED RID: 70125 RVA: 0x00075CD5 File Offset: 0x00073ED5
		' (set) Token: 0x060111EE RID: 70126 RVA: 0x00075CDF File Offset: 0x00073EDF
		Friend Overridable Property Label19 As Label

		' Token: 0x17006A52 RID: 27218
		' (get) Token: 0x060111EF RID: 70127 RVA: 0x00075CE8 File Offset: 0x00073EE8
		' (set) Token: 0x060111F0 RID: 70128 RVA: 0x00075CF2 File Offset: 0x00073EF2
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x17006A53 RID: 27219
		' (get) Token: 0x060111F1 RID: 70129 RVA: 0x00075CFB File Offset: 0x00073EFB
		' (set) Token: 0x060111F2 RID: 70130 RVA: 0x00075D05 File Offset: 0x00073F05
		Friend Overridable Property cboxLoyality As ComboBox

		' Token: 0x17006A54 RID: 27220
		' (get) Token: 0x060111F3 RID: 70131 RVA: 0x00075D0E File Offset: 0x00073F0E
		' (set) Token: 0x060111F4 RID: 70132 RVA: 0x00075D18 File Offset: 0x00073F18
		Friend Overridable Property Label23 As Label

		' Token: 0x17006A55 RID: 27221
		' (get) Token: 0x060111F5 RID: 70133 RVA: 0x00075D21 File Offset: 0x00073F21
		' (set) Token: 0x060111F6 RID: 70134 RVA: 0x00075D2B File Offset: 0x00073F2B
		Friend Overridable Property txtLoyalitypts As TextBox

		' Token: 0x17006A56 RID: 27222
		' (get) Token: 0x060111F7 RID: 70135 RVA: 0x00075D34 File Offset: 0x00073F34
		' (set) Token: 0x060111F8 RID: 70136 RVA: 0x00075D3E File Offset: 0x00073F3E
		Friend Overridable Property chkLoyality As CheckBox

		' Token: 0x17006A57 RID: 27223
		' (get) Token: 0x060111F9 RID: 70137 RVA: 0x00075D47 File Offset: 0x00073F47
		' (set) Token: 0x060111FA RID: 70138 RVA: 0x009EABE0 File Offset: 0x009E8DE0
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

		' Token: 0x17006A58 RID: 27224
		' (get) Token: 0x060111FB RID: 70139 RVA: 0x00075D51 File Offset: 0x00073F51
		' (set) Token: 0x060111FC RID: 70140 RVA: 0x00075D5B File Offset: 0x00073F5B
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17006A59 RID: 27225
		' (get) Token: 0x060111FD RID: 70141 RVA: 0x00075D64 File Offset: 0x00073F64
		' (set) Token: 0x060111FE RID: 70142 RVA: 0x009EAC24 File Offset: 0x009E8E24
		Private _chksameAddress As CheckBox
		Friend Overridable Property chksameAddress As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chksameAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chksameAddress_CheckedChanged
				Dim checkBox As CheckBox = Me._chksameAddress
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chksameAddress = value
				checkBox = Me._chksameAddress
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006A5A RID: 27226
		' (get) Token: 0x060111FF RID: 70143 RVA: 0x00075D6E File Offset: 0x00073F6E
		' (set) Token: 0x06011200 RID: 70144 RVA: 0x00075D78 File Offset: 0x00073F78
		Friend Overridable Property txtpermentAddress As TextBox

		' Token: 0x17006A5B RID: 27227
		' (get) Token: 0x06011201 RID: 70145 RVA: 0x00075D81 File Offset: 0x00073F81
		' (set) Token: 0x06011202 RID: 70146 RVA: 0x009EAC68 File Offset: 0x009E8E68
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

		' Token: 0x17006A5C RID: 27228
		' (get) Token: 0x06011203 RID: 70147 RVA: 0x00075D8B File Offset: 0x00073F8B
		' (set) Token: 0x06011204 RID: 70148 RVA: 0x009EACAC File Offset: 0x009E8EAC
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

		' Token: 0x06011205 RID: 70149 RVA: 0x009EACF0 File Offset: 0x009E8EF0
		Public Sub fillRouteName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(routename) FROM Route", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbRoute.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbRoute.Items.Add(dataRow(0).ToString())
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

		' Token: 0x06011206 RID: 70150 RVA: 0x009EAE24 File Offset: 0x009E9024
		Public Sub Reset()
			Me.txtAddress.Text = ""
			Me.txtRemarks.Text = ""
			Me.cmbCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtEmailID.Text = ""
			Me.cmbState.SelectedIndex = -1
			Me.txtZipCode.Text = ""
			Me.txtCity.Text = ""
			Me.cmbTCS.SelectedIndex = 1
			Me.cmbCustomerName.Focus()
			Me.txtGSTIN.Text = ""
			Me.txtPAN.Text = ""
			Me.txtCIN.Text = ""
			Me.txtAccountName.Text = ""
			Me.txtAccountNo.Text = ""
			Me.txtBank.Text = ""
			Me.txtBranch.Text = ""
			Me.txtIFSCcode.Text = ""
			Me.Picture.Image = Resources.photo
			Me.cmbOpeningBalanceType.SelectedIndex = 1
			Me.cboxLoyality.SelectedIndex = 0
			Me.txtOpeningBalance.Text = "0.00"
			Me.txtLoyalitypts.Text = "0.00"
			Me.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDownList
			Me.cmbOpeningBalanceType.Enabled = True
			Me.cboxLoyality.DropDownStyle = ComboBoxStyle.DropDownList
			Me.cboxLoyality.Enabled = True
			Me.chkLoyality.Checked = True
			Me.txtLoyalitypts.[ReadOnly] = False
			Me.txtOpeningBalance.[ReadOnly] = False
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.btnDelete.Enabled = False
			Me.auto()
			Me.txtPhNo.Text = ""
			Me.txtcrlimit.Text = "0.00"
			Me.cmbcrlimit.SelectedIndex = 0
			Me.cmbRoute.SelectedIndex = -1
			Me.Num1.Value = 0D
			Me.txtDiscItem.Text = "0"
			Me.cmbDiscStatus.SelectedIndex = 0
		End Sub

		' Token: 0x06011207 RID: 70151 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x06011208 RID: 70152 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateID() As String
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

		' Token: 0x06011209 RID: 70153 RVA: 0x009EB0AC File Offset: 0x009E92AC
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.txtCustomerID.Text = "C-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601120A RID: 70154 RVA: 0x009EB120 File Offset: 0x009E9320
		Public Sub fillCustomerName()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Customer", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbCustomerName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbCustomerName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0601120B RID: 70155 RVA: 0x009EB25C File Offset: 0x009E945C
		Private Sub DeleteRecord()
			Dim flag As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
			If flag Then
				MessageBox.Show("'Cash' account is not allowed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), "C-0001", False) = 0
				If flag2 Then
					MessageBox.Show("'Cash' account is not allowed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "SELECT Customer.ID FROM Customer INNER JOIN CreditCustomerPayment ON Customer.ID = CreditCustomerPayment.Customer_ID where Customer.ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MessageBox.Show("Unable to delete..Already in use in Customer's Receipt Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
							If flag4 Then
								ModCommonClasses.rdr.Close()
							End If
						Else
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "SELECT Customer.ID FROM Customer INNER JOIN InvoiceInfo ON Customer.ID = InvoiceInfo.Customer_ID where Customer.ID=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Unable to delete..Already in use in Sales Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "SELECT Customer.ID FROM Customer INNER JOIN Quotation ON Customer.ID = Quotation.CustomerID where Customer.ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
								If flag7 Then
									MessageBox.Show("Unable to delete..Already in use in Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag8 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con.Close()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "SELECT Customer.ID FROM Customer INNER JOIN Service ON Customer.ID = Service.CustomerID where Customer.ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
									Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
									If flag9 Then
										MessageBox.Show("Unable to delete..Already in use in Services", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag10 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag10 Then
											ModCommonClasses.rdr.Close()
										End If
									Else
										ModCommonClasses.con.Close()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text5 As String = "SELECT Customer.ID FROM Customer INNER JOIN Estimate ON Customer.ID = Estimate.CustomerID where Customer.ID=@d1"
										ModCommonClasses.cmd = New SqlCommand(text5)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
										If flag11 Then
											MessageBox.Show("Unable to delete..Already in use in Estimate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
											If flag12 Then
												ModCommonClasses.rdr.Close()
											End If
										Else
											ModCommonClasses.con.Close()
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "SELECT RTRIM(CSID) FROM Journal where CSID=@d1"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text.ToString())
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
											If flag13 Then
												MessageBox.Show("Unable to delete..Already in use in Journal Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag14 Then
													ModCommonClasses.rdr.Close()
												End If
											Else
												ModCommonClasses.con.Close()
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text7 As String = If(("delete from Customer where ID =" + Me.txtID.Text), "")
												ModCommonClasses.cmd = New SqlCommand(text7)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
												Dim flag15 As Boolean = num > 0
												If flag15 Then
													ModFunc.LedgerDelete(Me.txtCustomerID.Text, "Opening Balance")
													ModFunc.CustomerLedgerDelete(Me.txtCustomerID.Text)
													ModFunc.LedgerDelete_Loyality(Me.txtCustomerID.Text, "Opening Balance")
													ModFunc.CustomerLedgerDelete_Loyality(Me.txtCustomerID.Text)
													ModFunc.LogFunc(Me.lblUser.Text, "deleted the Customer record having Customer id '" + Me.txtCustomerID.Text + "'")
													MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.fillCustomerID()
													Me.Reset()
												Else
													MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.fillCustomerID()
													Me.Reset()
													Dim flag16 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
													If flag16 Then
														ModCommonClasses.con.Close()
													End If
													ModCommonClasses.con.Close()
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
		End Sub

		' Token: 0x0601120C RID: 70156 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbState_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0601120D RID: 70157 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x0601120E RID: 70158 RVA: 0x009EB920 File Offset: 0x009E9B20
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

		' Token: 0x0601120F RID: 70159 RVA: 0x009EBA28 File Offset: 0x009E9C28
		Private Sub txtEmailID_Validating(sender As Object, e As CancelEventArgs)
			Dim text As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
			Dim match As Match = Regex.Match(Me.txtEmailID.Text.Trim(), text, RegexOptions.IgnoreCase)
			Dim success As Boolean = match.Success
			If Not success Then
				MessageBox.Show("Please enter a valid email id", "Checking")
				Me.txtEmailID.Clear()
			End If
		End Sub

		' Token: 0x06011210 RID: 70160 RVA: 0x009EBA80 File Offset: 0x009E9C80
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

		' Token: 0x06011211 RID: 70161 RVA: 0x009EBB78 File Offset: 0x009E9D78
		Private Sub txtDiscItem_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtDiscItem.Text
					Dim selectionStart As Integer = Me.txtDiscItem.SelectionStart
					Dim selectionLength As Integer = Me.txtDiscItem.SelectionLength
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

		' Token: 0x06011212 RID: 70162 RVA: 0x00075D95 File Offset: 0x00073F95
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			MyProject.Forms.FrmValidate.TBoxGSTIN.Text = Me.txtGSTIN.Text
			MyProject.Forms.FrmValidate.ShowDialog()
		End Sub

		' Token: 0x06011213 RID: 70163 RVA: 0x009EBC70 File Offset: 0x009E9E70
		Private Sub txtCustNameId_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06011214 RID: 70164 RVA: 0x009EBC70 File Offset: 0x009E9E70
		Private Sub cmbCustomerName_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06011215 RID: 70165 RVA: 0x009EBC70 File Offset: 0x009E9E70
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.txtCustNameId.Text = Me.cmbCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {})
		End Sub

		' Token: 0x06011216 RID: 70166 RVA: 0x00075DC8 File Offset: 0x00073FC8
		Private Sub frmCustomer_Load(sender As Object, e As EventArgs)
			Me.GetApiDtl()
			Me.LinkLabel1.TabStop = False
			Me.chkLoyality.Checked = True
			Me.fillRouteName()
			Me.fillCustomerID()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011217 RID: 70167 RVA: 0x009EBCC0 File Offset: 0x009E9EC0
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

		' Token: 0x06011218 RID: 70168 RVA: 0x009EBD54 File Offset: 0x009E9F54
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
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x06011219 RID: 70169 RVA: 0x009EBEC4 File Offset: 0x009EA0C4
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

		' Token: 0x0601121A RID: 70170 RVA: 0x009EBF80 File Offset: 0x009EA180
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

		' Token: 0x0601121B RID: 70171 RVA: 0x00075E01 File Offset: 0x00074001
		Private Sub BRemove_Click(sender As Object, e As EventArgs)
			Me.Picture.Image = Resources.photo
		End Sub

		' Token: 0x0601121C RID: 70172 RVA: 0x009EC020 File Offset: 0x009EA220
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

		' Token: 0x0601121D RID: 70173 RVA: 0x009EC078 File Offset: 0x009EA278
		Private Sub txtcrlimit_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtcrlimit.Text
					Dim selectionStart As Integer = Me.txtcrlimit.SelectionStart
					Dim selectionLength As Integer = Me.txtcrlimit.SelectionLength
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

		' Token: 0x0601121E RID: 70174 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601121F RID: 70175 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAddress_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011220 RID: 70176 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCity_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011221 RID: 70177 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbState_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011222 RID: 70178 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtZipCode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011223 RID: 70179 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011224 RID: 70180 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtEmailID_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011225 RID: 70181 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtGSTIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011226 RID: 70182 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtCIN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011227 RID: 70183 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtPAN_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011228 RID: 70184 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtOpeningBalance_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011229 RID: 70185 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbOpeningBalanceType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122A RID: 70186 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122B RID: 70187 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbTCS_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122C RID: 70188 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtcrlimit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122D RID: 70189 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbcrlimit_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122E RID: 70190 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbRoute_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601122F RID: 70191 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011230 RID: 70192 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011231 RID: 70193 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBank_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011232 RID: 70194 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtBranch_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011233 RID: 70195 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtIFSCcode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011234 RID: 70196 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtDiscItem_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011235 RID: 70197 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbDiscStatus_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06011236 RID: 70198 RVA: 0x009EC170 File Offset: 0x009EA370
		Public Sub fillCustomerID()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT RTRIM(ID) FROM Customer order by ID ASC", ModCommonClasses.con)
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

		' Token: 0x06011237 RID: 70199 RVA: 0x009EC2AC File Offset: 0x009EA4AC
		Public Sub NextPrev()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal), Photo, RTRIM(Tcs), RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround),RTRIM(DiscPer),RTRIM(DiscStatus) from Customer where ID=@d1", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.cmbNP.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
					Me.chkvalid()
					Me.txtID.Text = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.txtCustomerID.Text = ModCommonClasses.rdr.GetValue(1).ToString()
					Me.cmbCustomerName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
					Me.txtCustName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
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
					Me.txtRemarks.Text = ModCommonClasses.rdr.GetValue(17).ToString()
					Me.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
					Me.cmbOpeningBalanceType.Text = ModCommonClasses.rdr.GetValue(18).ToString()
					Me.txtOpeningBalance.Text = ModCommonClasses.rdr.GetValue(19).ToString()
					Me.cmbTCS.Text = ModCommonClasses.rdr.GetValue(21).ToString()
					Me.txtcrlimit.Text = ModCommonClasses.rdr.GetValue(24).ToString()
					Me.cmbcrlimit.Text = ModCommonClasses.rdr.GetValue(25).ToString()
					Me.cmbRoute.Text = ModCommonClasses.rdr.GetValue(26).ToString()
					Me.Num1.Text = ModCommonClasses.rdr.GetValue(27).ToString()
					Me.txtDiscItem.Text = ModCommonClasses.rdr.GetValue(28).ToString()
					Me.cmbDiscStatus.Text = ModCommonClasses.rdr.GetValue(29).ToString()
					Dim array As Byte() = CType(ModCommonClasses.rdr.GetValue(20), Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011238 RID: 70200 RVA: 0x00075E15 File Offset: 0x00074015
		Private Sub txtNP_KeyDown(sender As Object, e As KeyEventArgs)
			Me.NextPrev()
			Me.NextPrev()
			Me.NextPrev()
		End Sub

		' Token: 0x06011239 RID: 70201 RVA: 0x009EC72C File Offset: 0x009EA92C
		Private Sub DataforNP()
			ModCommonClasses.con.Close()
			Me.CurrentRow = 0
			ModCommonClasses.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Customer", ModCommonClasses.con)
			Me.Dad.Fill(Me.Dst, "Customer")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Customer").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0601123A RID: 70202 RVA: 0x009EC808 File Offset: 0x009EAA08
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

		' Token: 0x0601123B RID: 70203 RVA: 0x009EC8C4 File Offset: 0x009EAAC4
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

		' Token: 0x0601123C RID: 70204 RVA: 0x009EC970 File Offset: 0x009EAB70
		Private Sub btnLast_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				Me.CurrentRow = Me.Dst.Tables("Customer").Rows.Count - 1
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Customer").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601123D RID: 70205 RVA: 0x009ECA28 File Offset: 0x009EAC28
		Private Sub btnFirst_Click(sender As Object, e As EventArgs)
			Try
				Me.CurrentRow = 0
				Me.cmbNP.Text = Conversions.ToString(Me.Dst.Tables("Customer").Rows(Conversions.ToInteger(Me.CurrentRow))("ID"))
				Me.NextPrev()
				Me.NextPrev()
				Me.NextPrev()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601123E RID: 70206 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub Num1_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601123F RID: 70207 RVA: 0x009ECAC0 File Offset: 0x009EACC0
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbCustomerName.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim reportDocument As ReportDocument = New rptCustomerEnvolve()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				Dim textObject As TextObject = CType(reportDocument.ReportDefinition.Sections("Section1").ReportObjects("Text15"), TextObject)
				textObject.Text = Me.cmbCustomerName.Text
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

		' Token: 0x06011240 RID: 70208 RVA: 0x009ECC7C File Offset: 0x009EAE7C
		Private Sub frmCustomer_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmCustomerRecord.Reset()
			Dim flag As Boolean = Operators.CompareString(Me.Label16.Text, "POS", False) = 0
			If flag Then
				MyProject.Forms.frmPOS.FillCustomers()
			End If
			Dim flag2 As Boolean = Operators.CompareString(Me.Label16.Text, "Estimate", False) = 0
			If flag2 Then
				MyProject.Forms.frmEstimate.FillCustomers()
			End If
			Dim flag3 As Boolean = Operators.CompareString(Me.Label16.Text, "POSTouch", False) = 0
			If flag3 Then
			End If
		End Sub

		' Token: 0x06011241 RID: 70209 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomer_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011242 RID: 70210 RVA: 0x009ECD18 File Offset: 0x009EAF18
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

		' Token: 0x06011243 RID: 70211 RVA: 0x009ECD98 File Offset: 0x009EAF98
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
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbCustomerName.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbCustomerName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbCustomerName, String.Empty)
			End If
		End Sub

		' Token: 0x06011244 RID: 70212 RVA: 0x009ECF24 File Offset: 0x009EB124
		Private Async Sub txtGSTIN_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x06011245 RID: 70213 RVA: 0x009ECF6C File Offset: 0x009EB16C
		Private Sub cmbOpeningBalanceType_MouseHover(sender As Object, e As EventArgs)
			Me.ToolTip1.IsBalloon = True
			Me.ToolTip1.UseAnimation = True
			Me.ToolTip1.ToolTipTitle = ""
			Me.ToolTip1.SetToolTip(Me.cmbOpeningBalanceType, "'DR' for Receivable Amount from Customer" & vbCrLf & "'CR' for Payable Amount to Customer")
		End Sub

		' Token: 0x06011246 RID: 70214 RVA: 0x00075E2D File Offset: 0x0007402D
		Private Sub frmCustomer_Closed(sender As Object, e As EventArgs)
			Me.Label16.Text = ""
		End Sub

		' Token: 0x06011247 RID: 70215 RVA: 0x009ECFBC File Offset: 0x009EB1BC
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
																																							Dim flag37 As Boolean = Operators.CompareString(Me.cmbState.Text, "Telangana", False) = 0
																																							If flag37 Then
																																								Me.lblCode.Text = "(Code : 36)"
																																							Else
																																								Dim flag38 As Boolean = Operators.CompareString(Me.cmbState.Text, "Other Territory", False) = 0
																																								If flag38 Then
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
			End If
		End Sub

		' Token: 0x06011248 RID: 70216 RVA: 0x00075E41 File Offset: 0x00074041
		Private Sub cmbState_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.strsatecondition()
		End Sub

		' Token: 0x06011249 RID: 70217 RVA: 0x009ED7D0 File Offset: 0x009EB9D0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtCustomerID.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please Select the customer name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please fill the contact number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					MyProject.Forms.frmMobileIDDialog.txtAndroidID.Text = ModFunc.MD5Encrypt(Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}).ToString() + Me.txtContactNo.Text.TrimEnd(New Char(-1) {}).ToString())
					MyProject.Forms.frmMobileIDDialog.ShowDialog()
					MyProject.Forms.frmMobileIDDialog.Dispose()
				End If
			End If
		End Sub

		' Token: 0x0601124A RID: 70218 RVA: 0x00075E4B File Offset: 0x0007404B
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0601124B RID: 70219 RVA: 0x009ED8BC File Offset: 0x009EBABC
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0601124C RID: 70220 RVA: 0x009ED940 File Offset: 0x009EBB40
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Customer having count(*) >= 5"
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
				Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
				If flag6 Then
					MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbCustomerName.Focus()
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
									Dim flag11 As Boolean = Me.cmbTCS.SelectedIndex = -1
									If flag11 Then
										MessageBox.Show("Please select TCS applied", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbTCS.Focus()
									Else
										Dim flag12 As Boolean = Operators.CompareString(Me.Num1.Text, "", False) = 0
										If flag12 Then
											MessageBox.Show("Please Enter Turn Around Days, Blank space is not allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.Num1.Focus()
										Else
											Try
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text3 As String = "select RTRIM(Name) from Customer where Name=@d1"
												ModCommonClasses.cmd = New SqlCommand(text3)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
												If flag13 Then
													MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Me.cmbCustomerName.Focus()
													Dim flag14 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag14 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con.Close()
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text4 As String = "select RTRIM(ContactNo) from Customer where ContactNo=@d1"
													ModCommonClasses.cmd = New SqlCommand(text4)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
													If flag15 Then
														MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Me.txtContactNo.Focus()
														Dim flag16 As Boolean = ModCommonClasses.rdr IsNot Nothing
														If flag16 Then
															ModCommonClasses.rdr.Close()
														End If
													Else
														Dim checked As Boolean = Me.chkLoyality.Checked
														Dim num As Integer
														If checked Then
															num = 0
														Else
															num = 1
														End If
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text5 As String = "insert into Customer(ID, CustomerID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,Optype,Opbal,Photo,Tcs,Limit,Lstatus,Route,Taround,DiscPer,DiscStatus,QrCustomer, OpLoyalitytype, OpbalLoyality,is_loyalityDisable,shippingAddress) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@qr, @d31, @d32, @d33,@d34)"
														ModCommonClasses.cmd = New SqlCommand(text5)
														Me.Generate_GiftQR(Me.txtContactNo.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
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
														ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.cmbOpeningBalanceType.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(Me.txtOpeningBalance.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.cmbTCS.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.txtcrlimit.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbcrlimit.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.cmbRoute.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.Num1.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val(Me.txtDiscItem.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.cmbDiscStatus.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.cboxLoyality.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Conversion.Val(Me.txtLoyalitypts.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d33", num)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d34", Me.txtpermentAddress.Text)
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
														Dim flag17 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 1
														If flag17 Then
															ModFunc.LedgerSave(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
															ModFunc.CustomerLedgerSave(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text)
														End If
														Dim flag18 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 0
														If flag18 Then
															ModFunc.LedgerSave(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
															ModFunc.CustomerLedgerSave(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text)
														End If
														Dim flag19 As Boolean = Me.cboxLoyality.SelectedIndex = 1
														If flag19 Then
															ModFunc.LedgerSave_Loyality(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), 0D, Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
															ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text)
														End If
														Dim flag20 As Boolean = Me.cboxLoyality.SelectedIndex = 0
														If flag20 Then
															ModFunc.LedgerSave_Loyality(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text)
															ModFunc.CustomerLedgerSave_Loyality(DateAndTime.Today, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance", 0D, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), Me.txtCustomerID.Text, Me.txtCustNameId.Text, Me.txtRemarks.Text)
														End If
														ModFunc.LogFunc(Me.lblUser.Text, "added the new Customer having Customer id '" + Me.txtCustomerID.Text + "'")
														Dim flag21 As Boolean = Operators.CompareString(Me.Label16.Text, "POSTouch", False) = 0
														If flag21 Then
															MyProject.Forms.frmPOSTouch.Show()
															MyBase.Hide()
															MyProject.Forms.frmPOSTouch.txtCID.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
															MyProject.Forms.frmPOSTouch.txtCustomerID.Text = Me.txtCustomerID.Text
															MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = Me.cmbCustomerName.Text
															MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = Me.cmbState.Text
															MyProject.Forms.frmPOSTouch.txtContactNo.Text = Me.txtContactNo.Text
															MyProject.Forms.frmPOSTouch.txtGSTIN.Text = Me.txtGSTIN.Text
															MyProject.Forms.frmPOSTouch.textmailid.Text = Me.txtEmailID.Text
															MyProject.Forms.frmPOSTouch.txtPan.Text = Me.txtPAN.Text
															MyProject.Forms.frmPOSTouch.txtTCSstatus.Text = Me.cmbTCS.Text
															MyProject.Forms.frmPOSTouch.txtLStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSTouch.txtCustLimit.Text = Conversions.ToString(Conversion.Val(Me.txtcrlimit.Text))
															MyProject.Forms.frmPOSTouch.btnCustomerSelection.Enabled = False
															MyProject.Forms.frmPOSTouch.cmbCustomerName.Enabled = False
															MyProject.Forms.frmPOSTouch.cmbCustomerState.Enabled = False
															MyProject.Forms.frmPOSTouch.TextBox15.[ReadOnly] = True
															MyProject.Forms.frmPOSTouch.Label82.Enabled = False
															MyProject.Forms.frmPOSTouch.CAddress = Me.txtAddress.Text
															MyProject.Forms.frmPOSTouch.txtCustomerDiscPer.Text = Me.txtDiscItem.Text
															MyProject.Forms.frmPOSTouch.txtDiscStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSTouch.GetCustomerBalance()
															MyProject.Forms.frmPOSTouch.GetCustomerBalanceforTCS()
															MyProject.Forms.frmPOSTouch.Calculate12345()
															MyProject.Forms.frmPOSTouch.Calculate143()
															MyProject.Forms.frmPOSTouch.tcsconn()
															MyProject.Forms.frmPOSTouch.InvoiceTCSinfo()
															MyProject.Forms.frmPOSTouch.tcsconn1()
														End If
														Dim flag22 As Boolean = Operators.CompareString(Me.Label16.Text, "POSTouchNew", False) = 0
														If flag22 Then
															MyProject.Forms.frmPOSNewTuch.Show()
															MyBase.Hide()
															MyProject.Forms.frmPOSNewTuch.txtCID.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
															MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = Me.txtCustomerID.Text
															MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = Me.cmbCustomerName.Text
															MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = Me.cmbState.Text
															MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = Me.txtContactNo.Text
															MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = Me.txtGSTIN.Text
															MyProject.Forms.frmPOSNewTuch.textmailid.Text = Me.txtEmailID.Text
															MyProject.Forms.frmPOSNewTuch.txtPan.Text = Me.txtPAN.Text
															MyProject.Forms.frmPOSNewTuch.txtTCSstatus.Text = Me.cmbTCS.Text
															MyProject.Forms.frmPOSNewTuch.txtLStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSNewTuch.txtCustLimit.Text = Conversions.ToString(Conversion.Val(Me.txtcrlimit.Text))
															MyProject.Forms.frmPOSNewTuch.btnCustomerSelection.Enabled = False
															MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
															MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Enabled = False
															MyProject.Forms.frmPOSNewTuch.TextBox15.[ReadOnly] = True
															MyProject.Forms.frmPOSNewTuch.Label82.Enabled = False
															MyProject.Forms.frmPOSNewTuch.CAddress = Me.txtAddress.Text
															MyProject.Forms.frmPOSNewTuch.txtCustomerDiscPer.Text = Me.txtDiscItem.Text
															MyProject.Forms.frmPOSNewTuch.txtDiscStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSNewTuch.GetCustomerBalance()
															MyProject.Forms.frmPOSNewTuch.GetCustomerBalanceforTCS()
															MyProject.Forms.frmPOSNewTuch.Calculate12345()
															MyProject.Forms.frmPOSNewTuch.Calculate143()
															MyProject.Forms.frmPOSNewTuch.tcsconn()
															MyProject.Forms.frmPOSNewTuch.InvoiceTCSinfo()
															MyProject.Forms.frmPOSNewTuch.tcsconn1()
														End If
														Dim flag23 As Boolean = Operators.CompareString(Me.Label16.Text, "POSTouchNew_Quotation", False) = 0
														If flag23 Then
															MyProject.Forms.frmPOSNewTuch_Quotation.Show()
															MyBase.Hide()
															MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = Conversions.ToString(Conversion.Val(Me.txtID.Text))
															MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = Me.txtCustomerID.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = Me.cmbCustomerName.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = Me.cmbState.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = Me.txtContactNo.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = Me.txtGSTIN.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.textmailid.Text = Me.txtEmailID.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtPan.Text = Me.txtPAN.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSstatus.Text = Me.cmbTCS.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtLStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtCustLimit.Text = Conversions.ToString(Conversion.Val(Me.txtcrlimit.Text))
															MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
															MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
															MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
															MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
															MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
															MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = Me.txtAddress.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerDiscPer.Text = Me.txtDiscItem.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.txtDiscStatus.Text = Me.cmbDiscStatus.Text
															MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalance()
															MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalanceforTCS()
															MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
															MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
															MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn()
															MyProject.Forms.frmPOSNewTuch_Quotation.InvoiceTCSinfo()
															MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn1()
														End If
														MessageBox.Show("Successfully Saved", "Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.fillCustomerID()
														Me.btnSave.Enabled = False
														Me.txtPhNo.Text = ""
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
			End If
		End Sub

		' Token: 0x0601124D RID: 70221 RVA: 0x009EF000 File Offset: 0x009ED200
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbCustomerName.Text.Trim(), "Cash", False) = 0
			If flag Then
				MessageBox.Show("'Cash' account is not allowed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), "C-0001", False) = 0
				If flag2 Then
					MessageBox.Show("'Cash' account is not allowed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbCustomerName.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.cmbCustomerName.Focus()
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
									Dim flag7 As Boolean = Operators.CompareString(Me.cmbState.Text, "", False) = 0
									If flag7 Then
										MessageBox.Show("Please enter state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbState.Focus()
									Else
										Dim flag8 As Boolean = Strings.Len(Strings.Trim(Me.txtContactNo.Text)) = 0
										If flag8 Then
											MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Me.txtContactNo.Focus()
										Else
											Dim flag9 As Boolean = Me.cmbTCS.SelectedIndex = -1
											If flag9 Then
												MessageBox.Show("Please select TCS applied", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Me.cmbTCS.Focus()
											Else
												Dim flag10 As Boolean = Operators.CompareString(Me.Num1.Text, "", False) = 0
												If flag10 Then
													MessageBox.Show("Please Enter Turn Around Days, Blank space is not allowed", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Me.Num1.Focus()
												Else
													Try
														Dim flag11 As Boolean = Operators.CompareString(Me.txtCustName.Text, Me.cmbCustomerName.Text, False) = 0
														If Not flag11 Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text As String = "select RTRIM(Name) from Customer where Name=@d1"
															ModCommonClasses.cmd = New SqlCommand(text)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbCustomerName.Text)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag12 As Boolean = ModCommonClasses.rdr.Read()
															If flag12 Then
																MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Me.cmbCustomerName.Focus()
																Dim flag13 As Boolean = ModCommonClasses.rdr IsNot Nothing
																If flag13 Then
																	ModCommonClasses.rdr.Close()
																End If
																Return
															End If
															ModCommonClasses.con.Close()
														End If
														Dim flag14 As Boolean = Operators.CompareString(Me.txtPhNo.Text, Me.txtContactNo.Text, False) = 0
														If Not flag14 Then
															ModCommonClasses.con = New SqlConnection(ModCS.cs)
															ModCommonClasses.con.Open()
															Dim text2 As String = "select RTRIM(ContactNo) from Customer where ContactNo=@d1"
															ModCommonClasses.cmd = New SqlCommand(text2)
															ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactNo.Text)
															ModCommonClasses.cmd.Connection = ModCommonClasses.con
															ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
															Dim flag15 As Boolean = ModCommonClasses.rdr.Read()
															If flag15 Then
																MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																Me.txtContactNo.Focus()
																Dim flag16 As Boolean = ModCommonClasses.rdr IsNot Nothing
																If flag16 Then
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
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text4 As String = "update CustomerLedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
														ModCommonClasses.cmd = New SqlCommand(text4)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text5 As String = "update CustomerLedgerBook set CustNameid=@d3 where PartyID=@d1"
														ModCommonClasses.cmd = New SqlCommand(text5)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustNameId.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text6 As String = "update LedgerBook_Loyality set [Name]=@d3 where PartyID=@d1 and Name=@d2"
														ModCommonClasses.cmd = New SqlCommand(text6)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text7 As String = "update CustomerLedgerBook_Loyality set [Name]=@d3 where PartyID=@d1 and Name=@d2"
														ModCommonClasses.cmd = New SqlCommand(text7)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text8 As String = "update CustomerLedgerBook_Loyality set CustNameid=@d3 where PartyID=@d1"
														ModCommonClasses.cmd = New SqlCommand(text8)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustNameId.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text9 As String = "update Journal set Name=@d3 where CSID=@d1 and Name=@d2"
														ModCommonClasses.cmd = New SqlCommand(text9)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustName.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModCommonClasses.con.Close()
														Me.Generate_GiftQR(Me.txtContactNo.Text)
														Dim checked As Boolean = Me.chkLoyality.Checked
														Dim num As Integer
														If checked Then
															num = 0
														Else
															num = 1
														End If
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text10 As String = "update Customer set CustomerID=@d2,[Name]=@d3, Address=@d5,City=@d6, ContactNo=@d7, EmailID=@d8,Remarks=@d9,State=@d10,ZipCode=@d11,GSTIN=@d12,CIN=@d14,PAN=@d15,AccountName=@d16,AccountNumber=@d17,Bank=@d18,Branch=@d19,IFSCCode=@d20,Optype=@d21,Opbal=@d22,Photo=@d23,Tcs=@d24,Limit=@d25,Lstatus=@d26,Route=@d27,Taround=@d28,DiscPer=@d29,DiscStatus=@d30,QrCustomer=@qr, OpLoyalitytype=@d31,OpbalLoyality=@d32,is_loyalityDisable=@d33,shippingAddress=@d34 where ID=@d1"
														ModCommonClasses.cmd = New SqlCommand(text10)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustomerID.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.cmbCustomerName.Text)
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
														ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Me.cmbOpeningBalanceType.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val(Me.txtOpeningBalance.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.cmbTCS.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val(Me.txtcrlimit.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d26", Me.cmbcrlimit.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Me.cmbRoute.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(Me.Num1.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val(Me.txtDiscItem.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d30", Me.cmbDiscStatus.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d31", Me.cboxLoyality.Text)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d32", Conversion.Val(Me.txtLoyalitypts.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d33", num)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d34", Me.txtpermentAddress.Text)
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
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.ExecuteNonQuery()
														ModFunc.LogFunc(Me.lblUser.Text, "updated the Customer having Customer id '" + Me.txtCustomerID.Text + "'")
														MessageBox.Show("Successfully Updated", "Customer Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
														Me.btnUpdate.Enabled = False
														ModCommonClasses.con.Close()
														Me.txtPhNo.Text = ""
														Dim flag17 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 1
														If flag17 Then
															ModFunc.LedgerUpdate1(Me.cmbCustomerName.Text, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance")
															ModFunc.CustomerLedgerUpdate1(Me.cmbCustomerName.Text, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), 0D, Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtCustomerID.Text, "Opening Balance")
														End If
														Dim flag18 As Boolean = Me.cmbOpeningBalanceType.SelectedIndex = 0
														If flag18 Then
															ModFunc.LedgerUpdate1(Me.cmbCustomerName.Text, 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance")
															ModFunc.CustomerLedgerUpdate1(Me.cmbCustomerName.Text, 0D, New Decimal(Conversion.Val(Me.txtOpeningBalance.Text)), Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtCustomerID.Text, "Opening Balance")
														End If
														Dim flag19 As Boolean = Me.cboxLoyality.SelectedIndex = 1
														If flag19 Then
															ModFunc.LedgerUpdate1_Loyality(Me.cmbCustomerName.Text, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), 0D, Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance")
															ModFunc.CustomerLedgerUpdate1_Loyality(Me.cmbCustomerName.Text, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), 0D, Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtCustomerID.Text, "Opening Balance")
														End If
														Dim flag20 As Boolean = Me.cboxLoyality.SelectedIndex = 0
														If flag20 Then
															ModFunc.LedgerUpdate1_Loyality(Me.cmbCustomerName.Text, 0D, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), Me.txtCustomerID.Text, Me.cmbCustomerName.Text, Me.txtCustomerID.Text, "Opening Balance")
															ModFunc.CustomerLedgerUpdate1_Loyality(Me.cmbCustomerName.Text, 0D, New Decimal(Conversion.Val(Me.txtLoyalitypts.Text)), Me.txtCustNameId.Text, Me.txtRemarks.Text, Me.txtCustomerID.Text, "Opening Balance")
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
					End If
				End If
			End If
		End Sub

		' Token: 0x0601124E RID: 70222 RVA: 0x009F0200 File Offset: 0x009EE400
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

		' Token: 0x0601124F RID: 70223 RVA: 0x009F0268 File Offset: 0x009EE468
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim frmCustomerRecord As frmCustomerRecord = New frmCustomerRecord()
			frmCustomerRecord.btnAddCustomer.Visible = False
			frmCustomerRecord.lblSet.Text = "Customer Entry"
			frmCustomerRecord.Getdata()
			frmCustomerRecord.ShowDialog()
			frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x06011250 RID: 70224 RVA: 0x009F02B0 File Offset: 0x009EE4B0
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

		' Token: 0x06011251 RID: 70225 RVA: 0x009F02F8 File Offset: 0x009EE4F8
		Public Async Function PerformOCR(imagePath As String) As Task
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim requestData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From { { "model", "gpt-4o-mini" }, { "messages", New List(Of Object)() From { New Dictionary(Of String, String)() From { { "role", "system" }, { "content", "You are an OCR assistant. From the invoice image, extract only the buyer details and return them in JSON format with the following fields:" & vbCrLf & vbCrLf & "buyer: {" & vbCrLf & "    name: Buyer's full name or company name," & vbCrLf & "    address: Complete address as found in the invoice," & vbCrLf & "    city: City name (if present or identify from address also)," & vbCrLf & "    state: State name (if present or identify from address also)," & vbCrLf & "    pincode: Postal/ZIP code (if present or identify from address also)," & vbCrLf & "    gst_number: Buyer's GSTIN number (if present)," & vbCrLf & "    phone_number: Buyer's phone number (if present)," & vbCrLf & "    email: Buyer's email address (if present)" & vbCrLf & "}" & vbCrLf & vbCrLf & "If any field is missing or not visible in the image, set it as null. Return only the structured JSON. Do not include explanations or other text." } }, New Dictionary(Of String, Object)() From { { "role", "user" }, { "content", New List(Of Object)() From { New Dictionary(Of String, Object)() From { { "type", "image_url" }, { "image_url", New Dictionary(Of String, String)() From { { "url", "data:image/jpeg;base64," + base64Image } } } } } } } } }, { "temperature", 0.2 } }
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
							If parsedJson("buyer") IsNot Nothing Then
								Dim supplier As JObject = CType(parsedJson("buyer"), JObject)
								Me.Invoke(New VB_AnonymousDelegate_0(Sub()
									Dim cmbCustomerName As ComboBox = Me.cmbCustomerName
									Dim jtoken As JToken = supplier("name")
									cmbCustomerName.Text = If((jtoken IsNot Nothing), jtoken.ToString(), Nothing)
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
								MessageBox.Show("No buyer details found in OCR response.")
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

		' Token: 0x06011252 RID: 70226 RVA: 0x009F0344 File Offset: 0x009EE544
		Private Sub chksameAddress_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chksameAddress.Checked
			If checked Then
				Me.txtpermentAddress.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Me.txtAddress.Text, Interaction.IIf(Operators.CompareString(Me.txtCity.Text.Trim(), "", False) <> 0, "," + Me.txtCity.Text, "")), Interaction.IIf(Operators.CompareString(Me.cmbState.Text.Trim(), "", False) <> 0, "," + Me.cmbState.Text, "")), Interaction.IIf(Operators.CompareString(Me.txtZipCode.Text.Trim(), "", False) <> 0, "," + Me.txtZipCode.Text, "")))
			Else
				Me.txtpermentAddress.Text = String.Empty
			End If
		End Sub

		' Token: 0x06011253 RID: 70227 RVA: 0x009F045C File Offset: 0x009EE65C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection.")
			Else
				Dim frmGSheet_Report As frmGSheet_Report = New frmGSheet_Report()
				frmGSheet_Report.ShowDialog()
				frmGSheet_Report.Dispose()
			End If
		End Sub

		' Token: 0x06011254 RID: 70228 RVA: 0x009F0498 File Offset: 0x009EE698
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomersNew.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomersNew.lblUserType.Text = Me.Label31.Text
			MyProject.Forms.frmCustomersNew.lblCName.Text = Me.lblCPhone.Text
			MyProject.Forms.frmCustomersNew.ShowDialog()
		End Sub

		' Token: 0x040066ED RID: 26349
		Private Photoname As String

		' Token: 0x040066EE RID: 26350
		Private IsImageChanged As Boolean

		' Token: 0x040066EF RID: 26351
		Private apiKey As String

		' Token: 0x040066F0 RID: 26352
		Private url As String

		' Token: 0x040066F1 RID: 26353
		Private Dad As SqlDataAdapter

		' Token: 0x040066F2 RID: 26354
		Private Dst As DataSet

		' Token: 0x040066F3 RID: 26355
		Private CurrentRow As Object
	End Class
End Namespace
