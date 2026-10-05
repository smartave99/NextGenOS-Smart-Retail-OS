Namespace BillPoint
	' Token: 0x02000133 RID: 307
		Public Partial Class frmMobileIDDialog
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600348E RID: 13454 RVA: 0x00206A88 File Offset: 0x00204C88
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

		' Token: 0x0600348F RID: 13455 RVA: 0x00206AD8 File Offset: 0x00204CD8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.LinkLabel2 = New Global.System.Windows.Forms.LinkLabel()
			Me.LinkLabel3 = New Global.System.Windows.Forms.LinkLabel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.txtAndroidID = New Global.System.Windows.Forms.TextBox()
			Me.PictureBox3 = New Global.System.Windows.Forms.PictureBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.GroupBox3.SuspendLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.GroupBox3.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox3.Controls.Add(Me.Button1)
			Me.GroupBox3.Controls.Add(Me.LinkLabel2)
			Me.GroupBox3.Controls.Add(Me.LinkLabel3)
			Me.GroupBox3.Controls.Add(Me.Button2)
			Me.GroupBox3.Controls.Add(Me.Label19)
			Me.GroupBox3.Controls.Add(Me.txtAndroidID)
			Me.GroupBox3.Controls.Add(Me.PictureBox3)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(12, 12)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(376, 168)
			Me.GroupBox3.TabIndex = 1747
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Mobile Application Info :"
			Me.LinkLabel2.ActiveLinkColor = Global.System.Drawing.Color.Blue
			Me.LinkLabel2.AutoSize = True
			Me.LinkLabel2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel2.LinkColor = Global.System.Drawing.Color.Red
			Me.LinkLabel2.Location = New Global.System.Drawing.Point(145, 100)
			Me.LinkLabel2.Name = "LinkLabel2"
			Me.LinkLabel2.Size = New Global.System.Drawing.Size(36, 15)
			Me.LinkLabel2.TabIndex = 1696
			Me.LinkLabel2.TabStop = True
			Me.LinkLabel2.Text = "(OFF)"
			Me.LinkLabel3.AutoSize = True
			Me.LinkLabel3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel3.LinkColor = Global.System.Drawing.Color.Green
			Me.LinkLabel3.Location = New Global.System.Drawing.Point(8, 100)
			Me.LinkLabel3.Name = "LinkLabel3"
			Me.LinkLabel3.Size = New Global.System.Drawing.Size(99, 15)
			Me.LinkLabel3.TabIndex = 1695
			Me.LinkLabel3.TabStop = True
			Me.LinkLabel3.Text = "2nd Display (ON)"
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.Transparent
			Me.Button2.Location = New Global.System.Drawing.Point(142, 12)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(39, 24)
			Me.Button2.TabIndex = 453
			Me.Button2.TabStop = False
			Me.Button2.Text = "&Copy"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label19.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label19.Location = New Global.System.Drawing.Point(5, 21)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(66, 15)
			Me.Label19.TabIndex = 452
			Me.Label19.Text = "Mobile ID :"
			Me.txtAndroidID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.txtAndroidID.Location = New Global.System.Drawing.Point(8, 39)
			Me.txtAndroidID.Multiline = True
			Me.txtAndroidID.Name = "txtAndroidID"
			Me.txtAndroidID.[ReadOnly] = True
			Me.txtAndroidID.Size = New Global.System.Drawing.Size(173, 51)
			Me.txtAndroidID.TabIndex = 451
			Me.txtAndroidID.TabStop = False
			Me.PictureBox3.Location = New Global.System.Drawing.Point(209, 11)
			Me.PictureBox3.Name = "PictureBox3"
			Me.PictureBox3.Size = New Global.System.Drawing.Size(161, 150)
			Me.PictureBox3.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox3.TabIndex = 450
			Me.PictureBox3.TabStop = False
			Me.Button1.BackColor = Global.System.Drawing.Color.Red
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(71, 138)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(56, 24)
			Me.Button1.TabIndex = 1697
			Me.Button1.TabStop = False
			Me.Button1.Text = "&Close"
			Me.Button1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(399, 191)
			MyBase.Controls.Add(Me.GroupBox3)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmMobileIDDialog"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040016A6 RID: 5798
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
