Namespace BillPoint
	' Token: 0x020005BF RID: 1471
		Public Partial Class frmPurchaseReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011E3F RID: 73279 RVA: 0x00A4E83C File Offset: 0x00A4CA3C
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

		' Token: 0x06011E40 RID: 73280 RVA: 0x00A4E88C File Offset: 0x00A4CA8C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPurchaseReport))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton6 = New Global.GelButtons.GelButton()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.GelButton5 = New Global.GelButtons.GelButton()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(698, 360)
			Me.Panel1.TabIndex = 2
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.GelButton1)
			Me.Panel4.Controls.Add(Me.GelButton6)
			Me.Panel4.Controls.Add(Me.GelButton4)
			Me.Panel4.Controls.Add(Me.GelButton5)
			Me.Panel4.Controls.Add(Me.btnGetData)
			Me.Panel4.Controls.Add(Me.Button1)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.ComboBox2)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.ComboBox1)
			Me.Panel4.Controls.Add(Me.cmbProductName)
			Me.Panel4.Controls.Add(Me.cmbCategory)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.dtpDateTo)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.dtpDateFrom)
			Me.Panel4.Location = New Global.System.Drawing.Point(8, 55)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(471, 266)
			Me.Panel4.TabIndex = 47
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(278, 220)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(118, 37)
			Me.GelButton1.TabIndex = 548
			Me.GelButton1.Text = "View Report"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton6.FlatAppearance.BorderSize = 0
			Me.GelButton6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton6.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton6.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton6.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton6.Image = CType(componentResourceManager.GetObject("GelButton6.Image"), Global.System.Drawing.Image)
			Me.GelButton6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton6.Location = New Global.System.Drawing.Point(278, 170)
			Me.GelButton6.Name = "GelButton6"
			Me.GelButton6.Size = New Global.System.Drawing.Size(118, 37)
			Me.GelButton6.TabIndex = 547
			Me.GelButton6.Text = "View Report"
			Me.GelButton6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton6.UseVisualStyleBackColor = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(278, 117)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(118, 37)
			Me.GelButton4.TabIndex = 545
			Me.GelButton4.Text = "View Report"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.GelButton5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton5.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton5.FlatAppearance.BorderSize = 0
			Me.GelButton5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton5.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton5.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton5.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton5.Image = CType(componentResourceManager.GetObject("GelButton5.Image"), Global.System.Drawing.Image)
			Me.GelButton5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton5.Location = New Global.System.Drawing.Point(278, 67)
			Me.GelButton5.Name = "GelButton5"
			Me.GelButton5.Size = New Global.System.Drawing.Size(118, 37)
			Me.GelButton5.TabIndex = 544
			Me.GelButton5.Text = "View Report"
			Me.GelButton5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton5.UseVisualStyleBackColor = False
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetData.FlatAppearance.BorderSize = 0
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(278, 24)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(118, 37)
			Me.btnGetData.TabIndex = 543
			Me.btnGetData.Text = "View Report"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
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
			Me.Button1.Location = New Global.System.Drawing.Point(278, 24)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(118, 37)
			Me.Button1.TabIndex = 542
			Me.Button1.Text = "View Report"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(10, 210)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(110, 13)
			Me.Label7.TabIndex = 26
			Me.Label7.Text = "Search By Tax Type :"
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "GST", "NON GST" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(13, 226)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(259, 28)
			Me.ComboBox2.TabIndex = 24
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(10, 160)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(134, 13)
			Me.Label6.TabIndex = 24
			Me.Label6.Text = "Search By Supplier Name :"
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Location = New Global.System.Drawing.Point(13, 176)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(259, 28)
			Me.ComboBox1.TabIndex = 22
			Me.cmbProductName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbProductName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.Location = New Global.System.Drawing.Point(13, 123)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(259, 28)
			Me.cmbProductName.TabIndex = 20
			Me.cmbCategory.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbCategory.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCategory.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(13, 73)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(259, 28)
			Me.cmbCategory.TabIndex = 18
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 107)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(96, 13)
			Me.Label5.TabIndex = 17
			Me.Label5.Text = "By Product Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 56)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label3.TabIndex = 16
			Me.Label3.Text = "By Category :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(153, 27)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 14
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(150, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(13, 27)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 11
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.GelButton3)
			Me.Panel5.Location = New Global.System.Drawing.Point(485, 55)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(192, 266)
			Me.Panel5.TabIndex = 46
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(17, 96)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(156, 55)
			Me.GelButton3.TabIndex = 543
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-2, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(699, 32)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(242, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(176, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Purchases Report"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(698, 360)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPurchaseReport"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006B89 RID: 27529
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
