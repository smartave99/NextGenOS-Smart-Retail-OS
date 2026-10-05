Namespace BillPoint
	' Token: 0x02000349 RID: 841
		Public Partial Class frmInvoicePhoto
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C52F RID: 50479 RVA: 0x007CFD60 File Offset: 0x007CDF60
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

		' Token: 0x0600C530 RID: 50480 RVA: 0x007CFDB0 File Offset: 0x007CDFB0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmInvoicePhoto))
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.Noimage
			Me.PictureBox1.Location = New Global.System.Drawing.Point(12, 12)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(355, 388)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 6
			Me.PictureBox1.TabStop = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(272, 406)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(94, 37)
			Me.btnSave.TabIndex = 7
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(12, 406)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(94, 37)
			Me.Button2.TabIndex = 150
			Me.Button2.TabStop = False
			Me.Button2.Text = "&Browse"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.TextBox1.Location = New Global.System.Drawing.Point(148, 423)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox1.TabIndex = 151
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(145, 406)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label1.TabIndex = 152
			Me.Label1.Text = "Enter ID No :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DarkOrange
			MyBase.ClientSize = New Global.System.Drawing.Size(378, 447)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.PictureBox1)
			Me.ForeColor = Global.System.Drawing.Color.Black
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedToolWindow
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmInvoicePhoto"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Invoice Photo"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004F0A RID: 20234
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
