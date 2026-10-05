Namespace BillPoint
	' Token: 0x02000206 RID: 518
		Public Partial Class frmSaleAmtCal
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060095B9 RID: 38329 RVA: 0x006BDF88 File Offset: 0x006BC188
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

		' Token: 0x060095BA RID: 38330 RVA: 0x006BDFD8 File Offset: 0x006BC1D8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblTaxPer = New Global.System.Windows.Forms.Label()
			Me.lblDiscAmt = New Global.System.Windows.Forms.Label()
			Me.lblTaxType = New Global.System.Windows.Forms.Label()
			Me.lblPrice = New Global.System.Windows.Forms.Label()
			Me.lblPOSType = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(12, 26)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(171, 50)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Item's Adjustable Amount :"
			Me.lblTaxPer.AutoSize = True
			Me.lblTaxPer.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblTaxPer.ForeColor = Global.System.Drawing.Color.White
			Me.lblTaxPer.Location = New Global.System.Drawing.Point(215, 9)
			Me.lblTaxPer.Name = "lblTaxPer"
			Me.lblTaxPer.Size = New Global.System.Drawing.Size(66, 13)
			Me.lblTaxPer.TabIndex = 1
			Me.lblTaxPer.Text = "Total Tax% :"
			Me.lblTaxPer.Visible = False
			Me.lblDiscAmt.AutoSize = True
			Me.lblDiscAmt.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblDiscAmt.ForeColor = Global.System.Drawing.Color.White
			Me.lblDiscAmt.Location = New Global.System.Drawing.Point(118, 9)
			Me.lblDiscAmt.Name = "lblDiscAmt"
			Me.lblDiscAmt.Size = New Global.System.Drawing.Size(82, 13)
			Me.lblDiscAmt.TabIndex = 4
			Me.lblDiscAmt.Text = "Total Disc Amt :"
			Me.lblDiscAmt.Visible = False
			Me.lblTaxType.AutoSize = True
			Me.lblTaxType.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblTaxType.ForeColor = Global.System.Drawing.Color.White
			Me.lblTaxType.Location = New Global.System.Drawing.Point(368, 9)
			Me.lblTaxType.Name = "lblTaxType"
			Me.lblTaxType.Size = New Global.System.Drawing.Size(58, 13)
			Me.lblTaxType.TabIndex = 5
			Me.lblTaxType.Text = "Tax Type :"
			Me.lblTaxType.Visible = False
			Me.lblPrice.AutoSize = True
			Me.lblPrice.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblPrice.ForeColor = Global.System.Drawing.Color.White
			Me.lblPrice.Location = New Global.System.Drawing.Point(308, 9)
			Me.lblPrice.Name = "lblPrice"
			Me.lblPrice.Size = New Global.System.Drawing.Size(37, 13)
			Me.lblPrice.TabIndex = 6
			Me.lblPrice.Text = "Price :"
			Me.lblPrice.Visible = False
			Me.lblPOSType.AutoSize = True
			Me.lblPOSType.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblPOSType.ForeColor = Global.System.Drawing.Color.White
			Me.lblPOSType.Location = New Global.System.Drawing.Point(12, 9)
			Me.lblPOSType.Name = "lblPOSType"
			Me.lblPOSType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblPOSType.TabIndex = 7
			Me.lblPOSType.Text = "lblPOSType"
			Me.lblPOSType.Visible = False
			Me.TextBox1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 27.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.TextBox1.Location = New Global.System.Drawing.Point(189, 26)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(190, 50)
			Me.TextBox1.TabIndex = 8
			Me.TextBox1.Text = "0.00"
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.Transparent
			Me.Button1.Location = New Global.System.Drawing.Point(164, 97)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 53)
			Me.Button1.TabIndex = 9
			Me.Button1.TabStop = False
			Me.Button1.Text = "OK"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Label2.AutoSize = True
			Me.Label2.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(3, 137)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label2.TabIndex = 10
			Me.Label2.Text = "ESC to CLOSE"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			MyBase.ClientSize = New Global.System.Drawing.Size(396, 153)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.lblPOSType)
			MyBase.Controls.Add(Me.lblPrice)
			MyBase.Controls.Add(Me.lblTaxType)
			MyBase.Controls.Add(Me.lblDiscAmt)
			MyBase.Controls.Add(Me.lblTaxPer)
			MyBase.Controls.Add(Me.Label1)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSaleAmtCal"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400423E RID: 16958
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
