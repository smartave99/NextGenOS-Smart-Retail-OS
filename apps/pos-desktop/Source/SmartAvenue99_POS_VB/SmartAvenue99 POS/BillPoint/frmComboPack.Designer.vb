Namespace BillPoint
	' Token: 0x020000CE RID: 206
		Public Partial Class frmComboPack
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600238C RID: 9100 RVA: 0x00169028 File Offset: 0x00167228
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

		' Token: 0x0600238D RID: 9101 RVA: 0x00169078 File Offset: 0x00167278
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
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmComboPack))
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ProductName = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Barcode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DefaultQty = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
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
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
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
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.btnUpdateProduct = New Global.GelButtons.GelButton()
			Me.btnRemoveProduct = New Global.GelButtons.GelButton()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnClear = New Global.GelButtons.GelButton()
			Me.cmbSearchCat = New Global.System.Windows.Forms.ComboBox()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.cmbProductName = New Global.System.Windows.Forms.TextBox()
			Me.txtQty = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.btnAddProduct = New Global.GelButtons.GelButton()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			MyBase.SuspendLayout()
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(581, 17)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(10, 13)
			Me.lblBarcode.TabIndex = 428
			Me.lblBarcode.Text = ":"
			Me.lblBarcode.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.ProductName, Me.Barcode, Me.DefaultQty, Me.Column2 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(5, 143)
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
			Me.dgw.Size = New Global.System.Drawing.Size(687, 432)
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
			Me.DefaultQty.HeaderText = "Default Qty"
			Me.DefaultQty.Name = "DefaultQty"
			Me.DefaultQty.[ReadOnly] = True
			Me.Column2.HeaderText = "ComboPack Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
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
			Me.Label1.Size = New Global.System.Drawing.Size(865, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Item /  Combo Offer Validation"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.ErrorProvider1.ContainerControl = Me
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.dgw4)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.txtComboPackID)
			Me.Panel1.Controls.Add(Me.txtProductID)
			Me.Panel1.Controls.Add(Me.GelButton4)
			Me.Panel1.Controls.Add(Me.cmbCategory)
			Me.Panel1.Controls.Add(Me.btnUpdateProduct)
			Me.Panel1.Controls.Add(Me.btnRemoveProduct)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.lblBarcode)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(851, 588)
			Me.Panel1.TabIndex = 2
			Me.dgw4.AllowUserToAddRows = False
			Me.dgw4.AllowUserToResizeColumns = False
			Me.dgw4.AllowUserToResizeRows = False
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw4.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgw4.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw4.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw4.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw4.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgw4.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7
			Me.dgw4.ColumnHeadersHeight = 35
			Me.dgw4.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgw4.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34, Me.DataGridViewTextBoxColumn35, Me.DataGridViewTextBoxColumn36, Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.Column20, Me.Column21, Me.Column23, Me.Column24, Me.Column29, Me.Column34, Me.Column43, Me.Column44, Me.Column45, Me.Column46, Me.Column47, Me.Column48, Me.Column50, Me.Column51 })
			Me.dgw4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.DefaultCellStyle = dataGridViewCellStyle8
			Me.dgw4.EnableHeadersVisualStyles = False
			Me.dgw4.GridColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.dgw4.Location = New Global.System.Drawing.Point(96, 120)
			Me.dgw4.MultiSelect = False
			Me.dgw4.Name = "dgw4"
			Me.dgw4.[ReadOnly] = True
			Me.dgw4.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.YellowGreen
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw4.RowHeadersDefaultCellStyle = dataGridViewCellStyle9
			Me.dgw4.RowHeadersVisible = False
			Me.dgw4.RowHeadersWidth = 25
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle10.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle10.SelectionBackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle10.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw4.RowsDefaultCellStyle = dataGridViewCellStyle10
			Me.dgw4.RowTemplate.Height = 25
			Me.dgw4.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw4.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw4.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw4.Size = New Global.System.Drawing.Size(596, 162)
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
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.DataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle11
			Me.DataGridViewTextBoxColumn28.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
			Me.DataGridViewTextBoxColumn28.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle12
			Me.DataGridViewTextBoxColumn29.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
			Me.DataGridViewTextBoxColumn29.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn29.Visible = False
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle13.Format = "N2"
			dataGridViewCellStyle13.NullValue = Nothing
			Me.DataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle13
			Me.DataGridViewTextBoxColumn30.HeaderText = "Retail Sale Price"
			Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
			Me.DataGridViewTextBoxColumn30.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle14
			Me.DataGridViewTextBoxColumn31.HeaderText = "Discount"
			Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
			Me.DataGridViewTextBoxColumn31.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn31.Visible = False
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle15
			Me.DataGridViewTextBoxColumn32.HeaderText = "CGST"
			Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
			Me.DataGridViewTextBoxColumn32.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn32.Visible = False
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridViewTextBoxColumn33.HeaderText = "SGST"
			Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
			Me.DataGridViewTextBoxColumn33.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn33.Visible = False
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle17
			Me.DataGridViewTextBoxColumn34.HeaderText = "CESS"
			Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
			Me.DataGridViewTextBoxColumn34.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn34.Visible = False
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.DataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle18
			Me.DataGridViewTextBoxColumn35.HeaderText = "Qty"
			Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
			Me.DataGridViewTextBoxColumn35.[ReadOnly] = True
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle19
			Me.DataGridViewTextBoxColumn36.HeaderText = "Main Unit"
			Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
			Me.DataGridViewTextBoxColumn36.[ReadOnly] = True
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle20.Format = "N2"
			dataGridViewCellStyle20.NullValue = Nothing
			Me.DataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle20
			Me.DataGridViewTextBoxColumn37.HeaderText = "Wholesale Sale Price"
			Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
			Me.DataGridViewTextBoxColumn37.[ReadOnly] = True
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle21.Format = "N2"
			dataGridViewCellStyle21.NullValue = Nothing
			Me.DataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle21
			Me.DataGridViewTextBoxColumn38.HeaderText = "Purchase Price"
			Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
			Me.DataGridViewTextBoxColumn38.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn38.Visible = False
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle22.NullValue = Nothing
			Me.DataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle22
			Me.DataGridViewTextBoxColumn39.HeaderText = "Alter Unit"
			Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
			Me.DataGridViewTextBoxColumn39.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn39.Visible = False
			dataGridViewCellStyle23.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle23
			Me.DataGridViewTextBoxColumn40.HeaderText = "Conv Value"
			Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
			Me.DataGridViewTextBoxColumn40.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn40.Visible = False
			dataGridViewCellStyle24.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle24
			Me.Column20.HeaderText = "Last Sold Price"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column20.Visible = False
			dataGridViewCellStyle25.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle25
			Me.Column21.FillWeight = 60F
			Me.Column21.HeaderText = "Damage Qty"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column23.HeaderText = "Description"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Visible = False
			dataGridViewCellStyle26.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle26
			Me.Column24.HeaderText = "Min Stock Limit"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column24.Visible = False
			dataGridViewCellStyle27.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle27.Format = "N2"
			Me.Column29.DefaultCellStyle = dataGridViewCellStyle27
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
			Me.txtComboPackID.Location = New Global.System.Drawing.Point(565, 50)
			Me.txtComboPackID.Name = "txtComboPackID"
			Me.txtComboPackID.Size = New Global.System.Drawing.Size(41, 21)
			Me.txtComboPackID.TabIndex = 1708
			Me.txtComboPackID.Visible = False
			Me.txtProductID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtProductID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductID.Location = New Global.System.Drawing.Point(501, 50)
			Me.txtProductID.Name = "txtProductID"
			Me.txtProductID.Size = New Global.System.Drawing.Size(41, 21)
			Me.txtProductID.TabIndex = 1706
			Me.txtProductID.Visible = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(397, 49)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(34, 32)
			Me.GelButton4.TabIndex = 521
			Me.GelButton4.Text = "+"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.cmbCategory.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCategory.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbCategory.Location = New Global.System.Drawing.Point(5, 57)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(386, 21)
			Me.cmbCategory.TabIndex = 525
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
			Me.btnUpdateProduct.Location = New Global.System.Drawing.Point(698, 184)
			Me.btnUpdateProduct.Name = "btnUpdateProduct"
			Me.btnUpdateProduct.Size = New Global.System.Drawing.Size(127, 35)
			Me.btnUpdateProduct.TabIndex = 517
			Me.btnUpdateProduct.Text = "Update"
			Me.btnUpdateProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdateProduct.UseVisualStyleBackColor = False
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
			Me.btnRemoveProduct.Location = New Global.System.Drawing.Point(698, 143)
			Me.btnRemoveProduct.Name = "btnRemoveProduct"
			Me.btnRemoveProduct.Size = New Global.System.Drawing.Size(127, 35)
			Me.btnRemoveProduct.TabIndex = 518
			Me.btnRemoveProduct.Text = "Remove"
			Me.btnRemoveProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemoveProduct.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(2, 41)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label5.TabIndex = 430
			Me.Label5.Text = "Combo Name"
			Me.Panel4.Controls.Add(Me.btnClear)
			Me.Panel4.Controls.Add(Me.cmbSearchCat)
			Me.Panel4.Controls.Add(Me.txtBarcode)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.txtQty)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.btnAddProduct)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 82)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(833, 54)
			Me.Panel4.TabIndex = 411
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
			Me.btnClear.Location = New Global.System.Drawing.Point(562, 9)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New Global.System.Drawing.Size(112, 35)
			Me.btnClear.TabIndex = 522
			Me.btnClear.Text = "Clear"
			Me.btnClear.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnClear.UseVisualStyleBackColor = False
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
			Me.txtQty.Location = New Global.System.Drawing.Point(424, 19)
			Me.txtQty.Name = "txtQty"
			Me.txtQty.Size = New Global.System.Drawing.Size(122, 20)
			Me.txtQty.TabIndex = 433
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(421, 2)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(60, 13)
			Me.Label3.TabIndex = 429
			Me.Label3.Text = "Default Qty"
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
			Me.btnAddProduct.Location = New Global.System.Drawing.Point(680, 9)
			Me.btnAddProduct.Name = "btnAddProduct"
			Me.btnAddProduct.Size = New Global.System.Drawing.Size(140, 35)
			Me.btnAddProduct.TabIndex = 516
			Me.btnAddProduct.Text = "Add"
			Me.btnAddProduct.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAddProduct.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(851, 588)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.MinimizeBox = False
			MyBase.Name = "frmComboPack"
			Me.Text = "frmComboPack"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw4, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000E89 RID: 3721
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
