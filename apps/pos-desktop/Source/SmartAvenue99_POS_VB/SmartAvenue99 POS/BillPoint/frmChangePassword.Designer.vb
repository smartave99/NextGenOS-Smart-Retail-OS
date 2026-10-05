Namespace BillPoint
	' Token: 0x020005E0 RID: 1504
		Public Partial Class frmChangePassword
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060127AB RID: 75691 RVA: 0x00AA2F58 File Offset: 0x00AA1158
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

		' Token: 0x060127AC RID: 75692 RVA: 0x00AA2FA8 File Offset: 0x00AA11A8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmChangePassword))
			Me.UserID = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ConfirmPassword = New Global.System.Windows.Forms.TextBox()
			Me.NewPassword = New Global.System.Windows.Forms.TextBox()
			Me.OldPassword = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnKeyboard = New Global.System.Windows.Forms.Button()
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel2.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.UserID.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Lower
			Me.UserID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.UserID.ForeColor = Global.System.Drawing.Color.DarkViolet
			Me.UserID.Location = New Global.System.Drawing.Point(192, 21)
			Me.UserID.Name = "UserID"
			Me.UserID.Size = New Global.System.Drawing.Size(200, 29)
			Me.UserID.TabIndex = 10
			Me.Label4.AutoSize = True
			Me.Label4.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.Label4.Location = New Global.System.Drawing.Point(19, 21)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(81, 24)
			Me.Label4.TabIndex = 17
			Me.Label4.Text = "User ID :"
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.Label3.Location = New Global.System.Drawing.Point(19, 117)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(172, 24)
			Me.Label3.TabIndex = 16
			Me.Label3.Text = "Confirm Password :"
			Me.ConfirmPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ConfirmPassword.ForeColor = Global.System.Drawing.Color.DarkViolet
			Me.ConfirmPassword.Location = New Global.System.Drawing.Point(192, 117)
			Me.ConfirmPassword.Name = "ConfirmPassword"
			Me.ConfirmPassword.PasswordChar = "•"c
			Me.ConfirmPassword.Size = New Global.System.Drawing.Size(200, 29)
			Me.ConfirmPassword.TabIndex = 14
			Me.NewPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.NewPassword.ForeColor = Global.System.Drawing.Color.DarkViolet
			Me.NewPassword.Location = New Global.System.Drawing.Point(192, 85)
			Me.NewPassword.Name = "NewPassword"
			Me.NewPassword.PasswordChar = "•"c
			Me.NewPassword.Size = New Global.System.Drawing.Size(200, 29)
			Me.NewPassword.TabIndex = 13
			Me.OldPassword.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.OldPassword.ForeColor = Global.System.Drawing.Color.DarkViolet
			Me.OldPassword.Location = New Global.System.Drawing.Point(192, 53)
			Me.OldPassword.Name = "OldPassword"
			Me.OldPassword.PasswordChar = "•"c
			Me.OldPassword.Size = New Global.System.Drawing.Size(200, 29)
			Me.OldPassword.TabIndex = 11
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.Label2.Location = New Global.System.Drawing.Point(19, 85)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(146, 24)
			Me.Label2.TabIndex = 12
			Me.Label2.Text = "New Password :"
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.Label1.Location = New Global.System.Drawing.Point(19, 53)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(137, 24)
			Me.Label1.TabIndex = 9
			Me.Label1.Text = "Old Password :"
			Me.btnKeyboard.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnKeyboard.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnKeyboard.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnKeyboard.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnKeyboard.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnKeyboard.FlatAppearance.BorderSize = 0
			Me.btnKeyboard.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnKeyboard.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnKeyboard.ForeColor = Global.System.Drawing.Color.Black
			Me.btnKeyboard.Image = CType(componentResourceManager.GetObject("btnKeyboard.Image"), Global.System.Drawing.Image)
			Me.btnKeyboard.Location = New Global.System.Drawing.Point(273, 302)
			Me.btnKeyboard.Name = "btnKeyboard"
			Me.btnKeyboard.Size = New Global.System.Drawing.Size(58, 57)
			Me.btnKeyboard.TabIndex = 59
			Me.btnKeyboard.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnKeyboard.UseVisualStyleBackColor = False
			Me.btnCancel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCancel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnCancel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCancel.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.FlatAppearance.BorderSize = 0
			Me.btnCancel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnCancel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCancel.Image = Global.BillPoint.My.Resources.Resources.Button_Delete_icon1
			Me.btnCancel.Location = New Global.System.Drawing.Point(337, 302)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Global.System.Drawing.Size(58, 57)
			Me.btnCancel.TabIndex = 60
			Me.btnCancel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCancel.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(239, 169)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(153, 57)
			Me.Button1.TabIndex = 15
			Me.Button1.Text = "             &Change Password"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label5.BackColor = Global.System.Drawing.Color.Orange
			Me.Label5.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 20.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(435, 50)
			Me.Label5.TabIndex = 19
			Me.Label5.Text = "Change Password Form"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel2.BackColor = Global.System.Drawing.Color.White
			Me.Panel2.Controls.Add(Me.PictureBox1)
			Me.Panel2.Controls.Add(Me.btnKeyboard)
			Me.Panel2.Controls.Add(Me.btnCancel)
			Me.Panel2.Controls.Add(Me.Button1)
			Me.Panel2.Controls.Add(Me.ConfirmPassword)
			Me.Panel2.Controls.Add(Me.OldPassword)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.UserID)
			Me.Panel2.Controls.Add(Me.NewPassword)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.Label2)
			Me.Panel2.Controls.Add(Me.Label4)
			Me.Panel2.Location = New Global.System.Drawing.Point(7, 58)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(421, 370)
			Me.Panel2.TabIndex = 20
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(4, 232)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(263, 135)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 62
			Me.PictureBox1.TabStop = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AcceptButton = Me.Button1
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			MyBase.ClientSize = New Global.System.Drawing.Size(435, 434)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.Label5)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmChangePassword"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Change Password"
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006F30 RID: 28464
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
