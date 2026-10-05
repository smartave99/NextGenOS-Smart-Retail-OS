Namespace BillPoint
	' Token: 0x020004C1 RID: 1217
		Public Partial Class frmDamageProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600F3E8 RID: 62440 RVA: 0x0092400C File Offset: 0x0092220C
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

		' Token: 0x0600F3E9 RID: 62441 RVA: 0x0092405C File Offset: 0x0092225C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmDamageProduct))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.TextBox11 = New Global.System.Windows.Forms.TextBox()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.TextBox12 = New Global.System.Windows.Forms.TextBox()
			Me.FlowLayoutPanel1 = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.CheckBox2 = New Global.System.Windows.Forms.CheckBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.TextBox9 = New Global.System.Windows.Forms.TextBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Button4 = New Global.GelButtons.GelButton()
			Me.TextBox7 = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.TextBox6 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox5 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox4 = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.cmbProductID = New Global.System.Windows.Forms.ComboBox()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.txtTotAvlQty = New Global.System.Windows.Forms.TextBox()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtTotDamage = New Global.System.Windows.Forms.TextBox()
			Me.txtGoodQty = New Global.System.Windows.Forms.TextBox()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.TextBox10 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox8 = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.Panel2.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.CheckBox1)
			Me.Panel1.Controls.Add(Me.TextBox11)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.TextBox12)
			Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1044, 499)
			Me.Panel1.TabIndex = 0
			Me.CheckBox1.AutoSize = True
			Me.CheckBox1.BackColor = Global.System.Drawing.Color.SpringGreen
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.ForeColor = Global.System.Drawing.Color.Navy
			Me.CheckBox1.Location = New Global.System.Drawing.Point(383, 63)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(112, 24)
			Me.CheckBox1.TabIndex = 416
			Me.CheckBox1.Text = "Show Items"
			Me.CheckBox1.UseVisualStyleBackColor = False
			Me.TextBox11.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox11.Location = New Global.System.Drawing.Point(596, 63)
			Me.TextBox11.Name = "TextBox11"
			Me.TextBox11.Size = New Global.System.Drawing.Size(211, 29)
			Me.TextBox11.TabIndex = 412
			Me.TextBox11.TabStop = False
			Me.Label10.AutoSize = True
			Me.Label10.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label10.Location = New Global.System.Drawing.Point(807, 41)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(216, 21)
			Me.Label10.TabIndex = 415
			Me.Label10.Text = "Search By Product Barcode :"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label11.Location = New Global.System.Drawing.Point(592, 40)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(198, 21)
			Me.Label11.TabIndex = 414
			Me.Label11.Text = "Search By Product Name :"
			Me.TextBox12.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox12.Location = New Global.System.Drawing.Point(813, 63)
			Me.TextBox12.Name = "TextBox12"
			Me.TextBox12.Size = New Global.System.Drawing.Size(211, 29)
			Me.TextBox12.TabIndex = 413
			Me.TextBox12.TabStop = False
			Me.FlowLayoutPanel1.AutoScroll = True
			Me.FlowLayoutPanel1.Location = New Global.System.Drawing.Point(383, 96)
			Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
			Me.FlowLayoutPanel1.Size = New Global.System.Drawing.Size(640, 382)
			Me.FlowLayoutPanel1.TabIndex = 411
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(838, 17)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 410
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Panel2.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel2.Controls.Add(Me.CheckBox2)
			Me.Panel2.Controls.Add(Me.Button2)
			Me.Panel2.Controls.Add(Me.GroupBox2)
			Me.Panel2.Controls.Add(Me.GroupBox1)
			Me.Panel2.Controls.Add(Me.btnReset)
			Me.Panel2.Controls.Add(Me.Label7)
			Me.Panel2.Controls.Add(Me.Label6)
			Me.Panel2.Controls.Add(Me.TextBox6)
			Me.Panel2.Controls.Add(Me.TextBox5)
			Me.Panel2.Controls.Add(Me.TextBox4)
			Me.Panel2.Controls.Add(Me.Label5)
			Me.Panel2.Controls.Add(Me.TextBox3)
			Me.Panel2.Controls.Add(Me.TextBox2)
			Me.Panel2.Controls.Add(Me.TextBox1)
			Me.Panel2.Controls.Add(Me.Label4)
			Me.Panel2.Controls.Add(Me.Label3)
			Me.Panel2.Controls.Add(Me.Label2)
			Me.Panel2.Controls.Add(Me.cmbProductID)
			Me.Panel2.Controls.Add(Me.GroupBox3)
			Me.Panel2.Controls.Add(Me.TextBox10)
			Me.Panel2.Controls.Add(Me.TextBox8)
			Me.Panel2.Location = New Global.System.Drawing.Point(4, 41)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(373, 437)
			Me.Panel2.TabIndex = 409
			Me.CheckBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.CheckBox2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox2.ForeColor = Global.System.Drawing.Color.White
			Me.CheckBox2.Location = New Global.System.Drawing.Point(288, 74)
			Me.CheckBox2.Name = "CheckBox2"
			Me.CheckBox2.Size = New Global.System.Drawing.Size(69, 78)
			Me.CheckBox2.TabIndex = 417
			Me.CheckBox2.Text = "Over Items Entry"
			Me.CheckBox2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox2.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.White
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.Black
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(302, 226)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(57, 56)
			Me.Button2.TabIndex = 22
			Me.Button2.TabStop = False
			Me.Button2.UseVisualStyleBackColor = False
			Me.GroupBox2.Controls.Add(Me.Button1)
			Me.GroupBox2.Controls.Add(Me.TextBox9)
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(7, 267)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(289, 78)
			Me.GroupBox2.TabIndex = 2
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Recover Product Entry"
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button1.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(150, 27)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(127, 43)
			Me.Button1.TabIndex = 516
			Me.Button1.Text = "Save"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.TextBox9.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox9.Location = New Global.System.Drawing.Point(6, 40)
			Me.TextBox9.Name = "TextBox9"
			Me.TextBox9.Size = New Global.System.Drawing.Size(139, 29)
			Me.TextBox9.TabIndex = 0
			Me.TextBox9.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label9.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(141, 16)
			Me.Label9.TabIndex = 17
			Me.Label9.Text = "Enter Recover Qty :"
			Me.GroupBox1.Controls.Add(Me.Button4)
			Me.GroupBox1.Controls.Add(Me.TextBox7)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(7, 186)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(289, 78)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Damage Product Entry"
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
			Me.Button4.Location = New Global.System.Drawing.Point(150, 29)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(127, 43)
			Me.Button4.TabIndex = 515
			Me.Button4.Text = "Save"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.TextBox7.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.TextBox7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox7.Location = New Global.System.Drawing.Point(6, 40)
			Me.TextBox7.Name = "TextBox7"
			Me.TextBox7.Size = New Global.System.Drawing.Size(139, 29)
			Me.TextBox7.TabIndex = 0
			Me.TextBox7.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.Red
			Me.Label8.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(141, 16)
			Me.Label8.TabIndex = 17
			Me.Label8.Text = "Enter Damage Qty :"
			Me.btnReset.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.Black
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnReset.Location = New Global.System.Drawing.Point(302, 288)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(57, 56)
			Me.btnReset.TabIndex = 3
			Me.btnReset.Text = "&Reset"
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(7, 161)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Damage Quality Qty :"
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(7, 132)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(93, 13)
			Me.Label6.TabIndex = 12
			Me.Label6.Text = "Good Quality Qty :"
			Me.TextBox6.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox6.Location = New Global.System.Drawing.Point(124, 132)
			Me.TextBox6.Name = "TextBox6"
			Me.TextBox6.[ReadOnly] = True
			Me.TextBox6.Size = New Global.System.Drawing.Size(123, 20)
			Me.TextBox6.TabIndex = 11
			Me.TextBox6.TabStop = False
			Me.TextBox6.Text = "0.000"
			Me.TextBox6.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox5.ForeColor = Global.System.Drawing.Color.Red
			Me.TextBox5.Location = New Global.System.Drawing.Point(124, 161)
			Me.TextBox5.Name = "TextBox5"
			Me.TextBox5.[ReadOnly] = True
			Me.TextBox5.Size = New Global.System.Drawing.Size(123, 20)
			Me.TextBox5.TabIndex = 10
			Me.TextBox5.TabStop = False
			Me.TextBox5.Text = "0.000"
			Me.TextBox5.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox4.ForeColor = Global.System.Drawing.Color.Blue
			Me.TextBox4.Location = New Global.System.Drawing.Point(124, 103)
			Me.TextBox4.Name = "TextBox4"
			Me.TextBox4.[ReadOnly] = True
			Me.TextBox4.Size = New Global.System.Drawing.Size(123, 20)
			Me.TextBox4.TabIndex = 9
			Me.TextBox4.TabStop = False
			Me.TextBox4.Text = "0.000"
			Me.TextBox4.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(7, 104)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(75, 13)
			Me.Label5.TabIndex = 8
			Me.Label5.Text = "Avaliable Qty :"
			Me.TextBox3.Location = New Global.System.Drawing.Point(231, 220)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.[ReadOnly] = True
			Me.TextBox3.Size = New Global.System.Drawing.Size(35, 20)
			Me.TextBox3.TabIndex = 7
			Me.TextBox3.TabStop = False
			Me.TextBox3.Visible = False
			Me.TextBox2.Location = New Global.System.Drawing.Point(124, 74)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(123, 20)
			Me.TextBox2.TabIndex = 6
			Me.TextBox2.TabStop = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(124, 45)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.[ReadOnly] = True
			Me.TextBox1.Size = New Global.System.Drawing.Size(233, 20)
			Me.TextBox1.TabIndex = 5
			Me.TextBox1.TabStop = False
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(7, 74)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label4.TabIndex = 4
			Me.Label4.Text = "Product Code : :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(7, 45)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 13)
			Me.Label3.TabIndex = 3
			Me.Label3.Text = "Product Name :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(7, 15)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label2.TabIndex = 2
			Me.Label2.Text = "Barcode :"
			Me.cmbProductID.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbProductID.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbProductID.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbProductID.FormattingEnabled = True
			Me.cmbProductID.Location = New Global.System.Drawing.Point(124, 15)
			Me.cmbProductID.Name = "cmbProductID"
			Me.cmbProductID.Size = New Global.System.Drawing.Size(233, 21)
			Me.cmbProductID.TabIndex = 0
			Me.GroupBox3.Controls.Add(Me.txtTotAvlQty)
			Me.GroupBox3.Controls.Add(Me.Label14)
			Me.GroupBox3.Controls.Add(Me.Label12)
			Me.GroupBox3.Controls.Add(Me.txtTotDamage)
			Me.GroupBox3.Controls.Add(Me.txtGoodQty)
			Me.GroupBox3.Controls.Add(Me.Label13)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(7, 346)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(352, 86)
			Me.GroupBox3.TabIndex = 29
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "Stock Summary"
			Me.txtTotAvlQty.BackColor = Global.System.Drawing.Color.White
			Me.txtTotAvlQty.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtTotAvlQty.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.txtTotAvlQty.ForeColor = Global.System.Drawing.Color.DarkGreen
			Me.txtTotAvlQty.Location = New Global.System.Drawing.Point(209, 16)
			Me.txtTotAvlQty.Name = "txtTotAvlQty"
			Me.txtTotAvlQty.[ReadOnly] = True
			Me.txtTotAvlQty.Size = New Global.System.Drawing.Size(118, 20)
			Me.txtTotAvlQty.TabIndex = 27
			Me.txtTotAvlQty.TabStop = False
			Me.txtTotAvlQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label14.Location = New Global.System.Drawing.Point(15, 13)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(191, 20)
			Me.Label14.TabIndex = 28
			Me.Label14.Text = "Grand Total Avaliable Qty :"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.Label12.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label12.Location = New Global.System.Drawing.Point(15, 36)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(185, 20)
			Me.Label12.TabIndex = 24
			Me.Label12.Text = "Grand Total Damage Qty :"
			Me.txtTotDamage.BackColor = Global.System.Drawing.Color.White
			Me.txtTotDamage.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtTotDamage.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.txtTotDamage.ForeColor = Global.System.Drawing.Color.Red
			Me.txtTotDamage.Location = New Global.System.Drawing.Point(209, 38)
			Me.txtTotDamage.Name = "txtTotDamage"
			Me.txtTotDamage.[ReadOnly] = True
			Me.txtTotDamage.Size = New Global.System.Drawing.Size(118, 20)
			Me.txtTotDamage.TabIndex = 23
			Me.txtTotDamage.TabStop = False
			Me.txtTotDamage.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtGoodQty.BackColor = Global.System.Drawing.Color.White
			Me.txtGoodQty.BorderStyle = Global.System.Windows.Forms.BorderStyle.None
			Me.txtGoodQty.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.txtGoodQty.ForeColor = Global.System.Drawing.Color.Blue
			Me.txtGoodQty.Location = New Global.System.Drawing.Point(209, 60)
			Me.txtGoodQty.Name = "txtGoodQty"
			Me.txtGoodQty.[ReadOnly] = True
			Me.txtGoodQty.Size = New Global.System.Drawing.Size(118, 20)
			Me.txtGoodQty.TabIndex = 25
			Me.txtGoodQty.TabStop = False
			Me.txtGoodQty.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.Label13.ForeColor = Global.System.Drawing.Color.SaddleBrown
			Me.Label13.Location = New Global.System.Drawing.Point(15, 58)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(165, 20)
			Me.Label13.TabIndex = 26
			Me.Label13.Text = "Grand Total Good Qty :"
			Me.TextBox10.Location = New Global.System.Drawing.Point(265, 161)
			Me.TextBox10.Name = "TextBox10"
			Me.TextBox10.[ReadOnly] = True
			Me.TextBox10.Size = New Global.System.Drawing.Size(43, 20)
			Me.TextBox10.TabIndex = 21
			Me.TextBox10.TabStop = False
			Me.TextBox10.Text = "0"
			Me.TextBox10.Visible = False
			Me.TextBox8.Location = New Global.System.Drawing.Point(314, 161)
			Me.TextBox8.Name = "TextBox8"
			Me.TextBox8.[ReadOnly] = True
			Me.TextBox8.Size = New Global.System.Drawing.Size(32, 20)
			Me.TextBox8.TabIndex = 18
			Me.TextBox8.TabStop = False
			Me.TextBox8.Text = "0"
			Me.TextBox8.Visible = False
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-11, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1054, 33)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Damage / Recover Product Management"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1044, 499)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmDamageProduct"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			Me.GroupBox3.PerformLayout()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04005D3B RID: 23867
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
