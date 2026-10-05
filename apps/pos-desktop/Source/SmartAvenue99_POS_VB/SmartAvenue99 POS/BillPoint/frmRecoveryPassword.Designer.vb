Namespace BillPoint
	' Token: 0x02000596 RID: 1430
		Public Partial Class frmRecoveryPassword
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0601196A RID: 72042 RVA: 0x00A31D04 File Offset: 0x00A2FF04
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

		' Token: 0x0601196B RID: 72043 RVA: 0x00A31D54 File Offset: 0x00A2FF54
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmRecoveryPassword))
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.btnKeyboard = New Global.System.Windows.Forms.Button()
			Me.btnSendMail = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.txtEmailID.CharacterCasing = Global.System.Windows.Forms.CharacterCasing.Lower
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.ForeColor = Global.System.Drawing.Color.DarkViolet
			Me.txtEmailID.Location = New Global.System.Drawing.Point(25, 74)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(355, 29)
			Me.txtEmailID.TabIndex = 10
			Me.Label4.AutoSize = True
			Me.Label4.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.MidnightBlue
			Me.Label4.Location = New Global.System.Drawing.Point(21, 45)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(139, 24)
			Me.Label4.TabIndex = 17
			Me.Label4.Text = "Enter Email ID :"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.btnCancel)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.btnKeyboard)
			Me.Panel1.Controls.Add(Me.txtEmailID)
			Me.Panel1.Controls.Add(Me.btnSendMail)
			Me.Panel1.Location = New Global.System.Drawing.Point(9, 61)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(405, 361)
			Me.Panel1.TabIndex = 18
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(3, 182)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(263, 176)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 61
			Me.PictureBox1.TabStop = False
			Me.btnCancel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCancel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnCancel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCancel.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.FlatAppearance.BorderSize = 0
			Me.btnCancel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnCancel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCancel.Image = Global.BillPoint.My.Resources.Resources.Button_Delete_icon1
			Me.btnCancel.Location = New Global.System.Drawing.Point(333, 295)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Global.System.Drawing.Size(56, 57)
			Me.btnCancel.TabIndex = 60
			Me.btnCancel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCancel.UseVisualStyleBackColor = False
			Me.btnKeyboard.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnKeyboard.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnKeyboard.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnKeyboard.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnKeyboard.FlatAppearance.BorderColor = Global.System.Drawing.Color.FromArgb(0, 64, 64)
			Me.btnKeyboard.FlatAppearance.BorderSize = 0
			Me.btnKeyboard.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnKeyboard.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnKeyboard.ForeColor = Global.System.Drawing.Color.White
			Me.btnKeyboard.Image = CType(componentResourceManager.GetObject("btnKeyboard.Image"), Global.System.Drawing.Image)
			Me.btnKeyboard.Location = New Global.System.Drawing.Point(272, 295)
			Me.btnKeyboard.Name = "btnKeyboard"
			Me.btnKeyboard.Size = New Global.System.Drawing.Size(56, 57)
			Me.btnKeyboard.TabIndex = 59
			Me.btnKeyboard.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnKeyboard.UseVisualStyleBackColor = False
			Me.btnSendMail.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSendMail.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSendMail.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSendMail.FlatAppearance.BorderSize = 0
			Me.btnSendMail.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnSendMail.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSendMail.ForeColor = Global.System.Drawing.Color.White
			Me.btnSendMail.Image = CType(componentResourceManager.GetObject("btnSendMail.Image"), Global.System.Drawing.Image)
			Me.btnSendMail.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSendMail.Location = New Global.System.Drawing.Point(233, 109)
			Me.btnSendMail.Name = "btnSendMail"
			Me.btnSendMail.Size = New Global.System.Drawing.Size(147, 57)
			Me.btnSendMail.TabIndex = 15
			Me.btnSendMail.Text = "&Send Email"
			Me.btnSendMail.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSendMail.UseVisualStyleBackColor = False
			Me.Label5.BackColor = Global.System.Drawing.Color.Orange
			Me.Label5.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 20.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(425, 50)
			Me.Label5.TabIndex = 19
			Me.Label5.Text = "Password Recovery Form"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AcceptButton = Me.btnSendMail
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(425, 434)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmRecoveryPassword"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Change Password"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006A30 RID: 27184
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
