Namespace BillPoint
	' Token: 0x0200030E RID: 782
		Public Partial Class frmBankAccountRegistration
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600B937 RID: 47415 RVA: 0x00773A18 File Offset: 0x00771C18
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

		' Token: 0x0600B938 RID: 47416 RVA: 0x00773A68 File Offset: 0x00771C68
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBankAccountRegistration))
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.txtBank = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtSwiftCode = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtIFSCCode = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.cmbActive = New Global.System.Windows.Forms.ComboBox()
			Me.txtBalanceAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountType = New Global.System.Windows.Forms.ComboBox()
			Me.txtAccountNo = New Global.System.Windows.Forms.TextBox()
			Me.dtpOpeningDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtAccountName = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtBranchID = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtAccNo = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNe = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.txtBranchID)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.txtAccNo)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1059, 680)
			Me.Panel1.TabIndex = 2
			Me.txtID.Location = New Global.System.Drawing.Point(409, 184)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtID.TabIndex = 9
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.GroupBox2.Controls.Add(Me.txtBank)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.txtSwiftCode)
			Me.GroupBox2.Controls.Add(Me.txtContactNo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.txtIFSCCode)
			Me.GroupBox2.Controls.Add(Me.txtAddress)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.txtBranchName)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 229)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(384, 253)
			Me.GroupBox2.TabIndex = 8
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Bank Details"
			Me.txtBank.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(121, 24)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.[ReadOnly] = True
			Me.txtBank.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBank.TabIndex = 0
			Me.txtBank.TabStop = False
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(14, 24)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Bank :"
			Me.txtSwiftCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSwiftCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode.Location = New Global.System.Drawing.Point(121, 192)
			Me.txtSwiftCode.Name = "txtSwiftCode"
			Me.txtSwiftCode.[ReadOnly] = True
			Me.txtSwiftCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtSwiftCode.TabIndex = 4
			Me.txtSwiftCode.TabStop = False
			Me.txtContactNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(121, 164)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtContactNo.TabIndex = 3
			Me.txtContactNo.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(14, 109)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Address :"
			Me.txtIFSCCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtIFSCCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode.Location = New Global.System.Drawing.Point(121, 219)
			Me.txtIFSCCode.Name = "txtIFSCCode"
			Me.txtIFSCCode.[ReadOnly] = True
			Me.txtIFSCCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtIFSCCode.TabIndex = 5
			Me.txtIFSCCode.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(121, 82)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.[ReadOnly] = True
			Me.txtAddress.Size = New Global.System.Drawing.Size(246, 75)
			Me.txtAddress.TabIndex = 2
			Me.txtAddress.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(14, 164)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Contact No. :"
			Me.txtBranchName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBranchName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName.Location = New Global.System.Drawing.Point(121, 55)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.[ReadOnly] = True
			Me.txtBranchName.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBranchName.TabIndex = 1
			Me.txtBranchName.TabStop = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(14, 192)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "IFSC :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(14, 219)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Branch Code :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(14, 55)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Branch Name :"
			Me.GroupBox1.Controls.Add(Me.cmbActive)
			Me.GroupBox1.Controls.Add(Me.txtBalanceAmount)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.cmbAccountType)
			Me.GroupBox1.Controls.Add(Me.txtAccountNo)
			Me.GroupBox1.Controls.Add(Me.dtpOpeningDate)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.Label12)
			Me.GroupBox1.Controls.Add(Me.txtAccountName)
			Me.GroupBox1.Controls.Add(Me.Label11)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 42)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(399, 174)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Account Information"
			Me.cmbActive.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbActive.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbActive.FormattingEnabled = True
			Me.cmbActive.Items.AddRange(New Object() { "Yes", "No" })
			Me.cmbActive.Location = New Global.System.Drawing.Point(291, 134)
			Me.cmbActive.Name = "cmbActive"
			Me.cmbActive.Size = New Global.System.Drawing.Size(87, 21)
			Me.cmbActive.TabIndex = 5
			Me.txtBalanceAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBalanceAmount.Location = New Global.System.Drawing.Point(109, 134)
			Me.txtBalanceAmount.Name = "txtBalanceAmount"
			Me.txtBalanceAmount.Size = New Global.System.Drawing.Size(123, 20)
			Me.txtBalanceAmount.TabIndex = 4
			Me.txtBalanceAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(12, 22)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label5.TabIndex = 38
			Me.Label5.Text = "Account No. :"
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(246, 134)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label13.TabIndex = 39
			Me.Label13.Text = "Active :"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(12, 134)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label8.TabIndex = 37
			Me.Label8.Text = "Balance Amount :"
			Me.cmbAccountType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountType.FormattingEnabled = True
			Me.cmbAccountType.Items.AddRange(New Object() { "Current Account", "Savings Bank Account", "Fixed Deposit Account" })
			Me.cmbAccountType.Location = New Global.System.Drawing.Point(110, 78)
			Me.cmbAccountType.Name = "cmbAccountType"
			Me.cmbAccountType.Size = New Global.System.Drawing.Size(268, 21)
			Me.cmbAccountType.TabIndex = 2
			Me.txtAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountNo.Location = New Global.System.Drawing.Point(110, 22)
			Me.txtAccountNo.Name = "txtAccountNo"
			Me.txtAccountNo.Size = New Global.System.Drawing.Size(268, 20)
			Me.txtAccountNo.TabIndex = 0
			Me.dtpOpeningDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpOpeningDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpOpeningDate.Location = New Global.System.Drawing.Point(110, 106)
			Me.dtpOpeningDate.Name = "dtpOpeningDate"
			Me.dtpOpeningDate.Size = New Global.System.Drawing.Size(97, 20)
			Me.dtpOpeningDate.TabIndex = 3
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(12, 106)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(79, 13)
			Me.Label10.TabIndex = 35
			Me.Label10.Text = "Opening Date :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(12, 50)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label12.TabIndex = 33
			Me.Label12.Text = "Account Name :"
			Me.txtAccountName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAccountName.Location = New Global.System.Drawing.Point(110, 50)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.Size = New Global.System.Drawing.Size(268, 20)
			Me.txtAccountName.TabIndex = 1
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(12, 78)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label11.TabIndex = 34
			Me.Label11.Text = "Account Type :"
			Me.txtBranchID.Location = New Global.System.Drawing.Point(409, 231)
			Me.txtBranchID.Name = "txtBranchID"
			Me.txtBranchID.[ReadOnly] = True
			Me.txtBranchID.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtBranchID.TabIndex = 6
			Me.txtBranchID.TabStop = False
			Me.txtBranchID.Visible = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column7, Me.Column8, Me.Column9, Me.Column11, Me.Column13, Me.Column14, Me.Column12, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.Column15 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(4, 488)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1036, 173)
			Me.DataGridView1.TabIndex = 3
			Me.DataGridView1.TabStop = False
			Me.Column7.HeaderText = "Account No."
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "Account Name"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column9.HeaderText = "Account Type"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			dataGridViewCellStyle5.Format = "dd/MM/yyyy"
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle5
			Me.Column11.HeaderText = "Opening Date"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column13.HeaderText = "Balance Amount"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "Active"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column12.HeaderText = "Branch ID"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column12.Visible = False
			Me.DataGridViewTextBoxColumn2.HeaderText = "Bank"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn3.HeaderText = "Branch Name"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn3.Width = 114
			Me.DataGridViewTextBoxColumn4.HeaderText = "Address"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn5.HeaderText = "Contact No."
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn6.HeaderText = "IFSC"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn7.HeaderText = "Branch Code"
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			Me.Column15.HeaderText = "ID"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column15.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(523, 221)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtAccNo.Location = New Global.System.Drawing.Point(409, 210)
			Me.txtAccNo.Name = "txtAccNo"
			Me.txtAccNo.[ReadOnly] = True
			Me.txtAccNo.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtAccNo.TabIndex = 4
			Me.txtAccNo.TabStop = False
			Me.txtAccNo.Visible = False
			Me.GroupBox3.Controls.Add(Me.btnUpdate)
			Me.GroupBox3.Controls.Add(Me.btnDelete)
			Me.GroupBox3.Controls.Add(Me.btnNe)
			Me.GroupBox3.Controls.Add(Me.btnSave)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(916, 42)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(127, 196)
			Me.GroupBox3.TabIndex = 30
			Me.GroupBox3.TabStop = False
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(3, 101)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(121, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(3, 148)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(121, 43)
			Me.btnDelete.TabIndex = 520
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnNe.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNe.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNe.FlatAppearance.BorderSize = 0
			Me.btnNe.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNe.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNe.ForeColor = Global.System.Drawing.Color.White
			Me.btnNe.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNe.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNe.Image = CType(componentResourceManager.GetObject("btnNe.Image"), Global.System.Drawing.Image)
			Me.btnNe.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNe.Location = New Global.System.Drawing.Point(3, 6)
			Me.btnNe.Name = "btnNe"
			Me.btnNe.Size = New Global.System.Drawing.Size(121, 43)
			Me.btnNe.TabIndex = 519
			Me.btnNe.Text = "New"
			Me.btnNe.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNe.UseVisualStyleBackColor = False
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
			Me.btnSave.Location = New Global.System.Drawing.Point(3, 53)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(121, 43)
			Me.btnSave.TabIndex = 518
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.Color.YellowGreen
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column10, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(398, 262)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.Color.Orange
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle8
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle9
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(642, 221)
			Me.dgw.TabIndex = 2
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "Bank"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column10.HeaderText = "Branch Name"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Width = 114
			Me.Column3.HeaderText = "Address"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Contact No."
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "IFSC"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Branch Code"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-11, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1069, 32)
			Me.Panel2.TabIndex = 0
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(168, 5)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 437
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(79, 4)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 436
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(401, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(265, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Bank Accounts Registration"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1059, 680)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmBankAccountRegistration"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox3.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004A99 RID: 19097
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
