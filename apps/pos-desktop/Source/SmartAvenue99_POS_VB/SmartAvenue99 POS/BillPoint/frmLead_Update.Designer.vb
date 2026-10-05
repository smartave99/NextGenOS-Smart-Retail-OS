Namespace BillPoint
	' Token: 0x020000C9 RID: 201
		Public Partial Class frmLead_Update
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002296 RID: 8854 RVA: 0x0015FE64 File Offset: 0x0015E064
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

		' Token: 0x06002297 RID: 8855 RVA: 0x0015FEB4 File Offset: 0x0015E0B4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLead_Update))
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnQuotation = New Global.GelButtons.GelButton()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cmbIntrestMode = New Global.System.Windows.Forms.ComboBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.cmbAlloted = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtLead_Id = New Global.System.Windows.Forms.TextBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.cmbProduct = New Global.System.Windows.Forms.ComboBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.cmbState = New Global.System.Windows.Forms.ComboBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtMobile = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.cmbCordinate_mode = New Global.System.Windows.Forms.ComboBox()
			Me.lblMobileno = New Global.System.Windows.Forms.Label()
			Me.lblState = New Global.System.Windows.Forms.Label()
			Me.lblFollowupID = New Global.System.Windows.Forms.Label()
			Me.lbl_Id = New Global.System.Windows.Forms.Label()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.txtCustcode = New Global.System.Windows.Forms.TextBox()
			Me.txtIDCus = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnQuotation)
			Me.Panel3.Controls.Add(Me.btnGetData)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(530, 8)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(149, 254)
			Me.Panel3.TabIndex = 1748
			Me.btnQuotation.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnQuotation.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnQuotation.FlatAppearance.BorderSize = 0
			Me.btnQuotation.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnQuotation.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnQuotation.ForeColor = Global.System.Drawing.Color.White
			Me.btnQuotation.GradientBottom = Global.System.Drawing.Color.FromArgb(128, 64, 0)
			Me.btnQuotation.GradientTop = Global.System.Drawing.Color.FromArgb(192, 192, 0)
			Me.btnQuotation.Image = CType(componentResourceManager.GetObject("btnQuotation.Image"), Global.System.Drawing.Image)
			Me.btnQuotation.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnQuotation.Location = New Global.System.Drawing.Point(4, 213)
			Me.btnQuotation.Name = "btnQuotation"
			Me.btnQuotation.Size = New Global.System.Drawing.Size(138, 36)
			Me.btnQuotation.TabIndex = 520
			Me.btnQuotation.Text = "Gen. Quotation"
			Me.btnQuotation.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnQuotation.UseVisualStyleBackColor = False
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(4, 172)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(138, 36)
			Me.btnGetData.TabIndex = 519
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(4, 88)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(138, 36)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(4, 130)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(138, 36)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(4, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(138, 36)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(4, 47)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(138, 36)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(75, 318)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label13.TabIndex = 1786
			Me.Label13.Text = "Alloted User :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(73, 210)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label4.TabIndex = 1780
			Me.Label4.Text = "Intrest Mode :"
			Me.cmbIntrestMode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbIntrestMode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbIntrestMode.FormattingEnabled = True
			Me.cmbIntrestMode.Items.AddRange(New Object() { "Low", "Medium", "High" })
			Me.cmbIntrestMode.Location = New Global.System.Drawing.Point(149, 207)
			Me.cmbIntrestMode.Name = "cmbIntrestMode"
			Me.cmbIntrestMode.Size = New Global.System.Drawing.Size(149, 21)
			Me.cmbIntrestMode.TabIndex = 1779
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(90, 262)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label10.TabIndex = 1778
			Me.Label10.Text = "Remarks :"
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(149, 262)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtRemarks.Size = New Global.System.Drawing.Size(351, 47)
			Me.txtRemarks.TabIndex = 1777
			Me.cmbAlloted.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAlloted.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAlloted.FormattingEnabled = True
			Me.cmbAlloted.Location = New Global.System.Drawing.Point(149, 315)
			Me.cmbAlloted.Name = "cmbAlloted"
			Me.cmbAlloted.Size = New Global.System.Drawing.Size(149, 21)
			Me.cmbAlloted.TabIndex = 1768
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(8, 59)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(137, 13)
			Me.Label2.TabIndex = 1770
			Me.Label2.Text = "Customer/Company Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(94, 32)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label3.TabIndex = 1763
			Me.Label3.Text = "Lead ID :"
			Me.txtLead_Id.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtLead_Id.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLead_Id.Location = New Global.System.Drawing.Point(150, 28)
			Me.txtLead_Id.Name = "txtLead_Id"
			Me.txtLead_Id.[ReadOnly] = True
			Me.txtLead_Id.Size = New Global.System.Drawing.Size(117, 21)
			Me.txtLead_Id.TabIndex = 1764
			Me.txtLead_Id.TabStop = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label11)
			Me.Panel4.Controls.Add(Me.cmbProduct)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.txtRemarks)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.cmbState)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtMobile)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.cmbCordinate_mode)
			Me.Panel4.Controls.Add(Me.lblMobileno)
			Me.Panel4.Controls.Add(Me.lblState)
			Me.Panel4.Controls.Add(Me.lblFollowupID)
			Me.Panel4.Controls.Add(Me.lbl_Id)
			Me.Panel4.Controls.Add(Me.txtCustomerName)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.cmbIntrestMode)
			Me.Panel4.Controls.Add(Me.cmbAlloted)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtLead_Id)
			Me.Panel4.Location = New Global.System.Drawing.Point(12, 8)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(516, 375)
			Me.Panel4.TabIndex = 1749
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(64, 237)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label11.TabIndex = 1803
			Me.Label11.Text = "Product Name :"
			Me.cmbProduct.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProduct.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbProduct.FormattingEnabled = True
			Me.cmbProduct.Items.AddRange(New Object() { "LOW", "MEDIUM", "HIGH" })
			Me.cmbProduct.Location = New Global.System.Drawing.Point(149, 234)
			Me.cmbProduct.Name = "cmbProduct"
			Me.cmbProduct.Size = New Global.System.Drawing.Size(351, 21)
			Me.cmbProduct.TabIndex = 1802
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(94, 166)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label9.TabIndex = 1801
			Me.Label9.Text = "Address :"
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(149, 163)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(351, 38)
			Me.txtAddress.TabIndex = 1800
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(106, 139)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label8.TabIndex = 1799
			Me.Label8.Text = "State :"
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "FOLLOW-UP", "FINISHED" })
			Me.cmbState.Location = New Global.System.Drawing.Point(149, 136)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(149, 21)
			Me.cmbState.TabIndex = 1798
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(81, 113)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(64, 13)
			Me.Label7.TabIndex = 1797
			Me.Label7.Text = "Mobile No. :"
			Me.txtMobile.Location = New Global.System.Drawing.Point(149, 110)
			Me.txtMobile.Name = "txtMobile"
			Me.txtMobile.Size = New Global.System.Drawing.Size(191, 20)
			Me.txtMobile.TabIndex = 1796
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(46, 87)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(99, 13)
			Me.Label6.TabIndex = 1795
			Me.Label6.Text = "Co-Ordinate Mode :"
			Me.cmbCordinate_mode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCordinate_mode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCordinate_mode.FormattingEnabled = True
			Me.cmbCordinate_mode.Items.AddRange(New Object() { "Owner", "Salesman", "Accountant", "Manager", "Clerk" })
			Me.cmbCordinate_mode.Location = New Global.System.Drawing.Point(149, 83)
			Me.cmbCordinate_mode.Name = "cmbCordinate_mode"
			Me.cmbCordinate_mode.Size = New Global.System.Drawing.Size(149, 21)
			Me.cmbCordinate_mode.TabIndex = 1794
			Me.lblMobileno.AutoSize = True
			Me.lblMobileno.Location = New Global.System.Drawing.Point(335, 9)
			Me.lblMobileno.Name = "lblMobileno"
			Me.lblMobileno.Size = New Global.System.Drawing.Size(60, 13)
			Me.lblMobileno.TabIndex = 1793
			Me.lblMobileno.Text = "lblMobileno"
			Me.lblMobileno.Visible = False
			Me.lblState.AutoSize = True
			Me.lblState.Location = New Global.System.Drawing.Point(430, 15)
			Me.lblState.Name = "lblState"
			Me.lblState.Size = New Global.System.Drawing.Size(42, 13)
			Me.lblState.TabIndex = 1792
			Me.lblState.Text = "lblState"
			Me.lblState.Visible = False
			Me.lblFollowupID.AutoSize = True
			Me.lblFollowupID.Location = New Global.System.Drawing.Point(430, 28)
			Me.lblFollowupID.Name = "lblFollowupID"
			Me.lblFollowupID.Size = New Global.System.Drawing.Size(70, 13)
			Me.lblFollowupID.TabIndex = 1789
			Me.lblFollowupID.Text = "lblFollowupID"
			Me.lblFollowupID.Visible = False
			Me.lbl_Id.AutoSize = True
			Me.lbl_Id.Location = New Global.System.Drawing.Point(148, 9)
			Me.lbl_Id.Name = "lbl_Id"
			Me.lbl_Id.Size = New Global.System.Drawing.Size(32, 13)
			Me.lbl_Id.TabIndex = 1788
			Me.lbl_Id.Text = "lbl_Id"
			Me.lbl_Id.Visible = False
			Me.txtCustomerName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(149, 56)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(351, 21)
			Me.txtCustomerName.TabIndex = 1787
			Me.txtCustomerName.TabStop = False
			Me.pbgiftqr.Image = Global.BillPoint.My.Resources.Resources._12
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(574, 284)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(46, 49)
			Me.pbgiftqr.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.pbgiftqr.TabIndex = 1817
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.pbgiftqr)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Location = New Global.System.Drawing.Point(6, 51)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(696, 396)
			Me.Panel1.TabIndex = 4
			Me.txtCustcode.Location = New Global.System.Drawing.Point(598, 6)
			Me.txtCustcode.Name = "txtCustcode"
			Me.txtCustcode.Size = New Global.System.Drawing.Size(81, 20)
			Me.txtCustcode.TabIndex = 1815
			Me.txtCustcode.Visible = False
			Me.txtIDCus.Location = New Global.System.Drawing.Point(511, 9)
			Me.txtIDCus.Name = "txtIDCus"
			Me.txtIDCus.Size = New Global.System.Drawing.Size(81, 20)
			Me.txtIDCus.TabIndex = 1816
			Me.txtIDCus.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(24, 12)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(268, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(128, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Lead Update"
			Me.Panel2.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.txtCustcode)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtIDCus)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(6, 6)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(696, 39)
			Me.Panel2.TabIndex = 3
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(419, 16)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1863
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(716, 459)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Name = "frmLead_Update"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Lead Update"
			Me.Panel3.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000E20 RID: 3616
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
