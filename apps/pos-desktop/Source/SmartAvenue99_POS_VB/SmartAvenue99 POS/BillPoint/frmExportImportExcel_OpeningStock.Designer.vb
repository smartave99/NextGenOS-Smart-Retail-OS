Namespace BillPoint
	' Token: 0x0200010E RID: 270
		Public Partial Class frmExportImportExcel_OpeningStock
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002C6E RID: 11374 RVA: 0x001B82A4 File Offset: 0x001B64A4
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

		' Token: 0x06002C6F RID: 11375 RVA: 0x001B82F4 File Offset: 0x001B64F4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmExportImportExcel_OpeningStock))
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
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.btnExportExcel = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.btnImportExcel = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.FolderBrowserDialog1 = New Global.System.Windows.Forms.FolderBrowserDialog()
			Me.Panel1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(6, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(765, 32)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "Opening Stock Import/Export (Excel Sheet)"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.LinkLabel1)
			Me.Panel1.Controls.Add(Me.btnExportExcel)
			Me.Panel1.Controls.Add(Me.btnSave)
			Me.Panel1.Controls.Add(Me.btnImportExcel)
			Me.Panel1.Controls.Add(Me.btnReset)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(10, 10)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(779, 429)
			Me.Panel1.TabIndex = 2
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(643, 77)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(128, 13)
			Me.LinkLabel1.TabIndex = 405
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Download Sample Format"
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(192, 42)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(97, 47)
			Me.btnExportExcel.TabIndex = 129
			Me.btnExportExcel.Text = "Export" & vbCrLf & " Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(393, 42)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(90, 47)
			Me.btnSave.TabIndex = 128
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.btnImportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnImportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnImportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnImportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnImportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnImportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnImportExcel.Image = CType(componentResourceManager.GetObject("btnImportExcel.Image"), Global.System.Drawing.Image)
			Me.btnImportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnImportExcel.Location = New Global.System.Drawing.Point(295, 42)
			Me.btnImportExcel.Name = "btnImportExcel"
			Me.btnImportExcel.Size = New Global.System.Drawing.Size(92, 47)
			Me.btnImportExcel.TabIndex = 127
			Me.btnImportExcel.Text = "Import " & vbCrLf & "Excel"
			Me.btnImportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnImportExcel.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(489, 42)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(91, 47)
			Me.btnReset.TabIndex = 126
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 32
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(3, 93)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.SaddleBrown
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(771, 331)
			Me.DataGridView1.TabIndex = 125
			Me.DataGridView1.Visible = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.ColumnHeadersHeight = 35
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column31, Me.Column32, Me.Column3, Me.Column4, Me.Column1, Me.Column2, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column5, Me.Column6, Me.Column7 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle7
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(3, 93)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle8
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle9
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(771, 331)
			Me.dgw.TabIndex = 124
			Me.Column31.HeaderText = "Product ID"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column32.HeaderText = "Qty"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			Me.Column3.HeaderText = "MRP"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Retail Sale Price"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column1.HeaderText = "Wholesale Sale Price"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Batch / Serial"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column26.HeaderText = "Mfg Date"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column27.HeaderText = "Exp Date"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			Me.Column28.HeaderText = "Size"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column29.HeaderText = "Colour"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column30.HeaderText = "Barcode"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle10.Format = "N2"
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column5.HeaderText = "Purchase Price"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "IMEI-1"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "IMEI-1"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(800, 450)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.Fixed3D
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmExportImportExcel_OpeningStock"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040012FF RID: 4863
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
