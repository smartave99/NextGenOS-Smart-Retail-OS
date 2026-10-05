Namespace BillPoint
	' Token: 0x020000D9 RID: 217
		Public Partial Class frmCustomerMobileAppSender
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060026EC RID: 9964 RVA: 0x00188E48 File Offset: 0x00187048
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

		' Token: 0x060026ED RID: 9965 RVA: 0x00188E98 File Offset: 0x00187098
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerMobileAppSender))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.PictureBox3 = New Global.System.Windows.Forms.PictureBox()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.btnNew = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.CheckBox3 = New Global.System.Windows.Forms.CheckBox()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.colStatus = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.PictureBox3)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.CheckBox3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(926, 500)
			Me.Panel1.TabIndex = 0
			Me.PictureBox3.Location = New Global.System.Drawing.Point(763, 40)
			Me.PictureBox3.Name = "PictureBox3"
			Me.PictureBox3.Size = New Global.System.Drawing.Size(143, 131)
			Me.PictureBox3.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox3.TabIndex = 1688
			Me.PictureBox3.TabStop = False
			Me.GroupBox2.Controls.Add(Me.Label3)
			Me.GroupBox2.Controls.Add(Me.Label2)
			Me.GroupBox2.Controls.Add(Me.TextBox5)
			Me.GroupBox2.Controls.Add(Me.TextBox4)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 137)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(459, 68)
			Me.GroupBox2.TabIndex = 1
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(241, 21)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(149, 13)
			Me.Label3.TabIndex = 3
			Me.Label3.Text = "Search By Customer Contact :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(15, 21)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(140, 13)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "Search By Customer Name :"
			Me.TextBox5.Location = New Global.System.Drawing.Point(244, 37)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.Size = New Global.System.Drawing.Size(196, 20)
			Me.TextBox5.TabIndex = 1
			Me.TextBox4.Location = New Global.System.Drawing.Point(18, 37)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.Size = New Global.System.Drawing.Size(196, 20)
			Me.TextBox4.TabIndex = 0
			Me.GroupBox1.Controls.Add(Me.btnNew)
			Me.GroupBox1.Controls.Add(Me.Button2)
			Me.GroupBox1.Controls.Add(Me.TextBox3)
			Me.GroupBox1.Controls.Add(Me.TextBox2)
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.CheckBox2)
			Me.GroupBox1.Controls.Add(Me.CheckBox1)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 40)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(690, 96)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Info :"
			Me.btnNew.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNew.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.Image = Global.BillPoint.My.Resources.Resources.Reset2_32x32
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(592, 55)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(90, 36)
			Me.btnNew.TabIndex = 6
			Me.btnNew.Text = "&Reset"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(591, 12)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(91, 39)
			Me.Button2.TabIndex = 5
			Me.Button2.Text = "Send"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.TextBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox3.Location = New Global.System.Drawing.Point(166, 15)
			Me.TextBox3.Multiline = True
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.TextBox3.Size = New Global.System.Drawing.Size(416, 33)
			Me.TextBox3.TabIndex = 0
			Me.TextBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox2.Location = New Global.System.Drawing.Point(166, 71)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(416, 20)
			Me.TextBox2.TabIndex = 4
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Location = New Global.System.Drawing.Point(166, 49)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(416, 20)
			Me.TextBox1.TabIndex = 2
			Me.TextBox1.Text = "https://drive.google.com/file/d/1MEsc02hz0A3-b8sjyViGO22NMemFemap/view?usp=sharing"
			Me.CheckBox2.AutoSize = True
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.Location = New Global.System.Drawing.Point(9, 71)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(98, 17)
			Me.CheckBox2.TabIndex = 3
			Me.CheckBox2.Text = "Video Clip link :"
			Me.CheckBox2.UseVisualStyleBackColor = True
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Location = New Global.System.Drawing.Point(9, 49)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(151, 17)
			Me.CheckBox1.TabIndex = 1
			Me.CheckBox1.Text = "Customer Mobile Apk link :"
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(6, 23)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(116, 13)
			Me.Label4.TabIndex = 2
			Me.Label4.Text = "Text Message (If Any) :"
			Me.CheckBox3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.CheckBox3.BackColor = Global.System.Drawing.Color.White
			Me.CheckBox3.CheckAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.CheckBox3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.CheckBox3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox3.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.CheckBox3.Location = New Global.System.Drawing.Point(809, 174)
			Me.CheckBox3.Name = "CheckBox3"
			Me.CheckBox3.Size = New Global.System.Drawing.Size(111, 30)
			Me.CheckBox3.TabIndex = 1687
			Me.CheckBox3.TabStop = False
			Me.CheckBox3.Text = "All (Mark/Unmark)"
			Me.CheckBox3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox3.UseVisualStyleBackColor = False
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column1, Me.colStatus })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(4, 208)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 35
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(916, 286)
			Me.dgw.TabIndex = 421
			Me.dgw.TabStop = False
			Me.Column4.HeaderText = "Customer ID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "Customer Name"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Mobile Apk ID"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Contact No."
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column1.HeaderText = "Mark/Unmark"
			Me.Column1.Name = "Column1"
			Me.colStatus.HeaderText = "Status"
			Me.colStatus.Name = "colStatus"
			Me.colStatus.[ReadOnly] = True
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(916, 34)
			Me.Label1.TabIndex = 1
			Me.Label1.Text = "WhatsApp Bulk Mobile Apk Sender to Customers"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(926, 500)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomerMobileAppSender"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000FFD RID: 4093
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
