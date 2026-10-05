Namespace BillPoint
	' Token: 0x020004B8 RID: 1208
		Public Partial Class frmCustomerBulkUpdate
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F20D RID: 61965 RVA: 0x00914B6C File Offset: 0x00912D6C
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

		' Token: 0x0600F20E RID: 61966 RVA: 0x00914BBC File Offset: 0x00912DBC
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerBulkUpdate))
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox42 = New Global.System.Windows.Forms.TextBox()
			Me.ColumnHeader18 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader17 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader16 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader15 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader13 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader12 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader14 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader19 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader20 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader21 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader22 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtTopResult = New Global.System.Windows.Forms.TextBox()
			Me.btnReset = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.ColumnHeader23 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader24 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader25 = New Global.System.Windows.Forms.ColumnHeader()
			Me.chkLoyality = New Global.System.Windows.Forms.CheckBox()
			Me.cboxLoyalityStatus = New Global.System.Windows.Forms.ComboBox()
			MyBase.SuspendLayout()
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(402, 10)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(147, 17)
			Me.Label2.TabIndex = 84
			Me.Label2.Text = "Search By Contact No :"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(211, 10)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(177, 17)
			Me.Label1.TabIndex = 83
			Me.Label1.Text = "Search By Customer Name :"
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Red
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(12, 34)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(81, 21)
			Me.chkSelectAll.TabIndex = 82
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(214, 30)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(173, 22)
			Me.TextBox1.TabIndex = 76
			Me.TextBox42.Location = New Global.System.Drawing.Point(1045, 14)
			Me.TextBox42.Name = "TextBox42"
			Me.TextBox42.Size = New Global.System.Drawing.Size(21, 20)
			Me.TextBox42.TabIndex = 81
			Me.TextBox42.TabStop = False
			Me.TextBox42.Visible = False
			Me.ColumnHeader18.DisplayIndex = 16
			Me.ColumnHeader18.Text = "CIN"
			Me.ColumnHeader18.Width = 100
			Me.ColumnHeader17.DisplayIndex = 15
			Me.ColumnHeader17.Text = "PAN"
			Me.ColumnHeader17.Width = 100
			Me.ColumnHeader16.DisplayIndex = 14
			Me.ColumnHeader16.Text = "GSTIN"
			Me.ColumnHeader16.Width = 100
			Me.ColumnHeader15.DisplayIndex = 13
			Me.ColumnHeader15.Text = "IFSC"
			Me.ColumnHeader15.Width = 100
			Me.ColumnHeader13.Text = "Bank"
			Me.ColumnHeader13.Width = 100
			Me.ColumnHeader12.Text = "A/c Name"
			Me.ColumnHeader12.Width = 100
			Me.ColumnHeader11.Text = "Bank A/c No"
			Me.ColumnHeader11.Width = 100
			Me.ColumnHeader10.Text = "Remarks"
			Me.ColumnHeader10.Width = 100
			Me.ColumnHeader9.Text = "Email ID"
			Me.ColumnHeader9.Width = 150
			Me.ColumnHeader8.Text = "Contact No"
			Me.ColumnHeader8.Width = 100
			Me.ColumnHeader7.Text = "Zip Code"
			Me.ColumnHeader7.Width = 100
			Me.ColumnHeader6.Text = "State"
			Me.ColumnHeader6.Width = 130
			Me.ColumnHeader5.Text = "City"
			Me.ColumnHeader5.Width = 100
			Me.ColumnHeader4.Text = "Address"
			Me.ColumnHeader4.Width = 180
			Me.ColumnHeader3.Text = "Customer Name"
			Me.ColumnHeader3.Width = 200
			Me.ColumnHeader2.Text = "Customer ID"
			Me.ColumnHeader2.Width = 100
			Me.ColumnHeader1.Text = "ID"
			Me.TextBox2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(405, 30)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(173, 22)
			Me.TextBox2.TabIndex = 77
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.Aquamarine
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(12, 58)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(1054, 399)
			Me.listView1.TabIndex = 80
			Me.listView1.TabStop = False
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader14.DisplayIndex = 17
			Me.ColumnHeader14.Text = "Branch"
			Me.ColumnHeader14.Width = 100
			Me.ColumnHeader19.Text = "TCS (Y/N)"
			Me.ColumnHeader19.Width = 100
			Me.ColumnHeader20.Text = "Limit"
			Me.ColumnHeader20.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader20.Width = 120
			Me.ColumnHeader21.Text = "Limit Status"
			Me.ColumnHeader21.Width = 100
			Me.ColumnHeader22.Text = "Turn Around Day"
			Me.ColumnHeader22.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader22.Width = 100
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(93, 10)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label6.TabIndex = 438
			Me.Label6.Text = "Records"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(6, 10)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label7.TabIndex = 437
			Me.Label7.Text = "Top"
			Me.txtTopResult.Location = New Global.System.Drawing.Point(33, 7)
			Me.txtTopResult.Name = "txtTopResult"
			Me.txtTopResult.Size = New Global.System.Drawing.Size(60, 20)
			Me.txtTopResult.TabIndex = 436
			Me.txtTopResult.TabStop = False
			Me.txtTopResult.Text = "50"
			Me.txtTopResult.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
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
			Me.btnReset.Location = New Global.System.Drawing.Point(916, 6)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnReset.TabIndex = 514
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(787, 6)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(123, 43)
			Me.btnSave.TabIndex = 515
			Me.btnSave.Text = "&Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.ColumnHeader23.Text = "Opening Loyality Bal"
			Me.ColumnHeader24.Text = "Type"
			Me.ColumnHeader25.Text = "Loyality (Enable/Disable)"
			Me.chkLoyality.AutoSize = True
			Me.chkLoyality.Location = New Global.System.Drawing.Point(613, 11)
			Me.chkLoyality.Name = "chkLoyality"
			Me.chkLoyality.Size = New Global.System.Drawing.Size(155, 17)
			Me.chkLoyality.TabIndex = 1802
			Me.chkLoyality.Text = "For Loyality Enable/Disable"
			Me.chkLoyality.UseVisualStyleBackColor = True
			Me.cboxLoyalityStatus.FormattingEnabled = True
			Me.cboxLoyalityStatus.Items.AddRange(New Object() { "Enable", "Disable" })
			Me.cboxLoyalityStatus.Location = New Global.System.Drawing.Point(613, 31)
			Me.cboxLoyalityStatus.Name = "cboxLoyalityStatus"
			Me.cboxLoyalityStatus.Size = New Global.System.Drawing.Size(121, 21)
			Me.cboxLoyalityStatus.TabIndex = 1803
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(1078, 467)
			MyBase.Controls.Add(Me.cboxLoyalityStatus)
			MyBase.Controls.Add(Me.chkLoyality)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.btnReset)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.txtTopResult)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.TextBox42)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.listView1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.Name = "frmCustomerBulkUpdate"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Customer Bulk Editor"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04005C72 RID: 23666
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
