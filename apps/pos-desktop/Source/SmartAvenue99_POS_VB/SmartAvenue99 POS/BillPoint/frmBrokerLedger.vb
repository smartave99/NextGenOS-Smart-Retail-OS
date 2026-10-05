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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000331 RID: 817
	<DesignerGenerated()>
	Public Partial Class frmBrokerLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C014 RID: 49172 RVA: 0x00055D5C File Offset: 0x00053F5C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBrokerLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBrokerLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004C6E RID: 19566
		' (get) Token: 0x0600C017 RID: 49175 RVA: 0x00055D8E File Offset: 0x00053F8E
		' (set) Token: 0x0600C018 RID: 49176 RVA: 0x00055D98 File Offset: 0x00053F98
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004C6F RID: 19567
		' (get) Token: 0x0600C019 RID: 49177 RVA: 0x00055DA1 File Offset: 0x00053FA1
		' (set) Token: 0x0600C01A RID: 49178 RVA: 0x007A6A34 File Offset: 0x007A4C34
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

		' Token: 0x17004C70 RID: 19568
		' (get) Token: 0x0600C01B RID: 49179 RVA: 0x00055DAB File Offset: 0x00053FAB
		' (set) Token: 0x0600C01C RID: 49180 RVA: 0x00055DB5 File Offset: 0x00053FB5
		Friend Overridable Property Label2 As Label

		' Token: 0x17004C71 RID: 19569
		' (get) Token: 0x0600C01D RID: 49181 RVA: 0x00055DBE File Offset: 0x00053FBE
		' (set) Token: 0x0600C01E RID: 49182 RVA: 0x00055DC8 File Offset: 0x00053FC8
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004C72 RID: 19570
		' (get) Token: 0x0600C01F RID: 49183 RVA: 0x00055DD1 File Offset: 0x00053FD1
		' (set) Token: 0x0600C020 RID: 49184 RVA: 0x007A6A78 File Offset: 0x007A4C78
		Private _txtSalesmanName As TextBox
		Friend Overridable Property txtSalesmanName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSalesmanName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSalesmanName_TextChanged
				Dim textBox As TextBox = Me._txtSalesmanName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSalesmanName = value
				textBox = Me._txtSalesmanName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C73 RID: 19571
		' (get) Token: 0x0600C021 RID: 49185 RVA: 0x00055DDB File Offset: 0x00053FDB
		' (set) Token: 0x0600C022 RID: 49186 RVA: 0x00055DE5 File Offset: 0x00053FE5
		Friend Overridable Property Label3 As Label

		' Token: 0x17004C74 RID: 19572
		' (get) Token: 0x0600C023 RID: 49187 RVA: 0x00055DEE File Offset: 0x00053FEE
		' (set) Token: 0x0600C024 RID: 49188 RVA: 0x007A6ABC File Offset: 0x007A4CBC
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C75 RID: 19573
		' (get) Token: 0x0600C025 RID: 49189 RVA: 0x00055DF8 File Offset: 0x00053FF8
		' (set) Token: 0x0600C026 RID: 49190 RVA: 0x00055E02 File Offset: 0x00054002
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004C76 RID: 19574
		' (get) Token: 0x0600C027 RID: 49191 RVA: 0x00055E0B File Offset: 0x0005400B
		' (set) Token: 0x0600C028 RID: 49192 RVA: 0x00055E15 File Offset: 0x00054015
		Friend Overridable Property Label1 As Label

		' Token: 0x17004C77 RID: 19575
		' (get) Token: 0x0600C029 RID: 49193 RVA: 0x00055E1E File Offset: 0x0005401E
		' (set) Token: 0x0600C02A RID: 49194 RVA: 0x00055E28 File Offset: 0x00054028
		Friend Overridable Property lblSet As Label

		' Token: 0x17004C78 RID: 19576
		' (get) Token: 0x0600C02B RID: 49195 RVA: 0x00055E31 File Offset: 0x00054031
		' (set) Token: 0x0600C02C RID: 49196 RVA: 0x00055E3B File Offset: 0x0005403B
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004C79 RID: 19577
		' (get) Token: 0x0600C02D RID: 49197 RVA: 0x00055E44 File Offset: 0x00054044
		' (set) Token: 0x0600C02E RID: 49198 RVA: 0x00055E4E File Offset: 0x0005404E
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004C7A RID: 19578
		' (get) Token: 0x0600C02F RID: 49199 RVA: 0x00055E57 File Offset: 0x00054057
		' (set) Token: 0x0600C030 RID: 49200 RVA: 0x00055E61 File Offset: 0x00054061
		Friend Overridable Property Label4 As Label

		' Token: 0x17004C7B RID: 19579
		' (get) Token: 0x0600C031 RID: 49201 RVA: 0x00055E6A File Offset: 0x0005406A
		' (set) Token: 0x0600C032 RID: 49202 RVA: 0x00055E74 File Offset: 0x00054074
		Friend Overridable Property Label5 As Label

		' Token: 0x17004C7C RID: 19580
		' (get) Token: 0x0600C033 RID: 49203 RVA: 0x00055E7D File Offset: 0x0005407D
		' (set) Token: 0x0600C034 RID: 49204 RVA: 0x00055E87 File Offset: 0x00054087
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004C7D RID: 19581
		' (get) Token: 0x0600C035 RID: 49205 RVA: 0x00055E90 File Offset: 0x00054090
		' (set) Token: 0x0600C036 RID: 49206 RVA: 0x00055E9A File Offset: 0x0005409A
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004C7E RID: 19582
		' (get) Token: 0x0600C037 RID: 49207 RVA: 0x00055EA3 File Offset: 0x000540A3
		' (set) Token: 0x0600C038 RID: 49208 RVA: 0x00055EAD File Offset: 0x000540AD
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004C7F RID: 19583
		' (get) Token: 0x0600C039 RID: 49209 RVA: 0x00055EB6 File Offset: 0x000540B6
		' (set) Token: 0x0600C03A RID: 49210 RVA: 0x007A6B00 File Offset: 0x007A4D00
		Private _cmbQuotationNo As ComboBox
		Friend Overridable Property cmbQuotationNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbQuotationNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbQuotationNo_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._cmbQuotationNo = value
				comboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C80 RID: 19584
		' (get) Token: 0x0600C03B RID: 49211 RVA: 0x00055EC0 File Offset: 0x000540C0
		' (set) Token: 0x0600C03C RID: 49212 RVA: 0x00055ECA File Offset: 0x000540CA
		Friend Overridable Property Label6 As Label

		' Token: 0x17004C81 RID: 19585
		' (get) Token: 0x0600C03D RID: 49213 RVA: 0x00055ED3 File Offset: 0x000540D3
		' (set) Token: 0x0600C03E RID: 49214 RVA: 0x00055EDD File Offset: 0x000540DD
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004C82 RID: 19586
		' (get) Token: 0x0600C03F RID: 49215 RVA: 0x00055EE6 File Offset: 0x000540E6
		' (set) Token: 0x0600C040 RID: 49216 RVA: 0x00055EF0 File Offset: 0x000540F0
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004C83 RID: 19587
		' (get) Token: 0x0600C041 RID: 49217 RVA: 0x00055EF9 File Offset: 0x000540F9
		' (set) Token: 0x0600C042 RID: 49218 RVA: 0x00055F03 File Offset: 0x00054103
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004C84 RID: 19588
		' (get) Token: 0x0600C043 RID: 49219 RVA: 0x00055F0C File Offset: 0x0005410C
		' (set) Token: 0x0600C044 RID: 49220 RVA: 0x00055F16 File Offset: 0x00054116
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17004C85 RID: 19589
		' (get) Token: 0x0600C045 RID: 49221 RVA: 0x00055F1F File Offset: 0x0005411F
		' (set) Token: 0x0600C046 RID: 49222 RVA: 0x00055F29 File Offset: 0x00054129
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004C86 RID: 19590
		' (get) Token: 0x0600C047 RID: 49223 RVA: 0x00055F32 File Offset: 0x00054132
		' (set) Token: 0x0600C048 RID: 49224 RVA: 0x00055F3C File Offset: 0x0005413C
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x17004C87 RID: 19591
		' (get) Token: 0x0600C049 RID: 49225 RVA: 0x00055F45 File Offset: 0x00054145
		' (set) Token: 0x0600C04A RID: 49226 RVA: 0x00055F4F File Offset: 0x0005414F
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17004C88 RID: 19592
		' (get) Token: 0x0600C04B RID: 49227 RVA: 0x00055F58 File Offset: 0x00054158
		' (set) Token: 0x0600C04C RID: 49228 RVA: 0x00055F62 File Offset: 0x00054162
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004C89 RID: 19593
		' (get) Token: 0x0600C04D RID: 49229 RVA: 0x00055F6B File Offset: 0x0005416B
		' (set) Token: 0x0600C04E RID: 49230 RVA: 0x00055F75 File Offset: 0x00054175
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004C8A RID: 19594
		' (get) Token: 0x0600C04F RID: 49231 RVA: 0x00055F7E File Offset: 0x0005417E
		' (set) Token: 0x0600C050 RID: 49232 RVA: 0x00055F88 File Offset: 0x00054188
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004C8B RID: 19595
		' (get) Token: 0x0600C051 RID: 49233 RVA: 0x00055F91 File Offset: 0x00054191
		' (set) Token: 0x0600C052 RID: 49234 RVA: 0x00055F9B File Offset: 0x0005419B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004C8C RID: 19596
		' (get) Token: 0x0600C053 RID: 49235 RVA: 0x00055FA4 File Offset: 0x000541A4
		' (set) Token: 0x0600C054 RID: 49236 RVA: 0x00055FAE File Offset: 0x000541AE
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17004C8D RID: 19597
		' (get) Token: 0x0600C055 RID: 49237 RVA: 0x00055FB7 File Offset: 0x000541B7
		' (set) Token: 0x0600C056 RID: 49238 RVA: 0x00055FC1 File Offset: 0x000541C1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004C8E RID: 19598
		' (get) Token: 0x0600C057 RID: 49239 RVA: 0x00055FCA File Offset: 0x000541CA
		' (set) Token: 0x0600C058 RID: 49240 RVA: 0x00055FD4 File Offset: 0x000541D4
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004C8F RID: 19599
		' (get) Token: 0x0600C059 RID: 49241 RVA: 0x00055FDD File Offset: 0x000541DD
		' (set) Token: 0x0600C05A RID: 49242 RVA: 0x007A6B44 File Offset: 0x007A4D44
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

		' Token: 0x17004C90 RID: 19600
		' (get) Token: 0x0600C05B RID: 49243 RVA: 0x00055FE7 File Offset: 0x000541E7
		' (set) Token: 0x0600C05C RID: 49244 RVA: 0x007A6B88 File Offset: 0x007A4D88
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

		' Token: 0x17004C91 RID: 19601
		' (get) Token: 0x0600C05D RID: 49245 RVA: 0x00055FF1 File Offset: 0x000541F1
		' (set) Token: 0x0600C05E RID: 49246 RVA: 0x007A6BCC File Offset: 0x007A4DCC
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

		' Token: 0x0600C05F RID: 49247 RVA: 0x007A6C10 File Offset: 0x007A4E10
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

		' Token: 0x0600C060 RID: 49248 RVA: 0x007A6CE4 File Offset: 0x007A4EE4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select ID, InvDate, RTRIM(InvNo), RTRIM(BName), RTRIM(BAddress), RTRIM(BContact),(TotAmt), RTRIM(CommApl), RTRIM(CommType),(CommPer),(CommAmt),RTRIM(CustName),RTRIM(CustContact) from BrokerLdr where InvDate between @d1 and @d2 order by InvDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C061 RID: 49249 RVA: 0x007A6F04 File Offset: 0x007A5104
		Private Sub frmBrokerLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.fillInvNo()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C062 RID: 49250 RVA: 0x007A6FA4 File Offset: 0x007A51A4
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

		' Token: 0x0600C063 RID: 49251 RVA: 0x007A711C File Offset: 0x007A531C
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

		' Token: 0x0600C064 RID: 49252 RVA: 0x007A71D8 File Offset: 0x007A53D8
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

		' Token: 0x0600C065 RID: 49253 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C066 RID: 49254 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C067 RID: 49255 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C068 RID: 49256 RVA: 0x007A72A4 File Offset: 0x007A54A4
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

		' Token: 0x0600C069 RID: 49257 RVA: 0x007A738C File Offset: 0x007A558C
		Private Sub txtSalesmanName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select ID, InvDate, RTRIM(InvNo), RTRIM(BName), RTRIM(BAddress), RTRIM(BContact),(TotAmt), RTRIM(CommApl), RTRIM(CommType),(CommPer),(CommAmt),RTRIM(CustName),RTRIM(CustContact) from BrokerLdr where BName like N'" + Me.txtSalesmanName.Text + "%' and InvDate between @d1 and @d2 order by InvDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C06A RID: 49258 RVA: 0x007A75CC File Offset: 0x007A57CC
		Private Sub txtCity_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select ID, InvDate, RTRIM(InvNo), RTRIM(BName), RTRIM(BAddress), RTRIM(BContact),(TotAmt), RTRIM(CommApl), RTRIM(CommType),(CommPer),(CommAmt),RTRIM(CustName),RTRIM(CustContact) from BrokerLdr where BContact like N'" + Me.txtCity.Text + "%' and InvDate between @d1 and @d2 order by InvDate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C06B RID: 49259 RVA: 0x007A780C File Offset: 0x007A5A0C
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column7").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600C06C RID: 49260 RVA: 0x007A7924 File Offset: 0x007A5B24
		Public Sub fillInvNo()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(InvNo) FROM BrokerLdr", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbQuotationNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbQuotationNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600C06D RID: 49261 RVA: 0x007A7A60 File Offset: 0x007A5C60
		Public Sub Reset()
			Me.cmbQuotationNo.SelectedIndex = -1
			Me.cmbQuotationNo.Text = ""
			Me.txtSalesmanName.Text = ""
			Me.fillInvNo()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.Calculate()
		End Sub

		' Token: 0x0600C06E RID: 49262 RVA: 0x007A7ACC File Offset: 0x007A5CCC
		Private Sub cmbQuotationNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select ID, InvDate, RTRIM(InvNo), RTRIM(BName), RTRIM(BAddress), RTRIM(BContact),(TotAmt), RTRIM(CommApl), RTRIM(CommType),(CommPer),(CommAmt),RTRIM(CustName),RTRIM(CustContact) from BrokerLdr where InvNo like N'" + Me.cmbQuotationNo.Text + "%'", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C06F RID: 49263 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBrokerLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C070 RID: 49264 RVA: 0x00055FFB File Offset: 0x000541FB
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600C071 RID: 49265 RVA: 0x00056005 File Offset: 0x00054205
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C072 RID: 49266 RVA: 0x007A7C98 File Offset: 0x007A5E98
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
	End Class
End Namespace
