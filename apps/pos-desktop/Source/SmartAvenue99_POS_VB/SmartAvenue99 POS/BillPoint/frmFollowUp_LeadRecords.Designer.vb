Namespace BillPoint
	' Token: 0x02000113 RID: 275
		Public Partial Class frmFollowUp_LeadRecords
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002EC0 RID: 11968 RVA: 0x001CDB2C File Offset: 0x001CBD2C
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

		' Token: 0x06002EC1 RID: 11969 RVA: 0x001CDB7C File Offset: 0x001CBD7C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmFollowUp_LeadRecords))
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtUser = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Panel6 = New Global.System.Windows.Forms.Panel()
			Me.txtCustomer = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnSearch = New Global.System.Windows.Forms.Button()
			Me.dtpTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtLead_Id = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblId = New Global.System.Windows.Forms.Label()
			Me.Id = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnfollowup = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel6.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			MyBase.SuspendLayout()
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Id, Me.btnfollowup, Me.Column1, Me.Column5, Me.Column20, Me.Column3, Me.Column9, Me.Column6, Me.Column11, Me.Column4, Me.Column2, Me.Column7 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(7, 83)
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
			Me.dgw.Size = New Global.System.Drawing.Size(1116, 372)
			Me.dgw.TabIndex = 2
			Me.dgw.TabStop = False
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.txtUser)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Location = New Global.System.Drawing.Point(623, 7)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel2.TabIndex = 56
			Me.txtUser.BackColor = Global.System.Drawing.Color.White
			Me.txtUser.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUser.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtUser.Name = "txtUser"
			Me.txtUser.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtUser.TabIndex = 13
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(87, 13)
			Me.Label5.TabIndex = 12
			Me.Label5.Text = "Search By User :"
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.Label6)
			Me.Panel5.Controls.Add(Me.Label7)
			Me.Panel5.Controls.Add(Me.txtTopResult)
			Me.Panel5.Controls.Add(Me.GelButton1)
			Me.Panel5.Controls.Add(Me.GelButton3)
			Me.Panel5.Location = New Global.System.Drawing.Point(828, 7)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(220, 70)
			Me.Panel5.TabIndex = 57
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(76, 5)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 527
			Me.Label6.Text = "Records"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(4, 5)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 526
			Me.Label7.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(31, 2)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(43, 20)
			Me.txtTopResult.TabIndex = 525
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "10"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(113, 26)
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(4, 26)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 524
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.Panel6.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel6.Controls.Add(Me.txtCustomer)
			Me.Panel6.Controls.Add(Me.Label4)
			Me.Panel6.Location = New Global.System.Drawing.Point(418, 7)
			Me.Panel6.Name = "Panel6"
			Me.Panel6.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel6.TabIndex = 55
			Me.txtCustomer.BackColor = Global.System.Drawing.Color.White
			Me.txtCustomer.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomer.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCustomer.Name = "txtCustomer"
			Me.txtCustomer.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtCustomer.TabIndex = 13
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(109, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "Search By Customer :"
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.btnSearch)
			Me.Panel4.Controls.Add(Me.dtpTo)
			Me.Panel4.Controls.Add(Me.dtpFrom)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Location = New Global.System.Drawing.Point(213, 7)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel4.TabIndex = 54
			Me.btnSearch.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 192)
			Me.btnSearch.Location = New Global.System.Drawing.Point(127, 5)
			Me.btnSearch.Name = "btnSearch"
			Me.btnSearch.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnSearch.TabIndex = 1788
			Me.btnSearch.Text = "Search"
			Me.btnSearch.UseVisualStyleBackColor = False
			Me.dtpTo.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpTo.Location = New Global.System.Drawing.Point(103, 31)
			Me.dtpTo.Name = "dtpTo"
			Me.dtpTo.Size = New Global.System.Drawing.Size(98, 20)
			Me.dtpTo.TabIndex = 1787
			Me.dtpFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpFrom.Location = New Global.System.Drawing.Point(2, 31)
			Me.dtpFrom.Name = "dtpFrom"
			Me.dtpFrom.Size = New Global.System.Drawing.Size(98, 20)
			Me.dtpFrom.TabIndex = 1786
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(2, 10)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(110, 13)
			Me.Label2.TabIndex = 12
			Me.Label2.Text = "Search By Reminder :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtLead_Id)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(8, 7)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(206, 70)
			Me.Panel3.TabIndex = 53
			Me.txtLead_Id.BackColor = Global.System.Drawing.Color.White
			Me.txtLead_Id.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtLead_Id.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtLead_Id.Name = "txtLead_Id"
			Me.txtLead_Id.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtLead_Id.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(101, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Lead Id :"
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Location = New Global.System.Drawing.Point(1054, 9)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(63, 13)
			Me.lblUserType.TabIndex = 1862
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(1054, 29)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1863
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblId.AutoSize = True
			Me.lblId.Location = New Global.System.Drawing.Point(1054, 48)
			Me.lblId.Name = "lblId"
			Me.lblId.Size = New Global.System.Drawing.Size(26, 13)
			Me.lblId.TabIndex = 1864
			Me.lblId.Text = "lblId"
			Me.lblId.Visible = False
			Me.Id.HeaderText = "ID"
			Me.Id.Name = "Id"
			Me.Id.[ReadOnly] = True
			Me.Id.Visible = False
			Me.btnfollowup.HeaderText = "Status"
			Me.btnfollowup.Name = "btnfollowup"
			Me.btnfollowup.[ReadOnly] = True
			Me.btnfollowup.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnfollowup.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column1.HeaderText = "Lead ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column5.HeaderText = "Reminder On"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column20.HeaderText = "Remarks"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column3.HeaderText = "Customer Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 150
			Me.Column9.HeaderText = "Contact No."
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column6.HeaderText = "State"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.HeaderText = "Product"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column4.HeaderText = "Follow By"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column2.HeaderText = "Follow_Up Date"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column7.HeaderText = "Rating"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1133, 467)
			MyBase.Controls.Add(Me.lblId)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.Panel2)
			MyBase.Controls.Add(Me.Panel5)
			MyBase.Controls.Add(Me.Panel6)
			MyBase.Controls.Add(Me.Panel4)
			MyBase.Controls.Add(Me.Panel3)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Name = "frmFollowUp_LeadRecords"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "FollowUp Lead Records"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			Me.Panel6.ResumeLayout(False)
			Me.Panel6.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040013F6 RID: 5110
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
