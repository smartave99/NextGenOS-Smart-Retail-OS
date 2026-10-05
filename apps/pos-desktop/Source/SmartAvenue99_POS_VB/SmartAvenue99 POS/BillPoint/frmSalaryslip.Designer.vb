Namespace BillPoint
	' Token: 0x0200036B RID: 875
		Public Partial Class frmSalaryslip
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CF09 RID: 53001 RVA: 0x00813468 File Offset: 0x00811668
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

		' Token: 0x0600CF0A RID: 53002 RVA: 0x008134B8 File Offset: 0x008116B8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSalaryslip))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.cmbPaymentID = New Global.System.Windows.Forms.ComboBox()
			Me.btnView = New Global.GelButtons.GelButton()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtCompanyName = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox3)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(447, 177)
			Me.Panel1.TabIndex = 2
			Me.GroupBox3.Location = New Global.System.Drawing.Point(413, 77)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(21, 87)
			Me.GroupBox3.TabIndex = 43
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Visible = False
			Me.GroupBox2.Controls.Add(Me.btnReset)
			Me.GroupBox2.Controls.Add(Me.cmbPaymentID)
			Me.GroupBox2.Controls.Add(Me.btnView)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 52)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(424, 87)
			Me.GroupBox2.TabIndex = 0
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search By Payment ID :"
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
			Me.btnReset.Location = New Global.System.Drawing.Point(292, 35)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(118, 29)
			Me.btnReset.TabIndex = 518
			Me.btnReset.Text = "Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.cmbPaymentID.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.Suggest
			Me.cmbPaymentID.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbPaymentID.FormattingEnabled = True
			Me.cmbPaymentID.Location = New Global.System.Drawing.Point(12, 42)
			Me.cmbPaymentID.Name = "cmbPaymentID"
			Me.cmbPaymentID.Size = New Global.System.Drawing.Size(139, 21)
			Me.cmbPaymentID.TabIndex = 0
			Me.btnView.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnView.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnView.FlatAppearance.BorderSize = 0
			Me.btnView.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnView.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnView.ForeColor = Global.System.Drawing.Color.White
			Me.btnView.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnView.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnView.Image = CType(componentResourceManager.GetObject("btnView.Image"), Global.System.Drawing.Image)
			Me.btnView.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnView.Location = New Global.System.Drawing.Point(176, 35)
			Me.btnView.Name = "btnView"
			Me.btnView.Size = New Global.System.Drawing.Size(110, 28)
			Me.btnView.TabIndex = 519
			Me.btnView.Text = "View Report"
			Me.btnView.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnView.UseVisualStyleBackColor = False
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(9, 22)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(68, 13)
			Me.Label9.TabIndex = 51
			Me.Label9.Text = "Payment ID :"
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.txtCompanyName)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(447, 31)
			Me.Panel2.TabIndex = 0
			Me.txtCompanyName.Location = New Global.System.Drawing.Point(4, 8)
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
			Me.Label1.Location = New Global.System.Drawing.Point(116, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(208, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Employee Salary Slip"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(447, 177)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSalaryslip"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400531A RID: 21274
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
