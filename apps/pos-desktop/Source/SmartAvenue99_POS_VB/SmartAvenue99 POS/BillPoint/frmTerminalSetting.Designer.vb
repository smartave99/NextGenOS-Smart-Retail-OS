Namespace BillPoint
	' Token: 0x02000559 RID: 1369
		Public Partial Class frmTerminalSetting
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06010BC9 RID: 68553 RVA: 0x009C600C File Offset: 0x009C420C
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

		' Token: 0x06010BCA RID: 68554 RVA: 0x009C605C File Offset: 0x009C425C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTerminalSetting))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cmbPrinter = New Global.System.Windows.Forms.ComboBox()
			Me.txtTillID = New Global.System.Windows.Forms.TextBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.chkActivePT = New Global.System.Windows.Forms.CheckBox()
			Me.txtBrandName = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtUPIid = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.label15 = New Global.System.Windows.Forms.Label()
			Me.baudrateTxt = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox7 = New Global.System.Windows.Forms.ComboBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.ComboBox6 = New Global.System.Windows.Forms.ComboBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.cmbSecDisplay = New Global.System.Windows.Forms.ComboBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.ComboBox4 = New Global.System.Windows.Forms.ComboBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.ComboBox3 = New Global.System.Windows.Forms.ComboBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cmbPrinterType = New Global.System.Windows.Forms.ComboBox()
			Me.PrintDocument1 = New Global.System.Drawing.Printing.PrintDocument()
			Me.PrintDialog1 = New Global.System.Windows.Forms.PrintDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.ComboBox5 = New Global.System.Windows.Forms.ComboBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.Label1.Location = New Global.System.Drawing.Point(4, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(517, 33)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Terminal Setting"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(1, 49)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(75, 15)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "Terminal ID :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(396, 41)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(125, 176)
			Me.Panel3.TabIndex = 10000
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(10, 84)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(107, 36)
			Me.btnUpdate.TabIndex = 521
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(10, 125)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(107, 36)
			Me.btnDelete.TabIndex = 520
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
			Me.btnNew.Location = New Global.System.Drawing.Point(10, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(107, 36)
			Me.btnNew.TabIndex = 519
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
			Me.btnSave.Location = New Global.System.Drawing.Point(10, 44)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(107, 36)
			Me.btnSave.TabIndex = 518
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.txtID.Location = New Global.System.Drawing.Point(12, 12)
			Me.txtID.Name = "txtID"
			Me.txtID.Size = New Global.System.Drawing.Size(21, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(1, 78)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(83, 15)
			Me.Label3.TabIndex = 5
			Me.Label3.Text = "Printer Name :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(4, 397)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(517, 127)
			Me.dgw.TabIndex = 4
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.FillWeight = 96.70051F
			Me.Column2.HeaderText = "Till ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 200
			Me.Column3.FillWeight = 96.70051F
			Me.Column3.HeaderText = "Printer Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 200
			Me.Column4.HeaderText = "Invoice Template Type"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Width = 200
			Me.Column5.HeaderText = "Cash Drawer Active"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Weight Machine PORT"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 200
			Me.Column7.HeaderText = "WM Active"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "Customer Display PORT"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 200
			Me.Column9.HeaderText = "CD Active"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Secondary Display"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "QR Display Port"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "QR Active "
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column13.HeaderText = "Baud Rate"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "UPI ID"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column15.HeaderText = "Brand Name"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column16.HeaderText = "img"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.cmbPrinter.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPrinter.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPrinter.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbPrinter.FormattingEnabled = True
			Me.cmbPrinter.Location = New Global.System.Drawing.Point(138, 78)
			Me.cmbPrinter.Name = "cmbPrinter"
			Me.cmbPrinter.Size = New Global.System.Drawing.Size(252, 23)
			Me.cmbPrinter.TabIndex = 1
			Me.txtTillID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTillID.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTillID.Location = New Global.System.Drawing.Point(138, 49)
			Me.txtTillID.Name = "txtTillID"
			Me.txtTillID.Size = New Global.System.Drawing.Size(252, 23)
			Me.txtTillID.TabIndex = 0
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label16)
			Me.Panel1.Controls.Add(Me.chkActivePT)
			Me.Panel1.Controls.Add(Me.txtBrandName)
			Me.Panel1.Controls.Add(Me.Label14)
			Me.Panel1.Controls.Add(Me.txtUPIid)
			Me.Panel1.Controls.Add(Me.Label13)
			Me.Panel1.Controls.Add(Me.label15)
			Me.Panel1.Controls.Add(Me.baudrateTxt)
			Me.Panel1.Controls.Add(Me.ComboBox7)
			Me.Panel1.Controls.Add(Me.Label12)
			Me.Panel1.Controls.Add(Me.ComboBox6)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.cmbSecDisplay)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Button4)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.ComboBox4)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.ComboBox3)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.ComboBox2)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.CheckBox1)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.cmbPrinterType)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.cmbPrinter)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.txtTillID)
			Me.Panel1.Location = New Global.System.Drawing.Point(8, 10)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(528, 557)
			Me.Panel1.TabIndex = 0
			Me.chkActivePT.AutoSize = True
			Me.chkActivePT.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkActivePT.Location = New Global.System.Drawing.Point(324, 372)
			Me.chkActivePT.Name = "chkActivePT"
			Me.chkActivePT.Size = New Global.System.Drawing.Size(199, 19)
			Me.chkActivePT.TabIndex = 10015
			Me.chkActivePT.Text = "Show Menu Item Images in POS"
			Me.chkActivePT.UseVisualStyleBackColor = True
			Me.txtBrandName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBrandName.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBrandName.Location = New Global.System.Drawing.Point(358, 343)
			Me.txtBrandName.Name = "txtBrandName"
			Me.txtBrandName.Size = New Global.System.Drawing.Size(163, 23)
			Me.txtBrandName.TabIndex = 10014
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(273, 347)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(79, 15)
			Me.Label14.TabIndex = 10013
			Me.Label14.Text = "Brand Name :"
			Me.txtUPIid.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUPIid.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUPIid.Location = New Global.System.Drawing.Point(138, 344)
			Me.txtUPIid.Name = "txtUPIid"
			Me.txtUPIid.Size = New Global.System.Drawing.Size(129, 23)
			Me.txtUPIid.TabIndex = 10012
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(0, 347)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(48, 15)
			Me.Label13.TabIndex = 10011
			Me.Label13.Text = "UPI ID :"
			Me.label15.AutoSize = True
			Me.label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.label15.Location = New Global.System.Drawing.Point(422, 301)
			Me.label15.Name = "label15"
			Me.label15.Size = New Global.System.Drawing.Size(67, 13)
			Me.label15.TabIndex = 10010
			Me.label15.Text = "Baud Rate : "
			Me.baudrateTxt.Location = New Global.System.Drawing.Point(425, 317)
			Me.baudrateTxt.Name = "baudrateTxt"
			Me.baudrateTxt.Size = New Global.System.Drawing.Size(96, 20)
			Me.baudrateTxt.TabIndex = 10009
			Me.baudrateTxt.Text = "115200"
			Me.ComboBox7.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox7.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox7.FormattingEnabled = True
			Me.ComboBox7.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox7.Location = New Global.System.Drawing.Point(322, 317)
			Me.ComboBox7.Name = "ComboBox7"
			Me.ComboBox7.Size = New Global.System.Drawing.Size(91, 21)
			Me.ComboBox7.TabIndex = 10007
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(270, 319)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label12.TabIndex = 10008
			Me.Label12.Text = "Active :"
			Me.ComboBox6.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.ComboBox6.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox6.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox6.FormattingEnabled = True
			Me.ComboBox6.Location = New Global.System.Drawing.Point(138, 317)
			Me.ComboBox6.Name = "ComboBox6"
			Me.ComboBox6.Size = New Global.System.Drawing.Size(129, 21)
			Me.ComboBox6.TabIndex = 10005
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(1, 319)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(104, 15)
			Me.Label11.TabIndex = 10006
			Me.Label11.Text = "QR Display PORT :"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(242, 172)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(148, 36)
			Me.GelButton1.TabIndex = 522
			Me.GelButton1.Text = "&Template Editor"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.cmbSecDisplay.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSecDisplay.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSecDisplay.FormattingEnabled = True
			Me.cmbSecDisplay.Items.AddRange(New Object() { "No", "Yes" })
			Me.cmbSecDisplay.Location = New Global.System.Drawing.Point(273, 287)
			Me.cmbSecDisplay.Name = "cmbSecDisplay"
			Me.cmbSecDisplay.Size = New Global.System.Drawing.Size(140, 21)
			Me.cmbSecDisplay.TabIndex = 8
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.Location = New Global.System.Drawing.Point(1, 292)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(266, 15)
			Me.Label6.TabIndex = 10004
			Me.Label6.Text = "Customer Secondary Monitor Display (Yes / No) :"
			Me.Button4.Location = New Global.System.Drawing.Point(207, 181)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(29, 23)
			Me.Button4.TabIndex = 10003
			Me.Button4.TabStop = False
			Me.Button4.Text = "UI"
			Me.Button4.UseVisualStyleBackColor = True
			Me.Button4.Visible = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(476, 5)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(43, 30)
			Me.Button2.TabIndex = 10002
			Me.Button2.TabStop = False
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button2.Visible = False
			Me.ComboBox4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox4.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox4.FormattingEnabled = True
			Me.ComboBox4.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox4.Location = New Global.System.Drawing.Point(430, 260)
			Me.ComboBox4.Name = "ComboBox4"
			Me.ComboBox4.Size = New Global.System.Drawing.Size(91, 21)
			Me.ComboBox4.TabIndex = 7
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(368, 262)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label10.TabIndex = 410
			Me.Label10.Text = "Active :"
			Me.ComboBox3.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.ComboBox3.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Location = New Global.System.Drawing.Point(138, 260)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(224, 21)
			Me.ComboBox3.TabIndex = 6
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(1, 262)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(139, 15)
			Me.Label9.TabIndex = 408
			Me.Label9.Text = "Customer Display PORT :"
			Me.ComboBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(430, 223)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(91, 21)
			Me.ComboBox2.TabIndex = 5
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(368, 225)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(46, 15)
			Me.Label8.TabIndex = 406
			Me.Label8.Text = "Active :"
			Me.ComboBox1.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.ComboBox1.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(138, 223)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(224, 21)
			Me.ComboBox1.TabIndex = 4
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(1, 225)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(134, 15)
			Me.Label7.TabIndex = 404
			Me.Label7.Text = "Weight Machine PORT :"
			Me.Label5.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label5.Location = New Global.System.Drawing.Point(4, 136)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(386, 33)
			Me.Label5.TabIndex = 401
			Me.Label5.Text = "Note : If printer is shared on network then use network path of shared printer as printer name. Expmale :"
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(4, 191)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(183, 19)
			Me.CheckBox1.TabIndex = 3
			Me.CheckBox1.Text = "Cash Drawer Active (Yes / No)"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(1, 107)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(132, 15)
			Me.Label4.TabIndex = 7
			Me.Label4.Text = "Invoice Template Type :"
			Me.cmbPrinterType.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbPrinterType.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPrinterType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPrinterType.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbPrinterType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPrinterType.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbPrinterType.FormattingEnabled = True
			Me.cmbPrinterType.Items.AddRange(New Object() { "Laser Printer", "Thermal Printer" })
			Me.cmbPrinterType.Location = New Global.System.Drawing.Point(138, 107)
			Me.cmbPrinterType.Name = "cmbPrinterType"
			Me.cmbPrinterType.Size = New Global.System.Drawing.Size(252, 23)
			Me.cmbPrinterType.TabIndex = 2
			Me.PrintDialog1.UseEXDialog = True
			Me.ErrorProvider1.ContainerControl = Me
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.ForeColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(555, 15)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(34, 31)
			Me.Button3.TabIndex = 6
			Me.Button3.TabStop = False
			Me.Button3.UseVisualStyleBackColor = True
			Me.PictureBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.PictureBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.PictureBox1.Image = Global.BillPoint.My.Resources.Resources.Noimage
			Me.PictureBox1.Location = New Global.System.Drawing.Point(592, 45)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(418, 490)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 5
			Me.PictureBox1.TabStop = False
			Me.ComboBox5.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.ComboBox5.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.ComboBox5.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox5.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox5.FormattingEnabled = True
			Me.ComboBox5.Items.AddRange(New Object() { "Customise-A4", "Customise-A5", "Customise-3Inch", "Customise-4Inch", "Laser Printer-A4", "Laser Printer-A4/Professional", "Laser Printer-A4/Description", "Laser Printer-A4/No Tax", "Laser Printer-A4/No Tax-Descr", "Laser Printer-A4/Mobile", "Laser Printer-A5", "Laser Printer-A5/Professional", "Laser Printer-A5/Economical", "Laser Printer-A5/Description", "Laser Printer-A5/No Tax", "Laser Printer-A5/No Tax-Descr", "Laser Printer-A5/Mobile", "Thermal Printer-3Inch-Slip", "Thermal Printer-4Inch-Slip", "Thermal Printer-3Inch-Express", "Thermal Printer-4Inch-Express", "Thermal Printer-3Inch-1Page", "Thermal Printer-4Inch-1Page" })
			Me.ComboBox5.Location = New Global.System.Drawing.Point(592, 16)
			Me.ComboBox5.Name = "ComboBox5"
			Me.ComboBox5.Size = New Global.System.Drawing.Size(418, 23)
			Me.ComboBox5.TabIndex = 10003
			Me.Label16.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label16.Location = New Global.System.Drawing.Point(3, 167)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(184, 21)
			Me.Label16.TabIndex = 10016
			Me.Label16.Text = "\\ServerName\PrinterName"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1019, 592)
			MyBase.Controls.Add(Me.ComboBox5)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.txtID)
			Me.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmTerminalSetting"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel3.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040064ED RID: 25837
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
