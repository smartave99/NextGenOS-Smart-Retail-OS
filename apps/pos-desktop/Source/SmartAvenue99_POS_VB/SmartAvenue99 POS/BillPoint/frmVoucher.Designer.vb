Namespace BillPoint
	' Token: 0x020005C0 RID: 1472
		Public Partial Class frmVoucher
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06011E8A RID: 73354 RVA: 0x00A51EB4 File Offset: 0x00A500B4
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

		' Token: 0x06011E8B RID: 73355 RVA: 0x00A51F04 File Offset: 0x00A50104
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmVoucher))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.txtRsToWords = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.txtDetails = New Global.System.Windows.Forms.TextBox()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.Label74 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.txtGrandTotal = New Global.System.Windows.Forms.TextBox()
			Me.Label31 = New Global.System.Windows.Forms.Label()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.btnNext = New Global.System.Windows.Forms.Button()
			Me.btnFirst = New Global.System.Windows.Forms.Button()
			Me.txtPrev = New Global.System.Windows.Forms.Button()
			Me.btnLast = New Global.System.Windows.Forms.Button()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.cmbtxtName = New Global.System.Windows.Forms.ComboBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtVoucherNo = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.cmbParticulars = New Global.System.Windows.Forms.ComboBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.btnRemove = New Global.System.Windows.Forms.Button()
			Me.txtNotes = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.btnAdd = New Global.System.Windows.Forms.Button()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.txtAmount = New Global.System.Windows.Forms.TextBox()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.btnGetData = New Global.GelButtons.GelButton()
			Me.btnPrint = New Global.GelButtons.GelButton()
			Me.btnUpdate = New Global.GelButtons.GelButton()
			Me.btnDelete = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.btnSave = New Global.GelButtons.GelButton()
			Me.Panel2 = New Global.System.Windows.Forms.Panel()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.lblCPhone = New Global.System.Windows.Forms.Label()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.cmbNP = New Global.System.Windows.Forms.ComboBox()
			Me.Button35 = New Global.System.Windows.Forms.Button()
			Me.Button34 = New Global.System.Windows.Forms.Button()
			Me.txtNP = New Global.System.Windows.Forms.TextBox()
			Me.txtSuffix = New Global.System.Windows.Forms.TextBox()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.txtInvCode1 = New Global.System.Windows.Forms.TextBox()
			Me.txtVoucherID = New Global.System.Windows.Forms.TextBox()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.ToolTip1 = New Global.System.Windows.Forms.ToolTip(Me.components)
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Dim label As Global.System.Windows.Forms.Label = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel3.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			Me.Panel4.SuspendLayout()
			Me.Panel2.SuspendLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			label.AutoSize = True
			label.ForeColor = Global.System.Drawing.Color.Black
			label.Location = New Global.System.Drawing.Point(26, 23)
			label.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			label.Name = "Label5"
			label.Size = New Global.System.Drawing.Size(73, 13)
			label.TabIndex = 268
			label.Text = "Voucher No. :"
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.txtRsToWords)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.GroupBox4)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel2)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(708, 629)
			Me.Panel1.TabIndex = 2
			Me.txtRsToWords.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.txtRsToWords.AutoSize = True
			Me.txtRsToWords.Location = New Global.System.Drawing.Point(621, 457)
			Me.txtRsToWords.Name = "txtRsToWords"
			Me.txtRsToWords.Size = New Global.System.Drawing.Size(75, 13)
			Me.txtRsToWords.TabIndex = 1757
			Me.txtRsToWords.Text = "txtRsToWords"
			Me.txtRsToWords.Visible = False
			Me.GroupBox1.Controls.Add(Me.txtDetails)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(9, 153)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(549, 77)
			Me.GroupBox1.TabIndex = 1
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Details"
			Me.txtDetails.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtDetails.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtDetails.Location = New Global.System.Drawing.Point(121, 16)
			Me.txtDetails.Multiline = True
			Me.txtDetails.Name = "txtDetails"
			Me.txtDetails.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.txtDetails.Size = New Global.System.Drawing.Size(411, 52)
			Me.txtDetails.TabIndex = 3
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.FromArgb(64, 64, 64)
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(9, 392)
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.CadetBlue
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.Khaki
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(468, 211)
			Me.DataGridView1.TabIndex = 2
			Me.DataGridView1.TabStop = False
			Me.Column1.HeaderText = "Particulars"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Width = 200
			Me.Column2.HeaderText = "Amount"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Notes"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 140
			Me.Panel3.BackColor = Global.System.Drawing.Color.Transparent
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.Label74)
			Me.Panel3.Controls.Add(Me.cmbAccountNo)
			Me.Panel3.Controls.Add(Me.ComboBox1)
			Me.Panel3.Controls.Add(Me.Label4)
			Me.Panel3.Controls.Add(Me.txtGrandTotal)
			Me.Panel3.Controls.Add(Me.Label31)
			Me.Panel3.Location = New Global.System.Drawing.Point(478, 498)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(201, 105)
			Me.Panel3.TabIndex = 5
			Me.Label74.AutoSize = True
			Me.Label74.Location = New Global.System.Drawing.Point(1, 44)
			Me.Label74.Name = "Label74"
			Me.Label74.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label74.TabIndex = 1737
			Me.Label74.Text = "Bank A/c No :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.Enabled = False
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(85, 41)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(113, 21)
			Me.cmbAccountNo.TabIndex = 1
			Me.ComboBox1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Cash", "Bank" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(85, 11)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(113, 21)
			Me.ComboBox1.TabIndex = 0
			Me.Label4.AutoSize = True
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.Location = New Global.System.Drawing.Point(2, 14)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(84, 13)
			Me.Label4.TabIndex = 87
			Me.Label4.Text = "Payment Mode :"
			Me.txtGrandTotal.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtGrandTotal.Location = New Global.System.Drawing.Point(85, 71)
			Me.txtGrandTotal.Name = "txtGrandTotal"
			Me.txtGrandTotal.[ReadOnly] = True
			Me.txtGrandTotal.Size = New Global.System.Drawing.Size(113, 20)
			Me.txtGrandTotal.TabIndex = 5
			Me.txtGrandTotal.TabStop = False
			Me.txtGrandTotal.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label31.AutoSize = True
			Me.Label31.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label31.Location = New Global.System.Drawing.Point(2, 74)
			Me.Label31.Name = "Label31"
			Me.Label31.Size = New Global.System.Drawing.Size(69, 13)
			Me.Label31.TabIndex = 84
			Me.Label31.Text = "Grand Total :"
			Me.GroupBox4.Controls.Add(Me.btnNext)
			Me.GroupBox4.Controls.Add(Me.btnFirst)
			Me.GroupBox4.Controls.Add(Me.txtPrev)
			Me.GroupBox4.Controls.Add(Me.btnLast)
			Me.GroupBox4.Controls.Add(Me.Label6)
			Me.GroupBox4.Controls.Add(Me.cmbtxtName)
			Me.GroupBox4.Controls.Add(Me.Label3)
			Me.GroupBox4.Controls.Add(Me.dtpDate)
			Me.GroupBox4.Controls.Add(Me.txtVoucherNo)
			Me.GroupBox4.Controls.Add(Me.Label2)
			Me.GroupBox4.Controls.Add(label)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(9, 44)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(549, 105)
			Me.GroupBox4.TabIndex = 0
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Voucher Information"
			Me.btnNext.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnNext.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnNext.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnNext.Image = CType(componentResourceManager.GetObject("btnNext.Image"), Global.System.Drawing.Image)
			Me.btnNext.Location = New Global.System.Drawing.Point(456, 11)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnNext.TabIndex = 1750
			Me.btnNext.TabStop = False
			Me.btnNext.UseVisualStyleBackColor = False
			Me.btnFirst.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnFirst.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnFirst.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnFirst.Image = CType(componentResourceManager.GetObject("btnFirst.Image"), Global.System.Drawing.Image)
			Me.btnFirst.Location = New Global.System.Drawing.Point(519, 11)
			Me.btnFirst.Name = "btnFirst"
			Me.btnFirst.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnFirst.TabIndex = 1753
			Me.btnFirst.TabStop = False
			Me.btnFirst.UseVisualStyleBackColor = False
			Me.txtPrev.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.txtPrev.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.txtPrev.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.txtPrev.Image = CType(componentResourceManager.GetObject("txtPrev.Image"), Global.System.Drawing.Image)
			Me.txtPrev.Location = New Global.System.Drawing.Point(488, 11)
			Me.txtPrev.Name = "txtPrev"
			Me.txtPrev.Size = New Global.System.Drawing.Size(26, 21)
			Me.txtPrev.TabIndex = 1751
			Me.txtPrev.TabStop = False
			Me.txtPrev.UseVisualStyleBackColor = False
			Me.btnLast.BackColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnLast.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnLast.ForeColor = Global.System.Drawing.Color.DodgerBlue
			Me.btnLast.Image = CType(componentResourceManager.GetObject("btnLast.Image"), Global.System.Drawing.Image)
			Me.btnLast.Location = New Global.System.Drawing.Point(423, 11)
			Me.btnLast.Name = "btnLast"
			Me.btnLast.Size = New Global.System.Drawing.Size(26, 21)
			Me.btnLast.TabIndex = 1752
			Me.btnLast.TabStop = False
			Me.btnLast.UseVisualStyleBackColor = False
			Me.Label6.AutoSize = True
			Me.Label6.ForeColor = Global.System.Drawing.Color.Red
			Me.Label6.Location = New Global.System.Drawing.Point(534, 82)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label6.TabIndex = 340
			Me.Label6.Text = "*"
			Me.cmbtxtName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbtxtName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbtxtName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbtxtName.FormattingEnabled = True
			Me.cmbtxtName.Location = New Global.System.Drawing.Point(121, 72)
			Me.cmbtxtName.Name = "cmbtxtName"
			Me.cmbtxtName.Size = New Global.System.Drawing.Size(411, 21)
			Me.cmbtxtName.TabIndex = 2
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(26, 72)
			Me.Label3.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label3.TabIndex = 336
			Me.Label3.Text = "Name :"
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(121, 48)
			Me.dtpDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(128, 20)
			Me.dtpDate.TabIndex = 1
			Me.txtVoucherNo.Location = New Global.System.Drawing.Point(121, 23)
			Me.txtVoucherNo.Name = "txtVoucherNo"
			Me.txtVoucherNo.[ReadOnly] = True
			Me.txtVoucherNo.Size = New Global.System.Drawing.Size(201, 20)
			Me.txtVoucherNo.TabIndex = 0
			Me.txtVoucherNo.TabStop = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(26, 48)
			Me.Label2.Margin = New Global.System.Windows.Forms.Padding(2, 0, 2, 0)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label2.TabIndex = 335
			Me.Label2.Text = "Date :"
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.GroupBox2.Controls.Add(Me.Label9)
			Me.GroupBox2.Controls.Add(Me.cmbParticulars)
			Me.GroupBox2.Controls.Add(Me.Label7)
			Me.GroupBox2.Controls.Add(Me.btnRemove)
			Me.GroupBox2.Controls.Add(Me.txtNotes)
			Me.GroupBox2.Controls.Add(Me.Label8)
			Me.GroupBox2.Controls.Add(Me.Label11)
			Me.GroupBox2.Controls.Add(Me.btnAdd)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.txtAmount)
			Me.GroupBox2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(9, 236)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(549, 150)
			Me.GroupBox2.TabIndex = 2
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Other Details"
			Me.Label9.AutoSize = True
			Me.Label9.ForeColor = Global.System.Drawing.Color.Red
			Me.Label9.Location = New Global.System.Drawing.Point(252, 59)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label9.TabIndex = 321
			Me.Label9.Text = "*"
			Me.cmbParticulars.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbParticulars.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbParticulars.FormattingEnabled = True
			Me.cmbParticulars.Location = New Global.System.Drawing.Point(121, 26)
			Me.cmbParticulars.Name = "cmbParticulars"
			Me.cmbParticulars.Size = New Global.System.Drawing.Size(411, 21)
			Me.cmbParticulars.TabIndex = 0
			Me.Label7.AutoSize = True
			Me.Label7.ForeColor = Global.System.Drawing.Color.Red
			Me.Label7.Location = New Global.System.Drawing.Point(535, 33)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(11, 13)
			Me.Label7.TabIndex = 320
			Me.Label7.Text = "*"
			Me.btnRemove.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnRemove.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnRemove.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnRemove.Enabled = False
			Me.btnRemove.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnRemove.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnRemove.ForeColor = Global.System.Drawing.Color.White
			Me.btnRemove.Image = CType(componentResourceManager.GetObject("btnRemove.Image"), Global.System.Drawing.Image)
			Me.btnRemove.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnRemove.Location = New Global.System.Drawing.Point(458, 87)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.Size = New Global.System.Drawing.Size(74, 54)
			Me.btnRemove.TabIndex = 4
			Me.btnRemove.Text = "Remove"
			Me.btnRemove.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.btnRemove.UseVisualStyleBackColor = False
			Me.txtNotes.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNotes.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtNotes.Location = New Global.System.Drawing.Point(121, 77)
			Me.txtNotes.Multiline = True
			Me.txtNotes.Name = "txtNotes"
			Me.txtNotes.[ReadOnly] = True
			Me.txtNotes.Size = New Global.System.Drawing.Size(238, 64)
			Me.txtNotes.TabIndex = 2
			Me.txtNotes.TabStop = False
			Me.Label8.AutoSize = True
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(22, 26)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(62, 13)
			Me.Label8.TabIndex = 95
			Me.Label8.Text = "Particulars :"
			Me.Label11.AutoSize = True
			Me.Label11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(22, 77)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label11.TabIndex = 89
			Me.Label11.Text = "Notes :"
			Me.btnAdd.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.btnAdd.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.btnAdd.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.btnAdd.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnAdd.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnAdd.ForeColor = Global.System.Drawing.Color.White
			Me.btnAdd.Image = CType(componentResourceManager.GetObject("btnAdd.Image"), Global.System.Drawing.Image)
			Me.btnAdd.ImageAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btnAdd.Location = New Global.System.Drawing.Point(380, 87)
			Me.btnAdd.Name = "btnAdd"
			Me.btnAdd.Size = New Global.System.Drawing.Size(74, 54)
			Me.btnAdd.TabIndex = 3
			Me.btnAdd.Text = "&Add To Grid"
			Me.btnAdd.TextAlign = Global.System.Drawing.ContentAlignment.BottomCenter
			Me.btnAdd.UseVisualStyleBackColor = False
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(22, 52)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label12.TabIndex = 87
			Me.Label12.Text = "Amount :"
			Me.txtAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAmount.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtAmount.Location = New Global.System.Drawing.Point(121, 52)
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.Size = New Global.System.Drawing.Size(128, 20)
			Me.txtAmount.TabIndex = 1
			Me.txtAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.btnGetData)
			Me.Panel4.Controls.Add(Me.btnPrint)
			Me.Panel4.Controls.Add(Me.btnUpdate)
			Me.Panel4.Controls.Add(Me.btnDelete)
			Me.Panel4.Controls.Add(Me.btnNew)
			Me.Panel4.Controls.Add(Me.btnSave)
			Me.Panel4.Location = New Global.System.Drawing.Point(571, 51)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(121, 289)
			Me.Panel4.TabIndex = 6
			Me.btnGetData.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnGetData.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnGetData.FlatAppearance.BorderSize = 0
			Me.btnGetData.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnGetData.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnGetData.ForeColor = Global.System.Drawing.Color.White
			Me.btnGetData.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnGetData.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnGetData.Image = CType(componentResourceManager.GetObject("btnGetData.Image"), Global.System.Drawing.Image)
			Me.btnGetData.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnGetData.Location = New Global.System.Drawing.Point(3, 191)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnGetData.TabIndex = 525
			Me.btnGetData.Text = "Get Data"
			Me.btnGetData.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnGetData.UseVisualStyleBackColor = False
			Me.btnPrint.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnPrint.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnPrint.FlatAppearance.BorderSize = 0
			Me.btnPrint.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnPrint.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnPrint.ForeColor = Global.System.Drawing.Color.White
			Me.btnPrint.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnPrint.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnPrint.Image = CType(componentResourceManager.GetObject("btnPrint.Image"), Global.System.Drawing.Image)
			Me.btnPrint.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnPrint.Location = New Global.System.Drawing.Point(3, 238)
			Me.btnPrint.Name = "btnPrint"
			Me.btnPrint.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnPrint.TabIndex = 524
			Me.btnPrint.Text = "Print"
			Me.btnPrint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnPrint.UseVisualStyleBackColor = False
			Me.btnUpdate.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnUpdate.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnUpdate.FlatAppearance.BorderSize = 0
			Me.btnUpdate.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnUpdate.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnUpdate.ForeColor = Global.System.Drawing.Color.White
			Me.btnUpdate.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnUpdate.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnUpdate.Image = CType(componentResourceManager.GetObject("btnUpdate.Image"), Global.System.Drawing.Image)
			Me.btnUpdate.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnUpdate.Location = New Global.System.Drawing.Point(3, 98)
			Me.btnUpdate.Name = "btnUpdate"
			Me.btnUpdate.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnUpdate.TabIndex = 523
			Me.btnUpdate.Text = "Update"
			Me.btnUpdate.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnUpdate.UseVisualStyleBackColor = False
			Me.btnDelete.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnDelete.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnDelete.FlatAppearance.BorderSize = 0
			Me.btnDelete.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnDelete.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnDelete.ForeColor = Global.System.Drawing.Color.White
			Me.btnDelete.GradientBottom = Global.System.Drawing.Color.Red
			Me.btnDelete.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.btnDelete.Image = CType(componentResourceManager.GetObject("btnDelete.Image"), Global.System.Drawing.Image)
			Me.btnDelete.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnDelete.Location = New Global.System.Drawing.Point(3, 145)
			Me.btnDelete.Name = "btnDelete"
			Me.btnDelete.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnDelete.TabIndex = 522
			Me.btnDelete.Text = "Delete"
			Me.btnDelete.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnDelete.UseVisualStyleBackColor = False
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
			Me.btnNew.Location = New Global.System.Drawing.Point(3, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnNew.TabIndex = 521
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.btnSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnSave.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnSave.FlatAppearance.BorderSize = 0
			Me.btnSave.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnSave.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnSave.ForeColor = Global.System.Drawing.Color.White
			Me.btnSave.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.btnSave.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.btnSave.Image = CType(componentResourceManager.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Me.btnSave.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnSave.Location = New Global.System.Drawing.Point(3, 50)
			Me.btnSave.Name = "btnSave"
			Me.btnSave.Size = New Global.System.Drawing.Size(112, 43)
			Me.btnSave.TabIndex = 520
			Me.btnSave.Text = "Save"
			Me.btnSave.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnSave.UseVisualStyleBackColor = False
			Me.Panel2.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Panel2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Panel2.Controls.Add(Me.Label1)
			Me.Panel2.Controls.Add(Me.lblCPhone)
			Me.Panel2.Controls.Add(Me.F2)
			Me.Panel2.Controls.Add(Me.F1)
			Me.Panel2.Controls.Add(Me.cmbNP)
			Me.Panel2.Controls.Add(Me.Button35)
			Me.Panel2.Controls.Add(Me.Button34)
			Me.Panel2.Controls.Add(Me.txtNP)
			Me.Panel2.Controls.Add(Me.txtSuffix)
			Me.Panel2.Controls.Add(Me.DTP2)
			Me.Panel2.Controls.Add(Me.DTP1)
			Me.Panel2.Controls.Add(Me.txtInvCode1)
			Me.Panel2.Controls.Add(Me.txtVoucherID)
			Me.Panel2.Controls.Add(Me.lblUser)
			Me.Panel2.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Panel2.Name = "Panel2"
			Me.Panel2.Size = New Global.System.Drawing.Size(708, 34)
			Me.Panel2.TabIndex = 0
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(228, 5)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(243, 24)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Expenses Voucher Entry"
			Me.lblCPhone.AutoSize = True
			Me.lblCPhone.Location = New Global.System.Drawing.Point(309, 25)
			Me.lblCPhone.Name = "lblCPhone"
			Me.lblCPhone.Size = New Global.System.Drawing.Size(55, 13)
			Me.lblCPhone.TabIndex = 1773
			Me.lblCPhone.Text = "lblCPhone"
			Me.lblCPhone.Visible = False
			Me.F2.Location = New Global.System.Drawing.Point(138, 9)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1767
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(103, 9)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1766
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.cmbNP.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbNP.FormattingEnabled = True
			Me.cmbNP.Location = New Global.System.Drawing.Point(3, 7)
			Me.cmbNP.Name = "cmbNP"
			Me.cmbNP.Size = New Global.System.Drawing.Size(49, 21)
			Me.cmbNP.TabIndex = 1762
			Me.cmbNP.TabStop = False
			Me.cmbNP.Visible = False
			Me.Button35.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button35.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button35.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button35.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button35.ForeColor = Global.System.Drawing.Color.White
			Me.Button35.Image = CType(componentResourceManager.GetObject("Button35.Image"), Global.System.Drawing.Image)
			Me.Button35.Location = New Global.System.Drawing.Point(642, 1)
			Me.Button35.Name = "Button35"
			Me.Button35.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button35.TabIndex = 1757
			Me.Button35.TabStop = False
			Me.Button35.UseVisualStyleBackColor = False
			Me.Button34.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button34.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button34.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button34.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button34.ForeColor = Global.System.Drawing.Color.White
			Me.Button34.Image = CType(componentResourceManager.GetObject("Button34.Image"), Global.System.Drawing.Image)
			Me.Button34.Location = New Global.System.Drawing.Point(676, 1)
			Me.Button34.Name = "Button34"
			Me.Button34.Size = New Global.System.Drawing.Size(31, 30)
			Me.Button34.TabIndex = 1756
			Me.Button34.TabStop = False
			Me.Button34.UseVisualStyleBackColor = False
			Me.txtNP.BackColor = Global.System.Drawing.SystemColors.Control
			Me.txtNP.Location = New Global.System.Drawing.Point(488, 11)
			Me.txtNP.Name = "txtNP"
			Me.txtNP.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.txtNP.Size = New Global.System.Drawing.Size(35, 20)
			Me.txtNP.TabIndex = 1728
			Me.txtNP.TabStop = False
			Me.txtNP.Visible = False
			Me.txtSuffix.Location = New Global.System.Drawing.Point(538, 9)
			Me.txtSuffix.Name = "txtSuffix"
			Me.txtSuffix.[ReadOnly] = True
			Me.txtSuffix.Size = New Global.System.Drawing.Size(33, 20)
			Me.txtSuffix.TabIndex = 430
			Me.txtSuffix.TabStop = False
			Me.txtSuffix.Visible = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(581, 35)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 429
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(467, 34)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 428
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.txtInvCode1.Location = New Global.System.Drawing.Point(21, 23)
			Me.txtInvCode1.Name = "txtInvCode1"
			Me.txtInvCode1.[ReadOnly] = True
			Me.txtInvCode1.Size = New Global.System.Drawing.Size(42, 20)
			Me.txtInvCode1.TabIndex = 420
			Me.txtInvCode1.TabStop = False
			Me.txtInvCode1.Visible = False
			Me.txtVoucherID.Location = New Global.System.Drawing.Point(68, 23)
			Me.txtVoucherID.Name = "txtVoucherID"
			Me.txtVoucherID.[ReadOnly] = True
			Me.txtVoucherID.Size = New Global.System.Drawing.Size(111, 20)
			Me.txtVoucherID.TabIndex = 4
			Me.txtVoucherID.TabStop = False
			Me.txtVoucherID.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(193, 18)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 5
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(708, 629)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmVoucher"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			Me.GroupBox4.ResumeLayout(False)
			Me.GroupBox4.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.Panel4.ResumeLayout(False)
			Me.Panel2.ResumeLayout(False)
			Me.Panel2.PerformLayout()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006BA3 RID: 27555
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
