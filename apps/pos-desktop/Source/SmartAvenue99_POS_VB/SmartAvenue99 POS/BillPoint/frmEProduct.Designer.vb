Namespace BillPoint
	' Token: 0x02000056 RID: 86
		Public Partial Class frmEProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000FD5 RID: 4053 RVA: 0x000BB1A0 File Offset: 0x000B93A0
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

		' Token: 0x06000FD6 RID: 4054 RVA: 0x000BB1F0 File Offset: 0x000B93F0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEProduct))
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
			Dim dataGridViewCellStyle11 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle12 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle13 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle14 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle15 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle16 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle17 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle18 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle20 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle21 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle22 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle23 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle24 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle25 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle26 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle27 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle28 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.txtPid = New Global.System.Windows.Forms.TextBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.btnEcomPost = New Global.GelButtons.GelButton()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtEcomCID = New Global.System.Windows.Forms.TextBox()
			Me.txtSubCategory = New Global.System.Windows.Forms.TextBox()
			Me.txtCategory = New Global.System.Windows.Forms.TextBox()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.txtSubCategoryID = New Global.System.Windows.Forms.TextBox()
			Me.txtCategoryID = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.btnAdd = New Global.System.Windows.Forms.Button()
			Me.txtDefMRP = New Global.System.Windows.Forms.TextBox()
			Me.btnRemove = New Global.System.Windows.Forms.Button()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtRSPrice = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtDiscount = New Global.System.Windows.Forms.TextBox()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.txtUnit = New Global.System.Windows.Forms.TextBox()
			Me.txtFeatures = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.cmbPpular = New Global.System.Windows.Forms.ComboBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.cmbProductStatus = New Global.System.Windows.Forms.ComboBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.cmbNotification = New Global.System.Windows.Forms.ComboBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtStock = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtSellerName = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtEcomSubCID = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column33 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column35 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column36 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column37 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column38 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column39 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column40 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column41 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column42 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtSearchBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.Red
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(503, 65)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(78, 33)
			Me.GelButton2.TabIndex = 1781
			Me.GelButton2.Text = "Reset"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.PictureBox2.BackColor = Global.System.Drawing.Color.White
			Me.PictureBox2.Image = Global.BillPoint.My.Resources.Resources.loading
			Me.PictureBox2.InitialImage = Global.BillPoint.My.Resources.Resources.loading
			Me.PictureBox2.Location = New Global.System.Drawing.Point(562, 135)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(14, 229)
			Me.PictureBox2.TabIndex = 1780
			Me.PictureBox2.TabStop = False
			Me.PictureBox2.Visible = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(365, 104)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(132, 33)
			Me.GelButton1.TabIndex = 1779
			Me.GelButton1.Text = "Bulk Post"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton1.Visible = False
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(278, 11)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.[ReadOnly] = True
			Me.txtBarcode.Size = New Global.System.Drawing.Size(130, 21)
			Me.txtBarcode.TabIndex = 1778
			Me.txtPid.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPid.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPid.Location = New Global.System.Drawing.Point(142, 11)
			Me.txtPid.Name = "txtPid"
			Me.txtPid.[ReadOnly] = True
			Me.txtPid.Size = New Global.System.Drawing.Size(130, 21)
			Me.txtPid.TabIndex = 1777
			Me.Label20.AutoSize = True
			Me.Label20.Location = New Global.System.Drawing.Point(5, 13)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label20.TabIndex = 1776
			Me.Label20.Text = "ProductId"
			Me.btnEcomPost.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnEcomPost.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnEcomPost.FlatAppearance.BorderSize = 0
			Me.btnEcomPost.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnEcomPost.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnEcomPost.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnEcomPost.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnEcomPost.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnEcomPost.Image = CType(componentResourceManager.GetObject("btnEcomPost.Image"), Global.System.Drawing.Image)
			Me.btnEcomPost.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnEcomPost.Location = New Global.System.Drawing.Point(365, 65)
			Me.btnEcomPost.Name = "btnEcomPost"
			Me.btnEcomPost.Size = New Global.System.Drawing.Size(132, 33)
			Me.btnEcomPost.TabIndex = 1775
			Me.btnEcomPost.Text = "Post"
			Me.btnEcomPost.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnEcomPost.UseVisualStyleBackColor = False
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(137, 217)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(33, 13)
			Me.Label19.TabIndex = 1773
			Me.Label19.Text = "Local"
			Me.Label18.AutoSize = True
			Me.Label18.Location = New Global.System.Drawing.Point(93, 217)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label18.TabIndex = 1772
			Me.Label18.Text = "E- Com"
			Me.txtEcomCID.BackColor = Global.System.Drawing.Color.Green
			Me.txtEcomCID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEcomCID.Location = New Global.System.Drawing.Point(95, 233)
			Me.txtEcomCID.Name = "txtEcomCID"
			Me.txtEcomCID.Size = New Global.System.Drawing.Size(36, 21)
			Me.txtEcomCID.TabIndex = 1770
			Me.txtSubCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSubCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSubCategory.Location = New Global.System.Drawing.Point(179, 263)
			Me.txtSubCategory.Name = "txtSubCategory"
			Me.txtSubCategory.[ReadOnly] = True
			Me.txtSubCategory.Size = New Global.System.Drawing.Size(145, 21)
			Me.txtSubCategory.TabIndex = 1769
			Me.txtCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCategory.Location = New Global.System.Drawing.Point(179, 234)
			Me.txtCategory.Name = "txtCategory"
			Me.txtCategory.[ReadOnly] = True
			Me.txtCategory.Size = New Global.System.Drawing.Size(145, 21)
			Me.txtCategory.TabIndex = 1768
			Me.DataGridViewImageColumn1.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
			Me.DataGridViewImageColumn1.HeaderText = "Photo"
			Me.DataGridViewImageColumn1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.[ReadOnly] = True
			Me.txtSubCategoryID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSubCategoryID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSubCategoryID.Location = New Global.System.Drawing.Point(137, 262)
			Me.txtSubCategoryID.Name = "txtSubCategoryID"
			Me.txtSubCategoryID.[ReadOnly] = True
			Me.txtSubCategoryID.Size = New Global.System.Drawing.Size(36, 21)
			Me.txtSubCategoryID.TabIndex = 1767
			Me.txtCategoryID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCategoryID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCategoryID.Location = New Global.System.Drawing.Point(137, 233)
			Me.txtCategoryID.Name = "txtCategoryID"
			Me.txtCategoryID.[ReadOnly] = True
			Me.txtCategoryID.Size = New Global.System.Drawing.Size(36, 21)
			Me.txtCategoryID.TabIndex = 1766
			Me.DataGridView1.AllowUserToAddRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewImageColumn1 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(169, 65)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.CadetBlue
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.RowHeadersVisible = False
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowTemplate.Height = 110
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(133, 125)
			Me.DataGridView1.TabIndex = 322
			Me.DataGridView1.TabStop = False
			Me.btnAdd.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnAdd.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAdd.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAdd.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAdd.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAdd.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.btnAdd.Image = CType(componentResourceManager.GetObject("btnAdd.Image"), Global.System.Drawing.Image)
			Me.btnAdd.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAdd.Location = New Global.System.Drawing.Point(308, 108)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New Global.System.Drawing.Size(43, 34)
			Me.btnAdd.TabIndex = 27
			Me.btnAdd.TabStop = False
			Me.btnAdd.Text = "                                &Add"
			Me.btnAdd.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAdd.UseVisualStyleBackColor = False
			Me.txtDefMRP.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDefMRP.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDefMRP.Location = New Global.System.Drawing.Point(140, 397)
			Me.txtDefMRP.Name = "txtDefMRP"
			Me.txtDefMRP.[ReadOnly] = True
			Me.txtDefMRP.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtDefMRP.TabIndex = 1760
			Me.txtDefMRP.Text = "0.00"
			Me.txtDefMRP.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.btnRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemove.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.btnRemove.Image = CType(componentResourceManager.GetObject("btnRemove.Image"), Global.System.Drawing.Image)
			Me.btnRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemove.Location = New Global.System.Drawing.Point(308, 156)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New Global.System.Drawing.Size(43, 34)
			Me.btnRemove.TabIndex = 28
			Me.btnRemove.TabStop = False
			Me.btnRemove.Text = "                                &Remove"
			Me.btnRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemove.UseVisualStyleBackColor = False
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(7, 422)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label14.TabIndex = 1764
			Me.Label14.Text = "Retail Sale Price :"
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(7, 397)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(37, 13)
			Me.Label15.TabIndex = 1765
			Me.Label15.Text = "MRP :"
			Me.txtRSPrice.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRSPrice.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRSPrice.Location = New Global.System.Drawing.Point(140, 422)
			Me.txtRSPrice.Name = "txtRSPrice"
			Me.txtRSPrice.[ReadOnly] = True
			Me.txtRSPrice.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtRSPrice.TabIndex = 1761
			Me.txtRSPrice.Text = "0.00"
			Me.txtRSPrice.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label17.AutoSize = True
			Me.Label17.Location = New Global.System.Drawing.Point(258, 408)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label17.TabIndex = 1763
			Me.Label17.Text = "Sales Discount % :"
			Me.txtDiscount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDiscount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDiscount.Location = New Global.System.Drawing.Point(261, 424)
			Me.txtDiscount.Name = "txtDiscount"
			Me.txtDiscount.[ReadOnly] = True
			Me.txtDiscount.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtDiscount.TabIndex = 1762
			Me.txtDiscount.Text = "0.00"
			Me.txtDiscount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label21.AutoSize = True
			Me.Label21.Location = New Global.System.Drawing.Point(604, 10)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(168, 13)
			Me.Label21.TabIndex = 1794
			Me.Label21.Text = "Search By Sub Category / Brand :"
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(5, 370)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label16.TabIndex = 336
			Me.Label16.Text = "Product (Gms,kg,ltr,ml,pcs)"
			Me.CheckBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckBox2.AutoSize = True
			Me.CheckBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.CheckBox2.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox2.ForeColor = Global.System.Drawing.Color.Blue
			Me.CheckBox2.Location = New Global.System.Drawing.Point(607, 57)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(120, 19)
			Me.CheckBox2.TabIndex = 1795
			Me.CheckBox2.TabStop = False
			Me.CheckBox2.Text = "All (Mark/Unmark)"
			Me.CheckBox2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox2.UseVisualStyleBackColor = False
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(607, 30)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(168, 21)
			Me.TextBox1.TabIndex = 1793
			Me.Panel6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel6.BackgroundImage = Global.BillPoint.My.Resources.Resources.GiftCard
			Me.Panel6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel6.Location = New Global.System.Drawing.Point(613, 172)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(500, 500)
			Me.Panel6.TabIndex = 1792
			Me.Panel6.Visible = False
			Me.txtUnit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUnit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUnit.Location = New Global.System.Drawing.Point(140, 370)
			Me.txtUnit.Name = "txtUnit"
			Me.txtUnit.[ReadOnly] = True
			Me.txtUnit.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtUnit.TabIndex = 335
			Me.txtFeatures.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFeatures.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFeatures.Location = New Global.System.Drawing.Point(142, 317)
			Me.txtFeatures.Multiline = True
			Me.txtFeatures.Name = "txtFeatures"
			Me.txtFeatures.[ReadOnly] = True
			Me.txtFeatures.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.txtFeatures.Size = New Global.System.Drawing.Size(395, 47)
			Me.txtFeatures.TabIndex = 322
			Me.txtFeatures.TabStop = False
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(5, 316)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(128, 13)
			Me.Label13.TabIndex = 323
			Me.Label13.Text = "Product Small Description"
			Me.cmbPpular.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPpular.FormattingEnabled = True
			Me.cmbPpular.Items.AddRange(New Object() { "Yes", "No" })
			Me.cmbPpular.Location = New Global.System.Drawing.Point(484, 292)
			Me.cmbPpular.Name = "cmbPpular"
			Me.cmbPpular.Size = New Global.System.Drawing.Size(91, 21)
			Me.cmbPpular.TabIndex = 321
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(330, 296)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(119, 13)
			Me.Label12.TabIndex = 320
			Me.Label12.Text = "Make Product Popular?"
			Me.cmbProductStatus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductStatus.FormattingEnabled = True
			Me.cmbProductStatus.Items.AddRange(New Object() { "Publish", "Unpublish" })
			Me.cmbProductStatus.Location = New Global.System.Drawing.Point(484, 260)
			Me.cmbProductStatus.Name = "cmbProductStatus"
			Me.cmbProductStatus.Size = New Global.System.Drawing.Size(91, 21)
			Me.cmbProductStatus.TabIndex = 319
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(329, 266)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(151, 13)
			Me.Label9.TabIndex = 318
			Me.Label9.Text = "Product Publish Or Unpublish?"
			Me.cmbNotification.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbNotification.FormattingEnabled = True
			Me.cmbNotification.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbNotification.Location = New Global.System.Drawing.Point(484, 231)
			Me.cmbNotification.Name = "cmbNotification"
			Me.cmbNotification.Size = New Global.System.Drawing.Size(91, 21)
			Me.cmbNotification.TabIndex = 317
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(329, 237)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(94, 13)
			Me.Label8.TabIndex = 316
			Me.Label8.Text = "Send Notification?"
			Me.txtStock.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtStock.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtStock.Location = New Global.System.Drawing.Point(179, 290)
			Me.txtStock.Name = "txtStock"
			Me.txtStock.[ReadOnly] = True
			Me.txtStock.Size = New Global.System.Drawing.Size(145, 21)
			Me.txtStock.TabIndex = 315
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(5, 292)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label7.TabIndex = 314
			Me.Label7.Text = "Product Stock"
			Me.txtSellerName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSellerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSellerName.Location = New Global.System.Drawing.Point(142, 196)
			Me.txtSellerName.Name = "txtSellerName"
			Me.txtSellerName.[ReadOnly] = True
			Me.txtSellerName.Size = New Global.System.Drawing.Size(284, 21)
			Me.txtSellerName.TabIndex = 313
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(5, 198)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(137, 13)
			Me.Label6.TabIndex = 312
			Me.Label6.Text = "Seller Name / Shop Name :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(5, 263)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label4.TabIndex = 311
			Me.Label4.Text = "Sub Cat. / Brand :"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(5, 234)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label1.TabIndex = 310
			Me.Label1.Text = "Category :"
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.PictureBox1.Location = New Global.System.Drawing.Point(503, 379)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(122, 89)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 307
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
			Me.Button2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(509, 473)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(66, 24)
			Me.Button2.TabIndex = 306
			Me.Button2.Text = "Remove"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button2.Visible = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(41, 65)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(122, 125)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 304
			Me.Picture.TabStop = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(431, 473)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(66, 24)
			Me.BRemove.TabIndex = 303
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.BRemove.Visible = False
			Me.cmbProductName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbProductName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbProductName.Location = New Global.System.Drawing.Point(142, 38)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(387, 21)
			Me.cmbProductName.TabIndex = 6
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(5, 40)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Product Name :"
			Me.txtEcomSubCID.BackColor = Global.System.Drawing.Color.Green
			Me.txtEcomSubCID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEcomSubCID.Location = New Global.System.Drawing.Point(95, 262)
			Me.txtEcomSubCID.Name = "txtEcomSubCID"
			Me.txtEcomSubCID.Size = New Global.System.Drawing.Size(36, 21)
			Me.txtEcomSubCID.TabIndex = 1771
			Me.GroupBox1.Controls.Add(Me.GelButton2)
			Me.GroupBox1.Controls.Add(Me.PictureBox2)
			Me.GroupBox1.Controls.Add(Me.GelButton1)
			Me.GroupBox1.Controls.Add(Me.txtBarcode)
			Me.GroupBox1.Controls.Add(Me.txtPid)
			Me.GroupBox1.Controls.Add(Me.Label20)
			Me.GroupBox1.Controls.Add(Me.btnEcomPost)
			Me.GroupBox1.Controls.Add(Me.Label19)
			Me.GroupBox1.Controls.Add(Me.Label18)
			Me.GroupBox1.Controls.Add(Me.txtEcomCID)
			Me.GroupBox1.Controls.Add(Me.txtSubCategory)
			Me.GroupBox1.Controls.Add(Me.txtCategory)
			Me.GroupBox1.Controls.Add(Me.txtSubCategoryID)
			Me.GroupBox1.Controls.Add(Me.txtCategoryID)
			Me.GroupBox1.Controls.Add(Me.DataGridView1)
			Me.GroupBox1.Controls.Add(Me.btnAdd)
			Me.GroupBox1.Controls.Add(Me.txtDefMRP)
			Me.GroupBox1.Controls.Add(Me.btnRemove)
			Me.GroupBox1.Controls.Add(Me.Label14)
			Me.GroupBox1.Controls.Add(Me.Label15)
			Me.GroupBox1.Controls.Add(Me.txtRSPrice)
			Me.GroupBox1.Controls.Add(Me.Label17)
			Me.GroupBox1.Controls.Add(Me.txtDiscount)
			Me.GroupBox1.Controls.Add(Me.Label16)
			Me.GroupBox1.Controls.Add(Me.txtUnit)
			Me.GroupBox1.Controls.Add(Me.txtFeatures)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Controls.Add(Me.cmbPpular)
			Me.GroupBox1.Controls.Add(Me.Label12)
			Me.GroupBox1.Controls.Add(Me.cmbProductStatus)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.cmbNotification)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.txtStock)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.txtSellerName)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.PictureBox1)
			Me.GroupBox1.Controls.Add(Me.Button2)
			Me.GroupBox1.Controls.Add(Me.Picture)
			Me.GroupBox1.Controls.Add(Me.BRemove)
			Me.GroupBox1.Controls.Add(Me.cmbProductName)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtEcomSubCID)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 3)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(587, 567)
			Me.GroupBox1.TabIndex = 1791
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Product Update"
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column22.DefaultCellStyle = dataGridViewCellStyle5
			Me.Column22.HeaderText = "Conversion Value"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column16.FillWeight = 60.33623F
			Me.Column16.HeaderText = "Sales Unit"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column15.FillWeight = 62.87987F
			Me.Column15.HeaderText = "Purchase Unit"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column10.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column10.FillWeight = 65.72141F
			Me.Column10.HeaderText = "Opening Stock"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Visible = False
			Me.Column14.FillWeight = 68.8817F
			Me.Column14.HeaderText = "Barcode"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column14.Visible = False
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column9.FillWeight = 72.32803F
			Me.Column9.HeaderText = "Wholesale Sale Price"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column20.FillWeight = 76.19376F
			Me.Column20.HeaderText = "CESS %"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column19.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column19.FillWeight = 80.45252F
			Me.Column19.HeaderText = "SGST/UTGST %"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column13.FillWeight = 85.13367F
			Me.Column13.HeaderText = "CGST %"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column12.FillWeight = 90.26913F
			Me.Column12.HeaderText = "Discount %"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle12.Format = "N2"
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column11.FillWeight = 95.89358F
			Me.Column11.HeaderText = "Retail Sale Price"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Visible = False
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle13.Format = "N2"
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column8.FillWeight = 102.0445F
			Me.Column8.HeaderText = "Purchase Price"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column7.FillWeight = 108.7626F
			Me.Column7.HeaderText = "Description"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column18.FillWeight = 116.0919F
			Me.Column18.HeaderText = "Part / Group"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column17.FillWeight = 124.0205F
			Me.Column17.HeaderText = "HSN Code"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column6.FillWeight = 132.7159F
			Me.Column6.HeaderText = "Sub Category / Brand"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column5.FillWeight = 142.1764F
			Me.Column5.HeaderText = "Category"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column4.HeaderText = "Sub Category ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Column3.FillWeight = 152.4618F
			Me.Column3.HeaderText = "Product Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 200
			Me.Column2.FillWeight = 163.6364F
			Me.Column2.HeaderText = "Product Code"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column1.HeaderText = "PID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle14.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle15.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle15.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle15.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle15.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle15.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column17, Me.Column18, Me.Column7, Me.Column8, Me.Column11, Me.Column12, Me.Column13, Me.Column19, Me.Column20, Me.Column9, Me.Column14, Me.Column10, Me.Column15, Me.Column16, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column37, Me.Column38, Me.Column39, Me.Column40, Me.Column41, Me.Column42 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle16.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle16.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle16.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle16.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle16.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle16
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(602, 82)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle17.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle17.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle17.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle17.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle17.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle17
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle18.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle18.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle18.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle18.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle18
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(514, 488)
			Me.dgw.TabIndex = 1783
			Me.dgw.TabStop = False
			Me.Column21.HeaderText = "Alter Unit"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column23.DefaultCellStyle = dataGridViewCellStyle19
			Me.Column23.HeaderText = "Minimum Stock"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle20.Format = "N2"
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle20
			Me.Column24.HeaderText = "MRP"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column24.Visible = False
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column25.DefaultCellStyle = dataGridViewCellStyle21
			Me.Column25.HeaderText = "Active"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column26.DefaultCellStyle = dataGridViewCellStyle22
			Me.Column26.HeaderText = "Sale Tax Type"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			dataGridViewCellStyle23.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column27.DefaultCellStyle = dataGridViewCellStyle23
			Me.Column27.HeaderText = "Purchase Tax Type"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			Me.Column28.HeaderText = "Godown"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column29.HeaderText = "Rack"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			dataGridViewCellStyle24.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column30.DefaultCellStyle = dataGridViewCellStyle24
			Me.Column30.HeaderText = "Default Sale Qty"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			dataGridViewCellStyle25.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column31.DefaultCellStyle = dataGridViewCellStyle25
			Me.Column31.HeaderText = "Opening Stock"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column32.HeaderText = "Barcode"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			dataGridViewCellStyle26.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle26.Format = "N2"
			Me.Column33.DefaultCellStyle = dataGridViewCellStyle26
			Me.Column33.HeaderText = "MRP"
			Me.Column33.Name = "Column33"
			Me.Column33.[ReadOnly] = True
			dataGridViewCellStyle27.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle27.Format = "N2"
			Me.Column34.DefaultCellStyle = dataGridViewCellStyle27
			Me.Column34.HeaderText = "Retail Sale Price"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			dataGridViewCellStyle28.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle28.Format = "N2"
			Me.Column35.DefaultCellStyle = dataGridViewCellStyle28
			Me.Column35.HeaderText = "Wholesale Sale Price"
			Me.Column35.Name = "Column35"
			Me.Column35.[ReadOnly] = True
			Me.Column36.HeaderText = "Batch"
			Me.Column36.Name = "Column36"
			Me.Column36.[ReadOnly] = True
			Me.Column37.HeaderText = "Mfg Date"
			Me.Column37.Name = "Column37"
			Me.Column37.[ReadOnly] = True
			Me.Column38.HeaderText = "Exp Date"
			Me.Column38.Name = "Column38"
			Me.Column38.[ReadOnly] = True
			Me.Column39.HeaderText = "Size"
			Me.Column39.Name = "Column39"
			Me.Column39.[ReadOnly] = True
			Me.Column40.HeaderText = "Colour"
			Me.Column40.Name = "Column40"
			Me.Column40.[ReadOnly] = True
			Me.Column41.HeaderText = "Product Order Section"
			Me.Column41.Name = "Column41"
			Me.Column41.[ReadOnly] = True
			Me.Column42.HeaderText = "Select"
			Me.Column42.Name = "Column42"
			Me.Column42.[ReadOnly] = True
			Me.Column42.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column42.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.txtTopResult.Location = New Global.System.Drawing.Point(1079, 3)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(43, 20)
			Me.txtTopResult.TabIndex = 1788
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label10.AutoSize = True
			Me.Label10.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label10.ForeColor = Global.System.Drawing.Color.White
			Me.Label10.Location = New Global.System.Drawing.Point(599, 3)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label10.TabIndex = 1790
			Me.Label10.Text = "Records"
			Me.Label10.Visible = False
			Me.txtSearchBarcode.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSearchBarcode.Location = New Global.System.Drawing.Point(975, 30)
			Me.txtSearchBarcode.Name = "txtSearchBarcode"
			Me.txtSearchBarcode.Size = New Global.System.Drawing.Size(123, 21)
			Me.txtSearchBarcode.TabIndex = 1785
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(968, 14)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label5.TabIndex = 1786
			Me.Label5.Text = "Barcode :"
			Me.txtProductName.BackColor = Global.System.Drawing.Color.White
			Me.txtProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductName.Location = New Global.System.Drawing.Point(781, 30)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.Size = New Global.System.Drawing.Size(188, 21)
			Me.txtProductName.TabIndex = 1784
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(778, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label3.TabIndex = 1787
			Me.Label3.Text = "Search By Product Name :"
			Me.Label11.AutoSize = True
			Me.Label11.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label11.ForeColor = Global.System.Drawing.Color.White
			Me.Label11.Location = New Global.System.Drawing.Point(1052, 6)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label11.TabIndex = 1789
			Me.Label11.Text = "Top"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1132, 584)
			MyBase.Controls.Add(Me.Label21)
			MyBase.Controls.Add(Me.CheckBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.txtTopResult)
			MyBase.Controls.Add(Me.Label10)
			MyBase.Controls.Add(Me.txtSearchBarcode)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.txtProductName)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label11)
			MyBase.Name = "frmEProduct"
			Me.Text = "frmEProduct"
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400049C RID: 1180
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
