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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005DB RID: 1499
	<DesignerGenerated()>
	Public Partial Class frmContacts
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06012533 RID: 75059 RVA: 0x0007DAA0 File Offset: 0x0007BCA0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmcategory_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmContacts_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170071B9 RID: 29113
		' (get) Token: 0x06012536 RID: 75062 RVA: 0x0007DAD2 File Offset: 0x0007BCD2
		' (set) Token: 0x06012537 RID: 75063 RVA: 0x0007DADC File Offset: 0x0007BCDC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170071BA RID: 29114
		' (get) Token: 0x06012538 RID: 75064 RVA: 0x0007DAE5 File Offset: 0x0007BCE5
		' (set) Token: 0x06012539 RID: 75065 RVA: 0x0007DAEF File Offset: 0x0007BCEF
		Friend Overridable Property Panel4 As Panel

		' Token: 0x170071BB RID: 29115
		' (get) Token: 0x0601253A RID: 75066 RVA: 0x0007DAF8 File Offset: 0x0007BCF8
		' (set) Token: 0x0601253B RID: 75067 RVA: 0x0007DB02 File Offset: 0x0007BD02
		Friend Overridable Property Label3 As Label

		' Token: 0x170071BC RID: 29116
		' (get) Token: 0x0601253C RID: 75068 RVA: 0x0007DB0B File Offset: 0x0007BD0B
		' (set) Token: 0x0601253D RID: 75069 RVA: 0x00A8936C File Offset: 0x00A8756C
		Private _txtContactPerson As TextBox
		Friend Overridable Property txtContactPerson As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactPerson
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactPerson_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactPerson
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactPerson = value
				textBox = Me._txtContactPerson
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071BD RID: 29117
		' (get) Token: 0x0601253E RID: 75070 RVA: 0x0007DB15 File Offset: 0x0007BD15
		' (set) Token: 0x0601253F RID: 75071 RVA: 0x00A893CC File Offset: 0x00A875CC
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
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071BE RID: 29118
		' (get) Token: 0x06012540 RID: 75072 RVA: 0x0007DB1F File Offset: 0x0007BD1F
		' (set) Token: 0x06012541 RID: 75073 RVA: 0x0007DB29 File Offset: 0x0007BD29
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170071BF RID: 29119
		' (get) Token: 0x06012542 RID: 75074 RVA: 0x0007DB32 File Offset: 0x0007BD32
		' (set) Token: 0x06012543 RID: 75075 RVA: 0x0007DB3C File Offset: 0x0007BD3C
		Friend Overridable Property Label1 As Label

		' Token: 0x170071C0 RID: 29120
		' (get) Token: 0x06012544 RID: 75076 RVA: 0x0007DB45 File Offset: 0x0007BD45
		' (set) Token: 0x06012545 RID: 75077 RVA: 0x0007DB4F File Offset: 0x0007BD4F
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170071C1 RID: 29121
		' (get) Token: 0x06012546 RID: 75078 RVA: 0x0007DB58 File Offset: 0x0007BD58
		' (set) Token: 0x06012547 RID: 75079 RVA: 0x0007DB62 File Offset: 0x0007BD62
		Friend Overridable Property txtID As TextBox

		' Token: 0x170071C2 RID: 29122
		' (get) Token: 0x06012548 RID: 75080 RVA: 0x0007DB6B File Offset: 0x0007BD6B
		' (set) Token: 0x06012549 RID: 75081 RVA: 0x0007DB75 File Offset: 0x0007BD75
		Friend Overridable Property lblUser As Label

		' Token: 0x170071C3 RID: 29123
		' (get) Token: 0x0601254A RID: 75082 RVA: 0x0007DB7E File Offset: 0x0007BD7E
		' (set) Token: 0x0601254B RID: 75083 RVA: 0x00A8942C File Offset: 0x00A8762C
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtContactNo_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtContactNo_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170071C4 RID: 29124
		' (get) Token: 0x0601254C RID: 75084 RVA: 0x0007DB88 File Offset: 0x0007BD88
		' (set) Token: 0x0601254D RID: 75085 RVA: 0x0007DB92 File Offset: 0x0007BD92
		Friend Overridable Property Label2 As Label

		' Token: 0x170071C5 RID: 29125
		' (get) Token: 0x0601254E RID: 75086 RVA: 0x0007DB9B File Offset: 0x0007BD9B
		' (set) Token: 0x0601254F RID: 75087 RVA: 0x0007DBA5 File Offset: 0x0007BDA5
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x170071C6 RID: 29126
		' (get) Token: 0x06012550 RID: 75088 RVA: 0x0007DBAE File Offset: 0x0007BDAE
		' (set) Token: 0x06012551 RID: 75089 RVA: 0x00A894A8 File Offset: 0x00A876A8
		Private _txtSearchByContactPerson As TextBox
		Friend Overridable Property txtSearchByContactPerson As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSearchByContactPerson
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSearchByContactPerson_TextChanged
				Dim textBox As TextBox = Me._txtSearchByContactPerson
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSearchByContactPerson = value
				textBox = Me._txtSearchByContactPerson
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071C7 RID: 29127
		' (get) Token: 0x06012552 RID: 75090 RVA: 0x0007DBB8 File Offset: 0x0007BDB8
		' (set) Token: 0x06012553 RID: 75091 RVA: 0x0007DBC2 File Offset: 0x0007BDC2
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170071C8 RID: 29128
		' (get) Token: 0x06012554 RID: 75092 RVA: 0x0007DBCB File Offset: 0x0007BDCB
		' (set) Token: 0x06012555 RID: 75093 RVA: 0x0007DBD5 File Offset: 0x0007BDD5
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170071C9 RID: 29129
		' (get) Token: 0x06012556 RID: 75094 RVA: 0x0007DBDE File Offset: 0x0007BDDE
		' (set) Token: 0x06012557 RID: 75095 RVA: 0x0007DBE8 File Offset: 0x0007BDE8
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170071CA RID: 29130
		' (get) Token: 0x06012558 RID: 75096 RVA: 0x0007DBF1 File Offset: 0x0007BDF1
		' (set) Token: 0x06012559 RID: 75097 RVA: 0x0007DBFB File Offset: 0x0007BDFB
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170071CB RID: 29131
		' (get) Token: 0x0601255A RID: 75098 RVA: 0x0007DC04 File Offset: 0x0007BE04
		' (set) Token: 0x0601255B RID: 75099 RVA: 0x00A894EC File Offset: 0x00A876EC
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071CC RID: 29132
		' (get) Token: 0x0601255C RID: 75100 RVA: 0x0007DC0E File Offset: 0x0007BE0E
		' (set) Token: 0x0601255D RID: 75101 RVA: 0x00A89530 File Offset: 0x00A87730
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071CD RID: 29133
		' (get) Token: 0x0601255E RID: 75102 RVA: 0x0007DC18 File Offset: 0x0007BE18
		' (set) Token: 0x0601255F RID: 75103 RVA: 0x00A89574 File Offset: 0x00A87774
		Private _btnNew As GelButton
		Friend Overridable Property btnNew As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnNew
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnNew = value
				gelButton = Me._btnNew
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170071CE RID: 29134
		' (get) Token: 0x06012560 RID: 75104 RVA: 0x0007DC22 File Offset: 0x0007BE22
		' (set) Token: 0x06012561 RID: 75105 RVA: 0x00A895B8 File Offset: 0x00A877B8
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06012562 RID: 75106 RVA: 0x00A895FC File Offset: 0x00A877FC
		Public Sub Reset()
			Me.txtContactPerson.Text = ""
			Me.txtContactNo.Text = ""
			Me.txtSearchByContactPerson.Text = ""
			Me.txtContactPerson.Focus()
			Me.Getdata()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtContactPerson.Focus()
		End Sub

		' Token: 0x06012563 RID: 75107 RVA: 0x00A89684 File Offset: 0x00A87884
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from company_contacts where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "deleted the contact having contact name '", Me.txtContactPerson.Text, "' and Contact no. '", Me.txtContactNo.Text, "'" }))
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Getdata()
					Me.Reset()
				Else
					MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.Reset()
				End If
				Dim flag2 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag2 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012564 RID: 75108 RVA: 0x00A89800 File Offset: 0x00A87A00
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.txtContactPerson.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtContactNo.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06012565 RID: 75109 RVA: 0x00A898EC File Offset: 0x00A87AEC
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

		' Token: 0x06012566 RID: 75110 RVA: 0x00A899D4 File Offset: 0x00A87BD4
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT (ID),RTRIM(ContactPerson),RTRIM(ContactNo) from Company_Contacts order by ContactPerson", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012567 RID: 75111 RVA: 0x00A89AD4 File Offset: 0x00A87CD4
		Private Sub frmcategory_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x06012568 RID: 75112 RVA: 0x00A89B5C File Offset: 0x00A87D5C
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

		' Token: 0x06012569 RID: 75113 RVA: 0x00A89CD4 File Offset: 0x00A87ED4
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

		' Token: 0x0601256A RID: 75114 RVA: 0x00A89D90 File Offset: 0x00A87F90
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

		' Token: 0x0601256B RID: 75115 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601256C RID: 75116 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601256D RID: 75117 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601256E RID: 75118 RVA: 0x00A89E5C File Offset: 0x00A8805C
		Private Sub txtSearchByContactPerson_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT (ID),RTRIM(ContactPerson),RTRIM(ContactNo) from Company_Contacts where ContactPerson like N'%" + Me.txtSearchByContactPerson.Text + "%' order by ContactPerson", ModCommonClasses.con)
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

		' Token: 0x0601256F RID: 75119 RVA: 0x0077BBFC File Offset: 0x00779DFC
		Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = Not Versioned.IsNumeric(e.KeyChar) AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "+", False) <> 0 AndAlso Operators.CompareString(Conversions.ToString(e.KeyChar), "-", False) <> 0 AndAlso e.KeyChar <> vbBack
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06012570 RID: 75120 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactPerson_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012571 RID: 75121 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtContactNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012572 RID: 75122 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmContacts_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012573 RID: 75123 RVA: 0x00A89F64 File Offset: 0x00A88164
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtContactPerson.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtContactPerson, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactPerson, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtContactNo.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtContactNo, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtContactNo, String.Empty)
			End If
		End Sub

		' Token: 0x06012574 RID: 75124 RVA: 0x00A8A00C File Offset: 0x00A8820C
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

		' Token: 0x06012575 RID: 75125 RVA: 0x00A8A074 File Offset: 0x00A88274
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.txtContactPerson.Text, "", False) = 0
			If flag Then
				MessageBox.Show("Please enter contact person", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtContactPerson.Focus()
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
				If flag2 Then
					MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtContactNo.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = If(("Update Company_Contacts set ContactPerson=@d1,ContactNo=@d2 where ID=" + Me.txtID.Text), "")
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactPerson.Text)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtContactNo.Text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						ModCommonClasses.con.Close()
						ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "updated the contact having contact name '", Me.txtContactPerson.Text, "' and Contact no. '", Me.txtContactNo.Text, "'" }))
						MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						Me.Getdata()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x06012576 RID: 75126 RVA: 0x00A8A26C File Offset: 0x00A8846C
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
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
				Dim flag3 As Boolean = Operators.CompareString(Me.txtContactPerson.Text, "", False) = 0
				If flag3 Then
					MessageBox.Show("Please enter contact person", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtContactPerson.Focus()
				Else
					Dim flag4 As Boolean = Operators.CompareString(Me.txtContactNo.Text, "", False) = 0
					If flag4 Then
						MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtContactNo.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select contactperson,contactno from Company_Contacts where ContactPerson=@d1 and ContactNo=@d2"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactPerson.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtContactNo.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
							If flag5 Then
								MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag6 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Company_Contacts(ContactPerson,ContactNo) VALUES (@d1,@d2)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtContactPerson.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtContactNo.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModFunc.LogFunc(Me.lblUser.Text, String.Concat(New String() { "added the new contact having contact name '", Me.txtContactPerson.Text, "' and Contact no. '", Me.txtContactNo.Text, "'" }))
								MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
								Me.btnSave.Enabled = False
								Me.Getdata()
							End If
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x06012577 RID: 75127 RVA: 0x0007DC2C File Offset: 0x0007BE2C
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
