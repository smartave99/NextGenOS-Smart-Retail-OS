Namespace BillPoint
	' Token: 0x020002A9 RID: 681
		Public Partial Class frmMRPShow
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600AE05 RID: 44549 RVA: 0x00742F6C File Offset: 0x0074116C
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

		' Token: 0x0600AE06 RID: 44550 RVA: 0x00742FBC File Offset: 0x007411BC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmMRPShow))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblPOSPanel = New Global.System.Windows.Forms.Label()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.NumericUpDown1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.lblRateType = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			CType(Me.NumericUpDown1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Controls.Add(Me.lblPOSPanel)
			Me.Panel1.Controls.Add(Me.lblBarcode)
			Me.Panel1.Controls.Add(Me.Button1)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.NumericUpDown1)
			Me.Panel1.Controls.Add(Me.ComboBox1)
			Me.Panel1.Controls.Add(Me.lblRateType)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 32)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(882, 265)
			Me.Panel1.TabIndex = 0
			Me.lblPOSPanel.AutoSize = True
			Me.lblPOSPanel.Location = New Global.System.Drawing.Point(374, 245)
			Me.lblPOSPanel.Name = "lblPOSPanel"
			Me.lblPOSPanel.Size = New Global.System.Drawing.Size(66, 13)
			Me.lblPOSPanel.TabIndex = 439
			Me.lblPOSPanel.Text = "lblPOSPanel"
			Me.lblPOSPanel.Visible = False
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblBarcode.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.lblBarcode.Location = New Global.System.Drawing.Point(449, 7)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(54, 21)
			Me.lblBarcode.TabIndex = 432
			Me.lblBarcode.Text = "..........."
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.Coral
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.Location = New Global.System.Drawing.Point(586, 229)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(29, 29)
			Me.Button1.TabIndex = 438
			Me.Button1.TabStop = False
			Me.Button1.UseVisualStyleBackColor = True
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(700, 12)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label6.TabIndex = 433
			Me.Label6.Text = "Customer Type :"
			Me.Label6.Visible = False
			Me.NumericUpDown1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.NumericUpDown1.Location = New Global.System.Drawing.Point(37, 235)
			Me.NumericUpDown1.Name = "NumericUpDown1"
			Me.NumericUpDown1.Size = New Global.System.Drawing.Size(46, 20)
			Me.NumericUpDown1.TabIndex = 432
			Me.NumericUpDown1.TabStop = False
			Me.NumericUpDown1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Dim numericUpDown As Global.System.Windows.Forms.NumericUpDown = Me.NumericUpDown1
			Dim array As Integer() = New Integer(3) {}
			array(0) = 5
			numericUpDown.Value = New Decimal(array)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Colour", "Size", "Info", "Batch", "Mfg Date", "Exp Date", "IMEI-1", "IMEI-2" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(643, 237)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(102, 21)
			Me.ComboBox1.TabIndex = 436
			Me.ComboBox1.TabStop = False
			Me.lblRateType.AutoSize = True
			Me.lblRateType.ForeColor = Global.System.Drawing.Color.White
			Me.lblRateType.Location = New Global.System.Drawing.Point(790, 12)
			Me.lblRateType.Name = "lblRateType"
			Me.lblRateType.Size = New Global.System.Drawing.Size(64, 13)
			Me.lblRateType.TabIndex = 432
			Me.lblRateType.Text = "lblRateType"
			Me.lblRateType.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToResizeColumns = False
			Me.dgw.AllowUserToResizeRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 29
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column5, Me.Column6, Me.Column2, Me.Column3, Me.Column4, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(0, 34)
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
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(882, 189)
			Me.dgw.TabIndex = 415
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "n2"
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column1.HeaderText = "MRP"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Width = 95
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column5.HeaderText = "Retail Sale Rate"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Width = 95
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column6.HeaderText = "Wholesale Sale Rate"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 95
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle9.Format = "n2"
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column2.HeaderText = "Purchase Rate"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 95
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle10.Format = "n2"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column3.HeaderText = "Purchase Rate + GST"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 95
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column4.HeaderText = "Barcode"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Width = 95
			Me.Column7.HeaderText = "Colour"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 95
			Me.Column8.HeaderText = "Size"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 95
			Me.Column9.HeaderText = "Info"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Width = 95
			Me.Column10.HeaderText = "Batch"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Mfg Date"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "Exp Date"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column13.HeaderText = "IMEI-1"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "IMEI-2"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column15.HeaderText = "StockId"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Label4.AutoSize = True
			Me.Label4.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(4, 237)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(32, 13)
			Me.Label4.TabIndex = 428
			Me.Label4.Text = "( Top"
			Me.TextBox1.Location = New Global.System.Drawing.Point(747, 238)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(132, 20)
			Me.TextBox1.TabIndex = 435
			Me.TextBox1.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(83, 237)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label5.TabIndex = 429
			Me.Label5.Text = "Records )"
			Me.Label8.AutoSize = True
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(640, 224)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label8.TabIndex = 437
			Me.Label8.Text = "Search :"
			Me.Label1.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(882, 32)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Product Parameter"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(3, 12)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(25, 20)
			Me.txtCustomerID.TabIndex = 2
			Me.txtCustomerID.TabStop = False
			Me.txtCustomerID.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label2.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label2.Location = New Global.System.Drawing.Point(5, 39)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(123, 21)
			Me.Label2.TabIndex = 430
			Me.Label2.Text = "Product Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label3.Location = New Global.System.Drawing.Point(126, 39)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(54, 21)
			Me.Label3.TabIndex = 431
			Me.Label3.Text = "..........."
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.Coral
			MyBase.ClientSize = New Global.System.Drawing.Size(882, 297)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtCustomerID)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MinimizeBox = False
			MyBase.Name = "frmMRPShow"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.NumericUpDown1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040048C4 RID: 18628
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
