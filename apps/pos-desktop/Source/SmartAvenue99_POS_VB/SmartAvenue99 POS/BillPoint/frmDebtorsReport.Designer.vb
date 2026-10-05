Namespace BillPoint
	' Token: 0x020004C2 RID: 1218
		Public Partial Class frmDebtorsReport
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F460 RID: 62560 RVA: 0x00927E3C File Offset: 0x0092603C
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

		' Token: 0x0600F461 RID: 62561 RVA: 0x00927E8C File Offset: 0x0092608C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmDebtorsReport))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton7 = New Global.GelButtons.GelButton()
			Me.GelButton6 = New Global.GelButtons.GelButton()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton5 = New Global.GelButtons.GelButton()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.dtpDateFrom)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.dtpDateTo)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(614, 296)
			Me.Panel1.TabIndex = 2
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(246, 171)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 533
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.GelButton7)
			Me.GroupBox1.Controls.Add(Me.GelButton6)
			Me.GroupBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(356, 135)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(226, 93)
			Me.GroupBox1.TabIndex = 51
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Supplier Outstanding Report"
			Me.GelButton7.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton7.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton7.FlatAppearance.BorderSize = 0
			Me.GelButton7.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton7.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton7.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton7.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton7.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton7.Image = CType(componentResourceManager.GetObject("GelButton7.Image"), Global.System.Drawing.Image)
			Me.GelButton7.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton7.Location = New Global.System.Drawing.Point(116, 36)
			Me.GelButton7.Name = "GelButton7"
			Me.GelButton7.Size = New Global.System.Drawing.Size(105, 37)
			Me.GelButton7.TabIndex = 537
			Me.GelButton7.Text = "Receivable"
			Me.GelButton7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton7.UseVisualStyleBackColor = False
			Me.GelButton6.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton6.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton6.FlatAppearance.BorderSize = 0
			Me.GelButton6.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton6.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton6.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton6.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton6.Image = CType(componentResourceManager.GetObject("GelButton6.Image"), Global.System.Drawing.Image)
			Me.GelButton6.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton6.Location = New Global.System.Drawing.Point(7, 36)
			Me.GelButton6.Name = "GelButton6"
			Me.GelButton6.Size = New Global.System.Drawing.Size(103, 37)
			Me.GelButton6.TabIndex = 537
			Me.GelButton6.Text = "Payable"
			Me.GelButton6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton6.UseVisualStyleBackColor = False
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(154, 78)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 64
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(151, 59)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 66
			Me.Label4.Text = "From :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(306, 59)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label3.TabIndex = 67
			Me.Label3.Text = "To :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(309, 78)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 65
			Me.GroupBox2.Controls.Add(Me.GelButton5)
			Me.GroupBox2.Controls.Add(Me.GelButton4)
			Me.GroupBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(10, 135)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(226, 93)
			Me.GroupBox2.TabIndex = 50
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Customer Outstanding Report"
			Me.GelButton5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton5.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton5.FlatAppearance.BorderSize = 0
			Me.GelButton5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton5.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton5.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton5.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton5.Image = CType(componentResourceManager.GetObject("GelButton5.Image"), Global.System.Drawing.Image)
			Me.GelButton5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton5.Location = New Global.System.Drawing.Point(115, 36)
			Me.GelButton5.Name = "GelButton5"
			Me.GelButton5.Size = New Global.System.Drawing.Size(103, 37)
			Me.GelButton5.TabIndex = 536
			Me.GelButton5.Text = "Payable"
			Me.GelButton5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton5.UseVisualStyleBackColor = False
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(6, 36)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(105, 37)
			Me.GelButton4.TabIndex = 535
			Me.GelButton4.Text = "Receivable"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-2, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(615, 45)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(148, 10)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(271, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Outstanding Balance Report"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(614, 296)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmDebtorsReport"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox2.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005D68 RID: 23912
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
