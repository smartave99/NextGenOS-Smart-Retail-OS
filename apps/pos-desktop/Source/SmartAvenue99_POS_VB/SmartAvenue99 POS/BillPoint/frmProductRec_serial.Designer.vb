Namespace BillPoint
	' Token: 0x020001DF RID: 479
		Public Partial Class frmProductRec_serial
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06008033 RID: 32819 RVA: 0x005EFF84 File Offset: 0x005EE184
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

		' Token: 0x06008034 RID: 32820 RVA: 0x005EFFD4 File Offset: 0x005EE1D4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductRec_serial))
			Me.txtBar = New Global.System.Windows.Forms.TextBox()
			Me.txtBarcodeTempStock = New Global.System.Windows.Forms.TextBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButtonNewRecord = New Global.GelButtons.GelButton()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtSerialno2 = New Global.System.Windows.Forms.TextBox()
			Me.btnUpdate = New Global.System.Windows.Forms.Button()
			Me.txtSerialno1 = New Global.System.Windows.Forms.TextBox()
			Me.chkScanner = New Global.System.Windows.Forms.CheckBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblInvoiceno = New Global.System.Windows.Forms.Label()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.lblstatus = New Global.System.Windows.Forms.Label()
			Me.PID = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.TempBarcode = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Serial_no = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Serial_no2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.txtBar.Location = New Global.System.Drawing.Point(581, 5)
			Me.txtBar.Name = "txtBar"
			Me.txtBar.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBar.TabIndex = 438
			Me.txtBar.Visible = False
			Me.txtBarcodeTempStock.Location = New Global.System.Drawing.Point(25, 508)
			Me.txtBarcodeTempStock.Name = "txtBarcodeTempStock"
			Me.txtBarcodeTempStock.Size = New Global.System.Drawing.Size(48, 20)
			Me.txtBarcodeTempStock.TabIndex = 439
			Me.txtBarcodeTempStock.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(470, 5)
			Me.txtID.Name = "txtID"
			Me.txtID.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtID.TabIndex = 440
			Me.txtID.Visible = False
			Me.txtProductCode.Location = New Global.System.Drawing.Point(597, 5)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtProductCode.TabIndex = 1801
			Me.txtProductCode.Visible = False
			Me.txtNP.Location = New Global.System.Drawing.Point(475, 5)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtNP.TabIndex = 1802
			Me.txtNP.Visible = False
			Me.txtBarcode.Location = New Global.System.Drawing.Point(99, 485)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBarcode.TabIndex = 1803
			Me.txtBarcode.Visible = False
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(576, 12)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(121, 21)
			Me.cmbNP.TabIndex = 1804
			Me.cmbNP.Visible = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.FromArgb(128, 128, 255)
			Me.DataGridView2.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView2.ColumnHeadersHeight = 40
			Me.DataGridView2.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.PID, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.TempBarcode, Me.Serial_no, Me.Serial_no2 })
			Me.DataGridView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView2.EnableHeadersVisualStyles = False
			Me.DataGridView2.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView2.Location = New Global.System.Drawing.Point(6, 80)
			Me.DataGridView2.MultiSelect = False
			Me.DataGridView2.Name = "DataGridView2"
			Me.DataGridView2.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.RowHeadersWidth = 25
			Me.DataGridView2.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView2.RowTemplate.Height = 30
			Me.DataGridView2.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.CellSelect
			Me.DataGridView2.Size = New Global.System.Drawing.Size(737, 375)
			Me.DataGridView2.TabIndex = 1807
			Me.DataGridView2.TabStop = False
			Me.Label14.AutoSize = True
			Me.Label14.Location = New Global.System.Drawing.Point(79, 511)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label14.TabIndex = 1808
			Me.Label14.Text = "Label14"
			Me.Label13.AutoSize = True
			Me.Label13.Location = New Global.System.Drawing.Point(28, 492)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(45, 13)
			Me.Label13.TabIndex = 1809
			Me.Label13.Text = "Label13"
			Me.DataGridViewImageColumn1.DataPropertyName = "Photo"
			Me.DataGridViewImageColumn1.FillWeight = 27.62098F
			Me.DataGridViewImageColumn1.HeaderText = "Photo"
			Me.DataGridViewImageColumn1.Image = Global.BillPoint.My.Resources.Resources._1__16_
			Me.DataGridViewImageColumn1.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.Visible = False
			Me.DataGridViewImageColumn1.Width = 61
			Me.pbgiftqr.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.pbgiftqr.Image = Global.BillPoint.My.Resources.Resources.Noimage
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(205, 485)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(45, 28)
			Me.pbgiftqr.TabIndex = 1800
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.Enabled = False
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(595, 459)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(144, 51)
			Me.GelButton1.TabIndex = 1806
			Me.GelButton1.Text = "Serial Sattle"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButtonNewRecord.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButtonNewRecord.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButtonNewRecord.FlatAppearance.BorderSize = 0
			Me.GelButtonNewRecord.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButtonNewRecord.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButtonNewRecord.ForeColor = Global.System.Drawing.Color.White
			Me.GelButtonNewRecord.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButtonNewRecord.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButtonNewRecord.Image = CType(componentResourceManager.GetObject("GelButtonNewRecord.Image"), Global.System.Drawing.Image)
			Me.GelButtonNewRecord.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButtonNewRecord.Location = New Global.System.Drawing.Point(365, 459)
			Me.GelButtonNewRecord.Name = "GelButtonNewRecord"
			Me.GelButtonNewRecord.Size = New Global.System.Drawing.Size(108, 51)
			Me.GelButtonNewRecord.TabIndex = 1805
			Me.GelButtonNewRecord.Text = "New"
			Me.GelButtonNewRecord.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButtonNewRecord.UseVisualStyleBackColor = False
			Me.GelButtonNewRecord.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(202, 10)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label2.TabIndex = 1814
			Me.Label2.Text = "Serial No. 2"
			Me.Label2.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(3, 10)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label1.TabIndex = 1813
			Me.Label1.Text = "Serial No."
			Me.txtSerialno2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSerialno2.Location = New Global.System.Drawing.Point(205, 26)
			Me.txtSerialno2.Name = "txtSerialno2"
			Me.txtSerialno2.Size = New Global.System.Drawing.Size(193, 30)
			Me.txtSerialno2.TabIndex = 1812
			Me.txtSerialno2.Visible = False
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.Red
			Me.btnUpdate.Location = New Global.System.Drawing.Point(404, 18)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(220, 40)
			Me.btnUpdate.TabIndex = 1811
			Me.btnUpdate.Text = "Click Here For Serial No. Update"
			Me.btnUpdate.UseVisualStyleBackColor = True
			Me.txtSerialno1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSerialno1.Location = New Global.System.Drawing.Point(6, 26)
			Me.txtSerialno1.Name = "txtSerialno1"
			Me.txtSerialno1.Size = New Global.System.Drawing.Size(193, 30)
			Me.txtSerialno1.TabIndex = 1810
			Me.chkScanner.AutoSize = True
			Me.chkScanner.Location = New Global.System.Drawing.Point(6, 62)
			Me.chkScanner.Name = "chkScanner"
			Me.chkScanner.Size = New Global.System.Drawing.Size(118, 17)
			Me.chkScanner.TabIndex = 1815
			Me.chkScanner.Text = "Check For Scanner"
			Me.chkScanner.UseVisualStyleBackColor = True
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(316, 473)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 1816
			Me.lblUser.Text = "Label3"
			Me.lblUser.Visible = False
			Me.lblInvoiceno.AutoSize = True
			Me.lblInvoiceno.Location = New Global.System.Drawing.Point(316, 490)
			Me.lblInvoiceno.Name = "lblInvoiceno"
			Me.lblInvoiceno.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblInvoiceno.TabIndex = 1817
			Me.lblInvoiceno.Text = "Label3"
			Me.lblInvoiceno.Visible = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(479, 459)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(110, 51)
			Me.GelButton2.TabIndex = 1818
			Me.GelButton2.Text = "Update"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.lblstatus.AutoSize = True
			Me.lblstatus.Location = New Global.System.Drawing.Point(265, 490)
			Me.lblstatus.Name = "lblstatus"
			Me.lblstatus.Size = New Global.System.Drawing.Size(45, 13)
			Me.lblstatus.TabIndex = 1819
			Me.lblstatus.Text = "lblstatus"
			Me.lblstatus.Visible = False
			Me.PID.DataPropertyName = "PID"
			Me.PID.HeaderText = "PID"
			Me.PID.Name = "PID"
			Me.PID.Visible = False
			Me.DataGridViewTextBoxColumn2.DataPropertyName = "ProductCode"
			Me.DataGridViewTextBoxColumn2.FillWeight = 153.7454F
			Me.DataGridViewTextBoxColumn2.HeaderText = "Product Code"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn3.DataPropertyName = "Productname"
			Me.DataGridViewTextBoxColumn3.FillWeight = 189.549F
			Me.DataGridViewTextBoxColumn3.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.TempBarcode.DataPropertyName = "TempBarcode"
			Me.TempBarcode.FillWeight = 145.2331F
			Me.TempBarcode.HeaderText = "Barcode"
			Me.TempBarcode.Name = "TempBarcode"
			Me.TempBarcode.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Serial_no.DataPropertyName = "Serial_no"
			Me.Serial_no.FillWeight = 154.6019F
			Me.Serial_no.HeaderText = "Serial No"
			Me.Serial_no.Name = "Serial_no"
			Me.Serial_no2.DataPropertyName = "Serial_no2"
			Me.Serial_no2.FillWeight = 147.2518F
			Me.Serial_no2.HeaderText = "Serial_no2"
			Me.Serial_no2.Name = "Serial_no2"
			Me.Serial_no2.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(736, 508)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.lblstatus)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.lblInvoiceno)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.chkScanner)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtSerialno2)
			MyBase.Controls.Add(Me.btnUpdate)
			MyBase.Controls.Add(Me.txtSerialno1)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.Label13)
			MyBase.Controls.Add(Me.Label14)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.GelButtonNewRecord)
			MyBase.Controls.Add(Me.cmbNP)
			MyBase.Controls.Add(Me.txtBarcode)
			MyBase.Controls.Add(Me.txtNP)
			MyBase.Controls.Add(Me.txtProductCode)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.txtBarcodeTempStock)
			MyBase.Controls.Add(Me.txtBar)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.Fixed3D
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmProductRec_serial"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400389A RID: 14490
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
