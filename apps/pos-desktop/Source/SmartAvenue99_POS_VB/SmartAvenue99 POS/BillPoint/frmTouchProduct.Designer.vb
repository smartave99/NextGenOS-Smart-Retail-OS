Namespace BillPoint
	' Token: 0x0200020F RID: 527
		Public Partial Class frmTouchProduct
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060098CD RID: 39117 RVA: 0x006DA8DC File Offset: 0x006D8ADC
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

		' Token: 0x060098CE RID: 39118 RVA: 0x006DA92C File Offset: 0x006D8B2C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTouchProduct))
			Me.FlowLayoutPanel1 = New Global.System.Windows.Forms.FlowLayoutPanel()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.NumericUpDown1 = New Global.System.Windows.Forms.NumericUpDown()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.cmbCategory = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.CheckBox1 = New Global.System.Windows.Forms.CheckBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.cmbComboPack = New Global.System.Windows.Forms.ComboBox()
			Me.Panel1.SuspendLayout()
			CType(Me.NumericUpDown1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.FlowLayoutPanel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.FlowLayoutPanel1.AutoScroll = True
			Me.FlowLayoutPanel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.FlowLayoutPanel1.Location = New Global.System.Drawing.Point(0, 64)
			Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
			Me.FlowLayoutPanel1.Size = New Global.System.Drawing.Size(987, 397)
			Me.FlowLayoutPanel1.TabIndex = 5
			Me.FlowLayoutPanel1.TabStop = True
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.Controls.Add(Me.cmbComboPack)
			Me.Panel1.Controls.Add(Me.Label9)
			Me.Panel1.Controls.Add(Me.Label8)
			Me.Panel1.Controls.Add(Me.NumericUpDown1)
			Me.Panel1.Controls.Add(Me.Label6)
			Me.Panel1.Controls.Add(Me.Label7)
			Me.Panel1.Controls.Add(Me.Label3)
			Me.Panel1.Controls.Add(Me.Label5)
			Me.Panel1.Controls.Add(Me.cmbCategory)
			Me.Panel1.Controls.Add(Me.Label4)
			Me.Panel1.Controls.Add(Me.TextBox1)
			Me.Panel1.Controls.Add(Me.Button2)
			Me.Panel1.Controls.Add(Me.btnReset)
			Me.Panel1.Controls.Add(Me.Label2)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.TextBox2)
			Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
			Me.Panel1.Controls.Add(Me.CheckBox1)
			Me.Panel1.Location = New Global.System.Drawing.Point(8, 9)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(987, 461)
			Me.Panel1.TabIndex = 1
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(277, 6)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label8.TabIndex = 436
			Me.Label8.Text = "Label8"
			Me.Label8.Visible = False
			Me.NumericUpDown1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.NumericUpDown1.Location = New Global.System.Drawing.Point(879, 42)
			Dim numericUpDown As Global.System.Windows.Forms.NumericUpDown = Me.NumericUpDown1
			Dim array As Integer() = New Integer(3) {}
			array(0) = 1316134911
			array(1) = 2328
			numericUpDown.Maximum = New Decimal(array)
			Me.NumericUpDown1.Name = "NumericUpDown1"
			Me.NumericUpDown1.Size = New Global.System.Drawing.Size(46, 20)
			Me.NumericUpDown1.TabIndex = 435
			Me.NumericUpDown1.TabStop = False
			Me.NumericUpDown1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Dim numericUpDown2 As Global.System.Windows.Forms.NumericUpDown = Me.NumericUpDown1
			Dim array2 As Integer() = New Integer(3) {}
			array2(0) = 100
			numericUpDown2.Value = New Decimal(array2)
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label6.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label6.Location = New Global.System.Drawing.Point(846, 44)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(32, 13)
			Me.Label6.TabIndex = 433
			Me.Label6.Text = "( Top"
			Me.Label7.AutoSize = True
			Me.Label7.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label7.ForeColor = Global.System.Drawing.Color.Maroon
			Me.Label7.Location = New Global.System.Drawing.Point(925, 44)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(53, 13)
			Me.Label7.TabIndex = 434
			Me.Label7.Text = "Records )"
			Me.Label3.AutoSize = True
			Me.Label3.BackColor = Global.System.Drawing.Color.White
			Me.Label3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.Label3.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label3.Location = New Global.System.Drawing.Point(3, 2)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(14, 21)
			Me.Label3.TabIndex = 415
			Me.Label3.Text = "."
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label5.Location = New Global.System.Drawing.Point(78, 9)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(95, 15)
			Me.Label5.TabIndex = 418
			Me.Label5.Text = "Category Name :"
			Me.cmbCategory.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbCategory.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbCategory.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold)
			Me.cmbCategory.FormattingEnabled = True
			Me.cmbCategory.Location = New Global.System.Drawing.Point(82, 28)
			Me.cmbCategory.Name = "cmbCategory"
			Me.cmbCategory.Size = New Global.System.Drawing.Size(176, 29)
			Me.cmbCategory.TabIndex = 0
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(325, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(39, 13)
			Me.Label4.TabIndex = 416
			Me.Label4.Text = "Label4"
			Me.Label4.Visible = False
			Me.TextBox1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox1.Location = New Global.System.Drawing.Point(505, 27)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(179, 29)
			Me.TextBox1.TabIndex = 1
			Me.Button2.BackColor = Global.System.Drawing.Color.WhiteSmoke
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.Transparent
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.Location = New Global.System.Drawing.Point(914, 6)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(65, 34)
			Me.Button2.TabIndex = 4
			Me.Button2.UseVisualStyleBackColor = False
			Me.btnReset.BackColor = Global.System.Drawing.Color.WhiteSmoke
			Me.btnReset.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Me.btnReset.Image = CType(componentResourceManager.GetObject("btnReset.Image"), Global.System.Drawing.Image)
			Me.btnReset.Location = New Global.System.Drawing.Point(843, 6)
			Me.btnReset.Name = "btnReset"
			Me.btnReset.Size = New Global.System.Drawing.Size(65, 34)
			Me.btnReset.TabIndex = 3
			Me.btnReset.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnReset.UseVisualStyleBackColor = False
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label2.Location = New Global.System.Drawing.Point(686, 8)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(156, 15)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Search By Product Barcode :"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label1.Location = New Global.System.Drawing.Point(507, 8)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(145, 15)
			Me.Label1.TabIndex = 3
			Me.Label1.Text = "Search By Product Name :"
			Me.TextBox2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TextBox2.Location = New Global.System.Drawing.Point(689, 27)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(146, 29)
			Me.TextBox2.TabIndex = 2
			Me.CheckBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.CheckBox1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.CheckBox1.ForeColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			Me.CheckBox1.Location = New Global.System.Drawing.Point(7, 18)
			Me.CheckBox1.Name = "CheckBox1"
			Me.CheckBox1.Size = New Global.System.Drawing.Size(65, 50)
			Me.CheckBox1.TabIndex = 419
			Me.CheckBox1.TabStop = False
			Me.CheckBox1.Text = "Show All"
			Me.CheckBox1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.CheckBox1.UseVisualStyleBackColor = True
			Me.Label9.AutoSize = True
			Me.Label9.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.DarkSlateGray
			Me.Label9.Location = New Global.System.Drawing.Point(264, 9)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(167, 15)
			Me.Label9.TabIndex = 437
			Me.Label9.Text = "Search By ComboPack Name :"
			Me.cmbComboPack.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbComboPack.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbComboPack.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbComboPack.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbComboPack.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.cmbComboPack.FormattingEnabled = True
			Me.cmbComboPack.ImeMode = Global.System.Windows.Forms.ImeMode.NoControl
			Me.cmbComboPack.Location = New Global.System.Drawing.Point(264, 28)
			Me.cmbComboPack.Name = "cmbComboPack"
			Me.cmbComboPack.Size = New Global.System.Drawing.Size(222, 28)
			Me.cmbComboPack.TabIndex = 526
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1004, 477)
			MyBase.Controls.Add(Me.Panel1)
			Me.DoubleBuffered = True
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.Name = "frmTouchProduct"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Product List"
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.NumericUpDown1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400439B RID: 17307
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
