Namespace BillPoint
	' Token: 0x02000605 RID: 1541
		Public Partial Class frmTokenSettlement
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012D2A RID: 77098 RVA: 0x00AC98E4 File Offset: 0x00AC7AE4
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

		' Token: 0x06012D2B RID: 77099 RVA: 0x00AC9934 File Offset: 0x00AC7B34
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTokenSettlement))
			Me.ColumnHeader31 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader3 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader7 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader19 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader12 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader13 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader15 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader16 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader17 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader18 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader14 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader20 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader21 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbBranchTo = New Global.System.Windows.Forms.ComboBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.cmbBranchFrom = New Global.System.Windows.Forms.ComboBox()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader22 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader23 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader24 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader25 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader26 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader27 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader28 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader29 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader30 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader32 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader33 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader34 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader35 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader36 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader37 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader38 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader40 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader41 = New Global.System.Windows.Forms.ColumnHeader()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtRemark = New Global.System.Windows.Forms.TextBox()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ColumnHeader76 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ListView2 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader39 = New Global.System.Windows.Forms.ColumnHeader()
			Me.txtBranchCode = New Global.System.Windows.Forms.TextBox()
			Me.txtDB = New Global.System.Windows.Forms.TextBox()
			Me.cmbBranchAdmin = New Global.System.Windows.Forms.ComboBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnDToken = New Global.GelButtons.GelButton()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Picture = New Global.System.Windows.Forms.PictureBox()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.txtID1 = New Global.System.Windows.Forms.TextBox()
			Me.txtProductCode = New Global.System.Windows.Forms.TextBox()
			Me.pbgiftqr = New Global.System.Windows.Forms.PictureBox()
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.ColumnHeader31.Text = "Barcode"
			Me.ColumnHeader31.Width = 100
			Me.ColumnHeader3.Text = "Product Name"
			Me.ColumnHeader3.Width = 200
			Me.ColumnHeader4.Text = "HSNC"
			Me.ColumnHeader4.Width = 80
			Me.ColumnHeader5.Text = "Part/Group"
			Me.ColumnHeader5.Width = 80
			Me.ColumnHeader6.Text = "Description"
			Me.ColumnHeader6.Width = 100
			Me.ColumnHeader7.Text = "Purchase Price"
			Me.ColumnHeader7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader7.Width = 100
			Me.ColumnHeader19.Text = "MRP"
			Me.ColumnHeader19.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader19.Width = 100
			Me.ColumnHeader8.Text = "R.Sale Price"
			Me.ColumnHeader8.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader8.Width = 100
			Me.ColumnHeader9.Text = "W.Sale Price"
			Me.ColumnHeader9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader10.Text = "Disc%"
			Me.ColumnHeader10.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader10.Width = 100
			Me.ColumnHeader11.Text = "CGST%"
			Me.ColumnHeader11.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader11.Width = 100
			Me.ColumnHeader12.Text = "SGST%"
			Me.ColumnHeader12.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader12.Width = 100
			Me.ColumnHeader13.Text = "CESS%"
			Me.ColumnHeader13.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader13.Width = 100
			Me.ColumnHeader15.Text = "Purchase Unit"
			Me.ColumnHeader15.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader15.Width = 100
			Me.ColumnHeader16.Text = "Sale Unit"
			Me.ColumnHeader16.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader16.Width = 100
			Me.ColumnHeader17.Text = "Alter Unit"
			Me.ColumnHeader17.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader17.Width = 100
			Me.ColumnHeader18.Text = "Con Value"
			Me.ColumnHeader18.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader18.Width = 80
			Me.ColumnHeader14.Text = "Minimum Stock"
			Me.ColumnHeader14.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader14.Width = 100
			Me.ColumnHeader20.Text = "Godown"
			Me.ColumnHeader20.Width = 120
			Me.ColumnHeader21.Text = "Rack"
			Me.ColumnHeader21.Width = 100
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(4, 6)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label2.TabIndex = 573
			Me.Label2.Text = "Token Search :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(7, 22)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(164, 21)
			Me.TextBox1.TabIndex = 572
			Me.TextBox1.TabStop = False
			Me.cmbBranchTo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchTo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchTo.FormattingEnabled = True
			Me.cmbBranchTo.Location = New Global.System.Drawing.Point(804, 22)
			Me.cmbBranchTo.Name = "cmbBranchTo"
			Me.cmbBranchTo.Size = New Global.System.Drawing.Size(162, 21)
			Me.cmbBranchTo.TabIndex = 571
			Me.cmbBranchTo.Visible = False
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(801, 6)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label1.TabIndex = 570
			Me.Label1.Text = "To :"
			Me.Label1.Visible = False
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(629, 6)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(84, 15)
			Me.Label21.TabIndex = 569
			Me.Label21.Text = "Branch From :"
			Me.Label21.Visible = False
			Me.ColumnHeader2.Text = "Product Code"
			Me.ColumnHeader2.Width = 100
			Me.ColumnHeader1.Text = "ID"
			Me.cmbBranchFrom.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchFrom.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchFrom.FormattingEnabled = True
			Me.cmbBranchFrom.Location = New Global.System.Drawing.Point(632, 22)
			Me.cmbBranchFrom.Name = "cmbBranchFrom"
			Me.cmbBranchFrom.Size = New Global.System.Drawing.Size(162, 21)
			Me.cmbBranchFrom.TabIndex = 584
			Me.cmbBranchFrom.Visible = False
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader31, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader19, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader14, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader40, Me.ColumnHeader41 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(362, 60)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(902, 559)
			Me.listView1.TabIndex = 574
			Me.listView1.TabStop = False
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader22.Text = "Def Sale Qty"
			Me.ColumnHeader22.Width = 80
			Me.ColumnHeader23.Text = "OS_Purchase Price"
			Me.ColumnHeader23.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader23.Width = 100
			Me.ColumnHeader24.Text = "OS_MRP"
			Me.ColumnHeader24.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader24.Width = 130
			Me.ColumnHeader25.Text = "OS_R.Sale Price"
			Me.ColumnHeader25.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader25.Width = 130
			Me.ColumnHeader26.Text = "OS_W.Sale Price"
			Me.ColumnHeader26.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.ColumnHeader26.Width = 130
			Me.ColumnHeader27.Text = "Batch"
			Me.ColumnHeader27.Width = 100
			Me.ColumnHeader28.Text = "Mfg Date"
			Me.ColumnHeader28.Width = 100
			Me.ColumnHeader29.Text = "Exp Date"
			Me.ColumnHeader29.Width = 100
			Me.ColumnHeader30.Text = "Colour"
			Me.ColumnHeader30.Width = 100
			Me.ColumnHeader32.Text = "Size"
			Me.ColumnHeader32.Width = 100
			Me.ColumnHeader33.Text = "IMEI-1"
			Me.ColumnHeader34.Text = "IMEI-2"
			Me.ColumnHeader35.Text = "Active"
			Me.ColumnHeader35.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.ColumnHeader36.Text = "Qr Code"
			Me.ColumnHeader37.Text = "Transfer Quantity"
			Me.ColumnHeader38.Text = "TokenNo"
			Me.ColumnHeader38.Width = 100
			Me.ColumnHeader40.Text = "Category"
			Me.ColumnHeader41.Text = "SubCategoryName"
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(971, 6)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label4.TabIndex = 578
			Me.Label4.Text = "Remark  :"
			Me.Label4.Visible = False
			Me.txtRemark.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemark.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemark.Location = New Global.System.Drawing.Point(974, 22)
			Me.txtRemark.Name = "txtRemark"
			Me.txtRemark.Size = New Global.System.Drawing.Size(345, 21)
			Me.txtRemark.TabIndex = 577
			Me.txtRemark.TabStop = False
			Me.txtRemark.Visible = False
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(497, 22)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(129, 20)
			Me.DateTimePicker1.TabIndex = 576
			Me.DateTimePicker1.Visible = False
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(494, 6)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(39, 15)
			Me.Label3.TabIndex = 575
			Me.Label3.Text = "Date :"
			Me.Label3.Visible = False
			Me.ColumnHeader76.Text = "TokenNo"
			Me.ColumnHeader76.Width = 230
			Me.ListView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.ListView2.BackColor = Global.System.Drawing.Color.Firebrick
			Me.ListView2.CheckBoxes = True
			Me.ListView2.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader76, Me.ColumnHeader39 })
			Me.ListView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView2.FullRowSelect = True
			Me.ListView2.GridLines = True
			Me.ListView2.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.ListView2.HideSelection = False
			Me.ListView2.Location = New Global.System.Drawing.Point(7, 60)
			Me.ListView2.MultiSelect = False
			Me.ListView2.Name = "ListView2"
			Me.ListView2.Size = New Global.System.Drawing.Size(329, 559)
			Me.ListView2.TabIndex = 581
			Me.ListView2.TabStop = False
			Me.ListView2.UseCompatibleStateImageBehavior = False
			Me.ListView2.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader39.Text = "Product Item"
			Me.ColumnHeader39.Width = 100
			Me.txtBranchCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBranchCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchCode.Location = New Global.System.Drawing.Point(362, 21)
			Me.txtBranchCode.Name = "txtBranchCode"
			Me.txtBranchCode.Size = New Global.System.Drawing.Size(130, 21)
			Me.txtBranchCode.TabIndex = 583
			Me.txtBranchCode.TabStop = False
			Me.txtBranchCode.Visible = False
			Me.txtDB.Location = New Global.System.Drawing.Point(453, 23)
			Me.txtDB.Multiline = True
			Me.txtDB.Name = "txtDB"
			Me.txtDB.[ReadOnly] = True
			Me.txtDB.Size = New Global.System.Drawing.Size(38, 20)
			Me.txtDB.TabIndex = 582
			Me.txtDB.TabStop = False
			Me.txtDB.WordWrap = False
			Me.cmbBranchAdmin.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchAdmin.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchAdmin.FormattingEnabled = True
			Me.cmbBranchAdmin.Location = New Global.System.Drawing.Point(1037, 0)
			Me.cmbBranchAdmin.Name = "cmbBranchAdmin"
			Me.cmbBranchAdmin.Size = New Global.System.Drawing.Size(197, 21)
			Me.cmbBranchAdmin.TabIndex = 585
			Me.cmbBranchAdmin.Visible = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Blue
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.Blue
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(-74, 6)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(159, 38)
			Me.GelButton1.TabIndex = 580
			Me.GelButton1.Text = "&Show Token"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.btnDToken.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDToken.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDToken.FlatAppearance.BorderSize = 0
			Me.btnDToken.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDToken.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDToken.ForeColor = Global.System.Drawing.Color.White
			Me.btnDToken.GradientBottom = Global.System.Drawing.Color.Green
			Me.btnDToken.GradientTop = Global.System.Drawing.Color.Green
			Me.btnDToken.Image = CType(componentResourceManager.GetObject("btnDToken.Image"), Global.System.Drawing.Image)
			Me.btnDToken.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDToken.Location = New Global.System.Drawing.Point(1077, 11)
			Me.btnDToken.Name = "btnDToken"
			Me.btnDToken.Size = New Global.System.Drawing.Size(187, 38)
			Me.btnDToken.TabIndex = 579
			Me.btnDToken.Text = "&Settlement Stock"
			Me.btnDToken.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDToken.UseVisualStyleBackColor = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUserType.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUserType.Location = New Global.System.Drawing.Point(420, 5)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(72, 15)
			Me.lblUserType.TabIndex = 587
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUser.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUser.Location = New Global.System.Drawing.Point(358, 5)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(46, 15)
			Me.lblUser.TabIndex = 586
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.Picture.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Picture.Image = Global.BillPoint.My.Resources.Resources.photo
			Me.Picture.Location = New Global.System.Drawing.Point(197, 463)
			Me.Picture.Name = "Picture"
			Me.Picture.Size = New Global.System.Drawing.Size(122, 89)
			Me.Picture.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Picture.TabIndex = 588
			Me.Picture.TabStop = False
			Me.Picture.Visible = False
			Me.txtID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtID.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID.Location = New Global.System.Drawing.Point(342, 33)
			Me.txtID.Name = "txtID"
			Me.txtID.Size = New Global.System.Drawing.Size(44, 21)
			Me.txtID.TabIndex = 589
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.txtID1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtID1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtID1.Location = New Global.System.Drawing.Point(342, 60)
			Me.txtID1.Name = "txtID1"
			Me.txtID1.Size = New Global.System.Drawing.Size(44, 21)
			Me.txtID1.TabIndex = 590
			Me.txtID1.TabStop = False
			Me.txtID1.Visible = False
			Me.txtProductCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtProductCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtProductCode.Location = New Global.System.Drawing.Point(342, 87)
			Me.txtProductCode.Name = "txtProductCode"
			Me.txtProductCode.Size = New Global.System.Drawing.Size(44, 21)
			Me.txtProductCode.TabIndex = 591
			Me.txtProductCode.TabStop = False
			Me.txtProductCode.Visible = False
			Me.pbgiftqr.Location = New Global.System.Drawing.Point(107, 463)
			Me.pbgiftqr.Name = "pbgiftqr"
			Me.pbgiftqr.Size = New Global.System.Drawing.Size(84, 82)
			Me.pbgiftqr.TabIndex = 1798
			Me.pbgiftqr.TabStop = False
			Me.pbgiftqr.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 701)
			MyBase.Controls.Add(Me.pbgiftqr)
			MyBase.Controls.Add(Me.txtProductCode)
			MyBase.Controls.Add(Me.txtID1)
			MyBase.Controls.Add(Me.txtID)
			MyBase.Controls.Add(Me.Picture)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.cmbBranchTo)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Label21)
			MyBase.Controls.Add(Me.btnDToken)
			MyBase.Controls.Add(Me.cmbBranchFrom)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.txtRemark)
			MyBase.Controls.Add(Me.DateTimePicker1)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.ListView2)
			MyBase.Controls.Add(Me.txtBranchCode)
			MyBase.Controls.Add(Me.txtDB)
			MyBase.Controls.Add(Me.cmbBranchAdmin)
			MyBase.Name = "frmTokenSettlement"
			Me.Text = "frmTokenSettlement"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			CType(Me.Picture, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.pbgiftqr, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x04007169 RID: 29033
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
