Namespace BillPoint
	' Token: 0x02000137 RID: 311
		Public Partial Class frmPdfReader
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06003552 RID: 13650 RVA: 0x0020C64C File Offset: 0x0020A84C
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

		' Token: 0x06003553 RID: 13651 RVA: 0x0020C69C File Offset: 0x0020A89C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.txtID_temp = New Global.System.Windows.Forms.TextBox()
			Me.txtBar = New Global.System.Windows.Forms.TextBox()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.txtMrp_per = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtWholesale_per = New Global.System.Windows.Forms.TextBox()
			Me.chkAll = New Global.System.Windows.Forms.CheckBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			Me.Photo = New Global.System.Windows.Forms.PictureBox()
			Me.btnSettle = New Global.System.Windows.Forms.Button()
			Me.btnResult = New Global.System.Windows.Forms.Button()
			Me.btnProcessPdf = New Global.System.Windows.Forms.Button()
			Me.btnApply = New Global.System.Windows.Forms.Button()
			Me.pnlDate = New Global.System.Windows.Forms.Panel()
			Me.btnOk = New Global.System.Windows.Forms.Button()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.ProgressBar1 = New Global.System.Windows.Forms.ProgressBar()
			Me.GelButton3 = New Global.System.Windows.Forms.Button()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlDate.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TextBox1.Location = New Global.System.Drawing.Point(54, 236)
			Me.TextBox1.Multiline = True
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(430, 164)
			Me.TextBox1.TabIndex = 0
			Me.TextBox1.Visible = False
			Me.DataGridView1.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.DataGridView1.Location = New Global.System.Drawing.Point(13, 53)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1220, 363)
			Me.DataGridView1.TabIndex = 1
			Me.TextBox2.Location = New Global.System.Drawing.Point(490, 236)
			Me.TextBox2.Multiline = True
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(727, 164)
			Me.TextBox2.TabIndex = 4
			Me.TextBox2.Visible = False
			Me.txtID_temp.Location = New Global.System.Drawing.Point(12, 422)
			Me.txtID_temp.Name = "txtID_temp"
			Me.txtID_temp.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtID_temp.TabIndex = 6
			Me.txtID_temp.Visible = False
			Me.txtBar.Location = New Global.System.Drawing.Point(118, 422)
			Me.txtBar.Name = "txtBar"
			Me.txtBar.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBar.TabIndex = 7
			Me.txtBar.Visible = False
			Me.txtBarcode.Location = New Global.System.Drawing.Point(256, 422)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBarcode.TabIndex = 1838
			Me.txtBarcode.Visible = False
			Me.TextBox4.Location = New Global.System.Drawing.Point(364, 422)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(100, 20)
			Me.TextBox4.TabIndex = 1839
			Me.TextBox4.Visible = False
			Me.txtMrp_per.Location = New Global.System.Drawing.Point(106, 453)
			Me.txtMrp_per.Name = "txtMrp_per"
			Me.txtMrp_per.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtMrp_per.TabIndex = 1840
			Me.txtMrp_per.Text = "20"
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(15, 457)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(89, 13)
			Me.Label1.TabIndex = 1841
			Me.Label1.Text = "MRP(%) of Rate :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(216, 458)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(115, 13)
			Me.Label2.TabIndex = 1843
			Me.Label2.Text = "Wholesale(%) of Rate :"
			Me.txtWholesale_per.Location = New Global.System.Drawing.Point(331, 454)
			Me.txtWholesale_per.Name = "txtWholesale_per"
			Me.txtWholesale_per.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtWholesale_per.TabIndex = 1842
			Me.txtWholesale_per.Text = "15"
			Me.chkAll.AutoSize = True
			Me.chkAll.Location = New Global.System.Drawing.Point(12, 30)
			Me.chkAll.Name = "chkAll"
			Me.chkAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkAll.TabIndex = 1844
			Me.chkAll.Text = "Select All"
			Me.chkAll.UseVisualStyleBackColor = True
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(849, 406)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(77, 39)
			Me.pbgiftqr.TabIndex = 1837
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			Me.Photo.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Photo.Location = New Global.System.Drawing.Point(224, 422)
			Me.Photo.Name = "Photo"
			Me.Photo.Size = New Global.System.Drawing.Size(26, 22)
			Me.Photo.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Photo.TabIndex = 1836
			Me.Photo.TabStop = False
			Me.Photo.Visible = False
			Me.btnSettle.BackgroundImage = Global.BillPoint.My.Resources.Resources.Bring_to_Purchase_Entry
			Me.btnSettle.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSettle.FlatAppearance.BorderSize = 0
			Me.btnSettle.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSettle.Location = New Global.System.Drawing.Point(1070, 3)
			Me.btnSettle.Name = "btnSettle"
			Me.btnSettle.Size = New Global.System.Drawing.Size(159, 44)
			Me.btnSettle.TabIndex = 5
			Me.btnSettle.UseVisualStyleBackColor = True
			Me.btnResult.BackgroundImage = Global.BillPoint.My.Resources.Resources.Extract_Data_copy
			Me.btnResult.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnResult.FlatAppearance.BorderSize = 0
			Me.btnResult.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnResult.Location = New Global.System.Drawing.Point(916, 3)
			Me.btnResult.Name = "btnResult"
			Me.btnResult.Size = New Global.System.Drawing.Size(148, 44)
			Me.btnResult.TabIndex = 3
			Me.btnResult.UseVisualStyleBackColor = True
			Me.btnProcessPdf.BackgroundImage = Global.BillPoint.My.Resources.Resources.Upload_File_copy
			Me.btnProcessPdf.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnProcessPdf.FlatAppearance.BorderSize = 0
			Me.btnProcessPdf.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnProcessPdf.Location = New Global.System.Drawing.Point(778, 3)
			Me.btnProcessPdf.Name = "btnProcessPdf"
			Me.btnProcessPdf.Size = New Global.System.Drawing.Size(132, 44)
			Me.btnProcessPdf.TabIndex = 2
			Me.btnProcessPdf.UseVisualStyleBackColor = True
			Me.btnApply.Location = New Global.System.Drawing.Point(437, 454)
			Me.btnApply.Name = "btnApply"
			Me.btnApply.Size = New Global.System.Drawing.Size(75, 23)
			Me.btnApply.TabIndex = 1845
			Me.btnApply.Text = "Apply"
			Me.btnApply.UseVisualStyleBackColor = True
			Me.pnlDate.BackColor = Global.System.Drawing.Color.FromArgb(255, 192, 128)
			Me.pnlDate.Controls.Add(Me.btnOk)
			Me.pnlDate.Controls.Add(Me.dtpDate)
			Me.pnlDate.Location = New Global.System.Drawing.Point(951, 82)
			Me.pnlDate.Name = "pnlDate"
			Me.pnlDate.Size = New Global.System.Drawing.Size(177, 39)
			Me.pnlDate.TabIndex = 1846
			Me.pnlDate.Visible = False
			Me.btnOk.BackColor = Global.System.Drawing.Color.Yellow
			Me.btnOk.Location = New Global.System.Drawing.Point(123, 8)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New Global.System.Drawing.Size(51, 23)
			Me.btnOk.TabIndex = 1847
			Me.btnOk.Text = "Ok"
			Me.btnOk.UseVisualStyleBackColor = False
			Me.dtpDate.AccessibleRole = Global.System.Windows.Forms.AccessibleRole.None
			Me.dtpDate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dtpDate.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(7, 7)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(110, 24)
			Me.dtpDate.TabIndex = 2
			Me.ProgressBar1.Location = New Global.System.Drawing.Point(106, 27)
			Me.ProgressBar1.Name = "ProgressBar1"
			Me.ProgressBar1.Size = New Global.System.Drawing.Size(190, 20)
			Me.ProgressBar1.TabIndex = 1847
			Me.ProgressBar1.Visible = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackgroundImage = Global.BillPoint.My.Resources.Resources.Set_Default_copy_1
			Me.GelButton3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Location = New Global.System.Drawing.Point(644, 6)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(128, 41)
			Me.GelButton3.TabIndex = 1848
			Me.GelButton3.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1244, 488)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.ProgressBar1)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.pnlDate)
			MyBase.Controls.Add(Me.btnApply)
			MyBase.Controls.Add(Me.chkAll)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.txtWholesale_per)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtMrp_per)
			MyBase.Controls.Add(Me.TextBox4)
			MyBase.Controls.Add(Me.txtBarcode)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.Photo)
			MyBase.Controls.Add(Me.txtBar)
			MyBase.Controls.Add(Me.txtID_temp)
			MyBase.Controls.Add(Me.btnSettle)
			MyBase.Controls.Add(Me.btnResult)
			MyBase.Controls.Add(Me.btnProcessPdf)
			MyBase.Name = "frmPdfReader"
			Me.Text = "Pdf Reader"
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Photo, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlDate.ResumeLayout(False)
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040016EB RID: 5867
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
