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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020000DF RID: 223
	<DesignerGenerated()>
	Public Partial Class frmCustomerRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060027F4 RID: 10228 RVA: 0x00191CA0 File Offset: 0x0018FEA0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerRecord_KeyDown
			AddHandler MyBase.Closing, AddressOf Me.frmCustomerRecord_Closing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000FB6 RID: 4022
		' (get) Token: 0x060027F7 RID: 10231 RVA: 0x0001A367 File Offset: 0x00018567
		' (set) Token: 0x060027F8 RID: 10232 RVA: 0x0001A371 File Offset: 0x00018571
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000FB7 RID: 4023
		' (get) Token: 0x060027F9 RID: 10233 RVA: 0x0001A37A File Offset: 0x0001857A
		' (set) Token: 0x060027FA RID: 10234 RVA: 0x00193C44 File Offset: 0x00191E44
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw_KeyDown
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.KeyDown, keyEventHandler
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.KeyDown, keyEventHandler
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FB8 RID: 4024
		' (get) Token: 0x060027FB RID: 10235 RVA: 0x0001A384 File Offset: 0x00018584
		' (set) Token: 0x060027FC RID: 10236 RVA: 0x0001A38E File Offset: 0x0001858E
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000FB9 RID: 4025
		' (get) Token: 0x060027FD RID: 10237 RVA: 0x0001A397 File Offset: 0x00018597
		' (set) Token: 0x060027FE RID: 10238 RVA: 0x00193CC0 File Offset: 0x00191EC0
		Private _txtCity As TextBox
		Friend Overridable Property txtCity As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCity
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCity_TextChanged
				Dim textBox As TextBox = Me._txtCity
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCity = value
				textBox = Me._txtCity
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FBA RID: 4026
		' (get) Token: 0x060027FF RID: 10239 RVA: 0x0001A3A1 File Offset: 0x000185A1
		' (set) Token: 0x06002800 RID: 10240 RVA: 0x0001A3AB File Offset: 0x000185AB
		Friend Overridable Property Label2 As Label

		' Token: 0x17000FBB RID: 4027
		' (get) Token: 0x06002801 RID: 10241 RVA: 0x0001A3B4 File Offset: 0x000185B4
		' (set) Token: 0x06002802 RID: 10242 RVA: 0x0001A3BE File Offset: 0x000185BE
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000FBC RID: 4028
		' (get) Token: 0x06002803 RID: 10243 RVA: 0x0001A3C7 File Offset: 0x000185C7
		' (set) Token: 0x06002804 RID: 10244 RVA: 0x00193D04 File Offset: 0x00191F04
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtCustomerName_KeyDown
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FBD RID: 4029
		' (get) Token: 0x06002805 RID: 10245 RVA: 0x0001A3D1 File Offset: 0x000185D1
		' (set) Token: 0x06002806 RID: 10246 RVA: 0x0001A3DB File Offset: 0x000185DB
		Friend Overridable Property Label3 As Label

		' Token: 0x17000FBE RID: 4030
		' (get) Token: 0x06002807 RID: 10247 RVA: 0x0001A3E4 File Offset: 0x000185E4
		' (set) Token: 0x06002808 RID: 10248 RVA: 0x0001A3EE File Offset: 0x000185EE
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17000FBF RID: 4031
		' (get) Token: 0x06002809 RID: 10249 RVA: 0x0001A3F7 File Offset: 0x000185F7
		' (set) Token: 0x0600280A RID: 10250 RVA: 0x00193D48 File Offset: 0x00191F48
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
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FC0 RID: 4032
		' (get) Token: 0x0600280B RID: 10251 RVA: 0x0001A401 File Offset: 0x00018601
		' (set) Token: 0x0600280C RID: 10252 RVA: 0x0001A40B File Offset: 0x0001860B
		Friend Overridable Property Label4 As Label

		' Token: 0x17000FC1 RID: 4033
		' (get) Token: 0x0600280D RID: 10253 RVA: 0x0001A414 File Offset: 0x00018614
		' (set) Token: 0x0600280E RID: 10254 RVA: 0x0001A41E File Offset: 0x0001861E
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17000FC2 RID: 4034
		' (get) Token: 0x0600280F RID: 10255 RVA: 0x0001A427 File Offset: 0x00018627
		' (set) Token: 0x06002810 RID: 10256 RVA: 0x0001A431 File Offset: 0x00018631
		Friend Overridable Property lblUser As Label

		' Token: 0x17000FC3 RID: 4035
		' (get) Token: 0x06002811 RID: 10257 RVA: 0x0001A43A File Offset: 0x0001863A
		' (set) Token: 0x06002812 RID: 10258 RVA: 0x0001A444 File Offset: 0x00018644
		Friend Overridable Property Label1 As Label

		' Token: 0x17000FC4 RID: 4036
		' (get) Token: 0x06002813 RID: 10259 RVA: 0x0001A44D File Offset: 0x0001864D
		' (set) Token: 0x06002814 RID: 10260 RVA: 0x0001A457 File Offset: 0x00018657
		Friend Overridable Property lblSet As Label

		' Token: 0x17000FC5 RID: 4037
		' (get) Token: 0x06002815 RID: 10261 RVA: 0x0001A460 File Offset: 0x00018660
		' (set) Token: 0x06002816 RID: 10262 RVA: 0x0001A46A File Offset: 0x0001866A
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17000FC6 RID: 4038
		' (get) Token: 0x06002817 RID: 10263 RVA: 0x0001A473 File Offset: 0x00018673
		' (set) Token: 0x06002818 RID: 10264 RVA: 0x0001A47D File Offset: 0x0001867D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000FC7 RID: 4039
		' (get) Token: 0x06002819 RID: 10265 RVA: 0x0001A486 File Offset: 0x00018686
		' (set) Token: 0x0600281A RID: 10266 RVA: 0x00193D8C File Offset: 0x00191F8C
		Private _txtRoute As TextBox
		Friend Overridable Property txtRoute As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRoute
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtRoute_TextChanged
				Dim textBox As TextBox = Me._txtRoute
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtRoute = value
				textBox = Me._txtRoute
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000FC8 RID: 4040
		' (get) Token: 0x0600281B RID: 10267 RVA: 0x0001A490 File Offset: 0x00018690
		' (set) Token: 0x0600281C RID: 10268 RVA: 0x0001A49A File Offset: 0x0001869A
		Friend Overridable Property Label5 As Label

		' Token: 0x17000FC9 RID: 4041
		' (get) Token: 0x0600281D RID: 10269 RVA: 0x0001A4A3 File Offset: 0x000186A3
		' (set) Token: 0x0600281E RID: 10270 RVA: 0x0001A4AD File Offset: 0x000186AD
		Friend Overridable Property Label6 As Label

		' Token: 0x17000FCA RID: 4042
		' (get) Token: 0x0600281F RID: 10271 RVA: 0x0001A4B6 File Offset: 0x000186B6
		' (set) Token: 0x06002820 RID: 10272 RVA: 0x0001A4C0 File Offset: 0x000186C0
		Friend Overridable Property Label7 As Label

		' Token: 0x17000FCB RID: 4043
		' (get) Token: 0x06002821 RID: 10273 RVA: 0x0001A4C9 File Offset: 0x000186C9
		' (set) Token: 0x06002822 RID: 10274 RVA: 0x0001A4D3 File Offset: 0x000186D3
		Friend Overridable Property txtTopResult As TextBox

		' Token: 0x17000FCC RID: 4044
		' (get) Token: 0x06002823 RID: 10275 RVA: 0x0001A4DC File Offset: 0x000186DC
		' (set) Token: 0x06002824 RID: 10276 RVA: 0x00193DD0 File Offset: 0x00191FD0
		Private _btnAddCustomer As GelButton
		Friend Overridable Property btnAddCustomer As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnAddCustomer
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
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

		' Token: 0x17000FCD RID: 4045
		' (get) Token: 0x06002825 RID: 10277 RVA: 0x0001A4E6 File Offset: 0x000186E6
		' (set) Token: 0x06002826 RID: 10278 RVA: 0x00193E14 File Offset: 0x00192014
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

		' Token: 0x17000FCE RID: 4046
		' (get) Token: 0x06002827 RID: 10279 RVA: 0x0001A4F0 File Offset: 0x000186F0
		' (set) Token: 0x06002828 RID: 10280 RVA: 0x00193E58 File Offset: 0x00192058
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

		' Token: 0x17000FCF RID: 4047
		' (get) Token: 0x06002829 RID: 10281 RVA: 0x0001A4FA File Offset: 0x000186FA
		' (set) Token: 0x0600282A RID: 10282 RVA: 0x0001A504 File Offset: 0x00018704
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000FD0 RID: 4048
		' (get) Token: 0x0600282B RID: 10283 RVA: 0x0001A50D File Offset: 0x0001870D
		' (set) Token: 0x0600282C RID: 10284 RVA: 0x0001A517 File Offset: 0x00018717
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000FD1 RID: 4049
		' (get) Token: 0x0600282D RID: 10285 RVA: 0x0001A520 File Offset: 0x00018720
		' (set) Token: 0x0600282E RID: 10286 RVA: 0x0001A52A File Offset: 0x0001872A
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000FD2 RID: 4050
		' (get) Token: 0x0600282F RID: 10287 RVA: 0x0001A533 File Offset: 0x00018733
		' (set) Token: 0x06002830 RID: 10288 RVA: 0x0001A53D File Offset: 0x0001873D
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000FD3 RID: 4051
		' (get) Token: 0x06002831 RID: 10289 RVA: 0x0001A546 File Offset: 0x00018746
		' (set) Token: 0x06002832 RID: 10290 RVA: 0x0001A550 File Offset: 0x00018750
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000FD4 RID: 4052
		' (get) Token: 0x06002833 RID: 10291 RVA: 0x0001A559 File Offset: 0x00018759
		' (set) Token: 0x06002834 RID: 10292 RVA: 0x0001A563 File Offset: 0x00018763
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000FD5 RID: 4053
		' (get) Token: 0x06002835 RID: 10293 RVA: 0x0001A56C File Offset: 0x0001876C
		' (set) Token: 0x06002836 RID: 10294 RVA: 0x0001A576 File Offset: 0x00018776
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000FD6 RID: 4054
		' (get) Token: 0x06002837 RID: 10295 RVA: 0x0001A57F File Offset: 0x0001877F
		' (set) Token: 0x06002838 RID: 10296 RVA: 0x0001A589 File Offset: 0x00018789
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000FD7 RID: 4055
		' (get) Token: 0x06002839 RID: 10297 RVA: 0x0001A592 File Offset: 0x00018792
		' (set) Token: 0x0600283A RID: 10298 RVA: 0x0001A59C File Offset: 0x0001879C
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000FD8 RID: 4056
		' (get) Token: 0x0600283B RID: 10299 RVA: 0x0001A5A5 File Offset: 0x000187A5
		' (set) Token: 0x0600283C RID: 10300 RVA: 0x0001A5AF File Offset: 0x000187AF
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000FD9 RID: 4057
		' (get) Token: 0x0600283D RID: 10301 RVA: 0x0001A5B8 File Offset: 0x000187B8
		' (set) Token: 0x0600283E RID: 10302 RVA: 0x0001A5C2 File Offset: 0x000187C2
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17000FDA RID: 4058
		' (get) Token: 0x0600283F RID: 10303 RVA: 0x0001A5CB File Offset: 0x000187CB
		' (set) Token: 0x06002840 RID: 10304 RVA: 0x0001A5D5 File Offset: 0x000187D5
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17000FDB RID: 4059
		' (get) Token: 0x06002841 RID: 10305 RVA: 0x0001A5DE File Offset: 0x000187DE
		' (set) Token: 0x06002842 RID: 10306 RVA: 0x0001A5E8 File Offset: 0x000187E8
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17000FDC RID: 4060
		' (get) Token: 0x06002843 RID: 10307 RVA: 0x0001A5F1 File Offset: 0x000187F1
		' (set) Token: 0x06002844 RID: 10308 RVA: 0x0001A5FB File Offset: 0x000187FB
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17000FDD RID: 4061
		' (get) Token: 0x06002845 RID: 10309 RVA: 0x0001A604 File Offset: 0x00018804
		' (set) Token: 0x06002846 RID: 10310 RVA: 0x0001A60E File Offset: 0x0001880E
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17000FDE RID: 4062
		' (get) Token: 0x06002847 RID: 10311 RVA: 0x0001A617 File Offset: 0x00018817
		' (set) Token: 0x06002848 RID: 10312 RVA: 0x0001A621 File Offset: 0x00018821
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17000FDF RID: 4063
		' (get) Token: 0x06002849 RID: 10313 RVA: 0x0001A62A File Offset: 0x0001882A
		' (set) Token: 0x0600284A RID: 10314 RVA: 0x0001A634 File Offset: 0x00018834
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x17000FE0 RID: 4064
		' (get) Token: 0x0600284B RID: 10315 RVA: 0x0001A63D File Offset: 0x0001883D
		' (set) Token: 0x0600284C RID: 10316 RVA: 0x0001A647 File Offset: 0x00018847
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x17000FE1 RID: 4065
		' (get) Token: 0x0600284D RID: 10317 RVA: 0x0001A650 File Offset: 0x00018850
		' (set) Token: 0x0600284E RID: 10318 RVA: 0x0001A65A File Offset: 0x0001885A
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x17000FE2 RID: 4066
		' (get) Token: 0x0600284F RID: 10319 RVA: 0x0001A663 File Offset: 0x00018863
		' (set) Token: 0x06002850 RID: 10320 RVA: 0x0001A66D File Offset: 0x0001886D
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000FE3 RID: 4067
		' (get) Token: 0x06002851 RID: 10321 RVA: 0x0001A676 File Offset: 0x00018876
		' (set) Token: 0x06002852 RID: 10322 RVA: 0x0001A680 File Offset: 0x00018880
		Friend Overridable Property Column12 As DataGridViewImageColumn

		' Token: 0x17000FE4 RID: 4068
		' (get) Token: 0x06002853 RID: 10323 RVA: 0x0001A689 File Offset: 0x00018889
		' (set) Token: 0x06002854 RID: 10324 RVA: 0x0001A693 File Offset: 0x00018893
		Friend Overridable Property Column22 As DataGridViewTextBoxColumn

		' Token: 0x17000FE5 RID: 4069
		' (get) Token: 0x06002855 RID: 10325 RVA: 0x0001A69C File Offset: 0x0001889C
		' (set) Token: 0x06002856 RID: 10326 RVA: 0x0001A6A6 File Offset: 0x000188A6
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x17000FE6 RID: 4070
		' (get) Token: 0x06002857 RID: 10327 RVA: 0x0001A6AF File Offset: 0x000188AF
		' (set) Token: 0x06002858 RID: 10328 RVA: 0x0001A6B9 File Offset: 0x000188B9
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x17000FE7 RID: 4071
		' (get) Token: 0x06002859 RID: 10329 RVA: 0x0001A6C2 File Offset: 0x000188C2
		' (set) Token: 0x0600285A RID: 10330 RVA: 0x0001A6CC File Offset: 0x000188CC
		Friend Overridable Property Column25 As DataGridViewTextBoxColumn

		' Token: 0x17000FE8 RID: 4072
		' (get) Token: 0x0600285B RID: 10331 RVA: 0x0001A6D5 File Offset: 0x000188D5
		' (set) Token: 0x0600285C RID: 10332 RVA: 0x0001A6DF File Offset: 0x000188DF
		Friend Overridable Property Column26 As DataGridViewTextBoxColumn

		' Token: 0x17000FE9 RID: 4073
		' (get) Token: 0x0600285D RID: 10333 RVA: 0x0001A6E8 File Offset: 0x000188E8
		' (set) Token: 0x0600285E RID: 10334 RVA: 0x0001A6F2 File Offset: 0x000188F2
		Friend Overridable Property Column27 As DataGridViewTextBoxColumn

		' Token: 0x17000FEA RID: 4074
		' (get) Token: 0x0600285F RID: 10335 RVA: 0x0001A6FB File Offset: 0x000188FB
		' (set) Token: 0x06002860 RID: 10336 RVA: 0x0001A705 File Offset: 0x00018905
		Friend Overridable Property Column28 As DataGridViewTextBoxColumn

		' Token: 0x17000FEB RID: 4075
		' (get) Token: 0x06002861 RID: 10337 RVA: 0x0001A70E File Offset: 0x0001890E
		' (set) Token: 0x06002862 RID: 10338 RVA: 0x0001A718 File Offset: 0x00018918
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x17000FEC RID: 4076
		' (get) Token: 0x06002863 RID: 10339 RVA: 0x0001A721 File Offset: 0x00018921
		' (set) Token: 0x06002864 RID: 10340 RVA: 0x0001A72B File Offset: 0x0001892B
		Friend Overridable Property Column30 As DataGridViewTextBoxColumn

		' Token: 0x17000FED RID: 4077
		' (get) Token: 0x06002865 RID: 10341 RVA: 0x0001A734 File Offset: 0x00018934
		' (set) Token: 0x06002866 RID: 10342 RVA: 0x0001A73E File Offset: 0x0001893E
		Friend Overridable Property Column32 As DataGridViewTextBoxColumn

		' Token: 0x17000FEE RID: 4078
		' (get) Token: 0x06002867 RID: 10343 RVA: 0x0001A747 File Offset: 0x00018947
		' (set) Token: 0x06002868 RID: 10344 RVA: 0x0001A751 File Offset: 0x00018951
		Friend Overridable Property Column31 As DataGridViewTextBoxColumn

		' Token: 0x17000FEF RID: 4079
		' (get) Token: 0x06002869 RID: 10345 RVA: 0x0001A75A File Offset: 0x0001895A
		' (set) Token: 0x0600286A RID: 10346 RVA: 0x0001A764 File Offset: 0x00018964
		Friend Overridable Property Column33 As DataGridViewTextBoxColumn

		' Token: 0x17000FF0 RID: 4080
		' (get) Token: 0x0600286B RID: 10347 RVA: 0x0001A76D File Offset: 0x0001896D
		' (set) Token: 0x0600286C RID: 10348 RVA: 0x0001A777 File Offset: 0x00018977
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x0600286D RID: 10349 RVA: 0x00193E9C File Offset: 0x0019209C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP " + Me.txtTopResult.Text + " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal), Photo, RTRIM(Tcs), RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer), RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality), is_loyalityDisable,shippingAddress from Customer order by name", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600286E RID: 10350 RVA: 0x001941A8 File Offset: 0x001923A8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600286F RID: 10351 RVA: 0x0019422C File Offset: 0x0019242C
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

		' Token: 0x06002870 RID: 10352 RVA: 0x001943A4 File Offset: 0x001925A4
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

		' Token: 0x06002871 RID: 10353 RVA: 0x00194470 File Offset: 0x00192670
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

		' Token: 0x06002872 RID: 10354 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06002873 RID: 10355 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06002874 RID: 10356 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002875 RID: 10357 RVA: 0x0019453C File Offset: 0x0019273C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06002876 RID: 10358 RVA: 0x0001A780 File Offset: 0x00018980
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06002877 RID: 10359 RVA: 0x00194564 File Offset: 0x00192764
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Entry", False) = 0
					If flag2 Then
						MyProject.Forms.frmCustomer.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomer.btnUpdate.Enabled = True
						MyProject.Forms.frmCustomer.btnDelete.Enabled = True
						MyProject.Forms.frmCustomer.btnSave.Enabled = False
						MyProject.Forms.frmCustomer.chkvalid()
						Me.lblSet.Text = ""
						MyProject.Forms.frmCustomer.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmCustomer.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomer.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtCity.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCustomer.cmbState.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCustomer.txtZipCode.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmCustomer.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtPhNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtEmailID.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCustomer.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtCIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCustomer.txtPAN.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmCustomer.txtAccountName.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmCustomer.txtAccountNo.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmCustomer.txtBank.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmCustomer.txtBranch.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmCustomer.txtIFSCcode.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmCustomer.txtRemarks.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmCustomer.cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDown
						MyProject.Forms.frmCustomer.cmbOpeningBalanceType.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmCustomer.txtOpeningBalance.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmCustomer.cmbTCS.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmCustomer.txtcrlimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmCustomer.cmbcrlimit.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmCustomer.cmbRoute.Text = dataGridViewRow.Cells(26).Value.ToString()
						Dim num As Integer = 0
						Dim text As String = dataGridViewRow.Cells(27).Value.ToString()
						Dim num2 As Decimal = New Decimal(num)
						Dim flag3 As Boolean = Decimal.TryParse(text, num2)
						num = Convert.ToInt32(num2)
						Dim flag4 As Boolean = flag3
						If flag4 Then
							MyProject.Forms.frmCustomer.Num1.Value = Conversions.ToDecimal(dataGridViewRow.Cells(27).Value.ToString())
						End If
						MyProject.Forms.frmCustomer.txtDiscItem.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmCustomer.cmbDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmCustomer.cboxLoyality.DropDownStyle = ComboBoxStyle.DropDown
						MyProject.Forms.frmCustomer.cboxLoyality.Text = dataGridViewRow.Cells(30).Value.ToString()
						MyProject.Forms.frmCustomer.txtLoyalitypts.Text = dataGridViewRow.Cells(31).Value.ToString()
						Dim flag5 As Boolean = Conversions.ToDouble(dataGridViewRow.Cells(32).Value.ToString()) = 0.0
						If flag5 Then
							MyProject.Forms.frmCustomer.chkLoyality.Checked = True
						Else
							MyProject.Forms.frmCustomer.chkLoyality.Checked = False
						End If
						Dim array As Byte() = CType(dataGridViewRow.Cells(20).Value, Byte())
						Dim memoryStream As MemoryStream = New MemoryStream(array)
						MyProject.Forms.frmCustomer.Picture.Image = Image.FromStream(memoryStream)
					End If
					Dim flag6 As Boolean = Operators.CompareString(Me.lblSet.Text, "Quotation", False) = 0
					If flag6 Then
						MyProject.Forms.frmQuotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmQuotation.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmQuotation.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmQuotation.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag7 As Boolean = Operators.CompareString(MyProject.Forms.frmQuotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag7 Then
							MyProject.Forms.frmQuotation.txtCustomerState.Text = MyProject.Forms.frmQuotation.txtCompanyState.Text
						Else
							MyProject.Forms.frmQuotation.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmQuotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmQuotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmQuotation.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmQuotation.btnProductSelection.Focus()
						Me.lblSet.Text = ""
					End If
					Dim flag8 As Boolean = Operators.CompareString(Me.lblSet.Text, "Estimate", False) = 0
					If flag8 Then
						MyProject.Forms.frmEstimate.Show()
						MyBase.Hide()
						MyProject.Forms.frmEstimate.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmEstimate.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmEstimate.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag9 As Boolean = Operators.CompareString(MyProject.Forms.frmEstimate.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag9 Then
							MyProject.Forms.frmEstimate.txtCustomerState.Text = MyProject.Forms.frmEstimate.txtCompanyState.Text
						Else
							MyProject.Forms.frmEstimate.txtCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmEstimate.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmEstimate.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmEstimate.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmEstimate.btnProductSelection.Focus()
						Me.lblSet.Text = ""
					End If
					Dim flag10 As Boolean = Operators.CompareString(Me.lblSet.Text, "POS", False) = 0
					If flag10 Then
						MyProject.Forms.frmPOS.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOS.FillCustomers()
						MyProject.Forms.frmPOS.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOS.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOS.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag11 As Boolean = Operators.CompareString(MyProject.Forms.frmPOS.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag11 Then
							MyProject.Forms.frmPOS.cmbCustomerState.Text = MyProject.Forms.frmPOS.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOS.cmbCustomerState.Text = ModCommonClasses.rdr.GetValue(5).ToString()
						End If
						MyProject.Forms.frmPOS.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOS.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOS.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOS.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOS.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOS.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOS.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOS.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOS.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOS.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOS.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOS.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOS.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOS.Label82.Enabled = False
						MyProject.Forms.frmPOS.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOS.GetCustomerBalance()
						MyProject.Forms.frmPOS.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOS.Calculate12345()
						MyProject.Forms.frmPOS.Calculate143()
						MyProject.Forms.frmPOS.tcsconn()
						MyProject.Forms.frmPOS.InvoiceTCSinfo()
						MyProject.Forms.frmPOS.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag12 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouch", False) = 0
					If flag12 Then
						MyProject.Forms.frmPOSTouch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSTouch.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag13 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSTouch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag13 Then
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = MyProject.Forms.frmPOSTouch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSTouch.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSTouch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSTouch.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSTouch.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSTouch.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSTouch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSTouch.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSTouch.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSTouch.Label82.Enabled = False
						MyProject.Forms.frmPOSTouch.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSTouch.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSTouch.GetCustomerBalance()
						MyProject.Forms.frmPOSTouch.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSTouch.Calculate12345()
						MyProject.Forms.frmPOSTouch.Calculate143()
						MyProject.Forms.frmPOSTouch.tcsconn()
						MyProject.Forms.frmPOSTouch.InvoiceTCSinfo()
						MyProject.Forms.frmPOSTouch.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag14 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouchNew", False) = 0
					If flag14 Then
						MyProject.Forms.frmPOSNewTuch.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag15 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag15 Then
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSNewTuch.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch.Label82.Enabled = False
						MyProject.Forms.frmPOSNewTuch.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.lblLoyality.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch.GetCustomerBalance()
						MyProject.Forms.frmPOSNewTuch.CustomerBalance_Loyality()
						MyProject.Forms.frmPOSNewTuch.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSNewTuch.Calculate12345()
						MyProject.Forms.frmPOSNewTuch.Calculate143()
						MyProject.Forms.frmPOSNewTuch.tcsconn()
						MyProject.Forms.frmPOSNewTuch.InvoiceTCSinfo()
						MyProject.Forms.frmPOSNewTuch.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag16 As Boolean = Operators.CompareString(Me.lblSet.Text, "POSTouchNew_Quotation", False) = 0
					If flag16 Then
						MyProject.Forms.frmPOSNewTuch_Quotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						Dim flag17 As Boolean = Operators.CompareString(MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag17 Then
							MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = MyProject.Forms.frmPOSNewTuch_Quotation.txtCompanyState.Text
						Else
							MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Text = dataGridViewRow.Cells(5).Value.ToString()
						End If
						MyProject.Forms.frmPOSNewTuch_Quotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.textmailid.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtPan.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtTCSstatus.Text = dataGridViewRow.Cells(21).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.lblcard.Text = dataGridViewRow.Cells(22).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtLStatus.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustLimit.Text = dataGridViewRow.Cells(24).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustLimitstatus.Text = dataGridViewRow.Cells(25).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.btnCustomerSelection.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerName.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.cmbCustomerState.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.TextBox15.[ReadOnly] = True
						MyProject.Forms.frmPOSNewTuch_Quotation.Label82.Enabled = False
						MyProject.Forms.frmPOSNewTuch_Quotation.CAddress = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtCustomerDiscPer.Text = dataGridViewRow.Cells(28).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.txtDiscStatus.Text = dataGridViewRow.Cells(29).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.lblLoyality.Text = dataGridViewRow.Cells(32).Value.ToString()
						MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalance()
						MyProject.Forms.frmPOSNewTuch_Quotation.CustomerBalance_Loyality()
						MyProject.Forms.frmPOSNewTuch_Quotation.GetCustomerBalanceforTCS()
						MyProject.Forms.frmPOSNewTuch_Quotation.Calculate12345()
						MyProject.Forms.frmPOSNewTuch_Quotation.Calculate143()
						MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn()
						MyProject.Forms.frmPOSNewTuch_Quotation.InvoiceTCSinfo()
						MyProject.Forms.frmPOSNewTuch_Quotation.tcsconn1()
						Me.lblSet.Text = ""
					End If
					Dim flag18 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag18 Then
						MyProject.Forms.frmCreditCustomerReceipt.Show()
						MyBase.Hide()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtAddress.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.GetCustomerBalance()
						Me.lblSet.Text = ""
					End If
					Dim flag19 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Ledger", False) = 0
					If flag19 Then
						MyProject.Forms.frmCustomerLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomerLedger.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomerLedger.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag20 As Boolean = Operators.CompareString(Me.lblSet.Text, "Customer Ledger Loyalty", False) = 0
					If flag20 Then
						MyProject.Forms.frmCustomerLedger.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomerLedger_Loyalty.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCustomerLedger_Loyalty.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag21 As Boolean = Operators.CompareString(Me.lblSet.Text, "CT", False) = 0
					If flag21 Then
						MyProject.Forms.frmCreditTermsStatements.Show()
						MyBase.Hide()
						MyProject.Forms.frmCreditTermsStatements.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCreditTermsStatements.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						Me.lblSet.Text = ""
					End If
					Dim flag22 As Boolean = Operators.CompareString(Me.lblSet.Text, "Services", False) = 0
					If flag22 Then
						MyProject.Forms.frmServices.Show()
						MyBase.Hide()
						MyProject.Forms.frmServices.txtCID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmServices.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002878 RID: 10360 RVA: 0x00196580 File Offset: 0x00194780
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x06002879 RID: 10361 RVA: 0x00196668 File Offset: 0x00194868
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal),Photo,RTRIM(Tcs),RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer), RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality), is_loyalityDisable,shippingAddress from Customer where City like N'", Me.txtCity.Text, "%' order by city" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600287A RID: 10362 RVA: 0x00196998 File Offset: 0x00194B98
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtCity.Text = ""
			Me.txtRoute.Text = ""
			Me.txtTopResult.Text = "10"
		End Sub

		' Token: 0x0600287B RID: 10363 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x0600287C RID: 10364 RVA: 0x001969FC File Offset: 0x00194BFC
		Private Sub txtRoute_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal),Photo,RTRIM(Tcs),RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer), RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality), is_loyalityDisable,shippingAddress from Customer where Route like N'", Me.txtRoute.Text, "%' order by city" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600287D RID: 10365 RVA: 0x00196D2C File Offset: 0x00194F2C
		Public Sub txtCustomerName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal),Photo,RTRIM(Tcs),RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer), RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality), is_loyalityDisable,shippingAddress from Customer where name like N'", Me.txtCustomerName.Text, "%' order by name" }), ModCommonClasses.con)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x0600287E RID: 10366 RVA: 0x00197070 File Offset: 0x00195270
		Public Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand(String.Concat(New String() { "SELECT TOP ", Me.txtTopResult.Text, " RTRIM(ID),RTRIM(CustomerID),RTRIM([Name]), RTRIM(Address),RTRIM(City),RTRIM(State),RTRIM(ZipCode), RTRIM(ContactNo), RTRIM(EmailID),RTRIM(GSTIN),RTRIM(CIN),RTRIM(PAN),RTRIM(AccountName),RTRIM(AccountNumber),RTRIM(Bank),RTRIM(Branch),RTRIM(IFSCCode),RTRIM(Remarks),RTRIM(Optype),RTRIM(Opbal),Photo,RTRIM(Tcs),RTRIM(CardNo), RTRIM(Status), RTRIM(Limit), RTRIM(Lstatus), RTRIM(Route), RTRIM(Taround), RTRIM(DiscPer), RTRIM(DiscStatus), RTRIM(OpLoyalitytype),RTRIM(OpbalLoyality), is_loyalityDisable,shippingAddress from Customer where ContactNo like N'", Me.txtContactNo.Text, "%' order by city" }), ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21), ModCommonClasses.rdr(22), ModCommonClasses.rdr(23), ModCommonClasses.rdr(24), ModCommonClasses.rdr(25), ModCommonClasses.rdr(26), ModCommonClasses.rdr(27), ModCommonClasses.rdr(28), ModCommonClasses.rdr(29), ModCommonClasses.rdr(30), ModCommonClasses.rdr(31), ModCommonClasses.rdr(32), ModCommonClasses.rdr(33) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.Rows(0).Selected = True
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600287F RID: 10367 RVA: 0x001973AC File Offset: 0x001955AC
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomer.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomer.Reset()
			MyProject.Forms.frmCustomer.ShowDialog()
			MyProject.Forms.frmCustomer.Dispose()
		End Sub

		' Token: 0x06002880 RID: 10368 RVA: 0x0019740C File Offset: 0x0019560C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
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
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
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
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002881 RID: 10369 RVA: 0x0001A78A File Offset: 0x0001898A
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002882 RID: 10370 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06002883 RID: 10371 RVA: 0x0001A794 File Offset: 0x00018994
		Private Sub frmCustomerRecord_Closing(sender As Object, e As CancelEventArgs)
			MyProject.Forms.frmQuotation.FillCustomers()
		End Sub

		' Token: 0x040010E8 RID: 4328
		Private num1 As Decimal

		' Token: 0x040010E9 RID: 4329
		Private num2 As Decimal

		' Token: 0x040010EA RID: 4330
		Private num3 As Decimal

		' Token: 0x040010EB RID: 4331
		Private str As String
	End Class
End Namespace
