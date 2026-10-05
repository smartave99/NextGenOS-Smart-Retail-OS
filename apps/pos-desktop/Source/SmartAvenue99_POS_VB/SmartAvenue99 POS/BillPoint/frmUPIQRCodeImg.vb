Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000372 RID: 882
	<DesignerGenerated()>
	Public Partial Class frmUPIQRCodeImg
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600D035 RID: 53301 RVA: 0x0005C96E File Offset: 0x0005AB6E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmUPIQRCodeImg_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmUPIQRCodeImg_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170051A1 RID: 20897
		' (get) Token: 0x0600D038 RID: 53304 RVA: 0x0005C9A0 File Offset: 0x0005ABA0
		' (set) Token: 0x0600D039 RID: 53305 RVA: 0x0005C9AA File Offset: 0x0005ABAA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170051A2 RID: 20898
		' (get) Token: 0x0600D03A RID: 53306 RVA: 0x0005C9B3 File Offset: 0x0005ABB3
		' (set) Token: 0x0600D03B RID: 53307 RVA: 0x0005C9BD File Offset: 0x0005ABBD
		Friend Overridable Property Panel5 As Panel

		' Token: 0x170051A3 RID: 20899
		' (get) Token: 0x0600D03C RID: 53308 RVA: 0x0005C9C6 File Offset: 0x0005ABC6
		' (set) Token: 0x0600D03D RID: 53309 RVA: 0x0005C9D0 File Offset: 0x0005ABD0
		Friend Overridable Property Label13 As Label

		' Token: 0x170051A4 RID: 20900
		' (get) Token: 0x0600D03E RID: 53310 RVA: 0x0005C9D9 File Offset: 0x0005ABD9
		' (set) Token: 0x0600D03F RID: 53311 RVA: 0x0081DD60 File Offset: 0x0081BF60
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

		' Token: 0x170051A5 RID: 20901
		' (get) Token: 0x0600D040 RID: 53312 RVA: 0x0005C9E3 File Offset: 0x0005ABE3
		' (set) Token: 0x0600D041 RID: 53313 RVA: 0x0005C9ED File Offset: 0x0005ABED
		Friend Overridable Property Label1 As Label

		' Token: 0x170051A6 RID: 20902
		' (get) Token: 0x0600D042 RID: 53314 RVA: 0x0005C9F6 File Offset: 0x0005ABF6
		' (set) Token: 0x0600D043 RID: 53315 RVA: 0x0081DDA4 File Offset: 0x0081BFA4
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
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellEnter
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellEnter, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellEnter, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170051A7 RID: 20903
		' (get) Token: 0x0600D044 RID: 53316 RVA: 0x0005CA00 File Offset: 0x0005AC00
		' (set) Token: 0x0600D045 RID: 53317 RVA: 0x0081DE20 File Offset: 0x0081C020
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051A8 RID: 20904
		' (get) Token: 0x0600D046 RID: 53318 RVA: 0x0005CA0A File Offset: 0x0005AC0A
		' (set) Token: 0x0600D047 RID: 53319 RVA: 0x0005CA14 File Offset: 0x0005AC14
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170051A9 RID: 20905
		' (get) Token: 0x0600D048 RID: 53320 RVA: 0x0005CA1D File Offset: 0x0005AC1D
		' (set) Token: 0x0600D049 RID: 53321 RVA: 0x0005CA27 File Offset: 0x0005AC27
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170051AA RID: 20906
		' (get) Token: 0x0600D04A RID: 53322 RVA: 0x0005CA30 File Offset: 0x0005AC30
		' (set) Token: 0x0600D04B RID: 53323 RVA: 0x0081DE64 File Offset: 0x0081C064
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170051AB RID: 20907
		' (get) Token: 0x0600D04C RID: 53324 RVA: 0x0005CA3A File Offset: 0x0005AC3A
		' (set) Token: 0x0600D04D RID: 53325 RVA: 0x0081DEA8 File Offset: 0x0081C0A8
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

		' Token: 0x170051AC RID: 20908
		' (get) Token: 0x0600D04E RID: 53326 RVA: 0x0005CA44 File Offset: 0x0005AC44
		' (set) Token: 0x0600D04F RID: 53327 RVA: 0x0005CA4E File Offset: 0x0005AC4E
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x170051AD RID: 20909
		' (get) Token: 0x0600D050 RID: 53328 RVA: 0x0005CA57 File Offset: 0x0005AC57
		' (set) Token: 0x0600D051 RID: 53329 RVA: 0x0081DEEC File Offset: 0x0081C0EC
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

		' Token: 0x170051AE RID: 20910
		' (get) Token: 0x0600D052 RID: 53330 RVA: 0x0005CA61 File Offset: 0x0005AC61
		' (set) Token: 0x0600D053 RID: 53331 RVA: 0x0005CA6B File Offset: 0x0005AC6B
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x170051AF RID: 20911
		' (get) Token: 0x0600D054 RID: 53332 RVA: 0x0005CA74 File Offset: 0x0005AC74
		' (set) Token: 0x0600D055 RID: 53333 RVA: 0x0005CA7E File Offset: 0x0005AC7E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170051B0 RID: 20912
		' (get) Token: 0x0600D056 RID: 53334 RVA: 0x0005CA87 File Offset: 0x0005AC87
		' (set) Token: 0x0600D057 RID: 53335 RVA: 0x0005CA91 File Offset: 0x0005AC91
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170051B1 RID: 20913
		' (get) Token: 0x0600D058 RID: 53336 RVA: 0x0005CA9A File Offset: 0x0005AC9A
		' (set) Token: 0x0600D059 RID: 53337 RVA: 0x0005CAA4 File Offset: 0x0005ACA4
		Friend Overridable Property Column4 As DataGridViewImageColumn

		' Token: 0x170051B2 RID: 20914
		' (get) Token: 0x0600D05A RID: 53338 RVA: 0x0005CAAD File Offset: 0x0005ACAD
		' (set) Token: 0x0600D05B RID: 53339 RVA: 0x0005CAB7 File Offset: 0x0005ACB7
		Friend Overridable Property Label2 As Label

		' Token: 0x170051B3 RID: 20915
		' (get) Token: 0x0600D05C RID: 53340 RVA: 0x0005CAC0 File Offset: 0x0005ACC0
		' (set) Token: 0x0600D05D RID: 53341 RVA: 0x0005CACA File Offset: 0x0005ACCA
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170051B4 RID: 20916
		' (get) Token: 0x0600D05E RID: 53342 RVA: 0x0005CAD3 File Offset: 0x0005ACD3
		' (set) Token: 0x0600D05F RID: 53343 RVA: 0x0081DF30 File Offset: 0x0081C130
		Private _Button3 As GelButton
		Friend Overridable Property Button3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._Button3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button3 = value
				gelButton = Me._Button3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051B5 RID: 20917
		' (get) Token: 0x0600D060 RID: 53344 RVA: 0x0005CADD File Offset: 0x0005ACDD
		' (set) Token: 0x0600D061 RID: 53345 RVA: 0x0081DF74 File Offset: 0x0081C174
		Private _Button4 As GelButton
		Friend Overridable Property Button4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._Button4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button4 = value
				gelButton = Me._Button4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051B6 RID: 20918
		' (get) Token: 0x0600D062 RID: 53346 RVA: 0x0005CAE7 File Offset: 0x0005ACE7
		' (set) Token: 0x0600D063 RID: 53347 RVA: 0x0081DFB8 File Offset: 0x0081C1B8
		Private _Button6 As GelButton
		Friend Overridable Property Button6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._Button6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button6 = value
				gelButton = Me._Button6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170051B7 RID: 20919
		' (get) Token: 0x0600D064 RID: 53348 RVA: 0x0005CAF1 File Offset: 0x0005ACF1
		' (set) Token: 0x0600D065 RID: 53349 RVA: 0x0081DFFC File Offset: 0x0081C1FC
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

		' Token: 0x0600D066 RID: 53350 RVA: 0x0081E040 File Offset: 0x0081C240
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Dim openFileDialog As OpenFileDialog = Me.OpenFileDialog1
				openFileDialog.Filter = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"
				openFileDialog.FilterIndex = 4
				Me.OpenFileDialog1.FileName = ""
				Dim flag As Boolean = Me.OpenFileDialog1.ShowDialog() = DialogResult.OK
				If flag Then
					Me.PictureBox1.Image = Image.FromFile(Me.OpenFileDialog1.FileName)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D067 RID: 53351 RVA: 0x0081E0E8 File Offset: 0x0081C2E8
		Private Sub frmUPIQRCodeImg_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.imageisplay()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600D068 RID: 53352 RVA: 0x0081E178 File Offset: 0x0081C378
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

		' Token: 0x0600D069 RID: 53353 RVA: 0x0081E2F0 File Offset: 0x0081C4F0
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

		' Token: 0x0600D06A RID: 53354 RVA: 0x0081E3AC File Offset: 0x0081C5AC
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

		' Token: 0x0600D06B RID: 53355 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600D06C RID: 53356 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600D06D RID: 53357 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600D06E RID: 53358 RVA: 0x0081E478 File Offset: 0x0081C678
		Private Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID),RTRIM(c1),c2 from UPIImg ORDER BY c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Me.dgw.ClearSelection()
		End Sub

		' Token: 0x0600D06F RID: 53359 RVA: 0x0081E578 File Offset: 0x0081C778
		Private Sub Clear()
			Me.PictureBox1.Image = Resources.Noimage
			Me.dgw.ClearSelection()
			Me.ComboBox1.SelectedIndex = -1
			Me.TextBox1.Text = ""
			Me.TextBox1.Focus()
		End Sub

		' Token: 0x0600D070 RID: 53360 RVA: 0x0081E5D0 File Offset: 0x0081C7D0
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button1.Enabled = False
					Me.Button3.Enabled = True
					Me.Button4.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox2.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
				Dim array As Byte() = CType(dataGridViewRow.Cells(2).Value, Byte())
				Dim memoryStream As MemoryStream = New MemoryStream(array)
				Me.PictureBox1.Image = Image.FromStream(memoryStream)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600D071 RID: 53361 RVA: 0x0081E6C8 File Offset: 0x0081C8C8
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con.Open()
				Dim text As String = "DELETE FROM UPIImg WHERE ID = " + Me.TextBox2.Text
				Dim sqlCommand As SqlCommand = New SqlCommand(text, ModCommonClasses.con)
				Dim flag As Boolean = sqlCommand.ExecuteNonQuery() > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.imageisplay()
					Me.GetData()
					Me.Clear()
					ModCommonClasses.con.Close()
					Me.Button1.Enabled = True
					Me.Button3.Enabled = False
					Me.Button4.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D072 RID: 53362 RVA: 0x0005CAFB File Offset: 0x0005ACFB
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Me.PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
			Me.PictureBox1.Refresh()
		End Sub

		' Token: 0x0600D073 RID: 53363 RVA: 0x0081E7B0 File Offset: 0x0081C9B0
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

		' Token: 0x0600D074 RID: 53364 RVA: 0x0081E5D0 File Offset: 0x0081C7D0
		Private Sub dgw_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.SelectedRows.Count <> 0
				If flag Then
					Me.Button1.Enabled = False
					Me.Button3.Enabled = True
					Me.Button4.Enabled = True
				End If
				Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
				Me.TextBox2.Text = dataGridViewRow.Cells(0).Value.ToString()
				Me.TextBox1.Text = dataGridViewRow.Cells(1).Value.ToString()
				Dim array As Byte() = CType(dataGridViewRow.Cells(2).Value, Byte())
				Dim memoryStream As MemoryStream = New MemoryStream(array)
				Me.PictureBox1.Image = Image.FromStream(memoryStream)
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600D075 RID: 53365 RVA: 0x0081E898 File Offset: 0x0081CA98
		Private Sub imageisplay()
			Try
				ModCommonClasses.con.Close()
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT c1 FROM UPIImg ORDER BY c1 ASC"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.CommandTimeout = 0
				Me.ComboBox1.Items.Clear()
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				While ModCommonClasses.rdr.Read()
					Me.ComboBox1.Items.Add(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D076 RID: 53366 RVA: 0x0081E9A8 File Offset: 0x0081CBA8
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(c1), c2 from UPIImg where c1 like N'%" + Me.ComboBox1.Text + "%' order by c1", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D077 RID: 53367 RVA: 0x0005CB1C File Offset: 0x0005AD1C
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600D078 RID: 53368 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmUPIQRCodeImg_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600D079 RID: 53369 RVA: 0x0081EAB0 File Offset: 0x0081CCB0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.TextBox1.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.TextBox1, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.TextBox1, String.Empty)
			End If
		End Sub

		' Token: 0x0600D07A RID: 53370 RVA: 0x0005CB38 File Offset: 0x0005AD38
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Clear()
			Me.Button1.Enabled = True
			Me.Button3.Enabled = False
			Me.Button4.Enabled = False
			Me.GetData()
			Me.imageisplay()
		End Sub

		' Token: 0x0600D07B RID: 53371 RVA: 0x0081EB0C File Offset: 0x0081CD0C
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
				If flag Then
					MessageBox.Show("Fill UPI Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.TextBox1.Focus()
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = If(("Update UPIImg set c1=@d1, c2=@d2 where ID=" + Me.TextBox2.Text), "")
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
					Dim memoryStream As MemoryStream = New MemoryStream()
					Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
					bitmap.Save(memoryStream, ImageFormat.Jpeg)
					Dim buffer As Byte() = memoryStream.GetBuffer()
					Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.VarBinary)
					sqlParameter.Value = buffer
					ModCommonClasses.cmd.Parameters.Add(sqlParameter)
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.imageisplay()
					Me.GetData()
					Me.Clear()
					Me.Button1.Enabled = True
					Me.Button3.Enabled = False
					Me.Button4.Enabled = False
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D07C RID: 53372 RVA: 0x0081ECD0 File Offset: 0x0081CED0
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600D07D RID: 53373 RVA: 0x0081ED38 File Offset: 0x0081CF38
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from Company"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
					ModCommonClasses.con.Close()
				Else
					Dim flag3 As Boolean = Operators.CompareString(Me.TextBox1.Text, "", False) = 0
					If flag3 Then
						Me.TextBox1.Focus()
						MessageBox.Show("Fill UPI Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Else
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text2 As String = "Insert into UPIImg(c1,c2) VALUES (@d1,@d2)"
						ModCommonClasses.cmd = New SqlCommand(text2)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox1.Text)
						Dim memoryStream As MemoryStream = New MemoryStream()
						Dim bitmap As Bitmap = New Bitmap(Me.PictureBox1.Image)
						bitmap.Save(memoryStream, ImageFormat.Jpeg)
						Dim buffer As Byte() = memoryStream.GetBuffer()
						Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.VarBinary)
						sqlParameter.Value = buffer
						ModCommonClasses.cmd.Parameters.Add(sqlParameter)
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
						MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.imageisplay()
						Me.Button1.Enabled = True
						Me.Button3.Enabled = False
						Me.Button4.Enabled = False
						Me.GetData()
						Me.Clear()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
