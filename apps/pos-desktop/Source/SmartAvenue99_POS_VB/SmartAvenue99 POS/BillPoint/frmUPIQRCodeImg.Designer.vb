Namespace BillPoint
	' Token: 0x02000372 RID: 882
		Public Partial Class frmUPIQRCodeImg
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600D036 RID: 53302 RVA: 0x0081C898 File Offset: 0x0081AA98
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

		' Token: 0x0600D037 RID: 53303 RVA: 0x0081C8E8 File Offset: 0x0081AAE8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmUPIQRCodeImg))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Button3 = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.GelButtons.GelButton()
			Me.Button6 = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.Button4)
			Me.Panel1.Controls.Add(Me.Button6)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Button5)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(728, 464)
			Me.Panel1.TabIndex = 154
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(593, 135)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(119, 43)
			Me.Button3.TabIndex = 521
			Me.Button3.Text = "Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.GradientBottom = Global.System.Drawing.Color.Red
			Me.Button4.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(593, 182)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(119, 43)
			Me.Button4.TabIndex = 520
			Me.Button4.Text = "Delete"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button6.FlatAppearance.BorderSize = 0
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button6.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button6.Image = CType(componentResourceManager.GetObject("Button6.Image"), Global.System.Drawing.Image)
			Me.Button6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button6.Location = New Global.System.Drawing.Point(593, 40)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(119, 43)
			Me.Button6.TabIndex = 519
			Me.Button6.Text = "New"
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button6.UseVisualStyleBackColor = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(593, 87)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(119, 43)
			Me.Button1.TabIndex = 518
			Me.Button1.Text = "Save"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(219, 53)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(84, 18)
			Me.Label2.TabIndex = 157
			Me.Label2.Text = "UPI Name :"
			Me.Panel5.BackColor = Global.System.Drawing.Color.FromArgb(128, 255, 255)
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.Label13)
			Me.Panel5.Controls.Add(Me.ComboBox1)
			Me.Panel5.Location = New Global.System.Drawing.Point(599, 230)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(108, 53)
			Me.Panel5.TabIndex = 156
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(-2, 3)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(111, 13)
			Me.Label13.TabIndex = 0
			Me.Label13.Text = "Search By UPI Name:"
			Me.ComboBox1.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.ComboBox1.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(6, 21)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(94, 23)
			Me.ComboBox1.TabIndex = 155
			Me.ComboBox1.TabStop = False
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(728, 36)
			Me.Label1.TabIndex = 154
			Me.Label1.Text = "UPI QR Code Image"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column3, Me.Column4 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(8, 44)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.Lime
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.MediumBlue
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 40
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(208, 399)
			Me.dgw.TabIndex = 145
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column1.Width = 42
			Me.Column3.HeaderText = "UPI Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Image"
			Me.Column4.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Stretch
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column4.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column4.Width = 55
			Me.Button5.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Button5.BackgroundImage = CType(componentResourceManager.GetObject("Button5.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button5.Location = New Global.System.Drawing.Point(606, 366)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(94, 77)
			Me.Button5.TabIndex = 152
			Me.Button5.Text = "&Rotate"
			Me.Button5.UseVisualStyleBackColor = False
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.Black
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.Noimage
			Me.PictureBox1.Location = New Global.System.Drawing.Point(222, 91)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(354, 352)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 0
			Me.PictureBox1.TabStop = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Location = New Global.System.Drawing.Point(694, 281)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(29, 12)
			Me.Panel4.TabIndex = 151
			Me.Panel4.Visible = False
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(309, 53)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(267, 24)
			Me.TextBox1.TabIndex = 0
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(606, 295)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(94, 65)
			Me.Button2.TabIndex = 149
			Me.Button2.Text = "&Browse..........."
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageAboveText
			Me.Button2.UseVisualStyleBackColor = False
			Me.TextBox2.Location = New Global.System.Drawing.Point(222, 44)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(37, 20)
			Me.TextBox2.TabIndex = 147
			Me.TextBox2.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(728, 464)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmUPIQRCodeImg"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005387 RID: 21383
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
