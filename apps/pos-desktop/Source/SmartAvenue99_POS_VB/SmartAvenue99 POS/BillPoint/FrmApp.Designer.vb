Namespace BillPoint
	' Token: 0x0200006A RID: 106
		Public Partial Class FrmApp
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600136C RID: 4972 RVA: 0x000D3718 File Offset: 0x000D1918
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

		' Token: 0x0600136D RID: 4973 RVA: 0x000D3768 File Offset: 0x000D1968
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.FrmApp))
			Me.Status = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Attach = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Message = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Phone = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.columnSelection = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.dgv = New Global.System.Windows.Forms.DataGridView()
			Me.columnBrowse = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.btnSendBulk = New Global.System.Windows.Forms.Button()
			Me.lblDelay = New Global.System.Windows.Forms.Label()
			Me.numDelay = New Global.System.Windows.Forms.NumericUpDown()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.panel2 = New Global.System.Windows.Forms.Panel()
			Me.tabBulk = New Global.System.Windows.Forms.TabPage()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.panelSend = New Global.System.Windows.Forms.Panel()
			Me.btnSend = New Global.System.Windows.Forms.Button()
			Me.btnAttachBrowse = New Global.System.Windows.Forms.Button()
			Me.tBoxAttach = New Global.System.Windows.Forms.TextBox()
			Me.label3 = New Global.System.Windows.Forms.Label()
			Me.tBoxMessage = New Global.System.Windows.Forms.TextBox()
			Me.label2 = New Global.System.Windows.Forms.Label()
			Me.tBoxPhone = New Global.System.Windows.Forms.TextBox()
			Me.label1 = New Global.System.Windows.Forms.Label()
			Me.label4 = New Global.System.Windows.Forms.Label()
			Me.timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.openAttach = New Global.System.Windows.Forms.OpenFileDialog()
			Me.btnLogout = New Global.System.Windows.Forms.Button()
			Me.flowLayoutPanel1 = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.LblSenderId = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.chkBoxHeadLess = New Global.System.Windows.Forms.CheckBox()
			Me.panel6 = New Global.System.Windows.Forms.Panel()
			Me.lblWhatsAppState = New Global.System.Windows.Forms.Label()
			Me.btnTerminate = New Global.System.Windows.Forms.Button()
			Me.btnInitialize = New Global.System.Windows.Forms.Button()
			Me.tabIndividual = New Global.System.Windows.Forms.TabPage()
			Me.panelAuth = New Global.System.Windows.Forms.Panel()
			Me.pBoxAuthQR = New Global.System.Windows.Forms.PictureBox()
			Me.statusRetriever = New Global.System.Windows.Forms.Timer(Me.components)
			Me.tabControlSender = New Global.System.Windows.Forms.TabControl()
			CType(Me.dgv, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.numDelay, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panel2.SuspendLayout()
			Me.tabBulk.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelSend.SuspendLayout()
			Me.flowLayoutPanel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.panel6.SuspendLayout()
			Me.tabIndividual.SuspendLayout()
			Me.panelAuth.SuspendLayout()
			CType(Me.pBoxAuthQR, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.tabControlSender.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Status.FillWeight = 21.69692F
			Me.Status.HeaderText = "Status"
			Me.Status.MinimumWidth = 6
			Me.Status.Name = "Status"
			Me.Status.[ReadOnly] = True
			Me.Attach.FillWeight = 14.45557F
			Me.Attach.HeaderText = "Attach"
			Me.Attach.MinimumWidth = 6
			Me.Attach.Name = "Attach"
			Me.Attach.[ReadOnly] = True
			Me.Message.FillWeight = 21.69692F
			Me.Message.HeaderText = "Message"
			Me.Message.MinimumWidth = 6
			Me.Message.Name = "Message"
			Me.Phone.FillWeight = 21.69692F
			Me.Phone.HeaderText = "Phone"
			Me.Phone.MinimumWidth = 6
			Me.Phone.Name = "Phone"
			Me.columnSelection.FillWeight = 12.24653F
			Me.columnSelection.HeaderText = "Mark"
			Me.columnSelection.MinimumWidth = 6
			Me.columnSelection.Name = "columnSelection"
			Me.dgv.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgv.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgv.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.columnSelection, Me.Phone, Me.Message, Me.Attach, Me.columnBrowse, Me.Status })
			Me.dgv.Location = New Global.System.Drawing.Point(0, 0)
			Me.dgv.Name = "dgv"
			Me.dgv.RowHeadersWidth = 51
			Me.dgv.Size = New Global.System.Drawing.Size(504, 163)
			Me.dgv.TabIndex = 3
			Me.columnBrowse.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			Me.columnBrowse.DefaultCellStyle = dataGridViewCellStyle
			Me.columnBrowse.FillWeight = 50F
			Me.columnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.columnBrowse.HeaderText = "Browse"
			Me.columnBrowse.MinimumWidth = 6
			Me.columnBrowse.Name = "columnBrowse"
			Me.columnBrowse.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.columnBrowse.Text = "Browse"
			Me.columnBrowse.UseColumnTextForButtonValue = True
			Me.columnBrowse.Width = 70
			Me.btnSendBulk.BackgroundImage = CType(componentResourceManager.GetObject("btnSendBulk.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnSendBulk.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSendBulk.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSendBulk.Dock = Global.System.Windows.Forms.DockStyle.Right
			Me.btnSendBulk.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 8.25F)
			Me.btnSendBulk.ForeColor = Global.System.Drawing.Color.White
			Me.btnSendBulk.Image = CType(componentResourceManager.GetObject("btnSendBulk.Image"), Global.System.Drawing.Image)
			Me.btnSendBulk.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSendBulk.Location = New Global.System.Drawing.Point(404, 0)
			Me.btnSendBulk.Name = "btnSendBulk"
			Me.btnSendBulk.Size = New Global.System.Drawing.Size(101, 40)
			Me.btnSendBulk.TabIndex = 0
			Me.btnSendBulk.Text = "Send Now"
			Me.btnSendBulk.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSendBulk.UseVisualStyleBackColor = True
			Me.lblDelay.AutoSize = True
			Me.lblDelay.Location = New Global.System.Drawing.Point(147, 183)
			Me.lblDelay.Name = "lblDelay"
			Me.lblDelay.Size = New Global.System.Drawing.Size(94, 13)
			Me.lblDelay.TabIndex = 2
			Me.lblDelay.Text = "Delay (in seconds)"
			Me.numDelay.Location = New Global.System.Drawing.Point(247, 181)
			Dim numDelay As Global.System.Windows.Forms.NumericUpDown = Me.numDelay
			Dim array As Integer() = New Integer(3) {}
			array(0) = 5
			numDelay.Minimum = New Decimal(array)
			Me.numDelay.Name = "numDelay"
			Me.numDelay.Size = New Global.System.Drawing.Size(45, 20)
			Me.numDelay.TabIndex = 1
			Me.numDelay.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Dim numDelay2 As Global.System.Windows.Forms.NumericUpDown = Me.numDelay
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 5
			numDelay2.Value = New Decimal(array2)
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Location = New Global.System.Drawing.Point(6, 182)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(118, 17)
			Me.CheckBox1.TabIndex = 3
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "(Mark / Unmark) All"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.panel2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.panel2.Controls.Add(Me.btnSendBulk)
			Me.panel2.Location = New Global.System.Drawing.Point(0, 169)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New Global.System.Drawing.Size(505, 40)
			Me.panel2.TabIndex = 4
			Me.tabBulk.Controls.Add(Me.lblDelay)
			Me.tabBulk.Controls.Add(Me.numDelay)
			Me.tabBulk.Controls.Add(Me.CheckBox1)
			Me.tabBulk.Controls.Add(Me.panel2)
			Me.tabBulk.Controls.Add(Me.dgv)
			Me.tabBulk.Location = New Global.System.Drawing.Point(4, 22)
			Me.tabBulk.Name = "tabBulk"
			Me.tabBulk.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.tabBulk.Size = New Global.System.Drawing.Size(505, 209)
			Me.tabBulk.TabIndex = 1
			Me.tabBulk.Text = "Bulk"
			Me.tabBulk.UseVisualStyleBackColor = True
			Me.PictureBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(3, 139)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(62, 61)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 22
			Me.PictureBox1.TabStop = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.ForestGreen
			Me.Button1.BackgroundImage = CType(componentResourceManager.GetObject("Button1.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(213, 146)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(129, 50)
			Me.Button1.TabIndex = 4
			Me.Button1.Text = "Send Report"
			Me.Button1.UseVisualStyleBackColor = False
			Me.panelSend.BackColor = Global.System.Drawing.Color.White
			Me.panelSend.Controls.Add(Me.PictureBox1)
			Me.panelSend.Controls.Add(Me.Button1)
			Me.panelSend.Controls.Add(Me.btnSend)
			Me.panelSend.Controls.Add(Me.btnAttachBrowse)
			Me.panelSend.Controls.Add(Me.tBoxAttach)
			Me.panelSend.Controls.Add(Me.label3)
			Me.panelSend.Controls.Add(Me.tBoxMessage)
			Me.panelSend.Controls.Add(Me.label2)
			Me.panelSend.Controls.Add(Me.tBoxPhone)
			Me.panelSend.Controls.Add(Me.label1)
			Me.panelSend.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.panelSend.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.panelSend.Location = New Global.System.Drawing.Point(3, 3)
			Me.panelSend.Name = "panelSend"
			Me.panelSend.Size = New Global.System.Drawing.Size(499, 203)
			Me.panelSend.TabIndex = 26
			Me.btnSend.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSend.BackColor = Global.System.Drawing.Color.ForestGreen
			Me.btnSend.BackgroundImage = CType(componentResourceManager.GetObject("btnSend.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnSend.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSend.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSend.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSend.ForeColor = Global.System.Drawing.Color.White
			Me.btnSend.Image = CType(componentResourceManager.GetObject("btnSend.Image"), Global.System.Drawing.Image)
			Me.btnSend.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSend.Location = New Global.System.Drawing.Point(360, 146)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New Global.System.Drawing.Size(129, 50)
			Me.btnSend.TabIndex = 3
			Me.btnSend.Text = "Send"
			Me.btnSend.UseVisualStyleBackColor = False
			Me.btnAttachBrowse.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnAttachBrowse.BackColor = Global.System.Drawing.Color.Cyan
			Me.btnAttachBrowse.BackgroundImage = CType(componentResourceManager.GetObject("btnAttachBrowse.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnAttachBrowse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAttachBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAttachBrowse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAttachBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnAttachBrowse.Location = New Global.System.Drawing.Point(400, 117)
			Me.btnAttachBrowse.Name = "btnAttachBrowse"
			Me.btnAttachBrowse.Size = New Global.System.Drawing.Size(89, 26)
			Me.btnAttachBrowse.TabIndex = 2
			Me.btnAttachBrowse.Text = "Browse"
			Me.btnAttachBrowse.UseVisualStyleBackColor = False
			Me.tBoxAttach.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.tBoxAttach.BackColor = Global.System.Drawing.Color.FromArgb(64, 64, 64)
			Me.tBoxAttach.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.tBoxAttach.ForeColor = Global.System.Drawing.Color.White
			Me.tBoxAttach.Location = New Global.System.Drawing.Point(74, 120)
			Me.tBoxAttach.Name = "tBoxAttach"
			Me.tBoxAttach.Size = New Global.System.Drawing.Size(320, 20)
			Me.tBoxAttach.TabIndex = 21
			Me.tBoxAttach.TabStop = False
			Me.label3.AutoSize = True
			Me.label3.Location = New Global.System.Drawing.Point(10, 123)
			Me.label3.Name = "label3"
			Me.label3.Size = New Global.System.Drawing.Size(38, 13)
			Me.label3.TabIndex = 20
			Me.label3.Text = "Attach"
			Me.tBoxMessage.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.tBoxMessage.BackColor = Global.System.Drawing.SystemColors.Info
			Me.tBoxMessage.Location = New Global.System.Drawing.Point(74, 37)
			Me.tBoxMessage.Multiline = True
			Me.tBoxMessage.Name = "tBoxMessage"
			Me.tBoxMessage.Size = New Global.System.Drawing.Size(415, 76)
			Me.tBoxMessage.TabIndex = 1
			Me.label2.AutoSize = True
			Me.label2.Location = New Global.System.Drawing.Point(10, 40)
			Me.label2.Name = "label2"
			Me.label2.Size = New Global.System.Drawing.Size(50, 13)
			Me.label2.TabIndex = 18
			Me.label2.Text = "Message"
			Me.tBoxPhone.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.tBoxPhone.BackColor = Global.System.Drawing.SystemColors.Info
			Me.tBoxPhone.Location = New Global.System.Drawing.Point(74, 11)
			Me.tBoxPhone.Name = "tBoxPhone"
			Me.tBoxPhone.Size = New Global.System.Drawing.Size(202, 20)
			Me.tBoxPhone.TabIndex = 0
			Me.label1.AutoSize = True
			Me.label1.Location = New Global.System.Drawing.Point(10, 14)
			Me.label1.Name = "label1"
			Me.label1.Size = New Global.System.Drawing.Size(38, 13)
			Me.label1.TabIndex = 16
			Me.label1.Text = "Phone"
			Me.label4.AutoSize = True
			Me.label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.label4.ForeColor = Global.System.Drawing.Color.Blue
			Me.label4.Location = New Global.System.Drawing.Point(52, 205)
			Me.label4.Name = "label4"
			Me.label4.Size = New Global.System.Drawing.Size(84, 20)
			Me.label4.TabIndex = 8
			Me.label4.Text = "Scan Me!"
			Me.timer1.Enabled = True
			Me.timer1.Interval = 1000
			Me.openAttach.DefaultExt = "*"
			Me.btnLogout.BackColor = Global.System.Drawing.Color.Red
			Me.btnLogout.BackgroundImage = CType(componentResourceManager.GetObject("btnLogout.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnLogout.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnLogout.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLogout.Dock = Global.System.Windows.Forms.DockStyle.Right
			Me.btnLogout.Enabled = False
			Me.btnLogout.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnLogout.ForeColor = Global.System.Drawing.Color.White
			Me.btnLogout.Location = New Global.System.Drawing.Point(411, 0)
			Me.btnLogout.Name = "btnLogout"
			Me.btnLogout.Size = New Global.System.Drawing.Size(51, 34)
			Me.btnLogout.TabIndex = 8
			Me.btnLogout.TabStop = False
			Me.btnLogout.Text = "Logout"
			Me.btnLogout.UseVisualStyleBackColor = False
			Me.flowLayoutPanel1.BackColor = Global.System.Drawing.Color.Transparent
			Me.flowLayoutPanel1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.flowLayoutPanel1.Controls.Add(Me.LblSenderId)
			Me.flowLayoutPanel1.FlowDirection = Global.System.Windows.Forms.FlowDirection.RightToLeft
			Me.flowLayoutPanel1.Location = New Global.System.Drawing.Point(171, 2)
			Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
			Me.flowLayoutPanel1.Size = New Global.System.Drawing.Size(238, 28)
			Me.flowLayoutPanel1.TabIndex = 1
			Me.LblSenderId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblSenderId.ForeColor = Global.System.Drawing.Color.White
			Me.LblSenderId.Location = New Global.System.Drawing.Point(34, 3)
			Me.LblSenderId.Margin = New Global.System.Windows.Forms.Padding(3)
			Me.LblSenderId.Name = "LblSenderId"
			Me.LblSenderId.Size = New Global.System.Drawing.Size(201, 20)
			Me.LblSenderId.TabIndex = 0
			Me.LblSenderId.Text = "Sender Id: Unavailable"
			Me.LblSenderId.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Panel4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel4.BackgroundImage = CType(componentResourceManager.GetObject("Panel4.BackgroundImage"), Global.System.Drawing.Image)
			Me.Panel4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel4.Controls.Add(Me.chkBoxHeadLess)
			Me.Panel4.Controls.Add(Me.panel6)
			Me.Panel4.Controls.Add(Me.btnTerminate)
			Me.Panel4.Controls.Add(Me.btnInitialize)
			Me.Panel4.Location = New Global.System.Drawing.Point(11, 13)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(720, 40)
			Me.Panel4.TabIndex = 33
			Me.chkBoxHeadLess.AutoSize = True
			Me.chkBoxHeadLess.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkBoxHeadLess.Checked = True
			Me.chkBoxHeadLess.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkBoxHeadLess.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkBoxHeadLess.Enabled = False
			Me.chkBoxHeadLess.ForeColor = Global.System.Drawing.Color.White
			Me.chkBoxHeadLess.Location = New Global.System.Drawing.Point(180, 12)
			Me.chkBoxHeadLess.Name = "chkBoxHeadLess"
			Me.chkBoxHeadLess.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkBoxHeadLess.TabIndex = 6
			Me.chkBoxHeadLess.TabStop = False
			Me.chkBoxHeadLess.Text = "Headless"
			Me.chkBoxHeadLess.UseVisualStyleBackColor = False
			Me.panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.panel6.BackColor = Global.System.Drawing.Color.Transparent
			Me.panel6.Controls.Add(Me.btnLogout)
			Me.panel6.Controls.Add(Me.flowLayoutPanel1)
			Me.panel6.Controls.Add(Me.lblWhatsAppState)
			Me.panel6.Location = New Global.System.Drawing.Point(255, 3)
			Me.panel6.Name = "panel6"
			Me.panel6.Size = New Global.System.Drawing.Size(462, 34)
			Me.panel6.TabIndex = 5
			Me.lblWhatsAppState.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblWhatsAppState.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblWhatsAppState.ForeColor = Global.System.Drawing.Color.White
			Me.lblWhatsAppState.Location = New Global.System.Drawing.Point(3, 2)
			Me.lblWhatsAppState.Margin = New Global.System.Windows.Forms.Padding(3)
			Me.lblWhatsAppState.Name = "lblWhatsAppState"
			Me.lblWhatsAppState.Size = New Global.System.Drawing.Size(163, 28)
			Me.lblWhatsAppState.TabIndex = 0
			Me.lblWhatsAppState.Text = "Engine: Not Ready"
			Me.lblWhatsAppState.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnTerminate.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			Me.btnTerminate.BackgroundImage = CType(componentResourceManager.GetObject("btnTerminate.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnTerminate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnTerminate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnTerminate.Enabled = False
			Me.btnTerminate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTerminate.ForeColor = Global.System.Drawing.Color.White
			Me.btnTerminate.Location = New Global.System.Drawing.Point(100, 3)
			Me.btnTerminate.Name = "btnTerminate"
			Me.btnTerminate.Size = New Global.System.Drawing.Size(74, 34)
			Me.btnTerminate.TabIndex = 3
			Me.btnTerminate.TabStop = False
			Me.btnTerminate.Text = "Terminate"
			Me.btnTerminate.UseVisualStyleBackColor = False
			Me.btnInitialize.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.btnInitialize.BackgroundImage = CType(componentResourceManager.GetObject("btnInitialize.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnInitialize.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnInitialize.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnInitialize.Enabled = False
			Me.btnInitialize.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnInitialize.ForeColor = Global.System.Drawing.Color.White
			Me.btnInitialize.Location = New Global.System.Drawing.Point(23, 3)
			Me.btnInitialize.Name = "btnInitialize"
			Me.btnInitialize.Size = New Global.System.Drawing.Size(74, 34)
			Me.btnInitialize.TabIndex = 1
			Me.btnInitialize.TabStop = False
			Me.btnInitialize.Text = "Initialize"
			Me.btnInitialize.UseVisualStyleBackColor = False
			Me.tabIndividual.Controls.Add(Me.panelSend)
			Me.tabIndividual.Location = New Global.System.Drawing.Point(4, 22)
			Me.tabIndividual.Name = "tabIndividual"
			Me.tabIndividual.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.tabIndividual.Size = New Global.System.Drawing.Size(505, 209)
			Me.tabIndividual.TabIndex = 0
			Me.tabIndividual.Text = "Individual"
			Me.tabIndividual.UseVisualStyleBackColor = True
			Me.panelAuth.BackColor = Global.System.Drawing.Color.White
			Me.panelAuth.Controls.Add(Me.pBoxAuthQR)
			Me.panelAuth.Controls.Add(Me.label4)
			Me.panelAuth.Enabled = False
			Me.panelAuth.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.panelAuth.Location = New Global.System.Drawing.Point(11, 59)
			Me.panelAuth.Name = "panelAuth"
			Me.panelAuth.Size = New Global.System.Drawing.Size(200, 235)
			Me.panelAuth.TabIndex = 32
			Me.pBoxAuthQR.BackColor = Global.System.Drawing.Color.White
			Me.pBoxAuthQR.Location = New Global.System.Drawing.Point(14, 13)
			Me.pBoxAuthQR.Name = "pBoxAuthQR"
			Me.pBoxAuthQR.Size = New Global.System.Drawing.Size(172, 172)
			Me.pBoxAuthQR.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pBoxAuthQR.TabIndex = 9
			Me.pBoxAuthQR.TabStop = False
			Me.statusRetriever.Enabled = True
			Me.statusRetriever.Interval = 1000
			Me.tabControlSender.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.tabControlSender.Controls.Add(Me.tabIndividual)
			Me.tabControlSender.Controls.Add(Me.tabBulk)
			Me.tabControlSender.Enabled = False
			Me.tabControlSender.Location = New Global.System.Drawing.Point(217, 59)
			Me.tabControlSender.Name = "tabControlSender"
			Me.tabControlSender.SelectedIndex = 0
			Me.tabControlSender.Size = New Global.System.Drawing.Size(513, 235)
			Me.tabControlSender.TabIndex = 34
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.NavajoWhite
			Me.BackgroundImage = CType(componentResourceManager.GetObject("$this.BackgroundImage"), Global.System.Drawing.Image)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(742, 306)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.panelAuth)
			MyBase.Controls.Add(Me.tabControlSender)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "FrmApp"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Auto WhatsApp Launcher (Rel. 17)"
			CType(Me.dgv, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.numDelay, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.panel2.ResumeLayout(False)
			Me.tabBulk.ResumeLayout(False)
			Me.tabBulk.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelSend.ResumeLayout(False)
			Me.panelSend.PerformLayout()
			Me.flowLayoutPanel1.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.panel6.ResumeLayout(False)
			Me.tabIndividual.ResumeLayout(False)
			Me.panelAuth.ResumeLayout(False)
			Me.panelAuth.PerformLayout()
			CType(Me.pBoxAuthQR, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.tabControlSender.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000644 RID: 1604
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
