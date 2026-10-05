Namespace BillPoint
	' Token: 0x0200035E RID: 862
		Public Partial Class frmProductImageUpdator
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CC24 RID: 52260 RVA: 0x007FB1C0 File Offset: 0x007F93C0
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

		' Token: 0x0600CC25 RID: 52261 RVA: 0x007FB210 File Offset: 0x007F9410
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductImageUpdator))
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.numericUpDown1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.btnRemove = New Global.System.Windows.Forms.Button()
			Me.btnAdd = New Global.System.Windows.Forms.Button()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.numericUpDown1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 283)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.CadetBlue
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowHeadersVisible = False
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowTemplate.Height = 180
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(209, 207)
			Me.dgw.TabIndex = 328
			Me.dgw.TabStop = False
			Me.Column1.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
			Me.Column1.HeaderText = "Photo"
			Me.Column1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.txtID.Location = New Global.System.Drawing.Point(270, 386)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(45, 20)
			Me.txtID.TabIndex = 330
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(337, 48)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(168, 22)
			Me.TextBox1.TabIndex = 331
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView2.GridColor = Global.System.Drawing.SystemColors.ControlDarkDark
			Me.DataGridView2.Location = New Global.System.Drawing.Point(337, 98)
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.RowTemplate.Height = 140
			Me.DataGridView2.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.Size = New Global.System.Drawing.Size(228, 392)
			Me.DataGridView2.TabIndex = 344
			Me.DataGridView2.TabStop = False
			Me.Label34.Anchor = Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label34.AutoSize = True
			Me.Label34.ForeColor = Global.System.Drawing.Color.White
			Me.Label34.Location = New Global.System.Drawing.Point(334, 75)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(66, 13)
			Me.Label34.TabIndex = 348
			Me.Label34.Text = "Image Limit :"
			Me.numericUpDown1.Anchor = Global.System.Windows.Forms.AnchorStyles.Left
			Me.numericUpDown1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.numericUpDown1.Location = New Global.System.Drawing.Point(406, 73)
			Dim numericUpDown As Global.System.Windows.Forms.NumericUpDown = Me.numericUpDown1
			Dim array As Integer() = New Integer(3) {}
			array(0) = 1
			numericUpDown.Minimum = New Decimal(array)
			Me.numericUpDown1.Name = "numericUpDown1"
			Me.numericUpDown1.Size = New Global.System.Drawing.Size(46, 20)
			Me.numericUpDown1.TabIndex = 347
			Me.numericUpDown1.TabStop = False
			Dim numericUpDown2 As Global.System.Windows.Forms.NumericUpDown = Me.numericUpDown1
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 10
			numericUpDown2.Value = New Decimal(array2)
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(334, 13)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(231, 19)
			Me.Label1.TabIndex = 349
			Me.Label1.Text = "Online Image Library"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(334, 34)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(96, 13)
			Me.Label2.TabIndex = 350
			Me.Label2.Text = "Item Image Name :"
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = Global.BillPoint.My.Resources.Resources.Reset2_32x32
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(222, 456)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(100, 34)
			Me.Button3.TabIndex = 351
			Me.Button3.TabStop = False
			Me.Button3.Text = "Reset"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(222, 386)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(100, 34)
			Me.Button1.TabIndex = 329
			Me.Button1.Text = "&Update"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(506, 48)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(59, 41)
			Me.Button2.TabIndex = 345
			Me.Button2.Text = "&Image Search"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.btnRemove.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemove.ForeColor = Global.System.Drawing.Color.White
			Me.btnRemove.Image = CType(componentResourceManager.GetObject("btnRemove.Image"), Global.System.Drawing.Image)
			Me.btnRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemove.Location = New Global.System.Drawing.Point(222, 321)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New Global.System.Drawing.Size(100, 34)
			Me.btnRemove.TabIndex = 326
			Me.btnRemove.Text = "&Remove"
			Me.btnRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemove.UseVisualStyleBackColor = False
			Me.btnAdd.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnAdd.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAdd.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAdd.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAdd.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAdd.ForeColor = Global.System.Drawing.Color.White
			Me.btnAdd.Image = CType(componentResourceManager.GetObject("btnAdd.Image"), Global.System.Drawing.Image)
			Me.btnAdd.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAdd.Location = New Global.System.Drawing.Point(222, 283)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New Global.System.Drawing.Size(100, 34)
			Me.btnAdd.TabIndex = 325
			Me.btnAdd.Text = "&Add"
			Me.btnAdd.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAdd.UseVisualStyleBackColor = False
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Picture.Location = New Global.System.Drawing.Point(9, 13)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(209, 229)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 327
			Me.Picture.TabStop = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BRemove.Location = New Global.System.Drawing.Point(116, 245)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(102, 34)
			Me.BRemove.TabIndex = 324
			Me.BRemove.Text = "Remove"
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Browse.Location = New Global.System.Drawing.Point(9, 245)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(102, 34)
			Me.Browse.TabIndex = 323
			Me.Browse.Text = "Browse..."
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.HotPink
			MyBase.ClientSize = New Global.System.Drawing.Size(574, 502)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Label34)
			MyBase.Controls.Add(Me.numericUpDown1)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.btnRemove)
			MyBase.Controls.Add(Me.btnAdd)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.BRemove)
			MyBase.Controls.Add(Me.Browse)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedToolWindow
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmProductImageUpdator"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Product Image Updator"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.numericUpDown1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040051E1 RID: 20961
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
