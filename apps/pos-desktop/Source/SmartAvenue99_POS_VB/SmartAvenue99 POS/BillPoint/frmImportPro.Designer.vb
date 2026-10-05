Namespace BillPoint
	' Token: 0x020000AC RID: 172
		Public Partial Class frmImportPro
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06001956 RID: 6486 RVA: 0x00112EE8 File Offset: 0x001110E8
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

		' Token: 0x06001957 RID: 6487 RVA: 0x00112F38 File Offset: 0x00111138
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmImportPro))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.btnBrowse = New Global.GelButtons.GelButton()
			Me.lblStatus = New Global.System.Windows.Forms.Label()
			Me.BackgroundWorker1 = New Global.System.ComponentModel.BackgroundWorker()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.txtFilePath = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.ProgressBar2 = New Global.System.Windows.Forms.ProgressBar()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.btnBrowse.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnBrowse.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnBrowse.FlatAppearance.BorderSize = 0
			Me.btnBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnBrowse.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnBrowse.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnBrowse.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnBrowse.Image = CType(componentResourceManager.GetObject("btnBrowse.Image"), Global.System.Drawing.Image)
			Me.btnBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnBrowse.Location = New Global.System.Drawing.Point(583, 10)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New Global.System.Drawing.Size(102, 27)
			Me.btnBrowse.TabIndex = 1832
			Me.btnBrowse.Text = " Browse"
			Me.btnBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnBrowse.UseVisualStyleBackColor = False
			Me.lblStatus.AutoSize = True
			Me.lblStatus.Location = New Global.System.Drawing.Point(494, 195)
			Me.lblStatus.Name = "lblStatus"
			Me.lblStatus.Size = New Global.System.Drawing.Size(47, 13)
			Me.lblStatus.TabIndex = 1833
			Me.lblStatus.Text = "lblStatus"
			Me.lblStatus.Visible = False
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(212, 189)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(276, 23)
			Me.ProgressBar1.TabIndex = 1834
			Me.ProgressBar1.Visible = False
			Me.txtFilePath.Location = New Global.System.Drawing.Point(12, 130)
			Me.txtFilePath.Name = "txtFilePath"
			Me.txtFilePath.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtFilePath.TabIndex = 1835
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
			Me.DataGridView1.Location = New Global.System.Drawing.Point(6, 43)
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
			Me.DataGridView1.Size = New Global.System.Drawing.Size(787, 395)
			Me.DataGridView1.TabIndex = 1838
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(691, 10)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(102, 27)
			Me.GelButton2.TabIndex = 1839
			Me.GelButton2.Text = "Insert"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(6, 68)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(102, 27)
			Me.GelButton3.TabIndex = 1840
			Me.GelButton3.Text = " Browse"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(6, 97)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(102, 27)
			Me.GelButton4.TabIndex = 1841
			Me.GelButton4.Text = "Insert"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(146, 68)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(100, 50)
			Me.pbgiftqr.TabIndex = 1842
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Location = New Global.System.Drawing.Point(308, 20)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(92, 17)
			Me.CheckBox1.TabIndex = 1843
			Me.CheckBox1.Text = "Stock Update"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.CheckBox1.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(254, 68)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(28, 20)
			Me.txtID.TabIndex = 1845
			Me.txtID.Visible = False
			Me.txtProductCode.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtProductCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductCode.Location = New Global.System.Drawing.Point(288, 68)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.[ReadOnly] = True
			Me.txtProductCode.Size = New Global.System.Drawing.Size(28, 21)
			Me.txtProductCode.TabIndex = 1844
			Me.txtProductCode.Visible = False
			Me.ProgressBar2.Location = New Global.System.Drawing.Point(212, 218)
			Me.ProgressBar2.Name = "ProgressBar2"
			Me.ProgressBar2.Size = New Global.System.Drawing.Size(276, 23)
			Me.ProgressBar2.TabIndex = 1846
			Me.ProgressBar2.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(496, 223)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(92, 13)
			Me.Label1.TabIndex = 1847
			Me.Label1.Text = "Exporting Excel...."
			Me.Label1.Visible = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(396, 10)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(181, 27)
			Me.GelButton1.TabIndex = 1848
			Me.GelButton1.Text = "Sample File Download"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(796, 450)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.ProgressBar2)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.lblStatus)
			MyBase.Controls.Add(Me.btnBrowse)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.txtFilePath)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.txtProductCode)
			MyBase.Controls.Add(Me.CheckBox1)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.GelButton4)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Name = "frmImportPro"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Import Products"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040009D2 RID: 2514
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
