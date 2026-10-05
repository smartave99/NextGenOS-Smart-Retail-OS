Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
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
	' Token: 0x020004BE RID: 1214
	<DesignerGenerated()>
	Public Partial Class frmCustomerOutstanding
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F2FA RID: 62202 RVA: 0x0006A55E File Offset: 0x0006875E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerOutstanding_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerOutstanding_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D09 RID: 23817
		' (get) Token: 0x0600F2FD RID: 62205 RVA: 0x0006A590 File Offset: 0x00068790
		' (set) Token: 0x0600F2FE RID: 62206 RVA: 0x0006A59A File Offset: 0x0006879A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005D0A RID: 23818
		' (get) Token: 0x0600F2FF RID: 62207 RVA: 0x0006A5A3 File Offset: 0x000687A3
		' (set) Token: 0x0600F300 RID: 62208 RVA: 0x0006A5AD File Offset: 0x000687AD
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D0B RID: 23819
		' (get) Token: 0x0600F301 RID: 62209 RVA: 0x0006A5B6 File Offset: 0x000687B6
		' (set) Token: 0x0600F302 RID: 62210 RVA: 0x0006A5C0 File Offset: 0x000687C0
		Friend Overridable Property Label4 As Label

		' Token: 0x17005D0C RID: 23820
		' (get) Token: 0x0600F303 RID: 62211 RVA: 0x0006A5C9 File Offset: 0x000687C9
		' (set) Token: 0x0600F304 RID: 62212 RVA: 0x0006A5D3 File Offset: 0x000687D3
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005D0D RID: 23821
		' (get) Token: 0x0600F305 RID: 62213 RVA: 0x0006A5DC File Offset: 0x000687DC
		' (set) Token: 0x0600F306 RID: 62214 RVA: 0x0006A5E6 File Offset: 0x000687E6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005D0E RID: 23822
		' (get) Token: 0x0600F307 RID: 62215 RVA: 0x0006A5EF File Offset: 0x000687EF
		' (set) Token: 0x0600F308 RID: 62216 RVA: 0x0006A5F9 File Offset: 0x000687F9
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005D0F RID: 23823
		' (get) Token: 0x0600F309 RID: 62217 RVA: 0x0006A602 File Offset: 0x00068802
		' (set) Token: 0x0600F30A RID: 62218 RVA: 0x0006A60C File Offset: 0x0006880C
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D10 RID: 23824
		' (get) Token: 0x0600F30B RID: 62219 RVA: 0x0006A615 File Offset: 0x00068815
		' (set) Token: 0x0600F30C RID: 62220 RVA: 0x0091D568 File Offset: 0x0091B768
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

		' Token: 0x17005D11 RID: 23825
		' (get) Token: 0x0600F30D RID: 62221 RVA: 0x0006A61F File Offset: 0x0006881F
		' (set) Token: 0x0600F30E RID: 62222 RVA: 0x0006A629 File Offset: 0x00068829
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005D12 RID: 23826
		' (get) Token: 0x0600F30F RID: 62223 RVA: 0x0006A632 File Offset: 0x00068832
		' (set) Token: 0x0600F310 RID: 62224 RVA: 0x0006A63C File Offset: 0x0006883C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005D13 RID: 23827
		' (get) Token: 0x0600F311 RID: 62225 RVA: 0x0006A645 File Offset: 0x00068845
		' (set) Token: 0x0600F312 RID: 62226 RVA: 0x0006A64F File Offset: 0x0006884F
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005D14 RID: 23828
		' (get) Token: 0x0600F313 RID: 62227 RVA: 0x0006A658 File Offset: 0x00068858
		' (set) Token: 0x0600F314 RID: 62228 RVA: 0x0006A662 File Offset: 0x00068862
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005D15 RID: 23829
		' (get) Token: 0x0600F315 RID: 62229 RVA: 0x0006A66B File Offset: 0x0006886B
		' (set) Token: 0x0600F316 RID: 62230 RVA: 0x0006A675 File Offset: 0x00068875
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005D16 RID: 23830
		' (get) Token: 0x0600F317 RID: 62231 RVA: 0x0006A67E File Offset: 0x0006887E
		' (set) Token: 0x0600F318 RID: 62232 RVA: 0x0091D5AC File Offset: 0x0091B7AC
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

		' Token: 0x17005D17 RID: 23831
		' (get) Token: 0x0600F319 RID: 62233 RVA: 0x0006A688 File Offset: 0x00068888
		' (set) Token: 0x0600F31A RID: 62234 RVA: 0x0006A692 File Offset: 0x00068892
		Friend Overridable Property btnReset As GelButton

		' Token: 0x17005D18 RID: 23832
		' (get) Token: 0x0600F31B RID: 62235 RVA: 0x0006A69B File Offset: 0x0006889B
		' (set) Token: 0x0600F31C RID: 62236 RVA: 0x0091D5F0 File Offset: 0x0091B7F0
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

		' Token: 0x17005D19 RID: 23833
		' (get) Token: 0x0600F31D RID: 62237 RVA: 0x0006A6A5 File Offset: 0x000688A5
		' (set) Token: 0x0600F31E RID: 62238 RVA: 0x0091D634 File Offset: 0x0091B834
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

		' Token: 0x17005D1A RID: 23834
		' (get) Token: 0x0600F31F RID: 62239 RVA: 0x0006A6AF File Offset: 0x000688AF
		' (set) Token: 0x0600F320 RID: 62240 RVA: 0x0091D678 File Offset: 0x0091B878
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D1B RID: 23835
		' (get) Token: 0x0600F321 RID: 62241 RVA: 0x0006A6B9 File Offset: 0x000688B9
		' (set) Token: 0x0600F322 RID: 62242 RVA: 0x0091D6BC File Offset: 0x0091B8BC
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D1C RID: 23836
		' (get) Token: 0x0600F323 RID: 62243 RVA: 0x0006A6C3 File Offset: 0x000688C3
		' (set) Token: 0x0600F324 RID: 62244 RVA: 0x0091D700 File Offset: 0x0091B900
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

		' Token: 0x17005D1D RID: 23837
		' (get) Token: 0x0600F325 RID: 62245 RVA: 0x0006A6CD File Offset: 0x000688CD
		' (set) Token: 0x0600F326 RID: 62246 RVA: 0x0091D744 File Offset: 0x0091B944
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

		' Token: 0x17005D1E RID: 23838
		' (get) Token: 0x0600F327 RID: 62247 RVA: 0x0006A6D7 File Offset: 0x000688D7
		' (set) Token: 0x0600F328 RID: 62248 RVA: 0x0006A6E1 File Offset: 0x000688E1
		Friend Overridable Property lblUser As Label

		' Token: 0x0600F329 RID: 62249 RVA: 0x0091D788 File Offset: 0x0091B988
		Private Sub frmCustomerOutstanding_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F32A RID: 62250 RVA: 0x0091D824 File Offset: 0x0091BA24
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

		' Token: 0x0600F32B RID: 62251 RVA: 0x0091D99C File Offset: 0x0091BB9C
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

		' Token: 0x0600F32C RID: 62252 RVA: 0x0091DA68 File Offset: 0x0091BC68
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

		' Token: 0x0600F32D RID: 62253 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F32E RID: 62254 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F32F RID: 62255 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F330 RID: 62256 RVA: 0x0091DB34 File Offset: 0x0091BD34
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600F331 RID: 62257 RVA: 0x0091DC10 File Offset: 0x0091BE10
		Private Sub Customeros()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select CustNameid, Sum(Credit), Sum(Debit), Sum(Debit)-Sum(Credit) from CustomerLedgerBook where Date between @d1 and @d2 Group By CustNameid order by CustNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F332 RID: 62258 RVA: 0x0091DDA8 File Offset: 0x0091BFA8
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

		' Token: 0x0600F333 RID: 62259 RVA: 0x0091DE90 File Offset: 0x0091C090
		Private Sub Condition1()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = True
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F334 RID: 62260 RVA: 0x0091DFF0 File Offset: 0x0091C1F0
		Private Sub Condition2()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = True
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F335 RID: 62261 RVA: 0x0091E150 File Offset: 0x0091C350
		Private Sub Condition3()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = True
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F336 RID: 62262 RVA: 0x0091E2B0 File Offset: 0x0091C4B0
		Private Sub Condition4()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = True
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = True
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = True
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F337 RID: 62263 RVA: 0x0091E410 File Offset: 0x0091C610
		Private Sub Condition5()
			Try
				For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(dataGridViewRow.Cells(3).Value, 0, False)
					If flag Then
						dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
						dataGridViewRow.DefaultCellStyle.BackColor = Color.Red
						dataGridViewRow.Visible = False
					Else
						Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(dataGridViewRow.Cells(3).Value, 0, False)
						If flag2 Then
							dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
							dataGridViewRow.DefaultCellStyle.BackColor = Color.Blue
							dataGridViewRow.Visible = False
						Else
							Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(dataGridViewRow.Cells(3).Value, 0, False)
							If flag3 Then
								dataGridViewRow.DefaultCellStyle.ForeColor = Color.White
								dataGridViewRow.DefaultCellStyle.BackColor = Color.Green
								dataGridViewRow.Visible = False
							End If
						End If
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600F338 RID: 62264 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerOutstanding_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F339 RID: 62265 RVA: 0x0091E570 File Offset: 0x0091C770
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

		' Token: 0x0600F33A RID: 62266 RVA: 0x0006A6EA File Offset: 0x000688EA
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Condition5()
			Me.dgw.Rows.Clear()
		End Sub

		' Token: 0x0600F33B RID: 62267 RVA: 0x0006A71D File Offset: 0x0006891D
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition4()
		End Sub

		' Token: 0x0600F33C RID: 62268 RVA: 0x0006A72E File Offset: 0x0006892E
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition1()
		End Sub

		' Token: 0x0600F33D RID: 62269 RVA: 0x0006A73F File Offset: 0x0006893F
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition2()
		End Sub

		' Token: 0x0600F33E RID: 62270 RVA: 0x0006A750 File Offset: 0x00068950
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Me.Customeros()
			Me.Condition3()
		End Sub

		' Token: 0x0600F33F RID: 62271 RVA: 0x0091E81C File Offset: 0x0091CA1C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmScreenlock.txtuser.Text = "sadmin"
				MyProject.Forms.frmScreenlock.Label2.Text = "Security Checked"
				MyProject.Forms.frmScreenlock.ShowDialog()
				MyProject.Forms.frmScreenlock.Dispose()
				Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
				openFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
				Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK AndAlso Operators.CompareString(openFileDialog.FileName, "", False) <> 0
				If flag Then
					Me.Cursor = Cursors.WaitCursor
					Dim fileName As String = openFileDialog.FileName
					Dim oleDbConnection As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;")
					Dim oleDbDataAdapter As OleDbDataAdapter = New OleDbDataAdapter("select * from [Export File$]", oleDbConnection)
					oleDbConnection.Open()
					ModCommonClasses.dtable = New DataTable()
					oleDbDataAdapter.Fill(ModCommonClasses.dtable)
					Try
						For Each obj As Object In ModCommonClasses.dtable.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim text As String = dataRow(0).ToString()
							Dim text2 As String = dataRow(1).ToString()
							Dim text3 As String = dataRow(2).ToString()
							Dim text4 As String = dataRow(3).ToString()
							Dim array As String() = text.Split(New Char() { "-"c })
							Dim text5 As String = array(1) + "-" + array(2)
							SqlConnection.ClearAllPools()
							ModFunc.LedgerSave(DateAndTime.Today, text, text5, "Opening Balance", New Decimal(Conversion.Val(text3)), 0D, text5, text)
							ModFunc.CustomerLedgerSave(DateAndTime.Today, text, text5, "Opening Balance", New Decimal(Conversion.Val(text3)), 0D, text5, text, "OLD CUSTOMER Debit Amount")
							ModFunc.LedgerSave(DateAndTime.Today, text, text5, "Opening Balance", 0D, New Decimal(Conversion.Val(text2)), text5, text)
							ModFunc.CustomerLedgerSave(DateAndTime.Today, text, text5, "Opening Balance", 0D, New Decimal(Conversion.Val(text2)), text5, text, "OLD CUSTOMER Credit Amount")
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					MessageBox.Show("Successfully imported")
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message + "ONCLICK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
