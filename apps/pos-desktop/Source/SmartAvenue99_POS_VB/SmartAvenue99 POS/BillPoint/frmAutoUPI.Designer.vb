Namespace BillPoint
	' Token: 0x02000292 RID: 658
		Public Partial Class frmAutoUPI
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600A75A RID: 42842 RVA: 0x007021C8 File Offset: 0x007003C8
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

		' Token: 0x0600A75B RID: 42843 RVA: 0x00702218 File Offset: 0x00700418
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmAutoUPI))
			Me.panel1 = New Global.System.Windows.Forms.Panel()
			Me.pBoxQR = New Global.System.Windows.Forms.PictureBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			CType(Me.pBoxQR, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.panel1.BackColor = Global.System.Drawing.Color.White
			Me.panel1.Location = New Global.System.Drawing.Point(149, 308)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New Global.System.Drawing.Size(19, 16)
			Me.panel1.TabIndex = 73
			Me.panel1.Visible = False
			Me.pBoxQR.BackColor = Global.System.Drawing.Color.Snow
			Me.pBoxQR.Location = New Global.System.Drawing.Point(15, 12)
			Me.pBoxQR.Name = "pBoxQR"
			Me.pBoxQR.Size = New Global.System.Drawing.Size(290, 290)
			Me.pBoxQR.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.pBoxQR.TabIndex = 53
			Me.pBoxQR.TabStop = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(450, 249)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(105, 53)
			Me.Button2.TabIndex = 74
			Me.Button2.Text = "Secondary Display Off"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(338, 249)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(105, 53)
			Me.Button1.TabIndex = 75
			Me.Button1.Text = "Secondary Display On"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 26.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Yellow
			Me.Label1.Location = New Global.System.Drawing.Point(0, 320)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(567, 57)
			Me.Label1.TabIndex = 76
			Me.Label1.Text = "0.00"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(349, 42)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(194, 201)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 77
			Me.PictureBox1.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 20.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(356, 5)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(177, 32)
			Me.Label2.TabIndex = 78
			Me.Label2.Text = "Scan To Pay"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.IndianRed
			MyBase.ClientSize = New Global.System.Drawing.Size(567, 377)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.pBoxQR)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmAutoUPI"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "UPI Gateway"
			CType(Me.pBoxQR, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040045C1 RID: 17857
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
