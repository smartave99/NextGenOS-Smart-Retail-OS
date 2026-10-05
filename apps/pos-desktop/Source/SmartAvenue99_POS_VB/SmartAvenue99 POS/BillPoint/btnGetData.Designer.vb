Namespace BillPoint
	' Token: 0x0200010D RID: 269
		Public Partial Class btnGetData
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06002BD8 RID: 11224 RVA: 0x001B01D0 File Offset: 0x001AE3D0
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

		' Token: 0x06002BD9 RID: 11225 RVA: 0x001B0220 File Offset: 0x001AE420
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.btnGetData))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle10 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle11 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle12 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle13 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle14 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle15 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle16 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle17 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle18 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle20 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblNoOfItems = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.lblSet = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.txtSearch = New Global.System.Windows.Forms.Button()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Button6 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.cmbSearchType = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.chkBoxZeroQty = New Global.System.Windows.Forms.CheckBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column29 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column30 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column31 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column32 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column33 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column34 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column35 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.Panel3.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblNoOfItems)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.lblSet)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1184, 682)
			Me.Panel1.TabIndex = 3
			Me.lblNoOfItems.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.lblNoOfItems.AutoSize = True
			Me.lblNoOfItems.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblNoOfItems.ForeColor = Global.System.Drawing.Color.Maroon
			Me.lblNoOfItems.Location = New Global.System.Drawing.Point(3, 661)
			Me.lblNoOfItems.Name = "lblNoOfItems"
			Me.lblNoOfItems.Size = New Global.System.Drawing.Size(86, 13)
			Me.lblNoOfItems.TabIndex = 1679
			Me.lblNoOfItems.Text = "No(s) of Items :"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.Location = New Global.System.Drawing.Point(852, 657)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(107, 18)
			Me.Label5.TabIndex = 55
			Me.Label5.Text = "Total Quantity :"
			Me.TextBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(963, 654)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(198, 24)
			Me.TextBox2.TabIndex = 53
			Me.TextBox2.TabStop = False
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.lblSet.AutoSize = True
			Me.lblSet.Location = New Global.System.Drawing.Point(812, 19)
			Me.lblSet.Name = "lblSet"
			Me.lblSet.Size = New Global.System.Drawing.Size(23, 13)
			Me.lblSet.TabIndex = 45
			Me.lblSet.Text = "Set"
			Me.lblSet.Visible = False
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.btnReset)
			Me.Panel3.Controls.Add(Me.txtSearch)
			Me.Panel3.Controls.Add(Me.GelButton3)
			Me.Panel3.Controls.Add(Me.GroupBox1)
			Me.Panel3.Controls.Add(Me.cmbSearchType)
			Me.Panel3.Controls.Add(Me.Label4)
			Me.Panel3.Controls.Add(Me.Panel2)
			Me.Panel3.Controls.Add(Me.chkBoxZeroQty)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Controls.Add(Me.Label2)
			Me.Panel3.Controls.Add(Me.TextBox1)
			Me.Panel3.Controls.Add(Me.dtpDateTo)
			Me.Panel3.Controls.Add(Me.Label10)
			Me.Panel3.Controls.Add(Me.Label11)
			Me.Panel3.Controls.Add(Me.dtpDateFrom)
			Me.Panel3.Location = New Global.System.Drawing.Point(6, 44)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(1155, 90)
			Me.Panel3.TabIndex = 0
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.Location = New Global.System.Drawing.Point(956, 2)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(43, 43)
			Me.btnReset.TabIndex = 6
			Me.btnReset.Text = "                                  &Reset"
			Me.btnReset.UseVisualStyleBackColor = False
			Me.txtSearch.BackColor = Global.System.Drawing.Color.Transparent
			Me.txtSearch.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.txtSearch.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtSearch.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtSearch.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtSearch.ForeColor = Global.System.Drawing.Color.White
			Me.txtSearch.Image = CType(componentResourceManager.GetObject("txtSearch.Image"), Global.System.Drawing.Image)
			Me.txtSearch.Location = New Global.System.Drawing.Point(1005, 2)
			Me.txtSearch.Name = "txtSearch"
			Me.txtSearch.Size = New Global.System.Drawing.Size(43, 43)
			Me.txtSearch.TabIndex = 5
			Me.txtSearch.Text = "                                    &Export Excel"
			Me.txtSearch.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(542, 13)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(133, 59)
			Me.GelButton3.TabIndex = 1680
			Me.GelButton3.Text = "Get Data"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.GroupBox1.Controls.Add(Me.Button6)
			Me.GroupBox1.Controls.Add(Me.Button5)
			Me.GroupBox1.Controls.Add(Me.Button4)
			Me.GroupBox1.Controls.Add(Me.Button3)
			Me.GroupBox1.Controls.Add(Me.Button2)
			Me.GroupBox1.Controls.Add(Me.Button1)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(684, 0)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(251, 85)
			Me.GroupBox1.TabIndex = 1690
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Expiring in Next :"
			Me.Button6.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button6.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button6.Location = New Global.System.Drawing.Point(168, 49)
			Me.Button6.Name = "Button6"
			Me.Button6.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button6.TabIndex = 1694
			Me.Button6.TabStop = False
			Me.Button6.Text = "365 Days"
			Me.Button6.UseVisualStyleBackColor = False
			Me.Button5.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.Location = New Global.System.Drawing.Point(168, 20)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button5.TabIndex = 1693
			Me.Button5.TabStop = False
			Me.Button5.Text = "180 Days"
			Me.Button5.UseVisualStyleBackColor = False
			Me.Button4.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.Location = New Global.System.Drawing.Point(87, 49)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button4.TabIndex = 1692
			Me.Button4.TabStop = False
			Me.Button4.Text = "90 Days"
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.Location = New Global.System.Drawing.Point(87, 20)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button3.TabIndex = 1691
			Me.Button3.TabStop = False
			Me.Button3.Text = "30 Days"
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Location = New Global.System.Drawing.Point(6, 49)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button2.TabIndex = 1690
			Me.Button2.TabStop = False
			Me.Button2.Text = "15 Days"
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.BackColor = Global.System.Drawing.Color.Bisque
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.Location = New Global.System.Drawing.Point(6, 20)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 1689
			Me.Button1.TabStop = False
			Me.Button1.Text = "7 Days"
			Me.Button1.UseVisualStyleBackColor = False
			Me.cmbSearchType.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbSearchType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbSearchType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbSearchType.FormattingEnabled = True
			Me.cmbSearchType.Items.AddRange(New Object() { "Product Name", "Barcode", "Category", "Sub Category", "Part/Group", "Godown", "Rack", "Batch", "Size", "Colour", "IMEI-1", "IMEI-2" })
			Me.cmbSearchType.Location = New Global.System.Drawing.Point(129, 53)
			Me.cmbSearchType.Name = "cmbSearchType"
			Me.cmbSearchType.Size = New Global.System.Drawing.Size(157, 32)
			Me.cmbSearchType.TabIndex = 3
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label4.Location = New Global.System.Drawing.Point(990, 69)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(160, 13)
			Me.Label4.TabIndex = 1681
			Me.Label4.Text = "Already Expired Detected Colour"
			Me.Panel2.BackColor = Global.System.Drawing.Color.HotPink
			Me.Panel2.Location = New Global.System.Drawing.Point(941, 63)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(49, 20)
			Me.Panel2.TabIndex = 1680
			Me.chkBoxZeroQty.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.chkBoxZeroQty.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkBoxZeroQty.Location = New Global.System.Drawing.Point(1077, 3)
			Me.chkBoxZeroQty.Name = "chkBoxZeroQty"
			Me.chkBoxZeroQty.Size = New Global.System.Drawing.Size(74, 42)
			Me.chkBoxZeroQty.TabIndex = 56
			Me.chkBoxZeroQty.TabStop = False
			Me.chkBoxZeroQty.Text = "With -Ve Stock Qty Show"
			Me.chkBoxZeroQty.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.chkBoxZeroQty.UseVisualStyleBackColor = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(290, 54)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(80, 24)
			Me.Label3.TabIndex = 1688
			Me.Label3.Text = "Search :"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(3, 54)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(128, 24)
			Me.Label2.TabIndex = 1687
			Me.Label2.Text = "Search Type :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.White
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(376, 54)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(157, 29)
			Me.TextBox1.TabIndex = 4
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(376, 11)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(157, 29)
			Me.dtpDateTo.TabIndex = 1
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(290, 11)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(43, 24)
			Me.Label10.TabIndex = 1684
			Me.Label10.Text = "To :"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(3, 11)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(65, 24)
			Me.Label11.TabIndex = 1683
			Me.Label11.Text = "From :"
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(129, 8)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(157, 29)
			Me.dtpDateFrom.TabIndex = 0
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column9, Me.Column1, Me.Column2, Me.Column11, Me.Column12, Me.Column8, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column13, Me.Column15, Me.Column7, Me.Column10, Me.Column14, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31, Me.Column32, Me.Column33, Me.Column34, Me.Column35 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(6, 140)
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
			Me.dgw.RowHeadersVisible = False
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 25
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1170, 512)
			Me.dgw.TabIndex = 43
			Me.dgw.TabStop = False
			Me.Column9.HeaderText = "PID"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column9.Visible = False
			Me.Column1.HeaderText = "Product Code"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Width = 88
			Me.Column2.HeaderText = "Product Name"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 250
			Me.Column11.HeaderText = "HSN Code"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Width = 76
			Me.Column12.HeaderText = "Part / Group"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			Me.Column12.Width = 83
			Me.Column8.HeaderText = "Barcode"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 71
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "N2"
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.HeaderText = "Purchase Price"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 95
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column4.HeaderText = "Retail Price"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.Width = 78
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column5.HeaderText = "Discount"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Width = 73
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column6.HeaderText = "CGST"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.Width = 60
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column13.HeaderText = "SGST"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column13.Width = 60
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column15.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column15.HeaderText = "CESS"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column15.Width = 59
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column7.HeaderText = "Qty. Available"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.Width = 88
			Me.Column10.HeaderText = "Main Unit"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Width = 70
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle13.Format = "N2"
			Me.Column14.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column14.HeaderText = "Wholesale Price"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column14.Width = 99
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle14.Format = "N2"
			dataGridViewCellStyle14.NullValue = Nothing
			Me.Column16.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column16.HeaderText = "MRP"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column16.Width = 99
			Me.Column17.HeaderText = "Category"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column17.Width = 73
			Me.Column18.HeaderText = "Sub Category / Brand"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column18.Width = 97
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle15.Format = "N2"
			Me.Column19.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column19.HeaderText = "Last Sold Price"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			Me.Column19.Width = 94
			dataGridViewCellStyle16.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle16
			Me.Column20.HeaderText = "Good Product Qty"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			Me.Column20.Width = 92
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column21.DefaultCellStyle = dataGridViewCellStyle17
			Me.Column21.HeaderText = "Damage Product Qty"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			Me.Column21.Width = 104
			Me.Column22.HeaderText = "Description"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			Me.Column22.Visible = False
			Me.Column22.Width = 84
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column23.DefaultCellStyle = dataGridViewCellStyle18
			Me.Column23.HeaderText = "Minimum Stock"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			Me.Column23.Width = 95
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle19
			Me.Column24.HeaderText = "Sale Tax Type"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			dataGridViewCellStyle20.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column25.DefaultCellStyle = dataGridViewCellStyle20
			Me.Column25.HeaderText = "Purchase Tax Type"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column26.HeaderText = "Godown"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column27.HeaderText = "Rack"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			Me.Column28.HeaderText = "Batch"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			Me.Column29.HeaderText = "Mfg Date"
			Me.Column29.Name = "Column29"
			Me.Column29.[ReadOnly] = True
			Me.Column30.HeaderText = "Exp Date"
			Me.Column30.Name = "Column30"
			Me.Column30.[ReadOnly] = True
			Me.Column31.HeaderText = "Size"
			Me.Column31.Name = "Column31"
			Me.Column31.[ReadOnly] = True
			Me.Column32.HeaderText = "Colour"
			Me.Column32.Name = "Column32"
			Me.Column32.[ReadOnly] = True
			Me.Column33.HeaderText = "Def Qty"
			Me.Column33.Name = "Column33"
			Me.Column33.[ReadOnly] = True
			Me.Column33.Visible = False
			Me.Column34.HeaderText = "IMEI-1"
			Me.Column34.Name = "Column34"
			Me.Column34.[ReadOnly] = True
			Me.Column35.HeaderText = "IMEI-2"
			Me.Column35.Name = "Column35"
			Me.Column35.[ReadOnly] = True
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, -1)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1184, 37)
			Me.Label1.TabIndex = 48
			Me.Label1.Text = "Expiry Product (Item Aging) Record"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1184, 682)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "btnGetData"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040012BD RID: 4797
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
