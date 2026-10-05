Namespace BillPoint
	' Token: 0x02000558 RID: 1368
		Public Partial Class frmStockEntryRecord
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06010B95 RID: 68501 RVA: 0x009C4258 File Offset: 0x009C2458
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

		' Token: 0x06010B96 RID: 68502 RVA: 0x009C42A8 File Offset: 0x009C24A8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmStockEntryRecord))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.cmbStockID = New Global.System.Windows.Forms.ComboBox()
			Me.btnExportExcel = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Location = New Global.System.Drawing.Point(10, 10)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1003, 566)
			Me.Panel1.TabIndex = 2
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 18F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(4, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(994, 34)
			Me.Label1.TabIndex = 111
			Me.Label1.Text = "List of Stock Entry"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Button1)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 41)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(523, 109)
			Me.GroupBox2.TabIndex = 110
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search By Date :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(188, 29)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(35, 20)
			Me.Label4.TabIndex = 10
			Me.Label4.Text = "To :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Font = New Global.System.Drawing.Font("Palatino Linotype", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(15, 50)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(168, 33)
			Me.dtpDateFrom.TabIndex = 106
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Font = New Global.System.Drawing.Font("Palatino Linotype", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(192, 50)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(160, 33)
			Me.dtpDateTo.TabIndex = 107
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(361, 32)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(152, 64)
			Me.Button1.TabIndex = 108
			Me.Button1.Text = "Search"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(11, 27)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(54, 20)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "From :"
			Me.GroupBox1.Controls.Add(Me.cmbStockID)
			Me.GroupBox1.Controls.Add(Me.btnExportExcel)
			Me.GroupBox1.Controls.Add(Me.btnReset)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(548, 41)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(450, 109)
			Me.GroupBox1.TabIndex = 109
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Stock ID :"
			Me.cmbStockID.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbStockID.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbStockID.FormattingEnabled = True
			Me.cmbStockID.Location = New Global.System.Drawing.Point(8, 50)
			Me.cmbStockID.Name = "cmbStockID"
			Me.cmbStockID.Size = New Global.System.Drawing.Size(182, 33)
			Me.cmbStockID.TabIndex = 1
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnExportExcel.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(308, 32)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(129, 64)
			Me.btnExportExcel.TabIndex = 5
			Me.btnExportExcel.Text = "Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnReset.Location = New Global.System.Drawing.Point(196, 32)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(106, 64)
			Me.btnReset.TabIndex = 0
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(339, 75)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(0, 13)
			Me.Label5.TabIndex = 12
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 40
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column3, Me.Column2 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(4, 156)
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
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 40
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(994, 405)
			Me.dgw.TabIndex = 40
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.FillWeight = 144.4618F
			Me.Column3.HeaderText = "Date"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column2.HeaderText = "Remarks"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1025, 588)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmStockEntryRecord"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040064DA RID: 25818
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
