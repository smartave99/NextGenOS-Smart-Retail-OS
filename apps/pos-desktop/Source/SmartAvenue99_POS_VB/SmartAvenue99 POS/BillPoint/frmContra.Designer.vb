Namespace BillPoint
	' Token: 0x020000D1 RID: 209
		Public Partial Class frmContra
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060024F5 RID: 9461 RVA: 0x00176858 File Offset: 0x00174A58
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

		' Token: 0x060024F6 RID: 9462 RVA: 0x001768A8 File Offset: 0x00174AA8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmContra))
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
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
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.txtID = New Global.System.Windows.Forms.TextBox()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.btnExportExcel = New Global.GelButtons.GelButton()
			Me.Button4 = New Global.GelButtons.GelButton()
			Me.Button2 = New Global.GelButtons.GelButton()
			Me.Button1 = New Global.GelButtons.GelButton()
			Me.Button3 = New Global.GelButtons.GelButton()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.txtAmount = New Global.System.Windows.Forms.TextBox()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtName = New Global.System.Windows.Forms.TextBox()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.cmbAccountNo = New Global.System.Windows.Forms.ComboBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.txtContraID = New Global.System.Windows.Forms.TextBox()
			Me.cmbTransType = New Global.System.Windows.Forms.ComboBox()
			Me.dtpDate = New Global.System.Windows.Forms.DateTimePicker()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Panel1.SuspendLayout()
			Me.GroupBox2.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
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
			Me.Panel1.Size = New Global.System.Drawing.Size(901, 534)
			Me.Panel1.TabIndex = 0
			Me.Label10.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label10.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label10.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.Location = New Global.System.Drawing.Point(742, 513)
			Me.Label10.Name = "Label10"
			Me.Label10.RightToLeft = Global.System.Windows.Forms.RightToLeft.Yes
			Me.Label10.Size = New Global.System.Drawing.Size(147, 15)
			Me.Label10.TabIndex = 49
			Me.Label10.Text = "0.00"
			Me.Label10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label11.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label11.AutoSize = True
			Me.Label11.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label11.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.Location = New Global.System.Drawing.Point(666, 513)
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
			Me.GroupBox2.Size = New Global.System.Drawing.Size(871, 64)
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
			Me.Button5.Location = New Global.System.Drawing.Point(784, 22)
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
			Me.DateTo.Location = New Global.System.Drawing.Point(659, 38)
			Me.DateTo.Name = "DateTo"
			Me.DateTo.Size = New Global.System.Drawing.Size(117, 20)
			Me.DateTo.TabIndex = 20
			Me.DateFrom.CalendarFont = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.CustomFormat = "dd/MM/yyyy"
			Me.DateFrom.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.DateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.DateFrom.Location = New Global.System.Drawing.Point(530, 38)
			Me.DateFrom.Name = "DateFrom"
			Me.DateFrom.Size = New Global.System.Drawing.Size(124, 20)
			Me.DateFrom.TabIndex = 19
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.Location = New Global.System.Drawing.Point(527, 20)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label12.TabIndex = 47
			Me.Label12.Text = "From :"
			Me.Label13.AutoSize = True
			Me.Label13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.Location = New Global.System.Drawing.Point(656, 20)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label13.TabIndex = 48
			Me.Label13.Text = "To :"
			Me.ComboBox3.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox3.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox3.FormattingEnabled = True
			Me.ComboBox3.Location = New Global.System.Drawing.Point(181, 38)
			Me.ComboBox3.Name = "ComboBox3"
			Me.ComboBox3.Size = New Global.System.Drawing.Size(170, 21)
			Me.ComboBox3.TabIndex = 17
			Me.ComboBox2.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox2.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox2.FormattingEnabled = True
			Me.ComboBox2.Location = New Global.System.Drawing.Point(357, 38)
			Me.ComboBox2.Name = "ComboBox2"
			Me.ComboBox2.Size = New Global.System.Drawing.Size(170, 21)
			Me.ComboBox2.TabIndex = 18
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Cash-In-Hand to Bank Account", "Bank Account to Cash-In-Hand" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(6, 38)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(170, 21)
			Me.ComboBox1.TabIndex = 16
			Me.Label16.AutoSize = True
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label16.Location = New Global.System.Drawing.Point(354, 20)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(156, 13)
			Me.Label16.TabIndex = 15
			Me.Label16.Text = "Search By Contra Voucher No :"
			Me.Label15.AutoSize = True
			Me.Label15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label15.Location = New Global.System.Drawing.Point(178, 20)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(150, 13)
			Me.Label15.TabIndex = 14
			Me.Label15.Text = "Search By Bank Account No :"
			Me.Label14.AutoSize = True
			Me.Label14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F)
			Me.Label14.Location = New Global.System.Drawing.Point(3, 20)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(148, 13)
			Me.Label14.TabIndex = 13
			Me.Label14.Text = "Search By Transaction Type :"
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
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7 })
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
			Me.dgw.Size = New Global.System.Drawing.Size(871, 292)
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
			Me.Column3.HeaderText = "Contra Voucher No"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column4.HeaderText = "Type of Transaction"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column5.HeaderText = "Bank A/c No"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column6.HeaderText = "Beneficiary Name"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column7.HeaderText = "Amount"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
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
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(901, 34)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Contra Voucher Entry"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox1.Controls.Add(Me.Label18)
			Me.GroupBox1.Controls.Add(Me.Label17)
			Me.GroupBox1.Controls.Add(Me.Label9)
			Me.GroupBox1.Controls.Add(Me.Panel5)
			Me.GroupBox1.Controls.Add(Me.Label8)
			Me.GroupBox1.Controls.Add(Me.Label7)
			Me.GroupBox1.Controls.Add(Me.txtAmount)
			Me.GroupBox1.Controls.Add(Me.Label6)
			Me.GroupBox1.Controls.Add(Me.txtName)
			Me.GroupBox1.Controls.Add(Me.Label5)
			Me.GroupBox1.Controls.Add(Me.cmbAccountNo)
			Me.GroupBox1.Controls.Add(Me.Label4)
			Me.GroupBox1.Controls.Add(Me.Label3)
			Me.GroupBox1.Controls.Add(Me.Label2)
			Me.GroupBox1.Controls.Add(Me.txtContraID)
			Me.GroupBox1.Controls.Add(Me.cmbTransType)
			Me.GroupBox1.Controls.Add(Me.dtpDate)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 36)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(871, 114)
			Me.GroupBox1.TabIndex = 0
			Me.GroupBox1.TabStop = False
			Me.Label18.AutoSize = True
			Me.Label18.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label18.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.Location = New Global.System.Drawing.Point(2, 94)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(89, 15)
			Me.Label18.TabIndex = 17
			Me.Label18.Text = "Bank Balance :"
			Me.Label17.AutoSize = True
			Me.Label17.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label17.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.Location = New Global.System.Drawing.Point(92, 94)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(31, 15)
			Me.Label17.TabIndex = 16
			Me.Label17.Text = "0.00"
			Me.Label9.AutoSize = True
			Me.Label9.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label9.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.Location = New Global.System.Drawing.Point(92, 76)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(31, 15)
			Me.Label9.TabIndex = 15
			Me.Label9.Text = "0.00"
			Me.Panel5.Controls.Add(Me.btnExportExcel)
			Me.Panel5.Controls.Add(Me.Button4)
			Me.Panel5.Controls.Add(Me.Button2)
			Me.Panel5.Controls.Add(Me.Button1)
			Me.Panel5.Controls.Add(Me.Button3)
			Me.Panel5.Location = New Global.System.Drawing.Point(382, 62)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(483, 47)
			Me.Panel5.TabIndex = 4
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
			Me.btnExportExcel.Location = New Global.System.Drawing.Point(369, 0)
			Me.btnExportExcel.Name = "btnExportExcel"
			Me.btnExportExcel.Size = New Global.System.Drawing.Size(85, 43)
			Me.btnExportExcel.TabIndex = 525
			Me.btnExportExcel.Text = "&Export Excel"
			Me.btnExportExcel.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.btnExportExcel.UseVisualStyleBackColor = False
			Me.Button4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Button4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.Button4.FlatAppearance.BorderSize = 0
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.GradientBottom = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.GradientTop = Global.System.Drawing.Color.RoyalBlue
			Me.Button4.Image = CType(componentResourceManager.GetObject("Button4.Image"), Global.System.Drawing.Image)
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(5, 0)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(85, 43)
			Me.Button4.TabIndex = 521
			Me.Button4.Text = "New"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
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
			Me.Button2.Location = New Global.System.Drawing.Point(96, 0)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(85, 43)
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
			Me.Button1.Location = New Global.System.Drawing.Point(278, 0)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(85, 43)
			Me.Button1.TabIndex = 522
			Me.Button1.Text = "Delete"
			Me.Button1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button1.UseVisualStyleBackColor = False
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
			Me.Button3.Location = New Global.System.Drawing.Point(187, 0)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(85, 43)
			Me.Button3.TabIndex = 523
			Me.Button3.Text = "Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Label8.AutoSize = True
			Me.Label8.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.Label8.Font = New Global.System.Drawing.Font("Arial", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.Location = New Global.System.Drawing.Point(2, 76)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(91, 15)
			Me.Label8.TabIndex = 14
			Me.Label8.Text = "Cash-in-Hand :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(749, 19)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label7.TabIndex = 13
			Me.Label7.Text = "Transaction Amount :"
			Me.txtAmount.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtAmount.Location = New Global.System.Drawing.Point(752, 36)
			Me.txtAmount.Name = "txtAmount"
			Me.txtAmount.Size = New Global.System.Drawing.Size(113, 20)
			Me.txtAmount.TabIndex = 3
			Me.txtAmount.Text = "0.00"
			Me.txtAmount.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(574, 19)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(96, 13)
			Me.Label6.TabIndex = 11
			Me.Label6.Text = "Beneficiary Name :"
			Me.txtName.Location = New Global.System.Drawing.Point(577, 36)
			Me.txtName.Name = "txtName"
			Me.txtName.[ReadOnly] = True
			Me.txtName.Size = New Global.System.Drawing.Size(169, 20)
			Me.txtName.TabIndex = 10
			Me.txtName.TabStop = False
			Me.Label5.AutoSize = True
			Me.Label5.Location = New Global.System.Drawing.Point(437, 19)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(101, 13)
			Me.Label5.TabIndex = 9
			Me.Label5.Text = "Bank Account No. :"
			Me.cmbAccountNo.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbAccountNo.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbAccountNo.FormattingEnabled = True
			Me.cmbAccountNo.Items.AddRange(New Object() { "Cash-In-Hand to Bank Account", "Bank Account to Cash-In-Hand" })
			Me.cmbAccountNo.Location = New Global.System.Drawing.Point(440, 36)
			Me.cmbAccountNo.Name = "cmbAccountNo"
			Me.cmbAccountNo.Size = New Global.System.Drawing.Size(131, 21)
			Me.cmbAccountNo.TabIndex = 2
			Me.Label4.AutoSize = True
			Me.Label4.Location = New Global.System.Drawing.Point(220, 19)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(108, 13)
			Me.Label4.TabIndex = 7
			Me.Label4.Text = "Type of Transaction :"
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(109, 19)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(107, 13)
			Me.Label3.TabIndex = 6
			Me.Label3.Text = "Contra Voucher No. :"
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(2, 19)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(36, 13)
			Me.Label2.TabIndex = 5
			Me.Label2.Text = "Date :"
			Me.txtContraID.Location = New Global.System.Drawing.Point(112, 36)
			Me.txtContraID.Name = "txtContraID"
			Me.txtContraID.[ReadOnly] = True
			Me.txtContraID.Size = New Global.System.Drawing.Size(104, 20)
			Me.txtContraID.TabIndex = 4
			Me.txtContraID.TabStop = False
			Me.cmbTransType.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.cmbTransType.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbTransType.FormattingEnabled = True
			Me.cmbTransType.Items.AddRange(New Object() { "Cash-In-Hand to Bank Account", "Bank Account to Cash-In-Hand" })
			Me.cmbTransType.Location = New Global.System.Drawing.Point(223, 36)
			Me.cmbTransType.Name = "cmbTransType"
			Me.cmbTransType.Size = New Global.System.Drawing.Size(211, 21)
			Me.cmbTransType.TabIndex = 1
			Me.dtpDate.CustomFormat = "dd/MM/yyyy"
			Me.dtpDate.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDate.Location = New Global.System.Drawing.Point(5, 36)
			Me.dtpDate.Margin = New Global.System.Windows.Forms.Padding(2)
			Me.dtpDate.Name = "dtpDate"
			Me.dtpDate.Size = New Global.System.Drawing.Size(101, 20)
			Me.dtpDate.TabIndex = 0
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(901, 534)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmContra"
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

		' Token: 0x04000F10 RID: 3856
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
