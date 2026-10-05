Namespace BillPoint
	' Token: 0x0200030F RID: 783
		Public Partial Class frmBranchMaster_Bank
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600B9D8 RID: 47576 RVA: 0x00779354 File Offset: 0x00777554
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

		' Token: 0x0600B9D9 RID: 47577 RVA: 0x007793A4 File Offset: 0x007775A4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBranchMaster_Bank))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.cmbBank = New Global.System.Windows.Forms.ComboBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.txtSwiftCode = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName = New Global.System.Windows.Forms.TextBox()
			Me.txtIFSCCode = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(665, 560)
			Me.Panel1.TabIndex = 2
			Me.GroupBox2.Controls.Add(Me.btnUpdate)
			Me.GroupBox2.Controls.Add(Me.btnDelete)
			Me.GroupBox2.Controls.Add(Me.btnNew)
			Me.GroupBox2.Controls.Add(Me.btnSave)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(512, 40)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(134, 235)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(6, 107)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(122, 43)
			Me.btnUpdate.TabIndex = 521
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnDelete.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete.FlatAppearance.BorderSize = 0
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnDelete.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(6, 154)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(122, 43)
			Me.btnDelete.TabIndex = 520
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(6, 12)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(122, 43)
			Me.btnNew.TabIndex = 519
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(6, 59)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(122, 43)
			Me.btnSave.TabIndex = 518
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.cmbBank)
			Me.GroupBox1.Controls.Add(Me.Label14)
			Me.GroupBox1.Controls.Add(Me.txtContactNo)
			Me.GroupBox1.Controls.Add(Me.txtSwiftCode)
			Me.GroupBox1.Controls.Add(Me.txtAddress)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.txtBranchName)
			Me.GroupBox1.Controls.Add(Me.txtIFSCCode)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 42)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(331, 233)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Bank Information"
			Me.cmbBank.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBank.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBank.FormattingEnabled = True
			Me.cmbBank.Location = New Global.System.Drawing.Point(88, 25)
			Me.cmbBank.Name = "cmbBank"
			Me.cmbBank.Size = New Global.System.Drawing.Size(213, 21)
			Me.cmbBank.TabIndex = 0
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(6, 29)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(38, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Bank :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(88, 148)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(122, 21)
			Me.txtContactNo.TabIndex = 3
			Me.txtSwiftCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSwiftCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode.Location = New Global.System.Drawing.Point(88, 174)
			Me.txtSwiftCode.Name = "txtSwiftCode"
			Me.txtSwiftCode.Size = New Global.System.Drawing.Size(122, 21)
			Me.txtSwiftCode.TabIndex = 4
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(88, 89)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.Size = New Global.System.Drawing.Size(213, 53)
			Me.txtAddress.TabIndex = 2
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(6, 152)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Contact No. :"
			Me.txtBranchName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBranchName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName.Location = New Global.System.Drawing.Point(88, 57)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.Size = New Global.System.Drawing.Size(213, 21)
			Me.txtBranchName.TabIndex = 1
			Me.txtIFSCCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIFSCCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode.Location = New Global.System.Drawing.Point(88, 200)
			Me.txtIFSCCode.Name = "txtIFSCCode"
			Me.txtIFSCCode.Size = New Global.System.Drawing.Size(122, 21)
			Me.txtIFSCCode.TabIndex = 5
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(6, 204)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Branch Code :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(6, 109)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Address :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(6, 61)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(78, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Branch Name :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(6, 178)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "IFSC :"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(338, 195)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(341, 144)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(20, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column10, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(4, 286)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(642, 254)
			Me.dgw.TabIndex = 1
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.Column2.HeaderText = "Bank"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column10.HeaderText = "Branch Name"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Width = 114
			Me.Column3.HeaderText = "Address"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Contact No."
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "IFSC"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Branch Code"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(665, 31)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(250, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(130, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Branch Entry"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(665, 560)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmBranchMaster_Bank"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004ADA RID: 19162
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
