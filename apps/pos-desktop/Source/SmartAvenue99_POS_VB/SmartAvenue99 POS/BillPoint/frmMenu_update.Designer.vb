Namespace BillPoint
	' Token: 0x0200012C RID: 300
		Public Partial Class frmMenu_update
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003400 RID: 13312 RVA: 0x002011B4 File Offset: 0x001FF3B4
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

		' Token: 0x06003401 RID: 13313 RVA: 0x00201204 File Offset: 0x001FF404
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmMenu_update))
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cboxActive = New Global.System.Windows.Forms.ComboBox()
			Me.lblStatus = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtFormname = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtSubcategory = New Global.System.Windows.Forms.TextBox()
			Me.chkAuto = New Global.System.Windows.Forms.CheckBox()
			Me.lblSubcategory = New Global.System.Windows.Forms.Label()
			Me.cboxCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.lblId = New Global.System.Windows.Forms.Label()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtstatusvisible = New Global.System.Windows.Forms.TextBox()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.txtstatusvisible)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.cboxActive)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.txtFormname)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.txtSubcategory)
			Me.GroupBox1.Controls.Add(Me.chkAuto)
			Me.GroupBox1.Controls.Add(Me.cboxCategory)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 11)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(628, 114)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Select Menu Type"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(405, 27)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(83, 13)
			Me.Label4.TabIndex = 18
			Me.Label4.Text = "Is Not Active ? :"
			Me.cboxActive.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cboxActive.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cboxActive.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxActive.FormattingEnabled = True
			Me.cboxActive.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cboxActive.Items.AddRange(New Object() { "True", "False" })
			Me.cboxActive.Location = New Global.System.Drawing.Point(495, 23)
			Me.cboxActive.Name = "cboxActive"
			Me.cboxActive.Size = New Global.System.Drawing.Size(96, 21)
			Me.cboxActive.TabIndex = 17
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Location = New Global.System.Drawing.Point(727, 346)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Global.System.Drawing.Size(35, 13)
			Me.lblStatus.TabIndex = 16
			Me.lblStatus.Text = "status"
			Me.lblStatus.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(60, 80)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label3.TabIndex = 15
			Me.Label3.Text = "Form Name :"
			Me.txtFormname.Location = New Global.System.Drawing.Point(141, 77)
			Me.txtFormname.Name = "txtFormname"
			Me.txtFormname.Size = New Global.System.Drawing.Size(251, 20)
			Me.txtFormname.TabIndex = 14
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(52, 54)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(77, 13)
			Me.Label1.TabIndex = 13
			Me.Label1.Text = "Sub Category :"
			Me.txtSubcategory.Location = New Global.System.Drawing.Point(141, 51)
			Me.txtSubcategory.Name = "txtSubcategory"
			Me.txtSubcategory.Size = New Global.System.Drawing.Size(251, 20)
			Me.txtSubcategory.TabIndex = 12
			Me.chkAuto.AutoSize = True
			Me.chkAuto.Location = New Global.System.Drawing.Point(437, 91)
			Me.chkAuto.Name = "chkAuto"
			Me.chkAuto.Size = New Global.System.Drawing.Size(152, 17)
			Me.chkAuto.TabIndex = 11
			Me.chkAuto.Text = "Auto Detect Image Upload"
			Me.chkAuto.UseVisualStyleBackColor = True
			Me.lblSubcategory.AutoSize = True
			Me.lblSubcategory.Location = New Global.System.Drawing.Point(589, 346)
			Me.lblSubcategory.Name = "lblSubcategory"
			Me.lblSubcategory.Size = New Global.System.Drawing.Size(68, 13)
			Me.lblSubcategory.TabIndex = 10
			Me.lblSubcategory.Text = "SubCategory"
			Me.lblSubcategory.Visible = False
			Me.cboxCategory.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cboxCategory.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cboxCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cboxCategory.FormattingEnabled = True
			Me.cboxCategory.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cboxCategory.Location = New Global.System.Drawing.Point(141, 23)
			Me.cboxCategory.Name = "cboxCategory"
			Me.cboxCategory.Size = New Global.System.Drawing.Size(251, 21)
			Me.cboxCategory.TabIndex = 8
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(74, 27)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "Category :"
			Me.lblId.AutoSize = True
			Me.lblId.Location = New Global.System.Drawing.Point(674, 346)
			Me.lblId.Name = "lblId"
			Me.lblId.Size = New Global.System.Drawing.Size(24, 13)
			Me.lblId.TabIndex = 6
			Me.lblId.Text = "ID :"
			Me.lblId.Visible = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			Me.DataGridView1.AllowUserToOrderColumns = True
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 40
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.DataGridView1.Location = New Global.System.Drawing.Point(12, 132)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 20
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.CellSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(490, 419)
			Me.DataGridView1.TabIndex = 1833
			Me.DataGridView1.TabStop = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Picture.Location = New Global.System.Drawing.Point(508, 133)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(132, 132)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 1835
			Me.Picture.TabStop = False
			Me.Browse.BackColor = Global.System.Drawing.Color.Transparent
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Browse.Location = New Global.System.Drawing.Point(508, 269)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(46, 34)
			Me.Browse.TabIndex = 1833
			Me.Browse.TabStop = False
			Me.Browse.Text = "                       Browse..."
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BRemove.Location = New Global.System.Drawing.Point(594, 269)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(46, 34)
			Me.BRemove.TabIndex = 1834
			Me.BRemove.TabStop = False
			Me.BRemove.Text = "                            Remove"
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(646, 12)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(169, 204)
			Me.Panel3.TabIndex = 1836
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(7, 100)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnUpdate.TabIndex = 517
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnDelete.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete.FlatAppearance.BorderSize = 0
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnDelete.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(7, 147)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnDelete.TabIndex = 516
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(7, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnNew.TabIndex = 515
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(7, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(405, 50)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(213, 13)
			Me.Label5.TabIndex = 20
			Me.Label5.Text = "Visible Status in Forms(S-Sale,P-Purchase) :"
			Me.txtstatusvisible.Location = New Global.System.Drawing.Point(408, 66)
			Me.txtstatusvisible.Name = "txtstatusvisible"
			Me.txtstatusvisible.Size = New Global.System.Drawing.Size(127, 20)
			Me.txtstatusvisible.TabIndex = 19
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Width = 52
			Me.Column2.HeaderText = "Header Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 143
			Me.Column3.HeaderText = "Sub Menu Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 165
			Me.Column4.HeaderText = "Icon Img"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Width = 103
			Me.Column5.HeaderText = "Form_Name"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Width = 130
			Me.Column6.HeaderText = "Is Not Active?"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 145
			Me.Column7.HeaderText = "Visible Status(Form)"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 197
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(827, 563)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.lblStatus)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.Browse)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.BRemove)
			MyBase.Controls.Add(Me.lblId)
			MyBase.Controls.Add(Me.lblSubcategory)
			MyBase.Name = "frmMenu_update"
			Me.Text = "Menu Image Update"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04001667 RID: 5735
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
