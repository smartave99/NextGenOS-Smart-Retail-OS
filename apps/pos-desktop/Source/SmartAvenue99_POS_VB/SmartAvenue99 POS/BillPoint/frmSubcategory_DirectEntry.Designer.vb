Namespace BillPoint
	' Token: 0x02000201 RID: 513
		Public Partial Class frmSubcategory_DirectEntry
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060093AC RID: 37804 RVA: 0x006AC7F0 File Offset: 0x006AA9F0
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

		' Token: 0x060093AD RID: 37805 RVA: 0x006AC840 File Offset: 0x006AAA40
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmSubcategory_DirectEntry))
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.cmbSubCategory = New Global.System.Windows.Forms.ComboBox()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.GroupBox2.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.GroupBox2.Controls.Add(Me.CheckBox1)
			Me.GroupBox2.Controls.Add(Me.cmbSubCategory)
			Me.GroupBox2.Controls.Add(Me.cmbCategory)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(12, 26)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(397, 83)
			Me.GroupBox2.TabIndex = 46
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Sub Category / Brand :"
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(314, 51)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(77, 17)
			Me.CheckBox1.TabIndex = 408
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Is Default "
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.CheckBox1.Visible = False
			Me.cmbSubCategory.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbSubCategory.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbSubCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSubCategory.FormattingEnabled = True
			Me.cmbSubCategory.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbSubCategory.Location = New Global.System.Drawing.Point(10, 19)
			Me.cmbSubCategory.Name = "cmbSubCategory"
			Me.cmbSubCategory.Size = New Global.System.Drawing.Size(374, 21)
			Me.cmbSubCategory.TabIndex = 0
			Me.cmbCategory.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Items.AddRange(New Object() { "General" })
			Me.cmbCategory.Location = New Global.System.Drawing.Point(68, 47)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(240, 21)
			Me.cmbCategory.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 50)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(55, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Category :"
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(308, 115)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(100, 31)
			Me.btnSave.TabIndex = 515
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.txtID.Location = New Global.System.Drawing.Point(12, 124)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(62, 20)
			Me.txtID.TabIndex = 516
			Me.txtID.TabStop = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources._12
			Me.Picture.Location = New Global.System.Drawing.Point(80, 121)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(30, 23)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 517
			Me.Picture.TabStop = False
			Me.Picture.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(369, 10)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 518
			Me.lblUser.Text = "lblUser"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ControlLightLight
			MyBase.ClientSize = New Global.System.Drawing.Size(420, 156)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.btnSave)
			MyBase.Controls.Add(Me.GroupBox2)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmSubcategory_DirectEntry"
			Me.Text = "New Sub Category"
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04004166 RID: 16742
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
