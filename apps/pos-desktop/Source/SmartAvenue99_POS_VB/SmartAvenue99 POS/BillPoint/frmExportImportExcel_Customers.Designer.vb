Namespace BillPoint
	' Token: 0x020002A1 RID: 673
		Public Partial Class frmExportImportExcel_Customers
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600AC2F RID: 44079 RVA: 0x007314EC File Offset: 0x0072F6EC
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

		' Token: 0x0600AC30 RID: 44080 RVA: 0x0073153C File Offset: 0x0072F73C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmExportImportExcel_Customers))
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
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.GelButton4 = New Global.GelButtons.GelButton()
			Me.GelButton2 = New Global.GelButtons.GelButton()
			Me.GelButton1 = New Global.GelButtons.GelButton()
			Me.GelButton3 = New Global.GelButtons.GelButton()
			Me.LinkLabel1 = New Global.System.Windows.Forms.LinkLabel()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Panel4 = New Global.System.Windows.Forms.Panel()
			Me.txtCity = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Panel3 = New Global.System.Windows.Forms.Panel()
			Me.txtCustomerName = New Global.System.Windows.Forms.TextBox()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.FolderBrowserDialog1 = New Global.System.Windows.Forms.FolderBrowserDialog()
			Me.SaveFileDialog1 = New Global.System.Windows.Forms.SaveFileDialog()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column18 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column19 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column21 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column20 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column22 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column23 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column24 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column25 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column26 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column27 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column28 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel4.SuspendLayout()
			Me.Panel3.SuspendLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Panel1.BackColor = Global.System.Drawing.Color.White
			Me.Panel1.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel1.Controls.Add(Me.GelButton4)
			Me.Panel1.Controls.Add(Me.GelButton2)
			Me.Panel1.Controls.Add(Me.GelButton1)
			Me.Panel1.Controls.Add(Me.GelButton3)
			Me.Panel1.Controls.Add(Me.LinkLabel1)
			Me.Panel1.Controls.Add(Me.DataGridView1)
			Me.Panel1.Controls.Add(Me.Label1)
			Me.Panel1.Controls.Add(Me.Panel4)
			Me.Panel1.Controls.Add(Me.Panel3)
			Me.Panel1.Controls.Add(Me.dgw)
			Me.Panel1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Panel1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(1018, 636)
			Me.Panel1.TabIndex = 2
			Me.GelButton4.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton4.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton4.FlatAppearance.BorderSize = 0
			Me.GelButton4.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton4.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton4.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton4.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton4.GradientTop = Global.System.Drawing.Color.DarkGreen
			Me.GelButton4.Image = CType(componentResourceManager.GetObject("GelButton4.Image"), Global.System.Drawing.Image)
			Me.GelButton4.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton4.Location = New Global.System.Drawing.Point(801, 46)
			Me.GelButton4.Name = "GelButton4"
			Me.GelButton4.Size = New Global.System.Drawing.Size(102, 52)
			Me.GelButton4.TabIndex = 532
			Me.GelButton4.Text = "Save"
			Me.GelButton4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton4.UseVisualStyleBackColor = False
			Me.GelButton2.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton2.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton2.FlatAppearance.BorderSize = 0
			Me.GelButton2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton2.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton2.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton2.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton2.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton2.Image = CType(componentResourceManager.GetObject("GelButton2.Image"), Global.System.Drawing.Image)
			Me.GelButton2.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton2.Location = New Global.System.Drawing.Point(685, 46)
			Me.GelButton2.Name = "GelButton2"
			Me.GelButton2.Size = New Global.System.Drawing.Size(112, 52)
			Me.GelButton2.TabIndex = 531
			Me.GelButton2.Text = "&Import Excel"
			Me.GelButton2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton2.UseVisualStyleBackColor = False
			Me.GelButton1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton1.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton1.FlatAppearance.BorderSize = 0
			Me.GelButton1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton1.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton1.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton1.GradientBottom = Global.System.Drawing.Color.LimeGreen
			Me.GelButton1.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton1.Image = CType(componentResourceManager.GetObject("GelButton1.Image"), Global.System.Drawing.Image)
			Me.GelButton1.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton1.Location = New Global.System.Drawing.Point(577, 46)
			Me.GelButton1.Name = "GelButton1"
			Me.GelButton1.Size = New Global.System.Drawing.Size(102, 52)
			Me.GelButton1.TabIndex = 529
			Me.GelButton1.Text = "&Export Excel"
			Me.GelButton1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton1.UseVisualStyleBackColor = False
			Me.GelButton3.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.GelButton3.BackColor = Global.System.Drawing.Color.MediumVioletRed
			Me.GelButton3.FlatAppearance.BorderSize = 0
			Me.GelButton3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.GelButton3.Font = New Global.System.Drawing.Font("Segoe UI Semibold", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GelButton3.ForeColor = Global.System.Drawing.Color.White
			Me.GelButton3.GradientBottom = Global.System.Drawing.Color.Red
			Me.GelButton3.GradientTop = Global.System.Drawing.Color.FromArgb(255, 128, 128)
			Me.GelButton3.Image = CType(componentResourceManager.GetObject("GelButton3.Image"), Global.System.Drawing.Image)
			Me.GelButton3.ImageAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.GelButton3.Location = New Global.System.Drawing.Point(909, 46)
			Me.GelButton3.Name = "GelButton3"
			Me.GelButton3.Size = New Global.System.Drawing.Size(98, 52)
			Me.GelButton3.TabIndex = 530
			Me.GelButton3.Text = "&Reset"
			Me.GelButton3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.GelButton3.UseVisualStyleBackColor = False
			Me.LinkLabel1.AutoSize = True
			Me.LinkLabel1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.LinkLabel1.Location = New Global.System.Drawing.Point(880, 99)
			Me.LinkLabel1.Name = "LinkLabel1"
			Me.LinkLabel1.Size = New Global.System.Drawing.Size(128, 13)
			Me.LinkLabel1.TabIndex = 402
			Me.LinkLabel1.TabStop = True
			Me.LinkLabel1.Text = "Download Sample Format"
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 32
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(8, 121)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(1000, 502)
			Me.DataGridView1.TabIndex = 320
			Me.DataGridView1.Visible = False
			Me.Label1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label1.BackColor = Global.System.Drawing.Color.RoyalBlue
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(-1, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(1018, 38)
			Me.Label1.TabIndex = 315
			Me.Label1.Text = "Customers Import / Export (Excel Sheet)"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Panel4.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel4.Controls.Add(Me.txtCity)
			Me.Panel4.Controls.Add(Me.Label2)
			Me.Panel4.Location = New Global.System.Drawing.Point(228, 46)
			Me.Panel4.Name = "Panel4"
			Me.Panel4.Size = New Global.System.Drawing.Size(213, 70)
			Me.Panel4.TabIndex = 49
			Me.txtCity.BackColor = Global.System.Drawing.Color.White
			Me.txtCity.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCity.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCity.Name = "txtCity"
			Me.txtCity.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtCity.TabIndex = 13
			Me.Label2.AutoSize = True
			Me.Label2.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(82, 13)
			Me.Label2.TabIndex = 12
			Me.Label2.Text = "Search By City :"
			Me.Panel3.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Panel3.Controls.Add(Me.txtCustomerName)
			Me.Panel3.Controls.Add(Me.Label3)
			Me.Panel3.Location = New Global.System.Drawing.Point(9, 46)
			Me.Panel3.Name = "Panel3"
			Me.Panel3.Size = New Global.System.Drawing.Size(213, 70)
			Me.Panel3.TabIndex = 48
			Me.txtCustomerName.BackColor = Global.System.Drawing.Color.White
			Me.txtCustomerName.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.txtCustomerName.Location = New Global.System.Drawing.Point(13, 30)
			Me.txtCustomerName.Name = "txtCustomerName"
			Me.txtCustomerName.Size = New Global.System.Drawing.Size(183, 21)
			Me.txtCustomerName.TabIndex = 13
			Me.Label3.AutoSize = True
			Me.Label3.Location = New Global.System.Drawing.Point(10, 10)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(140, 13)
			Me.Label3.TabIndex = 12
			Me.Label3.Text = "Search By Customer Name :"
			Me.dgw.AllowUserToAddRows = False
			Me.dgw.AllowUserToDeleteRows = False
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.Color.LightSteelBlue
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6
			Me.dgw.ColumnHeadersHeight = 30
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column8, Me.Column4, Me.Column6, Me.Column7, Me.Column9, Me.Column10, Me.Column11, Me.Column16, Me.Column15, Me.Column17, Me.Column18, Me.Column19, Me.Column5, Me.Column14, Me.Column13, Me.Column21, Me.Column20, Me.Column12, Me.Column22, Me.Column23, Me.Column24, Me.Column25, Me.Column26, Me.Column27, Me.Column28 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle7
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(9, 122)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle8.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle8.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle8.SelectionBackColor = Global.System.Drawing.Color.OrangeRed
			dataGridViewCellStyle8.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle8.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle8
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle9.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle9.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle9.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle9.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle9
			Me.dgw.RowTemplate.Height = 20
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(1000, 502)
			Me.dgw.TabIndex = 43
			Me.Column1.HeaderText = "ID"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column2.HeaderText = "Customer ID"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column3.HeaderText = "Customer Name"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 150
			Me.Column8.HeaderText = "Address"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 150
			Me.Column4.HeaderText = "City"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column6.HeaderText = "State"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column7.HeaderText = "Postal Code"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column9.HeaderText = "Contact No."
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Email ID"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column11.HeaderText = "Remarks"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column16.HeaderText = "Account No."
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column15.HeaderText = "Account Name"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column17.HeaderText = "Bank"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column18.HeaderText = "Branch"
			Me.Column18.Name = "Column18"
			Me.Column18.[ReadOnly] = True
			Me.Column19.HeaderText = "IFSC Code"
			Me.Column19.Name = "Column19"
			Me.Column19.[ReadOnly] = True
			Me.Column5.HeaderText = "GSTIN/UID"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column14.HeaderText = "PAN"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column13.HeaderText = "CIN"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			Me.Column21.HeaderText = "Opening Balance Type"
			Me.Column21.Name = "Column21"
			Me.Column21.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column20.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column20.HeaderText = "Opening Balance"
			Me.Column20.Name = "Column20"
			Me.Column20.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column12.HeaderText = "TCS"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column22.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column22.HeaderText = "Credit Limit"
			Me.Column22.Name = "Column22"
			Me.Column22.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column23.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column23.HeaderText = "Limit Status"
			Me.Column23.Name = "Column23"
			Me.Column23.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column24.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column24.HeaderText = "Turn Around Day"
			Me.Column24.Name = "Column24"
			Me.Column24.[ReadOnly] = True
			Me.Column25.HeaderText = "Disc% on Item"
			Me.Column25.Name = "Column25"
			Me.Column25.[ReadOnly] = True
			Me.Column26.HeaderText = "Disc Status"
			Me.Column26.Name = "Column26"
			Me.Column26.[ReadOnly] = True
			Me.Column27.HeaderText = "Opening Loyality Type"
			Me.Column27.Name = "Column27"
			Me.Column27.[ReadOnly] = True
			Me.Column28.HeaderText = "Loyality Balance"
			Me.Column28.Name = "Column28"
			Me.Column28.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			MyBase.ClientSize = New Global.System.Drawing.Size(1018, 636)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedSingle
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.Name = "frmExportImportExcel_Customers"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel4.ResumeLayout(False)
			Me.Panel4.PerformLayout()
			Me.Panel3.ResumeLayout(False)
			Me.Panel3.PerformLayout()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400480E RID: 18446
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
