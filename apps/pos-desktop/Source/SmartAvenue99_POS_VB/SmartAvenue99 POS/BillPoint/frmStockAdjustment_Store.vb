Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000552 RID: 1362
	<DesignerGenerated()>
	Public Partial Class frmStockAdjustment_Store
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06010948 RID: 67912 RVA: 0x009B0714 File Offset: 0x009AE914
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockAdjustment_Store_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmStockAdjustment_Store_KeyDown
			Me.strType = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x170066AA RID: 26282
		' (get) Token: 0x0601094B RID: 67915 RVA: 0x000725D3 File Offset: 0x000707D3
		' (set) Token: 0x0601094C RID: 67916 RVA: 0x000725DD File Offset: 0x000707DD
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170066AB RID: 26283
		' (get) Token: 0x0601094D RID: 67917 RVA: 0x000725E6 File Offset: 0x000707E6
		' (set) Token: 0x0601094E RID: 67918 RVA: 0x000725F0 File Offset: 0x000707F0
		Friend Overridable Property Label3 As Label

		' Token: 0x170066AC RID: 26284
		' (get) Token: 0x0601094F RID: 67919 RVA: 0x000725F9 File Offset: 0x000707F9
		' (set) Token: 0x06010950 RID: 67920 RVA: 0x00072603 File Offset: 0x00070803
		Friend Overridable Property Label1 As Label

		' Token: 0x170066AD RID: 26285
		' (get) Token: 0x06010951 RID: 67921 RVA: 0x0007260C File Offset: 0x0007080C
		' (set) Token: 0x06010952 RID: 67922 RVA: 0x00072616 File Offset: 0x00070816
		Friend Overridable Property Label2 As Label

		' Token: 0x170066AE RID: 26286
		' (get) Token: 0x06010953 RID: 67923 RVA: 0x0007261F File Offset: 0x0007081F
		' (set) Token: 0x06010954 RID: 67924 RVA: 0x00072629 File Offset: 0x00070829
		Friend Overridable Property Label8 As Label

		' Token: 0x170066AF RID: 26287
		' (get) Token: 0x06010955 RID: 67925 RVA: 0x00072632 File Offset: 0x00070832
		' (set) Token: 0x06010956 RID: 67926 RVA: 0x0007263C File Offset: 0x0007083C
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170066B0 RID: 26288
		' (get) Token: 0x06010957 RID: 67927 RVA: 0x00072645 File Offset: 0x00070845
		' (set) Token: 0x06010958 RID: 67928 RVA: 0x009B360C File Offset: 0x009B180C
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

		' Token: 0x170066B1 RID: 26289
		' (get) Token: 0x06010959 RID: 67929 RVA: 0x0007264F File Offset: 0x0007084F
		' (set) Token: 0x0601095A RID: 67930 RVA: 0x009B366C File Offset: 0x009B186C
		Private _txtAdjustmentID As TextBox
		Friend Overridable Property txtAdjustmentID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAdjustmentID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtAdjustmentID_TextChanged
				Dim textBox As TextBox = Me._txtAdjustmentID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtAdjustmentID = value
				textBox = Me._txtAdjustmentID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170066B2 RID: 26290
		' (get) Token: 0x0601095B RID: 67931 RVA: 0x00072659 File Offset: 0x00070859
		' (set) Token: 0x0601095C RID: 67932 RVA: 0x00072663 File Offset: 0x00070863
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170066B3 RID: 26291
		' (get) Token: 0x0601095D RID: 67933 RVA: 0x0007266C File Offset: 0x0007086C
		' (set) Token: 0x0601095E RID: 67934 RVA: 0x009B36B0 File Offset: 0x009B18B0
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

		' Token: 0x170066B4 RID: 26292
		' (get) Token: 0x0601095F RID: 67935 RVA: 0x00072676 File Offset: 0x00070876
		' (set) Token: 0x06010960 RID: 67936 RVA: 0x009B36F4 File Offset: 0x009B18F4
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170066B5 RID: 26293
		' (get) Token: 0x06010961 RID: 67937 RVA: 0x00072680 File Offset: 0x00070880
		' (set) Token: 0x06010962 RID: 67938 RVA: 0x009B3738 File Offset: 0x009B1938
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

		' Token: 0x170066B6 RID: 26294
		' (get) Token: 0x06010963 RID: 67939 RVA: 0x0007268A File Offset: 0x0007088A
		' (set) Token: 0x06010964 RID: 67940 RVA: 0x009B377C File Offset: 0x009B197C
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

		' Token: 0x170066B7 RID: 26295
		' (get) Token: 0x06010965 RID: 67941 RVA: 0x00072694 File Offset: 0x00070894
		' (set) Token: 0x06010966 RID: 67942 RVA: 0x009B37C0 File Offset: 0x009B19C0
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

		' Token: 0x170066B8 RID: 26296
		' (get) Token: 0x06010967 RID: 67943 RVA: 0x0007269E File Offset: 0x0007089E
		' (set) Token: 0x06010968 RID: 67944 RVA: 0x000726A8 File Offset: 0x000708A8
		Friend Overridable Property Label27 As Label

		' Token: 0x170066B9 RID: 26297
		' (get) Token: 0x06010969 RID: 67945 RVA: 0x000726B1 File Offset: 0x000708B1
		' (set) Token: 0x0601096A RID: 67946 RVA: 0x000726BB File Offset: 0x000708BB
		Friend Overridable Property Label34 As Label

		' Token: 0x170066BA RID: 26298
		' (get) Token: 0x0601096B RID: 67947 RVA: 0x000726C4 File Offset: 0x000708C4
		' (set) Token: 0x0601096C RID: 67948 RVA: 0x000726CE File Offset: 0x000708CE
		Friend Overridable Property txtProductCode As TextBox

		' Token: 0x170066BB RID: 26299
		' (get) Token: 0x0601096D RID: 67949 RVA: 0x000726D7 File Offset: 0x000708D7
		' (set) Token: 0x0601096E RID: 67950 RVA: 0x009B3804 File Offset: 0x009B1A04
		Private _btnScanBarcode As Button
		Public Overridable Property btnScanBarcode As Button
			<CompilerGenerated()>
			Get
				Return Me._btnScanBarcode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnScanBarcode_Click
				Dim button As Button = Me._btnScanBarcode
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnScanBarcode = value
				button = Me._btnScanBarcode
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170066BC RID: 26300
		' (get) Token: 0x0601096F RID: 67951 RVA: 0x000726E1 File Offset: 0x000708E1
		' (set) Token: 0x06010970 RID: 67952 RVA: 0x000726EB File Offset: 0x000708EB
		Friend Overridable Property gbAdjustment As GroupBox

		' Token: 0x170066BD RID: 26301
		' (get) Token: 0x06010971 RID: 67953 RVA: 0x000726F4 File Offset: 0x000708F4
		' (set) Token: 0x06010972 RID: 67954 RVA: 0x000726FE File Offset: 0x000708FE
		Friend Overridable Property rbMinus As RadioButton

		' Token: 0x170066BE RID: 26302
		' (get) Token: 0x06010973 RID: 67955 RVA: 0x00072707 File Offset: 0x00070907
		' (set) Token: 0x06010974 RID: 67956 RVA: 0x00072711 File Offset: 0x00070911
		Friend Overridable Property rbPlus As RadioButton

		' Token: 0x170066BF RID: 26303
		' (get) Token: 0x06010975 RID: 67957 RVA: 0x0007271A File Offset: 0x0007091A
		' (set) Token: 0x06010976 RID: 67958 RVA: 0x009B3848 File Offset: 0x009B1A48
		Private _txtReason As TextBox
		Friend Overridable Property txtReason As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtReason
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtReason_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtReason
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtReason = value
				textBox = Me._txtReason
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170066C0 RID: 26304
		' (get) Token: 0x06010977 RID: 67959 RVA: 0x00072724 File Offset: 0x00070924
		' (set) Token: 0x06010978 RID: 67960 RVA: 0x0007272E File Offset: 0x0007092E
		Friend Overridable Property Label5 As Label

		' Token: 0x170066C1 RID: 26305
		' (get) Token: 0x06010979 RID: 67961 RVA: 0x00072737 File Offset: 0x00070937
		' (set) Token: 0x0601097A RID: 67962 RVA: 0x009B38A8 File Offset: 0x009B1AA8
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
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtQty_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtQty
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtQty = value
				textBox = Me._txtQty
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170066C2 RID: 26306
		' (get) Token: 0x0601097B RID: 67963 RVA: 0x00072741 File Offset: 0x00070941
		' (set) Token: 0x0601097C RID: 67964 RVA: 0x0007274B File Offset: 0x0007094B
		Friend Overridable Property Label4 As Label

		' Token: 0x170066C3 RID: 26307
		' (get) Token: 0x0601097D RID: 67965 RVA: 0x00072754 File Offset: 0x00070954
		' (set) Token: 0x0601097E RID: 67966 RVA: 0x009B3924 File Offset: 0x009B1B24
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

		' Token: 0x170066C4 RID: 26308
		' (get) Token: 0x0601097F RID: 67967 RVA: 0x0007275E File Offset: 0x0007095E
		' (set) Token: 0x06010980 RID: 67968 RVA: 0x00072768 File Offset: 0x00070968
		Friend Overridable Property lblQty_S As Label

		' Token: 0x170066C5 RID: 26309
		' (get) Token: 0x06010981 RID: 67969 RVA: 0x00072771 File Offset: 0x00070971
		' (set) Token: 0x06010982 RID: 67970 RVA: 0x0007277B File Offset: 0x0007097B
		Friend Overridable Property Label7 As Label

		' Token: 0x170066C6 RID: 26310
		' (get) Token: 0x06010983 RID: 67971 RVA: 0x00072784 File Offset: 0x00070984
		' (set) Token: 0x06010984 RID: 67972 RVA: 0x009B3968 File Offset: 0x009B1B68
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

		' Token: 0x170066C7 RID: 26311
		' (get) Token: 0x06010985 RID: 67973 RVA: 0x0007278E File Offset: 0x0007098E
		' (set) Token: 0x06010986 RID: 67974 RVA: 0x00072798 File Offset: 0x00070998
		Friend Overridable Property txtQ As TextBox

		' Token: 0x170066C8 RID: 26312
		' (get) Token: 0x06010987 RID: 67975 RVA: 0x000727A1 File Offset: 0x000709A1
		' (set) Token: 0x06010988 RID: 67976 RVA: 0x000727AB File Offset: 0x000709AB
		Friend Overridable Property txtProductID As TextBox

		' Token: 0x170066C9 RID: 26313
		' (get) Token: 0x06010989 RID: 67977 RVA: 0x000727B4 File Offset: 0x000709B4
		' (set) Token: 0x0601098A RID: 67978 RVA: 0x000727BE File Offset: 0x000709BE
		Friend Overridable Property lblUser As Label

		' Token: 0x170066CA RID: 26314
		' (get) Token: 0x0601098B RID: 67979 RVA: 0x000727C7 File Offset: 0x000709C7
		' (set) Token: 0x0601098C RID: 67980 RVA: 0x000727D1 File Offset: 0x000709D1
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x170066CB RID: 26315
		' (get) Token: 0x0601098D RID: 67981 RVA: 0x000727DA File Offset: 0x000709DA
		' (set) Token: 0x0601098E RID: 67982 RVA: 0x000727E4 File Offset: 0x000709E4
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x170066CC RID: 26316
		' (get) Token: 0x0601098F RID: 67983 RVA: 0x000727ED File Offset: 0x000709ED
		' (set) Token: 0x06010990 RID: 67984 RVA: 0x009B39AC File Offset: 0x009B1BAC
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

		' Token: 0x170066CD RID: 26317
		' (get) Token: 0x06010991 RID: 67985 RVA: 0x000727F7 File Offset: 0x000709F7
		' (set) Token: 0x06010992 RID: 67986 RVA: 0x00072801 File Offset: 0x00070A01
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170066CE RID: 26318
		' (get) Token: 0x06010993 RID: 67987 RVA: 0x0007280A File Offset: 0x00070A0A
		' (set) Token: 0x06010994 RID: 67988 RVA: 0x009B39F0 File Offset: 0x009B1BF0
		Private _txtProductName As TextBox
		Friend Overridable Property txtProductName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProductName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.txtProductName_TextChanged
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProductName_KeyDown
				Dim keyEventHandler2 As KeyEventHandler = AddressOf Me.txtProductName_KeyUp
				Dim textBox As TextBox = Me._txtProductName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.KeyUp, keyEventHandler2
				End If
				Me._txtProductName = value
				textBox = Me._txtProductName
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.KeyUp, keyEventHandler2
				End If
			End Set
		End Property

		' Token: 0x170066CF RID: 26319
		' (get) Token: 0x06010995 RID: 67989 RVA: 0x00072814 File Offset: 0x00070A14
		' (set) Token: 0x06010996 RID: 67990 RVA: 0x009B3A90 File Offset: 0x009B1C90
		Private _dgw4 As DataGridView
		Friend Overridable Property dgw4 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw4_MouseClick
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dgw4_KeyDown
				Dim dataGridView As DataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.KeyDown, keyEventHandler
				End If
				Me._dgw4 = value
				dataGridView = Me._dgw4
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170066D0 RID: 26320
		' (get) Token: 0x06010997 RID: 67991 RVA: 0x0007281E File Offset: 0x00070A1E
		' (set) Token: 0x06010998 RID: 67992 RVA: 0x00072828 File Offset: 0x00070A28
		Friend Overridable Property DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn

		' Token: 0x170066D1 RID: 26321
		' (get) Token: 0x06010999 RID: 67993 RVA: 0x00072831 File Offset: 0x00070A31
		' (set) Token: 0x0601099A RID: 67994 RVA: 0x0007283B File Offset: 0x00070A3B
		Friend Overridable Property DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn

		' Token: 0x170066D2 RID: 26322
		' (get) Token: 0x0601099B RID: 67995 RVA: 0x00072844 File Offset: 0x00070A44
		' (set) Token: 0x0601099C RID: 67996 RVA: 0x0007284E File Offset: 0x00070A4E
		Friend Overridable Property DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn

		' Token: 0x170066D3 RID: 26323
		' (get) Token: 0x0601099D RID: 67997 RVA: 0x00072857 File Offset: 0x00070A57
		' (set) Token: 0x0601099E RID: 67998 RVA: 0x00072861 File Offset: 0x00070A61
		Friend Overridable Property DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn

		' Token: 0x170066D4 RID: 26324
		' (get) Token: 0x0601099F RID: 67999 RVA: 0x0007286A File Offset: 0x00070A6A
		' (set) Token: 0x060109A0 RID: 68000 RVA: 0x00072874 File Offset: 0x00070A74
		Friend Overridable Property DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn

		' Token: 0x170066D5 RID: 26325
		' (get) Token: 0x060109A1 RID: 68001 RVA: 0x0007287D File Offset: 0x00070A7D
		' (set) Token: 0x060109A2 RID: 68002 RVA: 0x00072887 File Offset: 0x00070A87
		Friend Overridable Property DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn

		' Token: 0x170066D6 RID: 26326
		' (get) Token: 0x060109A3 RID: 68003 RVA: 0x00072890 File Offset: 0x00070A90
		' (set) Token: 0x060109A4 RID: 68004 RVA: 0x0007289A File Offset: 0x00070A9A
		Friend Overridable Property DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn

		' Token: 0x170066D7 RID: 26327
		' (get) Token: 0x060109A5 RID: 68005 RVA: 0x000728A3 File Offset: 0x00070AA3
		' (set) Token: 0x060109A6 RID: 68006 RVA: 0x000728AD File Offset: 0x00070AAD
		Friend Overridable Property DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn

		' Token: 0x170066D8 RID: 26328
		' (get) Token: 0x060109A7 RID: 68007 RVA: 0x000728B6 File Offset: 0x00070AB6
		' (set) Token: 0x060109A8 RID: 68008 RVA: 0x000728C0 File Offset: 0x00070AC0
		Friend Overridable Property DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn

		' Token: 0x170066D9 RID: 26329
		' (get) Token: 0x060109A9 RID: 68009 RVA: 0x000728C9 File Offset: 0x00070AC9
		' (set) Token: 0x060109AA RID: 68010 RVA: 0x000728D3 File Offset: 0x00070AD3
		Friend Overridable Property DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn

		' Token: 0x170066DA RID: 26330
		' (get) Token: 0x060109AB RID: 68011 RVA: 0x000728DC File Offset: 0x00070ADC
		' (set) Token: 0x060109AC RID: 68012 RVA: 0x000728E6 File Offset: 0x00070AE6
		Friend Overridable Property DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn

		' Token: 0x170066DB RID: 26331
		' (get) Token: 0x060109AD RID: 68013 RVA: 0x000728EF File Offset: 0x00070AEF
		' (set) Token: 0x060109AE RID: 68014 RVA: 0x000728F9 File Offset: 0x00070AF9
		Friend Overridable Property DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn

		' Token: 0x170066DC RID: 26332
		' (get) Token: 0x060109AF RID: 68015 RVA: 0x00072902 File Offset: 0x00070B02
		' (set) Token: 0x060109B0 RID: 68016 RVA: 0x0007290C File Offset: 0x00070B0C
		Friend Overridable Property DataGridViewTextBoxColumn35 As DataGridViewTextBoxColumn

		' Token: 0x170066DD RID: 26333
		' (get) Token: 0x060109B1 RID: 68017 RVA: 0x00072915 File Offset: 0x00070B15
		' (set) Token: 0x060109B2 RID: 68018 RVA: 0x0007291F File Offset: 0x00070B1F
		Friend Overridable Property DataGridViewTextBoxColumn36 As DataGridViewTextBoxColumn

		' Token: 0x170066DE RID: 26334
		' (get) Token: 0x060109B3 RID: 68019 RVA: 0x00072928 File Offset: 0x00070B28
		' (set) Token: 0x060109B4 RID: 68020 RVA: 0x00072932 File Offset: 0x00070B32
		Friend Overridable Property DataGridViewTextBoxColumn37 As DataGridViewTextBoxColumn

		' Token: 0x170066DF RID: 26335
		' (get) Token: 0x060109B5 RID: 68021 RVA: 0x0007293B File Offset: 0x00070B3B
		' (set) Token: 0x060109B6 RID: 68022 RVA: 0x00072945 File Offset: 0x00070B45
		Friend Overridable Property DataGridViewTextBoxColumn38 As DataGridViewTextBoxColumn

		' Token: 0x170066E0 RID: 26336
		' (get) Token: 0x060109B7 RID: 68023 RVA: 0x0007294E File Offset: 0x00070B4E
		' (set) Token: 0x060109B8 RID: 68024 RVA: 0x00072958 File Offset: 0x00070B58
		Friend Overridable Property DataGridViewTextBoxColumn39 As DataGridViewTextBoxColumn

		' Token: 0x170066E1 RID: 26337
		' (get) Token: 0x060109B9 RID: 68025 RVA: 0x00072961 File Offset: 0x00070B61
		' (set) Token: 0x060109BA RID: 68026 RVA: 0x0007296B File Offset: 0x00070B6B
		Friend Overridable Property DataGridViewTextBoxColumn40 As DataGridViewTextBoxColumn

		' Token: 0x170066E2 RID: 26338
		' (get) Token: 0x060109BB RID: 68027 RVA: 0x00072974 File Offset: 0x00070B74
		' (set) Token: 0x060109BC RID: 68028 RVA: 0x0007297E File Offset: 0x00070B7E
		Friend Overridable Property Column20 As DataGridViewTextBoxColumn

		' Token: 0x170066E3 RID: 26339
		' (get) Token: 0x060109BD RID: 68029 RVA: 0x00072987 File Offset: 0x00070B87
		' (set) Token: 0x060109BE RID: 68030 RVA: 0x00072991 File Offset: 0x00070B91
		Friend Overridable Property Column21 As DataGridViewTextBoxColumn

		' Token: 0x170066E4 RID: 26340
		' (get) Token: 0x060109BF RID: 68031 RVA: 0x0007299A File Offset: 0x00070B9A
		' (set) Token: 0x060109C0 RID: 68032 RVA: 0x000729A4 File Offset: 0x00070BA4
		Friend Overridable Property Column23 As DataGridViewTextBoxColumn

		' Token: 0x170066E5 RID: 26341
		' (get) Token: 0x060109C1 RID: 68033 RVA: 0x000729AD File Offset: 0x00070BAD
		' (set) Token: 0x060109C2 RID: 68034 RVA: 0x000729B7 File Offset: 0x00070BB7
		Friend Overridable Property Column24 As DataGridViewTextBoxColumn

		' Token: 0x170066E6 RID: 26342
		' (get) Token: 0x060109C3 RID: 68035 RVA: 0x000729C0 File Offset: 0x00070BC0
		' (set) Token: 0x060109C4 RID: 68036 RVA: 0x000729CA File Offset: 0x00070BCA
		Friend Overridable Property Column29 As DataGridViewTextBoxColumn

		' Token: 0x170066E7 RID: 26343
		' (get) Token: 0x060109C5 RID: 68037 RVA: 0x000729D3 File Offset: 0x00070BD3
		' (set) Token: 0x060109C6 RID: 68038 RVA: 0x000729DD File Offset: 0x00070BDD
		Friend Overridable Property Column34 As DataGridViewTextBoxColumn

		' Token: 0x170066E8 RID: 26344
		' (get) Token: 0x060109C7 RID: 68039 RVA: 0x000729E6 File Offset: 0x00070BE6
		' (set) Token: 0x060109C8 RID: 68040 RVA: 0x000729F0 File Offset: 0x00070BF0
		Friend Overridable Property Column43 As DataGridViewTextBoxColumn

		' Token: 0x170066E9 RID: 26345
		' (get) Token: 0x060109C9 RID: 68041 RVA: 0x000729F9 File Offset: 0x00070BF9
		' (set) Token: 0x060109CA RID: 68042 RVA: 0x00072A03 File Offset: 0x00070C03
		Friend Overridable Property Column44 As DataGridViewTextBoxColumn

		' Token: 0x170066EA RID: 26346
		' (get) Token: 0x060109CB RID: 68043 RVA: 0x00072A0C File Offset: 0x00070C0C
		' (set) Token: 0x060109CC RID: 68044 RVA: 0x00072A16 File Offset: 0x00070C16
		Friend Overridable Property Column45 As DataGridViewTextBoxColumn

		' Token: 0x170066EB RID: 26347
		' (get) Token: 0x060109CD RID: 68045 RVA: 0x00072A1F File Offset: 0x00070C1F
		' (set) Token: 0x060109CE RID: 68046 RVA: 0x00072A29 File Offset: 0x00070C29
		Friend Overridable Property Column46 As DataGridViewTextBoxColumn

		' Token: 0x170066EC RID: 26348
		' (get) Token: 0x060109CF RID: 68047 RVA: 0x00072A32 File Offset: 0x00070C32
		' (set) Token: 0x060109D0 RID: 68048 RVA: 0x00072A3C File Offset: 0x00070C3C
		Friend Overridable Property Column47 As DataGridViewTextBoxColumn

		' Token: 0x170066ED RID: 26349
		' (get) Token: 0x060109D1 RID: 68049 RVA: 0x00072A45 File Offset: 0x00070C45
		' (set) Token: 0x060109D2 RID: 68050 RVA: 0x00072A4F File Offset: 0x00070C4F
		Friend Overridable Property Column48 As DataGridViewTextBoxColumn

		' Token: 0x170066EE RID: 26350
		' (get) Token: 0x060109D3 RID: 68051 RVA: 0x00072A58 File Offset: 0x00070C58
		' (set) Token: 0x060109D4 RID: 68052 RVA: 0x00072A62 File Offset: 0x00070C62
		Friend Overridable Property Column50 As DataGridViewTextBoxColumn

		' Token: 0x170066EF RID: 26351
		' (get) Token: 0x060109D5 RID: 68053 RVA: 0x00072A6B File Offset: 0x00070C6B
		' (set) Token: 0x060109D6 RID: 68054 RVA: 0x00072A75 File Offset: 0x00070C75
		Friend Overridable Property Column51 As DataGridViewTextBoxColumn

		' Token: 0x170066F0 RID: 26352
		' (get) Token: 0x060109D7 RID: 68055 RVA: 0x00072A7E File Offset: 0x00070C7E
		' (set) Token: 0x060109D8 RID: 68056 RVA: 0x00072A88 File Offset: 0x00070C88
		Friend Overridable Property Column54 As DataGridViewTextBoxColumn

		' Token: 0x170066F1 RID: 26353
		' (get) Token: 0x060109D9 RID: 68057 RVA: 0x00072A91 File Offset: 0x00070C91
		' (set) Token: 0x060109DA RID: 68058 RVA: 0x00072A9B File Offset: 0x00070C9B
		Friend Overridable Property Column66 As DataGridViewTextBoxColumn

		' Token: 0x170066F2 RID: 26354
		' (get) Token: 0x060109DB RID: 68059 RVA: 0x00072AA4 File Offset: 0x00070CA4
		' (set) Token: 0x060109DC RID: 68060 RVA: 0x00072AAE File Offset: 0x00070CAE
		Friend Overridable Property Column67 As DataGridViewTextBoxColumn

		' Token: 0x060109DD RID: 68061 RVA: 0x009B3AF0 File Offset: 0x009B1CF0
		Private Sub auto()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT MAX(SA_ID) FROM StockAdjustment_Store"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
				If flag Then
					Dim num As Integer = 1
					Me.txtAdjustmentID.Text = num.ToString()
				Else
					Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
					Me.txtAdjustmentID.Text = num.ToString()
				End If
				ModCommonClasses.cmd.Dispose()
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060109DE RID: 68062 RVA: 0x009B3BF4 File Offset: 0x009B1DF4
		Public Sub Reset()
			Me.txtBarcode.Text = ""
			Me.txtProductName.Text = ""
			Me.rbPlus.Checked = True
			Me.rbMinus.Checked = False
			Me.txtReason.Text = ""
			Me.txtQty.Text = ""
			Me.txtQ.Text = ""
			Me.txtProductID.Text = ""
			Me.txtProductCode.Text = ""
			Me.lblQty_S.Visible = False
			Me.dtpDate.Value = DateAndTime.Today
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtBarcode.Enabled = True
			Me.txtProductName.Enabled = True
			Me.gbAdjustment.Enabled = True
			Me.auto()
		End Sub

		' Token: 0x060109DF RID: 68063 RVA: 0x009B3D08 File Offset: 0x009B1F08
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from StockAdjustment_Store where SA_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtAdjustmentID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim checked As Boolean = Me.rbPlus.Checked
					If checked Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Update Temp_Stock set qty=qty - " + Conversions.ToString(Conversion.Val(Me.txtQty.Text)) + " where ProductID=@d1 and Barcode=@d2"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
					Dim checked2 As Boolean = Me.rbMinus.Checked
					If checked2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text3 As String = "Update Temp_Stock set qty=qty + " + Conversions.ToString(Conversion.Val(Me.txtQty.Text)) + " where ProductID=@d1 and Barcode=@d2"
						ModCommonClasses.cmd = New SqlCommand(text3)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text4 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
					ModCommonClasses.cmd = New SqlCommand(text4)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
					ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
					If flag2 Then
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text5 As String = "delete from StockMovement where ProductID=@d1 and TransID=@d2"
						ModCommonClasses.cmd = New SqlCommand(text5)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
					End If
					ModFunc.LogFunc(Me.lblUser.Text, "Deleted the Stock Adjustment(S) record having adjustment id '" + Me.txtAdjustmentID.Text + "'")
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
					ModFunc.RefreshRecords()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060109E0 RID: 68064 RVA: 0x00072AB7 File Offset: 0x00070CB7
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060109E1 RID: 68065 RVA: 0x009B414C File Offset: 0x009B234C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.auto()
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtProductName.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtProductName.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please Enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtBarcode.Focus()
					Else
						Dim flag5 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
						If flag5 Then
							MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtQty.Focus()
						Else
							Dim flag6 As Boolean = Conversion.Val(Conversions.ToDouble(Me.txtQty.Text) = 0.0) <> 0.0
							If flag6 Then
								MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtQty.Focus()
							Else
								Dim flag7 As Boolean = Operators.CompareString(Me.txtReason.Text, "", False) = 0
								If flag7 Then
									MessageBox.Show("Please enter reason", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtReason.Focus()
								Else
									Try
										Dim checked As Boolean = Me.rbPlus.Checked
										If checked Then
											Me.str = Me.rbPlus.Text
										Else
											Me.str = Me.rbMinus.Text
										End If
										Me.auto()
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = "insert into StockAdjustment_Store(SA_ID, ProductID, Barcode, Date, AdjustmentType, Qty, Reason) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtAdjustmentID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.str)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtQty.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtReason.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
										Dim checked2 As Boolean = Me.rbPlus.Checked
										If checked2 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text3 As String = "Update Temp_Stock set qty=qty + " + Conversions.ToString(Conversion.Val(Me.txtQty.Text)) + " where ProductID=@d1 and Barcode=@d2"
											ModCommonClasses.cmd = New SqlCommand(text3)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
										End If
										Dim checked3 As Boolean = Me.rbMinus.Checked
										If checked3 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text4 As String = "Update Temp_Stock set qty=qty - " + Conversions.ToString(Conversion.Val(Me.txtQty.Text)) + " where ProductID=@d1 and Barcode=@d2"
											ModCommonClasses.cmd = New SqlCommand(text4)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
										End If
										Dim checked4 As Boolean = Me.rbPlus.Checked
										If checked4 Then
											Dim flag8 As Boolean = Conversion.Val(Me.txtQty.Text) > 0.0
											If flag8 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text5 As String = "select ProductID from StockMovement where ProductID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text5)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag9 As Boolean = Not ModCommonClasses.rdr.Read()
												If flag9 Then
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtProductID.Text))), 0D, New Decimal(Conversion.Val(Me.txtQty.Text)), 0D, Me.dtpDate.Value.[Date], Me.TextBox1.Text)
												Else
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text6 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
													ModCommonClasses.cmd = New SqlCommand(text6)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag10 As Boolean = ModCommonClasses.rdr.Read()
													Dim num As Double
													If flag10 Then
														num = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
													Else
														num = 0.0
													End If
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtProductID.Text))), New Decimal(num), New Decimal(Conversion.Val(Me.txtQty.Text)), 0D, Me.dtpDate.Value.[Date], Me.TextBox1.Text)
												End If
												ModCommonClasses.con.Close()
											End If
										End If
										Dim checked5 As Boolean = Me.rbMinus.Checked
										If checked5 Then
											Dim flag11 As Boolean = Conversion.Val(Me.txtQty.Text) > 0.0
											If flag11 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text7 As String = "select ProductID from StockMovement where ProductID=@d1"
												ModCommonClasses.cmd = New SqlCommand(text7)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag12 As Boolean = Not ModCommonClasses.rdr.Read()
												If flag12 Then
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtProductID.Text))), 0D, 0D, New Decimal(Conversion.Val(Me.txtQty.Text)), Me.dtpDate.Value.[Date], Me.TextBox1.Text)
												Else
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text8 As String = "select IsNULL(Sum(StockIN-StockOUT),0) from StockMovement where ProductID=@d1 and Date < @d3"
													ModCommonClasses.cmd = New SqlCommand(text8)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.dtpDate.Value.[Date])
													ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
													Dim flag13 As Boolean = ModCommonClasses.rdr.Read()
													Dim num2 As Double
													If flag13 Then
														num2 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
													Else
														num2 = 0.0
													End If
													ModFunc.ProductSMSave(CInt(Math.Round(Conversion.Val(Me.txtProductID.Text))), New Decimal(num2), 0D, New Decimal(Conversion.Val(Me.txtQty.Text)), Me.dtpDate.Value.[Date], Me.TextBox1.Text)
												End If
												ModCommonClasses.con.Close()
											End If
										End If
										ModFunc.LogFunc(Me.lblUser.Text, "added the new Stock Adjustment(S) record having adjustment id '" + Me.txtAdjustmentID.Text + "'")
										MessageBox.Show("Successfully adjusted", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnSave.Enabled = False
										ModCommonClasses.con.Close()
										Me.Reset()
										ModFunc.RefreshRecords()
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

		' Token: 0x060109E2 RID: 68066 RVA: 0x009B4C14 File Offset: 0x009B2E14
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

		' Token: 0x060109E3 RID: 68067 RVA: 0x009B4C7C File Offset: 0x009B2E7C
		Public Sub GetQty_S()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "Select IsNull(Sum(Qty),0) from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and ProductID=@d1 and Temp_Stock.Barcode=@d2 group by ProductID,Temp_Stock.Barcode"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
				ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.lblQty_S.Visible = True
					Me.lblQty_S.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				Else
					Me.lblQty_S.Visible = True
					Me.lblQty_S.Text = "0.00"
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

		' Token: 0x060109E4 RID: 68068 RVA: 0x009B4DF0 File Offset: 0x009B2FF0
		Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs)
			Try
				Me.strType = "barcode"
				Dim flag As Boolean = e.KeyCode = Keys.[Return]
				If flag Then
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
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
						ModCommonClasses.cmd.CommandText = "SELECT PID,RTRIM(ProductCode),RTRIM(ProductName) from Product,Temp_Stock where Product.PID=Temp_Stock.ProductID and Temp_Stock.Barcode=@d1"
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtBarcode.Text)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
						If flag4 Then
							Me.txtProductID.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
							Me.txtProductCode.Text = ModCommonClasses.rdr.GetValue(1).ToString()
							Me.txtProductName.Text = ModCommonClasses.rdr.GetValue(2).ToString()
							Me.txtQty.Focus()
							Me.GetQty_S()
						End If
						Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag5 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag6 Then
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060109E5 RID: 68069 RVA: 0x00072AC1 File Offset: 0x00070CC1
		Private Sub btnScanBarcode_Click(sender As Object, e As EventArgs)
			Me.txtBarcode.Focus()
		End Sub

		' Token: 0x060109E6 RID: 68070 RVA: 0x009A8308 File Offset: 0x009A6508
		Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
			Dim flag2 As Boolean = Conversions.ToBoolean(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, Nothing, "text", New Object(-1) {}, Nothing, Nothing, Nothing), Nothing, "contains", New Object() { "." }, Nothing, Nothing, Nothing))
			If flag2 Then
				Dim flag3 As Boolean = Operators.CompareString(Conversions.ToString(e.KeyChar), ".", False) = 0
				If flag3 Then
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x060109E7 RID: 68071 RVA: 0x00072AD0 File Offset: 0x00070CD0
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060109E8 RID: 68072 RVA: 0x009B500C File Offset: 0x009B320C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtProductName.Text)) = 0
			If flag Then
				MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtProductName.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtBarcode.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please Enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtBarcode.Focus()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.txtQty.Text, "", False) = 0
					If flag3 Then
						MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtQty.Focus()
					Else
						Dim flag4 As Boolean = Conversion.Val(Conversions.ToDouble(Me.txtQty.Text) = 0.0) <> 0.0
						If flag4 Then
							MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtQty.Focus()
						Else
							Dim flag5 As Boolean = Operators.CompareString(Me.txtReason.Text, "", False) = 0
							If flag5 Then
								MessageBox.Show("Please enter reason", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtReason.Focus()
							Else
								Try
									Dim checked As Boolean = Me.rbPlus.Checked
									If checked Then
										Me.str = Me.rbPlus.Text
									Else
										Me.str = Me.rbMinus.Text
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text As String = "Update StockAdjustment_Store set ProductID=@d2, Barcode=@d3, Date=@d4, AdjustmentType=@d5, Qty=@d6, Reason=@d7 where SA_ID=@d1"
									ModCommonClasses.cmd = New SqlCommand(text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtAdjustmentID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtProductID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtBarcode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.dtpDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.str)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.txtQty.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtReason.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteNonQuery()
									ModCommonClasses.con.Close()
									Dim checked2 As Boolean = Me.rbPlus.Checked
									If checked2 Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text2 As String = String.Concat(New String() { "Update Temp_Stock set qty=qty + ( ", Conversions.ToString(Conversion.Val(Me.txtQty.Text)), " - ", Conversions.ToString(Conversion.Val(Me.txtQ.Text)), ") where ProductID=@d1 and Barcode=@d2" })
										ModCommonClasses.cmd = New SqlCommand(text2)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
									End If
									Dim checked3 As Boolean = Me.rbMinus.Checked
									If checked3 Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = String.Concat(New String() { "Update Temp_Stock set qty=qty - ( ", Conversions.ToString(Conversion.Val(Me.txtQty.Text)), " - ", Conversions.ToString(Conversion.Val(Me.txtQ.Text)), ") where ProductID=@d1 and Barcode=@d2" })
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtBarcode.Text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteNonQuery()
										ModCommonClasses.con.Close()
									End If
									Dim checked4 As Boolean = Me.rbPlus.Checked
									If checked4 Then
										Dim flag6 As Boolean = Conversion.Val(Me.txtQty.Text) > 0.0
										If flag6 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text4 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
											ModCommonClasses.cmd = New SqlCommand(text4)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
											If flag7 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text5 As String = "Update StockMovement set StockIn=@d1, Date=@d2 where ProductID=@d4 and TransID=@d3"
												ModCommonClasses.cmd = New SqlCommand(text5)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQty.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtProductID.Text))
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
											End If
										End If
									End If
									Dim checked5 As Boolean = Me.rbMinus.Checked
									If checked5 Then
										Dim flag8 As Boolean = Conversion.Val(Me.txtQty.Text) > 0.0
										If flag8 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "select ProductID from StockMovement where ProductID=@d1 and TransID=@d2"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtProductID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.TextBox1.Text)
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag9 As Boolean = ModCommonClasses.rdr.Read()
											If flag9 Then
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text7 As String = "Update StockMovement set StockOUT=@d1, Date=@d2 where ProductID=@d4 and TransID=@d3"
												ModCommonClasses.cmd = New SqlCommand(text7)
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtQty.Text))
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.dtpDate.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.TextBox1.Text)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtProductID.Text))
												ModCommonClasses.cmd.ExecuteReader()
												ModCommonClasses.con.Close()
											End If
										End If
									End If
									ModFunc.LogFunc(Me.lblUser.Text, "Updated the Stock Adjustment(S) record having adjustment id '" + Me.txtAdjustmentID.Text + "'")
									MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnUpdate.Enabled = False
									ModCommonClasses.con.Close()
									ModFunc.RefreshRecords()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060109E9 RID: 68073 RVA: 0x009B596C File Offset: 0x009B3B6C
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmStockAdjustment_Store_Record.lblSet.Text = "SA"
			MyProject.Forms.frmStockAdjustment_Store_Record.Reset()
			MyProject.Forms.frmStockAdjustment_Store_Record.ShowDialog()
			MyProject.Forms.frmStockAdjustment_Store_Record.Dispose()
		End Sub

		' Token: 0x060109EA RID: 68074 RVA: 0x00072AEC File Offset: 0x00070CEC
		Private Sub frmStockAdjustment_Store_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.Convert_Language()
		End Sub

		' Token: 0x060109EB RID: 68075 RVA: 0x009B59C4 File Offset: 0x009B3BC4
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

		' Token: 0x060109EC RID: 68076 RVA: 0x009B5B3C File Offset: 0x009B3D3C
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

		' Token: 0x060109ED RID: 68077 RVA: 0x009B5BF8 File Offset: 0x009B3DF8
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

		' Token: 0x060109EE RID: 68078 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060109EF RID: 68079 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060109F0 RID: 68080 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060109F1 RID: 68081 RVA: 0x009B5CC4 File Offset: 0x009B3EC4
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
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

		' Token: 0x060109F2 RID: 68082 RVA: 0x009B5DBC File Offset: 0x009B3FBC
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

		' Token: 0x060109F3 RID: 68083 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060109F4 RID: 68084 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060109F5 RID: 68085 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtReason_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x060109F6 RID: 68086 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmStockAdjustment_Store_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060109F7 RID: 68087 RVA: 0x009B5E68 File Offset: 0x009B4068
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Text = "SA-" + Conversion.Val(Me.txtAdjustmentID.Text).ToString() + "-Y"
		End Sub

		' Token: 0x060109F8 RID: 68088 RVA: 0x009B5E68 File Offset: 0x009B4068
		Private Sub txtAdjustmentID_TextChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Text = "SA-" + Conversion.Val(Me.txtAdjustmentID.Text).ToString() + "-Y"
		End Sub

		' Token: 0x060109F9 RID: 68089 RVA: 0x009B5EAC File Offset: 0x009B40AC
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtReason.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtReason, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtReason, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtQty.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtQty, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtQty, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtProductName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtProductName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtProductName, String.Empty)
			End If
		End Sub

		' Token: 0x060109FA RID: 68090 RVA: 0x009B5FA0 File Offset: 0x009B41A0
		Private Sub txtProductName_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.strType, "barcode", False) = 0
			If flag Then
				Me.dgw4.Visible = False
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtProductName.Text.TrimEnd(New Char(-1) {}), "", False) > 0
				If flag2 Then
					Me.getgriditemdata()
				Else
					Me.dgw4.Visible = False
				End If
			End If
			Me.strType = ""
		End Sub

		' Token: 0x060109FB RID: 68091 RVA: 0x009B6024 File Offset: 0x009B4224
		Private Sub getgriditemdata()
			Try
				Me.dgw4.Visible = True
				Me.dgw4.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
				Me.dgw4.RowHeadersVisible = False
				Me.dgw4.Columns(24).Visible = True
				Me.dgw4.Columns(26).Visible = True
				Me.dgw4.Columns(27).Visible = True
				Me.dgw4.Columns(28).Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 5 PID, RTRIM(Product.ProductCode),RTRIM(ProductName),RTRIM(HSNCode),RTRIM(PartNo),RTRIM(Temp_Stock.Barcode),(Temp_Stock.EPPrice),(Temp_Stock.SPrice),(Discount),CGST,SGST,CESS,Qty,RTRIM(SalesUnit),(Temp_Stock.WPrice),(Temp_Stock.EPPrice),RTRIM(SalesAltUnit),RTRIM(Conv),RTRIM(Product.LastPrice),RTRIM(Temp_Stock.Damage),RTRIM(Product.Description),RTRIM(Product.MinStock),(Temp_Stock.MRP),RTRIM(Product.STax),RTRIM(Temp_Stock.Batch),RTRIM(Temp_Stock.Mfgdate),RTRIM(Temp_Stock.Expdate),RTRIM(Temp_Stock.Size),RTRIM(Temp_Stock.Colour),RTRIM(Product.DefQty),RTRIM(Temp_Stock.IMEI1),RTRIM(Temp_Stock.IMEI2),RTRIM(Temp_Stock.SalesManPur),RTRIM(Product.loyality_mode), isnull(RTRIM(Product.loyality_value),0) from Temp_Stock,Product where Product.PID=Temp_Stock.ProductID and Product.Status='Yes' and ProductName like N'" + Me.txtProductName.Text + "%' order by ProductName", ModCommonClasses.con)
				Dim sqlDataReader As SqlDataReader = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw4.Rows.Clear()
				While sqlDataReader.Read()
					Me.dgw4.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8), sqlDataReader(9), sqlDataReader(10), sqlDataReader(11), sqlDataReader(12), sqlDataReader(13), sqlDataReader(14), sqlDataReader(15), sqlDataReader(16), sqlDataReader(17), sqlDataReader(18), sqlDataReader(19), sqlDataReader(20), sqlDataReader(21), sqlDataReader(22), sqlDataReader(23), sqlDataReader(24), sqlDataReader(25), sqlDataReader(26), sqlDataReader(27), sqlDataReader(28), sqlDataReader(29), sqlDataReader(30), sqlDataReader(31), sqlDataReader(32), sqlDataReader(33), sqlDataReader(34) })
				End While
				sqlDataReader.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060109FC RID: 68092 RVA: 0x009B6320 File Offset: 0x009B4520
		Private Sub txtProductName_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Operators.CompareString(Me.txtProductName.Text, "", False) = 0
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

		' Token: 0x060109FD RID: 68093 RVA: 0x009B642C File Offset: 0x009B462C
		Private Sub txtProductName_KeyUp(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Down
			If flag Then
				Dim visible As Boolean = Me.dgw4.Visible
				If visible Then
					Me.dgw4.Focus()
					SendKeys.Send("{DOWN}")
				End If
			End If
		End Sub

		' Token: 0x060109FE RID: 68094 RVA: 0x009B6474 File Offset: 0x009B4674
		Public Sub RetrieveData1()
			Try
				Dim dataGridViewRow As DataGridViewRow = Me.dgw4.SelectedRows(0)
				Me.txtProductID.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.txtProductCode.Text = dataGridViewRow.Cells(1).Value.ToString()
				Me.txtProductName.Text = dataGridViewRow.Cells(2).Value.ToString()
				Me.txtBarcode.Text = dataGridViewRow.Cells(5).Value.ToString()
				Me.txtQty.Focus()
				Me.GetQty_S()
				Me.dgw4.Visible = False
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060109FF RID: 68095 RVA: 0x00072AFD File Offset: 0x00070CFD
		Private Sub dgw4_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData1()
		End Sub

		' Token: 0x06010A00 RID: 68096 RVA: 0x009B6560 File Offset: 0x009B4760
		Private Sub dgw4_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData1()
			End If
		End Sub

		' Token: 0x0400643F RID: 25663
		Private str As String

		' Token: 0x04006440 RID: 25664
		Private strType As String
	End Class
End Namespace
