Namespace BillPoint
	' Token: 0x0200032C RID: 812
		Public Partial Class frmAdvanceEntryReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BE70 RID: 48752 RVA: 0x0079786C File Offset: 0x00795A6C
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

		' Token: 0x0600BE71 RID: 48753 RVA: 0x007978BC File Offset: 0x00795ABC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmAdvanceEntryReport))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.cmbEmployeeName = New Global.System.Windows.Forms.ComboBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(3, 4)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(627, 231)
			Me.Panel1.TabIndex = 2
			Me.GroupBox3.Controls.Add(Me.btnReset)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(468, 130)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(148, 87)
			Me.GroupBox3.TabIndex = 43
			Me.GroupBox3.TabStop = False
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
			Me.btnReset.Location = New Global.System.Drawing.Point(12, 22)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnReset.TabIndex = 515
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.btnExportExcel)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 130)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(420, 87)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Entry Date :"
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
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(276, 22)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnExportExcel.TabIndex = 516
			Me.btnExportExcel.Text = "View Report"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(131, 22)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label3.TabIndex = 10
			Me.Label3.Text = "To :"
			Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(134, 43)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(109, 20)
			Me.DateTimePicker1.TabIndex = 2
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(5, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 9
			Me.Label4.Text = "From :"
			Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
			Me.DateTimePicker2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTimePicker2.Location = New Global.System.Drawing.Point(8, 43)
			Me.DateTimePicker2.Name = "DateTimePicker2"
			Me.DateTimePicker2.Size = New Global.System.Drawing.Size(106, 20)
			Me.DateTimePicker2.TabIndex = 1
			Me.GroupBox2.Controls.Add(Me.GelButton1)
			Me.GroupBox2.Controls.Add(Me.cmbEmployeeName)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Controls.Add(Me.Label10)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 39)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(612, 87)
			Me.GroupBox2.TabIndex = 0
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search By Employee Name and Entry Date :"
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(476, 28)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton1.TabIndex = 517
			Me.GelButton1.Text = "View Report"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.cmbEmployeeName.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbEmployeeName.FormattingEnabled = True
			Me.cmbEmployeeName.Location = New Global.System.Drawing.Point(14, 42)
			Me.cmbEmployeeName.Name = "cmbEmployeeName"
			Me.cmbEmployeeName.Size = New Global.System.Drawing.Size(205, 21)
			Me.cmbEmployeeName.TabIndex = 0
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(11, 22)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label9.TabIndex = 51
			Me.Label9.Text = "Employee Name :"
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(348, 22)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label10.TabIndex = 10
			Me.Label10.Text = "To :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(351, 43)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(106, 20)
			Me.dtpDateTo.TabIndex = 2
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(222, 22)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label11.TabIndex = 9
			Me.Label11.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(225, 43)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(103, 20)
			Me.dtpDateFrom.TabIndex = 1
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.txtCompanyName)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(627, 31)
			Me.Panel2.TabIndex = 0
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(4, 5)
			Me.txtCompanyName.Name = "txtCompanyName"
			Me.txtCompanyName.[ReadOnly] = True
			Me.txtCompanyName.Size = New Global.System.Drawing.Size(29, 20)
			Me.txtCompanyName.TabIndex = 7
			Me.txtCompanyName.TabStop = False
			Me.txtCompanyName.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(179, 2)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(246, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Advance Payment Report"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(632, 241)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmAdvanceEntryReport"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004C55 RID: 19541
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
