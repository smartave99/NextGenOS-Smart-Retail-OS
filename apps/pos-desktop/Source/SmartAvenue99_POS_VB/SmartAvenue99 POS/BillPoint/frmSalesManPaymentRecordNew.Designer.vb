Namespace BillPoint
	' Token: 0x0200020A RID: 522
		Public Partial Class frmSalesManPaymentRecordNew
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060097AD RID: 38829 RVA: 0x006CFBAC File Offset: 0x006CDDAC
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

		' Token: 0x060097AE RID: 38830 RVA: 0x006CFBFC File Offset: 0x006CDDFC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSalesManPaymentRecordNew))
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(62, 22)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 1
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.Column9.HeaderText = "Bank A/c No"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Remarks"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Visible = False
			Me.Column7.HeaderText = "Payment Mode Details"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 120
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.TopRight
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle
			Me.Column8.HeaderText = "Transaction Amount"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column6.HeaderText = "Customer Name"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 230
			Me.Column5.HeaderText = "Customer ID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column4.HeaderText = "Cust ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Column11.HeaderText = "Payment Mode"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			dataGridViewCellStyle2.Format = "dd/MM/yyyy"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle2
			Me.Column3.HeaderText = "Date"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column2.HeaderText = "Transaction No."
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column11, Me.Column4, Me.Column5, Me.Column6, Me.Column8, Me.Column7, Me.Column10, Me.Column9 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle5.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 130)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle7
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(992, 379)
			Me.dgw.TabIndex = 43
			Me.dgw.TabStop = False
			Me.txtCustomerName.BackColor = Global.System.Drawing.Color.White
			Me.txtCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(144, 21)
			Me.txtCustomerName.TabIndex = 3
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(143, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By SalesMan Name :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtCustomerName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(376, 54)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(168, 70)
			Me.Panel3.TabIndex = 1
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(153, 27)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(150, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(278, 18)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(81, 37)
			Me.GelButton2.TabIndex = 535
			Me.GelButton2.Text = "Get Data"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.dtpDateFrom.TabIndex = 0
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.dtpDateTo)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.GelButton2)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.dtpDateFrom)
			Me.Panel4.Location = New Global.System.Drawing.Point(9, 54)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(368, 70)
			Me.Panel4.TabIndex = 0
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(3, 17)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 536
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(112, 17)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 534
			Me.GelButton1.Text = "&Export Excel"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(530, 515)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label5.TabIndex = 55
			Me.Label5.Text = "Grand Total Amount :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(644, 512)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(150, 20)
			Me.TextBox1.TabIndex = 54
			Me.TextBox1.TabStop = False
			Me.TextBox1.Text = "0.00"
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.GelButton3)
			Me.Panel5.Controls.Add(Me.GelButton1)
			Me.Panel5.Location = New Global.System.Drawing.Point(561, 54)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(224, 70)
			Me.Panel5.TabIndex = 2
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1031, 558)
			Me.Panel1.TabIndex = 3
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(1031, 41)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(417, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(340, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "List of Sales Man Payment Receipts"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1031, 558)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Name = "frmSalesManPaymentRecordNew"
			Me.Text = "frmSalesManPaymentRecordNew"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004319 RID: 17177
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
