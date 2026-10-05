Namespace BillPoint
	' Token: 0x020001FF RID: 511
		Public Partial Class frmSerialno_popup
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600935A RID: 37722 RVA: 0x006A9F74 File Offset: 0x006A8174
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

		' Token: 0x0600935B RID: 37723 RVA: 0x006A9FC4 File Offset: 0x006A81C4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.txtSerialno = New Global.System.Windows.Forms.TextBox()
			Me.btnUpdate = New Global.System.Windows.Forms.Button()
			Me.txtSerialno2 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.txtSerialno.Location = New Global.System.Drawing.Point(31, 57)
			Me.txtSerialno.Name = "txtSerialno"
			Me.txtSerialno.Size = New Global.System.Drawing.Size(193, 20)
			Me.txtSerialno.TabIndex = 0
			Me.btnUpdate.Location = New Global.System.Drawing.Point(31, 92)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnUpdate.TabIndex = 1
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.UseVisualStyleBackColor = True
			Me.txtSerialno2.Location = New Global.System.Drawing.Point(230, 57)
			Me.txtSerialno2.Name = "txtSerialno2"
			Me.txtSerialno2.Size = New Global.System.Drawing.Size(193, 20)
			Me.txtSerialno2.TabIndex = 2
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(28, 41)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label1.TabIndex = 3
			Me.Label1.Text = "Serial No. 1"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(227, 41)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Serial No. 2"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(448, 153)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtSerialno2)
			MyBase.Controls.Add(Me.btnUpdate)
			MyBase.Controls.Add(Me.txtSerialno)
			MyBase.Name = "frmSerialno_popup"
			Me.Text = "frmSerialno_popup"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004145 RID: 16709
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
