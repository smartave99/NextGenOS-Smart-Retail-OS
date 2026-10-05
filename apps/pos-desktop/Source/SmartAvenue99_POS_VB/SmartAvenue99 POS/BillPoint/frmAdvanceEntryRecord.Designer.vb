Namespace BillPoint
	' Token: 0x0200032B RID: 811
		Public Partial Class frmAdvanceEntryRecord
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BE3C RID: 48700 RVA: 0x00795960 File Offset: 0x00793B60
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

		' Token: 0x0600BE3D RID: 48701 RVA: 0x007959B0 File Offset: 0x00793BB0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmAdvanceEntryRecord))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Total = New Global.System.Windows.Forms.GroupBox()
			Me.TotalAdvance = New Global.System.Windows.Forms.TextBox()
			Me.groupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.DateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.label7 = New Global.System.Windows.Forms.Label()
			Me.label9 = New Global.System.Windows.Forms.Label()
			Me.groupBox5 = New Global.System.Windows.Forms.GroupBox()
			Me.txtEmployeeName = New Global.System.Windows.Forms.TextBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.Total.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.groupBox5.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Total)
			Me.Panel1.Controls.Add(Me.groupBox3)
			Me.Panel1.Controls.Add(Me.groupBox5)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(4, 5)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(645, 528)
			Me.Panel1.TabIndex = 2
			Me.Total.Controls.Add(Me.TotalAdvance)
			Me.Total.Location = New Global.System.Drawing.Point(470, 121)
			Me.Total.Name = "Total"
			Me.Total.Size = New Global.System.Drawing.Size(169, 48)
			Me.Total.TabIndex = 45
			Me.Total.TabStop = False
			Me.Total.Text = "Total Advance"
			Me.Total.Visible = False
			Me.TotalAdvance.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TotalAdvance.Location = New Global.System.Drawing.Point(16, 19)
			Me.TotalAdvance.Name = "TotalAdvance"
			Me.TotalAdvance.[ReadOnly] = True
			Me.TotalAdvance.Size = New Global.System.Drawing.Size(139, 20)
			Me.TotalAdvance.TabIndex = 10
			Me.TotalAdvance.TabStop = False
			Me.TotalAdvance.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.groupBox3.Controls.Add(Me.Button1)
			Me.groupBox3.Controls.Add(Me.DateTo)
			Me.groupBox3.Controls.Add(Me.DateFrom)
			Me.groupBox3.Controls.Add(Me.label7)
			Me.groupBox3.Controls.Add(Me.label9)
			Me.groupBox3.Location = New Global.System.Drawing.Point(256, 41)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New Global.System.Drawing.Size(383, 77)
			Me.groupBox3.TabIndex = 44
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Entry Date"
			Me.Button1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(289, 22)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(82, 38)
			Me.Button1.TabIndex = 46
			Me.Button1.Text = "Search"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.DateTo.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.CustomFormat = "dd/MM/yyyy"
			Me.DateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTo.Location = New Global.System.Drawing.Point(166, 42)
			Me.DateTo.Name = "DateTo"
			Me.DateTo.Size = New Global.System.Drawing.Size(117, 20)
			Me.DateTo.TabIndex = 12
			Me.DateFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.CustomFormat = "dd/MM/yyyy"
			Me.DateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateFrom.Location = New Global.System.Drawing.Point(30, 42)
			Me.DateFrom.Name = "DateFrom"
			Me.DateFrom.Size = New Global.System.Drawing.Size(124, 20)
			Me.DateFrom.TabIndex = 11
			Me.label7.AutoSize = True
			Me.label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.label7.Location = New Global.System.Drawing.Point(27, 21)
			Me.label7.Name = "label7"
			Me.label7.Size = New Global.System.Drawing.Size(30, 13)
			Me.label7.TabIndex = 9
			Me.label7.Text = "From"
			Me.label9.AutoSize = True
			Me.label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.label9.Location = New Global.System.Drawing.Point(163, 21)
			Me.label9.Name = "label9"
			Me.label9.Size = New Global.System.Drawing.Size(20, 13)
			Me.label9.TabIndex = 10
			Me.label9.Text = "To"
			Me.groupBox5.Controls.Add(Me.txtEmployeeName)
			Me.groupBox5.Location = New Global.System.Drawing.Point(5, 41)
			Me.groupBox5.Name = "groupBox5"
			Me.groupBox5.Size = New Global.System.Drawing.Size(245, 77)
			Me.groupBox5.TabIndex = 43
			Me.groupBox5.TabStop = False
			Me.groupBox5.Text = "Employee Name"
			Me.txtEmployeeName.Location = New Global.System.Drawing.Point(17, 31)
			Me.txtEmployeeName.Name = "txtEmployeeName"
			Me.txtEmployeeName.Size = New Global.System.Drawing.Size(211, 20)
			Me.txtEmployeeName.TabIndex = 0
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Controls.Add(Me.btnReset)
			Me.Panel5.Location = New Global.System.Drawing.Point(5, 124)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(274, 45)
			Me.Panel5.TabIndex = 42
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(140, 3)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(123, 33)
			Me.btnExportExcel.TabIndex = 522
			Me.btnExportExcel.Text = "Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
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
			Me.btnReset.Location = New Global.System.Drawing.Point(11, 4)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(123, 33)
			Me.btnReset.TabIndex = 521
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.MediumSeaGreen
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 24
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(5, 193)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.Orange
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(634, 329)
			Me.dgw.TabIndex = 40
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.lblSet)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(645, 32)
			Me.Panel2.TabIndex = 0
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(537, 11)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(21, 13)
			Me.lblSet.TabIndex = 1
			Me.lblSet.Text = "set"
			Me.lblSet.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(212, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(206, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "List of Advance Entry"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(654, 538)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmAdvanceEntryRecord"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Total.ResumeLayout(False)
			Me.Total.PerformLayout()
			Me.groupBox3.ResumeLayout(False)
			Me.groupBox3.PerformLayout()
			Me.groupBox5.ResumeLayout(False)
			Me.groupBox5.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004C41 RID: 19521
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
