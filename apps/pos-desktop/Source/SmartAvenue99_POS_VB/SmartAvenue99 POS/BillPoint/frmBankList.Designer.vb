Namespace BillPoint
	' Token: 0x0200007A RID: 122
		Public Partial Class frmBankList
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001477 RID: 5239 RVA: 0x000DCC64 File Offset: 0x000DAE64
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

		' Token: 0x06001478 RID: 5240 RVA: 0x000DCCB4 File Offset: 0x000DAEB4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBankList))
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.btnClose = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.flpTables = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.lblControl = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(37, 22)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 397
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.btnClose.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnClose.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnClose.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnClose.FlatAppearance.BorderSize = 0
			Me.btnClose.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClose.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClose.Image = CType(componentResourceManager.GetObject("btnClose.Image"), Global.System.Drawing.Image)
			Me.btnClose.Location = New Global.System.Drawing.Point(754, 2)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New Global.System.Drawing.Size(52, 49)
			Me.btnClose.TabIndex = 400
			Me.btnClose.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClose.UseVisualStyleBackColor = False
			Me.Label5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label5.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 20.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(-4, 1)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(756, 50)
			Me.Label5.TabIndex = 399
			Me.Label5.Text = "List of Bank Account No"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.flpTables.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpTables.AutoScroll = True
			Me.flpTables.BackColor = Global.System.Drawing.Color.White
			Me.flpTables.Location = New Global.System.Drawing.Point(12, 56)
			Me.flpTables.Name = "flpTables"
			Me.flpTables.Size = New Global.System.Drawing.Size(778, 326)
			Me.flpTables.TabIndex = 398
			Me.lblControl.AutoSize = True
			Me.lblControl.Location = New Global.System.Drawing.Point(635, 22)
			Me.lblControl.Name = "lblControl"
			Me.lblControl.Size = New Global.System.Drawing.Size(40, 13)
			Me.lblControl.TabIndex = 406
			Me.lblControl.Text = "Control"
			Me.lblControl.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(801, 394)
			MyBase.Controls.Add(Me.lblControl)
			MyBase.Controls.Add(Me.lblSet)
			MyBase.Controls.Add(Me.btnClose)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.flpTables)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmBankList"
			Me.Text = "frmBankList"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040006F4 RID: 1780
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
