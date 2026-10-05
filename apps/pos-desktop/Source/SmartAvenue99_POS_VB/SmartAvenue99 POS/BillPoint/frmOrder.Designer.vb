Namespace BillPoint
	' Token: 0x0200005D RID: 93
		Public Partial Class frmOrder
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600112F RID: 4399 RVA: 0x000C3CEC File Offset: 0x000C1EEC
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

		' Token: 0x06001130 RID: 4400 RVA: 0x000C3D3C File Offset: 0x000C1F3C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
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
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmOrder))
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtGrandTotal = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txtDCharg = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtSubTotal = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.txtDtime = New Global.System.Windows.Forms.TextBox()
			Me.txtDdate = New Global.System.Windows.Forms.TextBox()
			Me.txtOdate = New Global.System.Windows.Forms.TextBox()
			Me.txtPaymentMode = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtZipCode = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtOrderNo = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtOrderStatus = New Global.System.Windows.Forms.TextBox()
			Me.txtOrderId = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.id = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Orderid = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.customer = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.order_date = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.address = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.city = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.totalamount = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.status = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.paymentmode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.uid = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.MRP = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Dis = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.RadioButton3 = New Global.System.Windows.Forms.RadioButton()
			Me.RadioButton2 = New Global.System.Windows.Forms.RadioButton()
			Me.lblCode = New Global.System.Windows.Forms.Label()
			Me.RadioButton1 = New Global.System.Windows.Forms.RadioButton()
			Me.btnCancle = New Global.GelButtons.GelButton()
			Me.btnEcomPost = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.RadioButton4 = New Global.System.Windows.Forms.RadioButton()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(530, 16)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(86, 13)
			Me.Label8.TabIndex = 1800
			Me.Label8.Text = "Sub Total Price :"
			Me.txtCustomerID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtCustomerID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(6, 25)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(44, 21)
			Me.txtCustomerID.TabIndex = 1782
			Me.txtCustomerID.TabStop = False
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.txtGrandTotal)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.txtDCharg)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.txtSubTotal)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.GroupBox2)
			Me.GroupBox1.Controls.Add(Me.txtCustomerID)
			Me.GroupBox1.Controls.Add(Me.cmbCustomerName)
			Me.GroupBox1.Controls.Add(Me.txtEmailID)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.txtContactNo)
			Me.GroupBox1.Controls.Add(Me.txtZipCode)
			Me.GroupBox1.Controls.Add(Me.Label12)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtAddress)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.txtCity)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(340, 59)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(655, 146)
			Me.GroupBox1.TabIndex = 1810
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Customer"
			Me.txtGrandTotal.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGrandTotal.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGrandTotal.Location = New Global.System.Drawing.Point(532, 113)
			Me.txtGrandTotal.Name = "txtGrandTotal"
			Me.txtGrandTotal.[ReadOnly] = True
			Me.txtGrandTotal.Size = New Global.System.Drawing.Size(117, 21)
			Me.txtGrandTotal.TabIndex = 1805
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(530, 97)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label10.TabIndex = 1804
			Me.Label10.Text = "Grand Total :"
			Me.txtDCharg.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDCharg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDCharg.Location = New Global.System.Drawing.Point(532, 72)
			Me.txtDCharg.Name = "txtDCharg"
			Me.txtDCharg.[ReadOnly] = True
			Me.txtDCharg.Size = New Global.System.Drawing.Size(117, 21)
			Me.txtDCharg.TabIndex = 1803
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(530, 56)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label9.TabIndex = 1802
			Me.Label9.Text = "Delivery Charges :"
			Me.txtSubTotal.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSubTotal.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSubTotal.Location = New Global.System.Drawing.Point(532, 32)
			Me.txtSubTotal.Name = "txtSubTotal"
			Me.txtSubTotal.[ReadOnly] = True
			Me.txtSubTotal.Size = New Global.System.Drawing.Size(117, 21)
			Me.txtSubTotal.TabIndex = 1801
			Me.GroupBox2.Controls.Add(Me.txtDtime)
			Me.GroupBox2.Controls.Add(Me.txtDdate)
			Me.GroupBox2.Controls.Add(Me.txtOdate)
			Me.GroupBox2.Controls.Add(Me.txtPaymentMode)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(228, 9)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(298, 84)
			Me.GroupBox2.TabIndex = 1799
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Payment Mode"
			Me.txtDtime.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDtime.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDtime.Location = New Global.System.Drawing.Point(227, 57)
			Me.txtDtime.Name = "txtDtime"
			Me.txtDtime.[ReadOnly] = True
			Me.txtDtime.Size = New Global.System.Drawing.Size(65, 21)
			Me.txtDtime.TabIndex = 1803
			Me.txtDdate.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDdate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDdate.Location = New Global.System.Drawing.Point(118, 57)
			Me.txtDdate.Name = "txtDdate"
			Me.txtDdate.[ReadOnly] = True
			Me.txtDdate.Size = New Global.System.Drawing.Size(103, 21)
			Me.txtDdate.TabIndex = 1802
			Me.txtOdate.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOdate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOdate.Location = New Global.System.Drawing.Point(9, 57)
			Me.txtOdate.Name = "txtOdate"
			Me.txtOdate.[ReadOnly] = True
			Me.txtOdate.Size = New Global.System.Drawing.Size(103, 21)
			Me.txtOdate.TabIndex = 1801
			Me.txtPaymentMode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtPaymentMode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtPaymentMode.Location = New Global.System.Drawing.Point(9, 17)
			Me.txtPaymentMode.Name = "txtPaymentMode"
			Me.txtPaymentMode.[ReadOnly] = True
			Me.txtPaymentMode.Size = New Global.System.Drawing.Size(283, 21)
			Me.txtPaymentMode.TabIndex = 1800
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(6, 42)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(65, 13)
			Me.Label1.TabIndex = 1797
			Me.Label1.Text = "Order Date :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(116, 43)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(106, 13)
			Me.Label3.TabIndex = 1798
			Me.Label3.Text = "Delivery Date & Time :"
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCustomerName.Enabled = False
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(55, 25)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(165, 21)
			Me.cmbCustomerName.TabIndex = 1783
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(108, 112)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.[ReadOnly] = True
			Me.txtEmailID.Size = New Global.System.Drawing.Size(154, 21)
			Me.txtEmailID.TabIndex = 1790
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(371, 97)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label7.TabIndex = 1793
			Me.Label7.Text = "Contact No :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(105, 98)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label6.TabIndex = 1792
			Me.Label6.Text = "Email ID :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(374, 112)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.[ReadOnly] = True
			Me.txtContactNo.Size = New Global.System.Drawing.Size(148, 21)
			Me.txtContactNo.TabIndex = 1789
			Me.txtZipCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtZipCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtZipCode.Location = New Global.System.Drawing.Point(6, 112)
			Me.txtZipCode.Name = "txtZipCode"
			Me.txtZipCode.[ReadOnly] = True
			Me.txtZipCode.Size = New Global.System.Drawing.Size(98, 21)
			Me.txtZipCode.TabIndex = 1788
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(3, 98)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label12.TabIndex = 1796
			Me.Label12.Text = "Postal Code :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(52, 9)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 1787
			Me.Label2.Text = "Customer Name :"
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Enabled = False
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(55, 52)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.[ReadOnly] = True
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(165, 37)
			Me.txtAddress.TabIndex = 1784
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(6, 49)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label5.TabIndex = 1791
			Me.Label5.Text = "Address :"
			Me.txtCity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(267, 112)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.[ReadOnly] = True
			Me.txtCity.Size = New Global.System.Drawing.Size(99, 21)
			Me.txtCity.TabIndex = 1785
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(267, 95)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(30, 13)
			Me.Label4.TabIndex = 1794
			Me.Label4.Text = "City :"
			Me.txtOrderNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOrderNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOrderNo.Location = New Global.System.Drawing.Point(76, 17)
			Me.txtOrderNo.Name = "txtOrderNo"
			Me.txtOrderNo.[ReadOnly] = True
			Me.txtOrderNo.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtOrderNo.TabIndex = 1805
			Me.GroupBox4.Controls.Add(Me.Label11)
			Me.GroupBox4.Controls.Add(Me.txtOrderStatus)
			Me.GroupBox4.Controls.Add(Me.txtOrderNo)
			Me.GroupBox4.Controls.Add(Me.txtOrderId)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(340, 9)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(655, 46)
			Me.GroupBox4.TabIndex = 1813
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "E-Com Order"
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(238, 9)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label11.TabIndex = 1806
			Me.Label11.Text = "Order Status :"
			Me.txtOrderStatus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOrderStatus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOrderStatus.Location = New Global.System.Drawing.Point(311, 17)
			Me.txtOrderStatus.Name = "txtOrderStatus"
			Me.txtOrderStatus.[ReadOnly] = True
			Me.txtOrderStatus.Size = New Global.System.Drawing.Size(155, 21)
			Me.txtOrderStatus.TabIndex = 1806
			Me.txtOrderId.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtOrderId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtOrderId.Location = New Global.System.Drawing.Point(9, 17)
			Me.txtOrderId.Name = "txtOrderId"
			Me.txtOrderId.[ReadOnly] = True
			Me.txtOrderId.Size = New Global.System.Drawing.Size(64, 21)
			Me.txtOrderId.TabIndex = 1804
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(151, 9)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1811
			Me.lblUser.Text = "Label3"
			Me.lblUser.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
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
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.id, Me.Orderid, Me.customer, Me.order_date, Me.address, Me.city, Me.totalamount, Me.status, Me.paymentmode, Me.Column8, Me.uid })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 61)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 35
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(307, 377)
			Me.dgw.TabIndex = 1802
			Me.dgw.TabStop = False
			Me.id.HeaderText = "ID"
			Me.id.Name = "id"
			Me.Orderid.HeaderText = "Order Id"
			Me.Orderid.Name = "Orderid"
			Me.Orderid.Width = 175
			Me.customer.HeaderText = "Customer"
			Me.customer.Name = "customer"
			Me.order_date.HeaderText = "Order Date"
			Me.order_date.Name = "order_date"
			Me.address.HeaderText = "Address"
			Me.address.Name = "address"
			Me.city.HeaderText = "City"
			Me.city.Name = "city"
			Me.totalamount.HeaderText = "Total Amount"
			Me.totalamount.Name = "totalamount"
			Me.status.HeaderText = "Status"
			Me.status.Name = "status"
			Me.paymentmode.HeaderText = "Payment Mode"
			Me.paymentmode.Name = "paymentmode"
			Me.Column8.HeaderText = "Bill Status"
			Me.Column8.Name = "Column8"
			Me.uid.HeaderText = "uid"
			Me.uid.Name = "uid"
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6
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
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column7, Me.MRP, Me.Dis, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle8
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(322, 210)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9
			Me.DataGridView1.RowHeadersWidth = 35
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle10.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle10.Font = New Global.System.Drawing.Font("Tahoma", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle10.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle10.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10
			Me.DataGridView1.RowTemplate.Height = 30
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(834, 228)
			Me.DataGridView1.TabIndex = 1803
			Me.DataGridView1.TabStop = False
			Me.DataGridViewTextBoxColumn1.HeaderText = "Pid"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.Width = 30
			Me.DataGridViewTextBoxColumn2.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.Width = 230
			Me.Column7.HeaderText = "Barcode"
			Me.Column7.Name = "Column7"
			Me.Column7.Width = 130
			Me.MRP.HeaderText = "MRP"
			Me.MRP.Name = "MRP"
			Me.Dis.HeaderText = "Dis%"
			Me.Dis.Name = "Dis"
			Me.DataGridViewTextBoxColumn3.HeaderText = "Qty"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.Width = 75
			Me.DataGridViewTextBoxColumn4.HeaderText = "Unit"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.Width = 75
			Me.DataGridViewTextBoxColumn5.HeaderText = "Sale Rate"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.Width = 105
			Me.DataGridViewTextBoxColumn6.HeaderText = "Total"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.Width = 150
			Me.RadioButton3.AutoSize = True
			Me.RadioButton3.Location = New Global.System.Drawing.Point(76, 38)
			Me.RadioButton3.Name = "RadioButton3"
			Me.RadioButton3.Size = New Global.System.Drawing.Size(71, 17)
			Me.RadioButton3.TabIndex = 1808
			Me.RadioButton3.Text = "cancelled"
			Me.RadioButton3.UseVisualStyleBackColor = True
			Me.RadioButton2.AutoSize = True
			Me.RadioButton2.Location = New Global.System.Drawing.Point(151, 38)
			Me.RadioButton2.Name = "RadioButton2"
			Me.RadioButton2.Size = New Global.System.Drawing.Size(74, 17)
			Me.RadioButton2.TabIndex = 1807
			Me.RadioButton2.Text = "completed"
			Me.RadioButton2.UseVisualStyleBackColor = True
			Me.lblCode.AutoSize = True
			Me.lblCode.Font = New Global.System.Drawing.Font("Segoe UI", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblCode.ForeColor = Global.System.Drawing.Color.Green
			Me.lblCode.Location = New Global.System.Drawing.Point(524, 316)
			Me.lblCode.Name = "lblCode"
			Me.lblCode.Size = New Global.System.Drawing.Size(16, 13)
			Me.lblCode.TabIndex = 1809
			Me.lblCode.Text = "..."
			Me.RadioButton1.AutoSize = True
			Me.RadioButton1.Checked = True
			Me.RadioButton1.Location = New Global.System.Drawing.Point(9, 38)
			Me.RadioButton1.Name = "RadioButton1"
			Me.RadioButton1.Size = New Global.System.Drawing.Size(63, 17)
			Me.RadioButton1.TabIndex = 1806
			Me.RadioButton1.TabStop = True
			Me.RadioButton1.Text = "pending"
			Me.RadioButton1.UseVisualStyleBackColor = True
			Me.btnCancle.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnCancle.BackColor = Global.System.Drawing.Color.SteelBlue
			Me.btnCancle.BackgroundImage = CType(componentResourceManager.GetObject("btnCancle.BackgroundImage"), Global.System.Drawing.Image)
			Me.btnCancle.Enabled = False
			Me.btnCancle.FlatAppearance.BorderSize = 0
			Me.btnCancle.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnCancle.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnCancle.ForeColor = Global.System.Drawing.Color.White
			Me.btnCancle.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnCancle.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnCancle.Location = New Global.System.Drawing.Point(1001, 60)
			Me.btnCancle.Name = "btnCancle"
			Me.btnCancle.Size = New Global.System.Drawing.Size(155, 46)
			Me.btnCancle.TabIndex = 1812
			Me.btnCancle.Text = "Cancelled"
			Me.btnCancle.UseVisualStyleBackColor = False
			Me.btnEcomPost.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnEcomPost.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.btnEcomPost.Enabled = False
			Me.btnEcomPost.FlatAppearance.BorderSize = 0
			Me.btnEcomPost.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnEcomPost.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnEcomPost.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.btnEcomPost.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnEcomPost.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnEcomPost.Image = CType(componentResourceManager.GetObject("btnEcomPost.Image"), Global.System.Drawing.Image)
			Me.btnEcomPost.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnEcomPost.Location = New Global.System.Drawing.Point(1001, 9)
			Me.btnEcomPost.Name = "btnEcomPost"
			Me.btnEcomPost.Size = New Global.System.Drawing.Size(155, 46)
			Me.btnEcomPost.TabIndex = 1804
			Me.btnEcomPost.Text = "Make Bill"
			Me.btnEcomPost.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnEcomPost.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.SystemColors.ButtonHighlight
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(225, 6)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(91, 27)
			Me.GelButton1.TabIndex = 1805
			Me.GelButton1.Text = "Search"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.RadioButton4.AutoSize = True
			Me.RadioButton4.Location = New Global.System.Drawing.Point(226, 38)
			Me.RadioButton4.Name = "RadioButton4"
			Me.RadioButton4.Size = New Global.System.Drawing.Size(107, 17)
			Me.RadioButton4.TabIndex = 1814
			Me.RadioButton4.Text = "Offline completed"
			Me.RadioButton4.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1165, 450)
			MyBase.Controls.Add(Me.RadioButton4)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.GroupBox4)
			MyBase.Controls.Add(Me.btnCancle)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.RadioButton3)
			MyBase.Controls.Add(Me.RadioButton2)
			MyBase.Controls.Add(Me.lblCode)
			MyBase.Controls.Add(Me.RadioButton1)
			MyBase.Controls.Add(Me.btnEcomPost)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Name = "frmOrder"
			Me.Text = "frmOrder"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000538 RID: 1336
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
