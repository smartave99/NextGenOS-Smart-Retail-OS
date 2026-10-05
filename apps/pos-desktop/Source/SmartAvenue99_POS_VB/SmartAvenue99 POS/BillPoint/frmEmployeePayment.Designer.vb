Namespace BillPoint
	' Token: 0x0200033E RID: 830
		Public Partial Class frmEmployeePayment
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C176 RID: 49526 RVA: 0x007AFBC8 File Offset: 0x007ADDC8
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

		' Token: 0x0600C177 RID: 49527 RVA: 0x007AFC18 File Offset: 0x007ADE18
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEmployeePayment))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.btngetData = New Global.GelButtons.GelButton()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtEmployee = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label74 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.txtID1 = New Global.System.Windows.Forms.TextBox()
			Me.EmployeeID = New Global.System.Windows.Forms.TextBox()
			Me.txtSalary = New Global.System.Windows.Forms.TextBox()
			Me.PaymentID = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.PresentDays = New Global.System.Windows.Forms.TextBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtEmpID = New Global.System.Windows.Forms.TextBox()
			Me.Department = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Designation = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.PaymentModeDetails = New Global.System.Windows.Forms.TextBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Overtime = New Global.System.Windows.Forms.TextBox()
			Me.Advance = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.OvertimeAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.OvertimeRate = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.NetPay = New Global.System.Windows.Forms.TextBox()
			Me.PaymentDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.Deduction = New Global.System.Windows.Forms.TextBox()
			Me.Salary = New Global.System.Windows.Forms.TextBox()
			Me.paymentmode = New Global.System.Windows.Forms.ComboBox()
			Me.EmployeeName = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.groupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.DateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.GroupBox4)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.groupBox3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(860, 578)
			Me.Panel1.TabIndex = 2
			Me.Panel4.Location = New Global.System.Drawing.Point(722, 359)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(112, 281)
			Me.Panel4.TabIndex = 1
			Me.GroupBox4.Controls.Add(Me.btngetData)
			Me.GroupBox4.Controls.Add(Me.btnPrint)
			Me.GroupBox4.Controls.Add(Me.btnUpdate)
			Me.GroupBox4.Controls.Add(Me.btnDelete)
			Me.GroupBox4.Controls.Add(Me.btnNew)
			Me.GroupBox4.Controls.Add(Me.btnSave)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(722, 40)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(133, 303)
			Me.GroupBox4.TabIndex = 300
			Me.GroupBox4.TabStop = False
			Me.btngetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btngetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btngetData.FlatAppearance.BorderSize = 0
			Me.btngetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btngetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btngetData.ForeColor = Global.System.Drawing.Color.White
			Me.btngetData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btngetData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btngetData.Image = CType(componentResourceManager.GetObject("btngetData.Image"), Global.System.Drawing.Image)
			Me.btngetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btngetData.Location = New Global.System.Drawing.Point(8, 200)
			Me.btngetData.Name = "btngetData"
			Me.btngetData.Size = New Global.System.Drawing.Size(121, 43)
			Me.btngetData.TabIndex = 525
			Me.btngetData.Text = "Get Data"
			Me.btngetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btngetData.UseVisualStyleBackColor = False
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
			Me.btnPrint.Location = New Global.System.Drawing.Point(8, 247)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(121, 43)
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(8, 107)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(121, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(8, 154)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(121, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(8, 12)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(121, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(8, 59)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(121, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.txtEmployee)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(438, 40)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(278, 76)
			Me.GroupBox1.TabIndex = 299
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search by Employee Name"
			Me.txtEmployee.Location = New Global.System.Drawing.Point(33, 34)
			Me.txtEmployee.Name = "txtEmployee"
			Me.txtEmployee.Size = New Global.System.Drawing.Size(217, 20)
			Me.txtEmployee.TabIndex = 298
			Me.txtEmployee.TabStop = False
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.GroupBox2.Controls.Add(Me.Label74)
			Me.GroupBox2.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox2.Controls.Add(Me.txtID1)
			Me.GroupBox2.Controls.Add(Me.EmployeeID)
			Me.GroupBox2.Controls.Add(Me.txtSalary)
			Me.GroupBox2.Controls.Add(Me.PaymentID)
			Me.GroupBox2.Controls.Add(Me.Label19)
			Me.GroupBox2.Controls.Add(Me.PresentDays)
			Me.GroupBox2.Controls.Add(Me.Label18)
			Me.GroupBox2.Controls.Add(Me.txtEmpID)
			Me.GroupBox2.Controls.Add(Me.Department)
			Me.GroupBox2.Controls.Add(Me.lblUser)
			Me.GroupBox2.Controls.Add(Me.Designation)
			Me.GroupBox2.Controls.Add(Me.Label17)
			Me.GroupBox2.Controls.Add(Me.txtID)
			Me.GroupBox2.Controls.Add(Me.Label16)
			Me.GroupBox2.Controls.Add(Me.PaymentModeDetails)
			Me.GroupBox2.Controls.Add(Me.Label15)
			Me.GroupBox2.Controls.Add(Me.Overtime)
			Me.GroupBox2.Controls.Add(Me.Advance)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.OvertimeAmount)
			Me.GroupBox2.Controls.Add(Me.Label13)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.OvertimeRate)
			Me.GroupBox2.Controls.Add(Me.Label10)
			Me.GroupBox2.Controls.Add(Me.NetPay)
			Me.GroupBox2.Controls.Add(Me.PaymentDate)
			Me.GroupBox2.Controls.Add(Me.Deduction)
			Me.GroupBox2.Controls.Add(Me.Salary)
			Me.GroupBox2.Controls.Add(Me.paymentmode)
			Me.GroupBox2.Controls.Add(Me.EmployeeName)
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 117)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(423, 444)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.Label74.AutoSize = True
			Me.Label74.Location = New Global.System.Drawing.Point(27, 372)
			Me.Label74.Name = "Label74"
			Me.Label74.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label74.TabIndex = 1733
			Me.Label74.Text = "Bank A/c No :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.Cursor = Global.System.Windows.Forms.Cursors.[Default]
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.Enabled = False
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(169, 370)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(237, 21)
			Me.cmbAccountNo.TabIndex = 14
			Me.txtID1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID1.Location = New Global.System.Drawing.Point(383, 201)
			Me.txtID1.Name = "txtID1"
			Me.txtID1.[ReadOnly] = True
			Me.txtID1.Size = New Global.System.Drawing.Size(23, 20)
			Me.txtID1.TabIndex = 303
			Me.txtID1.TabStop = False
			Me.txtID1.Visible = False
			Me.EmployeeID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.EmployeeID.Location = New Global.System.Drawing.Point(169, 36)
			Me.EmployeeID.Name = "EmployeeID"
			Me.EmployeeID.[ReadOnly] = True
			Me.EmployeeID.Size = New Global.System.Drawing.Size(105, 20)
			Me.EmployeeID.TabIndex = 1
			Me.EmployeeID.TabStop = False
			Me.txtSalary.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSalary.Location = New Global.System.Drawing.Point(383, 228)
			Me.txtSalary.Name = "txtSalary"
			Me.txtSalary.[ReadOnly] = True
			Me.txtSalary.Size = New Global.System.Drawing.Size(23, 20)
			Me.txtSalary.TabIndex = 302
			Me.txtSalary.TabStop = False
			Me.txtSalary.Visible = False
			Me.PaymentID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PaymentID.Location = New Global.System.Drawing.Point(169, 10)
			Me.PaymentID.Name = "PaymentID"
			Me.PaymentID.[ReadOnly] = True
			Me.PaymentID.Size = New Global.System.Drawing.Size(105, 20)
			Me.PaymentID.TabIndex = 0
			Me.PaymentID.TabStop = False
			Me.Label19.AutoSize = True
			Me.Label19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label19.Location = New Global.System.Drawing.Point(26, 10)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label19.TabIndex = 50
			Me.Label19.Text = "Payment ID :"
			Me.PresentDays.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PresentDays.Location = New Global.System.Drawing.Point(169, 140)
			Me.PresentDays.Name = "PresentDays"
			Me.PresentDays.[ReadOnly] = True
			Me.PresentDays.Size = New Global.System.Drawing.Size(105, 20)
			Me.PresentDays.TabIndex = 5
			Me.PresentDays.TabStop = False
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(26, 140)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label18.TabIndex = 45
			Me.Label18.Text = "Present Days :"
			Me.txtEmpID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmpID.Location = New Global.System.Drawing.Point(383, 254)
			Me.txtEmpID.Name = "txtEmpID"
			Me.txtEmpID.[ReadOnly] = True
			Me.txtEmpID.Size = New Global.System.Drawing.Size(23, 20)
			Me.txtEmpID.TabIndex = 294
			Me.txtEmpID.TabStop = False
			Me.txtEmpID.Visible = False
			Me.Department.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Department.Location = New Global.System.Drawing.Point(169, 88)
			Me.Department.Name = "Department"
			Me.Department.[ReadOnly] = True
			Me.Department.Size = New Global.System.Drawing.Size(237, 20)
			Me.Department.TabIndex = 3
			Me.Department.TabStop = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(379, 303)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 293
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Designation.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Designation.Location = New Global.System.Drawing.Point(169, 114)
			Me.Designation.Name = "Designation"
			Me.Designation.[ReadOnly] = True
			Me.Designation.Size = New Global.System.Drawing.Size(237, 20)
			Me.Designation.TabIndex = 4
			Me.Designation.TabStop = False
			Me.Label17.AutoSize = True
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(27, 88)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label17.TabIndex = 44
			Me.Label17.Text = "Department :"
			Me.txtID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID.Location = New Global.System.Drawing.Point(383, 280)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(23, 20)
			Me.txtID.TabIndex = 292
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.Location = New Global.System.Drawing.Point(26, 114)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label16.TabIndex = 43
			Me.Label16.Text = "Designation :"
			Me.PaymentModeDetails.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.PaymentModeDetails.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PaymentModeDetails.Location = New Global.System.Drawing.Point(169, 394)
			Me.PaymentModeDetails.Name = "PaymentModeDetails"
			Me.PaymentModeDetails.Size = New Global.System.Drawing.Size(237, 20)
			Me.PaymentModeDetails.TabIndex = 15
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.Location = New Global.System.Drawing.Point(27, 394)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label15.TabIndex = 35
			Me.Label15.Text = "Note :"
			Me.Overtime.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Overtime.Location = New Global.System.Drawing.Point(169, 242)
			Me.Overtime.Name = "Overtime"
			Me.Overtime.[ReadOnly] = True
			Me.Overtime.Size = New Global.System.Drawing.Size(105, 20)
			Me.Overtime.TabIndex = 9
			Me.Overtime.TabStop = False
			Me.Advance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Advance.Location = New Global.System.Drawing.Point(169, 190)
			Me.Advance.Name = "Advance"
			Me.Advance.[ReadOnly] = True
			Me.Advance.Size = New Global.System.Drawing.Size(105, 20)
			Me.Advance.TabIndex = 7
			Me.Advance.TabStop = False
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(27, 190)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(56, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Advance :"
			Me.OvertimeAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.OvertimeAmount.Location = New Global.System.Drawing.Point(169, 294)
			Me.OvertimeAmount.Name = "OvertimeAmount"
			Me.OvertimeAmount.[ReadOnly] = True
			Me.OvertimeAmount.Size = New Global.System.Drawing.Size(105, 20)
			Me.OvertimeAmount.TabIndex = 11
			Me.OvertimeAmount.TabStop = False
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(26, 294)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(94, 13)
			Me.Label13.TabIndex = 30
			Me.Label13.Text = "Overtime Amount :"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(27, 268)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label3.TabIndex = 28
			Me.Label3.Text = "Overtime Rate :"
			Me.OvertimeRate.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.OvertimeRate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.OvertimeRate.Location = New Global.System.Drawing.Point(169, 268)
			Me.OvertimeRate.Name = "OvertimeRate"
			Me.OvertimeRate.Size = New Global.System.Drawing.Size(105, 20)
			Me.OvertimeRate.TabIndex = 10
			Me.OvertimeRate.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(27, 242)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(127, 13)
			Me.Label10.TabIndex = 26
			Me.Label10.Text = "Overtime (d.HH:MM:SS) :"
			Me.NetPay.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.NetPay.Location = New Global.System.Drawing.Point(169, 419)
			Me.NetPay.Name = "NetPay"
			Me.NetPay.[ReadOnly] = True
			Me.NetPay.Size = New Global.System.Drawing.Size(105, 20)
			Me.NetPay.TabIndex = 16
			Me.NetPay.TabStop = False
			Me.PaymentDate.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PaymentDate.CustomFormat = "dd/MM/yyyy"
			Me.PaymentDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.PaymentDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.PaymentDate.Location = New Global.System.Drawing.Point(169, 320)
			Me.PaymentDate.Name = "PaymentDate"
			Me.PaymentDate.Size = New Global.System.Drawing.Size(105, 20)
			Me.PaymentDate.TabIndex = 12
			Me.Deduction.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Deduction.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Deduction.Location = New Global.System.Drawing.Point(169, 216)
			Me.Deduction.Name = "Deduction"
			Me.Deduction.Size = New Global.System.Drawing.Size(105, 20)
			Me.Deduction.TabIndex = 8
			Me.Deduction.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Salary.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Salary.Location = New Global.System.Drawing.Point(169, 166)
			Me.Salary.Name = "Salary"
			Me.Salary.[ReadOnly] = True
			Me.Salary.Size = New Global.System.Drawing.Size(105, 20)
			Me.Salary.TabIndex = 6
			Me.Salary.TabStop = False
			Me.paymentmode.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.paymentmode.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.paymentmode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.paymentmode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.paymentmode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.paymentmode.FormattingEnabled = True
			Me.paymentmode.Items.AddRange(New Object() { "By Cash", "By Cheque", "By Online Transfer" })
			Me.paymentmode.Location = New Global.System.Drawing.Point(169, 346)
			Me.paymentmode.Name = "paymentmode"
			Me.paymentmode.Size = New Global.System.Drawing.Size(237, 21)
			Me.paymentmode.TabIndex = 13
			Me.EmployeeName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.EmployeeName.Location = New Global.System.Drawing.Point(169, 62)
			Me.EmployeeName.Name = "EmployeeName"
			Me.EmployeeName.[ReadOnly] = True
			Me.EmployeeName.Size = New Global.System.Drawing.Size(237, 20)
			Me.EmployeeName.TabIndex = 2
			Me.EmployeeName.TabStop = False
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(27, 419)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label8.TabIndex = 17
			Me.Label8.Text = "Net Pay :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(27, 216)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label5.TabIndex = 14
			Me.Label5.Text = "Deduction :"
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.Location = New Global.System.Drawing.Point(27, 166)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label6.TabIndex = 15
			Me.Label6.Text = "Basic Salary :"
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.Location = New Global.System.Drawing.Point(27, 320)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label7.TabIndex = 16
			Me.Label7.Text = "Payment Date :"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(26, 36)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label9.TabIndex = 11
			Me.Label9.Text = "Employee ID :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(27, 346)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(98, 13)
			Me.Label4.TabIndex = 13
			Me.Label4.Text = "Mode Of Payment :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(26, 62)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label2.TabIndex = 10
			Me.Label2.Text = "Employee Name :"
			Me.groupBox3.BackColor = Global.System.Drawing.Color.Transparent
			Me.groupBox3.Controls.Add(Me.DateTo)
			Me.groupBox3.Controls.Add(Me.DateFrom)
			Me.groupBox3.Controls.Add(Me.Label11)
			Me.groupBox3.Controls.Add(Me.Label12)
			Me.groupBox3.Location = New Global.System.Drawing.Point(4, 40)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New Global.System.Drawing.Size(278, 75)
			Me.groupBox3.TabIndex = 0
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Payment"
			Me.DateTo.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.CustomFormat = "dd/MM/yyyy"
			Me.DateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTo.Location = New Global.System.Drawing.Point(152, 35)
			Me.DateTo.Name = "DateTo"
			Me.DateTo.Size = New Global.System.Drawing.Size(105, 20)
			Me.DateTo.TabIndex = 1
			Me.DateFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.CustomFormat = "dd/MM/yyyy"
			Me.DateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateFrom.Location = New Global.System.Drawing.Point(13, 35)
			Me.DateFrom.Name = "DateFrom"
			Me.DateFrom.Size = New Global.System.Drawing.Size(105, 20)
			Me.DateFrom.TabIndex = 0
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(13, 16)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label11.TabIndex = 9
			Me.Label11.Text = "From :"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(152, 16)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label12.TabIndex = 10
			Me.Label12.Text = "To :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DodgerBlue
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column6, Me.Column4 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(438, 122)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Orange
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(278, 437)
			Me.dgw.TabIndex = 295
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "Id"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "Employee ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 72
			Me.Column3.HeaderText = "Employee Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 180
			Me.Column5.HeaderText = "Department"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Visible = False
			Me.Column6.HeaderText = "Designation"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Visible = False
			Me.Column4.HeaderText = "Basic Working Time"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.txtCompanyName)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(860, 34)
			Me.Panel2.TabIndex = 0
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(705, 5)
			Me.txtCompanyName.Name = "txtCompanyName"
			Me.txtCompanyName.[ReadOnly] = True
			Me.txtCompanyName.Size = New Global.System.Drawing.Size(29, 20)
			Me.txtCompanyName.TabIndex = 6
			Me.txtCompanyName.TabStop = False
			Me.txtCompanyName.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(322, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(213, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Payroll Payment Entry"
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(860, 578)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmEmployeePayment"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004D94 RID: 19860
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
