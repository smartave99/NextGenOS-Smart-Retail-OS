Namespace BillPoint
	' Token: 0x02000592 RID: 1426
		Public Partial Class frmCustomDialog2
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060116CA RID: 71370 RVA: 0x00A1AFA8 File Offset: 0x00A191A8
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

		' Token: 0x060116CB RID: 71371 RVA: 0x00A1AFF8 File Offset: 0x00A191F8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnOK = New Global.System.Windows.Forms.Button()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 21.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(51, 50)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(304, 40)
			Me.Label2.TabIndex = 31
			Me.Label2.Text = "Successfully changed."
			Me.btnOK.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnOK.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnOK.Location = New Global.System.Drawing.Point(149, 169)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New Global.System.Drawing.Size(98, 62)
			Me.btnOK.TabIndex = 32
			Me.btnOK.Text = "OK"
			Me.btnOK.UseVisualStyleBackColor = True
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.btnOK)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(401, 261)
			Me.Panel1.TabIndex = 33
			MyBase.AcceptButton = Me.btnOK
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(401, 261)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Name = "frmCustomDialog2"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006902 RID: 26882
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
