Namespace BillPoint
	' Token: 0x020004D7 RID: 1239
		Public Partial Class frmPrintLoyaltyCard
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FC4C RID: 64588 RVA: 0x0096F6AC File Offset: 0x0096D8AC
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

		' Token: 0x0600FC4D RID: 64589 RVA: 0x0096F6FC File Offset: 0x0096D8FC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmPrintLoyaltyCard))
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.columnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtMemberName = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.txtMemberID = New Global.System.Windows.Forms.TextBox()
			Me.txtHotelName = New Global.System.Windows.Forms.TextBox()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.btnViewReport = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.listView1.BackColor = Global.System.Drawing.Color.Wheat
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader3, Me.ColumnHeader4, Me.ColumnHeader2 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.ForeColor = Global.System.Drawing.Color.Black
			Me.listView1.GridLines = True
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(10, 103)
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(745, 475)
			Me.listView1.TabIndex = 67
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.columnHeader1.Text = "Customer ID"
			Me.columnHeader1.Width = 100
			Me.columnHeader3.Text = "Customer Name"
			Me.columnHeader3.Width = 270
			Me.ColumnHeader4.Text = "Address"
			Me.ColumnHeader4.Width = 250
			Me.ColumnHeader2.Text = "Contact No."
			Me.ColumnHeader2.Width = 120
			Me.GroupBox1.Controls.Add(Me.txtMemberName)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(10, 9)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(223, 68)
			Me.GroupBox1.TabIndex = 68
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search By Customer Name"
			Me.txtMemberName.BackColor = Global.System.Drawing.Color.White
			Me.txtMemberName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMemberName.Location = New Global.System.Drawing.Point(8, 29)
			Me.txtMemberName.Name = "txtMemberName"
			Me.txtMemberName.Size = New Global.System.Drawing.Size(207, 21)
			Me.txtMemberName.TabIndex = 0
			Me.GroupBox2.Controls.Add(Me.txtMemberID)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(240, 9)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(187, 68)
			Me.GroupBox2.TabIndex = 69
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search By Customer ID"
			Me.txtMemberID.BackColor = Global.System.Drawing.Color.White
			Me.txtMemberID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtMemberID.Location = New Global.System.Drawing.Point(11, 29)
			Me.txtMemberID.Name = "txtMemberID"
			Me.txtMemberID.Size = New Global.System.Drawing.Size(168, 21)
			Me.txtMemberID.TabIndex = 0
			Me.txtHotelName.AccessibleRole = Global.System.Windows.Forms.AccessibleRole.Equation
			Me.txtHotelName.Location = New Global.System.Drawing.Point(639, 38)
			Me.txtHotelName.Name = "txtHotelName"
			Me.txtHotelName.[ReadOnly] = True
			Me.txtHotelName.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtHotelName.TabIndex = 70
			Me.txtHotelName.Visible = False
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Lime
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.Black
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(10, 81)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 17)
			Me.chkSelectAll.TabIndex = 430
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.GroupBox3.Controls.Add(Me.TextBox1)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(433, 9)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(186, 68)
			Me.GroupBox3.TabIndex = 70
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Search By Customer Contact No"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(9, 29)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(168, 21)
			Me.TextBox1.TabIndex = 0
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(210, 83)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 444
			Me.Label6.Text = "Records"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(123, 83)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 443
			Me.Label7.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(150, 80)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(60, 20)
			Me.txtTopResult.TabIndex = 442
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.btnViewReport.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnViewReport.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnViewReport.FlatAppearance.BorderSize = 0
			Me.btnViewReport.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnViewReport.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnViewReport.ForeColor = Global.System.Drawing.Color.White
			Me.btnViewReport.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnViewReport.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnViewReport.Image = CType(componentResourceManager.GetObject("btnViewReport.Image"), Global.System.Drawing.Image)
			Me.btnViewReport.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnViewReport.Location = New Global.System.Drawing.Point(631, 5)
			Me.btnViewReport.Name = "btnViewReport"
			Me.btnViewReport.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnViewReport.TabIndex = 519
			Me.btnViewReport.Text = "View Card"
			Me.btnViewReport.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnViewReport.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(631, 54)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(123, 43)
			Me.GelButton1.TabIndex = 518
			Me.GelButton1.Text = "&Reset"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(768, 590)
			MyBase.Controls.Add(Me.btnViewReport)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtTopResult)
			MyBase.Controls.Add(Me.GroupBox3)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.txtHotelName)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.listView1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmPrintLoyaltyCard"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Loyalty Card Print"
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400609F RID: 24735
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
