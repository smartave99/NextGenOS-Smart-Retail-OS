Namespace BillPoint
	' Token: 0x02000582 RID: 1410
		Public Partial Class frmSalesmanLedger
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011114 RID: 69908 RVA: 0x009E4130 File Offset: 0x009E2330
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

		' Token: 0x06011115 RID: 69909 RVA: 0x009E4180 File Offset: 0x009E2380
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSalesmanLedger))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.btnSelection = New Global.System.Windows.Forms.Button()
			Me.txtSalesmanName = New Global.System.Windows.Forms.TextBox()
			Me.txtSalesmanID = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel2.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(859, 171)
			Me.Panel1.TabIndex = 2
			Me.GroupBox2.Controls.Add(Me.GelButton2)
			Me.GroupBox2.Controls.Add(Me.GelButton3)
			Me.GroupBox2.Controls.Add(Me.btnSelection)
			Me.GroupBox2.Controls.Add(Me.txtSalesmanName)
			Me.GroupBox2.Controls.Add(Me.txtSalesmanID)
			Me.GroupBox2.Controls.Add(Me.Label5)
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.dtpDateTo)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.Label4)
			Me.GroupBox2.Controls.Add(Me.dtpDateFrom)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 57)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(782, 75)
			Me.GroupBox2.TabIndex = 0
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search by Salesman Name and Date"
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
			Me.GelButton2.Location = New Global.System.Drawing.Point(537, 28)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(122, 37)
			Me.GelButton2.TabIndex = 538
			Me.GelButton2.Text = "View Report"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(665, 28)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 539
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.btnSelection.BackColor = Global.System.Drawing.Color.Lime
			Me.btnSelection.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSelection.Location = New Global.System.Drawing.Point(216, 18)
			Me.btnSelection.Name = "btnSelection"
			Me.btnSelection.Size = New Global.System.Drawing.Size(29, 21)
			Me.btnSelection.TabIndex = 0
			Me.btnSelection.Text = "..."
			Me.btnSelection.UseVisualStyleBackColor = False
			Me.txtSalesmanName.Location = New Global.System.Drawing.Point(110, 45)
			Me.txtSalesmanName.Name = "txtSalesmanName"
			Me.txtSalesmanName.[ReadOnly] = True
			Me.txtSalesmanName.Size = New Global.System.Drawing.Size(159, 20)
			Me.txtSalesmanName.TabIndex = 5
			Me.txtSalesmanID.Location = New Global.System.Drawing.Point(110, 19)
			Me.txtSalesmanID.Name = "txtSalesmanID"
			Me.txtSalesmanID.[ReadOnly] = True
			Me.txtSalesmanID.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtSalesmanID.TabIndex = 4
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(16, 45)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(90, 13)
			Me.Label5.TabIndex = 17
			Me.Label5.Text = "Salesman Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(16, 19)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label3.TabIndex = 16
			Me.Label3.Text = "Salesman ID :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(400, 45)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateTo.TabIndex = 2
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(397, 26)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label2.TabIndex = 13
			Me.Label2.Text = "To :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(272, 26)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 12
			Me.Label4.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(275, 45)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 20)
			Me.dtpDateFrom.TabIndex = 1
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 1)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(859, 34)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(331, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(173, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Salesman Ledger"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(859, 171)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmSalesmanLedger"
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

		' Token: 0x04006675 RID: 26229
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
