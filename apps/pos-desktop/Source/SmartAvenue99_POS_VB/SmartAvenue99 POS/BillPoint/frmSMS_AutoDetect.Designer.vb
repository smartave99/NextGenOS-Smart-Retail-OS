Namespace BillPoint
	' Token: 0x0200008A RID: 138
		Public Partial Class frmSMS_AutoDetect
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060016F2 RID: 5874 RVA: 0x000FAE7C File Offset: 0x000F907C
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

		' Token: 0x060016F3 RID: 5875 RVA: 0x000FAECC File Offset: 0x000F90CC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.txtOutput = New Global.System.Windows.Forms.TextBox()
			Me.btnStartListener = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.txtOutput.Location = New Global.System.Drawing.Point(230, 102)
			Me.txtOutput.Multiline = True
			Me.txtOutput.Name = "txtOutput"
			Me.txtOutput.Size = New Global.System.Drawing.Size(294, 336)
			Me.txtOutput.TabIndex = 0
			Me.btnStartListener.Location = New Global.System.Drawing.Point(404, 61)
			Me.btnStartListener.Name = "btnStartListener"
			Me.btnStartListener.Size = New Global.System.Drawing.Size(120, 35)
			Me.btnStartListener.TabIndex = 1
			Me.btnStartListener.Text = "Button1"
			Me.btnStartListener.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.btnStartListener)
			MyBase.Controls.Add(Me.txtOutput)
			MyBase.Name = "frmSMS_AutoDetect"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "frmSMS_AutoDetect"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000893 RID: 2195
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
