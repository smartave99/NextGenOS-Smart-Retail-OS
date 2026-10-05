Namespace BillPoint
	' Token: 0x020004E9 RID: 1257
		Public Partial Class frmVirtualCompany
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06010269 RID: 66153 RVA: 0x0099F9B0 File Offset: 0x0099DBB0
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

		' Token: 0x0601026A RID: 66154 RVA: 0x0099FA00 File Offset: 0x0099DC00
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmVirtualCompany))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.cmbState = New Global.System.Windows.Forms.ComboBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.txtCIN = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtGSTIN = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtEmailID = New Global.System.Windows.Forms.TextBox()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(643, 307)
			Me.Panel1.TabIndex = 0
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(433, 255)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 529
			Me.GelButton1.Text = "Save"
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(541, 256)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(74, 37)
			Me.GelButton3.TabIndex = 528
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.txtID.Location = New Global.System.Drawing.Point(525, 13)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(41, 20)
			Me.txtID.TabIndex = 16
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(11, 264)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(52, 13)
			Me.Label9.TabIndex = 15
			Me.Label9.Text = "Activate :"
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(69, 261)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(82, 21)
			Me.ComboBox1.TabIndex = 10
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.cmbState)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.txtCIN)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.txtGSTIN)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtEmailID)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtCompanyName)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(7, 41)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(612, 208)
			Me.Panel4.TabIndex = 8
			Me.cmbState.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbState.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbState.FormattingEnabled = True
			Me.cmbState.Items.AddRange(New Object() { "Jammu and Kashmir [01]", "Himachal Pradesh [02]", "Punjab [03]", "Chandigarh [04]", "Uttarakhand [05]", "Haryana [06]", "Delhi [07]", "Rajasthan [08]", "Uttar Pradesh [09]", "Bihar [10]", "Sikkim [11]", "Arunachal Pradesh [12]", "Nagaland [13]", "Manipur [14]", "Mizoram [15]", "Tripura [16]", "Meghalaya [17]", "Assam [18]", "West Bengal [19]", "Jharkhand [20]", "Odisha [21]", "Chhattisgarh [22]", "Madhya Pradesh [23]", "Gujarat [24]", "Daman and Diu [25]", "Dadra and Nagar Haveli [26]", "Maharashtra [27]", "Andhra Pradesh [28]", "Karnataka [29]", "Goa [30]", "Lakshadweep [31]", "Kerala [32]", "Tamil Nadu [33]", "Puducherry [34]", "Andaman and Nicobar Islands [35]", "Telangana [36]", "Andhra Pradesh(New) [37]", "Ladakh [38]" })
			Me.cmbState.Location = New Global.System.Drawing.Point(121, 74)
			Me.cmbState.Name = "cmbState"
			Me.cmbState.Size = New Global.System.Drawing.Size(486, 23)
			Me.cmbState.TabIndex = 2
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(121, 32)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(486, 37)
			Me.txtAddress.TabIndex = 1
			Me.txtCIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCIN.Location = New Global.System.Drawing.Point(121, 180)
			Me.txtCIN.Name = "txtCIN"
			Me.txtCIN.Size = New Global.System.Drawing.Size(486, 21)
			Me.txtCIN.TabIndex = 6
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(3, 180)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(33, 15)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "CIN :"
			Me.txtGSTIN.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtGSTIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGSTIN.Location = New Global.System.Drawing.Point(121, 154)
			Me.txtGSTIN.Name = "txtGSTIN"
			Me.txtGSTIN.Size = New Global.System.Drawing.Size(486, 21)
			Me.txtGSTIN.TabIndex = 5
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(3, 74)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(110, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "State [State Code] :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(3, 154)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(49, 15)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "GSTIN :"
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(3, 128)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Email ID :"
			Me.txtEmailID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtEmailID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtEmailID.Location = New Global.System.Drawing.Point(121, 128)
			Me.txtEmailID.Name = "txtEmailID"
			Me.txtEmailID.Size = New Global.System.Drawing.Size(486, 21)
			Me.txtEmailID.TabIndex = 4
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(121, 102)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(486, 21)
			Me.txtContactNo.TabIndex = 3
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 102)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label4.TabIndex = 6
			Me.Label4.Text = "Contact No. :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(3, 32)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Address :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(3, 6)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(102, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Company Name :"
			Me.txtCompanyName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCompanyName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(121, 6)
			Me.txtCompanyName.Name = "txtCompanyName"
			Me.txtCompanyName.Size = New Global.System.Drawing.Size(486, 21)
			Me.txtCompanyName.TabIndex = 0
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(652, 32)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Virtual Company Info for Estimate Bill"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(643, 307)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmVirtualCompany"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400631A RID: 25370
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
