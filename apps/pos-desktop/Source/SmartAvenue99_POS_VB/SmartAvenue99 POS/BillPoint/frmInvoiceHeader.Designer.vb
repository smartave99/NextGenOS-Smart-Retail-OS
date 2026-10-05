Namespace BillPoint
	' Token: 0x020002A2 RID: 674
		Public Partial Class frmInvoiceHeader
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600ACA3 RID: 44195 RVA: 0x00735EB4 File Offset: 0x007340B4
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

		' Token: 0x0600ACA4 RID: 44196 RVA: 0x00735F04 File Offset: 0x00734104
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmInvoiceHeader))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Description = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Button3 = New Global.GelButtons.GelButton()
			Me.Button2 = New Global.GelButtons.GelButton()
			Me.Button5 = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.GelButtons.GelButton()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtU = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.txtTillID = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtUnit = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.txtU)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(517, 390)
			Me.Panel1.TabIndex = 4
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Description, Me.Column1, Me.Column2, Me.Column3 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(5, 42)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.Crimson
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(499, 151)
			Me.dgw.TabIndex = 40
			Me.dgw.TabStop = False
			Me.Description.HeaderText = "Sales Invoice Template Header"
			Me.Description.Name = "Description"
			Me.Description.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column1.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column1.HeaderText = "Previous Invoice Date Show"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Default Invoice Template"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Terminal ID"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Panel2.Controls.Add(Me.Button3)
			Me.Panel2.Controls.Add(Me.Button2)
			Me.Panel2.Controls.Add(Me.Button5)
			Me.Panel2.Controls.Add(Me.Button4)
			Me.Panel2.Location = New Global.System.Drawing.Point(381, 192)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(123, 193)
			Me.Panel2.TabIndex = 47
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(4, 97)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(116, 43)
			Me.Button3.TabIndex = 521
			Me.Button3.Text = "Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button2.FlatAppearance.BorderSize = 0
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.GradientBottom = Global.System.Drawing.Color.Red
			Me.Button2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(4, 144)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(116, 43)
			Me.Button2.TabIndex = 520
			Me.Button2.Text = "Delete"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button5.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button5.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button5.FlatAppearance.BorderSize = 0
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button5.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(4, 2)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(116, 43)
			Me.Button5.TabIndex = 519
			Me.Button5.Text = "New"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.Button4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button4.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(4, 49)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(116, 43)
			Me.Button4.TabIndex = 518
			Me.Button4.Text = "Save"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Arial", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(517, 31)
			Me.Label1.TabIndex = 46
			Me.Label1.Text = "Sales Invoice Setting"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtU.Location = New Global.System.Drawing.Point(236, 45)
			Me.txtU.Name = "txtU"
			Me.txtU.[ReadOnly] = True
			Me.txtU.Size = New Global.System.Drawing.Size(81, 20)
			Me.txtU.TabIndex = 44
			Me.txtU.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(256, 68)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 43
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.txtTillID)
			Me.Panel4.Controls.Add(Me.Label4)
			Me.Panel4.Controls.Add(Me.ComboBox2)
			Me.Panel4.Controls.Add(Me.ComboBox1)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.txtUnit)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 192)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(377, 178)
			Me.Panel4.TabIndex = 0
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(8, 134)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(77, 15)
			Me.Label5.TabIndex = 1683
			Me.Label5.Text = "Terminal ID :"
			Me.txtTillID.Location = New Global.System.Drawing.Point(183, 134)
			Me.txtTillID.Name = "txtTillID"
			Me.txtTillID.[ReadOnly] = True
			Me.txtTillID.Size = New Global.System.Drawing.Size(162, 21)
			Me.txtTillID.TabIndex = 1682
			Me.txtTillID.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(8, 99)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(148, 15)
			Me.Label4.TabIndex = 1681
			Me.Label4.Text = "Default Invoice Template :"
			Me.ComboBox2.BackColor = Global.System.Drawing.SystemColors.Info
			Me.ComboBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold)
			Me.ComboBox2.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Items.AddRange(New Object() { "Laser Printer-A4", "Laser Printer-A5", "Thermal Printer-3Inch", "Thermal Printer-4Inch", "Customise-A4", "Customise-A5", "Customise-3Inch", "Customise-4Inch", "3Inch-Style1", "3Inch-Style2", "3Inch-Style3", "3Inch-Style4", "3Inch-Style5", "3Inch-Style6", "3Inch-Style7", "3Inch-Style8", "3Inch-Style9", "3Inch-Style10", "4Inch-Style1", "4Inch-Style2", "4Inch-Style3", "4Inch-Style4", "4Inch-Style5", "4Inch-Style6", "4Inch-Style7", "4Inch-Style8", "4Inch-Style9", "4Inch-Style10", "A4-Style1", "A4-Style2", "A4-Style3", "A4-Style4", "A4-Style5", "A4-Style6", "A4-Style7", "A4-Style8", "A4-Style9", "A4-Style10", "A5-Style1", "A5-Style2", "A5-Style3", "A5-Style4", "A5-Style5", "A5-Style6", "A5-Style7", "A5-Style8", "A5-Style9", "A5-Style10" })
			Me.ComboBox2.Location = New Global.System.Drawing.Point(183, 99)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(162, 21)
			Me.ComboBox2.TabIndex = 2
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "No", "Yes" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(183, 62)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(162, 23)
			Me.ComboBox1.TabIndex = 1
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(8, 62)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(167, 15)
			Me.Label2.TabIndex = 404
			Me.Label2.Text = "Previous Invoice Date Show  :"
			Me.txtUnit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtUnit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtUnit.Location = New Global.System.Drawing.Point(183, 27)
			Me.txtUnit.Name = "txtUnit"
			Me.txtUnit.Size = New Global.System.Drawing.Size(162, 21)
			Me.txtUnit.TabIndex = 0
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(8, 27)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Header Name :"
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(517, 390)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmInvoiceHeader"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel2.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004841 RID: 18497
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
