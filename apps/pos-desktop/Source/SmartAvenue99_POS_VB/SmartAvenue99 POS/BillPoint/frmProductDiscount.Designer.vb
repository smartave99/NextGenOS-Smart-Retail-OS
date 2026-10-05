Namespace BillPoint
	' Token: 0x020001D9 RID: 473
		Public Partial Class frmProductDiscount
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06007E29 RID: 32297 RVA: 0x005DEDF4 File Offset: 0x005DCFF4
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

		' Token: 0x06007E2A RID: 32298 RVA: 0x005DEE44 File Offset: 0x005DD044
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductDiscount))
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
			Me.btnClear = New Global.GelButtons.GelButton()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column43 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column44 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column45 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column46 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column47 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column48 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column50 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column51 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtComboPackID = New Global.System.Windows.Forms.TextBox()
			Me.txtProductID = New Global.System.Windows.Forms.TextBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtDiscountPur = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtMaxQty = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cmbSearchCat = New Global.System.Windows.Forms.ComboBox()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.cmbProductName = New Global.System.Windows.Forms.TextBox()
			Me.txtMinQty = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.btnAddProduct = New Global.GelButtons.GelButton()
			Me.btnUpdateProduct = New Global.GelButtons.GelButton()
			Me.btnRemoveProduct = New Global.GelButtons.GelButton()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ProductName = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Barcode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DefaultQty = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.colipoid = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.dgw4 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn33 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn35 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn36 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn37 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn38 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn39 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn40 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ipoid = New Global.System.Windows.Forms.TextBox()
			Me.Panel4.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.btnClear.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnClear.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnClear.FlatAppearance.BorderSize = 0
			Me.btnClear.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnClear.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnClear.ForeColor = Global.System.Drawing.Color.White
			Me.btnClear.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnClear.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnClear.Image = CType(componentResourceManager.GetObject("btnClear.Image"), Global.System.Drawing.Image)
			Me.btnClear.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnClear.Location = New Global.System.Drawing.Point(767, 9)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(112, 35)
			Me.btnClear.TabIndex = 522
			Me.btnClear.Text = "Clear"
			Me.btnClear.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClear.UseVisualStyleBackColor = False
			Me.Column23.HeaderText = "Description"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Visible = False
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle
			Me.Column24.HeaderText = "Min Stock Limit"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column24.Visible = False
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle2.Format = "N2"
			Me.Column29.DefaultCellStyle = dataGridViewCellStyle2
			Me.Column29.HeaderText = "MRP"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column34.HeaderText = "Sale Tax Type"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			Me.Column34.Visible = False
			Me.Column43.HeaderText = "Batch"
			Me.Column43.Name = "Column43"
			Me.Column43.[ReadOnly] = True
			Me.Column43.Visible = False
			Me.Column44.HeaderText = "Mfg Date"
			Me.Column44.Name = "Column44"
			Me.Column44.[ReadOnly] = True
			Me.Column44.Visible = False
			Me.Column45.FillWeight = 120F
			Me.Column45.HeaderText = "Exp Date"
			Me.Column45.Name = "Column45"
			Me.Column45.[ReadOnly] = True
			Me.Column45.Visible = False
			Me.Column46.FillWeight = 80F
			Me.Column46.HeaderText = "Size"
			Me.Column46.Name = "Column46"
			Me.Column46.[ReadOnly] = True
			Me.Column46.Visible = False
			Me.Column47.HeaderText = "Colour"
			Me.Column47.Name = "Column47"
			Me.Column47.[ReadOnly] = True
			Me.Column47.Visible = False
			Me.Column48.HeaderText = "Def Qty"
			Me.Column48.Name = "Column48"
			Me.Column48.[ReadOnly] = True
			Me.Column48.Visible = False
			Me.Column50.HeaderText = "IMEI-1"
			Me.Column50.Name = "Column50"
			Me.Column50.[ReadOnly] = True
			Me.Column50.Visible = False
			Me.Column51.HeaderText = "IMEI-2"
			Me.Column51.Name = "Column51"
			Me.Column51.[ReadOnly] = True
			Me.Column51.Visible = False
			Me.txtComboPackID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtComboPackID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtComboPackID.Location = New Global.System.Drawing.Point(720, 3)
			Me.txtComboPackID.Name = "txtComboPackID"
			Me.txtComboPackID.Size = New Global.System.Drawing.Size(41, 21)
			Me.txtComboPackID.TabIndex = 1708
			Me.txtComboPackID.Visible = False
			Me.txtProductID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtProductID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductID.Location = New Global.System.Drawing.Point(656, 3)
			Me.txtProductID.Name = "txtProductID"
			Me.txtProductID.Size = New Global.System.Drawing.Size(41, 21)
			Me.txtProductID.TabIndex = 1706
			Me.txtProductID.Visible = False
			Me.Panel4.Controls.Add(Me.txtDiscountPur)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtMaxQty)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.btnClear)
			Me.Panel4.Controls.Add(Me.cmbSearchCat)
			Me.Panel4.Controls.Add(Me.txtBarcode)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.txtMinQty)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.btnAddProduct)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 39)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(1038, 54)
			Me.Panel4.TabIndex = 411
			Me.txtDiscountPur.Location = New Global.System.Drawing.Point(587, 19)
			Me.txtDiscountPur.Name = "txtDiscountPur"
			Me.txtDiscountPur.Size = New Global.System.Drawing.Size(69, 20)
			Me.txtDiscountPur.TabIndex = 526
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(584, 2)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(60, 13)
			Me.Label5.TabIndex = 525
			Me.Label5.Text = "Discount %"
			Me.txtMaxQty.Location = New Global.System.Drawing.Point(507, 19)
			Me.txtMaxQty.Name = "txtMaxQty"
			Me.txtMaxQty.Size = New Global.System.Drawing.Size(69, 20)
			Me.txtMaxQty.TabIndex = 524
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(504, 2)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(46, 13)
			Me.Label4.TabIndex = 523
			Me.Label4.Text = "Max Qty"
			Me.cmbSearchCat.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.cmbSearchCat.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchCat.ForeColor = Global.System.Drawing.Color.White
			Me.cmbSearchCat.FormattingEnabled = True
			Me.cmbSearchCat.Items.AddRange(New Object() { "Product Name" })
			Me.cmbSearchCat.Location = New Global.System.Drawing.Point(4, 17)
			Me.cmbSearchCat.Name = "cmbSearchCat"
			Me.cmbSearchCat.Size = New Global.System.Drawing.Size(81, 21)
			Me.cmbSearchCat.TabIndex = 521
			Me.cmbSearchCat.TabStop = False
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(285, 18)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(133, 21)
			Me.txtBarcode.TabIndex = 520
			Me.cmbProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbProductName.Location = New Global.System.Drawing.Point(91, 18)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(188, 21)
			Me.cmbProductName.TabIndex = 519
			Me.txtMinQty.Location = New Global.System.Drawing.Point(424, 19)
			Me.txtMinQty.Name = "txtMinQty"
			Me.txtMinQty.Size = New Global.System.Drawing.Size(74, 20)
			Me.txtMinQty.TabIndex = 433
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(421, 2)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label3.TabIndex = 429
			Me.Label3.Text = "Min Qty"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(282, 1)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(102, 13)
			Me.Label2.TabIndex = 427
			Me.Label2.Text = "Search By Barcode:"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(6, 1)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label7.TabIndex = 425
			Me.Label7.Text = "Search By Product Name :"
			Me.btnAddProduct.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnAddProduct.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnAddProduct.FlatAppearance.BorderSize = 0
			Me.btnAddProduct.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAddProduct.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddProduct.ForeColor = Global.System.Drawing.Color.White
			Me.btnAddProduct.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnAddProduct.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnAddProduct.Image = CType(componentResourceManager.GetObject("btnAddProduct.Image"), Global.System.Drawing.Image)
			Me.btnAddProduct.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAddProduct.Location = New Global.System.Drawing.Point(885, 9)
			Me.btnAddProduct.Name = "btnAddProduct"
			Me.btnAddProduct.Size = New Global.System.Drawing.Size(140, 35)
			Me.btnAddProduct.TabIndex = 516
			Me.btnAddProduct.Text = "Add"
			Me.btnAddProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAddProduct.UseVisualStyleBackColor = False
			Me.btnUpdateProduct.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdateProduct.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdateProduct.FlatAppearance.BorderSize = 0
			Me.btnUpdateProduct.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdateProduct.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdateProduct.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdateProduct.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdateProduct.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdateProduct.Image = CType(componentResourceManager.GetObject("btnUpdateProduct.Image"), Global.System.Drawing.Image)
			Me.btnUpdateProduct.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdateProduct.Location = New Global.System.Drawing.Point(908, 341)
			Me.btnUpdateProduct.Name = "btnUpdateProduct"
			Me.btnUpdateProduct.Size = New Global.System.Drawing.Size(127, 35)
			Me.btnUpdateProduct.TabIndex = 517
			Me.btnUpdateProduct.Text = "Update"
			Me.btnUpdateProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdateProduct.UseVisualStyleBackColor = False
			Me.btnUpdateProduct.Visible = False
			Me.btnRemoveProduct.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRemoveProduct.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnRemoveProduct.FlatAppearance.BorderSize = 0
			Me.btnRemoveProduct.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemoveProduct.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemoveProduct.ForeColor = Global.System.Drawing.Color.White
			Me.btnRemoveProduct.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnRemoveProduct.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnRemoveProduct.Image = CType(componentResourceManager.GetObject("btnRemoveProduct.Image"), Global.System.Drawing.Image)
			Me.btnRemoveProduct.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemoveProduct.Location = New Global.System.Drawing.Point(895, 99)
			Me.btnRemoveProduct.Name = "btnRemoveProduct"
			Me.btnRemoveProduct.Size = New Global.System.Drawing.Size(127, 35)
			Me.btnRemoveProduct.TabIndex = 518
			Me.btnRemoveProduct.Text = "Remove"
			Me.btnRemoveProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemoveProduct.UseVisualStyleBackColor = False
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle3
			Me.Column21.FillWeight = 60F
			Me.Column21.HeaderText = "Damage Qty"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle4
			Me.Column20.HeaderText = "Last Sold Price"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column20.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.ProductName, Me.Barcode, Me.DefaultQty, Me.Column2, Me.Column3, Me.colipoid })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle7
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(5, 99)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle8
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle9
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(884, 432)
			Me.dgw.TabIndex = 409
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "PID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.ProductName.HeaderText = "Product Name"
			Me.ProductName.Name = "ProductName"
			Me.ProductName.[ReadOnly] = True
			Me.Barcode.HeaderText = "Barcode"
			Me.Barcode.Name = "Barcode"
			Me.Barcode.[ReadOnly] = True
			Me.DefaultQty.HeaderText = "Min Qty"
			Me.DefaultQty.Name = "DefaultQty"
			Me.DefaultQty.[ReadOnly] = True
			Me.Column2.HeaderText = "MaxQty"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Discount %"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.colipoid.HeaderText = "IPO ID"
			Me.colipoid.Name = "colipoid"
			Me.colipoid.[ReadOnly] = True
			Me.colipoid.Visible = False
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(581, 17)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(10, 13)
			Me.lblBarcode.TabIndex = 428
			Me.lblBarcode.Text = ":"
			Me.lblBarcode.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(653, 19)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 408
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-15, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1062, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Item /  Product Discount"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ErrorProvider1.ContainerControl = Me
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.btnShowAll)
			Me.Panel1.Controls.Add(Me.dgw4)
			Me.Panel1.Controls.Add(Me.ipoid)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.txtComboPackID)
			Me.Panel1.Controls.Add(Me.txtProductID)
			Me.Panel1.Controls.Add(Me.btnUpdateProduct)
			Me.Panel1.Controls.Add(Me.btnRemoveProduct)
			Me.Panel1.Controls.Add(Me.lblBarcode)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1048, 588)
			Me.Panel1.TabIndex = 3
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(895, 184)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(127, 35)
			Me.GelButton1.TabIndex = 1711
			Me.GelButton1.Text = "Delete All"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnShowAll.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(895, 143)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(127, 35)
			Me.btnShowAll.TabIndex = 1710
			Me.btnShowAll.Text = "Show All Data"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.dgw4.AllowUserToAddRows = False
			Me.dgw4.AllowUserToResizeColumns = False
			Me.dgw4.AllowUserToResizeRows = False
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10
			Me.dgw4.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgw4.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw4.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw4.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw4.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgw4.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle11.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle11.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle11.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle11.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle11.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11
			Me.dgw4.ColumnHeadersHeight = 35
			Me.dgw4.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgw4.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.Column20, Me.Column21, Me.Column23, Me.Column24, Me.Column29, Me.Column34, Me.Column43, Me.Column44, Me.Column45, Me.Column46, Me.Column47, Me.Column48, Me.Column50, Me.Column51 })
			Me.dgw4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle12.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle12.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle12.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle12.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle12.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.DefaultCellStyle = dataGridViewCellStyle12
			Me.dgw4.EnableHeadersVisualStyles = False
			Me.dgw4.GridColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.dgw4.Location = New Global.System.Drawing.Point(96, 84)
			Me.dgw4.MultiSelect = False
			Me.dgw4.Name = "dgw4"
			Me.dgw4.[ReadOnly] = True
			Me.dgw4.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle13.BackColor = Global.System.Drawing.Color.YellowGreen
			dataGridViewCellStyle13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle13.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle13.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle13.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle13.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.RowHeadersDefaultCellStyle = dataGridViewCellStyle13
			Me.dgw4.RowHeadersVisible = False
			Me.dgw4.RowHeadersWidth = 25
			dataGridViewCellStyle14.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle14.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle14.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle14.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw4.RowsDefaultCellStyle = dataGridViewCellStyle14
			Me.dgw4.RowTemplate.Height = 25
			Me.dgw4.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw4.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw4.Size = New Global.System.Drawing.Size(793, 240)
			Me.dgw4.TabIndex = 1705
			Me.dgw4.TabStop = False
			Me.dgw4.Visible = False
			Me.DataGridViewTextBoxColumn23.FillWeight = 300F
			Me.DataGridViewTextBoxColumn23.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
			Me.DataGridViewTextBoxColumn23.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn23.Visible = False
			Me.DataGridViewTextBoxColumn24.HeaderText = "Product Code"
			Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
			Me.DataGridViewTextBoxColumn24.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn24.Visible = False
			Me.DataGridViewTextBoxColumn25.FillWeight = 200F
			Me.DataGridViewTextBoxColumn25.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
			Me.DataGridViewTextBoxColumn25.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.HeaderText = "HSN Code"
			Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
			Me.DataGridViewTextBoxColumn26.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn26.Visible = False
			Me.DataGridViewTextBoxColumn27.FillWeight = 60F
			Me.DataGridViewTextBoxColumn27.HeaderText = "Part / Group"
			Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
			Me.DataGridViewTextBoxColumn27.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.DataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle15
			Me.DataGridViewTextBoxColumn28.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
			Me.DataGridViewTextBoxColumn28.[ReadOnly] = True
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridViewTextBoxColumn29.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
			Me.DataGridViewTextBoxColumn29.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn29.Visible = False
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle17.Format = "N2"
			dataGridViewCellStyle17.NullValue = Nothing
			Me.DataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle17
			Me.DataGridViewTextBoxColumn30.HeaderText = "Retail Sale Price"
			Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
			Me.DataGridViewTextBoxColumn30.[ReadOnly] = True
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle18
			Me.DataGridViewTextBoxColumn31.HeaderText = "Discount"
			Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
			Me.DataGridViewTextBoxColumn31.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn31.Visible = False
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle19
			Me.DataGridViewTextBoxColumn32.HeaderText = "CGST"
			Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
			Me.DataGridViewTextBoxColumn32.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn32.Visible = False
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle20
			Me.DataGridViewTextBoxColumn33.HeaderText = "SGST"
			Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
			Me.DataGridViewTextBoxColumn33.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn33.Visible = False
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle21
			Me.DataGridViewTextBoxColumn34.HeaderText = "CESS"
			Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
			Me.DataGridViewTextBoxColumn34.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn34.Visible = False
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle22
			Me.DataGridViewTextBoxColumn35.HeaderText = "Qty"
			Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
			Me.DataGridViewTextBoxColumn35.[ReadOnly] = True
			dataGridViewCellStyle23.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle23
			Me.DataGridViewTextBoxColumn36.HeaderText = "Main Unit"
			Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
			Me.DataGridViewTextBoxColumn36.[ReadOnly] = True
			dataGridViewCellStyle24.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle24.Format = "N2"
			dataGridViewCellStyle24.NullValue = Nothing
			Me.DataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle24
			Me.DataGridViewTextBoxColumn37.HeaderText = "Wholesale Sale Price"
			Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
			Me.DataGridViewTextBoxColumn37.[ReadOnly] = True
			dataGridViewCellStyle25.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle25.Format = "N2"
			dataGridViewCellStyle25.NullValue = Nothing
			Me.DataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle25
			Me.DataGridViewTextBoxColumn38.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
			Me.DataGridViewTextBoxColumn38.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn38.Visible = False
			dataGridViewCellStyle26.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle26.NullValue = Nothing
			Me.DataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle26
			Me.DataGridViewTextBoxColumn39.HeaderText = "Alter Unit"
			Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
			Me.DataGridViewTextBoxColumn39.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn39.Visible = False
			dataGridViewCellStyle27.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle27
			Me.DataGridViewTextBoxColumn40.HeaderText = "Conv Value"
			Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
			Me.DataGridViewTextBoxColumn40.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn40.Visible = False
			Me.ipoid.Location = New Global.System.Drawing.Point(895, 260)
			Me.ipoid.Name = "ipoid"
			Me.ipoid.Size = New Global.System.Drawing.Size(69, 20)
			Me.ipoid.TabIndex = 1709
			Me.ipoid.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1048, 588)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmProductDiscount"
			Me.Text = "frmProductDiscount"
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040037BB RID: 14267
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
