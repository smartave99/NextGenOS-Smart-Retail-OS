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
	' Token: 0x020005CE RID: 1486
	<DesignerGenerated()>
	Public Partial Class frmQuotationRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060121D9 RID: 74201 RVA: 0x0007C320 File Offset: 0x0007A520
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmQuotationRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17007081 RID: 28801
		' (get) Token: 0x060121DC RID: 74204 RVA: 0x0007C352 File Offset: 0x0007A552
		' (set) Token: 0x060121DD RID: 74205 RVA: 0x0007C35C File Offset: 0x0007A55C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17007082 RID: 28802
		' (get) Token: 0x060121DE RID: 74206 RVA: 0x0007C365 File Offset: 0x0007A565
		' (set) Token: 0x060121DF RID: 74207 RVA: 0x0007C36F File Offset: 0x0007A56F
		Friend Overridable Property Label1 As Label

		' Token: 0x17007083 RID: 28803
		' (get) Token: 0x060121E0 RID: 74208 RVA: 0x0007C378 File Offset: 0x0007A578
		' (set) Token: 0x060121E1 RID: 74209 RVA: 0x00A6E5B0 File Offset: 0x00A6C7B0
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

		' Token: 0x17007084 RID: 28804
		' (get) Token: 0x060121E2 RID: 74210 RVA: 0x0007C382 File Offset: 0x0007A582
		' (set) Token: 0x060121E3 RID: 74211 RVA: 0x0007C38C File Offset: 0x0007A58C
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17007085 RID: 28805
		' (get) Token: 0x060121E4 RID: 74212 RVA: 0x0007C395 File Offset: 0x0007A595
		' (set) Token: 0x060121E5 RID: 74213 RVA: 0x0007C39F File Offset: 0x0007A59F
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17007086 RID: 28806
		' (get) Token: 0x060121E6 RID: 74214 RVA: 0x0007C3A8 File Offset: 0x0007A5A8
		' (set) Token: 0x060121E7 RID: 74215 RVA: 0x0007C3B2 File Offset: 0x0007A5B2
		Friend Overridable Property Label2 As Label

		' Token: 0x17007087 RID: 28807
		' (get) Token: 0x060121E8 RID: 74216 RVA: 0x0007C3BB File Offset: 0x0007A5BB
		' (set) Token: 0x060121E9 RID: 74217 RVA: 0x0007C3C5 File Offset: 0x0007A5C5
		Friend Overridable Property Label4 As Label

		' Token: 0x17007088 RID: 28808
		' (get) Token: 0x060121EA RID: 74218 RVA: 0x0007C3CE File Offset: 0x0007A5CE
		' (set) Token: 0x060121EB RID: 74219 RVA: 0x0007C3D8 File Offset: 0x0007A5D8
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17007089 RID: 28809
		' (get) Token: 0x060121EC RID: 74220 RVA: 0x0007C3E1 File Offset: 0x0007A5E1
		' (set) Token: 0x060121ED RID: 74221 RVA: 0x00A6E62C File Offset: 0x00A6C82C
		Private _cmbQuotationNo As ComboBox
		Friend Overridable Property cmbQuotationNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbQuotationNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbOrderNo_SelectedIndexChanged
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbQuotationNo_Format
				Dim comboBox As ComboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbQuotationNo = value
				comboBox = Me._cmbQuotationNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700708A RID: 28810
		' (get) Token: 0x060121EE RID: 74222 RVA: 0x0007C3EB File Offset: 0x0007A5EB
		' (set) Token: 0x060121EF RID: 74223 RVA: 0x0007C3F5 File Offset: 0x0007A5F5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700708B RID: 28811
		' (get) Token: 0x060121F0 RID: 74224 RVA: 0x0007C3FE File Offset: 0x0007A5FE
		' (set) Token: 0x060121F1 RID: 74225 RVA: 0x0007C408 File Offset: 0x0007A608
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700708C RID: 28812
		' (get) Token: 0x060121F2 RID: 74226 RVA: 0x0007C411 File Offset: 0x0007A611
		' (set) Token: 0x060121F3 RID: 74227 RVA: 0x0007C41B File Offset: 0x0007A61B
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x1700708D RID: 28813
		' (get) Token: 0x060121F4 RID: 74228 RVA: 0x0007C424 File Offset: 0x0007A624
		' (set) Token: 0x060121F5 RID: 74229 RVA: 0x00A6E68C File Offset: 0x00A6C88C
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

		' Token: 0x1700708E RID: 28814
		' (get) Token: 0x060121F6 RID: 74230 RVA: 0x0007C42E File Offset: 0x0007A62E
		' (set) Token: 0x060121F7 RID: 74231 RVA: 0x0007C438 File Offset: 0x0007A638
		Friend Overridable Property Label3 As Label

		' Token: 0x1700708F RID: 28815
		' (get) Token: 0x060121F8 RID: 74232 RVA: 0x0007C441 File Offset: 0x0007A641
		' (set) Token: 0x060121F9 RID: 74233 RVA: 0x0007C44B File Offset: 0x0007A64B
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17007090 RID: 28816
		' (get) Token: 0x060121FA RID: 74234 RVA: 0x0007C454 File Offset: 0x0007A654
		' (set) Token: 0x060121FB RID: 74235 RVA: 0x0007C45E File Offset: 0x0007A65E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17007091 RID: 28817
		' (get) Token: 0x060121FC RID: 74236 RVA: 0x0007C467 File Offset: 0x0007A667
		' (set) Token: 0x060121FD RID: 74237 RVA: 0x0007C471 File Offset: 0x0007A671
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17007092 RID: 28818
		' (get) Token: 0x060121FE RID: 74238 RVA: 0x0007C47A File Offset: 0x0007A67A
		' (set) Token: 0x060121FF RID: 74239 RVA: 0x0007C484 File Offset: 0x0007A684
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17007093 RID: 28819
		' (get) Token: 0x06012200 RID: 74240 RVA: 0x0007C48D File Offset: 0x0007A68D
		' (set) Token: 0x06012201 RID: 74241 RVA: 0x0007C497 File Offset: 0x0007A697
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17007094 RID: 28820
		' (get) Token: 0x06012202 RID: 74242 RVA: 0x0007C4A0 File Offset: 0x0007A6A0
		' (set) Token: 0x06012203 RID: 74243 RVA: 0x0007C4AA File Offset: 0x0007A6AA
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17007095 RID: 28821
		' (get) Token: 0x06012204 RID: 74244 RVA: 0x0007C4B3 File Offset: 0x0007A6B3
		' (set) Token: 0x06012205 RID: 74245 RVA: 0x0007C4BD File Offset: 0x0007A6BD
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17007096 RID: 28822
		' (get) Token: 0x06012206 RID: 74246 RVA: 0x0007C4C6 File Offset: 0x0007A6C6
		' (set) Token: 0x06012207 RID: 74247 RVA: 0x0007C4D0 File Offset: 0x0007A6D0
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17007097 RID: 28823
		' (get) Token: 0x06012208 RID: 74248 RVA: 0x0007C4D9 File Offset: 0x0007A6D9
		' (set) Token: 0x06012209 RID: 74249 RVA: 0x0007C4E3 File Offset: 0x0007A6E3
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17007098 RID: 28824
		' (get) Token: 0x0601220A RID: 74250 RVA: 0x0007C4EC File Offset: 0x0007A6EC
		' (set) Token: 0x0601220B RID: 74251 RVA: 0x0007C4F6 File Offset: 0x0007A6F6
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17007099 RID: 28825
		' (get) Token: 0x0601220C RID: 74252 RVA: 0x0007C4FF File Offset: 0x0007A6FF
		' (set) Token: 0x0601220D RID: 74253 RVA: 0x0007C509 File Offset: 0x0007A709
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x1700709A RID: 28826
		' (get) Token: 0x0601220E RID: 74254 RVA: 0x0007C512 File Offset: 0x0007A712
		' (set) Token: 0x0601220F RID: 74255 RVA: 0x0007C51C File Offset: 0x0007A71C
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x1700709B RID: 28827
		' (get) Token: 0x06012210 RID: 74256 RVA: 0x0007C525 File Offset: 0x0007A725
		' (set) Token: 0x06012211 RID: 74257 RVA: 0x0007C52F File Offset: 0x0007A72F
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x1700709C RID: 28828
		' (get) Token: 0x06012212 RID: 74258 RVA: 0x0007C538 File Offset: 0x0007A738
		' (set) Token: 0x06012213 RID: 74259 RVA: 0x0007C542 File Offset: 0x0007A742
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x1700709D RID: 28829
		' (get) Token: 0x06012214 RID: 74260 RVA: 0x0007C54B File Offset: 0x0007A74B
		' (set) Token: 0x06012215 RID: 74261 RVA: 0x0007C555 File Offset: 0x0007A755
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x1700709E RID: 28830
		' (get) Token: 0x06012216 RID: 74262 RVA: 0x0007C55E File Offset: 0x0007A75E
		' (set) Token: 0x06012217 RID: 74263 RVA: 0x0007C568 File Offset: 0x0007A768
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x1700709F RID: 28831
		' (get) Token: 0x06012218 RID: 74264 RVA: 0x0007C571 File Offset: 0x0007A771
		' (set) Token: 0x06012219 RID: 74265 RVA: 0x0007C57B File Offset: 0x0007A77B
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x170070A0 RID: 28832
		' (get) Token: 0x0601221A RID: 74266 RVA: 0x0007C584 File Offset: 0x0007A784
		' (set) Token: 0x0601221B RID: 74267 RVA: 0x0007C58E File Offset: 0x0007A78E
		Friend Overridable Property Column19 As DataGridViewTextBoxColumn

		' Token: 0x170070A1 RID: 28833
		' (get) Token: 0x0601221C RID: 74268 RVA: 0x0007C597 File Offset: 0x0007A797
		' (set) Token: 0x0601221D RID: 74269 RVA: 0x0007C5A1 File Offset: 0x0007A7A1
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170070A2 RID: 28834
		' (get) Token: 0x0601221E RID: 74270 RVA: 0x0007C5AA File Offset: 0x0007A7AA
		' (set) Token: 0x0601221F RID: 74271 RVA: 0x0007C5B4 File Offset: 0x0007A7B4
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x170070A3 RID: 28835
		' (get) Token: 0x06012220 RID: 74272 RVA: 0x0007C5BD File Offset: 0x0007A7BD
		' (set) Token: 0x06012221 RID: 74273 RVA: 0x0007C5C7 File Offset: 0x0007A7C7
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x170070A4 RID: 28836
		' (get) Token: 0x06012222 RID: 74274 RVA: 0x0007C5D0 File Offset: 0x0007A7D0
		' (set) Token: 0x06012223 RID: 74275 RVA: 0x00A6E6D0 File Offset: 0x00A6C8D0
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

		' Token: 0x170070A5 RID: 28837
		' (get) Token: 0x06012224 RID: 74276 RVA: 0x0007C5DA File Offset: 0x0007A7DA
		' (set) Token: 0x06012225 RID: 74277 RVA: 0x00A6E714 File Offset: 0x00A6C914
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

		' Token: 0x170070A6 RID: 28838
		' (get) Token: 0x06012226 RID: 74278 RVA: 0x0007C5E4 File Offset: 0x0007A7E4
		' (set) Token: 0x06012227 RID: 74279 RVA: 0x00A6E758 File Offset: 0x00A6C958
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

		' Token: 0x06012228 RID: 74280 RVA: 0x00A6E79C File Offset: 0x00A6C99C
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

		' Token: 0x06012229 RID: 74281 RVA: 0x00A6E870 File Offset: 0x00A6CA70
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(quotation.Remarks) from Customer,quotation where Customer.ID=quotation.CustomerID and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601222A RID: 74282 RVA: 0x00A6EAEC File Offset: 0x00A6CCEC
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Calculate()
			Me.fillQuotationNo()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0601222B RID: 74283 RVA: 0x00A6EB8C File Offset: 0x00A6CD8C
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

		' Token: 0x0601222C RID: 74284 RVA: 0x00A6ED04 File Offset: 0x00A6CF04
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

		' Token: 0x0601222D RID: 74285 RVA: 0x00A6EDD0 File Offset: 0x00A6CFD0
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

		' Token: 0x0601222E RID: 74286 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601222F RID: 74287 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06012230 RID: 74288 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012231 RID: 74289 RVA: 0x00A6EE9C File Offset: 0x00A6D09C
		Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Me.RetrieveData()
			End If
		End Sub

		' Token: 0x06012232 RID: 74290 RVA: 0x0007C5EE File Offset: 0x0007A7EE
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Me.RetrieveData()
		End Sub

		' Token: 0x06012233 RID: 74291 RVA: 0x00A6EEC4 File Offset: 0x00A6D0C4
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.Label3.Text, "Qtn", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyProject.Forms.frmQuotation.Show()
						MyBase.Hide()
						MyProject.Forms.frmQuotation.txtQ_ID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmQuotation.txtQuotationNo.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmQuotation.dtpQuotationDate.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmQuotation.txtCustomerID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmQuotation.txtCID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmQuotation.cmbCustomerName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmQuotation.txtContactNo.Text = dataGridViewRow.Cells(7).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(MyProject.Forms.frmQuotation.cmbCustomerName.Text.Trim(), "Cash", False) = 0
						If flag3 Then
							MyProject.Forms.frmQuotation.txtCustomerState.Text = MyProject.Forms.frmQuotation.txtCompanyState.Text
						Else
							MyProject.Forms.frmQuotation.txtCustomerState.Text = dataGridViewRow.Cells(8).Value.ToString()
						End If
						MyProject.Forms.frmQuotation.txtGSTIN.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmQuotation.txtSubTotal.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmQuotation.txtCGST.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmQuotation.txtSGST.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmQuotation.txtIGST.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmQuotation.txtCESS.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmQuotation.txtTotal.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmQuotation.txtRoundOff.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmQuotation.txtGrandTotal.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmQuotation.txtRemarks.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmQuotation.btnSave.Enabled = False
						MyProject.Forms.frmQuotation.btnUpdate.Enabled = True
						MyProject.Forms.frmQuotation.btnPrint.Enabled = True
						MyProject.Forms.frmQuotation.btnDelete.Enabled = True
						MyProject.Forms.frmQuotation.btnCustomerSelection.Enabled = False
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = "SELECT PID,RTRIM(Product.HSNCode),RTRIM(Productname),RTRIM(Quotation_Join.Barcode),Quotation_Join.Qty, Quotation_Join.Price,Quotation_Join.DiscountPer,Quotation_Join.DiscountAmt,Quotation_Join. CGSTPer, Quotation_Join.CGSTAmt,Quotation_Join. SGSTPer,Quotation_Join. SGSTAmt,Quotation_Join. IGSTPer,Quotation_Join. IGSTAmt,Quotation_Join. CESSPer,Quotation_Join.CESSAmt,Quotation_Join.TotalAmount,Quotation_Join.AltQty,RTRIM(Quotation_Join.AltUnit),RTRIM(Quotation_Join.STaxType),Quotation_Join.TaxableAmt,RTRIM(Quotation_Join.MainUnit) from quotation,Quotation_Join,Product where quotation.Q_ID=Quotation_Join.QuotationID and Product.PID=Quotation_Join.ProductID and quotation.Q_ID=@d1"
						ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value)))
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						MyProject.Forms.frmQuotation.DataGridView1.Rows.Clear()
						While ModCommonClasses.rdr.Read()
							MyProject.Forms.frmQuotation.DataGridView1.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18), ModCommonClasses.rdr(19), ModCommonClasses.rdr(20), ModCommonClasses.rdr(21) })
						End While
						ModCommonClasses.con.Close()
						MyProject.Forms.frmQuotation.DataGridView1.ClearSelection()
						MyProject.Forms.frmQuotation.Calc()
						MyProject.Forms.frmQuotation.Compute()
						MyProject.Forms.frmQuotation.CTypeStatus()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012234 RID: 74292 RVA: 0x00A6F5AC File Offset: 0x00A6D7AC
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

		' Token: 0x06012235 RID: 74293 RVA: 0x00A6F694 File Offset: 0x00A6D894
		Public Sub fillQuotationNo()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(QuotationNo) FROM quotation", ModCommonClasses.con)
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

		' Token: 0x06012236 RID: 74294 RVA: 0x00A6F7C8 File Offset: 0x00A6D9C8
		Public Sub Reset()
			Me.cmbQuotationNo.SelectedIndex = -1
			Me.cmbQuotationNo.Text = ""
			Me.txtCustomerName.Text = ""
			Me.fillQuotationNo()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x06012237 RID: 74295 RVA: 0x00A6F82C File Offset: 0x00A6DA2C
		Private Sub cmbOrderNo_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(quotation.Remarks) from Customer,quotation where Customer.ID=quotation.CustomerID and QuotationNo='" + Me.cmbQuotationNo.Text + "' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012238 RID: 74296 RVA: 0x00A6FAD4 File Offset: 0x00A6DCD4
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.cmbQuotationNo.SelectedIndex = -1
				Me.cmbQuotationNo.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(quotation.Remarks) from Customer,quotation where Customer.ID=quotation.CustomerID and Name like N'" + Me.txtCustomerName.Text + "%' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x06012239 RID: 74297 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbQuotationNo_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0601223A RID: 74298 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmQuotationRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601223B RID: 74299 RVA: 0x00A6FD88 File Offset: 0x00A6DF88
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

		' Token: 0x0601223C RID: 74300 RVA: 0x00A6FEA0 File Offset: 0x00A6E0A0
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.cmbQuotationNo.SelectedIndex = -1
				Me.cmbQuotationNo.Text = ""
				Me.txtCustomerName.Text = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Q_ID, RTRIM(QuotationNo), Date,RTRIM(TaxType),Customer.ID,RTRIM(Customer.CustomerID),RTRIM(Name), RTRIM(ContactNo),RTRIM(State),RTRIM(GSTIN),SubTotal,CGST,SGST,IGST,CESS,Total,RoundOff,GrandTotal, RTRIM(quotation.Remarks) from Customer,quotation where Customer.ID=quotation.CustomerID and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13), ModCommonClasses.rdr(14), ModCommonClasses.rdr(15), ModCommonClasses.rdr(16), ModCommonClasses.rdr(17), ModCommonClasses.rdr(18) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.Calculate()
		End Sub

		' Token: 0x0601223D RID: 74301 RVA: 0x0007C5F8 File Offset: 0x0007A7F8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0601223E RID: 74302 RVA: 0x00A70150 File Offset: 0x00A6E350
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
