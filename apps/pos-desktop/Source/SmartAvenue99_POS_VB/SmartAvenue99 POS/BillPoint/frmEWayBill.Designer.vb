Namespace BillPoint
	' Token: 0x0200010C RID: 268
		Public Partial Class frmEWayBill
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002B6B RID: 11115 RVA: 0x001AC0C0 File Offset: 0x001AA2C0
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

		' Token: 0x06002B6C RID: 11116 RVA: 0x001AC110 File Offset: 0x001AA310
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmEWayBill))
			Me.txtInvoiceNo = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.TabControl1 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.txt_vehicle_number2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.btnUpdate_Vehicle = New Global.GelButtons.GelButton()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.TabPage2 = New Global.System.Windows.Forms.TabPage()
			Me.TabPage3 = New Global.System.Windows.Forms.TabPage()
			Me.btnEwaybill_Gen = New Global.GelButtons.GelButton()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtCancel_date = New Global.System.Windows.Forms.TextBox()
			Me.lblcancel = New Global.System.Windows.Forms.Label()
			Me.txt_reason_of_cancel = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.btnEwaybill_Cancel = New Global.GelButtons.GelButton()
			Me.lblUrl = New Global.System.Windows.Forms.Label()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.txtEwaybill_date = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtValidupto = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtEwaybillno = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.txt_transporter_document_date = New Global.System.Windows.Forms.TextBox()
			Me.txt_vehicle_type = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txt_vehicle_number = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txt_transportation_distance = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txt_transportation_mode = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txt_transporter_document_number = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txt_transporter_name = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtTransporterID = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.GroupBox1.SuspendLayout()
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.BackColor = Global.System.Drawing.Color.White
			label.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold)
			label.ForeColor = Global.System.Drawing.Color.Blue
			label.Location = New Global.System.Drawing.Point(12, 11)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label5"
			label.Size = New Global.System.Drawing.Size(82, 17)
			label.TabIndex = 270
			label.Text = "Invoice No :"
			label.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtInvoiceNo.BackColor = Global.System.Drawing.Color.White
			Me.txtInvoiceNo.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtInvoiceNo.Font = New Global.System.Drawing.Font("Segoe UI", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtInvoiceNo.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtInvoiceNo.Location = New Global.System.Drawing.Point(96, 12)
			Me.txtInvoiceNo.Name = "txtInvoiceNo"
			Me.txtInvoiceNo.[ReadOnly] = True
			Me.txtInvoiceNo.Size = New Global.System.Drawing.Size(181, 18)
			Me.txtInvoiceNo.TabIndex = 269
			Me.txtInvoiceNo.TabStop = False
			Me.GroupBox1.Controls.Add(Me.TabControl1)
			Me.GroupBox1.Controls.Add(Me.btnEwaybill_Gen)
			Me.GroupBox1.Controls.Add(Me.GroupBox2)
			Me.GroupBox1.Controls.Add(Me.txt_transporter_document_date)
			Me.GroupBox1.Controls.Add(Me.txt_vehicle_type)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.txt_vehicle_number)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.txt_transportation_distance)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.txt_transportation_mode)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.txt_transporter_document_number)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txt_transporter_name)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.txtTransporterID)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(15, 43)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(925, 501)
			Me.GroupBox1.TabIndex = 271
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Transportation Detail"
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Controls.Add(Me.TabPage2)
			Me.TabControl1.Controls.Add(Me.TabPage3)
			Me.TabControl1.Location = New Global.System.Drawing.Point(6, 289)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New Global.System.Drawing.Size(792, 206)
			Me.TabControl1.TabIndex = 1831
			Me.TabPage1.Controls.Add(Me.GroupBox3)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(784, 180)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Vehicle Number"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.GroupBox3.Controls.Add(Me.Label16)
			Me.GroupBox3.Controls.Add(Me.txt_vehicle_number2)
			Me.GroupBox3.Controls.Add(Me.TextBox1)
			Me.GroupBox3.Controls.Add(Me.btnUpdate_Vehicle)
			Me.GroupBox3.Controls.Add(Me.Label15)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(21, 23)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(516, 122)
			Me.GroupBox3.TabIndex = 1830
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Update e-Way Deteails"
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(31, 26)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label16.TabIndex = 1832
			Me.Label16.Text = "Vehicle Number"
			Me.txt_vehicle_number2.BackColor = Global.System.Drawing.Color.White
			Me.txt_vehicle_number2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_vehicle_number2.Location = New Global.System.Drawing.Point(34, 42)
			Me.txt_vehicle_number2.Name = "txt_vehicle_number2"
			Me.txt_vehicle_number2.Size = New Global.System.Drawing.Size(320, 21)
			Me.txt_vehicle_number2.TabIndex = 1831
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(34, 87)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(320, 21)
			Me.TextBox1.TabIndex = 1826
			Me.TextBox1.Text = "Others"
			Me.btnUpdate_Vehicle.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom
			Me.btnUpdate_Vehicle.AutoSize = True
			Me.btnUpdate_Vehicle.BackColor = Global.System.Drawing.Color.Green
			Me.btnUpdate_Vehicle.FlatAppearance.BorderSize = 0
			Me.btnUpdate_Vehicle.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate_Vehicle.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate_Vehicle.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate_Vehicle.GradientBottom = Global.System.Drawing.Color.Green
			Me.btnUpdate_Vehicle.GradientTop = Global.System.Drawing.Color.Green
			Me.btnUpdate_Vehicle.Image = CType(componentResourceManager.GetObject("btnUpdate_Vehicle.Image"), Global.System.Drawing.Image)
			Me.btnUpdate_Vehicle.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnUpdate_Vehicle.Location = New Global.System.Drawing.Point(367, 70)
			Me.btnUpdate_Vehicle.Name = "btnUpdate_Vehicle"
			Me.btnUpdate_Vehicle.Size = New Global.System.Drawing.Size(138, 38)
			Me.btnUpdate_Vehicle.TabIndex = 1826
			Me.btnUpdate_Vehicle.Text = "&E-WayBill Update"
			Me.btnUpdate_Vehicle.UseVisualStyleBackColor = False
			Me.Label15.AutoSize = True
			Me.Label15.Location = New Global.System.Drawing.Point(31, 67)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label15.TabIndex = 1827
			Me.Label15.Text = "Reason_of_cancel"
			Me.TabPage2.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage2.Size = New Global.System.Drawing.Size(784, 180)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "Extend Validity"
			Me.TabPage2.UseVisualStyleBackColor = True
			Me.TabPage3.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage3.Size = New Global.System.Drawing.Size(784, 180)
			Me.TabPage3.TabIndex = 2
			Me.TabPage3.Text = "Transporter ID"
			Me.TabPage3.UseVisualStyleBackColor = True
			Me.btnEwaybill_Gen.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom
			Me.btnEwaybill_Gen.AutoSize = True
			Me.btnEwaybill_Gen.BackColor = Global.System.Drawing.Color.Green
			Me.btnEwaybill_Gen.FlatAppearance.BorderSize = 0
			Me.btnEwaybill_Gen.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnEwaybill_Gen.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnEwaybill_Gen.ForeColor = Global.System.Drawing.Color.White
			Me.btnEwaybill_Gen.GradientBottom = Global.System.Drawing.Color.Green
			Me.btnEwaybill_Gen.GradientTop = Global.System.Drawing.Color.Green
			Me.btnEwaybill_Gen.Image = CType(componentResourceManager.GetObject("btnEwaybill_Gen.Image"), Global.System.Drawing.Image)
			Me.btnEwaybill_Gen.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnEwaybill_Gen.Location = New Global.System.Drawing.Point(775, 16)
			Me.btnEwaybill_Gen.Name = "btnEwaybill_Gen"
			Me.btnEwaybill_Gen.Size = New Global.System.Drawing.Size(137, 41)
			Me.btnEwaybill_Gen.TabIndex = 1818
			Me.btnEwaybill_Gen.Text = "&Generat E-WayBill "
			Me.btnEwaybill_Gen.UseVisualStyleBackColor = False
			Me.btnEwaybill_Gen.Visible = False
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.txtCancel_date)
			Me.GroupBox2.Controls.Add(Me.lblcancel)
			Me.GroupBox2.Controls.Add(Me.txt_reason_of_cancel)
			Me.GroupBox2.Controls.Add(Me.Label13)
			Me.GroupBox2.Controls.Add(Me.btnEwaybill_Cancel)
			Me.GroupBox2.Controls.Add(Me.lblUrl)
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.txtEwaybill_date)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.txtValidupto)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.txtEwaybillno)
			Me.GroupBox2.Controls.Add(Me.Label10)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 128)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(789, 155)
			Me.GroupBox2.TabIndex = 29
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "E-Way Bill Details"
			Me.GroupBox2.Visible = False
			Me.Label14.AutoSize = True
			Me.Label14.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 192)
			Me.Label14.Location = New Global.System.Drawing.Point(254, 122)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(365, 13)
			Me.Label14.TabIndex = 1825
			Me.Label14.Text = "Note : E-way bill can be cancelled within 24 hours of generation of e-way bill"
			Me.txtCancel_date.BackColor = Global.System.Drawing.Color.White
			Me.txtCancel_date.Enabled = False
			Me.txtCancel_date.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCancel_date.Location = New Global.System.Drawing.Point(219, 95)
			Me.txtCancel_date.Name = "txtCancel_date"
			Me.txtCancel_date.Size = New Global.System.Drawing.Size(197, 21)
			Me.txtCancel_date.TabIndex = 1823
			Me.lblcancel.AutoSize = True
			Me.lblcancel.Location = New Global.System.Drawing.Point(216, 75)
			Me.lblcancel.Name = "lblcancel"
			Me.lblcancel.Size = New Global.System.Drawing.Size(67, 13)
			Me.lblcancel.TabIndex = 1824
			Me.lblcancel.Text = "Cancel_date"
			Me.txt_reason_of_cancel.BackColor = Global.System.Drawing.Color.White
			Me.txt_reason_of_cancel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_reason_of_cancel.Location = New Global.System.Drawing.Point(422, 95)
			Me.txt_reason_of_cancel.Name = "txt_reason_of_cancel"
			Me.txt_reason_of_cancel.Size = New Global.System.Drawing.Size(197, 21)
			Me.txt_reason_of_cancel.TabIndex = 1821
			Me.txt_reason_of_cancel.Text = "Others"
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(419, 75)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(97, 13)
			Me.Label13.TabIndex = 1822
			Me.Label13.Text = "Reason_of_cancel"
			Me.btnEwaybill_Cancel.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom
			Me.btnEwaybill_Cancel.AutoSize = True
			Me.btnEwaybill_Cancel.BackColor = Global.System.Drawing.Color.Green
			Me.btnEwaybill_Cancel.FlatAppearance.BorderSize = 0
			Me.btnEwaybill_Cancel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnEwaybill_Cancel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnEwaybill_Cancel.ForeColor = Global.System.Drawing.Color.White
			Me.btnEwaybill_Cancel.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnEwaybill_Cancel.GradientTop = Global.System.Drawing.Color.Red
			Me.btnEwaybill_Cancel.Image = CType(componentResourceManager.GetObject("btnEwaybill_Cancel.Image"), Global.System.Drawing.Image)
			Me.btnEwaybill_Cancel.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnEwaybill_Cancel.Location = New Global.System.Drawing.Point(642, 71)
			Me.btnEwaybill_Cancel.Name = "btnEwaybill_Cancel"
			Me.btnEwaybill_Cancel.Size = New Global.System.Drawing.Size(137, 41)
			Me.btnEwaybill_Cancel.TabIndex = 1819
			Me.btnEwaybill_Cancel.Text = "&Cancel E-WayBill "
			Me.btnEwaybill_Cancel.UseVisualStyleBackColor = False
			Me.btnEwaybill_Cancel.Visible = False
			Me.lblUrl.AutoSize = True
			Me.lblUrl.Location = New Global.System.Drawing.Point(527, 16)
			Me.lblUrl.Name = "lblUrl"
			Me.lblUrl.Size = New Global.System.Drawing.Size(27, 13)
			Me.lblUrl.TabIndex = 1820
			Me.lblUrl.Text = "Link"
			Me.lblUrl.Visible = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom
			Me.GelButton1.AutoSize = True
			Me.GelButton1.BackColor = Global.System.Drawing.Color.Green
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Green
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.Green
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.GelButton1.Location = New Global.System.Drawing.Point(642, 27)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(138, 38)
			Me.GelButton1.TabIndex = 1819
			Me.GelButton1.Text = "&E-WayBill Download"
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.txtEwaybill_date.BackColor = Global.System.Drawing.Color.White
			Me.txtEwaybill_date.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEwaybill_date.Location = New Global.System.Drawing.Point(422, 47)
			Me.txtEwaybill_date.Name = "txtEwaybill_date"
			Me.txtEwaybill_date.Size = New Global.System.Drawing.Size(197, 21)
			Me.txtEwaybill_date.TabIndex = 33
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(419, 27)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label12.TabIndex = 34
			Me.Label12.Text = "E-Way Bill Date"
			Me.txtValidupto.BackColor = Global.System.Drawing.Color.White
			Me.txtValidupto.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtValidupto.Location = New Global.System.Drawing.Point(219, 47)
			Me.txtValidupto.Name = "txtValidupto"
			Me.txtValidupto.Size = New Global.System.Drawing.Size(197, 21)
			Me.txtValidupto.TabIndex = 31
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(216, 27)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(56, 13)
			Me.Label11.TabIndex = 32
			Me.Label11.Text = "Valid Upto"
			Me.txtEwaybillno.BackColor = Global.System.Drawing.Color.White
			Me.txtEwaybillno.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEwaybillno.Location = New Global.System.Drawing.Point(16, 47)
			Me.txtEwaybillno.Name = "txtEwaybillno"
			Me.txtEwaybillno.Size = New Global.System.Drawing.Size(197, 21)
			Me.txtEwaybillno.TabIndex = 29
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(13, 27)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label10.TabIndex = 30
			Me.Label10.Text = "E-Way Bill No."
			Me.txt_transporter_document_date.BackColor = Global.System.Drawing.Color.White
			Me.txt_transporter_document_date.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_transporter_document_date.Location = New Global.System.Drawing.Point(626, 36)
			Me.txt_transporter_document_date.Name = "txt_transporter_document_date"
			Me.txt_transporter_document_date.Size = New Global.System.Drawing.Size(136, 21)
			Me.txt_transporter_document_date.TabIndex = 28
			Me.txt_vehicle_type.BackColor = Global.System.Drawing.Color.White
			Me.txt_vehicle_type.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_vehicle_type.Location = New Global.System.Drawing.Point(447, 90)
			Me.txt_vehicle_type.Name = "txt_vehicle_type"
			Me.txt_vehicle_type.Size = New Global.System.Drawing.Size(100, 21)
			Me.txt_vehicle_type.TabIndex = 26
			Me.txt_vehicle_type.Text = "Regular"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(444, 70)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label9.TabIndex = 27
			Me.Label9.Text = "vehicle_type"
			Me.txt_vehicle_number.BackColor = Global.System.Drawing.Color.White
			Me.txt_vehicle_number.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_vehicle_number.Location = New Global.System.Drawing.Point(338, 90)
			Me.txt_vehicle_number.Name = "txt_vehicle_number"
			Me.txt_vehicle_number.Size = New Global.System.Drawing.Size(100, 21)
			Me.txt_vehicle_number.TabIndex = 24
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(335, 70)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label8.TabIndex = 25
			Me.Label8.Text = "vehicle_number"
			Me.txt_transportation_distance.BackColor = Global.System.Drawing.Color.White
			Me.txt_transportation_distance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_transportation_distance.Location = New Global.System.Drawing.Point(215, 90)
			Me.txt_transportation_distance.Name = "txt_transportation_distance"
			Me.txt_transportation_distance.Size = New Global.System.Drawing.Size(100, 21)
			Me.txt_transportation_distance.TabIndex = 22
			Me.txt_transportation_distance.Text = "0"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(212, 70)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(117, 13)
			Me.Label7.TabIndex = 23
			Me.Label7.Text = "transportation_distance"
			Me.txt_transportation_mode.BackColor = Global.System.Drawing.Color.White
			Me.txt_transportation_mode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_transportation_mode.Location = New Global.System.Drawing.Point(9, 90)
			Me.txt_transportation_mode.Name = "txt_transportation_mode"
			Me.txt_transportation_mode.Size = New Global.System.Drawing.Size(197, 21)
			Me.txt_transportation_mode.TabIndex = 20
			Me.txt_transportation_mode.Text = "Road"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(6, 70)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(103, 13)
			Me.Label6.TabIndex = 21
			Me.Label6.Text = "transportation_mode"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(623, 16)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(139, 13)
			Me.Label4.TabIndex = 19
			Me.Label4.Text = "Transporter Document Date"
			Me.txt_transporter_document_number.BackColor = Global.System.Drawing.Color.White
			Me.txt_transporter_document_number.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_transporter_document_number.Location = New Global.System.Drawing.Point(413, 36)
			Me.txt_transporter_document_number.Name = "txt_transporter_document_number"
			Me.txt_transporter_document_number.Size = New Global.System.Drawing.Size(197, 21)
			Me.txt_transporter_document_number.TabIndex = 17
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(410, 16)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(153, 13)
			Me.Label2.TabIndex = 18
			Me.Label2.Text = "Transporter Document Number"
			Me.txt_transporter_name.BackColor = Global.System.Drawing.Color.White
			Me.txt_transporter_name.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txt_transporter_name.Location = New Global.System.Drawing.Point(212, 36)
			Me.txt_transporter_name.Name = "txt_transporter_name"
			Me.txt_transporter_name.Size = New Global.System.Drawing.Size(197, 21)
			Me.txt_transporter_name.TabIndex = 15
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(209, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(92, 13)
			Me.Label1.TabIndex = 16
			Me.Label1.Text = "Transporter Name"
			Me.txtTransporterID.BackColor = Global.System.Drawing.Color.White
			Me.txtTransporterID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTransporterID.Location = New Global.System.Drawing.Point(9, 36)
			Me.txtTransporterID.Name = "txtTransporterID"
			Me.txtTransporterID.Size = New Global.System.Drawing.Size(197, 21)
			Me.txtTransporterID.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(6, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(121, 13)
			Me.Label3.TabIndex = 14
			Me.Label3.Text = "Transporter ID (GSTIN)*"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(954, 556)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(label)
			MyBase.Controls.Add(Me.txtInvoiceNo)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmEWayBill"
			Me.Text = "frmEWayBill"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400128D RID: 4749
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
