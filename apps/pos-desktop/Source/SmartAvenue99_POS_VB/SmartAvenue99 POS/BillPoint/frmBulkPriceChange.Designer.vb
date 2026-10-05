Namespace BillPoint
	' Token: 0x020000BF RID: 191
		Public Partial Class frmBulkPriceChange
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001B20 RID: 6944 RVA: 0x0012A03C File Offset: 0x0012823C
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

		' Token: 0x06001B21 RID: 6945 RVA: 0x0012A08C File Offset: 0x0012828C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn55 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn57 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewComboBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnUpdatePrice = New Global.System.Windows.Forms.Button()
			Me.lblCategoryId = New Global.System.Windows.Forms.Label()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn55, Me.Column4, Me.DataGridViewTextBoxColumn57, Me.DataGridViewComboBoxColumn1, Me.Column1, Me.Column2, Me.Column3 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.Location = New Global.System.Drawing.Point(12, 20)
			Me.dgw.Name = "dgw"
			Me.dgw.RowTemplate.Height = 30
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1207, 445)
			Me.dgw.TabIndex = 1828
			Me.DataGridViewTextBoxColumn55.DataPropertyName = "PID1"
			Me.DataGridViewTextBoxColumn55.HeaderText = "PID"
			Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
			Me.DataGridViewTextBoxColumn55.Visible = False
			Me.Column4.HeaderText = "ProductCode"
			Me.Column4.Name = "Column4"
			Me.Column4.Visible = False
			Me.DataGridViewTextBoxColumn57.DataPropertyName = "ProductName1"
			Me.DataGridViewTextBoxColumn57.FillWeight = 208.1594F
			Me.DataGridViewTextBoxColumn57.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
			Me.DataGridViewTextBoxColumn57.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn57.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridViewComboBoxColumn1.FillWeight = 41.63189F
			Me.DataGridViewComboBoxColumn1.HeaderText = "Barcode"
			Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
			Me.DataGridViewComboBoxColumn1.[ReadOnly] = True
			Me.DataGridViewComboBoxColumn1.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column1.FillWeight = 104.0797F
			Me.Column1.HeaderText = "MRP"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.FillWeight = 104.0797F
			Me.Column2.HeaderText = "Sale Price"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.FillWeight = 104.0797F
			Me.Column3.HeaderText = "Update Sell Price"
			Me.Column3.Name = "Column3"
			Me.btnUpdatePrice.Location = New Global.System.Drawing.Point(1032, 471)
			Me.btnUpdatePrice.Name = "btnUpdatePrice"
			Me.btnUpdatePrice.Size = New Global.System.Drawing.Size(187, 47)
			Me.btnUpdatePrice.TabIndex = 1829
			Me.btnUpdatePrice.Text = "Update Price"
			Me.btnUpdatePrice.UseVisualStyleBackColor = True
			Me.lblCategoryId.AutoSize = True
			Me.lblCategoryId.Location = New Global.System.Drawing.Point(428, 4)
			Me.lblCategoryId.Name = "lblCategoryId"
			Me.lblCategoryId.Size = New Global.System.Drawing.Size(68, 13)
			Me.lblCategoryId.TabIndex = 1830
			Me.lblCategoryId.Text = "lblCategoryId"
			Me.lblCategoryId.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1231, 523)
			MyBase.Controls.Add(Me.lblCategoryId)
			MyBase.Controls.Add(Me.btnUpdatePrice)
			MyBase.Controls.Add(Me.dgw)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmBulkPriceChange"
			Me.Text = "frmBulkPriceChange"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04000AB1 RID: 2737
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
