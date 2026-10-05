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
	' Token: 0x02000577 RID: 1399
	<DesignerGenerated()>
	Public Partial Class frmCreditCustomerReceiptRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0601100E RID: 69646 RVA: 0x00075140 File Offset: 0x00073340
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCreditCustomerReceiptRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700697C RID: 27004
		' (get) Token: 0x06011011 RID: 69649 RVA: 0x00075172 File Offset: 0x00073372
		' (set) Token: 0x06011012 RID: 69650 RVA: 0x0007517C File Offset: 0x0007337C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x1700697D RID: 27005
		' (get) Token: 0x06011013 RID: 69651 RVA: 0x00075185 File Offset: 0x00073385
		' (set) Token: 0x06011014 RID: 69652 RVA: 0x0007518F File Offset: 0x0007338F
		Friend Overridable Property Panel2 As Panel

		' Token: 0x1700697E RID: 27006
		' (get) Token: 0x06011015 RID: 69653 RVA: 0x00075198 File Offset: 0x00073398
		' (set) Token: 0x06011016 RID: 69654 RVA: 0x000751A2 File Offset: 0x000733A2
		Friend Overridable Property Label1 As Label

		' Token: 0x1700697F RID: 27007
		' (get) Token: 0x06011017 RID: 69655 RVA: 0x000751AB File Offset: 0x000733AB
		' (set) Token: 0x06011018 RID: 69656 RVA: 0x009E02A0 File Offset: 0x009DE4A0
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

		' Token: 0x17006980 RID: 27008
		' (get) Token: 0x06011019 RID: 69657 RVA: 0x000751B5 File Offset: 0x000733B5
		' (set) Token: 0x0601101A RID: 69658 RVA: 0x000751BF File Offset: 0x000733BF
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006981 RID: 27009
		' (get) Token: 0x0601101B RID: 69659 RVA: 0x000751C8 File Offset: 0x000733C8
		' (set) Token: 0x0601101C RID: 69660 RVA: 0x009E031C File Offset: 0x009DE51C
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
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

		' Token: 0x17006982 RID: 27010
		' (get) Token: 0x0601101D RID: 69661 RVA: 0x000751D2 File Offset: 0x000733D2
		' (set) Token: 0x0601101E RID: 69662 RVA: 0x000751DC File Offset: 0x000733DC
		Friend Overridable Property Label3 As Label

		' Token: 0x17006983 RID: 27011
		' (get) Token: 0x0601101F RID: 69663 RVA: 0x000751E5 File Offset: 0x000733E5
		' (set) Token: 0x06011020 RID: 69664 RVA: 0x000751EF File Offset: 0x000733EF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006984 RID: 27012
		' (get) Token: 0x06011021 RID: 69665 RVA: 0x000751F8 File Offset: 0x000733F8
		' (set) Token: 0x06011022 RID: 69666 RVA: 0x00075202 File Offset: 0x00073402
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006985 RID: 27013
		' (get) Token: 0x06011023 RID: 69667 RVA: 0x0007520B File Offset: 0x0007340B
		' (set) Token: 0x06011024 RID: 69668 RVA: 0x00075215 File Offset: 0x00073415
		Friend Overridable Property Label2 As Label

		' Token: 0x17006986 RID: 27014
		' (get) Token: 0x06011025 RID: 69669 RVA: 0x0007521E File Offset: 0x0007341E
		' (set) Token: 0x06011026 RID: 69670 RVA: 0x00075228 File Offset: 0x00073428
		Friend Overridable Property Label4 As Label

		' Token: 0x17006987 RID: 27015
		' (get) Token: 0x06011027 RID: 69671 RVA: 0x00075231 File Offset: 0x00073431
		' (set) Token: 0x06011028 RID: 69672 RVA: 0x0007523B File Offset: 0x0007343B
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006988 RID: 27016
		' (get) Token: 0x06011029 RID: 69673 RVA: 0x00075244 File Offset: 0x00073444
		' (set) Token: 0x0601102A RID: 69674 RVA: 0x0007524E File Offset: 0x0007344E
		Friend Overridable Property lblSet As Label

		' Token: 0x17006989 RID: 27017
		' (get) Token: 0x0601102B RID: 69675 RVA: 0x00075257 File Offset: 0x00073457
		' (set) Token: 0x0601102C RID: 69676 RVA: 0x00075261 File Offset: 0x00073461
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700698A RID: 27018
		' (get) Token: 0x0601102D RID: 69677 RVA: 0x0007526A File Offset: 0x0007346A
		' (set) Token: 0x0601102E RID: 69678 RVA: 0x00075274 File Offset: 0x00073474
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x1700698B RID: 27019
		' (get) Token: 0x0601102F RID: 69679 RVA: 0x0007527D File Offset: 0x0007347D
		' (set) Token: 0x06011030 RID: 69680 RVA: 0x00075287 File Offset: 0x00073487
		Friend Overridable Property Label5 As Label

		' Token: 0x1700698C RID: 27020
		' (get) Token: 0x06011031 RID: 69681 RVA: 0x00075290 File Offset: 0x00073490
		' (set) Token: 0x06011032 RID: 69682 RVA: 0x0007529A File Offset: 0x0007349A
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x1700698D RID: 27021
		' (get) Token: 0x06011033 RID: 69683 RVA: 0x000752A3 File Offset: 0x000734A3
		' (set) Token: 0x06011034 RID: 69684 RVA: 0x000752AD File Offset: 0x000734AD
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700698E RID: 27022
		' (get) Token: 0x06011035 RID: 69685 RVA: 0x000752B6 File Offset: 0x000734B6
		' (set) Token: 0x06011036 RID: 69686 RVA: 0x000752C0 File Offset: 0x000734C0
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x1700698F RID: 27023
		' (get) Token: 0x06011037 RID: 69687 RVA: 0x000752C9 File Offset: 0x000734C9
		' (set) Token: 0x06011038 RID: 69688 RVA: 0x000752D3 File Offset: 0x000734D3
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006990 RID: 27024
		' (get) Token: 0x06011039 RID: 69689 RVA: 0x000752DC File Offset: 0x000734DC
		' (set) Token: 0x0601103A RID: 69690 RVA: 0x000752E6 File Offset: 0x000734E6
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006991 RID: 27025
		' (get) Token: 0x0601103B RID: 69691 RVA: 0x000752EF File Offset: 0x000734EF
		' (set) Token: 0x0601103C RID: 69692 RVA: 0x000752F9 File Offset: 0x000734F9
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006992 RID: 27026
		' (get) Token: 0x0601103D RID: 69693 RVA: 0x00075302 File Offset: 0x00073502
		' (set) Token: 0x0601103E RID: 69694 RVA: 0x0007530C File Offset: 0x0007350C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006993 RID: 27027
		' (get) Token: 0x0601103F RID: 69695 RVA: 0x00075315 File Offset: 0x00073515
		' (set) Token: 0x06011040 RID: 69696 RVA: 0x0007531F File Offset: 0x0007351F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006994 RID: 27028
		' (get) Token: 0x06011041 RID: 69697 RVA: 0x00075328 File Offset: 0x00073528
		' (set) Token: 0x06011042 RID: 69698 RVA: 0x00075332 File Offset: 0x00073532
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006995 RID: 27029
		' (get) Token: 0x06011043 RID: 69699 RVA: 0x0007533B File Offset: 0x0007353B
		' (set) Token: 0x06011044 RID: 69700 RVA: 0x00075345 File Offset: 0x00073545
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006996 RID: 27030
		' (get) Token: 0x06011045 RID: 69701 RVA: 0x0007534E File Offset: 0x0007354E
		' (set) Token: 0x06011046 RID: 69702 RVA: 0x00075358 File Offset: 0x00073558
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006997 RID: 27031
		' (get) Token: 0x06011047 RID: 69703 RVA: 0x00075361 File Offset: 0x00073561
		' (set) Token: 0x06011048 RID: 69704 RVA: 0x0007536B File Offset: 0x0007356B
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006998 RID: 27032
		' (get) Token: 0x06011049 RID: 69705 RVA: 0x00075374 File Offset: 0x00073574
		' (set) Token: 0x0601104A RID: 69706 RVA: 0x009E0360 File Offset: 0x009DE560
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

		' Token: 0x17006999 RID: 27033
		' (get) Token: 0x0601104B RID: 69707 RVA: 0x0007537E File Offset: 0x0007357E
		' (set) Token: 0x0601104C RID: 69708 RVA: 0x009E03A4 File Offset: 0x009DE5A4
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

		' Token: 0x1700699A RID: 27034
		' (get) Token: 0x0601104D RID: 69709 RVA: 0x00075388 File Offset: 0x00073588
		' (set) Token: 0x0601104E RID: 69710 RVA: 0x009E03E8 File Offset: 0x009DE5E8
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

		' Token: 0x0601104F RID: 69711 RVA: 0x009E042C File Offset: 0x009DE62C
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

		' Token: 0x06011050 RID: 69712 RVA: 0x009E0500 File Offset: 0x009DE700
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks),RTRIM(CreditCustomerPayment.BankAcNo) from Customer,CreditCustomerPayment where Customer.ID=CreditCustomerPayment.Customer_ID and Amount > 0 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011051 RID: 69713 RVA: 0x009E06F8 File Offset: 0x009DE8F8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011052 RID: 69714 RVA: 0x009E0788 File Offset: 0x009DE988
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

		' Token: 0x06011053 RID: 69715 RVA: 0x009E0900 File Offset: 0x009DEB00
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

		' Token: 0x06011054 RID: 69716 RVA: 0x009E09CC File Offset: 0x009DEBCC
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

		' Token: 0x06011055 RID: 69717 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011056 RID: 69718 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011057 RID: 69719 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011058 RID: 69720 RVA: 0x009E0A98 File Offset: 0x009DEC98
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011059 RID: 69721 RVA: 0x009E0AC0 File Offset: 0x009DECC0
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmCreditCustomerReceipt.Show()
						MyBase.Hide()
						MyProject.Forms.frmCreditCustomerReceipt.txtT_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtTransactionNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.dtpTranactionDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.cmbPaymentMode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtTransactionAmount.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtTempAmt.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtPaymentModeDetails.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.txtRemarks.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.cmbAccountNo.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCreditCustomerReceipt.btnSave.Enabled = False
						MyProject.Forms.frmCreditCustomerReceipt.btnUpdate.Enabled = True
						MyProject.Forms.frmCreditCustomerReceipt.btnDelete.Enabled = True
						MyProject.Forms.frmCreditCustomerReceipt.GetCustomerInfo()
						MyProject.Forms.frmCreditCustomerReceipt.btnSelection.Enabled = False
						MyProject.Forms.frmCreditCustomerReceipt.btnPrint.Enabled = True
						MyProject.Forms.frmCreditCustomerReceipt.Button2.Enabled = True
						MyProject.Forms.frmCreditCustomerReceipt.GetCustomerBalance()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0601105A RID: 69722 RVA: 0x00075392 File Offset: 0x00073592
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x0601105B RID: 69723 RVA: 0x009E0E10 File Offset: 0x009DF010
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

		' Token: 0x0601105C RID: 69724 RVA: 0x0007539C File Offset: 0x0007359C
		Public Sub Reset()
			Me.txtCustomerName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x0601105D RID: 69725 RVA: 0x009E0EF8 File Offset: 0x009DF0F8
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks),RTRIM(CreditCustomerPayment.BankAcNo) from Customer,CreditCustomerPayment where Customer.ID=CreditCustomerPayment.Customer_ID and Amount > 0  and [Name] like N'" + Me.txtCustomerName.Text + "%' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601105E RID: 69726 RVA: 0x009E1108 File Offset: 0x009DF308
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks),RTRIM(CreditCustomerPayment.BankAcNo) from Customer,CreditCustomerPayment where Customer.ID=CreditCustomerPayment.Customer_ID and Amount > 0  and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601105F RID: 69727 RVA: 0x000753CF File Offset: 0x000735CF
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011060 RID: 69728 RVA: 0x009E1314 File Offset: 0x009DF514
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

		' Token: 0x06011061 RID: 69729 RVA: 0x009E15C0 File Offset: 0x009DF7C0
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
				Me.TextBox1.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x06011062 RID: 69730 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCreditCustomerReceiptRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006658 RID: 26200
		Private num1 As Decimal

		' Token: 0x04006659 RID: 26201
		Private num2 As Decimal

		' Token: 0x0400665A RID: 26202
		Private num3 As Decimal

		' Token: 0x0400665B RID: 26203
		Private str As String
	End Class
End Namespace
