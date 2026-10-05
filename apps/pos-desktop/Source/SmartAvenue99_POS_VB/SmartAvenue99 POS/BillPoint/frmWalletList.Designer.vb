Namespace BillPoint
	' Token: 0x02000215 RID: 533
		Public Partial Class frmWalletList
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060099CE RID: 39374 RVA: 0x006E436C File Offset: 0x006E256C
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

		' Token: 0x060099CF RID: 39375 RVA: 0x006E43BC File Offset: 0x006E25BC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmWalletList))
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.flpTables = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.btnClose = New Global.System.Windows.Forms.Button()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.lblControl = New Global.System.Windows.Forms.Label()
			Me.PictureBox6 = New Global.System.Windows.Forms.PictureBox()
			Me.lblGTotal = New Global.System.Windows.Forms.Label()
			CType(Me.PictureBox6, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(37, 19)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 401
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.Label5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label5.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 20.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(-4, -2)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(755, 50)
			Me.Label5.TabIndex = 403
			Me.Label5.Text = "List of Wallets"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.flpTables.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpTables.AutoScroll = True
			Me.flpTables.BackColor = Global.System.Drawing.Color.White
			Me.flpTables.Location = New Global.System.Drawing.Point(12, 53)
			Me.flpTables.Name = "flpTables"
			Me.flpTables.Size = New Global.System.Drawing.Size(777, 126)
			Me.flpTables.TabIndex = 402
			Me.btnClose.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnClose.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnClose.DialogResult = Global.System.Windows.Forms.DialogResult.Cancel
			Me.btnClose.FlatAppearance.BorderSize = 0
			Me.btnClose.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClose.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClose.Image = CType(componentResourceManager.GetObject("btnClose.Image"), Global.System.Drawing.Image)
			Me.btnClose.Location = New Global.System.Drawing.Point(753, -1)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New Global.System.Drawing.Size(52, 49)
			Me.btnClose.TabIndex = 404
			Me.btnClose.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClose.UseVisualStyleBackColor = False
			Me.Timer1.Interval = 1000
			Me.lblControl.AutoSize = True
			Me.lblControl.Location = New Global.System.Drawing.Point(602, 19)
			Me.lblControl.Name = "lblControl"
			Me.lblControl.Size = New Global.System.Drawing.Size(40, 13)
			Me.lblControl.TabIndex = 405
			Me.lblControl.Text = "Control"
			Me.lblControl.Visible = False
			Me.PictureBox6.Location = New Global.System.Drawing.Point(12, 187)
			Me.PictureBox6.Name = "PictureBox6"
			Me.PictureBox6.Size = New Global.System.Drawing.Size(220, 187)
			Me.PictureBox6.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox6.TabIndex = 1816
			Me.PictureBox6.TabStop = False
			Me.PictureBox6.Visible = False
			Me.lblGTotal.AutoSize = True
			Me.lblGTotal.Location = New Global.System.Drawing.Point(511, 19)
			Me.lblGTotal.Name = "lblGTotal"
			Me.lblGTotal.Size = New Global.System.Drawing.Size(49, 13)
			Me.lblGTotal.TabIndex = 1817
			Me.lblGTotal.Text = "lblGTotal"
			Me.lblGTotal.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 394)
			MyBase.Controls.Add(Me.lblGTotal)
			MyBase.Controls.Add(Me.PictureBox6)
			MyBase.Controls.Add(Me.lblControl)
			MyBase.Controls.Add(Me.lblSet)
			MyBase.Controls.Add(Me.btnClose)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.flpTables)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmWalletList"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Wallet List"
			CType(Me.PictureBox6, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400441A RID: 17434
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
