Namespace BillPoint
	' Token: 0x02000059 RID: 89
		Public Partial Class frmESubCategory
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060010E8 RID: 4328 RVA: 0x000C1F38 File Offset: 0x000C0138
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

		' Token: 0x060010E9 RID: 4329 RVA: 0x000C1F88 File Offset: 0x000C0188
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmESubCategory))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.DataGridViewImageColumn2 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.btnUpdate = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.CID = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Description = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.btnInsert = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.loading
			Me.PictureBox1.InitialImage = Global.BillPoint.My.Resources.Resources.loading
			Me.PictureBox1.Location = New Global.System.Drawing.Point(74, 159)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(509, 229)
			Me.PictureBox1.TabIndex = 1700
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
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
			Me.btnSave.Location = New Global.System.Drawing.Point(649, 164)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(234, 37)
			Me.btnSave.TabIndex = 1706
			Me.btnSave.Text = "Sync with onlice all Category"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
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
			Me.CheckBox2.Location = New Global.System.Drawing.Point(474, 308)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(127, 32)
			Me.CheckBox2.TabIndex = 1704
			Me.CheckBox2.TabStop = False
			Me.CheckBox2.Text = "All (Mark/Unmark)"
			Me.CheckBox2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox2.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(771, 134)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(66, 24)
			Me.BRemove.TabIndex = 1702
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Column4.HeaderText = "SubID"
			Me.Column4.Name = "Column4"
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(691, 15)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(146, 113)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 1705
			Me.Picture.TabStop = False
			Me.btnUpdate.HeaderText = "OnlineUpdate"
			Me.btnUpdate.Image = Global.BillPoint.My.Resources.Resources._911
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnUpdate.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnUpdate.Visible = False
			Me.Column3.HeaderText = "Status"
			Me.Column3.Name = "Column3"
			Me.Column2.HeaderText = "(Mark/Unmark)"
			Me.Column2.Name = "Column2"
			Me.Column2.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column2.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column2.Visible = False
			Me.CID.HeaderText = "CID"
			Me.CID.Name = "CID"
			Me.Column1.HeaderText = "Photo"
			Me.Column1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column1.Name = "Column1"
			Me.Column1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Description.HeaderText = "Category"
			Me.Description.Name = "Description"
			Me.Description.Width = 175
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
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Description, Me.Column1, Me.CID, Me.Column2, Me.Column3, Me.btnInsert, Me.btnUpdate, Me.Column4 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(12, 10)
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
			Me.dgw.RowHeadersWidth = 35
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(615, 517)
			Me.dgw.TabIndex = 1701
			Me.dgw.TabStop = False
			Me.btnInsert.HeaderText = "onlineInsert"
			Me.btnInsert.Image = Global.BillPoint.My.Resources.Resources._11
			Me.btnInsert.Name = "btnInsert"
			Me.btnInsert.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnInsert.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnInsert.Visible = False
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackgroundImage = Global.BillPoint.My.Resources.Resources.GiftCard
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.Location = New Global.System.Drawing.Point(149, 62)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(400, 400)
			Me.Panel6.TabIndex = 1703
			Me.Panel6.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(895, 536)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.CheckBox2)
			MyBase.Controls.Add(Me.BRemove)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Name = "frmESubCategory"
			Me.Text = "frmESubCategory"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400051B RID: 1307
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
