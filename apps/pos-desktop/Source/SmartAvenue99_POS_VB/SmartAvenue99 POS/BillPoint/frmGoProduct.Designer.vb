Namespace BillPoint
	' Token: 0x020000AB RID: 171
		Public Partial Class frmGoProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600192F RID: 6447 RVA: 0x00111B90 File Offset: 0x0010FD90
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

		' Token: 0x06001930 RID: 6448 RVA: 0x00111BE0 File Offset: 0x0010FDE0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmGoProduct))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.DataGridView2 = New Global.System.Windows.Forms.DataGridView()
			Me.Panel7 = New Global.System.Windows.Forms.Panel()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.txtSearchProduct = New Global.System.Windows.Forms.TextBox()
			Me.cmbSearchCat = New Global.System.Windows.Forms.ComboBox()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.ProductCode1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ProductName1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel5.SuspendLayout()
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel7.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.GelButton2)
			Me.Panel5.Controls.Add(Me.GelButton1)
			Me.Panel5.Location = New Global.System.Drawing.Point(612, 2)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(265, 80)
			Me.Panel5.TabIndex = 4
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(4, 20)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton2.TabIndex = 527
			Me.GelButton2.Text = "&Reset"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(132, 20)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton1.TabIndex = 528
			Me.GelButton1.Text = "&Export Excel"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView2.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView2.BackgroundColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(228, 255, 142)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlDarkDark
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView2.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView2.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.ProductCode1, Me.ProductName1, Me.Column1, Me.Column2 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Arial", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView2.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView2.EnableHeadersVisualStyles = False
			Me.DataGridView2.Location = New Global.System.Drawing.Point(3, 88)
			Me.DataGridView2.Name = "DataGridView2"
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Control
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView2.RowTemplate.Height = 30
			Me.DataGridView2.Size = New Global.System.Drawing.Size(874, 719)
			Me.DataGridView2.TabIndex = 1825
			Me.Panel7.BackColor = Global.System.Drawing.Color.FromArgb(229, 233, 219)
			Me.Panel7.Controls.Add(Me.Label18)
			Me.Panel7.Controls.Add(Me.Label21)
			Me.Panel7.Controls.Add(Me.txtTopResult)
			Me.Panel7.Location = New Global.System.Drawing.Point(7, 41)
			Me.Panel7.Name = "Panel7"
			Me.Panel7.Size = New Global.System.Drawing.Size(599, 41)
			Me.Panel7.TabIndex = 1828
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(183, 5)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(107, 30)
			Me.Label18.TabIndex = 1806
			Me.Label18.Text = "RECORDS"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Tai Le", 15F, Global.System.Drawing.FontStyle.Bold)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(13, 5)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(64, 30)
			Me.Label21.TabIndex = 51
			Me.Label21.Text = "TOP :"
			Me.Label21.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtTopResult.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtTopResult.Location = New Global.System.Drawing.Point(80, 5)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(97, 26)
			Me.txtTopResult.TabIndex = 433
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "100"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.txtSearchProduct.BackColor = Global.System.Drawing.Color.White
			Me.txtSearchProduct.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.txtSearchProduct.Location = New Global.System.Drawing.Point(176, 7)
			Me.txtSearchProduct.Name = "txtSearchProduct"
			Me.txtSearchProduct.Size = New Global.System.Drawing.Size(181, 26)
			Me.txtSearchProduct.TabIndex = 1826
			Me.cmbSearchCat.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.cmbSearchCat.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchCat.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchCat.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbSearchCat.ForeColor = Global.System.Drawing.Color.White
			Me.cmbSearchCat.FormattingEnabled = True
			Me.cmbSearchCat.Items.AddRange(New Object() { "Product Name", "Product Code" })
			Me.cmbSearchCat.Location = New Global.System.Drawing.Point(7, 7)
			Me.cmbSearchCat.Name = "cmbSearchCat"
			Me.cmbSearchCat.Size = New Global.System.Drawing.Size(163, 28)
			Me.cmbSearchCat.TabIndex = 1827
			Me.cmbSearchCat.TabStop = False
			Me.ProductCode1.DataPropertyName = "ProductCode1"
			Me.ProductCode1.HeaderText = "P-Code"
			Me.ProductCode1.Name = "ProductCode1"
			Me.ProductCode1.[ReadOnly] = True
			Me.ProductName1.DataPropertyName = "ProductName1"
			Me.ProductName1.HeaderText = "Product Name"
			Me.ProductName1.Name = "ProductName1"
			Me.Column1.HeaderText = "Unit"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Tax"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(888, 810)
			MyBase.Controls.Add(Me.Panel7)
			MyBase.Controls.Add(Me.txtSearchProduct)
			MyBase.Controls.Add(Me.cmbSearchCat)
			MyBase.Controls.Add(Me.DataGridView2)
			MyBase.Controls.Add(Me.Panel5)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmGoProduct"
			Me.Text = "frmGoProduct"
			Me.Panel5.ResumeLayout(False)
			CType(Me.DataGridView2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel7.ResumeLayout(False)
			Me.Panel7.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040009C2 RID: 2498
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
