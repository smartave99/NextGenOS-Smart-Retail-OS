Namespace BillPoint
	' Token: 0x020005FF RID: 1535
		Public Partial Class frmBranchAdmin
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012ADC RID: 76508 RVA: 0x00ABA538 File Offset: 0x00AB8738
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

		' Token: 0x06012ADD RID: 76509 RVA: 0x00ABA588 File Offset: 0x00AB8788
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBranchAdmin))
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
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.txtBAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtBMobile = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtBName = New Global.System.Windows.Forms.TextBox()
			Me.txtAdminCode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.btnprint = New Global.GelButtons.GelButton()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.cmbSearchType = New Global.System.Windows.Forms.ComboBox()
			Me.txtSearchData = New Global.System.Windows.Forms.TextBox()
			Me.txtBranchData = New Global.System.Windows.Forms.TextBox()
			Me.cmbBranch = New Global.System.Windows.Forms.ComboBox()
			Me.btnBranch = New Global.GelButtons.GelButton()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.cone = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ctwo = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cthree = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cfour = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cfive = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.csix = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cseven = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ceight = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cnine = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtBranchAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtBranchState = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtAdminCodeBranch = New Global.System.Windows.Forms.TextBox()
			Me.txtBranchCode = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			Me.Panel3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUserType.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUserType.Location = New Global.System.Drawing.Point(252, 9)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(72, 15)
			Me.lblUserType.TabIndex = 48
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUser.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUser.Location = New Global.System.Drawing.Point(190, 9)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(46, 15)
			Me.lblUser.TabIndex = 47
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.Controls.Add(Me.btnUpdate)
			Me.Panel1.Controls.Add(Me.btnReset)
			Me.Panel1.Controls.Add(Me.btnSave)
			Me.Panel1.Controls.Add(Me.txtBAddress)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.txtBMobile)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.txtBName)
			Me.Panel1.Controls.Add(Me.txtAdminCode)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(4, 40)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(466, 155)
			Me.Panel1.TabIndex = 50
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.Turquoise
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.DarkSlateGray
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(348, 105)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(103, 43)
			Me.btnUpdate.TabIndex = 520
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnReset.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(348, 56)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(103, 43)
			Me.btnReset.TabIndex = 519
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
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
			Me.btnSave.Location = New Global.System.Drawing.Point(348, 8)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(103, 43)
			Me.btnSave.TabIndex = 517
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.txtBAddress.Location = New Global.System.Drawing.Point(127, 87)
			Me.txtBAddress.Name = "txtBAddress"
			Me.txtBAddress.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtBAddress.TabIndex = 56
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(9, 90)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(117, 13)
			Me.Label3.TabIndex = 55
			Me.Label3.Text = "Admin Branch Address:"
			Me.txtBMobile.Location = New Global.System.Drawing.Point(127, 61)
			Me.txtBMobile.Name = "txtBMobile"
			Me.txtBMobile.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtBMobile.TabIndex = 54
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(9, 64)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(113, 13)
			Me.Label4.TabIndex = 53
			Me.Label4.Text = "Admin Branch Mobile :"
			Me.txtBName.Location = New Global.System.Drawing.Point(127, 35)
			Me.txtBName.Name = "txtBName"
			Me.txtBName.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtBName.TabIndex = 52
			Me.txtAdminCode.Location = New Global.System.Drawing.Point(127, 12)
			Me.txtAdminCode.Name = "txtAdminCode"
			Me.txtAdminCode.Size = New Global.System.Drawing.Size(179, 20)
			Me.txtAdminCode.TabIndex = 50
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(9, 38)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(110, 13)
			Me.Label2.TabIndex = 51
			Me.Label2.Text = "Admin Branch Name :"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(9, 12)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label1.TabIndex = 49
			Me.Label1.Text = "Admin Branch Code :"
			Me.btnprint.Anchor = Global.System.Windows.Forms.AnchorStyles.Top
			Me.btnprint.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnprint.FlatAppearance.BorderSize = 0
			Me.btnprint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnprint.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnprint.ForeColor = Global.System.Drawing.Color.White
			Me.btnprint.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnprint.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnprint.Image = CType(componentResourceManager.GetObject("btnprint.Image"), Global.System.Drawing.Image)
			Me.btnprint.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnprint.Location = New Global.System.Drawing.Point(348, 7)
			Me.btnprint.Name = "btnprint"
			Me.btnprint.Size = New Global.System.Drawing.Size(103, 42)
			Me.btnprint.TabIndex = 518
			Me.btnprint.Text = "Search"
			Me.btnprint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnprint.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column4, Me.Column3 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(4, 262)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
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
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(426, 353)
			Me.dgw.TabIndex = 51
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "Admin Branch Code"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Admin Branch Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column4.HeaderText = "Admin Branch Address"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column3.HeaderText = "Admin Branch Mobile "
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(5, 7)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label5.TabIndex = 1689
			Me.Label5.Text = "Search Type :"
			Me.cmbSearchType.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchType.FormattingEnabled = True
			Me.cmbSearchType.Items.AddRange(New Object() { "Admin Branch Code", "Admin Branch Name", "Admin Branch Mobile", "Admin Branch Address" })
			Me.cmbSearchType.Location = New Global.System.Drawing.Point(8, 24)
			Me.cmbSearchType.Name = "cmbSearchType"
			Me.cmbSearchType.Size = New Global.System.Drawing.Size(132, 21)
			Me.cmbSearchType.TabIndex = 1688
			Me.txtSearchData.Location = New Global.System.Drawing.Point(147, 24)
			Me.txtSearchData.Name = "txtSearchData"
			Me.txtSearchData.Size = New Global.System.Drawing.Size(178, 20)
			Me.txtSearchData.TabIndex = 1690
			Me.txtBranchData.Location = New Global.System.Drawing.Point(632, 21)
			Me.txtBranchData.Name = "txtBranchData"
			Me.txtBranchData.Size = New Global.System.Drawing.Size(178, 20)
			Me.txtBranchData.TabIndex = 1694
			Me.cmbBranch.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbBranch.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranch.FormattingEnabled = True
			Me.cmbBranch.Items.AddRange(New Object() { "Branch Code", "Admin Code" })
			Me.cmbBranch.Location = New Global.System.Drawing.Point(493, 21)
			Me.cmbBranch.Name = "cmbBranch"
			Me.cmbBranch.Size = New Global.System.Drawing.Size(132, 21)
			Me.cmbBranch.TabIndex = 1693
			Me.btnBranch.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom
			Me.btnBranch.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnBranch.FlatAppearance.BorderSize = 0
			Me.btnBranch.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBranch.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBranch.ForeColor = Global.System.Drawing.Color.White
			Me.btnBranch.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnBranch.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnBranch.Image = CType(componentResourceManager.GetObject("btnBranch.Image"), Global.System.Drawing.Image)
			Me.btnBranch.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBranch.Location = New Global.System.Drawing.Point(826, 10)
			Me.btnBranch.Name = "btnBranch"
			Me.btnBranch.Size = New Global.System.Drawing.Size(103, 42)
			Me.btnBranch.TabIndex = 1692
			Me.btnBranch.Text = "Search"
			Me.btnBranch.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBranch.UseVisualStyleBackColor = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7
			Me.DataGridView1.ColumnHeadersHeight = 40
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.cone, Me.ctwo, Me.cthree, Me.cfour, Me.cfive, Me.csix, Me.cseven, Me.ceight, Me.cnine })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(492, 262)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle10.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle10.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle10.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridView1.RowTemplate.Height = 20
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(780, 353)
			Me.DataGridView1.TabIndex = 1691
			Me.DataGridView1.TabStop = False
			Me.cone.HeaderText = "Branch Code"
			Me.cone.Name = "cone"
			Me.cone.[ReadOnly] = True
			Me.ctwo.HeaderText = "Admin Code"
			Me.ctwo.Name = "ctwo"
			Me.ctwo.[ReadOnly] = True
			Me.cthree.HeaderText = "Branch Name"
			Me.cthree.Name = "cthree"
			Me.cthree.[ReadOnly] = True
			Me.cthree.Width = 200
			Me.cfour.HeaderText = "Branch State"
			Me.cfour.Name = "cfour"
			Me.cfour.[ReadOnly] = True
			Me.cfour.Width = 120
			Me.cfive.HeaderText = "Branch Address"
			Me.cfive.Name = "cfive"
			Me.cfive.[ReadOnly] = True
			Me.csix.HeaderText = "Branch Mobile #"
			Me.csix.Name = "csix"
			Me.csix.[ReadOnly] = True
			Me.cseven.HeaderText = "Branch City"
			Me.cseven.Name = "cseven"
			Me.cseven.[ReadOnly] = True
			Me.ceight.HeaderText = "Branch Gst"
			Me.ceight.Name = "ceight"
			Me.ceight.[ReadOnly] = True
			Me.ceight.Width = 150
			Me.cnine.HeaderText = "Branch Status"
			Me.cnine.Name = "cnine"
			Me.cnine.[ReadOnly] = True
			Me.Panel2.Controls.Add(Me.btnprint)
			Me.Panel2.Controls.Add(Me.txtBranchData)
			Me.Panel2.Controls.Add(Me.cmbSearchType)
			Me.Panel2.Controls.Add(Me.cmbBranch)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Controls.Add(Me.btnBranch)
			Me.Panel2.Controls.Add(Me.txtSearchData)
			Me.Panel2.Location = New Global.System.Drawing.Point(4, 201)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1401, 55)
			Me.Panel2.TabIndex = 1695
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(441, 8)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(103, 43)
			Me.GelButton1.TabIndex = 1695
			Me.GelButton1.Text = "Delete"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Panel3.BackColor = Global.System.Drawing.Color.White
			Me.Panel3.Controls.Add(Me.txtBranchAddress)
			Me.Panel3.Controls.Add(Me.Label10)
			Me.Panel3.Controls.Add(Me.GelButton1)
			Me.Panel3.Controls.Add(Me.txtBranchState)
			Me.Panel3.Controls.Add(Me.Label6)
			Me.Panel3.Controls.Add(Me.txtBranchName)
			Me.Panel3.Controls.Add(Me.Label7)
			Me.Panel3.Controls.Add(Me.txtAdminCodeBranch)
			Me.Panel3.Controls.Add(Me.txtBranchCode)
			Me.Panel3.Controls.Add(Me.Label8)
			Me.Panel3.Controls.Add(Me.Label9)
			Me.Panel3.Location = New Global.System.Drawing.Point(497, 40)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(547, 155)
			Me.Panel3.TabIndex = 1696
			Me.txtBranchAddress.Location = New Global.System.Drawing.Point(127, 113)
			Me.txtBranchAddress.Multiline = True
			Me.txtBranchAddress.Name = "txtBranchAddress"
			Me.txtBranchAddress.[ReadOnly] = True
			Me.txtBranchAddress.Size = New Global.System.Drawing.Size(292, 35)
			Me.txtBranchAddress.TabIndex = 1697
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(9, 116)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label10.TabIndex = 1696
			Me.Label10.Text = "Branch Address :"
			Me.txtBranchState.Location = New Global.System.Drawing.Point(127, 87)
			Me.txtBranchState.Name = "txtBranchState"
			Me.txtBranchState.[ReadOnly] = True
			Me.txtBranchState.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtBranchState.TabIndex = 56
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(9, 90)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label6.TabIndex = 55
			Me.Label6.Text = "Branch State:"
			Me.txtBranchName.Location = New Global.System.Drawing.Point(127, 61)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.[ReadOnly] = True
			Me.txtBranchName.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtBranchName.TabIndex = 54
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(9, 64)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label7.TabIndex = 53
			Me.Label7.Text = "Branch Name :"
			Me.txtAdminCodeBranch.Location = New Global.System.Drawing.Point(127, 35)
			Me.txtAdminCodeBranch.Name = "txtAdminCodeBranch"
			Me.txtAdminCodeBranch.[ReadOnly] = True
			Me.txtAdminCodeBranch.Size = New Global.System.Drawing.Size(206, 20)
			Me.txtAdminCodeBranch.TabIndex = 52
			Me.txtBranchCode.Location = New Global.System.Drawing.Point(127, 12)
			Me.txtBranchCode.Name = "txtBranchCode"
			Me.txtBranchCode.[ReadOnly] = True
			Me.txtBranchCode.Size = New Global.System.Drawing.Size(292, 20)
			Me.txtBranchCode.TabIndex = 50
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(9, 38)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label8.TabIndex = 51
			Me.Label8.Text = "Admin Code :"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(9, 12)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label9.TabIndex = 49
			Me.Label9.Text = "Branch Code :"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.SystemColors.Highlight
			Me.Label11.Location = New Global.System.Drawing.Point(12, 11)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(177, 29)
			Me.Label11.TabIndex = 1695
			Me.Label11.Text = "ADMIN MODE"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.ForeColor = Global.System.Drawing.SystemColors.Highlight
			Me.Label12.Location = New Global.System.Drawing.Point(492, 8)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(202, 29)
			Me.Label12.TabIndex = 1697
			Me.Label12.Text = "BRANCH MODE"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 653)
			MyBase.Controls.Add(Me.Label12)
			MyBase.Controls.Add(Me.Label11)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Name = "frmBranchAdmin"
			Me.Text = "frmBranchAdmin"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04007062 RID: 28770
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
