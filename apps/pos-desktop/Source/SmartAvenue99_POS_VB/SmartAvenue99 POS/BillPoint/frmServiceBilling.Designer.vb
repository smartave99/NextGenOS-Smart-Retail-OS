Namespace BillPoint
	' Token: 0x020005CD RID: 1485
		Public Partial Class frmServiceBilling
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0601213A RID: 74042 RVA: 0x00A676A0 File Offset: 0x00A658A0
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

		' Token: 0x0601213B RID: 74043 RVA: 0x00A676F0 File Offset: 0x00A658F0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmServiceBilling))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtRemarks = New Global.System.Windows.Forms.TextBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.txtServiceTaxAmount = New Global.System.Windows.Forms.TextBox()
			Me.txtServiceTaxPer = New Global.System.Windows.Forms.TextBox()
			Me.txtRepairCharges = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtUpfront = New Global.System.Windows.Forms.TextBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txtGrandTotal = New Global.System.Windows.Forms.TextBox()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.txtPaymentDue = New Global.System.Windows.Forms.TextBox()
			Me.txtTotalPayment = New Global.System.Windows.Forms.TextBox()
			Me.Label34 = New Global.System.Windows.Forms.Label()
			Me.Label35 = New Global.System.Windows.Forms.Label()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtServiceCode = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnSelect = New Global.System.Windows.Forms.Button()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.dtpInvoiceDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtInvoiceNo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnGetdata = New Global.GelButtons.GelButton()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.Button35 = New Global.System.Windows.Forms.Button()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtcompname = New Global.System.Windows.Forms.TextBox()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtS_ID = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.txtCID = New Global.System.Windows.Forms.TextBox()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(4, 22)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label5"
			label.Size = New Global.System.Drawing.Size(68, 13)
			label.TabIndex = 268
			label.Text = "Invoice No. :"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.txtRemarks)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.GroupBox4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(998, 342)
			Me.Panel1.TabIndex = 3
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(564, 58)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label8.TabIndex = 85
			Me.Label8.Text = "Remarks :"
			Me.txtRemarks.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemarks.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemarks.Location = New Global.System.Drawing.Point(564, 77)
			Me.txtRemarks.Multiline = True
			Me.txtRemarks.Name = "txtRemarks"
			Me.txtRemarks.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtRemarks.Size = New Global.System.Drawing.Size(267, 232)
			Me.txtRemarks.TabIndex = 3
			Me.Panel4.BackColor = Global.System.Drawing.Color.Transparent
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.Label15)
			Me.Panel4.Controls.Add(Me.Label18)
			Me.Panel4.Controls.Add(Me.Label17)
			Me.Panel4.Controls.Add(Me.txtServiceTaxAmount)
			Me.Panel4.Controls.Add(Me.txtServiceTaxPer)
			Me.Panel4.Controls.Add(Me.txtRepairCharges)
			Me.Panel4.Controls.Add(Me.Label14)
			Me.Panel4.Controls.Add(Me.txtUpfront)
			Me.Panel4.Controls.Add(Me.Label16)
			Me.Panel4.Controls.Add(Me.txtGrandTotal)
			Me.Panel4.Controls.Add(Me.Label31)
			Me.Panel4.Controls.Add(Me.txtPaymentDue)
			Me.Panel4.Controls.Add(Me.txtTotalPayment)
			Me.Panel4.Controls.Add(Me.Label34)
			Me.Panel4.Controls.Add(Me.Label35)
			Me.Panel4.Location = New Global.System.Drawing.Point(9, 193)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(549, 118)
			Me.Panel4.TabIndex = 2
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.Red
			Me.Label6.Location = New Global.System.Drawing.Point(400, 71)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label6.TabIndex = 345
			Me.Label6.Text = "*"
			Me.Label15.AutoSize = True
			Me.Label15.ForeColor = Global.System.Drawing.Color.Red
			Me.Label15.Location = New Global.System.Drawing.Point(190, 18)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label15.TabIndex = 344
			Me.Label15.Text = "*"
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(377, 14)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(19, 16)
			Me.Label18.TabIndex = 94
			Me.Label18.Text = "%"
			Me.Label17.AutoSize = True
			Me.Label17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(205, 38)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label17.TabIndex = 93
			Me.Label17.Text = "Grand Total :"
			Me.txtServiceTaxAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtServiceTaxAmount.Location = New Global.System.Drawing.Point(402, 12)
			Me.txtServiceTaxAmount.Name = "txtServiceTaxAmount"
			Me.txtServiceTaxAmount.[ReadOnly] = True
			Me.txtServiceTaxAmount.Size = New Global.System.Drawing.Size(102, 20)
			Me.txtServiceTaxAmount.TabIndex = 4
			Me.txtServiceTaxAmount.TabStop = False
			Me.txtServiceTaxAmount.Text = "0.00"
			Me.txtServiceTaxAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtServiceTaxPer.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtServiceTaxPer.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtServiceTaxPer.Location = New Global.System.Drawing.Point(292, 12)
			Me.txtServiceTaxPer.Name = "txtServiceTaxPer"
			Me.txtServiceTaxPer.Size = New Global.System.Drawing.Size(81, 20)
			Me.txtServiceTaxPer.TabIndex = 3
			Me.txtServiceTaxPer.Text = "0.00"
			Me.txtServiceTaxPer.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtRepairCharges.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRepairCharges.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRepairCharges.Location = New Global.System.Drawing.Point(99, 12)
			Me.txtRepairCharges.Name = "txtRepairCharges"
			Me.txtRepairCharges.Size = New Global.System.Drawing.Size(87, 20)
			Me.txtRepairCharges.TabIndex = 0
			Me.txtRepairCharges.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.Location = New Global.System.Drawing.Point(6, 12)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(91, 13)
			Me.Label14.TabIndex = 90
			Me.Label14.Text = "Service Charges :"
			Me.txtUpfront.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUpfront.Location = New Global.System.Drawing.Point(99, 38)
			Me.txtUpfront.Name = "txtUpfront"
			Me.txtUpfront.[ReadOnly] = True
			Me.txtUpfront.Size = New Global.System.Drawing.Size(87, 20)
			Me.txtUpfront.TabIndex = 1
			Me.txtUpfront.TabStop = False
			Me.txtUpfront.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.Location = New Global.System.Drawing.Point(6, 38)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(48, 13)
			Me.Label16.TabIndex = 88
			Me.Label16.Text = "Upfront :"
			Me.txtGrandTotal.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGrandTotal.Location = New Global.System.Drawing.Point(292, 38)
			Me.txtGrandTotal.Name = "txtGrandTotal"
			Me.txtGrandTotal.[ReadOnly] = True
			Me.txtGrandTotal.Size = New Global.System.Drawing.Size(105, 20)
			Me.txtGrandTotal.TabIndex = 5
			Me.txtGrandTotal.TabStop = False
			Me.txtGrandTotal.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label31.AutoSize = True
			Me.Label31.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label31.Location = New Global.System.Drawing.Point(205, 12)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label31.TabIndex = 84
			Me.Label31.Text = "Service Tax :"
			Me.txtPaymentDue.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPaymentDue.Location = New Global.System.Drawing.Point(292, 90)
			Me.txtPaymentDue.Name = "txtPaymentDue"
			Me.txtPaymentDue.[ReadOnly] = True
			Me.txtPaymentDue.Size = New Global.System.Drawing.Size(105, 20)
			Me.txtPaymentDue.TabIndex = 7
			Me.txtPaymentDue.TabStop = False
			Me.txtPaymentDue.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtTotalPayment.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtTotalPayment.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTotalPayment.Location = New Global.System.Drawing.Point(292, 64)
			Me.txtTotalPayment.Name = "txtTotalPayment"
			Me.txtTotalPayment.Size = New Global.System.Drawing.Size(105, 20)
			Me.txtTotalPayment.TabIndex = 6
			Me.txtTotalPayment.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label34.AutoSize = True
			Me.Label34.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label34.Location = New Global.System.Drawing.Point(205, 90)
			Me.Label34.Name = "Label34"
			Me.Label34.Size = New Global.System.Drawing.Size(77, 13)
			Me.Label34.TabIndex = 79
			Me.Label34.Text = "Payment Due :"
			Me.Label35.AutoSize = True
			Me.Label35.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label35.Location = New Global.System.Drawing.Point(205, 64)
			Me.Label35.Name = "Label35"
			Me.Label35.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label35.TabIndex = 78
			Me.Label35.Text = "Total Payment :"
			Me.GroupBox3.Controls.Add(Me.Label7)
			Me.GroupBox3.Controls.Add(Me.Label9)
			Me.GroupBox3.Controls.Add(Me.txtServiceCode)
			Me.GroupBox3.Controls.Add(Me.Label2)
			Me.GroupBox3.Controls.Add(Me.btnSelect)
			Me.GroupBox3.Controls.Add(Me.Label3)
			Me.GroupBox3.Controls.Add(Me.txtCustomerID)
			Me.GroupBox3.Controls.Add(Me.txtCustomerName)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(262, 56)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(296, 120)
			Me.GroupBox3.TabIndex = 1
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Service Details"
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.Red
			Me.Label7.Location = New Global.System.Drawing.Point(78, 30)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label7.TabIndex = 344
			Me.Label7.Text = "*"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(5, 30)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(77, 13)
			Me.Label9.TabIndex = 11
			Me.Label9.Text = "Service Code :"
			Me.txtServiceCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtServiceCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtServiceCode.Location = New Global.System.Drawing.Point(95, 30)
			Me.txtServiceCode.Name = "txtServiceCode"
			Me.txtServiceCode.[ReadOnly] = True
			Me.txtServiceCode.Size = New Global.System.Drawing.Size(122, 21)
			Me.txtServiceCode.TabIndex = 8
			Me.txtServiceCode.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(5, 83)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Customer Name :"
			Me.btnSelect.BackColor = Global.System.Drawing.Color.Lime
			Me.btnSelect.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelect.Location = New Global.System.Drawing.Point(223, 30)
			Me.btnSelect.Name = "btnSelect"
			Me.btnSelect.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelect.TabIndex = 6
			Me.btnSelect.Text = "..."
			Me.btnSelect.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(5, 57)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Customer ID :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(95, 57)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(122, 21)
			Me.txtCustomerID.TabIndex = 0
			Me.txtCustomerID.TabStop = False
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(95, 83)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.[ReadOnly] = True
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(195, 20)
			Me.txtCustomerName.TabIndex = 0
			Me.txtCustomerName.TabStop = False
			Me.GroupBox4.Controls.Add(Me.dtpInvoiceDate)
			Me.GroupBox4.Controls.Add(Me.txtInvoiceNo)
			Me.GroupBox4.Controls.Add(Me.Label4)
			Me.GroupBox4.Controls.Add(label)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(9, 56)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(246, 81)
			Me.GroupBox4.TabIndex = 0
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Invoice Info"
			Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpInvoiceDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpInvoiceDate.Location = New Global.System.Drawing.Point(78, 45)
			Me.dtpInvoiceDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
			Me.dtpInvoiceDate.Size = New Global.System.Drawing.Size(111, 20)
			Me.dtpInvoiceDate.TabIndex = 1
			Me.txtInvoiceNo.Location = New Global.System.Drawing.Point(78, 19)
			Me.txtInvoiceNo.Name = "txtInvoiceNo"
			Me.txtInvoiceNo.[ReadOnly] = True
			Me.txtInvoiceNo.Size = New Global.System.Drawing.Size(162, 20)
			Me.txtInvoiceNo.TabIndex = 0
			Me.txtInvoiceNo.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(4, 47)
			Me.Label4.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(74, 13)
			Me.Label4.TabIndex = 335
			Me.Label4.Text = "Invoice Date :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnGetdata)
			Me.Panel3.Controls.Add(Me.btnPrint)
			Me.Panel3.Controls.Add(Me.btnUpdate)
			Me.Panel3.Controls.Add(Me.btnDelete)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.btnSave)
			Me.Panel3.Location = New Global.System.Drawing.Point(864, 48)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(121, 289)
			Me.Panel3.TabIndex = 4
			Me.btnGetdata.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetdata.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetdata.FlatAppearance.BorderSize = 0
			Me.btnGetdata.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetdata.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetdata.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetdata.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetdata.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnGetdata.Image = CType(componentResourceManager.GetObject("btnGetdata.Image"), Global.System.Drawing.Image)
			Me.btnGetdata.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetdata.Location = New Global.System.Drawing.Point(3, 191)
			Me.btnGetdata.Name = "btnGetdata"
			Me.btnGetdata.Size = New Global.System.Drawing.Size(113, 43)
			Me.btnGetdata.TabIndex = 525
			Me.btnGetdata.Text = "Get Data"
			Me.btnGetdata.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetdata.UseVisualStyleBackColor = False
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
			Me.btnPrint.Location = New Global.System.Drawing.Point(3, 238)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(113, 43)
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
			Me.btnUpdate.Location = New Global.System.Drawing.Point(3, 98)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(113, 43)
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(3, 145)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(113, 43)
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
			Me.btnNew.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(113, 43)
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
			Me.btnSave.Location = New Global.System.Drawing.Point(3, 50)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(113, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.F2)
			Me.Panel2.Controls.Add(Me.F1)
			Me.Panel2.Controls.Add(Me.Button35)
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.txtcompname)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox9)
			Me.Panel2.Controls.Add(Me.txtContactNo)
			Me.Panel2.Controls.Add(Me.txtS_ID)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.txtCID)
			Me.Panel2.Controls.Add(Me.lblUserType)
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(998, 40)
			Me.Panel2.TabIndex = 0
			Me.F2.Location = New Global.System.Drawing.Point(372, 21)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1771
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(337, 21)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1770
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.Button35.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button35.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button35.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button35.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button35.ForeColor = Global.System.Drawing.Color.White
			Me.Button35.Image = CType(componentResourceManager.GetObject("Button35.Image"), Global.System.Drawing.Image)
			Me.Button35.Location = New Global.System.Drawing.Point(966, 1)
			Me.Button35.Name = "Button35"
			Me.Button35.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button35.TabIndex = 1760
			Me.Button35.TabStop = False
			Me.Button35.UseVisualStyleBackColor = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(129, 31)
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
			Me.DTP1.Location = New Global.System.Drawing.Point(15, 30)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 430
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.txtcompname.Location = New Global.System.Drawing.Point(899, 22)
			Me.txtcompname.Name = "txtcompname"
			Me.txtcompname.[ReadOnly] = True
			Me.txtcompname.Size = New Global.System.Drawing.Size(20, 20)
			Me.txtcompname.TabIndex = 420
			Me.txtcompname.TabStop = False
			Me.txtcompname.Visible = False
			Me.TextBox10.Location = New Global.System.Drawing.Point(771, 21)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(20, 20)
			Me.TextBox10.TabIndex = 419
			Me.TextBox10.TabStop = False
			Me.TextBox10.Visible = False
			Me.TextBox9.Location = New Global.System.Drawing.Point(793, 22)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox9.TabIndex = 418
			Me.TextBox9.TabStop = False
			Me.TextBox9.Visible = False
			Me.txtContactNo.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(631, 23)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(130, 21)
			Me.txtContactNo.TabIndex = 318
			Me.txtContactNo.TabStop = False
			Me.txtContactNo.Visible = False
			Me.txtS_ID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtS_ID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtS_ID.Location = New Global.System.Drawing.Point(146, 17)
			Me.txtS_ID.Name = "txtS_ID"
			Me.txtS_ID.[ReadOnly] = True
			Me.txtS_ID.Size = New Global.System.Drawing.Size(70, 21)
			Me.txtS_ID.TabIndex = 317
			Me.txtS_ID.TabStop = False
			Me.txtS_ID.Visible = False
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
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(251, 32)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 314
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(206, 31)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(29, 13)
			Me.lblUser.TabIndex = 313
			Me.lblUser.Text = "User"
			Me.lblUser.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(419, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(143, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Service Billing"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(998, 342)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmServiceBilling"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006C8F RID: 27791
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
