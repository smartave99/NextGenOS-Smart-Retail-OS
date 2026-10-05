Namespace BillPoint
	' Token: 0x0200029B RID: 667
		Public Partial Class frmCustomerDiscRecord
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600A8D1 RID: 43217 RVA: 0x0070FC30 File Offset: 0x0070DE30
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

		' Token: 0x0600A8D2 RID: 43218 RVA: 0x0070FC80 File Offset: 0x0070DE80
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerDiscRecord))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle10 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle11 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle12 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle13 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblTotalAmount = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblTotalAmount)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1000, 627)
			Me.Panel1.TabIndex = 3
			Me.lblTotalAmount.AutoSize = True
			Me.lblTotalAmount.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblTotalAmount.Location = New Global.System.Drawing.Point(819, 603)
			Me.lblTotalAmount.Name = "lblTotalAmount"
			Me.lblTotalAmount.Size = New Global.System.Drawing.Size(77, 13)
			Me.lblTotalAmount.TabIndex = 59
			Me.lblTotalAmount.Text = "lblTotalAmount"
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Controls.Add(Me.ComboBox1)
			Me.Panel2.Location = New Global.System.Drawing.Point(345, 36)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(389, 68)
			Me.Panel2.TabIndex = 1
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(9, 11)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(146, 13)
			Me.Label3.TabIndex = 15
			Me.Label3.Text = "Select Category and Search :"
			Me.TextBox1.Location = New Global.System.Drawing.Point(164, 30)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(217, 20)
			Me.TextBox1.TabIndex = 1
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Inovice No", "Customer Name", "Customer Contact", "Broker Name", "Broker Contact" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(12, 30)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(147, 21)
			Me.ComboBox1.TabIndex = 0
			Me.GroupBox2.Controls.Add(Me.btnGetData)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 30)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(337, 76)
			Me.GroupBox2.TabIndex = 0
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Invoice Date"
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetData.FlatAppearance.BorderSize = 0
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnGetData.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(256, 37)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(75, 28)
			Me.btnGetData.TabIndex = 515
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(131, 41)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(128, 22)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(3, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(6, 41)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Location = New Global.System.Drawing.Point(733, 36)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(241, 68)
			Me.Panel5.TabIndex = 2
			Me.btnReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnReset.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnReset.FlatAppearance.BorderSize = 0
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnReset.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(6, 9)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(98, 43)
			Me.btnReset.TabIndex = 519
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(110, 9)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(122, 43)
			Me.btnExportExcel.TabIndex = 520
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column2, Me.Column3, Me.Column14, Me.Column6, Me.Column16, Me.Column17, Me.Column13, Me.Column15, Me.Column18, Me.Column4, Me.Column9, Me.Column1, Me.Column8, Me.Column5 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(9, 110)
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
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(982, 488)
			Me.dgw.TabIndex = 43
			Me.dgw.TabStop = False
			Me.Column2.HeaderText = "Invoice No."
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.HeaderText = "Invoice Date"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column14.HeaderText = "Customer Name"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column6.HeaderText = "Customer Address"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column16.HeaderText = "Contact"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column17.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column17.HeaderText = "Invoice Amount"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column13.HeaderText = "Invoice Tax Amount"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column15.HeaderText = "Approved Disc%"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle9.Format = "N2"
			Me.Column18.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column18.HeaderText = "Invoice Discount"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column4.HeaderText = "By Broker"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column9.HeaderText = "Broker Address"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column1.HeaderText = "Broker Contact"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column8.HeaderText = ""
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Visible = False
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column5.HeaderText = ""
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-6, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1005, 33)
			Me.Label1.TabIndex = 57
			Me.Label1.Text = "Customer Approved Discount Register"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1000, 627)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomerDiscRecord"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040046A3 RID: 18083
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
