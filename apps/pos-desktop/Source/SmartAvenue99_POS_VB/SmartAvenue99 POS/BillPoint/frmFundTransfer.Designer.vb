Namespace BillPoint
	' Token: 0x02000311 RID: 785
		Public Partial Class frmFundTransfer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BAD4 RID: 47828 RVA: 0x007818DC File Offset: 0x0077FADC
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

		' Token: 0x0600BAD5 RID: 47829 RVA: 0x0078192C File Offset: 0x0077FB2C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmFundTransfer))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox6 = New Global.System.Windows.Forms.GroupBox()
			Me.txtBank1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbAccountNo1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtSwiftCode1 = New Global.System.Windows.Forms.TextBox()
			Me.txtIFSCCode1 = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName1 = New Global.System.Windows.Forms.TextBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.txtAccountName1 = New Global.System.Windows.Forms.TextBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.DateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.label9 = New Global.System.Windows.Forms.Label()
			Me.groupBox5 = New Global.System.Windows.Forms.GroupBox()
			Me.txtAccNo = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtNotes = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtOperator = New Global.System.Windows.Forms.TextBox()
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
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox6.SuspendLayout()
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
			Me.Panel1.Controls.Add(Me.GroupBox6)
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
			Me.Panel1.Size = New Global.System.Drawing.Size(999, 628)
			Me.Panel1.TabIndex = 2
			Me.GroupBox6.Controls.Add(Me.txtBank1)
			Me.GroupBox6.Controls.Add(Me.cmbAccountNo1)
			Me.GroupBox6.Controls.Add(Me.Label13)
			Me.GroupBox6.Controls.Add(Me.Label15)
			Me.GroupBox6.Controls.Add(Me.txtSwiftCode1)
			Me.GroupBox6.Controls.Add(Me.txtIFSCCode1)
			Me.GroupBox6.Controls.Add(Me.Label16)
			Me.GroupBox6.Controls.Add(Me.txtBranchName1)
			Me.GroupBox6.Controls.Add(Me.Label17)
			Me.GroupBox6.Controls.Add(Me.Label18)
			Me.GroupBox6.Controls.Add(Me.txtAccountName1)
			Me.GroupBox6.Controls.Add(Me.Label19)
			Me.GroupBox6.Location = New Global.System.Drawing.Point(594, 44)
			Me.GroupBox6.Name = "GroupBox6"
			Me.GroupBox6.Size = New Global.System.Drawing.Size(279, 212)
			Me.GroupBox6.TabIndex = 2
			Me.GroupBox6.TabStop = False
			Me.GroupBox6.Text = "To Bank Account"
			Me.txtBank1.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBank1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank1.Location = New Global.System.Drawing.Point(106, 75)
			Me.txtBank1.Name = "txtBank1"
			Me.txtBank1.[ReadOnly] = True
			Me.txtBank1.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBank1.TabIndex = 2
			Me.txtBank1.TabStop = False
			Me.cmbAccountNo1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo1.FormattingEnabled = True
			Me.cmbAccountNo1.Location = New Global.System.Drawing.Point(106, 20)
			Me.cmbAccountNo1.Name = "cmbAccountNo1"
			Me.cmbAccountNo1.Size = New Global.System.Drawing.Size(155, 21)
			Me.cmbAccountNo1.TabIndex = 0
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(14, 76)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label13.TabIndex = 32
			Me.Label13.Text = "Bank :"
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(14, 23)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label15.TabIndex = 38
			Me.Label15.Text = "Account No. :"
			Me.txtSwiftCode1.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSwiftCode1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode1.Location = New Global.System.Drawing.Point(106, 131)
			Me.txtSwiftCode1.Name = "txtSwiftCode1"
			Me.txtSwiftCode1.[ReadOnly] = True
			Me.txtSwiftCode1.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtSwiftCode1.TabIndex = 4
			Me.txtSwiftCode1.TabStop = False
			Me.txtIFSCCode1.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtIFSCCode1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode1.Location = New Global.System.Drawing.Point(106, 160)
			Me.txtIFSCCode1.Name = "txtIFSCCode1"
			Me.txtIFSCCode1.[ReadOnly] = True
			Me.txtIFSCCode1.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtIFSCCode1.TabIndex = 5
			Me.txtIFSCCode1.TabStop = False
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(14, 133)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label16.TabIndex = 12
			Me.Label16.Text = "IFSC :"
			Me.txtBranchName1.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBranchName1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName1.Location = New Global.System.Drawing.Point(106, 102)
			Me.txtBranchName1.Name = "txtBranchName1"
			Me.txtBranchName1.[ReadOnly] = True
			Me.txtBranchName1.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBranchName1.TabIndex = 3
			Me.txtBranchName1.TabStop = False
			Me.Label17.AutoSize = True
			Me.Label17.Location = New Global.System.Drawing.Point(14, 160)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label17.TabIndex = 13
			Me.Label17.Text = "Branch Code :"
			Me.Label18.AutoSize = True
			Me.Label18.Location = New Global.System.Drawing.Point(14, 51)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label18.TabIndex = 33
			Me.Label18.Text = "Account Name :"
			Me.txtAccountName1.Location = New Global.System.Drawing.Point(106, 47)
			Me.txtAccountName1.Name = "txtAccountName1"
			Me.txtAccountName1.[ReadOnly] = True
			Me.txtAccountName1.Size = New Global.System.Drawing.Size(155, 20)
			Me.txtAccountName1.TabIndex = 1
			Me.txtAccountName1.TabStop = False
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(14, 106)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label19.TabIndex = 0
			Me.Label19.Text = "Branch Name :"
			Me.GroupBox4.Controls.Add(Me.GelButton3)
			Me.GroupBox4.Controls.Add(Me.DateTo)
			Me.GroupBox4.Controls.Add(Me.DateFrom)
			Me.GroupBox4.Controls.Add(Me.Label4)
			Me.GroupBox4.Controls.Add(Me.label9)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(205, 257)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(383, 77)
			Me.GroupBox4.TabIndex = 5
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Search By Transaction Date"
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(291, 34)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(84, 35)
			Me.GelButton3.TabIndex = 520
			Me.GelButton3.Text = "Search"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
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
			Me.groupBox5.Location = New Global.System.Drawing.Point(4, 262)
			Me.groupBox5.Name = "groupBox5"
			Me.groupBox5.Size = New Global.System.Drawing.Size(194, 72)
			Me.groupBox5.TabIndex = 4
			Me.groupBox5.TabStop = False
			Me.groupBox5.Text = "Search By Account No."
			Me.txtAccNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAccNo.Location = New Global.System.Drawing.Point(17, 28)
			Me.txtAccNo.Name = "txtAccNo"
			Me.txtAccNo.Size = New Global.System.Drawing.Size(156, 22)
			Me.txtAccNo.TabIndex = 0
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Location = New Global.System.Drawing.Point(594, 262)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(299, 70)
			Me.Panel5.TabIndex = 6
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
			Me.btnReset.Location = New Global.System.Drawing.Point(5, 20)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnReset.TabIndex = 521
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(105, 20)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(118, 43)
			Me.btnExportExcel.TabIndex = 520
			Me.btnExportExcel.Text = "Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.dtpDate)
			Me.GroupBox1.Controls.Add(Me.txtAmount)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtNotes)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.txtOperator)
			Me.GroupBox1.Controls.Add(Me.Label11)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 44)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(299, 212)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Transaction Info"
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(109, 76)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(134, 20)
			Me.dtpDate.TabIndex = 2
			Me.txtAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAmount.Location = New Global.System.Drawing.Point(109, 47)
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtAmount.TabIndex = 1
			Me.txtAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(11, 48)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label2.TabIndex = 32
			Me.Label2.Text = "Amount :"
			Me.txtNotes.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtNotes.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtNotes.Location = New Global.System.Drawing.Point(109, 104)
			Me.txtNotes.Multiline = True
			Me.txtNotes.Name = "txtNotes"
			Me.txtNotes.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtNotes.Size = New Global.System.Drawing.Size(178, 98)
			Me.txtNotes.TabIndex = 3
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(11, 105)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label8.TabIndex = 12
			Me.Label8.Text = "Notes :"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(11, 23)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(54, 13)
			Me.Label10.TabIndex = 33
			Me.Label10.Text = "Operator :"
			Me.txtOperator.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtOperator.Location = New Global.System.Drawing.Point(109, 19)
			Me.txtOperator.Name = "txtOperator"
			Me.txtOperator.[ReadOnly] = True
			Me.txtOperator.Size = New Global.System.Drawing.Size(134, 20)
			Me.txtOperator.TabIndex = 0
			Me.txtOperator.TabStop = False
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(11, 78)
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
			Me.GroupBox2.Location = New Global.System.Drawing.Point(309, 44)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(279, 212)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "From Bank Account"
			Me.Label20.AutoSize = True
			Me.Label20.Location = New Global.System.Drawing.Point(14, 177)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label20.TabIndex = 40
			Me.Label20.Text = "Balance Amount :"
			Me.txtBalanceAmount.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBalanceAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBalanceAmount.Location = New Global.System.Drawing.Point(106, 177)
			Me.txtBalanceAmount.Name = "txtBalanceAmount"
			Me.txtBalanceAmount.[ReadOnly] = True
			Me.txtBalanceAmount.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBalanceAmount.TabIndex = 39
			Me.txtBalanceAmount.TabStop = False
			Me.txtBank.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(106, 70)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.[ReadOnly] = True
			Me.txtBank.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBank.TabIndex = 2
			Me.txtBank.TabStop = False
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(106, 20)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(155, 21)
			Me.cmbAccountNo.TabIndex = 0
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(14, 70)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Bank :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(14, 20)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label5.TabIndex = 38
			Me.Label5.Text = "Account No. :"
			Me.txtSwiftCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSwiftCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode.Location = New Global.System.Drawing.Point(106, 124)
			Me.txtSwiftCode.Name = "txtSwiftCode"
			Me.txtSwiftCode.[ReadOnly] = True
			Me.txtSwiftCode.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtSwiftCode.TabIndex = 4
			Me.txtSwiftCode.TabStop = False
			Me.txtIFSCCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtIFSCCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode.Location = New Global.System.Drawing.Point(106, 151)
			Me.txtIFSCCode.Name = "txtIFSCCode"
			Me.txtIFSCCode.[ReadOnly] = True
			Me.txtIFSCCode.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtIFSCCode.TabIndex = 5
			Me.txtIFSCCode.TabStop = False
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(14, 124)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "IFSC :"
			Me.txtBranchName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBranchName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName.Location = New Global.System.Drawing.Point(106, 97)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.[ReadOnly] = True
			Me.txtBranchName.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtBranchName.TabIndex = 3
			Me.txtBranchName.TabStop = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(14, 152)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Branch Code :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(14, 46)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label12.TabIndex = 33
			Me.Label12.Text = "Account Name :"
			Me.txtAccountName.Location = New Global.System.Drawing.Point(106, 46)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.[ReadOnly] = True
			Me.txtAccountName.Size = New Global.System.Drawing.Size(155, 20)
			Me.txtAccountName.TabIndex = 1
			Me.txtAccountName.TabStop = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(14, 97)
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
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(4, 340)
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
			Me.DataGridView1.Size = New Global.System.Drawing.Size(976, 267)
			Me.DataGridView1.TabIndex = 3
			Me.DataGridView1.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Operator"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 147
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
			Me.Column5.HeaderText = "Notes"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Width = 200
			Me.Column6.HeaderText = "Account No. From"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 150
			Me.Column7.HeaderText = "Account No. To"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 150
			Me.GroupBox3.Controls.Add(Me.btnDelete)
			Me.GroupBox3.Controls.Add(Me.btnNew)
			Me.GroupBox3.Controls.Add(Me.btnSave)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(879, 44)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(109, 157)
			Me.GroupBox3.TabIndex = 3
			Me.GroupBox3.TabStop = False
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(6, 106)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnDelete.TabIndex = 519
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
			Me.btnNew.Location = New Global.System.Drawing.Point(6, 11)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnNew.TabIndex = 518
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
			Me.btnSave.Location = New Global.System.Drawing.Point(6, 58)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(94, 43)
			Me.btnSave.TabIndex = 517
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
			Me.Panel2.Location = New Global.System.Drawing.Point(-12, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1029, 32)
			Me.Panel2.TabIndex = 0
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(95, 5)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 441
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(6, 4)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 440
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(430, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(142, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Fund Transfer"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(198, 7)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(749, 9)
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
			MyBase.ClientSize = New Global.System.Drawing.Size(999, 628)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmFundTransfer"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox6.ResumeLayout(False)
			Me.GroupBox6.PerformLayout()
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

		' Token: 0x04004B39 RID: 19257
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
