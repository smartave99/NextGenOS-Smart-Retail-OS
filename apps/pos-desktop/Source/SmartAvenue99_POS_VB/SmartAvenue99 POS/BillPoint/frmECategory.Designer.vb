Namespace BillPoint
	' Token: 0x02000050 RID: 80
		Public Partial Class frmECategory
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000F26 RID: 3878 RVA: 0x000B5D94 File Offset: 0x000B3F94
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

		' Token: 0x06000F27 RID: 3879 RVA: 0x000B5DE4 File Offset: 0x000B3FE4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmECategory))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnRefress = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.DataGridViewImageColumn2 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.btnInsert = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.ID = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Description = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnUpdate = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.loading
			Me.PictureBox1.Location = New Global.System.Drawing.Point(43, 165)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(497, 229)
			Me.PictureBox1.TabIndex = 1701
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(565, 190)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(223, 35)
			Me.GelButton1.TabIndex = 1709
			Me.GelButton1.Text = "Sync with onlice all Category"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.btnRefress.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRefress.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnRefress.FlatAppearance.BorderSize = 0
			Me.btnRefress.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRefress.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRefress.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnRefress.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnRefress.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnRefress.Image = CType(componentResourceManager.GetObject("btnRefress.Image"), Global.System.Drawing.Image)
			Me.btnRefress.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRefress.Location = New Global.System.Drawing.Point(592, 275)
			Me.btnRefress.Name = "btnRefress"
			Me.btnRefress.Size = New Global.System.Drawing.Size(163, 34)
			Me.btnRefress.TabIndex = 1708
			Me.btnRefress.Text = "Refresh "
			Me.btnRefress.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRefress.UseVisualStyleBackColor = False
			Me.btnRefress.Visible = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(592, 151)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(106, 33)
			Me.btnSave.TabIndex = 1707
			Me.btnSave.Text = "Sync with onlice all Category"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.btnSave.Visible = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(606, 12)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(146, 113)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 1706
			Me.Picture.TabStop = False
			Me.DataGridViewImageColumn2.HeaderText = "OnlineUpdate"
			Me.DataGridViewImageColumn2.Image = Global.BillPoint.My.Resources.Resources._911
			Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
			Me.DataGridViewImageColumn2.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewImageColumn2.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.DataGridViewImageColumn1.HeaderText = "onlineInsert"
			Me.DataGridViewImageColumn1.Image = Global.BillPoint.My.Resources.Resources._11
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewImageColumn1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.CheckBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckBox2.AutoSize = True
			Me.CheckBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.CheckBox2.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.CheckBox2.Font = New Global.System.Drawing.Font("Arial", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox2.ForeColor = Global.System.Drawing.Color.Blue
			Me.CheckBox2.Location = New Global.System.Drawing.Point(609, 315)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(127, 32)
			Me.CheckBox2.TabIndex = 1705
			Me.CheckBox2.TabStop = False
			Me.CheckBox2.Text = "All (Mark/Unmark)"
			Me.CheckBox2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox2.UseVisualStyleBackColor = False
			Me.CheckBox2.Visible = False
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackgroundImage = Global.BillPoint.My.Resources.Resources.GiftCard
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.Location = New Global.System.Drawing.Point(103, 98)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(420, 400)
			Me.Panel6.TabIndex = 1704
			Me.Panel6.Visible = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(686, 131)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(66, 24)
			Me.BRemove.TabIndex = 1703
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.btnInsert.HeaderText = "onlineInsert"
			Me.btnInsert.Image = Global.BillPoint.My.Resources.Resources._11
			Me.btnInsert.Name = "btnInsert"
			Me.btnInsert.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnInsert.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnInsert.Visible = False
			Me.Column3.HeaderText = "Status"
			Me.Column3.Name = "Column3"
			Me.Column3.Width = 120
			Me.Column2.HeaderText = "(Mark/Unmark)"
			Me.Column2.Name = "Column2"
			Me.Column2.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column2.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column2.Visible = False
			Me.ID.HeaderText = "ID"
			Me.ID.Name = "ID"
			Me.Column1.HeaderText = "Photo"
			Me.Column1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column1.Name = "Column1"
			Me.Column1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Description.HeaderText = "Category"
			Me.Description.Name = "Description"
			Me.Description.Width = 200
			Me.btnUpdate.HeaderText = "OnlineUpdate"
			Me.btnUpdate.Image = Global.BillPoint.My.Resources.Resources._911
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnUpdate.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnUpdate.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Description, Me.Column1, Me.ID, Me.Column2, Me.Column3, Me.btnInsert, Me.btnUpdate })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 12)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 30
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(551, 510)
			Me.dgw.TabIndex = 1702
			Me.dgw.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(796, 534)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.btnRefress)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.CheckBox2)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Controls.Add(Me.BRemove)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Name = "frmECategory"
			Me.Text = "frmECategory"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000456 RID: 1110
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
