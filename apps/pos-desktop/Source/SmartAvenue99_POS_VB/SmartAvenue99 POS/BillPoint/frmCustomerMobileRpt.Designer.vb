Namespace BillPoint
	' Token: 0x020000DE RID: 222
		Public Partial Class frmCustomerMobileRpt
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002746 RID: 10054 RVA: 0x0018C438 File Offset: 0x0018A638
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

		' Token: 0x06002747 RID: 10055 RVA: 0x0018C488 File Offset: 0x0018A688
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmCustomerMobileRpt))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.PictureBox3 = New Global.System.Windows.Forms.PictureBox()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.LinkLabel2 = New Global.System.Windows.Forms.LinkLabel()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtAndroidID = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.btnNew = New Global.System.Windows.Forms.Button()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtCID = New Global.System.Windows.Forms.TextBox()
			Me.txtCustID = New Global.System.Windows.Forms.TextBox()
			Me.txtCustContact = New Global.System.Windows.Forms.TextBox()
			Me.txtCustAddress = New Global.System.Windows.Forms.TextBox()
			Me.cmbCustomerName = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.LinkLabel3 = New Global.System.Windows.Forms.LinkLabel()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.LinkLabel4 = New Global.System.Windows.Forms.LinkLabel()
			Me.LinkLabel5 = New Global.System.Windows.Forms.LinkLabel()
			Me.Panel1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox2.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.LinkLabel4)
			Me.Panel1.Controls.Add(Me.LinkLabel5)
			Me.Panel1.Controls.Add(Me.Label18)
			Me.Panel1.Controls.Add(Me.LinkLabel3)
			Me.Panel1.Controls.Add(Me.Label17)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Location = New Global.System.Drawing.Point(8, 7)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(937, 492)
			Me.Panel1.TabIndex = 1
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column19, Me.Column8, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column1, Me.Column9, Me.Column2, Me.Column17 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(4, 257)
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
			Me.dgw.Size = New Global.System.Drawing.Size(774, 230)
			Me.dgw.TabIndex = 420
			Me.dgw.TabStop = False
			Me.Column19.HeaderText = "Auto ID"
			Me.Column19.Name = "Column19"
			Me.Column19.Visible = False
			Me.Column8.HeaderText = "Android ID"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 250
			Me.Column3.HeaderText = "Customer Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 300
			Me.Column4.HeaderText = "CID"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Visible = False
			Me.Column4.Width = 62
			Me.Column5.HeaderText = "Customer ID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Address"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 250
			Me.Column7.HeaderText = "Contact"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "N2"
			Me.Column10.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column10.HeaderText = "Coupon Disc Amt"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.HeaderText = "Valid From"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column12.HeaderText = "Valid Upto"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column13.HeaderText = "Offer Status"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column14.HeaderText = "Coupon Code"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column15.HeaderText = "Coupon Status"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column16.HeaderText = "Coupon Issue Date"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column1.HeaderText = "Loyalty Card No"
			Me.Column1.Name = "Column1"
			Me.Column9.HeaderText = "Loyalty Point"
			Me.Column9.Name = "Column9"
			Me.Column2.HeaderText = "Message"
			Me.Column2.Name = "Column2"
			Me.Column2.Width = 400
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.NullValue = Global.System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(componentResourceManager.GetObject("DataGridViewCellStyle29.NullValue"))
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.Color.White
			Me.Column17.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column17.FillWeight = 80F
			Me.Column17.HeaderText = "Delete"
			Me.Column17.Image = CType(componentResourceManager.GetObject("Column17.Image"), Global.System.Drawing.Image)
			Me.Column17.ImageLayout = Global.System.Windows.Forms.DataGridViewImageCellLayout.Zoom
			Me.Column17.Name = "Column17"
			Me.Column17.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.Column17.ToolTipText = "Delete"
			Me.Column17.Width = 70
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(799, 14)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 7
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.GroupBox1.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox1.Controls.Add(Me.PictureBox3)
			Me.GroupBox1.Controls.Add(Me.btnSave)
			Me.GroupBox1.Controls.Add(Me.TextBox11)
			Me.GroupBox1.Controls.Add(Me.LinkLabel2)
			Me.GroupBox1.Controls.Add(Me.LinkLabel1)
			Me.GroupBox1.Controls.Add(Me.GroupBox2)
			Me.GroupBox1.Controls.Add(Me.TextBox12)
			Me.GroupBox1.Controls.Add(Me.Label23)
			Me.GroupBox1.Controls.Add(Me.Label22)
			Me.GroupBox1.Controls.Add(Me.Label21)
			Me.GroupBox1.Controls.Add(Me.TextBox10)
			Me.GroupBox1.Controls.Add(Me.TextBox9)
			Me.GroupBox1.Controls.Add(Me.Label15)
			Me.GroupBox1.Controls.Add(Me.TextBox8)
			Me.GroupBox1.Controls.Add(Me.Label14)
			Me.GroupBox1.Controls.Add(Me.TextBox7)
			Me.GroupBox1.Controls.Add(Me.Label13)
			Me.GroupBox1.Controls.Add(Me.TextBox6)
			Me.GroupBox1.Controls.Add(Me.Label12)
			Me.GroupBox1.Controls.Add(Me.TextBox5)
			Me.GroupBox1.Controls.Add(Me.TextBox4)
			Me.GroupBox1.Controls.Add(Me.TextBox2)
			Me.GroupBox1.Controls.Add(Me.Label10)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.TextBox1)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.txtAndroidID)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.btnNew)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtCID)
			Me.GroupBox1.Controls.Add(Me.txtCustID)
			Me.GroupBox1.Controls.Add(Me.txtCustContact)
			Me.GroupBox1.Controls.Add(Me.txtCustAddress)
			Me.GroupBox1.Controls.Add(Me.cmbCustomerName)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(4, 38)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(929, 222)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Customer Info :"
			Me.PictureBox3.Location = New Global.System.Drawing.Point(780, 59)
			Me.PictureBox3.Name = "PictureBox3"
			Me.PictureBox3.Size = New Global.System.Drawing.Size(143, 137)
			Me.PictureBox3.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox3.TabIndex = 449
			Me.PictureBox3.TabStop = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnSave.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnSave.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(647, 160)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(127, 58)
			Me.btnSave.TabIndex = 2
			Me.btnSave.Text = "&Save + Live Broadcast"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.TextImageRelation = Global.System.Windows.Forms.TextImageRelation.ImageBeforeText
			Me.btnSave.UseVisualStyleBackColor = False
			Me.TextBox11.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox11.Location = New Global.System.Drawing.Point(519, 84)
			Me.TextBox11.Multiline = True
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.TextBox11.Size = New Global.System.Drawing.Size(255, 73)
			Me.TextBox11.TabIndex = 1
			Me.LinkLabel2.ActiveLinkColor = Global.System.Drawing.Color.Blue
			Me.LinkLabel2.AutoSize = True
			Me.LinkLabel2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel2.LinkColor = Global.System.Drawing.Color.Red
			Me.LinkLabel2.Location = New Global.System.Drawing.Point(887, 201)
			Me.LinkLabel2.Name = "LinkLabel2"
			Me.LinkLabel2.Size = New Global.System.Drawing.Size(36, 15)
			Me.LinkLabel2.TabIndex = 1694
			Me.LinkLabel2.TabStop = True
			Me.LinkLabel2.Text = "(OFF)"
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(780, 201)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(99, 15)
			Me.LinkLabel1.TabIndex = 1693
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "2nd Display (ON)"
			Me.GroupBox2.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.GroupBox2.Controls.Add(Me.Button4)
			Me.GroupBox2.Controls.Add(Me.Label16)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.TextBox3)
			Me.GroupBox2.Controls.Add(Me.ComboBox1)
			Me.GroupBox2.ForeColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Location = New Global.System.Drawing.Point(4, 158)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(433, 62)
			Me.GroupBox2.TabIndex = 1692
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search :"
			Me.Button4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(364, 25)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(61, 29)
			Me.Button4.TabIndex = 4
			Me.Button4.Text = "Getdata"
			Me.Button4.UseVisualStyleBackColor = False
			Me.Label16.AutoSize = True
			Me.Label16.Location = New Global.System.Drawing.Point(157, 18)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label16.TabIndex = 3
			Me.Label16.Text = "Search :"
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(6, 18)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(92, 13)
			Me.Label11.TabIndex = 2
			Me.Label11.Text = "Search Category :"
			Me.TextBox3.Location = New Global.System.Drawing.Point(160, 35)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(198, 20)
			Me.TextBox3.TabIndex = 3
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.ItemHeight = 13
			Me.ComboBox1.Items.AddRange(New Object() { "Customer ID", "Customer Name", "Contact", "Android ID" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(7, 34)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(147, 21)
			Me.ComboBox1.TabIndex = 0
			Me.TextBox12.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox12.Location = New Global.System.Drawing.Point(6, 177)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.Size = New Global.System.Drawing.Size(12, 20)
			Me.TextBox12.TabIndex = 470
			Me.Label23.AutoSize = True
			Me.Label23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label23.Location = New Global.System.Drawing.Point(520, 66)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(64, 15)
			Me.Label23.TabIndex = 469
			Me.Label23.Text = "Message :"
			Me.Label22.AutoSize = True
			Me.Label22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label22.Location = New Global.System.Drawing.Point(413, 117)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(81, 15)
			Me.Label22.TabIndex = 467
			Me.Label22.Text = "Loyalty Point :"
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label21.Location = New Global.System.Drawing.Point(207, 117)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(101, 15)
			Me.Label21.TabIndex = 466
			Me.Label21.Text = "Loyalty Card No. :"
			Me.TextBox10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox10.Location = New Global.System.Drawing.Point(416, 135)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox10.TabIndex = 465
			Me.TextBox10.TabStop = False
			Me.TextBox9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox9.Location = New Global.System.Drawing.Point(210, 135)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.[ReadOnly] = True
			Me.TextBox9.Size = New Global.System.Drawing.Size(200, 21)
			Me.TextBox9.TabIndex = 464
			Me.TextBox9.TabStop = False
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label15.Location = New Global.System.Drawing.Point(106, 117)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(71, 15)
			Me.Label15.TabIndex = 463
			Me.Label15.Text = "Issue Date :"
			Me.TextBox8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox8.Location = New Global.System.Drawing.Point(107, 135)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox8.TabIndex = 462
			Me.TextBox8.TabStop = False
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label14.Location = New Global.System.Drawing.Point(1, 117)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(93, 15)
			Me.Label14.TabIndex = 461
			Me.Label14.Text = "Coupon Status :"
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox7.Location = New Global.System.Drawing.Point(4, 135)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.[ReadOnly] = True
			Me.TextBox7.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox7.TabIndex = 460
			Me.TextBox7.TabStop = False
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label13.Location = New Global.System.Drawing.Point(413, 66)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(88, 15)
			Me.Label13.TabIndex = 459
			Me.Label13.Text = "Coupon Code :"
			Me.TextBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox6.Location = New Global.System.Drawing.Point(416, 84)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox6.TabIndex = 458
			Me.TextBox6.TabStop = False
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label12.Location = New Global.System.Drawing.Point(310, 66)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label12.TabIndex = 457
			Me.Label12.Text = "Offer Status :"
			Me.TextBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox5.Location = New Global.System.Drawing.Point(313, 84)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox5.TabIndex = 456
			Me.TextBox5.TabStop = False
			Me.TextBox4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox4.Location = New Global.System.Drawing.Point(210, 84)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox4.TabIndex = 455
			Me.TextBox4.TabStop = False
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox2.Location = New Global.System.Drawing.Point(107, 84)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox2.TabIndex = 454
			Me.TextBox2.TabStop = False
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label10.Location = New Global.System.Drawing.Point(207, 66)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(69, 15)
			Me.Label10.TabIndex = 453
			Me.Label10.Text = "Valid Upto :"
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label9.Location = New Global.System.Drawing.Point(104, 66)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(72, 15)
			Me.Label9.TabIndex = 452
			Me.Label9.Text = "Valid From :"
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label8.Location = New Global.System.Drawing.Point(3, 66)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(101, 15)
			Me.Label8.TabIndex = 451
			Me.Label8.Text = "Coupon Amount :"
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.TextBox1.Location = New Global.System.Drawing.Point(4, 84)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(97, 21)
			Me.TextBox1.TabIndex = 450
			Me.TextBox1.TabStop = False
			Me.TextBox1.Text = "0.00"
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label7.AutoSize = True
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label7.Location = New Global.System.Drawing.Point(587, 15)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(111, 15)
			Me.Label7.TabIndex = 448
			Me.Label7.Text = "Android Mobile ID :"
			Me.txtAndroidID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.txtAndroidID.Location = New Global.System.Drawing.Point(590, 32)
			Me.txtAndroidID.Name = "txtAndroidID"
			Me.txtAndroidID.[ReadOnly] = True
			Me.txtAndroidID.Size = New Global.System.Drawing.Size(333, 21)
			Me.txtAndroidID.TabIndex = 447
			Me.txtAndroidID.TabStop = False
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label6.Location = New Global.System.Drawing.Point(202, 15)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(52, 15)
			Me.Label6.TabIndex = 446
			Me.Label6.Text = "Cust ID :"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label3.Location = New Global.System.Drawing.Point(162, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(33, 15)
			Me.Label3.TabIndex = 445
			Me.Label3.Text = "CID :"
			Me.btnNew.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnNew.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnNew.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNew.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNew.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnNew.ForeColor = Global.System.Drawing.Color.White
			Me.btnNew.Image = Global.BillPoint.My.Resources.Resources.Reset2_32x32
			Me.btnNew.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnNew.Location = New Global.System.Drawing.Point(538, 160)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(90, 58)
			Me.btnNew.TabIndex = 3
			Me.btnNew.Text = "&Reset"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label5.Location = New Global.System.Drawing.Point(428, 15)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label5.TabIndex = 423
			Me.Label5.Text = "Contact No. :"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label4.Location = New Global.System.Drawing.Point(269, 15)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(57, 15)
			Me.Label4.TabIndex = 422
			Me.Label4.Text = "Address :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Label2.Location = New Global.System.Drawing.Point(3, 15)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(47, 15)
			Me.Label2.TabIndex = 420
			Me.Label2.Text = "Name :"
			Me.txtCID.Location = New Global.System.Drawing.Point(165, 34)
			Me.txtCID.Name = "txtCID"
			Me.txtCID.[ReadOnly] = True
			Me.txtCID.Size = New Global.System.Drawing.Size(34, 20)
			Me.txtCID.TabIndex = 7
			Me.txtCID.TabStop = False
			Me.txtCustID.Location = New Global.System.Drawing.Point(205, 33)
			Me.txtCustID.Name = "txtCustID"
			Me.txtCustID.[ReadOnly] = True
			Me.txtCustID.Size = New Global.System.Drawing.Size(61, 20)
			Me.txtCustID.TabIndex = 6
			Me.txtCustID.TabStop = False
			Me.txtCustContact.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.txtCustContact.Location = New Global.System.Drawing.Point(431, 32)
			Me.txtCustContact.Name = "txtCustContact"
			Me.txtCustContact.[ReadOnly] = True
			Me.txtCustContact.Size = New Global.System.Drawing.Size(153, 21)
			Me.txtCustContact.TabIndex = 3
			Me.txtCustContact.TabStop = False
			Me.txtCustAddress.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.txtCustAddress.Location = New Global.System.Drawing.Point(272, 33)
			Me.txtCustAddress.Name = "txtCustAddress"
			Me.txtCustAddress.[ReadOnly] = True
			Me.txtCustAddress.Size = New Global.System.Drawing.Size(153, 21)
			Me.txtCustAddress.TabIndex = 2
			Me.txtCustAddress.TabStop = False
			Me.cmbCustomerName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbCustomerName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbCustomerName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbCustomerName.FormattingEnabled = True
			Me.cmbCustomerName.Location = New Global.System.Drawing.Point(6, 33)
			Me.cmbCustomerName.Name = "cmbCustomerName"
			Me.cmbCustomerName.Size = New Global.System.Drawing.Size(153, 23)
			Me.cmbCustomerName.TabIndex = 0
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(4, 3)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(927, 29)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Customer Mobile Notification Management"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LinkLabel3.AutoSize = True
			Me.LinkLabel3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel3.Location = New Global.System.Drawing.Point(793, 474)
			Me.LinkLabel3.Name = "LinkLabel3"
			Me.LinkLabel3.Size = New Global.System.Drawing.Size(130, 15)
			Me.LinkLabel3.TabIndex = 1695
			Me.LinkLabel3.TabStop = True
			Me.LinkLabel3.Text = "Download Apk Directly"
			Me.PictureBox1.Location = New Global.System.Drawing.Point(784, 292)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(143, 137)
			Me.PictureBox1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox1.TabIndex = 450
			Me.PictureBox1.TabStop = False
			Me.Label17.AutoSize = True
			Me.Label17.BackColor = Global.System.Drawing.Color.Yellow
			Me.Label17.Font = New Global.System.Drawing.Font("Arial Narrow", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.Black
			Me.Label17.Location = New Global.System.Drawing.Point(788, 272)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(133, 16)
			Me.Label17.TabIndex = 451
			Me.Label17.Text = "Scan Me to Download Apk"
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label18.Location = New Global.System.Drawing.Point(845, 458)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(18, 13)
			Me.Label18.TabIndex = 1696
			Me.Label18.Text = "Or"
			Me.LinkLabel4.ActiveLinkColor = Global.System.Drawing.Color.Blue
			Me.LinkLabel4.AutoSize = True
			Me.LinkLabel4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel4.LinkColor = Global.System.Drawing.Color.Red
			Me.LinkLabel4.Location = New Global.System.Drawing.Point(891, 432)
			Me.LinkLabel4.Name = "LinkLabel4"
			Me.LinkLabel4.Size = New Global.System.Drawing.Size(36, 15)
			Me.LinkLabel4.TabIndex = 1698
			Me.LinkLabel4.TabStop = True
			Me.LinkLabel4.Text = "(OFF)"
			Me.LinkLabel5.AutoSize = True
			Me.LinkLabel5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LinkLabel5.Location = New Global.System.Drawing.Point(784, 432)
			Me.LinkLabel5.Name = "LinkLabel5"
			Me.LinkLabel5.Size = New Global.System.Drawing.Size(99, 15)
			Me.LinkLabel5.TabIndex = 1697
			Me.LinkLabel5.TabStop = True
			Me.LinkLabel5.Text = "2nd Display (ON)"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(953, 507)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmCustomerMobileRpt"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400105C RID: 4188
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
