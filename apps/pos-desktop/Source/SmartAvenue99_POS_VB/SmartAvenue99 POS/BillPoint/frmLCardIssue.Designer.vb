Namespace BillPoint
	' Token: 0x020004CF RID: 1231
		Public Partial Class frmLCardIssue
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FAF4 RID: 64244 RVA: 0x00964920 File Offset: 0x00962B20
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

		' Token: 0x0600FAF5 RID: 64245 RVA: 0x00964970 File Offset: 0x00962B70
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmLCardIssue))
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.txtBank = New Global.System.Windows.Forms.TextBox()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtSwiftCode = New Global.System.Windows.Forms.TextBox()
			Me.txtIFSCCode = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtBranchName = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtAccountName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.TabControl1 = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.FlowLayoutPanel = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.GroupBox2.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.GroupBox2.Controls.Add(Me.btnDelete)
			Me.GroupBox2.Controls.Add(Me.btnSave)
			Me.GroupBox2.Controls.Add(Me.Label16)
			Me.GroupBox2.Controls.Add(Me.ComboBox1)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.Label1)
			Me.GroupBox2.Controls.Add(Me.Label15)
			Me.GroupBox2.Controls.Add(Me.txtBank)
			Me.GroupBox2.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.txtSwiftCode)
			Me.GroupBox2.Controls.Add(Me.txtIFSCCode)
			Me.GroupBox2.Controls.Add(Me.Label6)
			Me.GroupBox2.Controls.Add(Me.txtBranchName)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.txtAccountName)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(6, 46)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(393, 220)
			Me.GroupBox2.TabIndex = 2
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Customer Details :"
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
			Me.btnDelete.Location = New Global.System.Drawing.Point(274, 172)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(103, 40)
			Me.btnDelete.TabIndex = 518
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
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
			Me.btnSave.Location = New Global.System.Drawing.Point(274, 128)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(103, 40)
			Me.btnSave.TabIndex = 517
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Label16.AutoSize = True
			Me.Label16.ForeColor = Global.System.Drawing.Color.Red
			Me.Label16.Location = New Global.System.Drawing.Point(61, 193)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label16.TabIndex = 1682
			Me.Label16.Text = "*"
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Activated", "Deactivated" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(130, 189)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(134, 21)
			Me.ComboBox1.TabIndex = 6
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(12, 189)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(43, 13)
			Me.Label4.TabIndex = 1681
			Me.Label4.Text = "Status :"
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Red
			Me.Label1.Location = New Global.System.Drawing.Point(103, 164)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "*"
			Me.Label15.AutoSize = True
			Me.Label15.ForeColor = Global.System.Drawing.Color.Red
			Me.Label15.Location = New Global.System.Drawing.Point(88, 26)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label15.TabIndex = 1677
			Me.Label15.Text = "*"
			Me.txtBank.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBank.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBank.Location = New Global.System.Drawing.Point(130, 75)
			Me.txtBank.Name = "txtBank"
			Me.txtBank.[ReadOnly] = True
			Me.txtBank.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBank.TabIndex = 2
			Me.txtBank.TabStop = False
			Me.cmbAccountNo.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbAccountNo.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(130, 20)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(246, 21)
			Me.cmbAccountNo.TabIndex = 0
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(12, 76)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(51, 13)
			Me.Label14.TabIndex = 32
			Me.Label14.Text = "Address :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(12, 23)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(71, 13)
			Me.Label5.TabIndex = 38
			Me.Label5.Text = "Customer ID :"
			Me.txtSwiftCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSwiftCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSwiftCode.Location = New Global.System.Drawing.Point(130, 131)
			Me.txtSwiftCode.Name = "txtSwiftCode"
			Me.txtSwiftCode.[ReadOnly] = True
			Me.txtSwiftCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtSwiftCode.TabIndex = 4
			Me.txtSwiftCode.TabStop = False
			Me.txtIFSCCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIFSCCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIFSCCode.Location = New Global.System.Drawing.Point(130, 160)
			Me.txtIFSCCode.Name = "txtIFSCCode"
			Me.txtIFSCCode.Size = New Global.System.Drawing.Size(134, 21)
			Me.txtIFSCCode.TabIndex = 5
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(12, 133)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(67, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Contact No :"
			Me.txtBranchName.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtBranchName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchName.Location = New Global.System.Drawing.Point(130, 102)
			Me.txtBranchName.Name = "txtBranchName"
			Me.txtBranchName.[ReadOnly] = True
			Me.txtBranchName.Size = New Global.System.Drawing.Size(246, 21)
			Me.txtBranchName.TabIndex = 3
			Me.txtBranchName.TabStop = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(12, 160)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Loyalty Card No :"
			Me.Label12.AutoSize = True
			Me.Label12.Location = New Global.System.Drawing.Point(12, 51)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label12.TabIndex = 33
			Me.Label12.Text = "Customer Name :"
			Me.txtAccountName.Location = New Global.System.Drawing.Point(130, 47)
			Me.txtAccountName.Name = "txtAccountName"
			Me.txtAccountName.[ReadOnly] = True
			Me.txtAccountName.Size = New Global.System.Drawing.Size(246, 20)
			Me.txtAccountName.TabIndex = 1
			Me.txtAccountName.TabStop = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(12, 106)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(72, 13)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "State [Code] :"
			Me.lblUser.AutoSize = True
			Me.lblUser.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblUser.ForeColor = Global.System.Drawing.Color.Black
			Me.lblUser.Location = New Global.System.Drawing.Point(20, 18)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 3
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.pbgiftqr)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.txtTopResult)
			Me.Panel1.Controls.Add(Me.CheckBox1)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.TabControl1)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1030, 469)
			Me.Panel1.TabIndex = 3
			Me.Label8.AutoSize = True
			Me.Label8.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(691, 9)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label8.TabIndex = 435
			Me.Label8.Text = "Records"
			Me.Label9.AutoSize = True
			Me.Label9.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label9.ForeColor = Global.System.Drawing.Color.White
			Me.Label9.Location = New Global.System.Drawing.Point(619, 9)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label9.TabIndex = 434
			Me.Label9.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(646, 6)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(43, 20)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Location = New Global.System.Drawing.Point(514, 53)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(86, 17)
			Me.CheckBox1.TabIndex = 414
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Show / Hide"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.Button2.BackColor = Global.System.Drawing.Color.WhiteSmoke
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(983, -1)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(41, 31)
			Me.Button2.TabIndex = 413
			Me.Button2.TabStop = False
			Me.Button2.UseVisualStyleBackColor = False
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.TabControl1.Location = New Global.System.Drawing.Point(405, 52)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New Global.System.Drawing.Size(594, 387)
			Me.TabControl1.TabIndex = 411
			Me.TabPage1.Controls.Add(Me.FlowLayoutPanel)
			Me.TabPage1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TabPage1.ForeColor = Global.System.Drawing.Color.Maroon
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(586, 361)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "Customer Record"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.FlowLayoutPanel.AutoScroll = True
			Me.FlowLayoutPanel.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.FlowLayoutPanel.Location = New Global.System.Drawing.Point(3, 3)
			Me.FlowLayoutPanel.Name = "FlowLayoutPanel"
			Me.FlowLayoutPanel.Size = New Global.System.Drawing.Size(580, 355)
			Me.FlowLayoutPanel.TabIndex = 410
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(6, 271)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(393, 167)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 408
			Me.PictureBox1.TabStop = False
			Me.Label2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(1030, 33)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "Loyalty Card Issue"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(299, 388)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(100, 90)
			Me.pbgiftqr.TabIndex = 1798
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1030, 469)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmLCardIssue"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006006 RID: 24582
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
