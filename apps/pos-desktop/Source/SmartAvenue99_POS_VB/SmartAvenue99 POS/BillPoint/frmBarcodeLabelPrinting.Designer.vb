Namespace BillPoint
	' Token: 0x0200058E RID: 1422
		Public Partial Class frmBarcodeLabelPrinting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060115FE RID: 71166 RVA: 0x00A13270 File Offset: 0x00A11470
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

		' Token: 0x060115FF RID: 71167 RVA: 0x00A132C0 File Offset: 0x00A114C0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBarcodeLabelPrinting))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtIDs = New Global.System.Windows.Forms.TextBox()
			Me.txtVariant = New Global.System.Windows.Forms.TextBox()
			Me.btnAddCustomer = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.txtSearch = New Global.System.Windows.Forms.TextBox()
			Me.txtPInv = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.txtBCode = New Global.System.Windows.Forms.TextBox()
			Me.txtPCode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.columnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader12 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader13 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader14 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader15 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader16 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader17 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader18 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader19 = New Global.System.Windows.Forms.ColumnHeader()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.RadioButton2 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton1 = New Global.System.Windows.Forms.RadioButton()
			Me.txtNoOfCopies = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.txtCompany = New Global.System.Windows.Forms.TextBox()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.dgwBill = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn53 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn54 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.PictureBox5 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton11 = New Global.GelButtons.GelButton()
			Me.pnlPrinterSeting = New Global.System.Windows.Forms.Panel()
			Me.chkShowImageSetting = New Global.System.Windows.Forms.CheckBox()
			Me.chkSettingCashDraw = New Global.System.Windows.Forms.CheckBox()
			Me.Label196 = New Global.System.Windows.Forms.Label()
			Me.cmbPrinterType = New Global.System.Windows.Forms.ComboBox()
			Me.Label197 = New Global.System.Windows.Forms.Label()
			Me.txtTillID = New Global.System.Windows.Forms.TextBox()
			Me.FlowPanelBill = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.lblCategoryId = New Global.System.Windows.Forms.Label()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlPrinterSeting.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.txtIDs)
			Me.GroupBox1.Controls.Add(Me.txtVariant)
			Me.GroupBox1.Controls.Add(Me.btnAddCustomer)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.ComboBox2)
			Me.GroupBox1.Controls.Add(Me.txtSearch)
			Me.GroupBox1.Controls.Add(Me.txtPInv)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Controls.Add(Me.txtBCode)
			Me.GroupBox1.Controls.Add(Me.txtPCode)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Location = New Global.System.Drawing.Point(10, 12)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(711, 65)
			Me.GroupBox1.TabIndex = 26
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search"
			Me.txtIDs.Location = New Global.System.Drawing.Point(87, 11)
			Me.txtIDs.Name = "txtIDs"
			Me.txtIDs.Size = New Global.System.Drawing.Size(64, 20)
			Me.txtIDs.TabIndex = 526
			Me.txtVariant.Location = New Global.System.Drawing.Point(257, 10)
			Me.txtVariant.Name = "txtVariant"
			Me.txtVariant.Size = New Global.System.Drawing.Size(107, 20)
			Me.txtVariant.TabIndex = 525
			Me.btnAddCustomer.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnAddCustomer.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnAddCustomer.FlatAppearance.BorderSize = 0
			Me.btnAddCustomer.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAddCustomer.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddCustomer.ForeColor = Global.System.Drawing.Color.White
			Me.btnAddCustomer.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnAddCustomer.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnAddCustomer.Image = CType(componentResourceManager.GetObject("btnAddCustomer.Image"), Global.System.Drawing.Image)
			Me.btnAddCustomer.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAddCustomer.Location = New Global.System.Drawing.Point(567, 18)
			Me.btnAddCustomer.Name = "btnAddCustomer"
			Me.btnAddCustomer.Size = New Global.System.Drawing.Size(138, 37)
			Me.btnAddCustomer.TabIndex = 524
			Me.btnAddCustomer.Text = "Print Preview"
			Me.btnAddCustomer.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAddCustomer.UseVisualStyleBackColor = False
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(367, 17)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label1.TabIndex = 77
			Me.Label1.Text = "Template Type :"
			Me.Label1.Visible = False
			Me.ComboBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "Standard A4 Size (2 x 1)", "Standard (L) Single (2 x 1)", "TVS Printer Dual (2 x 1)", "Standard Single (1 x 0.5)", "Standard (C) Single (2 x 1)", "Standard Single (1.5x1.5)", "Standard Single (3 x 1.5)", "Double Size Dual (2 x 1)", "Standard Dual (2 x 1)", "Standard Single (1.5 x 3)", "Standard A4 4PCS(2 x 1)", "Standard A4 8PCS(2 x 1)", "Barcode Customise Single", "Barcode Customise A4" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(370, 33)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(191, 21)
			Me.ComboBox2.TabIndex = 76
			Me.ComboBox2.Visible = False
			Me.txtSearch.Location = New Global.System.Drawing.Point(167, 35)
			Me.txtSearch.Name = "txtSearch"
			Me.txtSearch.Size = New Global.System.Drawing.Size(197, 20)
			Me.txtSearch.TabIndex = 75
			Me.txtPInv.Location = New Global.System.Drawing.Point(526, 11)
			Me.txtPInv.Name = "txtPInv"
			Me.txtPInv.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtPInv.TabIndex = 35
			Me.txtPInv.TabStop = False
			Me.txtPInv.Visible = False
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Product Name", "Category", "Barcode", "Part No", "HSNC", "Batch", "Size", "Colour" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(11, 34)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(140, 21)
			Me.ComboBox1.TabIndex = 74
			Me.txtBCode.Location = New Global.System.Drawing.Point(393, 14)
			Me.txtBCode.Name = "txtBCode"
			Me.txtBCode.Size = New Global.System.Drawing.Size(28, 20)
			Me.txtBCode.TabIndex = 28
			Me.txtBCode.TabStop = False
			Me.txtBCode.Visible = False
			Me.txtPCode.Location = New Global.System.Drawing.Point(427, 14)
			Me.txtPCode.Name = "txtPCode"
			Me.txtPCode.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtPCode.TabIndex = 27
			Me.txtPCode.TabStop = False
			Me.txtPCode.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(164, 17)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label2.TabIndex = 26
			Me.Label2.Text = "Search :"
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.Color.Black
			Me.Label3.Location = New Global.System.Drawing.Point(7, 17)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label3.TabIndex = 22
			Me.Label3.Text = "Search Type :"
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 220, 128)
			Me.listView1.BackgroundImageTiled = True
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader3, Me.Category, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(10, 114)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(793, 547)
			Me.listView1.TabIndex = 67
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.columnHeader1.Text = "P Code"
			Me.columnHeader1.Width = 70
			Me.columnHeader3.Text = "Product Name"
			Me.columnHeader3.Width = 320
			Me.Category.Text = "Category"
			Me.Category.Width = 0
			Me.ColumnHeader2.Text = "Barcode"
			Me.ColumnHeader2.Width = 120
			Me.ColumnHeader4.Text = "Available Qty."
			Me.ColumnHeader4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader4.Width = 100
			Me.ColumnHeader5.Text = "No(s) of Copy"
			Me.ColumnHeader5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader5.Width = 100
			Me.ColumnHeader6.Text = "Part No"
			Me.ColumnHeader6.Width = 100
			Me.ColumnHeader7.Text = "HSNC"
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader7.Width = 100
			Me.ColumnHeader8.Text = "MRP"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader8.Width = 100
			Me.ColumnHeader9.Text = "Sale Price"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader10.Text = "W Sale Price"
			Me.ColumnHeader10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader10.Width = 100
			Me.ColumnHeader11.Text = "Batch"
			Me.ColumnHeader11.Width = 100
			Me.ColumnHeader12.Text = "Mfg Date"
			Me.ColumnHeader12.Width = 100
			Me.ColumnHeader13.Text = "Exp Date"
			Me.ColumnHeader13.Width = 100
			Me.ColumnHeader14.Text = "Size"
			Me.ColumnHeader14.Width = 100
			Me.ColumnHeader15.Text = "Colour"
			Me.ColumnHeader15.Width = 100
			Me.ColumnHeader16.Text = "GST%"
			Me.ColumnHeader16.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader16.Width = 100
			Me.ColumnHeader17.Text = "Purchse Inv No"
			Me.ColumnHeader17.Width = 0
			Me.ColumnHeader18.Text = "Qr"
			Me.ColumnHeader19.Text = "Discount"
			Me.GroupBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.GelButton3)
			Me.GroupBox2.Controls.Add(Me.RadioButton2)
			Me.GroupBox2.Controls.Add(Me.RadioButton1)
			Me.GroupBox2.Controls.Add(Me.txtNoOfCopies)
			Me.GroupBox2.Controls.Add(Me.CheckBox1)
			Me.GroupBox2.Controls.Add(Me.txtCompany)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.Yellow
			Me.GroupBox2.Location = New Global.System.Drawing.Point(1317, 12)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(229, 103)
			Me.GroupBox2.TabIndex = 70
			Me.GroupBox2.TabStop = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(123, 65)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 29)
			Me.GelButton1.TabIndex = 1682
			Me.GelButton1.Text = "&Edit Mode"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(122, 11)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 29)
			Me.GelButton3.TabIndex = 1683
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.RadioButton2.AutoSize = True
			Me.RadioButton2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton2.ForeColor = Global.System.Drawing.Color.Blue
			Me.RadioButton2.Location = New Global.System.Drawing.Point(185, 46)
			Me.RadioButton2.Name = "RadioButton2"
			Me.RadioButton2.Size = New Global.System.Drawing.Size(41, 17)
			Me.RadioButton2.TabIndex = 1681
			Me.RadioButton2.Text = "B-2"
			Me.RadioButton2.UseVisualStyleBackColor = True
			Me.RadioButton1.AutoSize = True
			Me.RadioButton1.Checked = True
			Me.RadioButton1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.RadioButton1.ForeColor = Global.System.Drawing.Color.Blue
			Me.RadioButton1.Location = New Global.System.Drawing.Point(123, 46)
			Me.RadioButton1.Name = "RadioButton1"
			Me.RadioButton1.Size = New Global.System.Drawing.Size(41, 17)
			Me.RadioButton1.TabIndex = 1680
			Me.RadioButton1.TabStop = True
			Me.RadioButton1.Text = "B-1"
			Me.RadioButton1.UseVisualStyleBackColor = True
			Me.txtNoOfCopies.BackColor = Global.System.Drawing.Color.White
			Me.txtNoOfCopies.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtNoOfCopies.Location = New Global.System.Drawing.Point(6, 55)
			Me.txtNoOfCopies.Name = "txtNoOfCopies"
			Me.txtNoOfCopies.Size = New Global.System.Drawing.Size(99, 26)
			Me.txtNoOfCopies.TabIndex = 27
			Me.txtNoOfCopies.Text = "1"
			Me.txtNoOfCopies.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.CheckBox1.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(6, 21)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(99, 32)
			Me.CheckBox1.TabIndex = 1679
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "No(s) of Copy for All Products"
			Me.CheckBox1.UseVisualStyleBackColor = False
			Me.txtCompany.Location = New Global.System.Drawing.Point(252, 7)
			Me.txtCompany.Name = "txtCompany"
			Me.txtCompany.[ReadOnly] = True
			Me.txtCompany.Size = New Global.System.Drawing.Size(39, 20)
			Me.txtCompany.TabIndex = 70
			Me.txtCompany.TabStop = False
			Me.txtCompany.Visible = False
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(10, 86)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 27
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(798, 83)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(57, 20)
			Me.TextBox1.TabIndex = 72
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
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
			Me.dgwBill.Location = New Global.System.Drawing.Point(783, 5)
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
			Me.dgwBill.Size = New Global.System.Drawing.Size(118, 70)
			Me.dgwBill.TabIndex = 444
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
			Me.DataGridViewTextBoxColumn53.HeaderText = "Print Preview Type"
			Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
			Me.DataGridViewTextBoxColumn53.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn54.HeaderText = "Column4"
			Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
			Me.DataGridViewTextBoxColumn54.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn54.Visible = False
			Me.PictureBox5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.PictureBox5.Location = New Global.System.Drawing.Point(1051, 163)
			Me.PictureBox5.Name = "PictureBox5"
			Me.PictureBox5.Size = New Global.System.Drawing.Size(500, 500)
			Me.PictureBox5.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox5.TabIndex = 450
			Me.PictureBox5.TabStop = False
			Me.GelButton11.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton11.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.FlatAppearance.BorderSize = 0
			Me.GelButton11.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton11.Font = New Global.System.Drawing.Font("Segoe UI Black", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton11.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton11.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton11.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton11.Image = CType(componentResourceManager.GetObject("GelButton11.Image"), Global.System.Drawing.Image)
			Me.GelButton11.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton11.Location = New Global.System.Drawing.Point(1397, 128)
			Me.GelButton11.Name = "GelButton11"
			Me.GelButton11.Size = New Global.System.Drawing.Size(146, 29)
			Me.GelButton11.TabIndex = 451
			Me.GelButton11.Text = "Apply"
			Me.GelButton11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton11.UseVisualStyleBackColor = False
			Me.pnlPrinterSeting.Controls.Add(Me.chkShowImageSetting)
			Me.pnlPrinterSeting.Controls.Add(Me.chkSettingCashDraw)
			Me.pnlPrinterSeting.Controls.Add(Me.Label196)
			Me.pnlPrinterSeting.Controls.Add(Me.cmbPrinterType)
			Me.pnlPrinterSeting.Controls.Add(Me.Label197)
			Me.pnlPrinterSeting.Controls.Add(Me.txtTillID)
			Me.pnlPrinterSeting.Location = New Global.System.Drawing.Point(1047, 623)
			Me.pnlPrinterSeting.Name = "pnlPrinterSeting"
			Me.pnlPrinterSeting.Size = New Global.System.Drawing.Size(132, 21)
			Me.pnlPrinterSeting.TabIndex = 10030
			Me.pnlPrinterSeting.Visible = False
			Me.chkShowImageSetting.AutoSize = True
			Me.chkShowImageSetting.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkShowImageSetting.Location = New Global.System.Drawing.Point(113, 126)
			Me.chkShowImageSetting.Name = "chkShowImageSetting"
			Me.chkShowImageSetting.Size = New Global.System.Drawing.Size(199, 19)
			Me.chkShowImageSetting.TabIndex = 10016
			Me.chkShowImageSetting.Text = "Show Menu Item Images in POS"
			Me.chkShowImageSetting.UseVisualStyleBackColor = True
			Me.chkSettingCashDraw.AutoSize = True
			Me.chkSettingCashDraw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSettingCashDraw.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSettingCashDraw.Location = New Global.System.Drawing.Point(113, 101)
			Me.chkSettingCashDraw.Name = "chkSettingCashDraw"
			Me.chkSettingCashDraw.Size = New Global.System.Drawing.Size(183, 19)
			Me.chkSettingCashDraw.TabIndex = 12
			Me.chkSettingCashDraw.Text = "Cash Drawer Active (Yes / No)"
			Me.chkSettingCashDraw.UseVisualStyleBackColor = True
			Me.Label196.AutoSize = True
			Me.Label196.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label196.Location = New Global.System.Drawing.Point(5, 54)
			Me.Label196.Name = "Label196"
			Me.Label196.Size = New Global.System.Drawing.Size(132, 15)
			Me.Label196.TabIndex = 11
			Me.Label196.Text = "Invoice Template Type :"
			Me.cmbPrinterType.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbPrinterType.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPrinterType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPrinterType.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbPrinterType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPrinterType.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbPrinterType.FormattingEnabled = True
			Me.cmbPrinterType.Items.AddRange(New Object() { "Laser Printer", "Thermal Printer" })
			Me.cmbPrinterType.Location = New Global.System.Drawing.Point(8, 72)
			Me.cmbPrinterType.Name = "cmbPrinterType"
			Me.cmbPrinterType.Size = New Global.System.Drawing.Size(307, 23)
			Me.cmbPrinterType.TabIndex = 9
			Me.Label197.AutoSize = True
			Me.Label197.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label197.Location = New Global.System.Drawing.Point(5, 5)
			Me.Label197.Name = "Label197"
			Me.Label197.Size = New Global.System.Drawing.Size(75, 15)
			Me.Label197.TabIndex = 10
			Me.Label197.Text = "Terminal ID :"
			Me.txtTillID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTillID.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTillID.Location = New Global.System.Drawing.Point(8, 23)
			Me.txtTillID.Name = "txtTillID"
			Me.txtTillID.Size = New Global.System.Drawing.Size(307, 23)
			Me.txtTillID.TabIndex = 8
			Me.FlowPanelBill.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.FlowPanelBill.AutoScroll = True
			Me.FlowPanelBill.BackColor = Global.System.Drawing.Color.AliceBlue
			Me.FlowPanelBill.Location = New Global.System.Drawing.Point(809, 115)
			Me.FlowPanelBill.Name = "FlowPanelBill"
			Me.FlowPanelBill.Size = New Global.System.Drawing.Size(237, 553)
			Me.FlowPanelBill.TabIndex = 10031
			Me.lblCategoryId.AutoSize = True
			Me.lblCategoryId.Location = New Global.System.Drawing.Point(964, 19)
			Me.lblCategoryId.Name = "lblCategoryId"
			Me.lblCategoryId.Size = New Global.System.Drawing.Size(13, 13)
			Me.lblCategoryId.TabIndex = 10032
			Me.lblCategoryId.Text = "0"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1556, 668)
			MyBase.Controls.Add(Me.lblCategoryId)
			MyBase.Controls.Add(Me.FlowPanelBill)
			MyBase.Controls.Add(Me.pnlPrinterSeting)
			MyBase.Controls.Add(Me.GelButton11)
			MyBase.Controls.Add(Me.PictureBox5)
			MyBase.Controls.Add(Me.dgwBill)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.Name = "frmBarcodeLabelPrinting"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "General Barcode Label Printing"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.dgwBill, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox5, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlPrinterSeting.ResumeLayout(False)
			Me.pnlPrinterSeting.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040068B3 RID: 26803
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
