Namespace BillPoint
	' Token: 0x020004EA RID: 1258
		Public Partial Class frmWhatsappMessage
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060102AC RID: 66220 RVA: 0x009A15F0 File Offset: 0x0099F7F0
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

		' Token: 0x060102AD RID: 66221 RVA: 0x009A1640 File Offset: 0x0099F840
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmWhatsappMessage))
			Me.txtWNo = New Global.System.Windows.Forms.TextBox()
			Me.txtWMsg = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnListReset1 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.txtWNo.BackColor = Global.System.Drawing.Color.White
			Me.txtWNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWNo.Location = New Global.System.Drawing.Point(344, 76)
			Me.txtWNo.Name = "txtWNo"
			Me.txtWNo.Size = New Global.System.Drawing.Size(261, 26)
			Me.txtWNo.TabIndex = 0
			Me.txtWMsg.BackColor = Global.System.Drawing.Color.White
			Me.txtWMsg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWMsg.Location = New Global.System.Drawing.Point(303, 141)
			Me.txtWMsg.Multiline = True
			Me.txtWMsg.Name = "txtWMsg"
			Me.txtWMsg.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtWMsg.Size = New Global.System.Drawing.Size(374, 175)
			Me.txtWMsg.TabIndex = 1
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button1.Location = New Global.System.Drawing.Point(609, 76)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(68, 60)
			Me.Button1.TabIndex = 3
			Me.Button1.Text = "&Send"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(299, 52)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(222, 20)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Receiver's WhatsApp No. :"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Black
			Me.Label3.Location = New Global.System.Drawing.Point(299, 116)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(130, 20)
			Me.Label3.TabIndex = 5
			Me.Label3.Text = "Text Message :"
			Me.Label3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(12, 40)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(281, 275)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 6
			Me.PictureBox1.TabStop = False
			Me.btnListReset1.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnListReset1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnListReset1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnListReset1.ForeColor = Global.System.Drawing.Color.Transparent
			Me.btnListReset1.Image = CType(componentResourceManager.GetObject("btnListReset1.Image"), Global.System.Drawing.Image)
			Me.btnListReset1.Location = New Global.System.Drawing.Point(569, 104)
			Me.btnListReset1.Name = "btnListReset1"
			Me.btnListReset1.Size = New Global.System.Drawing.Size(36, 32)
			Me.btnListReset1.TabIndex = 7
			Me.btnListReset1.TabStop = False
			Me.btnListReset1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnListReset1.UseVisualStyleBackColor = False
			Me.TextBox3.BackColor = Global.System.Drawing.SystemColors.Control
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(303, 76)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(39, 26)
			Me.TextBox3.TabIndex = 8
			Me.TextBox3.TabStop = False
			Me.TextBox3.Text = "+91"
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button2.Location = New Global.System.Drawing.Point(683, 76)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(68, 60)
			Me.Button2.TabIndex = 9
			Me.Button2.Text = "&Send"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button2.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.MintCream
			MyBase.ClientSize = New Global.System.Drawing.Size(836, 359)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.TextBox3)
			MyBase.Controls.Add(Me.btnListReset1)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.txtWMsg)
			MyBase.Controls.Add(Me.txtWNo)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmWhatsappMessage"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "WhatsApp Instant Message"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006331 RID: 25393
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
