Namespace BillPoint
	' Token: 0x020001D7 RID: 471
		Public Partial Class frmProductDefault
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007DBF RID: 32191 RVA: 0x005DB5A8 File Offset: 0x005D97A8
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

		' Token: 0x06007DC0 RID: 32192 RVA: 0x005DB5F8 File Offset: 0x005D97F8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductDefault))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.chkSubCategroy = New Global.System.Windows.Forms.CheckBox()
			Me.cmbSubCategory = New Global.System.Windows.Forms.ComboBox()
			Me.btnSubCategroy = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.ChkUnit = New Global.System.Windows.Forms.CheckBox()
			Me.cmbSalesUnit = New Global.System.Windows.Forms.ComboBox()
			Me.btnUnit = New Global.GelButtons.GelButton()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.ChkGST = New Global.System.Windows.Forms.CheckBox()
			Me.cmbGST = New Global.System.Windows.Forms.ComboBox()
			Me.btnGST = New Global.GelButtons.GelButton()
			Me.lblSource = New Global.System.Windows.Forms.Label()
			Me.dgwBill = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn53 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn54 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.PictureBox5 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.cmbSTax = New Global.System.Windows.Forms.ComboBox()
			Me.cmbPTax = New Global.System.Windows.Forms.ComboBox()
			Me.Label25 = New Global.System.Windows.Forms.Label()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.lblform = New Global.System.Windows.Forms.Label()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.txtDiscountRate = New Global.System.Windows.Forms.TextBox()
			Me.btnDiscount = New Global.GelButtons.GelButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.FlowPanelBill = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox4.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox2.Controls.Add(Me.chkSubCategroy)
			Me.GroupBox2.Controls.Add(Me.cmbSubCategory)
			Me.GroupBox2.Controls.Add(Me.btnSubCategroy)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(12, 43)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(479, 83)
			Me.GroupBox2.TabIndex = 46
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Sub Category / Brand :"
			Me.chkSubCategroy.AutoSize = True
			Me.chkSubCategroy.Checked = True
			Me.chkSubCategroy.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSubCategroy.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSubCategroy.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSubCategroy.Location = New Global.System.Drawing.Point(231, 19)
			Me.chkSubCategroy.Name = "chkSubCategroy"
			Me.chkSubCategroy.Size = New Global.System.Drawing.Size(77, 17)
			Me.chkSubCategroy.TabIndex = 517
			Me.chkSubCategroy.TabStop = False
			Me.chkSubCategroy.Text = "Is Default "
			Me.chkSubCategroy.UseVisualStyleBackColor = True
			Me.cmbSubCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSubCategory.FormattingEnabled = True
			Me.cmbSubCategory.Location = New Global.System.Drawing.Point(10, 41)
			Me.cmbSubCategory.Name = "cmbSubCategory"
			Me.cmbSubCategory.Size = New Global.System.Drawing.Size(298, 21)
			Me.cmbSubCategory.TabIndex = 516
			Me.btnSubCategroy.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSubCategroy.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSubCategroy.FlatAppearance.BorderSize = 0
			Me.btnSubCategroy.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSubCategroy.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSubCategroy.ForeColor = Global.System.Drawing.Color.White
			Me.btnSubCategroy.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSubCategroy.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSubCategroy.Image = CType(componentResourceManager.GetObject("btnSubCategroy.Image"), Global.System.Drawing.Image)
			Me.btnSubCategroy.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSubCategroy.Location = New Global.System.Drawing.Point(326, 19)
			Me.btnSubCategroy.Name = "btnSubCategroy"
			Me.btnSubCategroy.Size = New Global.System.Drawing.Size(147, 43)
			Me.btnSubCategroy.TabIndex = 515
			Me.btnSubCategroy.Text = "Set Is Default "
			Me.btnSubCategroy.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSubCategroy.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.ChkUnit)
			Me.GroupBox1.Controls.Add(Me.cmbSalesUnit)
			Me.GroupBox1.Controls.Add(Me.btnUnit)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 140)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(479, 57)
			Me.GroupBox1.TabIndex = 322
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Unit :"
			Me.ChkUnit.AutoSize = True
			Me.ChkUnit.Checked = True
			Me.ChkUnit.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.ChkUnit.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ChkUnit.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ChkUnit.Location = New Global.System.Drawing.Point(231, 8)
			Me.ChkUnit.Name = "ChkUnit"
			Me.ChkUnit.Size = New Global.System.Drawing.Size(74, 17)
			Me.ChkUnit.TabIndex = 518
			Me.ChkUnit.TabStop = False
			Me.ChkUnit.Text = "Is Default"
			Me.ChkUnit.UseVisualStyleBackColor = True
			Me.cmbSalesUnit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSalesUnit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSalesUnit.FormattingEnabled = True
			Me.cmbSalesUnit.Location = New Global.System.Drawing.Point(10, 30)
			Me.cmbSalesUnit.Name = "cmbSalesUnit"
			Me.cmbSalesUnit.Size = New Global.System.Drawing.Size(298, 21)
			Me.cmbSalesUnit.TabIndex = 517
			Me.btnUnit.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUnit.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUnit.FlatAppearance.BorderSize = 0
			Me.btnUnit.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUnit.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUnit.ForeColor = Global.System.Drawing.Color.White
			Me.btnUnit.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnUnit.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnUnit.Image = CType(componentResourceManager.GetObject("btnUnit.Image"), Global.System.Drawing.Image)
			Me.btnUnit.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUnit.Location = New Global.System.Drawing.Point(326, 8)
			Me.btnUnit.Name = "btnUnit"
			Me.btnUnit.Size = New Global.System.Drawing.Size(147, 43)
			Me.btnUnit.TabIndex = 516
			Me.btnUnit.Text = "Set Is Default "
			Me.btnUnit.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUnit.UseVisualStyleBackColor = False
			Me.GroupBox3.Controls.Add(Me.ChkGST)
			Me.GroupBox3.Controls.Add(Me.cmbGST)
			Me.GroupBox3.Controls.Add(Me.btnGST)
			Me.GroupBox3.Controls.Add(Me.lblSource)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(12, 212)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(479, 68)
			Me.GroupBox3.TabIndex = 408
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "GST Rate % :"
			Me.ChkGST.AutoSize = True
			Me.ChkGST.Checked = True
			Me.ChkGST.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.ChkGST.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ChkGST.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ChkGST.Location = New Global.System.Drawing.Point(173, 14)
			Me.ChkGST.Name = "ChkGST"
			Me.ChkGST.Size = New Global.System.Drawing.Size(135, 17)
			Me.ChkGST.TabIndex = 548
			Me.ChkGST.TabStop = False
			Me.ChkGST.Text = "Is Default GST Rate %"
			Me.ChkGST.UseVisualStyleBackColor = True
			Me.cmbGST.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbGST.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbGST.FormattingEnabled = True
			Me.cmbGST.Location = New Global.System.Drawing.Point(10, 37)
			Me.cmbGST.Name = "cmbGST"
			Me.cmbGST.Size = New Global.System.Drawing.Size(298, 21)
			Me.cmbGST.TabIndex = 547
			Me.btnGST.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGST.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGST.FlatAppearance.BorderSize = 0
			Me.btnGST.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGST.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGST.ForeColor = Global.System.Drawing.Color.White
			Me.btnGST.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnGST.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnGST.Image = CType(componentResourceManager.GetObject("btnGST.Image"), Global.System.Drawing.Image)
			Me.btnGST.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGST.Location = New Global.System.Drawing.Point(326, 16)
			Me.btnGST.Name = "btnGST"
			Me.btnGST.Size = New Global.System.Drawing.Size(147, 43)
			Me.btnGST.TabIndex = 517
			Me.btnGST.Text = "Set Is Default "
			Me.btnGST.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGST.UseVisualStyleBackColor = False
			Me.lblSource.AutoSize = True
			Me.lblSource.Location = New Global.System.Drawing.Point(179, -13)
			Me.lblSource.Name = "lblSource"
			Me.lblSource.Size = New Global.System.Drawing.Size(41, 13)
			Me.lblSource.TabIndex = 546
			Me.lblSource.Text = "Source"
			Me.dgwBill.AllowUserToAddRows = False
			Me.dgwBill.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgwBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgwBill.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgwBill.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgwBill.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgwBill.ColumnHeadersHeight = 40
			Me.dgwBill.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn48, Me.DataGridViewTextBoxColumn53, Me.DataGridViewTextBoxColumn54 })
			Me.dgwBill.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgwBill.EnableHeadersVisualStyles = False
			Me.dgwBill.GridColor = Global.System.Drawing.Color.White
			Me.dgwBill.Location = New Global.System.Drawing.Point(270, 513)
			Me.dgwBill.MultiSelect = False
			Me.dgwBill.Name = "dgwBill"
			Me.dgwBill.[ReadOnly] = True
			Me.dgwBill.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgwBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgwBill.RowHeadersWidth = 29
			Me.dgwBill.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgwBill.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgwBill.RowTemplate.Height = 20
			Me.dgwBill.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgwBill.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgwBill.Size = New Global.System.Drawing.Size(99, 60)
			Me.dgwBill.TabIndex = 445
			Me.dgwBill.TabStop = False
			Me.dgwBill.Visible = False
			Me.DataGridViewTextBoxColumn46.HeaderText = "Sr"
			Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
			Me.DataGridViewTextBoxColumn46.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn46.Visible = False
			Me.DataGridViewTextBoxColumn48.FillWeight = 163.6364F
			Me.DataGridViewTextBoxColumn48.HeaderText = "Barcode Style Name"
			Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
			Me.DataGridViewTextBoxColumn48.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn48.Visible = False
			Me.DataGridViewTextBoxColumn48.Width = 200
			Me.DataGridViewTextBoxColumn53.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
			Me.DataGridViewTextBoxColumn53.HeaderText = "Barcode Preview Type"
			Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
			Me.DataGridViewTextBoxColumn53.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn54.HeaderText = "Column4"
			Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
			Me.DataGridViewTextBoxColumn54.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn54.Visible = False
			Me.PictureBox5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.PictureBox5.Location = New Global.System.Drawing.Point(1179, 47)
			Me.PictureBox5.Name = "PictureBox5"
			Me.PictureBox5.Size = New Global.System.Drawing.Size(403, 520)
			Me.PictureBox5.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox5.TabIndex = 451
			Me.PictureBox5.TabStop = False
			Me.GelButton11.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(1436, 12)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(146, 29)
			Me.GelButton11.TabIndex = 452
			Me.GelButton11.Text = "Apply"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.cmbSTax.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSTax.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSTax.FormattingEnabled = True
			Me.cmbSTax.Items.AddRange(New Object() { "Inclusive", "Exclusive", "Exempt GST", "No Taxes" })
			Me.cmbSTax.Location = New Global.System.Drawing.Point(152, 292)
			Me.cmbSTax.Name = "cmbSTax"
			Me.cmbSTax.Size = New Global.System.Drawing.Size(165, 21)
			Me.cmbSTax.TabIndex = 1758
			Me.cmbPTax.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPTax.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPTax.FormattingEnabled = True
			Me.cmbPTax.Items.AddRange(New Object() { "Inclusive", "Exclusive", "Exempt GST", "No Taxes" })
			Me.cmbPTax.Location = New Global.System.Drawing.Point(155, 346)
			Me.cmbPTax.Name = "cmbPTax"
			Me.cmbPTax.Size = New Global.System.Drawing.Size(165, 21)
			Me.cmbPTax.TabIndex = 1759
			Me.Label25.AutoSize = True
			Me.Label25.Location = New Global.System.Drawing.Point(19, 346)
			Me.Label25.Name = "Label25"
			Me.Label25.Size = New Global.System.Drawing.Size(121, 13)
			Me.Label25.TabIndex = 1761
			Me.Label25.Text = "Tax Type on Purchase :"
			Me.Label24.AutoSize = True
			Me.Label24.Location = New Global.System.Drawing.Point(19, 300)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label24.TabIndex = 1760
			Me.Label24.Text = "Tax Type on Sale :"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(338, 283)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(147, 43)
			Me.GelButton1.TabIndex = 549
			Me.GelButton1.Text = "Set Is Default "
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(338, 332)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(147, 43)
			Me.GelButton2.TabIndex = 1762
			Me.GelButton2.Text = "Set Is Default "
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(338, 381)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(147, 43)
			Me.GelButton3.TabIndex = 1765
			Me.GelButton3.Text = "Set Is Default "
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "per", "point" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(93, 390)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(87, 21)
			Me.ComboBox1.TabIndex = 1763
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(19, 394)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label1.TabIndex = 1764
			Me.Label1.Text = "Select Mode :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(227, 390)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(93, 20)
			Me.TextBox1.TabIndex = 1766
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(183, 394)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(42, 13)
			Me.Label2.TabIndex = 1767
			Me.Label2.Text = "Points :"
			Me.lblform.AutoSize = True
			Me.lblform.Location = New Global.System.Drawing.Point(777, 469)
			Me.lblform.Name = "lblform"
			Me.lblform.Size = New Global.System.Drawing.Size(17, 13)
			Me.lblform.TabIndex = 1768
			Me.lblform.Text = "xx"
			Me.GroupBox4.Controls.Add(Me.txtDiscountRate)
			Me.GroupBox4.Controls.Add(Me.btnDiscount)
			Me.GroupBox4.Controls.Add(Me.Label3)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(12, 439)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(479, 68)
			Me.GroupBox4.TabIndex = 1769
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Discount Rate % :"
			Me.txtDiscountRate.Location = New Global.System.Drawing.Point(6, 19)
			Me.txtDiscountRate.Multiline = True
			Me.txtDiscountRate.Name = "txtDiscountRate"
			Me.txtDiscountRate.Size = New Global.System.Drawing.Size(133, 40)
			Me.txtDiscountRate.TabIndex = 1770
			Me.btnDiscount.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDiscount.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDiscount.FlatAppearance.BorderSize = 0
			Me.btnDiscount.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDiscount.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDiscount.ForeColor = Global.System.Drawing.Color.White
			Me.btnDiscount.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnDiscount.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnDiscount.Image = CType(componentResourceManager.GetObject("btnDiscount.Image"), Global.System.Drawing.Image)
			Me.btnDiscount.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDiscount.Location = New Global.System.Drawing.Point(326, 16)
			Me.btnDiscount.Name = "btnDiscount"
			Me.btnDiscount.Size = New Global.System.Drawing.Size(147, 43)
			Me.btnDiscount.TabIndex = 517
			Me.btnDiscount.Text = "Set Is Default "
			Me.btnDiscount.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDiscount.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(179, -13)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label3.TabIndex = 546
			Me.Label3.Text = "Source"
			Me.FlowPanelBill.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.FlowPanelBill.AutoScroll = True
			Me.FlowPanelBill.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.FlowPanelBill.Location = New Global.System.Drawing.Point(497, 47)
			Me.FlowPanelBill.Name = "FlowPanelBill"
			Me.FlowPanelBill.Size = New Global.System.Drawing.Size(666, 520)
			Me.FlowPanelBill.TabIndex = 10032
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1594, 579)
			MyBase.Controls.Add(Me.FlowPanelBill)
			MyBase.Controls.Add(Me.GroupBox4)
			MyBase.Controls.Add(Me.lblform)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.ComboBox1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.cmbSTax)
			MyBase.Controls.Add(Me.cmbPTax)
			MyBase.Controls.Add(Me.Label25)
			MyBase.Controls.Add(Me.Label24)
			MyBase.Controls.Add(Me.GelButton11)
			MyBase.Controls.Add(Me.PictureBox5)
			MyBase.Controls.Add(Me.dgwBill)
			MyBase.Controls.Add(Me.GroupBox3)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmProductDefault"
			Me.Text = "Product Default Setting"
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04003793 RID: 14227
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
