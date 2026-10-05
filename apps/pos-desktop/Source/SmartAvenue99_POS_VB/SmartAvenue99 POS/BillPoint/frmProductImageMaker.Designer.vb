Namespace BillPoint
	' Token: 0x0200035C RID: 860
		Public Partial Class frmProductImageMaker
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CBBD RID: 52157 RVA: 0x007F6FC4 File Offset: 0x007F51C4
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

		' Token: 0x0600CBBE RID: 52158 RVA: 0x007F7014 File Offset: 0x007F5214
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle10 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductImageMaker))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.ComboBox3 = New Global.System.Windows.Forms.ComboBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.Button3 = New Global.GelButtons.GelButton()
			Me.Button10 = New Global.GelButtons.GelButton()
			Me.Button2 = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.btnBulkImageUpdate = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton11)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.ComboBox3)
			Me.Panel1.Controls.Add(Me.Picture)
			Me.Panel1.Controls.Add(Me.Button3)
			Me.Panel1.Controls.Add(Me.Button10)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1184, 573)
			Me.Panel1.TabIndex = 45
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(45, 39)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(120, 13)
			Me.Label5.TabIndex = 1690
			Me.Label5.Text = "Select Catalogue Style :"
			Me.Label5.Visible = False
			Me.ComboBox3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox3.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Items.AddRange(New Object() { "Style1", "Style2", "Style3", "Style4", "Style5", "Style6", "Style7", "Style8", "Style9", "Style10" })
			Me.ComboBox3.Location = New Global.System.Drawing.Point(181, 39)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(157, 21)
			Me.ComboBox3.TabIndex = 1690
			Me.ComboBox3.Visible = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 40
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column1, Me.Column2, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewImageColumn1, Me.Column7 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(3, 130)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 50
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 50
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1171, 435)
			Me.DataGridView1.TabIndex = 1684
			Me.DataGridViewTextBoxColumn1.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.Visible = False
			Me.DataGridViewTextBoxColumn2.FillWeight = 70F
			Me.DataGridViewTextBoxColumn2.HeaderText = "Product Code"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn3.FillWeight = 220F
			Me.DataGridViewTextBoxColumn3.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridViewTextBoxColumn4.FillWeight = 75F
			Me.DataGridViewTextBoxColumn4.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.[ReadOnly] = True
			Me.Column1.HeaderText = "Category"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Sub Category"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7
			Me.DataGridViewTextBoxColumn5.HeaderText = "MRP"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridViewTextBoxColumn6.HeaderText = "Retail Sale Price"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridViewTextBoxColumn7.FillWeight = 75F
			Me.DataGridViewTextBoxColumn7.HeaderText = "Discount%"
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridViewTextBoxColumn8.FillWeight = 75F
			Me.DataGridViewTextBoxColumn8.HeaderText = "Activated"
			Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
			Me.DataGridViewTextBoxColumn8.[ReadOnly] = True
			Me.DataGridViewImageColumn1.HeaderText = "Photo"
			Me.DataGridViewImageColumn1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.[ReadOnly] = True
			Me.DataGridViewImageColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridViewImageColumn1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column7.FillWeight = 50F
			Me.Column7.HeaderText = "Mark / Unmark"
			Me.Column7.Name = "Column7"
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label4.Location = New Global.System.Drawing.Point(3, 114)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(225, 13)
			Me.Label4.TabIndex = 1683
			Me.Label4.Text = "Note : Please double click on Photo to update"
			Me.GroupBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.btnBulkImageUpdate)
			Me.GroupBox1.Controls.Add(Me.CheckBox1)
			Me.GroupBox1.Controls.Add(Me.Button4)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.ComboBox2)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Cursor = Global.System.Windows.Forms.Cursors.Arrow
			Me.GroupBox1.Location = New Global.System.Drawing.Point(692, 47)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(482, 80)
			Me.GroupBox1.TabIndex = 1682
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search"
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.BackColor = Global.System.Drawing.Color.PaleGreen
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(339, 60)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(137, 17)
			Me.CheckBox1.TabIndex = 1685
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "All (Mark / Unmark)"
			Me.CheckBox1.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(168, 14)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(58, 13)
			Me.Label3.TabIndex = 1685
			Me.Label3.Text = "Activated :"
			Me.ComboBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "Yes", "No" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(232, 11)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(78, 21)
			Me.ComboBox2.TabIndex = 2
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(14, 14)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 1683
			Me.Label2.Text = "Select Catagory :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Cursor = Global.System.Windows.Forms.Cursors.IBeam
			Me.TextBox1.Location = New Global.System.Drawing.Point(17, 54)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(144, 20)
			Me.TextBox1.TabIndex = 1
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Product Name", "Barcode", "Category", "Sub Category" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(17, 30)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(144, 21)
			Me.ComboBox1.TabIndex = 0
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1184, 35)
			Me.Label1.TabIndex = 51
			Me.Label1.Text = "Product Catalogue - cum - Image Update"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GelButton11.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(465, 44)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(218, 35)
			Me.GelButton11.TabIndex = 1693
			Me.GelButton11.Text = "Catalogue Style Set"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Picture.Location = New Global.System.Drawing.Point(445, 171)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(209, 229)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 1689
			Me.Picture.TabStop = False
			Me.Picture.Visible = False
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button3.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(568, 85)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(115, 43)
			Me.Button3.TabIndex = 1688
			Me.Button3.Text = "&Bulk &Sender"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.BottomLeft
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button10.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button10.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button10.FlatAppearance.BorderSize = 0
			Me.Button10.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button10.ForeColor = Global.System.Drawing.Color.White
			Me.Button10.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button10.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button10.Image = CType(componentResourceManager.GetObject("Button10.Image"), Global.System.Drawing.Image)
			Me.Button10.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button10.Location = New Global.System.Drawing.Point(409, 85)
			Me.Button10.Name = "Button10"
			Me.Button10.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button10.TabIndex = 1687
			Me.Button10.Text = "&Edit Catalogue"
			Me.Button10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button10.UseVisualStyleBackColor = False
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button2.FlatAppearance.BorderSize = 0
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(251, 85)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button2.TabIndex = 1686
			Me.Button2.Text = "&Catalogue View"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(251, 44)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(208, 35)
			Me.Button1.TabIndex = 1685
			Me.Button1.Text = "Show All &Products"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.btnBulkImageUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnBulkImageUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnBulkImageUpdate.FlatAppearance.BorderSize = 0
			Me.btnBulkImageUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBulkImageUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBulkImageUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnBulkImageUpdate.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnBulkImageUpdate.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnBulkImageUpdate.Image = CType(componentResourceManager.GetObject("btnBulkImageUpdate.Image"), Global.System.Drawing.Image)
			Me.btnBulkImageUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBulkImageUpdate.Location = New Global.System.Drawing.Point(171, 47)
			Me.btnBulkImageUpdate.Name = "btnBulkImageUpdate"
			Me.btnBulkImageUpdate.Size = New Global.System.Drawing.Size(154, 27)
			Me.btnBulkImageUpdate.TabIndex = 1689
			Me.btnBulkImageUpdate.Text = "&Bulk &Image Update"
			Me.btnBulkImageUpdate.TextAlign = Global.System.Drawing.ContentAlignment.BottomLeft
			Me.btnBulkImageUpdate.UseVisualStyleBackColor = False
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button4.ForeColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.Button4.Image = Global.BillPoint.My.Resources.Resources.Reset2_32x32
			Me.Button4.Location = New Global.System.Drawing.Point(432, 11)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(44, 36)
			Me.Button4.TabIndex = 3
			Me.Button4.UseVisualStyleBackColor = True
			Me.PictureBox1.Location = New Global.System.Drawing.Point(12, 24)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(21, 17)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 55
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1184, 573)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmProductImageMaker"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040051A7 RID: 20903
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
