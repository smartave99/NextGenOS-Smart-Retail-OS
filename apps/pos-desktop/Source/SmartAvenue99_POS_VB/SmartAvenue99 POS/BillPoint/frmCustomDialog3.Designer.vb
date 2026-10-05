Namespace BillPoint
	' Token: 0x0200033C RID: 828
		Public Partial Class frmCustomDialog3
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C132 RID: 49458 RVA: 0x007ADD94 File Offset: 0x007ABF94
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

		' Token: 0x0600C133 RID: 49459 RVA: 0x007ADDE4 File Offset: 0x007ABFE4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnOK = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 26.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(18, 36)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(416, 95)
			Me.Label2.TabIndex = 33
			Me.Label2.Text = "WhatsApp Message Sent Successfully"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.btnOK.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnOK.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnOK.Location = New Global.System.Drawing.Point(173, 163)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New Global.System.Drawing.Size(98, 62)
			Me.btnOK.TabIndex = 34
			Me.btnOK.Text = "OK"
			Me.btnOK.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.Aquamarine
			MyBase.ClientSize = New Global.System.Drawing.Size(450, 252)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.btnOK)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmCustomDialog3"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "frmCustomDialog3"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004D7B RID: 19835
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
