Namespace BillPoint
	' Token: 0x02000371 RID: 881
		Public Partial Class frmTempleteEdit
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600D023 RID: 53283 RVA: 0x0081C1E4 File Offset: 0x0081A3E4
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

		' Token: 0x0600D024 RID: 53284 RVA: 0x0081C234 File Offset: 0x0081A434
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(50, 23)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(128, 84)
			Me.Button1.TabIndex = 0
			Me.Button1.Text = "A4 Size"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(198, 23)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(128, 84)
			Me.Button2.TabIndex = 1
			Me.Button2.Text = "A5 Size"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Location = New Global.System.Drawing.Point(50, 126)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(128, 84)
			Me.Button3.TabIndex = 2
			Me.Button3.Text = "3 Inch Size"
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Location = New Global.System.Drawing.Point(198, 126)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(128, 84)
			Me.Button4.TabIndex = 3
			Me.Button4.Text = "4 Inch Size"
			Me.Button4.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 228)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(376, 14)
			Me.Label1.TabIndex = 4
			Me.Label1.Text = "Note : You must have to install the Visual Studio 2010 or upper edition to edit."
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(374, 243)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Button4)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedToolWindow
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmTempleteEdit"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Template Editor"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04005381 RID: 21377
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
