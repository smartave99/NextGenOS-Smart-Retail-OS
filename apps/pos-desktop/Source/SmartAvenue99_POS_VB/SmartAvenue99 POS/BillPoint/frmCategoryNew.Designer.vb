Namespace BillPoint
	' Token: 0x020000A2 RID: 162
		Public Partial Class frmCategoryNew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001846 RID: 6214 RVA: 0x001083A0 File Offset: 0x001065A0
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

		' Token: 0x06001847 RID: 6215 RVA: 0x001083F0 File Offset: 0x001065F0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.txtSearchProduct = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btnNewSupplier = New Global.System.Windows.Forms.Button()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Photo = New Global.System.Windows.Forms.PictureBox()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel7.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).BeginInit()
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
			Me.dgw.ColumnHeadersHeight = 35
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column16, Me.Column1, Me.Column22, Me.Column2 })
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.Location = New Global.System.Drawing.Point(14, 118)
			Me.dgw.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.dgw.Name = "dgw"
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(492, 304)
			Me.dgw.TabIndex = 1828
			Me.Panel4.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Location = New Global.System.Drawing.Point(14, 4)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(617, 51)
			Me.Panel4.TabIndex = 1845
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(556, 29)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label2.TabIndex = 52
			Me.Label2.Text = "lblUser"
			Me.Label2.Visible = False
			Me.PictureBox1.Location = New Global.System.Drawing.Point(4, 10)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(44, 30)
			Me.PictureBox1.TabIndex = 51
			Me.PictureBox1.TabStop = False
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 16F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(39, 8)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(252, 35)
			Me.Label17.TabIndex = 50
			Me.Label17.Text = "LIST OF CATEGORY"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Controls.Add(Me.Label19)
			Me.Panel7.Controls.Add(Me.txtSearchProduct)
			Me.Panel7.Controls.Add(Me.Label1)
			Me.Panel7.Controls.Add(Me.chkSelectAll)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Location = New Global.System.Drawing.Point(14, 63)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(617, 38)
			Me.Panel7.TabIndex = 1846
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(186, 6)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(48, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "5"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label19.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(4, 8)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(108, 25)
			Me.Label19.TabIndex = 1807
			Me.Label19.Text = "SELECT ALL :"
			Me.Label19.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtSearchProduct.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtSearchProduct.Location = New Global.System.Drawing.Point(460, 6)
			Me.txtSearchProduct.Name = "txtSearchProduct"
			Me.txtSearchProduct.Size = New Global.System.Drawing.Size(145, 26)
			Me.txtSearchProduct.TabIndex = 1848
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(363, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(91, 24)
			Me.Label1.TabIndex = 1808
			Me.Label1.Text = "Search By"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.chkSelectAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(121, 13)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(15, 14)
			Me.chkSelectAll.TabIndex = 1805
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(240, 4)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(133, 5)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.FlatAppearance.BorderSize = 0
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Location = New Global.System.Drawing.Point(514, 172)
			Me.Button2.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(102, 37)
			Me.Button2.TabIndex = 1850
			Me.Button2.Text = "Import Excel"
			Me.Button2.UseVisualStyleBackColor = True
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Location = New Global.System.Drawing.Point(514, 229)
			Me.Button1.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(102, 39)
			Me.Button1.TabIndex = 1847
			Me.Button1.Text = "Refresh"
			Me.Button1.UseVisualStyleBackColor = True
			Me.btnNewSupplier.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNewSupplier.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.btnNewSupplier.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNewSupplier.FlatAppearance.BorderSize = 0
			Me.btnNewSupplier.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNewSupplier.Location = New Global.System.Drawing.Point(514, 118)
			Me.btnNewSupplier.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			Me.btnNewSupplier.Name = "btnNewSupplier"
			Me.btnNewSupplier.Size = New Global.System.Drawing.Size(102, 38)
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
			Me.Column16.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
			Me.Column16.HeaderText = "ID"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column16.Visible = False
			Me.Column16.Width = 10
			Me.Column1.FillWeight = 190.3553F
			Me.Column1.HeaderText = "Category"
			Me.Column1.Name = "Column1"
			Me.Column22.FillWeight = 61.60448F
			Me.Column22.HeaderText = "Save"
			Me.Column22.Name = "Column22"
			Me.Column22.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column22.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column22.UseColumnTextForButtonValue = True
			Me.Column2.FillWeight = 48.04018F
			Me.Column2.HeaderText = "Delete"
			Me.Column2.Name = "Column2"
			Me.Column2.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column2.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column2.UseColumnTextForButtonValue = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(7F, 15F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(644, 431)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Panel7)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.btnNewSupplier)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.Photo)
			MyBase.Controls.Add(Me.dgw)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			MyBase.Margin = New Global.System.Windows.Forms.Padding(4, 3, 4, 3)
			MyBase.Name = "frmCategoryNew"
			Me.Text = "List of category"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000956 RID: 2390
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
