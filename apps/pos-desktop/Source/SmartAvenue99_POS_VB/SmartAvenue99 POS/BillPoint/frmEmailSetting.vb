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
	' Token: 0x02000593 RID: 1427
	<DesignerGenerated()>
	Public Partial Class frmEmailSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060116D3 RID: 71379 RVA: 0x00077F05 File Offset: 0x00076105
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSMSSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmailSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006C12 RID: 27666
		' (get) Token: 0x060116D6 RID: 71382 RVA: 0x00077F37 File Offset: 0x00076137
		' (set) Token: 0x060116D7 RID: 71383 RVA: 0x00077F41 File Offset: 0x00076141
		Friend Overridable Property Label1 As Label

		' Token: 0x17006C13 RID: 27667
		' (get) Token: 0x060116D8 RID: 71384 RVA: 0x00077F4A File Offset: 0x0007614A
		' (set) Token: 0x060116D9 RID: 71385 RVA: 0x00077F54 File Offset: 0x00076154
		Friend Overridable Property Label2 As Label

		' Token: 0x17006C14 RID: 27668
		' (get) Token: 0x060116DA RID: 71386 RVA: 0x00077F5D File Offset: 0x0007615D
		' (set) Token: 0x060116DB RID: 71387 RVA: 0x00A1CB9C File Offset: 0x00A1AD9C
		Private _txtSMTPAddress As TextBox
		Friend Overridable Property txtSMTPAddress As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSMTPAddress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtSMTPAddress
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtSMTPAddress = value
				textBox = Me._txtSMTPAddress
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C15 RID: 27669
		' (get) Token: 0x060116DC RID: 71388 RVA: 0x00077F67 File Offset: 0x00076167
		' (set) Token: 0x060116DD RID: 71389 RVA: 0x00077F71 File Offset: 0x00076171
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17006C16 RID: 27670
		' (get) Token: 0x060116DE RID: 71390 RVA: 0x00077F7A File Offset: 0x0007617A
		' (set) Token: 0x060116DF RID: 71391 RVA: 0x00077F84 File Offset: 0x00076184
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x17006C17 RID: 27671
		' (get) Token: 0x060116E0 RID: 71392 RVA: 0x00077F8D File Offset: 0x0007618D
		' (set) Token: 0x060116E1 RID: 71393 RVA: 0x00077F97 File Offset: 0x00076197
		Friend Overridable Property chkIsDefault As CheckBox

		' Token: 0x17006C18 RID: 27672
		' (get) Token: 0x060116E2 RID: 71394 RVA: 0x00077FA0 File Offset: 0x000761A0
		' (set) Token: 0x060116E3 RID: 71395 RVA: 0x00A1CBE0 File Offset: 0x00A1ADE0
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
				Dim dataGridViewCellFormattingEventHandler As DataGridViewCellFormattingEventHandler = AddressOf Me.dgw_CellFormatting
				Dim dataGridViewEditingControlShowingEventHandler As DataGridViewEditingControlShowingEventHandler = AddressOf Me.dgw_EditingControlShowing
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					RemoveHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					RemoveHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
					AddHandler dataGridView.CellFormatting, dataGridViewCellFormattingEventHandler
					AddHandler dataGridView.EditingControlShowing, dataGridViewEditingControlShowingEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C19 RID: 27673
		' (get) Token: 0x060116E4 RID: 71396 RVA: 0x00077FAA File Offset: 0x000761AA
		' (set) Token: 0x060116E5 RID: 71397 RVA: 0x00077FB4 File Offset: 0x000761B4
		Friend Overridable Property Label3 As Label

		' Token: 0x17006C1A RID: 27674
		' (get) Token: 0x060116E6 RID: 71398 RVA: 0x00077FBD File Offset: 0x000761BD
		' (set) Token: 0x060116E7 RID: 71399 RVA: 0x00077FC7 File Offset: 0x000761C7
		Friend Overridable Property Label4 As Label

		' Token: 0x17006C1B RID: 27675
		' (get) Token: 0x060116E8 RID: 71400 RVA: 0x00077FD0 File Offset: 0x000761D0
		' (set) Token: 0x060116E9 RID: 71401 RVA: 0x00077FDA File Offset: 0x000761DA
		Friend Overridable Property Label5 As Label

		' Token: 0x17006C1C RID: 27676
		' (get) Token: 0x060116EA RID: 71402 RVA: 0x00077FE3 File Offset: 0x000761E3
		' (set) Token: 0x060116EB RID: 71403 RVA: 0x00077FED File Offset: 0x000761ED
		Friend Overridable Property txtID As TextBox

		' Token: 0x17006C1D RID: 27677
		' (get) Token: 0x060116EC RID: 71404 RVA: 0x00077FF6 File Offset: 0x000761F6
		' (set) Token: 0x060116ED RID: 71405 RVA: 0x00A1CC80 File Offset: 0x00A1AE80
		Private _cmbServerName As ComboBox
		Friend Overridable Property cmbServerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbServerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.cmbServerName_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbServerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbServerName = value
				comboBox = Me._cmbServerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C1E RID: 27678
		' (get) Token: 0x060116EE RID: 71406 RVA: 0x00078000 File Offset: 0x00076200
		' (set) Token: 0x060116EF RID: 71407 RVA: 0x00A1CCE0 File Offset: 0x00A1AEE0
		Private _txtPort As TextBox
		Friend Overridable Property txtPort As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPort
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtPort_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtPort
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtPort = value
				textBox = Me._txtPort
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C1F RID: 27679
		' (get) Token: 0x060116F0 RID: 71408 RVA: 0x0007800A File Offset: 0x0007620A
		' (set) Token: 0x060116F1 RID: 71409 RVA: 0x00A1CD40 File Offset: 0x00A1AF40
		Private _txtPassword As TextBox
		Friend Overridable Property txtPassword As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtPassword
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtPassword
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtPassword = value
				textBox = Me._txtPassword
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C20 RID: 27680
		' (get) Token: 0x060116F2 RID: 71410 RVA: 0x00078014 File Offset: 0x00076214
		' (set) Token: 0x060116F3 RID: 71411 RVA: 0x00A1CD84 File Offset: 0x00A1AF84
		Private _txtEmailID As TextBox
		Friend Overridable Property txtEmailID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmailID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtUsername_KeyPress
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtEmailID = value
				textBox = Me._txtEmailID
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C21 RID: 27681
		' (get) Token: 0x060116F4 RID: 71412 RVA: 0x0007801E File Offset: 0x0007621E
		' (set) Token: 0x060116F5 RID: 71413 RVA: 0x00A1CDE4 File Offset: 0x00A1AFE4
		Private _cmbTSRequired As ComboBox
		Friend Overridable Property cmbTSRequired As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbTSRequired
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbTSRequired
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbTSRequired = value
				comboBox = Me._cmbTSRequired
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006C22 RID: 27682
		' (get) Token: 0x060116F6 RID: 71414 RVA: 0x00078028 File Offset: 0x00076228
		' (set) Token: 0x060116F7 RID: 71415 RVA: 0x00078032 File Offset: 0x00076232
		Friend Overridable Property Label6 As Label

		' Token: 0x17006C23 RID: 27683
		' (get) Token: 0x060116F8 RID: 71416 RVA: 0x0007803B File Offset: 0x0007623B
		' (set) Token: 0x060116F9 RID: 71417 RVA: 0x00078045 File Offset: 0x00076245
		Friend Overridable Property Label7 As Label

		' Token: 0x17006C24 RID: 27684
		' (get) Token: 0x060116FA RID: 71418 RVA: 0x0007804E File Offset: 0x0007624E
		' (set) Token: 0x060116FB RID: 71419 RVA: 0x00078058 File Offset: 0x00076258
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17006C25 RID: 27685
		' (get) Token: 0x060116FC RID: 71420 RVA: 0x00078061 File Offset: 0x00076261
		' (set) Token: 0x060116FD RID: 71421 RVA: 0x0007806B File Offset: 0x0007626B
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17006C26 RID: 27686
		' (get) Token: 0x060116FE RID: 71422 RVA: 0x00078074 File Offset: 0x00076274
		' (set) Token: 0x060116FF RID: 71423 RVA: 0x0007807E File Offset: 0x0007627E
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17006C27 RID: 27687
		' (get) Token: 0x06011700 RID: 71424 RVA: 0x00078087 File Offset: 0x00076287
		' (set) Token: 0x06011701 RID: 71425 RVA: 0x00078091 File Offset: 0x00076291
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17006C28 RID: 27688
		' (get) Token: 0x06011702 RID: 71426 RVA: 0x0007809A File Offset: 0x0007629A
		' (set) Token: 0x06011703 RID: 71427 RVA: 0x000780A4 File Offset: 0x000762A4
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17006C29 RID: 27689
		' (get) Token: 0x06011704 RID: 71428 RVA: 0x000780AD File Offset: 0x000762AD
		' (set) Token: 0x06011705 RID: 71429 RVA: 0x000780B7 File Offset: 0x000762B7
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17006C2A RID: 27690
		' (get) Token: 0x06011706 RID: 71430 RVA: 0x000780C0 File Offset: 0x000762C0
		' (set) Token: 0x06011707 RID: 71431 RVA: 0x000780CA File Offset: 0x000762CA
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17006C2B RID: 27691
		' (get) Token: 0x06011708 RID: 71432 RVA: 0x000780D3 File Offset: 0x000762D3
		' (set) Token: 0x06011709 RID: 71433 RVA: 0x000780DD File Offset: 0x000762DD
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17006C2C RID: 27692
		' (get) Token: 0x0601170A RID: 71434 RVA: 0x000780E6 File Offset: 0x000762E6
		' (set) Token: 0x0601170B RID: 71435 RVA: 0x000780F0 File Offset: 0x000762F0
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17006C2D RID: 27693
		' (get) Token: 0x0601170C RID: 71436 RVA: 0x000780F9 File Offset: 0x000762F9
		' (set) Token: 0x0601170D RID: 71437 RVA: 0x00078103 File Offset: 0x00076303
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17006C2E RID: 27694
		' (get) Token: 0x0601170E RID: 71438 RVA: 0x0007810C File Offset: 0x0007630C
		' (set) Token: 0x0601170F RID: 71439 RVA: 0x00A1CE28 File Offset: 0x00A1B028
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

		' Token: 0x17006C2F RID: 27695
		' (get) Token: 0x06011710 RID: 71440 RVA: 0x00078116 File Offset: 0x00076316
		' (set) Token: 0x06011711 RID: 71441 RVA: 0x00A1CE6C File Offset: 0x00A1B06C
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

		' Token: 0x17006C30 RID: 27696
		' (get) Token: 0x06011712 RID: 71442 RVA: 0x00078120 File Offset: 0x00076320
		' (set) Token: 0x06011713 RID: 71443 RVA: 0x00A1CEB0 File Offset: 0x00A1B0B0
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

		' Token: 0x17006C31 RID: 27697
		' (get) Token: 0x06011714 RID: 71444 RVA: 0x0007812A File Offset: 0x0007632A
		' (set) Token: 0x06011715 RID: 71445 RVA: 0x00A1CEF4 File Offset: 0x00A1B0F4
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

		' Token: 0x06011716 RID: 71446 RVA: 0x00A1CF38 File Offset: 0x00A1B138
		Public Sub Reset()
			Me.txtSMTPAddress.Text = ""
			Me.cmbServerName.SelectedIndex = -1
			Me.txtEmailID.Text = ""
			Me.txtPassword.Text = ""
			Me.txtPort.Text = ""
			Me.cmbTSRequired.SelectedIndex = 0
			Me.chkIsDefault.Checked = False
			Me.chkIsEnabled.Checked = True
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.cmbServerName.Focus()
			Me.Getdata()
		End Sub

		' Token: 0x06011717 RID: 71447 RVA: 0x00A1CFF8 File Offset: 0x00A1B1F8
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(ServerName), RTRIM(SMTPAddress), RTRIM(Username), RTRIM(Password), Port, RTRIM(TLS_SSL_Required), RTRIM(IsDefault), RTRIM(IsActive) from EmailSetting order by ServerName,SMTPAddress", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6), ModCommonClasses.rdr(7), ModCommonClasses.rdr(8) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011718 RID: 71448 RVA: 0x00078134 File Offset: 0x00076334
		Private Sub frmSMSSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011719 RID: 71449 RVA: 0x00A1D160 File Offset: 0x00A1B360
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

		' Token: 0x0601171A RID: 71450 RVA: 0x00A1D2D8 File Offset: 0x00A1B4D8
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

		' Token: 0x0601171B RID: 71451 RVA: 0x00A1D394 File Offset: 0x00A1B594
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

		' Token: 0x0601171C RID: 71452 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0601171D RID: 71453 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0601171E RID: 71454 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0601171F RID: 71455 RVA: 0x00A1D460 File Offset: 0x00A1B660
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from EmailSetting where ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					MessageBox.Show("Successfully Deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
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

		' Token: 0x06011720 RID: 71456 RVA: 0x00A1D580 File Offset: 0x00A1B780
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.cmbServerName.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.txtSMTPAddress.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.txtEmailID.Text = dataGridViewRow.Cells(3).Value.ToString()
					Me.txtPassword.Text = ModFunc.Decrypt(dataGridViewRow.Cells(4).Value.ToString())
					Me.txtPort.Text = dataGridViewRow.Cells(5).Value.ToString()
					Me.cmbTSRequired.Text = dataGridViewRow.Cells(6).Value.ToString()
					Dim flag2 As Boolean = Operators.CompareString(dataGridViewRow.Cells(7).Value.ToString(), "Yes", False) = 0
					If flag2 Then
						Me.chkIsDefault.Checked = True
					Else
						Me.chkIsDefault.Checked = False
					End If
					Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(8).Value.ToString(), "Yes", False) = 0
					If flag3 Then
						Me.chkIsEnabled.Checked = True
					Else
						Me.chkIsEnabled.Checked = False
					End If
					Me.btnUpdate.Enabled = True
					Me.btnDelete.Enabled = True
					Me.btnSave.Enabled = False
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06011721 RID: 71457 RVA: 0x00A1D794 File Offset: 0x00A1B994
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

		' Token: 0x06011722 RID: 71458 RVA: 0x00A1D87C File Offset: 0x00A1BA7C
		Private Sub cmbServerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbServerName.SelectedIndex = 0
			If flag Then
				Me.txtSMTPAddress.Text = "smtp.mail.yahoo.com"
				Me.txtPort.Text = Conversions.ToString(587)
			End If
			Dim flag2 As Boolean = Me.cmbServerName.SelectedIndex = 1
			If flag2 Then
				Me.txtSMTPAddress.Text = "smtp.gmail.com"
				Me.txtPort.Text = Conversions.ToString(587)
			End If
			Dim flag3 As Boolean = Me.cmbServerName.SelectedIndex = 2
			If flag3 Then
				Me.txtSMTPAddress.Text = "smtp.rediffmail.com"
				Me.txtPort.Text = Conversions.ToString(587)
			End If
			Dim flag4 As Boolean = Me.cmbServerName.SelectedIndex = 3
			If flag4 Then
				Me.txtSMTPAddress.Text = "smtp-mail.outlook.com"
				Me.txtPort.Text = Conversions.ToString(587)
			End If
		End Sub

		' Token: 0x06011723 RID: 71459 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtPort_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06011724 RID: 71460 RVA: 0x00A1D978 File Offset: 0x00A1BB78
		Private Sub dgw_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing
			If flag Then
				Me.dgw.Rows(e.RowIndex).Tag = RuntimeHelpers.GetObjectValue(e.Value)
				e.Value = New String("●"c, e.Value.ToString().Length)
			End If
		End Sub

		' Token: 0x06011725 RID: 71461 RVA: 0x00A1D9EC File Offset: 0x00A1BBEC
		Private Sub dgw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
			Dim flag As Boolean = Me.dgw.CurrentCell.ColumnIndex = 4
			If flag Then
				Dim textBox As TextBox = TryCast(e.Control, TextBox)
				Dim flag2 As Boolean = textBox IsNot Nothing
				If flag2 Then
					textBox.UseSystemPasswordChar = True
				End If
			Else
				Dim textBox2 As TextBox = TryCast(e.Control, TextBox)
				Dim flag3 As Boolean = textBox2 IsNot Nothing
				If flag3 Then
					textBox2.UseSystemPasswordChar = False
				End If
			End If
		End Sub

		' Token: 0x06011726 RID: 71462 RVA: 0x00A1DA54 File Offset: 0x00A1BC54
		Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim text As String = "@"
			Dim flag As Boolean = e.KeyChar <> vbBack
			If flag Then
				Dim flag2 As Boolean = (Strings.Asc(e.KeyChar) < 97) Or (Strings.Asc(e.KeyChar) > 122)
				If flag2 Then
					Dim flag3 As Boolean = (Strings.Asc(e.KeyChar) <> 46) And (Strings.Asc(e.KeyChar) <> 95)
					If flag3 Then
						Dim flag4 As Boolean = (Strings.Asc(e.KeyChar) < 48) Or (Strings.Asc(e.KeyChar) > 57)
						If flag4 Then
							Dim flag5 As Boolean = text.IndexOf(e.KeyChar) = -1
							If flag5 Then
								e.Handled = True
							Else
								Dim flag6 As Boolean = Me.txtEmailID.Text.Contains("@") And (Operators.CompareString(Conversions.ToString(e.KeyChar), "@", False) = 0)
								If flag6 Then
									e.Handled = True
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011727 RID: 71463 RVA: 0x00078145 File Offset: 0x00076345
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011728 RID: 71464 RVA: 0x00A1DB5C File Offset: 0x00A1BD5C
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.cmbServerName.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please select server name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbServerName.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtSMTPAddress.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please enter SMTP Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtSMTPAddress.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtEmailID.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtEmailID.Focus()
						Else
							Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtPassword.Text)) = 0
							If flag6 Then
								MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtPassword.Focus()
							Else
								Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtPort.Text)) = 0
								If flag7 Then
									MessageBox.Show("Please enter port", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtPort.Focus()
								Else
									Try
										Dim checked As Boolean = Me.chkIsDefault.Checked
										If checked Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text2 As String = "select IsDefault from EmailSetting where IsDefault='Yes'"
											ModCommonClasses.cmd = New SqlCommand(text2)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag8 As Boolean = ModCommonClasses.rdr.Read()
											If flag8 Then
												MessageBox.Show("Other Email ID is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag9 Then
													ModCommonClasses.rdr.Close()
												End If
												Return
											End If
										End If
										Dim checked2 As Boolean = Me.chkIsDefault.Checked
										If checked2 Then
											Me.st1 = "Yes"
										Else
											Me.st1 = "No"
										End If
										Dim checked3 As Boolean = Me.chkIsEnabled.Checked
										If checked3 Then
											Me.st2 = "Yes"
										Else
											Me.st2 = "No"
										End If
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text3 As String = "insert into EmailSetting(ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
										ModCommonClasses.cmd = New SqlCommand(text3)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbServerName.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSMTPAddress.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtEmailID.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", ModFunc.Encrypt(Me.txtPassword.Text))
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtPort.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cmbTSRequired.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.st1)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.st2)
										ModCommonClasses.cmd.ExecuteReader()
										ModCommonClasses.con.Close()
										MessageBox.Show("Successfully Saved", "Email Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.btnSave.Enabled = False
										Me.Getdata()
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011729 RID: 71465 RVA: 0x00A1E008 File Offset: 0x00A1C208
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbServerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please select server name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.cmbServerName.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtSMTPAddress.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter SMTP Address", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSMTPAddress.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtEmailID.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtEmailID.Focus()
					Else
						Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtPassword.Text)) = 0
						If flag4 Then
							MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.txtPassword.Focus()
						Else
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtPort.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please enter port", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.txtPort.Focus()
							Else
								Try
									Dim checked As Boolean = Me.chkIsDefault.Checked
									If checked Then
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text As String = "Update EmailSetting set IsDefault='No'"
										ModCommonClasses.cmd = New SqlCommand(text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.cmd.ExecuteReader()
									End If
									Dim checked2 As Boolean = Me.chkIsDefault.Checked
									If checked2 Then
										Me.st1 = "Yes"
									Else
										Me.st1 = "No"
									End If
									Dim checked3 As Boolean = Me.chkIsEnabled.Checked
									If checked3 Then
										Me.st2 = "Yes"
									Else
										Me.st2 = "No"
									End If
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text2 As String = If(("Update EmailSetting set ServerName=@d1, SMTPAddress=@d2, Username=@d3, Password=@d4, Port=@d5, TLS_SSL_Required=@d6, IsDefault=@d7, IsActive=@d8 where ID=" + Me.txtID.Text), "")
									ModCommonClasses.cmd = New SqlCommand(text2)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.cmbServerName.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtSMTPAddress.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtEmailID.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", ModFunc.Encrypt(Me.txtPassword.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtPort.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.cmbTSRequired.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.st1)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Me.st2)
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									MessageBox.Show("Successfully Updated", "Email Setting", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnUpdate.Enabled = False
									Me.Getdata()
								Catch ex As Exception
									MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0601172A RID: 71466 RVA: 0x00A1E3E4 File Offset: 0x00A1C5E4
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

		' Token: 0x0601172B RID: 71467 RVA: 0x00A1E44C File Offset: 0x00A1C64C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtSMTPAddress.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtSMTPAddress, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtSMTPAddress, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtPort.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtPort, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPort, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtPort.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtPort, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPort, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtPassword.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtPassword, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtPassword, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.txtEmailID.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.txtEmailID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtEmailID, String.Empty)
			End If
			Dim flag6 As Boolean = String.IsNullOrEmpty(Me.cmbTSRequired.Text.Trim())
			If flag6 Then
				Me.ErrorProvider1.SetError(Me.cmbTSRequired, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbTSRequired, String.Empty)
			End If
			Dim flag7 As Boolean = String.IsNullOrEmpty(Me.cmbServerName.Text.Trim())
			If flag7 Then
				Me.ErrorProvider1.SetError(Me.cmbServerName, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbServerName, String.Empty)
			End If
		End Sub

		' Token: 0x0601172C RID: 71468 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmailSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006927 RID: 26919
		Private st1 As String

		' Token: 0x04006928 RID: 26920
		Private st2 As String

		' Token: 0x04006929 RID: 26921
		Private st3 As String
	End Class
End Namespace
