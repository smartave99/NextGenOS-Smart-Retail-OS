Namespace BillPoint
	' Token: 0x02000140 RID: 320
		Public Partial Class frmPhonePeUPI
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060035BC RID: 13756 RVA: 0x00211950 File Offset: 0x0020FB50
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

		' Token: 0x060035BD RID: 13757 RVA: 0x002119A0 File Offset: 0x0020FBA0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnCheckout = New Global.System.Windows.Forms.Button()
			Me.LinkLabel2 = New Global.System.Windows.Forms.LinkLabel()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.btnLastTxns = New Global.System.Windows.Forms.Button()
			Me.tBoxLog = New Global.System.Windows.Forms.TextBox()
			Me.Label115 = New Global.System.Windows.Forms.Label()
			Me.tBoxConfirmation = New Global.System.Windows.Forms.TextBox()
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.pBoxQR = New Global.System.Windows.Forms.PictureBox()
			Me.tBoxAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label113 = New Global.System.Windows.Forms.Label()
			Me.Label114 = New Global.System.Windows.Forms.Label()
			Me.tBoxOrderId = New Global.System.Windows.Forms.TextBox()
			Me.buttonReloadUPIId = New Global.System.Windows.Forms.Button()
			Me.lblValUPIId = New Global.System.Windows.Forms.Label()
			Me.lblMyUPIID = New Global.System.Windows.Forms.Label()
			Me.btnInit = New Global.System.Windows.Forms.Button()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			CType(Me.pBoxQR, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.btnCheckout)
			Me.Panel1.Controls.Add(Me.LinkLabel2)
			Me.Panel1.Controls.Add(Me.LinkLabel1)
			Me.Panel1.Controls.Add(Me.btnLastTxns)
			Me.Panel1.Controls.Add(Me.tBoxLog)
			Me.Panel1.Controls.Add(Me.Label115)
			Me.Panel1.Controls.Add(Me.tBoxConfirmation)
			Me.Panel1.Controls.Add(Me.btnCancel)
			Me.Panel1.Controls.Add(Me.pBoxQR)
			Me.Panel1.Controls.Add(Me.tBoxAmount)
			Me.Panel1.Controls.Add(Me.Label113)
			Me.Panel1.Controls.Add(Me.Label114)
			Me.Panel1.Controls.Add(Me.tBoxOrderId)
			Me.Panel1.Controls.Add(Me.buttonReloadUPIId)
			Me.Panel1.Controls.Add(Me.lblValUPIId)
			Me.Panel1.Controls.Add(Me.lblMyUPIID)
			Me.Panel1.Controls.Add(Me.btnInit)
			Me.Panel1.Location = New Global.System.Drawing.Point(12, 12)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(544, 318)
			Me.Panel1.TabIndex = 0
			Me.btnCheckout.BackColor = Global.System.Drawing.Color.FromArgb(192, 192, 255)
			Me.btnCheckout.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCheckout.Location = New Global.System.Drawing.Point(205, 33)
			Me.btnCheckout.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.btnCheckout.Name = "btnCheckout"
			Me.btnCheckout.Size = New Global.System.Drawing.Size(86, 48)
			Me.btnCheckout.TabIndex = 1722
			Me.btnCheckout.Text = "Generate QR Code"
			Me.btnCheckout.UseVisualStyleBackColor = False
			Me.LinkLabel2.ActiveLinkColor = Global.System.Drawing.Color.Blue
			Me.LinkLabel2.AutoSize = True
			Me.LinkLabel2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel2.LinkColor = Global.System.Drawing.Color.Red
			Me.LinkLabel2.Location = New Global.System.Drawing.Point(294, 64)
			Me.LinkLabel2.Name = "LinkLabel2"
			Me.LinkLabel2.Size = New Global.System.Drawing.Size(36, 15)
			Me.LinkLabel2.TabIndex = 1730
			Me.LinkLabel2.TabStop = True
			Me.LinkLabel2.Text = "(OFF)"
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(287, 5)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(50, 48)
			Me.LinkLabel1.TabIndex = 1729
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "2nd Display (ON)"
			Me.LinkLabel1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnLastTxns.BackColor = Global.System.Drawing.Color.FromArgb(255, 224, 192)
			Me.btnLastTxns.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLastTxns.Location = New Global.System.Drawing.Point(3, 164)
			Me.btnLastTxns.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.btnLastTxns.Name = "btnLastTxns"
			Me.btnLastTxns.Size = New Global.System.Drawing.Size(50, 35)
			Me.btnLastTxns.TabIndex = 1728
			Me.btnLastTxns.Text = "Last Txns"
			Me.btnLastTxns.UseVisualStyleBackColor = False
			Me.tBoxLog.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.tBoxLog.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.tBoxLog.Location = New Global.System.Drawing.Point(3, 203)
			Me.tBoxLog.Multiline = True
			Me.tBoxLog.Name = "tBoxLog"
			Me.tBoxLog.[ReadOnly] = True
			Me.tBoxLog.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.tBoxLog.Size = New Global.System.Drawing.Size(536, 110)
			Me.tBoxLog.TabIndex = 1727
			Me.tBoxLog.TabStop = False
			Me.Label115.AutoSize = True
			Me.Label115.ForeColor = Global.System.Drawing.Color.FromArgb(192, 64, 0)
			Me.Label115.Location = New Global.System.Drawing.Point(5, 85)
			Me.Label115.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label115.Name = "Label115"
			Me.Label115.Size = New Global.System.Drawing.Size(37, 13)
			Me.Label115.TabIndex = 1726
			Me.Label115.Text = "Status"
			Me.tBoxConfirmation.BackColor = Global.System.Drawing.SystemColors.Control
			Me.tBoxConfirmation.Location = New Global.System.Drawing.Point(57, 85)
			Me.tBoxConfirmation.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.tBoxConfirmation.Multiline = True
			Me.tBoxConfirmation.Name = "tBoxConfirmation"
			Me.tBoxConfirmation.[ReadOnly] = True
			Me.tBoxConfirmation.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.tBoxConfirmation.Size = New Global.System.Drawing.Size(266, 56)
			Me.tBoxConfirmation.TabIndex = 1725
			Me.tBoxConfirmation.TabStop = False
			Me.btnCancel.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnCancel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnCancel.Enabled = False
			Me.btnCancel.Location = New Global.System.Drawing.Point(126, 168)
			Me.btnCancel.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Global.System.Drawing.Size(50, 26)
			Me.btnCancel.TabIndex = 1724
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = False
			Me.pBoxQR.Location = New Global.System.Drawing.Point(340, 3)
			Me.pBoxQR.Name = "pBoxQR"
			Me.pBoxQR.Size = New Global.System.Drawing.Size(199, 185)
			Me.pBoxQR.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pBoxQR.TabIndex = 1723
			Me.pBoxQR.TabStop = False
			Me.tBoxAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.tBoxAmount.Location = New Global.System.Drawing.Point(57, 59)
			Me.tBoxAmount.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.tBoxAmount.Name = "tBoxAmount"
			Me.tBoxAmount.Size = New Global.System.Drawing.Size(140, 20)
			Me.tBoxAmount.TabIndex = 1721
			Me.tBoxAmount.TabStop = False
			Me.tBoxAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label113.AutoSize = True
			Me.Label113.ForeColor = Global.System.Drawing.Color.FromArgb(192, 64, 0)
			Me.Label113.Location = New Global.System.Drawing.Point(4, 62)
			Me.Label113.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label113.Name = "Label113"
			Me.Label113.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label113.TabIndex = 1720
			Me.Label113.Text = "Amount"
			Me.Label114.AutoSize = True
			Me.Label114.ForeColor = Global.System.Drawing.Color.FromArgb(192, 64, 0)
			Me.Label114.Location = New Global.System.Drawing.Point(4, 37)
			Me.Label114.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.Label114.Name = "Label114"
			Me.Label114.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label114.TabIndex = 1719
			Me.Label114.Text = "Order ID"
			Me.tBoxOrderId.Location = New Global.System.Drawing.Point(57, 33)
			Me.tBoxOrderId.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.tBoxOrderId.Name = "tBoxOrderId"
			Me.tBoxOrderId.[ReadOnly] = True
			Me.tBoxOrderId.Size = New Global.System.Drawing.Size(140, 20)
			Me.tBoxOrderId.TabIndex = 1718
			Me.tBoxOrderId.TabStop = False
			Me.buttonReloadUPIId.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.buttonReloadUPIId.Location = New Global.System.Drawing.Point(205, 167)
			Me.buttonReloadUPIId.Name = "buttonReloadUPIId"
			Me.buttonReloadUPIId.Size = New Global.System.Drawing.Size(26, 22)
			Me.buttonReloadUPIId.TabIndex = 1717
			Me.buttonReloadUPIId.Text = "R"
			Me.buttonReloadUPIId.UseVisualStyleBackColor = True
			Me.buttonReloadUPIId.Visible = False
			Me.lblValUPIId.AutoSize = True
			Me.lblValUPIId.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold)
			Me.lblValUPIId.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblValUPIId.Location = New Global.System.Drawing.Point(55, 11)
			Me.lblValUPIId.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblValUPIId.Name = "lblValUPIId"
			Me.lblValUPIId.Size = New Global.System.Drawing.Size(40, 15)
			Me.lblValUPIId.TabIndex = 1716
			Me.lblValUPIId.Text = "<NA>"
			Me.lblMyUPIID.AutoSize = True
			Me.lblMyUPIID.ForeColor = Global.System.Drawing.Color.FromArgb(192, 64, 0)
			Me.lblMyUPIID.Location = New Global.System.Drawing.Point(4, 12)
			Me.lblMyUPIID.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblMyUPIID.Name = "lblMyUPIID"
			Me.lblMyUPIID.Size = New Global.System.Drawing.Size(51, 13)
			Me.lblMyUPIID.TabIndex = 1715
			Me.lblMyUPIID.Text = "MyUPI Id"
			Me.btnInit.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 192)
			Me.btnInit.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnInit.Location = New Global.System.Drawing.Point(184, 164)
			Me.btnInit.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.btnInit.Name = "btnInit"
			Me.btnInit.Size = New Global.System.Drawing.Size(19, 28)
			Me.btnInit.TabIndex = 1714
			Me.btnInit.TabStop = False
			Me.btnInit.Text = "Initialize"
			Me.btnInit.UseVisualStyleBackColor = False
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Location = New Global.System.Drawing.Point(233, 149)
			Me.TextBox1.Margin = New Global.System.Windows.Forms.Padding(4)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(90, 20)
			Me.TextBox1.TabIndex = 1731
			Me.TextBox1.TabStop = False
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			MyBase.ClientSize = New Global.System.Drawing.Size(568, 342)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmPhonePeUPI"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "PhonePe UPI Gateway"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.pBoxQR, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04001768 RID: 5992
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
