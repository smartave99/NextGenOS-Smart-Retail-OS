Namespace BillPoint
	' Token: 0x020004E5 RID: 1253
		Public Partial Class frmTCSValidation
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600FFD6 RID: 65494 RVA: 0x0098B114 File Offset: 0x00989314
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

		' Token: 0x0600FFD7 RID: 65495 RVA: 0x0098B164 File Offset: 0x00989364
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmTCSValidation))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.lblUser = New Global.System.Windows.Forms.Label()
			Me.Panel5 = New Global.System.Windows.Forms.Panel()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.Button4 = New Global.System.Windows.Forms.Button()
			Me.Button5 = New Global.System.Windows.Forms.Button()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.txtwithoutpan = New Global.System.Windows.Forms.TextBox()
			Me.txtwithpan = New Global.System.Windows.Forms.TextBox()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.dtpDateTo = New Global.System.Windows.Forms.DateTimePicker()
			Me.dtpDateFrom = New Global.System.Windows.Forms.DateTimePicker()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.txtlimit = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.ComboBox1 = New Global.System.Windows.Forms.ComboBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.ErrorProvider1 = New Global.System.Windows.Forms.ErrorProvider(Me.components)
			Me.Panel1.SuspendLayout()
			Me.Panel5.SuspendLayout()
			Me.Panel4.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.lblUser)
			Me.Panel1.Controls.Add(Me.Panel5)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Location = New Global.System.Drawing.Point(12, 12)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(551, 299)
			Me.Panel1.TabIndex = 1
			Me.lblUser.AutoSize = True
			Me.lblUser.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblUser.Location = New Global.System.Drawing.Point(23, 14)
			Me.lblUser.Name = "lblUser"
			Me.lblUser.Size = New Global.System.Drawing.Size(39, 13)
			Me.lblUser.TabIndex = 149
			Me.lblUser.Text = "Label8"
			Me.lblUser.Visible = False
			Me.Panel5.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel5.Controls.Add(Me.Button2)
			Me.Panel5.Controls.Add(Me.Button3)
			Me.Panel5.Controls.Add(Me.Button4)
			Me.Panel5.Controls.Add(Me.Button5)
			Me.Panel5.Location = New Global.System.Drawing.Point(437, 60)
			Me.Panel5.Name = "Panel5"
			Me.Panel5.Size = New Global.System.Drawing.Size(105, 169)
			Me.Panel5.TabIndex = 5
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.Enabled = False
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Image = CType(componentResourceManager.GetObject("Button2.Image"), Global.System.Drawing.Image)
			Me.Button2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button2.Location = New Global.System.Drawing.Point(6, 124)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button2.TabIndex = 5
			Me.Button2.Text = "&Delete"
			Me.Button2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button2.UseVisualStyleBackColor = False
			Me.Button3.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button3.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.Enabled = False
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.ForeColor = Global.System.Drawing.Color.White
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button3.Location = New Global.System.Drawing.Point(6, 85)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button3.TabIndex = 4
			Me.Button3.Text = "&Update"
			Me.Button3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button4.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button4.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button4.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button4.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button4.ForeColor = Global.System.Drawing.Color.White
			Me.Button4.Image = Global.BillPoint.My.Resources.Resources.Save_32x32
			Me.Button4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button4.Location = New Global.System.Drawing.Point(6, 46)
			Me.Button4.Name = "Button4"
			Me.Button4.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button4.TabIndex = 3
			Me.Button4.Text = "&Save"
			Me.Button4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button4.UseVisualStyleBackColor = False
			Me.Button5.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button5.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button5.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button5.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button5.Font = New Global.System.Drawing.Font("Arial", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button5.ForeColor = Global.System.Drawing.Color.White
			Me.Button5.Image = CType(componentResourceManager.GetObject("Button5.Image"), Global.System.Drawing.Image)
			Me.Button5.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Button5.Location = New Global.System.Drawing.Point(6, 7)
			Me.Button5.Name = "Button5"
			Me.Button5.Size = New Global.System.Drawing.Size(91, 35)
			Me.Button5.TabIndex = 2
			Me.Button5.Text = "&New"
			Me.Button5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Button5.UseVisualStyleBackColor = False
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(5, 4)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(537, 31)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "TCS Validation"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.Label11)
			Me.Panel4.Controls.Add(Me.Label10)
			Me.Panel4.Controls.Add(Me.Label9)
			Me.Panel4.Controls.Add(Me.txtwithoutpan)
			Me.Panel4.Controls.Add(Me.txtwithpan)
			Me.Panel4.Controls.Add(Me.Label8)
			Me.Panel4.Controls.Add(Me.Label7)
			Me.Panel4.Controls.Add(Me.dtpDateTo)
			Me.Panel4.Controls.Add(Me.dtpDateFrom)
			Me.Panel4.Controls.Add(Me.Label6)
			Me.Panel4.Controls.Add(Me.txtlimit)
			Me.Panel4.Controls.Add(Me.Label3)
			Me.Panel4.Controls.Add(Me.ComboBox1)
			Me.Panel4.Controls.Add(Me.TextBox2)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Panel4.Location = New Global.System.Drawing.Point(5, 60)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(433, 169)
			Me.Panel4.TabIndex = 1
			Me.Label11.AutoSize = True
			Me.Label11.Location = New Global.System.Drawing.Point(17, 136)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(54, 15)
			Me.Label11.TabIndex = 432
			Me.Label11.Text = "Activate :"
			Me.Label10.AutoSize = True
			Me.Label10.Location = New Global.System.Drawing.Point(281, 109)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(18, 15)
			Me.Label10.TabIndex = 431
			Me.Label10.Text = "%"
			Me.Label9.AutoSize = True
			Me.Label9.Location = New Global.System.Drawing.Point(281, 82)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(18, 15)
			Me.Label9.TabIndex = 430
			Me.Label9.Text = "%"
			Me.txtwithoutpan.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtwithoutpan.Location = New Global.System.Drawing.Point(198, 107)
			Me.txtwithoutpan.Name = "txtwithoutpan"
			Me.txtwithoutpan.Size = New Global.System.Drawing.Size(67, 21)
			Me.txtwithoutpan.TabIndex = 4
			Me.txtwithoutpan.Text = "0.000"
			Me.txtwithoutpan.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.txtwithpan.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtwithpan.Location = New Global.System.Drawing.Point(198, 77)
			Me.txtwithpan.Name = "txtwithpan"
			Me.txtwithpan.Size = New Global.System.Drawing.Size(67, 21)
			Me.txtwithpan.TabIndex = 3
			Me.txtwithpan.Text = "0.000"
			Me.txtwithpan.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label8.AutoSize = True
			Me.Label8.Location = New Global.System.Drawing.Point(17, 107)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(163, 15)
			Me.Label8.TabIndex = 427
			Me.Label8.Text = "Tax % Applied without PAN  :"
			Me.Label7.AutoSize = True
			Me.Label7.Location = New Global.System.Drawing.Point(17, 77)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(146, 15)
			Me.Label7.TabIndex = 426
			Me.Label7.Text = "Tax % Applied with PAN  :"
			Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateTo.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateTo.Location = New Global.System.Drawing.Point(280, 10)
			Me.dtpDateTo.Name = "dtpDateTo"
			Me.dtpDateTo.Size = New Global.System.Drawing.Size(119, 21)
			Me.dtpDateTo.TabIndex = 1
			Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
			Me.dtpDateFrom.Format = Global.System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpDateFrom.Location = New Global.System.Drawing.Point(104, 10)
			Me.dtpDateFrom.Name = "dtpDateFrom"
			Me.dtpDateFrom.Size = New Global.System.Drawing.Size(119, 21)
			Me.dtpDateFrom.TabIndex = 0
			Me.Label6.AutoSize = True
			Me.Label6.Location = New Global.System.Drawing.Point(238, 10)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(27, 15)
			Me.Label6.TabIndex = 408
			Me.Label6.Text = "To :"
			Me.txtlimit.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.txtlimit.Location = New Global.System.Drawing.Point(198, 44)
			Me.txtlimit.Name = "txtlimit"
			Me.txtlimit.Size = New Global.System.Drawing.Size(101, 21)
			Me.txtlimit.TabIndex = 2
			Me.txtlimit.Text = "0.00"
			Me.txtlimit.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Right
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(17, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(81, 15)
			Me.Label3.TabIndex = 404
			Me.Label3.Text = "Period From :"
			Me.ComboBox1.BackColor = Global.System.Drawing.Color.FromArgb(255, 255, 192)
			Me.ComboBox1.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.ComboBox1.FormattingEnabled = True
			Me.ComboBox1.Items.AddRange(New Object() { "Yes", "No" })
			Me.ComboBox1.Location = New Global.System.Drawing.Point(198, 136)
			Me.ComboBox1.Name = "ComboBox1"
			Me.ComboBox1.Size = New Global.System.Drawing.Size(101, 23)
			Me.ComboBox1.TabIndex = 5
			Me.TextBox2.Location = New Global.System.Drawing.Point(272, 1)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.[ReadOnly] = True
			Me.TextBox2.Size = New Global.System.Drawing.Size(13, 21)
			Me.TextBox2.TabIndex = 5
			Me.TextBox2.TabStop = False
			Me.TextBox2.Visible = False
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(17, 44)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(175, 15)
			Me.Label2.TabIndex = 4
			Me.Label2.Text = "Limit Exceeded Amount From :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.dgw.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
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
			Me.dgw.Location = New Global.System.Drawing.Point(5, 228)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.FromArgb(192, 0, 0)
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DeepPink
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(537, 66)
			Me.dgw.TabIndex = 40
			Me.dgw.TabStop = False
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Visible = False
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.Format = "d"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column2.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column2.HeaderText = "Period From"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle7.Format = "d"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column3.HeaderText = "Period To"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			dataGridViewCellStyle8.NullValue = Nothing
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column4.HeaderText = "Limited Exceeded"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle9.Format = "N3"
			dataGridViewCellStyle9.NullValue = Nothing
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column5.HeaderText = "Tax% with PAN"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle10.Format = "N3"
			dataGridViewCellStyle10.NullValue = Nothing
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column6.HeaderText = "Tax% without PAN"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column7.HeaderText = "Activate"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.ErrorProvider1.ContainerControl = Me
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(575, 323)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmTCSValidation"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			Me.Panel5.ResumeLayout(False)
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ErrorProvider1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04006201 RID: 25089
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
