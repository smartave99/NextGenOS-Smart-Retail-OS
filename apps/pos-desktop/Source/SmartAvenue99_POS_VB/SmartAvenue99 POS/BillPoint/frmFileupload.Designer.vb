Namespace BillPoint
	' Token: 0x02000111 RID: 273
		Public Partial Class frmFileupload
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002DCD RID: 11725 RVA: 0x001C6990 File Offset: 0x001C4B90
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

		' Token: 0x06002DCE RID: 11726 RVA: 0x001C69E0 File Offset: 0x001C4BE0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.Button1.Location = New Global.System.Drawing.Point(331, 147)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 0
			Me.Button1.Text = "Button1"
			Me.Button1.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Name = "frmFileupload"
			Me.Text = "frmFileupload"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400138C RID: 5004
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
