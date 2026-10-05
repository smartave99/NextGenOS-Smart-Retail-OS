Namespace BillPoint
	' Token: 0x02000293 RID: 659
		Public Partial Class frmBulkWhatsappDoc
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600A773 RID: 42867 RVA: 0x00702D98 File Offset: 0x00700F98
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

		' Token: 0x0600A774 RID: 42868 RVA: 0x00702DE8 File Offset: 0x00700FE8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBulkWhatsappDoc))
			Me.ListView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.RichTextBox1 = New Global.System.Windows.Forms.RichTextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Start = New Global.System.Windows.Forms.Button()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.openAttach = New Global.System.Windows.Forms.OpenFileDialog()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.tBoxAttach = New Global.System.Windows.Forms.TextBox()
			Me.label3 = New Global.System.Windows.Forms.Label()
			Me.btnAttachBrowse = New Global.System.Windows.Forms.Button()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.GroupBox7 = New Global.System.Windows.Forms.GroupBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtSlNo2 = New Global.System.Windows.Forms.TextBox()
			Me.txtSlNo1 = New Global.System.Windows.Forms.TextBox()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.lblAttach = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox7.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.ListView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.ListView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.ListView1.CheckBoxes = True
			Me.ListView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11 })
			Me.ListView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView1.GridLines = True
			Me.ListView1.HideSelection = False
			Me.ListView1.Location = New Global.System.Drawing.Point(12, 70)
			Me.ListView1.Name = "ListView1"
			Me.ListView1.Size = New Global.System.Drawing.Size(636, 347)
			Me.ListView1.TabIndex = 473
			Me.ListView1.TabStop = False
			Me.ListView1.UseCompatibleStateImageBehavior = False
			Me.ListView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader6.Text = "Customer ID"
			Me.ColumnHeader6.Width = 150
			Me.ColumnHeader7.Text = "Customer Name"
			Me.ColumnHeader7.Width = 230
			Me.ColumnHeader1.Text = "Whatsapp Number"
			Me.ColumnHeader1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader1.Width = 120
			Me.ColumnHeader2.Text = "SENT STATUS"
			Me.ColumnHeader2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader2.Width = 130
			Me.ColumnHeader3.Text = "Address"
			Me.ColumnHeader3.Width = 250
			Me.ColumnHeader4.Text = "City"
			Me.ColumnHeader4.Width = 200
			Me.ColumnHeader5.Text = "State"
			Me.ColumnHeader5.Width = 150
			Me.ColumnHeader8.Text = "Pin"
			Me.ColumnHeader8.Width = 100
			Me.ColumnHeader9.Text = "Card No"
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader10.Text = "Route"
			Me.ColumnHeader10.Width = 150
			Me.ColumnHeader11.Text = "Remarks"
			Me.ColumnHeader11.Width = 200
			Me.RichTextBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.RichTextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.RichTextBox1.Location = New Global.System.Drawing.Point(654, 70)
			Me.RichTextBox1.Name = "RichTextBox1"
			Me.RichTextBox1.Size = New Global.System.Drawing.Size(315, 183)
			Me.RichTextBox1.TabIndex = 476
			Me.RichTextBox1.Text = ""
			Me.Label2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.Black
			Me.Label2.Location = New Global.System.Drawing.Point(651, 51)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(133, 16)
			Me.Label2.TabIndex = 477
			Me.Label2.Text = "Enter Text Message :"
			Me.Start.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Start.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Start.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Start.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Start.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Start.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Start.ForeColor = Global.System.Drawing.Color.White
			Me.Start.ImageAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Start.Location = New Global.System.Drawing.Point(796, 360)
			Me.Start.Name = "Start"
			Me.Start.Size = New Global.System.Drawing.Size(173, 34)
			Me.Start.TabIndex = 501
			Me.Start.Text = "Agni-WhatsApp"
			Me.Start.UseVisualStyleBackColor = False
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label6.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 20.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.Black
			Me.Label6.Location = New Global.System.Drawing.Point(5, 0)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(444, 37)
			Me.Label6.TabIndex = 490
			Me.Label6.Text = "Bulk WhatsApp Documents Sender"
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Tomato
			Me.chkSelectAll.Checked = True
			Me.chkSelectAll.CheckState = Global.System.Windows.Forms.CheckState.Checked
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(12, 47)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(70, 20)
			Me.chkSelectAll.TabIndex = 491
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.openAttach.FileName = "OpenFileDialog1"
			Me.TextBox1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(204, 28)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(200, 21)
			Me.TextBox1.TabIndex = 496
			Me.TextBox1.TabStop = False
			Me.Label7.BackColor = Global.System.Drawing.Color.Tomato
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(9, 29)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(71, 20)
			Me.Label7.TabIndex = 497
			Me.Label7.Text = "Search By :"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.tBoxAttach.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.tBoxAttach.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.tBoxAttach.Location = New Global.System.Drawing.Point(654, 281)
			Me.tBoxAttach.Name = "tBoxAttach"
			Me.tBoxAttach.[ReadOnly] = True
			Me.tBoxAttach.Size = New Global.System.Drawing.Size(315, 20)
			Me.tBoxAttach.TabIndex = 499
			Me.tBoxAttach.TabStop = False
			Me.label3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.label3.AutoSize = True
			Me.label3.ForeColor = Global.System.Drawing.Color.Black
			Me.label3.Location = New Global.System.Drawing.Point(651, 265)
			Me.label3.Name = "label3"
			Me.label3.Size = New Global.System.Drawing.Size(38, 13)
			Me.label3.TabIndex = 498
			Me.label3.Text = "Attach"
			Me.btnAttachBrowse.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnAttachBrowse.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnAttachBrowse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAttachBrowse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAttachBrowse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.btnAttachBrowse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAttachBrowse.ForeColor = Global.System.Drawing.Color.White
			Me.btnAttachBrowse.Image = CType(componentResourceManager.GetObject("btnAttachBrowse.Image"), Global.System.Drawing.Image)
			Me.btnAttachBrowse.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnAttachBrowse.Location = New Global.System.Drawing.Point(881, 307)
			Me.btnAttachBrowse.Name = "btnAttachBrowse"
			Me.btnAttachBrowse.Size = New Global.System.Drawing.Size(89, 34)
			Me.btnAttachBrowse.TabIndex = 500
			Me.btnAttachBrowse.Text = "Browse"
			Me.btnAttachBrowse.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnAttachBrowse.UseVisualStyleBackColor = False
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Name", "WhatApp No", "Address", "City", "State", "Pin Code", "Card No", "Route", "Remarks" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(81, 28)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(121, 21)
			Me.ComboBox1.TabIndex = 495
			Me.GroupBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox1.Location = New Global.System.Drawing.Point(12, 423)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(410, 80)
			Me.GroupBox1.TabIndex = 503
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search :"
			Me.GroupBox7.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.GroupBox7.Controls.Add(Me.Label1)
			Me.GroupBox7.Controls.Add(Me.GelButton1)
			Me.GroupBox7.Controls.Add(Me.Label4)
			Me.GroupBox7.Controls.Add(Me.txtSlNo2)
			Me.GroupBox7.Controls.Add(Me.txtSlNo1)
			Me.GroupBox7.ForeColor = Global.System.Drawing.Color.Black
			Me.GroupBox7.Location = New Global.System.Drawing.Point(428, 423)
			Me.GroupBox7.Name = "GroupBox7"
			Me.GroupBox7.Size = New Global.System.Drawing.Size(274, 80)
			Me.GroupBox7.TabIndex = 504
			Me.GroupBox7.TabStop = False
			Me.GroupBox7.Text = "Search By Customer Serial No :"
			Me.Label1.AutoSize = True
			Me.Label1.ForeColor = Global.System.Drawing.Color.Black
			Me.Label1.Location = New Global.System.Drawing.Point(71, 22)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label1.TabIndex = 15
			Me.Label1.Text = "To :"
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(159, 24)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 37)
			Me.GelButton1.TabIndex = 540
			Me.GelButton1.Text = "Get Data"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Black
			Me.Label4.Location = New Global.System.Drawing.Point(6, 22)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label4.TabIndex = 14
			Me.Label4.Text = "From :"
			Me.txtSlNo2.BackColor = Global.System.Drawing.Color.White
			Me.txtSlNo2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSlNo2.Location = New Global.System.Drawing.Point(74, 40)
			Me.txtSlNo2.Name = "txtSlNo2"
			Me.txtSlNo2.Size = New Global.System.Drawing.Size(58, 21)
			Me.txtSlNo2.TabIndex = 7
			Me.txtSlNo1.BackColor = Global.System.Drawing.Color.White
			Me.txtSlNo1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSlNo1.Location = New Global.System.Drawing.Point(9, 40)
			Me.txtSlNo1.Name = "txtSlNo1"
			Me.txtSlNo1.Size = New Global.System.Drawing.Size(58, 21)
			Me.txtSlNo1.TabIndex = 6
			Me.PictureBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.PictureBox1.Image = CType(componentResourceManager.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Me.PictureBox1.Location = New Global.System.Drawing.Point(753, 435)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(226, 75)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 505
			Me.PictureBox1.TabStop = False
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
			Me.GelButton3.Location = New Global.System.Drawing.Point(684, 360)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(104, 37)
			Me.GelButton3.TabIndex = 541
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(676, 322)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(87, 37)
			Me.GelButton2.TabIndex = 541
			Me.GelButton2.Text = "UPLOAD"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GelButton2.Visible = False
			Me.lblAttach.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblAttach.AutoSize = True
			Me.lblAttach.ForeColor = Global.System.Drawing.Color.Black
			Me.lblAttach.Location = New Global.System.Drawing.Point(741, 265)
			Me.lblAttach.Name = "lblAttach"
			Me.lblAttach.Size = New Global.System.Drawing.Size(38, 13)
			Me.lblAttach.TabIndex = 542
			Me.lblAttach.Text = "Attach"
			Me.lblAttach.Visible = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Popup
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.Button1.Location = New Global.System.Drawing.Point(796, 397)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(173, 34)
			Me.Button1.TabIndex = 543
			Me.Button1.Text = "Tejas WhatsApp"
			Me.Button1.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(982, 515)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.lblAttach)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.GelButton3)
			MyBase.Controls.Add(Me.PictureBox1)
			MyBase.Controls.Add(Me.GroupBox7)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.btnAttachBrowse)
			MyBase.Controls.Add(Me.tBoxAttach)
			MyBase.Controls.Add(Me.label3)
			MyBase.Controls.Add(Me.ListView1)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.Start)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.RichTextBox1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmBulkWhatsappDoc"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox7.ResumeLayout(False)
			Me.GroupBox7.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040045CF RID: 17871
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
