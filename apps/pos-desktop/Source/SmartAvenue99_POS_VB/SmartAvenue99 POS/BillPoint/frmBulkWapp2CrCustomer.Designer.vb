Namespace BillPoint
	' Token: 0x02000332 RID: 818
		Public Partial Class frmBulkWapp2CrCustomer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600C074 RID: 49268 RVA: 0x007A7FC4 File Offset: 0x007A61C4
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

		' Token: 0x0600C075 RID: 49269 RVA: 0x007A8014 File Offset: 0x007A6214
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBulkWapp2CrCustomer))
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.ListBox1 = New Global.System.Windows.Forms.ListBox()
			Me.ListBox2 = New Global.System.Windows.Forms.ListBox()
			Me.ListBox3 = New Global.System.Windows.Forms.ListBox()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(0, 192, 0)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button2.Location = New Global.System.Drawing.Point(484, 43)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(138, 52)
			Me.Button2.TabIndex = 478
			Me.Button2.Text = "Send Bulk Message"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button2.UseVisualStyleBackColor = False
			Me.ColumnHeader1.Text = "Outstanding Balance"
			Me.ColumnHeader1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader1.Width = 130
			Me.ColumnHeader7.Text = "Whatsapp Number"
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader7.Width = 120
			Me.TextBox1.Location = New Global.System.Drawing.Point(133, 54)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(23, 20)
			Me.TextBox1.TabIndex = 476
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.ColumnHeader6.Text = "Customer Name"
			Me.ColumnHeader6.Width = 220
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(173, 53)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(26, 21)
			Me.cmbCustomerName.TabIndex = 469
			Me.cmbCustomerName.TabStop = False
			Me.cmbCustomerName.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label4.Location = New Global.System.Drawing.Point(6, 27)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label4.TabIndex = 467
			Me.Label4.Text = "From Date :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(137, 43)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 466
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(9, 43)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 465
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label5.Location = New Global.System.Drawing.Point(134, 27)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label5.TabIndex = 468
			Me.Label5.Text = "To Date :"
			Me.ListView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader8 })
			Me.ListView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(3, 115)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(1137, 362)
			Me.ListView1.TabIndex = 472
			Me.ListView1.TabStop = False
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader2.Text = "Address"
			Me.ColumnHeader2.Width = 200
			Me.ColumnHeader3.Text = "State[Code]"
			Me.ColumnHeader3.Width = 150
			Me.ColumnHeader4.Text = "City"
			Me.ColumnHeader4.Width = 120
			Me.ColumnHeader5.Text = "Zip"
			Me.ColumnHeader5.Width = 90
			Me.ColumnHeader8.Text = "STATUS"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader8.Width = 100
			Me.GroupBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.GelButton1)
			Me.GroupBox1.Controls.Add(Me.GelButton3)
			Me.GroupBox1.Controls.Add(Me.GelButton2)
			Me.GroupBox1.Controls.Add(Me.chkSelectAll)
			Me.GroupBox1.Controls.Add(Me.TextBox8)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.TextBox7)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.TextBox6)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.TextBox5)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.TextBox4)
			Me.GroupBox1.Controls.Add(Me.TextBox3)
			Me.GroupBox1.Controls.Add(Me.TextBox2)
			Me.GroupBox1.Controls.Add(Me.dtpDateTo)
			Me.GroupBox1.Controls.Add(Me.Button2)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 3)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(1136, 107)
			Me.GroupBox1.TabIndex = 479
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search"
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(369, 55)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 543
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(261, 55)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton2.TabIndex = 542
			Me.GelButton2.Text = "&Get Data"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(2, 90)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 492
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.TextBox8.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox8.Location = New Global.System.Drawing.Point(262, 9)
			Me.TextBox8.Multiline = True
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBox8.Size = New Global.System.Drawing.Size(173, 40)
			Me.TextBox8.TabIndex = 490
			Me.TextBox8.Text = "Please pay as soon as possible"
			Me.Label8.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label8.AutoSize = True
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(972, 49)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label8.TabIndex = 488
			Me.Label8.Text = "Search By Zip Code :"
			Me.TextBox7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(975, 64)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox7.TabIndex = 489
			Me.Label7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(972, 11)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label7.TabIndex = 486
			Me.Label7.Text = "Search By City :"
			Me.TextBox6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox6.Location = New Global.System.Drawing.Point(975, 27)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox6.TabIndex = 487
			Me.Label6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label6.Location = New Global.System.Drawing.Point(801, 51)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label6.TabIndex = 484
			Me.Label6.Text = "Search By State :"
			Me.Label3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label3.Location = New Global.System.Drawing.Point(801, 11)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(103, 13)
			Me.Label3.TabIndex = 485
			Me.Label3.Text = "Search By Address :"
			Me.TextBox5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox5.Location = New Global.System.Drawing.Point(804, 64)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox5.TabIndex = 484
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label2.Location = New Global.System.Drawing.Point(628, 50)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(132, 13)
			Me.Label2.TabIndex = 483
			Me.Label2.Text = "Search By WhatsApp No :"
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.SystemColors.InactiveCaptionText
			Me.Label1.Location = New Global.System.Drawing.Point(628, 11)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label1.TabIndex = 482
			Me.Label1.Text = "Search By Name :"
			Me.TextBox4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox4.Location = New Global.System.Drawing.Point(804, 27)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox4.TabIndex = 481
			Me.TextBox3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox3.Location = New Global.System.Drawing.Point(631, 65)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox3.TabIndex = 480
			Me.TextBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(631, 27)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(153, 21)
			Me.TextBox2.TabIndex = 479
			Me.ListBox1.FormattingEnabled = True
			Me.ListBox1.Location = New Global.System.Drawing.Point(46, 373)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox1.TabIndex = 480
			Me.ListBox2.FormattingEnabled = True
			Me.ListBox2.Location = New Global.System.Drawing.Point(214, 373)
			Me.ListBox2.Name = "ListBox2"
			Me.ListBox2.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox2.TabIndex = 481
			Me.ListBox3.FormattingEnabled = True
			Me.ListBox3.Location = New Global.System.Drawing.Point(389, 373)
			Me.ListBox3.Name = "ListBox3"
			Me.ListBox3.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox3.TabIndex = 482
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 10F, Global.System.Drawing.FontStyle.Bold)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(484, 9)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(138, 31)
			Me.GelButton1.TabIndex = 544
			Me.GelButton1.Text = "&Send WHatsApp"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1143, 480)
			MyBase.Controls.Add(Me.ListView1)
			MyBase.Controls.Add(Me.ListBox2)
			MyBase.Controls.Add(Me.ListBox1)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.cmbCustomerName)
			MyBase.Controls.Add(Me.ListBox3)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmBulkWapp2CrCustomer"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Bulk WhatsApp Messenger to Debt Customer"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004D1B RID: 19739
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
