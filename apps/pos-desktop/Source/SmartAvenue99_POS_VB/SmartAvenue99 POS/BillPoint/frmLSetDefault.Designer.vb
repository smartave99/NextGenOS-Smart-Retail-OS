Namespace BillPoint
	' Token: 0x0200012A RID: 298
		Public Partial Class frmLSetDefault
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060033A8 RID: 13224 RVA: 0x001FE684 File Offset: 0x001FC884
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

		' Token: 0x060033A9 RID: 13225 RVA: 0x001FE6D4 File Offset: 0x001FC8D4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLSetDefault))
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.lbltype = New Global.System.Windows.Forms.Label()
			MyBase.SuspendLayout()
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(183, 19)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(42, 13)
			Me.Label2.TabIndex = 1772
			Me.Label2.Text = "Points :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(227, 15)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(93, 20)
			Me.TextBox1.TabIndex = 1771
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "per", "point" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(93, 15)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(87, 21)
			Me.ComboBox1.TabIndex = 1768
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(19, 19)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label1.TabIndex = 1769
			Me.Label1.Text = "Select Mode :"
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(343, 12)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(147, 43)
			Me.GelButton3.TabIndex = 1770
			Me.GelButton3.Text = "Set Is Default "
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.lbltype.AutoSize = True
			Me.lbltype.Location = New Global.System.Drawing.Point(90, 59)
			Me.lbltype.Name = "lbltype"
			Me.lbltype.Size = New Global.System.Drawing.Size(17, 13)
			Me.lbltype.TabIndex = 1773
			Me.lbltype.Text = "xx"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(514, 81)
			MyBase.Controls.Add(Me.lbltype)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.ComboBox1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Name = "frmLSetDefault"
			Me.Text = "frmLSetDefault"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04001645 RID: 5701
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
