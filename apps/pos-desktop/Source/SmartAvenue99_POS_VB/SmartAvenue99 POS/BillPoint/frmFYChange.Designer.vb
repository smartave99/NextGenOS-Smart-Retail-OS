Namespace BillPoint
	' Token: 0x020004C6 RID: 1222
		Public Partial Class frmFYChange
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F5BE RID: 62910 RVA: 0x009347E4 File Offset: 0x009329E4
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

		' Token: 0x0600F5BF RID: 62911 RVA: 0x00934834 File Offset: 0x00932A34
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmFYChange))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.TextBox6)
			Me.Panel1.Controls.Add(Me.ProgressBar1)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.DTP2)
			Me.Panel1.Controls.Add(Me.DTP1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(550, 319)
			Me.Panel1.TabIndex = 0
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(414, 211)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 1753
			Me.GelButton1.Text = "&Save"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(305, 211)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 1754
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(5, 225)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(146, 13)
			Me.Label4.TabIndex = 1752
			Me.Label4.Text = "Starting POS Number Series :"
			Me.Button1.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.System
			Me.Button1.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(96, 241)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(43, 20)
			Me.Button1.TabIndex = 1751
			Me.Button1.TabStop = False
			Me.Button1.Text = "&Apply"
			Me.Button1.UseVisualStyleBackColor = False
			Me.TextBox6.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.TextBox6.Location = New Global.System.Drawing.Point(8, 241)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.Size = New Global.System.Drawing.Size(84, 20)
			Me.TextBox6.TabIndex = 1750
			Me.TextBox6.TabStop = False
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(3, 267)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(518, 23)
			Me.ProgressBar1.TabIndex = 452
			Me.TextBox1.Location = New Global.System.Drawing.Point(13, 15)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox1.TabIndex = 451
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(403, 23)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 450
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Red
			Me.Label3.Location = New Global.System.Drawing.Point(3, 148)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(167, 29)
			Me.Label3.TabIndex = 447
			Me.Label3.Text = "FY Ends On :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Red
			Me.Label2.Location = New Global.System.Drawing.Point(3, 71)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(216, 29)
			Me.Label2.TabIndex = 446
			Me.Label2.Text = "FY Begins From :"
			Me.DTP2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 24F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.DTP2.Location = New Global.System.Drawing.Point(314, 148)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.ShowUpDown = True
			Me.DTP2.Size = New Global.System.Drawing.Size(200, 44)
			Me.DTP2.TabIndex = 445
			Me.DTP1.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 24F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 24F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.DTP1.Location = New Global.System.Drawing.Point(314, 71)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.ShowUpDown = True
			Me.DTP1.Size = New Global.System.Drawing.Size(200, 44)
			Me.DTP1.TabIndex = 444
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(550, 31)
			Me.Label1.TabIndex = 48
			Me.Label1.Text = "Financial Year Change"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(550, 319)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmFYChange"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005DE9 RID: 24041
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
