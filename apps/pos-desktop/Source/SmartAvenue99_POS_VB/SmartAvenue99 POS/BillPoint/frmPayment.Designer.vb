Namespace BillPoint
	' Token: 0x020005B5 RID: 1461
		Public Partial Class frmPayment
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011CC9 RID: 72905 RVA: 0x00A43F40 File Offset: 0x00A42140
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

		' Token: 0x06011CCA RID: 72906 RVA: 0x00A43F90 File Offset: 0x00A42190
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPayment))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.txtTempAmt = New Global.System.Windows.Forms.TextBox()
			Me.gbPartyInfo = New Global.System.Windows.Forms.GroupBox()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.btnSelection = New Global.System.Windows.Forms.Button()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtSupplierID = New Global.System.Windows.Forms.TextBox()
			Me.lblBalance = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label26 = New Global.System.Windows.Forms.Label()
			Me.Label30 = New Global.System.Windows.Forms.Label()
			Me.Label36 = New Global.System.Windows.Forms.Label()
			Me.txtRemarks = New Global.System.Windows.Forms.RichTextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label74 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.txtPaymentModeDetails = New Global.System.Windows.Forms.RichTextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.cmbPaymentMode = New Global.System.Windows.Forms.ComboBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.dtpTranactionDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtTransactionNo = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtTransactionAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.Button35 = New Global.System.Windows.Forms.Button()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtSuffix = New Global.System.Windows.Forms.TextBox()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtInvCode1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtSup_ID = New Global.System.Windows.Forms.TextBox()
			Me.txtT_ID = New Global.System.Windows.Forms.TextBox()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.cmbSupplierName = New Global.System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.gbPartyInfo.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.txtTempAmt)
			Me.Panel1.Controls.Add(Me.gbPartyInfo)
			Me.Panel1.Controls.Add(Me.txtRemarks)
			Me.Panel1.Controls.Add(Me.Label12)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(9, 9)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(860, 540)
			Me.Panel1.TabIndex = 2
			Me.Panel4.Controls.Add(Me.btnGetData)
			Me.Panel4.Controls.Add(Me.btnUpdate)
			Me.Panel4.Controls.Add(Me.btnDelete)
			Me.Panel4.Controls.Add(Me.btnNew)
			Me.Panel4.Controls.Add(Me.btnSave)
			Me.Panel4.Location = New Global.System.Drawing.Point(686, 51)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(169, 241)
			Me.Panel4.TabIndex = 1743
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(7, 193)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(157, 43)
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(7, 100)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(157, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(7, 147)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(157, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(7, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(157, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(7, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnSave.TabIndex = 514
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.txtTempAmt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTempAmt.Location = New Global.System.Drawing.Point(438, 261)
			Me.txtTempAmt.Name = "txtTempAmt"
			Me.txtTempAmt.[ReadOnly] = True
			Me.txtTempAmt.Size = New Global.System.Drawing.Size(88, 20)
			Me.txtTempAmt.TabIndex = 11
			Me.txtTempAmt.TabStop = False
			Me.txtTempAmt.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtTempAmt.Visible = False
			Me.gbPartyInfo.Controls.Add(Me.cmbSupplierName)
			Me.gbPartyInfo.Controls.Add(Me.btnNext)
			Me.gbPartyInfo.Controls.Add(Me.btnFirst)
			Me.gbPartyInfo.Controls.Add(Me.txtPrev)
			Me.gbPartyInfo.Controls.Add(Me.btnSelection)
			Me.gbPartyInfo.Controls.Add(Me.btnLast)
			Me.gbPartyInfo.Controls.Add(Me.Label10)
			Me.gbPartyInfo.Controls.Add(Me.txtSupplierID)
			Me.gbPartyInfo.Controls.Add(Me.lblBalance)
			Me.gbPartyInfo.Controls.Add(Me.Label11)
			Me.gbPartyInfo.Controls.Add(Me.txtContactNo)
			Me.gbPartyInfo.Controls.Add(Me.txtCity)
			Me.gbPartyInfo.Controls.Add(Me.txtAddress)
			Me.gbPartyInfo.Controls.Add(Me.Label26)
			Me.gbPartyInfo.Controls.Add(Me.Label30)
			Me.gbPartyInfo.Controls.Add(Me.Label36)
			Me.gbPartyInfo.Location = New Global.System.Drawing.Point(9, 51)
			Me.gbPartyInfo.Name = "gbPartyInfo"
			Me.gbPartyInfo.Size = New Global.System.Drawing.Size(423, 196)
			Me.gbPartyInfo.TabIndex = 0
			Me.gbPartyInfo.TabStop = False
			Me.gbPartyInfo.Text = "Supplier Info"
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(330, 10)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1734
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(393, 10)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1737
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(362, 10)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1735
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.btnSelection.BackColor = Global.System.Drawing.Color.Lime
			Me.btnSelection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelection.Location = New Global.System.Drawing.Point(247, 25)
			Me.btnSelection.Name = "btnSelection"
			Me.btnSelection.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelection.TabIndex = 0
			Me.btnSelection.Text = "..."
			Me.btnSelection.UseVisualStyleBackColor = False
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(297, 10)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1736
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(11, 53)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label10.TabIndex = 36
			Me.Label10.Text = "Supplier Name :"
			Me.txtSupplierID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSupplierID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSupplierID.Location = New Global.System.Drawing.Point(95, 25)
			Me.txtSupplierID.Name = "txtSupplierID"
			Me.txtSupplierID.[ReadOnly] = True
			Me.txtSupplierID.Size = New Global.System.Drawing.Size(147, 21)
			Me.txtSupplierID.TabIndex = 0
			Me.txtSupplierID.TabStop = False
			Me.lblBalance.AutoSize = True
			Me.lblBalance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblBalance.ForeColor = Global.System.Drawing.Color.Maroon
			Me.lblBalance.Location = New Global.System.Drawing.Point(127, 168)
			Me.lblBalance.Name = "lblBalance"
			Me.lblBalance.Size = New Global.System.Drawing.Size(44, 20)
			Me.lblBalance.TabIndex = 5
			Me.lblBalance.Text = "0.00"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(10, 166)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(115, 20)
			Me.Label11.TabIndex = 34
			Me.Label11.Text = "A/c Balance :"
			Me.txtContactNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(95, 133)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(298, 21)
			Me.txtContactNo.TabIndex = 4
			Me.txtContactNo.TabStop = False
			Me.txtCity.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(95, 106)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.[ReadOnly] = True
			Me.txtCity.Size = New Global.System.Drawing.Size(298, 21)
			Me.txtCity.TabIndex = 3
			Me.txtCity.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(95, 79)
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.[ReadOnly] = True
			Me.txtAddress.Size = New Global.System.Drawing.Size(298, 21)
			Me.txtAddress.TabIndex = 2
			Me.txtAddress.TabStop = False
			Me.Label26.AutoSize = True
			Me.Label26.Location = New Global.System.Drawing.Point(11, 133)
			Me.Label26.Name = "Label26"
			Me.Label26.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label26.TabIndex = 29
			Me.Label26.Text = "Contact No. :"
			Me.Label30.AutoSize = True
			Me.Label30.Location = New Global.System.Drawing.Point(11, 77)
			Me.Label30.Name = "Label30"
			Me.Label30.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label30.TabIndex = 26
			Me.Label30.Text = "Address :"
			Me.Label36.AutoSize = True
			Me.Label36.Location = New Global.System.Drawing.Point(11, 25)
			Me.Label36.Name = "Label36"
			Me.Label36.Size = New Global.System.Drawing.Size(65, 13)
			Me.Label36.TabIndex = 23
			Me.Label36.Text = "Supplier ID :"
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(438, 73)
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.Size = New Global.System.Drawing.Size(242, 174)
			Me.txtRemarks.TabIndex = 4
			Me.txtRemarks.Text = ""
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(438, 57)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label12.TabIndex = 5
			Me.Label12.Text = "Remarks :"
			Me.GroupBox1.Controls.Add(Me.Label74)
			Me.GroupBox1.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox1.Controls.Add(Me.txtPaymentModeDetails)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.cmbPaymentMode)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.dtpTranactionDate)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.txtTransactionNo)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtTransactionAmount)
			Me.GroupBox1.Controls.Add(Me.Label19)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 253)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(423, 267)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Transaction Info"
			Me.Label74.AutoSize = True
			Me.Label74.Location = New Global.System.Drawing.Point(14, 89)
			Me.Label74.Name = "Label74"
			Me.Label74.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label74.TabIndex = 1733
			Me.Label74.Text = "Bank A/c No :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.Cursor = Global.System.Windows.Forms.Cursors.[Default]
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.Enabled = False
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(109, 89)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(147, 21)
			Me.cmbAccountNo.TabIndex = 3
			Me.txtPaymentModeDetails.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPaymentModeDetails.Location = New Global.System.Drawing.Point(14, 154)
			Me.txtPaymentModeDetails.Name = "txtPaymentModeDetails"
			Me.txtPaymentModeDetails.Size = New Global.System.Drawing.Size(379, 105)
			Me.txtPaymentModeDetails.TabIndex = 5
			Me.txtPaymentModeDetails.Text = ""
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(14, 138)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(263, 13)
			Me.Label4.TabIndex = 97
			Me.Label4.Text = "Payment Mode Details : (Transaction ID/ Cheque No.)"
			Me.cmbPaymentMode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPaymentMode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPaymentMode.FormattingEnabled = True
			Me.cmbPaymentMode.Items.AddRange(New Object() { "By Cash", "By Cheque", "By Online Transfer", "PhonePe", "Google Pay", "Paytm", "E-Wallet" })
			Me.cmbPaymentMode.Location = New Global.System.Drawing.Point(109, 64)
			Me.cmbPaymentMode.Name = "cmbPaymentMode"
			Me.cmbPaymentMode.Size = New Global.System.Drawing.Size(147, 21)
			Me.cmbPaymentMode.TabIndex = 2
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(14, 65)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "Payment Mode :"
			Me.dtpTranactionDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpTranactionDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpTranactionDate.Location = New Global.System.Drawing.Point(109, 40)
			Me.dtpTranactionDate.Name = "dtpTranactionDate"
			Me.dtpTranactionDate.Size = New Global.System.Drawing.Size(147, 20)
			Me.dtpTranactionDate.TabIndex = 1
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(14, 15)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(89, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Transaction No. :"
			Me.txtTransactionNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtTransactionNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransactionNo.Location = New Global.System.Drawing.Point(109, 15)
			Me.txtTransactionNo.Name = "txtTransactionNo"
			Me.txtTransactionNo.Size = New Global.System.Drawing.Size(147, 21)
			Me.txtTransactionNo.TabIndex = 0
			Me.txtTransactionNo.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(14, 41)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Transaction Date :"
			Me.txtTransactionAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTransactionAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransactionAmount.Location = New Global.System.Drawing.Point(109, 114)
			Me.txtTransactionAmount.Name = "txtTransactionAmount"
			Me.txtTransactionAmount.Size = New Global.System.Drawing.Size(147, 20)
			Me.txtTransactionAmount.TabIndex = 4
			Me.txtTransactionAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(14, 114)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label19.TabIndex = 96
			Me.Label19.Text = "Amount :"
			Me.Panel2.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.F2)
			Me.Panel2.Controls.Add(Me.F1)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.Button35)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtSuffix)
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.txtInvCode1)
			Me.Panel2.Controls.Add(Me.TextBox3)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtSup_ID)
			Me.Panel2.Controls.Add(Me.txtT_ID)
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(859, 38)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(318, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(144, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Payment Entry"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(363, 13)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1771
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.F2.Location = New Global.System.Drawing.Point(292, 13)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1763
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(257, 13)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1762
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(613, 11)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1760
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.Button35.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button35.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.Button35.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button35.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button35.ForeColor = Global.System.Drawing.Color.White
			Me.Button35.Image = CType(componentResourceManager.GetObject("Button35.Image"), Global.System.Drawing.Image)
			Me.Button35.Location = New Global.System.Drawing.Point(822, 5)
			Me.Button35.Name = "Button35"
			Me.Button35.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button35.TabIndex = 1755
			Me.Button35.TabStop = False
			Me.Button35.UseVisualStyleBackColor = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(262, 7)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1724
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtSuffix.Location = New Global.System.Drawing.Point(223, 10)
			Me.txtSuffix.Name = "txtSuffix"
			Me.txtSuffix.[ReadOnly] = True
			Me.txtSuffix.Size = New Global.System.Drawing.Size(33, 20)
			Me.txtSuffix.TabIndex = 427
			Me.txtSuffix.TabStop = False
			Me.txtSuffix.Visible = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(658, 4)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 425
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(544, 3)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 424
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.txtInvCode1.Location = New Global.System.Drawing.Point(101, 8)
			Me.txtInvCode1.Name = "txtInvCode1"
			Me.txtInvCode1.[ReadOnly] = True
			Me.txtInvCode1.Size = New Global.System.Drawing.Size(42, 20)
			Me.txtInvCode1.TabIndex = 418
			Me.txtInvCode1.TabStop = False
			Me.txtInvCode1.Visible = False
			Me.TextBox3.Location = New Global.System.Drawing.Point(558, 9)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox3.TabIndex = 315
			Me.TextBox3.Visible = False
			Me.TextBox2.Location = New Global.System.Drawing.Point(521, 9)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox2.TabIndex = 314
			Me.TextBox2.Visible = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(484, 9)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(31, 20)
			Me.TextBox1.TabIndex = 313
			Me.TextBox1.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(142, 5)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(56, 13)
			Me.lblUserType.TabIndex = 312
			Me.lblUserType.Text = "User Type"
			Me.lblUserType.Visible = False
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(187, 22)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 311
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(142, 20)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(29, 13)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "User"
			Me.lblUser.Visible = False
			Me.txtSup_ID.Location = New Global.System.Drawing.Point(60, 8)
			Me.txtSup_ID.Name = "txtSup_ID"
			Me.txtSup_ID.[ReadOnly] = True
			Me.txtSup_ID.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtSup_ID.TabIndex = 2
			Me.txtSup_ID.Visible = False
			Me.txtT_ID.Location = New Global.System.Drawing.Point(19, 8)
			Me.txtT_ID.Name = "txtT_ID"
			Me.txtT_ID.[ReadOnly] = True
			Me.txtT_ID.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtT_ID.TabIndex = 1
			Me.txtT_ID.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			Me.cmbSupplierName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.cmbSupplierName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbSupplierName.Location = New Global.System.Drawing.Point(95, 53)
			Me.cmbSupplierName.Name = "cmbSupplierName"
			Me.cmbSupplierName.[ReadOnly] = True
			Me.cmbSupplierName.Size = New Global.System.Drawing.Size(298, 21)
			Me.cmbSupplierName.TabIndex = 1738
			Me.cmbSupplierName.TabStop = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DodgerBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(881, 558)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPayment"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.gbPartyInfo.ResumeLayout(False)
			Me.gbPartyInfo.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006B06 RID: 27398
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
