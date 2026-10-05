Namespace BillPoint
	' Token: 0x02000312 RID: 786
		Public Partial Class frmPayment_Withdrawal
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BB83 RID: 48003 RVA: 0x00786E38 File Offset: 0x00785038
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

		' Token: 0x0600BB84 RID: 48004 RVA: 0x00786E88 File Offset: 0x00785088
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPayment_Withdrawal))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.DateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.label9 = New Global.System.Windows.Forms.Label()
			Me.groupBox5 = New Global.System.Windows.Forms.GroupBox()
			Me.txtAccNo = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.cmbPaymentMode = New Global.System.Windows.Forms.ComboBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtNotes = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtR_W = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.txtBalanceAmount = New Global.System.Windows.Forms.TextBox()
			Me.txtBank = New Global.System.Windows.Forms.TextBox()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtSwiftCode = New Global.System.Windows.Forms.TextBox()
			Me.txtIFSCCode = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtAccountName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			Me.groupBox5.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.GroupBox4)
			Me.Panel1.Controls.Add(Me.groupBox5)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(904, 635)
			Me.Panel1.TabIndex = 2
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(494, 354)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(86, 33)
			Me.Button1.TabIndex = 522
			Me.Button1.Text = "Search"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.GroupBox4.Controls.Add(Me.DateTo)
			Me.GroupBox4.Controls.Add(Me.DateFrom)
			Me.GroupBox4.Controls.Add(Me.Label4)
			Me.GroupBox4.Controls.Add(Me.label9)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(205, 321)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(383, 77)
			Me.GroupBox4.TabIndex = 47
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Search By Transaction Date"
			Me.DateTo.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.CustomFormat = "dd/MM/yyyy"
			Me.DateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTo.Location = New Global.System.Drawing.Point(166, 42)
			Me.DateTo.Name = "DateTo"
			Me.DateTo.Size = New Global.System.Drawing.Size(117, 20)
			Me.DateTo.TabIndex = 12
			Me.DateFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.CustomFormat = "dd/MM/yyyy"
			Me.DateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateFrom.Location = New Global.System.Drawing.Point(30, 42)
			Me.DateFrom.Name = "DateFrom"
			Me.DateFrom.Size = New Global.System.Drawing.Size(124, 20)
			Me.DateFrom.TabIndex = 11
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(27, 21)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(30, 13)
			Me.Label4.TabIndex = 9
			Me.Label4.Text = "From"
			Me.label9.AutoSize = True
			Me.label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.label9.Location = New Global.System.Drawing.Point(163, 21)
			Me.label9.Name = "label9"
			Me.label9.Size = New Global.System.Drawing.Size(20, 13)
			Me.label9.TabIndex = 10
			Me.label9.Text = "To"
			Me.groupBox5.Controls.Add(Me.txtAccNo)
			Me.groupBox5.Location = New Global.System.Drawing.Point(4, 321)
			Me.groupBox5.Name = "groupBox5"
			Me.groupBox5.Size = New Global.System.Drawing.Size(194, 77)
			Me.groupBox5.TabIndex = 46
			Me.groupBox5.TabStop = False
			Me.groupBox5.Text = "Search By Account No."
			Me.txtAccNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccNo.Location = New Global.System.Drawing.Point(17, 28)
			Me.txtAccNo.Name = "txtAccNo"
			Me.txtAccNo.Size = New Global.System.Drawing.Size(156, 22)
			Me.txtAccNo.TabIndex = 0
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Controls.Add(Me.GelButton2)
			Me.Panel5.Location = New Global.System.Drawing.Point(594, 326)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(224, 70)
			Me.Panel5.TabIndex = 45
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
			Me.btnReset.Location = New Global.System.Drawing.Point(9, 27)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(83, 33)
			Me.btnReset.TabIndex = 523
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(98, 27)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(110, 33)
			Me.GelButton2.TabIndex = 522
			Me.GelButton2.Text = "Export Excel"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.Label15)
			Me.GroupBox1.Controls.Add(Me.cmbPaymentMode)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Controls.Add(Me.txtContactNo)
			Me.GroupBox1.Controls.Add(Me.dtpDate)
			Me.GroupBox1.Controls.Add(Me.txtAmount)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtNotes)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.txtR_W)
			Me.GroupBox1.Controls.Add(Me.Label11)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 44)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(368, 274)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Transaction Information"
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(11, 136)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label15.TabIndex = 37
			Me.Label15.Text = "Payment Mode :"
			Me.cmbPaymentMode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbPaymentMode.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbPaymentMode.FormattingEnabled = True
			Me.cmbPaymentMode.Items.AddRange(New Object() { "By Online Transfer", "By Cheque", "By Cash" })
			Me.cmbPaymentMode.Location = New Global.System.Drawing.Point(109, 133)
			Me.cmbPaymentMode.Name = "cmbPaymentMode"
			Me.cmbPaymentMode.Size = New Global.System.Drawing.Size(149, 21)
			Me.cmbPaymentMode.TabIndex = 4
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(11, 54)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label13.TabIndex = 35
			Me.Label13.Text = "Contact No. :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(109, 54)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(149, 20)
			Me.txtContactNo.TabIndex = 1
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(109, 107)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(103, 20)
			Me.dtpDate.TabIndex = 3
			Me.txtAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAmount.Location = New Global.System.Drawing.Point(109, 80)
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.Size = New Global.System.Drawing.Size(149, 21)
			Me.txtAmount.TabIndex = 2
			Me.txtAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(11, 80)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label2.TabIndex = 32
			Me.Label2.Text = "Amount :"
			Me.txtNotes.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtNotes.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtNotes.Location = New Global.System.Drawing.Point(109, 160)
			Me.txtNotes.Multiline = True
			Me.txtNotes.Name = "txtNotes"
			Me.txtNotes.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtNotes.Size = New Global.System.Drawing.Size(237, 98)
			Me.txtNotes.TabIndex = 5
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(11, 195)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label8.TabIndex = 12
			Me.Label8.Text = "Notes :"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(11, 30)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(146, 13)
			Me.Label10.TabIndex = 33
			Me.Label10.Text = "Receiver/Withdrawer Name :"
			Me.txtR_W.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtR_W.Location = New Global.System.Drawing.Point(153, 25)
			Me.txtR_W.Name = "txtR_W"
			Me.txtR_W.Size = New Global.System.Drawing.Size(193, 20)
			Me.txtR_W.TabIndex = 0
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(11, 106)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label11.TabIndex = 0
			Me.Label11.Text = "Date :"
			Me.GroupBox2.Controls.Add(Me.Label20)
			Me.GroupBox2.Controls.Add(Me.txtBalanceAmount)
			Me.GroupBox2.Controls.Add(Me.txtBank)
			Me.GroupBox2.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.txtSwiftCode)
			Me.GroupBox2.Controls.Add(Me.txtIFSCCode)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.txtBranchName)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.txtAccountName)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(378, 44)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(385, 271)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "From Bank Account"
			Me.Label20.AutoSize = True
			Me.Label20.Location = New Global.System.Drawing.Point(14, 192)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label20.TabIndex = 42
			Me.Label20.Text = "Balance Amount :"
			Me.txtBalanceAmount.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBalanceAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBalanceAmount.Location = New Global.System.Drawing.Point(112, 189)
			Me.txtBalanceAmount.Name = "txtBalanceAmount"
			Me.txtBalanceAmount.[ReadOnly] = True
			Me.txtBalanceAmount.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtBalanceAmount.TabIndex = 6
			Me.txtBalanceAmount.TabStop = False
			Me.txtBank.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(112, 75)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.[ReadOnly] = True
			Me.txtBank.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBank.TabIndex = 2
			Me.txtBank.TabStop = False
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(112, 20)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(246, 21)
			Me.cmbAccountNo.TabIndex = 0
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(14, 76)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Bank :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(14, 23)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label5.TabIndex = 38
			Me.Label5.Text = "Account No. :"
			Me.txtSwiftCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSwiftCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode.Location = New Global.System.Drawing.Point(112, 131)
			Me.txtSwiftCode.Name = "txtSwiftCode"
			Me.txtSwiftCode.[ReadOnly] = True
			Me.txtSwiftCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtSwiftCode.TabIndex = 4
			Me.txtSwiftCode.TabStop = False
			Me.txtIFSCCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtIFSCCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode.Location = New Global.System.Drawing.Point(112, 160)
			Me.txtIFSCCode.Name = "txtIFSCCode"
			Me.txtIFSCCode.[ReadOnly] = True
			Me.txtIFSCCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtIFSCCode.TabIndex = 5
			Me.txtIFSCCode.TabStop = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(14, 133)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "IFSC :"
			Me.txtBranchName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBranchName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName.Location = New Global.System.Drawing.Point(112, 102)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.[ReadOnly] = True
			Me.txtBranchName.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBranchName.TabIndex = 3
			Me.txtBranchName.TabStop = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(14, 160)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Branch Code :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(14, 51)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label12.TabIndex = 33
			Me.Label12.Text = "Account Name :"
			Me.txtAccountName.Location = New Global.System.Drawing.Point(112, 47)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.[ReadOnly] = True
			Me.txtAccountName.Size = New Global.System.Drawing.Size(246, 20)
			Me.txtAccountName.TabIndex = 1
			Me.txtAccountName.TabStop = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(14, 106)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Branch Name :"
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
			Me.DataGridView1.ColumnHeadersHeight = 35
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column12, Me.Column3, Me.Column4, Me.Column13, Me.Column5, Me.Column6 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(4, 404)
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
			Me.DataGridView1.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(879, 210)
			Me.DataGridView1.TabIndex = 3
			Me.DataGridView1.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Receiver/Withdrawer Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 150
			Me.Column12.HeaderText = "Contact No."
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle5
			Me.Column3.HeaderText = "Amount"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column4.HeaderText = "Date"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column13.HeaderText = "Payment Mode"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column5.HeaderText = "Notes"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Account No."
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.GroupBox3.Controls.Add(Me.btnPrint)
			Me.GroupBox3.Controls.Add(Me.btnDelete)
			Me.GroupBox3.Controls.Add(Me.btnNew)
			Me.GroupBox3.Controls.Add(Me.btnSave)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(769, 44)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(130, 195)
			Me.GroupBox3.TabIndex = 6
			Me.GroupBox3.TabStop = False
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
			Me.btnPrint.Location = New Global.System.Drawing.Point(3, 143)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(128, 43)
			Me.btnPrint.TabIndex = 521
			Me.btnPrint.Text = "&Print"
			Me.btnPrint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnPrint.UseVisualStyleBackColor = False
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(2, 98)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(128, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(2, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(128, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(2, 52)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(128, 43)
			Me.btnSave.TabIndex = 518
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Location = New Global.System.Drawing.Point(-9, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(926, 32)
			Me.Panel2.TabIndex = 0
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(719, 5)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 443
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(630, 4)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 442
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(352, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(210, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Payment / Withdrawal"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(198, 7)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(243, 9)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtID.TabIndex = 9
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(904, 635)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPayment_Withdrawal"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			Me.groupBox5.ResumeLayout(False)
			Me.groupBox5.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004B7F RID: 19327
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
