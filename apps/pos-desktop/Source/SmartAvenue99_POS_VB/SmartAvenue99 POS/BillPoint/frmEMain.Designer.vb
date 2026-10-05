Namespace BillPoint
	' Token: 0x02000055 RID: 85
		Public Partial Class frmEMain
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000FBD RID: 4029 RVA: 0x000BA6A4 File Offset: 0x000B88A4
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

		' Token: 0x06000FBE RID: 4030 RVA: 0x000BA6F4 File Offset: 0x000B88F4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEMain))
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Button16 = New Global.GelButtons.GelButton()
			Me.Button10 = New Global.GelButtons.GelButton()
			MyBase.SuspendLayout()
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(239, 12)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1805
			Me.lblUser.Text = "Label3"
			Me.lblUser.Visible = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.SystemColors.MenuBar
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(12, 118)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(166, 47)
			Me.GelButton2.TabIndex = 1804
			Me.GelButton2.Text = "Product"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.SystemColors.MenuBar
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(12, 65)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(166, 47)
			Me.GelButton1.TabIndex = 1803
			Me.GelButton1.Text = "SubCategory"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Button16.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button16.BackColor = Global.System.Drawing.SystemColors.MenuBar
			Me.Button16.FlatAppearance.BorderSize = 0
			Me.Button16.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button16.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button16.ForeColor = Global.System.Drawing.Color.White
			Me.Button16.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button16.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button16.Image = CType(componentResourceManager.GetObject("Button16.Image"), Global.System.Drawing.Image)
			Me.Button16.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button16.Location = New Global.System.Drawing.Point(12, 12)
			Me.Button16.Name = "Button16"
			Me.Button16.Size = New Global.System.Drawing.Size(166, 47)
			Me.Button16.TabIndex = 1801
			Me.Button16.Text = "Category"
			Me.Button16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button16.UseVisualStyleBackColor = False
			Me.Button10.Anchor = Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button10.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button10.FlatAppearance.BorderSize = 0
			Me.Button10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button10.ForeColor = Global.System.Drawing.Color.White
			Me.Button10.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button10.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button10.Image = CType(componentResourceManager.GetObject("Button10.Image"), Global.System.Drawing.Image)
			Me.Button10.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button10.Location = New Global.System.Drawing.Point(12, 171)
			Me.Button10.Name = "Button10"
			Me.Button10.Size = New Global.System.Drawing.Size(166, 51)
			Me.Button10.TabIndex = 1802
			Me.Button10.Text = "Order"
			Me.Button10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button10.UseVisualStyleBackColor = False
			Me.Button10.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Button16)
			MyBase.Controls.Add(Me.Button10)
			MyBase.Name = "frmEMain"
			Me.Text = "frmEMain"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000496 RID: 1174
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
