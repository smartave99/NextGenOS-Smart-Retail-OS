Namespace BillPoint
	' Token: 0x02000360 RID: 864
		Public Partial Class frmProductLedgerPOS
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600CC5B RID: 52315 RVA: 0x007FCF04 File Offset: 0x007FB104
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

		' Token: 0x0600CC5C RID: 52316 RVA: 0x007FCF54 File Offset: 0x007FB154
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
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
			Dim dataGridViewCellStyle15 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.BillPoint.frmProductLedgerPOS))
			Dim dataGridViewCellStyle16 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle17 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle18 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle19 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle20 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle21 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle22 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle23 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle24 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle25 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle26 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle27 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle28 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle29 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.dgw = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.txtCustomerID = New Global.System.Windows.Forms.TextBox()
			Me.Button3 = New Global.System.Windows.Forms.Button()
			Me.TextBox1 = New Global.System.Windows.Forms.TextBox()
			Me.TextBox2 = New Global.System.Windows.Forms.TextBox()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.Button2 = New Global.System.Windows.Forms.Button()
			Me.TextBox3 = New Global.System.Windows.Forms.TextBox()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.lblBarcode = New Global.System.Windows.Forms.Label()
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.dgw.AllowUserToAddRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.dgw.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.dgw.BackgroundColor = Global.System.Drawing.Color.White
			Me.dgw.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.dgw.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.dgw.ColumnHeadersHeight = 29
			Me.dgw.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column2, Me.Column3, Me.Column12, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column13, Me.Column14, Me.Column15, Me.Column16 })
			Me.dgw.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgw.EnableHeadersVisualStyles = False
			Me.dgw.GridColor = Global.System.Drawing.Color.White
			Me.dgw.Location = New Global.System.Drawing.Point(3, 67)
			Me.dgw.MultiSelect = False
			Me.dgw.Name = "dgw"
			Me.dgw.[ReadOnly] = True
			Me.dgw.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Red
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.dgw.RowHeadersWidth = 25
			Me.dgw.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.White
			Me.dgw.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.dgw.RowTemplate.Height = 18
			Me.dgw.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgw.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgw.Size = New Global.System.Drawing.Size(630, 174)
			Me.dgw.TabIndex = 414
			Me.Column1.HeaderText = "Product Name"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			Me.Column1.Width = 200
			Me.Column2.HeaderText = "Barcode"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle6.Format = "N2"
			dataGridViewCellStyle6.NullValue = Nothing
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.HeaderText = "Purchase Rate"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			Me.Column12.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column12.HeaderText = "Purchase Rate + GST"
			Me.Column12.Name = "Column12"
			Me.Column12.[ReadOnly] = True
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle8.Format = "N2"
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column4.HeaderText = "MRP"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle9.Format = "N3"
			dataGridViewCellStyle9.NullValue = Nothing
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle9
			Me.Column5.HeaderText = "Unit"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.Visible = False
			Me.Column6.HeaderText = "Inv No"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle10.Format = "d"
			dataGridViewCellStyle10.NullValue = Nothing
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle10
			Me.Column7.HeaderText = "Inv Date"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column8.HeaderText = "Supl Inv No"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle11.Format = "d"
			dataGridViewCellStyle11.NullValue = Nothing
			Me.Column9.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column9.HeaderText = "Supl Inv Date"
			Me.Column9.Name = "Column9"
			Me.Column9.[ReadOnly] = True
			Me.Column10.HeaderText = "Supplier Name"
			Me.Column10.Name = "Column10"
			Me.Column10.[ReadOnly] = True
			Me.Column10.Width = 200
			Me.Column11.HeaderText = "State"
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Column11.Width = 130
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle12.NullValue = Nothing
			Me.Column13.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column13.HeaderText = "CGST%"
			Me.Column13.Name = "Column13"
			Me.Column13.[ReadOnly] = True
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column14.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column14.HeaderText = "SGST%"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			dataGridViewCellStyle14.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column15.DefaultCellStyle = dataGridViewCellStyle14
			Me.Column15.HeaderText = "IGST%"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			dataGridViewCellStyle15.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column16.DefaultCellStyle = dataGridViewCellStyle15
			Me.Column16.HeaderText = "CESS%"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Label1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Top
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.White
			Me.Label1.Location = New Global.System.Drawing.Point(0, 0)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(635, 32)
			Me.Label1.TabIndex = 416
			Me.Label1.Text = "Product Dash Board"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.txtCustomerID.Location = New Global.System.Drawing.Point(420, 8)
			Me.txtCustomerID.Name = "txtCustomerID"
			Me.txtCustomerID.[ReadOnly] = True
			Me.txtCustomerID.Size = New Global.System.Drawing.Size(21, 20)
			Me.txtCustomerID.TabIndex = 415
			Me.txtCustomerID.TabStop = False
			Me.txtCustomerID.Visible = False
			Me.Button3.BackColor = Global.System.Drawing.Color.White
			Me.Button3.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button3.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Button3.Image = CType(componentResourceManager.GetObject("Button3.Image"), Global.System.Drawing.Image)
			Me.Button3.Location = New Global.System.Drawing.Point(603, 1)
			Me.Button3.Name = "Button3"
			Me.Button3.Size = New Global.System.Drawing.Size(31, 31)
			Me.Button3.TabIndex = 417
			Me.Button3.TabStop = False
			Me.Button3.UseVisualStyleBackColor = False
			Me.Button3.Visible = False
			Me.TextBox1.Location = New Global.System.Drawing.Point(154, 469)
			Me.TextBox1.Name = "TextBox1"
			Me.TextBox1.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox1.TabIndex = 418
			Me.TextBox1.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.TextBox2.Location = New Global.System.Drawing.Point(236, 469)
			Me.TextBox2.Name = "TextBox2"
			Me.TextBox2.Size = New Global.System.Drawing.Size(58, 20)
			Me.TextBox2.TabIndex = 419
			Me.TextBox2.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label2.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label2.Location = New Global.System.Drawing.Point(1, 465)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(150, 32)
			Me.Label2.TabIndex = 420
			Me.Label2.Text = "Search the Purchase / Sale Rate from :"
			Me.Label3.AutoSize = True
			Me.Label3.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label3.Location = New Global.System.Drawing.Point(216, 472)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(16, 13)
			Me.Label3.TabIndex = 421
			Me.Label3.Text = "to"
			Me.Button1.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button1.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button1.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button1.ForeColor = Global.System.Drawing.Color.White
			Me.Button1.Location = New Global.System.Drawing.Point(300, 466)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button1.TabIndex = 422
			Me.Button1.Text = "Search"
			Me.Button1.UseVisualStyleBackColor = False
			Me.Button2.BackColor = Global.System.Drawing.Color.FromArgb(45, 63, 83)
			Me.Button2.BackgroundImageLayout = Global.System.Windows.Forms.ImageLayout.Stretch
			Me.Button2.Cursor = Global.System.Windows.Forms.Cursors.Hand
			Me.Button2.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Button2.ForeColor = Global.System.Drawing.Color.White
			Me.Button2.Location = New Global.System.Drawing.Point(381, 466)
			Me.Button2.Name = "Button2"
			Me.Button2.Size = New Global.System.Drawing.Size(75, 23)
			Me.Button2.TabIndex = 423
			Me.Button2.Text = "Reset"
			Me.Button2.UseVisualStyleBackColor = False
			Me.TextBox3.Location = New Global.System.Drawing.Point(543, 469)
			Me.TextBox3.Name = "TextBox3"
			Me.TextBox3.Size = New Global.System.Drawing.Size(43, 20)
			Me.TextBox3.TabIndex = 424
			Me.TextBox3.TabStop = False
			Me.TextBox3.Text = "8"
			Me.TextBox3.TextAlign = Global.System.Windows.Forms.HorizontalAlignment.Center
			Me.Label4.AutoSize = True
			Me.Label4.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label4.Location = New Global.System.Drawing.Point(514, 472)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(26, 13)
			Me.Label4.TabIndex = 425
			Me.Label4.Text = "Top"
			Me.Label5.AutoSize = True
			Me.Label5.ForeColor = Global.System.Drawing.Color.Navy
			Me.Label5.Location = New Global.System.Drawing.Point(586, 472)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(47, 13)
			Me.Label5.TabIndex = 426
			Me.Label5.Text = "Records"
			Me.DataGridView1.AllowUserToAddRows = False
			dataGridViewCellStyle16.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.CellBorderStyle = Global.System.Windows.Forms.DataGridViewCellBorderStyle.Raised
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle17.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle17.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle17.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle17.SelectionBackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle17.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle17.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17
			Me.DataGridView1.ColumnHeadersHeight = 29
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle18.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle18.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle18.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle18.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle18.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle18.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle18
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(3, 276)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle19.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle19.BackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle19.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle19.SelectionBackColor = Global.System.Drawing.Color.DarkViolet
			dataGridViewCellStyle19.SelectionForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle19.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle19
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle20.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle20.Font = New Global.System.Drawing.Font("Tahoma", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle20.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle20.SelectionBackColor = Global.System.Drawing.Color.DarkSlateGray
			dataGridViewCellStyle20.SelectionForeColor = Global.System.Drawing.Color.White
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle20
			Me.DataGridView1.RowTemplate.Height = 18
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(630, 174)
			Me.DataGridView1.TabIndex = 427
			Me.DataGridViewTextBoxColumn1.HeaderText = "Product Name"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn1.Width = 200
			Me.DataGridViewTextBoxColumn2.HeaderText = "Barcode"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.[ReadOnly] = True
			dataGridViewCellStyle21.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle21.Format = "N2"
			dataGridViewCellStyle21.NullValue = Nothing
			Me.DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle21
			Me.DataGridViewTextBoxColumn3.HeaderText = "Sales Rate"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.[ReadOnly] = True
			dataGridViewCellStyle22.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle22.Format = "N2"
			Me.DataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle22
			Me.DataGridViewTextBoxColumn4.HeaderText = "Sales Rate + GST"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.[ReadOnly] = True
			dataGridViewCellStyle23.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle23.Format = "N2"
			Me.DataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle23
			Me.DataGridViewTextBoxColumn5.HeaderText = "MRP"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			dataGridViewCellStyle24.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle24.Format = "N3"
			dataGridViewCellStyle24.NullValue = Nothing
			Me.DataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle24
			Me.DataGridViewTextBoxColumn6.HeaderText = "Unit"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn6.Visible = False
			Me.DataGridViewTextBoxColumn7.HeaderText = "Inv No"
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			dataGridViewCellStyle25.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle25.Format = "d"
			dataGridViewCellStyle25.NullValue = Nothing
			Me.DataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle25
			Me.DataGridViewTextBoxColumn8.HeaderText = "Inv Date"
			Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
			Me.DataGridViewTextBoxColumn8.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn11.HeaderText = "Customer Name"
			Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
			Me.DataGridViewTextBoxColumn11.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn11.Width = 200
			Me.DataGridViewTextBoxColumn12.HeaderText = "State"
			Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
			Me.DataGridViewTextBoxColumn12.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn12.Width = 130
			dataGridViewCellStyle26.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle26.NullValue = Nothing
			Me.DataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle26
			Me.DataGridViewTextBoxColumn13.HeaderText = "CGST%"
			Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
			Me.DataGridViewTextBoxColumn13.[ReadOnly] = True
			dataGridViewCellStyle27.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle27
			Me.DataGridViewTextBoxColumn14.HeaderText = "SGST%"
			Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
			Me.DataGridViewTextBoxColumn14.[ReadOnly] = True
			dataGridViewCellStyle28.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle28
			Me.DataGridViewTextBoxColumn15.HeaderText = "IGST%"
			Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
			Me.DataGridViewTextBoxColumn15.[ReadOnly] = True
			dataGridViewCellStyle29.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle29
			Me.DataGridViewTextBoxColumn16.HeaderText = "CESS%"
			Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
			Me.DataGridViewTextBoxColumn16.[ReadOnly] = True
			Me.Label6.AutoSize = True
			Me.Label6.BackColor = Global.System.Drawing.Color.Red
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(4, 44)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(147, 20)
			Me.Label6.TabIndex = 428
			Me.Label6.Text = "Purchase Record"
			Me.Label6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Label7.BackColor = Global.System.Drawing.Color.DarkViolet
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(4, 254)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(147, 20)
			Me.Label7.TabIndex = 429
			Me.Label7.Text = "Sales Record"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lblBarcode.AutoSize = True
			Me.lblBarcode.Location = New Global.System.Drawing.Point(547, 44)
			Me.lblBarcode.Name = "lblBarcode"
			Me.lblBarcode.Size = New Global.System.Drawing.Size(57, 13)
			Me.lblBarcode.TabIndex = 430
			Me.lblBarcode.Text = "lblBarcode"
			Me.lblBarcode.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.Gold
			MyBase.ClientSize = New Global.System.Drawing.Size(635, 493)
			MyBase.Controls.Add(Me.lblBarcode)
			MyBase.Controls.Add(Me.Label7)
			MyBase.Controls.Add(Me.Label6)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.Label5)
			MyBase.Controls.Add(Me.Label4)
			MyBase.Controls.Add(Me.TextBox3)
			MyBase.Controls.Add(Me.Button2)
			MyBase.Controls.Add(Me.Button1)
			MyBase.Controls.Add(Me.Label3)
			MyBase.Controls.Add(Me.Label2)
			MyBase.Controls.Add(Me.TextBox2)
			MyBase.Controls.Add(Me.TextBox1)
			MyBase.Controls.Add(Me.dgw)
			MyBase.Controls.Add(Me.Button3)
			MyBase.Controls.Add(Me.Label1)
			MyBase.Controls.Add(Me.txtCustomerID)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.KeyPreview = True
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "frmProductLedgerPOS"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmProductLedgerPOS"
			CType(Me.dgw, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
			MyBase.PerformLayout()
		End Sub

		' Token: 0x040051FB RID: 20987
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
