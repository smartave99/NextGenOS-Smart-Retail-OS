Namespace BillPoint
	' Token: 0x02000602 RID: 1538
		Public Partial Class frmStockTransfer
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06012B75 RID: 76661 RVA: 0x00ABED38 File Offset: 0x00ABCF38
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

		' Token: 0x06012B76 RID: 76662 RVA: 0x00ABED88 File Offset: 0x00ABCF88
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmStockTransfer))
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.txtBarcode = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.lblUserType = New Global.System.Windows.Forms.Label()
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
			Me.ColumnHeader37 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader38 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader39 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader40 = New Global.System.Windows.Forms.ColumnHeader()
			Me.chkSelectAll = New Global.System.Windows.Forms.CheckBox()
			Me.lblToken = New Global.System.Windows.Forms.Label()
			Me.txtBar = New Global.System.Windows.Forms.TextBox()
			Me.btnDToken = New Global.GelButtons.GelButton()
			Me.btnRemove = New Global.GelButtons.GelButton()
			Me.TextBox42 = New Global.System.Windows.Forms.TextBox()
			Me.TxtUpdateTQty = New Global.System.Windows.Forms.TextBox()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.txtBarcodeUpdate = New Global.System.Windows.Forms.TextBox()
			Me.txtProduct = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.txtPid = New Global.System.Windows.Forms.TextBox()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.GroupBox1.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Label21.AutoSize = True
			Me.Label21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label21.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.Label21.Location = New Global.System.Drawing.Point(12, 9)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(59, 15)
			Me.Label21.TabIndex = 33
			Me.Label21.Text = "Barcode :"
			Me.txtBarcode.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtBarcode.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtBarcode.Location = New Global.System.Drawing.Point(15, 25)
			Me.txtBarcode.Name = "txtBarcode"
			Me.txtBarcode.Size = New Global.System.Drawing.Size(225, 21)
			Me.txtBarcode.TabIndex = 32
			Me.txtBarcode.TabStop = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUser.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUser.Location = New Global.System.Drawing.Point(310, 9)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(46, 15)
			Me.lblUser.TabIndex = 45
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.lblUserType.AutoSize = True
			Me.lblUserType.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblUserType.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 0)
			Me.lblUserType.Location = New Global.System.Drawing.Point(372, 9)
			Me.lblUserType.Name = "lblUserType"
			Me.lblUserType.Size = New Global.System.Drawing.Size(72, 15)
			Me.lblUserType.TabIndex = 46
			Me.lblUserType.Text = "lblUserType"
			Me.lblUserType.Visible = False
			Me.listView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.listView1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 128)
			Me.listView1.CheckBoxes = True
			Me.listView1.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader31, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader19, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader14, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader40 })
			Me.listView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.listView1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.listView1.FullRowSelect = True
			Me.listView1.GridLines = True
			Me.listView1.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listView1.HideSelection = False
			Me.listView1.Location = New Global.System.Drawing.Point(15, 79)
			Me.listView1.MultiSelect = False
			Me.listView1.Name = "listView1"
			Me.listView1.Size = New Global.System.Drawing.Size(1257, 598)
			Me.listView1.TabIndex = 69
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
			Me.ColumnHeader37.Text = "Transfer Quantity"
			Me.ColumnHeader38.Text = "TokenNo"
			Me.ColumnHeader38.Width = 100
			Me.ColumnHeader39.Text = "Category"
			Me.ColumnHeader40.Text = "Sub Category"
			Me.chkSelectAll.AutoSize = True
			Me.chkSelectAll.BackColor = Global.System.Drawing.Color.Red
			Me.chkSelectAll.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.chkSelectAll.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.chkSelectAll.ForeColor = Global.System.Drawing.Color.White
			Me.chkSelectAll.Location = New Global.System.Drawing.Point(15, 52)
			Me.chkSelectAll.Name = "chkSelectAll"
			Me.chkSelectAll.Size = New Global.System.Drawing.Size(81, 21)
			Me.chkSelectAll.TabIndex = 543
			Me.chkSelectAll.TabStop = False
			Me.chkSelectAll.Text = "Select All"
			Me.chkSelectAll.UseVisualStyleBackColor = False
			Me.lblToken.AutoSize = True
			Me.lblToken.Location = New Global.System.Drawing.Point(183, 4)
			Me.lblToken.Name = "lblToken"
			Me.lblToken.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblToken.TabIndex = 545
			Me.lblToken.Text = "Label1"
			Me.txtBar.Location = New Global.System.Drawing.Point(246, 26)
			Me.txtBar.Name = "txtBar"
			Me.txtBar.Size = New Global.System.Drawing.Size(100, 20)
			Me.txtBar.TabIndex = 546
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
			Me.btnDToken.Location = New Global.System.Drawing.Point(1117, 15)
			Me.btnDToken.Name = "btnDToken"
			Me.btnDToken.Size = New Global.System.Drawing.Size(155, 38)
			Me.btnDToken.TabIndex = 544
			Me.btnDToken.Text = "&Generate Token"
			Me.btnDToken.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDToken.UseVisualStyleBackColor = False
			Me.btnRemove.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnRemove.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnRemove.FlatAppearance.BorderSize = 0
			Me.btnRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemove.ForeColor = Global.System.Drawing.Color.White
			Me.btnRemove.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnRemove.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnRemove.Image = CType(componentResourceManager.GetObject("btnRemove.Image"), Global.System.Drawing.Image)
			Me.btnRemove.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnRemove.Location = New Global.System.Drawing.Point(605, 17)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New Global.System.Drawing.Size(112, 38)
			Me.btnRemove.TabIndex = 542
			Me.btnRemove.Text = "&Remove"
			Me.btnRemove.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnRemove.UseVisualStyleBackColor = False
			Me.TextBox42.Location = New Global.System.Drawing.Point(637, 4)
			Me.TextBox42.Name = "TextBox42"
			Me.TextBox42.Size = New Global.System.Drawing.Size(21, 20)
			Me.TextBox42.TabIndex = 547
			Me.TextBox42.TabStop = False
			Me.TextBox42.Visible = False
			Me.TxtUpdateTQty.Location = New Global.System.Drawing.Point(453, 33)
			Me.TxtUpdateTQty.Name = "TxtUpdateTQty"
			Me.TxtUpdateTQty.Size = New Global.System.Drawing.Size(140, 20)
			Me.TxtUpdateTQty.TabIndex = 548
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.Green
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.Green
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(723, 17)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(113, 38)
			Me.GelButton1.TabIndex = 549
			Me.GelButton1.Text = "&Update"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.txtBarcodeUpdate.Location = New Global.System.Drawing.Point(307, 33)
			Me.txtBarcodeUpdate.Name = "txtBarcodeUpdate"
			Me.txtBarcodeUpdate.[ReadOnly] = True
			Me.txtBarcodeUpdate.Size = New Global.System.Drawing.Size(140, 20)
			Me.txtBarcodeUpdate.TabIndex = 550
			Me.txtProduct.Location = New Global.System.Drawing.Point(68, 33)
			Me.txtProduct.Name = "txtProduct"
			Me.txtProduct.[ReadOnly] = True
			Me.txtProduct.Size = New Global.System.Drawing.Size(233, 20)
			Me.txtProduct.TabIndex = 551
			Me.Label1.AutoSize = True
			Me.Label1.Location = New Global.System.Drawing.Point(68, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label1.TabIndex = 552
			Me.Label1.Text = "Product Name"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(304, 17)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label2.TabIndex = 553
			Me.Label2.Text = "Barcode"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(450, 16)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label3.TabIndex = 554
			Me.Label3.Text = "T- Qty"
			Me.txtPid.Location = New Global.System.Drawing.Point(24, 33)
			Me.txtPid.Name = "txtPid"
			Me.txtPid.[ReadOnly] = True
			Me.txtPid.Size = New Global.System.Drawing.Size(38, 20)
			Me.txtPid.TabIndex = 555
			Me.GroupBox1.Controls.Add(Me.TxtUpdateTQty)
			Me.GroupBox1.Controls.Add(Me.txtPid)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.GelButton1)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtBarcodeUpdate)
			Me.GroupBox1.Controls.Add(Me.btnRemove)
			Me.GroupBox1.Controls.Add(Me.Label1)
			Me.GroupBox1.Controls.Add(Me.txtProduct)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(388, 9)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(841, 66)
			Me.GroupBox1.TabIndex = 556
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "QtyUpdate"
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.SystemColors.ControlLightLight
			MyBase.ClientSize = New Global.System.Drawing.Size(1284, 689)
			MyBase.Controls.Add(Me.GroupBox1)
			MyBase.Controls.Add(Me.txtBar)
			MyBase.Controls.Add(Me.TextBox42)
			MyBase.Controls.Add(Me.lblToken)
			MyBase.Controls.Add(Me.btnDToken)
			MyBase.Controls.Add(Me.chkSelectAll)
			MyBase.Controls.Add(Me.listView1)
			MyBase.Controls.Add(Me.lblUserType)
			MyBase.Controls.Add(Me.lblUser)
			MyBase.Controls.Add(Me.Label21)
			MyBase.Controls.Add(Me.txtBarcode)
			MyBase.Name = "frmStockTransfer"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmStockTransfer"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040070AB RID: 28843
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
