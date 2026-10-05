Namespace BillPoint
	' Token: 0x02000341 RID: 833
		Public Partial Class frmEmployeeRegistration
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C29A RID: 49818 RVA: 0x007BA0E0 File Offset: 0x007B82E0
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

		' Token: 0x0600C29B RID: 49819 RVA: 0x007BA130 File Offset: 0x007B8330
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEmployeeRegistration))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.chkActive = New Global.System.Windows.Forms.CheckBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.txtSalary = New Global.System.Windows.Forms.MaskedTextBox()
			Me.txtEmail = New Global.System.Windows.Forms.TextBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.txtEmployeeID = New Global.System.Windows.Forms.TextBox()
			Me.txtBasicWorkingTime = New Global.System.Windows.Forms.MaskedTextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtEmployeeName = New Global.System.Windows.Forms.TextBox()
			Me.cmbDesignation = New Global.System.Windows.Forms.ComboBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.dtpDateOfJoining = New Global.System.Windows.Forms.DateTimePicker()
			Me.cmbDepartment = New Global.System.Windows.Forms.ComboBox()
			Me.cmbBloodGroup = New Global.System.Windows.Forms.ComboBox()
			Me.cmbGender = New Global.System.Windows.Forms.ComboBox()
			Me.txtContactNo = New Global.System.Windows.Forms.MaskedTextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtEmpName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Dim label2 As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Dim label3 As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(196, 205)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label4"
			label.Size = New Global.System.Drawing.Size(30, 13)
			label.TabIndex = 274
			label.Text = "City :"
			label2.AutoSize = True
			label2.ForeColor = Global.System.Drawing.Color.Black
			label2.Location = New Global.System.Drawing.Point(196, 78)
			label2.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label2.Name = "Label3"
			label2.Size = New Global.System.Drawing.Size(48, 13)
			label2.TabIndex = 278
			label2.Text = "Gender :"
			label3.AutoSize = True
			label3.ForeColor = Global.System.Drawing.Color.Black
			label3.Location = New Global.System.Drawing.Point(83, 265)
			label3.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label3.Name = "Label7"
			label3.Size = New Global.System.Drawing.Size(23, 13)
			label3.TabIndex = 290
			label3.Text = "OR"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnGetData)
			Me.Panel1.Controls.Add(Me.btnUpdate)
			Me.Panel1.Controls.Add(Me.btnDelete)
			Me.Panel1.Controls.Add(Me.btnNew)
			Me.Panel1.Controls.Add(Me.btnSave)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(670, 497)
			Me.Panel1.TabIndex = 2
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(554, 235)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnGetData.TabIndex = 524
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(554, 142)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnUpdate.TabIndex = 523
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(554, 189)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnDelete.TabIndex = 522
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
			Me.btnNew.Location = New Global.System.Drawing.Point(554, 47)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnNew.TabIndex = 521
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
			Me.btnSave.Location = New Global.System.Drawing.Point(554, 94)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(111, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.Transparent
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.chkActive)
			Me.GroupBox1.Controls.Add(Me.lblUser)
			Me.GroupBox1.Controls.Add(Me.Picture)
			Me.GroupBox1.Controls.Add(Me.BRemove)
			Me.GroupBox1.Controls.Add(Me.txtID)
			Me.GroupBox1.Controls.Add(Me.Browse)
			Me.GroupBox1.Controls.Add(Me.txtSalary)
			Me.GroupBox1.Controls.Add(label3)
			Me.GroupBox1.Controls.Add(Me.txtEmail)
			Me.GroupBox1.Controls.Add(Me.BStartCapture)
			Me.GroupBox1.Controls.Add(Me.txtAddress)
			Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
			Me.GroupBox1.Controls.Add(Me.txtBasicWorkingTime)
			Me.GroupBox1.Controls.Add(Me.Label12)
			Me.GroupBox1.Controls.Add(Me.txtEmployeeName)
			Me.GroupBox1.Controls.Add(Me.cmbDesignation)
			Me.GroupBox1.Controls.Add(Me.Label11)
			Me.GroupBox1.Controls.Add(Me.dtpDateOfJoining)
			Me.GroupBox1.Controls.Add(Me.cmbDepartment)
			Me.GroupBox1.Controls.Add(Me.cmbBloodGroup)
			Me.GroupBox1.Controls.Add(Me.cmbGender)
			Me.GroupBox1.Controls.Add(Me.txtContactNo)
			Me.GroupBox1.Controls.Add(label2)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Controls.Add(Me.Label14)
			Me.GroupBox1.Controls.Add(Me.Label15)
			Me.GroupBox1.Controls.Add(Me.Label16)
			Me.GroupBox1.Controls.Add(label)
			Me.GroupBox1.Controls.Add(Me.txtCity)
			Me.GroupBox1.Controls.Add(Me.Label17)
			Me.GroupBox1.Controls.Add(Me.Label18)
			Me.GroupBox1.Controls.Add(Me.Label19)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 40)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(543, 444)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Employee Details"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(196, 415)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label8.TabIndex = 295
			Me.Label8.Text = "Status :"
			Me.chkActive.AutoSize = True
			Me.chkActive.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.chkActive.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkActive.Location = New Global.System.Drawing.Point(304, 415)
			Me.chkActive.Name = "chkActive"
			Me.chkActive.Size = New Global.System.Drawing.Size(56, 17)
			Me.chkActive.TabIndex = 13
			Me.chkActive.Text = "Active"
			Me.chkActive.UseVisualStyleBackColor = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(468, 25)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 293
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(4, 23)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(186, 193)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 291
			Me.Picture.TabStop = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Image = CType(componentResourceManager.GetObject("BRemove.Image"), Global.System.Drawing.Image)
			Me.BRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BRemove.Location = New Global.System.Drawing.Point(101, 224)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(89, 35)
			Me.BRemove.TabIndex = 14
			Me.BRemove.Text = "Remove"
			Me.BRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BRemove.UseVisualStyleBackColor = False
			Me.txtID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID.Location = New Global.System.Drawing.Point(385, 21)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(71, 20)
			Me.txtID.TabIndex = 292
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Browse.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Image = CType(componentResourceManager.GetObject("Browse.Image"), Global.System.Drawing.Image)
			Me.Browse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Browse.Location = New Global.System.Drawing.Point(4, 224)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(93, 35)
			Me.Browse.TabIndex = 13
			Me.Browse.Text = "Browse..."
			Me.Browse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Browse.UseVisualStyleBackColor = False
			Me.txtSalary.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSalary.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSalary.Location = New Global.System.Drawing.Point(305, 361)
			Me.txtSalary.Name = "txtSalary"
			Me.txtSalary.Size = New Global.System.Drawing.Size(106, 20)
			Me.txtSalary.TabIndex = 11
			Me.txtSalary.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtEmail.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmail.Location = New Global.System.Drawing.Point(305, 253)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.Size = New Global.System.Drawing.Size(220, 20)
			Me.txtEmail.TabIndex = 7
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Image = CType(componentResourceManager.GetObject("BStartCapture.Image"), Global.System.Drawing.Image)
			Me.BStartCapture.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BStartCapture.Location = New Global.System.Drawing.Point(33, 286)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(123, 38)
			Me.BStartCapture.TabIndex = 15
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(305, 131)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(220, 62)
			Me.txtAddress.TabIndex = 4
			Me.txtEmployeeID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmployeeID.Location = New Global.System.Drawing.Point(304, 21)
			Me.txtEmployeeID.Name = "txtEmployeeID"
			Me.txtEmployeeID.[ReadOnly] = True
			Me.txtEmployeeID.Size = New Global.System.Drawing.Size(75, 20)
			Me.txtEmployeeID.TabIndex = 0
			Me.txtEmployeeID.TabStop = False
			Me.txtBasicWorkingTime.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBasicWorkingTime.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBasicWorkingTime.Location = New Global.System.Drawing.Point(305, 387)
			Me.txtBasicWorkingTime.Mask = "00:00:00"
			Me.txtBasicWorkingTime.Name = "txtBasicWorkingTime"
			Me.txtBasicWorkingTime.Size = New Global.System.Drawing.Size(106, 20)
			Me.txtBasicWorkingTime.TabIndex = 12
			Me.txtBasicWorkingTime.ValidatingType = GetType(Global.System.DateTime)
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(196, 391)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label12.TabIndex = 28
			Me.Label12.Text = "Basic Working Time :"
			Me.txtEmployeeName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmployeeName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmployeeName.Location = New Global.System.Drawing.Point(305, 48)
			Me.txtEmployeeName.Name = "txtEmployeeName"
			Me.txtEmployeeName.Size = New Global.System.Drawing.Size(220, 20)
			Me.txtEmployeeName.TabIndex = 1
			Me.cmbDesignation.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbDesignation.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbDesignation.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbDesignation.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbDesignation.FormattingEnabled = True
			Me.cmbDesignation.Location = New Global.System.Drawing.Point(305, 308)
			Me.cmbDesignation.Name = "cmbDesignation"
			Me.cmbDesignation.Size = New Global.System.Drawing.Size(220, 21)
			Me.cmbDesignation.TabIndex = 9
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(196, 312)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label11.TabIndex = 27
			Me.Label11.Text = "Designation :"
			Me.dtpDateOfJoining.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateOfJoining.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateOfJoining.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateOfJoining.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateOfJoining.Location = New Global.System.Drawing.Point(305, 335)
			Me.dtpDateOfJoining.Name = "dtpDateOfJoining"
			Me.dtpDateOfJoining.Size = New Global.System.Drawing.Size(106, 20)
			Me.dtpDateOfJoining.TabIndex = 10
			Me.cmbDepartment.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbDepartment.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbDepartment.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbDepartment.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbDepartment.FormattingEnabled = True
			Me.cmbDepartment.Location = New Global.System.Drawing.Point(305, 281)
			Me.cmbDepartment.Name = "cmbDepartment"
			Me.cmbDepartment.Size = New Global.System.Drawing.Size(220, 21)
			Me.cmbDepartment.TabIndex = 8
			Me.cmbBloodGroup.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Append
			Me.cmbBloodGroup.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbBloodGroup.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBloodGroup.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBloodGroup.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbBloodGroup.FormattingEnabled = True
			Me.cmbBloodGroup.Items.AddRange(New Object() { "A+", "B+", "AB+", "O+", "A-", "B-", "AB-", "O-" })
			Me.cmbBloodGroup.Location = New Global.System.Drawing.Point(305, 104)
			Me.cmbBloodGroup.Name = "cmbBloodGroup"
			Me.cmbBloodGroup.Size = New Global.System.Drawing.Size(75, 21)
			Me.cmbBloodGroup.TabIndex = 3
			Me.cmbGender.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbGender.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbGender.FormattingEnabled = True
			Me.cmbGender.Items.AddRange(New Object() { "Male", "Female" })
			Me.cmbGender.Location = New Global.System.Drawing.Point(305, 74)
			Me.cmbGender.Name = "cmbGender"
			Me.cmbGender.Size = New Global.System.Drawing.Size(75, 21)
			Me.cmbGender.TabIndex = 2
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(305, 227)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(137, 20)
			Me.txtContactNo.TabIndex = 6
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(196, 257)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(42, 13)
			Me.Label10.TabIndex = 9
			Me.Label10.Text = "E-Mail :"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(196, 25)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label9.TabIndex = 8
			Me.Label9.Text = "Employee ID :"
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(196, 365)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label13.TabIndex = 7
			Me.Label13.Text = "Basic Salary :"
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(196, 339)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label14.TabIndex = 6
			Me.Label14.Text = "Date of Joining :"
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.Location = New Global.System.Drawing.Point(196, 285)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label15.TabIndex = 5
			Me.Label15.Text = "Department :"
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.Location = New Global.System.Drawing.Point(196, 108)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label16.TabIndex = 4
			Me.Label16.Text = "Blood Group :"
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Location = New Global.System.Drawing.Point(305, 201)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(220, 20)
			Me.txtCity.TabIndex = 5
			Me.Label17.AutoSize = True
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(196, 154)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label17.TabIndex = 3
			Me.Label17.Text = "Address :"
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(196, 231)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label18.TabIndex = 2
			Me.Label18.Text = "Contact No. :"
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(196, 52)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label19.TabIndex = 1
			Me.Label19.Text = "Employee Name :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Location = New Global.System.Drawing.Point(554, 250)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(103, 222)
			Me.Panel3.TabIndex = 1
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.txtEmpName)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(672, 33)
			Me.Panel2.TabIndex = 0
			Me.txtEmpName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmpName.Location = New Global.System.Drawing.Point(30, 7)
			Me.txtEmpName.Name = "txtEmpName"
			Me.txtEmpName.[ReadOnly] = True
			Me.txtEmpName.Size = New Global.System.Drawing.Size(30, 20)
			Me.txtEmpName.TabIndex = 2
			Me.txtEmpName.TabStop = False
			Me.txtEmpName.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(218, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(220, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Employee Registration"
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(670, 497)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmEmployeeRegistration"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004E02 RID: 19970
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
