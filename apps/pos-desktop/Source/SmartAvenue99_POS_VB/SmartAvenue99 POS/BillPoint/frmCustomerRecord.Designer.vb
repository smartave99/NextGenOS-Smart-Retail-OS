Namespace BillPoint
	' Token: 0x020000DF RID: 223
		Public Partial Class frmCustomerRecord
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060027F5 RID: 10229 RVA: 0x00191CF0 File Offset: 0x0018FEF0
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

		' Token: 0x060027F6 RID: 10230 RVA: 0x00191D40 File Offset: 0x0018FF40
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerRecord))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.btnAddCustomer = New Global.GelButtons.GelButton()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtRoute = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column33 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.btnAddCustomer)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.lblSet)
			Me.Panel1.Controls.Add(Me.txtTopResult)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel6)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1183, 682)
			Me.Panel1.TabIndex = 2
			Me.btnAddCustomer.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnAddCustomer.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnAddCustomer.FlatAppearance.BorderSize = 0
			Me.btnAddCustomer.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAddCustomer.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAddCustomer.ForeColor = Global.System.Drawing.Color.White
			Me.btnAddCustomer.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnAddCustomer.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnAddCustomer.Image = CType(componentResourceManager.GetObject("btnAddCustomer.Image"), Global.System.Drawing.Image)
			Me.btnAddCustomer.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAddCustomer.Location = New Global.System.Drawing.Point(1054, 59)
			Me.btnAddCustomer.Name = "btnAddCustomer"
			Me.btnAddCustomer.Size = New Global.System.Drawing.Size(120, 37)
			Me.btnAddCustomer.TabIndex = 523
			Me.btnAddCustomer.Text = "Add Customer"
			Me.btnAddCustomer.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAddCustomer.UseVisualStyleBackColor = False
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(101, 17)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 432
			Me.Label6.Text = "Records"
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.txtRoute)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Location = New Global.System.Drawing.Point(624, 46)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel2.TabIndex = 51
			Me.txtRoute.BackColor = Global.System.Drawing.Color.White
			Me.txtRoute.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRoute.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtRoute.Name = "txtRoute"
			Me.txtRoute.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtRoute.TabIndex = 13
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(94, 13)
			Me.Label5.TabIndex = 12
			Me.Label5.Text = "Search By Route :"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(29, 17)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 431
			Me.Label7.Text = "Top"
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(863, 23)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 316
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.txtTopResult.Location = New Global.System.Drawing.Point(56, 14)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(43, 20)
			Me.txtTopResult.TabIndex = 430
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "10"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1183, 38)
			Me.Label1.TabIndex = 315
			Me.Label1.Text = "List of Customers"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(828, 21)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(29, 13)
			Me.lblUser.TabIndex = 314
			Me.lblUser.Text = "User"
			Me.lblUser.Visible = False
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.GelButton1)
			Me.Panel5.Controls.Add(Me.GelButton3)
			Me.Panel5.Location = New Global.System.Drawing.Point(829, 46)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(220, 70)
			Me.Panel5.TabIndex = 52
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(113, 12)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 522
			Me.GelButton1.Text = "&Export Excel"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(4, 12)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 524
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.txtContactNo)
			Me.Panel6.Controls.Add(Me.Label4)
			Me.Panel6.Location = New Global.System.Drawing.Point(419, 46)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel6.TabIndex = 50
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.White
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtContactNo.TabIndex = 13
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(122, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Contact No. :"
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.txtCity)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Location = New Global.System.Drawing.Point(214, 46)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel4.TabIndex = 49
			Me.txtCity.BackColor = Global.System.Drawing.Color.White
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtCity.TabIndex = 13
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label2.TabIndex = 12
			Me.Label2.Text = "Search By City :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtCustomerName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(9, 46)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel3.TabIndex = 48
			Me.txtCustomerName.BackColor = Global.System.Drawing.Color.White
			Me.txtCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtCustomerName.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(140, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Customer Name :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
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
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column8, Me.Column4, Me.Column6, Me.Column7, Me.Column9, Me.Column10, Me.Column5, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column11, Me.Column12, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column32, Me.Column31, Me.Column33, Me.Column34 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 122)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1165, 548)
			Me.dgw.TabIndex = 1
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "Customer ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Customer Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 150
			Me.Column8.HeaderText = "Address"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 150
			Me.Column4.HeaderText = "City"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column6.HeaderText = "State"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Postal Code"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column9.HeaderText = "Contact No."
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Email ID"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column5.HeaderText = "GSTIN/UID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column13.HeaderText = "CIN"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "PAN"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column15.HeaderText = "Account Name"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column16.HeaderText = "Account No."
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column17.HeaderText = "Bank"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column18.HeaderText = "Branch"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column19.HeaderText = "IFSC Code"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column20.HeaderText = "Remarks"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column21.HeaderText = "Opening Balance Type"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.HeaderText = "Opening Balance"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "Photo"
			Me.Column12.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column12.Visible = False
			Me.Column22.HeaderText = "TCS"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column23.HeaderText = "Loyalty Card No."
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column24.HeaderText = "LCard Status"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			dataGridViewCellStyle8.NullValue = Nothing
			Me.Column25.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column25.HeaderText = "Credit Limit"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column26.HeaderText = "Limit Status"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column27.HeaderText = "Route"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column28.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column28.HeaderText = "Turn Around Days"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column29.HeaderText = "Disc% on Items"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column30.HeaderText = "Discount Approved"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			Me.Column32.HeaderText = "Opening Loyality Type"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			Me.Column31.HeaderText = "Loyality Balance"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column33.HeaderText = "Loyality (Enable/Disable)"
			Me.Column33.Name = "Column33"
			Me.Column33.[ReadOnly] = True
			Me.Column34.HeaderText = "Shiping Address"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1183, 682)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomerRecord"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040010AC RID: 4268
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
