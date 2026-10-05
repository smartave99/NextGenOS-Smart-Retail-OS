Namespace BillPoint
	' Token: 0x020001DC RID: 476
		Public Partial Class frmProductPlus
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007F48 RID: 32584 RVA: 0x005E9824 File Offset: 0x005E7A24
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

		' Token: 0x06007F49 RID: 32585 RVA: 0x005E9874 File Offset: 0x005E7A74
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductPlus))
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
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.cmbRack = New Global.System.Windows.Forms.ComboBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.cmbGDown = New Global.System.Windows.Forms.ComboBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtSubCategory = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtCategory = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtProductName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
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
			Me.Panel5.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-2, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1214, 35)
			Me.Label1.TabIndex = 54
			Me.Label1.Text = "List of Products"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.btnShowAll)
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Location = New Global.System.Drawing.Point(837, 40)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(321, 96)
			Me.Panel5.TabIndex = 55
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.Label9)
			Me.Panel3.Controls.Add(Me.cmbRack)
			Me.Panel3.Controls.Add(Me.Label8)
			Me.Panel3.Controls.Add(Me.cmbGDown)
			Me.Panel3.Controls.Add(Me.Label7)
			Me.Panel3.Controls.Add(Me.TextBox1)
			Me.Panel3.Controls.Add(Me.ComboBox1)
			Me.Panel3.Controls.Add(Me.Label6)
			Me.Panel3.Controls.Add(Me.txtBarcode)
			Me.Panel3.Controls.Add(Me.Label5)
			Me.Panel3.Controls.Add(Me.txtSubCategory)
			Me.Panel3.Controls.Add(Me.Label4)
			Me.Panel3.Controls.Add(Me.txtCategory)
			Me.Panel3.Controls.Add(Me.Label2)
			Me.Panel3.Controls.Add(Me.txtProductName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(8, 41)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(714, 96)
			Me.Panel3.TabIndex = 53
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(546, 48)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label9.TabIndex = 56
			Me.Label9.Text = "Search By Rack :"
			Me.Label9.Visible = False
			Me.cmbRack.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbRack.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbRack.FormattingEnabled = True
			Me.cmbRack.Items.AddRange(New Object() { "Active", "Deactive" })
			Me.cmbRack.Location = New Global.System.Drawing.Point(549, 68)
			Me.cmbRack.Name = "cmbRack"
			Me.cmbRack.Size = New Global.System.Drawing.Size(159, 21)
			Me.cmbRack.TabIndex = 7
			Me.cmbRack.Visible = False
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(546, 1)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(105, 13)
			Me.Label8.TabIndex = 54
			Me.Label8.Text = "Search By Godown :"
			Me.Label8.Visible = False
			Me.cmbGDown.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbGDown.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbGDown.FormattingEnabled = True
			Me.cmbGDown.Items.AddRange(New Object() { "Active", "Deactive" })
			Me.cmbGDown.Location = New Global.System.Drawing.Point(549, 21)
			Me.cmbGDown.Name = "cmbGDown"
			Me.cmbGDown.Size = New Global.System.Drawing.Size(159, 21)
			Me.cmbGDown.TabIndex = 3
			Me.cmbGDown.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(363, 48)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label7.TabIndex = 14
			Me.Label7.Text = "Search By Status :"
			Me.Label7.Visible = False
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(366, 21)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(159, 21)
			Me.TextBox1.TabIndex = 2
			Me.TextBox1.Visible = False
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Active", "Deactive" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(366, 68)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(159, 21)
			Me.ComboBox1.TabIndex = 6
			Me.ComboBox1.Visible = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(363, 1)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(121, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Search By Part /Group :"
			Me.Label6.Visible = False
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.White
			Me.txtBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(184, 68)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(159, 21)
			Me.txtBarcode.TabIndex = 5
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(181, 48)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(105, 13)
			Me.Label5.TabIndex = 12
			Me.Label5.Text = "Search By Barcode :"
			Me.txtSubCategory.BackColor = Global.System.Drawing.Color.White
			Me.txtSubCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSubCategory.Location = New Global.System.Drawing.Point(184, 21)
			Me.txtSubCategory.Name = "txtSubCategory"
			Me.txtSubCategory.Size = New Global.System.Drawing.Size(159, 21)
			Me.txtSubCategory.TabIndex = 1
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(181, 1)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(168, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Sub Category / Brand :"
			Me.txtCategory.BackColor = Global.System.Drawing.Color.White
			Me.txtCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCategory.Location = New Global.System.Drawing.Point(3, 68)
			Me.txtCategory.Name = "txtCategory"
			Me.txtCategory.Size = New Global.System.Drawing.Size(159, 21)
			Me.txtCategory.TabIndex = 4
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(0, 48)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label2.TabIndex = 12
			Me.Label2.Text = "Search By Category :"
			Me.txtProductName.BackColor = Global.System.Drawing.Color.White
			Me.txtProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductName.Location = New Global.System.Drawing.Point(3, 21)
			Me.txtProductName.Name = "txtProductName"
			Me.txtProductName.Size = New Global.System.Drawing.Size(159, 21)
			Me.txtProductName.TabIndex = 0
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(0, 1)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Product Name :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
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
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column17, Me.Column18, Me.Column7, Me.Column8, Me.Column11, Me.Column12, Me.Column13, Me.Column19, Me.Column20, Me.Column9, Me.Column14, Me.Column10, Me.Column15, Me.Column16, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35, Me.Column36, Me.Column37, Me.Column38, Me.Column39, Me.Column40, Me.Column41 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(8, 143)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1150, 410)
			Me.dgw.TabIndex = 52
			Me.dgw.TabStop = False
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnShowAll.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(131, 2)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(184, 89)
			Me.btnShowAll.TabIndex = 516
			Me.btnShowAll.Text = "Show All Products   - F1"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(3, 48)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnExportExcel.TabIndex = 515
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnReset.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnReset.TabIndex = 514
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Column1.HeaderText = "PID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.FillWeight = 163.6364F
			Me.Column2.HeaderText = "Product Code"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.FillWeight = 152.4618F
			Me.Column3.HeaderText = "Product Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 200
			Me.Column4.HeaderText = "Sub Category ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Column5.FillWeight = 142.1764F
			Me.Column5.HeaderText = "Category"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.FillWeight = 132.7159F
			Me.Column6.HeaderText = "Sub Category / Brand"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column17.FillWeight = 124.0205F
			Me.Column17.HeaderText = "HSN Code"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column18.FillWeight = 116.0919F
			Me.Column18.HeaderText = "Part / Group"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column18.Visible = False
			Me.Column7.FillWeight = 108.7626F
			Me.Column7.HeaderText = "Description"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle6.Format = "N2"
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column8.FillWeight = 102.0445F
			Me.Column8.HeaderText = "Purchase Price"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.FillWeight = 95.89358F
			Me.Column11.HeaderText = "Retail Sale Price"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Visible = False
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column12.FillWeight = 90.26913F
			Me.Column12.HeaderText = "Discount %"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column13.FillWeight = 85.13367F
			Me.Column13.HeaderText = "CGST %"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column19.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column19.FillWeight = 80.45252F
			Me.Column19.HeaderText = "SGST/UTGST %"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column20.FillWeight = 76.19376F
			Me.Column20.HeaderText = "CESS %"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			dataGridViewCellStyle12.Format = "N2"
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column9.FillWeight = 72.32803F
			Me.Column9.HeaderText = "Wholesale Sale Price"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			Me.Column14.FillWeight = 68.8817F
			Me.Column14.HeaderText = "Barcode"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column14.Visible = False
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column10.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column10.FillWeight = 65.72141F
			Me.Column10.HeaderText = "Opening Stock"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column15.FillWeight = 62.87987F
			Me.Column15.HeaderText = "Purchase Unit"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column15.Visible = False
			Me.Column16.FillWeight = 60.33623F
			Me.Column16.HeaderText = "Sales Unit"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column21.HeaderText = "Alter Unit"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column21.Visible = False
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column22.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column22.HeaderText = "Conversion Value"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column22.Visible = False
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column23.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column23.HeaderText = "Minimum Stock"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Visible = False
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle16.Format = "N2"
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle16
			Me.Column24.HeaderText = "MRP"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column24.Visible = False
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column25.DefaultCellStyle = dataGridViewCellStyle17
			Me.Column25.HeaderText = "Active"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column25.Visible = False
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column26.DefaultCellStyle = dataGridViewCellStyle18
			Me.Column26.HeaderText = "Sale Tax Type"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column26.Visible = False
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column27.DefaultCellStyle = dataGridViewCellStyle19
			Me.Column27.HeaderText = "Purchase Tax Type"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			Me.Column27.Visible = False
			Me.Column28.HeaderText = "Godown"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column28.Visible = False
			Me.Column29.HeaderText = "Rack"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column29.Visible = False
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column30.DefaultCellStyle = dataGridViewCellStyle20
			Me.Column30.HeaderText = "Default Sale Qty"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column31.DefaultCellStyle = dataGridViewCellStyle21
			Me.Column31.HeaderText = "Opening Stock_1"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column32.HeaderText = "Barcode_1"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle22.Format = "N2"
			Me.Column33.DefaultCellStyle = dataGridViewCellStyle22
			Me.Column33.HeaderText = "MRP_1"
			Me.Column33.Name = "Column33"
			Me.Column33.[ReadOnly] = True
			dataGridViewCellStyle23.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle23.Format = "N2"
			Me.Column34.DefaultCellStyle = dataGridViewCellStyle23
			Me.Column34.HeaderText = "Retail Sale Price_1"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			dataGridViewCellStyle24.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle24.Format = "N2"
			Me.Column35.DefaultCellStyle = dataGridViewCellStyle24
			Me.Column35.HeaderText = "Wholesale Sale Price_1"
			Me.Column35.Name = "Column35"
			Me.Column35.[ReadOnly] = True
			Me.Column36.HeaderText = "Batch"
			Me.Column36.Name = "Column36"
			Me.Column36.[ReadOnly] = True
			Me.Column36.Visible = False
			Me.Column37.HeaderText = "Mfg Date"
			Me.Column37.Name = "Column37"
			Me.Column37.[ReadOnly] = True
			Me.Column37.Visible = False
			Me.Column38.HeaderText = "Exp Date"
			Me.Column38.Name = "Column38"
			Me.Column38.[ReadOnly] = True
			Me.Column38.Visible = False
			Me.Column39.HeaderText = "Size"
			Me.Column39.Name = "Column39"
			Me.Column39.[ReadOnly] = True
			Me.Column39.Visible = False
			Me.Column40.HeaderText = "Colour"
			Me.Column40.Name = "Column40"
			Me.Column40.[ReadOnly] = True
			Me.Column40.Visible = False
			Me.Column41.HeaderText = "Product Order Section"
			Me.Column41.Name = "Column41"
			Me.Column41.[ReadOnly] = True
			Me.Column41.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1162, 565)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Panel5)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Name = "frmProductPlus"
			Me.Text = "frmProductPlus"
			Me.Panel5.ResumeLayout(False)
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400382F RID: 14383
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
