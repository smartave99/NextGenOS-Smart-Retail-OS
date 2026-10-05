Namespace BillPoint
	' Token: 0x02000599 RID: 1433
		Public Partial Class frmSendSMS_Services
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060119A4 RID: 72100 RVA: 0x00A32F2C File Offset: 0x00A3112C
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

		' Token: 0x060119A5 RID: 72101 RVA: 0x00A32F7C File Offset: 0x00A3117C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSendSMS_Services))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.txtMessage = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnSend = New Global.System.Windows.Forms.Button()
			Me.btnListofServices = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(682, 57)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Send SMS"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(163, 25)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 45
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(28, 200)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(56, 13)
			Me.Label10.TabIndex = 51
			Me.Label10.Text = "Message :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(28, 82)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label3.TabIndex = 46
			Me.Label3.Text = "Customer ID  :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(141, 82)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(143, 21)
			Me.txtCustomerID.TabIndex = 0
			Me.txtMessage.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMessage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMessage.Location = New Global.System.Drawing.Point(141, 163)
			Me.txtMessage.Multiline = True
			Me.txtMessage.Name = "txtMessage"
			Me.txtMessage.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtMessage.Size = New Global.System.Drawing.Size(329, 151)
			Me.txtMessage.TabIndex = 3
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(28, 136)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label7.TabIndex = 50
			Me.Label7.Text = "Contact No :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(141, 136)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtContactNo.TabIndex = 2
			Me.txtCustomerName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(141, 109)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.[ReadOnly] = True
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(267, 21)
			Me.txtCustomerName.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(28, 109)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label2.TabIndex = 53
			Me.Label2.Text = "Customer Name  :"
			Me.btnSend.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSend.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSend.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSend.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSend.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSend.ForeColor = Global.System.Drawing.Color.White
			Me.btnSend.Image = CType(componentResourceManager.GetObject("btnSend.Image"), Global.System.Drawing.Image)
			Me.btnSend.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSend.Location = New Global.System.Drawing.Point(502, 250)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New Global.System.Drawing.Size(167, 62)
			Me.btnSend.TabIndex = 7
			Me.btnSend.Text = "&Send SMS"
			Me.btnSend.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSend.UseVisualStyleBackColor = False
			Me.btnListofServices.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnListofServices.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnListofServices.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnListofServices.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnListofServices.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnListofServices.ForeColor = Global.System.Drawing.Color.White
			Me.btnListofServices.Location = New Global.System.Drawing.Point(290, 80)
			Me.btnListofServices.Name = "btnListofServices"
			Me.btnListofServices.Size = New Global.System.Drawing.Size(118, 24)
			Me.btnListofServices.TabIndex = 5
			Me.btnListofServices.Text = "&List of Services"
			Me.btnListofServices.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(502, 177)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(167, 67)
			Me.btnReset.TabIndex = 6
			Me.btnReset.Text = "&Clear"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ButtonHighlight
			MyBase.ClientSize = New Global.System.Drawing.Size(682, 332)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.btnSend)
			MyBase.Controls.Add(Me.btnListofServices)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtCustomerName)
			MyBase.Controls.Add(Me.Label10)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.txtCustomerID)
			MyBase.Controls.Add(Me.txtMessage)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtContactNo)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.Label1)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSendSMS_Services"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Send SMS (Service)"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006A3C RID: 27196
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
