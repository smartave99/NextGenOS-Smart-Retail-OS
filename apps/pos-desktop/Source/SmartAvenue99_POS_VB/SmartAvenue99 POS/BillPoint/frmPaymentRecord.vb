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
	' Token: 0x020005B4 RID: 1460
	<DesignerGenerated()>
	Public Partial Class frmPaymentRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011C73 RID: 72819 RVA: 0x0007A0FB File Offset: 0x000782FB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmPaymentRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006E75 RID: 28277
		' (get) Token: 0x06011C76 RID: 72822 RVA: 0x0007A12D File Offset: 0x0007832D
		' (set) Token: 0x06011C77 RID: 72823 RVA: 0x0007A137 File Offset: 0x00078337
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006E76 RID: 28278
		' (get) Token: 0x06011C78 RID: 72824 RVA: 0x0007A140 File Offset: 0x00078340
		' (set) Token: 0x06011C79 RID: 72825 RVA: 0x0007A14A File Offset: 0x0007834A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006E77 RID: 28279
		' (get) Token: 0x06011C7A RID: 72826 RVA: 0x0007A153 File Offset: 0x00078353
		' (set) Token: 0x06011C7B RID: 72827 RVA: 0x0007A15D File Offset: 0x0007835D
		Friend Overridable Property Label1 As Label

		' Token: 0x17006E78 RID: 28280
		' (get) Token: 0x06011C7C RID: 72828 RVA: 0x0007A166 File Offset: 0x00078366
		' (set) Token: 0x06011C7D RID: 72829 RVA: 0x00A42ADC File Offset: 0x00A40CDC
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

		' Token: 0x17006E79 RID: 28281
		' (get) Token: 0x06011C7E RID: 72830 RVA: 0x0007A170 File Offset: 0x00078370
		' (set) Token: 0x06011C7F RID: 72831 RVA: 0x0007A17A File Offset: 0x0007837A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006E7A RID: 28282
		' (get) Token: 0x06011C80 RID: 72832 RVA: 0x0007A183 File Offset: 0x00078383
		' (set) Token: 0x06011C81 RID: 72833 RVA: 0x00A42B58 File Offset: 0x00A40D58
		Private _txtSupplierName As TextBox
		Friend Overridable Property txtSupplierName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierName_TextChanged
				Dim textBox As TextBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierName = value
				textBox = Me._txtSupplierName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006E7B RID: 28283
		' (get) Token: 0x06011C82 RID: 72834 RVA: 0x0007A18D File Offset: 0x0007838D
		' (set) Token: 0x06011C83 RID: 72835 RVA: 0x0007A197 File Offset: 0x00078397
		Friend Overridable Property Label3 As Label

		' Token: 0x17006E7C RID: 28284
		' (get) Token: 0x06011C84 RID: 72836 RVA: 0x0007A1A0 File Offset: 0x000783A0
		' (set) Token: 0x06011C85 RID: 72837 RVA: 0x0007A1AA File Offset: 0x000783AA
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17006E7D RID: 28285
		' (get) Token: 0x06011C86 RID: 72838 RVA: 0x0007A1B3 File Offset: 0x000783B3
		' (set) Token: 0x06011C87 RID: 72839 RVA: 0x0007A1BD File Offset: 0x000783BD
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006E7E RID: 28286
		' (get) Token: 0x06011C88 RID: 72840 RVA: 0x0007A1C6 File Offset: 0x000783C6
		' (set) Token: 0x06011C89 RID: 72841 RVA: 0x0007A1D0 File Offset: 0x000783D0
		Friend Overridable Property Label2 As Label

		' Token: 0x17006E7F RID: 28287
		' (get) Token: 0x06011C8A RID: 72842 RVA: 0x0007A1D9 File Offset: 0x000783D9
		' (set) Token: 0x06011C8B RID: 72843 RVA: 0x0007A1E3 File Offset: 0x000783E3
		Friend Overridable Property Label4 As Label

		' Token: 0x17006E80 RID: 28288
		' (get) Token: 0x06011C8C RID: 72844 RVA: 0x0007A1EC File Offset: 0x000783EC
		' (set) Token: 0x06011C8D RID: 72845 RVA: 0x0007A1F6 File Offset: 0x000783F6
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006E81 RID: 28289
		' (get) Token: 0x06011C8E RID: 72846 RVA: 0x0007A1FF File Offset: 0x000783FF
		' (set) Token: 0x06011C8F RID: 72847 RVA: 0x0007A209 File Offset: 0x00078409
		Friend Overridable Property lblSet As Label

		' Token: 0x17006E82 RID: 28290
		' (get) Token: 0x06011C90 RID: 72848 RVA: 0x0007A212 File Offset: 0x00078412
		' (set) Token: 0x06011C91 RID: 72849 RVA: 0x0007A21C File Offset: 0x0007841C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17006E83 RID: 28291
		' (get) Token: 0x06011C92 RID: 72850 RVA: 0x0007A225 File Offset: 0x00078425
		' (set) Token: 0x06011C93 RID: 72851 RVA: 0x0007A22F File Offset: 0x0007842F
		Friend Overridable Property Label5 As Label

		' Token: 0x17006E84 RID: 28292
		' (get) Token: 0x06011C94 RID: 72852 RVA: 0x0007A238 File Offset: 0x00078438
		' (set) Token: 0x06011C95 RID: 72853 RVA: 0x0007A242 File Offset: 0x00078442
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006E85 RID: 28293
		' (get) Token: 0x06011C96 RID: 72854 RVA: 0x0007A24B File Offset: 0x0007844B
		' (set) Token: 0x06011C97 RID: 72855 RVA: 0x0007A255 File Offset: 0x00078455
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17006E86 RID: 28294
		' (get) Token: 0x06011C98 RID: 72856 RVA: 0x0007A25E File Offset: 0x0007845E
		' (set) Token: 0x06011C99 RID: 72857 RVA: 0x0007A268 File Offset: 0x00078468
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006E87 RID: 28295
		' (get) Token: 0x06011C9A RID: 72858 RVA: 0x0007A271 File Offset: 0x00078471
		' (set) Token: 0x06011C9B RID: 72859 RVA: 0x0007A27B File Offset: 0x0007847B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006E88 RID: 28296
		' (get) Token: 0x06011C9C RID: 72860 RVA: 0x0007A284 File Offset: 0x00078484
		' (set) Token: 0x06011C9D RID: 72861 RVA: 0x0007A28E File Offset: 0x0007848E
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006E89 RID: 28297
		' (get) Token: 0x06011C9E RID: 72862 RVA: 0x0007A297 File Offset: 0x00078497
		' (set) Token: 0x06011C9F RID: 72863 RVA: 0x0007A2A1 File Offset: 0x000784A1
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17006E8A RID: 28298
		' (get) Token: 0x06011CA0 RID: 72864 RVA: 0x0007A2AA File Offset: 0x000784AA
		' (set) Token: 0x06011CA1 RID: 72865 RVA: 0x0007A2B4 File Offset: 0x000784B4
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006E8B RID: 28299
		' (get) Token: 0x06011CA2 RID: 72866 RVA: 0x0007A2BD File Offset: 0x000784BD
		' (set) Token: 0x06011CA3 RID: 72867 RVA: 0x0007A2C7 File Offset: 0x000784C7
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006E8C RID: 28300
		' (get) Token: 0x06011CA4 RID: 72868 RVA: 0x0007A2D0 File Offset: 0x000784D0
		' (set) Token: 0x06011CA5 RID: 72869 RVA: 0x0007A2DA File Offset: 0x000784DA
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006E8D RID: 28301
		' (get) Token: 0x06011CA6 RID: 72870 RVA: 0x0007A2E3 File Offset: 0x000784E3
		' (set) Token: 0x06011CA7 RID: 72871 RVA: 0x0007A2ED File Offset: 0x000784ED
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006E8E RID: 28302
		' (get) Token: 0x06011CA8 RID: 72872 RVA: 0x0007A2F6 File Offset: 0x000784F6
		' (set) Token: 0x06011CA9 RID: 72873 RVA: 0x0007A300 File Offset: 0x00078500
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006E8F RID: 28303
		' (get) Token: 0x06011CAA RID: 72874 RVA: 0x0007A309 File Offset: 0x00078509
		' (set) Token: 0x06011CAB RID: 72875 RVA: 0x0007A313 File Offset: 0x00078513
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17006E90 RID: 28304
		' (get) Token: 0x06011CAC RID: 72876 RVA: 0x0007A31C File Offset: 0x0007851C
		' (set) Token: 0x06011CAD RID: 72877 RVA: 0x0007A326 File Offset: 0x00078526
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006E91 RID: 28305
		' (get) Token: 0x06011CAE RID: 72878 RVA: 0x0007A32F File Offset: 0x0007852F
		' (set) Token: 0x06011CAF RID: 72879 RVA: 0x00A42B9C File Offset: 0x00A40D9C
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

		' Token: 0x17006E92 RID: 28306
		' (get) Token: 0x06011CB0 RID: 72880 RVA: 0x0007A339 File Offset: 0x00078539
		' (set) Token: 0x06011CB1 RID: 72881 RVA: 0x00A42BE0 File Offset: 0x00A40DE0
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

		' Token: 0x17006E93 RID: 28307
		' (get) Token: 0x06011CB2 RID: 72882 RVA: 0x0007A343 File Offset: 0x00078543
		' (set) Token: 0x06011CB3 RID: 72883 RVA: 0x00A42C24 File Offset: 0x00A40E24
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

		' Token: 0x06011CB4 RID: 72884 RVA: 0x00A42C68 File Offset: 0x00A40E68
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

		' Token: 0x06011CB5 RID: 72885 RVA: 0x00A42D3C File Offset: 0x00A40F3C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails),RTRIM(Payment.Remarks),RTRIM(Payment.BankAcN) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0 and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
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

		' Token: 0x06011CB6 RID: 72886 RVA: 0x00A42F34 File Offset: 0x00A41134
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06011CB7 RID: 72887 RVA: 0x00A42FC4 File Offset: 0x00A411C4
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

		' Token: 0x06011CB8 RID: 72888 RVA: 0x00A4313C File Offset: 0x00A4133C
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

		' Token: 0x06011CB9 RID: 72889 RVA: 0x00A43208 File Offset: 0x00A41408
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

		' Token: 0x06011CBA RID: 72890 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011CBB RID: 72891 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011CBC RID: 72892 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011CBD RID: 72893 RVA: 0x00A432D4 File Offset: 0x00A414D4
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06011CBE RID: 72894 RVA: 0x00A432FC File Offset: 0x00A414FC
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmPayment.Show()
						MyBase.Hide()
						MyProject.Forms.frmPayment.txtT_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmPayment.txtTransactionNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmPayment.dtpTranactionDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmPayment.cmbPaymentMode.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmPayment.txtSup_ID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmPayment.txtSupplierID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmPayment.cmbSupplierName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmPayment.txtTransactionAmount.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPayment.txtTempAmt.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmPayment.txtPaymentModeDetails.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmPayment.txtRemarks.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmPayment.cmbAccountNo.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmPayment.btnSave.Enabled = False
						MyProject.Forms.frmPayment.btnUpdate.Enabled = True
						MyProject.Forms.frmPayment.btnDelete.Enabled = True
						MyProject.Forms.frmPayment.GetSupplierInfo()
						MyProject.Forms.frmPayment.btnSelection.Enabled = False
						MyProject.Forms.frmPayment.GetSupplierBalance()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011CBF RID: 72895 RVA: 0x0007A34D File Offset: 0x0007854D
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06011CC0 RID: 72896 RVA: 0x00A43620 File Offset: 0x00A41820
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

		' Token: 0x06011CC1 RID: 72897 RVA: 0x0007A357 File Offset: 0x00078557
		Public Sub Reset()
			Me.txtSupplierName.Text = ""
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06011CC2 RID: 72898 RVA: 0x00A43708 File Offset: 0x00A41908
		Private Sub txtSupplierName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails),RTRIM(Payment.Remarks),RTRIM(Payment.BankAcN) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0  and [Name] like N'" + Me.txtSupplierName.Text + "%' and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
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

		' Token: 0x06011CC3 RID: 72899 RVA: 0x00A43918 File Offset: 0x00A41B18
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.txtSupplierName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails),RTRIM(Payment.Remarks),RTRIM(Payment.BankAcN) from Supplier,Payment where Supplier.ID=Payment.SupplierID and Amount > 0  and [Date] between @d1 and @d2 order by [Date]", ModCommonClasses.con)
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

		' Token: 0x06011CC4 RID: 72900 RVA: 0x0007A38A File Offset: 0x0007858A
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011CC5 RID: 72901 RVA: 0x00A43B24 File Offset: 0x00A41D24
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

		' Token: 0x06011CC6 RID: 72902 RVA: 0x00A43DD0 File Offset: 0x00A41FD0
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

		' Token: 0x06011CC7 RID: 72903 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmPaymentRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006B02 RID: 27394
		Private num1 As Decimal

		' Token: 0x04006B03 RID: 27395
		Private num2 As Decimal

		' Token: 0x04006B04 RID: 27396
		Private num3 As Decimal

		' Token: 0x04006B05 RID: 27397
		Private str As String
	End Class
End Namespace
