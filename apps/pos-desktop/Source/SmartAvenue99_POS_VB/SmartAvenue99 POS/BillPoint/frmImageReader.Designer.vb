Namespace BillPoint
	' Token: 0x0200011E RID: 286
		Public Partial Class frmImageReader
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060031A9 RID: 12713 RVA: 0x001EBDB4 File Offset: 0x001E9FB4
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

		' Token: 0x060031AA RID: 12714 RVA: 0x001EBE04 File Offset: 0x001EA004
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.btnUpload = New Global.System.Windows.Forms.Button()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.btnUpload.Location = New Global.System.Drawing.Point(25, 15)
			Me.btnUpload.Name = "btnUpload"
			Me.btnUpload.Size = New Global.System.Drawing.Size(134, 39)
			Me.btnUpload.TabIndex = 0
			Me.btnUpload.Text = "Extract Image Data"
			Me.btnUpload.UseVisualStyleBackColor = True
			Me.TextBox1.Location = New Global.System.Drawing.Point(25, 61)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(408, 20)
			Me.TextBox1.TabIndex = 1
			Me.Button1.Location = New Global.System.Drawing.Point(299, 15)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(134, 39)
			Me.Button1.TabIndex = 2
			Me.Button1.Text = "Extract Image Data(Without Text)"
			Me.Button1.UseVisualStyleBackColor = True
			Me.TextBox2.Location = New Global.System.Drawing.Point(25, 87)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(408, 20)
			Me.TextBox2.TabIndex = 3
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(519, 339)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(155, 24)
			Me.BStartCapture.TabIndex = 325
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(583, 322)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label26"
			label.Size = New Global.System.Drawing.Size(23, 13)
			label.TabIndex = 326
			label.Text = "OR"
			Me.Browse.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(519, 299)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(69, 24)
			Me.Browse.TabIndex = 323
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(605, 299)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(69, 24)
			Me.BRemove.TabIndex = 324
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(450, 12)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(300, 260)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 322
			Me.Picture.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(756, 383)
			MyBase.Controls.Add(Me.BStartCapture)
			MyBase.Controls.Add(label)
			MyBase.Controls.Add(Me.Browse)
			MyBase.Controls.Add(Me.BRemove)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.btnUpload)
			MyBase.Name = "frmImageReader"
			Me.Text = "Image Reader"
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400154E RID: 5454
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
