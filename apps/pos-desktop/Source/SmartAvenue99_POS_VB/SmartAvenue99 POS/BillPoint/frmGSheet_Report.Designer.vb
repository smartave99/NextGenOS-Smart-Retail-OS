Namespace BillPoint
	' Token: 0x0200011C RID: 284
		Public Partial Class frmGSheet_Report
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003179 RID: 12665 RVA: 0x001E9F50 File Offset: 0x001E8150
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

		' Token: 0x0600317A RID: 12666 RVA: 0x001E9FA0 File Offset: 0x001E81A0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGSheet_Report))
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.btnSetting = New Global.GelButtons.GelButton()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView1.Location = New Global.System.Drawing.Point(12, 80)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1064, 358)
			Me.DataGridView1.TabIndex = 0
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtCustomerName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(12, 4)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel3.TabIndex = 518
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
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.txtContactNo)
			Me.Panel6.Controls.Add(Me.Label4)
			Me.Panel6.Location = New Global.System.Drawing.Point(218, 4)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel6.TabIndex = 519
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
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(430, 4)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(337, 70)
			Me.GroupBox2.TabIndex = 520
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Date"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(131, 39)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(128, 20)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label1.TabIndex = 12
			Me.Label1.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 39)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
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
			Me.btnGetData.Location = New Global.System.Drawing.Point(256, 30)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(74, 30)
			Me.btnGetData.TabIndex = 516
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnShowAll.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnShowAll.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnShowAll.FlatAppearance.BorderSize = 0
			Me.btnShowAll.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnShowAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnShowAll.ForeColor = Global.System.Drawing.Color.White
			Me.btnShowAll.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnShowAll.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnShowAll.Image = CType(componentResourceManager.GetObject("btnShowAll.Image"), Global.System.Drawing.Image)
			Me.btnShowAll.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnShowAll.Location = New Global.System.Drawing.Point(773, 35)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(85, 39)
			Me.btnShowAll.TabIndex = 517
			Me.btnShowAll.Text = "Show All"
			Me.btnShowAll.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnShowAll.UseVisualStyleBackColor = False
			Me.btnSetting.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSetting.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSetting.FlatAppearance.BorderSize = 0
			Me.btnSetting.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSetting.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 10F, Global.System.Drawing.FontStyle.Bold)
			Me.btnSetting.ForeColor = Global.System.Drawing.Color.White
			Me.btnSetting.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSetting.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnSetting.Image = CType(componentResourceManager.GetObject("btnSetting.Image"), Global.System.Drawing.Image)
			Me.btnSetting.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSetting.Location = New Global.System.Drawing.Point(773, 9)
			Me.btnSetting.Name = "btnSetting"
			Me.btnSetting.Size = New Global.System.Drawing.Size(85, 22)
			Me.btnSetting.TabIndex = 517
			Me.btnSetting.Text = "Setting"
			Me.btnSetting.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSetting.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1088, 450)
			MyBase.Controls.Add(Me.btnSetting)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.btnShowAll)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Name = "frmGSheet_Report"
			Me.Text = "Google Sheet Customer"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04001538 RID: 5432
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
