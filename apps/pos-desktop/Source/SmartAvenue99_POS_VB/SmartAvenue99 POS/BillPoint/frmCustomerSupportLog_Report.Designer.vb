Namespace BillPoint
	' Token: 0x020000C7 RID: 199
		Public Partial Class frmCustomerSupportLog_Report
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060021EF RID: 8687 RVA: 0x0015AB40 File Offset: 0x00158D40
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

		' Token: 0x060021F0 RID: 8688 RVA: 0x0015AB90 File Offset: 0x00158D90
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerSupportLog_Report))
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtTokenNo = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.rdo_Closed = New Global.System.Windows.Forms.RadioButton()
			Me.rdo_Process = New Global.System.Windows.Forms.RadioButton()
			Me.rdo_Open = New Global.System.Windows.Forms.RadioButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.btnShowAll = New Global.GelButtons.GelButton()
			Me.btnSetting = New Global.GelButtons.GelButton()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel3.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtTokenNo)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(22, 12)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel3.TabIndex = 518
			Me.txtTokenNo.BackColor = Global.System.Drawing.Color.White
			Me.txtTokenNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtTokenNo.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtTokenNo.Name = "txtTokenNo"
			Me.txtTokenNo.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtTokenNo.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Token No. :"
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.rdo_Closed)
			Me.Panel6.Controls.Add(Me.rdo_Process)
			Me.Panel6.Controls.Add(Me.rdo_Open)
			Me.Panel6.Controls.Add(Me.Label4)
			Me.Panel6.Location = New Global.System.Drawing.Point(228, 12)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel6.TabIndex = 519
			Me.rdo_Closed.AutoSize = True
			Me.rdo_Closed.Location = New Global.System.Drawing.Point(134, 33)
			Me.rdo_Closed.Name = "rdo_Closed"
			Me.rdo_Closed.Size = New Global.System.Drawing.Size(57, 17)
			Me.rdo_Closed.TabIndex = 15
			Me.rdo_Closed.TabStop = True
			Me.rdo_Closed.Text = "Closed"
			Me.rdo_Closed.UseVisualStyleBackColor = True
			Me.rdo_Process.AutoSize = True
			Me.rdo_Process.Location = New Global.System.Drawing.Point(66, 33)
			Me.rdo_Process.Name = "rdo_Process"
			Me.rdo_Process.Size = New Global.System.Drawing.Size(63, 17)
			Me.rdo_Process.TabIndex = 14
			Me.rdo_Process.TabStop = True
			Me.rdo_Process.Text = "Process"
			Me.rdo_Process.UseVisualStyleBackColor = True
			Me.rdo_Open.AutoSize = True
			Me.rdo_Open.Location = New Global.System.Drawing.Point(9, 33)
			Me.rdo_Open.Name = "rdo_Open"
			Me.rdo_Open.Size = New Global.System.Drawing.Size(51, 17)
			Me.rdo_Open.TabIndex = 13
			Me.rdo_Open.TabStop = True
			Me.rdo_Open.Text = "Open"
			Me.rdo_Open.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(95, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Status :"
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(440, 12)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(337, 70)
			Me.GroupBox2.TabIndex = 520
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Date"
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
			Me.btnShowAll.Location = New Global.System.Drawing.Point(987, 50)
			Me.btnShowAll.Name = "btnShowAll"
			Me.btnShowAll.Size = New Global.System.Drawing.Size(177, 31)
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
			Me.btnSetting.Location = New Global.System.Drawing.Point(987, 17)
			Me.btnSetting.Name = "btnSetting"
			Me.btnSetting.Size = New Global.System.Drawing.Size(177, 28)
			Me.btnSetting.TabIndex = 517
			Me.btnSetting.Text = "Generate Token"
			Me.btnSetting.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSetting.UseVisualStyleBackColor = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.FromArgb(255, 224, 192)
			Me.Panel1.Controls.Add(Me.Panel6)
			Me.Panel1.Controls.Add(Me.btnSetting)
			Me.Panel1.Controls.Add(Me.btnShowAll)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1292, 100)
			Me.Panel1.TabIndex = 521
			Me.Panel2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Panel2.Controls.Add(Me.DataGridView1)
			Me.Panel2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel2.Location = New Global.System.Drawing.Point(0, 100)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1292, 416)
			Me.Panel2.TabIndex = 522
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			Me.DataGridView1.ColumnHeadersHeight = 30
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(0, 0)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1292, 416)
			Me.DataGridView1.TabIndex = 1
			Me.Column1.HeaderText = "LogID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "support_token_no"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Date"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "CurrentIssue"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column8.HeaderText = "SoftwareValidity"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column9.HeaderText = "Status"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Remarks"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Feedback"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "Rating"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1292, 516)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "frmCustomerSupportLog_Report"
			Me.Text = "Customer Support Log_Report"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000DD7 RID: 3543
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
