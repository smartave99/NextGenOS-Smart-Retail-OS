Namespace BillPoint
	' Token: 0x0200007B RID: 123
		Public Partial Class frmBillStyle
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001489 RID: 5257 RVA: 0x000DDE40 File Offset: 0x000DC040
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

		' Token: 0x0600148A RID: 5258 RVA: 0x000DDE90 File Offset: 0x000DC090
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBillStyle))
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.RA4 = New Global.System.Windows.Forms.RadioButton()
			Me.RA5 = New Global.System.Windows.Forms.RadioButton()
			Me.R3Inch = New Global.System.Windows.Forms.RadioButton()
			Me.RAll = New Global.System.Windows.Forms.RadioButton()
			Me.btnCash = New Global.GelButtons.GelButton()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnTwo = New Global.GelButtons.GelButton()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(12, 36)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 29
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(210, 699)
			Me.dgw.TabIndex = 44
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "Sr"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.FillWeight = 163.6364F
			Me.Column2.HeaderText = "Bill Style Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 180
			Me.Column3.HeaderText = "Column3"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Visible = False
			Me.Column4.HeaderText = "Column4"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.RA4.AutoSize = True
			Me.RA4.Location = New Global.System.Drawing.Point(13, 13)
			Me.RA4.Name = "RA4"
			Me.RA4.Size = New Global.System.Drawing.Size(41, 17)
			Me.RA4.TabIndex = 45
			Me.RA4.TabStop = True
			Me.RA4.Text = "A4 "
			Me.RA4.UseVisualStyleBackColor = True
			Me.RA5.AutoSize = True
			Me.RA5.Location = New Global.System.Drawing.Point(69, 13)
			Me.RA5.Name = "RA5"
			Me.RA5.Size = New Global.System.Drawing.Size(38, 17)
			Me.RA5.TabIndex = 46
			Me.RA5.TabStop = True
			Me.RA5.Text = "A5"
			Me.RA5.UseVisualStyleBackColor = True
			Me.R3Inch.AutoSize = True
			Me.R3Inch.Location = New Global.System.Drawing.Point(128, 13)
			Me.R3Inch.Name = "R3Inch"
			Me.R3Inch.Size = New Global.System.Drawing.Size(52, 17)
			Me.R3Inch.TabIndex = 47
			Me.R3Inch.TabStop = True
			Me.R3Inch.Text = "3Inch"
			Me.R3Inch.UseVisualStyleBackColor = True
			Me.RAll.AutoSize = True
			Me.RAll.Location = New Global.System.Drawing.Point(186, 13)
			Me.RAll.Name = "RAll"
			Me.RAll.Size = New Global.System.Drawing.Size(36, 17)
			Me.RAll.TabIndex = 48
			Me.RAll.TabStop = True
			Me.RAll.Text = "All"
			Me.RAll.UseVisualStyleBackColor = True
			Me.btnCash.Anchor = Global.System.Windows.Forms.AnchorStyles.Top
			Me.btnCash.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnCash.FlatAppearance.BorderSize = 0
			Me.btnCash.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCash.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.btnCash.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnCash.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnCash.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnCash.Image = CType(componentResourceManager.GetObject("btnCash.Image"), Global.System.Drawing.Image)
			Me.btnCash.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnCash.Location = New Global.System.Drawing.Point(531, 9)
			Me.btnCash.Name = "btnCash"
			Me.btnCash.Size = New Global.System.Drawing.Size(157, 29)
			Me.btnCash.TabIndex = 49
			Me.btnCash.Text = "Apply"
			Me.btnCash.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnCash.UseVisualStyleBackColor = False
			Me.PictureBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.PictureBox1.Location = New Global.System.Drawing.Point(228, 48)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(460, 687)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 50
			Me.PictureBox1.TabStop = False
			Me.btnTwo.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnTwo.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnTwo.FlatAppearance.BorderSize = 0
			Me.btnTwo.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnTwo.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnTwo.ForeColor = Global.System.Drawing.Color.White
			Me.btnTwo.GradientBottom = Global.System.Drawing.Color.SteelBlue
			Me.btnTwo.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnTwo.Location = New Global.System.Drawing.Point(379, 9)
			Me.btnTwo.Name = "btnTwo"
			Me.btnTwo.Size = New Global.System.Drawing.Size(146, 29)
			Me.btnTwo.TabIndex = 442
			Me.btnTwo.Text = "Printer Setting"
			Me.btnTwo.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			Me.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			MyBase.ClientSize = New Global.System.Drawing.Size(709, 747)
			MyBase.Controls.Add(Me.btnTwo)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.btnCash)
			MyBase.Controls.Add(Me.RAll)
			MyBase.Controls.Add(Me.R3Inch)
			MyBase.Controls.Add(Me.RA5)
			MyBase.Controls.Add(Me.RA4)
			MyBase.Controls.Add(Me.dgw)
			MyBase.ImeMode = Global.System.Windows.Forms.ImeMode.Hangul
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmBillStyle"
			Me.Text = "frmBillStyle"
			MyBase.TransparencyKey = Global.System.Drawing.Color.Red
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040006FB RID: 1787
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
