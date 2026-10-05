Namespace BillPoint
	' Token: 0x0200032F RID: 815
		Public Partial Class frmBroker
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600BF4D RID: 48973 RVA: 0x0079E938 File Offset: 0x0079CB38
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

		' Token: 0x0600BF4E RID: 48974 RVA: 0x0079E988 File Offset: 0x0079CB88
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmBroker))
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.txtEmail = New Global.System.Windows.Forms.TextBox()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cmbSalesmanName = New Global.System.Windows.Forms.ComboBox()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.button3 = New Global.GelButtons.GelButton()
			Me.button1 = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.button2 = New Global.GelButtons.GelButton()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label33 = New Global.System.Windows.Forms.Label()
			Me.txtCommissionPer = New Global.System.Windows.Forms.TextBox()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.BStartCapture = New Global.System.Windows.Forms.Button()
			Me.Browse = New Global.System.Windows.Forms.Button()
			Me.BRemove = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtSalesmanID = New Global.System.Windows.Forms.TextBox()
			Me.txtAddress = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtContactNo = New Global.System.Windows.Forms.TextBox()
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.Panel5.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(558, 194)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label8"
			label.Size = New Global.System.Drawing.Size(25, 15)
			label.TabIndex = 290
			label.Text = "OR"
			Me.ErrorProvider1.ContainerControl = Me
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(72, 15)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1727
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(355, 1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(125, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Broker Entry"
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(618, 22)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.FromArgb(192, 255, 255)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.ComboBox1)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(3, 183)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(470, 53)
			Me.GroupBox1.TabIndex = 365
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Search :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(243, 8)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label6.TabIndex = 298
			Me.Label6.Text = "Search :"
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(82, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label4.TabIndex = 297
			Me.Label4.Text = "Select Type :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(246, 27)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(166, 21)
			Me.TextBox1.TabIndex = 3
			Me.TextBox1.TabStop = False
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Broker Name", "Broker Contact" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(85, 26)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(135, 23)
			Me.ComboBox1.TabIndex = 0
			Me.ComboBox1.TabStop = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(17, 14)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1728
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.txtID)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(816, 29)
			Me.Panel2.TabIndex = 0
			Me.txtID.Location = New Global.System.Drawing.Point(669, 21)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(28, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.Column5.HeaderText = "Photo"
			Me.Column5.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column5.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.Automatic
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.txtEmail)
			Me.Panel5.Location = New Global.System.Drawing.Point(297, 6)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(111, 25)
			Me.Panel5.TabIndex = 4
			Me.Panel5.Visible = False
			Me.txtEmail.Location = New Global.System.Drawing.Point(96, 9)
			Me.txtEmail.Name = "txtEmail"
			Me.txtEmail.[ReadOnly] = True
			Me.txtEmail.Size = New Global.System.Drawing.Size(10, 21)
			Me.txtEmail.TabIndex = 8
			Me.txtEmail.TabStop = False
			Me.txtEmail.Visible = False
			Me.Column12.HeaderText = "Commission %"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column9.HeaderText = "Contact No."
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column8.HeaderText = "Address"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 200
			Me.Column3.HeaderText = "Broker Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 180
			Me.Column2.HeaderText = "Broker ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 70
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column8, Me.Column9, Me.Column12, Me.Column5 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(3, 240)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowTemplate.Height = 50
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(787, 138)
			Me.dgw.TabIndex = 364
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			Me.cmbSalesmanName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbSalesmanName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbSalesmanName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbSalesmanName.FormattingEnabled = True
			Me.cmbSalesmanName.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbSalesmanName.Location = New Global.System.Drawing.Point(125, 37)
			Me.cmbSalesmanName.Name = "cmbSalesmanName"
			Me.cmbSalesmanName.Size = New Global.System.Drawing.Size(329, 23)
			Me.cmbSalesmanName.TabIndex = 0
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Location = New Global.System.Drawing.Point(5, 2)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(816, 431)
			Me.Panel1.TabIndex = 4
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Panel3)
			Me.Panel4.Controls.Add(Me.GroupBox1)
			Me.Panel4.Controls.Add(Me.Panel5)
			Me.Panel4.Controls.Add(Me.dgw)
			Me.Panel4.Controls.Add(Me.cmbSalesmanName)
			Me.Panel4.Controls.Add(Me.Label16)
			Me.Panel4.Controls.Add(Me.Label13)
			Me.Panel4.Controls.Add(Me.Label33)
			Me.Panel4.Controls.Add(Me.txtCommissionPer)
			Me.Panel4.Controls.Add(Me.Label11)
			Me.Panel4.Controls.Add(Me.Picture)
			Me.Panel4.Controls.Add(Me.BStartCapture)
			Me.Panel4.Controls.Add(Me.Browse)
			Me.Panel4.Controls.Add(label)
			Me.Panel4.Controls.Add(Me.BRemove)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.txtSalesmanID)
			Me.Panel4.Controls.Add(Me.txtAddress)
			Me.Panel4.Controls.Add(Me.Label5)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.txtContactNo)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(9, 41)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(795, 383)
			Me.Panel4.TabIndex = 0
			Me.Panel3.Controls.Add(Me.button3)
			Me.Panel3.Controls.Add(Me.button1)
			Me.Panel3.Controls.Add(Me.btnNew)
			Me.Panel3.Controls.Add(Me.button2)
			Me.Panel3.Location = New Global.System.Drawing.Point(671, 3)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(119, 199)
			Me.Panel3.TabIndex = 366
			Me.button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.button3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.button3.FlatAppearance.BorderSize = 0
			Me.button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.button3.ForeColor = Global.System.Drawing.Color.White
			Me.button3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.button3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.button3.Image = CType(componentResourceManager.GetObject("button3.Image"), Global.System.Drawing.Image)
			Me.button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.button3.Location = New Global.System.Drawing.Point(3, 100)
			Me.button3.Name = "button3"
			Me.button3.Size = New Global.System.Drawing.Size(114, 43)
			Me.button3.TabIndex = 517
			Me.button3.Text = "Update"
			Me.button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.button3.UseVisualStyleBackColor = False
			Me.button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.button1.FlatAppearance.BorderSize = 0
			Me.button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.button1.ForeColor = Global.System.Drawing.Color.White
			Me.button1.GradientBottom = Global.System.Drawing.Color.Red
			Me.button1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.button1.Image = CType(componentResourceManager.GetObject("button1.Image"), Global.System.Drawing.Image)
			Me.button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.button1.Location = New Global.System.Drawing.Point(3, 147)
			Me.button1.Name = "button1"
			Me.button1.Size = New Global.System.Drawing.Size(114, 43)
			Me.button1.TabIndex = 516
			Me.button1.Text = "Delete"
			Me.button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.button1.UseVisualStyleBackColor = False
			Me.btnNew.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnNew.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnNew.FlatAppearance.BorderSize = 0
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnNew.Image = CType(componentResourceManager.GetObject("btnNew.Image"), Global.System.Drawing.Image)
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(3, 5)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(114, 43)
			Me.btnNew.TabIndex = 515
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.button2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.button2.FlatAppearance.BorderSize = 0
			Me.button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.button2.ForeColor = Global.System.Drawing.Color.White
			Me.button2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.button2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.button2.Image = CType(componentResourceManager.GetObject("button2.Image"), Global.System.Drawing.Image)
			Me.button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.button2.Location = New Global.System.Drawing.Point(3, 52)
			Me.button2.Name = "button2"
			Me.button2.Size = New Global.System.Drawing.Size(114, 43)
			Me.button2.TabIndex = 514
			Me.button2.Text = "Save"
			Me.button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.button2.UseVisualStyleBackColor = False
			Me.Label16.AutoSize = True
			Me.Label16.ForeColor = Global.System.Drawing.Color.Red
			Me.Label16.Location = New Global.System.Drawing.Point(295, 122)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(12, 15)
			Me.Label16.TabIndex = 363
			Me.Label16.Text = "*"
			Me.Label13.AutoSize = True
			Me.Label13.ForeColor = Global.System.Drawing.Color.Red
			Me.Label13.Location = New Global.System.Drawing.Point(457, 83)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(12, 15)
			Me.Label13.TabIndex = 360
			Me.Label13.Text = "*"
			Me.Label33.AutoSize = True
			Me.Label33.ForeColor = Global.System.Drawing.Color.Red
			Me.Label33.Location = New Global.System.Drawing.Point(457, 42)
			Me.Label33.Name = "Label33"
			Me.Label33.Size = New Global.System.Drawing.Size(12, 15)
			Me.Label33.TabIndex = 359
			Me.Label33.Text = "*"
			Me.txtCommissionPer.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtCommissionPer.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCommissionPer.Location = New Global.System.Drawing.Point(125, 146)
			Me.txtCommissionPer.Name = "txtCommissionPer"
			Me.txtCommissionPer.Size = New Global.System.Drawing.Size(102, 21)
			Me.txtCommissionPer.TabIndex = 3
			Me.txtCommissionPer.Text = "0.00"
			Me.txtCommissionPer.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(10, 149)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(96, 15)
			Me.Label11.TabIndex = 296
			Me.Label11.Text = "Commission % :"
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(479, 3)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(186, 168)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 291
			Me.Picture.TabStop = False
			Me.BStartCapture.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BStartCapture.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BStartCapture.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BStartCapture.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BStartCapture.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BStartCapture.ForeColor = Global.System.Drawing.Color.White
			Me.BStartCapture.Location = New Global.System.Drawing.Point(479, 212)
			Me.BStartCapture.Name = "BStartCapture"
			Me.BStartCapture.Size = New Global.System.Drawing.Size(186, 24)
			Me.BStartCapture.TabIndex = 15
			Me.BStartCapture.TabStop = False
			Me.BStartCapture.Text = "Use Webcam"
			Me.BStartCapture.UseVisualStyleBackColor = False
			Me.Browse.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Browse.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Browse.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Browse.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Browse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Browse.ForeColor = Global.System.Drawing.Color.White
			Me.Browse.Location = New Global.System.Drawing.Point(479, 173)
			Me.Browse.Name = "Browse"
			Me.Browse.Size = New Global.System.Drawing.Size(80, 24)
			Me.Browse.TabIndex = 12
			Me.Browse.TabStop = False
			Me.Browse.Text = "Browse..."
			Me.Browse.UseVisualStyleBackColor = False
			Me.BRemove.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.BRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.BRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.BRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.BRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BRemove.ForeColor = Global.System.Drawing.Color.White
			Me.BRemove.Location = New Global.System.Drawing.Point(585, 173)
			Me.BRemove.Name = "BRemove"
			Me.BRemove.Size = New Global.System.Drawing.Size(80, 24)
			Me.BRemove.TabIndex = 13
			Me.BRemove.TabStop = False
			Me.BRemove.Text = "Remove"
			Me.BRemove.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(10, 37)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(86, 15)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Broker Name :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 11)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(64, 15)
			Me.Label3.TabIndex = 0
			Me.Label3.Text = "Broker ID :"
			Me.txtSalesmanID.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtSalesmanID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSalesmanID.Location = New Global.System.Drawing.Point(125, 11)
			Me.txtSalesmanID.Name = "txtSalesmanID"
			Me.txtSalesmanID.[ReadOnly] = True
			Me.txtSalesmanID.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtSalesmanID.TabIndex = 0
			Me.txtSalesmanID.TabStop = False
			Me.txtAddress.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAddress.Location = New Global.System.Drawing.Point(125, 65)
			Me.txtAddress.Multiline = True
			Me.txtAddress.Name = "txtAddress"
			Me.txtAddress.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtAddress.Size = New Global.System.Drawing.Size(329, 47)
			Me.txtAddress.TabIndex = 1
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(10, 65)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label5.TabIndex = 11
			Me.Label5.Text = "Address :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(10, 119)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(73, 15)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Contact No :"
			Me.txtContactNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtContactNo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtContactNo.Location = New Global.System.Drawing.Point(125, 119)
			Me.txtContactNo.Name = "txtContactNo"
			Me.txtContactNo.Size = New Global.System.Drawing.Size(166, 21)
			Me.txtContactNo.TabIndex = 2
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.RoyalBlue
			MyBase.ClientSize = New Global.System.Drawing.Size(832, 447)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmBroker"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel5.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04004CA7 RID: 19623
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
