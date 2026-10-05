Namespace BillPoint
	' Token: 0x0200020D RID: 525
		Public Partial Class frmTest1
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060098B2 RID: 39090 RVA: 0x006D9C98 File Offset: 0x006D7E98
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

		' Token: 0x060098B3 RID: 39091 RVA: 0x006D9CE8 File Offset: 0x006D7EE8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.Panel16 = New Global.System.Windows.Forms.Panel()
			Me.Label130 = New Global.System.Windows.Forms.Label()
			Me.flpItems_BV = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.FlowLayoutPanel1 = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.flpItemsCategory = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.Panel16.SuspendLayout()
			Me.flpItems_BV.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel16.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel16.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.Panel16.Controls.Add(Me.Label130)
			Me.Panel16.Controls.Add(Me.flpItems_BV)
			Me.Panel16.Controls.Add(Me.flpItemsCategory)
			Me.Panel16.Location = New Global.System.Drawing.Point(7, 5)
			Me.Panel16.Name = "Panel16"
			Me.Panel16.Size = New Global.System.Drawing.Size(1122, 598)
			Me.Panel16.TabIndex = 10
			Me.Label130.AutoSize = True
			Me.Label130.Location = New Global.System.Drawing.Point(185, 552)
			Me.Label130.Name = "Label130"
			Me.Label130.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label130.TabIndex = 1714
			Me.Label130.Text = "Label1"
			Me.flpItems_BV.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpItems_BV.AutoScroll = True
			Me.flpItems_BV.BackColor = Global.System.Drawing.SystemColors.ControlLightLight
			Me.flpItems_BV.Controls.Add(Me.FlowLayoutPanel1)
			Me.flpItems_BV.Location = New Global.System.Drawing.Point(136, 85)
			Me.flpItems_BV.Name = "flpItems_BV"
			Me.flpItems_BV.Size = New Global.System.Drawing.Size(884, 329)
			Me.flpItems_BV.TabIndex = 475
			Me.FlowLayoutPanel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.FlowLayoutPanel1.BackColor = Global.System.Drawing.Color.Transparent
			Me.FlowLayoutPanel1.Location = New Global.System.Drawing.Point(3, 3)
			Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
			Me.FlowLayoutPanel1.Size = New Global.System.Drawing.Size(569, 0)
			Me.FlowLayoutPanel1.TabIndex = 476
			Me.flpItemsCategory.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpItemsCategory.AutoScroll = True
			Me.flpItemsCategory.Location = New Global.System.Drawing.Point(7, 7)
			Me.flpItemsCategory.Name = "flpItemsCategory"
			Me.flpItemsCategory.Size = New Global.System.Drawing.Size(1108, 72)
			Me.flpItemsCategory.TabIndex = 474
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1141, 605)
			MyBase.Controls.Add(Me.Panel16)
			MyBase.Name = "frmTest1"
			Me.Text = "Menu"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.Panel16.ResumeLayout(False)
			Me.Panel16.PerformLayout()
			Me.flpItems_BV.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004389 RID: 17289
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
