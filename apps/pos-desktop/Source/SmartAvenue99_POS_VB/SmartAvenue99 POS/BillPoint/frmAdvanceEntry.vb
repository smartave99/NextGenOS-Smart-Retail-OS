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
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200032A RID: 810
	<DesignerGenerated()>
	Public Partial Class frmAdvanceEntry
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BDE6 RID: 48614 RVA: 0x00054D8D File Offset: 0x00052F8D
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAdvanceEntry_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAdvanceEntry_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004BA4 RID: 19364
		' (get) Token: 0x0600BDE9 RID: 48617 RVA: 0x00054DBF File Offset: 0x00052FBF
		' (set) Token: 0x0600BDEA RID: 48618 RVA: 0x00054DC9 File Offset: 0x00052FC9
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004BA5 RID: 19365
		' (get) Token: 0x0600BDEB RID: 48619 RVA: 0x00054DD2 File Offset: 0x00052FD2
		' (set) Token: 0x0600BDEC RID: 48620 RVA: 0x00054DDC File Offset: 0x00052FDC
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004BA6 RID: 19366
		' (get) Token: 0x0600BDED RID: 48621 RVA: 0x00054DE5 File Offset: 0x00052FE5
		' (set) Token: 0x0600BDEE RID: 48622 RVA: 0x00054DEF File Offset: 0x00052FEF
		Friend Overridable Property Label1 As Label

		' Token: 0x17004BA7 RID: 19367
		' (get) Token: 0x0600BDEF RID: 48623 RVA: 0x00054DF8 File Offset: 0x00052FF8
		' (set) Token: 0x0600BDF0 RID: 48624 RVA: 0x00054E02 File Offset: 0x00053002
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004BA8 RID: 19368
		' (get) Token: 0x0600BDF1 RID: 48625 RVA: 0x00054E0B File Offset: 0x0005300B
		' (set) Token: 0x0600BDF2 RID: 48626 RVA: 0x00054E15 File Offset: 0x00053015
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004BA9 RID: 19369
		' (get) Token: 0x0600BDF3 RID: 48627 RVA: 0x00054E1E File Offset: 0x0005301E
		' (set) Token: 0x0600BDF4 RID: 48628 RVA: 0x00054E28 File Offset: 0x00053028
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17004BAA RID: 19370
		' (get) Token: 0x0600BDF5 RID: 48629 RVA: 0x00054E31 File Offset: 0x00053031
		' (set) Token: 0x0600BDF6 RID: 48630 RVA: 0x00054E3B File Offset: 0x0005303B
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004BAB RID: 19371
		' (get) Token: 0x0600BDF7 RID: 48631 RVA: 0x00054E44 File Offset: 0x00053044
		' (set) Token: 0x0600BDF8 RID: 48632 RVA: 0x00054E4E File Offset: 0x0005304E
		Friend Overridable Property lblUser As Label

		' Token: 0x17004BAC RID: 19372
		' (get) Token: 0x0600BDF9 RID: 48633 RVA: 0x00054E57 File Offset: 0x00053057
		' (set) Token: 0x0600BDFA RID: 48634 RVA: 0x00054E61 File Offset: 0x00053061
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004BAD RID: 19373
		' (get) Token: 0x0600BDFB RID: 48635 RVA: 0x00054E6A File Offset: 0x0005306A
		' (set) Token: 0x0600BDFC RID: 48636 RVA: 0x0079464C File Offset: 0x0079284C
		Private _txtAmount As TextBox
		Friend Overridable Property txtAmount As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtAmount
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtAmount_KeyPress
				Dim eventHandler As EventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtAmount
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validated, eventHandler
				End If
				Me._txtAmount = value
				textBox = Me._txtAmount
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validated, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BAE RID: 19374
		' (get) Token: 0x0600BDFD RID: 48637 RVA: 0x00054E74 File Offset: 0x00053074
		' (set) Token: 0x0600BDFE RID: 48638 RVA: 0x00054E7E File Offset: 0x0005307E
		Friend Overridable Property txtEmployeeName As TextBox

		' Token: 0x17004BAF RID: 19375
		' (get) Token: 0x0600BDFF RID: 48639 RVA: 0x00054E87 File Offset: 0x00053087
		' (set) Token: 0x0600BE00 RID: 48640 RVA: 0x00054E91 File Offset: 0x00053091
		Friend Overridable Property txtEmployeeID As TextBox

		' Token: 0x17004BB0 RID: 19376
		' (get) Token: 0x0600BE01 RID: 48641 RVA: 0x00054E9A File Offset: 0x0005309A
		' (set) Token: 0x0600BE02 RID: 48642 RVA: 0x00054EA4 File Offset: 0x000530A4
		Friend Overridable Property dtpEntryDate As DateTimePicker

		' Token: 0x17004BB1 RID: 19377
		' (get) Token: 0x0600BE03 RID: 48643 RVA: 0x00054EAD File Offset: 0x000530AD
		' (set) Token: 0x0600BE04 RID: 48644 RVA: 0x00054EB7 File Offset: 0x000530B7
		Friend Overridable Property Label2 As Label

		' Token: 0x17004BB2 RID: 19378
		' (get) Token: 0x0600BE05 RID: 48645 RVA: 0x00054EC0 File Offset: 0x000530C0
		' (set) Token: 0x0600BE06 RID: 48646 RVA: 0x00054ECA File Offset: 0x000530CA
		Friend Overridable Property Label5 As Label

		' Token: 0x17004BB3 RID: 19379
		' (get) Token: 0x0600BE07 RID: 48647 RVA: 0x00054ED3 File Offset: 0x000530D3
		' (set) Token: 0x0600BE08 RID: 48648 RVA: 0x00054EDD File Offset: 0x000530DD
		Friend Overridable Property Label4 As Label

		' Token: 0x17004BB4 RID: 19380
		' (get) Token: 0x0600BE09 RID: 48649 RVA: 0x00054EE6 File Offset: 0x000530E6
		' (set) Token: 0x0600BE0A RID: 48650 RVA: 0x00054EF0 File Offset: 0x000530F0
		Friend Overridable Property Label3 As Label

		' Token: 0x17004BB5 RID: 19381
		' (get) Token: 0x0600BE0B RID: 48651 RVA: 0x00054EF9 File Offset: 0x000530F9
		' (set) Token: 0x0600BE0C RID: 48652 RVA: 0x007946AC File Offset: 0x007928AC
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

		' Token: 0x17004BB6 RID: 19382
		' (get) Token: 0x0600BE0D RID: 48653 RVA: 0x00054F03 File Offset: 0x00053103
		' (set) Token: 0x0600BE0E RID: 48654 RVA: 0x00054F0D File Offset: 0x0005310D
		Friend Overridable Property txtEmpID As TextBox

		' Token: 0x17004BB7 RID: 19383
		' (get) Token: 0x0600BE0F RID: 48655 RVA: 0x00054F16 File Offset: 0x00053116
		' (set) Token: 0x0600BE10 RID: 48656 RVA: 0x00054F20 File Offset: 0x00053120
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004BB8 RID: 19384
		' (get) Token: 0x0600BE11 RID: 48657 RVA: 0x00054F29 File Offset: 0x00053129
		' (set) Token: 0x0600BE12 RID: 48658 RVA: 0x00054F33 File Offset: 0x00053133
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004BB9 RID: 19385
		' (get) Token: 0x0600BE13 RID: 48659 RVA: 0x00054F3C File Offset: 0x0005313C
		' (set) Token: 0x0600BE14 RID: 48660 RVA: 0x00054F46 File Offset: 0x00053146
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004BBA RID: 19386
		' (get) Token: 0x0600BE15 RID: 48661 RVA: 0x00054F4F File Offset: 0x0005314F
		' (set) Token: 0x0600BE16 RID: 48662 RVA: 0x00054F59 File Offset: 0x00053159
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004BBB RID: 19387
		' (get) Token: 0x0600BE17 RID: 48663 RVA: 0x00054F62 File Offset: 0x00053162
		' (set) Token: 0x0600BE18 RID: 48664 RVA: 0x00054F6C File Offset: 0x0005316C
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004BBC RID: 19388
		' (get) Token: 0x0600BE19 RID: 48665 RVA: 0x00054F75 File Offset: 0x00053175
		' (set) Token: 0x0600BE1A RID: 48666 RVA: 0x00054F7F File Offset: 0x0005317F
		Friend Overridable Property Label6 As Label

		' Token: 0x17004BBD RID: 19389
		' (get) Token: 0x0600BE1B RID: 48667 RVA: 0x00054F88 File Offset: 0x00053188
		' (set) Token: 0x0600BE1C RID: 48668 RVA: 0x0079470C File Offset: 0x0079290C
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

		' Token: 0x17004BBE RID: 19390
		' (get) Token: 0x0600BE1D RID: 48669 RVA: 0x00054F92 File Offset: 0x00053192
		' (set) Token: 0x0600BE1E RID: 48670 RVA: 0x00794750 File Offset: 0x00792950
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

		' Token: 0x17004BBF RID: 19391
		' (get) Token: 0x0600BE1F RID: 48671 RVA: 0x00054F9C File Offset: 0x0005319C
		' (set) Token: 0x0600BE20 RID: 48672 RVA: 0x00794794 File Offset: 0x00792994
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click_1
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

		' Token: 0x17004BC0 RID: 19392
		' (get) Token: 0x0600BE21 RID: 48673 RVA: 0x00054FA6 File Offset: 0x000531A6
		' (set) Token: 0x0600BE22 RID: 48674 RVA: 0x007947D8 File Offset: 0x007929D8
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

		' Token: 0x17004BC1 RID: 19393
		' (get) Token: 0x0600BE23 RID: 48675 RVA: 0x00054FB0 File Offset: 0x000531B0
		' (set) Token: 0x0600BE24 RID: 48676 RVA: 0x0079481C File Offset: 0x00792A1C
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

		' Token: 0x0600BE25 RID: 48677 RVA: 0x00794860 File Offset: 0x00792A60
		Public Sub Reset()
			Me.txtEmployeeID.Text = ""
			Me.txtEmployeeName.Text = ""
			Me.txtAmount.Text = ""
			Me.dtpEntryDate.Text = Conversions.ToString(DateAndTime.Now)
			Me.GetData()
			Me.btnDelete.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnUpdate.Enabled = False
			Me.dtpEntryDate.Enabled = True
		End Sub

		' Token: 0x0600BE26 RID: 48678 RVA: 0x007948F4 File Offset: 0x00792AF4
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),IsNull(sum(Amount)-sum(Deduction),0) FROM EmployeeRegistration left join AdvanceEntry on EmployeeRegistration.ID=AdvanceEntry.EmployeeID where Active='Yes' group by employeename,employeeregistration.employeeid,EmployeeRegistration.ID order by EmployeeName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
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

		' Token: 0x0600BE27 RID: 48679 RVA: 0x00794A04 File Offset: 0x00792C04
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

		' Token: 0x0600BE28 RID: 48680 RVA: 0x00794A6C File Offset: 0x00792C6C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from AdvanceEntry where id=" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LedgerDelete(Me.txtID.Text, "Payroll Advance")
					Dim text2 As String = "deleted the advance entry having id '" + Me.txtID.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.GetData()
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

		' Token: 0x0600BE29 RID: 48681 RVA: 0x00054FBA File Offset: 0x000531BA
		Private Sub frmAdvanceEntry_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BE2A RID: 48682 RVA: 0x00794BCC File Offset: 0x00792DCC
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

		' Token: 0x0600BE2B RID: 48683 RVA: 0x00794D44 File Offset: 0x00792F44
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

		' Token: 0x0600BE2C RID: 48684 RVA: 0x00794E00 File Offset: 0x00793000
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

		' Token: 0x0600BE2D RID: 48685 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BE2E RID: 48686 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BE2F RID: 48687 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BE30 RID: 48688 RVA: 0x00794ECC File Offset: 0x007930CC
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtEmpID.Text = Conversions.ToString(dataGridViewRow.Cells(0).Value)
					Me.txtEmployeeID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtEmployeeName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtAmount.Focus()
					Me.txtAmount.Clear()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BE31 RID: 48689 RVA: 0x00794FAC File Offset: 0x007931AC
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

		' Token: 0x0600BE32 RID: 48690 RVA: 0x00795094 File Offset: 0x00793294
		Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtAmount.Text
					Dim selectionStart As Integer = Me.txtAmount.SelectionStart
					Dim selectionLength As Integer = Me.txtAmount.SelectionLength
					text = text.Substring(0, selectionStart) + Conversions.ToString(keyChar) + text.Substring(selectionStart + selectionLength)
					Dim text2 As String = text
					Dim num As Integer = 0
					Dim flag3 As Boolean = Integer.TryParse(text2, num) AndAlso text.Length > 16
					If flag3 Then
						e.Handled = True
					Else
						Dim text3 As String = text
						Dim num2 As Double = 0.0
						Dim flag4 As Boolean = Double.TryParse(text3, num2) AndAlso text.IndexOf("."c) < text.Length - 3
						If flag4 Then
							e.Handled = False
						End If
					End If
				Else
					e.Handled = True
				End If
			End If
		End Sub

		' Token: 0x0600BE33 RID: 48691 RVA: 0x0079518C File Offset: 0x0079338C
		Private Sub auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT MAX(ID) FROM AdvanceEntry"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
			If flag Then
				Dim num As Integer = 1
				Me.txtID.Text = num.ToString()
			Else
				Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
				Me.txtID.Text = num.ToString()
			End If
			ModCommonClasses.cmd.Dispose()
			ModCommonClasses.con.Close()
			ModCommonClasses.con.Dispose()
		End Sub

		' Token: 0x0600BE34 RID: 48692 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAdvanceEntry_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BE35 RID: 48693 RVA: 0x00795258 File Offset: 0x00793458
		Private Sub TV(sender As Object, e As EventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtAmount.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtAmount, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtAmount, String.Empty)
			End If
		End Sub

		' Token: 0x0600BE36 RID: 48694 RVA: 0x00054FCB File Offset: 0x000531CB
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BE37 RID: 48695 RVA: 0x007952B4 File Offset: 0x007934B4
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtEmployeeID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please retrieve employee info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtEmployeeID.Focus()
				Else
					Dim flag4 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
					If flag4 Then
						MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtAmount.Focus()
					Else
						Try
							Me.auto()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = String.Concat(New String() { "insert into advanceentry(ID,workingdate,employeeid,amount,deduction) VALUES (", Me.txtID.Text, ",@d1,", Me.txtEmpID.Text, ",", Me.txtAmount.Text, ",0)" })
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.dtpEntryDate.Value)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
							If flag5 Then
								ModCommonClasses.con.Close()
							End If
							ModCommonClasses.con.Close()
							Dim flag6 As Boolean = Conversion.Val(Me.txtAmount.Text) > 0.0
							If flag6 Then
								ModFunc.LedgerSave(Me.dtpEntryDate.Value.[Date], "Cash Account", Me.txtID.Text, "Payroll Advance", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtEmployeeID.Text, Me.txtEmployeeName.Text)
								ModFunc.LedgerSave(Me.dtpEntryDate.Value.[Date], Me.txtEmployeeName.Text, Me.txtID.Text, "Payroll Advance", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtEmployeeID.Text, Me.txtEmployeeName.Text)
							End If
							Dim text3 As String = "added the new advance entry having id '" + Me.txtID.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text3)
							MessageBox.Show("Successfully Saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnSave.Enabled = False
							ModCommonClasses.con.Close()
							Me.GetData()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BE38 RID: 48696 RVA: 0x00795664 File Offset: 0x00793864
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtEmployeeID.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve employee info", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtEmployeeID.Focus()
			Else
				Dim flag2 As Boolean = Conversion.Val(Me.txtAmount.Text) <= 0.0
				If flag2 Then
					MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtAmount.Focus()
				Else
					Try
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = If(String.Concat(New String() { "Update advanceentry set EmployeeID=", Me.txtEmpID.Text, ",Amount=", Me.txtAmount.Text, " where id=", Me.txtID.Text }), "")
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag3 Then
							ModCommonClasses.con.Close()
						End If
						ModCommonClasses.con.Close()
						Dim text2 As String = "updated the advance entry having id '" + Me.txtID.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text2)
						MessageBox.Show("Successfully Updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.btnUpdate.Enabled = False
						ModCommonClasses.con.Close()
						Dim flag4 As Boolean = Conversion.Val(Me.txtAmount.Text) > 0.0
						If flag4 Then
							ModFunc.LedgerDelete(Me.txtID.Text, "Payroll Advance")
							ModFunc.LedgerSave(Me.dtpEntryDate.Value.[Date], "Cash Account", Me.txtID.Text, "Payroll Advance", New Decimal(Conversion.Val(Me.txtAmount.Text)), 0D, Me.txtEmployeeID.Text, Me.txtEmployeeName.Text)
							ModFunc.LedgerSave(Me.dtpEntryDate.Value.[Date], Me.txtEmployeeName.Text, Me.txtID.Text, "Payroll Advance", 0D, New Decimal(Conversion.Val(Me.txtAmount.Text)), Me.txtEmployeeID.Text, Me.txtEmployeeName.Text)
						End If
						Me.GetData()
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600BE39 RID: 48697 RVA: 0x00794A04 File Offset: 0x00792C04
		Private Sub btnDelete_Click_1(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					Me.DeleteRecord()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BE3A RID: 48698 RVA: 0x00054FD5 File Offset: 0x000531D5
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAdvanceEntryRecord.lblSet.Text = "Advance Entry"
			MyProject.Forms.frmAdvanceEntryRecord.Reset()
			MyProject.Forms.frmAdvanceEntryRecord.ShowDialog()
		End Sub
	End Class
End Namespace
