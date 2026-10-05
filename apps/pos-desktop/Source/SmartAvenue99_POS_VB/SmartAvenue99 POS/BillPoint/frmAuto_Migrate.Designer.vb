Namespace BillPoint
	' Token: 0x02000072 RID: 114
		Public Partial Class frmAuto_Migrate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060013E6 RID: 5094 RVA: 0x000D6770 File Offset: 0x000D4970
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

		' Token: 0x060013E7 RID: 5095 RVA: 0x000D67C0 File Offset: 0x000D49C0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.lblProgress = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblLastSynchronization = New Global.System.Windows.Forms.Label()
			Me.lblSyncStatus = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.lblSyncTrigger = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.Button4.Location = New Global.System.Drawing.Point(264, 148)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(149, 39)
			Me.Button4.TabIndex = 6
			Me.Button4.Text = "Data Synchronization"
			Me.Button4.UseVisualStyleBackColor = True
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(36, 119)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(614, 23)
			Me.ProgressBar1.TabIndex = 7
			Me.lblProgress.AutoSize = True
			Me.lblProgress.Location = New Global.System.Drawing.Point(330, 125)
			Me.lblProgress.Name = "lblProgress"
			Me.lblProgress.Size = New Global.System.Drawing.Size(21, 13)
			Me.lblProgress.TabIndex = 8
			Me.lblProgress.Text = "0%"
			Me.Button1.BackColor = Global.System.Drawing.Color.Red
			Me.Button1.ForeColor = Global.System.Drawing.SystemColors.ActiveCaptionText
			Me.Button1.Location = New Global.System.Drawing.Point(264, 193)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(149, 39)
			Me.Button1.TabIndex = 9
			Me.Button1.Text = "Stop  Auto Data Synchronization"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(159, 47)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(244, 17)
			Me.Label1.TabIndex = 10
			Me.Label1.Text = "Last Synchronization(Date and Time) :"
			Me.lblLastSynchronization.AutoSize = True
			Me.lblLastSynchronization.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblLastSynchronization.ForeColor = Global.System.Drawing.Color.Red
			Me.lblLastSynchronization.Location = New Global.System.Drawing.Point(403, 47)
			Me.lblLastSynchronization.Name = "lblLastSynchronization"
			Me.lblLastSynchronization.Size = New Global.System.Drawing.Size(32, 17)
			Me.lblLastSynchronization.TabIndex = 11
			Me.lblLastSynchronization.Text = "0.00"
			Me.lblSyncStatus.AutoSize = True
			Me.lblSyncStatus.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblSyncStatus.ForeColor = Global.System.Drawing.Color.Red
			Me.lblSyncStatus.Location = New Global.System.Drawing.Point(403, 67)
			Me.lblSyncStatus.Name = "lblSyncStatus"
			Me.lblSyncStatus.Size = New Global.System.Drawing.Size(32, 17)
			Me.lblSyncStatus.TabIndex = 13
			Me.lblSyncStatus.Text = "0.00"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(300, 67)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(103, 17)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Current Status :"
			Me.lblSyncTrigger.AutoSize = True
			Me.lblSyncTrigger.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblSyncTrigger.ForeColor = Global.System.Drawing.Color.Red
			Me.lblSyncTrigger.Location = New Global.System.Drawing.Point(403, 90)
			Me.lblSyncTrigger.Name = "lblSyncTrigger"
			Me.lblSyncTrigger.Size = New Global.System.Drawing.Size(32, 17)
			Me.lblSyncTrigger.TabIndex = 15
			Me.lblSyncTrigger.Text = "0.00"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft YaHei UI", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(280, 90)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(123, 17)
			Me.Label5.TabIndex = 14
			Me.Label5.Text = "Last Trigger Type :"
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(627, 9)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(56, 13)
			Me.lblUserType.TabIndex = 317
			Me.lblUserType.Text = "User Type"
			Me.lblUserType.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(705, 323)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblSyncTrigger)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.lblSyncStatus)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.lblLastSynchronization)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.lblProgress)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.Button4)
			MyBase.Name = "frmAuto_Migrate"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Manual Data Synchronization"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040006A5 RID: 1701
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
