Namespace BillPoint
	' Token: 0x02000054 RID: 84
		Public Partial Class frmEComSeting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000F74 RID: 3956 RVA: 0x000B86E0 File Offset: 0x000B68E0
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

		' Token: 0x06000F75 RID: 3957 RVA: 0x000B8730 File Offset: 0x000B6930
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEComSeting))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.ImageList1 = New Global.System.Windows.Forms.ImageList(Me.components)
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtFileUrl = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtPassword = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtUserId = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtFtpUrl = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnLogout = New Global.System.Windows.Forms.Button()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel3.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.ImageList1.ColorDepth = Global.System.Windows.Forms.ColorDepth.Depth8Bit
			Me.ImageList1.ImageSize = New Global.System.Drawing.Size(16, 16)
			Me.ImageList1.TransparentColor = Global.System.Drawing.Color.Transparent
			Me.Timer1.Enabled = True
			Me.Timer1.Interval = 1000
			Me.Panel3.BackColor = Global.System.Drawing.Color.White
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.Panel6)
			Me.Panel3.Controls.Add(Me.btnLogout)
			Me.Panel3.Location = New Global.System.Drawing.Point(0, 5)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(754, 335)
			Me.Panel3.TabIndex = 8
			Me.Panel6.BackColor = Global.System.Drawing.Color.White
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.Panel1)
			Me.Panel6.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(752, 334)
			Me.Panel6.TabIndex = 0
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(0, -2)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(751, 331)
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column3, Me.Column5, Me.Column6, Me.Column7, Me.Column8 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(5, 220)
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
			Me.dgw.Size = New Global.System.Drawing.Size(719, 91)
			Me.dgw.TabIndex = 41
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.HeaderText = "Status"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column5.HeaderText = "FTP URL"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "FTP User id"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "FTP Password"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "File Url"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.txtFileUrl)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtPassword)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtUserId)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.txtFtpUrl)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.ComboBox1)
			Me.Panel4.Controls.Add(Me.TextBox2)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 35)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(624, 128)
			Me.Panel4.TabIndex = 0
			Me.txtFileUrl.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFileUrl.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFileUrl.Location = New Global.System.Drawing.Point(79, 87)
			Me.txtFileUrl.Name = "txtFileUrl"
			Me.txtFileUrl.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtFileUrl.Size = New Global.System.Drawing.Size(511, 21)
			Me.txtFileUrl.TabIndex = 425
			Me.txtFileUrl.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtFileUrl.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(4, 87)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label8.TabIndex = 424
			Me.Label8.Text = "File Url :"
			Me.Label8.Visible = False
			Me.txtPassword.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPassword.Location = New Global.System.Drawing.Point(400, 60)
			Me.txtPassword.Name = "txtPassword"
			Me.txtPassword.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtPassword.Size = New Global.System.Drawing.Size(190, 21)
			Me.txtPassword.TabIndex = 423
			Me.txtPassword.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtPassword.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(305, 63)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(70, 15)
			Me.Label7.TabIndex = 422
			Me.Label7.Text = "Password  :"
			Me.Label7.Visible = False
			Me.txtUserId.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUserId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUserId.Location = New Global.System.Drawing.Point(79, 59)
			Me.txtUserId.Name = "txtUserId"
			Me.txtUserId.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtUserId.Size = New Global.System.Drawing.Size(210, 21)
			Me.txtUserId.TabIndex = 421
			Me.txtUserId.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtUserId.Visible = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(4, 59)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(55, 15)
			Me.Label6.TabIndex = 420
			Me.Label6.Text = "User Id  :"
			Me.Label6.Visible = False
			Me.txtFtpUrl.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFtpUrl.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFtpUrl.Location = New Global.System.Drawing.Point(79, 32)
			Me.txtFtpUrl.Name = "txtFtpUrl"
			Me.txtFtpUrl.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtFtpUrl.Size = New Global.System.Drawing.Size(511, 21)
			Me.txtFtpUrl.TabIndex = 419
			Me.txtFtpUrl.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtFtpUrl.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(4, 32)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(54, 15)
			Me.Label5.TabIndex = 418
			Me.Label5.Text = "FTP Url :"
			Me.Label5.Visible = False
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Enabled", "Disabled" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(79, 3)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(181, 23)
			Me.ComboBox1.TabIndex = 2
			Me.TextBox2.Location = New Global.System.Drawing.Point(416, 8)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(13, 21)
			Me.TextBox2.TabIndex = 5
			Me.TextBox2.TabStop = False
			Me.TextBox2.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(5, 6)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(50, 15)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = " Status :"
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
			Me.Label1.Text = "E-Com Configuration"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
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
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(754, 345)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Name = "frmEComSeting"
			Me.Text = "frmEComSeting"
			Me.Panel3.ResumeLayout(False)
			Me.Panel6.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000474 RID: 1140
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
