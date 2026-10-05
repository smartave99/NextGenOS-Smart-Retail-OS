Namespace BillPoint
	' Token: 0x020004DC RID: 1244
		Public Partial Class frmSuplBalanceLedger
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FD68 RID: 64872 RVA: 0x00978EF8 File Offset: 0x009770F8
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

		' Token: 0x0600FD69 RID: 64873 RVA: 0x00978F48 File Offset: 0x00977148
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
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSuplBalanceLedger))
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.txtSupplierID = New Global.System.Windows.Forms.TextBox()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(635, 30)
			Me.Label1.TabIndex = 416
			Me.Label1.Text = "Supplier Dashboard"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle.Format = "N2"
			dataGridViewCellStyle.NullValue = Nothing
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle
			Me.Column6.HeaderText = "Credit"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.ColumnHeadersHeight = 29
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(3, 33)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(630, 299)
			Me.dgw.TabIndex = 414
			Me.dgw.TabStop = False
			dataGridViewCellStyle7.Format = "d"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column1.HeaderText = "Date"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Visible = False
			Me.Column3.HeaderText = "Invoice/Voucher No."
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Particulars"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			dataGridViewCellStyle8.NullValue = Nothing
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column5.HeaderText = "Debit"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.txtSupplierID.Location = New Global.System.Drawing.Point(420, 21)
			Me.txtSupplierID.Name = "txtSupplierID"
			Me.txtSupplierID.[ReadOnly] = True
			Me.txtSupplierID.Size = New Global.System.Drawing.Size(21, 20)
			Me.txtSupplierID.TabIndex = 415
			Me.txtSupplierID.TabStop = False
			Me.txtSupplierID.Visible = False
			Me.Button3.BackColor = Global.System.Drawing.Color.White
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(604, 0)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(31, 31)
			Me.Button3.TabIndex = 417
			Me.Button3.TabStop = False
			Me.Button3.Text = "                      &C"
			Me.Button3.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.Maroon
			MyBase.ClientSize = New Global.System.Drawing.Size(635, 334)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.txtSupplierID)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSuplBalanceLedger"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmSuplBalanceLedger"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04006107 RID: 24839
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
