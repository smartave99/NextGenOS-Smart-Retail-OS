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
	' Token: 0x0200010A RID: 266
	<DesignerGenerated()>
	Public Partial Class frmEmailSetting_login
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002AB7 RID: 10935 RVA: 0x0001B7BE File Offset: 0x000199BE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSMSSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmailSetting_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001096 RID: 4246
		' (get) Token: 0x06002ABA RID: 10938 RVA: 0x0001B7F0 File Offset: 0x000199F0
		' (set) Token: 0x06002ABB RID: 10939 RVA: 0x0001B7FA File Offset: 0x000199FA
		Friend Overridable Property Label1 As Label

		' Token: 0x17001097 RID: 4247
		' (get) Token: 0x06002ABC RID: 10940 RVA: 0x0001B803 File Offset: 0x00019A03
		' (set) Token: 0x06002ABD RID: 10941 RVA: 0x0001B80D File Offset: 0x00019A0D
		Friend Overridable Property Label2 As Label

		' Token: 0x17001098 RID: 4248
		' (get) Token: 0x06002ABE RID: 10942 RVA: 0x0001B816 File Offset: 0x00019A16
		' (set) Token: 0x06002ABF RID: 10943 RVA: 0x001A7AD0 File Offset: 0x001A5CD0
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

		' Token: 0x17001099 RID: 4249
		' (get) Token: 0x06002AC0 RID: 10944 RVA: 0x0001B820 File Offset: 0x00019A20
		' (set) Token: 0x06002AC1 RID: 10945 RVA: 0x0001B82A File Offset: 0x00019A2A
		Friend Overridable Property Panel3 As Panel

		' Token: 0x1700109A RID: 4250
		' (get) Token: 0x06002AC2 RID: 10946 RVA: 0x0001B833 File Offset: 0x00019A33
		' (set) Token: 0x06002AC3 RID: 10947 RVA: 0x0001B83D File Offset: 0x00019A3D
		Friend Overridable Property chkIsEnabled As CheckBox

		' Token: 0x1700109B RID: 4251
		' (get) Token: 0x06002AC4 RID: 10948 RVA: 0x0001B846 File Offset: 0x00019A46
		' (set) Token: 0x06002AC5 RID: 10949 RVA: 0x0001B850 File Offset: 0x00019A50
		Friend Overridable Property chkIsDefault As CheckBox

		' Token: 0x1700109C RID: 4252
		' (get) Token: 0x06002AC6 RID: 10950 RVA: 0x0001B859 File Offset: 0x00019A59
		' (set) Token: 0x06002AC7 RID: 10951 RVA: 0x001A7B14 File Offset: 0x001A5D14
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

		' Token: 0x1700109D RID: 4253
		' (get) Token: 0x06002AC8 RID: 10952 RVA: 0x0001B863 File Offset: 0x00019A63
		' (set) Token: 0x06002AC9 RID: 10953 RVA: 0x0001B86D File Offset: 0x00019A6D
		Friend Overridable Property Label3 As Label

		' Token: 0x1700109E RID: 4254
		' (get) Token: 0x06002ACA RID: 10954 RVA: 0x0001B876 File Offset: 0x00019A76
		' (set) Token: 0x06002ACB RID: 10955 RVA: 0x0001B880 File Offset: 0x00019A80
		Friend Overridable Property Label4 As Label

		' Token: 0x1700109F RID: 4255
		' (get) Token: 0x06002ACC RID: 10956 RVA: 0x0001B889 File Offset: 0x00019A89
		' (set) Token: 0x06002ACD RID: 10957 RVA: 0x0001B893 File Offset: 0x00019A93
		Friend Overridable Property Label5 As Label

		' Token: 0x170010A0 RID: 4256
		' (get) Token: 0x06002ACE RID: 10958 RVA: 0x0001B89C File Offset: 0x00019A9C
		' (set) Token: 0x06002ACF RID: 10959 RVA: 0x0001B8A6 File Offset: 0x00019AA6
		Friend Overridable Property txtID As TextBox

		' Token: 0x170010A1 RID: 4257
		' (get) Token: 0x06002AD0 RID: 10960 RVA: 0x0001B8AF File Offset: 0x00019AAF
		' (set) Token: 0x06002AD1 RID: 10961 RVA: 0x001A7BB4 File Offset: 0x001A5DB4
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

		' Token: 0x170010A2 RID: 4258
		' (get) Token: 0x06002AD2 RID: 10962 RVA: 0x0001B8B9 File Offset: 0x00019AB9
		' (set) Token: 0x06002AD3 RID: 10963 RVA: 0x001A7C14 File Offset: 0x001A5E14
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

		' Token: 0x170010A3 RID: 4259
		' (get) Token: 0x06002AD4 RID: 10964 RVA: 0x0001B8C3 File Offset: 0x00019AC3
		' (set) Token: 0x06002AD5 RID: 10965 RVA: 0x001A7C74 File Offset: 0x001A5E74
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

		' Token: 0x170010A4 RID: 4260
		' (get) Token: 0x06002AD6 RID: 10966 RVA: 0x0001B8CD File Offset: 0x00019ACD
		' (set) Token: 0x06002AD7 RID: 10967 RVA: 0x001A7CB8 File Offset: 0x001A5EB8
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

		' Token: 0x170010A5 RID: 4261
		' (get) Token: 0x06002AD8 RID: 10968 RVA: 0x0001B8D7 File Offset: 0x00019AD7
		' (set) Token: 0x06002AD9 RID: 10969 RVA: 0x001A7D18 File Offset: 0x001A5F18
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

		' Token: 0x170010A6 RID: 4262
		' (get) Token: 0x06002ADA RID: 10970 RVA: 0x0001B8E1 File Offset: 0x00019AE1
		' (set) Token: 0x06002ADB RID: 10971 RVA: 0x0001B8EB File Offset: 0x00019AEB
		Friend Overridable Property Label6 As Label

		' Token: 0x170010A7 RID: 4263
		' (get) Token: 0x06002ADC RID: 10972 RVA: 0x0001B8F4 File Offset: 0x00019AF4
		' (set) Token: 0x06002ADD RID: 10973 RVA: 0x0001B8FE File Offset: 0x00019AFE
		Friend Overridable Property Label7 As Label

		' Token: 0x170010A8 RID: 4264
		' (get) Token: 0x06002ADE RID: 10974 RVA: 0x0001B907 File Offset: 0x00019B07
		' (set) Token: 0x06002ADF RID: 10975 RVA: 0x0001B911 File Offset: 0x00019B11
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x170010A9 RID: 4265
		' (get) Token: 0x06002AE0 RID: 10976 RVA: 0x0001B91A File Offset: 0x00019B1A
		' (set) Token: 0x06002AE1 RID: 10977 RVA: 0x001A7D5C File Offset: 0x001A5F5C
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

		' Token: 0x170010AA RID: 4266
		' (get) Token: 0x06002AE2 RID: 10978 RVA: 0x0001B924 File Offset: 0x00019B24
		' (set) Token: 0x06002AE3 RID: 10979 RVA: 0x001A7DA0 File Offset: 0x001A5FA0
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

		' Token: 0x170010AB RID: 4267
		' (get) Token: 0x06002AE4 RID: 10980 RVA: 0x0001B92E File Offset: 0x00019B2E
		' (set) Token: 0x06002AE5 RID: 10981 RVA: 0x001A7DE4 File Offset: 0x001A5FE4
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

		' Token: 0x170010AC RID: 4268
		' (get) Token: 0x06002AE6 RID: 10982 RVA: 0x0001B938 File Offset: 0x00019B38
		' (set) Token: 0x06002AE7 RID: 10983 RVA: 0x001A7E28 File Offset: 0x001A6028
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

		' Token: 0x170010AD RID: 4269
		' (get) Token: 0x06002AE8 RID: 10984 RVA: 0x0001B942 File Offset: 0x00019B42
		' (set) Token: 0x06002AE9 RID: 10985 RVA: 0x001A7E6C File Offset: 0x001A606C
		Private _btnLOGIN As GelButton
		Friend Overridable Property btnLOGIN As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnLOGIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnLOGIN_Click
				Dim gelButton As GelButton = Me._btnLOGIN
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnLOGIN = value
				gelButton = Me._btnLOGIN
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170010AE RID: 4270
		' (get) Token: 0x06002AEA RID: 10986 RVA: 0x0001B94C File Offset: 0x00019B4C
		' (set) Token: 0x06002AEB RID: 10987 RVA: 0x0001B956 File Offset: 0x00019B56
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x170010AF RID: 4271
		' (get) Token: 0x06002AEC RID: 10988 RVA: 0x0001B95F File Offset: 0x00019B5F
		' (set) Token: 0x06002AED RID: 10989 RVA: 0x0001B969 File Offset: 0x00019B69
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170010B0 RID: 4272
		' (get) Token: 0x06002AEE RID: 10990 RVA: 0x0001B972 File Offset: 0x00019B72
		' (set) Token: 0x06002AEF RID: 10991 RVA: 0x0001B97C File Offset: 0x00019B7C
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x170010B1 RID: 4273
		' (get) Token: 0x06002AF0 RID: 10992 RVA: 0x0001B985 File Offset: 0x00019B85
		' (set) Token: 0x06002AF1 RID: 10993 RVA: 0x0001B98F File Offset: 0x00019B8F
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x170010B2 RID: 4274
		' (get) Token: 0x06002AF2 RID: 10994 RVA: 0x0001B998 File Offset: 0x00019B98
		' (set) Token: 0x06002AF3 RID: 10995 RVA: 0x0001B9A2 File Offset: 0x00019BA2
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x170010B3 RID: 4275
		' (get) Token: 0x06002AF4 RID: 10996 RVA: 0x0001B9AB File Offset: 0x00019BAB
		' (set) Token: 0x06002AF5 RID: 10997 RVA: 0x0001B9B5 File Offset: 0x00019BB5
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x170010B4 RID: 4276
		' (get) Token: 0x06002AF6 RID: 10998 RVA: 0x0001B9BE File Offset: 0x00019BBE
		' (set) Token: 0x06002AF7 RID: 10999 RVA: 0x0001B9C8 File Offset: 0x00019BC8
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x170010B5 RID: 4277
		' (get) Token: 0x06002AF8 RID: 11000 RVA: 0x0001B9D1 File Offset: 0x00019BD1
		' (set) Token: 0x06002AF9 RID: 11001 RVA: 0x0001B9DB File Offset: 0x00019BDB
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170010B6 RID: 4278
		' (get) Token: 0x06002AFA RID: 11002 RVA: 0x0001B9E4 File Offset: 0x00019BE4
		' (set) Token: 0x06002AFB RID: 11003 RVA: 0x0001B9EE File Offset: 0x00019BEE
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x06002AFC RID: 11004 RVA: 0x001A7EB0 File Offset: 0x001A60B0
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

		' Token: 0x06002AFD RID: 11005 RVA: 0x001A7F70 File Offset: 0x001A6170
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID,RTRIM(ServerName), RTRIM(SMTPAddress), RTRIM(Username), RTRIM(Password), Port, RTRIM(TLS_SSL_Required), RTRIM(IsDefault), RTRIM(IsActive) from EmailSetting_login order by ServerName,SMTPAddress", ModCommonClasses.con)
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

		' Token: 0x06002AFE RID: 11006 RVA: 0x0001B9F7 File Offset: 0x00019BF7
		Private Sub frmSMSSetting_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x06002AFF RID: 11007 RVA: 0x001A80D8 File Offset: 0x001A62D8
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

		' Token: 0x06002B00 RID: 11008 RVA: 0x001A8250 File Offset: 0x001A6450
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

		' Token: 0x06002B01 RID: 11009 RVA: 0x001A830C File Offset: 0x001A650C
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

		' Token: 0x06002B02 RID: 11010 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06002B03 RID: 11011 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06002B04 RID: 11012 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06002B05 RID: 11013 RVA: 0x001A83D8 File Offset: 0x001A65D8
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "delete from EmailSetting_login where ID=@d1"
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

		' Token: 0x06002B06 RID: 11014 RVA: 0x001A84F8 File Offset: 0x001A66F8
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

		' Token: 0x06002B07 RID: 11015 RVA: 0x001A870C File Offset: 0x001A690C
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

		' Token: 0x06002B08 RID: 11016 RVA: 0x001A87F4 File Offset: 0x001A69F4
		Private Sub cmbServerName_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.cmbServerName.SelectedIndex = 0
			If flag Then
				Me.txtSMTPAddress.Text = "imap.mail.yahoo.com"
				Me.txtPort.Text = Conversions.ToString(993)
			End If
			Dim flag2 As Boolean = Me.cmbServerName.SelectedIndex = 1
			If flag2 Then
				Me.txtSMTPAddress.Text = "imap.gmail.com"
				Me.txtPort.Text = Conversions.ToString(993)
			End If
			Dim flag3 As Boolean = Me.cmbServerName.SelectedIndex = 2
			If flag3 Then
				Me.txtSMTPAddress.Text = "imap.rediffmail.com"
				Me.txtPort.Text = Conversions.ToString(993)
			End If
			Dim flag4 As Boolean = Me.cmbServerName.SelectedIndex = 3
			If flag4 Then
				Me.txtSMTPAddress.Text = "imap-mail.outlook.com"
				Me.txtPort.Text = Conversions.ToString(993)
			End If
		End Sub

		' Token: 0x06002B09 RID: 11017 RVA: 0x0008BE54 File Offset: 0x0008A054
		Private Sub txtPort_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim flag As Boolean = ((e.KeyChar < "0"c) Or (e.KeyChar > "9"c)) And (e.KeyChar <> vbBack)
			If flag Then
				e.Handled = True
			End If
		End Sub

		' Token: 0x06002B0A RID: 11018 RVA: 0x001A88F0 File Offset: 0x001A6AF0
		Private Sub dgw_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 4 AndAlso e.Value IsNot Nothing
			If flag Then
				Me.dgw.Rows(e.RowIndex).Tag = RuntimeHelpers.GetObjectValue(e.Value)
				e.Value = New String("●"c, e.Value.ToString().Length)
			End If
		End Sub

		' Token: 0x06002B0B RID: 11019 RVA: 0x001A8964 File Offset: 0x001A6B64
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

		' Token: 0x06002B0C RID: 11020 RVA: 0x001A89CC File Offset: 0x001A6BCC
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

		' Token: 0x06002B0D RID: 11021 RVA: 0x0001BA08 File Offset: 0x00019C08
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06002B0E RID: 11022 RVA: 0x001A8AD4 File Offset: 0x001A6CD4
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
											Dim text2 As String = "select IsDefault from EmailSetting_login where IsDefault='Yes'"
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
										Dim text3 As String = "insert into EmailSetting_login(ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
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

		' Token: 0x06002B0F RID: 11023 RVA: 0x001A8F80 File Offset: 0x001A7180
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
										Dim text As String = "Update EmailSetting_login set IsDefault='No'"
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
									Dim text2 As String = If(("Update EmailSetting_login set ServerName=@d1, SMTPAddress=@d2, Username=@d3, Password=@d4, Port=@d5, TLS_SSL_Required=@d6, IsDefault=@d7, IsActive=@d8 where ID=" + Me.txtID.Text), "")
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

		' Token: 0x06002B10 RID: 11024 RVA: 0x001A935C File Offset: 0x001A755C
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

		' Token: 0x06002B11 RID: 11025 RVA: 0x0001BA12 File Offset: 0x00019C12
		Private Sub btnLOGIN_Click(sender As Object, e As EventArgs)
			MyBase.Close()
			MyProject.Forms.frmEmailDashboard.ShowDialog()
		End Sub

		' Token: 0x06002B12 RID: 11026 RVA: 0x001A93C4 File Offset: 0x001A75C4
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

		' Token: 0x06002B13 RID: 11027 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x04001266 RID: 4710
		Private st1 As String

		' Token: 0x04001267 RID: 4711
		Private st2 As String

		' Token: 0x04001268 RID: 4712
		Private st3 As String
	End Class
End Namespace
