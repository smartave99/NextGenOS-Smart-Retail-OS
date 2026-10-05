Namespace BillPoint
	' Token: 0x02000601 RID: 1537
		Public Partial Class FrmStockOutPrint
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012B56 RID: 76630 RVA: 0x00ABDED4 File Offset: 0x00ABC0D4
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

		' Token: 0x06012B57 RID: 76631 RVA: 0x00ABDF24 File Offset: 0x00ABC124
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.FrmStockOutPrint))
			Me.ListView2 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader76 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader39 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			MyBase.SuspendLayout()
			Me.ListView2.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			Me.ListView2.CheckBoxes = True
			Me.ListView2.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader76, Me.ColumnHeader39 })
			Me.ListView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView2.FullRowSelect = True
			Me.ListView2.GridLines = True
			Me.ListView2.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.ListView2.HideSelection = False
			Me.ListView2.Location = New Global.System.Drawing.Point(9, 49)
			Me.ListView2.MultiSelect = False
			Me.ListView2.Name = "ListView2"
			Me.ListView2.Size = New Global.System.Drawing.Size(329, 583)
			Me.ListView2.TabIndex = 551
			Me.ListView2.TabStop = False
			Me.ListView2.UseCompatibleStateImageBehavior = False
			Me.ListView2.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader76.Text = "TokenNo"
			Me.ColumnHeader76.Width = 227
			Me.ColumnHeader39.Text = "Product Item"
			Me.ColumnHeader39.Width = 100
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(6, 5)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label2.TabIndex = 549
			Me.Label2.Text = "Token Search :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(9, 21)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(164, 21)
			Me.TextBox1.TabIndex = 548
			Me.TextBox1.TabStop = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Blue
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.Blue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(-16, 5)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(159, 38)
			Me.GelButton1.TabIndex = 550
			Me.GelButton1.Text = "&Show All Token"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.SystemColors.Highlight
			Me.GelButton2.GradientTop = Global.System.Drawing.SystemColors.HotTrack
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(149, 5)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(184, 38)
			Me.GelButton2.TabIndex = 553
			Me.GelButton2.Text = "&Print"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(1420, 8)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 556
			Me.Label6.Text = "Records"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(1333, 8)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 555
			Me.Label7.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(1360, 5)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(60, 20)
			Me.txtTopResult.TabIndex = 554
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 701)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtTopResult)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.ListView2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "FrmStockOutPrint"
			Me.Text = "FrmStockOutPrint"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04007098 RID: 28824
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
