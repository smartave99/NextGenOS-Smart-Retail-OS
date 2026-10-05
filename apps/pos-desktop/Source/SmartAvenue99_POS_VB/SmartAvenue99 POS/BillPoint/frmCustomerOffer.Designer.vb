Namespace BillPoint
	' Token: 0x020004BA RID: 1210
		Public Partial Class frmCustomerOffer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F2AF RID: 62127 RVA: 0x00919BF0 File Offset: 0x00917DF0
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

		' Token: 0x0600F2B0 RID: 62128 RVA: 0x00919C40 File Offset: 0x00917E40
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerOffer))
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.txtMessage = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.ListBox1 = New Global.System.Windows.Forms.ListBox()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			MyBase.SuspendLayout()
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.Black
			Me.Label5.Location = New Global.System.Drawing.Point(137, 22)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label5.TabIndex = 425
			Me.Label5.Text = "To Date :"
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Black
			Me.Label4.Location = New Global.System.Drawing.Point(9, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label4.TabIndex = 424
			Me.Label4.Text = "From Date :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(140, 38)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(12, 38)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(272, 37)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(168, 21)
			Me.cmbCustomerName.TabIndex = 2
			Me.ListView1.BackColor = Global.System.Drawing.Color.Cyan
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader6, Me.ColumnHeader7, Me.Category, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1, Me.ColumnHeader2 })
			Me.ListView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(2, 116)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(946, 343)
			Me.ListView1.TabIndex = 428
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader6.Text = "Customer Name"
			Me.ColumnHeader6.Width = 220
			Me.ColumnHeader7.Text = "Contact No."
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader7.Width = 125
			Me.Category.Text = "State"
			Me.Category.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Category.Width = 155
			Me.ColumnHeader8.Text = "GSTIN"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader8.Width = 120
			Me.ColumnHeader9.Text = "No(s) of Bill"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader1.Text = "Total Sale Amount"
			Me.ColumnHeader1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader1.Width = 120
			Me.ColumnHeader2.Text = "STATUS"
			Me.ColumnHeader2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader2.Width = 100
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Lime
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.Black
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(12, 93)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 429
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.txtMessage.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtMessage.Location = New Global.System.Drawing.Point(552, 22)
			Me.txtMessage.Multiline = True
			Me.txtMessage.Name = "txtMessage"
			Me.txtMessage.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtMessage.Size = New Global.System.Drawing.Size(119, 92)
			Me.txtMessage.TabIndex = 4
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(549, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label1.TabIndex = 432
			Me.Label1.Text = "Text Message :"
			Me.Button6.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button6.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button6.ForeColor = Global.System.Drawing.Color.White
			Me.Button6.Image = CType(componentResourceManager.GetObject("Button6.Image"), Global.System.Drawing.Image)
			Me.Button6.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button6.Location = New Global.System.Drawing.Point(677, 21)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(87, 93)
			Me.Button6.TabIndex = 5
			Me.Button6.Text = "Send Bulk SMS"
			Me.Button6.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button6.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(269, 22)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 433
			Me.Label2.Text = "Customer Name :"
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(770, 21)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(177, 93)
			Me.Button3.TabIndex = 7
			Me.Button3.Text = "Send  WhatsApp Bulk Message"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageAboveText
			Me.Button3.UseVisualStyleBackColor = False
			Me.ListBox1.FormattingEnabled = True
			Me.ListBox1.Location = New Global.System.Drawing.Point(399, 183)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox1.TabIndex = 498
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(444, 69)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 545
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
			Me.GelButton2.Location = New Global.System.Drawing.Point(444, 26)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton2.TabIndex = 544
			Me.GelButton2.Text = "&Get Data"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(950, 461)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.ListView1)
			MyBase.Controls.Add(Me.ListBox1)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtMessage)
			MyBase.Controls.Add(Me.Button6)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.cmbCustomerName)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.dtpDateTo)
			MyBase.Controls.Add(Me.dtpDateFrom)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomerOffer"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Bulk SMS to Customer"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04005CB0 RID: 23728
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
