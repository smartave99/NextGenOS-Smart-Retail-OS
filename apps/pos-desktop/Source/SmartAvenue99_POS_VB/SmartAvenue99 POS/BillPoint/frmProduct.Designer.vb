Namespace BillPoint
	' Token: 0x020001D4 RID: 468
		Public Partial Class frmProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007A0B RID: 31243 RVA: 0x005B08D8 File Offset: 0x005AEAD8
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

		' Token: 0x06007A0C RID: 31244 RVA: 0x005B0928 File Offset: 0x005AEB28
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProduct))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.LblLanguage = New Global.System.Windows.Forms.Label()
			Me.Button41 = New Global.System.Windows.Forms.Button()
			Me.Button40 = New Global.System.Windows.Forms.Button()
			Me.CheckBox4 = New Global.System.Windows.Forms.CheckBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.chkMarginOnOff = New Global.System.Windows.Forms.CheckBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.txtWMargin = New Global.System.Windows.Forms.TextBox()
			Me.txtDefMRP = New Global.System.Windows.Forms.TextBox()
			Me.txtRSPrice = New Global.System.Windows.Forms.TextBox()
			Me.txtSalePMargin = New Global.System.Windows.Forms.TextBox()
			Me.txtWSPrice = New Global.System.Windows.Forms.TextBox()
			Me.txtCESS = New Global.System.Windows.Forms.TextBox()
			Me.txtMRPMargin = New Global.System.Windows.Forms.TextBox()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.lblunitinfo = New Global.System.Windows.Forms.Label()
			Me.Label39 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.cmbGST = New Global.System.Windows.Forms.ComboBox()
			Me.txtIGST = New Global.System.Windows.Forms.TextBox()
			Me.Label37 = New Global.System.Windows.Forms.Label()
			Me.txtCGST = New Global.System.Windows.Forms.TextBox()
			Me.txtSGST = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label26 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtCostPrice = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtDiscount = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label40 = New Global.System.Windows.Forms.Label()
			Me.cmbPurchaseUnit = New Global.System.Windows.Forms.ComboBox()
			Me.txtMinStock = New Global.System.Windows.Forms.TextBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.cmbSalesUnit = New Global.System.Windows.Forms.ComboBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbAltunit = New Global.System.Windows.Forms.ComboBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.CheckBox3 = New Global.System.Windows.Forms.CheckBox()
			Me.cmbSTax = New Global.System.Windows.Forms.ComboBox()
			Me.cmbPTax = New Global.System.Windows.Forms.ComboBox()
			Me.LinkLabel3 = New Global.System.Windows.Forms.LinkLabel()
			Me.Label25 = New Global.System.Windows.Forms.Label()
			Me.cBoxLangs = New Global.System.Windows.Forms.ComboBox()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.Label46 = New Global.System.Windows.Forms.Label()
			Me.Button7 = New Global.System.Windows.Forms.Button()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtWMarginNew = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtSaaleMarginNew = New Global.System.Windows.Forms.TextBox()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.txtMRPMarginNew = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label49 = New Global.System.Windows.Forms.Label()
			Me.Label52 = New Global.System.Windows.Forms.Label()
			Me.Label50 = New Global.System.Windows.Forms.Label()
			Me.txtPurchase = New Global.System.Windows.Forms.TextBox()
			Me.Label48 = New Global.System.Windows.Forms.Label()
			Me.Label47 = New Global.System.Windows.Forms.Label()
			Me.txtIMEI2 = New Global.System.Windows.Forms.TextBox()
			Me.txtIMEI1 = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox5 = New Global.System.Windows.Forms.CheckBox()
			Me.Label28 = New Global.System.Windows.Forms.Label()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.Label33 = New Global.System.Windows.Forms.Label()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.Label32 = New Global.System.Windows.Forms.Label()
			Me.Label29 = New Global.System.Windows.Forms.Label()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.Label42 = New Global.System.Windows.Forms.Label()
			Me.Label38 = New Global.System.Windows.Forms.Label()
			Me.txtOpeningStock = New Global.System.Windows.Forms.TextBox()
			Me.TempBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.txtExp = New Global.System.Windows.Forms.TextBox()
			Me.txtMfg = New Global.System.Windows.Forms.TextBox()
			Me.cmbColour = New Global.System.Windows.Forms.ComboBox()
			Me.cmbSize = New Global.System.Windows.Forms.ComboBox()
			Me.btnRemoveFromGridOS = New Global.System.Windows.Forms.Button()
			Me.btnAddOS = New Global.System.Windows.Forms.Button()
			Me.txtMRP = New Global.System.Windows.Forms.TextBox()
			Me.dtpExpiryDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.txtBatchNo = New Global.System.Windows.Forms.TextBox()
			Me.dtpManufacturingDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label36 = New Global.System.Windows.Forms.Label()
			Me.txtSellingPrice = New Global.System.Windows.Forms.TextBox()
			Me.txtReorderPoint = New Global.System.Windows.Forms.TextBox()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.cmbKitchen = New Global.System.Windows.Forms.ComboBox()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.btnAdd = New Global.System.Windows.Forms.Button()
			Me.LinkLabel2 = New Global.System.Windows.Forms.LinkLabel()
			Me.btnRemove = New Global.System.Windows.Forms.Button()
			Me.Label43 = New Global.System.Windows.Forms.Label()
			Me.numericUpDown1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.txtSaleQty = New Global.System.Windows.Forms.TextBox()
			Me.Label35 = New Global.System.Windows.Forms.Label()
			Me.Label41 = New Global.System.Windows.Forms.Label()
			Me.Label27 = New Global.System.Windows.Forms.Label()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.cmbRack = New Global.System.Windows.Forms.ComboBox()
			Me.cmbGdown = New Global.System.Windows.Forms.ComboBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btnProductSelection = New Global.System.Windows.Forms.Button()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtPartNo = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtHSNCode = New Global.System.Windows.Forms.TextBox()
			Me.cmbSubCategory = New Global.System.Windows.Forms.ComboBox()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.txtFeatures = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtBar = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.lblCondn = New Global.System.Windows.Forms.Label()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtPNo = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.txtSubCategoryID = New Global.System.Windows.Forms.TextBox()
			Me.txtPName = New Global.System.Windows.Forms.TextBox()
			Me.txtBCode = New Global.System.Windows.Forms.TextBox()
			Me.txtOStock = New Global.System.Windows.Forms.TextBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Dim label2 As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel6.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox4.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.numericUpDown1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			label.ForeColor = Global.System.Drawing.Color.Crimson
			label.Location = New Global.System.Drawing.Point(10, 509)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label44"
			label.Size = New Global.System.Drawing.Size(45, 12)
			label.TabIndex = 1774
			label.Text = "(Optional)"
			label2.AutoSize = True
			label2.ForeColor = Global.System.Drawing.Color.Black
			label2.Location = New Global.System.Drawing.Point(7, 495)
			label2.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label2.Name = "Label45"
			label2.Size = New Global.System.Drawing.Size(116, 15)
			label2.TabIndex = 1773
			label2.Text = "Order Print Section :"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.LblLanguage)
			Me.Panel1.Controls.Add(Me.Button41)
			Me.Panel1.Controls.Add(Me.Button40)
			Me.Panel1.Controls.Add(Me.CheckBox4)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(8, 8)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1318, 588)
			Me.Panel1.TabIndex = 2
			Me.LblLanguage.AutoSize = True
			Me.LblLanguage.ForeColor = Global.System.Drawing.Color.Blue
			Me.LblLanguage.Location = New Global.System.Drawing.Point(1146, 350)
			Me.LblLanguage.Name = "LblLanguage"
			Me.LblLanguage.Size = New Global.System.Drawing.Size(60, 13)
			Me.LblLanguage.TabIndex = 1759
			Me.LblLanguage.Text = "Fetching...."
			Me.Button41.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button41.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button41.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button41.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button41.FlatAppearance.BorderColor = Global.System.Drawing.Color.White
			Me.Button41.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button41.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button41.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Button41.Image = CType(componentResourceManager.GetObject("Button41.Image"), Global.System.Drawing.Image)
			Me.Button41.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button41.Location = New Global.System.Drawing.Point(1222, 460)
			Me.Button41.Name = "Button41"
			Me.Button41.Size = New Global.System.Drawing.Size(85, 64)
			Me.Button41.TabIndex = 1760
			Me.Button41.TabStop = False
			Me.Button41.Text = "Language Setting"
			Me.Button41.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button41.UseVisualStyleBackColor = False
			Me.Button40.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button40.BackColor = Global.System.Drawing.Color.Transparent
			Me.Button40.BackgroundImage = CType(componentResourceManager.GetObject("Button40.BackgroundImage"), Global.System.Drawing.Image)
			Me.Button40.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Zoom
			Me.Button40.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button40.FlatAppearance.BorderColor = Global.System.Drawing.Color.White
			Me.Button40.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button40.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button40.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Button40.Location = New Global.System.Drawing.Point(1196, 366)
			Me.Button40.Name = "Button40"
			Me.Button40.Size = New Global.System.Drawing.Size(109, 86)
			Me.Button40.TabIndex = 1759
			Me.Button40.TabStop = False
			Me.Button40.Text = "Mic"
			Me.Button40.TextAlign = Global.System.Drawing.ContentAlignment.TopLeft
			Me.Button40.UseVisualStyleBackColor = False
			Me.CheckBox4.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.CheckBox4.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.CheckBox4.Checked = True
			Me.CheckBox4.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox4.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox4.ForeColor = Global.System.Drawing.Color.Navy
			Me.CheckBox4.Location = New Global.System.Drawing.Point(1152, 502)
			Me.CheckBox4.Name = "CheckBox4"
			Me.CheckBox4.Size = New Global.System.Drawing.Size(80, 60)
			Me.CheckBox4.TabIndex = 3
			Me.CheckBox4.TabStop = False
			Me.CheckBox4.Text = "Active / Deactive"
			Me.CheckBox4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox4.UseVisualStyleBackColor = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.chkMarginOnOff)
			Me.Panel4.Controls.Add(Me.GroupBox2)
			Me.Panel4.Controls.Add(Me.pbgiftqr)
			Me.Panel4.Controls.Add(Me.Panel6)
			Me.Panel4.Controls.Add(Me.cmbSTax)
			Me.Panel4.Controls.Add(Me.cmbPTax)
			Me.Panel4.Controls.Add(Me.LinkLabel3)
			Me.Panel4.Controls.Add(Me.Label25)
			Me.Panel4.Controls.Add(Me.cBoxLangs)
			Me.Panel4.Controls.Add(Me.Label24)
			Me.Panel4.Controls.Add(Me.Label46)
			Me.Panel4.Controls.Add(Me.Button7)
			Me.Panel4.Controls.Add(Me.GroupBox1)
			Me.Panel4.Controls.Add(label2)
			Me.Panel4.Controls.Add(Me.cmbKitchen)
			Me.Panel4.Controls.Add(Me.GroupBox4)
			Me.Panel4.Controls.Add(Me.txtSaleQty)
			Me.Panel4.Controls.Add(Me.Label35)
			Me.Panel4.Controls.Add(Me.Label41)
			Me.Panel4.Controls.Add(Me.Label27)
			Me.Panel4.Controls.Add(Me.Label23)
			Me.Panel4.Controls.Add(Me.LinkLabel1)
			Me.Panel4.Controls.Add(Me.txtID)
			Me.Panel4.Controls.Add(Me.cmbRack)
			Me.Panel4.Controls.Add(Me.cmbGdown)
			Me.Panel4.Controls.Add(Me.TextBox5)
			Me.Panel4.Controls.Add(Me.CheckBox2)
			Me.Panel4.Controls.Add(Me.TextBox3)
			Me.Panel4.Controls.Add(Me.btnNext)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.btnFirst)
			Me.Panel4.Controls.Add(Me.txtPrev)
			Me.Panel4.Controls.Add(Me.btnLast)
			Me.Panel4.Controls.Add(Me.Button1)
			Me.Panel4.Controls.Add(Me.btnProductSelection)
			Me.Panel4.Controls.Add(Me.Label22)
			Me.Panel4.Controls.Add(Me.Label21)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Controls.Add(Me.txtPartNo)
			Me.Panel4.Controls.Add(Me.Label16)
			Me.Panel4.Controls.Add(Me.txtHSNCode)
			Me.Panel4.Controls.Add(Me.cmbSubCategory)
			Me.Panel4.Controls.Add(Me.cmbCategory)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtProductCode)
			Me.Panel4.Controls.Add(Me.txtFeatures)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.CheckBox1)
			Me.Panel4.Controls.Add(label)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(9, 40)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(1127, 543)
			Me.Panel4.TabIndex = 0
			Me.chkMarginOnOff.BackColor = Global.System.Drawing.Color.LightGreen
			Me.chkMarginOnOff.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.chkMarginOnOff.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkMarginOnOff.ForeColor = Global.System.Drawing.Color.Blue
			Me.chkMarginOnOff.Location = New Global.System.Drawing.Point(351, 151)
			Me.chkMarginOnOff.Name = "chkMarginOnOff"
			Me.chkMarginOnOff.Size = New Global.System.Drawing.Size(119, 35)
			Me.chkMarginOnOff.TabIndex = 1798
			Me.chkMarginOnOff.TabStop = False
			Me.chkMarginOnOff.Text = "Margin % [On/Off]"
			Me.chkMarginOnOff.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.chkMarginOnOff.UseVisualStyleBackColor = False
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.txtWMargin)
			Me.GroupBox2.Controls.Add(Me.txtDefMRP)
			Me.GroupBox2.Controls.Add(Me.txtRSPrice)
			Me.GroupBox2.Controls.Add(Me.txtSalePMargin)
			Me.GroupBox2.Controls.Add(Me.txtWSPrice)
			Me.GroupBox2.Controls.Add(Me.txtCESS)
			Me.GroupBox2.Controls.Add(Me.txtMRPMargin)
			Me.GroupBox2.Controls.Add(Me.Button3)
			Me.GroupBox2.Controls.Add(Me.Label19)
			Me.GroupBox2.Controls.Add(Me.lblunitinfo)
			Me.GroupBox2.Controls.Add(Me.Label39)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.cmbGST)
			Me.GroupBox2.Controls.Add(Me.txtIGST)
			Me.GroupBox2.Controls.Add(Me.Label37)
			Me.GroupBox2.Controls.Add(Me.txtCGST)
			Me.GroupBox2.Controls.Add(Me.txtSGST)
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.Label26)
			Me.GroupBox2.Controls.Add(Me.Label10)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.Label18)
			Me.GroupBox2.Controls.Add(Me.txtCostPrice)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Controls.Add(Me.txtDiscount)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.Label40)
			Me.GroupBox2.Controls.Add(Me.cmbPurchaseUnit)
			Me.GroupBox2.Controls.Add(Me.txtMinStock)
			Me.GroupBox2.Controls.Add(Me.Label15)
			Me.GroupBox2.Controls.Add(Me.Button2)
			Me.GroupBox2.Controls.Add(Me.cmbSalesUnit)
			Me.GroupBox2.Controls.Add(Me.Label20)
			Me.GroupBox2.Controls.Add(Me.TextBox1)
			Me.GroupBox2.Controls.Add(Me.cmbAltunit)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(10, 182)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(492, 212)
			Me.GroupBox2.TabIndex = 23
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Price Info (Fill Compulsory) :"
			Me.txtWMargin.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWMargin.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWMargin.Location = New Global.System.Drawing.Point(345, 71)
			Me.txtWMargin.Name = "txtWMargin"
			Me.txtWMargin.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtWMargin.TabIndex = 1781
			Me.txtWMargin.Text = "0.00"
			Me.txtWMargin.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtDefMRP.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDefMRP.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDefMRP.Location = New Global.System.Drawing.Point(399, 26)
			Me.txtDefMRP.Name = "txtDefMRP"
			Me.txtDefMRP.Size = New Global.System.Drawing.Size(85, 21)
			Me.txtDefMRP.TabIndex = 0
			Me.txtDefMRP.Text = "0.00"
			Me.txtDefMRP.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtRSPrice.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRSPrice.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRSPrice.Location = New Global.System.Drawing.Point(399, 48)
			Me.txtRSPrice.Name = "txtRSPrice"
			Me.txtRSPrice.Size = New Global.System.Drawing.Size(85, 21)
			Me.txtRSPrice.TabIndex = 1
			Me.txtRSPrice.Text = "0.00"
			Me.txtRSPrice.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtSalePMargin.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSalePMargin.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSalePMargin.Location = New Global.System.Drawing.Point(345, 47)
			Me.txtSalePMargin.Name = "txtSalePMargin"
			Me.txtSalePMargin.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtSalePMargin.TabIndex = 1780
			Me.txtSalePMargin.Text = "0.00"
			Me.txtSalePMargin.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtWSPrice.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWSPrice.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWSPrice.Location = New Global.System.Drawing.Point(399, 70)
			Me.txtWSPrice.Name = "txtWSPrice"
			Me.txtWSPrice.Size = New Global.System.Drawing.Size(85, 21)
			Me.txtWSPrice.TabIndex = 2
			Me.txtWSPrice.Text = "0.00"
			Me.txtWSPrice.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtCESS.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCESS.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCESS.Location = New Global.System.Drawing.Point(345, 159)
			Me.txtCESS.Name = "txtCESS"
			Me.txtCESS.Size = New Global.System.Drawing.Size(115, 21)
			Me.txtCESS.TabIndex = 3
			Me.txtCESS.Text = "0.00"
			Me.txtCESS.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtMRPMargin.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMRPMargin.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMRPMargin.Location = New Global.System.Drawing.Point(345, 25)
			Me.txtMRPMargin.Name = "txtMRPMargin"
			Me.txtMRPMargin.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtMRPMargin.TabIndex = 1778
			Me.txtMRPMargin.Text = "0.00"
			Me.txtMRPMargin.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.Lime
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.Location = New Global.System.Drawing.Point(424, 99)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(33, 21)
			Me.Button3.TabIndex = 1746
			Me.Button3.TabStop = False
			Me.Button3.Text = "+"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button3.UseVisualStyleBackColor = False
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(266, 162)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(59, 15)
			Me.Label19.TabIndex = 340
			Me.Label19.Text = "CESS % :"
			Me.lblunitinfo.AutoSize = True
			Me.lblunitinfo.ForeColor = Global.System.Drawing.Color.Crimson
			Me.lblunitinfo.Location = New Global.System.Drawing.Point(10, 186)
			Me.lblunitinfo.Name = "lblunitinfo"
			Me.lblunitinfo.Size = New Global.System.Drawing.Size(60, 15)
			Me.lblunitinfo.TabIndex = 1777
			Me.lblunitinfo.Text = "lblunitinfo"
			Me.Label39.AutoSize = True
			Me.Label39.Location = New Global.System.Drawing.Point(342, 8)
			Me.Label39.Name = "Label39"
			Me.Label39.Size = New Global.System.Drawing.Size(66, 15)
			Me.Label39.TabIndex = 1779
			Me.Label39.Text = "Margin % :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(8, 17)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(96, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Purchase Price :"
			Me.cmbGST.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbGST.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbGST.FormattingEnabled = True
			Me.cmbGST.Location = New Global.System.Drawing.Point(334, 97)
			Me.cmbGST.Name = "cmbGST"
			Me.cmbGST.Size = New Global.System.Drawing.Size(86, 23)
			Me.cmbGST.TabIndex = 2
			Me.txtIGST.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtIGST.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtIGST.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIGST.Location = New Global.System.Drawing.Point(396, 137)
			Me.txtIGST.Multiline = True
			Me.txtIGST.Name = "txtIGST"
			Me.txtIGST.[ReadOnly] = True
			Me.txtIGST.Size = New Global.System.Drawing.Size(66, 18)
			Me.txtIGST.TabIndex = 1740
			Me.txtIGST.TabStop = False
			Me.txtIGST.Text = "0.00"
			Me.txtIGST.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label37.AutoSize = True
			Me.Label37.Location = New Global.System.Drawing.Point(277, 100)
			Me.Label37.Name = "Label37"
			Me.Label37.Size = New Global.System.Drawing.Size(51, 15)
			Me.Label37.TabIndex = 1743
			Me.Label37.Text = "GST % :"
			Me.txtCGST.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCGST.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtCGST.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCGST.Location = New Global.System.Drawing.Point(250, 137)
			Me.txtCGST.Multiline = True
			Me.txtCGST.Name = "txtCGST"
			Me.txtCGST.[ReadOnly] = True
			Me.txtCGST.Size = New Global.System.Drawing.Size(70, 18)
			Me.txtCGST.TabIndex = 9
			Me.txtCGST.TabStop = False
			Me.txtCGST.Text = "0.00"
			Me.txtCGST.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtSGST.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSGST.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtSGST.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSGST.Location = New Global.System.Drawing.Point(326, 137)
			Me.txtSGST.Multiline = True
			Me.txtSGST.Name = "txtSGST"
			Me.txtSGST.[ReadOnly] = True
			Me.txtSGST.Size = New Global.System.Drawing.Size(64, 18)
			Me.txtSGST.TabIndex = 11
			Me.txtSGST.TabStop = False
			Me.txtSGST.Text = "0.00"
			Me.txtSGST.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(247, 70)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(102, 15)
			Me.Label8.TabIndex = 1757
			Me.Label8.Text = "Wholesale Price :"
			Me.Label26.AutoSize = True
			Me.Label26.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label26.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label26.Location = New Global.System.Drawing.Point(415, 122)
			Me.Label26.Name = "Label26"
			Me.Label26.Size = New Global.System.Drawing.Size(41, 12)
			Me.Label26.TabIndex = 1741
			Me.Label26.Text = "IGST % :"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(247, 48)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(104, 15)
			Me.Label10.TabIndex = 1758
			Me.Label10.Text = "Retail Sale Price :"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label11.Location = New Global.System.Drawing.Point(257, 122)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(45, 12)
			Me.Label11.TabIndex = 302
			Me.Label11.Text = "CGST % :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(247, 26)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(41, 15)
			Me.Label12.TabIndex = 1759
			Me.Label12.Text = "MRP :"
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label18.Location = New Global.System.Drawing.Point(323, 122)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(81, 12)
			Me.Label18.TabIndex = 338
			Me.Label18.Text = "SGST / UTGST % :"
			Me.txtCostPrice.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCostPrice.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCostPrice.Location = New Global.System.Drawing.Point(126, 17)
			Me.txtCostPrice.Name = "txtCostPrice"
			Me.txtCostPrice.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtCostPrice.TabIndex = 8
			Me.txtCostPrice.Text = "0.00"
			Me.txtCostPrice.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(8, 71)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(109, 15)
			Me.Label9.TabIndex = 301
			Me.Label9.Text = "Sales Discount % :"
			Me.txtDiscount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDiscount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDiscount.Location = New Global.System.Drawing.Point(126, 71)
			Me.txtDiscount.Name = "txtDiscount"
			Me.txtDiscount.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtDiscount.TabIndex = 14
			Me.txtDiscount.Text = "0.00"
			Me.txtDiscount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(8, 98)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(121, 15)
			Me.Label14.TabIndex = 329
			Me.Label14.Text = "Purchase Main Unit :"
			Me.Label40.AutoSize = True
			Me.Label40.Location = New Global.System.Drawing.Point(8, 44)
			Me.Label40.Name = "Label40"
			Me.Label40.Size = New Global.System.Drawing.Size(67, 15)
			Me.Label40.TabIndex = 1749
			Me.Label40.Text = "Min Stock :"
			Me.cmbPurchaseUnit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPurchaseUnit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPurchaseUnit.FormattingEnabled = True
			Me.cmbPurchaseUnit.Location = New Global.System.Drawing.Point(135, 98)
			Me.cmbPurchaseUnit.Name = "cmbPurchaseUnit"
			Me.cmbPurchaseUnit.Size = New Global.System.Drawing.Size(102, 23)
			Me.cmbPurchaseUnit.TabIndex = 15
			Me.txtMinStock.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMinStock.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMinStock.Location = New Global.System.Drawing.Point(126, 44)
			Me.txtMinStock.Name = "txtMinStock"
			Me.txtMinStock.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtMinStock.TabIndex = 13
			Me.txtMinStock.Text = "0"
			Me.txtMinStock.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(8, 128)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(100, 15)
			Me.Label15.TabIndex = 331
			Me.Label15.Text = "Sales Main Unit :"
			Me.Button2.BackColor = Global.System.Drawing.Color.Lime
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Location = New Global.System.Drawing.Point(240, 185)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(33, 21)
			Me.Button2.TabIndex = 349
			Me.Button2.TabStop = False
			Me.Button2.Text = "+"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button2.UseVisualStyleBackColor = False
			Me.cmbSalesUnit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSalesUnit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSalesUnit.FormattingEnabled = True
			Me.cmbSalesUnit.Location = New Global.System.Drawing.Point(135, 128)
			Me.cmbSalesUnit.Name = "cmbSalesUnit"
			Me.cmbSalesUnit.Size = New Global.System.Drawing.Size(102, 23)
			Me.cmbSalesUnit.TabIndex = 16
			Me.Label20.AutoSize = True
			Me.Label20.Location = New Global.System.Drawing.Point(8, 159)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(62, 15)
			Me.Label20.TabIndex = 343
			Me.Label20.Text = "Alter Unit :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.Gainsboro
			Me.TextBox1.Location = New Global.System.Drawing.Point(284, 185)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(111, 21)
			Me.TextBox1.TabIndex = 18
			Me.TextBox1.Text = "1"
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.cmbAltunit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAltunit.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAltunit.FormattingEnabled = True
			Me.cmbAltunit.Location = New Global.System.Drawing.Point(135, 158)
			Me.cmbAltunit.Name = "cmbAltunit"
			Me.cmbAltunit.Size = New Global.System.Drawing.Size(102, 23)
			Me.cmbAltunit.TabIndex = 17
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(289, 453)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(84, 82)
			Me.pbgiftqr.TabIndex = 1797
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.Panel6.Controls.Add(Me.Panel5)
			Me.Panel6.Controls.Add(Me.CheckBox3)
			Me.Panel6.Location = New Global.System.Drawing.Point(511, 41)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(60, 35)
			Me.Panel6.TabIndex = 1779
			Me.Panel6.Visible = False
			Me.Panel5.BackgroundImage = CType(componentResourceManager.GetObject("Panel5.BackgroundImage"), Global.System.Drawing.Image)
			Me.Panel5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel5.Location = New Global.System.Drawing.Point(123, 66)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(551, 42)
			Me.Panel5.TabIndex = 1776
			Me.CheckBox3.AutoSize = True
			Me.CheckBox3.BackColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.CheckBox3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox3.ForeColor = Global.System.Drawing.Color.White
			Me.CheckBox3.Location = New Global.System.Drawing.Point(8, 23)
			Me.CheckBox3.Name = "CheckBox3"
			Me.CheckBox3.Size = New Global.System.Drawing.Size(56, 19)
			Me.CheckBox3.TabIndex = 1751
			Me.CheckBox3.TabStop = False
			Me.CheckBox3.Text = "P.List"
			Me.CheckBox3.UseVisualStyleBackColor = False
			Me.CheckBox3.Visible = False
			Me.cmbSTax.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSTax.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSTax.FormattingEnabled = True
			Me.cmbSTax.Items.AddRange(New Object() { "Inclusive", "Exclusive", "Exempt GST", "No Taxes" })
			Me.cmbSTax.Location = New Global.System.Drawing.Point(380, 410)
			Me.cmbSTax.Name = "cmbSTax"
			Me.cmbSTax.Size = New Global.System.Drawing.Size(93, 23)
			Me.cmbSTax.TabIndex = 0
			Me.cmbPTax.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPTax.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPTax.FormattingEnabled = True
			Me.cmbPTax.Items.AddRange(New Object() { "Inclusive", "Exclusive", "Exempt GST", "No Taxes" })
			Me.cmbPTax.Location = New Global.System.Drawing.Point(380, 435)
			Me.cmbPTax.Name = "cmbPTax"
			Me.cmbPTax.Size = New Global.System.Drawing.Size(93, 23)
			Me.cmbPTax.TabIndex = 1
			Me.LinkLabel3.AutoSize = True
			Me.LinkLabel3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel3.Location = New Global.System.Drawing.Point(507, 107)
			Me.LinkLabel3.Name = "LinkLabel3"
			Me.LinkLabel3.Size = New Global.System.Drawing.Size(79, 15)
			Me.LinkLabel3.TabIndex = 5
			Me.LinkLabel3.TabStop = True
			Me.LinkLabel3.Text = "Convert Lang"
			Me.Label25.AutoSize = True
			Me.Label25.Location = New Global.System.Drawing.Point(244, 435)
			Me.Label25.Name = "Label25"
			Me.Label25.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label25.TabIndex = 1757
			Me.Label25.Text = "Tax Type on Purchase :"
			Me.cBoxLangs.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cBoxLangs.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cBoxLangs.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cBoxLangs.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cBoxLangs.FormattingEnabled = True
			Me.cBoxLangs.Location = New Global.System.Drawing.Point(500, 82)
			Me.cBoxLangs.Name = "cBoxLangs"
			Me.cBoxLangs.Size = New Global.System.Drawing.Size(90, 23)
			Me.cBoxLangs.TabIndex = 1778
			Me.cBoxLangs.TabStop = False
			Me.Label24.AutoSize = True
			Me.Label24.Location = New Global.System.Drawing.Point(244, 410)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(107, 15)
			Me.Label24.TabIndex = 1756
			Me.Label24.Text = "Tax Type on Sale :"
			Me.Label46.AutoSize = True
			Me.Label46.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Label46.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label46.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label46.Location = New Global.System.Drawing.Point(71, 513)
			Me.Label46.Name = "Label46"
			Me.Label46.Size = New Global.System.Drawing.Size(34, 9)
			Me.Label46.TabIndex = 1776
			Me.Label46.Text = "Remove"
			Me.Button7.BackColor = Global.System.Drawing.Color.Lime
			Me.Button7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button7.Location = New Global.System.Drawing.Point(236, 497)
			Me.Button7.Name = "Button7"
			Me.Button7.Size = New Global.System.Drawing.Size(29, 21)
			Me.Button7.TabIndex = 1775
			Me.Button7.TabStop = False
			Me.Button7.Text = "+"
			Me.Button7.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button7.UseVisualStyleBackColor = False
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.txtWMarginNew)
			Me.GroupBox1.Controls.Add(Me.DataGridView1)
			Me.GroupBox1.Controls.Add(Me.txtSaaleMarginNew)
			Me.GroupBox1.Controls.Add(Me.Button6)
			Me.GroupBox1.Controls.Add(Me.txtMRPMarginNew)
			Me.GroupBox1.Controls.Add(Me.TextBox2)
			Me.GroupBox1.Controls.Add(Me.Label49)
			Me.GroupBox1.Controls.Add(Me.Label52)
			Me.GroupBox1.Controls.Add(Me.Label50)
			Me.GroupBox1.Controls.Add(Me.txtPurchase)
			Me.GroupBox1.Controls.Add(Me.Label48)
			Me.GroupBox1.Controls.Add(Me.Label47)
			Me.GroupBox1.Controls.Add(Me.txtIMEI2)
			Me.GroupBox1.Controls.Add(Me.txtIMEI1)
			Me.GroupBox1.Controls.Add(Me.CheckBox5)
			Me.GroupBox1.Controls.Add(Me.Label28)
			Me.GroupBox1.Controls.Add(Me.Label30)
			Me.GroupBox1.Controls.Add(Me.Label33)
			Me.GroupBox1.Controls.Add(Me.Label31)
			Me.GroupBox1.Controls.Add(Me.Label32)
			Me.GroupBox1.Controls.Add(Me.Label29)
			Me.GroupBox1.Controls.Add(Me.Label34)
			Me.GroupBox1.Controls.Add(Me.Label42)
			Me.GroupBox1.Controls.Add(Me.Label38)
			Me.GroupBox1.Controls.Add(Me.txtOpeningStock)
			Me.GroupBox1.Controls.Add(Me.TempBarcode)
			Me.GroupBox1.Controls.Add(Me.Button5)
			Me.GroupBox1.Controls.Add(Me.txtExp)
			Me.GroupBox1.Controls.Add(Me.txtMfg)
			Me.GroupBox1.Controls.Add(Me.cmbColour)
			Me.GroupBox1.Controls.Add(Me.cmbSize)
			Me.GroupBox1.Controls.Add(Me.btnRemoveFromGridOS)
			Me.GroupBox1.Controls.Add(Me.btnAddOS)
			Me.GroupBox1.Controls.Add(Me.txtMRP)
			Me.GroupBox1.Controls.Add(Me.dtpExpiryDate)
			Me.GroupBox1.Controls.Add(Me.TextBox4)
			Me.GroupBox1.Controls.Add(Me.txtBatchNo)
			Me.GroupBox1.Controls.Add(Me.dtpManufacturingDate)
			Me.GroupBox1.Controls.Add(Me.Label36)
			Me.GroupBox1.Controls.Add(Me.txtSellingPrice)
			Me.GroupBox1.Controls.Add(Me.txtReorderPoint)
			Me.GroupBox1.Controls.Add(Me.txtBarcode)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(509, 181)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(601, 353)
			Me.GroupBox1.TabIndex = 24
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Opening Stock (Optional Except Barcode) :"
			Me.txtWMarginNew.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtWMarginNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtWMarginNew.Location = New Global.System.Drawing.Point(232, 132)
			Me.txtWMarginNew.Name = "txtWMarginNew"
			Me.txtWMarginNew.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtWMarginNew.TabIndex = 1785
			Me.txtWMarginNew.Text = "0.00"
			Me.txtWMarginNew.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 33
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column7, Me.DataGridViewTextBoxColumn1, Me.Column2, Me.Column3, Me.Column8, Me.Column9, Me.Column5, Me.Column4, Me.Column6, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(6, 226)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(589, 120)
			Me.DataGridView1.TabIndex = 1780
			Me.DataGridView1.TabStop = False
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle5
			Me.Column7.HeaderText = "Qty."
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 70
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "N2"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.DataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridViewTextBoxColumn1.HeaderText = "MRP"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column2.HeaderText = "Retail Sale Price"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column3.HeaderText = "Wholesale Price"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column8.HeaderText = "Batch No."
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 90
			dataGridViewCellStyle9.Format = "dd/MM/yyyy"
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column9.HeaderText = "Mfg. Date"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Width = 70
			dataGridViewCellStyle10.Format = "dd/MM/yyyy"
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column5.HeaderText = "Expiry Date"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Width = 70
			Me.Column4.HeaderText = "Size"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column6.HeaderText = "Colour"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column10.HeaderText = "Barcode"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "R Cipher"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Visible = False
			Me.Column12.HeaderText = "W Code"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column12.Visible = False
			Me.Column13.HeaderText = "Temp Barcode"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column13.Visible = False
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle11.Format = "N2"
			Me.Column14.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column14.HeaderText = "Purchase Price"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle12.Format = "N2"
			Me.Column15.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column15.HeaderText = "OP Stock Value"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column15.Visible = False
			Me.Column16.HeaderText = "IMEI - 1"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column17.HeaderText = "IMEI - 2"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.txtSaaleMarginNew.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSaaleMarginNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSaaleMarginNew.Location = New Global.System.Drawing.Point(232, 107)
			Me.txtSaaleMarginNew.Name = "txtSaaleMarginNew"
			Me.txtSaaleMarginNew.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtSaaleMarginNew.TabIndex = 1784
			Me.txtSaaleMarginNew.Text = "0.00"
			Me.txtSaaleMarginNew.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Button6.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.Button6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.Enabled = False
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.Image = Global.BillPoint.My.Resources.Resources.edit
			Me.Button6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button6.Location = New Global.System.Drawing.Point(522, 94)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(69, 33)
			Me.Button6.TabIndex = 15
			Me.Button6.Text = "&Edit"
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button6.UseVisualStyleBackColor = False
			Me.txtMRPMarginNew.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMRPMarginNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMRPMarginNew.Location = New Global.System.Drawing.Point(232, 83)
			Me.txtMRPMarginNew.Name = "txtMRPMarginNew"
			Me.txtMRPMarginNew.Size = New Global.System.Drawing.Size(49, 21)
			Me.txtMRPMarginNew.TabIndex = 1782
			Me.txtMRPMarginNew.Text = "0.00"
			Me.txtMRPMarginNew.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TextBox2.BackColor = Global.System.Drawing.Color.LightSkyBlue
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox2.Location = New Global.System.Drawing.Point(335, 157)
			Me.TextBox2.Multiline = True
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(63, 18)
			Me.TextBox2.TabIndex = 3
			Me.TextBox2.TabStop = False
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label49.AutoSize = True
			Me.Label49.Location = New Global.System.Drawing.Point(232, 65)
			Me.Label49.Name = "Label49"
			Me.Label49.Size = New Global.System.Drawing.Size(66, 15)
			Me.Label49.TabIndex = 1783
			Me.Label49.Text = "Margin % :"
			Me.Label52.AutoSize = True
			Me.Label52.Location = New Global.System.Drawing.Point(426, 157)
			Me.Label52.Name = "Label52"
			Me.Label52.Size = New Global.System.Drawing.Size(40, 15)
			Me.Label52.TabIndex = 1784
			Me.Label52.Text = "WCC :"
			Me.Label50.AutoSize = True
			Me.Label50.Location = New Global.System.Drawing.Point(3, 61)
			Me.Label50.Name = "Label50"
			Me.Label50.Size = New Global.System.Drawing.Size(96, 15)
			Me.Label50.TabIndex = 1782
			Me.Label50.Text = "Purchase Price :"
			Me.txtPurchase.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPurchase.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPurchase.Location = New Global.System.Drawing.Point(114, 61)
			Me.txtPurchase.Name = "txtPurchase"
			Me.txtPurchase.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtPurchase.TabIndex = 2
			Me.txtPurchase.Text = "0.00"
			Me.txtPurchase.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label48.AutoSize = True
			Me.Label48.Location = New Global.System.Drawing.Point(297, 133)
			Me.Label48.Name = "Label48"
			Me.Label48.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label48.TabIndex = 1780
			Me.Label48.Text = "IMEI -2 :"
			Me.Label47.AutoSize = True
			Me.Label47.Location = New Global.System.Drawing.Point(297, 110)
			Me.Label47.Name = "Label47"
			Me.Label47.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label47.TabIndex = 1779
			Me.Label47.Text = "IMEI -1 :"
			Me.txtIMEI2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIMEI2.Location = New Global.System.Drawing.Point(354, 133)
			Me.txtIMEI2.Name = "txtIMEI2"
			Me.txtIMEI2.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtIMEI2.TabIndex = 12
			Me.txtIMEI1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIMEI1.Location = New Global.System.Drawing.Point(354, 110)
			Me.txtIMEI1.Name = "txtIMEI1"
			Me.txtIMEI1.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtIMEI1.TabIndex = 11
			Me.CheckBox5.BackColor = Global.System.Drawing.Color.LightGreen
			Me.CheckBox5.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.CheckBox5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox5.ForeColor = Global.System.Drawing.Color.Blue
			Me.CheckBox5.Location = New Global.System.Drawing.Point(183, 20)
			Me.CheckBox5.Name = "CheckBox5"
			Me.CheckBox5.Size = New Global.System.Drawing.Size(63, 35)
			Me.CheckBox5.TabIndex = 1775
			Me.CheckBox5.TabStop = False
			Me.CheckBox5.Text = "Extra Info"
			Me.CheckBox5.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.CheckBox5.UseVisualStyleBackColor = False
			Me.Label28.AutoSize = True
			Me.Label28.Location = New Global.System.Drawing.Point(297, 59)
			Me.Label28.Name = "Label28"
			Me.Label28.Size = New Global.System.Drawing.Size(37, 15)
			Me.Label28.TabIndex = 1774
			Me.Label28.Text = "Size :"
			Me.Label30.AutoSize = True
			Me.Label30.Location = New Global.System.Drawing.Point(297, 86)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(49, 15)
			Me.Label30.TabIndex = 1773
			Me.Label30.Text = "Colour :"
			Me.Label33.AutoSize = True
			Me.Label33.Location = New Global.System.Drawing.Point(3, 200)
			Me.Label33.Name = "Label33"
			Me.Label33.Size = New Global.System.Drawing.Size(75, 15)
			Me.Label33.TabIndex = 1771
			Me.Label33.Text = "Expiry Date :"
			Me.Label31.AutoSize = True
			Me.Label31.Location = New Global.System.Drawing.Point(3, 177)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(66, 15)
			Me.Label31.TabIndex = 1770
			Me.Label31.Text = "Mfg. Date :"
			Me.Label32.AutoSize = True
			Me.Label32.Location = New Global.System.Drawing.Point(3, 153)
			Me.Label32.Name = "Label32"
			Me.Label32.Size = New Global.System.Drawing.Size(107, 15)
			Me.Label32.TabIndex = 1769
			Me.Label32.Text = "Batch / Serial No. :"
			Me.Label29.AutoSize = True
			Me.Label29.Location = New Global.System.Drawing.Point(3, 128)
			Me.Label29.Name = "Label29"
			Me.Label29.Size = New Global.System.Drawing.Size(102, 15)
			Me.Label29.TabIndex = 1768
			Me.Label29.Text = "Wholesale Price :"
			Me.Label34.AutoSize = True
			Me.Label34.Location = New Global.System.Drawing.Point(3, 106)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(104, 15)
			Me.Label34.TabIndex = 1767
			Me.Label34.Text = "Retail Sale Price :"
			Me.Label42.AutoSize = True
			Me.Label42.Location = New Global.System.Drawing.Point(3, 84)
			Me.Label42.Name = "Label42"
			Me.Label42.Size = New Global.System.Drawing.Size(41, 15)
			Me.Label42.TabIndex = 1766
			Me.Label42.Text = "MRP :"
			Me.Label38.AutoSize = True
			Me.Label38.Location = New Global.System.Drawing.Point(291, 157)
			Me.Label38.Name = "Label38"
			Me.Label38.Size = New Global.System.Drawing.Size(38, 15)
			Me.Label38.TabIndex = 1762
			Me.Label38.Text = "RCC :"
			Me.txtOpeningStock.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOpeningStock.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOpeningStock.Location = New Global.System.Drawing.Point(66, 17)
			Me.txtOpeningStock.Name = "txtOpeningStock"
			Me.txtOpeningStock.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtOpeningStock.TabIndex = 0
			Me.txtOpeningStock.Text = "0"
			Me.txtOpeningStock.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.TempBarcode.Location = New Global.System.Drawing.Point(362, 185)
			Me.TempBarcode.Name = "TempBarcode"
			Me.TempBarcode.[ReadOnly] = True
			Me.TempBarcode.Size = New Global.System.Drawing.Size(81, 21)
			Me.TempBarcode.TabIndex = 1765
			Me.TempBarcode.TabStop = False
			Me.TempBarcode.Visible = False
			Me.Button5.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 192)
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button5.Location = New Global.System.Drawing.Point(90, 177)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(21, 43)
			Me.Button5.TabIndex = 1764
			Me.Button5.TabStop = False
			Me.Button5.Text = "C"
			Me.Button5.UseVisualStyleBackColor = False
			Me.txtExp.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtExp.Location = New Global.System.Drawing.Point(114, 199)
			Me.txtExp.Name = "txtExp"
			Me.txtExp.[ReadOnly] = True
			Me.txtExp.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtExp.TabIndex = 1763
			Me.txtExp.TabStop = False
			Me.txtMfg.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtMfg.Location = New Global.System.Drawing.Point(114, 176)
			Me.txtMfg.Name = "txtMfg"
			Me.txtMfg.[ReadOnly] = True
			Me.txtMfg.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtMfg.TabIndex = 1762
			Me.txtMfg.TabStop = False
			Me.cmbColour.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbColour.FormattingEnabled = True
			Me.cmbColour.Location = New Global.System.Drawing.Point(354, 84)
			Me.cmbColour.Name = "cmbColour"
			Me.cmbColour.Size = New Global.System.Drawing.Size(112, 23)
			Me.cmbColour.TabIndex = 10
			Me.cmbSize.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSize.FlatStyle = Global.System.Windows.Forms.FlatStyle.System
			Me.cmbSize.FormattingEnabled = True
			Me.cmbSize.Location = New Global.System.Drawing.Point(354, 57)
			Me.cmbSize.Name = "cmbSize"
			Me.cmbSize.Size = New Global.System.Drawing.Size(112, 23)
			Me.cmbSize.TabIndex = 9
			Me.btnRemoveFromGridOS.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.btnRemoveFromGridOS.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnRemoveFromGridOS.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRemoveFromGridOS.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemoveFromGridOS.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemoveFromGridOS.ForeColor = Global.System.Drawing.Color.White
			Me.btnRemoveFromGridOS.Image = CType(componentResourceManager.GetObject("btnRemoveFromGridOS.Image"), Global.System.Drawing.Image)
			Me.btnRemoveFromGridOS.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemoveFromGridOS.Location = New Global.System.Drawing.Point(522, 57)
			Me.btnRemoveFromGridOS.Name = "btnRemoveFromGridOS"
			Me.btnRemoveFromGridOS.Size = New Global.System.Drawing.Size(69, 33)
			Me.btnRemoveFromGridOS.TabIndex = 14
			Me.btnRemoveFromGridOS.Text = "&Del"
			Me.btnRemoveFromGridOS.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemoveFromGridOS.UseVisualStyleBackColor = False
			Me.btnAddOS.BackColor = Global.System.Drawing.SystemColors.HotTrack
			Me.btnAddOS.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAddOS.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAddOS.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAddOS.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddOS.ForeColor = Global.System.Drawing.Color.White
			Me.btnAddOS.Image = CType(componentResourceManager.GetObject("btnAddOS.Image"), Global.System.Drawing.Image)
			Me.btnAddOS.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAddOS.Location = New Global.System.Drawing.Point(522, 20)
			Me.btnAddOS.Name = "btnAddOS"
			Me.btnAddOS.Size = New Global.System.Drawing.Size(69, 33)
			Me.btnAddOS.TabIndex = 13
			Me.btnAddOS.Text = "&Add"
			Me.btnAddOS.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAddOS.UseVisualStyleBackColor = False
			Me.txtMRP.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMRP.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMRP.Location = New Global.System.Drawing.Point(114, 84)
			Me.txtMRP.Name = "txtMRP"
			Me.txtMRP.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtMRP.TabIndex = 3
			Me.txtMRP.Text = "0.00"
			Me.txtMRP.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.dtpExpiryDate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dtpExpiryDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpExpiryDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpExpiryDate.Location = New Global.System.Drawing.Point(227, 200)
			Me.dtpExpiryDate.Name = "dtpExpiryDate"
			Me.dtpExpiryDate.Size = New Global.System.Drawing.Size(89, 21)
			Me.dtpExpiryDate.TabIndex = 8
			Me.TextBox4.BackColor = Global.System.Drawing.Color.LightSkyBlue
			Me.TextBox4.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.TextBox4.Location = New Global.System.Drawing.Point(474, 157)
			Me.TextBox4.Multiline = True
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(63, 18)
			Me.TextBox4.TabIndex = 1737
			Me.TextBox4.TabStop = False
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtBatchNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBatchNo.Location = New Global.System.Drawing.Point(114, 153)
			Me.txtBatchNo.Name = "txtBatchNo"
			Me.txtBatchNo.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtBatchNo.TabIndex = 6
			Me.dtpManufacturingDate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dtpManufacturingDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpManufacturingDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpManufacturingDate.Location = New Global.System.Drawing.Point(227, 177)
			Me.dtpManufacturingDate.Name = "dtpManufacturingDate"
			Me.dtpManufacturingDate.Size = New Global.System.Drawing.Size(89, 21)
			Me.dtpManufacturingDate.TabIndex = 7
			Me.Label36.AutoSize = True
			Me.Label36.Location = New Global.System.Drawing.Point(3, 17)
			Me.Label36.Name = "Label36"
			Me.Label36.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label36.TabIndex = 325
			Me.Label36.Text = "Quantity :"
			Me.txtSellingPrice.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSellingPrice.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSellingPrice.Location = New Global.System.Drawing.Point(114, 106)
			Me.txtSellingPrice.Name = "txtSellingPrice"
			Me.txtSellingPrice.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtSellingPrice.TabIndex = 4
			Me.txtSellingPrice.Text = "0.00"
			Me.txtSellingPrice.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtReorderPoint.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtReorderPoint.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtReorderPoint.Location = New Global.System.Drawing.Point(114, 128)
			Me.txtReorderPoint.Name = "txtReorderPoint"
			Me.txtReorderPoint.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtReorderPoint.TabIndex = 5
			Me.txtReorderPoint.Text = "0.00"
			Me.txtReorderPoint.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(66, 39)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(111, 21)
			Me.txtBarcode.TabIndex = 1
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(3, 40)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(59, 15)
			Me.Label13.TabIndex = 327
			Me.Label13.Text = "Barcode :"
			Me.cmbKitchen.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbKitchen.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbKitchen.FormattingEnabled = True
			Me.cmbKitchen.Location = New Global.System.Drawing.Point(125, 496)
			Me.cmbKitchen.Name = "cmbKitchen"
			Me.cmbKitchen.Size = New Global.System.Drawing.Size(111, 23)
			Me.cmbKitchen.TabIndex = 22
			Me.GroupBox4.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox4.Controls.Add(Me.dgw)
			Me.GroupBox4.Controls.Add(Me.Picture)
			Me.GroupBox4.Controls.Add(Me.Browse)
			Me.GroupBox4.Controls.Add(Me.BRemove)
			Me.GroupBox4.Controls.Add(Me.btnAdd)
			Me.GroupBox4.Controls.Add(Me.LinkLabel2)
			Me.GroupBox4.Controls.Add(Me.btnRemove)
			Me.GroupBox4.Controls.Add(Me.Label43)
			Me.GroupBox4.Controls.Add(Me.numericUpDown1)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(810, -8)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(300, 185)
			Me.GroupBox4.TabIndex = 1767
			Me.GroupBox4.TabStop = False
			Me.dgw.AllowUserToAddRows = False
			dataGridViewCellStyle13.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle14.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle14.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle14.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle14.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle14.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(121, 10)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle15.BackColor = Global.System.Drawing.Color.CadetBlue
			dataGridViewCellStyle15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle15.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle15.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle15.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle15.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle15
			Me.dgw.RowHeadersVisible = False
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle16.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle16.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle16.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle16.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle16
			Me.dgw.RowTemplate.Height = 110
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(139, 133)
			Me.dgw.TabIndex = 322
			Me.dgw.TabStop = False
			Me.Column1.AutoSizeMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
			Me.Column1.HeaderText = "Photo"
			Me.Column1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Picture.Location = New Global.System.Drawing.Point(5, 11)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(113, 132)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 297
			Me.Picture.TabStop = False
			Me.Browse.BackColor = Global.System.Drawing.Color.Transparent
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Browse.Location = New Global.System.Drawing.Point(5, 147)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(46, 34)
			Me.Browse.TabIndex = 25
			Me.Browse.TabStop = False
			Me.Browse.Text = "                       Browse..."
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BRemove.Location = New Global.System.Drawing.Point(72, 147)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(46, 34)
			Me.BRemove.TabIndex = 26
			Me.BRemove.TabStop = False
			Me.BRemove.Text = "                            Remove"
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.btnAdd.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnAdd.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAdd.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAdd.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAdd.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAdd.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.btnAdd.Image = CType(componentResourceManager.GetObject("btnAdd.Image"), Global.System.Drawing.Image)
			Me.btnAdd.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAdd.Location = New Global.System.Drawing.Point(260, 61)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New Global.System.Drawing.Size(43, 34)
			Me.btnAdd.TabIndex = 27
			Me.btnAdd.TabStop = False
			Me.btnAdd.Text = "                                &Add"
			Me.btnAdd.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAdd.UseVisualStyleBackColor = False
			Me.LinkLabel2.AutoSize = True
			Me.LinkLabel2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel2.Location = New Global.System.Drawing.Point(129, 144)
			Me.LinkLabel2.Name = "LinkLabel2"
			Me.LinkLabel2.Size = New Global.System.Drawing.Size(121, 15)
			Me.LinkLabel2.TabIndex = 1771
			Me.LinkLabel2.TabStop = True
			Me.LinkLabel2.Text = "Online Image Library"
			Me.btnRemove.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemove.ForeColor = Global.System.Drawing.Color.FromArgb(255, 192, 255)
			Me.btnRemove.Image = CType(componentResourceManager.GetObject("btnRemove.Image"), Global.System.Drawing.Image)
			Me.btnRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemove.Location = New Global.System.Drawing.Point(260, 109)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New Global.System.Drawing.Size(43, 34)
			Me.btnRemove.TabIndex = 28
			Me.btnRemove.TabStop = False
			Me.btnRemove.Text = "                                &Remove"
			Me.btnRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemove.UseVisualStyleBackColor = False
			Me.Label43.Anchor = Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label43.AutoSize = True
			Me.Label43.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label43.Location = New Global.System.Drawing.Point(126, 165)
			Me.Label43.Name = "Label43"
			Me.Label43.Size = New Global.System.Drawing.Size(78, 15)
			Me.Label43.TabIndex = 1770
			Me.Label43.Text = "Image Limit :"
			Me.numericUpDown1.Anchor = Global.System.Windows.Forms.AnchorStyles.Left
			Me.numericUpDown1.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.numericUpDown1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.numericUpDown1.Location = New Global.System.Drawing.Point(210, 165)
			Dim numericUpDown As Global.System.Windows.Forms.NumericUpDown = Me.numericUpDown1
			Dim array As Integer() = New Integer(3) {}
			array(0) = 1
			numericUpDown.Minimum = New Decimal(array)
			Me.numericUpDown1.Name = "numericUpDown1"
			Me.numericUpDown1.Size = New Global.System.Drawing.Size(46, 17)
			Me.numericUpDown1.TabIndex = 1769
			Me.numericUpDown1.TabStop = False
			Dim numericUpDown2 As Global.System.Windows.Forms.NumericUpDown = Me.numericUpDown1
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 10
			numericUpDown2.Value = New Decimal(array2)
			Me.txtSaleQty.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSaleQty.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSaleQty.Location = New Global.System.Drawing.Point(125, 468)
			Me.txtSaleQty.Name = "txtSaleQty"
			Me.txtSaleQty.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtSaleQty.TabIndex = 21
			Me.txtSaleQty.Text = "1"
			Me.txtSaleQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label35.AutoSize = True
			Me.Label35.Location = New Global.System.Drawing.Point(7, 468)
			Me.Label35.Name = "Label35"
			Me.Label35.Size = New Global.System.Drawing.Size(100, 15)
			Me.Label35.TabIndex = 1766
			Me.Label35.Text = "Default Sale Qty :"
			Me.Label41.AutoSize = True
			Me.Label41.Location = New Global.System.Drawing.Point(242, 11)
			Me.Label41.Name = "Label41"
			Me.Label41.Size = New Global.System.Drawing.Size(70, 15)
			Me.Label41.TabIndex = 1764
			Me.Label41.Text = "Product ID :"
			Me.Label41.Visible = False
			Me.Label27.AutoSize = True
			Me.Label27.Location = New Global.System.Drawing.Point(7, 439)
			Me.Label27.Name = "Label27"
			Me.Label27.Size = New Global.System.Drawing.Size(97, 15)
			Me.Label27.TabIndex = 1761
			Me.Label27.Text = "Rack / Location :"
			Me.Label23.AutoSize = True
			Me.Label23.Location = New Global.System.Drawing.Point(7, 410)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(111, 15)
			Me.Label23.TabIndex = 1760
			Me.Label23.Text = "Storage / Godown :"
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(242, 129)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(109, 15)
			Me.LinkLabel1.TabIndex = 3
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Check HSN Online"
			Me.txtID.Location = New Global.System.Drawing.Point(321, 13)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(79, 21)
			Me.txtID.TabIndex = 323
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.cmbRack.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbRack.FormattingEnabled = True
			Me.cmbRack.Location = New Global.System.Drawing.Point(125, 439)
			Me.cmbRack.Name = "cmbRack"
			Me.cmbRack.Size = New Global.System.Drawing.Size(111, 23)
			Me.cmbRack.TabIndex = 20
			Me.cmbGdown.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbGdown.FormattingEnabled = True
			Me.cmbGdown.Location = New Global.System.Drawing.Point(125, 410)
			Me.cmbGdown.Name = "cmbGdown"
			Me.cmbGdown.Size = New Global.System.Drawing.Size(111, 23)
			Me.cmbGdown.TabIndex = 19
			Me.TextBox5.Location = New Global.System.Drawing.Point(588, 108)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(65, 21)
			Me.TextBox5.TabIndex = 1739
			Me.TextBox5.TabStop = False
			Me.TextBox5.Visible = False
			Me.CheckBox2.Checked = True
			Me.CheckBox2.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.Location = New Global.System.Drawing.Point(535, 135)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(16, 19)
			Me.CheckBox2.TabIndex = 1738
			Me.CheckBox2.TabStop = False
			Me.CheckBox2.Text = "W.Sale Price Cipher Code  :"
			Me.CheckBox2.UseVisualStyleBackColor = True
			Me.CheckBox2.Visible = False
			Me.TextBox3.Location = New Global.System.Drawing.Point(565, 130)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(65, 21)
			Me.TextBox3.TabIndex = 1735
			Me.TextBox3.TabStop = False
			Me.TextBox3.Visible = False
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(439, 3)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1730
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.cmbProductName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbProductName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbProductName.Location = New Global.System.Drawing.Point(125, 39)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(372, 23)
			Me.cmbProductName.TabIndex = 0
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(503, 3)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1733
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(471, 3)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1731
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(406, 3)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1732
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.Lime
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.Location = New Global.System.Drawing.Point(290, 97)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(33, 21)
			Me.Button1.TabIndex = 348
			Me.Button1.TabStop = False
			Me.Button1.Text = "+"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button1.UseVisualStyleBackColor = False
			Me.btnProductSelection.BackColor = Global.System.Drawing.Color.Lime
			Me.btnProductSelection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnProductSelection.Location = New Global.System.Drawing.Point(290, 68)
			Me.btnProductSelection.Name = "btnProductSelection"
			Me.btnProductSelection.Size = New Global.System.Drawing.Size(33, 21)
			Me.btnProductSelection.TabIndex = 347
			Me.btnProductSelection.TabStop = False
			Me.btnProductSelection.Text = "+"
			Me.btnProductSelection.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnProductSelection.UseVisualStyleBackColor = False
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label22.Location = New Global.System.Drawing.Point(9, 406)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(39, 10)
			Me.Label22.TabIndex = 346
			Me.Label22.Text = "( Coversion Value = No(s) of Alter Unit Per Main Unit )"
			Me.Label22.Visible = False
			Me.Label21.AutoSize = True
			Me.Label21.Location = New Global.System.Drawing.Point(7, 543)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(108, 15)
			Me.Label21.TabIndex = 344
			Me.Label21.Text = "Conversion Value :"
			Me.Label21.Visible = False
			Me.Label17.AutoSize = True
			Me.Label17.Location = New Global.System.Drawing.Point(7, 155)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(78, 15)
			Me.Label17.TabIndex = 336
			Me.Label17.Text = "Part / Group :"
			Me.txtPartNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPartNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPartNo.Location = New Global.System.Drawing.Point(125, 155)
			Me.txtPartNo.Name = "txtPartNo"
			Me.txtPartNo.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtPartNo.TabIndex = 4
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(7, 126)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(71, 15)
			Me.Label16.TabIndex = 334
			Me.Label16.Text = "HSN Code :"
			Me.txtHSNCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtHSNCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtHSNCode.Location = New Global.System.Drawing.Point(125, 126)
			Me.txtHSNCode.Name = "txtHSNCode"
			Me.txtHSNCode.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtHSNCode.TabIndex = 3
			Me.cmbSubCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSubCategory.Enabled = False
			Me.cmbSubCategory.FormattingEnabled = True
			Me.cmbSubCategory.Location = New Global.System.Drawing.Point(125, 97)
			Me.cmbSubCategory.Name = "cmbSubCategory"
			Me.cmbSubCategory.Size = New Global.System.Drawing.Size(140, 23)
			Me.cmbSubCategory.TabIndex = 2
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(125, 68)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(140, 23)
			Me.cmbCategory.TabIndex = 1
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(7, 97)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(101, 15)
			Me.Label4.TabIndex = 24
			Me.Label4.Text = "Sub Cat. / Brand :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 41)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(92, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Product Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(7, 11)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(87, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Product Code :"
			Me.txtProductCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtProductCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductCode.Location = New Global.System.Drawing.Point(125, 13)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.[ReadOnly] = True
			Me.txtProductCode.Size = New Global.System.Drawing.Size(112, 21)
			Me.txtProductCode.TabIndex = 0
			Me.txtProductCode.TabStop = False
			Me.txtFeatures.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtFeatures.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtFeatures.Location = New Global.System.Drawing.Point(330, 82)
			Me.txtFeatures.Multiline = True
			Me.txtFeatures.Name = "txtFeatures"
			Me.txtFeatures.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.txtFeatures.Size = New Global.System.Drawing.Size(167, 40)
			Me.txtFeatures.TabIndex = 5
			Me.txtFeatures.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(7, 68)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(61, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Category :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(325, 64)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(177, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Product Name (2nd Language)"
			Me.CheckBox1.Checked = True
			Me.CheckBox1.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Location = New Global.System.Drawing.Point(515, 135)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(14, 19)
			Me.CheckBox1.TabIndex = 1734
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "R.Sale Price Cipher Code  :"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.CheckBox1.Visible = False
			Me.Panel3.Controls.Add(Me.btnGetData)
			Me.Panel3.Controls.Add(Me.Button4)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(1142, 47)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(169, 293)
			Me.Panel3.TabIndex = 2
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetData.FlatAppearance.BorderSize = 0
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(7, 193)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnGetData.TabIndex = 519
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.Button4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(7, 240)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(157, 43)
			Me.Button4.TabIndex = 518
			Me.Button4.Text = "Barcode"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(7, 100)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnUpdate.TabIndex = 517
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnDelete.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete.FlatAppearance.BorderSize = 0
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnDelete.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(7, 147)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnDelete.TabIndex = 516
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(7, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnNew.TabIndex = 515
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(7, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.txtBar)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.lblCondn)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtPNo)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.txtSubCategoryID)
			Me.Panel2.Controls.Add(Me.txtPName)
			Me.Panel2.Controls.Add(Me.txtBCode)
			Me.Panel2.Controls.Add(Me.txtOStock)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, -3)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1345, 35)
			Me.Panel2.TabIndex = 0
			Me.txtBar.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBar.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBar.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtBar.Location = New Global.System.Drawing.Point(672, 10)
			Me.txtBar.Multiline = True
			Me.txtBar.Name = "txtBar"
			Me.txtBar.Size = New Global.System.Drawing.Size(44, 24)
			Me.txtBar.TabIndex = 1798
			Me.txtBar.TabStop = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(446, 7)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(136, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Product Entry"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(483, 11)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1777
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.lblCondn.AutoSize = True
			Me.lblCondn.Location = New Global.System.Drawing.Point(923, 21)
			Me.lblCondn.Name = "lblCondn"
			Me.lblCondn.Size = New Global.System.Drawing.Size(48, 13)
			Me.lblCondn.TabIndex = 1726
			Me.lblCondn.Text = "lblCondn"
			Me.lblCondn.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(789, 26)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1725
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(606, 21)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1723
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtPNo.Location = New Global.System.Drawing.Point(372, 7)
			Me.txtPNo.Name = "txtPNo"
			Me.txtPNo.[ReadOnly] = True
			Me.txtPNo.Size = New Global.System.Drawing.Size(53, 20)
			Me.txtPNo.TabIndex = 342
			Me.txtPNo.TabStop = False
			Me.txtPNo.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(10, 24)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 12
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(55, 24)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(56, 13)
			Me.lblUserType.TabIndex = 313
			Me.lblUserType.Text = "User Type"
			Me.lblUserType.Visible = False
			Me.txtSubCategoryID.Location = New Global.System.Drawing.Point(126, 24)
			Me.txtSubCategoryID.Name = "txtSubCategoryID"
			Me.txtSubCategoryID.[ReadOnly] = True
			Me.txtSubCategoryID.Size = New Global.System.Drawing.Size(53, 20)
			Me.txtSubCategoryID.TabIndex = 13
			Me.txtSubCategoryID.TabStop = False
			Me.txtSubCategoryID.Visible = False
			Me.txtPName.Location = New Global.System.Drawing.Point(365, 23)
			Me.txtPName.Name = "txtPName"
			Me.txtPName.[ReadOnly] = True
			Me.txtPName.Size = New Global.System.Drawing.Size(53, 20)
			Me.txtPName.TabIndex = 341
			Me.txtPName.TabStop = False
			Me.txtPName.Visible = False
			Me.txtBCode.Location = New Global.System.Drawing.Point(247, 24)
			Me.txtBCode.Name = "txtBCode"
			Me.txtBCode.[ReadOnly] = True
			Me.txtBCode.Size = New Global.System.Drawing.Size(53, 20)
			Me.txtBCode.TabIndex = 328
			Me.txtBCode.TabStop = False
			Me.txtBCode.Visible = False
			Me.txtOStock.Location = New Global.System.Drawing.Point(306, 24)
			Me.txtOStock.Name = "txtOStock"
			Me.txtOStock.[ReadOnly] = True
			Me.txtOStock.Size = New Global.System.Drawing.Size(53, 20)
			Me.txtOStock.TabIndex = 332
			Me.txtOStock.TabStop = False
			Me.txtOStock.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 600)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmProduct"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.numericUpDown1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400361B RID: 13851
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
