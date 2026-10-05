Namespace BillPoint
	' Token: 0x020004D0 RID: 1232
		Public Partial Class frmLoyaltySMS
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FB54 RID: 64340 RVA: 0x0096761C File Offset: 0x0096581C
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

		' Token: 0x0600FB55 RID: 64341 RVA: 0x0096766C File Offset: 0x0096586C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLoyaltySMS))
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Category = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btnGetData = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.ListBox2 = New Global.System.Windows.Forms.ListBox()
			Me.ListBox1 = New Global.System.Windows.Forms.ListBox()
			MyBase.SuspendLayout()
			Me.ColumnHeader1.Text = "Loyalty Amount"
			Me.ColumnHeader1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader1.Width = 120
			Me.Label2.AutoSize = True
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(262, 20)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 446
			Me.Label2.Text = "Customer Name :"
			Me.ColumnHeader9.Text = "No(s) of Bill"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader9.Width = 100
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Tomato
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(8, 78)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 443
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(133, 20)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label5.TabIndex = 438
			Me.Label5.Text = "To Date :"
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader6, Me.ColumnHeader7, Me.Category, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1, Me.ColumnHeader2 })
			Me.ListView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(2, 101)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(936, 358)
			Me.ListView1.TabIndex = 441
			Me.ListView1.TabStop = False
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader6.Text = "Customer Name"
			Me.ColumnHeader6.Width = 200
			Me.ColumnHeader7.Text = "Contact No."
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader7.Width = 130
			Me.Category.Text = "State"
			Me.Category.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Category.Width = 150
			Me.ColumnHeader8.Text = "GSTIN"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader8.Width = 128
			Me.ColumnHeader2.Text = "STATUS"
			Me.ColumnHeader2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader2.Width = 100
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(265, 35)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(184, 21)
			Me.cmbCustomerName.TabIndex = 439
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(5, 20)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label4.TabIndex = 437
			Me.Label4.Text = "From Date :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(136, 36)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 436
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(8, 36)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 435
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(559, 23)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(106, 39)
			Me.Button1.TabIndex = 447
			Me.Button1.Text = "Send SMS"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.btnGetData.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnGetData.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(455, 23)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(101, 40)
			Me.btnGetData.TabIndex = 440
			Me.btnGetData.Text = "&Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(668, 23)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(86, 39)
			Me.btnReset.TabIndex = 448
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(851, 20)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(23, 20)
			Me.TextBox1.TabIndex = 449
			Me.TextBox1.TabStop = False
			Me.TextBox1.Visible = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.Button3.Location = New Global.System.Drawing.Point(760, 4)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(178, 93)
			Me.Button3.TabIndex = 495
			Me.Button3.Text = "Send Bulk WhatsApp Message"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button3.UseVisualStyleBackColor = False
			Me.ListBox2.FormattingEnabled = True
			Me.ListBox2.Location = New Global.System.Drawing.Point(478, 135)
			Me.ListBox2.Name = "ListBox2"
			Me.ListBox2.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox2.TabIndex = 495
			Me.ListBox1.FormattingEnabled = True
			Me.ListBox1.Location = New Global.System.Drawing.Point(310, 135)
			Me.ListBox1.Name = "ListBox1"
			Me.ListBox1.Size = New Global.System.Drawing.Size(153, 95)
			Me.ListBox1.TabIndex = 494
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(939, 461)
			MyBase.Controls.Add(Me.ListView1)
			MyBase.Controls.Add(Me.ListBox2)
			MyBase.Controls.Add(Me.ListBox1)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.cmbCustomerName)
			MyBase.Controls.Add(Me.btnGetData)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.dtpDateTo)
			MyBase.Controls.Add(Me.dtpDateFrom)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmLoyaltySMS"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Loyalty SMS to Customer"
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006029 RID: 24617
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
