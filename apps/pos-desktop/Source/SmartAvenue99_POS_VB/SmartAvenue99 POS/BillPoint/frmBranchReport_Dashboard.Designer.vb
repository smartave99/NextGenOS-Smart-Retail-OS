Namespace BillPoint
	' Token: 0x0200007D RID: 125
		Public Partial Class frmBranchReport_Dashboard
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060014D7 RID: 5335 RVA: 0x000E02D4 File Offset: 0x000DE4D4
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

		' Token: 0x060014D8 RID: 5336 RVA: 0x000E0324 File Offset: 0x000DE524
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.txtCompanyId = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.btnLogin = New Global.System.Windows.Forms.Button()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.flpItemsCategory = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.flpItems_BV = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.FlowLayoutPanel1 = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btnDel = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.flpItems_BV.SuspendLayout()
			MyBase.SuspendLayout()
			Me.txtCompanyId.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCompanyId.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCompanyId.Location = New Global.System.Drawing.Point(8, 21)
			Me.txtCompanyId.Name = "txtCompanyId"
			Me.txtCompanyId.Size = New Global.System.Drawing.Size(249, 21)
			Me.txtCompanyId.TabIndex = 2
			Me.GroupBox1.Controls.Add(Me.btnLogin)
			Me.GroupBox1.Controls.Add(Me.txtCompanyId)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 12)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(339, 54)
			Me.GroupBox1.TabIndex = 3
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Branch Code"
			Me.btnLogin.Location = New Global.System.Drawing.Point(263, 21)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New Global.System.Drawing.Size(70, 23)
			Me.btnLogin.TabIndex = 3
			Me.btnLogin.Text = "Add"
			Me.btnLogin.UseVisualStyleBackColor = True
			Me.GroupBox2.Controls.Add(Me.dgw)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(13, 73)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(338, 506)
			Me.GroupBox2.TabIndex = 4
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Dashboard"
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column3, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.btnDel, Me.Column7 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(7, 19)
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
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.MediumTurquoise
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 40
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(325, 481)
			Me.dgw.TabIndex = 41
			Me.dgw.TabStop = False
			Me.flpItemsCategory.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpItemsCategory.AutoScroll = True
			Me.flpItemsCategory.BackColor = Global.System.Drawing.Color.FromArgb(238, 238, 242)
			Me.flpItemsCategory.Location = New Global.System.Drawing.Point(357, 12)
			Me.flpItemsCategory.Name = "flpItemsCategory"
			Me.flpItemsCategory.Size = New Global.System.Drawing.Size(882, 81)
			Me.flpItemsCategory.TabIndex = 506
			Me.flpItems_BV.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.flpItems_BV.AutoScroll = True
			Me.flpItems_BV.AutoSize = True
			Me.flpItems_BV.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.flpItems_BV.Controls.Add(Me.FlowLayoutPanel1)
			Me.flpItems_BV.Location = New Global.System.Drawing.Point(357, 95)
			Me.flpItems_BV.Name = "flpItems_BV"
			Me.flpItems_BV.Size = New Global.System.Drawing.Size(882, 31)
			Me.flpItems_BV.TabIndex = 507
			Me.flpItems_BV.Visible = False
			Me.FlowLayoutPanel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.FlowLayoutPanel1.BackColor = Global.System.Drawing.Color.Transparent
			Me.FlowLayoutPanel1.Location = New Global.System.Drawing.Point(3, 3)
			Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
			Me.FlowLayoutPanel1.Size = New Global.System.Drawing.Size(569, 0)
			Me.FlowLayoutPanel1.TabIndex = 476
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Format = "dd/MM/yyyy"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.FillWeight = 205.9932F
			Me.Column3.HeaderText = "Branch Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column2.HeaderText = "Local DB"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Visible = False
			Me.Column4.HeaderText = "Online Db"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Column5.HeaderText = "Status"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column5.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Column5.Visible = False
			Me.Column6.HeaderText = "Company Id"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Visible = False
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.Color.Red
			Me.btnDel.DefaultCellStyle = dataGridViewCellStyle7
			Me.btnDel.FillWeight = 38.46861F
			Me.btnDel.HeaderText = "Del"
			Me.btnDel.Name = "btnDel"
			Me.btnDel.[ReadOnly] = True
			Me.btnDel.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.btnDel.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.btnDel.Text = "X"
			Me.btnDel.UseColumnTextForButtonValue = True
			Me.Column7.HeaderText = "Id2"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1244, 591)
			MyBase.Controls.Add(Me.flpItems_BV)
			MyBase.Controls.Add(Me.flpItemsCategory)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Name = "frmBranchReport_Dashboard"
			Me.Text = "Branch Report Dashboard"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.flpItems_BV.ResumeLayout(False)
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400071D RID: 1821
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
