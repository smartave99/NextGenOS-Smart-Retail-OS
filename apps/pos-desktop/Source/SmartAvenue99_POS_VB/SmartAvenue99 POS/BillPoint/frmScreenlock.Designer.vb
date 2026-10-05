Namespace BillPoint
	' Token: 0x020004D9 RID: 1241
		Public Partial Class frmScreenlock
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FCB6 RID: 64694 RVA: 0x00973190 File Offset: 0x00971390
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

		' Token: 0x0600FCB7 RID: 64695 RVA: 0x009731E0 File Offset: 0x009713E0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmScreenlock))
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.UserType = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtuser = New Global.System.Windows.Forms.TextBox()
			Me.UsernameLabel = New Global.System.Windows.Forms.Label()
			Me.PasswordLabel = New Global.System.Windows.Forms.Label()
			Me.Btnshow = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.LogoPictureBox = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2.SuspendLayout()
			CType(Me.LogoPictureBox, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Button5)
			Me.Panel2.Controls.Add(Me.Button2)
			Me.Panel2.Controls.Add(Me.Button4)
			Me.Panel2.Controls.Add(Me.Button3)
			Me.Panel2.Controls.Add(Me.UserType)
			Me.Panel2.Controls.Add(Me.Label2)
			Me.Panel2.Controls.Add(Me.txtuser)
			Me.Panel2.Controls.Add(Me.UsernameLabel)
			Me.Panel2.Controls.Add(Me.PasswordLabel)
			Me.Panel2.Controls.Add(Me.Btnshow)
			Me.Panel2.Controls.Add(Me.Button1)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.LogoPictureBox)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel2.ForeColor = Global.System.Drawing.Color.White
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(442, 245)
			Me.Panel2.TabIndex = 64
			Me.Button5.BackColor = Global.System.Drawing.Color.White
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.Location = New Global.System.Drawing.Point(371, 133)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(47, 26)
			Me.Button5.TabIndex = 86
			Me.Button5.TabStop = False
			Me.Button5.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.White
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(371, 133)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(47, 26)
			Me.Button2.TabIndex = 85
			Me.Button2.TabStop = False
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button2.Visible = False
			Me.Button4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.BackgroundImage = CType(componentResourceManager.GetObject("Button4.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button4.Location = New Global.System.Drawing.Point(180, 177)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(83, 57)
			Me.Button4.TabIndex = 84
			Me.Button4.Text = "                                               &Keyboard"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button3.Location = New Global.System.Drawing.Point(348, 177)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(78, 57)
			Me.Button3.TabIndex = 83
			Me.Button3.Text = "                                                              &Exit"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button3.UseVisualStyleBackColor = False
			Me.UserType.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.UserType.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.UserType.Location = New Global.System.Drawing.Point(342, 30)
			Me.UserType.Name = "UserType"
			Me.UserType.[ReadOnly] = True
			Me.UserType.Size = New Global.System.Drawing.Size(67, 22)
			Me.UserType.TabIndex = 81
			Me.UserType.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.UserType.Visible = False
			Me.Label2.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label2.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label2.Font = New Global.System.Drawing.Font("Arial", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(440, 27)
			Me.Label2.TabIndex = 66
			Me.Label2.Text = "Screen Locked"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtuser.Font = New Global.System.Drawing.Font("Arial", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtuser.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.txtuser.Location = New Global.System.Drawing.Point(172, 61)
			Me.txtuser.Name = "txtuser"
			Me.txtuser.Size = New Global.System.Drawing.Size(247, 29)
			Me.txtuser.TabIndex = 0
			Me.txtuser.TabStop = False
			Me.txtuser.Text = "sadmin"
			Me.txtuser.Visible = False
			Me.UsernameLabel.AutoSize = True
			Me.UsernameLabel.BackColor = Global.System.Drawing.Color.Transparent
			Me.UsernameLabel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.UsernameLabel.Location = New Global.System.Drawing.Point(171, 36)
			Me.UsernameLabel.Name = "UsernameLabel"
			Me.UsernameLabel.Size = New Global.System.Drawing.Size(75, 25)
			Me.UsernameLabel.TabIndex = 0
			Me.UsernameLabel.Text = "User ID"
			Me.UsernameLabel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.UsernameLabel.Visible = False
			Me.PasswordLabel.BackColor = Global.System.Drawing.Color.Transparent
			Me.PasswordLabel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PasswordLabel.ForeColor = Global.System.Drawing.Color.White
			Me.PasswordLabel.Location = New Global.System.Drawing.Point(173, 107)
			Me.PasswordLabel.Name = "PasswordLabel"
			Me.PasswordLabel.Size = New Global.System.Drawing.Size(220, 23)
			Me.PasswordLabel.TabIndex = 2
			Me.PasswordLabel.Text = "Password"
			Me.PasswordLabel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Btnshow.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Btnshow.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Btnshow.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Btnshow.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Btnshow.ForeColor = Global.System.Drawing.Color.White
			Me.Btnshow.Location = New Global.System.Drawing.Point(102, 30)
			Me.Btnshow.Name = "Btnshow"
			Me.Btnshow.Size = New Global.System.Drawing.Size(52, 27)
			Me.Btnshow.TabIndex = 64
			Me.Btnshow.TabStop = False
			Me.Btnshow.Text = "Show"
			Me.Btnshow.UseVisualStyleBackColor = False
			Me.Btnshow.Visible = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button1.Location = New Global.System.Drawing.Point(264, 177)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(83, 57)
			Me.Button1.TabIndex = 2
			Me.Button1.Text = "                                           &Unlock"
			Me.Button1.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageAboveText
			Me.Button1.UseVisualStyleBackColor = False
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.ForeColor = Global.System.Drawing.Color.Silver
			Me.TextBox2.Location = New Global.System.Drawing.Point(172, 132)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.PasswordChar = "✹"c
			Me.TextBox2.Size = New Global.System.Drawing.Size(247, 29)
			Me.TextBox2.TabIndex = 1
			Me.TextBox2.Text = "Enter the Password"
			Me.LogoPictureBox.BackColor = Global.System.Drawing.Color.Transparent
			Me.LogoPictureBox.Image = CType(componentResourceManager.GetObject("LogoPictureBox.Image"), Global.System.Drawing.Image)
			Me.LogoPictureBox.Location = New Global.System.Drawing.Point(2, 61)
			Me.LogoPictureBox.Name = "LogoPictureBox"
			Me.LogoPictureBox.Size = New Global.System.Drawing.Size(169, 173)
			Me.LogoPictureBox.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.LogoPictureBox.TabIndex = 0
			Me.LogoPictureBox.TabStop = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.DarkKhaki
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(442, 245)
			Me.Panel1.TabIndex = 65
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DarkKhaki
			MyBase.ClientSize = New Global.System.Drawing.Size(442, 245)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Name = "frmScreenlock"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmScreenlock"
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.LogoPictureBox, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040060C4 RID: 24772
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
