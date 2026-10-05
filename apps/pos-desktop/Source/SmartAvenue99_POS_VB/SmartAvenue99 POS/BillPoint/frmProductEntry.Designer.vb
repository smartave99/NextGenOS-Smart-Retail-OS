Namespace BillPoint
	' Token: 0x020001DA RID: 474
		Public Partial Class frmProductEntry
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007ECD RID: 32461 RVA: 0x005E4D70 File Offset: 0x005E2F70
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

		' Token: 0x06007ECE RID: 32462 RVA: 0x005E4DC0 File Offset: 0x005E2FC0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductEntry))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.txtbarcodeNocopy = New Global.System.Windows.Forms.TextBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtSearchProduct = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.btnExportExcel = New Global.System.Windows.Forms.Button()
			Me.btnImportExcel = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.txtCompany = New Global.System.Windows.Forms.TextBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.PID1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ProductCode1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ProductName1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cboxUnit1 = New Global.System.Windows.Forms.DataGridViewComboBoxColumn()
			Me.cboxTax1 = New Global.System.Windows.Forms.DataGridViewComboBoxColumn()
			Me.InsertButton = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.UpdateButton = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.DeleteButton = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.txtPPrice1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtMRP1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtSPrice1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtBarcode1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.BarcodeButton = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.cmbSearchCat = New Global.System.Windows.Forms.ComboBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.GelButtonNewRecord = New Global.System.Windows.Forms.Button()
			Me.btnShowAll = New Global.System.Windows.Forms.Button()
			Me.DataGridViewImageColumn2 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.FolderBrowserDialog1 = New Global.System.Windows.Forms.FolderBrowserDialog()
			Me.Panel7.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel5.SuspendLayout()
			MyBase.SuspendLayout()
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(80, 5)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(97, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "5"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(13, 5)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.txtbarcodeNocopy)
			Me.Panel7.Controls.Add(Me.Label20)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Location = New Global.System.Drawing.Point(14, 41)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(593, 41)
			Me.Panel7.TabIndex = 1823
			Me.txtbarcodeNocopy.BackColor = Global.System.Drawing.Color.White
			Me.txtbarcodeNocopy.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtbarcodeNocopy.Location = New Global.System.Drawing.Point(547, 5)
			Me.txtbarcodeNocopy.Name = "txtbarcodeNocopy"
			Me.txtbarcodeNocopy.Size = New Global.System.Drawing.Size(42, 26)
			Me.txtbarcodeNocopy.TabIndex = 1803
			Me.txtbarcodeNocopy.Text = "1"
			Me.Label20.BackColor = Global.System.Drawing.Color.LightGray
			Me.Label20.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.Label20.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label20.Location = New Global.System.Drawing.Point(350, 6)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(206, 25)
			Me.Label20.TabIndex = 1808
			Me.Label20.Text = "BARCODE No. of Copies :"
			Me.Label20.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(183, 5)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(861, -1)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label16.TabIndex = 1815
			Me.Label16.Text = "Label16"
			Me.Label16.Visible = False
			Me.txtSearchProduct.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtSearchProduct.Location = New Global.System.Drawing.Point(183, 7)
			Me.txtSearchProduct.Name = "txtSearchProduct"
			Me.txtSearchProduct.Size = New Global.System.Drawing.Size(424, 26)
			Me.txtSearchProduct.TabIndex = 1821
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 21F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(39, 8)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(287, 35)
			Me.Label17.TabIndex = 50
			Me.Label17.Text = "LIST OF PRODUCTS"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel4.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.Panel4.Controls.Add(Me.LinkLabel1)
			Me.Panel4.Controls.Add(Me.btnExportExcel)
			Me.Panel4.Controls.Add(Me.btnImportExcel)
			Me.Panel4.Controls.Add(Me.PictureBox1)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Controls.Add(Me.txtCompany)
			Me.Panel4.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel4.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(1164, 51)
			Me.Panel4.TabIndex = 1820
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(815, 30)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(128, 13)
			Me.LinkLabel1.TabIndex = 1807
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Download Sample Format"
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(959, 2)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(97, 47)
			Me.btnExportExcel.TabIndex = 534
			Me.btnExportExcel.Text = "Export" & vbCrLf & " Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.btnImportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnImportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnImportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnImportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnImportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnImportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnImportExcel.Image = CType(componentResourceManager.GetObject("btnImportExcel.Image"), Global.System.Drawing.Image)
			Me.btnImportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnImportExcel.Location = New Global.System.Drawing.Point(1062, 2)
			Me.btnImportExcel.Name = "btnImportExcel"
			Me.btnImportExcel.Size = New Global.System.Drawing.Size(92, 47)
			Me.btnImportExcel.TabIndex = 533
			Me.btnImportExcel.Text = "Import " & vbCrLf & "Excel"
			Me.btnImportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnImportExcel.UseVisualStyleBackColor = False
			Me.PictureBox1.Location = New Global.System.Drawing.Point(4, 10)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(44, 30)
			Me.PictureBox1.TabIndex = 51
			Me.PictureBox1.TabStop = False
			Me.txtCompany.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCompany.Location = New Global.System.Drawing.Point(628, 16)
			Me.txtCompany.Name = "txtCompany"
			Me.txtCompany.Size = New Global.System.Drawing.Size(42, 21)
			Me.txtCompany.TabIndex = 1806
			Me.txtCompany.Visible = False
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(797, -1)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label15.TabIndex = 1814
			Me.Label15.Text = "Label15"
			Me.Label15.Visible = False
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.DataGridView2)
			Me.Panel1.Controls.Add(Me.Panel7)
			Me.Panel1.Controls.Add(Me.Label16)
			Me.Panel1.Controls.Add(Me.txtSearchProduct)
			Me.Panel1.Controls.Add(Me.Label15)
			Me.Panel1.Controls.Add(Me.cmbSearchCat)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Location = New Global.System.Drawing.Point(4, 57)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1160, 428)
			Me.Panel1.TabIndex = 1819
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView2.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.PID1, Me.ProductCode1, Me.ProductName1, Me.cboxUnit1, Me.cboxTax1, Me.InsertButton, Me.UpdateButton, Me.DeleteButton, Me.txtPPrice1, Me.txtMRP1, Me.txtSPrice1, Me.txtBarcode1, Me.BarcodeButton })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Arial", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView2.EnableHeadersVisualStyles = False
			Me.DataGridView2.Location = New Global.System.Drawing.Point(14, 88)
			Me.DataGridView2.Name = "DataGridView2"
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.RowTemplate.Height = 30
			Me.DataGridView2.Size = New Global.System.Drawing.Size(1133, 317)
			Me.DataGridView2.TabIndex = 1824
			Me.PID1.DataPropertyName = "PID1"
			Me.PID1.HeaderText = "PID"
			Me.PID1.Name = "PID1"
			Me.PID1.Visible = False
			Me.ProductCode1.DataPropertyName = "ProductCode1"
			Me.ProductCode1.HeaderText = "P-Code"
			Me.ProductCode1.Name = "ProductCode1"
			Me.ProductCode1.[ReadOnly] = True
			Me.ProductName1.DataPropertyName = "ProductName1"
			Me.ProductName1.HeaderText = "Product Name"
			Me.ProductName1.Name = "ProductName1"
			Me.cboxUnit1.HeaderText = "Unit"
			Me.cboxUnit1.Name = "cboxUnit1"
			Me.cboxUnit1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.cboxUnit1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.cboxTax1.HeaderText = "tax %"
			Me.cboxTax1.Name = "cboxTax1"
			Me.cboxTax1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.cboxTax1.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.InsertButton.DataPropertyName = "InsertButton"
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.InsertButton.DefaultCellStyle = dataGridViewCellStyle5
			Me.InsertButton.HeaderText = "Insert"
			Me.InsertButton.Name = "InsertButton"
			Me.InsertButton.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.InsertButton.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.InsertButton.Text = "Insert"
			Me.InsertButton.UseColumnTextForButtonValue = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.UpdateButton.DefaultCellStyle = dataGridViewCellStyle6
			Me.UpdateButton.HeaderText = "Update"
			Me.UpdateButton.Name = "UpdateButton"
			Me.UpdateButton.Text = "Update"
			Me.UpdateButton.UseColumnTextForButtonValue = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.Color.Red
			Me.DeleteButton.DefaultCellStyle = dataGridViewCellStyle7
			Me.DeleteButton.HeaderText = "Delete"
			Me.DeleteButton.Name = "DeleteButton"
			Me.DeleteButton.Text = "Delete"
			Me.DeleteButton.UseColumnTextForButtonValue = True
			Me.txtPPrice1.HeaderText = "Purchase Price"
			Me.txtPPrice1.Name = "txtPPrice1"
			Me.txtPPrice1.Visible = False
			Me.txtMRP1.HeaderText = "MRP"
			Me.txtMRP1.Name = "txtMRP1"
			Me.txtMRP1.Visible = False
			Me.txtSPrice1.HeaderText = "Sale Price"
			Me.txtSPrice1.Name = "txtSPrice1"
			Me.txtBarcode1.HeaderText = "Barcode"
			Me.txtBarcode1.Name = "txtBarcode1"
			Me.txtBarcode1.[ReadOnly] = True
			Me.BarcodeButton.HeaderText = "Barcode Print"
			Me.BarcodeButton.Name = "BarcodeButton"
			Me.BarcodeButton.Text = "Print"
			Me.BarcodeButton.UseColumnTextForButtonValue = True
			Me.cmbSearchCat.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.cmbSearchCat.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchCat.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbSearchCat.ForeColor = Global.System.Drawing.Color.White
			Me.cmbSearchCat.FormattingEnabled = True
			Me.cmbSearchCat.Items.AddRange(New Object() { "Product Name", "Product Code" })
			Me.cmbSearchCat.Location = New Global.System.Drawing.Point(14, 7)
			Me.cmbSearchCat.Name = "cmbSearchCat"
			Me.cmbSearchCat.Size = New Global.System.Drawing.Size(163, 28)
			Me.cmbSearchCat.TabIndex = 1822
			Me.cmbSearchCat.TabStop = False
			Me.Panel5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel5.Controls.Add(Me.GelButton3)
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Controls.Add(Me.GelButtonNewRecord)
			Me.Panel5.Controls.Add(Me.btnShowAll)
			Me.Panel5.Location = New Global.System.Drawing.Point(613, 13)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(539, 56)
			Me.Panel5.TabIndex = 51
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackgroundImage = Global.BillPoint.My.Resources.Resources.Set_Default_copy_1
			Me.GelButton3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Location = New Global.System.Drawing.Point(10, 4)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(128, 46)
			Me.GelButton3.TabIndex = 1835
			Me.GelButton3.UseVisualStyleBackColor = True
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackgroundImage = Global.BillPoint.My.Resources.Resources.Reset_copy
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Location = New Global.System.Drawing.Point(142, 4)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(128, 46)
			Me.btnReset.TabIndex = 1817
			Me.btnReset.UseVisualStyleBackColor = True
			Me.GelButtonNewRecord.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButtonNewRecord.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.GelButtonNewRecord.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButtonNewRecord.FlatAppearance.BorderSize = 0
			Me.GelButtonNewRecord.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButtonNewRecord.Location = New Global.System.Drawing.Point(407, 4)
			Me.GelButtonNewRecord.Name = "GelButtonNewRecord"
			Me.GelButtonNewRecord.Size = New Global.System.Drawing.Size(128, 46)
			Me.GelButtonNewRecord.TabIndex = 1834
			Me.GelButtonNewRecord.UseVisualStyleBackColor = True
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackgroundImage = Global.BillPoint.My.Resources.Resources.Show_All_copy
			Me.btnShowAll.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Location = New Global.System.Drawing.Point(274, 4)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(128, 46)
			Me.btnShowAll.TabIndex = 1833
			Me.btnShowAll.UseVisualStyleBackColor = True
			Me.DataGridViewImageColumn2.DataPropertyName = "Photo"
			Me.DataGridViewImageColumn2.FillWeight = 27.62098F
			Me.DataGridViewImageColumn2.HeaderText = "Photo"
			Me.DataGridViewImageColumn2.Image = Global.BillPoint.My.Resources.Resources._12
			Me.DataGridViewImageColumn2.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
			Me.DataGridViewImageColumn2.Width = 61
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1164, 497)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "frmProductEntry"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmProductEntry"
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel5.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040037FF RID: 14335
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
