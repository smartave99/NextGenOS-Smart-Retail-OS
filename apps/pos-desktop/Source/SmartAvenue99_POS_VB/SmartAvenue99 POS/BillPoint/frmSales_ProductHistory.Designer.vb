Namespace BillPoint
	' Token: 0x020001F7 RID: 503
		Public Partial Class frmSales_ProductHistory
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06008FB7 RID: 36791 RVA: 0x0068C228 File Offset: 0x0068A428
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

		' Token: 0x06008FB8 RID: 36792 RVA: 0x0068C278 File Offset: 0x0068A478
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
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
			Dim dataGridViewCellStyle14 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle15 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle16 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle17 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle18 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSales_ProductHistory))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.lblCustomerId = New Global.System.Windows.Forms.Label()
			Me.lblTotalAmount = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
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
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.txtTopResult)
			Me.Panel1.Controls.Add(Me.lblBarcode)
			Me.Panel1.Controls.Add(Me.lblCustomerId)
			Me.Panel1.Controls.Add(Me.lblTotalAmount)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1505, 627)
			Me.Panel1.TabIndex = 2
			Me.Label10.AutoSize = True
			Me.Label10.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label10.ForeColor = Global.System.Drawing.Color.White
			Me.Label10.Location = New Global.System.Drawing.Point(90, 6)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label10.TabIndex = 438
			Me.Label10.Text = "Records"
			Me.Label11.AutoSize = True
			Me.Label11.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label11.ForeColor = Global.System.Drawing.Color.White
			Me.Label11.Location = New Global.System.Drawing.Point(18, 6)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label11.TabIndex = 437
			Me.Label11.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(45, 3)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(43, 20)
			Me.txtTopResult.TabIndex = 436
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "30"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblBarcode.Location = New Global.System.Drawing.Point(1171, 596)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(0, 13)
			Me.lblBarcode.TabIndex = 61
			Me.lblCustomerId.AutoSize = True
			Me.lblCustomerId.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblCustomerId.Location = New Global.System.Drawing.Point(1053, 596)
			Me.lblCustomerId.Name = "lblCustomerId"
			Me.lblCustomerId.Size = New Global.System.Drawing.Size(0, 13)
			Me.lblCustomerId.TabIndex = 60
			Me.lblTotalAmount.AutoSize = True
			Me.lblTotalAmount.ForeColor = Global.System.Drawing.Color.Blue
			Me.lblTotalAmount.Location = New Global.System.Drawing.Point(815, 596)
			Me.lblTotalAmount.Name = "lblTotalAmount"
			Me.lblTotalAmount.Size = New Global.System.Drawing.Size(77, 13)
			Me.lblTotalAmount.TabIndex = 59
			Me.lblTotalAmount.Text = "lblTotalAmount"
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.Crimson
			Me.Label6.Location = New Global.System.Drawing.Point(6, 596)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(253, 13)
			Me.Label6.TabIndex = 58
			Me.Label6.Text = "Info : Double lick on cell to copy the Invoice number"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column2, Me.Column3, Me.Column14, Me.Column6, Me.Column16, Me.Column17, Me.Column13, Me.Column15, Me.Column18, Me.Column4, Me.Column9, Me.Column1, Me.Column8, Me.Column5, Me.Column19, Me.Column11, Me.Column20, Me.Column12, Me.Column21, Me.Column27, Me.Column22, Me.Column7, Me.Column10, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 33)
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
			Me.dgw.Size = New Global.System.Drawing.Size(1487, 550)
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
			Me.Column14.HeaderText = "Tax Type"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column6.HeaderText = "Customer Name"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column16.HeaderText = "State"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column17.HeaderText = "GSTIN/UID"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column13.HeaderText = "Product Name"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column15.HeaderText = "HSN Code"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column18.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column18.HeaderText = "Sales Rate"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column4.HeaderText = "Qty."
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column9.HeaderText = "UOM"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column1.HeaderText = "Discount %"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column8.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column8.HeaderText = "Discount"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column5.HeaderText = "CGST %"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column19.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column19.HeaderText = "CGST"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column11.HeaderText = "SGST %"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column20.HeaderText = "SGST/UTGST"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column12.HeaderText = "IGST %"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle16
			Me.Column21.HeaderText = "IGST"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column27.DefaultCellStyle = dataGridViewCellStyle17
			Me.Column27.HeaderText = "CESS %"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column22.DefaultCellStyle = dataGridViewCellStyle18
			Me.Column22.HeaderText = "CESS"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle19
			Me.Column7.HeaderText = "Total Amount"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column10.HeaderText = "Product Code"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column23.HeaderText = "Barcode"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column24.HeaderText = "IMEI(1)"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column25.HeaderText = "IMEI(2)"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column26.HeaderText = "Description"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column28.HeaderText = "Batch/Serial"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column29.HeaderText = "Mfg Date"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column30.HeaderText = "Exp Date"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			Me.Column31.HeaderText = "Size"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column32.HeaderText = "Colour"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1521, 31)
			Me.Label1.TabIndex = 57
			Me.Label1.Text = "Product Sales History"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1505, 627)
			MyBase.Controls.Add(Me.Panel1)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSales_ProductHistory"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04003F9D RID: 16285
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
