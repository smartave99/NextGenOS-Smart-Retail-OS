Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GDClient
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000345 RID: 837
	<DesignerGenerated()>
	Public Partial Class FrmGDClientSample
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C3E0 RID: 50144 RVA: 0x007C5DAC File Offset: 0x007C3FAC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmGDClientSample_Load
			AddHandler MyBase.Closing, AddressOf Me.FrmGDClientSample_Closing
			AddHandler MyBase.KeyDown, AddressOf Me.FrmGDClientSample_KeyDown
			Me.compname = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004DC4 RID: 19908
		' (get) Token: 0x0600C3E3 RID: 50147 RVA: 0x0005795E File Offset: 0x00055B5E
		' (set) Token: 0x0600C3E4 RID: 50148 RVA: 0x00057968 File Offset: 0x00055B68
		Friend Overridable Property textDataDirectory As TextBox

		' Token: 0x17004DC5 RID: 19909
		' (get) Token: 0x0600C3E5 RID: 50149 RVA: 0x00057971 File Offset: 0x00055B71
		' (set) Token: 0x0600C3E6 RID: 50150 RVA: 0x007C7178 File Offset: 0x007C5378
		Private _btnBrowse As Button
		Friend Overridable Property btnBrowse As Button
			<CompilerGenerated()>
			Get
				Return Me._btnBrowse
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnBrowse_Click
				Dim button As Button = Me._btnBrowse
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnBrowse = value
				button = Me._btnBrowse
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004DC6 RID: 19910
		' (get) Token: 0x0600C3E7 RID: 50151 RVA: 0x0005797B File Offset: 0x00055B7B
		' (set) Token: 0x0600C3E8 RID: 50152 RVA: 0x00057985 File Offset: 0x00055B85
		Friend Overridable Property folderBrowserDialog As FolderBrowserDialog

		' Token: 0x17004DC7 RID: 19911
		' (get) Token: 0x0600C3E9 RID: 50153 RVA: 0x0005798E File Offset: 0x00055B8E
		' (set) Token: 0x0600C3EA RID: 50154 RVA: 0x00057998 File Offset: 0x00055B98
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004DC8 RID: 19912
		' (get) Token: 0x0600C3EB RID: 50155 RVA: 0x000579A1 File Offset: 0x00055BA1
		' (set) Token: 0x0600C3EC RID: 50156 RVA: 0x000579AB File Offset: 0x00055BAB
		Friend Overridable Property Label1 As Label

		' Token: 0x17004DC9 RID: 19913
		' (get) Token: 0x0600C3ED RID: 50157 RVA: 0x000579B4 File Offset: 0x00055BB4
		' (set) Token: 0x0600C3EE RID: 50158 RVA: 0x000579BE File Offset: 0x00055BBE
		Friend Overridable Property Label2 As Label

		' Token: 0x17004DCA RID: 19914
		' (get) Token: 0x0600C3EF RID: 50159 RVA: 0x000579C7 File Offset: 0x00055BC7
		' (set) Token: 0x0600C3F0 RID: 50160 RVA: 0x007C71BC File Offset: 0x007C53BC
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

		' Token: 0x17004DCB RID: 19915
		' (get) Token: 0x0600C3F1 RID: 50161 RVA: 0x000579D1 File Offset: 0x00055BD1
		' (set) Token: 0x0600C3F2 RID: 50162 RVA: 0x000579DB File Offset: 0x00055BDB
		Friend Overridable Property lblUser As Label

		' Token: 0x17004DCC RID: 19916
		' (get) Token: 0x0600C3F3 RID: 50163 RVA: 0x000579E4 File Offset: 0x00055BE4
		' (set) Token: 0x0600C3F4 RID: 50164 RVA: 0x000579EE File Offset: 0x00055BEE
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17004DCD RID: 19917
		' (get) Token: 0x0600C3F5 RID: 50165 RVA: 0x000579F7 File Offset: 0x00055BF7
		' (set) Token: 0x0600C3F6 RID: 50166 RVA: 0x00057A01 File Offset: 0x00055C01
		Friend Overridable Property txtDB As TextBox

		' Token: 0x17004DCE RID: 19918
		' (get) Token: 0x0600C3F7 RID: 50167 RVA: 0x00057A0A File Offset: 0x00055C0A
		' (set) Token: 0x0600C3F8 RID: 50168 RVA: 0x007C7200 File Offset: 0x007C5400
		Private _dataGridView As DataGridView
		Friend Overridable Property dataGridView As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dataGridView
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dataGridView_RowPostPaint
				Dim dataGridView As DataGridView = Me._dataGridView
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dataGridView = value
				dataGridView = Me._dataGridView
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004DCF RID: 19919
		' (get) Token: 0x0600C3F9 RID: 50169 RVA: 0x00057A14 File Offset: 0x00055C14
		' (set) Token: 0x0600C3FA RID: 50170 RVA: 0x00057A1E File Offset: 0x00055C1E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004DD0 RID: 19920
		' (get) Token: 0x0600C3FB RID: 50171 RVA: 0x00057A27 File Offset: 0x00055C27
		' (set) Token: 0x0600C3FC RID: 50172 RVA: 0x00057A31 File Offset: 0x00055C31
		Friend Overridable Property Label3 As Label

		' Token: 0x17004DD1 RID: 19921
		' (get) Token: 0x0600C3FD RID: 50173 RVA: 0x00057A3A File Offset: 0x00055C3A
		' (set) Token: 0x0600C3FE RID: 50174 RVA: 0x007C7244 File Offset: 0x007C5444
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

		' Token: 0x17004DD2 RID: 19922
		' (get) Token: 0x0600C3FF RID: 50175 RVA: 0x00057A44 File Offset: 0x00055C44
		' (set) Token: 0x0600C400 RID: 50176 RVA: 0x007C7288 File Offset: 0x007C5488
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

		' Token: 0x17004DD3 RID: 19923
		' (get) Token: 0x0600C401 RID: 50177 RVA: 0x00057A4E File Offset: 0x00055C4E
		' (set) Token: 0x0600C402 RID: 50178 RVA: 0x007C72CC File Offset: 0x007C54CC
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

		' Token: 0x17004DD4 RID: 19924
		' (get) Token: 0x0600C403 RID: 50179 RVA: 0x00057A58 File Offset: 0x00055C58
		' (set) Token: 0x0600C404 RID: 50180 RVA: 0x007C7310 File Offset: 0x007C5510
		Private _btnBackup As GelButton
		Friend Overridable Property btnBackup As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnBackup
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._btnBackup
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnBackup = value
				gelButton = Me._btnBackup
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004DD5 RID: 19925
		' (get) Token: 0x0600C405 RID: 50181 RVA: 0x00057A62 File Offset: 0x00055C62
		' (set) Token: 0x0600C406 RID: 50182 RVA: 0x007C7354 File Offset: 0x007C5554
		Private _btnRestore As GelButton
		Friend Overridable Property btnRestore As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRestore
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnAddCustomer_Click
				Dim gelButton As GelButton = Me._btnRestore
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRestore = value
				gelButton = Me._btnRestore
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600C407 RID: 50183 RVA: 0x007C7398 File Offset: 0x007C5598
		Private Sub FrmGDClientSample_Load(sender As Object, e As EventArgs)
			Try
				Me.gDClient = New Global.GDClient.GDClient()
				Me.dataGridView.DataSource = Me.gDClient.ListData()
				Me.dataGridView.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
			Dim flag As Boolean = Not Directory.Exists("D:\SBPE_DATA")
			If flag Then
				Directory.CreateDirectory("D:\SBPE_DATA")
			End If
			Me.CompanyInfoDisplay()
			Me.dataGridView.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dataGridView.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600C408 RID: 50184 RVA: 0x007C749C File Offset: 0x007C569C
		Private Sub btnBrowse_Click(sender As Object, e As EventArgs)
			Me.folderBrowserDialog.ShowNewFolderButton = True
			Dim dialogResult As DialogResult = Me.folderBrowserDialog.ShowDialog()
			Dim flag As Boolean = dialogResult = DialogResult.OK
			Dim flag2 As Boolean = flag
			If flag2 Then
				Me.textDataDirectory.Text = Me.folderBrowserDialog.SelectedPath
				Dim rootFolder As Environment.SpecialFolder = Me.folderBrowserDialog.RootFolder
			End If
		End Sub

		' Token: 0x0600C409 RID: 50185 RVA: 0x007C74F4 File Offset: 0x007C56F4
		Private Sub dataGridView_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dataGridView.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dataGridView.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600C40A RID: 50186 RVA: 0x00057A6C File Offset: 0x00055C6C
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C40B RID: 50187 RVA: 0x007C75DC File Offset: 0x007C57DC
		Public Sub autoBackup()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.stX = array(0)
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Me.stX + ".bak"
				Me.Filename = "D:\SBPE_DATA\" + Me.stX + ".bak"
				Dim flag As Boolean = File.Exists(text)
				If flag Then
					File.Delete(text)
				End If
				ModCommonClasses.con = New SqlConnection(ModCS.ReadCS())
				ModCommonClasses.con.Open()
				Dim text2 As String = String.Concat(New String() { "backup database ", Me.stX, " to disk='", Me.Filename, "'with format" })
				ModCommonClasses.cmd = New SqlCommand(text2)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.ExecuteReader()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C40C RID: 50188 RVA: 0x007C770C File Offset: 0x007C590C
		Private Sub FrmGDClientSample_Closing(sender As Object, e As CancelEventArgs)
			Dim text As String = "D:\SBPE_DATA"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
			Me.txtDB.Text = ""
		End Sub

		' Token: 0x0600C40D RID: 50189 RVA: 0x007C7760 File Offset: 0x007C5960
		Public Sub CompanyInfoDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT ID, CompanyName, Address, ContactNo, EmailID, GSTIN, State, RTRIM(FYFrom), RTRIM(FYTo) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.compname = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.compname = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C40E RID: 50190 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub FrmGDClientSample_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C40F RID: 50191 RVA: 0x007C783C File Offset: 0x007C5A3C
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.textDataDirectory.Text = "D:\SBPE_DATA"
			Try
				Me.gDClient = New Global.GDClient.GDClient()
				Me.dataGridView.DataSource = Me.gDClient.ListData()
				Me.dataGridView.ClearSelection()
			Catch ex As Exception
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C410 RID: 50192 RVA: 0x007C78C0 File Offset: 0x007C5AC0
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = MessageBox.Show("Do you really want to delete this backup data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim text As String = Me.dataGridView.SelectedRows(0).Cells("Id").Value.ToString()
				Dim flag3 As Boolean = Me.gDClient.Delete(text)
				MessageBox.Show("Successfully Deleted")
				Me.dataGridView.DataSource = Me.gDClient.ListData()
			End If
		End Sub

		' Token: 0x0600C411 RID: 50193 RVA: 0x007C7948 File Offset: 0x007C5B48
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmMainMenu.Label1.Text = Me.lblUser.Text
			MyProject.Forms.frmMainMenu.Restoredata()
			Me.CompanyInfoDisplay()
			ModCommonClasses.con = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
			ModCommonClasses.con.Open()
			Dim text As String = "Update RaintechMaster set companyName=@d1 where DBName=@d2"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.compname)
			ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtDB.Text)
			ModCommonClasses.cmd.ExecuteNonQuery()
			ModCommonClasses.con.Close()
		End Sub

		' Token: 0x0600C412 RID: 50194 RVA: 0x007C7A1C File Offset: 0x007C5C1C
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Dim text As String = "D:\SBPE_DATA"
			For Each text2 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
				File.Delete(text2)
			Next
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Me.autoBackup()
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim flag2 As Boolean = Me.textDataDirectory.TextLength > 0
					Dim flag3 As Boolean = flag2
					If flag3 Then
						Dim flag4 As Boolean = Directory.Exists(Me.textDataDirectory.Text)
						Dim flag5 As Boolean = flag4
						If flag5 Then
							Dim gddata As GDData = Me.gDClient.BackupData(Me.textDataDirectory.Text)
							MessageBox.Show("Successfully Backed Up, File ID : " + gddata.Id)
							Me.dataGridView.DataSource = Me.gDClient.ListData()
						Else
							MessageBox.Show("Directory not exists")
						End If
					Else
						MessageBox.Show("Data directory not selected")
					End If
					For Each text3 As String In Directory.GetFiles(text, "*.*", SearchOption.TopDirectoryOnly)
						File.Delete(text3)
					Next
				Catch ex As Exception
				End Try
			Else
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600C413 RID: 50195 RVA: 0x007C7B98 File Offset: 0x007C5D98
		Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not Directory.Exists("D:\SBPE_DATA")
			If flag Then
				Directory.CreateDirectory("D:\SBPE_DATA")
			End If
			Dim flag2 As Boolean = ModFunc.CheckForInternetConnection()
			If flag2 Then
				Try
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim flag3 As Boolean = Me.textDataDirectory.TextLength > 0
					Dim flag4 As Boolean = flag3
					If flag4 Then
						Dim flag5 As Boolean = Not Directory.Exists(Me.textDataDirectory.Text)
						Dim flag6 As Boolean = flag5
						If flag6 Then
							Directory.CreateDirectory(Me.textDataDirectory.Text)
						End If
						Dim flag7 As Boolean = Me.dataGridView.SelectedRows.Count > 0
						Dim flag8 As Boolean = flag7
						If flag8 Then
							Dim text As String = Me.dataGridView.SelectedRows(0).Cells("Id").Value.ToString()
							Dim gddata As GDData = Me.gDClient.RestoreData(text, Me.textDataDirectory.Text)
							MessageBox.Show("Successfully Downloaded the file in " + Me.textDataDirectory.Text + ", File ID : " + gddata.Id)
						Else
							MessageBox.Show("Backup data not selected")
						End If
					Else
						MessageBox.Show("Data directory not selected")
					End If
				Catch ex As Exception
				End Try
			Else
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x04004E96 RID: 20118
		Private gDClient As Global.GDClient.GDClient

		' Token: 0x04004E97 RID: 20119
		Private compname As String

		' Token: 0x04004E98 RID: 20120
		Private Filename As String

		' Token: 0x04004E99 RID: 20121
		Private stX As String
	End Class
End Namespace
