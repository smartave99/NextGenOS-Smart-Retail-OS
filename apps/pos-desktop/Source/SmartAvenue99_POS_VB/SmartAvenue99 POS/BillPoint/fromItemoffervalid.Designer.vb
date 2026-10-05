Namespace BillPoint
	' Token: 0x020004ED RID: 1261
		Public Partial Class fromItemoffervalid
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060102D4 RID: 66260 RVA: 0x009A2A24 File Offset: 0x009A0C24
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

		' Token: 0x060102D5 RID: 66261 RVA: 0x009A2A74 File Offset: 0x009A0C74
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.fromItemoffervalid))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpToDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpFromDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtDiscPerc = New Global.System.Windows.Forms.TextBox()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.cmbSubCat = New Global.System.Windows.Forms.ComboBox()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.btnShowAll = New Global.System.Windows.Forms.Button()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnNew = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.btnDelete = New Global.System.Windows.Forms.Button()
			Me.btnUpdate = New Global.System.Windows.Forms.Button()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.chkSelectAll)
			Me.Panel1.Controls.Add(Me.ListView1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(10, 12)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(807, 477)
			Me.Panel1.TabIndex = 1
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Controls.Add(Me.Label4)
			Me.Panel2.Controls.Add(Me.dtpToDate)
			Me.Panel2.Controls.Add(Me.dtpFromDate)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.txtDiscPerc)
			Me.Panel2.Location = New Global.System.Drawing.Point(546, 116)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(148, 187)
			Me.Panel2.TabIndex = 412
			Me.txtID.Location = New Global.System.Drawing.Point(124, 162)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(19, 20)
			Me.txtID.TabIndex = 422
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(3, 78)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label5.TabIndex = 421
			Me.Label5.Text = "To Date :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 35)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label4.TabIndex = 420
			Me.Label4.Text = "From Date :"
			Me.dtpToDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpToDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpToDate.Location = New Global.System.Drawing.Point(6, 94)
			Me.dtpToDate.Name = "dtpToDate"
			Me.dtpToDate.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpToDate.TabIndex = 419
			Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpFromDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpFromDate.Location = New Global.System.Drawing.Point(7, 51)
			Me.dtpFromDate.Name = "dtpFromDate"
			Me.dtpFromDate.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpFromDate.TabIndex = 416
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(3, 120)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(66, 13)
			Me.Label3.TabIndex = 415
			Me.Label3.Text = "Discount % :"
			Me.txtDiscPerc.BackColor = Global.System.Drawing.Color.White
			Me.txtDiscPerc.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDiscPerc.Location = New Global.System.Drawing.Point(6, 136)
			Me.txtDiscPerc.Name = "txtDiscPerc"
			Me.txtDiscPerc.Size = New Global.System.Drawing.Size(120, 21)
			Me.txtDiscPerc.TabIndex = 420
			Me.txtDiscPerc.Text = "0.00"
			Me.txtDiscPerc.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Lime
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.Black
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(5, 98)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 430
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader7, Me.Category, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1 })
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(5, 116)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(542, 187)
			Me.ListView1.TabIndex = 429
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader7.Text = "Product Code"
			Me.ColumnHeader7.Width = 100
			Me.Category.Text = "Product Name"
			Me.Category.Width = 210
			Me.ColumnHeader8.Text = "Category"
			Me.ColumnHeader8.Width = 120
			Me.ColumnHeader9.Text = "Sub Category"
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader1.Text = "ID"
			Me.ColumnHeader1.Width = 0
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.cmbSubCat)
			Me.Panel4.Controls.Add(Me.lblBarcode)
			Me.Panel4.Controls.Add(Me.btnShowAll)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.cmbCategory)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 42)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(795, 54)
			Me.Panel4.TabIndex = 411
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(461, 5)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(129, 13)
			Me.Label2.TabIndex = 430
			Me.Label2.Text = "Search By Sub Category :"
			Me.cmbSubCat.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSubCat.FormattingEnabled = True
			Me.cmbSubCat.Location = New Global.System.Drawing.Point(464, 21)
			Me.cmbSubCat.Name = "cmbSubCat"
			Me.cmbSubCat.Size = New Global.System.Drawing.Size(170, 21)
			Me.cmbSubCat.TabIndex = 429
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(416, 6)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(10, 13)
			Me.lblBarcode.TabIndex = 428
			Me.lblBarcode.Text = ":"
			Me.lblBarcode.Visible = False
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnShowAll.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnShowAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(693, 6)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnShowAll.TabIndex = 426
			Me.btnShowAll.Text = "Show &All"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(188, 5)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label7.TabIndex = 425
			Me.Label7.Text = "Search By Product Name :"
			Me.cmbProductName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductName.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.Location = New Global.System.Drawing.Point(191, 21)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(267, 21)
			Me.cmbProductName.TabIndex = 424
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(3, 5)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(138, 13)
			Me.Label6.TabIndex = 423
			Me.Label6.Text = "Search By Category Name :"
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(6, 21)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(179, 21)
			Me.cmbCategory.TabIndex = 415
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Location = New Global.System.Drawing.Point(693, 116)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(107, 187)
			Me.Panel3.TabIndex = 413
			Me.btnNew.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNew.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(7, 7)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnNew.TabIndex = 414
			Me.btnNew.Text = "&New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(7, 51)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnSave.TabIndex = 415
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.btnDelete.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnDelete.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnDelete.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnDelete.Enabled = False
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(7, 139)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnDelete.TabIndex = 417
			Me.btnDelete.Text = "&Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnUpdate.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnUpdate.Enabled = False
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(7, 95)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(92, 40)
			Me.btnUpdate.TabIndex = 416
			Me.btnUpdate.Text = "&Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column7, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(5, 307)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
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
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(795, 164)
			Me.dgw.TabIndex = 409
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column7.HeaderText = "Product ID"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Visible = False
			Me.Column2.HeaderText = "Product Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Product Code"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Discount%"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "From Date"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "To Date"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(653, 15)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 408
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(5, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(795, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Item / Product Offer Validation"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(827, 501)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "fromItemoffervalid"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006350 RID: 25424
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
