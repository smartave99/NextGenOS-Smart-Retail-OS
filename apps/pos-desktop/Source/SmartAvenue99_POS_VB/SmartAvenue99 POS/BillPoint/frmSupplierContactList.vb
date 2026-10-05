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
	' Token: 0x020004DE RID: 1246
	<DesignerGenerated()>
	Public Partial Class frmSupplierContactList
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FDDE RID: 64990 RVA: 0x0006F3F0 File Offset: 0x0006D5F0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSupplierContactList_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplierContactList_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006106 RID: 24838
		' (get) Token: 0x0600FDE1 RID: 64993 RVA: 0x0006F422 File Offset: 0x0006D622
		' (set) Token: 0x0600FDE2 RID: 64994 RVA: 0x0006F42C File Offset: 0x0006D62C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006107 RID: 24839
		' (get) Token: 0x0600FDE3 RID: 64995 RVA: 0x0006F435 File Offset: 0x0006D635
		' (set) Token: 0x0600FDE4 RID: 64996 RVA: 0x0006F43F File Offset: 0x0006D63F
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006108 RID: 24840
		' (get) Token: 0x0600FDE5 RID: 64997 RVA: 0x0006F448 File Offset: 0x0006D648
		' (set) Token: 0x0600FDE6 RID: 64998 RVA: 0x0097D608 File Offset: 0x0097B808
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

		' Token: 0x17006109 RID: 24841
		' (get) Token: 0x0600FDE7 RID: 64999 RVA: 0x0006F452 File Offset: 0x0006D652
		' (set) Token: 0x0600FDE8 RID: 65000 RVA: 0x0097D64C File Offset: 0x0097B84C
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

		' Token: 0x1700610A RID: 24842
		' (get) Token: 0x0600FDE9 RID: 65001 RVA: 0x0006F45C File Offset: 0x0006D65C
		' (set) Token: 0x0600FDEA RID: 65002 RVA: 0x0006F466 File Offset: 0x0006D666
		Friend Overridable Property Label4 As Label

		' Token: 0x1700610B RID: 24843
		' (get) Token: 0x0600FDEB RID: 65003 RVA: 0x0006F46F File Offset: 0x0006D66F
		' (set) Token: 0x0600FDEC RID: 65004 RVA: 0x0006F479 File Offset: 0x0006D679
		Friend Overridable Property Label3 As Label

		' Token: 0x1700610C RID: 24844
		' (get) Token: 0x0600FDED RID: 65005 RVA: 0x0006F482 File Offset: 0x0006D682
		' (set) Token: 0x0600FDEE RID: 65006 RVA: 0x0006F48C File Offset: 0x0006D68C
		Friend Overridable Property Label2 As Label

		' Token: 0x1700610D RID: 24845
		' (get) Token: 0x0600FDEF RID: 65007 RVA: 0x0006F495 File Offset: 0x0006D695
		' (set) Token: 0x0600FDF0 RID: 65008 RVA: 0x0097D690 File Offset: 0x0097B890
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

		' Token: 0x1700610E RID: 24846
		' (get) Token: 0x0600FDF1 RID: 65009 RVA: 0x0006F49F File Offset: 0x0006D69F
		' (set) Token: 0x0600FDF2 RID: 65010 RVA: 0x0097D6D4 File Offset: 0x0097B8D4
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

		' Token: 0x1700610F RID: 24847
		' (get) Token: 0x0600FDF3 RID: 65011 RVA: 0x0006F4A9 File Offset: 0x0006D6A9
		' (set) Token: 0x0600FDF4 RID: 65012 RVA: 0x0097D718 File Offset: 0x0097B918
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

		' Token: 0x17006110 RID: 24848
		' (get) Token: 0x0600FDF5 RID: 65013 RVA: 0x0006F4B3 File Offset: 0x0006D6B3
		' (set) Token: 0x0600FDF6 RID: 65014 RVA: 0x0097D75C File Offset: 0x0097B95C
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

		' Token: 0x17006111 RID: 24849
		' (get) Token: 0x0600FDF7 RID: 65015 RVA: 0x0006F4BD File Offset: 0x0006D6BD
		' (set) Token: 0x0600FDF8 RID: 65016 RVA: 0x0006F4C7 File Offset: 0x0006D6C7
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006112 RID: 24850
		' (get) Token: 0x0600FDF9 RID: 65017 RVA: 0x0006F4D0 File Offset: 0x0006D6D0
		' (set) Token: 0x0600FDFA RID: 65018 RVA: 0x0006F4DA File Offset: 0x0006D6DA
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006113 RID: 24851
		' (get) Token: 0x0600FDFB RID: 65019 RVA: 0x0006F4E3 File Offset: 0x0006D6E3
		' (set) Token: 0x0600FDFC RID: 65020 RVA: 0x0006F4ED File Offset: 0x0006D6ED
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006114 RID: 24852
		' (get) Token: 0x0600FDFD RID: 65021 RVA: 0x0006F4F6 File Offset: 0x0006D6F6
		' (set) Token: 0x0600FDFE RID: 65022 RVA: 0x0006F500 File Offset: 0x0006D700
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x17006115 RID: 24853
		' (get) Token: 0x0600FDFF RID: 65023 RVA: 0x0006F509 File Offset: 0x0006D709
		' (set) Token: 0x0600FE00 RID: 65024 RVA: 0x0006F513 File Offset: 0x0006D713
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006116 RID: 24854
		' (get) Token: 0x0600FE01 RID: 65025 RVA: 0x0006F51C File Offset: 0x0006D71C
		' (set) Token: 0x0600FE02 RID: 65026 RVA: 0x0006F526 File Offset: 0x0006D726
		Friend Overridable Property Label1 As Label

		' Token: 0x17006117 RID: 24855
		' (get) Token: 0x0600FE03 RID: 65027 RVA: 0x0006F52F File Offset: 0x0006D72F
		' (set) Token: 0x0600FE04 RID: 65028 RVA: 0x0006F539 File Offset: 0x0006D739
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x0600FE05 RID: 65029 RVA: 0x0097D7BC File Offset: 0x0097B9BC
		Private Sub frmSupplierContactList_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FE06 RID: 65030 RVA: 0x0097D844 File Offset: 0x0097BA44
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

		' Token: 0x0600FE07 RID: 65031 RVA: 0x0097D9BC File Offset: 0x0097BBBC
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

		' Token: 0x0600FE08 RID: 65032 RVA: 0x0097DA78 File Offset: 0x0097BC78
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

		' Token: 0x0600FE09 RID: 65033 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600FE0A RID: 65034 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600FE0B RID: 65035 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600FE0C RID: 65036 RVA: 0x0097DB44 File Offset: 0x0097BD44
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SupplierID),RTRIM([Name]),RTRIM(ContactNo),Photo from Supplier order by name", ModCommonClasses.con)
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

		' Token: 0x0600FE0D RID: 65037 RVA: 0x0097DC50 File Offset: 0x0097BE50
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SupplierID),RTRIM([Name]), RTRIM(ContactNo), Photo from Supplier where SupplierID like N'%" + Me.TextBox1.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600FE0E RID: 65038 RVA: 0x0097DD74 File Offset: 0x0097BF74
		Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SupplierID),RTRIM([Name]), RTRIM(ContactNo), Photo from Supplier where Name like N'%" + Me.TextBox2.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600FE0F RID: 65039 RVA: 0x0097DE98 File Offset: 0x0097C098
		Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(SupplierID),RTRIM([Name]), RTRIM(ContactNo), Photo from Supplier where ContactNo like N'%" + Me.TextBox3.Text + "%' order by Name", ModCommonClasses.con)
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

		' Token: 0x0600FE10 RID: 65040 RVA: 0x0097DFBC File Offset: 0x0097C1BC
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

		' Token: 0x0600FE11 RID: 65041 RVA: 0x0006F542 File Offset: 0x0006D742
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
			Me.Getdata()
		End Sub

		' Token: 0x0600FE12 RID: 65042 RVA: 0x0097E0A4 File Offset: 0x0097C2A4
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

		' Token: 0x0600FE13 RID: 65043 RVA: 0x0097E350 File Offset: 0x0097C550
		Private Sub dgw_MouseDoubleClick(sender As Object, e As MouseEventArgs)
			Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
			Dim array As Byte() = CType(dataGridViewRow.Cells(3).Value, Byte())
			Dim memoryStream As MemoryStream = New MemoryStream(array)
			MyProject.Forms.frmContactPhoto.PictureBox1.Image = Image.FromStream(memoryStream)
			MyProject.Forms.frmContactPhoto.ShowDialog()
			MyProject.Forms.frmContactPhoto.Dispose()
		End Sub

		' Token: 0x0600FE14 RID: 65044 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplierContactList_KeyDown(sender As Object, e As KeyEventArgs)
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
