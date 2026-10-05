Namespace BillPoint
	' Token: 0x020000B2 RID: 178
		Public Partial Class frmCustomersNew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060019DE RID: 6622 RVA: 0x0011C940 File Offset: 0x0011AB40
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

		' Token: 0x060019DF RID: 6623 RVA: 0x0011C990 File Offset: 0x0011AB90
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.txtSearchProduct = New Global.System.Windows.Forms.TextBox()
			Me.cmbSearchCat = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btnNewSupplier = New Global.System.Windows.Forms.Button()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Photo = New Global.System.Windows.Forms.PictureBox()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.lblCName = New Global.System.Windows.Forms.Label()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel7.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
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
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column16, Me.Column1, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column2 })
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.Location = New Global.System.Drawing.Point(14, 107)
			Me.dgw.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.dgw.Name = "dgw"
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1729, 512)
			Me.dgw.TabIndex = 1828
			Me.Column16.HeaderText = "ID"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column16.Visible = False
			Me.Column1.HeaderText = "Customer ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column3.HeaderText = "Customer Name"
			Me.Column3.Name = "Column3"
			Me.Column4.HeaderText = "Address"
			Me.Column4.Name = "Column4"
			Me.Column5.HeaderText = "City"
			Me.Column5.Name = "Column5"
			Me.Column6.HeaderText = "State"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Postal Code"
			Me.Column7.Name = "Column7"
			Me.Column8.HeaderText = "Contact No"
			Me.Column8.MaxInputLength = 10
			Me.Column8.Name = "Column8"
			Me.Column9.HeaderText = "Email ID"
			Me.Column9.Name = "Column9"
			Me.Column10.HeaderText = "GSTIN UID"
			Me.Column10.Name = "Column10"
			Me.Column11.HeaderText = "CIN"
			Me.Column11.Name = "Column11"
			Me.Column12.HeaderText = "PAN"
			Me.Column12.Name = "Column12"
			Me.Column13.HeaderText = "Opening Balance"
			Me.Column13.Name = "Column13"
			Me.Column14.HeaderText = "Remarks"
			Me.Column14.Name = "Column14"
			Me.Column15.HeaderText = "Credit Limit"
			Me.Column15.Name = "Column15"
			Me.Column17.HeaderText = "Loyality Point"
			Me.Column17.Name = "Column17"
			Me.Column18.HeaderText = "Loyality Enabled"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column18.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column18.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column19.HeaderText = "TCS Applied"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			Me.Column19.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column19.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column20.HeaderText = "Route"
			Me.Column20.Name = "Column20"
			Me.Column20.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column20.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column21.HeaderText = "Turn Around Days"
			Me.Column21.Name = "Column21"
			Me.Column21.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column21.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column22.HeaderText = "Save"
			Me.Column22.Name = "Column22"
			Me.Column22.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column22.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column2.HeaderText = "Delete"
			Me.Column2.Name = "Column2"
			Me.Column2.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column2.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(868, 14)
			Me.lblUser.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(46, 15)
			Me.lblUser.TabIndex = 1839
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(682, 14)
			Me.lblUserType.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(72, 15)
			Me.lblUserType.TabIndex = 1840
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(785, 14)
			Me.lblCPhone.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(64, 15)
			Me.lblCPhone.TabIndex = 1844
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.Panel4.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Location = New Global.System.Drawing.Point(14, 4)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(556, 51)
			Me.Panel4.TabIndex = 1845
			Me.PictureBox1.Location = New Global.System.Drawing.Point(4, 10)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(44, 30)
			Me.PictureBox1.TabIndex = 51
			Me.PictureBox1.TabStop = False
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 21F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(39, 8)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(348, 35)
			Me.Label17.TabIndex = 50
			Me.Label17.Text = "LIST OF CUSTOMERS"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.Label19)
			Me.Panel7.Controls.Add(Me.chkSelectAll)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Location = New Global.System.Drawing.Point(14, 63)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(556, 38)
			Me.Panel7.TabIndex = 1846
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label19.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(4, 8)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(145, 25)
			Me.Label19.TabIndex = 1807
			Me.Label19.Text = "SELECT ALL :"
			Me.Label19.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.chkSelectAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(153, 15)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(15, 14)
			Me.chkSelectAll.TabIndex = 1805
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(443, 4)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(273, 4)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(340, 4)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(97, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "5"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtSearchProduct.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtSearchProduct.Location = New Global.System.Drawing.Point(752, 70)
			Me.txtSearchProduct.Name = "txtSearchProduct"
			Me.txtSearchProduct.Size = New Global.System.Drawing.Size(424, 26)
			Me.txtSearchProduct.TabIndex = 1848
			Me.cmbSearchCat.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.cmbSearchCat.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchCat.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbSearchCat.ForeColor = Global.System.Drawing.Color.White
			Me.cmbSearchCat.FormattingEnabled = True
			Me.cmbSearchCat.Items.AddRange(New Object() { "Customer Name", "Mobile No" })
			Me.cmbSearchCat.Location = New Global.System.Drawing.Point(583, 70)
			Me.cmbSearchCat.Name = "cmbSearchCat"
			Me.cmbSearchCat.Size = New Global.System.Drawing.Size(163, 28)
			Me.cmbSearchCat.TabIndex = 1849
			Me.cmbSearchCat.TabStop = False
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(577, 44)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(91, 24)
			Me.Label1.TabIndex = 1808
			Me.Label1.Text = "Search By"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Location = New Global.System.Drawing.Point(1403, 14)
			Me.Button1.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(149, 47)
			Me.Button1.TabIndex = 1847
			Me.Button1.Text = "Refresh"
			Me.Button1.UseVisualStyleBackColor = True
			Me.Button1.Visible = False
			Me.btnNewSupplier.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNewSupplier.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.btnNewSupplier.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNewSupplier.FlatAppearance.BorderSize = 0
			Me.btnNewSupplier.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNewSupplier.Location = New Global.System.Drawing.Point(1594, 14)
			Me.btnNewSupplier.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.btnNewSupplier.Name = "btnNewSupplier"
			Me.btnNewSupplier.Size = New Global.System.Drawing.Size(149, 47)
			Me.btnNewSupplier.TabIndex = 1842
			Me.btnNewSupplier.UseVisualStyleBackColor = True
			Me.pbgiftqr.Image = Global.BillPoint.My.Resources.Resources._12
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(86, 644)
			Me.pbgiftqr.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(30, 25)
			Me.pbgiftqr.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbgiftqr.TabIndex = 1837
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.Photo.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Photo.Location = New Global.System.Drawing.Point(37, 644)
			Me.Photo.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Photo.Name = "Photo"
			Me.Photo.Size = New Global.System.Drawing.Size(30, 25)
			Me.Photo.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Photo.TabIndex = 1836
			Me.Photo.TabStop = False
			Me.Photo.Visible = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(1229, 5)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(102, 93)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 1850
			Me.Picture.TabStop = False
			Me.lblCName.AutoSize = True
			Me.lblCName.Location = New Global.System.Drawing.Point(944, 40)
			Me.lblCName.Margin = New Global.System.Windows.Forms.Padding(4, 0, 4, 0)
			Me.lblCName.Name = "lblCName"
			Me.lblCName.Size = New Global.System.Drawing.Size(45, 15)
			Me.lblCName.TabIndex = 1851
			Me.lblCName.Text = "Label2"
			Me.lblCName.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(7F, 15F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1757, 683)
			MyBase.Controls.Add(Me.lblCName)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtSearchProduct)
			MyBase.Controls.Add(Me.cmbSearchCat)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Panel7)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.lblCPhone)
			MyBase.Controls.Add(Me.btnNewSupplier)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.Photo)
			MyBase.Controls.Add(Me.dgw)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			MyBase.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			MyBase.Name = "frmCustomersNew"
			Me.Text = "Product New & Update"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000A0B RID: 2571
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
