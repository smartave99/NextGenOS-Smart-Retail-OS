Namespace BillPoint
	' Token: 0x02000205 RID: 517
		Public Partial Class frmRefundAmt
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060094FA RID: 38138 RVA: 0x006B5E38 File Offset: 0x006B4038
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

		' Token: 0x060094FB RID: 38139 RVA: 0x006B5E88 File Offset: 0x006B4088
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmRefundAmt))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label23 = New Global.System.Windows.Forms.Label()
			Me.Label22 = New Global.System.Windows.Forms.Label()
			Me.F2 = New Global.System.Windows.Forms.TextBox()
			Me.F1 = New Global.System.Windows.Forms.TextBox()
			Me.DTP2 = New Global.System.Windows.Forms.DateTimePicker()
			Me.DTP1 = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.DateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.DateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.ComboBox3 = New Global.System.Windows.Forms.ComboBox()
			Me.ComboBox2 = New Global.System.Windows.Forms.ComboBox()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.btnNew = New Global.GelButtons.GelButton()
			Me.Button3 = New Global.GelButtons.GelButton()
			Me.Button2 = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.Label24 = New Global.System.Windows.Forms.Label()
			Me.txtNote = New Global.System.Windows.Forms.TextBox()
			Me.LblBenName = New Global.System.Windows.Forms.Label()
			Me.cmbName = New Global.System.Windows.Forms.ComboBox()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label21 = New Global.System.Windows.Forms.Label()
			Me.ComboBox4 = New Global.System.Windows.Forms.ComboBox()
			Me.Label20 = New Global.System.Windows.Forms.Label()
			Me.cmbTransType = New Global.System.Windows.Forms.ComboBox()
			Me.cmbAmtType = New Global.System.Windows.Forms.ComboBox()
			Me.Label19 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.txtAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtName = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtContraID = New Global.System.Windows.Forms.TextBox()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Label25 = New Global.System.Windows.Forms.Label()
			Me.Label26 = New Global.System.Windows.Forms.Label()
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.Label26)
			Me.Panel1.Controls.Add(Me.Label25)
			Me.Panel1.Controls.Add(Me.Label23)
			Me.Panel1.Controls.Add(Me.Label22)
			Me.Panel1.Controls.Add(Me.F2)
			Me.Panel1.Controls.Add(Me.F1)
			Me.Panel1.Controls.Add(Me.DTP2)
			Me.Panel1.Controls.Add(Me.DTP1)
			Me.Panel1.Controls.Add(Me.Label10)
			Me.Panel1.Controls.Add(Me.Label11)
			Me.Panel1.Controls.Add(Me.GroupBox2)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.txtID)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.GroupBox1)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(987, 534)
			Me.Panel1.TabIndex = 1
			Me.Label23.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label23.AutoSize = True
			Me.Label23.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label23.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label23.ForeColor = Global.System.Drawing.Color.Red
			Me.Label23.Location = New Global.System.Drawing.Point(360, 513)
			Me.Label23.Name = "Label23"
			Me.Label23.Size = New Global.System.Drawing.Size(16, 15)
			Me.Label23.TabIndex = 1765
			Me.Label23.Text = "..."
			Me.Label22.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label22.AutoSize = True
			Me.Label22.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label22.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label22.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label22.Location = New Global.System.Drawing.Point(112, 512)
			Me.Label22.Name = "Label22"
			Me.Label22.Size = New Global.System.Drawing.Size(16, 15)
			Me.Label22.TabIndex = 1764
			Me.Label22.Text = "..."
			Me.F2.Location = New Global.System.Drawing.Point(659, 11)
			Me.F2.Name = "F2"
			Me.F2.[ReadOnly] = True
			Me.F2.Size = New Global.System.Drawing.Size(29, 20)
			Me.F2.TabIndex = 1763
			Me.F2.TabStop = False
			Me.F2.Visible = False
			Me.F1.Location = New Global.System.Drawing.Point(623, 11)
			Me.F1.Name = "F1"
			Me.F1.[ReadOnly] = True
			Me.F1.Size = New Global.System.Drawing.Size(33, 20)
			Me.F1.TabIndex = 1762
			Me.F1.TabStop = False
			Me.F1.Visible = False
			Me.DTP2.CustomFormat = "dd/MM/yyyy"
			Me.DTP2.Enabled = False
			Me.DTP2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP2.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP2.Location = New Global.System.Drawing.Point(780, 11)
			Me.DTP2.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP2.Name = "DTP2"
			Me.DTP2.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP2.TabIndex = 425
			Me.DTP2.TabStop = False
			Me.DTP2.Visible = False
			Me.DTP1.CustomFormat = "dd/MM/yyyy"
			Me.DTP1.Enabled = False
			Me.DTP1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DTP1.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DTP1.Location = New Global.System.Drawing.Point(690, 10)
			Me.DTP1.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.DTP1.Name = "DTP1"
			Me.DTP1.Size = New Global.System.Drawing.Size(87, 21)
			Me.DTP1.TabIndex = 424
			Me.DTP1.TabStop = False
			Me.DTP1.Visible = False
			Me.Label10.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label10.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label10.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(815, 513)
			Me.Label10.Name = "Label10"
			Me.Label10.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.Label10.Size = New Global.System.Drawing.Size(147, 15)
			Me.Label10.TabIndex = 49
			Me.Label10.Text = "0.00"
			Me.Label10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label11.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label11.AutoSize = True
			Me.Label11.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label11.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(739, 513)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(76, 15)
			Me.Label11.TabIndex = 48
			Me.Label11.Text = "Grand Total :"
			Me.GroupBox2.BackColor = Global.System.Drawing.Color.White
			Me.GroupBox2.Controls.Add(Me.Button5)
			Me.GroupBox2.Controls.Add(Me.DateTo)
			Me.GroupBox2.Controls.Add(Me.DateFrom)
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.Label13)
			Me.GroupBox2.Controls.Add(Me.ComboBox3)
			Me.GroupBox2.Controls.Add(Me.ComboBox2)
			Me.GroupBox2.Controls.Add(Me.ComboBox1)
			Me.GroupBox2.Controls.Add(Me.Label16)
			Me.GroupBox2.Controls.Add(Me.Label15)
			Me.GroupBox2.Controls.Add(Me.Label14)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(6, 151)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(957, 64)
			Me.GroupBox2.TabIndex = 47
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Search"
			Me.Button5.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(866, 22)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(82, 36)
			Me.Button5.TabIndex = 21
			Me.Button5.Text = "Search"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.DateTo.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.CustomFormat = "dd/MM/yyyy"
			Me.DateTo.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateTo.Location = New Global.System.Drawing.Point(741, 38)
			Me.DateTo.Name = "DateTo"
			Me.DateTo.Size = New Global.System.Drawing.Size(117, 20)
			Me.DateTo.TabIndex = 20
			Me.DateFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.CustomFormat = "dd/MM/yyyy"
			Me.DateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateFrom.Location = New Global.System.Drawing.Point(612, 38)
			Me.DateFrom.Name = "DateFrom"
			Me.DateFrom.Size = New Global.System.Drawing.Size(124, 20)
			Me.DateFrom.TabIndex = 19
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(609, 20)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label12.TabIndex = 47
			Me.Label12.Text = "From :"
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(738, 20)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label13.TabIndex = 48
			Me.Label13.Text = "To :"
			Me.ComboBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox3.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Location = New Global.System.Drawing.Point(210, 38)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(180, 21)
			Me.ComboBox3.TabIndex = 17
			Me.ComboBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Location = New Global.System.Drawing.Point(419, 38)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(170, 21)
			Me.ComboBox2.TabIndex = 18
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Customer", "Supplier" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(6, 38)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(180, 21)
			Me.ComboBox1.TabIndex = 16
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label16.Location = New Global.System.Drawing.Point(416, 20)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(122, 13)
			Me.Label16.TabIndex = 15
			Me.Label16.Text = "Search By Voucher No :"
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label15.Location = New Global.System.Drawing.Point(207, 20)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(132, 13)
			Me.Label15.TabIndex = 14
			Me.Label15.Text = "Search By (Cust/Supl) ID :"
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label14.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(185, 13)
			Me.Label14.TabIndex = 13
			Me.Label14.Text = "Search By (Customer/Supplier) Type :"
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
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11 })
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
			Me.dgw.Location = New Global.System.Drawing.Point(6, 216)
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
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 50
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(973, 292)
			Me.dgw.TabIndex = 21
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle6.Format = "d"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "Date"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Voucher No"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Customer/Supplier"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "Name"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "(Cust/Supl) ID"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column7.HeaderText = "Amount"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "Payment/Receive"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column9.HeaderText = "Amount Type"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Bank A/c No"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Note"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Visible = False
			Me.lblUser.AutoSize = True
			Me.lblUser.Location = New Global.System.Drawing.Point(53, 15)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 6
			Me.lblUser.Text = "lblUser"
			Me.lblUser.Visible = False
			Me.txtID.Location = New Global.System.Drawing.Point(11, 15)
			Me.txtID.Name = "txtID"
			Me.txtID.[ReadOnly] = True
			Me.txtID.Size = New Global.System.Drawing.Size(36, 20)
			Me.txtID.TabIndex = 4
			Me.txtID.TabStop = False
			Me.txtID.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(987, 34)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Journal Voucher Entry"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox1.Controls.Add(Me.Panel5)
			Me.GroupBox1.Controls.Add(Me.Label24)
			Me.GroupBox1.Controls.Add(Me.txtNote)
			Me.GroupBox1.Controls.Add(Me.LblBenName)
			Me.GroupBox1.Controls.Add(Me.cmbName)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.Label21)
			Me.GroupBox1.Controls.Add(Me.ComboBox4)
			Me.GroupBox1.Controls.Add(Me.Label20)
			Me.GroupBox1.Controls.Add(Me.cmbTransType)
			Me.GroupBox1.Controls.Add(Me.cmbAmtType)
			Me.GroupBox1.Controls.Add(Me.Label19)
			Me.GroupBox1.Controls.Add(Me.Label17)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.Label18)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.txtAmount)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.txtName)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtContraID)
			Me.GroupBox1.Controls.Add(Me.dtpDate)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 36)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(973, 114)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Controls.Add(Me.btnNew)
			Me.Panel5.Controls.Add(Me.Button3)
			Me.Panel5.Controls.Add(Me.Button2)
			Me.Panel5.Controls.Add(Me.Button1)
			Me.Panel5.Location = New Global.System.Drawing.Point(509, 62)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(459, 47)
			Me.Panel5.TabIndex = 7
			Me.btnExportExcel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.btnExportExcel.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.btnExportExcel.FlatAppearance.BorderSize = 0
			Me.btnExportExcel.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnExportExcel.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btnExportExcel.ForeColor = Global.System.Drawing.Color.White
			Me.btnExportExcel.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.btnExportExcel.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.btnExportExcel.Image = CType(componentResourceManager.GetObject("btnExportExcel.Image"), Global.System.Drawing.Image)
			Me.btnExportExcel.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(371, 4)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(86, 43)
			Me.btnExportExcel.TabIndex = 525
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
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
			Me.btnNew.Location = New Global.System.Drawing.Point(4, 3)
			Me.btnNew.Name = "btnNew"
			Me.btnNew.Size = New Global.System.Drawing.Size(86, 43)
			Me.btnNew.TabIndex = 521
			Me.btnNew.Text = "New"
			Me.btnNew.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnNew.UseVisualStyleBackColor = False
			Me.Button3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button3.FlatAppearance.BorderSize = 0
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(96, 4)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(86, 43)
			Me.Button3.TabIndex = 523
			Me.Button3.Text = "Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button2.FlatAppearance.BorderSize = 0
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.Button2.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(280, 4)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(86, 43)
			Me.Button2.TabIndex = 520
			Me.Button2.Text = "Save"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button1.FlatAppearance.BorderSize = 0
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.GradientBottom = Global.System.Drawing.Color.Red
			Me.Button1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.Button1.Image = CType(componentResourceManager.GetObject("Button1.Image"), Global.System.Drawing.Image)
			Me.Button1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button1.Location = New Global.System.Drawing.Point(188, 4)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(86, 43)
			Me.Button1.TabIndex = 522
			Me.Button1.Text = "Delete"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
			Me.Label24.AutoSize = True
			Me.Label24.Location = New Global.System.Drawing.Point(254, 59)
			Me.Label24.Name = "Label24"
			Me.Label24.Size = New Global.System.Drawing.Size(70, 13)
			Me.Label24.TabIndex = 26
			Me.Label24.Text = "Note (if any) :"
			Me.txtNote.BackColor = Global.System.Drawing.Color.FromArgb(64, 64, 64)
			Me.txtNote.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtNote.ForeColor = Global.System.Drawing.Color.White
			Me.txtNote.Location = New Global.System.Drawing.Point(257, 74)
			Me.txtNote.Multiline = True
			Me.txtNote.Name = "txtNote"
			Me.txtNote.ScrollBars = Global.System.Windows.Forms.ScrollBars.Both
			Me.txtNote.Size = New Global.System.Drawing.Size(230, 35)
			Me.txtNote.TabIndex = 25
			Me.txtNote.TabStop = False
			Me.LblBenName.AutoSize = True
			Me.LblBenName.Location = New Global.System.Drawing.Point(354, 74)
			Me.LblBenName.Name = "LblBenName"
			Me.LblBenName.Size = New Global.System.Drawing.Size(16, 13)
			Me.LblBenName.TabIndex = 24
			Me.LblBenName.Text = "..."
			Me.LblBenName.Visible = False
			Me.cmbName.AutoCompleteMode = Global.System.Windows.Forms.AutoCompleteMode.SuggestAppend
			Me.cmbName.AutoCompleteSource = Global.System.Windows.Forms.AutoCompleteSource.ListItems
			Me.cmbName.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbName.FormattingEnabled = True
			Me.cmbName.Location = New Global.System.Drawing.Point(353, 29)
			Me.cmbName.Name = "cmbName"
			Me.cmbName.Size = New Global.System.Drawing.Size(134, 21)
			Me.cmbName.TabIndex = 2
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(597, 12)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(49, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Amount :"
			Me.Label21.AutoSize = True
			Me.Label21.Location = New Global.System.Drawing.Point(672, 12)
			Me.Label21.Name = "Label21"
			Me.Label21.Size = New Global.System.Drawing.Size(99, 13)
			Me.Label21.TabIndex = 23
			Me.Label21.Text = "Payment/Receive :"
			Me.ComboBox4.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox4.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox4.FormattingEnabled = True
			Me.ComboBox4.Items.AddRange(New Object() { "Payment", "Receive" })
			Me.ComboBox4.Location = New Global.System.Drawing.Point(675, 28)
			Me.ComboBox4.Name = "ComboBox4"
			Me.ComboBox4.Size = New Global.System.Drawing.Size(96, 21)
			Me.ComboBox4.TabIndex = 4
			Me.Label20.AutoSize = True
			Me.Label20.Location = New Global.System.Drawing.Point(844, 12)
			Me.Label20.Name = "Label20"
			Me.Label20.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label20.TabIndex = 21
			Me.Label20.Text = "Bank A/c No :"
			Me.cmbTransType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbTransType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbTransType.FormattingEnabled = True
			Me.cmbTransType.Items.AddRange(New Object() { "Customer", "Supplier" })
			Me.cmbTransType.Location = New Global.System.Drawing.Point(245, 29)
			Me.cmbTransType.Name = "cmbTransType"
			Me.cmbTransType.Size = New Global.System.Drawing.Size(106, 21)
			Me.cmbTransType.TabIndex = 1
			Me.cmbAmtType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAmtType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAmtType.FormattingEnabled = True
			Me.cmbAmtType.Items.AddRange(New Object() { "Cash", "Bank" })
			Me.cmbAmtType.Location = New Global.System.Drawing.Point(773, 28)
			Me.cmbAmtType.Name = "cmbAmtType"
			Me.cmbAmtType.Size = New Global.System.Drawing.Size(73, 21)
			Me.cmbAmtType.TabIndex = 5
			Me.Label19.AutoSize = True
			Me.Label19.Location = New Global.System.Drawing.Point(770, 12)
			Me.Label19.Name = "Label19"
			Me.Label19.Size = New Global.System.Drawing.Size(76, 13)
			Me.Label19.TabIndex = 18
			Me.Label19.Text = "Amount Type :"
			Me.Label17.AutoSize = True
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label17.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(93, 90)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(31, 15)
			Me.Label17.TabIndex = 16
			Me.Label17.Text = "0.00"
			Me.Label9.AutoSize = True
			Me.Label9.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label9.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(93, 72)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(31, 15)
			Me.Label9.TabIndex = 15
			Me.Label9.Text = "0.00"
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label18.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(2, 90)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label18.TabIndex = 17
			Me.Label18.Text = "Bank Balance :"
			Me.Label8.AutoSize = True
			Me.Label8.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label8.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(2, 72)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "Cash-In-Hand :"
			Me.txtAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAmount.Location = New Global.System.Drawing.Point(600, 29)
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.Size = New Global.System.Drawing.Size(74, 20)
			Me.txtAmount.TabIndex = 3
			Me.txtAmount.Text = "0.00"
			Me.txtAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(485, 12)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(80, 13)
			Me.Label6.TabIndex = 11
			Me.Label6.Text = "(Cust/Supl) ID :"
			Me.txtName.Location = New Global.System.Drawing.Point(488, 29)
			Me.txtName.Name = "txtName"
			Me.txtName.[ReadOnly] = True
			Me.txtName.Size = New Global.System.Drawing.Size(111, 20)
			Me.txtName.TabIndex = 10
			Me.txtName.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(350, 12)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(41, 13)
			Me.Label5.TabIndex = 9
			Me.Label5.Text = "Name :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.Enabled = False
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Items.AddRange(New Object() { "Cash-In-Hand to Bank Account", "Bank Account to Cash-In-Hand" })
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(847, 28)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(107, 21)
			Me.cmbAccountNo.TabIndex = 6
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(242, 12)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(100, 13)
			Me.Label4.TabIndex = 7
			Me.Label4.Text = "Customer/Supplier :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(104, 12)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(73, 13)
			Me.Label3.TabIndex = 6
			Me.Label3.Text = "Voucher No. :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(2, 12)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Date :"
			Me.txtContraID.Location = New Global.System.Drawing.Point(107, 29)
			Me.txtContraID.Name = "txtContraID"
			Me.txtContraID.[ReadOnly] = True
			Me.txtContraID.Size = New Global.System.Drawing.Size(137, 20)
			Me.txtContraID.TabIndex = 4
			Me.txtContraID.TabStop = False
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(5, 29)
			Me.dtpDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(101, 20)
			Me.dtpDate.TabIndex = 0
			Me.Label25.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label25.AutoSize = True
			Me.Label25.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label25.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label25.ForeColor = Global.System.Drawing.Color.Blue
			Me.Label25.Location = New Global.System.Drawing.Point(15, 513)
			Me.Label25.Name = "Label25"
			Me.Label25.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label25.TabIndex = 1766
			Me.Label25.Text = "Total Receive : "
			Me.Label26.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left
			Me.Label26.AutoSize = True
			Me.Label26.BackColor = Global.System.Drawing.Color.Transparent
			Me.Label26.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label26.ForeColor = Global.System.Drawing.Color.Red
			Me.Label26.Location = New Global.System.Drawing.Point(259, 512)
			Me.Label26.Name = "Label26"
			Me.Label26.Size = New Global.System.Drawing.Size(93, 15)
			Me.Label26.TabIndex = 1767
			Me.Label26.Text = "Total Payment : "
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(987, 534)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmRefundAmt"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox1.ResumeLayout(False)
			Me.GroupBox1.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040041F6 RID: 16886
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
