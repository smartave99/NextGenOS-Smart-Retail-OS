Namespace BillPoint
	' Token: 0x02000329 RID: 809
		Public Partial Class Form2
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BDDF RID: 48607 RVA: 0x00792B44 File Offset: 0x00790D44
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

		' Token: 0x0600BDE0 RID: 48608 RVA: 0x00792B94 File Offset: 0x00790D94
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.PictureBox1.Location = New Global.System.Drawing.Point(0, 0)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(361, 349)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 1
			Me.PictureBox1.TabStop = False
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(361, 349)
			Me.Panel1.TabIndex = 2
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(361, 349)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "Form2"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Form2"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004C1F RID: 19487
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
