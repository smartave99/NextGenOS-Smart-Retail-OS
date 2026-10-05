Namespace BillPoint
	' Token: 0x02000578 RID: 1400
		Public Partial Class frmSendSMS_Sales
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011064 RID: 69732 RVA: 0x009E16D0 File Offset: 0x009DF8D0
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

		' Token: 0x06011065 RID: 69733 RVA: 0x009E1720 File Offset: 0x009DF920
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSendSMS_Sales))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtMessage = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtMobileNo = New Global.System.Windows.Forms.TextBox()
			Me.btnSend = New Global.System.Windows.Forms.Button()
			Me.btnGetSales = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.txtCompany = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(685, 57)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "SMS Sender"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(163, 25)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 45
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(28, 156)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(68, 17)
			Me.Label10.TabIndex = 51
			Me.Label10.Text = "Message :"
			Me.txtMessage.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMessage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMessage.Location = New Global.System.Drawing.Point(118, 106)
			Me.txtMessage.Multiline = True
			Me.txtMessage.Name = "txtMessage"
			Me.txtMessage.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtMessage.Size = New Global.System.Drawing.Size(352, 135)
			Me.txtMessage.TabIndex = 1
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(28, 73)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(81, 17)
			Me.Label7.TabIndex = 50
			Me.Label7.Text = "Mobile No. :"
			Me.txtMobileNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMobileNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMobileNo.Location = New Global.System.Drawing.Point(118, 73)
			Me.txtMobileNo.Name = "txtMobileNo"
			Me.txtMobileNo.Size = New Global.System.Drawing.Size(205, 26)
			Me.txtMobileNo.TabIndex = 0
			Me.btnSend.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnSend.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSend.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSend.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSend.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSend.ForeColor = Global.System.Drawing.Color.White
			Me.btnSend.Image = CType(componentResourceManager.GetObject("btnSend.Image"), Global.System.Drawing.Image)
			Me.btnSend.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSend.Location = New Global.System.Drawing.Point(502, 179)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.Size = New Global.System.Drawing.Size(167, 62)
			Me.btnSend.TabIndex = 4
			Me.btnSend.Text = "&Send SMS"
			Me.btnSend.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSend.UseVisualStyleBackColor = False
			Me.btnGetSales.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetSales.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnGetSales.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetSales.Location = New Global.System.Drawing.Point(328, 73)
			Me.btnGetSales.Name = "btnGetSales"
			Me.btnGetSales.Size = New Global.System.Drawing.Size(167, 26)
			Me.btnGetSales.TabIndex = 2
			Me.btnGetSales.Text = "Get Today Sales Data"
			Me.btnGetSales.UseVisualStyleBackColor = True
			Me.btnReset.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(502, 106)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(167, 67)
			Me.btnReset.TabIndex = 3
			Me.btnReset.Text = "&Clear"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.txtCompany.Location = New Global.System.Drawing.Point(92, 12)
			Me.txtCompany.Name = "txtCompany"
			Me.txtCompany.Size = New Global.System.Drawing.Size(17, 20)
			Me.txtCompany.TabIndex = 52
			Me.txtCompany.Visible = False
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.Location = New Global.System.Drawing.Point(500, 73)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(183, 26)
			Me.Button1.TabIndex = 53
			Me.Button1.Text = "Get Today Cash Sales Data"
			Me.Button1.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ButtonHighlight
			MyBase.ClientSize = New Global.System.Drawing.Size(685, 256)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.txtCompany)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.btnSend)
			MyBase.Controls.Add(Me.btnGetSales)
			MyBase.Controls.Add(Me.Label10)
			MyBase.Controls.Add(Me.txtMessage)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtMobileNo)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.Label1)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSendSMS_Sales"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "SMS Sender"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400665C RID: 26204
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
