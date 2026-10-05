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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005D1 RID: 1489
	<DesignerGenerated()>
	Public Partial Class frmServicesRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012280 RID: 74368 RVA: 0x0007C86F File Offset: 0x0007AA6F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServicesRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170070C3 RID: 28867
		' (get) Token: 0x06012283 RID: 74371 RVA: 0x0007C8A1 File Offset: 0x0007AAA1
		' (set) Token: 0x06012284 RID: 74372 RVA: 0x0007C8AB File Offset: 0x0007AAAB
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170070C4 RID: 28868
		' (get) Token: 0x06012285 RID: 74373 RVA: 0x0007C8B4 File Offset: 0x0007AAB4
		' (set) Token: 0x06012286 RID: 74374 RVA: 0x0007C8BE File Offset: 0x0007AABE
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170070C5 RID: 28869
		' (get) Token: 0x06012287 RID: 74375 RVA: 0x0007C8C7 File Offset: 0x0007AAC7
		' (set) Token: 0x06012288 RID: 74376 RVA: 0x0007C8D1 File Offset: 0x0007AAD1
		Friend Overridable Property Label1 As Label

		' Token: 0x170070C6 RID: 28870
		' (get) Token: 0x06012289 RID: 74377 RVA: 0x0007C8DA File Offset: 0x0007AADA
		' (set) Token: 0x0601228A RID: 74378 RVA: 0x00A73470 File Offset: 0x00A71670
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170070C7 RID: 28871
		' (get) Token: 0x0601228B RID: 74379 RVA: 0x0007C8E4 File Offset: 0x0007AAE4
		' (set) Token: 0x0601228C RID: 74380 RVA: 0x0007C8EE File Offset: 0x0007AAEE
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170070C8 RID: 28872
		' (get) Token: 0x0601228D RID: 74381 RVA: 0x0007C8F7 File Offset: 0x0007AAF7
		' (set) Token: 0x0601228E RID: 74382 RVA: 0x0007C901 File Offset: 0x0007AB01
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170070C9 RID: 28873
		' (get) Token: 0x0601228F RID: 74383 RVA: 0x0007C90A File Offset: 0x0007AB0A
		' (set) Token: 0x06012290 RID: 74384 RVA: 0x0007C914 File Offset: 0x0007AB14
		Friend Overridable Property Label2 As Label

		' Token: 0x170070CA RID: 28874
		' (get) Token: 0x06012291 RID: 74385 RVA: 0x0007C91D File Offset: 0x0007AB1D
		' (set) Token: 0x06012292 RID: 74386 RVA: 0x0007C927 File Offset: 0x0007AB27
		Friend Overridable Property Label4 As Label

		' Token: 0x170070CB RID: 28875
		' (get) Token: 0x06012293 RID: 74387 RVA: 0x0007C930 File Offset: 0x0007AB30
		' (set) Token: 0x06012294 RID: 74388 RVA: 0x0007C93A File Offset: 0x0007AB3A
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170070CC RID: 28876
		' (get) Token: 0x06012295 RID: 74389 RVA: 0x0007C943 File Offset: 0x0007AB43
		' (set) Token: 0x06012296 RID: 74390 RVA: 0x00A734D0 File Offset: 0x00A716D0
		Private _cmbServiceCode As ComboBox
		Friend Overridable Property cmbServiceCode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbServiceCode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbOrderNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbInvoiceNo_Format
				Dim comboBox As ComboBox = Me._cmbServiceCode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbServiceCode = value
				comboBox = Me._cmbServiceCode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x170070CD RID: 28877
		' (get) Token: 0x06012297 RID: 74391 RVA: 0x0007C94D File Offset: 0x0007AB4D
		' (set) Token: 0x06012298 RID: 74392 RVA: 0x0007C957 File Offset: 0x0007AB57
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170070CE RID: 28878
		' (get) Token: 0x06012299 RID: 74393 RVA: 0x0007C960 File Offset: 0x0007AB60
		' (set) Token: 0x0601229A RID: 74394 RVA: 0x0007C96A File Offset: 0x0007AB6A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170070CF RID: 28879
		' (get) Token: 0x0601229B RID: 74395 RVA: 0x0007C973 File Offset: 0x0007AB73
		' (set) Token: 0x0601229C RID: 74396 RVA: 0x0007C97D File Offset: 0x0007AB7D
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170070D0 RID: 28880
		' (get) Token: 0x0601229D RID: 74397 RVA: 0x0007C986 File Offset: 0x0007AB86
		' (set) Token: 0x0601229E RID: 74398 RVA: 0x0007C990 File Offset: 0x0007AB90
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x170070D1 RID: 28881
		' (get) Token: 0x0601229F RID: 74399 RVA: 0x0007C999 File Offset: 0x0007AB99
		' (set) Token: 0x060122A0 RID: 74400 RVA: 0x0007C9A3 File Offset: 0x0007ABA3
		Friend Overridable Property Label3 As Label

		' Token: 0x170070D2 RID: 28882
		' (get) Token: 0x060122A1 RID: 74401 RVA: 0x0007C9AC File Offset: 0x0007ABAC
		' (set) Token: 0x060122A2 RID: 74402 RVA: 0x0007C9B6 File Offset: 0x0007ABB6
		Friend Overridable Property Label5 As Label

		' Token: 0x170070D3 RID: 28883
		' (get) Token: 0x060122A3 RID: 74403 RVA: 0x0007C9BF File Offset: 0x0007ABBF
		' (set) Token: 0x060122A4 RID: 74404 RVA: 0x0007C9C9 File Offset: 0x0007ABC9
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x170070D4 RID: 28884
		' (get) Token: 0x060122A5 RID: 74405 RVA: 0x0007C9D2 File Offset: 0x0007ABD2
		' (set) Token: 0x060122A6 RID: 74406 RVA: 0x0007C9DC File Offset: 0x0007ABDC
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170070D5 RID: 28885
		' (get) Token: 0x060122A7 RID: 74407 RVA: 0x0007C9E5 File Offset: 0x0007ABE5
		' (set) Token: 0x060122A8 RID: 74408 RVA: 0x00A73530 File Offset: 0x00A71730
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170070D6 RID: 28886
		' (get) Token: 0x060122A9 RID: 74409 RVA: 0x0007C9EF File Offset: 0x0007ABEF
		' (set) Token: 0x060122AA RID: 74410 RVA: 0x0007C9F9 File Offset: 0x0007ABF9
		Friend Overridable Property lblSet As Label

		' Token: 0x170070D7 RID: 28887
		' (get) Token: 0x060122AB RID: 74411 RVA: 0x0007CA02 File Offset: 0x0007AC02
		' (set) Token: 0x060122AC RID: 74412 RVA: 0x0007CA0C File Offset: 0x0007AC0C
		Friend Overridable Property Label6 As Label

		' Token: 0x170070D8 RID: 28888
		' (get) Token: 0x060122AD RID: 74413 RVA: 0x0007CA15 File Offset: 0x0007AC15
		' (set) Token: 0x060122AE RID: 74414 RVA: 0x0007CA1F File Offset: 0x0007AC1F
		Friend Overridable Property cmbStatus As ComboBox

		' Token: 0x170070D9 RID: 28889
		' (get) Token: 0x060122AF RID: 74415 RVA: 0x0007CA28 File Offset: 0x0007AC28
		' (set) Token: 0x060122B0 RID: 74416 RVA: 0x0007CA32 File Offset: 0x0007AC32
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170070DA RID: 28890
		' (get) Token: 0x060122B1 RID: 74417 RVA: 0x0007CA3B File Offset: 0x0007AC3B
		' (set) Token: 0x060122B2 RID: 74418 RVA: 0x0007CA45 File Offset: 0x0007AC45
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170070DB RID: 28891
		' (get) Token: 0x060122B3 RID: 74419 RVA: 0x0007CA4E File Offset: 0x0007AC4E
		' (set) Token: 0x060122B4 RID: 74420 RVA: 0x0007CA58 File Offset: 0x0007AC58
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170070DC RID: 28892
		' (get) Token: 0x060122B5 RID: 74421 RVA: 0x0007CA61 File Offset: 0x0007AC61
		' (set) Token: 0x060122B6 RID: 74422 RVA: 0x0007CA6B File Offset: 0x0007AC6B
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170070DD RID: 28893
		' (get) Token: 0x060122B7 RID: 74423 RVA: 0x0007CA74 File Offset: 0x0007AC74
		' (set) Token: 0x060122B8 RID: 74424 RVA: 0x0007CA7E File Offset: 0x0007AC7E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170070DE RID: 28894
		' (get) Token: 0x060122B9 RID: 74425 RVA: 0x0007CA87 File Offset: 0x0007AC87
		' (set) Token: 0x060122BA RID: 74426 RVA: 0x0007CA91 File Offset: 0x0007AC91
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170070DF RID: 28895
		' (get) Token: 0x060122BB RID: 74427 RVA: 0x0007CA9A File Offset: 0x0007AC9A
		' (set) Token: 0x060122BC RID: 74428 RVA: 0x0007CAA4 File Offset: 0x0007ACA4
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170070E0 RID: 28896
		' (get) Token: 0x060122BD RID: 74429 RVA: 0x0007CAAD File Offset: 0x0007ACAD
		' (set) Token: 0x060122BE RID: 74430 RVA: 0x0007CAB7 File Offset: 0x0007ACB7
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170070E1 RID: 28897
		' (get) Token: 0x060122BF RID: 74431 RVA: 0x0007CAC0 File Offset: 0x0007ACC0
		' (set) Token: 0x060122C0 RID: 74432 RVA: 0x0007CACA File Offset: 0x0007ACCA
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170070E2 RID: 28898
		' (get) Token: 0x060122C1 RID: 74433 RVA: 0x0007CAD3 File Offset: 0x0007ACD3
		' (set) Token: 0x060122C2 RID: 74434 RVA: 0x0007CADD File Offset: 0x0007ACDD
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170070E3 RID: 28899
		' (get) Token: 0x060122C3 RID: 74435 RVA: 0x0007CAE6 File Offset: 0x0007ACE6
		' (set) Token: 0x060122C4 RID: 74436 RVA: 0x0007CAF0 File Offset: 0x0007ACF0
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170070E4 RID: 28900
		' (get) Token: 0x060122C5 RID: 74437 RVA: 0x0007CAF9 File Offset: 0x0007ACF9
		' (set) Token: 0x060122C6 RID: 74438 RVA: 0x0007CB03 File Offset: 0x0007AD03
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170070E5 RID: 28901
		' (get) Token: 0x060122C7 RID: 74439 RVA: 0x0007CB0C File Offset: 0x0007AD0C
		' (set) Token: 0x060122C8 RID: 74440 RVA: 0x0007CB16 File Offset: 0x0007AD16
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170070E6 RID: 28902
		' (get) Token: 0x060122C9 RID: 74441 RVA: 0x0007CB1F File Offset: 0x0007AD1F
		' (set) Token: 0x060122CA RID: 74442 RVA: 0x0007CB29 File Offset: 0x0007AD29
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170070E7 RID: 28903
		' (get) Token: 0x060122CB RID: 74443 RVA: 0x0007CB32 File Offset: 0x0007AD32
		' (set) Token: 0x060122CC RID: 74444 RVA: 0x0007CB3C File Offset: 0x0007AD3C
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170070E8 RID: 28904
		' (get) Token: 0x060122CD RID: 74445 RVA: 0x0007CB45 File Offset: 0x0007AD45
		' (set) Token: 0x060122CE RID: 74446 RVA: 0x0007CB4F File Offset: 0x0007AD4F
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x170070E9 RID: 28905
		' (get) Token: 0x060122CF RID: 74447 RVA: 0x0007CB58 File Offset: 0x0007AD58
		' (set) Token: 0x060122D0 RID: 74448 RVA: 0x0007CB62 File Offset: 0x0007AD62
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170070EA RID: 28906
		' (get) Token: 0x060122D1 RID: 74449 RVA: 0x0007CB6B File Offset: 0x0007AD6B
		' (set) Token: 0x060122D2 RID: 74450 RVA: 0x0007CB75 File Offset: 0x0007AD75
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x170070EB RID: 28907
		' (get) Token: 0x060122D3 RID: 74451 RVA: 0x0007CB7E File Offset: 0x0007AD7E
		' (set) Token: 0x060122D4 RID: 74452 RVA: 0x00A73574 File Offset: 0x00A71774
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

		' Token: 0x170070EC RID: 28908
		' (get) Token: 0x060122D5 RID: 74453 RVA: 0x0007CB88 File Offset: 0x0007AD88
		' (set) Token: 0x060122D6 RID: 74454 RVA: 0x00A735B8 File Offset: 0x00A717B8
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

		' Token: 0x170070ED RID: 28909
		' (get) Token: 0x060122D7 RID: 74455 RVA: 0x0007CB92 File Offset: 0x0007AD92
		' (set) Token: 0x060122D8 RID: 74456 RVA: 0x00A735FC File Offset: 0x00A717FC
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

		' Token: 0x170070EE RID: 28910
		' (get) Token: 0x060122D9 RID: 74457 RVA: 0x0007CB9C File Offset: 0x0007AD9C
		' (set) Token: 0x060122DA RID: 74458 RVA: 0x00A73640 File Offset: 0x00A71840
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

		' Token: 0x170070EF RID: 28911
		' (get) Token: 0x060122DB RID: 74459 RVA: 0x0007CBA6 File Offset: 0x0007ADA6
		' (set) Token: 0x060122DC RID: 74460 RVA: 0x00A73684 File Offset: 0x00A71884
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060122DD RID: 74461 RVA: 0x00A736C8 File Offset: 0x00A718C8
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
					Me.DateTimePicker2.Value = DateAndTime.Today
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

		' Token: 0x060122DE RID: 74462 RVA: 0x00A737AC File Offset: 0x00A719AC
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate, RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060122DF RID: 74463 RVA: 0x00A739E8 File Offset: 0x00A71BE8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.fillServiceCode()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x060122E0 RID: 74464 RVA: 0x00A73A88 File Offset: 0x00A71C88
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

		' Token: 0x060122E1 RID: 74465 RVA: 0x00A73D28 File Offset: 0x00A71F28
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

		' Token: 0x060122E2 RID: 74466 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060122E3 RID: 74467 RVA: 0x00A73DE4 File Offset: 0x00A71FE4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Services", False) = 0
					If flag2 Then
						MyProject.Forms.frmServices.Show()
						MyBase.Hide()
						MyProject.Forms.frmServices.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmServices.txtServiceCode.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmServices.dtpServiceCreationDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmServices.txtCID.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmServices.txtCustomerName.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmServices.cmbServiceType.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmServices.txtItemsDescription.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmServices.txtProblemDescription.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmServices.txtChargesQuote.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmServices.txtUpfront.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmServices.dtpEstimatedRepairDate.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmServices.txtRemarks.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmServices.cmbStatus.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmServices.txtContactNo.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmServices.btnSave.Enabled = False
						MyProject.Forms.frmServices.btnUpdate.Enabled = True
						MyProject.Forms.frmServices.btnPrint.Enabled = True
						MyProject.Forms.frmServices.btnDelete.Enabled = True
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x060122E4 RID: 74468 RVA: 0x00A7416C File Offset: 0x00A7236C
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

		' Token: 0x060122E5 RID: 74469 RVA: 0x00A74254 File Offset: 0x00A72454
		Public Sub fillServiceCode()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ServiceCode) FROM Service", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbServiceCode.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbServiceCode.Items.Add(dataRow(0).ToString())
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

		' Token: 0x060122E6 RID: 74470 RVA: 0x00A74388 File Offset: 0x00A72588
		Public Sub Reset()
			Me.cmbServiceCode.SelectedIndex = -1
			Me.cmbServiceCode.Text = ""
			Me.txtCustomerName.Text = ""
			Me.TextBox1.Text = ""
			Me.fillServiceCode()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
			Me.cmbStatus.SelectedIndex = -1
			Me.Getdata()
		End Sub

		' Token: 0x060122E7 RID: 74471 RVA: 0x00A7441C File Offset: 0x00A7261C
		Private Sub cmbOrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and ServiceCode='" + Me.cmbServiceCode.Text + "' and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060122E8 RID: 74472 RVA: 0x00A74684 File Offset: 0x00A72884
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbServiceCode.SelectedIndex = -1
				Me.cmbServiceCode.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate, RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and Name like N'" + Me.txtCustomerName.Text + "%' and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060122E9 RID: 74473 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbInvoiceNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x060122EA RID: 74474 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServicesRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060122EB RID: 74475 RVA: 0x00A748F8 File Offset: 0x00A72AF8
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column8").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x060122EC RID: 74476 RVA: 0x00A74A10 File Offset: 0x00A72C10
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate, RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and Service.Remarks like N'%" + Me.TextBox1.Text + "%' and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060122ED RID: 74477 RVA: 0x0007CBB0 File Offset: 0x0007ADB0
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x060122EE RID: 74478 RVA: 0x00A74C70 File Offset: 0x00A72E70
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

		' Token: 0x060122EF RID: 74479 RVA: 0x00A74F1C File Offset: 0x00A7311C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Operators.CompareString(Me.cmbStatus.Text, "", False) = 0) Or (Me.cmbStatus.SelectedIndex = -1)
				If flag Then
					MessageBox.Show("Please select status", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbStatus.Focus()
					Return
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks),RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and RTRIM(Service.Status)='" + Me.cmbStatus.Text + "'  and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x060122F0 RID: 74480 RVA: 0x00A751C4 File Offset: 0x00A733C4
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select S_ID, RTRIM(ServiceCode),ServiceCreationDate, Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ServiceType), RTRIM(ItemDescription), RTRIM(ProblemDescription), ChargesQuote, AdvanceDeposit, EstimatedRepairDate,RTRIM(Service.Remarks), RTRIM(Service.Status),RTRIM(Customer.ContactNo) from Customer,Service where Customer.ID=Service.CustomerID and ServiceCreationDate between @d1 and @d2 order by ServiceCreationDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub
	End Class
End Namespace
