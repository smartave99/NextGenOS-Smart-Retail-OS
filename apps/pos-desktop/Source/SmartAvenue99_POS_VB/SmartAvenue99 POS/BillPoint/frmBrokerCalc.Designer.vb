Namespace BillPoint
	' Token: 0x02000330 RID: 816
		Public Partial Class frmBrokerCalc
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BFD1 RID: 49105 RVA: 0x007A2BAC File Offset: 0x007A0DAC
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

		' Token: 0x0600BFD2 RID: 49106 RVA: 0x007A2BFC File Offset: 0x007A0DFC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBrokerCalc))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtVID = New Global.System.Windows.Forms.TextBox()
			Me.Button9 = New Global.System.Windows.Forms.Button()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtVoucherNo = New Global.System.Windows.Forms.TextBox()
			Me.txtVoucherID = New Global.System.Windows.Forms.TextBox()
			Me.txtInvCode1 = New Global.System.Windows.Forms.TextBox()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.txtSuffix = New Global.System.Windows.Forms.TextBox()
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.PictureBox2)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.txtVID)
			Me.Panel1.Controls.Add(Me.Button9)
			Me.Panel1.Controls.Add(Me.DTP2)
			Me.Panel1.Controls.Add(Me.DTP1)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.TextBox5)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.TextBox4)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.TextBox3)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.dtpDate)
			Me.Panel1.Controls.Add(Me.txtVoucherNo)
			Me.Panel1.Controls.Add(Me.txtVoucherID)
			Me.Panel1.Controls.Add(Me.txtInvCode1)
			Me.Panel1.Controls.Add(Me.F2)
			Me.Panel1.Controls.Add(Me.F1)
			Me.Panel1.Controls.Add(Me.txtSuffix)
			Me.Panel1.Location = New Global.System.Drawing.Point(7, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(285, 287)
			Me.Panel1.TabIndex = 0
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(240, 41)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1793
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(2, 227)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(70, 54)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox2.TabIndex = 1792
			Me.PictureBox2.TabStop = False
			Me.Label8.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(11, 10)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(257, 30)
			Me.Label8.TabIndex = 1791
			Me.Label8.Text = "Broker Payment"
			Me.Label8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtVID.Location = New Global.System.Drawing.Point(12, 246)
			Me.txtVID.Name = "txtVID"
			Me.txtVID.[ReadOnly] = True
			Me.txtVID.Size = New Global.System.Drawing.Size(68, 20)
			Me.txtVID.TabIndex = 1790
			Me.txtVID.TabStop = False
			Me.txtVID.Visible = False
			Me.Button9.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button9.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button9.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button9.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button9.ForeColor = Global.System.Drawing.Color.White
			Me.Button9.Location = New Global.System.Drawing.Point(138, 246)
			Me.Button9.Name = "Button9"
			Me.Button9.Size = New Global.System.Drawing.Size(128, 35)
			Me.Button9.TabIndex = 1789
			Me.Button9.Text = "Pay - F12"
			Me.Button9.UseVisualStyleBackColor = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(165, 16)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 1788
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(51, 15)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 1787
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(18, 211)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label7.TabIndex = 1786
			Me.Label7.Text = "Note :"
			Me.TextBox5.Location = New Global.System.Drawing.Point(138, 211)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(128, 20)
			Me.TextBox5.TabIndex = 1785
			Me.TextBox5.TabStop = False
			Me.TextBox5.Text = "Expenses (Direct/Indirect)"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(18, 185)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label6.TabIndex = 1784
			Me.Label6.Text = "Amount :"
			Me.TextBox4.Location = New Global.System.Drawing.Point(138, 185)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(128, 20)
			Me.TextBox4.TabIndex = 1783
			Me.TextBox4.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(18, 159)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label5.TabIndex = 1782
			Me.Label5.Text = "Particulars :"
			Me.TextBox3.Location = New Global.System.Drawing.Point(138, 159)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(128, 20)
			Me.TextBox3.TabIndex = 1781
			Me.TextBox3.TabStop = False
			Me.TextBox3.Text = "Broker Payment"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(18, 133)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label4.TabIndex = 1780
			Me.Label4.Text = "Details :"
			Me.TextBox2.Location = New Global.System.Drawing.Point(138, 133)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(128, 20)
			Me.TextBox2.TabIndex = 1779
			Me.TextBox2.TabStop = False
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(18, 107)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label3.TabIndex = 1778
			Me.Label3.Text = "Name :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(18, 82)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label2.TabIndex = 1777
			Me.Label2.Text = "Date :"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(18, 57)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label1.TabIndex = 1776
			Me.Label1.Text = "Voucher No. :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(138, 107)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(128, 20)
			Me.TextBox1.TabIndex = 1775
			Me.TextBox1.TabStop = False
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(138, 82)
			Me.dtpDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(128, 20)
			Me.dtpDate.TabIndex = 1773
			Me.dtpDate.TabStop = False
			Me.txtVoucherNo.Location = New Global.System.Drawing.Point(138, 57)
			Me.txtVoucherNo.Name = "txtVoucherNo"
			Me.txtVoucherNo.[ReadOnly] = True
			Me.txtVoucherNo.Size = New Global.System.Drawing.Size(128, 20)
			Me.txtVoucherNo.TabIndex = 1772
			Me.txtVoucherNo.TabStop = False
			Me.txtVoucherID.Location = New Global.System.Drawing.Point(166, 20)
			Me.txtVoucherID.Name = "txtVoucherID"
			Me.txtVoucherID.[ReadOnly] = True
			Me.txtVoucherID.Size = New Global.System.Drawing.Size(32, 20)
			Me.txtVoucherID.TabIndex = 1774
			Me.txtVoucherID.TabStop = False
			Me.txtVoucherID.Visible = False
			Me.txtInvCode1.Location = New Global.System.Drawing.Point(118, 20)
			Me.txtInvCode1.Name = "txtInvCode1"
			Me.txtInvCode1.[ReadOnly] = True
			Me.txtInvCode1.Size = New Global.System.Drawing.Size(42, 20)
			Me.txtInvCode1.TabIndex = 1771
			Me.txtInvCode1.TabStop = False
			Me.txtInvCode1.Visible = False
			Me.F2.Location = New Global.System.Drawing.Point(44, 20)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1770
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(9, 20)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1769
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.txtSuffix.Location = New Global.System.Drawing.Point(79, 20)
			Me.txtSuffix.Name = "txtSuffix"
			Me.txtSuffix.[ReadOnly] = True
			Me.txtSuffix.Size = New Global.System.Drawing.Size(33, 20)
			Me.txtSuffix.TabIndex = 1768
			Me.txtSuffix.TabStop = False
			Me.txtSuffix.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(299, 301)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmBrokerCalc"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004CDA RID: 19674
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
