Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports ClosedXML.Excel
Imports DevNet
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json.Linq
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000081 RID: 129
	<DesignerGenerated()>
	Public Partial Class frmProductSmart
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001548 RID: 5448 RVA: 0x000E61A4 File Offset: 0x000E43A4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmProductRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmProductRecord_KeyDown
			Me.shouldHandleSelectedIndexChanged = False
			Me.dt = New DataTable()
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.apiKey = ""
			Me.url = ""
			Me.prevCell = Nothing
			Me.leftnavigationhappened = False
			Me.Dst = New DataSet()
			Me.defaultSubCategoryId = 0
			Me.defaultCatSubText = ""
			Me.defaultCategory = ""
			Me.defaultSubCategory = ""
			Me.unit = ""
			Me.Rate = 0.0
			Me.stax_type = ""
			Me.Ptax_type = ""
			Me.DRate = 0.0
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700088D RID: 2189
		' (get) Token: 0x0600154B RID: 5451 RVA: 0x00011590 File Offset: 0x0000F790
		' (set) Token: 0x0600154C RID: 5452 RVA: 0x0001159A File Offset: 0x0000F79A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700088E RID: 2190
		' (get) Token: 0x0600154D RID: 5453 RVA: 0x000115A3 File Offset: 0x0000F7A3
		' (set) Token: 0x0600154E RID: 5454 RVA: 0x000115AD File Offset: 0x0000F7AD
		Friend Overridable Property lblSet As Label

		' Token: 0x1700088F RID: 2191
		' (get) Token: 0x0600154F RID: 5455 RVA: 0x000115B6 File Offset: 0x0000F7B6
		' (set) Token: 0x06001550 RID: 5456 RVA: 0x000115C0 File Offset: 0x0000F7C0
		Friend Overridable Property txtCategory As TextBox

		' Token: 0x17000890 RID: 2192
		' (get) Token: 0x06001551 RID: 5457 RVA: 0x000115C9 File Offset: 0x0000F7C9
		' (set) Token: 0x06001552 RID: 5458 RVA: 0x000115D3 File Offset: 0x0000F7D3
		Friend Overridable Property Label2 As Label

		' Token: 0x17000891 RID: 2193
		' (get) Token: 0x06001553 RID: 5459 RVA: 0x000115DC File Offset: 0x0000F7DC
		' (set) Token: 0x06001554 RID: 5460 RVA: 0x000115E6 File Offset: 0x0000F7E6
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17000892 RID: 2194
		' (get) Token: 0x06001555 RID: 5461 RVA: 0x000115EF File Offset: 0x0000F7EF
		' (set) Token: 0x06001556 RID: 5462 RVA: 0x000115F9 File Offset: 0x0000F7F9
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000893 RID: 2195
		' (get) Token: 0x06001557 RID: 5463 RVA: 0x00011602 File Offset: 0x0000F802
		' (set) Token: 0x06001558 RID: 5464 RVA: 0x0001160C File Offset: 0x0000F80C
		Friend Overridable Property txtProductName As TextBox

		' Token: 0x17000894 RID: 2196
		' (get) Token: 0x06001559 RID: 5465 RVA: 0x00011615 File Offset: 0x0000F815
		' (set) Token: 0x0600155A RID: 5466 RVA: 0x0001161F File Offset: 0x0000F81F
		Friend Overridable Property Label3 As Label

		' Token: 0x17000895 RID: 2197
		' (get) Token: 0x0600155B RID: 5467 RVA: 0x00011628 File Offset: 0x0000F828
		' (set) Token: 0x0600155C RID: 5468 RVA: 0x00011632 File Offset: 0x0000F832
		Friend Overridable Property Label4 As Label

		' Token: 0x17000896 RID: 2198
		' (get) Token: 0x0600155D RID: 5469 RVA: 0x0001163B File Offset: 0x0000F83B
		' (set) Token: 0x0600155E RID: 5470 RVA: 0x00011645 File Offset: 0x0000F845
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x17000897 RID: 2199
		' (get) Token: 0x0600155F RID: 5471 RVA: 0x0001164E File Offset: 0x0000F84E
		' (set) Token: 0x06001560 RID: 5472 RVA: 0x00011658 File Offset: 0x0000F858
		Friend Overridable Property Label5 As Label

		' Token: 0x17000898 RID: 2200
		' (get) Token: 0x06001561 RID: 5473 RVA: 0x00011661 File Offset: 0x0000F861
		' (set) Token: 0x06001562 RID: 5474 RVA: 0x0001166B File Offset: 0x0000F86B
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17000899 RID: 2201
		' (get) Token: 0x06001563 RID: 5475 RVA: 0x00011674 File Offset: 0x0000F874
		' (set) Token: 0x06001564 RID: 5476 RVA: 0x0001167E File Offset: 0x0000F87E
		Friend Overridable Property Label6 As Label

		' Token: 0x1700089A RID: 2202
		' (get) Token: 0x06001565 RID: 5477 RVA: 0x00011687 File Offset: 0x0000F887
		' (set) Token: 0x06001566 RID: 5478 RVA: 0x00011691 File Offset: 0x0000F891
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700089B RID: 2203
		' (get) Token: 0x06001567 RID: 5479 RVA: 0x0001169A File Offset: 0x0000F89A
		' (set) Token: 0x06001568 RID: 5480 RVA: 0x000116A4 File Offset: 0x0000F8A4
		Friend Overridable Property ComboBox1 As ComboBox

		' Token: 0x1700089C RID: 2204
		' (get) Token: 0x06001569 RID: 5481 RVA: 0x000116AD File Offset: 0x0000F8AD
		' (set) Token: 0x0600156A RID: 5482 RVA: 0x000116B7 File Offset: 0x0000F8B7
		Friend Overridable Property Label7 As Label

		' Token: 0x1700089D RID: 2205
		' (get) Token: 0x0600156B RID: 5483 RVA: 0x000116C0 File Offset: 0x0000F8C0
		' (set) Token: 0x0600156C RID: 5484 RVA: 0x000116CA File Offset: 0x0000F8CA
		Friend Overridable Property Label9 As Label

		' Token: 0x1700089E RID: 2206
		' (get) Token: 0x0600156D RID: 5485 RVA: 0x000116D3 File Offset: 0x0000F8D3
		' (set) Token: 0x0600156E RID: 5486 RVA: 0x000116DD File Offset: 0x0000F8DD
		Friend Overridable Property cmbRack As ComboBox

		' Token: 0x1700089F RID: 2207
		' (get) Token: 0x0600156F RID: 5487 RVA: 0x000116E6 File Offset: 0x0000F8E6
		' (set) Token: 0x06001570 RID: 5488 RVA: 0x000116F0 File Offset: 0x0000F8F0
		Friend Overridable Property Label8 As Label

		' Token: 0x170008A0 RID: 2208
		' (get) Token: 0x06001571 RID: 5489 RVA: 0x000116F9 File Offset: 0x0000F8F9
		' (set) Token: 0x06001572 RID: 5490 RVA: 0x00011703 File Offset: 0x0000F903
		Friend Overridable Property cmbGDown As ComboBox

		' Token: 0x170008A1 RID: 2209
		' (get) Token: 0x06001573 RID: 5491 RVA: 0x0001170C File Offset: 0x0000F90C
		' (set) Token: 0x06001574 RID: 5492 RVA: 0x000EC878 File Offset: 0x000EAA78
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

		' Token: 0x170008A2 RID: 2210
		' (get) Token: 0x06001575 RID: 5493 RVA: 0x00011716 File Offset: 0x0000F916
		' (set) Token: 0x06001576 RID: 5494 RVA: 0x000EC8BC File Offset: 0x000EAABC
		Private _txtTopResult As TextBox
		Friend Overridable Property txtTopResult As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTopResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtTopResult_TextChanged
				Dim textBox As TextBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTopResult = value
				textBox = Me._txtTopResult
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008A3 RID: 2211
		' (get) Token: 0x06001577 RID: 5495 RVA: 0x00011720 File Offset: 0x0000F920
		' (set) Token: 0x06001578 RID: 5496 RVA: 0x0001172A File Offset: 0x0000F92A
		Friend Overridable Property txtID As TextBox

		' Token: 0x170008A4 RID: 2212
		' (get) Token: 0x06001579 RID: 5497 RVA: 0x00011733 File Offset: 0x0000F933
		' (set) Token: 0x0600157A RID: 5498 RVA: 0x0001173D File Offset: 0x0000F93D
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x170008A5 RID: 2213
		' (get) Token: 0x0600157B RID: 5499 RVA: 0x00011746 File Offset: 0x0000F946
		' (set) Token: 0x0600157C RID: 5500 RVA: 0x00011750 File Offset: 0x0000F950
		Friend Overridable Property txtBarcodeTempStock As TextBox

		' Token: 0x170008A6 RID: 2214
		' (get) Token: 0x0600157D RID: 5501 RVA: 0x00011759 File Offset: 0x0000F959
		' (set) Token: 0x0600157E RID: 5502 RVA: 0x00011763 File Offset: 0x0000F963
		Friend Overridable Property txtBar As TextBox

		' Token: 0x170008A7 RID: 2215
		' (get) Token: 0x0600157F RID: 5503 RVA: 0x0001176C File Offset: 0x0000F96C
		' (set) Token: 0x06001580 RID: 5504 RVA: 0x00011776 File Offset: 0x0000F976
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x170008A8 RID: 2216
		' (get) Token: 0x06001581 RID: 5505 RVA: 0x0001177F File Offset: 0x0000F97F
		' (set) Token: 0x06001582 RID: 5506 RVA: 0x00011789 File Offset: 0x0000F989
		Friend Overridable Property cmbNP As ComboBox

		' Token: 0x170008A9 RID: 2217
		' (get) Token: 0x06001583 RID: 5507 RVA: 0x00011792 File Offset: 0x0000F992
		' (set) Token: 0x06001584 RID: 5508 RVA: 0x0001179C File Offset: 0x0000F99C
		Friend Overridable Property txtNP As TextBox

		' Token: 0x170008AA RID: 2218
		' (get) Token: 0x06001585 RID: 5509 RVA: 0x000117A5 File Offset: 0x0000F9A5
		' (set) Token: 0x06001586 RID: 5510 RVA: 0x000117AF File Offset: 0x0000F9AF
		Friend Overridable Property txtID_Update As TextBox

		' Token: 0x170008AB RID: 2219
		' (get) Token: 0x06001587 RID: 5511 RVA: 0x000117B8 File Offset: 0x0000F9B8
		' (set) Token: 0x06001588 RID: 5512 RVA: 0x000117C2 File Offset: 0x0000F9C2
		Friend Overridable Property txtbarcodeNocopy As TextBox

		' Token: 0x170008AC RID: 2220
		' (get) Token: 0x06001589 RID: 5513 RVA: 0x000117CB File Offset: 0x0000F9CB
		' (set) Token: 0x0600158A RID: 5514 RVA: 0x000117D5 File Offset: 0x0000F9D5
		Friend Overridable Property Label12 As Label

		' Token: 0x170008AD RID: 2221
		' (get) Token: 0x0600158B RID: 5515 RVA: 0x000117DE File Offset: 0x0000F9DE
		' (set) Token: 0x0600158C RID: 5516 RVA: 0x000117E8 File Offset: 0x0000F9E8
		Public Overridable Property Picture As PictureBox

		' Token: 0x170008AE RID: 2222
		' (get) Token: 0x0600158D RID: 5517 RVA: 0x000117F1 File Offset: 0x0000F9F1
		' (set) Token: 0x0600158E RID: 5518 RVA: 0x000117FB File Offset: 0x0000F9FB
		Friend Overridable Property ComboBox2 As ComboBox

		' Token: 0x170008AF RID: 2223
		' (get) Token: 0x0600158F RID: 5519 RVA: 0x00011804 File Offset: 0x0000FA04
		' (set) Token: 0x06001590 RID: 5520 RVA: 0x000EC900 File Offset: 0x000EAB00
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

		' Token: 0x170008B0 RID: 2224
		' (get) Token: 0x06001591 RID: 5521 RVA: 0x0001180E File Offset: 0x0000FA0E
		' (set) Token: 0x06001592 RID: 5522 RVA: 0x00011818 File Offset: 0x0000FA18
		Friend Overridable Property txtCompany As TextBox

		' Token: 0x170008B1 RID: 2225
		' (get) Token: 0x06001593 RID: 5523 RVA: 0x00011821 File Offset: 0x0000FA21
		' (set) Token: 0x06001594 RID: 5524 RVA: 0x0001182B File Offset: 0x0000FA2B
		Friend Overridable Property pnlVariant As Panel

		' Token: 0x170008B2 RID: 2226
		' (get) Token: 0x06001595 RID: 5525 RVA: 0x00011834 File Offset: 0x0000FA34
		' (set) Token: 0x06001596 RID: 5526 RVA: 0x0001183E File Offset: 0x0000FA3E
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x170008B3 RID: 2227
		' (get) Token: 0x06001597 RID: 5527 RVA: 0x00011847 File Offset: 0x0000FA47
		' (set) Token: 0x06001598 RID: 5528 RVA: 0x00011851 File Offset: 0x0000FA51
		Friend Overridable Property Label13 As Label

		' Token: 0x170008B4 RID: 2228
		' (get) Token: 0x06001599 RID: 5529 RVA: 0x0001185A File Offset: 0x0000FA5A
		' (set) Token: 0x0600159A RID: 5530 RVA: 0x00011864 File Offset: 0x0000FA64
		Friend Overridable Property Label14 As Label

		' Token: 0x170008B5 RID: 2229
		' (get) Token: 0x0600159B RID: 5531 RVA: 0x0001186D File Offset: 0x0000FA6D
		' (set) Token: 0x0600159C RID: 5532 RVA: 0x00011877 File Offset: 0x0000FA77
		Friend Overridable Property DataGridViewImageColumn2 As DataGridViewImageColumn

		' Token: 0x170008B6 RID: 2230
		' (get) Token: 0x0600159D RID: 5533 RVA: 0x00011880 File Offset: 0x0000FA80
		' (set) Token: 0x0600159E RID: 5534 RVA: 0x0001188A File Offset: 0x0000FA8A
		Friend Overridable Property PID2 As DataGridViewTextBoxColumn

		' Token: 0x170008B7 RID: 2231
		' (get) Token: 0x0600159F RID: 5535 RVA: 0x00011893 File Offset: 0x0000FA93
		' (set) Token: 0x060015A0 RID: 5536 RVA: 0x0001189D File Offset: 0x0000FA9D
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x170008B8 RID: 2232
		' (get) Token: 0x060015A1 RID: 5537 RVA: 0x000118A6 File Offset: 0x0000FAA6
		' (set) Token: 0x060015A2 RID: 5538 RVA: 0x000118B0 File Offset: 0x0000FAB0
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x170008B9 RID: 2233
		' (get) Token: 0x060015A3 RID: 5539 RVA: 0x000118B9 File Offset: 0x0000FAB9
		' (set) Token: 0x060015A4 RID: 5540 RVA: 0x000118C3 File Offset: 0x0000FAC3
		Friend Overridable Property CategoryName As DataGridViewTextBoxColumn

		' Token: 0x170008BA RID: 2234
		' (get) Token: 0x060015A5 RID: 5541 RVA: 0x000118CC File Offset: 0x0000FACC
		' (set) Token: 0x060015A6 RID: 5542 RVA: 0x000118D6 File Offset: 0x0000FAD6
		Friend Overridable Property DataGridViewButtonColumn1 As DataGridViewButtonColumn

		' Token: 0x170008BB RID: 2235
		' (get) Token: 0x060015A7 RID: 5543 RVA: 0x000118DF File Offset: 0x0000FADF
		' (set) Token: 0x060015A8 RID: 5544 RVA: 0x000118E9 File Offset: 0x0000FAE9
		Friend Overridable Property SubCategoryName As DataGridViewTextBoxColumn

		' Token: 0x170008BC RID: 2236
		' (get) Token: 0x060015A9 RID: 5545 RVA: 0x000118F2 File Offset: 0x0000FAF2
		' (set) Token: 0x060015AA RID: 5546 RVA: 0x000118FC File Offset: 0x0000FAFC
		Friend Overridable Property DataGridViewButtonColumn2 As DataGridViewButtonColumn

		' Token: 0x170008BD RID: 2237
		' (get) Token: 0x060015AB RID: 5547 RVA: 0x00011905 File Offset: 0x0000FB05
		' (set) Token: 0x060015AC RID: 5548 RVA: 0x0001190F File Offset: 0x0000FB0F
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x170008BE RID: 2238
		' (get) Token: 0x060015AD RID: 5549 RVA: 0x00011918 File Offset: 0x0000FB18
		' (set) Token: 0x060015AE RID: 5550 RVA: 0x00011922 File Offset: 0x0000FB22
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x170008BF RID: 2239
		' (get) Token: 0x060015AF RID: 5551 RVA: 0x0001192B File Offset: 0x0000FB2B
		' (set) Token: 0x060015B0 RID: 5552 RVA: 0x00011935 File Offset: 0x0000FB35
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x170008C0 RID: 2240
		' (get) Token: 0x060015B1 RID: 5553 RVA: 0x0001193E File Offset: 0x0000FB3E
		' (set) Token: 0x060015B2 RID: 5554 RVA: 0x00011948 File Offset: 0x0000FB48
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x170008C1 RID: 2241
		' (get) Token: 0x060015B3 RID: 5555 RVA: 0x00011951 File Offset: 0x0000FB51
		' (set) Token: 0x060015B4 RID: 5556 RVA: 0x0001195B File Offset: 0x0000FB5B
		Friend Overridable Property CostPrice As DataGridViewTextBoxColumn

		' Token: 0x170008C2 RID: 2242
		' (get) Token: 0x060015B5 RID: 5557 RVA: 0x00011964 File Offset: 0x0000FB64
		' (set) Token: 0x060015B6 RID: 5558 RVA: 0x0001196E File Offset: 0x0000FB6E
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x170008C3 RID: 2243
		' (get) Token: 0x060015B7 RID: 5559 RVA: 0x00011977 File Offset: 0x0000FB77
		' (set) Token: 0x060015B8 RID: 5560 RVA: 0x00011981 File Offset: 0x0000FB81
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x170008C4 RID: 2244
		' (get) Token: 0x060015B9 RID: 5561 RVA: 0x0001198A File Offset: 0x0000FB8A
		' (set) Token: 0x060015BA RID: 5562 RVA: 0x00011994 File Offset: 0x0000FB94
		Friend Overridable Property cmbGST1 As DataGridViewTextBoxColumn

		' Token: 0x170008C5 RID: 2245
		' (get) Token: 0x060015BB RID: 5563 RVA: 0x0001199D File Offset: 0x0000FB9D
		' (set) Token: 0x060015BC RID: 5564 RVA: 0x000119A7 File Offset: 0x0000FBA7
		Friend Overridable Property DataGridViewButtonColumn3 As DataGridViewButtonColumn

		' Token: 0x170008C6 RID: 2246
		' (get) Token: 0x060015BD RID: 5565 RVA: 0x000119B0 File Offset: 0x0000FBB0
		' (set) Token: 0x060015BE RID: 5566 RVA: 0x000119BA File Offset: 0x0000FBBA
		Friend Overridable Property DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn

		' Token: 0x170008C7 RID: 2247
		' (get) Token: 0x060015BF RID: 5567 RVA: 0x000119C3 File Offset: 0x0000FBC3
		' (set) Token: 0x060015C0 RID: 5568 RVA: 0x000119CD File Offset: 0x0000FBCD
		Friend Overridable Property DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn

		' Token: 0x170008C8 RID: 2248
		' (get) Token: 0x060015C1 RID: 5569 RVA: 0x000119D6 File Offset: 0x0000FBD6
		' (set) Token: 0x060015C2 RID: 5570 RVA: 0x000119E0 File Offset: 0x0000FBE0
		Friend Overridable Property DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn

		' Token: 0x170008C9 RID: 2249
		' (get) Token: 0x060015C3 RID: 5571 RVA: 0x000119E9 File Offset: 0x0000FBE9
		' (set) Token: 0x060015C4 RID: 5572 RVA: 0x000119F3 File Offset: 0x0000FBF3
		Friend Overridable Property DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn

		' Token: 0x170008CA RID: 2250
		' (get) Token: 0x060015C5 RID: 5573 RVA: 0x000119FC File Offset: 0x0000FBFC
		' (set) Token: 0x060015C6 RID: 5574 RVA: 0x00011A06 File Offset: 0x0000FC06
		Friend Overridable Property DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn

		' Token: 0x170008CB RID: 2251
		' (get) Token: 0x060015C7 RID: 5575 RVA: 0x00011A0F File Offset: 0x0000FC0F
		' (set) Token: 0x060015C8 RID: 5576 RVA: 0x00011A19 File Offset: 0x0000FC19
		Friend Overridable Property DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn

		' Token: 0x170008CC RID: 2252
		' (get) Token: 0x060015C9 RID: 5577 RVA: 0x00011A22 File Offset: 0x0000FC22
		' (set) Token: 0x060015CA RID: 5578 RVA: 0x00011A2C File Offset: 0x0000FC2C
		Friend Overridable Property DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn

		' Token: 0x170008CD RID: 2253
		' (get) Token: 0x060015CB RID: 5579 RVA: 0x00011A35 File Offset: 0x0000FC35
		' (set) Token: 0x060015CC RID: 5580 RVA: 0x00011A3F File Offset: 0x0000FC3F
		Friend Overridable Property cmbPurchaseUnit2 As DataGridViewTextBoxColumn

		' Token: 0x170008CE RID: 2254
		' (get) Token: 0x060015CD RID: 5581 RVA: 0x00011A48 File Offset: 0x0000FC48
		' (set) Token: 0x060015CE RID: 5582 RVA: 0x00011A52 File Offset: 0x0000FC52
		Friend Overridable Property cmbSalesUnit2 As DataGridViewTextBoxColumn

		' Token: 0x170008CF RID: 2255
		' (get) Token: 0x060015CF RID: 5583 RVA: 0x00011A5B File Offset: 0x0000FC5B
		' (set) Token: 0x060015D0 RID: 5584 RVA: 0x00011A65 File Offset: 0x0000FC65
		Friend Overridable Property cmbAltunit2 As DataGridViewTextBoxColumn

		' Token: 0x170008D0 RID: 2256
		' (get) Token: 0x060015D1 RID: 5585 RVA: 0x00011A6E File Offset: 0x0000FC6E
		' (set) Token: 0x060015D2 RID: 5586 RVA: 0x00011A78 File Offset: 0x0000FC78
		Friend Overridable Property DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn

		' Token: 0x170008D1 RID: 2257
		' (get) Token: 0x060015D3 RID: 5587 RVA: 0x00011A81 File Offset: 0x0000FC81
		' (set) Token: 0x060015D4 RID: 5588 RVA: 0x00011A8B File Offset: 0x0000FC8B
		Friend Overridable Property DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn

		' Token: 0x170008D2 RID: 2258
		' (get) Token: 0x060015D5 RID: 5589 RVA: 0x00011A94 File Offset: 0x0000FC94
		' (set) Token: 0x060015D6 RID: 5590 RVA: 0x00011A9E File Offset: 0x0000FC9E
		Friend Overridable Property DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn

		' Token: 0x170008D3 RID: 2259
		' (get) Token: 0x060015D7 RID: 5591 RVA: 0x00011AA7 File Offset: 0x0000FCA7
		' (set) Token: 0x060015D8 RID: 5592 RVA: 0x00011AB1 File Offset: 0x0000FCB1
		Friend Overridable Property DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn

		' Token: 0x170008D4 RID: 2260
		' (get) Token: 0x060015D9 RID: 5593 RVA: 0x00011ABA File Offset: 0x0000FCBA
		' (set) Token: 0x060015DA RID: 5594 RVA: 0x00011AC4 File Offset: 0x0000FCC4
		Friend Overridable Property cmbSalesTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x170008D5 RID: 2261
		' (get) Token: 0x060015DB RID: 5595 RVA: 0x00011ACD File Offset: 0x0000FCCD
		' (set) Token: 0x060015DC RID: 5596 RVA: 0x00011AD7 File Offset: 0x0000FCD7
		Friend Overridable Property cmbPurchaseTaxType2 As DataGridViewTextBoxColumn

		' Token: 0x170008D6 RID: 2262
		' (get) Token: 0x060015DD RID: 5597 RVA: 0x00011AE0 File Offset: 0x0000FCE0
		' (set) Token: 0x060015DE RID: 5598 RVA: 0x00011AEA File Offset: 0x0000FCEA
		Friend Overridable Property ddlGdown2 As DataGridViewTextBoxColumn

		' Token: 0x170008D7 RID: 2263
		' (get) Token: 0x060015DF RID: 5599 RVA: 0x00011AF3 File Offset: 0x0000FCF3
		' (set) Token: 0x060015E0 RID: 5600 RVA: 0x00011AFD File Offset: 0x0000FCFD
		Friend Overridable Property ddlRack2 As DataGridViewTextBoxColumn

		' Token: 0x170008D8 RID: 2264
		' (get) Token: 0x060015E1 RID: 5601 RVA: 0x00011B06 File Offset: 0x0000FD06
		' (set) Token: 0x060015E2 RID: 5602 RVA: 0x00011B10 File Offset: 0x0000FD10
		Friend Overridable Property DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn

		' Token: 0x170008D9 RID: 2265
		' (get) Token: 0x060015E3 RID: 5603 RVA: 0x00011B19 File Offset: 0x0000FD19
		' (set) Token: 0x060015E4 RID: 5604 RVA: 0x00011B23 File Offset: 0x0000FD23
		Friend Overridable Property txtOpeningStock2 As DataGridViewTextBoxColumn

		' Token: 0x170008DA RID: 2266
		' (get) Token: 0x060015E5 RID: 5605 RVA: 0x00011B2C File Offset: 0x0000FD2C
		' (set) Token: 0x060015E6 RID: 5606 RVA: 0x00011B36 File Offset: 0x0000FD36
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170008DB RID: 2267
		' (get) Token: 0x060015E7 RID: 5607 RVA: 0x00011B3F File Offset: 0x0000FD3F
		' (set) Token: 0x060015E8 RID: 5608 RVA: 0x00011B49 File Offset: 0x0000FD49
		Friend Overridable Property txtMRP As DataGridViewTextBoxColumn

		' Token: 0x170008DC RID: 2268
		' (get) Token: 0x060015E9 RID: 5609 RVA: 0x00011B52 File Offset: 0x0000FD52
		' (set) Token: 0x060015EA RID: 5610 RVA: 0x00011B5C File Offset: 0x0000FD5C
		Friend Overridable Property txtRSP1 As DataGridViewTextBoxColumn

		' Token: 0x170008DD RID: 2269
		' (get) Token: 0x060015EB RID: 5611 RVA: 0x00011B65 File Offset: 0x0000FD65
		' (set) Token: 0x060015EC RID: 5612 RVA: 0x00011B6F File Offset: 0x0000FD6F
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170008DE RID: 2270
		' (get) Token: 0x060015ED RID: 5613 RVA: 0x00011B78 File Offset: 0x0000FD78
		' (set) Token: 0x060015EE RID: 5614 RVA: 0x00011B82 File Offset: 0x0000FD82
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170008DF RID: 2271
		' (get) Token: 0x060015EF RID: 5615 RVA: 0x00011B8B File Offset: 0x0000FD8B
		' (set) Token: 0x060015F0 RID: 5616 RVA: 0x00011B95 File Offset: 0x0000FD95
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170008E0 RID: 2272
		' (get) Token: 0x060015F1 RID: 5617 RVA: 0x00011B9E File Offset: 0x0000FD9E
		' (set) Token: 0x060015F2 RID: 5618 RVA: 0x00011BA8 File Offset: 0x0000FDA8
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170008E1 RID: 2273
		' (get) Token: 0x060015F3 RID: 5619 RVA: 0x00011BB1 File Offset: 0x0000FDB1
		' (set) Token: 0x060015F4 RID: 5620 RVA: 0x00011BBB File Offset: 0x0000FDBB
		Friend Overridable Property cmbSize2 As DataGridViewTextBoxColumn

		' Token: 0x170008E2 RID: 2274
		' (get) Token: 0x060015F5 RID: 5621 RVA: 0x00011BC4 File Offset: 0x0000FDC4
		' (set) Token: 0x060015F6 RID: 5622 RVA: 0x00011BCE File Offset: 0x0000FDCE
		Friend Overridable Property cmbColour2 As DataGridViewTextBoxColumn

		' Token: 0x170008E3 RID: 2275
		' (get) Token: 0x060015F7 RID: 5623 RVA: 0x00011BD7 File Offset: 0x0000FDD7
		' (set) Token: 0x060015F8 RID: 5624 RVA: 0x00011BE1 File Offset: 0x0000FDE1
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170008E4 RID: 2276
		' (get) Token: 0x060015F9 RID: 5625 RVA: 0x00011BEA File Offset: 0x0000FDEA
		' (set) Token: 0x060015FA RID: 5626 RVA: 0x00011BF4 File Offset: 0x0000FDF4
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x170008E5 RID: 2277
		' (get) Token: 0x060015FB RID: 5627 RVA: 0x00011BFD File Offset: 0x0000FDFD
		' (set) Token: 0x060015FC RID: 5628 RVA: 0x00011C07 File Offset: 0x0000FE07
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x170008E6 RID: 2278
		' (get) Token: 0x060015FD RID: 5629 RVA: 0x00011C10 File Offset: 0x0000FE10
		' (set) Token: 0x060015FE RID: 5630 RVA: 0x00011C1A File Offset: 0x0000FE1A
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x170008E7 RID: 2279
		' (get) Token: 0x060015FF RID: 5631 RVA: 0x00011C23 File Offset: 0x0000FE23
		' (set) Token: 0x06001600 RID: 5632 RVA: 0x00011C2D File Offset: 0x0000FE2D
		Friend Overridable Property btnAddNew As DataGridViewButtonColumn

		' Token: 0x170008E8 RID: 2280
		' (get) Token: 0x06001601 RID: 5633 RVA: 0x00011C36 File Offset: 0x0000FE36
		' (set) Token: 0x06001602 RID: 5634 RVA: 0x00011C40 File Offset: 0x0000FE40
		Friend Overridable Property lblUser As Label

		' Token: 0x170008E9 RID: 2281
		' (get) Token: 0x06001603 RID: 5635 RVA: 0x00011C49 File Offset: 0x0000FE49
		' (set) Token: 0x06001604 RID: 5636 RVA: 0x00011C53 File Offset: 0x0000FE53
		Friend Overridable Property Label16 As Label

		' Token: 0x170008EA RID: 2282
		' (get) Token: 0x06001605 RID: 5637 RVA: 0x00011C5C File Offset: 0x0000FE5C
		' (set) Token: 0x06001606 RID: 5638 RVA: 0x00011C66 File Offset: 0x0000FE66
		Friend Overridable Property Label15 As Label

		' Token: 0x170008EB RID: 2283
		' (get) Token: 0x06001607 RID: 5639 RVA: 0x00011C6F File Offset: 0x0000FE6F
		' (set) Token: 0x06001608 RID: 5640 RVA: 0x00011C79 File Offset: 0x0000FE79
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170008EC RID: 2284
		' (get) Token: 0x06001609 RID: 5641 RVA: 0x00011C82 File Offset: 0x0000FE82
		' (set) Token: 0x0600160A RID: 5642 RVA: 0x000EC944 File Offset: 0x000EAB44
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click_1
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

		' Token: 0x170008ED RID: 2285
		' (get) Token: 0x0600160B RID: 5643 RVA: 0x00011C8C File Offset: 0x0000FE8C
		' (set) Token: 0x0600160C RID: 5644 RVA: 0x000EC988 File Offset: 0x000EAB88
		Private _Button16 As Button
		Friend Overridable Property Button16 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button16
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button16_Click
				Dim button As Button = Me._Button16
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button16 = value
				button = Me._Button16
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008EE RID: 2286
		' (get) Token: 0x0600160D RID: 5645 RVA: 0x00011C96 File Offset: 0x0000FE96
		' (set) Token: 0x0600160E RID: 5646 RVA: 0x000EC9CC File Offset: 0x000EABCC
		Private _btnExportExcel As Button
		Friend Overridable Property btnExportExcel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click_1
				Dim button As Button = Me._btnExportExcel
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnExportExcel = value
				button = Me._btnExportExcel
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008EF RID: 2287
		' (get) Token: 0x0600160F RID: 5647 RVA: 0x00011CA0 File Offset: 0x0000FEA0
		' (set) Token: 0x06001610 RID: 5648 RVA: 0x000ECA10 File Offset: 0x000EAC10
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

		' Token: 0x170008F0 RID: 2288
		' (get) Token: 0x06001611 RID: 5649 RVA: 0x00011CAA File Offset: 0x0000FEAA
		' (set) Token: 0x06001612 RID: 5650 RVA: 0x00011CB4 File Offset: 0x0000FEB4
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170008F1 RID: 2289
		' (get) Token: 0x06001613 RID: 5651 RVA: 0x00011CBD File Offset: 0x0000FEBD
		' (set) Token: 0x06001614 RID: 5652 RVA: 0x00011CC7 File Offset: 0x0000FEC7
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170008F2 RID: 2290
		' (get) Token: 0x06001615 RID: 5653 RVA: 0x00011CD0 File Offset: 0x0000FED0
		' (set) Token: 0x06001616 RID: 5654 RVA: 0x00011CDA File Offset: 0x0000FEDA
		Friend Overridable Property Label17 As Label

		' Token: 0x170008F3 RID: 2291
		' (get) Token: 0x06001617 RID: 5655 RVA: 0x00011CE3 File Offset: 0x0000FEE3
		' (set) Token: 0x06001618 RID: 5656 RVA: 0x000ECA54 File Offset: 0x000EAC54
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

		' Token: 0x170008F4 RID: 2292
		' (get) Token: 0x06001619 RID: 5657 RVA: 0x00011CED File Offset: 0x0000FEED
		' (set) Token: 0x0600161A RID: 5658 RVA: 0x000ECA98 File Offset: 0x000EAC98
		Private _btnBulkImageUpdate As Button
		Friend Overridable Property btnBulkImageUpdate As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBulkImageUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBulkImageUpdate_Click
				Dim button As Button = Me._btnBulkImageUpdate
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBulkImageUpdate = value
				button = Me._btnBulkImageUpdate
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008F5 RID: 2293
		' (get) Token: 0x0600161B RID: 5659 RVA: 0x00011CF7 File Offset: 0x0000FEF7
		' (set) Token: 0x0600161C RID: 5660 RVA: 0x000ECADC File Offset: 0x000EACDC
		Private _btnShowAll As Button
		Friend Overridable Property btnShowAll As Button
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click_1
				Dim button As Button = Me._btnShowAll
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnShowAll = value
				button = Me._btnShowAll
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008F6 RID: 2294
		' (get) Token: 0x0600161D RID: 5661 RVA: 0x00011D01 File Offset: 0x0000FF01
		' (set) Token: 0x0600161E RID: 5662 RVA: 0x000ECB20 File Offset: 0x000EAD20
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

		' Token: 0x170008F7 RID: 2295
		' (get) Token: 0x0600161F RID: 5663 RVA: 0x00011D0B File Offset: 0x0000FF0B
		' (set) Token: 0x06001620 RID: 5664 RVA: 0x000ECB64 File Offset: 0x000EAD64
		Private _GelButton6 As Button
		Friend Overridable Property GelButton6 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim button As Button = Me._GelButton6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton6 = value
				button = Me._GelButton6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008F8 RID: 2296
		' (get) Token: 0x06001621 RID: 5665 RVA: 0x00011D15 File Offset: 0x0000FF15
		' (set) Token: 0x06001622 RID: 5666 RVA: 0x000ECBA8 File Offset: 0x000EADA8
		Private _GelButtonNewRecord As Button
		Friend Overridable Property GelButtonNewRecord As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButtonNewRecord
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButtonNewRecord_Click
				Dim button As Button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButtonNewRecord = value
				button = Me._GelButtonNewRecord
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008F9 RID: 2297
		' (get) Token: 0x06001623 RID: 5667 RVA: 0x00011D1F File Offset: 0x0000FF1F
		' (set) Token: 0x06001624 RID: 5668 RVA: 0x00011D29 File Offset: 0x0000FF29
		Friend Overridable Property Panel7 As Panel

		' Token: 0x170008FA RID: 2298
		' (get) Token: 0x06001625 RID: 5669 RVA: 0x00011D32 File Offset: 0x0000FF32
		' (set) Token: 0x06001626 RID: 5670 RVA: 0x00011D3C File Offset: 0x0000FF3C
		Friend Overridable Property Label20 As Label

		' Token: 0x170008FB RID: 2299
		' (get) Token: 0x06001627 RID: 5671 RVA: 0x00011D45 File Offset: 0x0000FF45
		' (set) Token: 0x06001628 RID: 5672 RVA: 0x00011D4F File Offset: 0x0000FF4F
		Friend Overridable Property Label19 As Label

		' Token: 0x170008FC RID: 2300
		' (get) Token: 0x06001629 RID: 5673 RVA: 0x00011D58 File Offset: 0x0000FF58
		' (set) Token: 0x0600162A RID: 5674 RVA: 0x00011D62 File Offset: 0x0000FF62
		Friend Overridable Property Label18 As Label

		' Token: 0x170008FD RID: 2301
		' (get) Token: 0x0600162B RID: 5675 RVA: 0x00011D6B File Offset: 0x0000FF6B
		' (set) Token: 0x0600162C RID: 5676 RVA: 0x00011D75 File Offset: 0x0000FF75
		Friend Overridable Property Label21 As Label

		' Token: 0x170008FE RID: 2302
		' (get) Token: 0x0600162D RID: 5677 RVA: 0x00011D7E File Offset: 0x0000FF7E
		' (set) Token: 0x0600162E RID: 5678 RVA: 0x000ECBEC File Offset: 0x000EADEC
		Private _txtSearchProduct As TextBox
		Friend Overridable Property txtSearchProduct As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchProduct
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtSearchProduct_KeyDown
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchProduct_TextChanged
				Dim textBox As TextBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchProduct = value
				textBox = Me._txtSearchProduct
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170008FF RID: 2303
		' (get) Token: 0x0600162F RID: 5679 RVA: 0x00011D88 File Offset: 0x0000FF88
		' (set) Token: 0x06001630 RID: 5680 RVA: 0x000ECC4C File Offset: 0x000EAE4C
		Private _cmbSearchCat As ComboBox
		Friend Overridable Property cmbSearchCat As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbSearchCat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbSearchCat_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbSearchCat = value
				comboBox = Me._cmbSearchCat
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000900 RID: 2304
		' (get) Token: 0x06001631 RID: 5681 RVA: 0x00011D92 File Offset: 0x0000FF92
		' (set) Token: 0x06001632 RID: 5682 RVA: 0x000ECC90 File Offset: 0x000EAE90
		Private _GelButton2 As Button
		Friend Overridable Property GelButton2 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click_1
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

		' Token: 0x17000901 RID: 2305
		' (get) Token: 0x06001633 RID: 5683 RVA: 0x00011D9C File Offset: 0x0000FF9C
		' (set) Token: 0x06001634 RID: 5684 RVA: 0x000ECCD4 File Offset: 0x000EAED4
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

		' Token: 0x17000902 RID: 2306
		' (get) Token: 0x06001635 RID: 5685 RVA: 0x00011DA6 File Offset: 0x0000FFA6
		' (set) Token: 0x06001636 RID: 5686 RVA: 0x000ECD18 File Offset: 0x000EAF18
		Private _btnWebcam As Button
		Friend Overridable Property btnWebcam As Button
			<CompilerGenerated()>
			Get
				Return Me._btnWebcam
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnWebcam_Click
				Dim button As Button = Me._btnWebcam
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnWebcam = value
				button = Me._btnWebcam
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000903 RID: 2307
		' (get) Token: 0x06001637 RID: 5687 RVA: 0x00011DB0 File Offset: 0x0000FFB0
		' (set) Token: 0x06001638 RID: 5688 RVA: 0x000ECD5C File Offset: 0x000EAF5C
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim eventHandler As EventHandler = AddressOf Me.dgw_CurrentCellChanged
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellContentClick
				Dim dataGridViewCellEventHandler2 As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CurrentCellChanged, eventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler2
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CurrentCellChanged, eventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler2
				End If
			End Set
		End Property

		' Token: 0x17000904 RID: 2308
		' (get) Token: 0x06001639 RID: 5689 RVA: 0x00011DBA File Offset: 0x0000FFBA
		' (set) Token: 0x0600163A RID: 5690 RVA: 0x00011DC4 File Offset: 0x0000FFC4
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x17000905 RID: 2309
		' (get) Token: 0x0600163B RID: 5691 RVA: 0x00011DCD File Offset: 0x0000FFCD
		' (set) Token: 0x0600163C RID: 5692 RVA: 0x00011DD7 File Offset: 0x0000FFD7
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x17000906 RID: 2310
		' (get) Token: 0x0600163D RID: 5693 RVA: 0x00011DE0 File Offset: 0x0000FFE0
		' (set) Token: 0x0600163E RID: 5694 RVA: 0x00011DEA File Offset: 0x0000FFEA
		Friend Overridable Property DataGridViewTextBoxColumn64 As DataGridViewTextBoxColumn

		' Token: 0x17000907 RID: 2311
		' (get) Token: 0x0600163F RID: 5695 RVA: 0x00011DF3 File Offset: 0x0000FFF3
		' (set) Token: 0x06001640 RID: 5696 RVA: 0x00011DFD File Offset: 0x0000FFFD
		Friend Overridable Property DataGridViewTextBoxColumn45 As DataGridViewTextBoxColumn

		' Token: 0x17000908 RID: 2312
		' (get) Token: 0x06001641 RID: 5697 RVA: 0x00011E06 File Offset: 0x00010006
		' (set) Token: 0x06001642 RID: 5698 RVA: 0x00011E10 File Offset: 0x00010010
		Friend Overridable Property DataGridViewTextBoxColumn48 As DataGridViewTextBoxColumn

		' Token: 0x17000909 RID: 2313
		' (get) Token: 0x06001643 RID: 5699 RVA: 0x00011E19 File Offset: 0x00010019
		' (set) Token: 0x06001644 RID: 5700 RVA: 0x00011E23 File Offset: 0x00010023
		Friend Overridable Property PCode As DataGridViewTextBoxColumn

		' Token: 0x1700090A RID: 2314
		' (get) Token: 0x06001645 RID: 5701 RVA: 0x00011E2C File Offset: 0x0001002C
		' (set) Token: 0x06001646 RID: 5702 RVA: 0x00011E36 File Offset: 0x00010036
		Friend Overridable Property ProductName As DataGridViewTextBoxColumn

		' Token: 0x1700090B RID: 2315
		' (get) Token: 0x06001647 RID: 5703 RVA: 0x00011E3F File Offset: 0x0001003F
		' (set) Token: 0x06001648 RID: 5704 RVA: 0x00011E49 File Offset: 0x00010049
		Friend Overridable Property CatSubCategory As DataGridViewTextBoxColumn

		' Token: 0x1700090C RID: 2316
		' (get) Token: 0x06001649 RID: 5705 RVA: 0x00011E52 File Offset: 0x00010052
		' (set) Token: 0x0600164A RID: 5706 RVA: 0x00011E5C File Offset: 0x0001005C
		Friend Overridable Property HSNCode As DataGridViewTextBoxColumn

		' Token: 0x1700090D RID: 2317
		' (get) Token: 0x0600164B RID: 5707 RVA: 0x00011E65 File Offset: 0x00010065
		' (set) Token: 0x0600164C RID: 5708 RVA: 0x00011E6F File Offset: 0x0001006F
		Friend Overridable Property Part_Group As DataGridViewTextBoxColumn

		' Token: 0x1700090E RID: 2318
		' (get) Token: 0x0600164D RID: 5709 RVA: 0x00011E78 File Offset: 0x00010078
		' (set) Token: 0x0600164E RID: 5710 RVA: 0x00011E82 File Offset: 0x00010082
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x1700090F RID: 2319
		' (get) Token: 0x0600164F RID: 5711 RVA: 0x00011E8B File Offset: 0x0001008B
		' (set) Token: 0x06001650 RID: 5712 RVA: 0x00011E95 File Offset: 0x00010095
		Friend Overridable Property PurchasePrice As DataGridViewTextBoxColumn

		' Token: 0x17000910 RID: 2320
		' (get) Token: 0x06001651 RID: 5713 RVA: 0x00011E9E File Offset: 0x0001009E
		' (set) Token: 0x06001652 RID: 5714 RVA: 0x00011EA8 File Offset: 0x000100A8
		Friend Overridable Property Discount As DataGridViewTextBoxColumn

		' Token: 0x17000911 RID: 2321
		' (get) Token: 0x06001653 RID: 5715 RVA: 0x00011EB1 File Offset: 0x000100B1
		' (set) Token: 0x06001654 RID: 5716 RVA: 0x00011EBB File Offset: 0x000100BB
		Friend Overridable Property GST As DataGridViewTextBoxColumn

		' Token: 0x17000912 RID: 2322
		' (get) Token: 0x06001655 RID: 5717 RVA: 0x00011EC4 File Offset: 0x000100C4
		' (set) Token: 0x06001656 RID: 5718 RVA: 0x00011ECE File Offset: 0x000100CE
		Friend Overridable Property CGST As DataGridViewTextBoxColumn

		' Token: 0x17000913 RID: 2323
		' (get) Token: 0x06001657 RID: 5719 RVA: 0x00011ED7 File Offset: 0x000100D7
		' (set) Token: 0x06001658 RID: 5720 RVA: 0x00011EE1 File Offset: 0x000100E1
		Friend Overridable Property SGST_UTGST As DataGridViewTextBoxColumn

		' Token: 0x17000914 RID: 2324
		' (get) Token: 0x06001659 RID: 5721 RVA: 0x00011EEA File Offset: 0x000100EA
		' (set) Token: 0x0600165A RID: 5722 RVA: 0x00011EF4 File Offset: 0x000100F4
		Friend Overridable Property CESS As DataGridViewTextBoxColumn

		' Token: 0x17000915 RID: 2325
		' (get) Token: 0x0600165B RID: 5723 RVA: 0x00011EFD File Offset: 0x000100FD
		' (set) Token: 0x0600165C RID: 5724 RVA: 0x00011F07 File Offset: 0x00010107
		Friend Overridable Property PurchaseMainUnit As DataGridViewTextBoxColumn

		' Token: 0x17000916 RID: 2326
		' (get) Token: 0x0600165D RID: 5725 RVA: 0x00011F10 File Offset: 0x00010110
		' (set) Token: 0x0600165E RID: 5726 RVA: 0x00011F1A File Offset: 0x0001011A
		Friend Overridable Property SalsesUnit As DataGridViewTextBoxColumn

		' Token: 0x17000917 RID: 2327
		' (get) Token: 0x0600165F RID: 5727 RVA: 0x00011F23 File Offset: 0x00010123
		' (set) Token: 0x06001660 RID: 5728 RVA: 0x00011F2D File Offset: 0x0001012D
		Friend Overridable Property AlterUnit As DataGridViewTextBoxColumn

		' Token: 0x17000918 RID: 2328
		' (get) Token: 0x06001661 RID: 5729 RVA: 0x00011F36 File Offset: 0x00010136
		' (set) Token: 0x06001662 RID: 5730 RVA: 0x00011F40 File Offset: 0x00010140
		Friend Overridable Property Conv As DataGridViewTextBoxColumn

		' Token: 0x17000919 RID: 2329
		' (get) Token: 0x06001663 RID: 5731 RVA: 0x00011F49 File Offset: 0x00010149
		' (set) Token: 0x06001664 RID: 5732 RVA: 0x00011F53 File Offset: 0x00010153
		Friend Overridable Property MinStock As DataGridViewTextBoxColumn

		' Token: 0x1700091A RID: 2330
		' (get) Token: 0x06001665 RID: 5733 RVA: 0x00011F5C File Offset: 0x0001015C
		' (set) Token: 0x06001666 RID: 5734 RVA: 0x00011F66 File Offset: 0x00010166
		Friend Overridable Property Active As DataGridViewTextBoxColumn

		' Token: 0x1700091B RID: 2331
		' (get) Token: 0x06001667 RID: 5735 RVA: 0x00011F6F File Offset: 0x0001016F
		' (set) Token: 0x06001668 RID: 5736 RVA: 0x00011F79 File Offset: 0x00010179
		Friend Overridable Property SaleTaxType As DataGridViewTextBoxColumn

		' Token: 0x1700091C RID: 2332
		' (get) Token: 0x06001669 RID: 5737 RVA: 0x00011F82 File Offset: 0x00010182
		' (set) Token: 0x0600166A RID: 5738 RVA: 0x00011F8C File Offset: 0x0001018C
		Friend Overridable Property PurchaseTaxType As DataGridViewTextBoxColumn

		' Token: 0x1700091D RID: 2333
		' (get) Token: 0x0600166B RID: 5739 RVA: 0x00011F95 File Offset: 0x00010195
		' (set) Token: 0x0600166C RID: 5740 RVA: 0x00011F9F File Offset: 0x0001019F
		Friend Overridable Property GDown As DataGridViewTextBoxColumn

		' Token: 0x1700091E RID: 2334
		' (get) Token: 0x0600166D RID: 5741 RVA: 0x00011FA8 File Offset: 0x000101A8
		' (set) Token: 0x0600166E RID: 5742 RVA: 0x00011FB2 File Offset: 0x000101B2
		Friend Overridable Property Rack As DataGridViewTextBoxColumn

		' Token: 0x1700091F RID: 2335
		' (get) Token: 0x0600166F RID: 5743 RVA: 0x00011FBB File Offset: 0x000101BB
		' (set) Token: 0x06001670 RID: 5744 RVA: 0x00011FC5 File Offset: 0x000101C5
		Friend Overridable Property DefQty As DataGridViewTextBoxColumn

		' Token: 0x17000920 RID: 2336
		' (get) Token: 0x06001671 RID: 5745 RVA: 0x00011FCE File Offset: 0x000101CE
		' (set) Token: 0x06001672 RID: 5746 RVA: 0x00011FD8 File Offset: 0x000101D8
		Friend Overridable Property OpeningStock As DataGridViewTextBoxColumn

		' Token: 0x17000921 RID: 2337
		' (get) Token: 0x06001673 RID: 5747 RVA: 0x00011FE1 File Offset: 0x000101E1
		' (set) Token: 0x06001674 RID: 5748 RVA: 0x00011FEB File Offset: 0x000101EB
		Friend Overridable Property Barcode As DataGridViewTextBoxColumn

		' Token: 0x17000922 RID: 2338
		' (get) Token: 0x06001675 RID: 5749 RVA: 0x00011FF4 File Offset: 0x000101F4
		' (set) Token: 0x06001676 RID: 5750 RVA: 0x00011FFE File Offset: 0x000101FE
		Friend Overridable Property MRP As DataGridViewTextBoxColumn

		' Token: 0x17000923 RID: 2339
		' (get) Token: 0x06001677 RID: 5751 RVA: 0x00012007 File Offset: 0x00010207
		' (set) Token: 0x06001678 RID: 5752 RVA: 0x00012011 File Offset: 0x00010211
		Friend Overridable Property RSPrice As DataGridViewTextBoxColumn

		' Token: 0x17000924 RID: 2340
		' (get) Token: 0x06001679 RID: 5753 RVA: 0x0001201A File Offset: 0x0001021A
		' (set) Token: 0x0600167A RID: 5754 RVA: 0x00012024 File Offset: 0x00010224
		Friend Overridable Property WSPrice As DataGridViewTextBoxColumn

		' Token: 0x17000925 RID: 2341
		' (get) Token: 0x0600167B RID: 5755 RVA: 0x0001202D File Offset: 0x0001022D
		' (set) Token: 0x0600167C RID: 5756 RVA: 0x00012037 File Offset: 0x00010237
		Friend Overridable Property Batch As DataGridViewTextBoxColumn

		' Token: 0x17000926 RID: 2342
		' (get) Token: 0x0600167D RID: 5757 RVA: 0x00012040 File Offset: 0x00010240
		' (set) Token: 0x0600167E RID: 5758 RVA: 0x0001204A File Offset: 0x0001024A
		Friend Overridable Property MfgDate As DataGridViewTextBoxColumn

		' Token: 0x17000927 RID: 2343
		' (get) Token: 0x0600167F RID: 5759 RVA: 0x00012053 File Offset: 0x00010253
		' (set) Token: 0x06001680 RID: 5760 RVA: 0x0001205D File Offset: 0x0001025D
		Friend Overridable Property ExpDate As DataGridViewTextBoxColumn

		' Token: 0x17000928 RID: 2344
		' (get) Token: 0x06001681 RID: 5761 RVA: 0x00012066 File Offset: 0x00010266
		' (set) Token: 0x06001682 RID: 5762 RVA: 0x00012070 File Offset: 0x00010270
		Friend Overridable Property Size As DataGridViewTextBoxColumn

		' Token: 0x17000929 RID: 2345
		' (get) Token: 0x06001683 RID: 5763 RVA: 0x00012079 File Offset: 0x00010279
		' (set) Token: 0x06001684 RID: 5764 RVA: 0x00012083 File Offset: 0x00010283
		Friend Overridable Property Colour As DataGridViewTextBoxColumn

		' Token: 0x1700092A RID: 2346
		' (get) Token: 0x06001685 RID: 5765 RVA: 0x0001208C File Offset: 0x0001028C
		' (set) Token: 0x06001686 RID: 5766 RVA: 0x00012096 File Offset: 0x00010296
		Friend Overridable Property IME1 As DataGridViewTextBoxColumn

		' Token: 0x1700092B RID: 2347
		' (get) Token: 0x06001687 RID: 5767 RVA: 0x0001209F File Offset: 0x0001029F
		' (set) Token: 0x06001688 RID: 5768 RVA: 0x000120A9 File Offset: 0x000102A9
		Friend Overridable Property IME2 As DataGridViewTextBoxColumn

		' Token: 0x1700092C RID: 2348
		' (get) Token: 0x06001689 RID: 5769 RVA: 0x000120B2 File Offset: 0x000102B2
		' (set) Token: 0x0600168A RID: 5770 RVA: 0x000120BC File Offset: 0x000102BC
		Friend Overridable Property Kitchen As DataGridViewTextBoxColumn

		' Token: 0x1700092D RID: 2349
		' (get) Token: 0x0600168B RID: 5771 RVA: 0x000120C5 File Offset: 0x000102C5
		' (set) Token: 0x0600168C RID: 5772 RVA: 0x000120CF File Offset: 0x000102CF
		Friend Overridable Property Photo As DataGridViewImageColumn

		' Token: 0x1700092E RID: 2350
		' (get) Token: 0x0600168D RID: 5773 RVA: 0x000120D8 File Offset: 0x000102D8
		' (set) Token: 0x0600168E RID: 5774 RVA: 0x000120E2 File Offset: 0x000102E2
		Friend Overridable Property Mark_Unmark As DataGridViewCheckBoxColumn

		' Token: 0x1700092F RID: 2351
		' (get) Token: 0x0600168F RID: 5775 RVA: 0x000120EB File Offset: 0x000102EB
		' (set) Token: 0x06001690 RID: 5776 RVA: 0x000120F5 File Offset: 0x000102F5
		Friend Overridable Property DataGridViewButtonColumn6 As DataGridViewButtonColumn

		' Token: 0x17000930 RID: 2352
		' (get) Token: 0x06001691 RID: 5777 RVA: 0x000120FE File Offset: 0x000102FE
		' (set) Token: 0x06001692 RID: 5778 RVA: 0x00012108 File Offset: 0x00010308
		Friend Overridable Property DataGridViewButtonColumn7 As DataGridViewButtonColumn

		' Token: 0x17000931 RID: 2353
		' (get) Token: 0x06001693 RID: 5779 RVA: 0x00012111 File Offset: 0x00010311
		' (set) Token: 0x06001694 RID: 5780 RVA: 0x0001211B File Offset: 0x0001031B
		Friend Overridable Property DataGridViewButtonColumn8 As DataGridViewButtonColumn

		' Token: 0x17000932 RID: 2354
		' (get) Token: 0x06001695 RID: 5781 RVA: 0x00012124 File Offset: 0x00010324
		' (set) Token: 0x06001696 RID: 5782 RVA: 0x0001212E File Offset: 0x0001032E
		Friend Overridable Property variantName As DataGridViewButtonColumn

		' Token: 0x17000933 RID: 2355
		' (get) Token: 0x06001697 RID: 5783 RVA: 0x00012137 File Offset: 0x00010337
		' (set) Token: 0x06001698 RID: 5784 RVA: 0x00012141 File Offset: 0x00010341
		Public Property POSForm As frmPOSNewTuch

		' Token: 0x06001699 RID: 5785 RVA: 0x000ECDD8 File Offset: 0x000EAFD8
		Public Sub default_fillUnit_Default()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = Me.con.CreateCommand()
				Me.cmd.CommandText = "SELECT RTRIM(Unit) as Unit, IsDefault FROM UnitMaster where isDefault=@d1"
				Me.cmd.Parameters.AddWithValue("@d1", "Yes")
				Me.rdr = Me.cmd.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				If flag Then
					Dim text As String = Me.rdr.GetValue(0).ToString()
					Dim num As Integer = Me.DataGridView1.Rows.Count - 1
					Dim index As Integer = Me.DataGridView1.Columns(19).Index
					Me.DataGridView1.Rows(num).Cells(index).Value = text
					Dim index2 As Integer = Me.DataGridView1.Columns(20).Index
					Me.DataGridView1.Rows(num).Cells(index2).Value = text
					Dim index3 As Integer = Me.DataGridView1.Columns(21).Index
					Me.DataGridView1.Rows(num).Cells(index3).Value = text
				End If
				Dim flag2 As Boolean = Me.rdr IsNot Nothing
				If flag2 Then
					Me.rdr.Close()
				End If
				Dim flag3 As Boolean = Me.con.State = ConnectionState.Open
				If flag3 Then
					Me.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600169A RID: 5786 RVA: 0x000ECFC4 File Offset: 0x000EB1C4
		Public Sub Getdata()
			Try
				Me.DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.DataGridView1.RowHeadersVisible = False
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("Select Top " + Me.txtTopResult.Text + " PID,SubCategoryID,temp_Stock.Variant_id,OpeningStock," & vbCrLf & "    (Product.MRP),RTRIM(ProductCode),RTRIM(Productname),RTRIM(CategoryName) + ', ' + RTRIM(SubCategoryName)," & vbCrLf & "    RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description,CostPrice,Discount," & vbCrLf & "    (CGST+SGST) as GST,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit)," & vbCrLf & "    RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty," & vbCrLf & "    RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate)," & vbCrLf & "    RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),temp_Stock.IMEI1,temp_Stock.IMEI2," & vbCrLf & "    RTRIM(Product.Kitchen),Photo from Category,SubCategory,Product," & vbCrLf & "    Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and " & vbCrLf & "    Temp_Stock.ProductID=Product.PID and Product.PID=Product_Join.ProductID order by PID desc", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While Me.rdr.Read()
					Dim num As Integer = Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41) })
					Me.DataGridView1.Rows(num).Cells(43).Value = "Update"
					Me.DataGridView1.Rows(num).Cells(44).Value = "Delete"
				End While
				Application.DoEvents()
				Me.rdr.Close()
				Me.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600169B RID: 5787 RVA: 0x000ED418 File Offset: 0x000EB618
		Private Sub CustomizeRowHeaders()
			Me.DataGridView1.Columns(8).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(8).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(8).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(11).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(11).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(11).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(31).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(31).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(31).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(15).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(15).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(15).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(23).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(23).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(23).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(19).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(19).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(19).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(28).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(28).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(28).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
			Me.DataGridView1.Columns(30).HeaderCell.Style.BackColor = Color.Red
			Me.DataGridView1.Columns(30).HeaderCell.Style.ForeColor = Color.White
			Me.DataGridView1.Columns(30).HeaderCell.Style.Font = New Font("Arial", 12F, FontStyle.Bold)
		End Sub

		' Token: 0x0600169C RID: 5788 RVA: 0x000ED824 File Offset: 0x000EBA24
		Private Sub NumericDecimal_KeyPress(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				e.Handled = True
				e.SuppressKeyPress = True
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.CurrentCell.RowIndex).Cells(Me.DataGridView1.CurrentCell.ColumnIndex - 1)
				Dim message As Message = Message.Create(MyBase.Handle, 0, IntPtr.Zero, IntPtr.Zero)
				Me.ProcessCmdKey(message, Keys.[Return])
			End If
		End Sub

		' Token: 0x0600169D RID: 5789 RVA: 0x000ED8BC File Offset: 0x000EBABC
		Private Sub dgw_CurrentCellChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.prevCell IsNot Nothing
			If flag Then
				Me.prevCell.Style.BackColor = Color.White
			End If
			Dim flag2 As Boolean = Me.DataGridView1.CurrentCell IsNot Nothing
			If flag2 Then
				Me.DataGridView1.CurrentCell.Style.BackColor = Color.Yellow
				Me.prevCell = Me.DataGridView1.CurrentCell
			End If
		End Sub

		' Token: 0x0600169E RID: 5790 RVA: 0x000ED930 File Offset: 0x000EBB30
		Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
			' The following expression was wrapped in a checked-statement
			Dim flag2 As Boolean
			Try
				Dim flag As Boolean = Me.DataGridView1.CurrentCell Is Nothing
				If flag Then
					flag2 = False
				Else
					Dim rowIndex As Integer = Me.DataGridView1.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.DataGridView1.CurrentCell.ColumnIndex
					Dim dataGridView As DataGridView = Me.DataGridView1
					Dim flag3 As Boolean = keyData = Keys.[Return] AndAlso Me.leftnavigationhappened
					If flag3 Then
						Me.leftnavigationhappened = False
						dataGridView.EndEdit()
						dataGridView.BeginEdit(True)
						flag2 = Me.MoveToNextAndClear()
					Else
						Dim flag4 As Boolean = keyData = Keys.[Return] AndAlso dataGridView.CurrentCell.ColumnIndex > 1 AndAlso dataGridView.CurrentCell.ColumnIndex < 47
						If flag4 Then
							Dim flag5 As Boolean = dataGridView.CurrentCell.ColumnIndex = 7
							If flag5 Then
								Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
								Dim text As String = Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(7).Value))
								Dim text2 As String = ""
								Dim flag6 As Boolean = Not String.IsNullOrWhiteSpace(text) AndAlso text.Contains(",")
								If flag6 Then
									Dim array As String() = text.Split(New Char() { ","c })
									Dim flag7 As Boolean = array.Length > 1
									If flag7 Then
										text2 = array(1).Trim()
									End If
								End If
								MyProject.Forms.frmSubCategoryNew.currentRow = rowIndex
								MyProject.Forms.frmSubCategoryNew.currentColumn = columnIndex
								MyProject.Forms.frmSubCategoryNew.Owner = Me
								MyProject.Forms.frmSubCategoryNew.HideControls(True, text2)
								MyProject.Forms.frmSubCategoryNew.ShowDialog()
								MyProject.Forms.frmSubCategoryNew.Dispose()
								flag2 = True
							Else
								Dim flag8 As Boolean = dataGridView.CurrentCell.ColumnIndex = 13
								If flag8 Then
									Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
									MyProject.Forms.frmTaxCategoryNew.currentRow = rowIndex
									MyProject.Forms.frmTaxCategoryNew.currentColumn = columnIndex
									MyProject.Forms.frmTaxCategoryNew.Owner = Me
									Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(13).Value)
									MyProject.Forms.frmTaxCategoryNew.HideControls(True, Conversions.ToString(objectValue))
									MyProject.Forms.frmTaxCategoryNew.ShowDialog()
									MyProject.Forms.frmTaxCategoryNew.Dispose()
									flag2 = True
								Else
									Dim flag9 As Boolean = dataGridView.CurrentCell.ColumnIndex = 17
									If flag9 Then
										Dim dataGridViewRow3 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
										MyProject.Forms.frmUnitMasterNew.currentRow = rowIndex
										MyProject.Forms.frmUnitMasterNew.currentColumn = columnIndex
										Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow3.Cells(17).Value)
										MyProject.Forms.frmUnitMasterNew.Owner = Me
										MyProject.Forms.frmUnitMasterNew.HideControls(True, Conversions.ToString(objectValue2))
										MyProject.Forms.frmUnitMasterNew.ShowDialog()
										MyProject.Forms.frmUnitMasterNew.Dispose()
										flag2 = True
									Else
										Dim flag10 As Boolean = dataGridView.CurrentCell.ColumnIndex = 18
										If flag10 Then
											Dim dataGridViewRow4 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
											MyProject.Forms.frmUnitMasterNew.currentRow = rowIndex
											MyProject.Forms.frmUnitMasterNew.currentColumn = columnIndex
											Dim objectValue3 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(17).Value)
											MyProject.Forms.frmUnitMasterNew.Owner = Me
											MyProject.Forms.frmUnitMasterNew.HideControls(True, Conversions.ToString(objectValue3))
											MyProject.Forms.frmUnitMasterNew.ShowDialog()
											MyProject.Forms.frmUnitMasterNew.Dispose()
											flag2 = True
										Else
											Dim flag11 As Boolean = dataGridView.CurrentCell.ColumnIndex = 19
											If flag11 Then
												Dim dataGridViewRow5 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
												MyProject.Forms.frmUnitMasterNew.currentRow = rowIndex
												MyProject.Forms.frmUnitMasterNew.currentColumn = columnIndex
												Dim objectValue4 As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow5.Cells(17).Value)
												MyProject.Forms.frmUnitMasterNew.Owner = Me
												MyProject.Forms.frmUnitMasterNew.HideControls(True, Conversions.ToString(objectValue4))
												MyProject.Forms.frmUnitMasterNew.ShowDialog()
												MyProject.Forms.frmUnitMasterNew.Dispose()
												flag2 = True
											Else
												Dim flag12 As Boolean = dataGridView.CurrentCell.ColumnIndex = 22
												If flag12 Then
													Dim dataGridViewRow6 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
													MyProject.Forms.frmYesNo.currentRow = rowIndex
													MyProject.Forms.frmYesNo.currentColumn = columnIndex
													MyProject.Forms.frmYesNo.Owner = Me
													MyProject.Forms.frmYesNo.ShowDialog()
													MyProject.Forms.frmYesNo.Dispose()
													flag2 = True
												Else
													Dim flag13 As Boolean = dataGridView.CurrentCell.ColumnIndex = 23
													If flag13 Then
														Dim dataGridViewRow7 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
														MyProject.Forms.frmInEx.currentRow = rowIndex
														MyProject.Forms.frmInEx.currentColumn = columnIndex
														MyProject.Forms.frmInEx.Owner = Me
														MyProject.Forms.frmInEx.ShowDialog()
														MyProject.Forms.frmInEx.Dispose()
														flag2 = True
													Else
														Dim flag14 As Boolean = dataGridView.CurrentCell.ColumnIndex = 24
														If flag14 Then
															Dim dataGridViewRow8 As DataGridViewRow = Me.DataGridView1.Rows(rowIndex)
															MyProject.Forms.frmInEx.currentRow = rowIndex
															MyProject.Forms.frmInEx.currentColumn = columnIndex
															MyProject.Forms.frmInEx.Owner = Me
															MyProject.Forms.frmInEx.ShowDialog()
															MyProject.Forms.frmInEx.Dispose()
															flag2 = True
														Else
															Dim flag15 As Boolean = dataGridView.CurrentCell.ColumnIndex = 43
															If flag15 Then
																Dim e As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(columnIndex, rowIndex)
																Me.DataGridView1_CellContentClick(dataGridView, e)
																flag2 = True
															Else
																Dim flag16 As Boolean = dataGridView.CurrentCell.ColumnIndex = 44
																If flag16 Then
																	Dim e2 As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(columnIndex, rowIndex)
																	Me.DataGridView1_CellContentClick(dataGridView, e2)
																	flag2 = True
																Else
																	Dim num As Integer = columnIndex + 1
																	While num < dataGridView.Columns.Count AndAlso Not dataGridView.Columns(num).Visible
																		num += 1
																	End While
																	Dim flag17 As Boolean = columnIndex = 46 OrElse num >= dataGridView.Columns.Count
																	If flag17 Then
																		Dim flag18 As Boolean = rowIndex = dataGridView.RowCount - 1
																		If flag18 Then
																			dataGridView.CurrentCell = dataGridView.Rows(0).Cells(6)
																		Else
																			dataGridView.CurrentCell = dataGridView.Rows(rowIndex + 1).Cells(6)
																		End If
																	Else
																		dataGridView.CurrentCell = dataGridView.Rows(rowIndex).Cells(num)
																	End If
																	dataGridView.ClearSelection()
																	dataGridView.BeginEdit(True)
																	flag2 = True
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
						Else
							Dim flag19 As Boolean = keyData = Keys.Left
							If flag19 Then
								Me.leftnavigationhappened = True
								Dim flag20 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex > 5
								If flag20 Then
									Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex - 1, Me.DataGridView1.CurrentCell.RowIndex)
								Else
									Dim flag21 As Boolean = Me.DataGridView1.CurrentCell.RowIndex > 0
									If flag21 Then
										Me.DataGridView1.CurrentCell = Me.DataGridView1(42, Me.DataGridView1.CurrentCell.RowIndex - 1)
									End If
								End If
								Me.DataGridView1.ClearSelection()
								Me.DataGridView1.BeginEdit(True)
								flag2 = True
							Else
								Dim flag22 As Boolean = keyData = Keys.Right
								If flag22 Then
									Dim flag23 As Boolean = Me.DataGridView1.CurrentCell.ColumnIndex < Me.DataGridView1.ColumnCount - 1
									If flag23 Then
										Me.DataGridView1.CurrentCell = Me.DataGridView1(Me.DataGridView1.CurrentCell.ColumnIndex + 1, Me.DataGridView1.CurrentCell.RowIndex)
									Else
										Me.DataGridView1.CurrentCell = Me.DataGridView1(6, Me.DataGridView1.CurrentCell.RowIndex + 1)
									End If
									Me.DataGridView1.ClearSelection()
									Me.DataGridView1.BeginEdit(True)
									flag2 = True
								Else
									flag2 = MyBase.ProcessCmdKey(msg, keyData)
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				ex.ToString()
				flag2 = False
			End Try
			Return flag2
		End Function

		' Token: 0x0600169F RID: 5791 RVA: 0x000EE25C File Offset: 0x000EC45C
		Public Function MoveToNextAndClear() As Boolean
			Me.DataGridView1.ClearSelection()
			Me.DataGridView1.BeginEdit(True)
			Application.DoEvents()
			Return True
		End Function

		' Token: 0x060016A0 RID: 5792 RVA: 0x0001214A File Offset: 0x0001034A
		Public Sub Reset()
			Me.Getdata()
		End Sub

		' Token: 0x060016A1 RID: 5793 RVA: 0x000EE290 File Offset: 0x000EC490
		Private Sub txtSearchProduct_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
					Me.getgriditemdata()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016A2 RID: 5794 RVA: 0x000EE2EC File Offset: 0x000EC4EC
		Private Sub getgriditemdata()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex = 0
				If flag Then
					Me.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                        RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & "     Product.SubCategoryID=SubCategory.ID and" & vbCrLf & "     Temp_Stock.ProductID=Product.PID and " & vbCrLf & "     Product.PID=Product_Join.ProductID and" & vbCrLf & "     ProductName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
				Else
					Dim flag2 As Boolean = Me.cmbSearchCat.SelectedIndex = 1
					If flag2 Then
						Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                        RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & "     Product.SubCategoryID=SubCategory.ID and" & vbCrLf & vbCrLf & "     Temp_Stock.ProductID=Product.PID and " & vbCrLf & "     Product.PID=Product_Join.ProductID and" & vbCrLf & "     SubCategory.SubCategoryName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
					Else
						Dim flag3 As Boolean = Me.cmbSearchCat.SelectedIndex = 2
						If flag3 Then
							Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                        RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & "     Product.SubCategoryID=SubCategory.ID and" & vbCrLf & vbCrLf & "     Temp_Stock.ProductID=Product.PID and " & vbCrLf & "     Product.PID=Product_Join.ProductID and" & vbCrLf & "     SubCategory.Category like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
						Else
							Dim flag4 As Boolean = Me.cmbSearchCat.SelectedIndex = 3
							If flag4 Then
								Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                        RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & "     Product.SubCategoryID=SubCategory.ID and" & vbCrLf & vbCrLf & "     Temp_Stock.ProductID=Product.PID and " & vbCrLf & "     Product.PID=Product_Join.ProductID and" & vbCrLf & "    Temp_Stock.Barcode like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
							Else
								Dim flag5 As Boolean = Me.cmbSearchCat.SelectedIndex = 4
								If flag5 Then
									Me.cmd = New SqlCommand(String.Concat(New String() { "Select TOP ", Me.txtTopResult.Text, " PID, RTrim(ProductCode), RTrim(ProductName)," & vbCrLf & "    RTrim(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint, RTrim(Product.Barcode), OpeningStock, RTrim(PurchaseUnit), RTrim(Salesunit), RTrim(SalesAltUnit), RTrim(Conv), RTrim(MinStock), (Product.MRP), RTrim(Product.Status)," & vbCrLf & "    (Product.STax), (Product.PTax), RTrim(Product.GDown), RTrim(Product.Rack), (Product.DefQty), Temp_Stock.Qty, RTrim(Temp_Stock.Barcode), (Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice), (Temp_Stock.WPrice), RTrim(Temp_Stock.Batch), (Temp_Stock.Mfgdate), (Temp_Stock.Expdate), RTrim(Temp_Stock.Size)," & vbCrLf & "    RTrim(Temp_Stock.Colour), RTrim(Product.Kitchen), temp_Stock.IMEI1, temp_Stock.IMEI2, Photo from Category, SubCategory, Product, Temp_Stock, Product_Join where Category.CategoryName=SubCategory.Category And" & vbCrLf & "     Product.SubCategoryID = SubCategory.ID And" & vbCrLf & vbCrLf & "     Temp_Stock.ProductID = Product.PID And" & vbCrLf & "     Product.PID = Product_Join.ProductID And" & vbCrLf & "    PartNo Like N'", Me.TextBox1.Text, "%' order by PID desc" }), Me.con)
								Else
									Me.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " PID, RTRIM(ProductCode),RTRIM(Productname), " & vbCrLf & "                        RTRIM(CategoryName),'', RTRIM(SubCategoryName),'',SubCategoryID,RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description, CostPrice,SellingPrice, Discount,'','',CGST,SGST,'',CESS, " & vbCrLf & "    ReorderPoint,RTRIM(Product.Barcode),OpeningStock,RTRIM(PurchaseUnit),RTRIM(Salesunit),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),(Product.MRP),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty,RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),RTRIM(Product.Kitchen),temp_Stock.IMEI1,temp_Stock.IMEI2,Photo,temp_Stock.Variant_id from Category,SubCategory,Product,Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and" & vbCrLf & "     Product.SubCategoryID=SubCategory.ID and" & vbCrLf & "     Temp_Stock.ProductID=Product.PID and " & vbCrLf & "     Product.PID=Product_Join.ProductID and" & vbCrLf & "     ProductName like N'", Me.txtSearchProduct.Text, "%' order by PID desc" }), Me.con)
								End If
							End If
						End If
					End If
				End If
				Dim sqlDataReader As SqlDataReader = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While sqlDataReader.Read()
					Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18), sqlDataReader(19), sqlDataReader(20), sqlDataReader(21), sqlDataReader(22), sqlDataReader(23), sqlDataReader(24), sqlDataReader(25), sqlDataReader(26), sqlDataReader(27), sqlDataReader(28), sqlDataReader(29), sqlDataReader(30), sqlDataReader(31), sqlDataReader(32), sqlDataReader(33), sqlDataReader(34), sqlDataReader(35), sqlDataReader(36), sqlDataReader(37), sqlDataReader(38), sqlDataReader(39), sqlDataReader(40), sqlDataReader(41), sqlDataReader(42), sqlDataReader(43), sqlDataReader(44), sqlDataReader(45), sqlDataReader(46), sqlDataReader(47), sqlDataReader(48), sqlDataReader(49) })
				End While
				sqlDataReader.Close()
				Me.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060016A3 RID: 5795 RVA: 0x000EE848 File Offset: 0x000ECA48
		Public Sub CheckAllResourceImages()
			Dim list As List(Of String) = New List(Of String)()
			Dim resourceSet As ResourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, True, True)
			For Each obj As Object In resourceSet
				Dim dictionaryEntry As DictionaryEntry = If((obj IsNot Nothing), CType(obj, DictionaryEntry), Nothing)
				Dim text As String = dictionaryEntry.Key.ToString()
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dictionaryEntry.Value)
				Dim flag As Boolean = TypeOf objectValue Is Bitmap OrElse TypeOf objectValue Is Image
				If flag Then
					Try
						Using CType(objectValue, Image)
						End Using
					Catch ex As Exception
						list.Add(text)
					End Try
				End If
			Next
			Dim flag2 As Boolean = list.Count > 0
			If flag2 Then
				MessageBox.Show("Corrupt Images Found: " + String.Join(", ", list))
			Else
				MessageBox.Show("All images are valid.")
			End If
		End Sub

		' Token: 0x060016A4 RID: 5796 RVA: 0x00012154 File Offset: 0x00010354
		Private Sub frmProductRecord_Load(sender As Object, e As EventArgs)
			Me.SetupDataGridViewColumns()
			Me.Getdata()
		End Sub

		' Token: 0x060016A5 RID: 5797 RVA: 0x000EE970 File Offset: 0x000ECB70
		Private Sub DataforNP()
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Close()
			Me.CurrentRow = 0
			Me.con.Open()
			Me.Dad = New SqlDataAdapter("Select * FROM Product", Me.con)
			Me.Dad.Fill(Me.Dst, "Product")
			Try
				Me.txtNP.Text = Conversions.ToString(Me.Dst.Tables("Product").Rows(Conversions.ToInteger(Me.CurrentRow))("PID"))
				Me.con.Close()
			Catch ex As Exception
			End Try
			Me.con.Close()
		End Sub

		' Token: 0x060016A6 RID: 5798 RVA: 0x000EEA60 File Offset: 0x000ECC60
		Private Function GenerateID1() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("ID"))
				End If
				Me.rdr.Close()
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
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060016A7 RID: 5799 RVA: 0x000EEBE4 File Offset: 0x000ECDE4
		Public Sub GenerateBarcode()
			Try
				Me.BCodeDisplay()
				Dim text As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
				Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text
				Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells(29).Value = Me.txtBarcodeTempStock.Text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016A8 RID: 5800 RVA: 0x000EECA8 File Offset: 0x000ECEA8
		Public Sub BCodeDisplay()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlCommand As SqlCommand = Me.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				Me.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = Me.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = Me.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				Me.rdr.Close()
				Me.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016A9 RID: 5801 RVA: 0x000EED98 File Offset: 0x000ECF98
		Public Sub ScrollToSelectedCell(rowIndex As Short, colIndex As Short)
			Me.DataGridView1.FirstDisplayedScrollingRowIndex = CInt(rowIndex)
			Me.DataGridView1.FirstDisplayedScrollingColumnIndex = CInt(colIndex)
			Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(CInt(rowIndex)).Cells(CInt(colIndex))
		End Sub

		' Token: 0x060016AA RID: 5802 RVA: 0x000EEDE8 File Offset: 0x000ECFE8
		Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.DataGridView1.ClearSelection()
			Me.DataGridView1.EndEdit()
			Me.DataGridView1.BeginEdit(True)
			Dim flag As Boolean = e.ColumnIndex = Me.DataGridView1.Columns(43).Index AndAlso e.RowIndex >= 0
			If flag Then
				Dim text As String = Me.DataGridView1.Rows(e.RowIndex).Cells(43).Value.ToString()
				Dim flag2 As Boolean = Operators.CompareString(text, "Update", False) = 0
				If flag2 Then
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text2 As String = "Update Product Set ProductCode=@d1, Productname=@d2, SubCategoryID=@d3,HSNCode=@d4,PartNo=@d5, Description=@d6, CostPrice=@d7," & vbCrLf & "SellingPrice=@d8,Discount=@d9, CGST=@d10,SGST=@d11,Cess=@d12,Barcode=@d13,PurchaseUnit=@d16,SalesUnit=@d17," & vbCrLf & "SalesAltUnit=@d18,Conv=@d19,MinStock=@d21,MRP=@d22,Status=@d23,STax=@d24,PTax=@d25,GDown=@d26,Rack=@d27,DefQty=@d29,  " & vbCrLf & "Kitchen=@d30 where PID= @d0"
					Me.cmd = New SqlCommand(text2)
					Me.cmd.Parameters.AddWithValue("@d0", dataGridViewRow.Cells(0).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d3", Conversions.ToInteger(dataGridViewRow.Cells(1).Value))
					Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(5).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells(6).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells(8).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(dataGridViewRow.Cells(9).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d6", dataGridViewRow.Cells(10).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells(11).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(dataGridViewRow.Cells(31).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d9", Conversion.Val(dataGridViewRow.Cells(12).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d10", dataGridViewRow.Cells(14).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d11", dataGridViewRow.Cells(15).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells(16).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d13", Conversion.Val(dataGridViewRow.Cells(29).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d16", dataGridViewRow.Cells(17).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d17", dataGridViewRow.Cells(18).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(19).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow.Cells(20).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(dataGridViewRow.Cells(21).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d23", dataGridViewRow.Cells(22).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d22", Conversion.Val(dataGridViewRow.Cells(30).Value.ToString()))
					Me.cmd.Parameters.AddWithValue("@d24", dataGridViewRow.Cells(23).Value.ToString())
					Me.cmd.Parameters.AddWithValue("@d25", dataGridViewRow.Cells(24).Value.ToString())
					Dim flag3 As Boolean = dataGridViewRow.Cells(25).Value IsNot Nothing
					If flag3 Then
						Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(25).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d26", "")
					End If
					Dim flag4 As Boolean = dataGridViewRow.Cells(26).Value IsNot Nothing
					If flag4 Then
						Me.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(26).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d27", "")
					End If
					Dim flag5 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, "", False), Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, "0", False)))
					If flag5 Then
						Me.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d29", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
					End If
					Me.cmd.Parameters.AddWithValue("@d30", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(40).Value))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteNonQuery()
					Me.con.Close()
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text3 As String = "Update Temp_Stock Set SalePrice=@d2, WSalePrice=@d3, StLimit=@d4, MRP=@d5, Batch=@d6, Mfgdate=@d7, Expdate=@d8, Size=@d9," & vbCrLf & "Colour=@d10, SPrice=@d11, WPrice=@d12, IMEI1=@d14, IMEI2=@d15,  PPrice=@d16 where ProductID=@d1"
					Me.cmd = New SqlCommand(text3)
					Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
					Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(31).Value)))
					Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(32).Value)))
					Me.cmd.Parameters.AddWithValue("@d4", 0.0)
					Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
					Dim flag6 As Boolean = dataGridViewRow.Cells(33).Value IsNot Nothing
					If flag6 Then
						Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(33).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d6", "")
					End If
					Dim flag7 As Boolean = dataGridViewRow.Cells(34).Value IsNot Nothing
					If flag7 Then
						Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(34).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d7", "")
					End If
					Dim flag8 As Boolean = dataGridViewRow.Cells(35).Value IsNot Nothing
					If flag8 Then
						Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(35).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d8", "")
					End If
					Dim flag9 As Boolean = dataGridViewRow.Cells(36).Value IsNot Nothing
					If flag9 Then
						Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(36).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d9", "")
					End If
					Dim flag10 As Boolean = dataGridViewRow.Cells(37).Value IsNot Nothing
					If flag10 Then
						Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(37).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d10", "")
					End If
					Me.cmd.Parameters.AddWithValue("@d11", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(31).Value)))
					Me.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(32).Value)))
					Dim flag11 As Boolean = dataGridViewRow.Cells(38).Value IsNot Nothing
					If flag11 Then
						Me.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(38).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d14", "")
					End If
					Dim flag12 As Boolean = dataGridViewRow.Cells(39).Value IsNot Nothing
					If flag12 Then
						Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(39).Value))
					Else
						Me.cmd.Parameters.AddWithValue("@d15", "")
					End If
					Me.cmd.Parameters.AddWithValue("@d16", Conversion.Val(dataGridViewRow.Cells(11).Value.ToString()))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteNonQuery()
					Me.con.Close()
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text4 As String = "delete from ExtDB1 where a1=@d1"
					Me.cmd = New SqlCommand(text4)
					Me.cmd.Parameters.AddWithValue("@d1", Me.id)
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteReader()
					Me.con.Close()
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text5 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
					Me.cmd = New SqlCommand(text5)
					Me.cmd.Parameters.AddWithValue("@d1", Me.id)
					Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(18).Value))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteReader()
					Me.con.Close()
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text6 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
					Me.cmd = New SqlCommand(text6)
					Me.cmd.Parameters.AddWithValue("@d1", Me.id)
					Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(19).Value))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteReader()
					Me.con.Close()
					ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the Product '", dataGridViewRow.Cells(6).Value.ToString(), "' having Product code '", dataGridViewRow.Cells(5).Value.ToString(), "'" }))
					MessageBox.Show("Successfully Updated", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.con.Close()
				Else
					Dim flag13 As Boolean = Operators.CompareString(text, "Save", False) = 0
					If flag13 Then
						Me.auto()
						Dim dataGridViewRow2 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
						Dim flag14 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow2.Cells(29).Value, "", False)
						If flag14 Then
							Me.GenerateBarcode()
						End If
						Dim flag15 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells(6).Value))) = 0
						If flag15 Then
							MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 6)
							Return
						End If
						Dim flag16 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells(7).Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells(7).Value))) = 0)
						If flag16 Then
							MessageBox.Show("Please select subcategory ,category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 7)
							Return
						End If
						Dim flag17 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value))))) = 0) Or (dataGridViewRow2.Cells(11).Value Is Nothing)
						If flag17 Then
							MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 11)
							Return
						End If
						Dim flag18 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells(13).Value))) = 0
						If flag18 Then
							MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 13)
							Return
						End If
						Dim flag19 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow2.Cells(17).Value))) = 0) Or (dataGridViewRow2.Cells(17).Value Is Nothing)
						If flag19 Then
							MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 17)
							Return
						End If
						Dim flag20 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow2.Cells(18).Value.ToString())) = 0
						If flag20 Then
							MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 18)
							Return
						End If
						Dim flag21 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow2.Cells(19).Value.ToString())) = 0
						If flag21 Then
							MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 19)
							Return
						End If
						Dim flag22 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(20).Value))))) = 0) Or (dataGridViewRow2.Cells(20).Value Is Nothing)
						If flag22 Then
							MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 20)
							Return
						End If
						Dim flag23 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(27).Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow2.Cells(27).Value, 0, False)))
						If flag23 Then
							MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 27)
							Return
						End If
						Dim flag24 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(30).Value)) <= 0.0
						If flag24 Then
							MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.SetCurrentCell(dataGridViewRow2, 30)
							Return
						End If
						Dim flag25 As Boolean = Me.DataGridView1.Rows.Count > 0
						If flag25 Then
							Try
								For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
									Dim dataGridViewRow3 As DataGridViewRow = CType(obj, DataGridViewRow)
									Me.con = New SqlConnection(ModCS.cs)
									Me.con.Open()
									Dim text7 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
									Me.cmd = New SqlCommand(text7)
									Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
									Me.cmd.Connection = Me.con
									Me.rdr = Me.cmd.ExecuteReader()
									Dim flag26 As Boolean = Me.rdr.Read()
									If flag26 Then
										MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow3.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
										Dim flag27 As Boolean = Me.rdr IsNot Nothing
										If flag27 Then
											Me.rdr.Close()
										End If
										Return
									End If
									Me.con = New SqlConnection(ModCS.cs)
									Me.con.Open()
									Dim text8 As String = "select Barcode from Temp_Stock where Barcode=@d1"
									Me.cmd = New SqlCommand(text8)
									Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
									Me.cmd.Connection = Me.con
									Me.rdr = Me.cmd.ExecuteReader()
									Dim flag28 As Boolean = Me.rdr.Read()
									If flag28 Then
										MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow3.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
										Dim flag29 As Boolean = Me.rdr IsNot Nothing
										If flag29 Then
											Me.rdr.Close()
										End If
										Return
									End If
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
						Else
							Dim flag30 As Boolean = Me.DataGridView1.Rows.Count <= 0
							If flag30 Then
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text9 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
								Me.cmd = New SqlCommand(text9)
								Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
								Me.cmd.Connection = Me.con
								Me.rdr = Me.cmd.ExecuteReader()
								Dim flag31 As Boolean = Me.rdr.Read()
								If flag31 Then
									MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
									Dim flag32 As Boolean = Me.rdr IsNot Nothing
									If flag32 Then
										Me.rdr.Close()
									End If
									Return
								End If
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text10 As String = "select Barcode from Temp_Stock where Barcode=@d1"
								Me.cmd = New SqlCommand(text10)
								Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
								Me.cmd.Connection = Me.con
								Me.rdr = Me.cmd.ExecuteReader()
								Dim flag33 As Boolean = Me.rdr.Read()
								If flag33 Then
									MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
									Dim flag34 As Boolean = Me.rdr IsNot Nothing
									If flag34 Then
										Me.rdr.Close()
									End If
									Return
								End If
							End If
						End If
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text11 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID,HSNCode,PartNo, Description, CostPrice,SellingPrice," & vbCrLf & "Discount, CGST, SGST, CESS, Barcode,  PurchaseUnit, SalesUnit, SalesAltUnit, Conv, MinStock, MRP, Status, STax," & vbCrLf & "PTax, GDown, Rack, DefQty, Kitchen,loyality_mode,loyality_value,AddDate) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17," & vbCrLf & "@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29)"
						Me.cmd = New SqlCommand(text11, Me.con)
						Me.cmd.Parameters.AddWithValue("@d0", Conversions.ToInteger(dataGridViewRow2.Cells(0).Value.ToString()))
						Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow2.Cells(5).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(6).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(1).Value))
						Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow2.Cells(8).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d5", dataGridViewRow2.Cells(9).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d6", dataGridViewRow2.Cells(10).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(11).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(11).Value))))
						Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(31).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(31).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(31).Value))))
						Dim parameters As SqlParameterCollection = Me.cmd.Parameters
						Dim text12 As String = "@d9"
						Dim flag35 As Boolean = Not dataGridViewRow2.Cells(12).Visible
						Dim value As Object = dataGridViewRow2.Cells(12).Value
						parameters.AddWithValue(text12, RuntimeHelpers.GetObjectValue(If((flag35 Or String.IsNullOrEmpty(If((value IsNot Nothing), value.ToString(), Nothing)) Or Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(12).Value))), If((String.IsNullOrEmpty(Conversions.ToString(Me.DRate)) Or Information.IsDBNull(Me.DRate)), DBNull.Value, Me.DRate), Conversions.ToDouble(dataGridViewRow2.Cells(12).Value))))
						Dim parameters2 As SqlParameterCollection = Me.cmd.Parameters
						Dim text13 As String = "@d10"
						Dim flag36 As Boolean = Not dataGridViewRow2.Cells(14).Visible
						Dim value2 As Object = dataGridViewRow2.Cells(14).Value
						parameters2.AddWithValue(text13, RuntimeHelpers.GetObjectValue(If((flag36 Or String.IsNullOrEmpty(If((value2 IsNot Nothing), value2.ToString(), Nothing)) Or Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(14).Value))), If((String.IsNullOrEmpty(Conversions.ToString(Me.Rate)) Or Information.IsDBNull(Me.Rate)), DBNull.Value, (Me.Rate / 2.0)), Conversions.ToDouble(dataGridViewRow2.Cells(14).Value))))
						Dim parameters3 As SqlParameterCollection = Me.cmd.Parameters
						Dim text14 As String = "@d11"
						Dim flag37 As Boolean = Not dataGridViewRow2.Cells(15).Visible
						Dim value3 As Object = dataGridViewRow2.Cells(15).Value
						parameters3.AddWithValue(text14, RuntimeHelpers.GetObjectValue(If((flag37 Or String.IsNullOrEmpty(If((value3 IsNot Nothing), value3.ToString(), Nothing)) Or Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(15).Value))), If((String.IsNullOrEmpty(Conversions.ToString(Me.Rate)) Or Information.IsDBNull(Me.Rate)), DBNull.Value, (Me.Rate / 2.0)), Conversions.ToDouble(dataGridViewRow2.Cells(15).Value))))
						Me.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(16).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(16).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(16).Value))))
						Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow2.Cells(29).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Not dataGridViewRow2.Cells(17).Visible, Operators.CompareObjectEqual(dataGridViewRow2.Cells(17).Value, "", False)), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(17).Value)))), If(((Me.unit = Nothing) Or (Operators.CompareString(Me.unit, "", False) = 0)), DBNull.Value, Me.unit), dataGridViewRow2.Cells(17).Value.ToString())))
						Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Not dataGridViewRow2.Cells(18).Visible, Operators.CompareObjectEqual(dataGridViewRow2.Cells(18).Value, "", False)), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(18).Value)))), If(((Me.unit = Nothing) Or (Operators.CompareString(Me.unit, "", False) = 0)), DBNull.Value, Me.unit), dataGridViewRow2.Cells(18).Value.ToString())))
						Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Not dataGridViewRow2.Cells(19).Visible, Operators.CompareObjectEqual(dataGridViewRow2.Cells(19).Value, "", False)), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(19).Value)))), If(((Me.unit = Nothing) Or (Operators.CompareString(Me.unit, "", False) = 0)), DBNull.Value, Me.unit), dataGridViewRow2.Cells(19).Value.ToString())))
						Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(20).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(20).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(20).Value))))
						Me.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(21).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(21).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(21).Value))))
						Me.cmd.Parameters.AddWithValue("@d19", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(30).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(30).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(30).Value))))
						Me.cmd.Parameters.AddWithValue("@d20", dataGridViewRow2.Cells(22).Value.ToString())
						Me.cmd.Parameters.AddWithValue("@d21", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Not dataGridViewRow2.Cells(23).Visible, Operators.CompareObjectEqual(dataGridViewRow2.Cells(23).Value, "", False)), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(23).Value)))), If(((Me.stax_type = Nothing) Or (Operators.CompareString(Me.stax_type, "", False) = 0)), DBNull.Value, Me.stax_type), dataGridViewRow2.Cells(23).Value.ToString())))
						Me.cmd.Parameters.AddWithValue("@d22", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Not dataGridViewRow2.Cells(24).Visible, Operators.CompareObjectEqual(dataGridViewRow2.Cells(24).Value, "", False)), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(24).Value)))), If(((Me.Ptax_type = Nothing) Or (Operators.CompareString(Me.Ptax_type, "", False) = 0)), DBNull.Value, Me.Ptax_type), dataGridViewRow2.Cells(24).Value.ToString())))
						Me.cmd.Parameters.AddWithValue("@d23", If((dataGridViewRow2.Cells(25).Value Is Nothing), "", dataGridViewRow2.Cells(25).Value.ToString()))
						Me.cmd.Parameters.AddWithValue("@d24", If((dataGridViewRow2.Cells(26).Value Is Nothing), "", dataGridViewRow2.Cells(26).Value.ToString()))
						Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(If(Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow2.Cells(27).Value, "", False), Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(27).Value)))), DBNull.Value, Conversions.ToDouble(dataGridViewRow2.Cells(27).Value))))
						Me.cmd.Parameters.AddWithValue("@d26", If((dataGridViewRow2.Cells(40).Value Is Nothing), "", dataGridViewRow2.Cells(40).Value.ToString()))
						Me.cmd.Parameters.AddWithValue("@d27", "per")
						Me.cmd.Parameters.AddWithValue("@d28", "0.00")
						Me.cmd.Parameters.AddWithValue("@d29", DateTime.Today)
						Me.cmd.Connection = Me.con
						Me.cmd.ExecuteNonQuery()
						Me.con.Close()
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text15 As String = " insert into Product_Join(ProductID, Photo) VALUES (@d0,@d1) "
						Me.cmd = New SqlCommand(text15)
						Me.cmd.Connection = Me.con
						Me.cmd.Parameters.AddWithValue("@d0", Me.id)
						Dim sqlParameter As SqlParameter = New SqlParameter("@d1", SqlDbType.Image)
						Dim flag38 As Boolean = dataGridViewRow2.Cells(41).Value IsNot Nothing
						If flag38 Then
							Dim flag39 As Boolean = TypeOf dataGridViewRow2.Cells(41).Value Is Image
							If flag39 Then
								Dim image As Image = CType(dataGridViewRow2.Cells(41).Value, Image)
								Using memoryStream As MemoryStream = New MemoryStream()
									image.Save(memoryStream, ImageFormat.Jpeg)
									sqlParameter.Value = memoryStream.ToArray()
								End Using
							Else
								Dim flag40 As Boolean = TypeOf dataGridViewRow2.Cells(41).Value Is Byte()
								If flag40 Then
									sqlParameter.Value = RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(41).Value)
								Else
									sqlParameter.Value = DBNull.Value
								End If
							End If
						Else
							sqlParameter.Value = DBNull.Value
						End If
						Me.cmd.Parameters.Add(sqlParameter)
						Me.cmd.ExecuteNonQuery()
						Me.con.Close()
						Me.con.Open()
						Dim text16 As String = "insert into Product_OpeningStock(ProductID,Qty,Barcode,SalePrice,MRP,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,IMEI1,IMEI2,PPrice," & vbCrLf & "PAddDate,OPSValue) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
						Me.cmd = New SqlCommand(text16)
						Me.cmd.Connection = Me.con
						Me.cmd.Parameters.AddWithValue("@d0", Me.id)
						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(28).Value))
						Dim flag41 As Boolean = dataGridViewRow2.Cells(29).Value Is Nothing
						If flag41 Then
							Me.cmd.Parameters.AddWithValue("@d2", Me.txtBarcodeTempStock.Text)
						Else
							Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
						End If
						Dim flag42 As Boolean = dataGridViewRow2.Cells(30).Value IsNot Nothing
						If flag42 Then
							Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(31).Value)))
						Else
							Me.cmd.Parameters.AddWithValue("@d3", 0)
						End If
						Dim flag43 As Boolean = dataGridViewRow2.Cells(31).Value IsNot Nothing
						If flag43 Then
							Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(30).Value)))
						Else
							Me.cmd.Parameters.AddWithValue("@d4", 0)
						End If
						Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(32).Value)))
						Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(33).Value))
						Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(34).Value))
						Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(35).Value))
						Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(36).Value))
						Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(37).Value))
						Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(38).Value))
						Me.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(39).Value))
						Me.cmd.Parameters.AddWithValue("@d14", DateTime.Today)
						Dim flag44 As Boolean = Operators.CompareString(dataGridViewRow2.Cells(24).ToString(), "Inclusive", False) = 0
						Dim num As Double
						If flag44 Then
							num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value)), 2)), "0.00"))
						Else
							num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(11).Value)), 2)), "0.00"))
						End If
						Me.cmd.Parameters.AddWithValue("@d13", num)
						Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(3).Value)), 2)), "0.00"))
						Me.cmd.ExecuteNonQuery()
						Me.cmd.Parameters.Clear()
						Me.con.Close()
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text17 As String = " insert into Temp_Stock(ProductID, PPrice, Qty, Barcode, MRP, SPrice, WPrice,   " & vbCrLf & "Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice,  IMEI1, " & vbCrLf & "IMEI2, EPPrice, Variant_id, StLimit, SuplName, QrBarcode, SalesManPur) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10," & vbCrLf & "@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21) "
						Me.cmd = New SqlCommand(text17)
						Me.cmd.Connection = Me.con
						Me.cmd.Parameters.AddWithValue("@d0", Me.id)
						Dim flag45 As Boolean = dataGridViewRow2.Cells(11).Value IsNot Nothing
						If flag45 Then
							Me.cmd.Parameters.AddWithValue("@d1", Conversions.ToDecimal(dataGridViewRow2.Cells(11).Value))
							Me.cmd.Parameters.AddWithValue("@d16", Conversions.ToDecimal(dataGridViewRow2.Cells(11).Value))
						Else
							Me.cmd.Parameters.AddWithValue("@d1", 0)
							Me.cmd.Parameters.AddWithValue("@d16", 0)
						End If
						Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(28).Value))
						Dim flag46 As Boolean = dataGridViewRow2.Cells(29).Value Is Nothing
						If flag46 Then
							Me.cmd.Parameters.AddWithValue("@d3", Me.txtBarcodeTempStock.Text)
						Else
							Me.cmd.Parameters.AddWithValue("@d3", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(29).Value))
						End If
						Dim flag47 As Boolean = dataGridViewRow2.Cells(30).Value IsNot Nothing
						If flag47 Then
							Me.cmd.Parameters.AddWithValue("@d4", Conversions.ToDecimal(dataGridViewRow2.Cells(30).Value))
						Else
							Me.cmd.Parameters.AddWithValue("@d4", 0)
						End If
						Me.cmd.Parameters.AddWithValue("@d5", Conversions.ToDecimal(dataGridViewRow2.Cells(31).Value))
						Me.cmd.Parameters.AddWithValue("@d6", Conversions.ToDecimal(dataGridViewRow2.Cells(32).Value))
						Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(33).Value))
						Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(34).Value))
						Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(35).Value))
						Dim flag48 As Boolean = dataGridViewRow2.Cells(36).Value IsNot Nothing
						If flag48 Then
							Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(36).Value))
						Else
							Me.cmd.Parameters.AddWithValue("@d10", "")
						End If
						Dim flag49 As Boolean = dataGridViewRow2.Cells(37).Value IsNot Nothing
						If flag49 Then
							Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(37).Value))
						Else
							Me.cmd.Parameters.AddWithValue("@d11", "")
						End If
						Me.cmd.Parameters.AddWithValue("@d12", Conversions.ToDecimal(dataGridViewRow2.Cells(31).Value))
						Me.cmd.Parameters.AddWithValue("@d13", Conversions.ToDecimal(dataGridViewRow2.Cells(32).Value))
						Me.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(38).Value))
						Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow2.Cells(39).Value))
						Me.cmd.Parameters.AddWithValue("@d17", Me.id)
						Me.cmd.Parameters.AddWithValue("@d18", 0.0)
						Me.cmd.Parameters.AddWithValue("@d19", "Opening Stock")
						Dim flag50 As Boolean = dataGridViewRow2.Cells(29).Value Is Nothing
						If flag50 Then
							Me.Generate_GiftQR(Me.txtBarcodeTempStock.Text)
						Else
							Me.Generate_GiftQR(Conversions.ToString(dataGridViewRow2.Cells(29).Value))
						End If
						Dim memoryStream2 As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
						bitmap.Save(memoryStream2, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream2.GetBuffer()
						Dim sqlParameter2 As SqlParameter = New SqlParameter("@d20", SqlDbType.Image)
						sqlParameter2.Value = buffer
						Me.cmd.Parameters.Add(sqlParameter2)
						Me.cmd.Parameters.AddWithValue("@d21", "0.00")
						Try
							Me.cmd.ExecuteNonQuery()
						Catch ex As Exception
							Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
						End Try
						Me.cmd.Parameters.Clear()
						Me.con.Close()
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text18 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
						Me.cmd = New SqlCommand(text18)
						Me.cmd.Parameters.AddWithValue("@d1", Me.id)
						Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(18).Value.ToString())
						Me.cmd.Connection = Me.con
						Me.cmd.ExecuteReader()
						Me.con.Close()
						Me.con = New SqlConnection(ModCS.cs)
						Me.con.Open()
						Dim text19 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
						Me.cmd = New SqlCommand(text19)
						Me.cmd.Parameters.AddWithValue("@d1", Me.id)
						Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow2.Cells(19).Value.ToString())
						Me.cmd.Connection = Me.con
						Me.cmd.ExecuteReader()
						Me.con.Close()
						ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new Product '", dataGridViewRow2.Cells(6).Value.ToString(), "' having Product code '", dataGridViewRow2.Cells(5).Value.ToString(), "'" }))
						MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.DataGridView1.Rows(e.RowIndex).Cells(43).Value = "Update"
						Me.DataGridView1.Rows(e.RowIndex).Cells(44).Value = "Delete"
						Me.Getdata()
						Me.AddNewRow()
					End If
				End If
			End If
			Dim flag51 As Boolean = e.ColumnIndex = Me.DataGridView1.Columns(44).Index AndAlso e.RowIndex >= 0
			If flag51 Then
				Try
					Dim flag52 As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
					If flag52 Then
						Try
							Dim dataGridViewRow4 As DataGridViewRow = Me.DataGridView1.Rows(e.RowIndex)
							Me.con = New SqlConnection(ModCS.cs)
							Me.con.Open()
							Dim text20 As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Store ON Product.PID = StockAdjustment_Store.ProductID where PID=@d1"
							Me.cmd = New SqlCommand(text20)
							Me.cmd.Connection = Me.con
							Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
							Me.rdr = Me.cmd.ExecuteReader()
							Dim flag53 As Boolean = Me.rdr.Read()
							If flag53 Then
								MessageBox.Show("Unable to delete..Already in use in Stock Adjustment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag54 As Boolean = Me.rdr IsNot Nothing
								If flag54 Then
									Me.rdr.Close()
								End If
							Else
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text21 As String = "SELECT PID FROM Product INNER JOIN Stock_Store_Join ON Product.PID = Stock_Store_Join.ProductID where PID=@d1"
								Me.cmd = New SqlCommand(text21)
								Me.cmd.Connection = Me.con
								Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
								Me.rdr = Me.cmd.ExecuteReader()
								Dim flag55 As Boolean = Me.rdr.Read()
								If flag55 Then
									MessageBox.Show("Unable to delete..Already in use in Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag56 As Boolean = Me.rdr IsNot Nothing
									If flag56 Then
										Me.rdr.Close()
									End If
								Else
									Me.con.Close()
									Me.con = New SqlConnection(ModCS.cs)
									Me.con.Open()
									Dim text22 As String = "SELECT PID FROM Product INNER JOIN PurchaseOrder_Join ON Product.PID = PurchaseOrder_Join.ProductID where PID=@d1"
									Me.cmd = New SqlCommand(text22)
									Me.cmd.Connection = Me.con
									Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
									Me.rdr = Me.cmd.ExecuteReader()
									Dim flag57 As Boolean = Me.rdr.Read()
									If flag57 Then
										MessageBox.Show("Unable to delete..Already in use in Purchase Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Dim flag58 As Boolean = Me.rdr IsNot Nothing
										If flag58 Then
											Me.rdr.Close()
										End If
									Else
										Me.con.Close()
										Me.con = New SqlConnection(ModCS.cs)
										Me.con.Open()
										Dim text23 As String = "SELECT PID FROM Product INNER JOIN Stock_Product ON Product.PID = Stock_Product.ProductID where PID=@d1"
										Me.cmd = New SqlCommand(text23)
										Me.cmd.Connection = Me.con
										Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
										Me.rdr = Me.cmd.ExecuteReader()
										Dim flag59 As Boolean = Me.rdr.Read()
										If flag59 Then
											MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Dim flag60 As Boolean = Me.rdr IsNot Nothing
											If flag60 Then
												Me.rdr.Close()
											End If
										Else
											Me.con.Close()
											Me.con = New SqlConnection(ModCS.cs)
											Me.con.Open()
											Dim text24 As String = "SELECT PID FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID where PID=@d1"
											Me.cmd = New SqlCommand(text24)
											Me.cmd.Connection = Me.con
											Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
											Me.rdr = Me.cmd.ExecuteReader()
											Dim flag61 As Boolean = Me.rdr.Read()
											If flag61 Then
												MessageBox.Show("Unable to delete..Already in use in Sale Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Dim flag62 As Boolean = Me.rdr IsNot Nothing
												If flag62 Then
													Me.rdr.Close()
												End If
											Else
												Me.con.Close()
												Me.con = New SqlConnection(ModCS.cs)
												Me.con.Open()
												Dim text25 As String = "SELECT PID FROM Product INNER JOIN Quotation_Join ON Product.PID = Quotation_Join.ProductID where PID=@d1"
												Me.cmd = New SqlCommand(text25)
												Me.cmd.Connection = Me.con
												Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
												Me.rdr = Me.cmd.ExecuteReader()
												Dim flag63 As Boolean = Me.rdr.Read()
												If flag63 Then
													MessageBox.Show("Unable to delete..Already in use in Quotation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag64 As Boolean = Me.rdr IsNot Nothing
													If flag64 Then
														Me.rdr.Close()
													End If
												Else
													Me.con.Close()
													Me.con = New SqlConnection(ModCS.cs)
													Me.con.Open()
													Dim text26 As String = "SELECT PID FROM Product INNER JOIN Estimate_Join ON Product.PID = Estimate_Join.ProductID where PID=@d1"
													Me.cmd = New SqlCommand(text26)
													Me.cmd.Connection = Me.con
													Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
													Me.rdr = Me.cmd.ExecuteReader()
													Dim flag65 As Boolean = Me.rdr.Read()
													If flag65 Then
														MessageBox.Show("Unable to delete..Already in use in Estimate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
														Dim flag66 As Boolean = Me.rdr IsNot Nothing
														If flag66 Then
															Me.rdr.Close()
														End If
													Else
														Me.con.Close()
														Me.con = New SqlConnection(ModCS.cs)
														Me.con.Open()
														Dim text27 As String = "select ProductID from StockMovement where ProductID=@d1"
														Me.cmd = New SqlCommand(text27)
														Me.cmd.Connection = Me.con
														Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
														Me.rdr = Me.cmd.ExecuteReader()
														Dim flag67 As Boolean = Me.rdr.Read()
														If flag67 Then
															Me.con = New SqlConnection(ModCS.cs)
															Me.con.Open()
															Dim text28 As String = "delete from StockMovement where ProductID=@d1"
															Me.cmd = New SqlCommand(text28)
															Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
															Me.cmd.Connection = Me.con
															Me.cmd.ExecuteNonQuery()
															Me.con.Close()
														End If
														Me.con.Close()
														Me.con = New SqlConnection(ModCS.cs)
														Me.con.Open()
														Dim text29 As String = "delete from Product_OpeningStock where ProductID=@d1"
														Me.cmd = New SqlCommand(text29)
														Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
														Me.cmd.Connection = Me.con
														Dim num2 As Integer = Me.cmd.ExecuteNonQuery()
														Dim flag68 As Boolean = num2 > 0
														If flag68 Then
															Me.con.Close()
														End If
														Me.con.Close()
														Me.con = New SqlConnection(ModCS.cs)
														Me.con.Open()
														Dim text30 As String = "delete from ExtDB1 where a1=@d1"
														Me.cmd = New SqlCommand(text30)
														Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
														Me.cmd.Connection = Me.con
														Me.cmd.ExecuteReader()
														Me.con.Close()
														Me.con.Close()
														Me.con = New SqlConnection(ModCS.cs)
														Me.con.Open()
														Dim text31 As String = "delete from Product where PID=@d1"
														Me.cmd = New SqlCommand(text31)
														Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow4.Cells(0).Value))
														Me.cmd.Connection = Me.con
														num2 = Me.cmd.ExecuteNonQuery()
														Dim flag69 As Boolean = num2 > 0
														If flag69 Then
															MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
															Me.Getdata()
															Me.fillProductID()
															Me.auto()
															Me.GenerateBarcode()
														Else
															MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
															Me.fillProductID()
															Me.auto()
															Me.GenerateBarcode()
															Dim flag70 As Boolean = Me.con.State = ConnectionState.Open
															If flag70 Then
																Me.con.Close()
															End If
															Me.con.Close()
														End If
														Me.DataforNP()
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						Catch ex2 As Exception
							MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				Catch ex3 As Exception
					MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060016AB RID: 5803 RVA: 0x00012165 File Offset: 0x00010365
		Private Sub SetCurrentCell(Row As DataGridViewRow, currentCell As Integer)
			Me.DataGridView1.CurrentCell = Row.Cells(currentCell)
			Me.DataGridView1.BeginEdit(True)
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016AC RID: 5804 RVA: 0x000F2B90 File Offset: 0x000F0D90
		Public Sub DBoperation(rowNo As Integer, Operation As String)
			Dim flag As Boolean = Operators.CompareString(Operation, "Insert", False) = 0 AndAlso rowNo >= 0
			If flag Then
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(rowNo)
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("ProductName").Value))) = 0
				If flag2 Then
					MessageBox.Show("Please enter product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbCategory").Value))) = 0)
					If flag3 Then
						MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = (Operators.CompareString(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value)), "Select", False) = 0) Or (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells("cmbSubCategory").Value))) = 0)
						If flag4 Then
							MessageBox.Show("Please select sub category", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag5 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))))) = 0) Or (dataGridViewRow.Cells("txtPartNo").Value Is Nothing)
							If flag5 Then
								MessageBox.Show("Please enter Part No", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Else
								Dim flag6 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value))))) = 0) Or (dataGridViewRow.Cells(30).Value Is Nothing)
								If flag6 Then
									MessageBox.Show("Please enter purchase price", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Else
									Dim flag7 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(dataGridViewRow.Cells(12).Value.ToString())))) = 0
									If flag7 Then
										MessageBox.Show("Please enter Discount%", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Else
										Dim flag8 As Boolean = Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells(15).Value))) = 0
										If flag8 Then
											MessageBox.Show("Please select your GST %", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Else
											Dim flag9 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(21).Value, "", False)
											If flag9 Then
												MessageBox.Show("Please enter minimum stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
											Else
												Dim flag10 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(dataGridViewRow.Cells(19).Value))) = 0) Or (dataGridViewRow.Cells(19).Value Is Nothing)
												If flag10 Then
													MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
												Else
													Dim flag11 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(20).Value.ToString())) = 0
													If flag11 Then
														MessageBox.Show("Please select sales main unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
													Else
														Dim flag12 As Boolean = Strings.Len(Strings.Trim(dataGridViewRow.Cells(21).Value.ToString())) = 0
														If flag12 Then
															MessageBox.Show("Please select alter unit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
														Else
															Dim flag13 As Boolean = (Strings.Len(Strings.Trim(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))))) = 0) Or (dataGridViewRow.Cells(20).Value Is Nothing)
															If flag13 Then
																MessageBox.Show("Please enter conversion value", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
															Else
																Dim flag14 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, 0, False)))
																If flag14 Then
																	MessageBox.Show("Please enter default sale qty", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																Else
																	Dim flag15 As Boolean = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)) <= 0.0
																	If flag15 Then
																		MessageBox.Show("Please enter MRP", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																	Else
																		Dim flag16 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(29).Value, "", False)
																		If flag16 Then
																			MessageBox.Show("Please enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
																			Me.txtBarcode.Focus()
																		Else
																			Dim flag17 As Boolean = Me.DataGridView1.Rows.Count > 0
																			If flag17 Then
																				Try
																					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag18 As Boolean = Me.rdr.Read()
																						If flag18 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag19 As Boolean = Me.rdr IsNot Nothing
																							If flag19 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																						Me.con = New SqlConnection(ModCS.cs)
																						Me.con.Open()
																						Dim text2 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																						Me.cmd = New SqlCommand(text2)
																						Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																						Me.cmd.Connection = Me.con
																						Me.rdr = Me.cmd.ExecuteReader()
																						Dim flag20 As Boolean = Me.rdr.Read()
																						If flag20 Then
																							MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																							Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow2.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																							Dim flag21 As Boolean = Me.rdr IsNot Nothing
																							If flag21 Then
																								Me.rdr.Close()
																							End If
																							Return
																						End If
																					Next
																				Finally
																					Dim enumerator As IEnumerator
																					If TypeOf enumerator Is IDisposable Then
																						TryCast(enumerator, IDisposable).Dispose()
																					End If
																				End Try
																			Else
																				Dim flag22 As Boolean = Me.DataGridView1.Rows.Count <= 0
																				If flag22 Then
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text3 As String = "select Barcode from Product_OpeningStock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text3)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag23 As Boolean = Me.rdr.Read()
																					If flag23 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag24 As Boolean = Me.rdr IsNot Nothing
																						If flag24 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																					Me.con = New SqlConnection(ModCS.cs)
																					Me.con.Open()
																					Dim text4 As String = "select Barcode from Temp_Stock where Barcode=@d1"
																					Me.cmd = New SqlCommand(text4)
																					Me.cmd.Parameters.AddWithValue("@d1", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																					Me.cmd.Connection = Me.con
																					Me.rdr = Me.cmd.ExecuteReader()
																					Dim flag25 As Boolean = Me.rdr.Read()
																					If flag25 Then
																						MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
																						Me.DataGridView1.CurrentCell = Me.DataGridView1(dataGridViewRow.Cells(29).ColumnIndex, Me.DataGridView1.CurrentCell.RowIndex)
																						Dim flag26 As Boolean = Me.rdr IsNot Nothing
																						If flag26 Then
																							Me.rdr.Close()
																						End If
																						Return
																					End If
																				End If
																			End If
																			Me.auto()
																			Dim text5 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "    Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
																			Me.cmd = New SqlCommand(text5)
																			Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																			Me.cmd.Parameters.AddWithValue("@d1", dataGridViewRow.Cells(5).Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d2", dataGridViewRow.Cells("ProductName").Value.ToString())
																			Dim flag27 As Boolean = Operators.CompareString(frmProductSmart.strForm, "POSNewTuch", False) = 0
																			If flag27 Then
																				Me.cmd.Parameters.AddWithValue("@d3", frmProductSmart.strSubcategory_POSNewTuch)
																			Else
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(dataGridViewRow.Cells(1).Value.ToString()))
																			End If
																			Dim flag28 As Boolean = dataGridViewRow.Cells(10).Value IsNot Nothing
																			If flag28 Then
																				Me.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d4", dataGridViewRow.Cells("ProductName").Value.ToString())
																			End If
																			Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																			Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(dataGridViewRow.Cells(12).Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value)))
																			Me.cmd.Parameters.AddWithValue("@d11", "0")
																			Me.cmd.Parameters.AddWithValue("@d12", dataGridViewRow.Cells(19).Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d13", dataGridViewRow.Cells(20).Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtSGST").Value)))
																			Me.cmd.Parameters.AddWithValue("@d15", dataGridViewRow.Cells("txtHSNCode").Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtPartNo").Value))
																			Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value)))
																			Me.cmd.Parameters.AddWithValue("@d18", dataGridViewRow.Cells(19).Value.ToString())
																			Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(dataGridViewRow.Cells(20).Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(dataGridViewRow.Cells(21).Value.ToString()))
																			Me.cmd.Parameters.AddWithValue("@d22", "Yes")
																			Me.cmd.Parameters.AddWithValue("@d23", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSalesTaxType").Value))
																			Me.cmd.Parameters.AddWithValue("@d24", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbPurchaseTaxType").Value))
																			Dim flag29 As Boolean = dataGridViewRow.Cells("ddlGDown").Value IsNot Nothing
																			If flag29 Then
																				Me.cmd.Parameters.AddWithValue("@d25", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlGDown").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d25", "")
																			End If
																			Dim flag30 As Boolean = dataGridViewRow.Cells("ddlRack").Value IsNot Nothing
																			If flag30 Then
																				Me.cmd.Parameters.AddWithValue("@d26", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ddlRack").Value))
																			Else
																				Me.cmd.Parameters.AddWithValue("@d26", "")
																			End If
																			Me.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																			Me.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d29", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																			Me.cmd.Parameters.AddWithValue("@d30", "0")
																			Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
																			Dim flag31 As Boolean = Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, 0.0, False), Operators.CompareObjectEqual(dataGridViewRow.Cells(27).Value, 0, False)))
																			If flag31 Then
																				Me.cmd.Parameters.AddWithValue("@d32", "1")
																			Else
																				Me.cmd.Parameters.AddWithValue("@d32", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(27).Value))
																			End If
																			Me.cmd.Parameters.AddWithValue("@d33", "")
																			Me.con = New SqlConnection(ModCS.cs)
																			Try
																				Me.con.Open()
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteNonQuery()
																				Me.con.Close()
																				Me.con.Open()
																				Dim text6 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
																				Me.cmd = New SqlCommand(text6)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Try
																					For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
																						Dim dataGridViewRow3 As DataGridViewRow = CType(obj2, DataGridViewRow)
																						Dim isNewRow As Boolean = dataGridViewRow3.IsNewRow
																						If isNewRow Then
																							Dim memoryStream As MemoryStream = New MemoryStream()
																							Dim image As Image = CType(dataGridViewRow3.Cells("Photo").Value, Image)
																							Dim bitmap As Bitmap = New Bitmap(image)
																							bitmap.Save(memoryStream, ImageFormat.Jpeg)
																							Dim buffer As Byte() = memoryStream.GetBuffer()
																							Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
																							sqlParameter.Value = buffer
																							Me.cmd.Parameters.Add(sqlParameter)
																							Me.cmd.ExecuteNonQuery()
																							Me.cmd.Parameters.Clear()
																						End If
																					Next
																				Finally
																					Dim enumerator2 As IEnumerator
																					If TypeOf enumerator2 Is IDisposable Then
																						TryCast(enumerator2, IDisposable).Dispose()
																					End If
																				End Try
																				Me.con.Close()
																				Me.con.Open()
																				Dim text7 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
																				Me.cmd = New SqlCommand(text7)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Dim flag32 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag32 Then
																					Me.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d5", "")
																				End If
																				Dim flag33 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag33 Then
																					Me.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d6", "")
																				End If
																				Dim flag34 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag34 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag35 As Boolean = dataGridViewRow.Cells("cmbSize").Value IsNot Nothing
																				If flag35 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag36 As Boolean = dataGridViewRow.Cells("cmbColour").Value IsNot Nothing
																				If flag36 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
																				Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Dim flag37 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells("cmbPurchaseTaxType").Value, "Inclusive", False)
																				Dim num As Double
																				If flag37 Then
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)), 2)), "0.00"))
																				Else
																					num = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)), 2)), "0.00"))
																				End If
																				Me.cmd.Parameters.AddWithValue("@d14", num)
																				Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)), 2)), "0.00"))
																				Dim flag38 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag38 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Dim flag39 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag39 Then
																					Me.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d17", "")
																				End If
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text8 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "    Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
																				Me.cmd = New SqlCommand(text8)
																				Me.cmd.Connection = Me.con
																				Me.cmd.Prepare()
																				Me.Generate_GiftQR(Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))))
																				Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock").Value)))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(29).Value))
																				Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtWSP").Value)))
																				Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value)))
																				Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																				Dim flag40 As Boolean = dataGridViewRow.Cells("txtBatch").Value IsNot Nothing
																				If flag40 Then
																					Me.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtBatch").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d7", "")
																				End If
																				Dim flag41 As Boolean = dataGridViewRow.Cells("MfgDate").Value IsNot Nothing
																				If flag41 Then
																					Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("MfgDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d8", "")
																				End If
																				Dim flag42 As Boolean = dataGridViewRow.Cells("ExpDate").Value IsNot Nothing
																				If flag42 Then
																					Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("ExpDate").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d9", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d10", "")
																				Me.cmd.Parameters.AddWithValue("@d11", "")
																				Me.cmd.Parameters.AddWithValue("@d12", "")
																				Me.cmd.Parameters.AddWithValue("@d13", "")
																				Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
																				Dim flag43 As Boolean = dataGridViewRow.Cells("txtIMEI1").Value IsNot Nothing
																				If flag43 Then
																					Me.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI1").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d15", "")
																				End If
																				Dim flag44 As Boolean = dataGridViewRow.Cells("txtIMEI2").Value IsNot Nothing
																				If flag44 Then
																					Me.cmd.Parameters.AddWithValue("@d16", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtIMEI2").Value))
																				Else
																					Me.cmd.Parameters.AddWithValue("@d16", "")
																				End If
																				Me.cmd.Parameters.AddWithValue("@d17", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																				Me.cmd.Parameters.AddWithValue("@d18", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(30).Value)))
																				Dim memoryStream2 As MemoryStream = New MemoryStream()
																				Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
																				bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
																				Dim buffer2 As Byte() = memoryStream2.GetBuffer()
																				Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
																				sqlParameter2.Value = buffer2
																				Me.cmd.Parameters.AddWithValue("@d20", 0.0)
																				Me.cmd.Parameters.Add(sqlParameter2)
																				Me.cmd.ExecuteNonQuery()
																				Me.cmd.Parameters.Clear()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text9)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(20).Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				Me.con = New SqlConnection(ModCS.cs)
																				Me.con.Open()
																				Dim text10 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
																				Me.cmd = New SqlCommand(text10)
																				Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
																				Me.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(21).Value))
																				Me.cmd.Connection = Me.con
																				Me.cmd.ExecuteReader()
																				Me.con.Close()
																				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
																				Me.fillProductID()
																				Me.con.Close()
																				Me.auto()
																				Me.GenerateBarcode()
																				Me.Getdata()
																				Me.strPcode = ""
																				Me.GelButtonNewRecord.Focus()
																			Catch ex As Exception
																				MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
																			Finally
																				Me.con.Close()
																			End Try
																			Me.DataforNP()
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

		' Token: 0x060016AD RID: 5805 RVA: 0x000F4C04 File Offset: 0x000F2E04
		Public Sub fillProductID()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.adp = New SqlDataAdapter()
				Me.adp.SelectCommand = New SqlCommand("SELECT RTRIM(PID) FROM Product order by PID ASC", Me.con)
				Me.ds = New DataSet("ds")
				Me.adp.Fill(Me.ds)
				Me.dtable = Me.ds.Tables(0)
				Me.cmbNP.Items.Clear()
				Try
					For Each obj As Object In Me.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbNP.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060016AE RID: 5806 RVA: 0x000F4D40 File Offset: 0x000F2F40
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060016AF RID: 5807 RVA: 0x000F4DC4 File Offset: 0x000F2FC4
		Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
			Dim flag As Boolean = e.RowIndex = Me.DataGridView1.NewRowIndex
			If flag Then
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(Me.DataGridView1.Rows(e.RowIndex).Cells(0).Value)
				Dim dataGridViewCell As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(0)
				Dim dataGridViewCell2 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
				Dim dataGridViewCell3 As DataGridViewCell = Me.DataGridView1.Rows(e.RowIndex).Cells(29)
				dataGridViewCell3.Value = Me.txtBarcodeTempStock.Text
				dataGridViewCell.Value = Conversion.Val(Me.txtID.Text)
				Dim flag2 As Boolean = Operators.CompareString(Me.strPcode, Me.txtProductCode.Text, False) <> 0
				If flag2 Then
					Me.strPcode = Me.txtProductCode.Text
					dataGridViewCell2.Value = Me.strPcode
				End If
			End If
		End Sub

		' Token: 0x060016B0 RID: 5808 RVA: 0x000F4EF4 File Offset: 0x000F30F4
		Public Sub auto()
			Try
				Dim text As String = Me.GenerateID()
				Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells(0).Value = text
				Me.id = Conversions.ToShort(text)
				Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells(5).Value = "P-" + text
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016B1 RID: 5809 RVA: 0x000F4FBC File Offset: 0x000F31BC
		Private Function GenerateID() As String
			Me.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				Me.con.Open()
				Me.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = Me.rdr.HasRows
				If hasRows Then
					Me.rdr.Read()
					text = Conversions.ToString(Me.rdr("PID"))
				End If
				Me.rdr.Close()
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
				Dim flag4 As Boolean = Me.con.State = ConnectionState.Open
				If flag4 Then
					Me.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060016B2 RID: 5810 RVA: 0x00012199 File Offset: 0x00010399
		Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
			e.ThrowException = False
		End Sub

		' Token: 0x060016B3 RID: 5811 RVA: 0x000F5140 File Offset: 0x000F3340
		Private Sub frmProductRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
			Dim flag3 As Boolean = e.KeyCode = Keys.F1
			If flag3 Then
				e.Handled = True
				Me.btnShowAll.PerformClick()
			End If
		End Sub

		' Token: 0x060016B4 RID: 5812 RVA: 0x000121A4 File Offset: 0x000103A4
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060016B5 RID: 5813 RVA: 0x000121C0 File Offset: 0x000103C0
		Private Sub btnReset_Click_1(sender As Object, e As EventArgs)
			Me.Reset()
			Me.strPcode = ""
		End Sub

		' Token: 0x060016B6 RID: 5814 RVA: 0x000F51B0 File Offset: 0x000F33B0
		Private Sub btnExportExcel_Click_1(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Dim num As Integer = Me.DataGridView1.Columns.Count - 8
					For i As Integer = 0 To num
						Dim dataGridViewColumn As DataGridViewColumn = Me.DataGridView1.Columns(i)
						dataTable.Columns.Add(dataGridViewColumn.Name)
					Next
					Dim num2 As Integer = 0
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = CDbl(num2) >= Conversion.Val(Me.txtTopResult.Text)
							If flag2 Then
								Exit For
							End If
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj2 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj2, DataGridViewCell)
									Dim flag3 As Boolean = dataGridViewCell.ColumnIndex < 49
									If flag3 Then
										dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
							num2 += 1
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag4 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag4 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016B7 RID: 5815 RVA: 0x000F5474 File Offset: 0x000F3674
		Private Sub btnShowAll_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes
			If flag Then
				Me.GetDataAll()
				Me.DataGridView1.Focus()
			End If
			Me.strPcode = ""
		End Sub

		' Token: 0x060016B8 RID: 5816 RVA: 0x000F54BC File Offset: 0x000F36BC
		Public Sub GetDataAll()
			Try
				Me.DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.DataGridView1.RowHeadersVisible = False
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Me.cmd = New SqlCommand("Select PID,SubCategoryID,temp_Stock.Variant_id,OpeningStock," & vbCrLf & "    (Product.MRP),RTRIM(ProductCode),RTRIM(Productname),RTRIM(CategoryName) + ', ' + RTRIM(SubCategoryName)," & vbCrLf & "    RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description,CostPrice,Discount," & vbCrLf & "    (CGST+SGST) as GST,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit)," & vbCrLf & "    RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty," & vbCrLf & "    RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate)," & vbCrLf & "    RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),temp_Stock.IMEI1,temp_Stock.IMEI2," & vbCrLf & "    RTRIM(Product.Kitchen),Photo from Category,SubCategory,Product," & vbCrLf & "    Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and " & vbCrLf & "    Temp_Stock.ProductID=Product.PID and Product.PID=Product_Join.ProductID order by PID desc", Me.con)
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While Me.rdr.Read()
					Dim num As Integer = Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41) })
					Me.DataGridView1.Rows(num).Cells(43).Value = "Update"
				End While
				Me.rdr.Close()
				Me.con.Close()
				Me.DataGridView1.ClearSelection()
				Dim flag As Boolean = Me.DataGridView1.RowCount > 0
				If flag Then
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(6)
						Me.DataGridView1.ClearSelection()
						Me.DataGridView1.BeginEdit(True)
					End Sub))
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016B9 RID: 5817 RVA: 0x000F58F4 File Offset: 0x000F3AF4
		Private Sub ComboBox_Enter(sender As Object, e As EventArgs)
			Dim comboBox As ComboBox = CType(sender, ComboBox)
			comboBox.DroppedDown = True
		End Sub

		' Token: 0x060016BA RID: 5818 RVA: 0x000121D5 File Offset: 0x000103D5
		Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016BB RID: 5819 RVA: 0x000121E4 File Offset: 0x000103E4
		Private Sub GelButtonNewRecord_Click(sender As Object, e As EventArgs)
			Me.AddNewRow()
		End Sub

		' Token: 0x060016BC RID: 5820 RVA: 0x000121EE File Offset: 0x000103EE
		Private Sub btnProductSeting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductSeting.ShowDialog()
			MyProject.Forms.frmProductSeting.Dispose()
			Me.SetupDataGridViewColumns()
		End Sub

		' Token: 0x060016BD RID: 5821 RVA: 0x000F5914 File Offset: 0x000F3B14
		Private Sub btnBulkImageUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = (Me.DataGridView1.Columns.Count = 0) Or (Me.DataGridView1.Rows.Count = 0)
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim num As Integer = 0
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						Dim flag2 As Boolean = Conversions.ToBoolean(Operators.AndObject(dataGridViewRow.Cells(54).Value IsNot Nothing, Operators.CompareObjectEqual(dataGridViewRow.Cells(54).Value, True, False)))
						If flag2 Then
							num += 1
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim flag3 As Boolean = num <= 0
				If flag3 Then
					MessageBox.Show("Please select item list", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Me.getImage()
				End If
			End If
		End Sub

		' Token: 0x060016BE RID: 5822 RVA: 0x000F5A34 File Offset: 0x000F3C34
		Public Async Sub getImage()
			Try
				Dim flag As Boolean = ModFunc.CheckForInternetConnection()
				If flag Then
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim isSelected As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(row.Cells(54).Value))
							Dim flag2 As Boolean = isSelected
							If flag2 Then
								Dim result As List(Of WebImage) = Await QImage.Query(row.Cells(2).Value.ToString(), 1)
								Me.Picture.Image = result(0).Image
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim cb As String = "delete from Product_Join where ProductID=@d1"
								Me.cmd = New SqlCommand(cb)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(row.Cells(0).Value.ToString()))
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim ck As String = "insert into Product_Join(ProductID,Photo) VALUES (" + row.Cells(0).Value.ToString() + ",@d2)"
								Me.cmd = New SqlCommand(ck)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Dim ms As MemoryStream = New MemoryStream()
								Dim img As Image = Me.Picture.Image
								Dim bmpImage As Bitmap = New Bitmap(img)
								bmpImage.Save(ms, ImageFormat.Jpeg)
								Dim data As Byte() = ms.GetBuffer()
								Dim p As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
								p.Value = data
								Me.cmd.Parameters.Add(p)
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#C9E639")
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.Rows.Clear()
					Me.Getdata()
					Me.DataGridView1.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
					Me.DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
				Else
					MessageBox.Show("Internet Connction not found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End Sub

		' Token: 0x060016BF RID: 5823 RVA: 0x000F5A70 File Offset: 0x000F3C70
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox1.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(42).Value = True
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox1.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(42).Value = False
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x060016C0 RID: 5824 RVA: 0x000F5B80 File Offset: 0x000F3D80
		Private Sub SetupDataGridViewColumns()
			Me.Gridmenusetting()
			Dim num As Integer = 0
			Do
				Me.DataGridView1.Columns(num).Frozen = True
				num += 1
			Loop While num <= 4
			Me.DataGridView1.ScrollBars = ScrollBars.Both
		End Sub

		' Token: 0x060016C1 RID: 5825 RVA: 0x000F5BC4 File Offset: 0x000F3DC4
		Private Sub Gridmenusetting()
			Try
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				sqlDataAdapter.SelectCommand = New SqlCommand("SELECT menu_name, is_active FROM product_menu_setting", Me.con)
				Dim dataSet As DataSet = New DataSet("ds1")
				sqlDataAdapter.Fill(dataSet, "menu_setting")
				Dim dataTable As DataTable = dataSet.Tables("menu_setting")
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("menu_name").ToString()
						Dim num As Short = Conversions.ToShort(dataRow("is_active").ToString())
						Try
							For Each obj2 As Object In Me.DataGridView1.Columns
								Dim dataGridViewColumn As DataGridViewColumn = CType(obj2, DataGridViewColumn)
								Dim flag As Boolean = Operators.CompareString(dataGridViewColumn.Name, text, False) = 0
								If flag Then
									Dim flag2 As Boolean = num = 0S
									If flag2 Then
										dataGridViewColumn.Visible = False
									Else
										dataGridViewColumn.Visible = True
									End If
									Exit For
								End If
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
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016C2 RID: 5826 RVA: 0x000F5DA0 File Offset: 0x000F3FA0
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Dim text As String = Conversions.ToString(Me.dt.Rows(0)("Productname"))
			Dim text2 As String = Conversions.ToString(Me.dt.Rows(0)("CategoryName"))
			Dim flag As Boolean = Me.dt.Rows.Count > 0
			If flag Then
				Try
					Dim num As Integer = Me.DataGridView2.Rows.Count - 1
					For i As Integer = 1 To num
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow

							If Not isNewRow Then
								Me.txtID.Text = Me.GenerateID()
								Me.txtProductCode.Text = "P-" + Me.GenerateID()
								Me.BCodeDisplay()
								Dim text3 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateID1()))
								Me.txtBarcodeTempStock.Text = Me.txtBar.Text + text3
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text4 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "            Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
								Me.cmd = New SqlCommand(text4)
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(0))
								Me.cmd.Parameters.AddWithValue("@d1", Me.txtProductCode.Text)
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)(6).ToString())
								Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.dt.Rows(0)(1).ToString()))
								Dim flag2 As Boolean = Me.dt.Rows(0)("Description").ToString() <> Nothing
								If flag2 Then
									Me.cmd.Parameters.AddWithValue("@d4", Me.dt.Rows(0)("Description").ToString())
								Else
									Me.cmd.Parameters.AddWithValue("@d4", Me.dt.Rows(0)("Productname").ToString())
								End If
								Dim flag3 As Boolean = dataGridViewRow.Cells("CostPrice").Value IsNot Nothing
								If flag3 Then
									Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d5", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.dt.Rows(0)("Discount").ToString()))
								Me.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.dt.Rows(0)("CGST").ToString()))
								Me.cmd.Parameters.AddWithValue("@d11", Me.txtBarcodeTempStock.Text)
								Me.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("PurchaseUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("SalesUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Me.dt.Rows(0)("SGST").ToString()))
								Me.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("HSNCode").ToString())
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("PartNo").ToString())
								Me.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("CESS").ToString())
								Me.cmd.Parameters.AddWithValue("@d18", Me.dt.Rows(0)("SalesAltUnit").ToString())
								Me.cmd.Parameters.AddWithValue("@d19", Conversion.Val(Me.dt.Rows(0)(20).ToString()))
								Me.cmd.Parameters.AddWithValue("@d20", Conversion.Val(Me.dt.Rows(0)("MinStock").ToString()))
								Me.cmd.Parameters.AddWithValue("@d22", "Yes")
								Me.cmd.Parameters.AddWithValue("@d23", Me.dt.Rows(0)("STax").ToString())
								Me.cmd.Parameters.AddWithValue("@d24", Me.dt.Rows(0)("PTax").ToString())
								Me.cmd.Parameters.AddWithValue("@d25", Me.dt.Rows(0)("GDown").ToString())
								Me.cmd.Parameters.AddWithValue("@d26", Me.dt.Rows(0)("Rack").ToString())
								Dim flag4 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag4 Then
									Me.cmd.Parameters.AddWithValue("@d27", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d27", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d28", Me.dt.Rows(0)("SPrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d29", Me.dt.Rows(0)("ReorderPoint").ToString())
								Dim flag5 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag5 Then
									Me.cmd.Parameters.AddWithValue("@d30", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d30", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
								Me.cmd.Parameters.AddWithValue("@d32", Me.dt.Rows(0)("DefQty").ToString())
								Me.cmd.Parameters.AddWithValue("@d33", "")
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteNonQuery()
								Me.con.Close()
								Me.con.Open()
								Dim text5 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID.Text + ",@d2)"
								Me.cmd = New SqlCommand(text5)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Try
									For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow2 As DataGridViewRow = CType(obj, DataGridViewRow)
										Dim isNewRow2 As Boolean = dataGridViewRow2.IsNewRow
										If isNewRow2 Then
											Dim memoryStream As MemoryStream = New MemoryStream()
											Dim image As Image = CType(dataGridViewRow2.Cells("Photo").Value, Image)
											Dim bitmap As Bitmap = New Bitmap(image)
											bitmap.Save(memoryStream, ImageFormat.Jpeg)
											Dim buffer As Byte() = memoryStream.GetBuffer()
											Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
											sqlParameter.Value = buffer
											Me.cmd.Parameters.Add(sqlParameter)
											Me.cmd.ExecuteNonQuery()
											Me.cmd.Parameters.Clear()
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								Me.con.Close()
								Me.con.Open()
								Dim text6 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
								Me.cmd = New SqlCommand(text6)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag6 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag6 Then
									Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								Dim flag7 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag7 Then
									Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d2", 0)
								End If
								Dim flag8 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag8 Then
									Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								Dim flag9 As Boolean = Operators.ConditionalCompareObjectGreater(Me.dt.Rows(0)("WPrice"), 0, False)
								If flag9 Then
									Me.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(RuntimeHelpers.GetObjectValue(Me.dt.Rows(0)("WPrice"))))
								Else
									Me.cmd.Parameters.AddWithValue("@d4", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d5", Me.dt.Rows(0)("Batch").ToString())
								Me.cmd.Parameters.AddWithValue("@d6", Me.dt.Rows(0)("Mfgdate").ToString())
								Me.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Expdate").ToString())
								Dim flag10 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag10 Then
									Me.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d8", "")
								End If
								Dim flag11 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag11 Then
									Me.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d9", "")
								End If
								Me.cmd.Parameters.AddWithValue("@d10", Me.txtBarcodeTempStock.Text)
								Me.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
								Me.cmd.Parameters.AddWithValue("@d12", "")
								Me.cmd.Parameters.AddWithValue("@d13", "")
								Dim flag12 As Boolean = Operators.CompareString(Me.dt.Rows(0)("PTax").ToString(), "Inclusive", False) = 0
								Dim num2 As Double
								If flag12 Then
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								Else
									num2 = Conversions.ToDouble(String.Format(Conversions.ToString(Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("CostPrice").Value)), 2)), "0.00"))
								End If
								Me.cmd.Parameters.AddWithValue("@d14", num2)
								Me.cmd.Parameters.AddWithValue("@d15", String.Format(Conversions.ToString(Math.Round(num2 * Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)), 2)), "0.00"))
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI1").ToString().Trim())
								Me.cmd.Parameters.AddWithValue("@d17", Me.dt.Rows(0)("IMEI2").ToString().Trim())
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text7 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "            Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
								Me.cmd = New SqlCommand(text7)
								Me.cmd.Connection = Me.con
								Me.cmd.Prepare()
								Me.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID.Text))
								Dim flag13 As Boolean = dataGridViewRow.Cells("txtOpeningStock2").Value IsNot Nothing
								If flag13 Then
									Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtOpeningStock2").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d1", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d2", Me.txtBarcodeTempStock.Text)
								Dim flag14 As Boolean = dataGridViewRow.Cells("txtRSP1").Value IsNot Nothing
								If flag14 Then
									Me.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtRSP1").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d3", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d4", Convert.ToDecimal(Me.dt.Rows(0)("WPrice").ToString()))
								Me.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.dt.Rows(0)("StLimit").ToString()))
								Dim flag15 As Boolean = dataGridViewRow.Cells("txtMRP").Value IsNot Nothing
								If flag15 Then
									Me.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("txtMRP").Value)))
								Else
									Me.cmd.Parameters.AddWithValue("@d6", 0)
								End If
								Me.cmd.Parameters.AddWithValue("@d7", Me.dt.Rows(0)("Batch").ToString())
								Me.cmd.Parameters.AddWithValue("@d8", Me.dt.Rows(0)("MfgDate").ToString())
								Me.cmd.Parameters.AddWithValue("@d9", Me.dt.Rows(0)("ExpDate").ToString())
								Dim flag16 As Boolean = dataGridViewRow.Cells("cmbSize2").Value IsNot Nothing
								If flag16 Then
									Me.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbSize2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d10", "")
								End If
								Dim flag17 As Boolean = dataGridViewRow.Cells("cmbColour2").Value IsNot Nothing
								If flag17 Then
									Me.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells("cmbColour2").Value))
								Else
									Me.cmd.Parameters.AddWithValue("@d11", "")
								End If
								Me.cmd.Parameters.AddWithValue("@d12", Me.dt.Rows(0)("SalePrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d13", Me.dt.Rows(0)("WSalePrice").ToString())
								Me.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
								Me.cmd.Parameters.AddWithValue("@d15", Me.dt.Rows(0)("IMEI1").ToString())
								Me.cmd.Parameters.AddWithValue("@d16", Me.dt.Rows(0)("IMEI2").ToString())
								Me.cmd.Parameters.AddWithValue("@d17", Convert.ToDecimal(Me.dt.Rows(0)("PPrice").ToString()))
								Me.cmd.Parameters.AddWithValue("@d18", Convert.ToDecimal(Me.dt.Rows(0)("EPPrice").ToString()))
								Me.Generate_GiftQR(Me.txtBarcodeTempStock.Text)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								Me.cmd.Parameters.AddWithValue("@d20", 0.0)
								Me.cmd.Parameters.AddWithValue("@d21", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("PID2").Value)))
								Me.cmd.Parameters.Add(sqlParameter2)
								Me.cmd.ExecuteNonQuery()
								Me.cmd.Parameters.Clear()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text8 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								Me.cmd = New SqlCommand(text8)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesUnit").ToString())
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
								Me.con = New SqlConnection(ModCS.cs)
								Me.con.Open()
								Dim text9 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
								Me.cmd = New SqlCommand(text9)
								Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								Me.cmd.Parameters.AddWithValue("@d2", Me.dt.Rows(0)("SalesAltUnit").ToString())
								Me.cmd.Connection = Me.con
								Me.cmd.ExecuteReader()
								Me.con.Close()
							End If

					Next
					Me.con = New SqlConnection(ModCS.cs)
					Me.con.Open()
					Dim text10 As String = "Update Temp_Stock set Qty=@d1,Variant_id=@d2 where ProductID=@d2"
					Me.cmd = New SqlCommand(text10)
					Me.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("txtOpeningStock2").Value)))
					Me.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(Me.DataGridView2.Rows(0).Cells("PID2").Value)))
					Me.cmd.Connection = Me.con
					Me.cmd.ExecuteReader()
					Me.con.Close()
				Catch ex As Exception
					MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
				Finally
					Me.con.Close()
				End Try
				MessageBox.Show("Successfully Saved", "Product Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Me.pnlVariant.Visible = False
				Me.DataGridView2.Visible = False
				Me.Getdata()
			End If
		End Sub

		' Token: 0x060016C3 RID: 5827 RVA: 0x000F7774 File Offset: 0x000F5974
		Private Sub gridtodatatable()
			Dim dataTable As DataTable = New DataTable()
			Try
				For Each obj As Object In Me.DataGridView2.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim type As Type = If(dataGridViewColumn.ValueType, GetType(String))
					dataTable.Columns.Add(dataGridViewColumn.HeaderText, type)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim num As Integer = Me.DataGridView2.Rows.Count - 1
			For i As Integer = 1 To num
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
				Dim flag As Boolean = Not dataGridViewRow.IsNewRow
				If flag Then
					Dim dataRow As DataRow = dataTable.NewRow()
					Dim num2 As Integer = Me.DataGridView2.Columns.Count - 1
					For j As Integer = 0 To num2
						dataRow(j) = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(j).Value)
					Next
					dataTable.Rows.Add(dataRow)
				End If
			Next
		End Sub

		' Token: 0x060016C4 RID: 5828 RVA: 0x000F78B4 File Offset: 0x000F5AB4
		Private Sub CalculateColumnSum()
			Dim flag As Boolean = Me.dt.Rows.Count = 1
			If flag Then
				Dim num As Decimal = 0D
				Dim text As String = "txtOpeningStock2"
				Dim num2 As Integer = Me.DataGridView2.Rows.Count - 1
				For i As Integer = 1 To num2
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView2.Rows(i)
					Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
					If flag2 Then
						Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(text).Value)
						Dim num3 As Decimal = 0D
						Dim flag3 As Boolean = Decimal.TryParse(objectValue.ToString(), num3)
						If flag3 Then
							num = Decimal.Add(num, num3)
							Dim num4 As Decimal = Decimal.Subtract(Me.initialQty, num)
							Me.DataGridView2.Rows(0).Cells(text).Value = num4
						End If
					End If
				Next
			End If
		End Sub

		' Token: 0x060016C5 RID: 5829 RVA: 0x00012218 File Offset: 0x00010418
		Private Sub GelButton2_Click_1(sender As Object, e As EventArgs)
			MyProject.Forms.frmBarcodeLabelPrinting.txtVariant.Text = Me.Label14.Text.ToString()
			MyProject.Forms.frmBarcodeLabelPrinting.ShowDialog()
		End Sub

		' Token: 0x060016C6 RID: 5830 RVA: 0x000F79B4 File Offset: 0x000F5BB4
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCategory.Label2.Text = "setting"
			MyProject.Forms.frmCategory.Reset()
			MyBase.Dispose()
			MyProject.Forms.frmCategory.ShowDialog()
		End Sub

		' Token: 0x060016C7 RID: 5831 RVA: 0x000F7A24 File Offset: 0x000F5C24
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSubCategory.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmSubCategory.Label3.Text = "setting"
			MyProject.Forms.frmSubCategory.Reset()
			MyBase.Dispose()
			MyProject.Forms.frmSubCategory.ShowDialog()
		End Sub

		' Token: 0x060016C8 RID: 5832 RVA: 0x00012250 File Offset: 0x00010450
		Private Sub Button16_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmProductBulkUpdate.ShowDialog()
			MyProject.Forms.frmProductBulkUpdate.Dispose()
		End Sub

		' Token: 0x060016C9 RID: 5833 RVA: 0x000F7A94 File Offset: 0x000F5C94
		Private Sub btnWebcam_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				MyProject.Forms.frmCamera.Label2.Text = "frmProductRec"
				Dim frmCamera As frmCamera = New frmCamera()
				frmCamera.ShowDialog()
				Dim flag2 As Boolean = ModCommonClasses.TempFileNames2.Length > 0
				If flag2 Then
					Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
					Me.Photoname = ModCommonClasses.TempFileNames2
					Me.IsImageChanged = True
					Me.ImageExtrator()
				End If
			Else
				MessageBox.Show("No internet connection.")
			End If
		End Sub

		' Token: 0x060016CA RID: 5834 RVA: 0x000F7B24 File Offset: 0x000F5D24
		Public Async Sub ImageExtrator()
			Dim flag As Boolean = File.Exists(ModCommonClasses.TempFileNames2)
			If flag Then
				Me.DataGridView1.[ReadOnly] = False
				Dim newRowIndex As Integer = Me.DataGridView1.Rows.Count - 1
				Dim columnIndexToFocus As Integer = 2
				Dim ocrResult As String = Await Me.PerformOCR_(ModCommonClasses.TempFileNames2)
				Me.DataGridView1.Rows(newRowIndex).Cells(columnIndexToFocus).Value = ocrResult
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(newRowIndex).Cells(columnIndexToFocus)
				Try
					For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
						Dim row As DataGridViewRow = CType(obj, DataGridViewRow)
						If row.IsNewRow Then
							Me.DataGridView1.Rows(row.Index).Cells(2).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(2).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(3).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(3).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(5).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(5).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(30).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(30).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(12).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(12).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(21).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(21).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(19).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(19).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(20).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(20).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(21).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(21).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(20).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(20).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(27).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(27).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(30).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(30).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(31).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(31).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(32).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(32).Style.ForeColor = Color.White
							Me.DataGridView1.Rows(row.Index).Cells(29).Style.BackColor = Color.Red
							Me.DataGridView1.Rows(row.Index).Cells(29).Style.ForeColor = Color.White
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.DataGridView1.BeginEdit(True)
				Me.DataGridView1.Rows(newRowIndex).Cells(8).Value = 0
				Me.DataGridView1.Rows(newRowIndex).Cells(13).Value = 0.0
				Me.DataGridView1.Rows(newRowIndex).Cells(16).Value = "0.00"
				Me.DataGridView1.Rows(newRowIndex).Cells(21).Value = "0.00"
				Me.DataGridView1.Rows(newRowIndex).Cells(20).Value = 1
				Me.DataGridView1.Rows(newRowIndex).Cells(27).Value = 1
			Else
				MessageBox.Show("Captured image not found.")
			End If
		End Sub

		' Token: 0x060016CB RID: 5835 RVA: 0x000F7B60 File Offset: 0x000F5D60
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

		' Token: 0x060016CC RID: 5836 RVA: 0x000F7BF4 File Offset: 0x000F5DF4
		Public Async Function PerformOCR_(imagePath As String) As Task(Of String)
			Dim text As String
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
					text = ""
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim jsonRequest As String = "{" & vbCrLf & "                ""model"": ""gpt-4o-mini""," & vbCrLf & "                ""messages"": [" & vbCrLf & "                    {""role"": ""system"", ""content"": ""Identify main object of image and provide product name only (name with singular noun, not plural noun).""}," & vbCrLf & "                    {""role"": ""user"", ""content"": [" & vbCrLf & "                        {""type"": ""image_url"", ""image_url"": {""url"": ""data:image/jpeg;base64," + base64Image + """}}" & vbCrLf & "                    ]}" & vbCrLf & "                ]" & vbCrLf & "            }"
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim response As HttpResponseMessage = Await client.PostAsync(Me.url, New StringContent(jsonRequest, Encoding.UTF8, "application/json"))
						Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
						If response.StatusCode <> HttpStatusCode.OK Then
							MessageBox.Show("API Error: " + jsonResponse)
							text = ""
						Else
							Dim result As JObject = JObject.Parse(jsonResponse)
							If result("choices") Is Nothing OrElse result("choices").Count() = 0 Then
								MessageBox.Show("Error: No response from GPT-4 Vision.")
								text = ""
							Else
								Dim extractedText As String = result("choices")(0)("message")("content").ToString()
								text = extractedText
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Error: " + ex.Message)
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x060016CD RID: 5837 RVA: 0x00012273 File Offset: 0x00010473
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "frmProductRec"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x060016CE RID: 5838 RVA: 0x000F7C40 File Offset: 0x000F5E40
		Public Sub UpdateCatAndSubCategoryName(currentRow As Integer, currentColumn As Integer, subcategoryId As Integer, selectedCat As String, selectedSubCat As String)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = ""
			Dim text As String = selectedSubCat + "," + selectedCat
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = text
			Me.DataGridView1.Rows(currentRow).Cells(1).Value = subcategoryId
			Me.DataGridView1.EndEdit()
			Me.DataGridView1.RefreshEdit()
			Me.DataGridView1.Invalidate()
			Dim num As Integer = currentColumn + 1
			While num < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(num).Visible
				num += 1
			End While
			Dim flag As Boolean = num < Me.DataGridView1.Columns.Count
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(num)
			End If
			Me.DataGridView1.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.DataGridView1.Focus()
				Me.DataGridView1.BeginEdit(True)
				Me.DataGridView1.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x060016CF RID: 5839 RVA: 0x000F7D94 File Offset: 0x000F5F94
		Public Sub UpdateGstRate(currentRow As Integer, currentColumn As Integer, taxId As Integer, selectedGstRate As Decimal)
			Me.DataGridView1.EndEdit()
			Me.DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = selectedGstRate.ToString("0.00")
			Me.DataGridView1.RefreshEdit()
			Me.DataGridView1.Invalidate()
			Dim text As String = Decimal.Divide(selectedGstRate, 2D).ToString("0.00")
			Me.DataGridView1.Rows(currentRow).Cells(14).Value = text
			Me.DataGridView1.Rows(currentRow).Cells(15).Value = text
			Dim num As Integer = 16
			While num < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(num).Visible
				num += 1
			End While
			Dim flag As Boolean = num < Me.DataGridView1.Columns.Count
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(num)
			End If
			Me.DataGridView1.Focus()
			Dim flag2 As Boolean = num < Me.DataGridView1.Columns.Count
			If flag2 Then
				Me.DataGridView1.BeginEdit(True)
			End If
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016D0 RID: 5840 RVA: 0x000F7F2C File Offset: 0x000F612C
		Public Sub UpdateUnit(currentRow As Integer, currentColumn As Integer, selectedUnit As String)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = selectedUnit
			Dim num As Integer = 21
			Dim flag As Boolean = currentColumn = 17 OrElse currentColumn = 18
			If flag Then
				Me.DataGridView1.Rows(currentRow).Cells(18).Value = selectedUnit
				Me.DataGridView1.Rows(currentRow).Cells(19).Value = selectedUnit
				Me.DataGridView1.Rows(currentRow).Cells(20).Value = "1.00"
				num = 21
			End If
			While num < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(num).Visible
				num += 1
			End While
			Dim flag2 As Boolean = num < Me.DataGridView1.Columns.Count
			If flag2 Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(num)
			End If
			Me.DataGridView1.ClearSelection()
			Me.DataGridView1.BeginEdit(True)
		End Sub

		' Token: 0x060016D1 RID: 5841 RVA: 0x000F807C File Offset: 0x000F627C
		Friend Async Sub UpdateYesNo(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			While nextCol < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(nextCol).Visible
				nextCol += 1
			End While
			Dim flag As Boolean = nextCol < Me.DataGridView1.Columns.Count
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(nextCol)
			End If
			Me.DataGridView1.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.DataGridView1.BeginEdit(True)
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016D2 RID: 5842 RVA: 0x000F80CC File Offset: 0x000F62CC
		Friend Async Sub UpdateTaxType(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			While nextCol < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(nextCol).Visible
				nextCol += 1
			End While
			Dim flag As Boolean = nextCol < Me.DataGridView1.Columns.Count
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(nextCol)
			End If
			Me.DataGridView1.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.DataGridView1.BeginEdit(True)
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016D3 RID: 5843 RVA: 0x000F811C File Offset: 0x000F631C
		Friend Async Sub UpdateBoxBag(currentRow As Integer, currentColumn As Integer, selectedType As String)
			Me.DataGridView1.Rows(currentRow).Cells(currentColumn).Value = selectedType
			Dim nextCol As Integer = currentColumn + 1
			While nextCol < Me.DataGridView1.Columns.Count AndAlso Not Me.DataGridView1.Columns(nextCol).Visible
				nextCol += 1
			End While
			Dim flag As Boolean = nextCol < Me.DataGridView1.Columns.Count
			If flag Then
				Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(currentRow).Cells(nextCol)
			End If
			Me.DataGridView1.Focus()
			Application.DoEvents()
			Await Task.Delay(50)
			Me.DataGridView1.BeginEdit(True)
			Me.DataGridView1.ClearSelection()
		End Sub

		' Token: 0x060016D4 RID: 5844 RVA: 0x000F816C File Offset: 0x000F636C
		Private Sub txtTopResult_TextChanged(sender As Object, e As EventArgs)
			' Initial control values must not query SQL before the window loads.
			If Not Me.IsHandleCreated Then Return
			Dim flag As Boolean = Me.DataGridView1.Columns.Count = 0
			If Not flag Then
				Dim flag2 As Boolean = Not Me.txtTopResult.Focused
				If Not flag2 Then
					Dim selectionStart As Integer = Me.txtTopResult.SelectionStart
					Dim flag3 As Boolean = Not String.IsNullOrEmpty(Me.txtTopResult.Text.Trim())
					If flag3 Then
						Me.Getdata()
					End If
					Me.txtTopResult.Focus()
				End If
			End If
		End Sub

		' Token: 0x060016D5 RID: 5845 RVA: 0x000122A7 File Offset: 0x000104A7
		Private Sub cmbSearchCat_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.txtSearchProduct.Text = ""
		End Sub

		' Token: 0x060016D6 RID: 5846 RVA: 0x000F81E4 File Offset: 0x000F63E4
		Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbSearchCat.SelectedIndex <> -1
			If flag Then
				Me.Getdata_bySearch()
			End If
		End Sub

		' Token: 0x060016D7 RID: 5847 RVA: 0x000F8210 File Offset: 0x000F6410
		Public Sub Getdata_bySearch()
			Try
				Dim text As String = Me.txtSearchProduct.Text.Trim()
				Dim selectedIndex As Integer = Me.cmbSearchCat.SelectedIndex
				Me.DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.DataGridView1.RowHeadersVisible = False
				Me.con = New SqlConnection(ModCS.cs)
				Me.con.Open()
				Dim text2 As String = "Select Top " + Me.txtTopResult.Text + " PID,SubCategoryID,temp_Stock.Variant_id,OpeningStock," & vbCrLf & "    (Product.MRP),RTRIM(ProductCode),RTRIM(Productname),RTRIM(CategoryName) + ', ' + RTRIM(SubCategoryName)," & vbCrLf & "    RTRIM(HSNCode),RTRIM(PartNo) as PartNo, RTRIM(Description) As Description,CostPrice,Discount," & vbCrLf & "    (CGST+SGST) as GST,CGST,SGST,CESS, RTRIM(PurchaseUnit),RTRIM(Salesunit)," & vbCrLf & "    RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(MinStock),RTRIM(Product.Status)," & vbCrLf & "    (Product.STax),(Product.PTax),RTRIM(Product.GDown),RTRIM(Product.Rack),(Product.DefQty),Temp_Stock.Qty," & vbCrLf & "    RTRIM(Temp_Stock.Barcode),(Temp_Stock.MRP)," & vbCrLf & "    (Temp_Stock.SPrice),(Temp_Stock.WPrice),RTRIM(Temp_Stock.Batch),(Temp_Stock.Mfgdate),(Temp_Stock.Expdate)," & vbCrLf & "    RTRIM(Temp_Stock.Size)," & vbCrLf & "    RTRIM(Temp_Stock.Colour),temp_Stock.IMEI1,temp_Stock.IMEI2," & vbCrLf & "    RTRIM(Product.Kitchen),Photo from Category,SubCategory,Product," & vbCrLf & "    Temp_Stock,Product_Join where Category.CategoryName=SubCategory.Category and Product.SubCategoryID=SubCategory.ID and " & vbCrLf & "    Temp_Stock.ProductID=Product.PID and Product.PID=Product_Join.ProductID "
				Dim flag As Boolean = selectedIndex = 0
				If flag Then
					text2 += " and RTRIM(Product.Productname) like @search order by PID desc"
				Else
					Dim flag2 As Boolean = selectedIndex = 1
					If flag2 Then
						text2 += " and RTRIM(CategoryName) + ', ' + RTRIM(SubCategoryName) like @search order by PID desc"
					Else
						Dim flag3 As Boolean = selectedIndex = 2
						If flag3 Then
							text2 += " and RTRIM(Temp_Stock.Barcode) like @search order by PID desc"
						Else
							Dim flag4 As Boolean = selectedIndex = 3
							If flag4 Then
								text2 += " and RTRIM(PartNo) like @search order by PID desc"
							End If
						End If
					End If
				End If
				Me.cmd = New SqlCommand(text2, Me.con)
				Me.cmd.CommandTimeout = 0
				Me.cmd.Parameters.AddWithValue("@search", "%" + text + "%")
				Me.rdr = Me.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.DataGridView1.Rows.Clear()
				While Me.rdr.Read()
					Dim num As Integer = Me.DataGridView1.Rows.Add(New Object() { Me.rdr(0), Me.rdr(1), Me.rdr(2), Me.rdr(3), Me.rdr(4), Me.rdr(5), Me.rdr(6), Me.rdr(7), Me.rdr(8), Me.rdr(9), Me.rdr(10), Me.rdr(11), Me.rdr(12), Me.rdr(13), Me.rdr(14), Me.rdr(15), Me.rdr(16), Me.rdr(17), Me.rdr(18), Me.rdr(19), Me.rdr(20), Me.rdr(21), Me.rdr(22), Me.rdr(23), Me.rdr(24), Me.rdr(25), Me.rdr(26), Me.rdr(27), Me.rdr(28), Me.rdr(29), Me.rdr(30), Me.rdr(31), Me.rdr(32), Me.rdr(33), Me.rdr(34), Me.rdr(35), Me.rdr(36), Me.rdr(37), Me.rdr(38), Me.rdr(39), Me.rdr(40), Me.rdr(41) })
					Me.DataGridView1.Rows(num).Cells(43).Value = "Update"
				End While
				Me.rdr.Close()
				Me.con.Close()
				Me.DataGridView1.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060016D8 RID: 5848 RVA: 0x000F86D4 File Offset: 0x000F68D4
		Private Sub AddNewRow()
			For Each row As DataGridViewRow In Me.DataGridView1.Rows
				If row.Cells(0).Value IsNot Nothing AndAlso Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(0).Value)) = 0.0 Then
					MessageBox.Show("A new row already exists. Please save it before adding another.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.DataGridView1.ClearSelection()
					Dim r As DataGridViewRow = row
					MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
						Me.DataGridView1.Focus()
						Me.DataGridView1.CurrentCell = r.Cells(6)
						Me.DataGridView1.BeginEdit(True)
						Me.DataGridView1.ClearSelection()
					End Sub))
					Return
				End If
			Next
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text As String = "select RTRIM(unit) from UnitMaster WHERE ISDEFAULT = 'Yes'"
			Me.cmd = New SqlCommand(text)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag2 As Boolean = Me.rdr.Read()
			If flag2 Then
				Me.unit = Me.rdr(0).ToString()
				Dim flag3 As Boolean = Me.rdr IsNot Nothing
				If flag3 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text2 As String = "select Rate from TaxCat WHERE ISDEFAULT = 'Yes'"
			Me.cmd = New SqlCommand(text2)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag4 As Boolean = Me.rdr.Read()
			If flag4 Then
				Me.Rate = Conversions.ToDouble(Me.rdr(0).ToString())
				Dim flag5 As Boolean = Me.rdr IsNot Nothing
				If flag5 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text3 As String = "select stax_type from Defaulttaxtype WHERE id = '1'"
			Me.cmd = New SqlCommand(text3)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag6 As Boolean = Me.rdr.Read()
			If flag6 Then
				Me.stax_type = Me.rdr(0).ToString()
				Dim flag7 As Boolean = Me.rdr IsNot Nothing
				If flag7 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text4 As String = "select Ptax_type from Defaulttaxtype WHERE id = '1'"
			Me.cmd = New SqlCommand(text4)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag8 As Boolean = Me.rdr.Read()
			If flag8 Then
				Me.Ptax_type = Me.rdr(0).ToString()
				Dim flag9 As Boolean = Me.rdr IsNot Nothing
				If flag9 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text5 As String = "select Rate as DRate from tbl_DiscountDefault WHERE id = '1'"
			Me.cmd = New SqlCommand(text5)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag10 As Boolean = Me.rdr.Read()
			If flag10 Then
				Me.DRate = Conversions.ToDouble(Me.rdr(0).ToString())
				Dim flag11 As Boolean = Me.rdr IsNot Nothing
				If flag11 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Me.con = New SqlConnection(ModCS.cs)
			Me.con.Open()
			Dim text6 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
			Me.cmd = New SqlCommand(text6)
			Me.cmd.Connection = Me.con
			Me.rdr = Me.cmd.ExecuteReader()
			Dim flag12 As Boolean = Me.rdr.Read()
			If flag12 Then
				Dim text7 As String = Me.rdr(1).ToString()
				Dim num As Double = Conversions.ToDouble(Me.rdr(2).ToString())
				Dim flag13 As Boolean = Me.rdr IsNot Nothing
				If flag13 Then
					Me.rdr.Close()
					Me.con.Close()
				End If
			End If
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Using sqlCommand As SqlCommand = New SqlCommand("SELECT sc.Id," & vbCrLf & "                    RTRIM(c.CategoryName) As Category," & vbCrLf & "                    RTRIM(sc.SubCategoryName) AS SubCategory" & vbCrLf & "             FROM SubCategory sc" & vbCrLf & "             JOIN Category c ON c.CategoryName = sc.Category" & vbCrLf & "             WHERE sc.IsDefault = 'Yes'", sqlConnection)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						Dim flag14 As Boolean = sqlDataReader.Read()
						If flag14 Then
							Me.defaultSubCategoryId = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlDataReader("Id")))
							Me.defaultCategory = sqlDataReader("Category").ToString()
							Me.defaultSubCategory = sqlDataReader("SubCategory").ToString()
							Me.defaultCatSubText = Me.defaultCategory + ", " + Me.defaultSubCategory
						Else
							MessageBox.Show("No default SubCategory found (IsDefault = Yes).")
						End If
					End Using
				End Using
				sqlConnection.Close()
			End Using
			Me.DataGridView1.ClearSelection()
			Dim num2 As Integer = Me.DataGridView1.Rows.Add()
			Dim newRow As DataGridViewRow = Me.DataGridView1.Rows(num2)
			newRow.Cells(0).Value = 0
			newRow.Cells(1).Value = Me.defaultSubCategoryId
			newRow.Cells(2).Value = 0
			newRow.Cells(3).Value = 0
			newRow.Cells(4).Value = 0
			newRow.Cells(5).Value = ""
			newRow.Cells(6).Value = ""
			newRow.Cells(7).Value = Me.defaultCatSubText
			newRow.Cells(8).Value = ""
			newRow.Cells(9).Value = 0
			newRow.Cells(10).Value = ""
			newRow.Cells(11).Value = "0.00"
			newRow.Cells(12).Value = Me.DRate.ToString("0.00")
			newRow.Cells(13).Value = Me.Rate.ToString("0.00")
			newRow.Cells(14).Value = (Me.Rate / 2.0).ToString("0.00")
			newRow.Cells(15).Value = (Me.Rate / 2.0).ToString("0.00")
			newRow.Cells(16).Value = "0.00"
			newRow.Cells(17).Value = Me.unit
			newRow.Cells(18).Value = Me.unit
			newRow.Cells(19).Value = Me.unit
			newRow.Cells(20).Value = "1.00"
			newRow.Cells(21).Value = "0.00"
			newRow.Cells(22).Value = "Yes"
			newRow.Cells(23).Value = Me.stax_type
			newRow.Cells(24).Value = Me.Ptax_type
			newRow.Cells(25).Value = ""
			newRow.Cells(26).Value = ""
			newRow.Cells(27).Value = "1"
			newRow.Cells(28).Value = "0.00"
			newRow.Cells(29).Value = ""
			newRow.Cells(30).Value = "0.00"
			newRow.Cells(31).Value = "0.00"
			newRow.Cells(32).Value = "0.00"
			newRow.Cells(33).Value = "0.00"
			newRow.Cells(34).Value = ""
			newRow.Cells(35).Value = ""
			newRow.Cells(36).Value = ""
			newRow.Cells(37).Value = ""
			newRow.Cells(38).Value = ""
			newRow.Cells(39).Value = ""
			newRow.Cells(40).Value = ""
			newRow.Cells(41).Value = Nothing
			newRow.Cells(42).Value = False
			newRow.Cells(44).Value = Nothing
			newRow.Cells(44).[ReadOnly] = True
			newRow.Cells(45).Value = ""
			newRow.Cells(46).Value = ""
			newRow.Cells(43).Value = "Save"
			Me.DataGridView1.ClearSelection()
			MyBase.BeginInvoke(New VB_AnonymousDelegate_0(Sub()
				Me.DataGridView1.Focus()
				Me.DataGridView1.CurrentCell = newRow.Cells(6)
				Me.DataGridView1.BeginEdit(True)
				Me.DataGridView1.ClearSelection()
			End Sub))
		End Sub

		' Token: 0x040007F5 RID: 2037
		Public Const COL_PID As Integer = 0

		' Token: 0x040007F6 RID: 2038
		Public Const COL_SubCategoryID As Integer = 1

		' Token: 0x040007F7 RID: 2039
		Public Const COL_VariantID As Integer = 2

		' Token: 0x040007F8 RID: 2040
		Public Const COL_OpeningStockOld As Integer = 3

		' Token: 0x040007F9 RID: 2041
		Public Const COL_MRP_Old As Integer = 4

		' Token: 0x040007FA RID: 2042
		Public Const COL_PCode As Integer = 5

		' Token: 0x040007FB RID: 2043
		Public Const COL_ProductName As Integer = 6

		' Token: 0x040007FC RID: 2044
		Public Const COL_CatSubCategory As Integer = 7

		' Token: 0x040007FD RID: 2045
		Public Const COL_HSNCode As Integer = 8

		' Token: 0x040007FE RID: 2046
		Public Const COL_PartGroup As Integer = 9

		' Token: 0x040007FF RID: 2047
		Public Const COL_Description As Integer = 10

		' Token: 0x04000800 RID: 2048
		Public Const COL_PurchasePrice As Integer = 11

		' Token: 0x04000801 RID: 2049
		Public Const COL_Discount As Integer = 12

		' Token: 0x04000802 RID: 2050
		Public Const COL_GST As Integer = 13

		' Token: 0x04000803 RID: 2051
		Public Const COL_CGST As Integer = 14

		' Token: 0x04000804 RID: 2052
		Public Const COL_SGST_UTGST As Integer = 15

		' Token: 0x04000805 RID: 2053
		Public Const COL_CESS As Integer = 16

		' Token: 0x04000806 RID: 2054
		Public Const COL_PurchaseMainUnit As Integer = 17

		' Token: 0x04000807 RID: 2055
		Public Const COL_SalesUnit As Integer = 18

		' Token: 0x04000808 RID: 2056
		Public Const COL_AlterUnit As Integer = 19

		' Token: 0x04000809 RID: 2057
		Public Const COL_Conv As Integer = 20

		' Token: 0x0400080A RID: 2058
		Public Const COL_MinStock As Integer = 21

		' Token: 0x0400080B RID: 2059
		Public Const COL_Active As Integer = 22

		' Token: 0x0400080C RID: 2060
		Public Const COL_SaleTaxType As Integer = 23

		' Token: 0x0400080D RID: 2061
		Public Const COL_PurchaseTaxType As Integer = 24

		' Token: 0x0400080E RID: 2062
		Public Const COL_GDown As Integer = 25

		' Token: 0x0400080F RID: 2063
		Public Const COL_Rack As Integer = 26

		' Token: 0x04000810 RID: 2064
		Public Const COL_DefQty As Integer = 27

		' Token: 0x04000811 RID: 2065
		Public Const COL_OpeningQty As Integer = 28

		' Token: 0x04000812 RID: 2066
		Public Const COL_Barcode As Integer = 29

		' Token: 0x04000813 RID: 2067
		Public Const COL_MRP As Integer = 30

		' Token: 0x04000814 RID: 2068
		Public Const COL_RetailSalePrice As Integer = 31

		' Token: 0x04000815 RID: 2069
		Public Const COL_WholesaleSalePrice As Integer = 32

		' Token: 0x04000816 RID: 2070
		Public Const COL_Batch As Integer = 33

		' Token: 0x04000817 RID: 2071
		Public Const COL_MfgDate As Integer = 34

		' Token: 0x04000818 RID: 2072
		Public Const COL_ExpDate As Integer = 35

		' Token: 0x04000819 RID: 2073
		Public Const COL_Size As Integer = 36

		' Token: 0x0400081A RID: 2074
		Public Const COL_Colour As Integer = 37

		' Token: 0x0400081B RID: 2075
		Public Const COL_IME1 As Integer = 38

		' Token: 0x0400081C RID: 2076
		Public Const COL_IME2 As Integer = 39

		' Token: 0x0400081D RID: 2077
		Public Const COL_Kitchen As Integer = 40

		' Token: 0x0400081E RID: 2078
		Public Const COL_Photo As Integer = 41

		' Token: 0x0400081F RID: 2079
		Public Const COL_MarkUnmark As Integer = 42

		' Token: 0x04000820 RID: 2080
		Public Const COL_Update As Integer = 43

		' Token: 0x04000821 RID: 2081
		Public Const COL_Delete As Integer = 44

		' Token: 0x04000822 RID: 2082
		Public Const COL_Print As Integer = 45

		' Token: 0x04000823 RID: 2083
		Public Const COL_VariantName As Integer = 46

		' Token: 0x04000824 RID: 2084
		Public Const TotalColumnCount As Integer = 47

		' Token: 0x04000825 RID: 2085
		Private shouldHandleSelectedIndexChanged As Boolean

		' Token: 0x04000826 RID: 2086
		Private con As SqlConnection

		' Token: 0x04000827 RID: 2087
		Private cmd As SqlCommand

		' Token: 0x04000828 RID: 2088
		Private rdr As SqlDataReader

		' Token: 0x04000829 RID: 2089
		Private adp As SqlDataAdapter

		' Token: 0x0400082A RID: 2090
		Private ds As DataSet

		' Token: 0x0400082B RID: 2091
		Private dtable As DataTable

		' Token: 0x0400082C RID: 2092
		Private categories As DataTable

		' Token: 0x0400082D RID: 2093
		Private subcategories As DataTable

		' Token: 0x0400082E RID: 2094
		Private items As DataTable

		' Token: 0x0400082F RID: 2095
		Private insertBtn As String

		' Token: 0x04000830 RID: 2096
		Private updateBtn As String

		' Token: 0x04000831 RID: 2097
		Private strPcode As String

		' Token: 0x04000832 RID: 2098
		Private id As Short

		' Token: 0x04000833 RID: 2099
		Private strBarcode As String

		' Token: 0x04000834 RID: 2100
		Private dt As DataTable

		' Token: 0x04000835 RID: 2101
		Private initialQty As Decimal

		' Token: 0x04000836 RID: 2102
		Private StyleId As String

		' Token: 0x04000837 RID: 2103
		Private strStax As String

		' Token: 0x04000838 RID: 2104
		Private strPtax As String

		' Token: 0x04000839 RID: 2105
		Private Photoname As String

		' Token: 0x0400083A RID: 2106
		Private IsImageChanged As Boolean

		' Token: 0x0400083B RID: 2107
		Private apiKey As String

		' Token: 0x0400083C RID: 2108
		Private url As String

		' Token: 0x0400083D RID: 2109
		Public Shared strForm As String = ""

		' Token: 0x0400083E RID: 2110
		Public Shared strSubcategory_POSNewTuch As String = ""

		' Token: 0x04000840 RID: 2112
		Private prevCell As DataGridViewCell

		' Token: 0x04000841 RID: 2113
		Private leftnavigationhappened As Boolean

		' Token: 0x04000842 RID: 2114
		Private Dad As SqlDataAdapter

		' Token: 0x04000843 RID: 2115
		Private Dst As DataSet

		' Token: 0x04000844 RID: 2116
		Private CurrentRow As Object

		' Token: 0x04000845 RID: 2117
		Private isd As String

		' Token: 0x04000846 RID: 2118
		Public defaultSubCategoryId As Integer

		' Token: 0x04000847 RID: 2119
		Public defaultCatSubText As String

		' Token: 0x04000848 RID: 2120
		Public defaultCategory As String

		' Token: 0x04000849 RID: 2121
		Public defaultSubCategory As String

		' Token: 0x0400084A RID: 2122
		Public unit As String

		' Token: 0x0400084B RID: 2123
		Public Rate As Double

		' Token: 0x0400084C RID: 2124
		Public stax_type As String

		' Token: 0x0400084D RID: 2125
		Public Ptax_type As String

		' Token: 0x0400084E RID: 2126
		Public DRate As Double
	End Class
End Namespace
