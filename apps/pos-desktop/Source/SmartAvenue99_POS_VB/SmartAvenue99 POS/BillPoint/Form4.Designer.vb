Namespace BillPoint
	' Token: 0x02000069 RID: 105
		Public Partial Class Form4
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001365 RID: 4965 RVA: 0x000D34B4 File Offset: 0x000D16B4
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

		' Token: 0x06001366 RID: 4966 RVA: 0x000D3504 File Offset: 0x000D1704
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.Form4))
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.lblCName = New Global.System.Windows.Forms.Label()
			Me.Panel6.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackColor = Global.System.Drawing.Color.White
			Me.Panel6.BackgroundImage = CType(componentResourceManager.GetObject("Panel6.BackgroundImage"), Global.System.Drawing.Image)
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Panel6.Controls.Add(Me.lblCName)
			Me.Panel6.Location = New Global.System.Drawing.Point(-6, -8)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(813, 466)
			Me.Panel6.TabIndex = 505
			Me.lblCName.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblCName.AutoSize = True
			Me.lblCName.Location = New Global.System.Drawing.Point(368, 400)
			Me.lblCName.Name = "lblCName"
			Me.lblCName.Size = New Global.System.Drawing.Size(52, 13)
			Me.lblCName.TabIndex = 503
			Me.lblCName.Text = "lblCName"
			Me.lblCName.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Name = "Form4"
			Me.Text = "Form4"
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000641 RID: 1601
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
