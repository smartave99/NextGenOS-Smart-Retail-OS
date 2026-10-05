Namespace BillPoint
	' Token: 0x020004A6 RID: 1190
		Public Partial Class Error8
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600EC4F RID: 60495 RVA: 0x008E46F0 File Offset: 0x008E28F0
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

		' Token: 0x0600EC50 RID: 60496 RVA: 0x008E4740 File Offset: 0x008E2940
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.Error8))
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(3, 36)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(35, 32)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.Zoom
			Me.PictureBox1.TabIndex = 13
			Me.PictureBox1.TabStop = False
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(44, 42)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(211, 25)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "Unlock Failed...Please Try Again !"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(257, 104)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "Error8"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Checking"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005A3A RID: 23098
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
