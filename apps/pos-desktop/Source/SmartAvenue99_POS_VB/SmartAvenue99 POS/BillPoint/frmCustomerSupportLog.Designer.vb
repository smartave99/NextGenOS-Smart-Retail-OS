Namespace BillPoint
	' Token: 0x020000C4 RID: 196
		Public Partial Class frmCustomerSupportLog
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001F82 RID: 8066 RVA: 0x00147BA8 File Offset: 0x00145DA8
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

		' Token: 0x06001F83 RID: 8067 RVA: 0x00147BF8 File Offset: 0x00145DF8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerSupportLog))
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtCallingNo = New Global.System.Windows.Forms.TextBox()
			Me.lbl_Result = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtCurrentStatus = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtValidity = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtSoftwareName = New Global.System.Windows.Forms.TextBox()
			Me.btnGenerate = New Global.GelButtons.GelButton()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.lblToken_Id = New Global.System.Windows.Forms.Label()
			Me.lbl_Id = New Global.System.Windows.Forms.Label()
			Me.lblMessage = New Global.System.Windows.Forms.Label()
			Me.txtIssue = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.txtCallingNo)
			Me.GroupBox1.Controls.Add(Me.lbl_Result)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.txtEmailID)
			Me.GroupBox1.Controls.Add(Me.txtContactNo)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.cmbCustomerName)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 19)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(685, 136)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Customer Details"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(416, 64)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(64, 13)
			Me.Label1.TabIndex = 1748
			Me.Label1.Text = "Calling No. :"
			Me.txtCallingNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCallingNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCallingNo.Location = New Global.System.Drawing.Point(486, 58)
			Me.txtCallingNo.Name = "txtCallingNo"
			Me.txtCallingNo.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtCallingNo.TabIndex = 1747
			Me.lbl_Result.AutoSize = True
			Me.lbl_Result.Location = New Global.System.Drawing.Point(141, 90)
			Me.lbl_Result.Name = "lbl_Result"
			Me.lbl_Result.Size = New Global.System.Drawing.Size(0, 13)
			Me.lbl_Result.TabIndex = 1746
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(57, 58)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label7.TabIndex = 1745
			Me.Label7.Text = "Registered No. :"
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(148, 83)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtEmailID.TabIndex = 1743
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(148, 56)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtContactNo.TabIndex = 1742
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(89, 86)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label6.TabIndex = 1744
			Me.Label6.Text = "Email ID :"
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(148, 29)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(513, 21)
			Me.cmbCustomerName.TabIndex = 6
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(53, 33)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(88, 13)
			Me.Label2.TabIndex = 7
			Me.Label2.Text = "Customer Name :"
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.txtCurrentStatus)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.txtValidity)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.txtSoftwareName)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(703, 19)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(473, 136)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Software Details"
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(77, 93)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label8.TabIndex = 1751
			Me.Label8.Text = "Current Status :"
			Me.txtCurrentStatus.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCurrentStatus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCurrentStatus.Location = New Global.System.Drawing.Point(165, 91)
			Me.txtCurrentStatus.Name = "txtCurrentStatus"
			Me.txtCurrentStatus.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtCurrentStatus.TabIndex = 1750
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(111, 66)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(46, 13)
			Me.Label4.TabIndex = 1749
			Me.Label4.Text = "Validity :"
			Me.txtValidity.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtValidity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtValidity.Location = New Global.System.Drawing.Point(165, 64)
			Me.txtValidity.Name = "txtValidity"
			Me.txtValidity.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtValidity.TabIndex = 1748
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(71, 35)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(86, 13)
			Me.Label3.TabIndex = 1747
			Me.Label3.Text = "Software Name :"
			Me.txtSoftwareName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtSoftwareName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSoftwareName.Location = New Global.System.Drawing.Point(165, 33)
			Me.txtSoftwareName.Name = "txtSoftwareName"
			Me.txtSoftwareName.Size = New Global.System.Drawing.Size(175, 21)
			Me.txtSoftwareName.TabIndex = 1746
			Me.btnGenerate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGenerate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGenerate.FlatAppearance.BorderSize = 0
			Me.btnGenerate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGenerate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGenerate.ForeColor = Global.System.Drawing.Color.White
			Me.btnGenerate.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnGenerate.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnGenerate.Image = CType(componentResourceManager.GetObject("btnGenerate.Image"), Global.System.Drawing.Image)
			Me.btnGenerate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGenerate.Location = New Global.System.Drawing.Point(141, 171)
			Me.btnGenerate.Name = "btnGenerate"
			Me.btnGenerate.Size = New Global.System.Drawing.Size(157, 43)
			Me.btnGenerate.TabIndex = 515
			Me.btnGenerate.Text = "Ticket Generate"
			Me.btnGenerate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGenerate.UseVisualStyleBackColor = False
			Me.GroupBox3.Controls.Add(Me.lblToken_Id)
			Me.GroupBox3.Controls.Add(Me.lbl_Id)
			Me.GroupBox3.Controls.Add(Me.lblMessage)
			Me.GroupBox3.Controls.Add(Me.txtIssue)
			Me.GroupBox3.Controls.Add(Me.btnGenerate)
			Me.GroupBox3.Controls.Add(Me.Label5)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(12, 161)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(1164, 251)
			Me.GroupBox3.TabIndex = 2
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Complain Explain"
			Me.lblToken_Id.AutoSize = True
			Me.lblToken_Id.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.25F)
			Me.lblToken_Id.Location = New Global.System.Drawing.Point(1048, 171)
			Me.lblToken_Id.Name = "lblToken_Id"
			Me.lblToken_Id.Size = New Global.System.Drawing.Size(78, 16)
			Me.lblToken_Id.TabIndex = 1751
			Me.lblToken_Id.Text = "lblToken_Id"
			Me.lblToken_Id.Visible = False
			Me.lbl_Id.AutoSize = True
			Me.lbl_Id.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.25F)
			Me.lbl_Id.Location = New Global.System.Drawing.Point(965, 171)
			Me.lbl_Id.Name = "lbl_Id"
			Me.lbl_Id.Size = New Global.System.Drawing.Size(39, 16)
			Me.lbl_Id.TabIndex = 1750
			Me.lbl_Id.Text = "lbl_Id"
			Me.lbl_Id.Visible = False
			Me.lblMessage.AutoSize = True
			Me.lblMessage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.25F)
			Me.lblMessage.Location = New Global.System.Drawing.Point(332, 151)
			Me.lblMessage.Name = "lblMessage"
			Me.lblMessage.Size = New Global.System.Drawing.Size(78, 16)
			Me.lblMessage.TabIndex = 1749
			Me.lblMessage.Text = "lblMessage"
			Me.lblMessage.Visible = False
			Me.txtIssue.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtIssue.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtIssue.Location = New Global.System.Drawing.Point(141, 36)
			Me.txtIssue.Multiline = True
			Me.txtIssue.Name = "txtIssue"
			Me.txtIssue.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtIssue.Size = New Global.System.Drawing.Size(890, 109)
			Me.txtIssue.TabIndex = 12
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(57, 39)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label5.TabIndex = 13
			Me.Label5.Text = "Explain Issue :"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1188, 424)
			MyBase.Controls.Add(Me.GroupBox3)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Name = "frmCustomerSupportLog"
			Me.Text = "Customer Support Log"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000CBF RID: 3263
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
