Namespace BillPoint
	' Token: 0x020000BC RID: 188
		Public Partial Class frmProductNew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001ACA RID: 6858 RVA: 0x00124F50 File Offset: 0x00123150
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

		' Token: 0x06001ACB RID: 6859 RVA: 0x00124FA0 File Offset: 0x001231A0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductNew))
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn55 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn57 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewComboBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnUpdatePrice = New Global.System.Windows.Forms.Button()
			Me.lblCategoryId = New Global.System.Windows.Forms.Label()
			Me.btnNewItem = New Global.System.Windows.Forms.Button()
			Me.txtBar = New Global.System.Windows.Forms.TextBox()
			Me.txtID_temp = New Global.System.Windows.Forms.TextBox()
			Me.strStax = New Global.System.Windows.Forms.TextBox()
			Me.strPtax = New Global.System.Windows.Forms.TextBox()
			Me.Photo = New Global.System.Windows.Forms.PictureBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.settingdefault = New Global.System.Windows.Forms.Button()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.GelButton3 = New Global.System.Windows.Forms.Button()
			Me.GelButtonNewRecord = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.GelButtons.GelButton()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn55, Me.Column4, Me.DataGridViewTextBoxColumn57, Me.DataGridViewComboBoxColumn1, Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column6, Me.Column7 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.Location = New Global.System.Drawing.Point(12, 48)
			Me.dgw.Name = "dgw"
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1207, 489)
			Me.dgw.TabIndex = 1828
			Me.DataGridViewTextBoxColumn55.DataPropertyName = "PID1"
			Me.DataGridViewTextBoxColumn55.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
			Me.DataGridViewTextBoxColumn55.Visible = False
			Me.Column4.HeaderText = "ProductCode"
			Me.Column4.Name = "Column4"
			Me.Column4.Visible = False
			Me.DataGridViewTextBoxColumn57.DataPropertyName = "ProductName1"
			Me.DataGridViewTextBoxColumn57.FillWeight = 208.1594F
			Me.DataGridViewTextBoxColumn57.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
			Me.DataGridViewTextBoxColumn57.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn57.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewComboBoxColumn1.FillWeight = 41.63189F
			Me.DataGridViewComboBoxColumn1.HeaderText = "Barcode"
			Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
			Me.Column1.FillWeight = 104.0797F
			Me.Column1.HeaderText = "Purchase Price"
			Me.Column1.Name = "Column1"
			Me.Column1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.Column2.FillWeight = 104.0797F
			Me.Column2.HeaderText = "Sale Price"
			Me.Column2.Name = "Column2"
			Me.Column3.HeaderText = "TempBarcode"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Visible = False
			Me.Column5.HeaderText = "TempPPrice"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Visible = False
			Me.Column6.HeaderText = "SPrice"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Visible = False
			Me.Column7.HeaderText = "Quantity"
			Me.Column7.Name = "Column7"
			Me.btnUpdatePrice.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdatePrice.Location = New Global.System.Drawing.Point(497, 543)
			Me.btnUpdatePrice.Name = "btnUpdatePrice"
			Me.btnUpdatePrice.Size = New Global.System.Drawing.Size(187, 47)
			Me.btnUpdatePrice.TabIndex = 1829
			Me.btnUpdatePrice.Text = "Update Price"
			Me.btnUpdatePrice.UseVisualStyleBackColor = True
			Me.btnUpdatePrice.Visible = False
			Me.lblCategoryId.AutoSize = True
			Me.lblCategoryId.Location = New Global.System.Drawing.Point(428, 4)
			Me.lblCategoryId.Name = "lblCategoryId"
			Me.lblCategoryId.Size = New Global.System.Drawing.Size(68, 13)
			Me.lblCategoryId.TabIndex = 1830
			Me.lblCategoryId.Text = "lblCategoryId"
			Me.lblCategoryId.Visible = False
			Me.btnNewItem.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNewItem.Location = New Global.System.Drawing.Point(391, 9)
			Me.btnNewItem.Name = "btnNewItem"
			Me.btnNewItem.Size = New Global.System.Drawing.Size(137, 38)
			Me.btnNewItem.TabIndex = 1831
			Me.btnNewItem.Text = "New Item"
			Me.btnNewItem.UseVisualStyleBackColor = True
			Me.btnNewItem.Visible = False
			Me.txtBar.Location = New Global.System.Drawing.Point(584, 22)
			Me.txtBar.Name = "txtBar"
			Me.txtBar.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBar.TabIndex = 1832
			Me.txtBar.Visible = False
			Me.txtID_temp.Location = New Global.System.Drawing.Point(714, 22)
			Me.txtID_temp.Name = "txtID_temp"
			Me.txtID_temp.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtID_temp.TabIndex = 1833
			Me.txtID_temp.Visible = False
			Me.strStax.Location = New Global.System.Drawing.Point(830, 22)
			Me.strStax.Name = "strStax"
			Me.strStax.Size = New Global.System.Drawing.Size(100, 20)
			Me.strStax.TabIndex = 1834
			Me.strStax.Visible = False
			Me.strPtax.Location = New Global.System.Drawing.Point(652, 1)
			Me.strPtax.Name = "strPtax"
			Me.strPtax.Size = New Global.System.Drawing.Size(100, 20)
			Me.strPtax.TabIndex = 1835
			Me.strPtax.Visible = False
			Me.Photo.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Photo.Location = New Global.System.Drawing.Point(32, 558)
			Me.Photo.Name = "Photo"
			Me.Photo.Size = New Global.System.Drawing.Size(26, 22)
			Me.Photo.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Photo.TabIndex = 1836
			Me.Photo.TabStop = False
			Me.Photo.Visible = False
			Me.pbgiftqr.Image = Global.BillPoint.My.Resources.Resources._12
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(74, 558)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(26, 22)
			Me.pbgiftqr.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbgiftqr.TabIndex = 1837
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.settingdefault.AccessibleRole = Global.System.Windows.Forms.AccessibleRole.TitleBar
			Me.settingdefault.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.settingdefault.Location = New Global.System.Drawing.Point(271, 9)
			Me.settingdefault.Name = "settingdefault"
			Me.settingdefault.Size = New Global.System.Drawing.Size(114, 38)
			Me.settingdefault.TabIndex = 1838
			Me.settingdefault.Text = "Setting Default"
			Me.settingdefault.UseVisualStyleBackColor = True
			Me.settingdefault.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(161, 22)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1839
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(93, 22)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1840
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackgroundImage = Global.BillPoint.My.Resources.Resources.Set_Default_copy_1
			Me.GelButton3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Location = New Global.System.Drawing.Point(958, 4)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(128, 41)
			Me.GelButton3.TabIndex = 1841
			Me.GelButton3.UseVisualStyleBackColor = True
			Me.GelButtonNewRecord.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButtonNewRecord.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.GelButtonNewRecord.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButtonNewRecord.FlatAppearance.BorderSize = 0
			Me.GelButtonNewRecord.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButtonNewRecord.Location = New Global.System.Drawing.Point(1091, 4)
			Me.GelButtonNewRecord.Name = "GelButtonNewRecord"
			Me.GelButtonNewRecord.Size = New Global.System.Drawing.Size(128, 41)
			Me.GelButtonNewRecord.TabIndex = 1842
			Me.GelButtonNewRecord.UseVisualStyleBackColor = True
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(1047, 543)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(172, 43)
			Me.btnSave.TabIndex = 1843
			Me.btnSave.Text = "Update Price"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1231, 592)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.GelButtonNewRecord)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.settingdefault)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.Photo)
			MyBase.Controls.Add(Me.strPtax)
			MyBase.Controls.Add(Me.strStax)
			MyBase.Controls.Add(Me.txtID_temp)
			MyBase.Controls.Add(Me.txtBar)
			MyBase.Controls.Add(Me.btnNewItem)
			MyBase.Controls.Add(Me.lblCategoryId)
			MyBase.Controls.Add(Me.btnUpdatePrice)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Name = "frmProductNew"
			Me.Text = "Product New & Update"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000A8D RID: 2701
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
