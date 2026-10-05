Namespace BillPoint
	' Token: 0x02000127 RID: 295
		Public Partial Class frmLead2
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060032D7 RID: 13015 RVA: 0x001F6880 File Offset: 0x001F4A80
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

		' Token: 0x060032D8 RID: 13016 RVA: 0x001F68D0 File Offset: 0x001F4AD0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Id = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lead_id = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.customer_name = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.co_mode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.mobileno = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.state = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.address = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.intrest_mode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.product_name = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.alloted_user = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.remarks = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.InsertButtonColumn = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.UpdateButtonColumn = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.DeleteButtonColumn = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.grdState = New Global.System.Windows.Forms.DataGridView()
			Me.txtID_Update = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.grdCo_Mode = New Global.System.Windows.Forms.DataGridView()
			Me.grdIntrest_Mode = New Global.System.Windows.Forms.DataGridView()
			Me.grdProduct = New Global.System.Windows.Forms.DataGridView()
			Me.grdUser = New Global.System.Windows.Forms.DataGridView()
			Me.txtLead_Id = New Global.System.Windows.Forms.TextBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.btnExportExcel = New Global.System.Windows.Forms.Button()
			Me.btnShowAll = New Global.System.Windows.Forms.Button()
			Me.GelButtonNewRecord = New Global.System.Windows.Forms.Button()
			Me.btnAddProduct = New Global.System.Windows.Forms.Button()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtMobile = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.grdState, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel7.SuspendLayout()
			CType(Me.grdCo_Mode, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.grdIntrest_Mode, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.grdProduct, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.grdUser, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 40
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Id, Me.lead_id, Me.customer_name, Me.co_mode, Me.mobileno, Me.state, Me.address, Me.intrest_mode, Me.product_name, Me.alloted_user, Me.remarks, Me.InsertButtonColumn, Me.UpdateButtonColumn, Me.DeleteButtonColumn })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.DataGridView1.Location = New Global.System.Drawing.Point(12, 59)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 15
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 30
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1162, 330)
			Me.DataGridView1.TabIndex = 437
			Me.DataGridView1.TabStop = False
			Me.Id.HeaderText = "Id"
			Me.Id.Name = "Id"
			Me.Id.Visible = False
			Me.Id.Width = 50
			Me.lead_id.HeaderText = "Lead Id"
			Me.lead_id.Name = "lead_id"
			Me.lead_id.Width = 94
			Me.customer_name.FillWeight = 740.0392F
			Me.customer_name.HeaderText = "Customer Name"
			Me.customer_name.Name = "customer_name"
			Me.customer_name.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.customer_name.Visible = False
			Me.customer_name.Width = 162
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.Padding = New Global.System.Windows.Forms.Padding(2)
			Me.co_mode.DefaultCellStyle = dataGridViewCellStyle6
			Me.co_mode.FillWeight = 266.6693F
			Me.co_mode.HeaderText = "Co-Ordinate Mode"
			Me.co_mode.Name = "co_mode"
			Me.co_mode.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.co_mode.Visible = False
			Me.co_mode.Width = 180
			Me.mobileno.FillWeight = 219.0145F
			Me.mobileno.HeaderText = "Mobile No."
			Me.mobileno.Name = "mobileno"
			Me.mobileno.Width = 117
			Me.state.DataPropertyName = "cmbState"
			Me.state.FillWeight = 142.034F
			Me.state.HeaderText = "State"
			Me.state.Name = "state"
			Me.state.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.state.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.state.Visible = False
			Me.state.Width = 59
			Me.address.FillWeight = 203.019F
			Me.address.HeaderText = "Address"
			Me.address.Name = "address"
			Me.address.Visible = False
			dataGridViewCellStyle7.Padding = New Global.System.Windows.Forms.Padding(2)
			Me.intrest_mode.DefaultCellStyle = dataGridViewCellStyle7
			Me.intrest_mode.FillWeight = 95.29082F
			Me.intrest_mode.HeaderText = "Intrest Mode"
			Me.intrest_mode.Name = "intrest_mode"
			Me.intrest_mode.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.intrest_mode.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.intrest_mode.Visible = False
			Me.intrest_mode.Width = 117
			Me.product_name.HeaderText = "Product Name"
			Me.product_name.Name = "product_name"
			Me.product_name.Visible = False
			Me.product_name.Width = 147
			Me.alloted_user.HeaderText = "Alloted User"
			Me.alloted_user.Name = "alloted_user"
			Me.alloted_user.Width = 132
			Me.remarks.HeaderText = "Remarks"
			Me.remarks.Name = "remarks"
			Me.remarks.Width = 104
			Me.InsertButtonColumn.FillWeight = 13.07769F
			Me.InsertButtonColumn.HeaderText = "Insert"
			Me.InsertButtonColumn.Name = "InsertButtonColumn"
			Me.InsertButtonColumn.Text = "Insert"
			Me.InsertButtonColumn.UseColumnTextForButtonValue = True
			Me.InsertButtonColumn.Width = 61
			Me.UpdateButtonColumn.DataPropertyName = "UpdateButtonColumn"
			Me.UpdateButtonColumn.FillWeight = 12.39162F
			Me.UpdateButtonColumn.HeaderText = "Update"
			Me.UpdateButtonColumn.Name = "UpdateButtonColumn"
			Me.UpdateButtonColumn.Text = "Update"
			Me.UpdateButtonColumn.UseColumnTextForButtonValue = True
			Me.UpdateButtonColumn.Width = 73
			Me.DeleteButtonColumn.DataPropertyName = "DeleteButtonColumn"
			Me.DeleteButtonColumn.FillWeight = 11.75682F
			Me.DeleteButtonColumn.HeaderText = "Delete"
			Me.DeleteButtonColumn.Name = "DeleteButtonColumn"
			Me.DeleteButtonColumn.Text = "Delete"
			Me.DeleteButtonColumn.UseColumnTextForButtonValue = True
			Me.DeleteButtonColumn.Width = 67
			Me.grdState.AllowUserToAddRows = False
			Me.grdState.AllowUserToDeleteRows = False
			Me.grdState.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdState.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.grdState.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdState.Location = New Global.System.Drawing.Point(32, 243)
			Me.grdState.Name = "grdState"
			Me.grdState.[ReadOnly] = True
			Me.grdState.Size = New Global.System.Drawing.Size(240, 118)
			Me.grdState.TabIndex = 1847
			Me.grdState.Visible = False
			Me.txtID_Update.Location = New Global.System.Drawing.Point(521, 27)
			Me.txtID_Update.Name = "txtID_Update"
			Me.txtID_Update.Size = New Global.System.Drawing.Size(23, 20)
			Me.txtID_Update.TabIndex = 1848
			Me.txtID_Update.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(512, 1)
			Me.txtID.Name = "txtID"
			Me.txtID.Size = New Global.System.Drawing.Size(13, 20)
			Me.txtID.TabIndex = 1849
			Me.txtID.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(763, 1)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1850
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Location = New Global.System.Drawing.Point(12, 12)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(301, 41)
			Me.Panel7.TabIndex = 1851
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(183, 5)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(13, 5)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(80, 5)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(97, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "5"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.grdCo_Mode.AllowUserToAddRows = False
			Me.grdCo_Mode.AllowUserToDeleteRows = False
			Me.grdCo_Mode.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdCo_Mode.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.grdCo_Mode.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdCo_Mode.Location = New Global.System.Drawing.Point(278, 243)
			Me.grdCo_Mode.Name = "grdCo_Mode"
			Me.grdCo_Mode.[ReadOnly] = True
			Me.grdCo_Mode.Size = New Global.System.Drawing.Size(130, 118)
			Me.grdCo_Mode.TabIndex = 1852
			Me.grdCo_Mode.Visible = False
			Me.grdIntrest_Mode.AllowUserToAddRows = False
			Me.grdIntrest_Mode.AllowUserToDeleteRows = False
			Me.grdIntrest_Mode.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdIntrest_Mode.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.grdIntrest_Mode.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdIntrest_Mode.Location = New Global.System.Drawing.Point(414, 243)
			Me.grdIntrest_Mode.Name = "grdIntrest_Mode"
			Me.grdIntrest_Mode.[ReadOnly] = True
			Me.grdIntrest_Mode.Size = New Global.System.Drawing.Size(130, 118)
			Me.grdIntrest_Mode.TabIndex = 1853
			Me.grdIntrest_Mode.Visible = False
			Me.grdProduct.AllowUserToAddRows = False
			Me.grdProduct.AllowUserToDeleteRows = False
			Me.grdProduct.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdProduct.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.grdProduct.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdProduct.Location = New Global.System.Drawing.Point(550, 243)
			Me.grdProduct.Name = "grdProduct"
			Me.grdProduct.[ReadOnly] = True
			Me.grdProduct.Size = New Global.System.Drawing.Size(275, 118)
			Me.grdProduct.TabIndex = 1857
			Me.grdProduct.Visible = False
			Me.grdUser.AllowUserToAddRows = False
			Me.grdUser.AllowUserToDeleteRows = False
			Me.grdUser.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.grdUser.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.grdUser.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.grdUser.Location = New Global.System.Drawing.Point(831, 243)
			Me.grdUser.Name = "grdUser"
			Me.grdUser.[ReadOnly] = True
			Me.grdUser.Size = New Global.System.Drawing.Size(130, 118)
			Me.grdUser.TabIndex = 1858
			Me.grdUser.Visible = False
			Me.txtLead_Id.Location = New Global.System.Drawing.Point(531, 1)
			Me.txtLead_Id.Name = "txtLead_Id"
			Me.txtLead_Id.Size = New Global.System.Drawing.Size(13, 20)
			Me.txtLead_Id.TabIndex = 1859
			Me.txtLead_Id.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(653, 1)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1860
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackgroundImage = Global.BillPoint.My.Resources.Resources.Reset_copy
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Location = New Global.System.Drawing.Point(644, 11)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(128, 41)
			Me.btnReset.TabIndex = 1854
			Me.btnReset.UseVisualStyleBackColor = True
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackgroundImage = Global.BillPoint.My.Resources.Resources.Export_Excel_copy
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(912, 11)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(128, 41)
			Me.btnExportExcel.TabIndex = 1855
			Me.btnExportExcel.UseVisualStyleBackColor = True
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackgroundImage = Global.BillPoint.My.Resources.Resources.Show_All_copy
			Me.btnShowAll.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Location = New Global.System.Drawing.Point(778, 11)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(128, 41)
			Me.btnShowAll.TabIndex = 1856
			Me.btnShowAll.UseVisualStyleBackColor = True
			Me.GelButtonNewRecord.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButtonNewRecord.BackgroundImage = Global.BillPoint.My.Resources.Resources.New_copy1
			Me.GelButtonNewRecord.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButtonNewRecord.FlatAppearance.BorderSize = 0
			Me.GelButtonNewRecord.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButtonNewRecord.Location = New Global.System.Drawing.Point(1046, 11)
			Me.GelButtonNewRecord.Name = "GelButtonNewRecord"
			Me.GelButtonNewRecord.Size = New Global.System.Drawing.Size(128, 41)
			Me.GelButtonNewRecord.TabIndex = 1835
			Me.GelButtonNewRecord.UseVisualStyleBackColor = True
			Me.btnAddProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8F, Global.System.Drawing.FontStyle.Bold)
			Me.btnAddProduct.ForeColor = Global.System.Drawing.Color.Red
			Me.btnAddProduct.Location = New Global.System.Drawing.Point(550, 12)
			Me.btnAddProduct.Name = "btnAddProduct"
			Me.btnAddProduct.Size = New Global.System.Drawing.Size(88, 37)
			Me.btnAddProduct.TabIndex = 1861
			Me.btnAddProduct.Text = "Add Product"
			Me.btnAddProduct.UseVisualStyleBackColor = True
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(565, 1)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label15.TabIndex = 1862
			Me.Label15.Text = "Label1"
			Me.Label15.Visible = False
			Me.txtMobile.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtMobile.Location = New Global.System.Drawing.Point(319, 27)
			Me.txtMobile.Name = "txtMobile"
			Me.txtMobile.Size = New Global.System.Drawing.Size(149, 26)
			Me.txtMobile.TabIndex = 1807
			Me.txtMobile.TabStop = False
			Me.txtMobile.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(319, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(149, 15)
			Me.Label1.TabIndex = 1807
			Me.Label1.Text = "Mobile No. :"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1186, 392)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtMobile)
			MyBase.Controls.Add(Me.Label15)
			MyBase.Controls.Add(Me.btnAddProduct)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.txtLead_Id)
			MyBase.Controls.Add(Me.grdUser)
			MyBase.Controls.Add(Me.grdProduct)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.btnExportExcel)
			MyBase.Controls.Add(Me.btnShowAll)
			MyBase.Controls.Add(Me.grdIntrest_Mode)
			MyBase.Controls.Add(Me.grdCo_Mode)
			MyBase.Controls.Add(Me.Panel7)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.txtID_Update)
			MyBase.Controls.Add(Me.grdState)
			MyBase.Controls.Add(Me.GelButtonNewRecord)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Name = "frmLead2"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Lead Generate"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.grdState, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			CType(Me.grdCo_Mode, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.grdIntrest_Mode, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.grdProduct, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.grdUser, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040015F9 RID: 5625
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
