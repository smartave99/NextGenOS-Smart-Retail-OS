Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005BA RID: 1466
	<DesignerGenerated()>
	Public Partial Class frmSqlServerSetting
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011DD1 RID: 73169 RVA: 0x0007A9F5 File Offset: 0x00078BF5
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSqlServerSetting_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSqlServerSetting_KeyDown
			Me.InitializeComponent()
			AddHandler MyBase.Shown, Sub(sender, e)
				If Not AppleUITheme.IsCapturing Then RetailLayouts.Apply(Me)
			End Sub
		End Sub

		' Token: 0x17006EF3 RID: 28403
		' (get) Token: 0x06011DD4 RID: 73172 RVA: 0x0007AA27 File Offset: 0x00078C27
		' (set) Token: 0x06011DD5 RID: 73173 RVA: 0x0007AA31 File Offset: 0x00078C31
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006EF4 RID: 28404
		' (get) Token: 0x06011DD6 RID: 73174 RVA: 0x0007AA3A File Offset: 0x00078C3A
		' (set) Token: 0x06011DD7 RID: 73175 RVA: 0x0007AA44 File Offset: 0x00078C44
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006EF5 RID: 28405
		' (get) Token: 0x06011DD8 RID: 73176 RVA: 0x0007AA4D File Offset: 0x00078C4D
		' (set) Token: 0x06011DD9 RID: 73177 RVA: 0x0007AA57 File Offset: 0x00078C57
		Friend Overridable Property Label1 As Label

		' Token: 0x17006EF6 RID: 28406
		' (get) Token: 0x06011DDA RID: 73178 RVA: 0x0007AA60 File Offset: 0x00078C60
		' (set) Token: 0x06011DDB RID: 73179 RVA: 0x00A4DB1C File Offset: 0x00A4BD1C
		Private _btnCreateDemoDataDB As Button
		Friend Overridable Property btnCreateDemoDataDB As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCreateDemoDataDB
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim button As Button = Me._btnCreateDemoDataDB
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnCreateDemoDataDB = value
				button = Me._btnCreateDemoDataDB
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EF7 RID: 28407
		' (get) Token: 0x06011DDC RID: 73180 RVA: 0x0007AA6A File Offset: 0x00078C6A
		' (set) Token: 0x06011DDD RID: 73181 RVA: 0x0007AA74 File Offset: 0x00078C74
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006EF8 RID: 28408
		' (get) Token: 0x06011DDE RID: 73182 RVA: 0x0007AA7D File Offset: 0x00078C7D
		' (set) Token: 0x06011DDF RID: 73183 RVA: 0x00A4DB60 File Offset: 0x00A4BD60
		Private _btnClose As Button
		Friend Overridable Property btnClose As Button
			<CompilerGenerated()>
			Get
				Return Me._btnClose
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnClose_Click
				Dim button As Button = Me._btnClose
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnClose = value
				button = Me._btnClose
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EF9 RID: 28409
		' (get) Token: 0x06011DE0 RID: 73184 RVA: 0x0007AA87 File Offset: 0x00078C87
		' (set) Token: 0x06011DE1 RID: 73185 RVA: 0x00A4DBA4 File Offset: 0x00A4BDA4
		Private _LinkLabel1 As LinkLabel
		Friend Overridable Property LinkLabel1 As LinkLabel
			<CompilerGenerated()>
			Get
				Return Me._LinkLabel1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As LinkLabel)
				Dim linkLabelLinkClickedEventHandler As LinkLabelLinkClickedEventHandler = AddressOf Me.LinkLabel1_LinkClicked
				Dim linkLabel As LinkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					RemoveHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
				Me._LinkLabel1 = value
				linkLabel = Me._LinkLabel1
				If linkLabel IsNot Nothing Then
					AddHandler linkLabel.LinkClicked, linkLabelLinkClickedEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EFA RID: 28410
		' (get) Token: 0x06011DE2 RID: 73186 RVA: 0x0007AA91 File Offset: 0x00078C91
		' (set) Token: 0x06011DE3 RID: 73187 RVA: 0x00A4DBE8 File Offset: 0x00A4BDE8
		Private _cmbServerName As ComboBox
		Friend Overridable Property cmbServerName As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbServerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbServerName
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbServerName = value
				comboBox = Me._cmbServerName
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EFB RID: 28411
		' (get) Token: 0x06011DE4 RID: 73188 RVA: 0x0007AA9B File Offset: 0x00078C9B
		' (set) Token: 0x06011DE5 RID: 73189 RVA: 0x00A4DC2C File Offset: 0x00A4BE2C
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

		' Token: 0x17006EFC RID: 28412
		' (get) Token: 0x06011DE6 RID: 73190 RVA: 0x0007AAA5 File Offset: 0x00078CA5
		' (set) Token: 0x06011DE7 RID: 73191 RVA: 0x00A4DC70 File Offset: 0x00A4BE70
		Private _txtUserName As TextBox
		Friend Overridable Property txtUserName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUserName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtUserName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtUserName = value
				textBox = Me._txtUserName
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17006EFD RID: 28413
		' (get) Token: 0x06011DE8 RID: 73192 RVA: 0x0007AAAF File Offset: 0x00078CAF
		' (set) Token: 0x06011DE9 RID: 73193 RVA: 0x0007AAB9 File Offset: 0x00078CB9
		Friend Overridable Property Label3 As Label

		' Token: 0x17006EFE RID: 28414
		' (get) Token: 0x06011DEA RID: 73194 RVA: 0x0007AAC2 File Offset: 0x00078CC2
		' (set) Token: 0x06011DEB RID: 73195 RVA: 0x0007AACC File Offset: 0x00078CCC
		Friend Overridable Property Label2 As Label

		' Token: 0x17006EFF RID: 28415
		' (get) Token: 0x06011DEC RID: 73196 RVA: 0x0007AAD5 File Offset: 0x00078CD5
		' (set) Token: 0x06011DED RID: 73197 RVA: 0x0007AADF File Offset: 0x00078CDF
		Friend Overridable Property Label4 As Label

		' Token: 0x17006F00 RID: 28416
		' (get) Token: 0x06011DEE RID: 73198 RVA: 0x0007AAE8 File Offset: 0x00078CE8
		' (set) Token: 0x06011DEF RID: 73199 RVA: 0x0007AAF2 File Offset: 0x00078CF2
		Friend Overridable Property Label5 As Label

		' Token: 0x17006F01 RID: 28417
		' (get) Token: 0x06011DF0 RID: 73200 RVA: 0x0007AAFB File Offset: 0x00078CFB
		' (set) Token: 0x06011DF1 RID: 73201 RVA: 0x0007AB05 File Offset: 0x00078D05
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17006F02 RID: 28418
		' (get) Token: 0x06011DF2 RID: 73202 RVA: 0x0007AB0E File Offset: 0x00078D0E
		' (set) Token: 0x06011DF3 RID: 73203 RVA: 0x0007AB18 File Offset: 0x00078D18
		Friend Overridable Property lblSet As Label

		' Token: 0x17006F03 RID: 28419
		' (get) Token: 0x06011DF4 RID: 73204 RVA: 0x0007AB21 File Offset: 0x00078D21
		' (set) Token: 0x06011DF5 RID: 73205 RVA: 0x00A4DCB4 File Offset: 0x00A4BEB4
		Private _btnTestConnection As Button
		Friend Overridable Property btnTestConnection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnTestConnection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnTestConnection_Click_1
				Dim button As Button = Me._btnTestConnection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnTestConnection = value
				button = Me._btnTestConnection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F04 RID: 28420
		' (get) Token: 0x06011DF6 RID: 73206 RVA: 0x0007AB2B File Offset: 0x00078D2B
		' (set) Token: 0x06011DF7 RID: 73207 RVA: 0x00A4DCF8 File Offset: 0x00A4BEF8
		Private _Timer2 As Timer
		Friend Overridable Property Timer2 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006F05 RID: 28421
		' (get) Token: 0x06011DF8 RID: 73208 RVA: 0x0007AB35 File Offset: 0x00078D35
		' (set) Token: 0x06011DF9 RID: 73209 RVA: 0x0007AB3F File Offset: 0x00078D3F
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17006F06 RID: 28422
		' (get) Token: 0x06011DFA RID: 73210 RVA: 0x0007AB48 File Offset: 0x00078D48
		' (set) Token: 0x06011DFB RID: 73211 RVA: 0x0007AB52 File Offset: 0x00078D52
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x17006F07 RID: 28423
		' (get) Token: 0x06011DFC RID: 73212 RVA: 0x0007AB5B File Offset: 0x00078D5B
		' (set) Token: 0x06011DFD RID: 73213 RVA: 0x00A4DD3C File Offset: 0x00A4BF3C
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

		' Token: 0x17006F08 RID: 28424
		' (get) Token: 0x06011DFE RID: 73214 RVA: 0x0007AB65 File Offset: 0x00078D65
		' (set) Token: 0x06011DFF RID: 73215 RVA: 0x0007AB6F File Offset: 0x00078D6F
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x06011E00 RID: 73216 RVA: 0x00A4DD80 File Offset: 0x00A4BF80
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Operators.CompareString(Me.cmbServerName.Text, "", False) = 0
				Dim flag2 As Boolean = flag
				If flag2 Then
					MessageBox.Show("Please select/enter Server Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.cmbServerName.Focus()
				Else
					flag = Me.txtUserName.Text.Length = 0
					Dim flag3 As Boolean = flag
					If flag3 Then
						MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtUserName.Focus()
					Else
						flag = Me.txtPassword.Text.Length = 0
						Dim flag4 As Boolean = flag
						If flag4 Then
							MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.txtPassword.Focus()
						Else
							Me.Cursor = Cursors.WaitCursor
							Me.Timer2.Enabled = True
							ModCommonClasses.con = New SqlConnection(String.Concat(New String() { "Data Source=", Me.cmbServerName.Text.Trim(), ";Initial Catalog=master;User ID=", Me.txtUserName.Text.Trim(), ";Password=", Me.txtPassword.Text, ";MultipleActiveResultSets=True" }))
							ModCommonClasses.con.Open()
							flag = ModCommonClasses.con.State = ConnectionState.Open
							Dim flag5 As Boolean = flag
							If flag5 Then
								Dim flag6 As Boolean = MessageBox.Show("It will create the DB and configure the sql server, Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
								Dim flag7 As Boolean = flag6
								If flag7 Then
									Dim streamWriter As StreamWriter = New StreamWriter(Application.StartupPath + "\SQLSettings.dat")
									Try
										streamWriter.WriteLine(Me.cmbServerName.Text.Trim())
										streamWriter.WriteLine(Me.txtUserName.Text.Trim())
										streamWriter.WriteLine(Me.txtPassword.Text.Trim())
										streamWriter.Close()
										Me.CreateDB()
										MessageBox.Show("DB has been created and SQL Server setting has been saved successfully..." & vbCrLf & "Application will be closed,Please start it again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										ProjectData.EndApp()
									Finally
										flag6 = streamWriter IsNot Nothing
										Dim flag8 As Boolean = flag6
										If flag8 Then
											CType(streamWriter, IDisposable).Dispose()
										End If
									End Try
								End If
							End If
							ModCommonClasses.con.Close()
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show("Unable to connect to sql server" & vbCrLf + Microsoft.VisualBasic.Information.Err().Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011E01 RID: 73217 RVA: 0x00A4E03C File Offset: 0x00A4C23C
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblSet.Text, "Main Form", False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MyBase.Close()
			Else
				flag = MessageBox.Show("Do you want to close the application....?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				Dim flag3 As Boolean = flag
				If flag3 Then
					ProjectData.EndApp()
				End If
			End If
		End Sub

		' Token: 0x06011E02 RID: 73218 RVA: 0x00A4E098 File Offset: 0x00A4C298
		Public Sub CreateDB()
			Try
				Dim text As String = "Data source=" + Me.cmbServerName.Text + ";Initial Catalog=master;Integrated Security=True;"
				ModCommonClasses.con = New SqlConnection(text)
				ModCommonClasses.con.Open()
				Dim text2 As String = "Select * from sysdatabases where name='RaintechMaster_DB'"
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					ModCommonClasses.con = New SqlConnection(text)
					ModCommonClasses.con.Open()
					Dim text3 As String = "USE Master ALTER DATABASE RaintechMaster_DB SET Single_User WITH Rollback Immediate DROP database RaintechMaster_DB"
					ModCommonClasses.cmd = New SqlCommand(text3)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Try
						ModCommonClasses.con = New SqlConnection(text)
						ModCommonClasses.con.Open()
						Dim text4 As String = "Create Database RaintechMaster_DB"
						ModCommonClasses.cmd = New SqlCommand(text4)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.cmd.ExecuteNonQuery()
						ModCommonClasses.con.Close()
						Dim streamReader As StreamReader = New StreamReader(Application.StartupPath + "\CompanyMasterDBScript.sql")
						Try
							Me.st = streamReader.ReadToEnd()
							Dim server As Server = New Server(New ServerConnection(ModCommonClasses.con))
							server.ConnectionContext.ExecuteNonQuery(Me.st)
						Finally
							flag = streamReader IsNot Nothing
							Dim flag3 As Boolean = flag
							If flag3 Then
								CType(streamReader, IDisposable).Dispose()
							End If
						End Try
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				Else
					ModCommonClasses.con = New SqlConnection(text)
					ModCommonClasses.con.Open()
					Dim text5 As String = "Create Database RaintechMaster_DB"
					ModCommonClasses.cmd = New SqlCommand(text5)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.cmd.ExecuteNonQuery()
					ModCommonClasses.con.Close()
					Dim streamReader2 As StreamReader = New StreamReader(Application.StartupPath + "\CompanyMasterDBScript.sql")
					Try
						Me.st = streamReader2.ReadToEnd()
						Dim server2 As Server = New Server(New ServerConnection(ModCommonClasses.con))
						server2.ConnectionContext.ExecuteNonQuery(Me.st)
					Finally
						flag = streamReader2 IsNot Nothing
						Dim flag4 As Boolean = flag
						If flag4 Then
							CType(streamReader2, IDisposable).Dispose()
						End If
					End Try
				End If
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Finally
				Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				Dim flag6 As Boolean = flag5
				If flag6 Then
					ModCommonClasses.con.Close()
				End If
			End Try
		End Sub

		' Token: 0x06011E03 RID: 73219 RVA: 0x00A4E3D0 File Offset: 0x00A4C5D0
		Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer2.Enabled = True
				Dim dataTable As DataTable = SmoApplication.EnumAvailableSqlServers(True)
				Me.cmbServerName.ValueMember = "Name"
				Me.cmbServerName.DataSource = dataTable
				Dim text As String = Me.cmbServerName.SelectedValue.ToString()
				Dim server As Server = New Server(text)
			Catch ex As Exception
				MessageBox.Show("Sorry unable to find SQL Server instance" & vbCrLf & "If you have installed SQL Server then enter name of SQL Server instance manually", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			End Try
		End Sub

		' Token: 0x06011E04 RID: 73220 RVA: 0x0007AB78 File Offset: 0x00078D78
		Public Sub Reset()
			Me.txtPassword.Text = ""
			Me.txtUserName.Text = ""
			Me.cmbServerName.Text = ""
		End Sub

		' Token: 0x06011E05 RID: 73221 RVA: 0x00A4E46C File Offset: 0x00A4C66C
		Private Sub btnTestConnection_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.cmbServerName.Text, "", False) = 0
			Dim flag2 As Boolean = flag
			If flag2 Then
				MessageBox.Show("Please select/enter Server Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.cmbServerName.Focus()
			Else
				flag = Me.txtUserName.Text.Length = 0
				Dim flag3 As Boolean = flag
				If flag3 Then
					MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.txtUserName.Focus()
				Else
					flag = Me.txtPassword.Text.Length = 0
					Dim flag4 As Boolean = flag
					If flag4 Then
						MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.txtPassword.Focus()
					Else
						Me.Cursor = Cursors.WaitCursor
						Me.Timer2.Enabled = True
						Dim sqlConnection As SqlConnection = New SqlConnection()
						Me.SqlConnStr = String.Concat(New String() { "Data Source=", Me.cmbServerName.Text.Trim(), ";Initial Catalog=master;User ID=", Me.txtUserName.Text.Trim(), ";Password=", Me.txtPassword.Text, "" })
						flag = sqlConnection.State = ConnectionState.Closed
						Dim flag5 As Boolean = flag
						If flag5 Then
							sqlConnection.ConnectionString = Me.SqlConnStr
							Try
								sqlConnection.Open()
								MessageBox.Show("Succsessfull DB Connnection", "DB Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Catch ex As Exception
								MessageBox.Show("Invalid DB SqlConnnection" & vbCrLf + Microsoft.VisualBasic.Information.Err().Description, "DB Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06011E06 RID: 73222 RVA: 0x0007ABAE File Offset: 0x00078DAE
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x06011E07 RID: 73223 RVA: 0x00A4E648 File Offset: 0x00A4C848
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.cmbServerName.Text = ""
			Me.txtUserName.Text = ""
			Me.txtPassword.Text = ""
			Me.LinkLabel1.Focus()
		End Sub

		' Token: 0x06011E08 RID: 73224 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmSqlServerSetting_Load(sender As Object, e As EventArgs)
			Me.BackColor = AppleUITheme.CanvasBg
			AppleUITheme.ApplyPrimaryButton(Me.btnCreateDemoDataDB, "Save Setting", False)
			AppleUITheme.ApplySecondaryButton(Me.btnTestConnection, "Test Connection")
			AppleUITheme.ApplySecondaryButton(Me.btnClose, "Close")
			AppleUITheme.ApplySecondaryButton(Me.Button1, "Reset")
		End Sub

		' Token: 0x06011E09 RID: 73225 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSqlServerSetting_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011E0A RID: 73226 RVA: 0x00A4E698 File Offset: 0x00A4C898
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtUserName.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtUserName, "Enter the database username.")
			Else
				Me.ErrorProvider1.SetError(Me.txtUserName, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtPassword.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtPassword, "Enter the database password.")
			Else
				Me.ErrorProvider1.SetError(Me.txtPassword, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.cmbServerName.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.cmbServerName, "Enter a SQL Server name.")
			Else
				Me.ErrorProvider1.SetError(Me.cmbServerName, String.Empty)
			End If
		End Sub

		' Token: 0x04006B87 RID: 27527
		Private st As String

		' Token: 0x04006B88 RID: 27528
		Private SqlConnStr As String
	End Class
End Namespace
