Namespace BillPoint
	' Token: 0x02000373 RID: 883
		Public Partial Class frmWAppAPIServer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600D07F RID: 53375 RVA: 0x0081EFD8 File Offset: 0x0081D1D8
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x0600D080 RID: 53376 RVA: 0x0081F028 File Offset: 0x0081D228
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmWAppAPIServer))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtMsgApi = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtFileUrl = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtPassword = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtUserId = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtFtpUrl = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtWApi = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnInitialize = New Global.System.Windows.Forms.Button()
			Me.btnLogout = New Global.System.Windows.Forms.Button()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.ImageList1 = New Global.System.Windows.Forms.ImageList(Me.components)
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnReconnect = New Global.GelButtons.GelButton()
			Me.btnResetInstance = New Global.GelButtons.GelButton()
			Me.btnRebootInstance = New Global.GelButtons.GelButton()
			Me.Panel9 = New Global.System.Windows.Forms.Panel()
			Me.imgBarcode = New Global.System.Windows.Forms.PictureBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.chkBoxHeadLess = New Global.System.Windows.Forms.CheckBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Panel8 = New Global.System.Windows.Forms.Panel()
			Me.LblSenderId = New Global.System.Windows.Forms.Label()
			Me.lblWhatsAppState = New Global.System.Windows.Forms.Label()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.pBoxAuthQR = New Global.System.Windows.Forms.PictureBox()
			Me.btnTerminate = New Global.System.Windows.Forms.Button()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel4.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.Panel9.SuspendLayout()
			CType(Me.imgBarcode, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel8.SuspendLayout()
			Me.Panel7.SuspendLayout()
			CType(Me.pBoxAuthQR, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel6.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Timer1.Enabled = True
			Me.Timer1.Interval = 1000
			Me.Column6.HeaderText = "FTP User id"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Visible = False
			Me.Column7.HeaderText = "FTP Password"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Visible = False
			Me.Column8.HeaderText = "File Url"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Visible = False
			Me.Column9.HeaderText = "WhatsApp Text API"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.txtMsgApi)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.txtFileUrl)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtPassword)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtUserId)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.txtFtpUrl)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtWApi)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.TextBox1)
			Me.Panel4.Controls.Add(Me.ComboBox1)
			Me.Panel4.Controls.Add(Me.TextBox2)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 35)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(624, 207)
			Me.Panel4.TabIndex = 0
			Me.txtMsgApi.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMsgApi.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMsgApi.Location = New Global.System.Drawing.Point(125, 178)
			Me.txtMsgApi.Name = "txtMsgApi"
			Me.txtMsgApi.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtMsgApi.Size = New Global.System.Drawing.Size(465, 21)
			Me.txtMsgApi.TabIndex = 427
			Me.txtMsgApi.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtMsgApi.Visible = False
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(4, 178)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(115, 15)
			Me.Label9.TabIndex = 426
			Me.Label9.Text = "WhatsApp Text API :"
			Me.Label9.Visible = False
			Me.txtFileUrl.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFileUrl.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFileUrl.Location = New Global.System.Drawing.Point(100, 151)
			Me.txtFileUrl.Name = "txtFileUrl"
			Me.txtFileUrl.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtFileUrl.Size = New Global.System.Drawing.Size(491, 21)
			Me.txtFileUrl.TabIndex = 425
			Me.txtFileUrl.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtFileUrl.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(5, 151)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label8.TabIndex = 424
			Me.Label8.Text = "File Url :"
			Me.Label8.Visible = False
			Me.txtPassword.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPassword.Location = New Global.System.Drawing.Point(401, 124)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtPassword.Size = New Global.System.Drawing.Size(190, 21)
			Me.txtPassword.TabIndex = 423
			Me.txtPassword.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtPassword.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(306, 127)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(70, 15)
			Me.Label7.TabIndex = 422
			Me.Label7.Text = "Password  :"
			Me.Label7.Visible = False
			Me.txtUserId.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUserId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUserId.Location = New Global.System.Drawing.Point(100, 123)
			Me.txtUserId.Name = "txtUserId"
			Me.txtUserId.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtUserId.Size = New Global.System.Drawing.Size(190, 21)
			Me.txtUserId.TabIndex = 421
			Me.txtUserId.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtUserId.Visible = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(5, 123)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(55, 15)
			Me.Label6.TabIndex = 420
			Me.Label6.Text = "User Id  :"
			Me.Label6.Visible = False
			Me.txtFtpUrl.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFtpUrl.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFtpUrl.Location = New Global.System.Drawing.Point(100, 96)
			Me.txtFtpUrl.Name = "txtFtpUrl"
			Me.txtFtpUrl.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtFtpUrl.Size = New Global.System.Drawing.Size(491, 21)
			Me.txtFtpUrl.TabIndex = 419
			Me.txtFtpUrl.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtFtpUrl.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(5, 96)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(54, 15)
			Me.Label5.TabIndex = 418
			Me.Label5.Text = "FTP Url :"
			Me.Label5.Visible = False
			Me.txtWApi.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWApi.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWApi.Location = New Global.System.Drawing.Point(138, 68)
			Me.txtWApi.Name = "txtWApi"
			Me.txtWApi.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtWApi.Size = New Global.System.Drawing.Size(453, 21)
			Me.txtWApi.TabIndex = 417
			Me.txtWApi.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtWApi.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(5, 68)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(127, 15)
			Me.Label4.TabIndex = 416
			Me.Label4.Text = "WhatsApp Media API :"
			Me.Label4.Visible = False
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(192, 6)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBox1.Size = New Global.System.Drawing.Size(94, 21)
			Me.TextBox1.TabIndex = 0
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Enabled", "Disabled" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(192, 39)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(94, 23)
			Me.ComboBox1.TabIndex = 2
			Me.TextBox2.Location = New Global.System.Drawing.Point(272, 1)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(13, 21)
			Me.TextBox2.TabIndex = 5
			Me.TextBox2.TabStop = False
			Me.TextBox2.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(1, 39)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(126, 15)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "WhatsApp API Status :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(1, 6)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(179, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Country Code of WhatsApp No. :"
			Me.Column5.HeaderText = "FTP URL"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Visible = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(749, 30)
			Me.Panel2.TabIndex = 0
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(749, 32)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "WhatsApp Configuration"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnInitialize.BackgroundImage = Global.BillPoint.My.Resources.Resources.NewGreen
			Me.btnInitialize.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnInitialize.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnInitialize.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnInitialize.ForeColor = Global.System.Drawing.Color.White
			Me.btnInitialize.Location = New Global.System.Drawing.Point(535, 304)
			Me.btnInitialize.Name = "btnInitialize"
			Me.btnInitialize.Size = New Global.System.Drawing.Size(59, 26)
			Me.btnInitialize.TabIndex = 50
			Me.btnInitialize.TabStop = False
			Me.btnInitialize.Text = "Initialize"
			Me.btnInitialize.UseVisualStyleBackColor = True
			Me.btnInitialize.Visible = False
			Me.btnLogout.BackgroundImage = Global.BillPoint.My.Resources.Resources.NewRed
			Me.btnLogout.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnLogout.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLogout.Enabled = False
			Me.btnLogout.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnLogout.ForeColor = Global.System.Drawing.Color.White
			Me.btnLogout.Location = New Global.System.Drawing.Point(670, 308)
			Me.btnLogout.Name = "btnLogout"
			Me.btnLogout.Size = New Global.System.Drawing.Size(59, 26)
			Me.btnLogout.TabIndex = 8
			Me.btnLogout.TabStop = False
			Me.btnLogout.Text = "Logout"
			Me.btnLogout.UseVisualStyleBackColor = True
			Me.ErrorProvider1.ContainerControl = Me
			Me.ImageList1.ColorDepth = Global.System.Windows.Forms.ColorDepth.Depth8Bit
			Me.ImageList1.ImageSize = New Global.System.Drawing.Size(16, 16)
			Me.ImageList1.TransparentColor = Global.System.Drawing.Color.Transparent
			Me.Column4.HeaderText = "WhatsApp Api"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Panel3.BackColor = Global.System.Drawing.Color.White
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnReconnect)
			Me.Panel3.Controls.Add(Me.btnResetInstance)
			Me.Panel3.Controls.Add(Me.btnRebootInstance)
			Me.Panel3.Controls.Add(Me.Panel9)
			Me.Panel3.Controls.Add(Me.chkBoxHeadLess)
			Me.Panel3.Controls.Add(Me.Button1)
			Me.Panel3.Controls.Add(Me.Panel8)
			Me.Panel3.Controls.Add(Me.Button6)
			Me.Panel3.Controls.Add(Me.Panel7)
			Me.Panel3.Controls.Add(Me.btnTerminate)
			Me.Panel3.Controls.Add(Me.Panel6)
			Me.Panel3.Controls.Add(Me.btnLogout)
			Me.Panel3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel3.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(754, 582)
			Me.Panel3.TabIndex = 6
			Me.btnReconnect.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReconnect.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnReconnect.FlatAppearance.BorderSize = 0
			Me.btnReconnect.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReconnect.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReconnect.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnReconnect.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnReconnect.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnReconnect.Image = CType(componentResourceManager.GetObject("btnReconnect.Image"), Global.System.Drawing.Image)
			Me.btnReconnect.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReconnect.Location = New Global.System.Drawing.Point(368, 499)
			Me.btnReconnect.Name = "btnReconnect"
			Me.btnReconnect.Size = New Global.System.Drawing.Size(164, 46)
			Me.btnReconnect.TabIndex = 411
			Me.btnReconnect.Text = "Reconnect"
			Me.btnReconnect.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReconnect.UseVisualStyleBackColor = False
			Me.btnResetInstance.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnResetInstance.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnResetInstance.FlatAppearance.BorderSize = 0
			Me.btnResetInstance.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnResetInstance.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnResetInstance.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnResetInstance.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnResetInstance.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnResetInstance.Image = CType(componentResourceManager.GetObject("btnResetInstance.Image"), Global.System.Drawing.Image)
			Me.btnResetInstance.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnResetInstance.Location = New Global.System.Drawing.Point(368, 452)
			Me.btnResetInstance.Name = "btnResetInstance"
			Me.btnResetInstance.Size = New Global.System.Drawing.Size(164, 46)
			Me.btnResetInstance.TabIndex = 410
			Me.btnResetInstance.Text = "Reset Instance"
			Me.btnResetInstance.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnResetInstance.UseVisualStyleBackColor = False
			Me.btnRebootInstance.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRebootInstance.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnRebootInstance.FlatAppearance.BorderSize = 0
			Me.btnRebootInstance.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRebootInstance.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRebootInstance.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnRebootInstance.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnRebootInstance.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnRebootInstance.Image = CType(componentResourceManager.GetObject("btnRebootInstance.Image"), Global.System.Drawing.Image)
			Me.btnRebootInstance.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRebootInstance.Location = New Global.System.Drawing.Point(368, 405)
			Me.btnRebootInstance.Name = "btnRebootInstance"
			Me.btnRebootInstance.Size = New Global.System.Drawing.Size(164, 46)
			Me.btnRebootInstance.TabIndex = 409
			Me.btnRebootInstance.Text = "Reboot Instance"
			Me.btnRebootInstance.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRebootInstance.UseVisualStyleBackColor = False
			Me.Panel9.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Panel9.Controls.Add(Me.imgBarcode)
			Me.Panel9.Controls.Add(Me.PictureBox1)
			Me.Panel9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel9.Location = New Global.System.Drawing.Point(67, 335)
			Me.Panel9.Name = "Panel9"
			Me.Panel9.Size = New Global.System.Drawing.Size(295, 242)
			Me.Panel9.TabIndex = 406
			Me.imgBarcode.Location = New Global.System.Drawing.Point(3, 8)
			Me.imgBarcode.Name = "imgBarcode"
			Me.imgBarcode.Size = New Global.System.Drawing.Size(289, 218)
			Me.imgBarcode.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.imgBarcode.TabIndex = 8
			Me.imgBarcode.TabStop = False
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox1.Location = New Global.System.Drawing.Point(128, 269)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(42, 25)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 7
			Me.PictureBox1.TabStop = False
			Me.chkBoxHeadLess.AutoSize = True
			Me.chkBoxHeadLess.Checked = True
			Me.chkBoxHeadLess.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkBoxHeadLess.Location = New Global.System.Drawing.Point(468, 312)
			Me.chkBoxHeadLess.Name = "chkBoxHeadLess"
			Me.chkBoxHeadLess.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkBoxHeadLess.TabIndex = 52
			Me.chkBoxHeadLess.Text = "Headless"
			Me.chkBoxHeadLess.UseVisualStyleBackColor = True
			Me.chkBoxHeadLess.Visible = False
			Me.Button1.BackgroundImage = Global.BillPoint.My.Resources.Resources.UpdateOrange
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(368, 373)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(91, 26)
			Me.Button1.TabIndex = 408
			Me.Button1.TabStop = False
			Me.Button1.Text = "Terminate"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Panel8.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel8.Controls.Add(Me.LblSenderId)
			Me.Panel8.Controls.Add(Me.lblWhatsAppState)
			Me.Panel8.Location = New Global.System.Drawing.Point(619, 340)
			Me.Panel8.Name = "Panel8"
			Me.Panel8.Size = New Global.System.Drawing.Size(125, 106)
			Me.Panel8.TabIndex = 53
			Me.LblSenderId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblSenderId.ForeColor = Global.System.Drawing.Color.Chocolate
			Me.LblSenderId.Location = New Global.System.Drawing.Point(248, 3)
			Me.LblSenderId.Margin = New Global.System.Windows.Forms.Padding(3)
			Me.LblSenderId.Name = "LblSenderId"
			Me.LblSenderId.Size = New Global.System.Drawing.Size(211, 23)
			Me.LblSenderId.TabIndex = 0
			Me.LblSenderId.Text = "Sender Id: Unavailable"
			Me.LblSenderId.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.lblWhatsAppState.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblWhatsAppState.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblWhatsAppState.Location = New Global.System.Drawing.Point(123, 17)
			Me.lblWhatsAppState.Margin = New Global.System.Windows.Forms.Padding(3)
			Me.lblWhatsAppState.Name = "lblWhatsAppState"
			Me.lblWhatsAppState.Size = New Global.System.Drawing.Size(115, 10)
			Me.lblWhatsAppState.TabIndex = 0
			Me.lblWhatsAppState.Text = "Engine : Not Ready"
			Me.lblWhatsAppState.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button6.BackgroundImage = Global.BillPoint.My.Resources.Resources.NewGreen
			Me.Button6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.Location = New Global.System.Drawing.Point(368, 341)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(88, 26)
			Me.Button6.TabIndex = 407
			Me.Button6.TabStop = False
			Me.Button6.Text = "Initialize"
			Me.Button6.UseVisualStyleBackColor = True
			Me.Panel7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Panel7.Controls.Add(Me.pBoxAuthQR)
			Me.Panel7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel7.Location = New Global.System.Drawing.Point(539, 340)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(62, 226)
			Me.Panel7.TabIndex = 49
			Me.pBoxAuthQR.BackColor = Global.System.Drawing.Color.White
			Me.pBoxAuthQR.Location = New Global.System.Drawing.Point(128, 269)
			Me.pBoxAuthQR.Name = "pBoxAuthQR"
			Me.pBoxAuthQR.Size = New Global.System.Drawing.Size(42, 25)
			Me.pBoxAuthQR.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pBoxAuthQR.TabIndex = 7
			Me.pBoxAuthQR.TabStop = False
			Me.btnTerminate.BackgroundImage = Global.BillPoint.My.Resources.Resources.UpdateOrange
			Me.btnTerminate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTerminate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTerminate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTerminate.ForeColor = Global.System.Drawing.Color.White
			Me.btnTerminate.Location = New Global.System.Drawing.Point(604, 308)
			Me.btnTerminate.Name = "btnTerminate"
			Me.btnTerminate.Size = New Global.System.Drawing.Size(62, 26)
			Me.btnTerminate.TabIndex = 51
			Me.btnTerminate.TabStop = False
			Me.btnTerminate.Text = "Terminate"
			Me.btnTerminate.UseVisualStyleBackColor = True
			Me.btnTerminate.Visible = False
			Me.Panel6.BackColor = Global.System.Drawing.Color.White
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.LinkLabel1)
			Me.Panel6.Controls.Add(Me.Panel1)
			Me.Panel6.Controls.Add(Me.btnInitialize)
			Me.Panel6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel6.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(752, 580)
			Me.Panel6.TabIndex = 0
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(603, 318)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(125, 13)
			Me.LinkLabel1.TabIndex = 405
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Download Chrome Driver"
			Me.LinkLabel1.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(751, 298)
			Me.Panel1.TabIndex = 3
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.Button2)
			Me.Panel5.Controls.Add(Me.Button3)
			Me.Panel5.Controls.Add(Me.Button4)
			Me.Panel5.Controls.Add(Me.Button5)
			Me.Panel5.Location = New Global.System.Drawing.Point(635, 35)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(105, 179)
			Me.Panel5.TabIndex = 48
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Enabled = False
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(6, 134)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button2.TabIndex = 3
			Me.Button2.Text = "&Delete"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.Enabled = False
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(6, 92)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button3.TabIndex = 2
			Me.Button3.Text = "&Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(6, 50)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button4.TabIndex = 1
			Me.Button4.Text = "&Save"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button5.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(6, 8)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button5.TabIndex = 0
			Me.Button5.Text = "&New"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(5, 248)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DeepPink
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(719, 63)
			Me.dgw.TabIndex = 41
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "Country Code of WhatsApp"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column3.HeaderText = "WhatsApp API Status"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(754, 582)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmWAppAPIServer"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel9.ResumeLayout(False)
			CType(Me.imgBarcode, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel8.ResumeLayout(False)
			Me.Panel7.ResumeLayout(False)
			CType(Me.pBoxAuthQR, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400539F RID: 21407
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
