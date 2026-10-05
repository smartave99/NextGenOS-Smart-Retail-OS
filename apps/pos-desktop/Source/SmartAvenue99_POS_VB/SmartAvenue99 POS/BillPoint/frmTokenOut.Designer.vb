Namespace BillPoint
	' Token: 0x02000604 RID: 1540
		Public Partial Class frmTokenOut
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012C9E RID: 76958 RVA: 0x00AC5EFC File Offset: 0x00AC40FC
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

		' Token: 0x06012C9F RID: 76959 RVA: 0x00AC5F4C File Offset: 0x00AC414C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTokenOut))
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.cmbBranchTo = New Global.System.Windows.Forms.ComboBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.listView1 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader1 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader2 = New Global.System.Windows.Forms.ColumnHeader()
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
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.DateTimePicker1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtRemark = New Global.System.Windows.Forms.TextBox()
			Me.ColumnHeader76 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ListView2 = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader39 = New Global.System.Windows.Forms.ColumnHeader()
			Me.txtDB = New Global.System.Windows.Forms.TextBox()
			Me.txtBranchCode = New Global.System.Windows.Forms.TextBox()
			Me.cmbBranchFrom = New Global.System.Windows.Forms.ComboBox()
			Me.cmbBranchAdmin = New Global.System.Windows.Forms.ComboBox()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.btnDToken = New Global.GelButtons.GelButton()
			MyBase.SuspendLayout()
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(637, 9)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(84, 15)
			Me.Label21.TabIndex = 35
			Me.Label21.Text = "Branch From :"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label1.Location = New Global.System.Drawing.Point(809, 9)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label1.TabIndex = 37
			Me.Label1.Text = "To :"
			Me.cmbBranchTo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchTo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchTo.FormattingEnabled = True
			Me.cmbBranchTo.Location = New Global.System.Drawing.Point(812, 25)
			Me.cmbBranchTo.Name = "cmbBranchTo"
			Me.cmbBranchTo.Size = New Global.System.Drawing.Size(162, 21)
			Me.cmbBranchTo.TabIndex = 38
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label2.Location = New Global.System.Drawing.Point(12, 9)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label2.TabIndex = 40
			Me.Label2.Text = "Token Search :"
			Me.TextBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(15, 25)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(164, 21)
			Me.TextBox1.TabIndex = 39
			Me.TextBox1.TabStop = False
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
			Me.listView1.Location = New Global.System.Drawing.Point(370, 63)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(902, 559)
			Me.listView1.TabIndex = 70
			Me.listView1.TabStop = False
			Me.listView1.UseCompatibleStateImageBehavior = False
			Me.listView1.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader1.Text = "ID"
			Me.ColumnHeader2.Text = "Product Code"
			Me.ColumnHeader2.Width = 100
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
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label3.Location = New Global.System.Drawing.Point(502, 9)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(39, 15)
			Me.Label3.TabIndex = 71
			Me.Label3.Text = "Date :"
			Me.Label3.Visible = False
			Me.DateTimePicker1.Location = New Global.System.Drawing.Point(505, 25)
			Me.DateTimePicker1.Name = "DateTimePicker1"
			Me.DateTimePicker1.Size = New Global.System.Drawing.Size(129, 20)
			Me.DateTimePicker1.TabIndex = 72
			Me.DateTimePicker1.Visible = False
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(979, 9)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(60, 15)
			Me.Label4.TabIndex = 74
			Me.Label4.Text = "Remark  :"
			Me.txtRemark.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtRemark.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtRemark.Location = New Global.System.Drawing.Point(982, 25)
			Me.txtRemark.Name = "txtRemark"
			Me.txtRemark.Size = New Global.System.Drawing.Size(242, 21)
			Me.txtRemark.TabIndex = 73
			Me.txtRemark.TabStop = False
			Me.ColumnHeader76.Text = "TokenNo"
			Me.ColumnHeader76.Width = 230
			Me.ListView2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.ListView2.BackColor = Global.System.Drawing.Color.DeepSkyBlue
			Me.ListView2.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader76, Me.ColumnHeader39 })
			Me.ListView2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ListView2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ListView2.FullRowSelect = True
			Me.ListView2.GridLines = True
			Me.ListView2.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.ListView2.HideSelection = False
			Me.ListView2.Location = New Global.System.Drawing.Point(15, 63)
			Me.ListView2.MultiSelect = False
			Me.ListView2.Name = "ListView2"
			Me.ListView2.Size = New Global.System.Drawing.Size(329, 559)
			Me.ListView2.TabIndex = 547
			Me.ListView2.TabStop = False
			Me.ListView2.UseCompatibleStateImageBehavior = False
			Me.ListView2.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader39.Text = "Product Item"
			Me.ColumnHeader39.Width = 100
			Me.txtDB.Location = New Global.System.Drawing.Point(461, 26)
			Me.txtDB.Multiline = True
			Me.txtDB.Name = "txtDB"
			Me.txtDB.[ReadOnly] = True
			Me.txtDB.Size = New Global.System.Drawing.Size(38, 20)
			Me.txtDB.TabIndex = 548
			Me.txtDB.TabStop = False
			Me.txtDB.WordWrap = False
			Me.txtBranchCode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBranchCode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBranchCode.Location = New Global.System.Drawing.Point(366, 9)
			Me.txtBranchCode.Name = "txtBranchCode"
			Me.txtBranchCode.Size = New Global.System.Drawing.Size(130, 21)
			Me.txtBranchCode.TabIndex = 549
			Me.txtBranchCode.TabStop = False
			Me.txtBranchCode.Visible = False
			Me.cmbBranchFrom.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchFrom.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchFrom.FormattingEnabled = True
			Me.cmbBranchFrom.Location = New Global.System.Drawing.Point(640, 25)
			Me.cmbBranchFrom.Name = "cmbBranchFrom"
			Me.cmbBranchFrom.Size = New Global.System.Drawing.Size(162, 21)
			Me.cmbBranchFrom.TabIndex = 550
			Me.cmbBranchAdmin.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbBranchAdmin.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbBranchAdmin.FormattingEnabled = True
			Me.cmbBranchAdmin.Location = New Global.System.Drawing.Point(1062, 3)
			Me.cmbBranchAdmin.Name = "cmbBranchAdmin"
			Me.cmbBranchAdmin.Size = New Global.System.Drawing.Size(162, 21)
			Me.cmbBranchAdmin.TabIndex = 551
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.SystemColors.Highlight
			Me.GelButton2.GradientTop = Global.System.Drawing.SystemColors.HotTrack
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(979, 14)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(100, 38)
			Me.GelButton2.TabIndex = 552
			Me.GelButton2.Text = "&RePrint"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
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
			Me.GelButton1.Location = New Global.System.Drawing.Point(-66, 9)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(159, 38)
			Me.GelButton1.TabIndex = 546
			Me.GelButton1.Text = "&Show Pending Token"
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
			Me.btnDToken.Location = New Global.System.Drawing.Point(1085, 14)
			Me.btnDToken.Name = "btnDToken"
			Me.btnDToken.Size = New Global.System.Drawing.Size(187, 38)
			Me.btnDToken.TabIndex = 545
			Me.btnDToken.Text = "&Send Post"
			Me.btnDToken.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDToken.UseVisualStyleBackColor = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 701)
			MyBase.Controls.Add(Me.GelButton2)
			MyBase.Controls.Add(Me.cmbBranchAdmin)
			MyBase.Controls.Add(Me.cmbBranchFrom)
			MyBase.Controls.Add(Me.txtBranchCode)
			MyBase.Controls.Add(Me.txtDB)
			MyBase.Controls.Add(Me.ListView2)
			MyBase.Controls.Add(Me.GelButton1)
			MyBase.Controls.Add(Me.btnDToken)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.txtRemark)
			MyBase.Controls.Add(Me.DateTimePicker1)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.cmbBranchTo)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.Label21)
			MyBase.Name = "frmTokenOut"
			Me.Text = "frmTokenOut"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x0400712C RID: 28972
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
