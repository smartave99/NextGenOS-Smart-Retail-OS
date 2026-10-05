Namespace BillPoint
	' Token: 0x02000016 RID: 22
		Public Partial Class frmBarcodeLabelPrintingnew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060004F5 RID: 1269 RVA: 0x0008843C File Offset: 0x0008663C
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

		' Token: 0x060004F6 RID: 1270 RVA: 0x0008848C File Offset: 0x0008668C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBarcodeLabelPrintingnew))
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader12 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader13 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader14 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader15 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader16 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader17 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader18 = New Global.System.Windows.Forms.ColumnHeader()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.RadioButton2 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton1 = New Global.System.Windows.Forms.RadioButton()
			Me.txtNoOfCopies = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.txtCompany = New Global.System.Windows.Forms.TextBox()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.columnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.btnAddCustomer = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.cmbLayouts = New Global.System.Windows.Forms.ComboBox()
			Me.txtSearch = New Global.System.Windows.Forms.TextBox()
			Me.txtPInv = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.txtBCode = New Global.System.Windows.Forms.TextBox()
			Me.txtPCode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.PrintDialog1 = New Global.System.Windows.Forms.PrintDialog()
			Me.PrintDocument1 = New Global.System.Drawing.Printing.PrintDocument()
			Me.PrintPreviewDialog1 = New Global.System.Windows.Forms.PrintPreviewDialog()
			Me.pnlCheque = New Global.System.Windows.Forms.Panel()
			Me.lblHidden = New Global.System.Windows.Forms.Label()
			Me.gbxChequeSize = New Global.System.Windows.Forms.GroupBox()
			Me.btnBgColor_Layout = New Global.System.Windows.Forms.Button()
			Me.lnklblSetDefault = New Global.System.Windows.Forms.LinkLabel()
			Me.lblChequeHeight = New Global.System.Windows.Forms.Label()
			Me.lblChequeWidth = New Global.System.Windows.Forms.Label()
			Me.nudChequeLeafWidth = New Global.System.Windows.Forms.NumericUpDown()
			Me.nudChequeHeight = New Global.System.Windows.Forms.NumericUpDown()
			Me.txtLayoutName = New Global.System.Windows.Forms.TextBox()
			Me.PageSetupDialog1 = New Global.System.Windows.Forms.PageSetupDialog()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.lblHiddenImage = New Global.System.Windows.Forms.Label()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.gbxChequeSize.SuspendLayout()
			CType(Me.nudChequeLeafWidth, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nudChequeHeight, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.ColumnHeader8.Text = "MRP"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader8.Width = 100
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
			Me.GroupBox2.Location = New Global.System.Drawing.Point(956, 10)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(229, 103)
			Me.GroupBox2.TabIndex = 76
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
			Me.GelButton1.Visible = False
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
			Me.RadioButton2.Visible = False
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
			Me.RadioButton1.Visible = False
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
			Me.ColumnHeader9.Text = "Sale Price"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader9.Width = 100
			Me.TextBox1.Location = New Global.System.Drawing.Point(797, 81)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(57, 20)
			Me.TextBox1.TabIndex = 77
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.ColumnHeader7.Text = "HSNC"
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader7.Width = 100
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 220, 128)
			Me.listView1.BackgroundImageTiled = True
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader3, Me.Category, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(9, 112)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(1176, 547)
			Me.listView1.TabIndex = 75
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.columnHeader1.Text = "Product Code"
			Me.columnHeader1.Width = 100
			Me.columnHeader3.Text = "Product Name"
			Me.columnHeader3.Width = 320
			Me.Category.Text = "Category"
			Me.Category.Width = 200
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
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.btnAddCustomer)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.cmbLayouts)
			Me.GroupBox1.Controls.Add(Me.txtSearch)
			Me.GroupBox1.Controls.Add(Me.txtPInv)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Controls.Add(Me.txtBCode)
			Me.GroupBox1.Controls.Add(Me.txtPCode)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 10)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(711, 65)
			Me.GroupBox1.TabIndex = 73
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search"
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
			Me.cmbLayouts.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbLayouts.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbLayouts.FormattingEnabled = True
			Me.cmbLayouts.Items.AddRange(New Object() { "Select" })
			Me.cmbLayouts.Location = New Global.System.Drawing.Point(370, 33)
			Me.cmbLayouts.Name = "cmbLayouts"
			Me.cmbLayouts.Size = New Global.System.Drawing.Size(191, 21)
			Me.cmbLayouts.TabIndex = 76
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
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(9, 84)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 74
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.PrintDialog1.UseEXDialog = True
			Me.PrintPreviewDialog1.AutoScrollMargin = New Global.System.Drawing.Size(0, 0)
			Me.PrintPreviewDialog1.AutoScrollMinSize = New Global.System.Drawing.Size(0, 0)
			Me.PrintPreviewDialog1.ClientSize = New Global.System.Drawing.Size(400, 300)
			Me.PrintPreviewDialog1.Enabled = True
			Me.PrintPreviewDialog1.Icon = CType(componentResourceManager.GetObject("PrintPreviewDialog1.Icon"), Global.System.Drawing.Icon)
			Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
			Me.PrintPreviewDialog1.Visible = False
			Me.pnlCheque.BackColor = Global.System.Drawing.Color.White
			Me.pnlCheque.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.None
			Me.pnlCheque.Location = New Global.System.Drawing.Point(148, 169)
			Me.pnlCheque.MaximumSize = New Global.System.Drawing.Size(895, 399)
			Me.pnlCheque.Name = "pnlCheque"
			Me.pnlCheque.Size = New Global.System.Drawing.Size(669, 331)
			Me.pnlCheque.TabIndex = 78
			Me.pnlCheque.Visible = False
			Me.lblHidden.AutoSize = True
			Me.lblHidden.Location = New Global.System.Drawing.Point(675, 84)
			Me.lblHidden.Name = "lblHidden"
			Me.lblHidden.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblHidden.TabIndex = 117
			Me.lblHidden.Text = "Label1"
			Me.lblHidden.Visible = False
			Me.gbxChequeSize.BackColor = Global.System.Drawing.Color.Transparent
			Me.gbxChequeSize.Controls.Add(Me.btnBgColor_Layout)
			Me.gbxChequeSize.Controls.Add(Me.lnklblSetDefault)
			Me.gbxChequeSize.Controls.Add(Me.lblChequeHeight)
			Me.gbxChequeSize.Controls.Add(Me.lblChequeWidth)
			Me.gbxChequeSize.Controls.Add(Me.nudChequeLeafWidth)
			Me.gbxChequeSize.Controls.Add(Me.nudChequeHeight)
			Me.gbxChequeSize.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.gbxChequeSize.Location = New Global.System.Drawing.Point(726, 12)
			Me.gbxChequeSize.Name = "gbxChequeSize"
			Me.gbxChequeSize.Size = New Global.System.Drawing.Size(224, 66)
			Me.gbxChequeSize.TabIndex = 116
			Me.gbxChequeSize.TabStop = False
			Me.gbxChequeSize.Text = "Cheque Size"
			Me.gbxChequeSize.Visible = False
			Me.btnBgColor_Layout.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBgColor_Layout.Location = New Global.System.Drawing.Point(156, 38)
			Me.btnBgColor_Layout.Name = "btnBgColor_Layout"
			Me.btnBgColor_Layout.Size = New Global.System.Drawing.Size(65, 24)
			Me.btnBgColor_Layout.TabIndex = 118
			Me.btnBgColor_Layout.Text = "BG Color"
			Me.btnBgColor_Layout.UseVisualStyleBackColor = True
			Me.lnklblSetDefault.AutoSize = True
			Me.lnklblSetDefault.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lnklblSetDefault.Location = New Global.System.Drawing.Point(47, 45)
			Me.lnklblSetDefault.Name = "lnklblSetDefault"
			Me.lnklblSetDefault.Size = New Global.System.Drawing.Size(74, 13)
			Me.lnklblSetDefault.TabIndex = 2
			Me.lnklblSetDefault.TabStop = True
			Me.lnklblSetDefault.Text = "Set to Default"
			Me.lblChequeHeight.AutoSize = True
			Me.lblChequeHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblChequeHeight.Location = New Global.System.Drawing.Point(117, 19)
			Me.lblChequeHeight.Name = "lblChequeHeight"
			Me.lblChequeHeight.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblChequeHeight.TabIndex = 23
			Me.lblChequeHeight.Text = "Height"
			Me.lblChequeWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblChequeWidth.Location = New Global.System.Drawing.Point(4, 20)
			Me.lblChequeWidth.Name = "lblChequeWidth"
			Me.lblChequeWidth.Size = New Global.System.Drawing.Size(39, 15)
			Me.lblChequeWidth.TabIndex = 22
			Me.lblChequeWidth.Text = "Width"
			Me.nudChequeLeafWidth.DecimalPlaces = 1
			Me.nudChequeLeafWidth.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudChequeLeafWidth.Increment = New Decimal(New Integer() { 10, 0, 0, 131072 })
			Me.nudChequeLeafWidth.Location = New Global.System.Drawing.Point(50, 16)
			Dim nudChequeLeafWidth As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array As Integer() = New Integer(3) {}
			array(0) = 2000
			nudChequeLeafWidth.Maximum = New Decimal(array)
			Dim nudChequeLeafWidth2 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 1
			nudChequeLeafWidth2.Minimum = New Decimal(array2)
			Me.nudChequeLeafWidth.Name = "nudChequeLeafWidth"
			Me.nudChequeLeafWidth.Size = New Global.System.Drawing.Size(61, 21)
			Me.nudChequeLeafWidth.TabIndex = 0
			Dim nudChequeLeafWidth3 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeLeafWidth
			Dim array3 As Integer() = New Integer(3) {}
			array3(0) = 5
			nudChequeLeafWidth3.Value = New Decimal(array3)
			Me.nudChequeHeight.DecimalPlaces = 1
			Me.nudChequeHeight.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.nudChequeHeight.Increment = New Decimal(New Integer() { 10, 0, 0, 131072 })
			Me.nudChequeHeight.Location = New Global.System.Drawing.Point(161, 15)
			Dim nudChequeHeight As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeHeight
			Dim array4 As Integer() = New Integer(3) {}
			array4(0) = 2000
			nudChequeHeight.Maximum = New Decimal(array4)
			Dim nudChequeHeight2 As Global.System.Windows.Forms.NumericUpDown = Me.nudChequeHeight
			Dim array5 As Integer() = New Integer(3) {}
			array5(0) = 1
			nudChequeHeight2.Minimum = New Decimal(array5)
			Me.nudChequeHeight.Name = "nudChequeHeight"
			Me.nudChequeHeight.Size = New Global.System.Drawing.Size(61, 21)
			Me.nudChequeHeight.TabIndex = 1
			Me.nudChequeHeight.Value = New Decimal(New Integer() { 87, 0, 0, 65536 })
			Me.txtLayoutName.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLayoutName.Location = New Global.System.Drawing.Point(379, 80)
			Me.txtLayoutName.Name = "txtLayoutName"
			Me.txtLayoutName.Size = New Global.System.Drawing.Size(276, 21)
			Me.txtLayoutName.TabIndex = 115
			Me.txtLayoutName.Visible = False
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(928, 233)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(58, 52)
			Me.pbgiftqr.TabIndex = 1798
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.lblHiddenImage.AutoSize = True
			Me.lblHiddenImage.Location = New Global.System.Drawing.Point(720, 85)
			Me.lblHiddenImage.Name = "lblHiddenImage"
			Me.lblHiddenImage.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblHiddenImage.TabIndex = 1799
			Me.lblHiddenImage.Text = "Label2"
			Me.lblHiddenImage.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1195, 668)
			MyBase.Controls.Add(Me.lblHiddenImage)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.lblHidden)
			MyBase.Controls.Add(Me.gbxChequeSize)
			MyBase.Controls.Add(Me.txtLayoutName)
			MyBase.Controls.Add(Me.pnlCheque)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Name = "frmBarcodeLabelPrintingnew"
			Me.Text = "frmBarcodeLabelPrintingNew"
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.gbxChequeSize.ResumeLayout(False)
			Me.gbxChequeSize.PerformLayout()
			CType(Me.nudChequeLeafWidth, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nudChequeHeight, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040001DD RID: 477
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
