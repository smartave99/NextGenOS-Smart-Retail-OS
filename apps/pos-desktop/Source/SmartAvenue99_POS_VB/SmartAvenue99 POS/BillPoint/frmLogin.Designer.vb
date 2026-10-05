Namespace BillPoint
	' Token: 0x020005D3 RID: 1491
		Public Partial Class frmLogin
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012389 RID: 74633 RVA: 0x00A7AC0C File Offset: 0x00A78E0C
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

		' Token: 0x06012392 RID: 74642 RVA: 0x00A7AE14 File Offset: 0x00A79014
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLogin))
			Me.UserID = New Global.System.Windows.Forms.TextBox()
			Me.Password = New Global.System.Windows.Forms.TextBox()
			Me.UserType = New Global.System.Windows.Forms.TextBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnHelp = New Global.System.Windows.Forms.Button()
			Me.cmbLang = New Global.System.Windows.Forms.ComboBox()
			Me.chkRememberme = New Global.System.Windows.Forms.CheckBox()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.LabelMsg = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblAttempt = New Global.System.Windows.Forms.Label()
			Me.btnCompany = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.cmbCompany = New Global.System.Windows.Forms.ComboBox()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Cancel = New Global.System.Windows.Forms.Button()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnRecoveryPassword = New Global.System.Windows.Forms.Button()
			Me.btnChangePassword = New Global.System.Windows.Forms.Button()
			Me.btnKeyboard = New Global.System.Windows.Forms.Button()
			Me.OK = New Global.System.Windows.Forms.Button()
			Me.txtDBName = New Global.System.Windows.Forms.TextBox()
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.UserID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.UserID.ForeColor = Global.System.Drawing.Color.Silver
			Me.UserID.Location = New Global.System.Drawing.Point(340, 112)
			Me.UserID.Name = "UserID"
			Me.UserID.Size = New Global.System.Drawing.Size(341, 35)
			Me.UserID.TabIndex = 1
			Me.UserID.Text = "Enter the User Name"
			Me.Password.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Password.ForeColor = Global.System.Drawing.Color.Silver
			Me.Password.Location = New Global.System.Drawing.Point(340, 172)
			Me.Password.Name = "Password"
			Me.Password.PasswordChar = "✹"c
			Me.Password.Size = New Global.System.Drawing.Size(341, 35)
			Me.Password.TabIndex = 2
			Me.Password.Text = "Enter the Password"
			Me.UserType.Location = New Global.System.Drawing.Point(231, 338)
			Me.UserType.Name = "UserType"
			Me.UserType.[ReadOnly] = True
			Me.UserType.Size = New Global.System.Drawing.Size(55, 20)
			Me.UserType.TabIndex = 10
			Me.UserType.TabStop = False
			Me.UserType.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnHelp)
			Me.Panel1.Controls.Add(Me.cmbLang)
			Me.Panel1.Controls.Add(Me.chkRememberme)
			Me.Panel1.Controls.Add(Me.Panel6)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.LabelMsg)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.lblAttempt)
			Me.Panel1.Controls.Add(Me.btnCompany)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.cmbCompany)
			Me.Panel1.Controls.Add(Me.Button5)
			Me.Panel1.Controls.Add(Me.Button4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Cancel)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.btnRecoveryPassword)
			Me.Panel1.Controls.Add(Me.btnChangePassword)
			Me.Panel1.Controls.Add(Me.btnKeyboard)
			Me.Panel1.Controls.Add(Me.UserType)
			Me.Panel1.Controls.Add(Me.UserID)
			Me.Panel1.Controls.Add(Me.Password)
			Me.Panel1.Controls.Add(Me.OK)
			Me.Panel1.Controls.Add(Me.txtDBName)
			Me.Panel1.ForeColor = Global.System.Drawing.Color.White
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(705, 370)
			Me.Panel1.TabIndex = 0
			Me.btnHelp.Location = New Global.System.Drawing.Point(442, 327)
			Me.btnHelp.Name = "btnHelp"
			Me.btnHelp.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnHelp.TabIndex = 102
			Me.btnHelp.Text = "Help"
			Me.btnHelp.UseVisualStyleBackColor = True
			Me.btnHelp.Visible = False
			Me.cmbLang.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbLang.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbLang.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbLang.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.cmbLang.FormattingEnabled = True
			Me.cmbLang.Location = New Global.System.Drawing.Point(550, 14)
			Me.cmbLang.Name = "cmbLang"
			Me.cmbLang.Size = New Global.System.Drawing.Size(131, 32)
			Me.cmbLang.TabIndex = 101
			Me.chkRememberme.AutoSize = True
			Me.chkRememberme.Font = New Global.System.Drawing.Font("MS Outlook", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkRememberme.ForeColor = Global.System.Drawing.Color.Blue
			Me.chkRememberme.Location = New Global.System.Drawing.Point(550, 213)
			Me.chkRememberme.Name = "chkRememberme"
			Me.chkRememberme.Size = New Global.System.Drawing.Size(130, 22)
			Me.chkRememberme.TabIndex = 99
			Me.chkRememberme.Text = "Remember Me"
			Me.chkRememberme.UseVisualStyleBackColor = True
			Me.chkRememberme.Visible = False
			Me.Panel6.BackColor = Global.System.Drawing.Color.White
			Me.Panel6.Location = New Global.System.Drawing.Point(320, 5)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(30, 24)
			Me.Panel6.TabIndex = 98
			Me.Panel5.BackColor = Global.System.Drawing.Color.White
			Me.Panel5.Location = New Global.System.Drawing.Point(309, 13)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(30, 24)
			Me.Panel5.TabIndex = 97
			Me.Panel4.BackColor = Global.System.Drawing.Color.White
			Me.Panel4.Location = New Global.System.Drawing.Point(297, 21)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(30, 24)
			Me.Panel4.TabIndex = 96
			Me.Panel3.BackColor = Global.System.Drawing.Color.White
			Me.Panel3.Location = New Global.System.Drawing.Point(285, 28)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(30, 24)
			Me.Panel3.TabIndex = 95
			Me.LabelMsg.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.LabelMsg.Font = New Global.System.Drawing.Font("Segoe UI", 12F, Global.System.Drawing.FontStyle.Bold Or Global.System.Drawing.FontStyle.Italic, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LabelMsg.ForeColor = Global.System.Drawing.Color.White
			Me.LabelMsg.Location = New Global.System.Drawing.Point(8, 5)
			Me.LabelMsg.Name = "LabelMsg"
			Me.LabelMsg.Size = New Global.System.Drawing.Size(321, 30)
			Me.LabelMsg.TabIndex = 94
			Me.LabelMsg.Text = "LabelMsg"
			Me.LabelMsg.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label1.Location = New Global.System.Drawing.Point(6, 303)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(293, 29)
			Me.Label1.TabIndex = 93
			Me.Label1.Text = "NextGen OS"
			Me.lblAttempt.AutoSize = True
			Me.lblAttempt.BackColor = Global.System.Drawing.Color.White
			Me.lblAttempt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblAttempt.ForeColor = Global.System.Drawing.Color.Maroon
			Me.lblAttempt.Location = New Global.System.Drawing.Point(337, 315)
			Me.lblAttempt.Name = "lblAttempt"
			Me.lblAttempt.Size = New Global.System.Drawing.Size(19, 16)
			Me.lblAttempt.TabIndex = 92
			Me.lblAttempt.Text = "...."
			Me.btnCompany.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCompany.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnCompany.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCompany.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnCompany.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnCompany.FlatAppearance.BorderSize = 0
			Me.btnCompany.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnCompany.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCompany.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnCompany.Image = CType(componentResourceManager.GetObject("btnCompany.Image"), Global.System.Drawing.Image)
			Me.btnCompany.Location = New Global.System.Drawing.Point(523, 310)
			Me.btnCompany.Name = "btnCompany"
			Me.btnCompany.Size = New Global.System.Drawing.Size(40, 40)
			Me.btnCompany.TabIndex = 5
			Me.btnCompany.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCompany.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label5.Location = New Global.System.Drawing.Point(335, 31)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(134, 21)
			Me.Label5.TabIndex = 90
			Me.Label5.Text = "Company Name :"
			Me.cmbCompany.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbCompany.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCompany.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbCompany.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.cmbCompany.FormattingEnabled = True
			Me.cmbCompany.Location = New Global.System.Drawing.Point(339, 55)
			Me.cmbCompany.Name = "cmbCompany"
			Me.cmbCompany.Size = New Global.System.Drawing.Size(341, 33)
			Me.cmbCompany.TabIndex = 0
			Me.Button5.BackColor = Global.System.Drawing.Color.White
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.Location = New Global.System.Drawing.Point(633, 173)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(47, 31)
			Me.Button5.TabIndex = 85
			Me.Button5.TabStop = False
			Me.Button5.UseVisualStyleBackColor = False
			Me.Button4.BackColor = Global.System.Drawing.Color.White
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.Location = New Global.System.Drawing.Point(633, 173)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(47, 31)
			Me.Button4.TabIndex = 84
			Me.Button4.TabStop = False
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button4.Visible = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Panel2.BackgroundImage = Nothing
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.PictureBox1)
			Me.Panel2.Location = New Global.System.Drawing.Point(36, 38)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(254, 259)
			Me.Panel2.TabIndex = 68
			Me.PictureBox1.ErrorImage = Nothing
			Me.PictureBox1.Image = Nothing
			Me.PictureBox1.Location = New Global.System.Drawing.Point(161, 175)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(94, 81)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 31
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
			Me.Cancel.BackColor = Global.System.Drawing.Color.Transparent
			Me.Cancel.BackgroundImage = CType(componentResourceManager.GetObject("Cancel.BackgroundImage"), Global.System.Drawing.Image)
			Me.Cancel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Cancel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Cancel.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.Cancel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Cancel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Cancel.ForeColor = Global.System.Drawing.Color.White
			Me.Cancel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Cancel.Location = New Global.System.Drawing.Point(512, 232)
			Me.Cancel.Name = "Cancel"
			Me.Cancel.Size = New Global.System.Drawing.Size(169, 65)
			Me.Cancel.TabIndex = 4
			Me.Cancel.Text = "                                                                        &E"
			Me.Cancel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Cancel.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label3.Location = New Global.System.Drawing.Point(335, 150)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(87, 21)
			Me.Label3.TabIndex = 63
			Me.Label3.Text = "Password :"
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label2.Location = New Global.System.Drawing.Point(335, 90)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(98, 21)
			Me.Label2.TabIndex = 62
			Me.Label2.Text = "User Name :"
			Me.btnRecoveryPassword.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRecoveryPassword.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnRecoveryPassword.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRecoveryPassword.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnRecoveryPassword.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnRecoveryPassword.FlatAppearance.BorderSize = 0
			Me.btnRecoveryPassword.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnRecoveryPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRecoveryPassword.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnRecoveryPassword.Image = CType(componentResourceManager.GetObject("btnRecoveryPassword.Image"), Global.System.Drawing.Image)
			Me.btnRecoveryPassword.Location = New Global.System.Drawing.Point(611, 310)
			Me.btnRecoveryPassword.Name = "btnRecoveryPassword"
			Me.btnRecoveryPassword.Size = New Global.System.Drawing.Size(40, 40)
			Me.btnRecoveryPassword.TabIndex = 7
			Me.btnRecoveryPassword.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRecoveryPassword.UseVisualStyleBackColor = False
			Me.btnChangePassword.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnChangePassword.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnChangePassword.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnChangePassword.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnChangePassword.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnChangePassword.FlatAppearance.BorderSize = 0
			Me.btnChangePassword.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnChangePassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnChangePassword.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnChangePassword.Image = CType(componentResourceManager.GetObject("btnChangePassword.Image"), Global.System.Drawing.Image)
			Me.btnChangePassword.Location = New Global.System.Drawing.Point(567, 310)
			Me.btnChangePassword.Name = "btnChangePassword"
			Me.btnChangePassword.Size = New Global.System.Drawing.Size(40, 40)
			Me.btnChangePassword.TabIndex = 6
			Me.btnChangePassword.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnChangePassword.UseVisualStyleBackColor = False
			Me.btnKeyboard.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnKeyboard.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnKeyboard.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnKeyboard.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnKeyboard.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnKeyboard.FlatAppearance.BorderSize = 0
			Me.btnKeyboard.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnKeyboard.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnKeyboard.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnKeyboard.Image = CType(componentResourceManager.GetObject("btnKeyboard.Image"), Global.System.Drawing.Image)
			Me.btnKeyboard.Location = New Global.System.Drawing.Point(655, 310)
			Me.btnKeyboard.Name = "btnKeyboard"
			Me.btnKeyboard.Size = New Global.System.Drawing.Size(40, 40)
			Me.btnKeyboard.TabIndex = 8
			Me.btnKeyboard.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnKeyboard.UseVisualStyleBackColor = False
			Me.OK.BackColor = Global.System.Drawing.Color.Transparent
			Me.OK.BackgroundImage = CType(componentResourceManager.GetObject("OK.BackgroundImage"), Global.System.Drawing.Image)
			Me.OK.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.OK.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.OK.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.OK.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.OK.ForeColor = Global.System.Drawing.Color.White
			Me.OK.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.OK.Location = New Global.System.Drawing.Point(340, 232)
			Me.OK.Name = "OK"
			Me.OK.Size = New Global.System.Drawing.Size(169, 65)
			Me.OK.TabIndex = 3
			Me.OK.Text = "                                                                               &L"
			Me.OK.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.OK.UseVisualStyleBackColor = False
			Me.txtDBName.Location = New Global.System.Drawing.Point(173, 338)
			Me.txtDBName.Name = "txtDBName"
			Me.txtDBName.[ReadOnly] = True
			Me.txtDBName.Size = New Global.System.Drawing.Size(52, 20)
			Me.txtDBName.TabIndex = 88
			Me.txtDBName.TabStop = False
			Me.txtDBName.Visible = False
			Me.Timer1.Enabled = True
			MyBase.AcceptButton = Me.OK
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.AutoSize = True
			Me.BackColor = Global.System.Drawing.Color.White
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Center
			MyBase.CancelButton = Me.Cancel
			MyBase.ClientSize = New Global.System.Drawing.Size(705, 371)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmLogin"
			MyBase.ShowInTaskbar = False
			MyBase.SizeGripStyle = Global.System.Windows.Forms.SizeGripStyle.Hide
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Login Form"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006D80 RID: 28032
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
