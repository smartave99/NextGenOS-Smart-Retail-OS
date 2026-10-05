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
	' Token: 0x0200029B RID: 667
	<DesignerGenerated()>
	Public Partial Class frmCustomerDiscRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A8D0 RID: 43216 RVA: 0x0004EA76 File Offset: 0x0004CC76
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerDiscRecord_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerDiscRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004161 RID: 16737
		' (get) Token: 0x0600A8D3 RID: 43219 RVA: 0x0004EAA8 File Offset: 0x0004CCA8
		' (set) Token: 0x0600A8D4 RID: 43220 RVA: 0x0004EAB2 File Offset: 0x0004CCB2
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004162 RID: 16738
		' (get) Token: 0x0600A8D5 RID: 43221 RVA: 0x0004EABB File Offset: 0x0004CCBB
		' (set) Token: 0x0600A8D6 RID: 43222 RVA: 0x0004EAC5 File Offset: 0x0004CCC5
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004163 RID: 16739
		' (get) Token: 0x0600A8D7 RID: 43223 RVA: 0x0004EACE File Offset: 0x0004CCCE
		' (set) Token: 0x0600A8D8 RID: 43224 RVA: 0x0004EAD8 File Offset: 0x0004CCD8
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004164 RID: 16740
		' (get) Token: 0x0600A8D9 RID: 43225 RVA: 0x0004EAE1 File Offset: 0x0004CCE1
		' (set) Token: 0x0600A8DA RID: 43226 RVA: 0x0004EAEB File Offset: 0x0004CCEB
		Friend Overridable Property Label3 As Label

		' Token: 0x17004165 RID: 16741
		' (get) Token: 0x0600A8DB RID: 43227 RVA: 0x0004EAF4 File Offset: 0x0004CCF4
		' (set) Token: 0x0600A8DC RID: 43228 RVA: 0x007111C4 File Offset: 0x0070F3C4
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

		' Token: 0x17004166 RID: 16742
		' (get) Token: 0x0600A8DD RID: 43229 RVA: 0x0004EAFE File Offset: 0x0004CCFE
		' (set) Token: 0x0600A8DE RID: 43230 RVA: 0x00711208 File Offset: 0x0070F408
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004167 RID: 16743
		' (get) Token: 0x0600A8DF RID: 43231 RVA: 0x0004EB08 File Offset: 0x0004CD08
		' (set) Token: 0x0600A8E0 RID: 43232 RVA: 0x0004EB12 File Offset: 0x0004CD12
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004168 RID: 16744
		' (get) Token: 0x0600A8E1 RID: 43233 RVA: 0x0004EB1B File Offset: 0x0004CD1B
		' (set) Token: 0x0600A8E2 RID: 43234 RVA: 0x0004EB25 File Offset: 0x0004CD25
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004169 RID: 16745
		' (get) Token: 0x0600A8E3 RID: 43235 RVA: 0x0004EB2E File Offset: 0x0004CD2E
		' (set) Token: 0x0600A8E4 RID: 43236 RVA: 0x0004EB38 File Offset: 0x0004CD38
		Friend Overridable Property Label2 As Label

		' Token: 0x1700416A RID: 16746
		' (get) Token: 0x0600A8E5 RID: 43237 RVA: 0x0004EB41 File Offset: 0x0004CD41
		' (set) Token: 0x0600A8E6 RID: 43238 RVA: 0x0004EB4B File Offset: 0x0004CD4B
		Friend Overridable Property Label4 As Label

		' Token: 0x1700416B RID: 16747
		' (get) Token: 0x0600A8E7 RID: 43239 RVA: 0x0004EB54 File Offset: 0x0004CD54
		' (set) Token: 0x0600A8E8 RID: 43240 RVA: 0x0004EB5E File Offset: 0x0004CD5E
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700416C RID: 16748
		' (get) Token: 0x0600A8E9 RID: 43241 RVA: 0x0004EB67 File Offset: 0x0004CD67
		' (set) Token: 0x0600A8EA RID: 43242 RVA: 0x0004EB71 File Offset: 0x0004CD71
		Friend Overridable Property Panel5 As Panel

		' Token: 0x1700416D RID: 16749
		' (get) Token: 0x0600A8EB RID: 43243 RVA: 0x0004EB7A File Offset: 0x0004CD7A
		' (set) Token: 0x0600A8EC RID: 43244 RVA: 0x0071124C File Offset: 0x0070F44C
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

		' Token: 0x1700416E RID: 16750
		' (get) Token: 0x0600A8ED RID: 43245 RVA: 0x0004EB84 File Offset: 0x0004CD84
		' (set) Token: 0x0600A8EE RID: 43246 RVA: 0x0004EB8E File Offset: 0x0004CD8E
		Friend Overridable Property Label1 As Label

		' Token: 0x1700416F RID: 16751
		' (get) Token: 0x0600A8EF RID: 43247 RVA: 0x0004EB97 File Offset: 0x0004CD97
		' (set) Token: 0x0600A8F0 RID: 43248 RVA: 0x0004EBA1 File Offset: 0x0004CDA1
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004170 RID: 16752
		' (get) Token: 0x0600A8F1 RID: 43249 RVA: 0x0004EBAA File Offset: 0x0004CDAA
		' (set) Token: 0x0600A8F2 RID: 43250 RVA: 0x0004EBB4 File Offset: 0x0004CDB4
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004171 RID: 16753
		' (get) Token: 0x0600A8F3 RID: 43251 RVA: 0x0004EBBD File Offset: 0x0004CDBD
		' (set) Token: 0x0600A8F4 RID: 43252 RVA: 0x0004EBC7 File Offset: 0x0004CDC7
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004172 RID: 16754
		' (get) Token: 0x0600A8F5 RID: 43253 RVA: 0x0004EBD0 File Offset: 0x0004CDD0
		' (set) Token: 0x0600A8F6 RID: 43254 RVA: 0x0004EBDA File Offset: 0x0004CDDA
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004173 RID: 16755
		' (get) Token: 0x0600A8F7 RID: 43255 RVA: 0x0004EBE3 File Offset: 0x0004CDE3
		' (set) Token: 0x0600A8F8 RID: 43256 RVA: 0x0004EBED File Offset: 0x0004CDED
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004174 RID: 16756
		' (get) Token: 0x0600A8F9 RID: 43257 RVA: 0x0004EBF6 File Offset: 0x0004CDF6
		' (set) Token: 0x0600A8FA RID: 43258 RVA: 0x0004EC00 File Offset: 0x0004CE00
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004175 RID: 16757
		' (get) Token: 0x0600A8FB RID: 43259 RVA: 0x0004EC09 File Offset: 0x0004CE09
		' (set) Token: 0x0600A8FC RID: 43260 RVA: 0x0004EC13 File Offset: 0x0004CE13
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x17004176 RID: 16758
		' (get) Token: 0x0600A8FD RID: 43261 RVA: 0x0004EC1C File Offset: 0x0004CE1C
		' (set) Token: 0x0600A8FE RID: 43262 RVA: 0x0004EC26 File Offset: 0x0004CE26
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x17004177 RID: 16759
		' (get) Token: 0x0600A8FF RID: 43263 RVA: 0x0004EC2F File Offset: 0x0004CE2F
		' (set) Token: 0x0600A900 RID: 43264 RVA: 0x0004EC39 File Offset: 0x0004CE39
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x17004178 RID: 16760
		' (get) Token: 0x0600A901 RID: 43265 RVA: 0x0004EC42 File Offset: 0x0004CE42
		' (set) Token: 0x0600A902 RID: 43266 RVA: 0x0004EC4C File Offset: 0x0004CE4C
		Friend Overridable Property Column18 As DataGridViewTextBoxColumn

		' Token: 0x17004179 RID: 16761
		' (get) Token: 0x0600A903 RID: 43267 RVA: 0x0004EC55 File Offset: 0x0004CE55
		' (set) Token: 0x0600A904 RID: 43268 RVA: 0x0004EC5F File Offset: 0x0004CE5F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x1700417A RID: 16762
		' (get) Token: 0x0600A905 RID: 43269 RVA: 0x0004EC68 File Offset: 0x0004CE68
		' (set) Token: 0x0600A906 RID: 43270 RVA: 0x0004EC72 File Offset: 0x0004CE72
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x1700417B RID: 16763
		' (get) Token: 0x0600A907 RID: 43271 RVA: 0x0004EC7B File Offset: 0x0004CE7B
		' (set) Token: 0x0600A908 RID: 43272 RVA: 0x0004EC85 File Offset: 0x0004CE85
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700417C RID: 16764
		' (get) Token: 0x0600A909 RID: 43273 RVA: 0x0004EC8E File Offset: 0x0004CE8E
		' (set) Token: 0x0600A90A RID: 43274 RVA: 0x0004EC98 File Offset: 0x0004CE98
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x1700417D RID: 16765
		' (get) Token: 0x0600A90B RID: 43275 RVA: 0x0004ECA1 File Offset: 0x0004CEA1
		' (set) Token: 0x0600A90C RID: 43276 RVA: 0x0004ECAB File Offset: 0x0004CEAB
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x1700417E RID: 16766
		' (get) Token: 0x0600A90D RID: 43277 RVA: 0x0004ECB4 File Offset: 0x0004CEB4
		' (set) Token: 0x0600A90E RID: 43278 RVA: 0x00711290 File Offset: 0x0070F490
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700417F RID: 16767
		' (get) Token: 0x0600A90F RID: 43279 RVA: 0x0004ECBE File Offset: 0x0004CEBE
		' (set) Token: 0x0600A910 RID: 43280 RVA: 0x007112D4 File Offset: 0x0070F4D4
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004180 RID: 16768
		' (get) Token: 0x0600A911 RID: 43281 RVA: 0x0004ECC8 File Offset: 0x0004CEC8
		' (set) Token: 0x0600A912 RID: 43282 RVA: 0x00711318 File Offset: 0x0070F518
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
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

		' Token: 0x0600A913 RID: 43283 RVA: 0x0071135C File Offset: 0x0070F55C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 order by InvDate", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A914 RID: 43284 RVA: 0x00711594 File Offset: 0x0070F794
		Private Sub frmCustomerDiscRecord_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Calculate()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600A915 RID: 43285 RVA: 0x00711624 File Offset: 0x0070F824
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

		' Token: 0x0600A916 RID: 43286 RVA: 0x007118C4 File Offset: 0x0070FAC4
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

		' Token: 0x0600A917 RID: 43287 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600A918 RID: 43288 RVA: 0x00711980 File Offset: 0x0070FB80
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

		' Token: 0x0600A919 RID: 43289 RVA: 0x00711A68 File Offset: 0x0070FC68
		Public Sub Reset()
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
			Me.Calculate()
		End Sub

		' Token: 0x0600A91A RID: 43290 RVA: 0x00711AC0 File Offset: 0x0070FCC0
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(8).Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(8).Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total Discount Amt : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600A91B RID: 43291 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerDiscRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600A91C RID: 43292 RVA: 0x00711BD0 File Offset: 0x0070FDD0
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 and InvNo like N'" + Me.TextBox1.Text + "' order by InvDate", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 and CustName like N'" + Me.TextBox1.Text + "%'", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 and CustContact like N'" + Me.TextBox1.Text + "%' order by InvDate", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 and ByBroker like N'" + Me.TextBox1.Text + "%' order by InvDate", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(InvNo), InvDate, RTRIM(CustName), RTRIM(CustAddress), RTRIM(CustContact), RTRIM(InvAmt), RTRIM(InvTaxAmt), RTRIM(AppliedDiscPer), (AppliedDiscAmt), RTRIM(ByBroker), RTRIM(BrokerID), RTRIM(BrokerContact), RTRIM(Item), RTRIM(BCode) FROM CustDiscApply where InvDate between @d1 and @d2 and BrokerContact like N'" + Me.TextBox1.Text + "%' order by InvDate", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									End If
								End If
							End If
						End If
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8), ModCommonClasses.rdr(9), ModCommonClasses.rdr(10), ModCommonClasses.rdr(11), ModCommonClasses.rdr(12), ModCommonClasses.rdr(13) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x0600A91D RID: 43293 RVA: 0x0004ECD2 File Offset: 0x0004CED2
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600A91E RID: 43294 RVA: 0x0004ECE1 File Offset: 0x0004CEE1
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600A91F RID: 43295 RVA: 0x0071214C File Offset: 0x0071034C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
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
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A920 RID: 43296 RVA: 0x0004ECEB File Offset: 0x0004CEEB
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Calculate()
		End Sub
	End Class
End Namespace
