Namespace BillPoint
	' Token: 0x0200036F RID: 879
		Public Partial Class frmStockMovementReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CFB5 RID: 53173 RVA: 0x008183B0 File Offset: 0x008165B0
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

		' Token: 0x0600CFB6 RID: 53174 RVA: 0x00818400 File Offset: 0x00816600
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmStockMovementReport))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.cmbProductName = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(574, 184)
			Me.Panel1.TabIndex = 2
			Me.GroupBox1.Controls.Add(Me.GelButton1)
			Me.GroupBox1.Controls.Add(Me.GelButton3)
			Me.GroupBox1.Controls.Add(Me.GelButton2)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.cmbProductName)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.dtpDateTo)
			Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 43)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(551, 123)
			Me.GroupBox1.TabIndex = 3
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Date :"
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(257, 80)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(120, 37)
			Me.GelButton1.TabIndex = 535
			Me.GelButton1.Text = "View Report"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(407, 30)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 533
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(257, 30)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(120, 37)
			Me.GelButton2.TabIndex = 534
			Me.GelButton2.Text = "View Report"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(8, 67)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(133, 13)
			Me.Label3.TabIndex = 15
			Me.Label3.Text = "Search By Product Name :"
			Me.cmbProductName.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbProductName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbProductName.FormattingEnabled = True
			Me.cmbProductName.Location = New Global.System.Drawing.Point(11, 88)
			Me.cmbProductName.Name = "cmbProductName"
			Me.cmbProductName.Size = New Global.System.Drawing.Size(225, 24)
			Me.cmbProductName.TabIndex = 3
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(130, 19)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label4.TabIndex = 10
			Me.Label4.Text = "To :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(133, 38)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(103, 20)
			Me.dtpDateTo.TabIndex = 1
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(11, 38)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(104, 20)
			Me.dtpDateFrom.TabIndex = 0
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(8, 19)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label2.TabIndex = 9
			Me.Label2.Text = "From :"
			Me.Panel2.BackColor = Global.System.Drawing.Color.DarkMagenta
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(590, 27)
			Me.Panel2.TabIndex = 0
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-12, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(636, 27)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Stock Movement Report"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(574, 184)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmStockMovementReport"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005356 RID: 21334
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
