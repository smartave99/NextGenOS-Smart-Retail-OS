Namespace BillPoint
	' Token: 0x02000068 RID: 104
		Public Partial Class Form3
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600132A RID: 4906 RVA: 0x000D1A98 File Offset: 0x000CFC98
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

		' Token: 0x0600132B RID: 4907 RVA: 0x000D1AE8 File Offset: 0x000CFCE8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label4 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label7 = New Global.System.Windows.Forms.Label()
			Me.Label8 = New Global.System.Windows.Forms.Label()
			Me.Label9 = New Global.System.Windows.Forms.Label()
			Me.Label10 = New Global.System.Windows.Forms.Label()
			Me.Label11 = New Global.System.Windows.Forms.Label()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.Label13 = New Global.System.Windows.Forms.Label()
			Me.Label14 = New Global.System.Windows.Forms.Label()
			Me.TableLayoutPanel1 = New Global.System.Windows.Forms.TableLayoutPanel()
			Me.Label15 = New Global.System.Windows.Forms.Label()
			Me.Label16 = New Global.System.Windows.Forms.Label()
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.Label17 = New Global.System.Windows.Forms.Label()
			Me.DataGridView1 = New Global.System.Windows.Forms.DataGridView()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Panel1 = New Global.System.Windows.Forms.Panel()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.lblGT = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.TableLayoutPanel1.SuspendLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Panel1.SuspendLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.Label1.AutoSize = True
			Me.Label1.BackColor = Global.System.Drawing.Color.Yellow
			Me.Label1.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label1.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 21.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label1.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label1.Location = New Global.System.Drawing.Point(880, 39)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(206, 37)
			Me.Label1.TabIndex = 410
			Me.Label1.Text = "Label1"
			Me.Label1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label2.AutoSize = True
			Me.Label2.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label2.ForeColor = Global.System.Drawing.Color.White
			Me.Label2.Location = New Global.System.Drawing.Point(4, 1)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(114, 37)
			Me.Label2.TabIndex = 411
			Me.Label2.Text = "TOTAL ITEM"
			Me.Label2.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label3.AutoSize = True
			Me.Label3.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label3.ForeColor = Global.System.Drawing.Color.White
			Me.Label3.Location = New Global.System.Drawing.Point(427, 1)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label3.TabIndex = 412
			Me.Label3.Text = "BILL SUNDRY"
			Me.Label3.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label4.AutoSize = True
			Me.Label4.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label4.ForeColor = Global.System.Drawing.Color.White
			Me.Label4.Location = New Global.System.Drawing.Point(125, 1)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label4.TabIndex = 413
			Me.Label4.Text = "TAXABLE AMT"
			Me.Label4.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label5.AutoSize = True
			Me.Label5.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label5.ForeColor = Global.System.Drawing.Color.White
			Me.Label5.Location = New Global.System.Drawing.Point(276, 1)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label5.TabIndex = 414
			Me.Label5.Text = "TAX AMT"
			Me.Label5.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label6.AutoSize = True
			Me.Label6.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label6.ForeColor = Global.System.Drawing.Color.White
			Me.Label6.Location = New Global.System.Drawing.Point(578, 1)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label6.TabIndex = 415
			Me.Label6.Text = "BILL DISCOUNT"
			Me.Label6.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label7.AutoSize = True
			Me.Label7.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label7.ForeColor = Global.System.Drawing.Color.White
			Me.Label7.Location = New Global.System.Drawing.Point(729, 1)
			Me.Label7.Name = "Label7"
			Me.Label7.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label7.TabIndex = 416
			Me.Label7.Text = "ROUNDOFF"
			Me.Label7.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label8.AutoSize = True
			Me.Label8.BorderStyle = Global.System.Windows.Forms.BorderStyle.FixedSingle
			Me.Label8.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label8.ForeColor = Global.System.Drawing.Color.White
			Me.Label8.Location = New Global.System.Drawing.Point(880, 1)
			Me.Label8.Name = "Label8"
			Me.Label8.Size = New Global.System.Drawing.Size(206, 37)
			Me.Label8.TabIndex = 417
			Me.Label8.Text = "TOTAL BILL AMOUNT"
			Me.Label8.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label9.AutoSize = True
			Me.Label9.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label9.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label9.ForeColor = Global.System.Drawing.Color.SpringGreen
			Me.Label9.Location = New Global.System.Drawing.Point(4, 39)
			Me.Label9.Name = "Label9"
			Me.Label9.Size = New Global.System.Drawing.Size(114, 37)
			Me.Label9.TabIndex = 418
			Me.Label9.Text = "Label9"
			Me.Label9.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label10.AutoSize = True
			Me.Label10.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label10.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label10.ForeColor = Global.System.Drawing.Color.Gold
			Me.Label10.Location = New Global.System.Drawing.Point(125, 39)
			Me.Label10.Name = "Label10"
			Me.Label10.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label10.TabIndex = 419
			Me.Label10.Text = "Label10"
			Me.Label10.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label11.AutoSize = True
			Me.Label11.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label11.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label11.ForeColor = Global.System.Drawing.Color.Gold
			Me.Label11.Location = New Global.System.Drawing.Point(276, 39)
			Me.Label11.Name = "Label11"
			Me.Label11.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label11.TabIndex = 420
			Me.Label11.Text = "Label11"
			Me.Label11.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label12.AutoSize = True
			Me.Label12.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label12.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label12.ForeColor = Global.System.Drawing.Color.Gold
			Me.Label12.Location = New Global.System.Drawing.Point(427, 39)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label12.TabIndex = 421
			Me.Label12.Text = "Label12"
			Me.Label12.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label13.AutoSize = True
			Me.Label13.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label13.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label13.ForeColor = Global.System.Drawing.Color.Pink
			Me.Label13.Location = New Global.System.Drawing.Point(578, 39)
			Me.Label13.Name = "Label13"
			Me.Label13.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label13.TabIndex = 422
			Me.Label13.Text = "Label13"
			Me.Label13.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label14.AutoSize = True
			Me.Label14.Dock = Global.System.Windows.Forms.DockStyle.Fill
			Me.Label14.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 15.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label14.ForeColor = Global.System.Drawing.Color.Pink
			Me.Label14.Location = New Global.System.Drawing.Point(729, 39)
			Me.Label14.Name = "Label14"
			Me.Label14.Size = New Global.System.Drawing.Size(144, 37)
			Me.Label14.TabIndex = 423
			Me.Label14.Text = "Label14"
			Me.Label14.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.TableLayoutPanel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.TableLayoutPanel1.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			Me.TableLayoutPanel1.CellBorderStyle = Global.System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
			Me.TableLayoutPanel1.ColumnCount = 7
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 120F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 150F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 150F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 150F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 150F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 150F))
			Me.TableLayoutPanel1.ColumnStyles.Add(New Global.System.Windows.Forms.ColumnStyle(Global.System.Windows.Forms.SizeType.Absolute, 212F))
			Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label8, 6, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label1, 6, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label14, 5, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label13, 4, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label7, 5, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label12, 3, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label10, 1, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label6, 4, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label11, 2, 1)
			Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
			Me.TableLayoutPanel1.Controls.Add(Me.Label3, 3, 0)
			Me.TableLayoutPanel1.Location = New Global.System.Drawing.Point(1, 393)
			Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
			Me.TableLayoutPanel1.RowCount = 2
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.RowStyles.Add(New Global.System.Windows.Forms.RowStyle(Global.System.Windows.Forms.SizeType.Percent, 50F))
			Me.TableLayoutPanel1.Size = New Global.System.Drawing.Size(1082, 77)
			Me.TableLayoutPanel1.TabIndex = 424
			Me.Label15.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label15.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.Label15.Font = New Global.System.Drawing.Font("Impact", 36F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label15.ForeColor = Global.System.Drawing.Color.Indigo
			Me.Label15.Location = New Global.System.Drawing.Point(1, 9)
			Me.Label15.Name = "Label15"
			Me.Label15.Size = New Global.System.Drawing.Size(1079, 65)
			Me.Label15.TabIndex = 425
			Me.Label15.Text = "Label15"
			Me.Label15.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label16.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label16.ForeColor = Global.System.Drawing.Color.Magenta
			Me.Label16.Location = New Global.System.Drawing.Point(686, 87)
			Me.Label16.Name = "Label16"
			Me.Label16.Size = New Global.System.Drawing.Size(394, 23)
			Me.Label16.TabIndex = 426
			Me.Label16.Text = "Label16"
			Me.Label16.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.Timer1.Enabled = True
			Me.Label17.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Label17.Font = New Global.System.Drawing.Font("Arial Black", 21.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label17.ForeColor = Global.System.Drawing.Color.OrangeRed
			Me.Label17.Location = New Global.System.Drawing.Point(1, 76)
			Me.Label17.Name = "Label17"
			Me.Label17.Size = New Global.System.Drawing.Size(1082, 41)
			Me.Label17.TabIndex = 427
			Me.Label17.Text = "POINT OF SALE"
			Me.Label17.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.DataGridView1.AllowUserToAddRows = False
			Me.DataGridView1.AllowUserToDeleteRows = False
			dataGridViewCellStyle.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle
			Me.DataGridView1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.DataGridView1.AutoSizeColumnsMode = Global.System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
			Me.DataGridView1.AutoSizeRowsMode = Global.System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
			Me.DataGridView1.BackgroundColor = Global.System.Drawing.Color.White
			Me.DataGridView1.ColumnHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.Color.FromArgb(24, 112, 148)
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2
			Me.DataGridView1.ColumnHeadersHeight = 24
			Me.DataGridView1.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column1, Me.Column3, Me.Column11 })
			Me.DataGridView1.Cursor = Global.System.Windows.Forms.Cursors.Hand
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Highlight
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3
			Me.DataGridView1.EnableHeadersVisualStyles = False
			Me.DataGridView1.GridColor = Global.System.Drawing.Color.White
			Me.DataGridView1.Location = New Global.System.Drawing.Point(1, 120)
			Me.DataGridView1.MultiSelect = False
			Me.DataGridView1.Name = "DataGridView1"
			Me.DataGridView1.[ReadOnly] = True
			Me.DataGridView1.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.Color.LightSeaGreen
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.WindowText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.Color.Orange
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.HighlightText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[True]
			Me.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4
			Me.DataGridView1.RowHeadersVisible = False
			Me.DataGridView1.RowHeadersWidth = 25
			Me.DataGridView1.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.Color.White
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Tahoma", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.Color.Black
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.Color.Moccasin
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.Color.Black
			Me.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5
			Me.DataGridView1.RowTemplate.Height = 45
			Me.DataGridView1.RowTemplate.Resizable = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.DataGridView1.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.DataGridView1.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.DataGridView1.Size = New Global.System.Drawing.Size(839, 271)
			Me.DataGridView1.TabIndex = 428
			Me.Column1.FillWeight = 170.6349F
			Me.Column1.HeaderText = "Item Name"
			Me.Column1.Name = "Column1"
			Me.Column1.[ReadOnly] = True
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
			Me.Column3.DefaultCellStyle = dataGridViewCellStyle6
			Me.Column3.FillWeight = 48.04989F
			Me.Column3.HeaderText = "Qty."
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			dataGridViewCellStyle7.Format = "N2"
			dataGridViewCellStyle7.NullValue = Nothing
			Me.Column11.DefaultCellStyle = dataGridViewCellStyle7
			Me.Column11.FillWeight = 81.3152F
			Me.Column11.HeaderText = "Total Amt."
			Me.Column11.Name = "Column11"
			Me.Column11.[ReadOnly] = True
			Me.Panel1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.Panel1.Controls.Add(Me.Label18)
			Me.Panel1.Controls.Add(Me.lblGT)
			Me.Panel1.Controls.Add(Me.PictureBox1)
			Me.Panel1.Location = New Global.System.Drawing.Point(855, 120)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New Global.System.Drawing.Size(225, 258)
			Me.Panel1.TabIndex = 430
			Me.Label18.BackColor = Global.System.Drawing.Color.Yellow
			Me.Label18.Dock = Global.System.Windows.Forms.DockStyle.Bottom
			Me.Label18.Font = New Global.System.Drawing.Font("Arial Rounded MT Bold", 21.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Label18.ForeColor = Global.System.Drawing.Color.FromArgb(0, 0, 64)
			Me.Label18.Location = New Global.System.Drawing.Point(0, 225)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(225, 33)
			Me.Label18.TabIndex = 471
			Me.Label18.Text = "Label18"
			Me.Label18.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lblGT.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblGT.AutoSize = True
			Me.lblGT.Font = New Global.System.Drawing.Font("Segoe UI", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblGT.ForeColor = Global.System.Drawing.Color.Green
			Me.lblGT.Location = New Global.System.Drawing.Point(35, 240)
			Me.lblGT.Name = "lblGT"
			Me.lblGT.Size = New Global.System.Drawing.Size(65, 30)
			Me.lblGT.TabIndex = 470
			Me.lblGT.Text = "lblGT"
			Me.lblGT.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.PictureBox1.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.PictureBox1.Location = New Global.System.Drawing.Point(19, 17)
			Me.PictureBox1.Name = "PictureBox1"
			Me.PictureBox1.Size = New Global.System.Drawing.Size(184, 188)
			Me.PictureBox1.TabIndex = 429
			Me.PictureBox1.TabStop = False
			Me.PictureBox1.Visible = False
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			MyBase.ClientSize = New Global.System.Drawing.Size(1084, 474)
			MyBase.Controls.Add(Me.Panel1)
			MyBase.Controls.Add(Me.DataGridView1)
			MyBase.Controls.Add(Me.Label16)
			MyBase.Controls.Add(Me.Label15)
			MyBase.Controls.Add(Me.TableLayoutPanel1)
			MyBase.Controls.Add(Me.Label17)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.None
			MyBase.Name = "Form3"
			MyBase.ShowIcon = False
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Form3"
			MyBase.WindowState = Global.System.Windows.Forms.FormWindowState.Maximized
			Me.TableLayoutPanel1.ResumeLayout(False)
			Me.TableLayoutPanel1.PerformLayout()
			CType(Me.DataGridView1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Panel1.ResumeLayout(False)
			Me.Panel1.PerformLayout()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x04000625 RID: 1573
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
