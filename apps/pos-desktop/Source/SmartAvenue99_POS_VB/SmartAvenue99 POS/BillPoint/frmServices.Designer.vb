Namespace BillPoint
	' Token: 0x020005D2 RID: 1490
		Public Partial Class frmServices
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060122F2 RID: 74482 RVA: 0x00A75450 File Offset: 0x00A73650
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

		' Token: 0x060122F3 RID: 74483 RVA: 0x00A754A0 File Offset: 0x00A736A0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmServices))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.btnSelect = New Global.System.Windows.Forms.Button()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.txtProblemDescription = New Global.System.Windows.Forms.TextBox()
			Me.dtpEstimatedRepairDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtItemsDescription = New Global.System.Windows.Forms.TextBox()
			Me.cmbStatus = New Global.System.Windows.Forms.ComboBox()
			Me.txtUpfront = New Global.System.Windows.Forms.TextBox()
			Me.txtChargesQuote = New Global.System.Windows.Forms.TextBox()
			Me.cmbServiceType = New Global.System.Windows.Forms.ComboBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.dtpServiceCreationDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtServiceCode = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.Button35 = New Global.System.Windows.Forms.Button()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtcompname = New Global.System.Windows.Forms.TextBox()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.txtCID = New Global.System.Windows.Forms.TextBox()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(26, 19)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label5"
			label.Size = New Global.System.Drawing.Size(77, 13)
			label.TabIndex = 268
			label.Text = "Service Code :"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1130, 480)
			Me.Panel1.TabIndex = 2
			Me.GroupBox4.Controls.Add(Me.Label8)
			Me.GroupBox4.Controls.Add(Me.txtRemarks)
			Me.GroupBox4.Controls.Add(Me.GroupBox3)
			Me.GroupBox4.Controls.Add(Me.txtProblemDescription)
			Me.GroupBox4.Controls.Add(Me.dtpEstimatedRepairDate)
			Me.GroupBox4.Controls.Add(Me.txtItemsDescription)
			Me.GroupBox4.Controls.Add(Me.cmbStatus)
			Me.GroupBox4.Controls.Add(Me.txtUpfront)
			Me.GroupBox4.Controls.Add(Me.txtChargesQuote)
			Me.GroupBox4.Controls.Add(Me.cmbServiceType)
			Me.GroupBox4.Controls.Add(Me.Label13)
			Me.GroupBox4.Controls.Add(Me.Label7)
			Me.GroupBox4.Controls.Add(Me.Label12)
			Me.GroupBox4.Controls.Add(Me.Label11)
			Me.GroupBox4.Controls.Add(Me.Label10)
			Me.GroupBox4.Controls.Add(Me.Label9)
			Me.GroupBox4.Controls.Add(Me.Label6)
			Me.GroupBox4.Controls.Add(Me.dtpServiceCreationDate)
			Me.GroupBox4.Controls.Add(Me.txtServiceCode)
			Me.GroupBox4.Controls.Add(Me.Label4)
			Me.GroupBox4.Controls.Add(label)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(9, 43)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(973, 429)
			Me.GroupBox4.TabIndex = 0
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Service Information"
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(26, 303)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label8.TabIndex = 85
			Me.Label8.Text = "Remarks :"
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(28, 319)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtRemarks.Size = New Global.System.Drawing.Size(308, 91)
			Me.txtRemarks.TabIndex = 10
			Me.GroupBox3.Controls.Add(Me.Label14)
			Me.GroupBox3.Controls.Add(Me.Label2)
			Me.GroupBox3.Controls.Add(Me.txtContactNo)
			Me.GroupBox3.Controls.Add(Me.btnSelect)
			Me.GroupBox3.Controls.Add(Me.Label3)
			Me.GroupBox3.Controls.Add(Me.txtCustomerID)
			Me.GroupBox3.Controls.Add(Me.txtCustomerName)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(28, 201)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(308, 99)
			Me.GroupBox3.TabIndex = 9
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Customer Details"
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(6, 74)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label14.TabIndex = 8
			Me.Label14.Text = "Contact No :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(6, 48)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Customer Name :"
			Me.txtContactNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(99, 74)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(203, 21)
			Me.txtContactNo.TabIndex = 319
			Me.txtContactNo.TabStop = False
			Me.btnSelect.BackColor = Global.System.Drawing.Color.Lime
			Me.btnSelect.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelect.Location = New Global.System.Drawing.Point(273, 21)
			Me.btnSelect.Name = "btnSelect"
			Me.btnSelect.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelect.TabIndex = 2
			Me.btnSelect.Text = "..."
			Me.btnSelect.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(6, 21)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Customer ID :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(99, 21)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(147, 21)
			Me.txtCustomerID.TabIndex = 0
			Me.txtCustomerID.TabStop = False
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(99, 48)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.[ReadOnly] = True
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(203, 20)
			Me.txtCustomerName.TabIndex = 1
			Me.txtCustomerName.TabStop = False
			Me.txtProblemDescription.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtProblemDescription.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProblemDescription.Location = New Global.System.Drawing.Point(453, 203)
			Me.txtProblemDescription.Multiline = True
			Me.txtProblemDescription.Name = "txtProblemDescription"
			Me.txtProblemDescription.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtProblemDescription.Size = New Global.System.Drawing.Size(492, 210)
			Me.txtProblemDescription.TabIndex = 4
			Me.dtpEstimatedRepairDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpEstimatedRepairDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpEstimatedRepairDate.Location = New Global.System.Drawing.Point(163, 149)
			Me.dtpEstimatedRepairDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpEstimatedRepairDate.Name = "dtpEstimatedRepairDate"
			Me.dtpEstimatedRepairDate.Size = New Global.System.Drawing.Size(111, 20)
			Me.dtpEstimatedRepairDate.TabIndex = 7
			Me.txtItemsDescription.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtItemsDescription.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtItemsDescription.Location = New Global.System.Drawing.Point(453, 19)
			Me.txtItemsDescription.Multiline = True
			Me.txtItemsDescription.Name = "txtItemsDescription"
			Me.txtItemsDescription.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtItemsDescription.Size = New Global.System.Drawing.Size(492, 174)
			Me.txtItemsDescription.TabIndex = 3
			Me.cmbStatus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbStatus.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbStatus.FormattingEnabled = True
			Me.cmbStatus.Items.AddRange(New Object() { "Resolved", "Under Processing", "Unresolved" })
			Me.cmbStatus.Location = New Global.System.Drawing.Point(163, 174)
			Me.cmbStatus.Name = "cmbStatus"
			Me.cmbStatus.Size = New Global.System.Drawing.Size(111, 21)
			Me.cmbStatus.TabIndex = 8
			Me.txtUpfront.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUpfront.Location = New Global.System.Drawing.Point(163, 124)
			Me.txtUpfront.Name = "txtUpfront"
			Me.txtUpfront.Size = New Global.System.Drawing.Size(111, 20)
			Me.txtUpfront.TabIndex = 6
			Me.txtUpfront.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtChargesQuote.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtChargesQuote.Location = New Global.System.Drawing.Point(163, 98)
			Me.txtChargesQuote.Name = "txtChargesQuote"
			Me.txtChargesQuote.Size = New Global.System.Drawing.Size(111, 20)
			Me.txtChargesQuote.TabIndex = 5
			Me.txtChargesQuote.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.cmbServiceType.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbServiceType.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbServiceType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbServiceType.FormattingEnabled = True
			Me.cmbServiceType.Location = New Global.System.Drawing.Point(163, 71)
			Me.cmbServiceType.Name = "cmbServiceType"
			Me.cmbServiceType.Size = New Global.System.Drawing.Size(111, 21)
			Me.cmbServiceType.TabIndex = 2
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(26, 174)
			Me.Label13.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label13.TabIndex = 342
			Me.Label13.Text = "Status :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(341, 19)
			Me.Label7.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(94, 13)
			Me.Label7.TabIndex = 337
			Me.Label7.Text = "Items Description :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(26, 149)
			Me.Label12.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(119, 13)
			Me.Label12.TabIndex = 341
			Me.Label12.Text = "Estimated Repair Date :"
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(26, 124)
			Me.Label11.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(48, 13)
			Me.Label11.TabIndex = 340
			Me.Label11.Text = "Upfront :"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(26, 98)
			Me.Label10.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label10.TabIndex = 339
			Me.Label10.Text = "Charges Quote :"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(341, 203)
			Me.Label9.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(112, 13)
			Me.Label9.TabIndex = 338
			Me.Label9.Text = "Problems Description :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(26, 71)
			Me.Label6.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label6.TabIndex = 336
			Me.Label6.Text = "Service Type :"
			Me.dtpServiceCreationDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpServiceCreationDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpServiceCreationDate.Location = New Global.System.Drawing.Point(163, 45)
			Me.dtpServiceCreationDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpServiceCreationDate.Name = "dtpServiceCreationDate"
			Me.dtpServiceCreationDate.Size = New Global.System.Drawing.Size(111, 20)
			Me.dtpServiceCreationDate.TabIndex = 1
			Me.txtServiceCode.Location = New Global.System.Drawing.Point(163, 19)
			Me.txtServiceCode.Name = "txtServiceCode"
			Me.txtServiceCode.[ReadOnly] = True
			Me.txtServiceCode.Size = New Global.System.Drawing.Size(173, 20)
			Me.txtServiceCode.TabIndex = 0
			Me.txtServiceCode.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(26, 45)
			Me.Label4.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(117, 13)
			Me.Label4.TabIndex = 335
			Me.Label4.Text = "Service Creation Date :"
			Me.Panel3.Controls.Add(Me.btnGetData)
			Me.Panel3.Controls.Add(Me.btnPrint)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(986, 77)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(131, 293)
			Me.Panel3.TabIndex = 3
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(5, 191)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnGetData.TabIndex = 525
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnPrint.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnPrint.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnPrint.FlatAppearance.BorderSize = 0
			Me.btnPrint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnPrint.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPrint.ForeColor = Global.System.Drawing.Color.White
			Me.btnPrint.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnPrint.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnPrint.Image = CType(componentResourceManager.GetObject("btnPrint.Image"), Global.System.Drawing.Image)
			Me.btnPrint.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnPrint.Location = New Global.System.Drawing.Point(5, 238)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnPrint.TabIndex = 524
			Me.btnPrint.Text = "Print"
			Me.btnPrint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnPrint.UseVisualStyleBackColor = False
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(5, 98)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(123, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(5, 145)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(123, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(5, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(123, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(5, 50)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.F2)
			Me.Panel2.Controls.Add(Me.F1)
			Me.Panel2.Controls.Add(Me.Button35)
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.txtcompname)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox9)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.txtCID)
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1130, 34)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(488, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(90, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Services"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(520, 25)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1774
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.F2.Location = New Global.System.Drawing.Point(418, 21)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1769
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(383, 21)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1768
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.Button35.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button35.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button35.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button35.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button35.ForeColor = Global.System.Drawing.Color.White
			Me.Button35.Image = CType(componentResourceManager.GetObject("Button35.Image"), Global.System.Drawing.Image)
			Me.Button35.Location = New Global.System.Drawing.Point(1098, 1)
			Me.Button35.Name = "Button35"
			Me.Button35.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button35.TabIndex = 1759
			Me.Button35.TabStop = False
			Me.Button35.UseVisualStyleBackColor = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(770, 10)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 431
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(656, 9)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 430
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.txtcompname.Location = New Global.System.Drawing.Point(935, 24)
			Me.txtcompname.Name = "txtcompname"
			Me.txtcompname.[ReadOnly] = True
			Me.txtcompname.Size = New Global.System.Drawing.Size(20, 20)
			Me.txtcompname.TabIndex = 418
			Me.txtcompname.TabStop = False
			Me.txtcompname.Visible = False
			Me.TextBox10.Location = New Global.System.Drawing.Point(807, 23)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(20, 20)
			Me.TextBox10.TabIndex = 417
			Me.TextBox10.TabStop = False
			Me.TextBox10.Visible = False
			Me.TextBox9.Location = New Global.System.Drawing.Point(829, 24)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox9.TabIndex = 416
			Me.TextBox9.TabStop = False
			Me.TextBox9.Visible = False
			Me.txtID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID.Location = New Global.System.Drawing.Point(285, 40)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(70, 21)
			Me.txtID.TabIndex = 12
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.txtCID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCID.Location = New Global.System.Drawing.Point(285, 13)
			Me.txtCID.Name = "txtCID"
			Me.txtCID.[ReadOnly] = True
			Me.txtCID.Size = New Global.System.Drawing.Size(70, 21)
			Me.txtCID.TabIndex = 7
			Me.txtCID.TabStop = False
			Me.txtCID.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(206, 18)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(56, 13)
			Me.lblUserType.TabIndex = 315
			Me.lblUserType.Text = "User Type"
			Me.lblUserType.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(206, 31)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(29, 13)
			Me.lblUser.TabIndex = 313
			Me.lblUser.Text = "User"
			Me.lblUser.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1130, 480)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmServices"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006D41 RID: 27969
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
