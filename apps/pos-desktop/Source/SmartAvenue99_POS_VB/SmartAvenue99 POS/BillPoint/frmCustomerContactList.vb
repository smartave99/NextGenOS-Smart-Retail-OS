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
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004B9 RID: 1209
	<DesignerGenerated()>
	Public Partial Class frmCustomerContactList
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F277 RID: 62071 RVA: 0x0006A1FF File Offset: 0x000683FF
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerContactList_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerContactList_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005CE0 RID: 23776
		' (get) Token: 0x0600F27A RID: 62074 RVA: 0x0006A231 File Offset: 0x00068431
		' (set) Token: 0x0600F27B RID: 62075 RVA: 0x0006A23B File Offset: 0x0006843B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005CE1 RID: 23777
		' (get) Token: 0x0600F27C RID: 62076 RVA: 0x0006A244 File Offset: 0x00068444
		' (set) Token: 0x0600F27D RID: 62077 RVA: 0x0006A24E File Offset: 0x0006844E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005CE2 RID: 23778
		' (get) Token: 0x0600F27E RID: 62078 RVA: 0x0006A257 File Offset: 0x00068457
		' (set) Token: 0x0600F27F RID: 62079 RVA: 0x0006A261 File Offset: 0x00068461
		Friend Overridable Property Label1 As Label

		' Token: 0x17005CE3 RID: 23779
		' (get) Token: 0x0600F280 RID: 62080 RVA: 0x0006A26A File Offset: 0x0006846A
		' (set) Token: 0x0600F281 RID: 62081 RVA: 0x00918DC8 File Offset: 0x00916FC8
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
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseDoubleClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.MouseDoubleClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CE4 RID: 23780
		' (get) Token: 0x0600F282 RID: 62082 RVA: 0x0006A274 File Offset: 0x00068474
		' (set) Token: 0x0600F283 RID: 62083 RVA: 0x0006A27E File Offset: 0x0006847E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005CE5 RID: 23781
		' (get) Token: 0x0600F284 RID: 62084 RVA: 0x0006A287 File Offset: 0x00068487
		' (set) Token: 0x0600F285 RID: 62085 RVA: 0x0006A291 File Offset: 0x00068491
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005CE6 RID: 23782
		' (get) Token: 0x0600F286 RID: 62086 RVA: 0x0006A29A File Offset: 0x0006849A
		' (set) Token: 0x0600F287 RID: 62087 RVA: 0x0006A2A4 File Offset: 0x000684A4
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005CE7 RID: 23783
		' (get) Token: 0x0600F288 RID: 62088 RVA: 0x0006A2AD File Offset: 0x000684AD
		' (set) Token: 0x0600F289 RID: 62089 RVA: 0x0006A2B7 File Offset: 0x000684B7
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x17005CE8 RID: 23784
		' (get) Token: 0x0600F28A RID: 62090 RVA: 0x0006A2C0 File Offset: 0x000684C0
		' (set) Token: 0x0600F28B RID: 62091 RVA: 0x0006A2CA File Offset: 0x000684CA
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005CE9 RID: 23785
		' (get) Token: 0x0600F28C RID: 62092 RVA: 0x0006A2D3 File Offset: 0x000684D3
		' (set) Token: 0x0600F28D RID: 62093 RVA: 0x00918E28 File Offset: 0x00917028
		Private _TextBox3 As TextBox
		Friend Overridable Property TextBox3 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox3_TextChanged
				Dim textBox As TextBox = Me._TextBox3
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox3 = value
				textBox = Me._TextBox3
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CEA RID: 23786
		' (get) Token: 0x0600F28E RID: 62094 RVA: 0x0006A2DD File Offset: 0x000684DD
		' (set) Token: 0x0600F28F RID: 62095 RVA: 0x00918E6C File Offset: 0x0091706C
		Private _TextBox2 As TextBox
		Friend Overridable Property TextBox2 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox2_TextChanged
				Dim textBox As TextBox = Me._TextBox2
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox2 = value
				textBox = Me._TextBox2
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CEB RID: 23787
		' (get) Token: 0x0600F290 RID: 62096 RVA: 0x0006A2E7 File Offset: 0x000684E7
		' (set) Token: 0x0600F291 RID: 62097 RVA: 0x00918EB0 File Offset: 0x009170B0
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

		' Token: 0x17005CEC RID: 23788
		' (get) Token: 0x0600F292 RID: 62098 RVA: 0x0006A2F1 File Offset: 0x000684F1
		' (set) Token: 0x0600F293 RID: 62099 RVA: 0x0006A2FB File Offset: 0x000684FB
		Friend Overridable Property Label4 As Label

		' Token: 0x17005CED RID: 23789
		' (get) Token: 0x0600F294 RID: 62100 RVA: 0x0006A304 File Offset: 0x00068504
		' (set) Token: 0x0600F295 RID: 62101 RVA: 0x0006A30E File Offset: 0x0006850E
		Friend Overridable Property Label3 As Label

		' Token: 0x17005CEE RID: 23790
		' (get) Token: 0x0600F296 RID: 62102 RVA: 0x0006A317 File Offset: 0x00068517
		' (set) Token: 0x0600F297 RID: 62103 RVA: 0x0006A321 File Offset: 0x00068521
		Friend Overridable Property Label2 As Label

		' Token: 0x17005CEF RID: 23791
		' (get) Token: 0x0600F298 RID: 62104 RVA: 0x0006A32A File Offset: 0x0006852A
		' (set) Token: 0x0600F299 RID: 62105 RVA: 0x00918EF4 File Offset: 0x009170F4
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CF0 RID: 23792
		' (get) Token: 0x0600F29A RID: 62106 RVA: 0x0006A334 File Offset: 0x00068534
		' (set) Token: 0x0600F29B RID: 62107 RVA: 0x00918F38 File Offset: 0x00917138
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005CF1 RID: 23793
		' (get) Token: 0x0600F29C RID: 62108 RVA: 0x0006A33E File Offset: 0x0006853E
		' (set) Token: 0x0600F29D RID: 62109 RVA: 0x0006A348 File Offset: 0x00068548
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600F29E RID: 62110 RVA: 0x00918F7C File Offset: 0x0091717C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID),RTRIM([Name]),RTRIM(ContactNo),Photo from Customer where name not in ('Cash') order by name", ModCommonClasses.con)
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

		' Token: 0x0600F29F RID: 62111 RVA: 0x00919088 File Offset: 0x00917288
		Private Sub frmCustomerContactList_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F2A0 RID: 62112 RVA: 0x00919110 File Offset: 0x00917310
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

		' Token: 0x0600F2A1 RID: 62113 RVA: 0x00919288 File Offset: 0x00917488
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

		' Token: 0x0600F2A2 RID: 62114 RVA: 0x00919344 File Offset: 0x00917544
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

		' Token: 0x0600F2A3 RID: 62115 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F2A4 RID: 62116 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F2A5 RID: 62117 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F2A6 RID: 62118 RVA: 0x00919410 File Offset: 0x00917610
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID),RTRIM([Name]), RTRIM(ContactNo), Photo from Customer where name not in ('Cash') and CustomerID like N'%" + Me.TextBox1.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600F2A7 RID: 62119 RVA: 0x00919534 File Offset: 0x00917734
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID),RTRIM([Name]), RTRIM(ContactNo), Photo from Customer where name not in ('Cash') and Name like N'%" + Me.TextBox2.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600F2A8 RID: 62120 RVA: 0x00919658 File Offset: 0x00917858
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(CustomerID),RTRIM([Name]), RTRIM(ContactNo), Photo from Customer where name not in ('Cash') and ContactNo like N'%" + Me.TextBox3.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600F2A9 RID: 62121 RVA: 0x0091977C File Offset: 0x0091797C
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

		' Token: 0x0600F2AA RID: 62122 RVA: 0x0006A351 File Offset: 0x00068551
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600F2AB RID: 62123 RVA: 0x00919864 File Offset: 0x00917A64
		Private Sub Button2_Click(sender As Object, e As EventArgs)
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

		' Token: 0x0600F2AC RID: 62124 RVA: 0x00919B10 File Offset: 0x00917D10
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
			Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
			Dim memoryStream As MemoryStream = New MemoryStream(array)
			MyProject.Forms.frmContactPhoto.PictureBox1.Image = Image.FromStream(memoryStream)
			MyProject.Forms.frmContactPhoto.ShowDialog()
			MyProject.Forms.frmContactPhoto.Dispose()
		End Sub

		' Token: 0x0600F2AD RID: 62125 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerContactList_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
