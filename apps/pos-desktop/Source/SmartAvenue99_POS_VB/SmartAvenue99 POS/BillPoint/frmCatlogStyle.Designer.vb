Namespace BillPoint
	' Token: 0x020000CB RID: 203
		Public Partial Class frmCatlogStyle
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002356 RID: 9046 RVA: 0x0016748C File Offset: 0x0016568C
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

		' Token: 0x06002357 RID: 9047 RVA: 0x001674DC File Offset: 0x001656DC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCatlogStyle))
			Me.dgwBill = New Global.System.Windows.Forms.DataGridView()
			Me.PictureBox5 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.DataGridViewTextBoxColumn46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn54 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgwBill.AllowUserToAddRows = False
			Me.dgwBill.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgwBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgwBill.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgwBill.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgwBill.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgwBill.ColumnHeadersHeight = 40
			Me.dgwBill.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn48, Me.DataGridViewTextBoxColumn54 })
			Me.dgwBill.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgwBill.EnableHeadersVisualStyles = False
			Me.dgwBill.GridColor = Global.System.Drawing.Color.White
			Me.dgwBill.Location = New Global.System.Drawing.Point(22, 54)
			Me.dgwBill.MultiSelect = False
			Me.dgwBill.Name = "dgwBill"
			Me.dgwBill.[ReadOnly] = True
			Me.dgwBill.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgwBill.RowHeadersWidth = 29
			Me.dgwBill.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgwBill.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgwBill.RowTemplate.Height = 20
			Me.dgwBill.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgwBill.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgwBill.Size = New Global.System.Drawing.Size(235, 605)
			Me.dgwBill.TabIndex = 450
			Me.dgwBill.TabStop = False
			Me.PictureBox5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.PictureBox5.Location = New Global.System.Drawing.Point(285, 54)
			Me.PictureBox5.Name = "PictureBox5"
			Me.PictureBox5.Size = New Global.System.Drawing.Size(838, 696)
			Me.PictureBox5.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox5.TabIndex = 451
			Me.PictureBox5.TabStop = False
			Me.GelButton11.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(953, 12)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(170, 29)
			Me.GelButton11.TabIndex = 453
			Me.GelButton11.Text = "Apply"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.DataGridViewTextBoxColumn46.HeaderText = "Sr"
			Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
			Me.DataGridViewTextBoxColumn46.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn46.Visible = False
			Me.DataGridViewTextBoxColumn48.FillWeight = 163.6364F
			Me.DataGridViewTextBoxColumn48.HeaderText = "Catalogue Style Set"
			Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
			Me.DataGridViewTextBoxColumn48.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn48.Width = 200
			Me.DataGridViewTextBoxColumn54.HeaderText = "Column4"
			Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
			Me.DataGridViewTextBoxColumn54.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ControlLightLight
			MyBase.ClientSize = New Global.System.Drawing.Size(1159, 753)
			MyBase.Controls.Add(Me.GelButton11)
			MyBase.Controls.Add(Me.dgwBill)
			MyBase.Controls.Add(Me.PictureBox5)
			MyBase.Name = "frmCatlogStyle"
			Me.Text = "frmCatlogStyle"
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000E70 RID: 3696
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
