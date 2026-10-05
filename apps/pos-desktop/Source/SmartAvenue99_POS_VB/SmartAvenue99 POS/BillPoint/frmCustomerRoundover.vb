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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004BF RID: 1215
	<DesignerGenerated()>
	Public Partial Class frmCustomerRoundover
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F340 RID: 62272 RVA: 0x0006A761 File Offset: 0x00068961
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerRoundover_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerRoundover_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D1F RID: 23839
		' (get) Token: 0x0600F343 RID: 62275 RVA: 0x0006A793 File Offset: 0x00068993
		' (set) Token: 0x0600F344 RID: 62276 RVA: 0x0006A79D File Offset: 0x0006899D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005D20 RID: 23840
		' (get) Token: 0x0600F345 RID: 62277 RVA: 0x0006A7A6 File Offset: 0x000689A6
		' (set) Token: 0x0600F346 RID: 62278 RVA: 0x0006A7B0 File Offset: 0x000689B0
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005D21 RID: 23841
		' (get) Token: 0x0600F347 RID: 62279 RVA: 0x0006A7B9 File Offset: 0x000689B9
		' (set) Token: 0x0600F348 RID: 62280 RVA: 0x0006A7C3 File Offset: 0x000689C3
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D22 RID: 23842
		' (get) Token: 0x0600F349 RID: 62281 RVA: 0x0006A7CC File Offset: 0x000689CC
		' (set) Token: 0x0600F34A RID: 62282 RVA: 0x0006A7D6 File Offset: 0x000689D6
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17005D23 RID: 23843
		' (get) Token: 0x0600F34B RID: 62283 RVA: 0x0006A7DF File Offset: 0x000689DF
		' (set) Token: 0x0600F34C RID: 62284 RVA: 0x0091FAF4 File Offset: 0x0091DCF4
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

		' Token: 0x17005D24 RID: 23844
		' (get) Token: 0x0600F34D RID: 62285 RVA: 0x0006A7E9 File Offset: 0x000689E9
		' (set) Token: 0x0600F34E RID: 62286 RVA: 0x0006A7F3 File Offset: 0x000689F3
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005D25 RID: 23845
		' (get) Token: 0x0600F34F RID: 62287 RVA: 0x0006A7FC File Offset: 0x000689FC
		' (set) Token: 0x0600F350 RID: 62288 RVA: 0x0006A806 File Offset: 0x00068A06
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005D26 RID: 23846
		' (get) Token: 0x0600F351 RID: 62289 RVA: 0x0006A80F File Offset: 0x00068A0F
		' (set) Token: 0x0600F352 RID: 62290 RVA: 0x0006A819 File Offset: 0x00068A19
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005D27 RID: 23847
		' (get) Token: 0x0600F353 RID: 62291 RVA: 0x0006A822 File Offset: 0x00068A22
		' (set) Token: 0x0600F354 RID: 62292 RVA: 0x0006A82C File Offset: 0x00068A2C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005D28 RID: 23848
		' (get) Token: 0x0600F355 RID: 62293 RVA: 0x0006A835 File Offset: 0x00068A35
		' (set) Token: 0x0600F356 RID: 62294 RVA: 0x0006A83F File Offset: 0x00068A3F
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17005D29 RID: 23849
		' (get) Token: 0x0600F357 RID: 62295 RVA: 0x0006A848 File Offset: 0x00068A48
		' (set) Token: 0x0600F358 RID: 62296 RVA: 0x0006A852 File Offset: 0x00068A52
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17005D2A RID: 23850
		' (get) Token: 0x0600F359 RID: 62297 RVA: 0x0006A85B File Offset: 0x00068A5B
		' (set) Token: 0x0600F35A RID: 62298 RVA: 0x0006A865 File Offset: 0x00068A65
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005D2B RID: 23851
		' (get) Token: 0x0600F35B RID: 62299 RVA: 0x0006A86E File Offset: 0x00068A6E
		' (set) Token: 0x0600F35C RID: 62300 RVA: 0x0006A878 File Offset: 0x00068A78
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005D2C RID: 23852
		' (get) Token: 0x0600F35D RID: 62301 RVA: 0x0006A881 File Offset: 0x00068A81
		' (set) Token: 0x0600F35E RID: 62302 RVA: 0x0006A88B File Offset: 0x00068A8B
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17005D2D RID: 23853
		' (get) Token: 0x0600F35F RID: 62303 RVA: 0x0006A894 File Offset: 0x00068A94
		' (set) Token: 0x0600F360 RID: 62304 RVA: 0x0006A89E File Offset: 0x00068A9E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005D2E RID: 23854
		' (get) Token: 0x0600F361 RID: 62305 RVA: 0x0006A8A7 File Offset: 0x00068AA7
		' (set) Token: 0x0600F362 RID: 62306 RVA: 0x0006A8B1 File Offset: 0x00068AB1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17005D2F RID: 23855
		' (get) Token: 0x0600F363 RID: 62307 RVA: 0x0006A8BA File Offset: 0x00068ABA
		' (set) Token: 0x0600F364 RID: 62308 RVA: 0x0091FB38 File Offset: 0x0091DD38
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

		' Token: 0x17005D30 RID: 23856
		' (get) Token: 0x0600F365 RID: 62309 RVA: 0x0006A8C4 File Offset: 0x00068AC4
		' (set) Token: 0x0600F366 RID: 62310 RVA: 0x0006A8CE File Offset: 0x00068ACE
		Friend Overridable Property Label2 As Label

		' Token: 0x17005D31 RID: 23857
		' (get) Token: 0x0600F367 RID: 62311 RVA: 0x0006A8D7 File Offset: 0x00068AD7
		' (set) Token: 0x0600F368 RID: 62312 RVA: 0x0091FB7C File Offset: 0x0091DD7C
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

		' Token: 0x17005D32 RID: 23858
		' (get) Token: 0x0600F369 RID: 62313 RVA: 0x0006A8E1 File Offset: 0x00068AE1
		' (set) Token: 0x0600F36A RID: 62314 RVA: 0x0091FBC0 File Offset: 0x0091DDC0
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

		' Token: 0x17005D33 RID: 23859
		' (get) Token: 0x0600F36B RID: 62315 RVA: 0x0006A8EB File Offset: 0x00068AEB
		' (set) Token: 0x0600F36C RID: 62316 RVA: 0x0091FC04 File Offset: 0x0091DE04
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600F36D RID: 62317 RVA: 0x0091FC48 File Offset: 0x0091DE48
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

		' Token: 0x0600F36E RID: 62318 RVA: 0x0006A8F5 File Offset: 0x00068AF5
		Private Sub frmCustomerRoundover_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F36F RID: 62319 RVA: 0x0091FD24 File Offset: 0x0091DF24
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

		' Token: 0x0600F370 RID: 62320 RVA: 0x0091FE9C File Offset: 0x0091E09C
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

		' Token: 0x0600F371 RID: 62321 RVA: 0x0091FF58 File Offset: 0x0091E158
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

		' Token: 0x0600F372 RID: 62322 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F373 RID: 62323 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F374 RID: 62324 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F375 RID: 62325 RVA: 0x00920024 File Offset: 0x0091E224
		Private Sub datecal()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim dateTime As DateTime = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column1").Value))
					Dim dateTime2 As DateTime = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column4").Value))
					Dim timeSpan As TimeSpan = dateTime - dateTime2
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(8).Value))
					If flag Then
						Me.dgw.Rows(i).Cells("Column5").Value = timeSpan.Days
					Else
						Me.dgw.Rows(i).Cells(8).Value = 0
					End If
					Dim flag2 As Boolean = Operators.ConditionalCompareObjectLess(timeSpan.Days, Me.dgw.Rows(i).Cells(7).Value, False)
					If flag2 Then
						Me.dgw.Rows(i).Cells(9).Value = "0"
					Else
						Dim flag3 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells(9).Value))
						If flag3 Then
							' The following expression was wrapped in a unchecked-expression
							Me.dgw.Rows(i).Cells(9).Value = Conversions.ToDouble(Me.dgw.Rows(i).Cells(8).Value) - CDbl(Conversions.ToInteger(Me.dgw.Rows(i).Cells(7).Value))
						End If
					End If
				Next
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600F376 RID: 62326 RVA: 0x0092029C File Offset: 0x0091E49C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select DISTINCT RTRIM(Name),RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),Lvisitdate,RTRIM(Taround) from Customer WHERE Taround > 0", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), DateAndTime.Today, ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), "", "" })
					Me.datecal()
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F377 RID: 62327 RVA: 0x00920418 File Offset: 0x0091E618
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

		' Token: 0x0600F378 RID: 62328 RVA: 0x00920500 File Offset: 0x0091E700
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select DISTINCT RTRIM(Name),RTRIM(CustomerID),RTRIM(Address),RTRIM(State),RTRIM(ContactNo),Lvisitdate,RTRIM(Taround) from Customer WHERE Taround > 0 and Name like N'%" + Me.TextBox1.Text + "%'", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), DateAndTime.Today, ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), "", "" })
					Me.datecal()
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F379 RID: 62329 RVA: 0x0006A90D File Offset: 0x00068B0D
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600F37A RID: 62330 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerRoundover_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F37B RID: 62331 RVA: 0x00920690 File Offset: 0x0091E890
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dgw.RowCount = 0
			If flag Then
				MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim dataTable As DataTable = New DataTable()
				Dim dataTable2 As DataTable = dataTable
				dataTable2.Columns.Add("a")
				dataTable2.Columns.Add("b")
				dataTable2.Columns.Add("c")
				dataTable2.Columns.Add("d")
				dataTable2.Columns.Add("e")
				dataTable2.Columns.Add("f")
				dataTable2.Columns.Add("g")
				dataTable2.Columns.Add("h")
				dataTable2.Columns.Add("i")
				dataTable2.Columns.Add("k")
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataTable.Rows.Add(New Object() { dataGridViewRow.Cells(0).Value, dataGridViewRow.Cells(1).Value, dataGridViewRow.Cells(2).Value, dataGridViewRow.Cells(3).Value, dataGridViewRow.Cells(4).Value, dataGridViewRow.Cells(5).Value, dataGridViewRow.Cells(6).Value, dataGridViewRow.Cells(7).Value, dataGridViewRow.Cells(8).Value, dataGridViewRow.Cells(9).Value })
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim reportDocument As ReportDocument = New rptTurnAround()
				reportDocument.SetDataSource(dataTable)
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = reportDocument
				MyProject.Forms.frmReport.ShowDialog()
				MyProject.Forms.frmReport.Dispose()
			End If
		End Sub

		' Token: 0x0600F37C RID: 62332 RVA: 0x0006A929 File Offset: 0x00068B29
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.fyear()
			Me.Getdata()
		End Sub
	End Class
End Namespace
